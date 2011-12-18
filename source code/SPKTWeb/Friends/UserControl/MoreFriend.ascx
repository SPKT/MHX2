<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoreFriend.ascx.cs"
    Inherits="SPKTWeb.Friends.UserControl.MoreFriend" %>
<%@ Register src="Friendship.ascx" tagname="Friendship" tagprefix="uc1" %>
<%@ Register src="~/Messages/UserControl/ButtonMess.ascx" tagname="btmess" tagprefix="uc2" %>
<%@ Register Src="~/UserControl/ButtonComment.ascx" TagName="btcom" tagprefix="uc3" %>
<div style="border: 1px solid #999999; -moz-border-radius:5px;-webkit-border-radius:5px; background-color:White;">
    <div align="center" style="background-image: url('../../Image/lista.png'); width:100%; height:25px;-moz-border-radius:2px;-webkit-border-radius:2px;">
        <asp:Label ID="lb_gioithieu" runat="server" ForeColor="White" Font-Bold="true"></asp:Label>
    </div>
    <div style="float: left; width:100%;background-image: url('../../Image/thead.gif'); background-repeat: repeat-x;">
        <div style="height: 45px; width: 50px; float: left; margin-left: 10px;
            margin-top: 10px; margin-bottom: 0px; margin-right: 20px">
            <asp:Image ID="Avatar" runat="server" Width="100%" Height="100%" />
        </div>
        <div style="float:left; height: 41px; margin-left:60px; margin-top:-50px; margin-right: 10px;
            margin-bottom: 10px; width: 74%" align="center">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                Font-Names="Times New Roman" Font-Size="16px" ForeColor="#3366FF"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                Font-Names="Times New Roman" Font-Size="10px" ForeColor="#999966"></asp:Label>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                Font-Names="Times New Roman" Font-Size="10px" ForeColor="#999966" Visible="false"></asp:Label>
        </div>
    </div>
    <div style="margin: 7px 15px 2px 11px; margin-top:10px; height: 100px; width: 98%;" align="left">
        <asp:Label ID="status" runat="server" ForeColor="#FF6600" Font-Size="16px" Font-Italic="True"></asp:Label>
        <br /><asp:Label ID="date" runat="server" ForeColor="#666666" Font-Size="10px"></asp:Label>
    </div>
    <div class="icon" style="height:25px; width:98%; margin-right:20px; margin-left: 13px; margin-top: 5px; margin-bottom: 2px;" align="left">       
        <div style="width: 90%; margin-right:20px;">
            <ul>
                <li style="float:left; list-style-image: url('../../Image/110934_27850_48_email_forward_letter_send_icon1.png'); width:100px;">
                    <uc2:btmess ID="mess1" runat="server" />
                </li>
                <li style="float:left; list-style-image: url('../../Image/send-icon1.png'); width:100px;">
                    <uc3:btcom ID="com1" runat="server"></uc3:btcom>
                </li>
            </ul>
            
        </div>
    </div>
    <div style="height: 55px; width: 100%; background-image: url('../../Image/bbl-body-bg.png'); border-bottom-style: solid; border-bottom-width: 0px; border-bottom-color: #FFFFFF; border-top-style: solid; border-top-width: 1px; border-top-color: #CCCCCC;">
        <div style="margin:3px; margin-left:0; margin-top:5px;">
            <uc1:Friendship ID="Friendship1" runat="server" />
        </div>
    </div>
    <div style="height: 10px; width: 100%; background-image: url('../../Image/lista.png');">
        
    </div>
</div>
