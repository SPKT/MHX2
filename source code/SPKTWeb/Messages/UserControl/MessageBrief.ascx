<%@ Register src="~/Messages/UserControl/MessageNew.ascx" tagname="MessageNew" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBrief.ascx.cs" Inherits="SPKTWeb.Messages.UserControl.MessageBrief" %>
<div>
  <asp:Panel runat="server" ID="panel1">
<div id="div_brief" runat="server" style="background-color: #FFFFFF; border: 1px solid #CCCCCC;">
   <table width="100%">
    <tr>
        <td style="width:97%">
            <asp:CheckBox ID="CheckBox1" runat="server" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lb_To" runat="server" Font-Italic="True" ForeColor="#0066FF"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="lb_Subject" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="lb_Content" runat="server" Font-Underline="False" 
        ForeColor="Black" onclick="lb_Content_Click"></asp:LinkButton>
    <asp:Label ID="lb_MessageID" runat="server" Visible="False"></asp:Label>
        </td>
        <td align="center" style="width:3%">
            
            <asp:ImageButton ID="Image1" runat="server" 
                ImageUrl="~/Image/expand.jpg" style="height: 13px" /> 
                
        </td>
    </tr>
    
    </table>
</div>
</asp:Panel>
<asp:Panel runat="server" ID="panel2" Visible="False">
<div id="div1" runat="server" style="border: 1px solid #CCCCCC; background-image: url('../../Image/block_topbg.gif');">
   <table width="100%">
    <tr>
        <td style="width:97%">
            <asp:CheckBox ID="CheckBox2" runat="server" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbTo_1" runat="server" Font-Italic="True" ForeColor="#0066FF"></asp:Label>
&nbsp;&nbsp;
    <asp:Label ID="lb_subject_1" runat="server"></asp:Label>
&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="False" 
        ForeColor="Black" onclick="lb_Content_Click"></asp:LinkButton>
    <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
            &nbsp;
            <asp:Label ID="lb_Thoigian" runat="server" Font-Italic="True" 
                ForeColor="#FF6600"></asp:Label>
        </td>
        <td align="center" style="width:3%">
            
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/collapse.jpg" /> 
                
        </td>
    </tr>
    
    </table>
</div>
<div id="div_content" runat="server" style="border: 1px solid #999999; height:auto">
 
    &nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lb_Noidung" runat="server"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbt_Traloi" runat="server" onclick="lbt_Traloi_Click">Trả lời</asp:LinkButton>

 &nbsp;&nbsp;
    <asp:LinkButton ID="lbt_Xoa" runat="server" onclick="lbt_Xoa_Click">Xóa</asp:LinkButton>
        
</div>
</asp:Panel>
  
</div>
