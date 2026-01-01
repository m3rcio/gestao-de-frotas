<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManutencaoForm.aspx.cs" Inherits="ManutencaoForm" %>

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

    <!-- MAIN -->
    <div class="body-wrapper">
        <div class="body-wrapper-inner">
            <div class="container-fluid">

                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title fw-semibold mb-4">
                            Registar Manutenção
                        </h5>

                       
                        <div class="mb-3">
                            <label class="form-label">Veículo</label>
                            <asp:DropDownList
                                ID="ddlVeiculo"
                                runat="server"
                                CssClass="form-select" />
                        </div>

                     
                        <div class="mb-3">
                            <label class="form-label">Tipo</label>
                            <asp:TextBox
                                ID="txtTipo"
                                runat="server"
                                CssClass="form-control" />
                        </div>

                       
                        <div class="mb-3">
                            <label class="form-label">Custo</label>
                            <asp:TextBox
                                ID="txtCusto"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Number" />
                        </div>

                      
                        <div class="mb-3">
                            <label class="form-label">Data</label>
                            <asp:TextBox
                                ID="txtData"
                                runat="server"
                                CssClass="form-control"
                                TextMode="DateTimeLocal" />
                        </div>

                       
                        <div class="mb-3">
                            <label class="form-label">Descrição</label>
                            <asp:TextBox
                                ID="txtDescricao"
                                runat="server"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Rows="3" />
                        </div>

                        
                        <asp:Button
                            ID="btnSalvar"
                            runat="server"
                            Text="Salvar"
                            CssClass="btn btn-success"
                            OnClick="btnSalvar_Click" />

                        <asp:Button
                            ID="btnCancelar"
                            runat="server"
                            Text="Cancelar"
                            CssClass="btn btn-secondary ms-2"
                            CausesValidation="false"
                            OnClick="btnCancelar_Click" />

                        <asp:Label
                            ID="lblMsg"
                            runat="server"
                            CssClass="text-success d-block mt-3"
                            Visible="false" />
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>

</asp:Content>

