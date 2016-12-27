using EntityManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoMing.phone.Sub
{
    public partial class MingDan : System.Web.UI.Page
    {
        BaseRepository<UserInfo> bu = new BaseRepository<UserInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["shinidie"] == null)
                {
                    Page.RegisterStartupScript("", " <script language='javascript'>alert('请重新进入！');location.href='SubForm2.aspx' </script>");
                    //Response.Redirect(""); 
                }
                else
                {
                    BindUsers();
                }

                
            }
        }

        protected void BindUsers()
        {
            var eps = DynamicLinqExpressions.True<UserInfo>();
            //eps = eps.And(c => c.Id <= 532);
            eps = eps.And(c => c.Status == 1);
            //eps = eps.Or(c => c.Id == 533);
            IQueryable<UserInfo> result = bu.LoadEntities(eps);
            rptList.DataSource = result.ToDataTable();
            rptList.DataBind();
        }
    }
}