<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForumHeader.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.ForumHeader" %>
<div class="divContainer" id="com" style="border: 1px solid #999999; width: 100%;
    -moz-border-radius: 5px; -webkit-border-radius: 5px; background-color: White;">
    <div class="div" style="border-color:Blue; width: 100%; height:100px;">
        <div class="divContainerTitle" style="border: 0px none #000066;  -moz-border-radius: 5px; -webkit-border-radius: 5px;font-family: 'Times New Roman', Times, serif;
             width: 621px; height: 33px; background-image: url('/Image/thead.gif');
            background-repeat: repeat-y;">
            <asp:Label  ID="lblTen"  font-weight=" bold " Text="Diễn Đàn" color= "#3366FF" font-size=" 22px"  runat="server"></asp:Label>
        </div>
        <div>
            Ngày tạo: <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
            Tổng số bài viết: <asp:Label ID="lblPostCount" runat="server"></asp:Label><br />
         </div>
         <div>
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