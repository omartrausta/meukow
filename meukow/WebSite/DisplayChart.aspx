<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayChart.aspx.cs" Inherits="DisplayChart" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="m_chartGridView" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Position" HeaderText="S&#230;ti" />
            <asp:BoundField DataField="SongName" HeaderText="Lag" />
            <asp:HyperLinkField DataNavigateUrlFields="ArtistID" DataNavigateUrlFormatString="./DisplayArtistDetails.aspx?ID={0}"
                DataTextField="ArtistName" HeaderText="Flytjandi" Text="Flytjandi" />
        </Columns>
    </asp:GridView>
</asp:Content>

