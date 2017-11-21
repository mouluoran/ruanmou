using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Model.Base;
using Dal.ruanmou;
using com.Utility;
using Model.ruanmou;
using System.IO;
using System.Web;
namespace DAL.ruanmou
{
    public class PageBase : AdminPageBase
    {
        //获取当前HTTP请求的虚拟路径
        private string _pageName = "";
        public string PageName
        {
            get
            {
                if (string.IsNullOrEmpty(_pageName))
                    _pageName = Path.GetFileName(HttpContext.Current.Request.Path).ToLower();
                return _pageName;
            }
            set { _pageName = value; }
        }
    }
}
