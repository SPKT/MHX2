<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_PE.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="SPKTWeb.Blogs.Post" EnableEventValidation="false" %>
<%@ Register src="../Styles/LEFT_MENU.ascx" tagname="LEFT_MENU" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
    <uc1:LEFT_MENU ID="LEFT_MENU1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
<div>
    <div>
        <div>
            Tiêu đề

        </div>
            
        <div>
            <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
        </div>
        <div style="float:right">
                      <asp:ImageButton Width="20px" Height="20px" ID="ibDelete" runat="server" 
                ImageUrl="/image/icon_close.gif" onclick="ibDelete_Click" />
        </div>
    </div>
    <div>
        <div>
            Chủ đề
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtSubject"></asp:TextBox>
        </div>
    </div>
    <div>   
        <asp:CheckBox ID="ckPubic" Text="Chia sẻ" runat="server" />     
    </div>
    <div>
        
        <cc1:Editor ID="editBody" runat="server" />
        
    </div>
    <div>
        
        <asp:Button ID="btnSave" runat="server" Text="Đăng" onclick="btnSave_Click" />
        
    </div>
</div>
</asp:Content>
