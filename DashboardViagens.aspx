<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardViagens.aspx.cs" Inherits="DashboardViagens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashboardViagem.aspx.cs" Inherits="DashboardViagem" %>

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

                                <h4 class="card-title">Viagens</h4>

                                <asp:Button
                                    ID="btnNovaViagem"
                                    runat="server"
                                    Text="Nova Viagem"
                                    CssClass="btn btn-secondary mb-3"
                                    OnClick="btnNovaViagem_Click" />

                                <div class="table-responsive">

                                    <asp:GridView ID="gvViagens"
                                        runat="server"
                                        CssClass="table mb-0 text-nowrap varient-table align-middle fs-3"
                                        AutoGenerateColumns="false"
                                        DataKeyNames="id"
                                        OnRowCommand="gvViagens_RowCommand">

                                        <Columns>

                                            <asp:BoundField DataField="id" HeaderText="ID" />

                                            <asp:BoundField DataField="veiculo" HeaderText="Veículo" />
                                            <asp:BoundField DataField="motorista" HeaderText="Motorista" />

                                            <asp:BoundField DataField="data_saida"
                                                HeaderText="Data Saída"
                                                DataFormatString="{0:dd/MM/yyyy HH:mm}" />

                                            <asp:BoundField DataField="data_retorno"
                                                HeaderText="Data Retorno"
                                                DataFormatString="{0:dd/MM/yyyy HH:mm}" />

                                            <asp:BoundField DataField="km_saida" HeaderText="KM Saída" />
                                            <asp:BoundField DataField="km_retorno" HeaderText="KM Retorno" />

                                            <asp:TemplateField HeaderText="Ações">
                                                <ItemTemplate>

                                                    <!-- EDITAR -->
                                                    <asp:LinkButton
                                                        runat="server"
                                                        CssClass="btn btn-sm btn-warning me-1"
                                                        CommandName="Editar"
                                                        CommandArgument='<%# Eval("id") %>'>
                                                        <i class="bi bi-pencil"></i>
                                                    </asp:LinkButton>

                                                    <!-- APAGAR -->
                                                    <asp:LinkButton
                                                        runat="server"
                                                        CssClass="btn btn-sm btn-danger"
                                                        CommandName="Apagar"
                                                        CommandArgument='<%# Eval("id") %>'
                                                        OnClientClick="return confirm('Deseja apagar esta viagem?');">
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

