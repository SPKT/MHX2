<%@ Register Src="~/Messages/UserControl/MessageNew.ascx" TagName="MessageNew" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonMessage.ascx.cs" Inherits="SPKTWeb.Messages.UserControl.ButtonMessage" %>
<div align="left" class="link" style="width:100%; height:28px;">
    <asp:LinkButton ID="bt_mess" runat="server" Width="70px" Height="20px" 
        Font-Underline="False" onclick="LinkButton1_Click">Nhắn tin</asp:LinkButton>
    <div style="margin: 10px; -moz-border-radius: 10px; -webkit-border-radius: 10px;">
            <asp:Panel ID="pnregist" runat="server" Width="555px" Height="310px">
                <div style="width: 100%; height: 100%;">
                    <div style="float: left; margin-left: 0%; height: 97%; width: 100%; margin-top: 0px;">
                        <uc1:MessageNew ID="MessageNew1" runat="server" />
                    </div>
                    <div style="float: left; margin-left:2%; margin-top:-13px;">
                        <asp:Button ID="bt" Text="Đóng" runat="server" BackColor="Green" ForeColor="White" />
                    </div>
                </div>
            </asp:Panel>
            
            <aspt:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="bt_mess"
                PopupControlID="pnregist" BackgroundCssClass="modalBackground" DropShadow="false"
                OkControlID="bt" OnOkScript="onOk()" />
        </div>
</div>