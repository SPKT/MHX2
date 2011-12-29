<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupHeader.ascx.cs"
    Inherits="SPKTWeb.Groups.UserControl.GroupHeader" %>
<div class="divContainerRow" style="width: 100%; height: auto">
    <asp:Label ForeColor="Red" ID="lblMessage" runat="server"></asp:Label>
    &nbsp; &nbsp;
    <asp:Label ID="lblPrivateMessage" ForeColor="Red" runat="server" Text="Group này không cho phép người ngoài xem!"></asp:Label>
    <asp:Panel ID="pnlPublic" runat="server" Width="100%" Height="120px">
        <div style="float: none; width: 100%;">
            <div style="float: left;">
                <div align="left" class="Main_Subject">
                    <asp:Label ID="lblName" runat="server" Font-Bold="true"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="lbRequestMembership" runat="server" OnClick="lbRequestMembership_Click"
                        Text="Tham gia nhóm" Font-Size="Medium"></asp:LinkButton>
                    <br />
                </div>
                <div style="background-color: #CCCCCC; width: 100%; height: 2px; margin-bottom: 0px;">
                </div>
                <div style="float: left; width:100%; margin-top:10px;">
                    <div style="float: left; width: 120px; height: 80px;">
                        <asp:Image ID="imgGroupLogo" Width="100%" Height="100%" runat="server" />
                    </div>
                    <div style="margin-left: 136px; margin-right: 2%; width:auto; margin-top:0px;">
                        Ngày tạo:
                        <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                        <br />
                        Cập nhật cuối:
                        <asp:Label ID="lblUpdateDate" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlPrivate" runat="server">
        <asp:LinkButton ID="lbForum" Visible="false" Text="View Forum" runat="server"></asp:LinkButton>&nbsp;
        <asp:LinkButton ID="lbViewMembers" OnClick="lbViewMembers_Click" Text="Thành Viên"
            runat="server"></asp:LinkButton>
            <asp:HyperLink ID="linkNewThread" runat="server" Text="Tạo bài mới"></asp:HyperLink>
        <%--<asp:Label ID="lblBody" runat="server"></asp:Label>--%>
    </asp:Panel>
</div>
