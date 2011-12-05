<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.master" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="SPKTWeb.Profiles.ManageProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .winzard
        {
            display:run-in;
            margin-top:3%;
            padding:0;
            width:100%;
        }
        #scroll_box {   height:483px; 
                          display:block;
                            border: 1px solid #CCCCCC; 
                              margin: 0em 0 1em 0; 
                              overflow:scroll;
            width:100%;
        }
        .style15
        {
            width: 287px;
        }
        .style18
        {
            width: 115px;
            height: 32px;
        }
        .style19
        {
            width: 287px;
            height: 32px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="left" runat="server">
    <div>
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right1" runat="server">

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
  <div style="height: 100%">
          <div class="winzard">
        <asp:Wizard CssClass="winzard"  EnableViewState="true" ID="Wizard1" 
            runat="server" ActiveStepIndex="0" 
            CellPadding="10" FinishCompleteButtonText="Lưu" 
            FinishPreviousButtonText="Trước" 
            onfinishbuttonclick="Wizard1_FinishButtonClick" StartNextButtonText="Tiếp" 
            StepNextButtonText="Tiếp" StepPreviousButtonText="Trước" Width="581px">
            <FinishCompleteButtonStyle BorderColor="#000066" BorderStyle="Solid" 
                BorderWidth="1px" Font-Bold="True" ForeColor="Blue" />
            <FinishPreviousButtonStyle BorderColor="#000066" BorderStyle="Solid" 
                BorderWidth="1px" Font-Bold="True" ForeColor="Blue" />
            <StartNextButtonStyle BorderColor="#000066" BorderStyle="Solid" 
                BorderWidth="1px" Font-Bold="True" ForeColor="#0033CC" />
            <WizardSteps>
                <asp:WizardStep EnableViewState="true" ID="WizardStep1" runat="server" Title="Quảnlýthôngtincánhân">
                <asp:Panel ID="Panel1" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <a style=" color: #FF0000; font-size: x-large; font-weight: bold;"> Quản lý thông tin cá nhân</a>
                    <br />
    
                    <table border="0"">
                        <caption>
                            <br />
                            <tr>
                                <td align="left" class="style18" 
                                    style="color: #6699FF; font-size: medium; font-family: 'Times New Roman', Times, serif;">
                                    Tên tài khoản:</td>
                                <td align="left" class="style19">
                                    <asp:TextBox ID="txtProfileName" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="21px" Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style18" 
                                    style="color: #6699FF; font-size: medium; font-family: 'Times New Roman', Times, serif;">
                                    Tên đầy đủ:</td>
                                <td align="left" class="style19">
                                    <asp:TextBox ID="txtTenThat" runat="server" BackColor="White" 
                                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="140px" 
                                        ></asp:TextBox>
                                    <asp:DropDownList ID="ddlVisibility1" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style18" 
                                    style="color: #6699FF; font-size: medium; font-family: 'Times New Roman', Times, serif;">
                                    Ngày sinh:</td>
                                <td align="left" class="style19">
                                    <asp:TextBox ID="txtNgaySinh" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="21px" Width="140px" 
                                     ></asp:TextBox>
                                    <asp:DropDownList ID="ddlVisibility2" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style18" 
                                    style="color: #6699FF; font-size: medium; font-family: 'Times New Roman', Times, serif;">
                                    Giới Tính:</td>
                                <td align="left" class="style19">
                                    <asp:TextBox ID="txtSex" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="140px" 
                                     ></asp:TextBox>
                                    <asp:DropDownList ID="ddlVisibility3" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style18" 
                                    style="color: #6699FF; font-size: medium; font-family: 'Times New Roman', Times, serif;">
                                    Chữ ký:</td>
                                <td align="left" class="style19">
                                    <asp:TextBox ID="txtChuKy" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="21px" Width="140px"  
                                     ></asp:TextBox>
                                    <asp:DropDownList ID="ddlVisibility4" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </caption>
                </table>
                </asp:Panel>
            </asp:WizardStep>
            <asp:wizardStep ID="WinzardStep2" runat="server" Title="Thôngtin">
                <asp:Panel ID="Panel2" runat="server">
                    <div id="divProfileAttribute" runat="server">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
            </asp:wizardStep>
     </WizardSteps>
   </asp:Wizard>
 </div>
            <div>
              <asp:Button ID="btnSaveProfile" runat="server" onclick="btnSaveProfile_Click" 
                  Text="Lưu thay đổi" Visible="False" BorderColor="#000066" 
                    BorderStyle="Solid" BorderWidth="1px" ForeColor="Blue" />
            </div>
  </div>
</asp:Content>

