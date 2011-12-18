<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_NEW.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SPKTWeb.Accounts.Register" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    <%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style104
        {
            height: 23px;
        }
        .style106
        {
            font-size:12px;
            font-family: Times New Roman;
            
        }
        .sign-in {
            float: right;
                }
        .signin-box, .accountchooser-box {
            background: none repeat scroll 0 0 #F5F5F5;
           
            width:100%;
            height:auto;
}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <div style="width:100%; height:700px; background-color:White;background-image: url('../Image/bo4.gif');-moz-border-radius:5px;-webkit-border-radius:5px; background-repeat:repeat-x;">
     
        <div align="center" class="divContainerTitle" style=" padding-top:50px;background-image: url('../Image/bo4.gif'); color: #FF0000; font-size: x-large; font-weight: bold;">Đăng Ký Tài Khoản</div> <br />
                   <table class="signin-box" border="0" style="background-color:White; padding-top:20px;">
                    <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style106">
                            Tên đăng ký :</td>
                        <td align="left" class="style109">
                           <asp:TextBox ID="txtUserName" AutoPostBack="true" runat="server"  
                                OnTextChanged="txtUserName_TextChanged" 
                               CausesValidation="True" BorderColor="#9999FF" BorderStyle="Solid" 
                                BorderWidth="1px" Width="220px" Height="22px"></asp:TextBox> 
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                            
                            <asp:Label ID="lblCheckUsername" runat="server"></asp:Label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtUserName" Display="Dynamic" 
                                ErrorMessage="Chưa điền Tên đăng ký"></asp:RequiredFieldValidator>
                             <asp:CustomValidator ID="Username_CustomValidator" runat="server" 
                                ControlToValidate="txtUserName" Display="Dynamic" 
                                ErrorMessage="Tên đăng ký đã tồn tại" 
                                onservervalidate="Username_CustomValidator_ServerValidate"></asp:CustomValidator>
                             </ContentTemplate>
                           
                         </asp:UpdatePanel>
                        </td>

                       

                    </tr>
                    <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style106">
                            Mật khẩu:</td>
                        <td align="left" class="style109">
                           <asp:TextBox ID="txtPassword" runat="server" 
                                
                               TextMode="Password" Width="220px" BorderColor="#9999FF" BorderStyle="Solid" 
                                BorderWidth="1px" Height="22px"></asp:TextBox>
                            <asp:Label ID="lblMessageLegthPass" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPassword" Display="Dynamic" 
                                ErrorMessage="Chưa nhập Mật khẩu">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="PasswordCustomValidator" runat="server" Display="Dynamic" 
                                ControlToValidate="txtPassword" ErrorMessage="Mật khẩu quá yếu" 
                                onservervalidate="PasswordCustomValidator_ServerValidate" ></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style106">
                            Nhắc lại Mật khẩu:</td>
                        <td align="left" class="style109">
                            <asp:TextBox ID="txtPasswordPre" runat="server" 
                                
                              TextMode="Password" Width="220px" BorderColor="#9999FF" BorderStyle="Solid" 
                                BorderWidth="1px" Height="22px" ></asp:TextBox>
                            <asp:PasswordStrength ID="txtPassword_PasswordStrength" runat="server" 
                                Enabled="True" TargetControlID="txtPassword">
                            </asp:PasswordStrength>
                            <asp:Label ID="lblMessagepass" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtPasswordPre" ErrorMessage="Chưa nhập lại mật khẩu" 
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtPasswordPre" ControlToValidate="txtPassword" 
                                Display="Dynamic" ErrorMessage="Mật khẩu nhập lại không đúng"></asp:CompareValidator>
                         </td>

                    </tr>
                    <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style104">
                            Email:</td>
                        <td align="left" class="style104">
                            <asp:TextBox ID="txtEmail" runat="server" Width="220px" BorderColor="#9999FF" 
                                BorderStyle="Solid" BorderWidth="1px" Height="22px"
                              ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Chưa nhập email"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Không phải email." 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style104">
                            Captcha:</td>
                        <td align="left" class="style104">
                                  <div class="divContainerRow">
                                    <div class="divContainerCell">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/image/CaptChaIma.aspx" />
                                </div>
                        </td>
                    </tr>
                   <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style104">
                            Captcha:</td>
                        <td align="left" class="style104">
                            <asp:TextBox ID="txtCaptCha" runat="server" BorderColor="#9999FF" 
                                BorderStyle="Solid" BorderWidth="1px" Height="22px" 
                             ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtCaptCha" Display="Dynamic" 
                                ErrorMessage="Chưa nhập Captcha"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                
                   <tr>
                        <td class="style107">
                        </td>
                        <td align="left" class="style110">
                            <asp:Button ID="btnRegister" runat="server" ForeColor="Blue" Height="30px" 
                                Text="Đăng Ký" Width="100px" onclick="btnRegister_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style107">
                        </td>
                        <td align="left" class="style110">
                            
                            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style105">
                            &nbsp;</td>
                        <td align="left" class="style108">
                           
                            <asp:Label ID="lblRegisterMessage" runat="server"></asp:Label>
                           
                        </td>
                    </tr>
                </table>
                </div>
</asp:Content>
