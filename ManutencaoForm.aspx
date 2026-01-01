<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManutencaoForm.aspx.cs" Inherits="ManutencaoForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-wrapper" id="main-wrapper"
    data-layout="vertical"
    data-navbarbg="skin6"
    data-sidebartype="full"
    data-sidebar-position="fixed"
    data-header-position="fixed">

    <aside class="left-sidebar">
        <div>
            <nav class="sidebar-nav scroll-sidebar">
                <ul id="sidebarnav">
                    <li class="sidebar-item">
                        <a class="sidebar-link" runat="server" href="~/DashboardManutencoes.aspx">
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

                        <!-- VEÍCULO -->
                        <div class="mb-3">
                            <label class="form-label">Veículo</label>
                            <asp:DropDownList
                                ID="ddlVeiculo"
                                runat="server"
                                CssClass="form-select" />
                        </div>

                        <!-- TIPO -->
                        <div class="mb-3">
                            <label class="form-label">Tipo</label>
                            <asp:TextBox
                                ID="txtTipo"
                                runat="server"
                                CssClass="form-control" />
                        </div>

                        <!-- CUSTO -->
                        <div class="mb-3">
                            <label class="form-label">Custo</label>
                            <asp:TextBox
                                ID="txtCusto"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Number" />
                        </div>

                        <!-- DATA -->
                        <div class="mb-3">
                            <label class="form-label">Data</label>
                            <asp:TextBox
                                ID="txtData"
                                runat="server"
                                CssClass="form-control"
                                TextMode="DateTimeLocal" />
                        </div>

                        <!-- DESCRIÇÃO -->
                        <div class="mb-3">
                            <label class="form-label">Descrição</label>
                            <asp:TextBox
                                ID="txtDescricao"
                                runat="server"
                                CssClass="form-control"
                                TextMode="MultiLine"
                                Rows="3" />
                        </div>

                        <!-- BOTÕES -->
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

