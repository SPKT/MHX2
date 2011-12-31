<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SPKTWeb.Photo.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">




<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Upload Files</title>
</head>
<body>
    <form id="form1" 
          runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" 
                        runat="server" />
        <br />
        
        <asp:Button ID="Button1" 
                    runat="server" 
                    OnClick="Button1_Click" 
                    Text="Upload" />
        
        </div>
    </form>
</body>
</html>