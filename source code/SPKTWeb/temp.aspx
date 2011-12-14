<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="SPKTWeb.temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <div style="background-color: Blue;">
                <div style="background:#ccffcc; margin: 10px;">
                    tieu de
                </div>
                <div style="background-color:Purple;height:50px;">
                    <div style="float:left; width:45px; height:20px;">
                        avatar
                    </div>
                    <div style="float:none" >
                        <div style="float:left; width:20%">
                            user name
                        </div>
                        <div style="width:20%" >
                            ngày tạo
                        </div>
                    </div>
                </div>
                <div style="background-color:Green">
                    mô tả
                </div>

            </div>
            <div style="background-color: Blue;">
                <div style="background-color:Purple;height:50px;">
                    <div style="float:left; width:45px; height:20px;">
                        avatar
                    </div>
                    <div style="float:none" >
                        <div style="float:left; width:20%">
                            user name
                        </div>
                        <div style="width:20%" >
                            ngày tạo
                        </div>
                    </div>
                </div>
                <div style="background-color:Green">
                    mô tả
                </div>

            </div>

 <asp:ListView id="lvGroups" runat="server" OnItemDataBound="lvGroups_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="groupsList">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    
                    <ItemTemplate>
                   
                   <div>
                     
                            <asp:Literal Visible="false" ID="litImageID" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).FileID %>'></asp:Literal>
                            <asp:Literal ID="litPageName" Visible="false" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).PageName %>'></asp:Literal>
                            <div>
                                <div style="float:left;">
                                    <div style="float:left;">
                                        <div>
                                        <asp:LinkButton OnClick="lbPageName_Click" id="lbPageName" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Name %>'></asp:LinkButton>
                                        </div>
                                        <asp:Image ID="imgGroupImage" Width="60px" Height="60px" runat="server" />
                                    </div>
                                    <div >
                                        <br />
                                        Ngày tạo:<asp:Label ID="Label1" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).CreateDate %>' runat="server"></asp:Label><br />
                                        Mô tả:<asp:Label ID="lbl" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).MemberCount %>' runat="server"></asp:Label><br />
                                        Số lượng thành viên:<asp:Label ID="Label2" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Description %>' runat="server"></asp:Label>
                                    </div>
                                </div>
                                
                                <div style="text-align:right;"><asp:ImageButton Width="20px" Height="20px" ID="ibDelete" OnClick="ibDelete_Click" runat="server" ImageUrl="~/image/icon_close.gif" />
                                <asp:ImageButton Width="20px" Height="20px" ID="ibEdit" OnClick="ibEdit_Click" runat="server" ImageUrl="~/image/pencil.jpg" />
                                </div>
                            </div>  
                         <asp:Literal Visible="false" ID="litGroupID" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).GroupID %>'></asp:Literal>
                        </div>
                        <br />
                        
                        
                       </div>
                    </ItemTemplate>
                    
                    <EmptyDataTemplate>
                        
                    </EmptyDataTemplate>
                </asp:ListView>
    </div>
    </form>
</body>
</html>
