<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true"
    CodeBehind="EditAccount.aspx.cs" Inherits="SPKTWeb.Accounts.EditAccount" %>
        <%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .accordion
        {
            width: 400px;
        }
        .accordionHeader
        {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #2E4d7B;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }
        .accordionHeaderSelected
        {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }
        .accordionContent
        {
            background-color: #D3DEEF;
            border: 1px dashed #2F4F4F;
            border-top: none;
            padding: 5px;
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
    <div>
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">

    <div align="center">
        <asp:Accordion ID="Accordion1"  CssClass="accordion" TabIndex="-1" HeaderCssClass="accordionHeader"
            HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
            runat="server">
            <Panes>
                <asp:AccordionPane  ID="AccordionPane1" runat="server">
                    <Header>
                        Tên Tài Khoản:
                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></Header>
                    <Content>
                        <div>
                            <asp:Label ID="lbluser" Text="Tên tài khoản không thể thay đổi" runat="server"></asp:Label>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>
                        Tên Hiển Thị:
                        <asp:Label ID="lblOldTenHienThi" runat="server" Text=""></asp:Label>
                    </Header>
                    <Content>
                        <asp:Label ID="lblTenHienThi" Text="Tên hiển thị:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtTenHienThi" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnSaveTenHienThi" runat="server" Text="Lưu thay đổi" OnClick=" btnSaveTenHienThi_Click" />
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>
                        Mật Khẩu</Header>
                    <Content>
                        <asp:Label ID="lblOldPass" Text="Mật khẩu cũ" runat="server"></asp:Label>
                        <asp:TextBox ID="txtOlaPass" TextMode="Password" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblNewPass" Text="Mật khẩu mới" runat="server"></asp:Label>
                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnSavePass" runat="server" Text="Lưu thay đổi" OnClick="btnSavePass_Click" />
                        <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>
                        Email: <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></Header>
                    <Content>
                        <asp:Label ID="lblnewemail" Text="Sử dụng Email mới:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtNewEmail"  runat="server"></asp:TextBox>
                        <br />
                         <asp:Label ID="Label1" Text="Mật khẩu:" runat="server"></asp:Label>
                         <asp:TextBox ID="txtVeriPass" TextMode="Password"  runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnSaveNewEmail" runat="server" Text="Lưu thay đổi" OnClick="btnSaveNewEmail_Click" />
                         <asp:Label ID="lblErrorpass" Text="" runat="server"></asp:Label>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </div>
</asp:Content>
