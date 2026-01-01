<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper" id="main-wrapper"
     data-layout="vertical"
     data-navbarbg="skin6"
     data-sidebartype="full"
     data-sidebar-position="fixed"
     data-header-position="fixed">

    <div class="position-relative overflow-hidden text-bg-light min-vh-100 d-flex align-items-center justify-content-center">
        <div class="d-flex align-items-center justify-content-center w-100">
            <div class="row justify-content-center w-100">
                <div class="col-md-8 col-lg-6 col-xxl-3">

                    <div class="card mb-0">
                        <div class="card-body">

                            <a runat="server" href="~/Login.aspx"
                               class="text-nowrap logo-img text-center d-block py-3 w-100">
                                <img src="assets/images/logos/logo.svg" alt="">
                            </a>

                            <p class="text-center">Entrar no sistema</p>

                            <!-- USUÁRIO -->
                            <div class="mb-3">
                                <label class="form-label">Username</label>
                                <asp:TextBox
                                    ID="txtUsuario"
                                    runat="server"
                                    CssClass="form-control" />
                            </div>

                            <!-- SENHA -->
                            <div class="mb-4">
                                <label class="form-label">Password</label>
                                <asp:TextBox
                                    ID="txtSenha"
                                    runat="server"
                                    CssClass="form-control"
                                    TextMode="Password" />
                            </div>

                            <!-- BOTÃO LOGIN -->
                            <asp:Button
                                ID="btnLogin"
                                runat="server"
                                Text="Entrar"
                                CssClass="btn btn-primary w-100 py-8 fs-4 mb-4 rounded-2"
                                OnClick="btnLogin_Click" />

                            <!-- ERRO -->
                            <asp:Label
                                ID="lblErro"
                                runat="server"
                                CssClass="text-danger text-center d-block"
                                Visible="false" />

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</div>


       

</asp:Content>
