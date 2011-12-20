<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MXH_P.master" CodeBehind="ViewGroup.aspx.cs" Inherits="SPKTWeb.Groups.ViewGroup" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<%@ Register src="UserControl/GroupForumUC.ascx" tagname="GroupForumUC" tagprefix="uc1" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            .divMain
            {
                width:100%;
                height: auto;
                background-color:#CCFFCC;
                border-color: Blue;
            }
            .divContainer
            {
               margin: 5px;
               width:80%;
               float:left;
            }
            .divContainerunder
            {
            
               width:20%;
               float:left;
               border-color: Blue;
            }
            .divtitle
            {
                color: Gray;
                font-size:x-large;
                text-align:center;
            }
            .divForum
            {
                float:right;
                <%--width:75%;--%>
            }
        .divContainerCell { display: block; text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:5px;background-color:#d8dfea;color:Teal;border-bottom:solid 1px #a3bdef;border-top:solid 1px #5c76a4; font-weight:bold;text-align:left;padding-bottom:5px;padding-top:5px;padding-left:5px;}
        .divContainerCellHeader {display:block; height:100%;padding-right:5px; width:150px;text-align:right;font-weight:bold;float:left; }
        .divInnerRowHeader {text-align: right; width: 100px; font-size: 10px; color: #000000; font-weight:bold; float:left; padding-right: 5px; }
        .divInnerRowCell { width: 100%; font-size: 10px; color: #000000; padding-left: 5px; }
        .divContainerHelpText { font-size:10px; color:#777777; font-weight:normal; }
        .divContainerSeparator { border-top:solid 1px #a3bdef; padding-top: 5px; padding-bottom: 5px; }
        .Wizard { width:90%;padding:10px 10px 10px 10px; }
        .divContainerBox {border:solid 1px #a3bdef; background-color:#ffffff;}
        .style1
        {
            color: #FF6666;
            font-size: x-large;
            text-align: center;
        }
        .divContent{margin:5px;}
    </style>
</asp:Content>
<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="divMain">

    <div class="divContainer">
        <div class="divContainerBox">
            <div class="divContainerRow" style="width:100%;">
                <asp:Label ForeColor="Red" ID="lblMessage" runat="server"></asp:Label>
                <asp:Panel ID="pnlPublic" runat="server">
                    <div style="float: none;">
                        
                        <div style="float: left;">
                        <asp:Label ID="lblName" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label><br />
                            <asp:Image ID="imgGroupLogo" Width="120px" Height="80px" runat="server" /></div>
                        <div style="text-align: right;">
                            <asp:Label ID="lblPrivateMessage" ForeColor="Red" runat="server" Text="Nhóm đang ở chế độ riêng tư!"></asp:Label>
                            <asp:LinkButton ID="lbRequestMembership" OnClick="lbRequestMembership_Click" Text="Tham gia nhóm"
                                runat="server"></asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    Ngày tạo:
                    <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                    Cập nhật cuối:
                    <asp:Label ID="lblUpdateDate" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    <br />
                </asp:Panel>
                <asp:Panel ID="pnlPrivate" runat="server">
                    <asp:HyperLink ID="hylinkForum" Text="View Forum" Visible="false" runat="server"></asp:HyperLink>&nbsp;
                    <asp:HyperLink ID="hylinkViewMembers" Text="Members" NavigateUrl="" runat="server"></asp:HyperLink>
                    
                </asp:Panel>
            </div>
        </div>
        <div class="divContainerunder">
        <asp:Panel ID="pnlMember" runat="server">
            Danh sách thành viên
            <br />
            <asp:Repeater ID="reMember" runat="server" OnItemCommand="reMember_ItemCommand">
                <ItemTemplate>
                    <a href='/Profiles/UserProfile2.aspx?AccountID= <%# ((SPKTCore.Core.Domain.Account)Container.DataItem).AccountID %>'>
                        <img alt='avatar' style="padding: 5px; margin-top: 4px;" id="imgAvatar" width="40px" height="40px"  class="img" src='/image/ProfileAvatar.aspx?AccountID=<%# ((SPKTCore.Core.Domain.Account)Container.DataItem).AccountID %>' />
                    </a>
                   <br />
                    <a style="margin-bottom:35px;" href='/Profiles/UserProfile2.aspx?AccountID=<%# ((SPKTCore.Core.Domain.Account)Container.DataItem).AccountID %>'>
                        <%# ((SPKTCore.Core.Domain.Account)Container.DataItem).UserName %>
                    </a>
                    
                    <br />
                </ItemTemplate>
            </asp:Repeater>
            </asp:Panel>
        </div>
        <div style="float: right; width: 80%">
         <asp:Panel ID="pnlForum" runat="server">
             <uc1:GroupForumUC ID="uc" runat="server" />
                        
        </asp:Panel>

        </div>
    </div>

    <div class="divForum">
        Danh sách các forum của group
    </div>
    </div>
    </asp:Content>