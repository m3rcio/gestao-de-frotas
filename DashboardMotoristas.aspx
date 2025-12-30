<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DashboardMotoristas.aspx.cs" Inherits="DashboardMotoristas" %>

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
                        <a class="sidebar-link" runat="server" href="~/MotoristaForm.aspx">
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

                                <h4 class="card-title">Motoristas</h4>
                               

                                <div class="table-responsive mt-4">
                                     <asp:Button
                        ID="btnMotoristaForm"
                         runat="server"
                         Text="Adicionar Motorista"
                         CssClass="btn btn-secondary mt-3"
                         CausesValidation="false"
                         OnClick="btnMotoristaForm_Click" />
                                    <!-- TABELA EM ASP.NET -->
                                    <asp:GridView ID="gvMotoristas"
                                        runat="server"
                                        CssClass="table mb-0 text-nowrap varient-table align-middle fs-3"
                                        AutoGenerateColumns="false" DataKeyNames="motorista_id"
                                        OnRowCommand="gvMotoristas_RowCommand">

                                        <Columns>
                                            <asp:BoundField DataField="veiculo_id" HeaderText="ID" />
                                            <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                            <asp:BoundField DataField="Contacto" HeaderText="Contacto" />
                                            <asp:BoundField DataField="Carta" HeaderText="Carta" />
                                            <asp:BoundField DataField="Morada" HeaderText="Morada" />

        <asp:TemplateField HeaderText="Ações">
            <ItemTemplate>

                <!-- EDITAR -->
                <asp:LinkButton
                runat="server"
                CssClass="btn btn-sm btn-warning me-1"
                CommandArgument='<%# Eval("motorista_id") %>'
                OnCommand="Editar_Command">
                <i class="bi bi-pencil"></i>
                </asp:LinkButton>


                <!-- APAGAR -->
                <asp:LinkButton
                    runat="server"
                    CssClass="btn btn-sm btn-danger"
                    CommandName="Apagar"
                    CommandArgument='<%# Eval("motorista_id") %>'
                    OnClientClick="return confirm('Deseja realmente apagar este motorista?');">
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

