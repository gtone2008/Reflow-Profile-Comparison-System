using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using Util;

namespace SMT_Reflow_Profile_Comparison_System.DBUtility
{
    /// <summary>
	/// 抽象工厂模式创建DAL。
	/// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口) 
	/// DataCache类在导出代码的文件夹里
	/// <appSettings> 
	/// <add key="DAL" value="SMT_Reflow_Profile_Comparison_System.DBUtility.MySQLDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)(程序集名称 不是命名空间)
	/// </appSettings> 
	/// </summary>
	public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        private static readonly string path = "SMT Reflow Profile Comparison System";
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);
                    DataCache.SetCache(ClassNamespace, objType);
                }
                catch
                { }
            }
            return objType;
        }

        /// <summary>
        /// 创建reflow数据层接口。
        /// </summary>
        public static Ireflow Createreflow()
        {

            string ClassNamespace = AssemblyPath + ".reflow";
            object objType = CreateObject(path, ClassNamespace);
            return (Ireflow)objType;
        }

    }
}