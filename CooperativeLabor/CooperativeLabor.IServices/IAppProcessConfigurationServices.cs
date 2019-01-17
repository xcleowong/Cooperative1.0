using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    public interface IAppProcessConfigurationServices
    {
        /// <summary>
        /// 添加
        /// </summary>
        int Add(AppProcessConfiguration appProcessConfiguration);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="appProcessConfiguration"></param>
        /// <returns></returns>
        int Update(AppProcessConfiguration appProcessConfiguration);

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        IEnumerable<AppProcessConfiguration> GetAppProcess();

        /// <summary>
        /// 显示单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        AppProcessConfiguration GetAppProcessById(int Id);
    }
}
