<%@ Page Title="Inscrição" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnaliseInscricao.aspx.cs" Inherits="Palestra.AnaliseInscricao" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>

        function EsconderMotivo(id)
        {
            var control = document.getElementById(id.id);
            if (control.value == 3) 
                document.getElementById('MainContent_txtMotivo').disabled = '';
            else
                document.getElementById('MainContent_txtMotivo').disabled = 'disabled';
        } 

 </script>
    <div class="jumbotron">
        <h3><asp:Label ID="lblInscricao" runat="server"></asp:Label></h3>
        <table>
            <tr>
                <td>Nome: </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server" Width="320px" MaxLength="40" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>CPF: </td>
                <td>
                    <asp:TextBox ID="txtCPF" runat="server" Width="320px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Data de nascimento: </td>
                <td>
                    <asp:TextBox ID="txtDataNascimento" runat="server" Width="320px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Cópia do RG: </td>
                <td>
                    <asp:LinkButton ID="lnkCopiaRG" runat="server" Width="320px" OnClick="lnkCopiaRG_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>Cópia do CPF: </td>
                <td>
                    <asp:LinkButton ID="lnkCopiaCPF" runat="server" Width="320px" OnClick="lnkCopiaCPF_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>Cópia de contrato de trabalho: </td>
                <td>
                    <asp:LinkButton ID="lnkCopiaContrato" runat="server" Width="320px" OnClick="lnkCopiaContrato_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>Situação: </td>
                <td>
                    <asp:DropDownList ID="drpSituacao" runat="server" Width="320px" onchange="EsconderMotivo(this);" >
                        <asp:ListItem Value="1" Text="Pendente"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Aceita"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Não aceita"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Motivo: </td>
                <td>
                    <asp:TextBox ID="txtMotivo" runat="server" Width="320px" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <br />
                    <br />
                    <asp:Button ID="btnSalvar" runat="server" Text="Gravar" OnClick="btnSalvar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </td>
            </tr>            
        </table>
    </div>
    <div class="row">
    </div>
</asp:Content>
