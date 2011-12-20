<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="SPKTWeb.Forums.Post" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>



<%@ Register src="/Forums/UserControl/ForumHeader.ascx" tagname="ForumHeader" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
 .divContainer {font-size:12px;background-image:url(/images/transparent.gif); padding: 10px; width:90%; margin-left:auto;margin-right:auto;text-align:center; }
        .divContainerBox {border:solid 1px #a3bdef; background-color:#ffffff;}
        .divContainerRow { background-color:#ffffff;text-align:left; float:none; padding:5px;}
        .divContainerCell { display: block; text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:5px;background-color:#d8dfea;border-bottom:solid 1px #a3bdef;border-top:solid 1px #5c76a4; font-weight:bold;text-align:left;padding-bottom:5px;padding-top:5px;padding-left:5px;}
        .divContainerCellHeader {display:block; height:100%;padding-right:5px; width:150px;text-align:right;font-weight:bold;float:left; }
        .divInnerRowHeader {text-align: right; width: 100px; font-size: 10px; color: #000000; font-weight:bold; float:left; padding-right: 5px; }
        .divInnerRowCell { width: 100%; font-size: 10px; color: #000000; padding-left: 5px; }
        .divContainerHelpText { font-size:10px; color:#777777; font-weight:normal; }
        .divContainerSeparator { border-top:solid 1px #a3bdef; padding-top: 5px; padding-bottom: 5px; }
        .Wizard { width:90%;padding:10px 10px 10px 10px; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
   <div>
    <div>
        
        <uc1:ForumHeader ID="ForumHeader1" runat="server" />
        
    </div>
    <div>
        Tiêu đề:
    </div>
    <div>
         <div class="divContainerRow">

                <div >Tên bài viết:<div class="divContainerCell"><asp:TextBox Width="400" ID="txtName" runat="server"></asp:TextBox></div>
                </div>
                <br />
                Nội dung:<br />
                <cc1:Editor ID="Editor1" runat="server" />
                <br />
            </div>
            <div class="divContainerFooter"><asp:Button ID="btnSubmit" runat="server" Text="Đăng" OnClick="btnSubmit_Click" /></div>
    </div>
   </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>

