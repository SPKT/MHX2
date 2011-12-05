<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="UseComment.aspx.cs" Inherits="SPKTWeb.Comments.UseComment" %>
<%@ Register src="UserControl/BoxComment.ascx" tagname="BoxComment" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main_1" runat="server">
    <div style="height:500px; background-color: #FFFFFF;" align="center">
        <uc1:BoxComment ID="BoxComment1" runat="server" />
    </div>
</asp:Content>
