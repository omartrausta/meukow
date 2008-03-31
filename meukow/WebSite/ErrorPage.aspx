<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="PageError" Title="Eitthvað mis..." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<p>
		Því miður hefur komið upp villa, umsjónarmanni kerfisins hefur verið gert viðvart.
	</p>
	<asp:LinkButton ID="m_lnkShowDetails" runat="server" OnClick="OnShowDetails">Smelltu hér til að sjá nánari villuskilaboð</asp:LinkButton>
	<asp:Panel ID="m_pnlDetailedMessage" runat="server">
	</asp:Panel>
		<table align="left" width="100%">
			<tr>
				<td valign="top">
					Message:</td>
				<td valign="top">
					<asp:Label ID="m_lblErrorMessage" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td valign="top">
					Source:</td>
				<td valign="top">
					<asp:Label ID="m_lblSource" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td valign="top">
					Source:</td>
				<td valign="top">
					<asp:Label ID="m_lblStackTrace" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td valign="top">
					Help link:</td>
				<td valign="top">
					<asp:Label ID="m_lblHelpLink" runat="server"></asp:Label></td>
			</tr>
		</table>
</asp:Content>

