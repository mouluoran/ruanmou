﻿using DAL.ruanmou;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class TaskInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserInforDal.CurrentUser() == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}