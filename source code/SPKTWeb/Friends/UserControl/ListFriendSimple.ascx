<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListFriendSimple.ascx.cs" Inherits="SPKTWeb.Friends.ListFriendSimple" %>
<%@ Register src="../../Friends/UserControl/FriendSimple.ascx" tagname="FriendSimple" tagprefix="uc1" %>
<div align="center" style="border: 1px solid #999999; font-family: Constantia; font-weight: bold; color: #006600; background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; width: 198px; height: 25px;">
    <asp:LinkButton ID="lbt_Friend" runat="server" Font-Names="Times New Roman" 
        Font-Underline="False" ForeColor="#006600">Danh Sách Bạn Bè</asp:LinkButton>
</div>
<asp:Panel ID="pnlInFriends" Height="200px" ScrollBars="Vertical" runat="server" Width="198px" HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
    <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
             <ItemTemplate>
                    <uc1:FriendSimple id="pdFriendSimple" runat="server"></uc1:FriendSimple>
             </ItemTemplate>
    </asp:Repeater>
 </asp:Panel>


