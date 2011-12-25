<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginDesign.ascx.cs" Inherits="MXH.LoginDesign" %>
<div style="border: 1px solid #CCCCCC; height: 198px; background-color:White;-moz-border-radius:5px; -webkit-border-radius:5px;">
    <div align="center" 
        
        
        style="height: 20px; font-size:12px; background-image: url('../../Image/lista.png'); background-repeat: repeat-x; color: #FFFFFF;">
        PHỤC HỒI MẬT KHẨU</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 27px;"></div>
    <div style="height: 30px;">
        <div style="float:left; margin-left:5%; height:100%; width:45%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Tên đăng nhập :</div>
        <div style="float:left; margin-left:1%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtUserName" runat="server" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%"></asp:TextBox>
        </div>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:5%; height:100%; width:45%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Email:</div>
        <div style="float:left; margin-left:1%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtEmail" runat="server" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" 
                TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div style="height: 23px" align="center">
    </div>
    <div align="center" style="height: 24px">
						<asp:Button ID="btnRecoverPassword" runat="server" BackColor="#0066FF" BorderColor="Blue" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" 
                                Height="25px" Text="Phục hồi" Width="30%" onclick="btnRecoverPassword_Click" 
                            Font-Size="X-Small" style="margin-top: 2px" />
    </div>
    <div align="center" style="margin-top: 8px">
						
						<asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
	</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 9px;">
    </div>
</div>
