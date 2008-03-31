<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplaySongDetails.aspx.cs" Inherits="DisplaySongDetails" Title="Um Lagið" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="height: 2px">
                Nafn:</td>
            <td style="width: 237px; height: 2px">
                <asp:Label ID="lbl_Name" runat="server" Width="233px"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td style="height: 23px">
                Flytjandi:</td>
            <td style="width: 237px; height: 23px">
                <asp:Label ID="lbl_Artist" runat="server" Text="Label" Width="232px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 63px">
                Lýsing:</td>
            <td style="width: 237px; height: 63px">
                <asp:TextBox ID="txt_Description" runat="server" Height="51px" ReadOnly="True" TextMode="MultiLine"
                    Width="229px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 37px">
                <asp:HyperLink ID="SongHyperlink" runat="server" Width="296px">Hlusta á lagið</asp:HyperLink></td>
        </tr>
    </table>
</asp:Content>

