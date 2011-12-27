<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_R.Master" AutoEventWireup="true" CodeBehind="ViewPost1.aspx.cs" Inherits="SPKTWeb.Forums.ViewPost1" %>
<%@ Register src="UserControl/ForumHeader.ascx" tagname="ForumHeader" tagprefix="uc1" %>
<%@ Register src="UserControl/Viewpost.ascx" tagname="Viewpost" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
<div>
    <div>
    
    </div>
    <div>

        <uc1:ForumHeader ID="UCForumHeader" runat="server" />

    </div>
    <div>
        
    </div>
    <div>
        <uc2:Viewpost ID="UCViewpost" runat="server" />
    </div>
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
