<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MingDan.aspx.cs" Inherits="BaoMing.phone.Sub.MingDan" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">
        <meta name="format-detection" content="telephone=no">
        <title>参会名单</title>
        <script type="text/javascript" src="http://tajs.qq.com/stats?sId=37342703" charset="UTF-8"></script>
        <link rel="stylesheet" href="../css/frozen.css">
        <link rel="stylesheet" href="css.css">
    </head>
    
    <body ontouchstart>
        <header class="ui-header ui-header-positive ui-border-b">
            <i class="ui-icon-return" onclick="history.back()"></i>
            <h1>参会名单</h1>
            <!-- <button class="ui-btn">回首页</button> -->
        </header>
        <form id="form1" runat="server">
          
    <div>
    
         <section class="ui-container">


            <section id="table">
                <div class="demo-item">
                    <p class="demo-desc">全省农产品品牌建设大会参会代表名单</p>
                    <div class="demo-block">
                        <table class="ui-table ui-border-tb">
                            <thead>
                            <tr><th style="width:30px">姓名</th><th style="width:30px">单位</th><th style="width:20px">电话</th></tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                       <ItemTemplate> 
                            <tr><td><%#Eval("username")%> </td><td><%#Eval("address")%></td><td><%#Eval("mobile")%></td></tr>
                          
                        
                               </ItemTemplate>
        </asp:Repeater>
                           
                            </tbody>
                        </table>
                    </div>
                </div>
            </section>


        </section><!-- /.ui-container-->
    </div>
     </form>
       
        <script>
        $('.ui-list li,.ui-tiled li').click(function(){
            if($(this).data('href')){
                location.href= $(this).data('href');
            }
        });
        $('.ui-header .ui-btn').click(function(){
            location.href= 'index.html';
        });
        </script>
    </body>
</html>
