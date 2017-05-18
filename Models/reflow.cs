using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMT_Reflow_Profile_Comparison_System.Models
{
    /// <summary>
	/// reflow:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class reflow
    {

        #region Model
        private string _target;
        private string _step;
        private string _group;
        private string _line;
        private string _maxtemperature;
        private string _elapsetime;
        private string _target1;
        private string _target2;
        /// <summary>
        /// 
        /// </summary>
        public string target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string step
        {
            set { _step = value; }
            get { return _step; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string group
        {
            set { _group = value; }
            get { return _group; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string line
        {
            set { _line = value; }
            get { return _line; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maxTemperature
        {
            set { _maxtemperature = value; }
            get { return _maxtemperature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string elapseTime
        {
            set { _elapsetime = value; }
            get { return _elapsetime; }
        }

        public string target1
        {
            set { _target1 = value; }
            get { return _target1; }
        }

        public string target2
        {
            set { _target2 = value; }
            get { return _target2; }
        }
        #endregion Model

    }
}