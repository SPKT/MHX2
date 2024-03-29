﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTop.ascx.cs" Inherits="SPKTWeb.UserControl.MenuTop" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menul" TagPrefix="uc8" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
<div>
            <div style="height: 40px; float: none; background-color: White;">
                <div class="item_banner_logo">
                    &nbsp;&nbsp;&nbsp;<asp:Image ID="imga" runat="server" ImageUrl="/Image/logo3.jpg"
                        Width="300px" Height="100%" />
                </div>
                <div class="item_banner_text">
                    <div id="item_banner_2" style="height: 23px;" align="center">
                        <asp:Image ID="img_av" runat="server" Width="20px" Height="15px" />
                        <a href="/Default.aspx" style="color: DarkBlue" visible="false" id="linkLogin" runat="server">
                            Đăng nhập</a> <a href="/Accounts/Register.aspx" style="color: DarkBlue" visible="false"
                                id="linkRegister" runat="server">Đăng ký</a>
                        <asp:Label ID="lblUserName" runat="server" ForeColor="DarkBlue" Text="Xin chao" Font-Size="Small"></asp:Label>
                        <asp:Image Width="13px" Height="13px" ImageUrl="/Image/expand.jpg" runat="server"
                            ID="img_1" />
                        <asp:Panel ID="Panel1" runat="server" Style="display: block; width: 120px; height: 80px;">
                            <div style="margin-left: 86%; margin-top: 7px; float: left">
                                <a onclick="document.body.click(); return false;" title="Fermer" style="color: Gray">
                                    <asp:Button Width="20px" Height="18px" Text="X" runat="server" ID="ii" /></a>
                            </div>
                            <div style="background-image: url('/Image/bbl-body-bg.png'); width: 100%; height: 100%;
                                margin: 5px; margin-top: 10px; border-color: #666666; border-style: solid; border-width: 1px;
                                -moz-border-radius: 5px; -webkit-border-radius: 5px;">
                                <div class="link">
                                    <asp:LinkButton ID="lb_thaydoi" runat="server" Text="Quản lý tài khoản" Font-Strikeout="false"
                                        Width="100%" Height="18px" OnClick="thaydoi_Click"></asp:LinkButton>
                                </div>
                                <div class="link">
                                    <asp:LinkButton ID="lb_thoat" runat="server" Text="Đăng xuất" Font-Strikeout="false"
                                        Width="100%" Height="18px" OnClick="lb_thoat_Click"></asp:LinkButton>
                                </div>
                            </div>
                        </asp:Panel>
                        <aspt:ToolkitScriptManager ID="ScriptManager1" runat="server" />
                        <aspt:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="img_1"
                            PopupControlID="Panel1" Position="Left" OffsetX="-100" OffsetY="0">
                        </aspt:PopupControlExtender>
                    </div>
                </div>
            </div>
            <div style="height: 30px; float: none; background-image: url('/Image/1f.gif'); background-repeat: repeat;
                border-top-style: solid; border-top-width: 2px; border-top-color: #C0C0C0;">
                <div id="box_menu_top_1">
                    <asp:Menu ID="Menu2" runat="server" DataSourceID="HorisontalMenu" DynamicHorizontalOffset="0"
                        Font-Names="Verdana" Font-Size="11px" ForeColor="#525151" Height="30px" Orientation="Horizontal"
                        StaticSubMenuIndent="30px" Width="100%">
                        <DynamicHoverStyle BackColor="#b50606" ForeColor="Yellow" Font-Underline="true" />
                        <DynamicMenuItemStyle HorizontalPadding="30px" VerticalPadding="5px" ForeColor="White" />
                        <DynamicMenuStyle BackColor="#b50606" ForeColor="White" VerticalPadding="1px" BorderStyle="Solid"
                            BorderColor="White" BorderWidth="1" />
                        <DynamicSelectedStyle BackColor="#b50606" />
                        <StaticHoverStyle BackColor="#b50606" ForeColor="White" Font-Underline="true" />
                        <StaticMenuItemStyle HorizontalPadding="10px" VerticalPadding="7px" />
                        <StaticSelectedStyle BackColor="#b50606" ForeColor="White" />
                    </asp:Menu>
                    <asp:SiteMapDataSource ID="HorisontalMenu" runat="server" ShowStartingNode="False"
                        SiteMapProvider="HorisontalMenu" />
                </div>
                <div id="box_menu_top_timkiem">
                    <div class="menu_ngang_timkiem" style="margin: 0px; padding-left: 25px; border-style: none;
                        background-image: url('/Image/img02.gif'); background-repeat: no-repeat;">
                        <input id="timkiem" type="text" name="timkiem" runat="server" style="margin: 2px;
                            border-style: none; margin-bottom: 1px; background-image: url('/Image/tim1.gif');
                            background-repeat: repeat-x;" />
                    </div>
                    <div align="center" class="menu_ngang_timkiem_nut" style="background-color: #b50606;">
                        <asp:LinkButton ID="lbt_tim" runat="server" CssClass="nuttim" Font-Underline="False"
                            Height="100%" Width="100%" Font-Size="Medium" OnClick="lbt_tim_Click">TÌM</asp:LinkButton>
                    </div>
                </div>
            </div>
