using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoMing
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                string UserId = txtAccount.Text.Trim();
                string UserPwd = txtPass.Text.Trim();
                string list = "";
               
                if (UserId != "" && UserPwd != "")
                {
                    //string Id = ds.Tables[0].Rows[0]["AccountId"].ToString();
                    if (UserId == "admin" && UserPwd == "123456")
                    {
                        list = "1";

                    }
                }
                else
                {
                    //用户名或密码错误！
                    Page.RegisterStartupScript("", " <script language='javascript'>alert('用户名或密码错误！'); </script>");
                    return;
                }


                //建立身份验证票对象
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, list, DateTime.Now, DateTime.Now.AddMinutes(60), false, "1");
                //加密序列化验证票为字符串
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
                HttpContext.Current.Response.Cookies.Add(userCookie);
                if (Request.QueryString["ReturnUrl"] != null)
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    //Common.WriteLog("1", "Role:" + role + "登录", "商家:" + UserId + "登录系统.成功!", (int)System.Net.IPAddress.Parse(Request.UserHostAddress).Address);
                    Response.Redirect("Users/UserList.aspx");
                }
            }
            catch (Exception ex)
            {
                //账号已冻结！请联系管理员...
                Page.RegisterStartupScript("", " <script language='javascript'>alert('登录失败，" + ex.Message + "'); </script>");
            }
        }
    }
}