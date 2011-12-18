<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageNew.ascx.cs"
    Inherits="SPKTWeb.Messages.UserControl.MessageNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
     <div style="border: 1px solid #6699FF; background-color:White; width:100%; height:310px; -moz-border-radius:10px; -webkit-border-radius:10px;">
        <div style="height: 51px; background-color: #FFFFFF; background-image: url('../../Image/bbl-body-bg.png');margin-top:2px; margin-left:1px; margin-right:1px; -moz-border-radius:3px;-webkit-border-radius:3px;" 
            align="center">
            <asp:Label ID="Label1" runat="server" Text="Gửi đến:" Width="100px" 
                ForeColor="#FF6600"></asp:Label>
            <asp:TextBox AutoPostBack="false"  ID="tb_To" runat="server" BorderColor="#9999FF" BorderStyle="Solid"
                BorderWidth="1px" Width="50%" Height="17px" 
                Style="margin-left: 1px; margin-top: 2px;"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Chủ đề:" Width="100px" 
                ForeColor="#FF6600"></asp:Label>
            <asp:TextBox AutoPostBack="false" ID="tb_Subject" runat="server" BorderColor="#9999FF" BorderStyle="Solid"
                BorderWidth="1px" Width="50%" Height="17px" 
                Style="margin-left: 1px; margin-top: 2px;"></asp:TextBox>
        </div>
        <div id="paint" runat="server" style="border: 1px solid #CCCCCC; background-image: url('../../Image/htitle.gif');
            height: 27px; background-repeat: repeat-x;"></div>
        <div align="center" style="height: 200px; margin:1px;">
            <asp:TextBox AutoPostBack="false" ID="tb_Box" runat="server" Height="200px" TextMode="MultiLine" Width="99%" BorderStyle="None" BackColor="White"></asp:TextBox>
        </div>
        <div align="right" style="height: 30px; margin-bottom:2px; margin-left:1px; margin-right:1px;-moz-border-radius:3px;-webkit-border-radius:3px;background-image: url('../../Image/htitle.gif'); background-repeat: repeat-x;">
            <div style="margin:2px; ">
            <asp:Label ID="lb_Ketqua" runat="server" BackColor="#FF9933"></asp:Label>
            <asp:Button ID="bt_Send" runat="server" BackColor="Blue" ForeColor="White" Height="22px"
                OnClick="bt_Send_Click" Style="margin-left: 0px" Text="Gửi" Width="15%" /></div>
        </div>
    </div>