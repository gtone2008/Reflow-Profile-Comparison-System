using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SMT_Reflow_Profile_Comparison_System.DBUtility
{
    /// <summary>
	/// 接口层reflow
	/// </summary>
	public interface Ireflow
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string target, string step, string group, string line);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(Models.reflow model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Models.reflow model);

        /// <summary>
        /// update spec1 spec2 data
        /// </summary>
        /// <param name="step"></param>
        /// <param name="group"></param>
        /// <param name="line"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        bool UpdateSpec(string step, string group, string line, string spec);
        /// <summary>
        /// 修改config
        /// </summary>
        /// <param name="T"></param>
        /// <param name="E"></param>
        /// <returns></returns>
        bool Config(string T,string E);

        DataTable getConfig();

        /// <summary>
        /// if i=0 query all else if i=1 query target1 、target2
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        DataTable GetData();
        DataTable GetTarget(Models.reflow model);
        #endregion  成员方法

    }
}
