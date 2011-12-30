<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageMember.ascx.cs" Inherits="SPKTWeb.Groups.UserControl.ManageMember" %>
<%@Register Src="~/UserControl/ProfileDisplay.ascx" TagPrefix="SPKT" TagName="ProfileDisplay" %>
    <div class="divContainerBox">
            <div class="divContainerRow">
                <div style="float:left;"><asp:LinkButton OnClick="lbBack_Click" ID="lbBack" 
                        runat="server" Text="Quay Lại"></asp:LinkButton>&nbsp;</div>
                <div style="float:left;"><asp:LinkButton OnClick="lbPrevious_Click" ID="lbPrevious" 
                        runat="server" Text="Trước"></asp:LinkButton>&nbsp;</div>
                <div style="text-align:right;"><asp:LinkButton OnClick="lbNext_Click" ID="lbNext" 
                        runat="server" Text="Tiếp"></asp:LinkButton>&nbsp;</div>
            </div>
            <div class="divContainerTitle">Danh sách thành viên muốn tham gia Group</div>
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
            <div class="divContainerTitle">Danh sách thành viên</div>
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
                    <asp:Button ID="btnApprove" OnClick="btnApprove_Click" runat="server" 
                        Text="Chấp nhận" />
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" 
                        Text="Xóa" />
                    <asp:Button ID="btnPromoteToAdmin" OnClick="btnPromoteToAdmin_Click" 
                        runat="server" Text="Cho phép trở thành Admin của Group" />
                    <asp:Button ID="btnDemoteAdmins" OnClick="btnDemoteAdmins_Click" runat="server" 
                        Text="Xóa chức vụ Admin Group" />
                </asp:Panel>
            </div>
        </div>