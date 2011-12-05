<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileAttributeControlFull.ascx.cs" Inherits="SPKTWeb.Profiles.UserControls.ProfileAttributeControlFull" %>
             <div>
        <asp:Wizard EnableViewState="true" ID="Wizard1" runat="server" ActiveStepIndex="1" 
            BackColor="LemonChiffon" BorderStyle="Groove" BorderWidth="2px" 
            CellPadding="10" FinishCompleteButtonText="Lưu" 
            FinishPreviousButtonText="Trước" 
            onfinishbuttonclick="Wizard1_FinishButtonClick" StartNextButtonText="Tiếp" 
            StepNextButtonText="Tiếp" StepPreviousButtonText="Trước">
            <FinishCompleteButtonStyle BackColor="#0099FF" BorderColor="#66FFFF" 
                BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
            <FinishPreviousButtonStyle BackColor="#990000" BorderColor="#33CCFF" 
                BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
            <StartNextButtonStyle BackColor="#3399FF" BorderColor="#33CCFF" 
                BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
            <WizardSteps>
                <asp:WizardStep EnableViewState="true" ID="WizardStep1" runat="server" Title="Quảnlýthôngtincánhân">
                <asp:Panel ID="Panel1" runat="server">
                    <a style="height: 65px; width: 370px; color: #FF0000; font-size: x-large; font-weight: bold;"> Quản lý thông tin cá nhân</a>
                    <br />
    
                    <table border="0"  height:243px;" style="width: 602px">
                        <caption>
                            <a style="height: 65px; width: 370px; color:Green; font-size:large;font-weight: bold;">
                            Thông tin tài khoản</a>
                            <tr>
                                <td align="Right" class="style105" style="color: #0000FF; font-size: large;">
                                    Tên tài khoản:</td>
                                <td align="left" class="style108">
                                    <asp:TextBox ID="txtProfileName" runat="server" BorderColor="#3366FF" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="22px" Width="170px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style106" style="color: #0000FF; font-size: large;">
                                    Tên đầy đủ:</td>
                                <td align="left" class="style109">
                                    <asp:TextBox ID="txtTenThat" runat="server" BorderColor="#3366FF" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="21px" Width="171px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style106" style="color: #0000FF; font-size: large;">
                                    Ngày sinh:</td>
                                <td align="left" class="style109">
                                    <asp:TextBox ID="txtNgaySinh" runat="server" BorderColor="#3366FF" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="21px" Width="171px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style104" style="color: #0000FF; font-size: large;">
                                    Giới Tính:</td>
                                <td align="left" class="style104">
                                    <asp:TextBox ID="txtSex" runat="server" BorderColor="#6699FF" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="170px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style106" style="color: #0000FF; font-size: large;">
                                    Chữ ký:</td>
                                <td align="left" class="style109">
                                    <asp:TextBox ID="txtChuKy" runat="server" BorderColor="#3366FF" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="21px" Width="171px"></asp:TextBox>
                                </td>
                            </tr>
                        </caption>
                </table>
                </asp:Panel>
            </asp:WizardStep>
            <asp:wizardStep ID="WinzardStep2" runat="server" Title="Thôngtin">
                <asp:Panel ID="Panel2" runat="server">
                    <div id="divProfileAttribute" runat="server">
                        <asp:Label ID="lblError" runat="server" ForeColor="#006600"></asp:Label>
                    </div>
                </asp:Panel>
            </asp:wizardStep>
     </WizardSteps>
   </asp:Wizard>
   </div>