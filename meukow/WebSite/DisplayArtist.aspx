<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayArtist.aspx.cs" Inherits="DisplayArtist" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="m_artistGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataTextField="Name" HeaderText="Flytjandi" />
            <asp:BoundField DataField="Description" HeaderText="L&#253;sing" />
            <asp:ImageField DataImageUrlField="Picture" HeaderText="Mynd">
            </asp:ImageField>
      
        </Columns>
    </asp:GridView>
</asp:Content>

