<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_PE.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="SPKTWeb.Blogs.ViewPost" %>
<%@ Register src="/Styles/LEFT_MENU.ascx" tagname="LEFT_MENU" tagprefix="uc1" %>
<%@ Import Namespace="SPKTCore.Core.Domain" %>
<%@ Register src="../UserControl/Comments.ascx" tagname="Comments" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">

    <uc1:LEFT_MENU ID="LEFT_MENU1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
<asp:Panel ID="pnlViewPost" runat="server">
        
        <div>Tiêu đề bài viết: 
        
        <div class="Subject">
            <asp:Label  class="Main_Subject" ID="lblTitle"  runat="server"></asp:Label>
        </div>
        <div style="background-color: #CCCCCC; width:100%; height:2px; margin-bottom:10px;">
        </div>
        <div style="float:right">
        <asp:ImageButton Visible="false" Width="20px" Height="20px" ID="ibEdit" runat="server" 
                ImageUrl="/image/pencil.jpg" onclick="ibEdit_Click" />
        <asp:ImageButton Width="20px" Height="20px" ID="ibDelete" runat="server" 
                ImageUrl="/image/icon_close.gif" Visible="false" onclick="ibDelete_Click" />
        </div>
        </div>
      
        <div>Chủ đề bài viết:
        <asp:Label runat="server" ID="lblSubject" ></asp:Label>
        </div>
        <div>Nội dung bài viết:
        </div>
        <div>
            Ngày đăng:
            <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
        </div>
        <div>
            Ngày cập nhật cuối:
             <asp:Label ID="lblUpdateDate" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" ID="lblBody" ></asp:Label>
            <br />
            <uc2:Comments ID="UCComments" SystemObjectID="3" runat="server" />
        </div>

</asp:Panel>
<div>
    <asp:Label ID="lblMessages" runat="server"></asp:Label>
</div>
</asp:Content>
