<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MXH_P.master"  CodeBehind="Members.aspx.cs" Inherits="SPKTWeb.Groups.Members" %>
<%@Register Src="~/UserControl/ProfileDisplay.ascx" TagPrefix="SPKT" TagName="ProfileDisplay" %>


<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <style type="text/css">
            .divMain
            {
                width:600px;
                height: auto;
                background-color:#CCFFCC;
                border-color: Blue;
            }
            .divContainer
            {
               margin: 5px;
            }
            .divtitle
            {
                color: Gray;
                font-size:x-large;
                text-align:center;
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
        </style>
</asp:Content>
<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <form id="form1" runat="server">
    <div>
            <div class="divContainer">
        <div class="divContainerBox">
            <div class="divContainerRow">
                <div style="float:left;"><asp:LinkButton OnClick="lbBack_Click" ID="lbBack" runat="server" Text="Back"></asp:LinkButton>&nbsp;</div>
                <div style="float:left;"><asp:LinkButton OnClick="lbPrevious_Click" ID="lbPrevious" runat="server" Text="Previous"></asp:LinkButton>&nbsp;</div>
                <div style="text-align:right;"><asp:LinkButton OnClick="lbNext_Click" ID="lbNext" runat="server" Text="Next"></asp:LinkButton>&nbsp;</div>
            </div>
            <div class="divContainerTitle">Members to approve:</div>
            <div class="divContainerRow">
                <asp:Repeater ID="repMembersToApprove" runat="server" OnItemDataBound="repMembersToApprove_ItemDataBound">
                    <HeaderTemplate><table><tr><td>&nbsp;</td><td>&nbsp;</td></tr></HeaderTemplate>
                    <ItemTemplate>
                        <tr><td>
                            <asp:CheckBox ID="chkProfile" runat="server" />
                        </td><td>
                            <SPKT:ProfileDisplay ID="Profile1" ShowDeleteButton="false" runat="server" />
                        </td></tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
            </div>    
            <div class="divContainerTitle">Members</div>
            <div class="divContainerRow">            
                <asp:Repeater ID="repMembers" runat="server" OnItemDataBound="repMembers_ItemDataBound">
                    <HeaderTemplate><table><tr><td>&nbsp;</td><td>&nbsp;</td></tr></HeaderTemplate>
                    <ItemTemplate>
                        <tr><td>
                            <asp:CheckBox ID="chkProfile" runat="server" />
                        </td><td>
                            <SPKT:ProfileDisplay ID="Profile1" ShowDeleteButton="false" runat="server" />
                        </td></tr>
                    </ItemTemplate>
                    <FooterTemplate></table></FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="divContainerRow">            
                <asp:Label ForeColor="Red" runat="server" ID="lblMessage"></asp:Label>
            </div>
            <div class="divContainerFooter">&nbsp;
                <asp:Panel ID="pnlButtons" runat="server">
                    <asp:Button ID="btnApprove" OnClick="btnApprove_Click" runat="server" Text="Approve" />
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete" />
                    <asp:Button ID="btnPromoteToAdmin" OnClick="btnPromoteToAdmin_Click" runat="server" Text="Promote to Admin" />
                    <asp:Button ID="btnDemoteAdmins" OnClick="btnDemoteAdmins_Click" runat="server" Text="Demote Admins" />
                </asp:Panel>
            </div>
        </div>
    </div>
    </div>
    </form>
</asp:Content>