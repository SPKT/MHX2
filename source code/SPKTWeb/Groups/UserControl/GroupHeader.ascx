<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupHeader.ascx.cs" Inherits="SPKTWeb.Groups.UserControl.GroupHeader" %>
<div class="divContainerRow" style="width:100%; height:auto">
                <asp:Label ForeColor="Red" ID="lblMessage" runat="server"></asp:Label>
                <asp:Panel ID="pnlPublic" runat="server">
                    <div style="float: none;">
                        
                        <div style="float: left;">
                        <asp:Label ID="lblName" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label><br />
                            <asp:Image ID="imgGroupLogo" Width="120px" Height="80px" runat="server" /></div>
                        <div style="text-align: right;">
                            <asp:Label ID="lblPrivateMessage" ForeColor="Red" runat="server" Text="Group này không cho phép người ngoài xem!"></asp:Label>
                            <asp:LinkButton ID="lbRequestMembership" OnClick="lbRequestMembership_Click" Text="Tham gia nhóm!"
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
                    <asp:LinkButton ID="lbForum" Visible="false"  Text="View Forum" runat="server"></asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lbViewMembers" OnClick="lbViewMembers_Click" Text="Thành Viên" runat="server"></asp:LinkButton>
                    
                    <asp:Label ID="lblBody" runat="server"></asp:Label>
                </asp:Panel>
</div>