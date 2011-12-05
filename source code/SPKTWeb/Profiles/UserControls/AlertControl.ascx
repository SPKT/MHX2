<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlertControl.ascx.cs" Inherits="SPKTWeb.Profiles.UserControls.AlertControl" %>

<asp:Panel ID="pnlAlert" runat="server">
    <asp:Label ID="lblContent" runat="server"></asp:Label>
</asp:Panel>
<asp:Panel ID="pnlButton" runat="server">
    <asp:Button ID="btnDelete" Visible="false" runat="server" Text="Xóa" />
</asp:Panel>