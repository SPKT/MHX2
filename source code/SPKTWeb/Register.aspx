<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SPKTWeb.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="up1">
  <ContentTemplate>
    Username: <asp:TextBox runat="server" id="Username" 
    AutoPostBack="true" OnTextChanged="Username_Changed" />
    <div runat="server" id="UserAvailability"></div><br />
  </ContentTemplate>
</asp:UpdatePanel>    
    </div>
    </form>
</body>
</html>
