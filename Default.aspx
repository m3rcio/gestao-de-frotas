<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-wrap" style="background-image: url('<%= ResolveUrl("~/images/bg_1.jpg") %>');"
     data-stellar-background-ratio="0.5">
    <div class="overlay"></div>

    <div class="container">
        <div class="row no-gutters slider-text justify-content-start align-items-center">

            <!-- TEXTO -->
            <div class="col-lg-6 col-md-6 ftco-animate d-flex align-items-end">
                <div class="text">
                    <h1 class="mb-4">
                        Now <span>It's easy for you</span>
                        <span>rent a car</span>
                    </h1>

                    <p style="font-size:18px;">
                        A small river named Duden flows by their place and supplies it with the necessary regelialia.
                    </p>

                    <a href="https://vimeo.com/45830194"
                       class="icon-wrap popup-vimeo d-flex align-items-center mt-4">
                        <div class="icon d-flex align-items-center justify-content-center">
                            <span class="ion-ios-play"></span>
                        </div>
                        <div class="heading-title ml-5">
                            <span>Easy steps for renting a car</span>
                        </div>
                    </a>
                </div>
            </div>

            <!-- FORMULÁRIO -->
            <div class="col-lg-4 col-md-6 mt-0 mt-md-5 d-flex">
                <asp:Panel runat="server" CssClass="request-form ftco-animate">

                    <h2>Entrar</h2>

                    <div class="form-group">
                        <label class="label">Email</label>
                        <asp:TextBox ID="txtPickup" runat="server"
                            CssClass="form-control"
                            Placeholder="City, Airport, Station, etc" />
                    </div>

                    <div class="form-group">
                        <label class="label">Palavra-Passe</label>
                        <asp:TextBox ID="txtDropoff" runat="server"
                            CssClass="form-control"
                            Placeholder="City, Airport, Station, etc" Type="password"/>
                    </div>



                    <div class="form-group">
                        <asp:Button ID="btnSearch" runat="server"
                            Text="Entrar"
                            CssClass="btn btn-primary py-3 px-4"
                            OnClick="btnSearch_Click" />
                    </div>

                </asp:Panel>
            </div>

        </div>
    </div>
</div>


       

</asp:Content>
