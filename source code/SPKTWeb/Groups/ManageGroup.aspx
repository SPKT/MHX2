<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MXH_P.master" CodeBehind="ManageGroup.aspx.cs" Inherits="SPKTWeb.Groups.ManageGroup" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            .divMain
            {
                width:600px;
                height: auto;
               
                border-color: Blue;
            }
            .divContainer
            {
               margin: 5px;
            }
            .divtitle
            {
                color: Gray;
                font-size:x-large;
                text-align:center;
            }
        .divContainerCell { display: block; text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:5px;background-color:#d8dfea;color:Teal;border-bottom:solid 1px #a3bdef;border-top:solid 1px #5c76a4; font-weight:bold;text-align:left;padding-bottom:5px;padding-top:5px;padding-left:5px;}
        .divContainerCellHeader {display:block; height:100%;padding-right:5px; width:150px;text-align:right;font-weight:bold;float:left; }
        .divInnerRowHeader {text-align: right; width: 100px; font-size: 10px; color: #000000; font-weight:bold; float:left; padding-right: 5px; }
        .divInnerRowCell { width: 100%; font-size: 10px; color: #000000; padding-left: 5px; }
        .divContainerHelpText { font-size:10px; color:#777777; font-weight:normal; }
        .divContainerSeparator { border-top:solid 1px #a3bdef; padding-top: 5px; padding-bottom: 5px; }
        .Wizard { width:90%;padding:10px 10px 10px 10px; }
        .style1
        {
            color: #FF6666;
            font-size: x-large;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div style="margin-left:5%; width:80%">
        <div class="style1">
            Tạo Group mới
        </div>
     <div class="divContainer">
       
            <div class="divContainerRow">
                <br />
                <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                <div class="divContainerCellHeader">Name:
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></div>
                <div class="divContainerCell"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
                <div class="divContainerCellHeader" style="margin-left:-8px;">Public:</div>
                <div class="divContainerCell"><asp:CheckBox id="chkIsPublic" runat="server" /></div>
                <div class="divContainerCellHeader" style=" margin-left:-160px;">Logo:</div>
                <div class="divContainerCell"><asp:FileUpload ID="fuLogo" runat="server" /></div>
                <div class="divContainerCell"><asp:Image ID="imgLogo" runat="server" /></div>
                
                <div class="divContainerCellHeader">Description:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescriptionEditor" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></div><div class="divContainerCell">&nbsp;
               
                </div>
                <div class="divContainerCell">
                    <cc1:Editor ID="txtDescriptionEditor" runat="server" />
                </div>
                <div class="divContainerCell"><div style="font-size:10px;color:#FF0000;">This text is public and will be seen by all!</div></div>
                
                <div class="divContainerCellHeader">Page Body:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBodyEditor" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator></div><div class="divContainerCell">&nbsp;</div>
                <div class="divContainerCell">
                    <cc1:Editor ID="txtBodyEditor" runat="server" />
                </div>
                <div class="divContainerCell"><div style="font-size:10px;color:#FF0000;">This text is private and will only be seen by members if this is a private group!</div></div>
                
                <div class="divContainerCellHeader">Group Types:</div>
                <div class="divContainerCell"><asp:ListBox ID="lbGroupTypes" runat="server" SelectionMode="Multiple"></asp:ListBox></div>
                
                <asp:Literal Visible="false" ID="litGroupID" runat="server" Text="0"></asp:Literal>
                <asp:Literal Visible="false" ID="litAccountID" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litCreateDate" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litUpdateDate" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litMemberCount" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litTimestamp" runat="server"></asp:Literal>
                <asp:Literal Visible="false" ID="litFileID" Text="0" runat="server"></asp:Literal>
            </div>  
            <div class="divContainerFooter">
                <asp:Button ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" runat="server" />
            </div>
        </div>
  
    </div>
    
</asp:Content>

