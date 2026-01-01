<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditarViagem.aspx.cs" Inherits="EditarViagem" %>

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

                <div class="card">
                    <div class="card-body">

                        <h5 class="card-title fw-semibold mb-4">Registrar Viagem</h5>

                        <!-- VEÍCULO -->
                        <div class="mb-3">
                            <label class="form-label">Veículo</label>
                            <asp:DropDownList
                                ID="ddlVeiculo"
                                runat="server"
                                CssClass="form-select" />
                        </div>

                        <!-- MOTORISTA -->
                        <div class="mb-3">
                            <label class="form-label">Motorista</label>
                            <asp:DropDownList
                                ID="ddlMotorista"
                                runat="server"
                                CssClass="form-select" />
                        </div>

                        <!-- DATA SAÍDA -->
                        <div class="mb-3">
                            <label class="form-label">Data de Saída</label>
                            <asp:TextBox
                                ID="txtDataSaida"
                                runat="server"
                                CssClass="form-control"
                                TextMode="DateTimeLocal" />
                        </div>

                        <!-- KM SAÍDA -->
                        <div class="mb-3">
                            <label class="form-label">KM de Saída</label>
                            <asp:TextBox
                                ID="txtKmSaida"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Number" />
                        </div>

                        <!-- DATA RETORNO -->
                        <div class="mb-3">
                            <label class="form-label">Data de Retorno</label>
                            <asp:TextBox
                                ID="txtDataRetorno"
                                runat="server"
                                CssClass="form-control"
                                TextMode="DateTimeLocal" />
                        </div>

                        <!-- KM RETORNO -->
                        <div class="mb-3">
                            <label class="form-label">KM de Retorno</label>
                            <asp:TextBox
                                ID="txtKmRetorno"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Number" />
                        </div>

                        <asp:Button
                            ID="btnAtualizar"
                            runat="server"
                            Text="Atualizar Viagem"
                            CssClass="btn btn-success mt-3"
                            OnClick="btnAtualizar_Click" />

                        <asp:Label
                            ID="lblMsg"
                            runat="server"
                            CssClass="text-success mt-3 d-block"
                            Visible="false" />

                    </div>
                </div>

            </div>
        </div>
    </div>

</div>
</asp:Content>

