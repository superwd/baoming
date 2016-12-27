using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManage;
using System.Data;
using System.Collections;
using System.ComponentModel;

namespace BaoMing.Users
{
    public partial class UserList : System.Web.UI.Page
    {
        BaseRepository<UserInfo> bu = new BaseRepository<UserInfo>();
        BaoMingEntities bm = new BaoMingEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfoList();
            }
        }

        private void BindInfoList()
        {
            AspNetPager1.PageSize = 15;
            int totalRecord = 0;
            var eps = DynamicLinqExpressions.True<UserInfo>();
            eps = eps.And(c => c.Status == 0);
            IQueryable<UserInfo> result = bu.LoadPagerEntities(AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, out totalRecord, eps, true, c1 => c1.Id);
            this.AspNetPager1.RecordCount = totalRecord;
            rptList.DataSource = result;
            rptList.DataBind();

        }

        //分页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {            
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindInfoList();
        }
        protected void btnShenHe_Click(object sender, EventArgs e)
        {

            //string  result = "";

            //遍历repeater控件的itemtemplate模版  

            foreach (RepeaterItem item in rptList.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("chkInfo"); //根据控件id获得控件对象，cdDelete是checkBox控件的id  
                if (cb.Checked == true)
                {
                    //删除操作，根据id删除记录，cb.ToolTip里存放的就是记录id  
                    int Id = int.Parse(cb.ToolTip.ToString());
                    UserInfo ui = bm.UserInfo.Where(a => a.Id == Id).FirstOrDefault();                
                    ui.Status = 1;
                    bu.UpdateEntities(ui);
                }
            }
            BindInfoList();
        }

        protected void btnDaoChu_Click(object sender, EventArgs e)
        {
            var eps = DynamicLinqExpressions.True<UserInfo>();
            eps = eps.And(c => c.Status == 1);          
            IQueryable<UserInfo> result = bu.LoadEntities(eps);
            //rptList.DataSource = result.ToList();
            //rptList.DataBind();

            DataTable dt = DynamicLinqExpressions.ToDataTable<UserInfo>(result.ToList());
            getExcel(dt);
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

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindInfoList();
        }
    }
}