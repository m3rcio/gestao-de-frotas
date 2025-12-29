<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditarVeiculo.aspx.cs" Inherits="EditarVeiculo" %>

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
            <img src="<%= ResolveUrl("~/assets/images/logos/logo-wrappixel.svg") %>" width="150" />
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
                            Registre um Veículo
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
                                    <label class="form-label">Marca</label>
                                    <asp:TextBox ID="txtMarca" runat="server"
                                        CssClass="form-control" />
                                </div>

                                <div class="mb-3">
                                    <label class="form-label">Modelo</label>
                                    <asp:TextBox ID="txtModelo" runat="server"
                                        CssClass="form-control" />
                                </div>

                                <div class="mb-3">
                                    <label class="form-label">Matrícula</label>
                                    <asp:TextBox ID="txtMatricula" runat="server"
                                        CssClass="form-control" />
                                </div>

                               <!-- <div class="mb-3">
                                    <label class="form-label">Localização</label>
                                    <asp:TextBox ID="txtLocalizacao" runat="server"
                                        CssClass="form-control" />
                                </div> -->

                                <div class="mb-3">
                                 <label class="form-label">Quilometragem</label>
                                <asp:TextBox ID="txtKm" runat="server"
                                  CssClass="form-control"
                                  TextMode="Number" />
                                 </div>

                                <div class="mb-3">
                                <label class="form-label">Ano</label>
                                <asp:TextBox ID="txtAno" runat="server"
                                  CssClass="form-control"
                                  TextMode="Number" />
                                </div>

                                <div class="mb-3">
                                 <label class="form-label">Estado</label>
                                    <asp:DropDownList ID="ddlEstado" runat="server"
                                    CssClass="form-select">
                                   <asp:ListItem Text="Selecione..." Value="" />
                                   <asp:ListItem Text="Ativo" Value="Ativo" />
                                  <asp:ListItem Text="Inativo" Value="Inativo" />
                                  </asp:DropDownList>
                                </div>


                                <asp:Button
                                ID="btnAtualizar"
                                 runat="server"
                                 Text="Atualizar"
                                 CssClass="btn btn-success mt-3"
                                 OnClick="btnAtualizar_Click" />

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

