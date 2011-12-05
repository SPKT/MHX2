<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="SPKTWeb.Profiles.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .winzard
        {
            display:run-in;
            margin:0;
            padding:0;
            }
        #scroll_box {   height:467px; 
                          display: auto; 
                            border: 1px solid #CCCCCC; 
                              margin: 0em 0 1em 0; 
                              overflow:scroll; 
        }
        .label
        {
            border-color:#3333FF;
            border-style:outset;
            border-width:1px;
            width:286px;
            height:18px;
        }
        .divContainerRow { background-color:#ffffff;text-align:right; padding:0px; color:Coral; float:right}
        .divContainerCell { display: block; text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:0px; color:GrayText;background-color:White; width:500px;border-bottom:solid 1px #5c76a4;border-top:solid 1px #5c76a4; font-weight:bold;text-align:left;padding-bottom:5px;padding-top:5px;padding-left:5px;}
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="left" runat="server">
<div  style="background-color:White;  height:462px;">
        
            <img id="imgAvatar" src="~/Image/ProfileAvatar.aspx" alt="test image" width="145"
                height="100" runat="server" style="border: 2px solid #FFCCFF" />
           <div style="border-top-color:Blue">
                <asp:Label ID="lblDisplayProfileName" ForeColor="Aqua" runat="server"></asp:Label>
            </div>
            <div class="buttonlink">
                <a href="UploadAvatar.aspx" id="lnkChangeAvatar" runat="server" style="border-top-color:Blue">Đối Avatar</a>
            </div>

            <div class="buttonlink">
                <a href="ManageProfile.aspx" runat="server" id="lnkManageProfile">Thay đổi thông tin</a>
            </div>

        </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
       
    <div style="background-color:White; height: 469px;">
   <div class="winzard" id="scroll_box">
        <asp:Wizard CssClass="winzard"  EnableViewState="true" ID="Wizard1" 
            runat="server" ActiveStepIndex="0" 
            CellPadding="10" FinishCompleteButtonText="Hết" 
            FinishPreviousButtonText="Trước" StartNextButtonText="Tiếp" 
            StepNextButtonText="Tiếp" StepPreviousButtonText="Trước" Width="581px">
            <WizardSteps>
                <asp:WizardStep EnableViewState="true" ID="WizardStep1" runat="server" Title="Tài Khoản" EnableTheming="true">
                <asp:Panel ID="Panel1" runat="server">
                    <a style=" color: #FF0000; font-size: x-large; font-weight: bold; outline-color:invert"></a>
                    <br />
    
                    <table border="0"">
                        <caption>
                            <tr class="divContainerTitle" >
                                <td align="left"  style=" font-size: large;">
                                   Tên tài khoản</td>
                                <td align="right"class="divContainerRow"  >
                                    <asp:Label  ID="lblProfileName" ForeColor="Coral" Width="286px" runat="server" 
                                         ></asp:Label>
                                </td>
                            </tr>
                            <tr id="TenDayDu" runat="server" class="divContainerTitle" >
                                    <td align="left"  style=" font-size: large;">
                                    Tên đầy đủ</td>
                                <td align="right" class="divContainerRow"  >
                                    <asp:Label ID="lblTenThat" runat="server" ForeColor="Coral" Width="286px"
                                        ></asp:Label>
                                </td>
                            </tr>
                            <tr id="NgaySinh" runat="server" class="divContainerTitle" >
                          
                                <td align="left"  style=" font-size: large;">
                                    Ngày sinh</td>
                           
                                <td align="right" class="divContainerRow"  >
                                    <asp:Label ID="lblNgaySinh" runat="server"  ForeColor="Coral" Width="286px"
                                     ></asp:Label>
                                </td>
                            </tr>
                            <tr id="GioiTinh" runat="server" class="divContainerTitle">
                                <td align="left"   style="font-size: large;">
                                    Giới Tính</td>
                                <td align="right" class="divContainerRow" >
                                    <asp:Label ID="lblSex" runat="server"  ForeColor="Coral" Width="286px"
                          
                                     ></asp:Label>
                                </td>
                            </tr >
                            <tr id="ChuKy" runat="server" class="divContainerTitle" >
                                <td align="left"  style=" font-size: large;">
                                    Chữ ký</td>
                              <td align="right" class="divContainerRow" >
                                    <asp:Label ID="lblChuKy" runat="server" ForeColor="Coral" Width="286px"
                                        ></asp:Label>
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
                        <br />

                    </div>
                </asp:Panel>
            </asp:wizardStep>
     </WizardSteps>
   </asp:Wizard>
 </div>

</div>
</asp:Content>
