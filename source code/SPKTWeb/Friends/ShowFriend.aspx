<%@ Import namespace="SPKTCore.Core.Domain"%>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_PE.Master" AutoEventWireup="true" CodeBehind="ShowFriend.aspx.cs" Inherits="SPKTWeb.Friends.ShowFriend1" %>
<%@ Register src="~/Friends/UserControl/ShowFriend.ascx" tagname="ShowFriend" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div>
<div align="center" class="move" style="margin-top:20px; width:70%; margin-left:3%">
    <uc1:ShowFriend ID="ShowFriend2" runat="server" />
</div>
</div>
</asp:Content>
