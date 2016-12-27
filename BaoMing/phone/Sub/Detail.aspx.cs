using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManage;
using System.Data;

namespace BaoMing.phone.Sub
{
    public partial class Detail : System.Web.UI.Page
    {
        BaoMingEntities bm = new BaoMingEntities();
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

            }
        }

        protected void lbBtn_Click(object sender, EventArgs e)
        {
            //var eps = DynamicLinqExpressions.True<UserInfo>();
            //eps = eps.And(c => c.Status == 1);
            //IQueryable<UserInfo> result = bu.LoadEntities(eps);
            ////rptList.DataSource = result.ToList();
            ////rptList.DataBind();

            //DataTable dt = DynamicLinqExpressions.ToDataTable<UserInfo>(result.ToList());
            //getExcel(dt);
            Response.Redirect("MingDan.aspx");
        }

        protected void getExcel(DataTable dt)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("报名列表");
            NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{

            //}

            row.CreateCell(1).SetCellValue("城市");
            row.CreateCell(2).SetCellValue("姓名");
            row.CreateCell(3).SetCellValue("性别");
            row.CreateCell(4).SetCellValue("单位");
            row.CreateCell(5).SetCellValue("职务");
            row.CreateCell(6).SetCellValue("电话");
            row.CreateCell(7).SetCellValue("邮箱");
            row.CreateCell(8).SetCellValue("备注");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                for (int j = 1; j < dt.Columns.Count - 1; j++)
                    row2.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
            }


            //写入到客户端  
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            book.Write(ms);
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=报名列表.xls"));
            Response.BinaryWrite(ms.ToArray());
            book = null;
            ms.Close();
            ms.Dispose();

        }

        protected void lbGl_Click(object sender, EventArgs e)
        {
            Response.Redirect("BanFa.aspx");
        }
    }
}