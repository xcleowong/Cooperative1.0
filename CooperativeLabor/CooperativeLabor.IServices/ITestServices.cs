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

        /// <summary>
        /// 测试添加
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(Test test);

        /// <summary>
        /// 测试删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<Test> GetTestById(int Id);

        /// <summary>
        /// 测试修改
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(Test test);
    }
}
