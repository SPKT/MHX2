<%@ Import Namespace="SPKTCore.Core.Domain" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendProfile.ascx.cs"
    Inherits="SPKTWeb.Friends.FriendProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
<%@ Register Src="~/Friends/UserControl/MoreFriend.ascx" TagName="more" TagPrefix="uc7" %>
<div 
    style="border-left: 0px solid #FFFFFF; border-right: 0px solid #FFFFFF; border-top: 0px solid #FFFFFF;
    border-bottom: 1px solid #9999FF; float: left; width: 100%; height: 87px;background-image: url('../../Image/block_topbg2.gif'); -moz-border-radius:5px; -webkit-border-radius:5px; border-width: 1px; border-color: #666666; background-repeat: repeat-x;">
    <div style="height: 86px; float: left; width: 61%;">
        <a><asp:Image  Style=" margin:10px;"  ImageAlign="Left" Width="70px" Height="66px" ID="imgAvatar"
            ImageUrl="~/Image/ProfileAvatar.aspx" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1" /></a>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tên tài khoản:
        <asp:Label ID="lblUsername" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Blue"></asp:Label><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Tên đại diện:
        <asp:Label ID="lblName" runat="server"></asp:Label>
        &nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCreateDate" Visible="false" runat="server"></asp:Label>
        <asp:Label ID="lblFriendID" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblemail" runat="server" Visible="False"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <br />
    <asp:Button ID="btn_add_de" runat="server" OnClick="btn_add_de_Click" Text="Thêm Bạn"
        Width="99px" BackColor="#006600" BorderColor="Lime" BorderStyle="Solid" BorderWidth="1px"
        Font-Bold="True" Font-Names="Constantia" ForeColor="White" UseSubmitBehavior="False" />
    <asp:Button ID="btn_de" runat="server" OnClick="btn_de_Click" Text="Xóa Bạn" Width="99px"
        BackColor="Maroon" BorderColor="Lime" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
        Font-Names="Constantia" ForeColor="White" Visible="False" />
    <asp:Button ID="btn_ok" runat="server" OnClick="btn_add_de_Click" Text="Hoàn thành"
        Width="99px" BackColor="#0066FF" BorderColor="Yellow" BorderStyle="Solid" BorderWidth="1px"
        Font-Bold="True" Font-Names="Constantia" ForeColor="White" UseSubmitBehavior="False"
        Visible="False" />
    <div style="margin-left: 93%; margin-top: -40px; height: 95%; width:7%;">
        <asp:ImageButton ID="lb_extend" runat="server" CssClass="popupHover" 
            ImageUrl="~/Image/gray Icon.png" Height="81%"
            Width="74%" Style="margin-left: 6px; margin-top: 7px"/>
        
            <asp:Panel ID="pn2" runat="server" Width="300px" Height="300px">
                <div>
                    <uc7:more ID="more1" runat="server" />
                </div>
            </asp:Panel>
            <aspt:HoverMenuExtender ID="HoverMenuExtender1" runat="Server" TargetControlID="lb_extend"
                PopupControlID="pn2" HoverCssClass="popupHover" PopupPosition="Right" OffsetX="2"
                OffsetY="0" PopDelay="50" />
    </div>
</div>
