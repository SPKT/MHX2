<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListFolderShare.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.ListFolderShare" %>
<%@ Register Src="~/Photo/UserControl/ShareFolderItem.ascx" TagName="FolderShare" TagPrefix="uc1" %>
<div style="width: 100%; height: auto; margin: 5px; margin-left: 0px; background-color: White;">
    
                <asp:Repeater ID="repFiles" runat="server" OnItemDataBound="repFiles_ItemDataBound">
                    <ItemTemplate>
                        <uc1:FolderShare ID="file1" runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            
</div>
