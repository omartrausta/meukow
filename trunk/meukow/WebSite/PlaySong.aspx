<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PlaySong.aspx.cs" Inherits="Default2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div>
 <object id="Player" classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">
            <param name="autoStart" value="True" />
            <param name="URL" value="<%=url_filename %>" />
            <param name="rate" value="1" />
            <param name="balance" value="0" />
            <param name="enabled" value="true" />
            <param name="enabledContextMenu" value="true" />
            <param name="fullScreen" value="false" />
            <param name="playCount" value="1" />
            <param name="volume" value="100" />
        </object>
    </div>
    <asp:GridView ID="GridView1" runat="server" onselectedindexchanging="GridView1_SelectedIndexChanging">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CommandName="select" Text="Button" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
</asp:Content>

