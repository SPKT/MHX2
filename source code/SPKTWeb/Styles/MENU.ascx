<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MENU.ascx.cs" Inherits="SPKTWeb.Styles.MENU" %>
<div style="margin-left:0px;position:fixed; left:-1px; top:53px;right:-1px; -moz-border-radius:10px; -webkit-border-radius:10px; margin-left:1%; margin-top:2px; margin-right:1%; height: 28px;background-image: url("~/image/pro_15_0.gif");>
        <li style="padding: 0px; list-style-image: url('../Image/4.gif'); float:left; width:auto; height:25px;">
            <asp:LinkButton runat="server" ID="lbt_Home">Trang chủ</asp:LinkButton>
        </li>
        <li style="list-style-image: url('../Image/6.gif');float:left;width:auto; height:25px;">
            <asp:LinkButton runat="server" ID="lbt_Profile">Cá nhân</asp:LinkButton>
        </li>
        <li style="list-style-image: url('../Image/5.gif');float:left; width:auto; height:25px;">
            <asp:LinkButton runat="server" ID="lbt_friend">Bạn bè</asp:LinkButton>
        </li>
        <li style="list-style-image: url('../Image/1.gif');float:left;width:auto; height:25px;">
            <asp:LinkButton runat="server" ID="lbt_forum">Diễn đàn</asp:LinkButton>
        </li>
        <li style="list-style-image: url('../Image/3.gif');float:left; width:auto; height:25px;">
            <asp:LinkButton runat="server" ID="lbt_group">Nhóm</asp:LinkButton>
        </li>
        <li style="list-style-image: url('../Image/2.gif');float:left;width:auto; height:25px;">
            <asp:LinkButton runat="server" ID="LinkButton1">Thông tin</asp:LinkButton>
        </li>
    </ul>
</div>