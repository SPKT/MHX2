<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RIGHT_MENU.ascx.cs" Inherits="SPKTWeb.Styles.RIGHT_MENU" %>
<%@ Register src="../Messages/UserControl/MessageNew.ascx" tagname="MessageNew" tagprefix="uc1" %>
<div style="height:auto">
    <div style="padding: 5px; height: 27px;" align="center">
        
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bt_add0" runat="server" BorderColor="#9999FF" 
            BorderStyle="Solid" BorderWidth="1px" onclick="bt_add_Click" Text="Tìm bạn" 
            Visible="False" />
        <asp:Button ID="bt_add" runat="server" BorderColor="#9999FF" 
            BorderStyle="Solid" BorderWidth="1px" onclick="bt_add_Click" Text="Thêm bạn" 
            Visible="False" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" BorderColor="#9999FF" 
            BorderStyle="Solid" BorderWidth="1px" onclick="Button2_Click" 
            Text="Gửi tin nhắn" />
        
    </div>
    <div style="margin:10px;-moz-border-radius:10px;-webkit-border-radius:10px;">
        <asp:Panel ID="pn5" runat="server" Visible="false">
        <uc1:MessageNew ID="MessageNew1" runat="server" />
        </asp:Panel>
    </div>
</div>