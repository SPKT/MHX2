<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadMessage.aspx.cs" Inherits="SPKTWeb.Messages.ReadMessage" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>CollapsiblePanel</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1" />
    <div style="width: 410px; background: gray;">
        <asp:Panel runat="server" ID="panel1">
        <div style="font-weight: bold; background-color: ThreeDShadow;">
            <table width="100%">
                <tr>
                    <td align="left">Clicking Here To view my profile
                        <asp:Label runat="server" ID="textLabel" />
                    </td>
                    <td align="right" width="10px">
                        <asp:Image ID="Image1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="panel2" Width="98%" HorizontalAlign="center">
        <div>
            <table width="100%">
                <tr valign="top">
                    <td align="left" width="100px">
                        <img src="../Image/ALIEN_01_01.jpg" />
                    </td>
                    <td align="left">Hi<br />This is Purushottam rathore<br />Noida-201301<br />India
                    </td>
                </tr>
            </table>
        </div>
        </asp:Panel>
        <ajaxToolkit:CollapsiblePanelExtender runat="server" ID="cpe" TargetControlID="panel2" CollapseControlID="panel1" ExpandControlID="panel1" Collapsed="true" 
        CollapsedSize="0" ExpandedSize="120" ExpandedText="(Collapse...)" CollapsedText="(Expand...)" TextLabelID="textLabel" ImageControlID="Image1" ExpandedImage="~/Image/collapse.jpg" CollapsedImage="~/Image/expand.jpg">
    </ajaxToolkit:CollapsiblePanelExtender>
</div>
</form>
</body>
</html>
