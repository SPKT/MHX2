<%@ Import namespace="SPKTCore.Core.Domain"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendProfile.ascx.cs" Inherits="SPKTWeb.Friends.FriendProfile" %>
<div style="border: 1px solid #9999FF; float:left; width: 654px; height: 87px;">
    <div style="height:86px; float:left; width: 537px;">
        
        <asp:Image style="padding:5px;" ImageAlign="Left" Width="82px" Height="76px" 
            ID="imgAvatar" ImageUrl="~/Image/ProfileAvatar.aspx" 
            runat="server" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Tên tài khoản:
        <asp:Label ID="lblUsername" runat="server" Font-Bold="True" Font-Italic="True" 
            ForeColor="Blue"></asp:Label><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Tên đại diện:
        <asp:Label ID="lblName" runat="server"></asp:Label> &nbsp; Ngày tạo: <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblFriendID" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblemail" runat="server" Visible="False"></asp:Label>
    </div>
    
    <br />
    <asp:Button ID="btn_add_de" runat="server" onclick="btn_add_de_Click" Text="Thêm Bạn" 
        Width="99px" BackColor="#006600" BorderColor="Lime" BorderStyle="Solid" 
        BorderWidth="1px" Font-Bold="True" Font-Names="Constantia" 
        ForeColor="White" UseSubmitBehavior="False" />
     <asp:Button ID="btn_de" runat="server" onclick="btn_de_Click" Text="Xóa Bạn" 
        Width="99px" BackColor="Maroon" BorderColor="Lime" BorderStyle="Solid" 
        BorderWidth="1px" Font-Bold="True" Font-Names="Constantia" 
        ForeColor="White" Visible="False" />
    <asp:Button ID="btn_ok" runat="server" onclick="btn_add_de_Click" Text="Hoàn thành" 
        Width="99px" BackColor="#0066FF" BorderColor="Yellow" BorderStyle="Solid" 
        BorderWidth="1px" Font-Bold="True" Font-Names="Constantia" 
        ForeColor="White" UseSubmitBehavior="False" Visible="False" />
</div>
