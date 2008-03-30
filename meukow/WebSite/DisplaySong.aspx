<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplaySong.aspx.cs" Inherits="DisplaySong" Title="L�g"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <asp:GridView ID="m_songGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="m_songGridView_SelectedRow">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="SongPath" DataTextField="Name" HeaderText="Lag" />
            <asp:BoundField DataField="Artist" HeaderText="Flytjandi" />
            <asp:BoundField DataField="Description" HeaderText="L&#253;sing" />
            <asp:HyperLinkField 
				DataNavigateUrlFields="ID" 
				DataNavigateUrlFormatString="~/DisplaySongBlog.aspx?ID={0}"
				HeaderText="Blogg" Text="Sko&#240;a" />
        </Columns>
    </asp:GridView>
</asp:Content>

