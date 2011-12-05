<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SPKTWeb.Messages.WebForm1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AJAX CONTROL: Accordion Pane Show</title>
    <link href="MyStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" width="50%" align="center">
            <tr>
                <td>
                    <ajaxtoolkit:toolkitscriptmanager id="ScriptManager1" runat="server" />
                    <div>
                        <ajaxtoolkit:accordion id="Accordion1" runat="server" fadetransitions="True" selectedindex="0"
                            transitionduration="300" headercssclass="accordionHeader"
contentcssclass="accordionContent">
                            <Panes>
                                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                                    <Header>
                                        AJAX FIRST PANE</Header>
                                    <Content>
                                        AJAX FIRST PANE AJAX FIRST PANE AJAX FIRST PANE AJAX FIRST PANE
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                    <Header>
                                        AJAX SECOND PANE
                                    </Header>
                                    <Content>
                                        AJAX SECOND PANE AJAX SECOND PANE AJAX SECOND PANE AJAX SECOND PANE
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                                    <Header>
                                        AJAX THIRD PANE
                                    </Header>
                                    <Content>
                                        AJAX THIRD PANE AJAX THIRD PANE AJAX THIRD PANE AJAX THIRD PANE
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                                    <Header>
                                        AJAX FOURTH PANE
                                    </Header>
                                    <Content>
                                        AJAX FOURTH PANE AJAX FOURTH PANE AJAX FOURTH PANE AJAX FOURTH PANE
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                            </Panes>
                        </ajaxtoolkit:accordion>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>