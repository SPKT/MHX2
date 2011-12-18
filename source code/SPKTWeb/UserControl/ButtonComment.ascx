<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ButtonComment.ascx.cs" Inherits="SPKTWeb.Profiles.UserControls.ButtonComment" %>
<%@ Register Src="~/UserControl/Comment.ascx" TagName="comment" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
<div align="left" class="icon" style="width:100%; height:20px;">
    <asp:LinkButton ID="bt_comment" runat="server" Width="66px" Height="20px" 
        Font-Underline="False" onclick="LinkButton1_Click">Bình luận</asp:LinkButton>
     <div style="margin: 10px; -moz-border-radius: 10px; -webkit-border-radius: 10px;">
            <asp:Panel ID="pnregist" runat="server" Width="1020px" Height="149px">
                <div align="center" style="width: 100%; height: 86%; margin-top:10px;">
                    <div style="float: left; margin-left: 0%; height: 100%; width: 96%; margin-top: 0px;">
                        <uc1:comment ID="comment1" runat="server" />
                    </div>
                    <div style="float: left; margin-left:23%; margin-top:-10px; width: 58px; height: 22px;">
                        <asp:Button ID="bt" Text="X" runat="server" BackColor="White" 
                            ForeColor="Black" Height="16px" Font-Bold="True" 
                            Font-Names="Times New Roman" Font-Size="8px" />
                    </div>
                </div>
            </asp:Panel>
            
            <aspt:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="bt_comment"
                PopupControlID="pnregist" BackgroundCssClass="modalBackground" DropShadow="false"
                OkControlID="bt" OnOkScript="onOk()" />
        </div>
</div>