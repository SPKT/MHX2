<%@ Page Title="" Language="C#" MasterPageFile="~/MXH1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="SPKTWeb.Profiles.UserProfile" %>
<%@ Register src="UserControls/StatusControl.ascx" tagname="StatusControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .winzard
        {
            display:run-in;
            margin:0;
            padding:0;
            }
        #scroll_box {   height:400px; 
                          display: auto; 
                            border: 1px solid #CCCCCC; 
                              margin: 1em 0; 
                              overflow:scroll; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <div>
        <div class="mainleft">
            <img src="~/Image/ProfileAvatar.aspx" alt="test image" id="testImage" width="145"
                height="100" runat="server" style="border:2px solid #FFCCFF" />
            <div>
                <asp:LinkButton ID="lbtnChangeAvatar" runat="server" Text="Đối Avatar"></asp:LinkButton>
            </div>
            <div>
                <asp:Label ID="lblProfileName" runat="server"></asp:Label>
            </div>
            <div>
            <asp:LinkButton ID="lbtnInfo" Text="Thông Tin" runat="server"></asp:LinkButton>
                <br />
                <asp:LinkButton ID="lbt_DSBB" runat="server" onclick="lbt_DSBB_Click">Danh sách bạn bè</asp:LinkButton>
            </div>
        </div>

        <div class="main">
            <asp:Panel ID="pnlStatusUpdate" runat="server" Width="674px">
                <uc1:StatusControl ID="StatusControl1" runat="server" />
                <br />
            </asp:Panel>
            <asp:Panel ID="pnlAlert" runat="server">
            </asp:Panel>
        </div>
    </div>
</asp:Content>
