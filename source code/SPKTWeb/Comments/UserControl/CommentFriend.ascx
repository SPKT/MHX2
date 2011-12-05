<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentFriend.ascx.cs" Inherits="SPKTWeb.Comments.UserControl.CommentFriend" %>
<div style="border: 1px solid #FFFFFF; height: 80px; width: 50%">
    <div style="border: 1px solid #CCCCCC; width: 65px; margin-top:5px; margin-left:5px; margin-bottom:5px; height: 65px;">    
    <div style="border: 1px solid #FFFFFF; width: 15px; margin-top:5px; margin-left:66px; margin-bottom:5px; height: 34px; background-image: url('../../Image/arrow.jpg'); background-repeat: no-repeat;">
    <div style="border: 1px solid #CCCCCC; width: 398px; margin-top:0px; margin-left:15px; margin-bottom:5px;height:auto; background-image: url('../../Image/block_topbg.gif');">
    &nbsp;
        <asp:Label ID="lb_Comment" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbt_UserName" runat="server" onclick="lbt_UserName_Click"></asp:LinkButton>
&nbsp;&nbsp;
        <asp:Label ID="lb_Ngay" runat="server" ForeColor="#990000" Text="Ngày Đăng :"></asp:Label>
    </div>
    </div>
    </div>
</div>