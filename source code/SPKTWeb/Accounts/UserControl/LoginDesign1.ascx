<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginDesign1.ascx.cs" Inherits="SPKTWeb.Accounts.UserControl.LoginDesign1" %>
<div style="border: 1px solid #CCCCCC; height: 210px; background-color:White;-moz-border-radius:5px; -webkit-border-radius:5px;">
    <div align="center" 
        
        style="height: 25px; background-image: url('../../Image/htitle.gif'); background-repeat: repeat-x; color: #333333;">
        ĐĂNG NHẬP</div>
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
            Mật khẩu :</div>
        <div style="float:left; margin-left:1%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtPassword" runat="server" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" 
                TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div style="height: 23px" align="center">
						<asp:LinkButton id="lbRecoverPassword" runat="server" Font-Size="Small">Quên mật 
						khẩu</asp:LinkButton>
    </div>
    <div align="center" style="height: 24px">
						<asp:Button id="btnLogin" runat="server" BackColor="#0066FF" BorderColor="Blue" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" 
                                Height="25px" Text="Đăng nhập" Width="30%" onclick="btnLogin_Click" 
                            Font-Size="X-Small" style="margin-top: 2px" />
    </div>
    <div align="center" style="margin-top: 8px">
						<asp:CheckBox id="ckbAutoLogin" runat="server" TextAlign="Left" />
						<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Gray" Text="Duy trì trạng thái đăng nhập" Font-Size="Small"></asp:Label>
	</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 15px;"></div>
</div>
