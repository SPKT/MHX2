<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddData.aspx.cs" Inherits="SPKTWeb.AddData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainLeft_above" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainLeft_under" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainCenter" runat="server">
    <div>
    <asp:TextBox ID="txtPermissionName" runat="server">
    </asp:TextBox>
    </div>
    <div>
    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="ADD" >
    </asp:Button>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="mainRight" runat="server">
</asp:Content>
