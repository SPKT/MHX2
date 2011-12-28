<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Post.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.Post" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
   <div class="divContainer" style="margin-top:2%">
        <div class="divContainerBox">
            <div class="divContainerRow">

                <div class="divContainerCellHeader">Tên bài viết:<div class="divContainerCell"><asp:TextBox Width="400" ID="txtName" runat="server"></asp:TextBox></div>
                </div>
                <br />
                Nội dung:<br />
                <cc1:Editor ID="Editor1" runat="server" />
                <br />
            </div>
            <div class="divContainerFooter"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></div>
        </div>
    </div>