<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplaySong.aspx.cs" Inherits="DisplaySong" Title="Lög"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <asp:GridView ID="m_songGridView" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="m_songGridView_SelectedIndexChanged">
        <Columns>
            <asp:HyperLinkField DataTextField="Name" HeaderText="Lag" DataNavigateUrlFields="SongPath" DataNavigateUrlFormatString="{0}" />
            <asp:BoundField DataField="Artist" HeaderText="Flytjandi" />
            <asp:BoundField DataField="Description" HeaderText="L&#253;sing" />
            <asp:HyperLinkField 
				DataNavigateUrlFields="ID" 
				DataNavigateUrlFormatString="~/DisplaySongBlog.aspx?ID={0}"
				HeaderText="Blogg" Text="Sko&#240;a" />
        </Columns>
        
    </asp:GridView>
    
</asp:Content>


    
        