<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SPKTWeb.Accounts.Register" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
    <%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style104
        {
            height: 23px;
        }
        .sign-in {
            float: right;
                }
        .signin-box, .accountchooser-box {
            background: none repeat scroll 0 0 #F5F5F5;
            border: 1px solid #E5E5E5;

            width:auto;
            height:auto;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">

     <table class="signin-box" border="0">
        <div class="divContainerTitle" style="background-image: url('../Image/block_topbg.gif'); color: #FF0000; font-size: x-large; font-weight: bold;">Đăng Ký Tài Khoản</div> <br />
                   
                    <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style105">
                            Tên đăng ký:</td>


                        <td align="left" class="style108">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                            <asp:TextBox ID="txtUserName" AutoPostBack="true" runat="server"  
                                OnTextChanged="txtUserName_TextChanged" 
                               CausesValidation="True"></asp:TextBox>
                         
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
                                
                               TextMode="Password"></asp:TextBox>
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
                                
                              TextMode="Password" ></asp:TextBox>
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
                            <asp:TextBox ID="txtEmail" runat="server" 
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
                            <asp:TextBox ID="txtCaptCha" runat="server" 
                             ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtCaptCha" Display="Dynamic" 
                                ErrorMessage="Chưa nhập Captcha"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                   <tr>
                        <td align="right" 
                            style="color: #0000FF; font-size: large;" class="style106">
                            Thuộc Nhóm:</td>
                        <td align="left" class="style109">
                        
                            <asp:RadioButton ID="rdbCuuSinhVien" runat="server" ForeColor="#0000CC" Text="Cựu sinh viên" 
                            />
&nbsp;&nbsp;
                            <asp:RadioButton ID="rdbGiaoVien" runat="server" ForeColor="#0000CC" Text="Giáo viên" 
                              />
&nbsp;&nbsp;
                            <asp:RadioButton ID="rdbNguoiNgoai" runat="server" Checked="True" 
                                ForeColor="#0000CC" Text="Người ngoài" 
                              />
                        
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
</asp:Content>
