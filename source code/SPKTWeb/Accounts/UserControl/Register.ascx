<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="SPKTWeb.Accounts.UserControl.Register" %>
<style type="text/css">
    .text
    {
        Border-Color:#999999;
        Border-Style:Solid;
        Border-Width:1px;
    }
    text:hover
    {
        Border-Color:#6699FF;
        Border-Style:Solid;
        Border-Width:1px;
    }
</style>
<div style="border: 1px solid #CCCCCC; height: 376px; background-color:White;-moz-border-radius:5px; -webkit-border-radius:5px;">
    <div align="center" 
        
        style="height: 25px; background-image: url('../../Image/htitle.gif'); background-repeat: repeat-x; color: #333333;">
        ĐĂNG KÝ</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 27px;"></div>
    <div style="height: 30px;">
        <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Tên đăng ký :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtUserName" runat="server" Height="17px" Width="89%" 
                CssClass="text"></asp:TextBox>
        </div>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Mật khẩu :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtPassword" runat="server" Height="17px" Width="89%" 
                CssClass="text" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Nhắc lại mật khẩu :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtPasswordPre" runat="server" Height="17px" Width="89%" 
                CssClass="text" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Email :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtEmail" runat="server" Height="17px" Width="89%" 
                CssClass="text"></asp:TextBox>
        </div>
    </div>
    <div style="height: 40px">
        <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
          Capchar : </div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/image/CaptChaIma.aspx" />
        </div>
    </div>
    <div style="height: 40px">
        <div style="float:left; margin-left:5%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Nhập Capchar :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtCaptCha" runat="server" Height="17px" Width="50%" 
                CssClass="text"></asp:TextBox>
        </div>
    </div>
    <div style="height: 30px">
    </div>
    <div style="height: 27px" align="center">
						<asp:Button id="btnLogin" runat="server" BackColor="#0066FF" BorderColor="Blue" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" 
                                Height="25px" Text="Đăng ký" Width="26%" Font-Size="X-Small" 
                            style="margin-top: 0px" />
    </div>
    <div align="center" style="height: 20px">
                            
                            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                            
    </div>
    <div align="center" style="margin-top: 8px">
                           
                            <asp:Label ID="lblRegisterMessage" runat="server"></asp:Label>
                           
	</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 18px;"></div>
</div>