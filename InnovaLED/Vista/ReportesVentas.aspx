<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="ReportesVentas.aspx.vb" Inherits="Vista.Reportes_Ventas" %>



<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



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
                        <asp:Label ID="lblpanelReportesVentas" runat="server" Text="Reportes Ventas" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />


        </div>


        <!--Ganancias Anual-->
        <%--   </div>--%>

        <%--<div class="col-md-2 col-md-offset-1">
            <asp:Label ID="lblfechadesde" runat="server" Text="Fecha Desde:" CssClass="control-label labelform"></asp:Label>
            <div class="input-group">
                <input runat="server" clientidmode="Static" class="form-control" type="text" id="datepicker1" readonly="true" name="datepicker1" />
                <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>
                    <asp:TextBox ID="Fecha_Desde" runat="server" Visible="False"></asp:TextBox>
                </span>

            </div>
        </div>
        <div class="col-md-2">
            <asp:Label ID="lblfechahasta" runat="server" Text="Fecha Hasta:" CssClass="control-label labelform"></asp:Label>
            <div class="input-group">
                <input runat="server" clientidmode="Static" class="form-control" type="text" id="datepicker2" name="datepicker2" readonly="true" />
                <span class="input-group-addon" id="basic-addon2"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>
                </span>

            </div>
        </div>--%>


        <div class="panel-group col-md-12">
            <div class="panel-default">
                <hr />
                <div class="panel-heading text-center">Información de Ventas Total</div>
                <hr />
                <div class="panel-body">

                    <div id="divGanancias_Content" class="row col-md-10 col-md-offset-1" runat="server">
                        <div id="divPreguntaGanancias" runat="server" style="width: 100%; font-size: 4vh; font-weight: bold" />
                        <div class="table-responsive">
                            <asp:Table ID="tblGanancias" runat="server" CssClass="table table-hover table-bordered table-responsive table-active text-center">
                            </asp:Table>
                        </div>
                    </div>

                </div>
            </div>

            <br />
            <br />

            <div class="panel-group col-md-12">
                <div class="panel-default">
                    <hr />
                    <div class="panel-heading text-center">Gráficos de Ventas segmentado por periodos</div>
                    <hr />
                    <div class="panel-body">

                        <div class="row text-center">
                            <hr />
                            <h3>Reporte Anual - Periodo 2019</h3>
                            <hr />
                        </div>

                        <div class="row col-md-12">

                            <div class="row col-md-offset-4">

                                <%-- CHARTs Anual--%>

                                <asp:Chart EnableViewState="true" ID="chartGanancias" runat="server" Visible="true" Style="max-width: 100%">
                                    <Series>
                                        <asp:Series Name="Series1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </div>
                        </div>
                        <div class="row text-center">
                            <hr />
                            <hr />
                            <h3>Reporte Mensual</h3>
                            <hr />
                            <hr />
                            <hr />
                        </div>

                        <div class="row col-md-12">
                            <%-- CHART Mensual --%>
                            <div class="col-md-offset-4">
                                <asp:Chart EnableViewState="true" ID="chartGananciMensual" runat="server" Visible="true" Style="max-width: 100%">
                                    <Series>
                                        <asp:Series Name="Series1"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1 " Area3DStyle-Enable3D="true"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>


                                <asp:DropDownList ID="ddl_Mes" runat="server" CssClass="combo">
                                    <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
                                    <asp:ListItem Value="01">Enero</asp:ListItem>
                                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                                    <asp:ListItem Value="06">Junio</asp:ListItem>
                                    <asp:ListItem Value="07">Julio</asp:ListItem>
                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblmensual" runat="server" Visible="false"></asp:Label>
                                <asp:Button ID="btn_buscarMensual" runat="server" Text="Buscar" class="btn btn-success btn-sm" />

                            </div>

                        </div>




                        <div class="row text-center">
                            <hr />
                            <hr />
                            <h3>Reporte Semanal</h3>
                            <hr />
                            <hr />
                        </div>

                        <div class="row col-md-12">

                            <%-- CHART Semanal (Este sería el diario)--%>
                            <div class="col-md-offset2">

                                <%--  <asp:Chart EnableViewState="true" ID="chartGananciaSemanal" runat="server" Visible="true" Style="max-width: 100%" Height="600px" Width="600px">
                                    <Series>
                                        <asp:Series Name="Series1"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>--%>

                                <asp:Chart ID="chartGananciaSemanal" runat="server" Width="800" Height="400" CssClass="bg-light">
                                    <Series>
                                        <%--<asp:Series Name="Series1" ChartType="Spline" LabelFormat="{0:c}" Color="#2d94d8" LegendText="Ventas diarias"></asp:Series>--%>
                                        <asp:Series Name="Series1" ChartType="Column" LabelFormat="{0:c}" Color="#2e8456" LegendText="Ventas Diarias"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>


                                <asp:DropDownList ID="ddl_Semanal" runat="server" CssClass="combo">
                                    <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
                                    <asp:ListItem Value="01">Enero</asp:ListItem>
                                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                                    <asp:ListItem Value="06">Junio</asp:ListItem>
                                    <asp:ListItem Value="07">Julio</asp:ListItem>
                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btn_buscarSemanal" runat="server" Text="Buscar" class="btn btn-success btn-sm" />

                            </div>
                        </div>


                        <div class="row text-center">
                            <hr />
                            <hr />
                            <h3>Reporte Semanal 2 </h3>
                            <hr />
                            <hr />
                        </div>

                        <div class="row col-md-12">

                            <%-- CHART Semanal 2 (este sería el semanal) --%>
                            <div class="col-md-offset2">

                                <%--  <asp:Chart EnableViewState="true" ID="chartGananciaSemanal" runat="server" Visible="true" Style="max-width: 100%" Height="600px" Width="600px">
                                    <Series>
                                        <asp:Series Name="Series1"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>--%>

                                <asp:Chart ID="chartGananciaSemanal2" runat="server" Width="600" Height="350" CssClass="bg-light">
                                    <Series>
                                        <asp:Series Name="Series1" ChartType="Column" LabelFormat="{0:c}" Color="#2e8456" LegendText="Ventas Semanal"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                                <asp:DropDownList ID="ddl_Semanal2" runat="server" CssClass="combo">
                                    <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
                                    <asp:ListItem Value="01">Enero</asp:ListItem>
                                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                                    <asp:ListItem Value="06">Junio</asp:ListItem>
                                    <asp:ListItem Value="07">Julio</asp:ListItem>
                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="Btn_Semanal2" runat="server" Text="Buscar" class="btn btn-success btn-sm" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--   </div>--%>
</asp:Content>



