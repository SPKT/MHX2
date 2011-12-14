<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Post.ascx.cs" Inherits="SPKTWeb.Groups.UserControl.Post" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
   <div class="divContainer">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
        <div class="divContainerBox">
            <div class="divContainerRow">
                <div class="divContainerCell"><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
                <div class="divContainerCellHeader">Name:</div>
                <div class="divContainerCell"><asp:TextBox Width="400" ID="txtName" runat="server"></asp:TextBox></div>
                <div class="divContainerCellHeader" style="margin-top:3px">Page Name:</div>
                <div class="divContainerCell" style="margin-top:3px"><asp:TextBox Width="400" ID="txtPageName" runat="server"></asp:TextBox></div>
                <br />
                <br />
                <cc1:Editor ID="Editor1" runat="server" />
                <br />
            </div>
            <div class="divContainerFooter"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></div>
        </div>
    </div>