<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DisplayEnterArtist.aspx.cs" Inherits="DisplayEnterArtist" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 id="m_studentHeading" runat="server">
        Sláðu inn upplýsingar um flytjanda
        og ýttu á "Uppfæra" takka      
        </h2>
    <table>
        <tr>
            <td>
                Nafn:</td>
            <td>
                <asp:TextBox ID="m_txtName" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="m_validateName" runat="server" ControlToValidate="m_txtName"
                    ErrorMessage="Það verður að slá inn nafn!" Display="Dynamic" ValidationGroup="studentValidationGroup">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Lýsing:</td>
            <td>
                <asp:TextBox ID="m_txtDescription" runat="server"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Slóð á mynd:</td>
            <td>
                <asp:TextBox ID="m_txtPicture" runat="server"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Veffang:</td>
            <td>
                <asp:TextBox ID="m_txtURL" runat="server"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="m_btnAdd" runat="server" OnClick="OnBtnAdd" Text="Uppfæra" ValidationGroup="studentValidationGroup" /></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:ValidationSummary ID="m_validationSummary" runat="server" ValidationGroup="studentValidationGroup" />
</asp:Content>
