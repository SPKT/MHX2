<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginDesign.ascx.cs" Inherits="MXH.LoginDesign" %>
<style type="text/css">
    .style1
    {
        height: 43px;

    }
    .style3
    {
        height: 23px;
        width: 95px;
    }
    .style4
    {
        height: 23px;
    }
    .style6
    {
        height: 31px;
        width: 95px;
    }
    .style7
    {
        height: 31px;
    }
    .style8
    {
        height: 43px;
        width: 173px;
    }
    .style9
    {
        height: 34px;
        width: 173px;
    }
    .style10
    {
        height: 28px;
        width: 173px;
    }
    .style11
    {
        height: 6px;
        width: 173px;
    }
    .style12
    {
        height: 23px;
        width: 173px;
    }
    .style13
    {
        height: 31px;
        width: 173px;
    }
</style>
				<table style="padding: 0px; width: 100%; height: 245px; background-color: #FFFFFF; margin-top: 0px; margin-right:0px; background-image: none; background-repeat: repeat-x;" border="0" cellpadding="0" cellspacing="0">
					<tr style="background-image: url('../Image/block_topbg.gif')">
						<td style="background-image: url('../../Image/block_topbg.gif');"></td>
						<td style="background-image: url('../../Image/block_topbg.gif');" 
                            align="center" valign="middle">
				<asp:Label id="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000" Text="ĐĂNG NHẬP"></asp:Label>
						</td>
						<td style="background-image: url('../../Image/block_topbg.gif');"></td>
					</tr>
					<tr>
						<td style="height: 34px; width: 50px; background-image: none; background-repeat: repeat-x;"></td>
						<td style="width: 95px; height: 34px">
						<asp:Label id="Label1" runat="server" Text="Tên đăng nhập:"></asp:Label>
						</td>
						<td style="height: 34px">
						<asp:TextBox id="txtUserName" runat="server" BackColor="White" BorderColor="#3399FF" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Names="Times New Roman" 
                                Font-Size="Medium" Width="175px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="height: 24px; width: 50px; background-image: none; background-repeat: repeat-x;"></td>
						<td style="height: 24px; width: 95px">
						<asp:Label id="Label2" runat="server" Text="Mật khẩu:"></asp:Label>
						</td>
						<td style="height: 24px">
						<asp:TextBox id="txtPassword" runat="server" BorderColor="#3399FF" BorderStyle="Solid" 
                                BorderWidth="1px" Font-Names="Times New Roman" Font-Size="Medium" Width="175px" 
                                TextMode="Password"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="height: 23px; width: 50px; background-image: none; background-repeat: repeat-x;"></td>
						<td style="height: 23px; width: 95px"></td>
						<td style="height: 23px">
						<asp:LinkButton id="lbRecoverPassword" runat="server" 
                                onclick="lbRecoverPassword_Click1">Quên mật 
						khẩu</asp:LinkButton>
						&nbsp;</td>
					</tr>
					<tr>
						<td style="height: 28px; width: 50px"></td>
						<td style="width: 95px; height: 28px">
						<asp:Button id="btnLogin" runat="server" BackColor="#0066FF" BorderColor="Blue" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" 
                                Height="26px" Text="Đăng nhập" Width="87px" onclick="btnLogin_Click" />
						&nbsp;</td>
						<td style="height: 28px"></td>
					</tr>
					<tr>
						<td style="width: 50px; height: 23px"></td>
						<td align="right" style="width: 95px; height: 23px">
						<asp:CheckBox id="ckbAutoLogin" runat="server" TextAlign="Left" />
						</td>
						<td style="height: 23px">
						<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Gray" Text="Duy trì trạng thái đăng nhập" Font-Size="Small"></asp:Label>
						</td>
					</tr>
					<tr bgcolor="#000000">
						<td style="width: 50px; height: 6px"></td>
						<td align="right" style="width: 95px; height: 6px">
						</td>
						<td style="height: 6px">
						</td>
					</tr>
					</table>

