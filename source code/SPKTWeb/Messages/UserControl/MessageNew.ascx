<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageNew.ascx.cs" Inherits="SPKTWeb.Messages.UserControl.MessageNew" %>
<div style="border: 1px solid #CCCCCC; height: 313px; width:100%">
    <div style="height: 47px; background-color: #FFFFCC;">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Gửi đến:"></asp:Label>
&nbsp; <asp:TextBox ID="tb_To" runat="server" BorderColor="#666666" 
            BorderStyle="Solid" BorderWidth="1px" Width="30%" 
            style="margin-left: 1px"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Chủ đề :&nbsp;
        <asp:TextBox ID="tb_Subject" runat="server" BorderColor="#666666" 
            BorderStyle="Solid" BorderWidth="1px" Width="30%" 
            style="margin-left: 6px"></asp:TextBox>
    </div>
    <div id="paint" runat="server" style="border: 1px solid #CCCCCC; background-image: url('../../Image/block_topbg.gif'); height: 27px;">
&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
    <div style="height: 212px">
        <asp:TextBox ID="tb_Box" runat="server" Height="211px" TextMode="MultiLine" 
            Width="100%" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
    </div>
    <div align="right" style="height: 30px; background-color: #CCCCCC;">
        <asp:Label ID="lb_Ketqua" runat="server" BackColor="#FF9933"></asp:Label>
        <asp:Button ID="bt_Send" runat="server" BackColor="Blue" ForeColor="White" 
            Height="20px" onclick="bt_Send_Click" style="margin-left: 0px" Text="Gửi" 
            Width="15%" />
    </div>
</div>
 
 