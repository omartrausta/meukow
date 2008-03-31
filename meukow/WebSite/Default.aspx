<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Meukow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="m_listGridView" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CssClass="lists" EnableViewState="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/DisplayChart.aspx?ID={0}"
                DataTextField="Name" HeaderText="Listi" />
            <asp:BoundField DataField="Starts" HeaderText="Byrjar" DataFormatString="{0:dd.MM.yyyy}" >
                <ControlStyle BorderWidth="5px" />
            </asp:BoundField>
            <asp:BoundField DataField="Ends" HeaderText="Endar" DataFormatString="{0:dd.MM.yyyy}" />
        </Columns>
        <EditRowStyle BorderWidth="2px" />
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
    </asp:GridView>
</asp:Content>

