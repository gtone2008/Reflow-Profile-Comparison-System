using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using SMT_Reflow_Profile_Comparison_System.Models;
using System.Data;

namespace SMT_Reflow_Profile_Comparison_System.DBUtility.MySQLDAL
{
    /// <summary>
    /// 数据访问类:reflow
    /// </summary>
    public class reflow : Ireflow
    {
        public reflow() { }
        public string _connStr = ConfigurationManager.AppSettings["MySQLconn"];
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string target, string step, string group, string line)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from reflow");
            if (target == "0")
                strSql.Append(" where step='" + step + "' and `group`='" + group + "' and line='" + line + "' ");
            else
                strSql.Append(" where  `group`='" + group + "' and line='" + line + "' ");
            object obj = MySqlHelper.ExecuteScalar(this._connStr, strSql.ToString());
            //int res = 0;
            if (Convert.ToInt32(obj) == 0)
                return false;//不存在
            else
                return true;
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Models.reflow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into reflow( ");
            strSql.Append("step,`group`,line,maxTemperature,elapseTime,target1,target2 ) ");
            strSql.Append(" values (");
            strSql.Append(" '@step','@group','@line','@maxTemperature','@elapseTime','@target1','@target2') ");

            strSql.Replace("@step", model.step);
            strSql.Replace("@group", model.group);
            strSql.Replace("@line", model.line);
            strSql.Replace("@maxTemperature", model.maxTemperature);
            strSql.Replace("@elapseTime", model.elapseTime);
            strSql.Replace("@target1", model.target1);
            strSql.Replace("@target2", model.target2);

            int rows = MySqlHelper.ExecuteNonQuery(_connStr, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Models.reflow model)
        {
            string strSql;
            if (model.target == "1")
            {
                strSql = @"update reflow set target1 ='@target1',target2='@target2' where  `group`='@group' and line='@line'";
                strSql = strSql.Replace("@group", model.group);
                strSql = strSql.Replace("@line", model.line);
                strSql = strSql.Replace("@target1", model.target1);
                strSql = strSql.Replace("@target2", model.target2);
            }
            else
            {
                strSql = @"update reflow set maxTemperature='@maxTemperature',elapseTime='@elapseTime' where step='@step'  and `group`='@group' and line='@line'";
                strSql = strSql.Replace("@step", model.step);
                strSql = strSql.Replace("@group", model.group);
                strSql = strSql.Replace("@line", model.line);
                strSql = strSql.Replace("@maxTemperature", model.maxTemperature);
                strSql = strSql.Replace("@elapseTime", model.elapseTime);
            }
           
            int rows = MySqlHelper.ExecuteNonQuery(_connStr, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetData()
        {
            string strSql;
            strSql = "SELECT step, `group`, line, maxTemperature, elapseTime,target1,target2 FROM reflow order by step,`group` ";
            DataTable dt = MySqlHelper.ExecuteDataset(_connStr, strSql).Tables[0];
            return dt;
        }

        public DataTable GetTarget(Models.reflow model)
        {
            string strSql;
            strSql = "SELECT  target1, target2 FROM reflow where `group`='{0}' and line='{1}' ";
            strSql = string.Format(strSql, model.group, model.line);
            DataTable dt = MySqlHelper.ExecuteDataset(_connStr, strSql).Tables[0];
            return dt;
        }


        public bool Config(string T, string E)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update config set id=1 ");
            if(!string.IsNullOrEmpty(T))
            {
                strSql.Append(" ,txtT='"+T.Trim()+"'");
            }
            if (!string.IsNullOrEmpty(E))
            {
                strSql.Append(" ,txtE='" + E.Trim() + "'");
            }

            int rows = MySqlHelper.ExecuteNonQuery(_connStr, strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable getConfig()
        {
            string strSql;
            strSql = "SELECT  txtT, txtE FROM config  ";
            DataTable dt = MySqlHelper.ExecuteDataset(_connStr, strSql).Tables[0];
            return dt;
        }
    }
}