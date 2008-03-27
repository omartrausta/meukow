<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="m_listGridView" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="5">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/DisplayChart.aspx?ID={0}"
                DataTextField="Name" HeaderText="Listi" />
            <asp:BoundField DataField="Starts" HeaderText="Byrjar" DataFormatString="{0:dd.MM.yyyy}" >
                <ControlStyle BorderWidth="5px" />
            </asp:BoundField>
            <asp:BoundField DataField="Ends" HeaderText="Endar" DataFormatString="{0:dd.MM.yyyy}" />
        </Columns>
        <EditRowStyle BorderWidth="2px" />
    </asp:GridView>
</asp:Content>

