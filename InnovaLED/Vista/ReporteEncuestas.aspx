<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReporteEncuestas.aspx.vb" Inherits="Vista.ReporteEncuestas" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->
    <script src="JS/Chart.js"></script>

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
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Reporte Encuestas" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />


        </div>



        <%--  Sección Reporte Encuesta ST--%>

        <%--<div class="fila">
            <div class="col-md-12">
                <div id="error" class="msj-error col-md-12" runat="server" visible="false">
                    <asp:Label ID="lbl_TituloError" runat="server" CssClass="label"></asp:Label>
                </div>
            </div>
        </div>--%>
        <br />
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-verde">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_EstadisticasSatisfaccion" runat="server">Estadisticas de Satisfaccion</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-6 col-md-offset-1">
                                <asp:Label ID="Label1" Text="Enunciado: " runat="server"></asp:Label>
                                <asp:DropDownList ID="encuestas" runat="server" AutoPostBack="false" DataTextField="Enunciado" DataValueField="ID" CssClass="combo"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Button ID="btn_buscar" runat="server" Text="Buscar" CssClass="btn btn-modificar" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-6 col-md-offset-1">
                                <div id="canvas-holder">
                                    <canvas id="chart-area" width="300" height="300" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%-- SECCION REPORTE FICHA DE OPINION--%>


        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-verde">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_EstadisticasEncuestas" runat="server">Estadisticas de Ficha Opinion</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <br />
                        <div class="fila">
                            <div class="col-md-6 col-md-offset-1">
                                <asp:Label ID="Label2" Text="Enunciado: " runat="server"></asp:Label>
                                <asp:DropDownList ID="opinion" runat="server" DataTextField="Enunciado" DataValueField="ID" AutoPostBack="false" CssClass="combo"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-md-offset-2 ">
                                <asp:Button ID="btn_buscaropinion" runat="server" Text="Buscar" CssClass="btn btn-modificar" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-6  col-md-offset-1">
                                <div id="canvas-holder2">
                                    <canvas id="chart-area2" width="300" height="300" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>










        <asp:HiddenField ID="ID_encuesta" runat="server" />


    </div>



</asp:Content>




