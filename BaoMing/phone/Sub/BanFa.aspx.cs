using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoMing.phone.Sub
{
    public partial class BanFa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["shinidie"] == null)
                {
                    Page.RegisterStartupScript("", " <script language='javascript'>alert('请重新进入！');location.href='SubForm2.aspx' </script>");
                    //Response.Redirect(""); 
                }
            }
        }
    }
}