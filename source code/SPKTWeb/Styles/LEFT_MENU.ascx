﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LEFT_MENU.ascx.cs" Inherits="SPKTWeb.Styles.LEFT_MENU" %>
<%@ Register Src="~/Friends/UserControl/BoxInvite.ascx" TagName="BoxInvite" TagPrefix="uc1" %>
<%@ Register Src="~/Friends/UserControl/ListFriend.ascx" TagName="FriendList" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
<div class="mainleft" align="center" style="height: 402px; background-color: #FFFFFF;">
    <div style="-moz-border-radius: 10px; -webkit-border-radius: 10px; border-style: solid;
        border-width: 1px 1px 0px 1px; border-color: #999999; width: 89%; height: 42%">
        <div style="margin-top: 15px;">
            <img src="~/Image/ProfileAvatar.aspx" alt="test image" id="testImage" runat="server"
                style="border: 1px solid #666666; width: 160px; height: 120px; background-color: #FFFFFF;"
                onclick="return testImage_onclick()" /></div>
    </div>
    <div style="border: 1px solid #999999; -moz-border-radius: 5px; -webkit-border-radius: 5px;
        margin-top: -6%; background-image: url('/Image/htitle.gif'); background-repeat: repeat-x;
        width: 84%">
        <asp:Label ID="lblProfileName" runat="server" ForeColor="#333333"></asp:Label>
    </div>
    <br />
    <div style="border-color:#999999; border-style:Solid; border-width:1px ; Height:70px; Width:90%;-moz-border-radius:5px;-webkit-border-radius:5px;
             border-bottom-color:White; border-bottom-width:0px;">
        <asp:Panel ID="pn1" runat="server" Height="25px">
        <div class="link" style="color: #C0C0C0; margin-top:2px;">
            <asp:LinkButton ID="lbtnChangeAvatar" runat="server" Text="Đối Avatar" OnClick="lbtnChangeAvatar_Click"
                Font-Underline="False" Width="100%" Height="100%"></asp:LinkButton>
        </div></asp:Panel>
        
        <asp:Panel ID="pn2" runat="server" Height="25px">
        <div class="link">
           <asp:LinkButton ID="LinkButton1" runat="server" Text="Thông tin cá nhân" 
                Font-Underline="False" Width="100%" Height="100%" 
                onclick="LinkButton1_Click"></asp:LinkButton>
        </div></asp:Panel>
    </div>
    <div style="border: 1px solid #999999; -moz-border-radius: 5px; -webkit-border-radius: 5px;
        margin-top: -6%; background-image: url('/Image/htitle.gif'); background-repeat: repeat-x;
        width: 84%">
        <asp:Label ID="Label1" runat="server" ForeColor="#333333" Text="Chào bạn"></asp:Label>
    </div>
    <br />
    <div>
        <aspt:Accordion ID="Accordion1" runat="server" FadeTransitions="True" SelectedIndex="2"
            TransitionDuration="300" HeaderCssClass="accordionHeader" ContentCssClass="accordionContent">
            <Panes>
                <aspt:AccordionPane ID="AccordionPane1" runat="server" TabIndex="0">
                    <Header>
                        <div align="left" class="menu_left">
                            Hộp thư mời
                            <asp:Label ID="lb_invite" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                    </Header>
                    <Content>
                        <div class="menu_left_content">
                            <uc1:BoxInvite ID="boxintvite" runat="server" />
                        </div>
                    </Content>
                </aspt:AccordionPane>
                <aspt:AccordionPane ID="AccordionPane3" runat="server" TabIndex="1">
                    <Header>
                        <div align="left" class="menu_left">
                            Thông điệp
                            <asp:Label ID="lb_message" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </div>
                    </Header>
                    <Content>
                        <div class="menu_left_content">
                        </div>
                    </Content>
                </aspt:AccordionPane>
                <aspt:AccordionPane ID="AccordionPane2" runat="server" TabIndex="2">
                    <Header>
                        <div align="left" class="menu_left">
                            Hộp bạn
                            <asp:Label ID="lb_ban" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </div>
                    </Header>
                    <Content>
                        <div class="menu_left_content">
                            <uc2:FriendList ID="FriendList1" runat="server" />
                        </div>
                    </Content>
                </aspt:AccordionPane>
            </Panes>
        </aspt:Accordion>
    </div>
</div>