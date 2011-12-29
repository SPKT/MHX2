<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForumHeader.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.ForumHeader" %>
<div class="divContainer" id="com" style="width: 100%;background-color: White; margin-top:0px;">
    <div class="div" style="border-color:White; width: 100%; height:50px;">
        <div class="Subject">
            <asp:Label  class="Main_Subject" ID="lblTen"  runat="server"></asp:Label> | Ngày Tạo: <asp:Label Text=" | " ID="lblCreateDate" runat="server" CssClass="Subject"></asp:Label> | Tổng Số Bài Viết: <asp:Label Text=" | " ID="lblPostCount" runat="server" CssClass="Subject"></asp:Label>
        </div>
        <div style="background-color: #CCCCCC; width:100%; height:2px; margin-bottom:10px;">
        </div>
         <div align="right">
            <asp:HyperLink ID="alkTatCaBaiViet" NavigateUrl="/Forums/ViewForum1.aspx" Text="Tất cả bài viết" runat="server"></asp:HyperLink>
                        &nbsp;&nbsp; 
            <asp:HyperLink ID="alkDangBaiMoi" NavigateUrl="/Forums/Post.aspx" Text="Đăng bài mới" runat="server"></asp:HyperLink>
                        &nbsp;&nbsp;
            <asp:HyperLink ID="alkBaiVietGanNhat" NavigateUrl="/Forums/ViewForum1.aspx" Text="Bài viết gần nhất" runat="server"></asp:HyperLink>
            
            &nbsp;&nbsp;
            <asp:HyperLink ID="alkXemNhieuNhat" NavigateUrl="/Forums/ViewForum1.aspx" Text="Bài được xem nhiều nhất" runat="server"></asp:HyperLink>
            
            &nbsp;&nbsp;
            <asp:HyperLink ID="alkQuanTrong" NavigateUrl="/Forums/ViewForum1.aspx" Text="Bài viết quan trọng" runat="server"></asp:HyperLink>
        </div>  
    </div>
    </div>