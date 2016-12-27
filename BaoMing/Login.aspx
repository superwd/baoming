<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BaoMing.Login" %>

<!DOCTYPE html>
<html>
<head lang="en">
  <meta charset="UTF-8">
  <title>山东省农产品品牌建设大会</title>
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="format-detection" content="telephone=no">
  <meta name="renderer" content="webkit">
  <meta http-equiv="Cache-Control" content="no-siteapp" />
  <link rel="alternate icon" type="image/png" href="assets/i/favicon.png">

    <link href="/Users/assets/css/amazeui.min.css" rel="stylesheet" />
  <style>
    .header {
      text-align: center;
    }
    .header h1 {
      font-size: 200%;
      color: #333;
      margin-top: 30px;
    }
    .header p {
      font-size: 14px;
    }
  </style>
</head>
<body>
<div class="header">
  <div class="am-g">
    <h1>山东省农产品品牌建设大会后台管理系统</h1>
    <!-- <p>Integrated Development Environment<br/>代码编辑，代码生成，界面设计，调试，编译</p> -->
  </div>
  <hr />
</div>
<div class="am-g">
  <div class="am-u-lg-6 am-u-md-8 am-u-sm-centered">
    <h3>登录</h3>
    <hr>
    <br>

    <form id="form1" runat="server" class="am-form">
      <label for="account">账号:</label>
    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
      <br>   
      <label for="password">密码:</label>
     <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
      <br /> 
      <div class="am-cf">
       <asp:Button ID="btnLogin" runat="server" Text="登 录" class="am-btn am-btn-primary am-btn-sm am-fl" OnClick="btnLogin_Click" />
      </div>
    </form>
    <hr>
    <p>© 2016 山东省农业厅</p>
  </div>
</div>
</body>
</html>