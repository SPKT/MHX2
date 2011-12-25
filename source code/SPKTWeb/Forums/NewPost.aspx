<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_E.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="SPKTWeb.Forums.NewPost" %>
<%@ Register src="UserControl/ForumHeader.ascx" tagname="ForumHeader" tagprefix="uc1" %>

<%@ Register src="UserControl/Post.ascx" tagname="Post" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
 <div>
    <div>
    </div>

    <div>

        <uc1:ForumHeader ID="ForumHeader1" runat="server" />

    </div>
    <div>
    Tạo bài viết mới:
    <asp:Label ID="lblTen" runat="server"></asp:Label>
    </div>
    <div>
        

        

        <uc2:Post ID="Post1" runat="server" />
        

        

    </div>
 </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
