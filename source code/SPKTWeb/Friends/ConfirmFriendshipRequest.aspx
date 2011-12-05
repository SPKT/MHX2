<%@ Page Title="" Language="C#" MasterPageFile="~/MXH1.Master" AutoEventWireup="true" CodeBehind="ConfirmFriendshipRequest.aspx.cs" Inherits="SPKTWeb.Friends.ConfirmFriendshipRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .divContainerCell
    {
        height: 66px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
  <div style="height:567px">
    <div class="divContainer">
        <div class="divContainerBox">
            <asp:Panel ID="pnlConfirm" runat="server">
                <div class="divContainerTitle">Friend Invitation</div>
                <div class="divContainerRow" style="height:105px;">
                    <div class="divContainerCellHeader">
                        <asp:Image Width="100" Height="100" ID="imgProfileAvatar" runat="server" />
                    </div>
                    <div class="divContainerCell">
                        Become <asp:Label ID="lblFullName" runat="server"></asp:Label>'s friend on 
                        <asp:Label ID="lblSiteName1" runat="server"></asp:Label>
                        <hr />
                        Join <asp:Label ID="lblSiteName2" runat="server"></asp:Label> to connect 
                        with your friends, share photos, and create your own profile.  If you 
                        already have an account, 
                        <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click" Text="click here"></asp:LinkButton> 
                        to login and link this requestor as 
                        your friend.  Otherwise 
                        <asp:LinkButton ID="lbCreateAccount" runat="server" OnClick="lbCreateAccount_Click" Text="click here"></asp:LinkButton> 
                        to create an account.
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlError" runat="server" Height="16px">
                <div class="divContainerRow">
                    <div class="divContainerCell">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
  </div>
</asp:Content>
