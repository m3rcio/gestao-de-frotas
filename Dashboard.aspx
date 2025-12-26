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

    <!-- TOP STRIP -->
    <div class="app-topstrip bg-dark py-6 px-3 w-100 d-lg-flex align-items-center justify-content-between">
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

                    <li class="nav-small-cap">
                        <span class="hide-menu">Home</span>
                    </li>

                    <li class="sidebar-item">
                        <a class="sidebar-link" runat="server" href="~/Dashboard.aspx">
                            <i class="ti ti-atom"></i>
                            <span class="hide-menu">Dashboard</span>
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

                                <h4 class="card-title">Products Performance</h4>
                                <p class="card-subtitle">Ample Admin Vs Pixel Admin</p>

                                <div class="table-responsive mt-4">

                                    <!-- TABELA EM ASP.NET -->
                                    <asp:GridView ID="gvPerformance"
                                        runat="server"
                                        CssClass="table mb-0 text-nowrap varient-table align-middle fs-3"
                                        AutoGenerateColumns="false">

                                        <Columns>
                                            <asp:BoundField DataField="Nome" HeaderText="Name" />
                                            <asp:BoundField DataField="Cargo" HeaderText="Role" />
                                            <asp:BoundField DataField="Prioridade" HeaderText="Priority" />
                                            <asp:BoundField DataField="Budget" HeaderText="Budget" />
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

