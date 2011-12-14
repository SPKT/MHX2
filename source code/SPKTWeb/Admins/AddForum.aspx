<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="AddForum.aspx.cs" Inherits="SPKTWeb.Admins.AddForum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div class="divContainerTitle" >
        Add Forum
    </div>
    <div class="divContainerRow">
        Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </div>
    <div class="divContainerRow">
        Subject: <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
    </div>
    <div class="divContainerRow">
        PageName: <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
    </div>
    <div class="divContainerRow">
        Category: 
        <asp:DropDownList ID="ddlcategory" runat="server">
        </asp:DropDownList>
    </div>
    <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
