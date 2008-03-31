<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayArtistDetails.aspx.cs" Inherits="DisplayArtistDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="height: 2px">
                Nafn:</td>
            <td style="width: 237px; height: 2px">
                <asp:Label ID="lbl_Name" runat="server" Width="233px"></asp:Label></td>
            <td rowspan="3" style="width: 171px">
                <asp:Image ID="m_ArtistImage" runat="server" AlternateText="Engin mynd er af þessum flytjanda!"
                    ImageAlign="Middle" Width="163px" /></td>
        </tr>
        <tr style="color: #000000">
            <td style="height: 133px">
                Lýsing:</td>
            <td style="width: 237px; height: 133px">
                <asp:TextBox ID="m_txtDescription" runat="server" Height="120px" ReadOnly="True"
                    TextMode="MultiLine" Width="230px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 37px">
                Heimasíða:</td>
            <td style="width: 237px; height: 37px">
                <asp:HyperLink ID="m_WebHypelink" runat="server" Width="235px">[m_WebHypelink]</asp:HyperLink></td>
        </tr>
    </table>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</asp:Content>

