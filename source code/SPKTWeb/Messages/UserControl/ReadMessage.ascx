<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReadMessage.ascx.cs" Inherits="SPKTWeb.Messages.UserControl.ReadMessage" %>
<div id="div_content" runat="server" style="border: 1px solid #999999; height:auto">
 
    <asp:LinkButton ID="lbt_Nguoigui" runat="server" Font-Underline="False" 
        ForeColor="#006600">Gửi từ </asp:LinkButton>
&nbsp;_
    <asp:Label ID="lb_Thoigian" runat="server" Font-Italic="True"></asp:Label>
    <br />
&nbsp;<asp:Label ID="lb_Noidung" runat="server"></asp:Label>
 
</div>
<div align="right">
    <asp:LinkButton ID="lbt_Traloi" runat="server" onclick="lbt_Traloi_Click">Trả lời</asp:LinkButton>
</div>