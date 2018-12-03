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
        <%--  <div id="divGanancias" runat="server" class="container mt-2">
            <div class="row">
                <div class="col-sm-3">
                    <asp:Label runat="server" for="dpDesdeGanancias">Desde:</asp:Label>
                    <uc2:datepicker id="dpDesdeGanancias" runat="server" />
                </div>
                <div class="col-sm-3">
                    <asp:Label runat="server" for="dpHastaGanancias">Hasta:</asp:Label>
                    <uc2:datepicker id="dpHastaGanancias" runat="server" />
                </div>
                <div class="col-sm-3">
                    <br />
                    <asp:Button class="btn btn-primary mt-1" ID="btnFiltrarGanancias" runat="server" Text="Filtrar" />
                </div>
            </div>--%>

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
                            <asp:Table ID="tblGanancias" runat="server" CssClass="table table-hover table-bordered table-responsive table-active text-center" >
                              
                               
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


                        <div class="row col-md-10 col-md-offset-2">

                            <%-- CHARTs Anual--%>

                            <asp:Chart EnableViewState="true" ID="chartGanancias" runat="server" Visible="true" Style="max-width: 100%">
                                <Series>
                                    <asp:Series Name="Series1">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>

                            <%-- CHART Mensual --%>

                            <asp:Chart EnableViewState="true" ID="chartGananciMensual" runat="server" Visible="true" Style="max-width: 100%">
                                <Series>
                                    <asp:Series Name="Series1"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>

                            <%-- CHART Semanal --%>

                            <asp:Chart EnableViewState="true" ID="chartGananciaSemanal" runat="server" Visible="true" Style="max-width: 100%">
                                <Series>
                                    <asp:Series Name="Series1"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



