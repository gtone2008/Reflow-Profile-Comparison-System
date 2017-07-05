using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SMT_Reflow_Profile_Comparison_System.Models;

namespace SMT_Reflow_Profile_Comparison_System.Controllers
{
    public class HomeController : Controller
    {
        BLL.reflow bllref = new BLL.reflow();
        // GET: Home/Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

        /// <summary>
        /// 返回前端json
        /// </summary>
        /// <returns></returns>
        public string getReport()
        {
            return  bllref.getData();

        }

        /// <summary>
        /// 上传csv
        /// </summary>
        /// <returns></returns>
        public ActionResult postFileCSV()
        {
            try
            {
                string folderPath = Server.MapPath("Uploads");
                if (!System.IO.Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var csvfile = Request.Files["file-csv"];
                string fileName = csvfile.FileName;
                string saveFile = Path.Combine(folderPath, fileName);
                csvfile.SaveAs(saveFile);
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }

        /// <summary>
        /// ajax update spec data
        /// </summary>
        /// <param name="step"></param>
        /// <param name="group"></param>
        /// <param name="line"></param>
        /// <param name="spec"></param>
        public void updateSpec(string step,string group,string line,string spec)
        {
            bllref.updateSpec(step,group,line,spec);
        }  

        /// <summary>
        /// target=1是比对数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="target"></param>
        /// <returns></returns>

        public void insertData(string data, string target)
        {
            if (target == "1")
            {
                bllref.insertDataja(data, target);
            }
            else
            {
                bllref.insertDataja(data, "0");
            }
        }


        public void setConfig(string txtT,string txtE)
        {
            bllref.setConfig(txtT, txtE);
        }

        public string  getConfig()
        {
            return bllref.getConfig();
        }
    }
}