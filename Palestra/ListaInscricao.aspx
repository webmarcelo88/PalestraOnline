<%@ Page Title="Inscrições" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaInscricao.aspx.cs" Inherits="Palestra.ListaInscricao" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Inscrições</h3>
        <asp:GridView ID="gridInscricao" runat="server" OnRowCommand="gridInscricao_RowCommand" AutoGenerateColumns="False" DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:TemplateField HeaderText="Nº Inscrição" HeaderStyle-Width="15%">
				    <ItemTemplate>
					    <asp:LinkButton ID="link1" runat="server" Text='<%# Eval("NumeroInscricao") %>' CommandName="Selecionar" CommandArgument="<%# Container.DataItemIndex %>"></asp:LinkButton>
				    </ItemTemplate>
			    </asp:TemplateField>
                <asp:BoundField HeaderText="Nome" DataField="Nome" HeaderStyle-Width="40%" />
                <asp:BoundField HeaderText="CPF" DataField="CPF" HeaderStyle-Width="15%" />
                <asp:BoundField HeaderText="Data Nascimento" DataField="DataNascimento" HeaderStyle-Width="20%" DataFormatString="{0:d}" />
                <asp:TemplateField HeaderText="Aceita" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <%# (Eval("SituacaoInscricao").ToString() == "2" ? "Sim" : "Não") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#4B4B4B" Font-Bold="False" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>

    <div class="row">
        
    </div>

</asp:Content>
