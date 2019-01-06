using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;

    [RoutePrefix("test")]
    public class DefaultController : ApiController
    {

        //方法一
        //需要引用 using Unity.Attributes;
        /// <summary>
        /// 属性实例化
        /// </summary>
        [Dependency]
        public ITestServices TestServices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("getTests")]
        [HttpGet]
        public List<Test> GetTests()
        {
            var result = this.TestServices.GetTests();
            return result;
        }

        [Route("getTest1")]
        [HttpGet]
        public IHttpActionResult GetTest1()
        {
            var result = this.TestServices.GetTests();
            return Json<List<Test>>(result);
        }

        [Route("addTest")]
        [HttpPost]
        public int AddTest(Test test)
        {
            var result = this.TestServices.Add(test);
            return result;
        }
        
        [Route("deleteTest")]
        [HttpPost]
        public int DeleteTest(int Id)
        {
            var result = this.TestServices.Delete(Id);
            return result;
        }

        [Route("getTestById")]
        [HttpGet]
        public IHttpActionResult GetTestById(int Id)
        {
            var result = this.TestServices.GetTestById(Id);
            return Json<List<Test>>(result);
        }

        [Route("updateTest")]
        [HttpPost]
        public int UpdateTest(Test test)
        {
            var result = this.TestServices.Update(test);
            return result;
        }

        //方法二
        //不需要引用Unity
        ITestServices _bookscarkservice = null;
        /// <summary>
        /// 构造函数注入点
        /// </summary>
        /// <param name="bookScarkService"></param>
        public DefaultController(ITestServices bookScarkService)
        {
            _bookscarkservice = bookScarkService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("getTest")]
        [HttpGet]
        public List<Test> GetTest()
        {
            var result = _bookscarkservice.GetTests();
            return result;
        }

    }
}
