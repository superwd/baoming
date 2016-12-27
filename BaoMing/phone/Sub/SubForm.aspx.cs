using EntityManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoMing.phone.Sub
{
    public partial class SubForm : System.Web.UI.Page
    {
        BaoMingEntities bm = new BaoMingEntities();
        BaseRepository<UserInfo> bu = new BaseRepository<UserInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("<script language='javascript'>window.history.forward(1);</script>");
                //Response.Write("<script language='javascript'>window.history.forward(1);</script>");
                if (Request.Cookies["shinidie"] != null)
                {
                    string test = Request.Cookies["shinidie"].Value;
                    //Page.RegisterStartupScript("", " <script language='javascript'>alert('请重新进入！');location.href='SubForm2.aspx' </script>");
                    Response.Redirect("Detail.aspx");
                }
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text.Trim() == "")
            {
                Page.RegisterStartupScript("", " <script language='javascript'>alert('请输入姓名！'); </script>");
                return;
            }
            if (this.txtMobile.Text.Trim().Length != 11)
            {
                Page.RegisterStartupScript("", " <script language='javascript'>alert('请输入有效的手机号码！'); </script>");
                return;
            }
            Match m = Regex.Match(this.txtMobile.Text.Trim(), "(13|15|18)\\d{9}");
            if (!m.Success)
            {
                Page.RegisterStartupScript("", " <script language='javascript'>alert('请输入有效的手机号码！'); </script>");
                return;
            }
            if (this.txtAddress.Text.Trim() == "")
            {
                Page.RegisterStartupScript("", " <script language='javascript'>alert('请输入单位！'); </script>");
                return;
            }
            string valid = this.txtSigncode.Text.Trim();
            if (Session["ValidNums"] == null)
            {
                Page.RegisterStartupScript("", " <script language='javascript'>alert('验证码失效'); </script>");
                return;
            }
            if (Session["ValidNums"].ToString().ToLower() != valid.ToLower())
            {
                Page.RegisterStartupScript("", " <script language='javascript'>alert('验证码错误'); </script>");
                return;
            }
            //var list = new List<Expression<Func<UserInfo, bool>>>();

            string username = this.txtUserName.Text.Trim().Replace(" ", "");
            string mobile = this.txtMobile.Text.Trim().Replace(" ","");
            //string sex = this.rdoList.SelectedValue;
            string address = this.txtAddress.Text.Trim();
            //string job = this.txtJob.Text.Trim();
            //string email = this.txtEmail.Text.Trim();

            //if (!string.IsNullOrEmpty(username)) list.Add(c => c.UserName == username && c => c.Mobile == mobile);
            //if (!string.IsNullOrEmpty(mobile)) list.Add(c => c.Mobile == mobile);

            ////Add more condition
            //Expression<Func<UserInfo, bool>> newsQueryTotal = null;

            //foreach (var expression in list)
            //{
            //    newsQueryTotal = expression.And(expression);
            //}

            var eps = DynamicLinqExpressions.True<UserInfo>();
            eps = eps.And(c => c.UserName.Trim() == username);
            //eps = eps.And(c => c.Status == 1);
            double call = double.Parse(mobile);
            //eps = eps.And(c => c.Mobile == call);
            IQueryable<UserInfo> result = bu.LoadEntities(eps);
            int res = result.Count();
            UserInfo newui = new UserInfo();
            if (res == 0)
            {
                DateTime dt1 = DateTime.Parse(DateTime.Now.ToShortDateString());
                DateTime dt2 = DateTime.Parse("2016-11-19");
                if (dt1 < dt2)
                {
                    UserInfo ui = new UserInfo();
                    //ui.Sex = sex;
                    ui.UserName = username;
                    ui.Address = address;
                    //ui.Job = job;
                    ui.Mobile = call;
                    //ui.Email = email;
                    ui.Status = 0;
                    newui = bu.AddEntities(ui);
                    Response.Write("<span style='font-size:100px'>等待管理员审核！</span>");
                    Response.End();
                }
                else
                {
                    Response.Write("<span style='font-size:100px'>报名已结束！</span>");
                    Response.End();
                }
            }
            else
            {
                if (result.ToDataTable().Rows[0]["Status"].ToString() == "0")
                {
                    Response.Write("<span style='font-size:100px'>等待管理员审核！</span>");
                    Response.End();
                }
                else
                {
                    Page.RegisterStartupScript("", " <script language='javascript'>alert('注册成功请登录！');location.href='SubForm2.aspx' </script>");
                    //Response.Redirect("");
                }
               
            }
        }

        protected void btnYz_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubForm2.aspx");
        }
    }
}