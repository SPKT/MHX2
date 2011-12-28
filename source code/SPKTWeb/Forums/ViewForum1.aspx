<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_R.Master" AutoEventWireup="true"
    CodeBehind="ViewForum1.aspx.cs" Inherits="SPKTWeb.Forums.ViewForum1" EnableEventValidation="false" %>

<%@ Register Src="UserControl/ForumHeader.ascx" TagName="ForumHeader" TagPrefix="uc1" %>
<%@ Register Src="UserControl/ViewAllPost.ascx" TagName="ViewAllPost" TagPrefix="uc2" %>
<%@ Register Src="UserControl/ViewTopPost.ascx" TagName="ViewTopPost" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div style="width:100%; padding:0px; margin:0px;">
    <div>
        <uc1:ForumHeader ID="UCForumHeader" runat="server" />
    </div>
    <div>
        <uc2:ViewAllPost ID="UCViewAllPost" runat="server" />
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
    <div style="width:100%; background-color:White; margin:0px; padding:0px">
    <div style="margin-top: 0px">
        <div style="font-family:Arial; font-weight:bold; font-size:medium">
            Bài viết được xem nhiều nhất
        </div>
        <uc3:ViewTopPost ID="UCViewTopPost" runat="server" />
    </div>
    <div>
        <div style="font-family:Arial; font-weight:bold; font-size:medium">
            Bài viết cùng Category được xem nhiều nhất
        </div>
        <uc3:ViewTopPost ID="UCViewTopPost1" runat="server" />
    </div>
    </div>
</asp:Content>
