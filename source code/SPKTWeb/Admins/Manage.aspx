<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_E.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="SPKTWeb.Admins.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div>
        <a href="AddCategory.aspx" id="linkAddcate" runat="server" >Thêm Category</a>
        <a href="AddForum.aspx" id="linkAddForum" runat="server" >Thêm Forum</a>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
