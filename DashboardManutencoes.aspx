<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardManutencoes.aspx.cs" Inherits="DashboardManutencoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h4 class="card-title">Manutenções</h4>

<asp:Button
    ID="btnNovaManutencao"
    runat="server"
    Text="Nova Manutenção"
    CssClass="btn btn-secondary mb-3"
    OnClick="btnNovaManutencao_Click" />

<asp:GridView
    ID="gvManutencoes"
    runat="server"
    CssClass="table mb-0 text-nowrap align-middle fs-3"
    AutoGenerateColumns="false"
    DataKeyNames="manutencao_id"
    OnRowCommand="gvManutencoes_RowCommand">

    <Columns>
        <asp:BoundField DataField="manutencao_id" HeaderText="ID" />
        <asp:BoundField DataField="veiculo" HeaderText="Veículo" />
        <asp:BoundField DataField="tipo" HeaderText="Tipo" />
        <asp:BoundField DataField="custo" HeaderText="Custo" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="data" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="descricao" HeaderText="Descrição" />

        <asp:TemplateField HeaderText="Ações">
            <ItemTemplate>

                <!-- EDITAR -->
                <asp:LinkButton
                    runat="server"
                    CssClass="btn btn-sm btn-warning me-1"
                    CommandName="Editar"
                    CommandArgument='<%# Eval("manutencao_id") %>'>
                    <i class="bi bi-pencil"></i>
                </asp:LinkButton>

                <!-- APAGAR -->
                <asp:LinkButton
                    runat="server"
                    CssClass="btn btn-sm btn-danger"
                    CommandName="Apagar"
                    CommandArgument='<%# Eval("manutencao_id") %>'
                    OnClientClick="return confirm('Deseja apagar esta manutenção?');">
                    <i class="bi bi-trash"></i>
                </asp:LinkButton>

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

</asp:Content>

