using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.Services
{
    using CooperativeLabor.Common;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Model;
    using Dapper;
    using MySql.Data.MySqlClient;
    ///<summary>
    ///单位科室维护表
    ///</summary>
    public class DepartmentMaintenanceServices : IDepartmentMaintenanceServices
    {
        /// <summary>
        /// 添加单位科室
        /// </summary>
        /// <param name="departmentMaintenance"></param>
        /// <returns></returns>
        public int AddDepartmentMaintenance(DepartmentMaintenance departmentMaintenance)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                departmentMaintenance.ModificationTime = System.DateTime.Now;
                departmentMaintenance.EmployingUnit = departmentMaintenance.Pid.ToString();
                string sql = @"INSERT INTO departmentmaintenance(EmployingUnit,UnitDepartment,IsStart,CreationTime,ModificationTime,Pid) VALUES(@EmployingUnit,@UnitDepartment,@IsStart,@CreationTime,@ModificationTime,@Pid)";
                var result = conn.Execute(sql, departmentMaintenance);
                return result;
            }


        }

        /// <summary>
        /// 删除单位科室
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteDepartmentMaintenance(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"DELETE FROM departmentmaintenance WHERE Id=@Id";
                var result = conn.Execute(sql, new { Id });
                return result;
            }

        }

        /// <summary>
        /// 根据ID获取单位科室
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DepartmentMaintenance GetAloneDepartmentMaintenance(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"SELECT Id,EmployingUnit,UnitDepartment,IsStart,CreationTime,ModificationTime,Pid FROM departmentmaintenance WHERE Id=@Id";
                DepartmentMaintenance result = conn.Query<DepartmentMaintenance>(sql, new { Id }).FirstOrDefault();
                return result;
            }


        }

        /// <summary>
        /// 获取单位科室
        /// </summary>
        /// <returns></returns>
        public List<DepartmentMaintenance> GetDepartmentMaintenance()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"SELECT Id,EmployingUnit,UnitDepartment,IsStart,CreationTime,ModificationTime,Pid FROM departmentmaintenance ";
                var result = conn.Query<DepartmentMaintenance>(sql, null);
                return result.ToList();
            }

        }

        /// <summary>
        /// 根据PID获取单位科室
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public DepartmentMaintenance GetDepartmentMaintenancePid(int Pid)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"SELECT Id,EmployingUnit,UnitDepartment,IsStart,CreationTime,ModificationTime,Pid FROM departmentmaintenance WHERE Pid=@Pid";
                DepartmentMaintenance result = conn.Query<DepartmentMaintenance>(sql, new { Pid }).FirstOrDefault();
                return result;
            }

        }

        /// <summary>
        /// 修改单位科室
        /// </summary>
        /// <param name="departmentMaintenance"></param>
        /// <returns></returns>
        public int UpdateDepartmentMaintenance(DepartmentMaintenance departmentMaintenance)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                departmentMaintenance.ModificationTime = System.DateTime.Now;
                departmentMaintenance.EmployingUnit = departmentMaintenance.Pid.ToString();
                string sql = @"UPDATE departmentmaintenance SET  EmployingUnit=@EmployingUnit,UnitDepartment=UnitDepartment,IsStart=@IsStart,CreationTime=@CreationTime,ModificationTime=@ModificationTime,Pid=@Pid WHERE Id=@Id";
                var result = conn.Execute(sql, departmentMaintenance);
                return result;
            }

        }
    }
}
