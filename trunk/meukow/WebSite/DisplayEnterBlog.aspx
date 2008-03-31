<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayEnterBlog.aspx.cs" Inherits="DisplayEnterBlog" Title="Skrifa blogg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 id="m_BlogHeading" runat="server">
        Skrifa blogg og ýta á "Uppfæra" takka      
        </h2>
    <table>
        <tr>
            <td style="height: 26px">
                Titill blogs:</td>
            <td style="width: 159px; height: 26px;">
                <asp:TextBox ID="m_txtTitle" runat="server" Width="437px"></asp:TextBox></td>
            <td style="height: 26px">
                <asp:RequiredFieldValidator ID="m_validateName" runat="server" ControlToValidate="m_txtTitle"
                    ErrorMessage="Það verður að slá inn Titil!" Display="Dynamic" ValidationGroup="studentValidationGroup">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="height: 250px">
                Innihald:</td>
            <td style="width: 159px; height: 250px">
                <asp:TextBox ID="m_txtContent" runat="server" Height="236px" Width="437px"></asp:TextBox></td>
            <td style="height: 250px">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 159px">
                <asp:Button ID="m_btnAdd" runat="server" OnClick="OnBtnAdd" Text="Uppfæra" ValidationGroup="studentValidationGroup" /></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:ValidationSummary ID="m_validationSummary" runat="server" ValidationGroup="studentValidationGroup" />
</asp:Content>

