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
        <div style="float:left; margin-left:0%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Tên đăng ký :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtUserName" runat="server" Height="17px" Width="89%" 
                CssClass="text"></asp:TextBox>
        </div>
                            
                            <asp:Label ID="lblCheckUsername" runat="server"></asp:Label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtUserName" Display="Dynamic" 
                                ErrorMessage="Chưa điền Tên đăng ký" 
            ValidationGroup="regist"></asp:RequiredFieldValidator>
                             <asp:CustomValidator ID="Username_CustomValidator" runat="server" 
                                ControlToValidate="txtUserName" Display="Dynamic" 
                                ErrorMessage="Tên đăng ký đã tồn tại" 
                                
            onservervalidate="Username_CustomValidator_ServerValidate" 
            ValidationGroup="regist"></asp:CustomValidator>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:0%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Mật khẩu :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtPassword" runat="server" Height="17px" Width="89%" 
                CssClass="text" TextMode="Password"></asp:TextBox>
        </div>
                            <asp:Label ID="lblMessageLegthPass" runat="server"></asp:Label>
                            <asp:CustomValidator ID="PasswordCustomValidator" 
            runat="server" Display="Dynamic" 
                                ControlToValidate="txtPassword" ErrorMessage="Mật khẩu quá yếu" 
                                
            onservervalidate="PasswordCustomValidator_ServerValidate" 
            ValidationGroup="regist" ></asp:CustomValidator>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:0%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Nhắc lại mật khẩu :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtPasswordPre" runat="server" Height="17px" Width="89%" 
                CssClass="text" TextMode="Password"></asp:TextBox>
        </div>
                            <asp:Label ID="lblMessagepass" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtPasswordPre" ErrorMessage="Chưa nhập lại mật khẩu" 
                                Display="Dynamic" ValidationGroup="regist"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtPasswordPre" ControlToValidate="txtPassword" 
                                Display="Dynamic" ErrorMessage="Mật khẩu nhập lại sai"></asp:CompareValidator>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:0%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Email :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtEmail" runat="server" Height="17px" Width="89%" 
                CssClass="text"></asp:TextBox>
        </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Chưa nhập email"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Không phải email." 
                                
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ValidationGroup="regist"></asp:RegularExpressionValidator>
    </div>
    <div style="height: 40px">
        <div style="float:left; margin-left:0%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
          Capchar : </div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/image/CaptChaIma.aspx" />
        </div>
    </div>
    <div style="height: 40px">
        <div style="float:left; margin-left:0%; height:100%; width:30%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Nhập Capchar :</div>
        <div style="float:left; margin-left:0%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtCaptCha" runat="server" Height="17px" Width="50%" 
                CssClass="text"></asp:TextBox>
        </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtCaptCha" Display="Dynamic" 
                                ErrorMessage="Chưa nhập Captcha" 
            ValidationGroup="regist"></asp:RequiredFieldValidator>
    </div>
    <div style="height: 30px">
    </div>
    <div style="height: 27px" align="center">
						<asp:Button id="btnLogin" runat="server" BackColor="#0066FF" BorderColor="Blue" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" 
                                Height="22px" Text="Đăng ký" Width="23%" Font-Size="X-Small" 
                            style="margin-top: 0px" />
    &nbsp;&nbsp;
						<asp:Button id="btnLogin0" runat="server" BackColor="#0066FF" BorderColor="Blue" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" 
                                Height="22px" Text="Thoát" Width="17%" Font-Size="X-Small" 
                            style="margin-top: 0px" onclick="btnLogin0_Click" />
    </div>
    <div align="center" style="height: 20px">
                            
                            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                            
    </div>
    <div align="center" style="margin-top: 8px">
                           
                            <asp:Label ID="lblRegisterMessage" runat="server"></asp:Label>
                           
	</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 18px;"></div>
</div>