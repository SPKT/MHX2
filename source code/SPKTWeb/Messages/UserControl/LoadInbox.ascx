<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoadInbox.ascx.cs" Inherits="SPKTWeb.Messages.UserControl.LoadInbox" %>
<%@ Register src="MessageBrief.ascx" tagname="MessageBrief" tagprefix="uc1" %>
<div style="height:auto">
  <asp:Panel ID="pnlInMessages" runat="server">
    <asp:Repeater ID="repMessages" runat="server" OnItemDataBound="repMessages_ItemDataBound">
             <ItemTemplate>
                    <uc1:MessageBrief ID="MessageBrief1" runat="server"></uc1:MessageBrief>
             </ItemTemplate>
    </asp:Repeater>
 </asp:Panel>
</div>
