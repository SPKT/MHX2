<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SPKTWeb.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="Div1"  style="background-color:Green; margin-top:30px; height:20px" runat="server">
                            <asp:Menu ID="Menu2" runat="server" DataSourceID="HorisontalMenu" DynamicHorizontalOffset="2"
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Height="100%" Orientation="Horizontal"
                            StaticSubMenuIndent="15px" Width="100%">
                            <DynamicHoverStyle BackColor="YellowGreen" ForeColor="White" />
                            <DynamicMenuItemStyle HorizontalPadding="15px" VerticalPadding="2px" />
                            <DynamicMenuStyle BackColor="#B5C7DE" />
                            <DynamicSelectedStyle BackColor="#507CD1" />
                            <StaticHoverStyle BackColor="#660066" ForeColor="White" />
                            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                            <StaticSelectedStyle BackColor="#9966ff" />
                        </asp:Menu>
                        <asp:SiteMapDataSource ID="HorisontalMenu" runat="server" ShowStartingNode="False" SiteMapProvider="HorisontalMenu" />
    </div>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
