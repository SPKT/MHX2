<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_E.Master" AutoEventWireup="true"
    CodeBehind="EditAccount.aspx.cs" Inherits="SPKTWeb.Accounts.EditAccount" %>
        <%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .accordion
        {
            width: 100%;
        }
        .accordionHeader
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

    <div align="center" style="width:100%; margin-top:10px;">
     
                    <div class="accordionHeader">
                        Tên Tài Khoản:
                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="accordionContent">
                            <asp:Label ID="lbluser" Text="Tên tài khoản không thể thay đổi" runat="server"></asp:Label>
                    </div>
                    <div class="accordionHeader">
                        Tên Hiển Thị:
                        <asp:Label ID="lblOldTenHienThi" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="accordionContent">
                        <asp:Label ID="lblTenHienThi" Text="Tên hiển thị:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtTenHienThi" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnSaveTenHienThi" runat="server" Text="Lưu thay đổi" OnClick=" btnSaveTenHienThi_Click" />
                        <asp:Label ID="lblDisplaynameMessage" Text="" runat="server"></asp:Label>
                   </div>
                    <div class="accordionHeader">
                        Mật Khẩu
                        </div>
                    <div class="accordionContent">
                        <asp:label ID="lblAuthentication" runat="server" />
                        <br />
                        <asp:Label ID="lblOldPass" Text="Mật khẩu cũ" runat="server"></asp:Label>
                        <asp:TextBox ID="txtOlaPass" TextMode="Password" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblNewPass" Text="Mật khẩu mới" runat="server"></asp:Label>
                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnSavePass" runat="server" Text="Lưu thay đổi" OnClick="btnSavePass_Click" />
                        <asp:Label ID="lblErrorpass" Text="" runat="server"></asp:Label>
                 </div>
                <div class="accordionHeader">
                        Email: <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </div>
                <div class="accordionContent">
                        <asp:Label ID="lblnewemail" Text="Sử dụng Email mới:" runat="server"></asp:Label>
                        <asp:TextBox ID="txtNewEmail"  runat="server"></asp:TextBox>
                        <br />
                         <asp:Label ID="Label1" Text="Mật khẩu:" runat="server"></asp:Label>
                         <asp:TextBox ID="txtVeriPass" TextMode="Password"  runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnSaveNewEmail" runat="server" Text="Lưu thay đổi" OnClick="btnSaveNewEmail_Click" />
                         <asp:Label ID="lblEmailMessage" Text="" runat="server"></asp:Label>
                    </div>
                
                
                <asp:Panel ID="pnlUseAuthen" runat="server" Visible="true">
                    <div class="accordionHeader">
                        Thay đổi cách sử dụng chứng thực (chỉ chọn được quyền chứng thực bằng tài khoản website mạng xã hội khi đã đổi mật khẩu một lần) </asp:Label></Header>
                    </div>
                    <div class="accordionContent">
                        <asp:Label ID="lbl1" Text="Bạn đang sử dụng quyền chứng thực:" runat="server"></asp:Label><br />
                        <asp:RadioButton ID="rdbUseDKMH" GroupName="use" Text="Sử dụng chứng thực bằng tài khoản đăng ký môn học" runat="server" /><br />
                        <asp:RadioButton ID="rdbUseMXH" GroupName="use" Text="Sử dụng chứng thực bằng tài khoản website Mạng xã hội" runat="server" /><br />
                        <asp:Button ID="btnSave" runat="server" Text="Lưu thay đổi" OnClick="btnSaveUserAuthentication_Click" />
                        
                         <asp:Label ID="lblUseAuthen" Text="" runat="server"></asp:Label>
                  </div>
                  </asp:Panel>
    </div>
<%--        <div align="center" style="width:100%;">
        <asp:Accordion ID="Accordion1"  CssClass="accordion" TabIndex="-1" HeaderCssClass="accordionHeader"
            HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
            runat="server">
            <Panes>
                <asp:AccordionPane  ID="AccordionPane1" runat="server">
                    <Header>
                        Tên Tài Khoản:
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></Header>
                    <Content>
                        <div>
                            <asp:Label ID="Label3" Text="Tên tài khoản không thể thay đổi" runat="server"></asp:Label>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>
                        Tên Hiển Thị:
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    </Header>
                    <Content>
                        <asp:Label ID="Label5" Text="Tên hiển thị:" runat="server"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Lưu thay đổi" OnClick=" btnSaveTenHienThi_Click" />
                        <asp:Label ID="Label6" Text="" runat="server"></asp:Label>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>
                        Mật Khẩu</Header>
                    <Content>
                        <asp:label ID="Label7" runat="server" />
                        <br />
                        <asp:Label ID="Label8" Text="Mật khẩu cũ" runat="server"></asp:Label>
                        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label9" Text="Mật khẩu mới" runat="server"></asp:Label>
                        <asp:TextBox ID="TextBox3" TextMode="Password" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Lưu thay đổi" OnClick="btnSavePass_Click" />
                        <asp:Label ID="Label10" Text="" runat="server"></asp:Label>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>
                        Email: <asp:Label ID="Label11" runat="server" Text=""></asp:Label></Header>
                    <Content>
                        <asp:Label ID="Label12" Text="Sử dụng Email mới:" runat="server"></asp:Label>
                        <asp:TextBox ID="TextBox4"  runat="server"></asp:TextBox>
                        <br />
                         <asp:Label ID="Label13" Text="Mật khẩu:" runat="server"></asp:Label>
                         <asp:TextBox ID="TextBox5" TextMode="Password"  runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button3" runat="server" Text="Lưu thay đổi" OnClick="btnSaveNewEmail_Click" />
                         <asp:Label ID="Label14" Text="" runat="server"></asp:Label>
                    </Content>
                </asp:AccordionPane>
                
                <asp:AccordionPane ID="AccordionPane5" runat="server" Enabled="true">
                    <Header>
                        Thay đổi cách sử dụng chứng thực (chỉ chọn được quyền chứng thực bằng tài khoản website mạng xã hội khi đã đổi mật khẩu một lần) </asp:Label></Header>
                    <Content>
                        <asp:Label ID="Label15" Text="Bạn đang sử dụng quyền chứng thực:" runat="server"></asp:Label><br />
                        <asp:RadioButton ID="RadioButton1" GroupName="use" Text="Sử dụng chứng thực bằng tài khoản đăng ký môn học" runat="server" /><br />
                        <asp:RadioButton ID="RadioButton2" GroupName="use" Text="Sử dụng chứng thực bằng tài khoản website Mạng xã hội" runat="server" /><br />
                        <asp:Button ID="Button4" runat="server" Text="Lưu thay đổi" OnClick="btnSaveUserAuthentication_Click" />
                        
                         <asp:Label ID="Label16" Text="" runat="server"></asp:Label>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </div>--%>
</asp:Content>
