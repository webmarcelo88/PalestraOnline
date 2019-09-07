<%@ Page Title="Consultar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarInscricao.aspx.cs" Inherits="Palestra.ConsultarInscricao" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Inscrição</h3>
        <table>
            <tr>
                <td>Nº de Inscrição: </td>
                <td>
                    <asp:TextBox ID="txtNumero" runat="server" Width="320px" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td></td>
                <td><br /><br /><asp:Button ID="btnEnviar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" /></td>
            </tr>            
            <tr>
                <td><br /></td>
                <td>
                    <br />
                    <asp:Label ID="lblSituacao" runat="server" Text="" ForeColor="Green" Font-Size="Large"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="row">
    </div>
</asp:Content>
