<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.master" AutoEventWireup="true"
    CodeBehind="MessageMange.aspx.cs" Inherits="SPKTWeb.Messages.MessageMange" %>

<%@ Register Src="~/Friends/UserControl/BoxInvite.ascx" TagName="BoxInvite" TagPrefix="uc1" %>
<%@ Register Src="~/Friends/UserControl/ListFriendSimple.ascx" TagName="ListFriendSimple"
    TagPrefix="uc2" %>
<%@ Register Src="UserControl/MessageNew.ascx" TagName="MessageNew" TagPrefix="uc3" %>
<%@ Register Src="UserControl/LoadInbox.ascx" TagName="LoadInbox" TagPrefix="uc4" %>
<%@ Register Src="UserControl/ReadMessage.ascx" TagName="ReadMessage" TagPrefix="uc5" %>
<asp:Content ID="content4" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="right" runat="server"></asp:Content>
<asp:Content ID="content5" ContentPlaceHolderID="right1" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="left" runat="server">
    <div style="border: 1px solid #999999; height: 473px; width: 100%">
        <div align="center" style="border: 1px solid #CCCCCC; background-image: url('../Image/thead.gif');
            background-repeat: repeat-x; height: 25px;">
            <asp:LinkButton ID="lbt_Box" runat="server" Font-Underline="False" Font-Bold="True"
                ForeColor="#006600">Hộp tin nhắn</asp:LinkButton>
        </div>
        <div style="border: 1px solid #CCCCCC; height: 10px; background-color: #333333;">
        </div>
        <div style="height: 18%;">
            <asp:Panel ID="Panel2" runat="server" Height="81px" HorizontalAlign="Left" BorderColor="Gray"
                BorderStyle="Solid" BorderWidth="1px">
                &nbsp;&nbsp;<asp:LinkButton ID="lbt_MessTo" runat="server" OnClick="lbt_MessTo_Click">Tin Nhắn Đến</asp:LinkButton>
                <br />
                &nbsp;
                <asp:LinkButton ID="lbt_MessNew" runat="server" OnClick="lbt_MessNew_Click">Soạn Tin Nhắn</asp:LinkButton>
                <br />
                &nbsp;
                <asp:LinkButton ID="lbt_MessFrom" runat="server">Tin Nhắn Đã Gửi</asp:LinkButton>
                <br />
                &nbsp;
                <asp:LinkButton ID="lbt_MessSpam" runat="server">Thùng Rác</asp:LinkButton>
            </asp:Panel>
        </div>
        <div style="border: 1px solid #CCCCCC; height: 10px; background-color: #333333;">
        </div>
        <div>
            <uc2:ListFriendSimple ID="ListFriendSimple1" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="border: 1px solid #999999; height: 600px; width: 100%">
        <div style="border-color: #CCCCCC; background-image: url('../Image/thanhtren.gif.png');
            background-repeat: repeat-x; height: 24px;">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="bt_Xoa" runat="server" BorderColor="#0066FF" BorderStyle="Solid"
                BorderWidth="1px" Font-Bold="False" Font-Underline="True" ForeColor="#006600"
                Text="Xóa" Width="50px" />
            &nbsp;&nbsp;
            <asp:Button ID="bt_Xoa_All" runat="server" BorderColor="#0066FF" BorderStyle="Solid"
                BorderWidth="1px" Font-Bold="False" Font-Underline="True" ForeColor="#990000"
                Text="Xóa Tất Cả" Width="83px" />
        </div>
        <div>
            <div>
                <uc3:MessageNew ID="MessageNew1" runat="server" Visible="false" />
                <uc4:LoadInbox ID="LoadInbox1" runat="server" Visible="true" />
            </div>
        </div>
       
    </div>

</asp:Content>
