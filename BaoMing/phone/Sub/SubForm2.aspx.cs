using EntityManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaoMing.phone.Sub
{
    public partial class SubForm2 : System.Web.UI.Page
    {
        BaoMingEntities bm = new BaoMingEntities();
        BaseRepository<UserInfo> bu = new BaseRepository<UserInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Response.Write("<script language='javascript'>window.history.forward(1);</script>");               
                if (Request.Cookies["shinidie"] != null)
                {
                    string test = Request.Cookies["shinidie"].Value;
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
            string username = this.txtUserName.Text.Trim().Replace(" ", "");
            var eps = DynamicLinqExpressions.True<UserInfo>();
            eps = eps.And(c => c.UserName.Trim() == username);
            IQueryable<UserInfo> result = bu.LoadEntities(eps);
            int res = result.Count();
            UserInfo newui = new UserInfo();
            if (res > 0)
            {
                HttpCookie cookieUserName = new HttpCookie("shinidie");  //创建帐号的cookie实例
                cookieUserName.Value = result.ToDataTable().Rows[0]["UserName"].ToString();
                cookieUserName.Expires = new DateTime(2016, 11, 27);  //设置帐号cookie的过期时间，当前时间算往后推两天
                Response.Cookies.Add(cookieUserName);  //将创建的cookieUserName文件输入到浏览器端
                //Session["Id"] = result.ToDataTable().Rows[0]["Id"].ToString();//创建
                //Session.Timeout = 7200;//设置过期时间7200分钟
                Response.Redirect("Detail.aspx");
                //Response.Redirect("Detail.aspx");
            }
            else
            {
                Page.RegisterStartupScript("", " <script language='javascript'>alert('该姓名不存在！');location.href='SubForm2.aspx' </script>");
            }
            
        }

        protected void btnYz_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubForm.aspx");
        }

        /// <summary>
        /// DEC 加密过程
        /// </summary>
        /// <param name="pToEncrypt">被加密的字符串</param>
        /// <param name="sKey">密钥（只支持8个字节的密钥）</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            //访问数据加密标准(DES)算法的加密服务提供程序 (CSP) 版本的包装对象
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);　 //原文使用ASCIIEncoding.ASCII方法的GetBytes方法

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);//把字符串放到byte数组中

            MemoryStream ms = new MemoryStream();//创建其支持存储区为内存的流　
            //定义将数据流链接到加密转换的流
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //上面已经完成了把加密后的结果放到内存中去

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// DEC 解密过程
        /// </summary>
        /// <param name="pToDecrypt">被解密的字符串</param>
        /// <param name="sKey">密钥（只支持8个字节的密钥，同前面的加密密钥相同）</param>
        /// <returns>返回被解密的字符串</returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量，此值重要，不能修改
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //建立StringBuild对象，createDecrypt使用的是流对象，必须把解密后的文本变成流对象
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}