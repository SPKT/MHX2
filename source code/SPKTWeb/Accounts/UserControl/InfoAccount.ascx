<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InfoAccount.ascx.cs" Inherits="SPKTWeb.Accounts.UserControl.InfoAccount" %>
<div style="border-left: 1px solid #666666; border-right: 1px solid #666666; height: 320px; width: 100%; -moz-border-radius:5px;
	-webkit-border-radius:5px; background-color: #FFFFFF;">
    <div style="background-image: url('../../Image/Bground.gif'); background-repeat: repeat-x; height: 27px;"></div>
    <div style="height: 266px">
        <div align="center" 
            style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; color: #333333;">
            THÔNG TIN TÀI KHOẢN
        </div>
        <div style="height: 77px; margin-top: 5px; margin-left: 50px;">
            <a href="~/Profiles/UserProfile.aspx?AccountID=<asp:Literal id='litAccountID' runat='server'></asp:Literal>">
                <asp:Image style="padding:5px; margin-top: 4px;" ImageAlign="Left" ID="imgAvatar" runat="server" CssClass="img" /></a>
        </div>
        <div style="margin: 20px;">
            <div style="height: 30px">
                <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 16px; color: #666666;">
                    Tên tài khoản :</div>
                <div style="float:left; margin-left:0%; height:100%; width:65%; margin-top:1px; vertical-align:middle;">
                    <asp:Label ID="lb_name_ac" runat="server" Height="17px" Width="89%" 
                        ForeColor="#333333"></asp:Label>       
                </div>
            </div>
            <div style="height: 30px">
                <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 16px; color: #666666;">
                    Tên đại diện :</div>
                <div style="float:left; margin-left:0%; height:100%; width:65%; margin-top:1px; vertical-align:middle;">
                    <asp:Label ID="lb_name" runat="server" Height="17px" Width="89%" 
                        ForeColor="#333333"></asp:Label>       
                </div>
            </div>
            <div style="height: 30px">
                <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 16px; color: #666666;">
                    Mail đăng ký :</div>
                <div style="float:left; margin-left:0%; height:100%; width:65%; margin-top:1px; vertical-align:middle;">
                    <asp:Label ID="lb_mail" runat="server" Height="17px" Width="89%" 
                        ForeColor="#333333"></asp:Label>       
                </div>
            </div>
            <div style="height: 30px">
                <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 16px; color: #666666;">
                    Ngày tạo :</div>
                <div style="float:left; margin-left:0%; height:100%; width:65%; margin-top:1px; vertical-align:middle;">
                    <asp:Label ID="lb_date" runat="server" Height="17px" Width="89%" 
                        ForeColor="#333333"></asp:Label>       
                </div>
            </div>
         </div>
    </div>    
    <div style="background-image: url('../../Image/Bground.gif'); background-repeat: repeat-x; height: 26px;"></div>
</div>