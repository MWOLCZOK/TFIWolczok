<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="BusquedaGlobal.aspx.vb" Inherits="Vista.BusquedaGlobal" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris">
        <br />
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="textovalid" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessmodUser" class="text-success"></label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Busqueda Global" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />


            <div class="panel-group col-md-12">
                <div class="panel-default">
                    <hr />
                    <div class="panel-heading text-center">Resultados de Búsqueda</div>
                    <hr />
                    <br />
                    <br />

                    <div class="text-center">
                        <h2>
                            <asp:Label ID="Lbl_sinresul" runat="server"      Font-Size="18" Text="¡UPS!.. NO HAY RESULTADOS PARA SU BUSQUEDA" Visible="false"></asp:Label></h2>
                    </div>
                    <div id="ID_Resultados" runat="server" class="panel-body">
                        <br />
                        <br />


                    </div>

                </div>
            </div>
        </div>
    </div>


</asp:Content>



