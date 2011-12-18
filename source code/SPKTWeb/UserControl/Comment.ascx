<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comment.ascx.cs" Inherits="SPKTWeb.Profiles.UserControls.Comment" %>
<div style="border: 1px solid #666666; width:500px; height:137px;-moz-border-radius:5px; -webkit-border-radius:5px; background-color:White">
    
    <div style="border: 1px solid #CCCCCC; float:left; width:50px; height:50px; margin:10px;">
        <asp:Image ID="Image1" runat="server" Width="100%" Height="100%" />
    </div>
    <div align="center" 
            style="border: 1px solid #9999FF; padding-top:3px; float:left; margin-left:9px; width:400px; height:60px; -moz-border-radius:5px; -webkit-border-radius:5px; background-color: #FFFFFF; margin-right: 10px; margin-top: 10px; margin-bottom: 10px;">
            <asp:TextBox ID="tb_comment" runat="server" Width="94%" Height="55px" 
                BorderStyle="Solid" BorderWidth="1" BorderColor="White" AutoPostBack="true"></asp:TextBox>
    </div>
    <div style="height:20px; width: 383px; margin-left: 82px; margin-top:85px;" 
        align="right">
        <asp:Button ID="Button1" runat="server" Font-Names="Times New Roman" 
            Font-Size="10px" ForeColor="#3333CC" Height="19px" Text="GỬI" Width="34px" 
            onclick="Button1_Click" />
    </div>
    <div style="height:20px; margin-top:10px; background-image: url('../../Image/lista.png'); background-repeat: repeat-x;" 
        align="right">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
            Font-Names="Times New Roman" Font-Size="12px" ForeColor="White" Text="Label"></asp:Label>
    </div>
</div>