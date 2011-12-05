<%@ Import namespace="SPKTCore.Core.Domain"%>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="ShowFriend.aspx.cs" Inherits="SPKTWeb.Friends.ShowFriend1" %>
<%@ Register src="~/Friends/UserControl/ShowFriend.ascx" tagname="ShowFriend" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div>
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div>
    
    <uc1:ShowFriend ID="ShowFriend2" runat="server" />
</div>

</asp:Content>
