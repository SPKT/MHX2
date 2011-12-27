<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_R.Master" AutoEventWireup="true" CodeBehind="ViewForum1.aspx.cs" Inherits="SPKTWeb.Forums.ViewForum1" EnableEventValidation="false" %>
<%@ Register src="UserControl/ForumHeader.ascx" tagname="ForumHeader" tagprefix="uc1" %>
<%@ Register src="UserControl/ViewAllPost.ascx"tagname="ViewAllPost" TagPrefix="uc2" %>
<%@ Register src="UserControl/ViewTopPost.ascx" tagname="ViewTopPost" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
<div>
    
</div>
<div>
    
    <uc1:ForumHeader ID="UCForumHeader" runat="server" />
    
</div>
<div>
    
   <uc2:ViewAllPost Id="UCViewAllPost" runat="server"/>
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">

    <uc3:ViewTopPost ID="UCViewTopPost" runat="server" />

</asp:Content>

