<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxComment.ascx.cs" Inherits="SPKTWeb.Comments.UserControl.BoxComment" %>
<div style="height: 236px; width: 62%">
    <div style="border: 1px solid #999999; background-image: url('../../Image/notepad.png'); background-repeat: repeat-x" 
        align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <div style="border: 0px solid #999999; height: 194px;">
        <asp:Panel ID="pnComment" runat="server" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" Height="192px" ScrollBars="Vertical">
        </asp:Panel>
    </div>
    <div style="border: 1px solid #999999; background-image: url('../../Image/notepad.png'); background-repeat: repeat-x" 
        align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <div style="border: 1px solid #CCCCCC; height: 152px">
    <div align="center" 
            
            style="background-image: none; background-repeat: repeat-x; height: 25px; color: #006600; font-weight: bold; background-color: #FFCC00;">
        Bình luận mới</div>
        <div align="center" style="height: 96px">
            <br />
            <asp:TextBox ID="tb_comment" runat="server" BorderColor="#6699FF" 
                BorderStyle="Solid" BorderWidth="1px" Height="68px" Width="467px" 
                TextMode="MultiLine"></asp:TextBox>
            <br />
        </div>
        <div align="right" style="height: 23px">
            <asp:Button ID="bt_send" runat="server" BackColor="#FFCC00" 
                BorderColor="#9999FF" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" 
                ForeColor="#990000" onclick="bt_send_Click" style="margin-left: 0px" 
                Text="Gửi Bình Luận Mới" Width="154px" Font-Names="Times New Roman" />
        </div>
    </div>
</div>