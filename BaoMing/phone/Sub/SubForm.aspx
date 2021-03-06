﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubForm.aspx.cs" Inherits="BaoMing.phone.Sub.SubForm" %>


<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">
        <meta name="format-detection" content="telephone=no">
        <title>山东省农产品品牌建设大会</title>
        <link rel="stylesheet" href="../css/frozen.css">
        <link rel="stylesheet" href="css.css">
        <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        //window.history.forward(1);
        function YanZheng()
        {
            if ($("#txtUserName").val() == "")
            {
                alert('请输入姓名！');
                return false;
            }
            if ($("#txtMobile").val().length != 11) {
                alert('请输入有效的手机号码！');
                return false;
            }
            if ($("#txtAddress").val() == "") {
                alert('请输入单位！');
                return false;
            }
            var myreg = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
            if (!myreg.test($("#txtMobile").val())) {
                alert('请输入有效的手机号码！');
                return false;
            }
            
            if ($("#txtSigncode").val() == "") {
                alert('请输入验证码！');
                return false;
            }
        }
        $('#ui_tab .ui_tab_nav li').click(function () {
            alert("1");
            $(this).addClass('current').siblings().removeClass('current');
            $('#ui_tab .ui_tab_content .ui_tab_content_item').eq($(this).index()).show().siblings().hide();
            return false;
        });
        $('#ui_tab2 .ui_tab_nav li').click(function () {
            $(this).addClass('current').siblings().removeClass('current');
            $('#ui_tab2 .ui_tab_content .ui_tab_content_item').eq($(this).index()).show().siblings().hide();
            return false;
        });
        $('#ui_tab3 .ui_tab_nav li').click(function () {
            $(this).addClass('current').siblings().removeClass('current');
            $('#ui_tab3 .ui_tab_content .ui_tab_content_item').eq($(this).index()).show().siblings().hide();
            return false;
        });

        var slider = new fz.Scroll('.ui-slider', {
            role: 'slider',
            indicator: true,
            autoplay: true,
            interval: 3000
        });

        slider.on('beforeScrollStart', function (fromIndex, toIndex) {
            console.log(fromIndex, toIndex)
        });

        slider.on('scrollEnd', function (cruPage) {
            console.log(cruPage)
        });

</script>
    </head>
    <body ontouchstart>
        <header class="ui-header ui-header-positive ui-border-b">
            <!-- <i class="ui-icon-return" onclick="history.back()"></i> -->
            <h1>山东省农产品品牌建设大会</h1>
            <!-- <button class="ui-btn">回首页</button> -->
            
        </header>
        <section class="ui-container">
            <p class="demo-desc">参会人信息</p>
            <div class="reg_panel">
                <form id="form1" runat="server">
                <div class="demo-block">
                    <div class="ui-form ui-border-t">
                        
                            <div class="ui-form-item ui-border-b">
                                <label>
                                    姓名
                                </label>
                                <%--<input type="text" placeholder="请填写真实姓名">--%>
        <asp:TextBox ID="txtUserName" runat="server" placeholder="请填写真实姓名"></asp:TextBox>
                               <%-- <a href="#" class="ui-icon-close">
                                </a>--%>
                            </div>
                            <div class="ui-form-item ui-form-item-textarea ui-border-b">
                                <label>
                                    单位
                                </label>
                                 <asp:TextBox ID="txtAddress" runat="server" placeholder="请填写单位"></asp:TextBox>
                            </div>
                            <%--<div class="ui-form-item ui-border-b">
                                <label>地市</label>
                                <div class="ui-select">
                                    <select>
                                        <option>省直</option>
                                        <option selected="">济南</option>
                                        <option>青岛</option>
                                    </select>
                                </div>
                            </div>--%>
                            <div class="ui-form-item ui-form-item-l ui-border-b">
                                <label class="ui-border-r">
                                    中国 +86
                                </label>
                              <asp:TextBox ID="txtMobile" runat="server" placeholder="请填写手机号"></asp:TextBox>
                               <%-- <a href="#" class="ui-icon-close">
                                </a>--%>
                            </div>
<%--                            <div class="ui-form-item ui-border-b">
                                <label>
                                    电子邮箱
                                </label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="请填写邮箱"></asp:TextBox>
                                <%--<input type="text" placeholder="请填写电子邮箱">
                                <a href="#" class="ui-icon-close">
                                </a>
                            </div>--%>
                        <div class="ui-form-item ui-border-b">
                                <label>
                                   <img id="imgcode" style="cursor: hand;margin-top:2px;height:32px;"   onclick="javascript:document.getElementById  

('imgcode').src='ValidNums.aspx?'+Math.random();"
                    title="看不清楚,点击更换" src="ValidNums.aspx" align="absMiddle" name="imgcode"   height="32px"/>
                                </label>
                                <asp:TextBox ID="txtSigncode" runat="server" placeholder="请填写验证码"></asp:TextBox>
                                
                            </div>
                         <div class="ui-btn-wrap">
                          <asp:Button ID="btnSub" class="ui-btn-lg ui-btn-primary" runat="server" OnClick="btnSub_Click" Text="提交" OnClientClick="return YanZheng()"/><br />
                            <asp:Button ID="btnYz" class="ui-btn-lg ui-btn-primary" runat="server"  Text="我已注册" OnClientClick="return YanZheng()" OnClick="btnYz_Click"/>
                    </div>
                  
                </div>
             </form>
            </div>    
        </section>
        
        
       
        





        <script src="../lib/zepto.min.js"></script>
        <script src="../js/frozen.js"></script>

            <script>
                (function (){

                    $('#ui_tab .ui_tab_nav li').click(function(){
                        $(this).addClass('current').siblings().removeClass('current');
                        $('#ui_tab .ui_tab_content .ui_tab_content_item').eq($(this).index()).show().siblings().hide();
                        return false;
                    });
                    $('#ui_tab2 .ui_tab_nav li').click(function(){
                        $(this).addClass('current').siblings().removeClass('current');
                        $('#ui_tab2 .ui_tab_content .ui_tab_content_item').eq($(this).index()).show().siblings().hide();
                        return false;
                    });
                    $('#ui_tab3 .ui_tab_nav li').click(function(){
                        $(this).addClass('current').siblings().removeClass('current');
                        $('#ui_tab3 .ui_tab_content .ui_tab_content_item').eq($(this).index()).show().siblings().hide();
                        return false;
                    });

                    var slider = new fz.Scroll('.ui-slider', {
                        role: 'slider',
                        indicator: true,
                        autoplay: true,
                        interval: 3000
                    });

                    slider.on('beforeScrollStart', function(fromIndex, toIndex) {
                        console.log(fromIndex,toIndex)
                    });

                    slider.on('scrollEnd', function(cruPage) {
                        console.log(cruPage)
                    });


                })();
        </script>
    </body>
</html>