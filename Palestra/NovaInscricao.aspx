<%@ Page Title="Inscrição" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovaInscricao.aspx.cs" Inherits="Palestra.NovaInscricao" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h3>Inscrição</h3>
        <table>
            <tr>
                <td>Nome: </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server" Width="320px" MaxLength="40" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>CPF: </td>
                <td>
                    <asp:TextBox ID="txtCPF" runat="server" Width="320px" TabIndex="2"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCPF" Mask="999,999,999-99" />
                    <asp:RequiredFieldValidator ID="rfvCPF" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCPF"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Data de nascimento: </td>
                <td>
                    <asp:TextBox ID="txtDataNascimento" runat="server" Width="320px" TabIndex="3"></asp:TextBox>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDataNascimento" Mask="99/99/9999" />
                    <asp:RequiredFieldValidator ID="rfvDataNascimento" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDataNascimento"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-bottom:solid 1px"><br />Arquivos</td>
            </tr>
            <tr>
                <td>Cópia do RG: </td>
                <td>
                    <asp:FileUpload ID="fileUploadRG" runat="server" Width="320px" />
                </td>
            </tr>
            <tr>
                <td>Cópia do CPF: </td>
                <td>
                    <asp:FileUpload ID="fileUploadCPF" runat="server" Width="320px" />
                </td>
            </tr>
            <tr>
                <td>Cópia de contrato de trabalho: </td>
                <td>
                    <asp:FileUpload ID="fileUploadContrato" runat="server" Width="320px" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td><br /><br /><asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" /><asp:Label ID="lblNumeroInscricao" runat="server" Text="" ForeColor="Green" Font-Size="Large"></asp:Label></td>
            </tr>            
        </table>
    </div>
    <div class="row">
    </div>
</asp:Content>
