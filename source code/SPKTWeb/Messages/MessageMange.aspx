<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_PE.master" AutoEventWireup="true"
    CodeBehind="MessageMange.aspx.cs" Inherits="SPKTWeb.Messages.MessageMange" %>

<%@ Register Src="~/Friends/UserControl/BoxInvite.ascx" TagName="BoxInvite" TagPrefix="uc1" %>
<%@ Register Src="~/Friends/UserControl/ListFriendSimple.ascx" TagName="ListFriendSimple"
    TagPrefix="uc2" %>
<%@ Register Src="UserControl/MessageNew.ascx" TagName="MessageNew" TagPrefix="uc3" %>
<%@ Register Src="UserControl/LoadInbox.ascx" TagName="LoadInbox" TagPrefix="uc4" %>
<%@ Register Src="UserControl/ReadMessage.ascx" TagName="ReadMessage" TagPrefix="uc5" %>
<asp:Content ID="content4" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="left" runat="server">
    <div style="border: 1px solid #999999;background-color:White;">
        <div align="center" style="border: 1px solid #CCCCCC; background-image: url('../Image/htitle.gif');
            background-repeat: repeat-x; height: 25px;">
            <asp:LinkButton ID="lbt_Box" runat="server" Font-Underline="False" Font-Bold="True"
                ForeColor="#006600">Hộp tin nhắn</asp:LinkButton>
        </div>
        <div style="border: 1px solid #CCCCCC; height: 2px; background-color: #333333;">
        </div>
        <div style="height:auto; margin:10px;">
            <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Left" BorderColor="White"
                BorderStyle="Solid" BorderWidth="1px">
                &nbsp;&nbsp;<asp:LinkButton ID="lbt_MessTo" runat="server" OnClick="lbt_MessTo_Click" Font-Underline="False">Tin Nhắn Đến</asp:LinkButton>
                <br />
                &nbsp;
                <asp:LinkButton ID="lbt_MessNew" runat="server" OnClick="lbt_MessNew_Click" Font-Underline="False">Soạn Tin Nhắn</asp:LinkButton>
                <br />
                &nbsp;
            </asp:Panel>
        </div>
        <div style="border: 1px solid #CCCCCC; height: 1px; background-color: #333333;">
        </div>
        <div style="margin:1px;">
            <uc2:ListFriendSimple ID="ListFriendSimple1" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="border: 1px solid #999999; height:auto; width: 100%">
        <div style="border-color: #CCCCCC; background-image: url('../Image/1g.gif'); width:100%; height:25px; background-repeat: repeat-x;">
            
        </div>
        <div style="border-color:White; border-width:0px;">
            <div style="margin:15px">
                <uc3:MessageNew ID="MessageNew1" runat="server" Visible="false" />
                <uc4:LoadInbox ID="LoadInbox1" runat="server" Visible="true" />
            </div>
        </div>
    </div>

</asp:Content>
