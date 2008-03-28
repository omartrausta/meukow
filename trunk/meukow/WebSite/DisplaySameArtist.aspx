<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DisplaySameArtist.aspx.cs" Inherits="DisplaySameArtist" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 id="m_artistconflict" runat="server">
        Flytjandi er þegar til í grunni
    </h2>
    <asp:Button ID="m_btnGoBack" runat="server" Text="Til Baka" OnClick="OnGoBack" />
</asp:Content>
