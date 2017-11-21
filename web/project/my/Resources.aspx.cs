using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model.ruanmou;
using DAL.ruanmou;
namespace project
{
    public partial class Resources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfor user = UserInforDal.CurrentUser();
            if (user == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!(user.UserType == 3 || user.UserType == 5))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}