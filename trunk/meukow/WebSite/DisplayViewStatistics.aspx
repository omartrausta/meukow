<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayViewStatistics.aspx.cs" Inherits="DisplayViewStatistics" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:Image ID="m_statImage" runat="server" Height="95px" OnLoad="OnLoadPicture"
        Width="138px" ImageAlign="Middle" />
       <p> 
    <asp:Label ID="lbl_selectChartPos" runat="server" Text="VelduSæli"></asp:Label>
    <p>
    <asp:DropDownList ID="ddl_selectPos" runat="server">
    </asp:DropDownList>
    <p>
    <asp:Button ID="m_btnSelectPos" runat="server" Text="Teikna Súlurit" OnClick="OnDrawGraph" /></asp:Content>

