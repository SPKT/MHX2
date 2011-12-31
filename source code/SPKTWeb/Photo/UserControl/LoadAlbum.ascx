<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoadAlbum.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.LoadAlbum" %>
<%@ Register Src="~/Photo/UserControl/FolderItem.ascx" TagName="file1" TagPrefix="uc1" %>
<div style="width: 100%; height: auto; margin: 5px; margin-left: 0px; background-color: White;">
    
                <asp:Repeater ID="repFiles" runat="server" OnItemDataBound="repFiles_ItemDataBound">
                    <ItemTemplate>
                        <uc1:file1 ID="file1" runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            
</div>
