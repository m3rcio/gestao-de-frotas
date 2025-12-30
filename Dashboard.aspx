<%@ Page Title="Dashboard" Language="C#"
    MasterPageFile="~/Site.master"
    AutoEventWireup="true"
    CodeFile="Dashboard.aspx.cs"
    Inherits="Dashboard" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

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
            <!--    <img src="<%= ResolveUrl("~/assets/images/logos/logo.svg") %>" /> -->Home Page
                </a>
            </div>  

            <nav class="sidebar-nav scroll-sidebar">
                <ul id="sidebarnav">

                    <li class="nav-small-cap">
                        <span class="hide-menu">Home</span>
                    </li>

                    <li class="sidebar-item">
                        <a class="sidebar-link" runat="server" href="~/Dashboard.aspx">
                            <i class="ti ti-atom"></i>
                            <span class="hide-menu">Veículos</span>
                        </a>
                    </li>

                    <li class="sidebar-item">
                        <a class="sidebar-link" runat="server" href="~/DashboardMotoristas.aspx">
                            <i class="ti ti-atom"></i>
                            <span class="hide-menu">Motoristas</span>
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

                                <h4 class="card-title">Veículos</h4>
                               

                                <div class="table-responsive mt-4">
                                     <asp:Button
                        ID="btnVeiculoForm"
                         runat="server"
                         Text="Adicionar Veículo"
                         CssClass="btn btn-secondary mt-3"
                         CausesValidation="false"
                         OnClick="btnVeiculoForm_Click" />
                                    <!-- TABELA EM ASP.NET -->
                                    <asp:GridView ID="gvVeiculos"
                                        runat="server"
                                        CssClass="table mb-0 text-nowrap varient-table align-middle fs-3"
                                        AutoGenerateColumns="false" DataKeyNames="veiculo_id"
                                        OnRowCommand="gvVeiculos_RowCommand">

                                        <Columns>
                                            <asp:BoundField DataField="veiculo_id" HeaderText="ID" />
                                            <asp:BoundField DataField="Marca" HeaderText="Marca" />
                                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                            <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                            <asp:BoundField DataField="Quilometragem" HeaderText="Quilometragem" />
                                            <asp:BoundField DataField="Ano" HeaderText="Ano" />
                                            <asp:BoundField DataField="Estado" HeaderText="Estado" />

        <asp:TemplateField HeaderText="Ações">
            <ItemTemplate>

                <!-- EDITAR -->
                <asp:LinkButton
                runat="server"
                CssClass="btn btn-sm btn-warning me-1"
                CommandArgument='<%# Eval("veiculo_id") %>'
                OnCommand="Editar_Command">
                <i class="bi bi-pencil"></i>
                </asp:LinkButton>


                <!-- APAGAR -->
                <asp:LinkButton
                    runat="server"
                    CssClass="btn btn-sm btn-danger"
                    CommandName="Apagar"
                    CommandArgument='<%# Eval("veiculo_id") %>'
                    OnClientClick="return confirm('Deseja realmente apagar este veículo?');">
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

