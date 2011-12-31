<%@ Register Src="~/Photo/UserControl/FileItem.ascx" TagName="file" TagPrefix="uc1" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileListItemAlbum.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.FileListItemAlbum" %>
<div style="width: 100%; height: auto; margin: 5px; margin-left: 0px; background-color: White;">
    
                <asp:Repeater ID="repFiles" runat="server" OnItemDataBound="repFiles_ItemDataBound">
                    <ItemTemplate>
                        <uc1:file ID="file1" runat="server"></uc1:file>
                    </ItemTemplate>
                </asp:Repeater>
            
       
</div>