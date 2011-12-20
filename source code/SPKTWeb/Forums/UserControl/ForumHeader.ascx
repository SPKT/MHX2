<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForumHeader.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.ForumHeader" %>
<div class="divContainer" id="com" style="border: 1px solid #999999; width: 621px;
    -moz-border-radius: 5px; -webkit-border-radius: 5px; background-color: White;">
    <div class="div" style="border-color:Blue; width: 100%; height:100px;">
        <div class="divContainerTitle" style="border: 0px none #000066;  -moz-border-radius: 5px; -webkit-border-radius: 5px;font-family: 'Times New Roman', Times, serif;
             width: 621px; height: 33px; background-image: url('../../Image/thead.gif');
            background-repeat: repeat-x;">
            <asp:Label  ID="lblTen"  font-weight=" bold " Text="Diễn Đàn" color= "#3366FF" font-size=" 22px"  runat="server"></asp:Label>
        </div>
        <div>
            Ngày tạo: <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
            Tổng số bài viết: <asp:Label ID="lblPostCount" runat="server"></asp:Label><br />
         </div>
         <div>
            <a ID="A1" href="/Forums/ViewForum.aspx" runat="server">Tất cả bài viết</a> 
            &nbsp;&nbsp; 
            <a ID="HyperLink2" href="/Forums/Post.aspx" runat="server">Đăng bài mới</a>
            &nbsp;&nbsp;
            <a ID="HyperLink3" href="/Forums/ViewForum.aspx" runat="server">Bài viết gần nhất</a>
            &nbsp;&nbsp;
            <a ID="HyperLink4"  href="/Forums/ViewForum.aspx" runat="server">Bài được xem nhiều nhất</a>
            &nbsp;&nbsp;
            <a ID="HyperLink5"  href="/Forums/ViewForum.aspx" runat="server">Bài viết quan trọng</a>
        </div>  
    </div>
    </div>