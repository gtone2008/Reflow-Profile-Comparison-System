using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SMT_Reflow_Profile_Comparison_System.DBUtility;
using Util;

namespace SMT_Reflow_Profile_Comparison_System.BLL
{
    /// <summary>
	/// reflow
	/// </summary>
	public class reflow
    {
        private readonly Ireflow Idal = DataAccess.Createreflow();
        public reflow()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string target, string step, string group, string line)
        {
            return Idal.Exists(target, step, group, line);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Models.reflow model)
        {
            return Idal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Models.reflow model)
        {
            return Idal.Update(model);
        }



        /// <summary>
        /// ajax插入数据
        /// </summary>
        public void insertDataja(string data, string target)
        {
            JArray ja = (JArray)JsonConvert.DeserializeObject(data);
            //string ja1a = ja[1]["line"].ToString();
            foreach (var ja1 in ja)
            {
                Models.reflow refmodle = new Models.reflow()
                {
                    target = target,
                    step = ja1["step"].ToString(),
                    group = ja1["group"].ToString(),
                    line = ja1["line"].ToString(),
                    maxTemperature = ja1["maxTemperature"].ToString(),
                    elapseTime = ja1["elapseTime"].ToString(),
                };
                //if (target == "1")
                //{
                //    refmodle.step = "";
                //}

                if (!Exists(refmodle.target, refmodle.step, refmodle.group, refmodle.line))
                {
                    if (target == "1")
                    {
                        refmodle.target1 = refmodle.maxTemperature;
                        refmodle.target2 = refmodle.elapseTime;
                        refmodle.maxTemperature = "";
                        refmodle.elapseTime = "";
                    }
                    else
                    {
                        DataTable tb = Idal.GetTarget(refmodle);
                        refmodle.target1 = tb.Rows[0][0].ToString();
                        refmodle.target2 = tb.Rows[0][1].ToString();
                    }
                    Add(refmodle);
                }
                else
                {
                    if (target == "1")
                    {
                        refmodle.target1 = refmodle.maxTemperature;
                        refmodle.target2 = refmodle.elapseTime;
                    }
                    else
                    {
                        DataTable tb = Idal.GetTarget(refmodle);
                        refmodle.target1 = tb.Rows[0][0].ToString();
                        refmodle.target2 = tb.Rows[0][1].ToString();
                    }
                        Update(refmodle);
                }
            }
        }

        /// <summary>
        /// 查询所有转json字符串
        /// </summary>
        /// <returns></returns>
        public string getData()
        {
            DataTable dt = Idal.GetData();
            return JsonHelper.ToJson(dt);
        }

        public void setConfig(string T,string E)
        {
            Idal.Config(T,E);
            DataCache.DelCache("jsonConfig");
        }

        public string getConfig()
        {         
            object objType = DataCache.GetCache("jsonConfig");
            if (objType == null)
            {
                try
                {
                    DataTable dt = Idal.getConfig();
                    objType = JsonHelper.ToJson(dt);
                    DataCache.SetCache("jsonConfig", objType);
                }
                catch
                { }
            }
            return objType.ToString();
        }

        #endregion  ExtensionMethod
    }
}
