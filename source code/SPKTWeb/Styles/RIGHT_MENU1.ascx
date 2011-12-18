<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RIGHT_MENU1.ascx.cs"
    Inherits="SPKTWeb.Styles.RIGHT_MENU1" %>
<%@ Register Src="~/Messages/UserControl/ButtonMessage.ascx" TagName="Message" TagPrefix="uc1" %>
<%@ Register Src="~/Friends/UserControl/ButtonAddFriend.ascx" TagName="Friend" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>

<div style="padding: 10px 20px 10px 20px; border: 1px solid #9999FF; height:auto;-moz-border-radius:5px;
	-webkit-border-radius:5px; background-image: url('../Image/block_topbg.gif'); background-repeat: repeat-x; height:80px;">
  
   
    <div style="height: 30px;">
        <div style="float:left; margin:5px; margin-top:8px; margin-left:7px; width:10%; height:90% ; vertical-align:middle">
            <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="~/Image/redstyle-10-add.png" 
                 Width="15px" Height="15px" /></div>
        <div style="float:left; margin-left:14%; width:84%; margin-top:-30px; height:100%";">
            <uc2:Friend ID="Friend1" runat="server" />
        </div>
    </div>
   
   
    <div style="height: 30px;">
        <div style="float:left; margin:2px; width:10%; height:90% ; vertical-align:middle">
            <asp:ImageButton ID="img_send_mess" runat="server" 
                ImageUrl="~/Image/red-square-icon-social-media-logos-mail.png" 
                 Width="21px" Height="21px" /></div>
        <div style="float:left; margin-left:14%; width:84%; margin-top:-25px; height:100%";">
            <uc1:Message ID="Message1" runat="server" />
        </div>
    </div>
    
</div>
