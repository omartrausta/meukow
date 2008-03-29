<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplaySong.aspx.cs" Inherits="DisplaySong" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="m_songGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataTextField="Name" HeaderText="Lag" />
            <asp:BoundField DataField="Artist" HeaderText="Flytjandi" />
            <asp:BoundField DataField="Description" HeaderText="L&#253;sing" />
        </Columns>
    </asp:GridView>
</asp:Content>

