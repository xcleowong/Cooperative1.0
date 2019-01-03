using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;

    public interface ITestServices
    {
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        List<Test> GetTests();
    }
}
