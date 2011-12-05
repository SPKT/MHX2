<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SPKTWeb.Profiles.Test" %>
<%@ Register Src="~/UserControl/Comments.ascx" Tagname="Comment" Tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
                   <div id="Div1" class="divStatus" runat="server">
                        <asp:GridView ID="gvStatus" runat="server" AutoGenerateColumns="false" BorderColor="#FF33CC"
                            BorderStyle="None" BorderWidth="1px" Width="565px" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <img width="50" height="50" alt="avatar" src='../image/ProfileAvatar.aspx?AccountID=<%#Eval("SenderID")%>&w=50&h=50'
                                            align="middle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="AlertHeader">
                                            <a href='UserProfile2.aspx?AccountID=<%# Eval("SenderID")%>'>
                                                <%#Eval("SenderID")%></a>
                                            <a style="color:Gray">trên tường nhà</a>  <a href='UserProfile2.aspx?AccountID=<%# Eval("AccountID")%>'>
                                                <%#Eval("AccountID")%></a>

                                        </div>
                                        <div style="color:Fuchsia">
                                            <%#Eval("Status") %>
                                        </div>
                                        <div>
                                            Ngày:
                                            <%#Eval("CreateDate") %>
                                        </div>
                                        <div>
                                        <uc2:Comment ID="ucComment1" runat="server" SystemObjectID="1" SystemObjectRecordID='<%#Eval("StatusUpdateID")%>' />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" />
                            <EmptyDataRowStyle BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" />
                        </asp:GridView>
                        <uc2:Comment ID="ucComment2" runat="server" SystemObjectID="1" SystemObjectRecordID="2" />
                        
                    </div>
     
    </div>
    </form>
</body>
</html>
