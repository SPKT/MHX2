<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SPKTWeb.Accounts.Login" %>
<%@ Register src="UserControl/LoginDesign.ascx" tagname="LoginDesign" tagprefix="uc1" %>
    <%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <uc1:LoginDesign ID="LoginDesign2" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
