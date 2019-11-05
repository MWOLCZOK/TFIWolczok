<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReportesTRChat.aspx.vb" Inherits="Vista.Reportes_TR_Chat" %>



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
                        <asp:Label ID="lbl_Reporte_TR_Chat" runat="server" Text="Reporte Tiempos de Respuesta" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />
        </div>
        <br />
        <br />

        <div class="row">
            <div class="panel-group col-md-4 col-md-offset-1">
                <div class="panel-default">
                    <hr />
                    <div class="panel-heading text-center">Tiempo Promedio de Atención</div>
                    <hr />
                    <div class="panel-body">

                        <div id="divTiempoDeRespuesta_Content" class="row" runat="server">
                            <div id="divPreguntaTiempoDeRespuesta" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
                            <div id="divChartTiempoDeRespuesta" runat="server" style="width: 400px; height: 307px">
                                <asp:Chart EnableViewState="true" ID="chartTiempoDeRespuesta" runat="server" Style="max-width: 100%">
                                    <Series>
                                        <asp:Series Name="Series1"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <Area3DStyle Enable3D="true" />
                                        </asp:ChartArea>

                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="panel-group col-md-6">
                    <div class="panel-default">
                        <hr />
                        <div class="panel-heading text-center">Distribución Total de Chats Ingresados</div>
                        <hr />
                        <div class="panel-body text-center" >
                                  <div id="canvas-holder1">
                                        <canvas id="chart-area1" width="250" height="250" />
                                    </div>
                        </div>
                    </div>

                </div>
            </div>


        </div>
    </div>
    <br />
    <br />
</asp:Content>




