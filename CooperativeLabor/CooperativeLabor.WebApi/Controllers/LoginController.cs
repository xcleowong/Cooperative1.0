using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CooperativeLabor.Comm;
namespace CooperativeLabor.WebApi.Controllers
{
    
    using CooperativeLabor.Common;
    using CooperativeLabor.Cache;
    using Newtonsoft.Json;
    using Unity.Utility;
    using CooperativeLabor.Common.一拓云短信验证;
    using System.Collections.Specialized;
    using System.Text;
    using System.Security.Cryptography;

    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {

        //[Dependency]

        //public IUserManagementServices userManagement { get; set; }
        [Dependency]
        public IUserManagementServices iUserManagement { get; set; }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpGet]
        public UserManagement Login(string UserName, string UserPassword)
        {
            var result = this.iUserManagement.Login(UserName, UserPassword);

            CookieHelper.SetCookie("cookie_rememberme", UserName, 1);

            return result;
        }

        [Route("getusers")]
        [HttpGet]
        public object getusers(string UserName, string UserPassword)
        {
            var result = this.iUserManagement.getusers(UserName,UserPassword);
             
            return result;
        }














        /// ========================================程序配置参数区开始

        //接口生产地址(应用上线后正式环境必须使用该地址)
        //private  static String url = "http://www.etuocloud.com/gateway.action";

        //接口测试地址（未上线前测试环境使用）
        private static String url = "http://www.etuocloud.com/gatetest.action";

        //应用 app_key
        private static String APP_KEY = "tffIzqWaDtC4aNZQQ79Jjmx3EybXwcaX";
        //应用 app_secret
        private static String APP_SECRET = "Y3tGKAFfF2kSkPHkU9DyaHo3l0LZemL7KXaA11p6UqQharBWlUsO5thznLf2QlEd";

        //接口响应格式 json或xml
        private static String FORMAT = "json";

        /// ========================================程序配置参数区结束
        /// <summary>
        /// 发生短信验证码
        /// </summary>
        /// <param name="to">手机号</param>
        /// <param name="template">短信模板ID</param>
        /// <param name="smscode">验证码</param>
        /// <returns></returns>
        [Route("sendSmsCode")]
        [HttpGet]
        public  string sendSmsCode(string to, int template, string smscode)
        {

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("app_key", APP_KEY);
            parameters.Add("view", FORMAT);
            parameters.Add("method", "cn.etuo.cloud.api.sms.simple");
            parameters.Add("out_trade_no", "");//商户订单号，可空
            parameters.Add("to", to);
            parameters.Add("template", template.ToString());
            parameters.Add("smscode", smscode);
            parameters.Add("sign", getsign(parameters));
            return HttpClient.HttpPost(url, parameters);

        }
        /// <summary>
        /// 获取param签名
        /// </summary>
        /// <param name="sParams"></param>
        /// <returns></returns>
        private static string getsign(NameValueCollection parameters)
        {
            SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
            foreach (string key in parameters.Keys)
            {
                sParams.Add(key, parameters[key]);
            }

            string sign = string.Empty;
            StringBuilder codedString = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in sParams)
            {
                if (temp.Value == "" || temp.Value == null || temp.Key.ToLower() == "sign")
                {
                    continue;
                }

                if (codedString.Length > 0)
                {
                    codedString.Append("&");
                }
                codedString.Append(temp.Key.Trim());
                codedString.Append("=");
                codedString.Append(temp.Value.Trim());
            }

            // 应用key
            codedString.Append(APP_SECRET);
            string signkey = codedString.ToString();
            sign = GetMD5(signkey, "utf-8");

            return sign;
        }
        //md5
        private static string GetMD5(string encypStr, string charset)
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用XXX编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception)
            {
                inputBye = System.Text.Encoding.UTF8.GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();

            //  return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(ConvertString, "MD5").ToLower(); ;

            return retStr;
        }


        //[Route("action")]
        //[HttpPost]
        //public string action(string newNum)
        //{
        //    // var num =  Guid.NewGuid().ToString().Substring(0,6);
        //    Random rNumber = new Random();//实例化一个随机数对象
        //    string num = "";
        //    Random rNum = new Random();//随机生成类
        //    int num1 = rNum.Next(0, 9);//返回指定范围内的随机数
        //    int num2 = rNum.Next(0, 9);
        //    int num3 = rNum.Next(0, 9);
        //    int num4 = rNum.Next(0, 9);
        //    int num5 = rNum.Next(0, 9);
        //    int num6 = rNum.Next(0, 9);
        //    int[] nums = new int[6] { num1, num2, num3, num4, num5, num6 };
        //    for (int i = 0; i < nums.Length; i++)//循环添加四个随机生成数
        //    {
        //        num += nums[i].ToString();
        //    }
        //    newNum = num;
        //    Console.WriteLine(newNum);
        //    string ret = Verification.sendSmsCode("17631149904", 1, newNum);
        //    //Console.WriteLine(ret);
        //    return ret;
        //}

    }
}
