<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardViagens.aspx.cs" Inherits="DashboardViagens" %>

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

        <!-- MENU -->
        <nav class="sidebar-nav scroll-sidebar">
            <ul id="sidebarnav">

                <li class="nav-small-cap">
                    <span class="hide-menu">Dashboards</span>
                </li>

                
                <li class="sidebar-item">
                    <a class="sidebar-link" runat="server" href="~/Dashboard.aspx">
                        <i class="bi bi-car-front-fill"></i>
                        <span class="hide-menu">Veículos</span>
                    </a>
                </li>

                
                <li class="sidebar-item">
                    <a class="sidebar-link" runat="server" href="~/DashboardMotoristas.aspx">
                        <i class="bi bi-person-fill"></i>
                        <span class="hide-menu">Motoristas</span>
                    </a>
                </li>

                
                <li class="sidebar-item">
                    <a class="sidebar-link" runat="server" href="~/DashboardViagens.aspx">
                        <i class="bi bi-signpost-2-fill"></i>
                        <span class="hide-menu">Viagens</span>
                    </a>
                </li>

                
                <li class="sidebar-item">
                    <a class="sidebar-link" runat="server" href="~/DashboardManutencoes.aspx">
                        <i class="bi bi-tools"></i>
                        <span class="hide-menu">Manutenções</span>
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
                                        DataKeyNames="viagem_id"
                                        OnRowCommand="gvViagens_RowCommand">

                                        <Columns>

                                            <asp:BoundField DataField="viagem_id" HeaderText="ID" />

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
                                                      CommandArgument='<%# Eval("viagem_id") %>'
                                                      OnCommand="Editar_Command">
                                                      <i class="bi bi-pencil"></i>
                                                    </asp:LinkButton>

                                                    <!-- APAGAR -->
                                                    <asp:LinkButton
                                                        runat="server"
                                                        CssClass="btn btn-sm btn-danger"
                                                        CommandName="Apagar"
                                                        CommandArgument='<%# Eval("viagem_id") %>'
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

