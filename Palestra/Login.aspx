<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Palestra.Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Login</h3>
        <table>
            <tr>
                <td>Usuário: </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Senha: </td>
                <td>
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSenha"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnLogin" runat="server" Text="Acessar" OnClick="btnLogin_Click" /></td>
            </tr>
        </table>
    </div>
    <div class="row">
    </div>
</asp:Content>
