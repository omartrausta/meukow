<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayViewStatistics.aspx.cs" Inherits="DisplayViewStatistics" Title="Tölfræði" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <asp:Panel ID="m_statPanel" runat="server" Height="297px" ScrollBars="Horizontal"
        Width="750px">
        <asp:Image ID="m_statImage" runat="server" Height="164px" OnLoad="OnLoadPicture"
        Width="532px" ImageAlign="Middle" /></asp:Panel>
       <p> 
    <asp:Label ID="lbl_selectChartPos" runat="server" Text="VelduSæti"></asp:Label>
    <p>
    <asp:DropDownList ID="ddl_selectPos" runat="server">
    </asp:DropDownList>
    <p>
    <asp:Button ID="m_btnSelectPos" runat="server" Text="Teikna Súlurit" OnClick="OnDrawGraph" /></asp:Content>

