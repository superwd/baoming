﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="BaoMing.Users.UserList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


  <title>山东省农产品品牌建设大会</title>
  <meta name="description" content="">
  <meta name="keywords" content="table">
  <link rel="icon" type="image/png" href="assets/i/favicon.png">
  <link rel="apple-touch-icon-precomposed" href="assets/i/app-icon72x72@2x.png">
  <link rel="stylesheet" href="assets/css/amazeui.min.css"/>
  <link rel="stylesheet" href="assets/css/admin.css">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
<!--[if lte IE 9]>
<p class="browsehappy">你正在使用<strong>过时</strong>的浏览器，系统 暂不支持。 请 <a href="http://browsehappy.com/" target="_blank">升级浏览器</a>
  以获得更好的体验！</p>
<![endif]-->

<header class="am-topbar am-topbar-inverse admin-header">
  <div class="am-topbar-brand">
    <strong>山东省农产品品牌建设大会</strong> <small>后台管理系统</small>
  </div>

  <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-success am-show-sm-only" data-am-collapse="{target: '#topbar-collapse'}"><span class="am-sr-only">导航切换</span> <span class="am-icon-bars"></span></button>

  <div class="am-collapse am-topbar-collapse" id="topbar-collapse">

    <ul class="am-nav am-nav-pills am-topbar-nav am-topbar-right admin-header-list">
      <!-- <li><a href="javascript:;"><span class="am-icon-envelope-o"></span> 收件箱 <span class="am-badge am-badge-warning">5</span></a></li> -->
      <li class="am-dropdown" data-am-dropdown>
        <a class="am-dropdown-toggle" data-am-dropdown-toggle href="javascript:;">
          <span class="am-icon-users"></span> 管理员 <span class="am-icon-caret-down"></span>
        </a>
        <ul class="am-dropdown-content">
          <li><a href="#"><span class="am-icon-user"></span> 资料</a></li>
          <li><a href="#"><span class="am-icon-cog"></span> 设置</a></li>
          <li><a href="#"><span class="am-icon-power-off"></span> 退出</a></li>
        </ul>
      </li>
      <!-- <li class="am-hide-sm-only"><a href="javascript:;" id="admin-fullscreen"><span class="am-icon-arrows-alt"></span> <span class="admin-fullText">开启全屏</span></a></li> -->
    </ul>
  </div>
</header>

<div class="am-cf admin-main">
  

  <!-- content start -->
  <div class="admin-content">
    <div class="admin-content-body">
      <div class="am-cf am-padding am-padding-bottom-0">
        <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">报名信息</strong> / <small>Registration</small></div>
      </div>

      <hr>
        <form id="form1" runat="server">
      <div class="am-g">
        <div class="am-u-sm-12 am-u-md-6">
          <div class="am-btn-toolbar">
            <div class="am-btn-group am-btn-group-xs">
              
              <%--<button type="button" class="am-btn am-btn-default"><span class="am-icon-save"></span> 导出</button>
              <button type="button" class="am-btn am-btn-default"><span class="am-icon-archive"></span> 审核</button>--%>
                <asp:Button ID="btnQuery" runat="server" Text="查询"    class="am-btn am-btn-default" OnClick="btnQuery_Click"/>
               <asp:Button ID="btnDaoChu" runat="server" Text="导出" OnClick="btnDaoChu_Click"  class="am-btn am-btn-default"/>
                <asp:Button ID="btnShenHe" runat="server" Text="审核" OnClick="btnShenHe_Click" OnClientClick="return confirm('确定此操作?')"  class="am-btn am-btn-default"/>
            </div>
          </div>
        </div>
        <%--<div class="am-u-sm-12 am-u-md-3">
          <div class="am-form-group">
            <select data-am-selected="{btnSize: 'sm'}">
              <option value="option1">筛选条件</option>
              <option value="option2">1</option>
              <option value="option3">2</option>
              <option value="option3">3</option>
              <option value="option3">4</option>
              <option value="option3">5</option>
              <option value="option3">7</option>
            </select>
          </div>
        </div>
        <div class="am-u-sm-12 am-u-md-3">
          <div class="am-input-group am-input-group-sm">
            <input type="text" class="am-form-field">
          <span class="am-input-group-btn">
            <button class="am-btn am-btn-default" type="button">搜索</button>
          </span>
          </div>
        </div>--%>
      </div>

      <div class="am-g">
        <div class="am-u-sm-12">
          
            <table class="am-table am-table-striped am-table-hover table-main">
              <thead>
              <tr>
                <th class="table-check"><input type="checkbox" /></th><th class="table-author am-hide-sm-only">姓名</th><th class="table-author am-hide-sm-only">电话</th><th class="table-date am-hide-sm-only">工作单位</th>
              </tr>
              </thead>
              <tbody>
                  <asp:Repeater ID="rptList" runat="server">
                       <ItemTemplate> 
               <tr>
                <td><asp:CheckBox ID="chkInfo" ToolTip='<%#Eval("id") %>' Text="" runat="server"/></td>  
                
              <td>
                  <%#Eval("username")%> </td>
                <td class="am-hide-sm-only"><%#Eval("mobile")%></td>
                  <td class="am-hide-sm-only"><%#Eval("Address")%></td>
               <%-- <td>
                  <div class="am-btn-toolbar">
                    <div class="am-btn-group am-btn-group-xs">
                      <button class="am-btn am-btn-default am-btn-xs am-text-secondary"><span class="am-icon-pencil-square-o"></span> 编辑</button>
                      <button class="am-btn am-btn-default am-btn-xs am-text-danger am-hide-sm-only"><span class="am-icon-trash-o"></span> 删除</button>
                    </div>
                  </div>
                </td>--%>
              </tr>
  
                           </ItemTemplate>
              </asp:Repeater>
              </tbody>
            </table>
            <div class="am-cf">
              <%--共 15 条记录--%>
                 <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center"  FirstPageText="首页" 
            LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" NumericButtonTextFormatString="{0}" Width="600px"
           ShowCustomInfoSection="Left" ShowBoxThreshold="2" PageSize="5"  InputBoxClass="text2" TextAfterInputBox="" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
              <div class="am-fr">
                <%--<ul class="am-pagination">
                  <li class="am-disabled"><a href="#">«</a></li>
                  <li class="am-active"><a href="#">1</a></li>
                  <li><a href="#">2</a></li>
                  <li><a href="#">3</a></li>
                  <li><a href="#">4</a></li>
                  <li><a href="#">5</a></li>
                  <li><a href="#">»</a></li>
                </ul>--%>
                  

              </div>
            </div>
           <%-- <hr />
            <p>注：.....</p>--%>
         
        </div>

      </div>
            </form>
    </div>
       
    <footer class="admin-content-footer">
      <hr>
      <p class="am-padding-left">© 2016 AllMobilize, Inc. Licensed under MIT license.</p>
    </footer>

  </div>
  <!-- content end -->
</div>

<a href="#" class="am-icon-btn am-icon-th-list am-show-sm-only admin-menu" data-am-offcanvas="{target: '#admin-offcanvas'}"></a>

<%--<footer>
  <hr>
  <p class="am-padding-left">© 2014 AllMobilize, Inc. Licensed under MIT license.</p>
</footer>--%>

<!--[if lt IE 9]>
<script src="http://libs.baidu.com/jquery/1.11.1/jquery.min.js"></script>
<script src="http://cdn.staticfile.org/modernizr/2.8.3/modernizr.js"></script>
<script src="assets/js/amazeui.ie8polyfill.min.js"></script>
<![endif]-->


</body>
</html>
