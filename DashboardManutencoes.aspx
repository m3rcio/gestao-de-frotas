<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardManutencoes.aspx.cs" Inherits="DashboardManutencoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-wrapper" id="main-wrapper"
     data-layout="vertical"
     data-navbarbg="skin6"
     data-sidebartype="full"
     data-sidebar-position="fixed"
     data-header-position="fixed">

    <!-- SIDEBAR -->
    <aside class="left-sidebar">
        <div>
            <div class="brand-logo d-flex align-items-center justify-content-between">
                <a runat="server" href="~/Dashboard.aspx" class="text-nowrap logo-img">
                    Home Page
                </a>
            </div>

            <nav class="sidebar-nav scroll-sidebar">
                <ul id="sidebarnav">

                    <li class="nav-small-cap">
                        <span class="hide-menu">Gestão</span>
                    </li>

                    <li class="sidebar-item">
                        <a class="sidebar-link" runat="server" href="~/Dashboard.aspx">
                            <span class="hide-menu">Veículos</span>
                        </a>
                    </li>

                    <li class="sidebar-item">
                        <a class="sidebar-link" runat="server" href="~/DashboardMotorista.aspx">
                            <span class="hide-menu">Motoristas</span>
                        </a>
                    </li>

                    <li class="sidebar-item">
                        <a class="sidebar-link active" runat="server" href="~/DashboardViagem.aspx">
                            <span class="hide-menu">Viagens</span>
                        </a>
                    </li>

                </ul>
            </nav>
        </div>
    </aside>
          <!-- MAIN CONTENT -->
    <div class="body-wrapper">
        <div class="body-wrapper-inner">
            <div class="container-fluid">

                <div class="row">
                    <div class="col-12">

                        <div class="card">
                            <div class="card-body">
    <h4 class="card-title">Manutenções</h4>

<asp:Button
    ID="btnNovaManutencao"
    runat="server"
    Text="Nova Manutenção"
    CssClass="btn btn-secondary mb-3"
    OnClick="btnNovaManutencao_Click" />

                                <div class="table-responsive">

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
           </div>

                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</div>

</asp:Content>

