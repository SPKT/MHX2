<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="ViewForum1.aspx.cs" Inherits="SPKTWeb.Forums.ViewForum1" %>
<%@ Register src="UserControl/ForumHeader.ascx" tagname="ForumHeader" tagprefix="uc1" %>
<%@ Register src="~/Forums/UserControl/ViewAllPost.ascx"tagname="ViewAllPost" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
<div>
    
</div>
<div>
    
    <uc1:ForumHeader ID="ForumHeader1" runat="server" />
    
</div>
<div>
    
   <uc2:ViewAllPost Id="ViewAllPost" runat="server"/>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
