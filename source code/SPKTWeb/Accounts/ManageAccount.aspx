<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_NEW.Master" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="SPKTWeb.Accounts.ManageAccount" %>
<%@ Register src="UserControl/Register.ascx" tagname="Register" tagprefix="uc1" %>
<%@ Register src="UserControl/LoginDesign1.ascx" tagname="LoginDesign1" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="border: 1px solid #CCCCCC; height:85%; -moz-border-radius:10px; -webkit-border-radius:10px;position:fixed; left:0;top:52px; right:0px;margin-left:50px; margin-top:0px; margin-right:50px; background-color:White;">
    <div id="cc" runat="server" 
        style="float:left; margin:10px; margin-left:10px; width:60%; height:100%;" align="center">
        <div style=" margin:30px; margin-left:100px;">
            <uc1:Register ID="Register1" runat="server" Visible="false" />
        </div>
    
    </div>
    <div style="border: 1px solid #9999FF; float:right; margin:0px; width:25%; height:100%; -moz-border-radius:10px; -webkit-border-radius:10px; background-image: url('../../Image/y.gif');">
        <div style="margin:20px; margin-top:20px;">
            
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Đăng ký tài khoản</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server">Thông tin quy định</asp:LinkButton>
            
        </div>
        <div style="margin:20px; margin-top:20px;">
        <uc2:LoginDesign1 ID="LoginDesign11" runat="server" />
        </div>
        
    </div>
</div>

</asp:Content>
