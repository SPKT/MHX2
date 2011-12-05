<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxFriend.ascx.cs" Inherits="SPKTWeb.Friends.BoxFriend" %>

<div style="width: 176px; margin-left:2px" align="left">
    <asp:LinkButton ID="lbt_Ketban" runat="server" Font-Size="Small" 
        Font-Underline="False" ForeColor="#CC0000" onclick="lbt_Ketban_Click">LinkButton</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="bt_OK" runat="server" Font-Size="X-Small" 
        onclick="bt_OK_Click">OK</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="bt_Cancel" runat="server" Font-Size="X-Small" 
        onclick="bt_Cancel_Click">XÓA</asp:LinkButton>
</div>
<div style="width: 181px; background-color: #666666; height: 1px;">
</div>