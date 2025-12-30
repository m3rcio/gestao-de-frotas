<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MotoristaForm.aspx.cs" Inherits="MotoristaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-wrapper" id="main-wrapper"
     data-layout="vertical"
     data-navbarbg="skin6"
     data-sidebartype="full"
     data-sidebar-position="fixed"
     data-header-position="fixed">

    <!-- TOP STRIP -->
    <div class="app-topstrip bg-dark py-6 px-3 w-100 d-lg-flex align-items-center">
        <a class="d-flex justify-content-center" runat="server" href="~/Dashboard.aspx">
          <!--  <img src="<%= ResolveUrl("~/assets/images/logos/logo-wrappixel.svg") %>" width="150" /> -->
        </a>
    </div>

    <!-- SIDEBAR -->
    <aside class="left-sidebar">
        <div>
            <div class="brand-logo d-flex align-items-center justify-content-between">
                <a runat="server" href="~/Dashboard.aspx" class="text-nowrap logo-img">
                    <img src="<%= ResolveUrl("~/assets/images/logos/logo.svg") %>" />
                </a>
            </div>

            <nav class="sidebar-nav scroll-sidebar">
                <ul id="sidebarnav">
                    <li class="sidebar-item">
                        <a runat="server" href="~/Dashboard.aspx" class="sidebar-link">
                            <i class="ti ti-atom"></i>
                            <span class="hide-menu">Dashboard</span>
                        </a>
                    </li>
                </ul>
            </nav>
        </div>
    </aside>

    <!-- CONTEÚDO -->
    <div class="body-wrapper">
        <div class="body-wrapper-inner">
            <div class="container-fluid">

                <div class="card">
                    <div class="card-body">

                        <h5 class="card-title fw-semibold mb-4">
                            Registre um Motorista
                        </h5>
                        <asp:Button
                        ID="btnDashboard"
                         runat="server"
                         Text="Ir para Dashboard"
                         CssClass="btn btn-secondary mt-3"
                         CausesValidation="false"
                         OnClick="btnDashboard_Click" />

                        <div class="card">
                            <div class="card-body">

                                <!-- FORM ASP.NET -->
                                <div class="mb-3">
                                    <label class="form-label">Nome</label>
                                    <asp:TextBox ID="txtNome" runat="server"
                                        CssClass="form-control" />
                                </div>

                                <div class="mb-3">
                                    <label class="form-label">Contacto</label>
                                    <asp:TextBox ID="txtContacto" runat="server"
                                        CssClass="form-control" />
                                </div>

                                <div class="mb-3">
                                    <label class="form-label">Carta</label>
                                    <asp:TextBox ID="txtCarta" runat="server"
                                        CssClass="form-control" />
                                </div>

                                <div class="mb-3">
                                 <label class="form-label">Morada</label>
                                <asp:TextBox ID="txtMorada" runat="server"
                                  CssClass="form-control"
                                  TextMode="Number" />
                                 </div>

                                <div class="mb-3">
                                    <asp:Button ID="btnSalvar" runat="server"
                                        Text="Salvar Veículo"
                                        CssClass="btn btn-primary"
                                        OnClick="btnSalvar_Click" />
                                </div>

                                <asp:Label ID="lblMsg" runat="server"
                                    CssClass="text-success"
                                    Visible="false" />

                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</div>
</asp:Content>

