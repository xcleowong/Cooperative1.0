using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    //注意NPOI 引入这个命名空间
    //Excel >>WorkBook>>WorkSheet>>Row>>Cell
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using System.Text;
    //using CooperativeLabor.WebApi;
    using System.IO;
    using CooperativeLabor.Model;
    using CooperativeLabor.Services;
    public class AllowancesViewController : Controller
    {
        AllowancesServices allowancesServices = new AllowancesServices();
        // GET: AllowancesView
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加补助标准界面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAllowancesView()
        {
            return View();
        }

        /// <summary>
        /// 显示补助标准标准界面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllowancesView()
        {
            return View();
        }

        /// <summary>
        /// 修改补助标准界面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateAllowancesView()
        {
            return View();
        }

        /// <summary>
        /// 导入Excel
        /// </summary>
        public void ImportExcel()
        {
            HttpPostedFileBase fileBase = Request.Files["fielName"];
            HSSFWorkbook workBook = new HSSFWorkbook(fileBase.InputStream);
            ISheet sheet = workBook.GetSheetAt(0);
            // sheet.FirstRowNum; 找到相应的工作表的第一行
            //  sheet.LastRowNum;   找到相应的工作表的最后一行
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            for (int i = sheet.FirstRowNum; i < sheet.LastRowNum; i++)
            {


                IRow row = sheet.GetRow(i);
                sb.Append("<tr>");
                //获取表格的列数
                int CellsCount = row.Cells.Count;
                for (int j = 0; j < CellsCount; j++)
                {
                    ICell cell = row.GetCell(j);
                    if (cell != null)
                    {
                        //HTTPClient
                        string getCellValue = cell.StringCellValue + "";
                        sb.Append("<td>" + getCellValue + "</td>");
                    }
                }
                sb.Append("</tr>");

            }
            sb.Append("</table>");
            Response.Write(sb.ToString());
        }

        //[HttpGet]
        public ActionResult Export()
        {
            List<Allowances> listGA = allowancesServices.GetAllowances().ToList();
            //Excel 中工作簿
            HSSFWorkbook workBook = new HSSFWorkbook();
            //工作表
            ISheet sheet = workBook.CreateSheet("补助标准配置");
            IRow row0 = sheet.CreateRow(0);
            ICell cell0 = row0.CreateCell(0);
            cell0.SetCellValue("主键");
            ICell cell1 = row0.CreateCell(1);
            cell1.SetCellValue("平日工作补助");
            ICell cell2 = row0.CreateCell(2);
            cell2.SetCellValue("出差补助");
            ICell cell3 = row0.CreateCell(3);
            cell3.SetCellValue("公休节假日加班");
            ICell cell4 = row0.CreateCell(4);
            cell4.SetCellValue("公休节假日休息");
            ICell cell5 = row0.CreateCell(5);
            cell5.SetCellValue("每日餐补");
            ICell cell6 = row0.CreateCell(6);
            cell6.SetCellValue("发布时间");
            ICell cell7 = row0.CreateCell(7);
            cell7.SetCellValue("发布时间");
            //PageNumber pageNumber = new PageNumber();
            //pageNumber.DataCount = listGA.Count;
            //pageNumber.CurrentPage = Convert.ToInt32(pageIndex);
            //pageNumber.TotlePage = (listGA.Count / PAGESIZE) + (listGA.Count % PAGESIZE == 0 ? 0 : 1);
            //pageNumber.Data = listGA.Skip((Convert.ToInt32(pageIndex) - 1) * PAGESIZE).Take(PAGESIZE);
            //return pageNumber;
            for (int i = 1; i <= listGA.Count; i++)
            {
                //创建行
                IRow row = sheet.CreateRow(i);
                ICell ic0 = row.CreateCell(0);
                ic0.SetCellValue(listGA[i - 1].Id);
                ICell ic1 = row.CreateCell(1);
                ic1.SetCellValue(listGA[i - 1].EvectionSubsidy);
                ICell ic2 = row.CreateCell(2);
                ic2.SetCellValue(listGA[i - 1].HolidaysOverTime);
                ICell ic3 = row.CreateCell(3);
                ic3.SetCellValue(listGA[i - 1].HolidaysRest);
                ICell ic4 = row.CreateCell(4);
                ic4.SetCellValue(listGA[i - 1].ExchangeSubsidy);
                ICell ic5 = row.CreateCell(5);
                ic5.SetCellValue(listGA[i - 1].MealSubsidy);
                ICell ic6 = row.CreateCell(6);
                ic6.SetCellValue(listGA[i - 1].ReleaseTime);
                ICell ic7 = row.CreateCell(7);
                ic7.SetCellValue(listGA[i - 1].ModificationTime);
                ICell ic8 = row.CreateCell(8);
                ic8.SetCellValue(listGA[i - 1].WeekDaysSubsidy);
            }
            MemoryStream ms = new MemoryStream();
            workBook.Write(ms);
            //把读取的数据的指针，调整到第一条
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/octet-stream", "Allowances.xls");

        }




    }



}
