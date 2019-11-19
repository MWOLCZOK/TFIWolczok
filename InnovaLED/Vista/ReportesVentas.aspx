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


        <div class="row text-center">
            <hr />
            <h3>Reporte Anual - Periodo 2019</h3>
            <hr />
        </div>

        <div class="row col-md-12">
            <div class="row col-md-offset-2">
                <%-- CHARTs Anual--%>
                <asp:Chart ID="chartGananciasAnuales" runat="server" Width="800" Height="400" CssClass="bg-light">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Column" LabelFormat="{0:c}" Color="#2e8456"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:Label ID="Lbl_anual" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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
            <%-- CHART MENSUAL --%>
            <div class="col-md-offset-2 col-md-6">
                <asp:Chart ID="chartGananciaMensual" runat="server" Width="800" Height="400" CssClass="bg-light">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Column" LabelFormat="{0:c}" Color="#2e8456"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div class="col-md-offset-1 col-md-2">
                <br />
                <br />
                <asp:DropDownList ID="ddl_Ano_Mes" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="0">2019</asp:ListItem>
                    <asp:ListItem Value="01">2020</asp:ListItem>
                    <asp:ListItem Value="02">2021</asp:ListItem>
                    <asp:ListItem Value="03">2022</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddl_Mes" runat="server" CssClass="form-control">
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
                <br />
                <asp:Button ID="btn_buscarMensual" runat="server" Text="Buscar" class="btn btn-success btn-sm" />
            </div>
            <div class="row col-md-offset-3">
                <asp:Label ID="lblmensual" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
            <br />
            <br />
            <br />
            <br />
        </div>


        <div class="row text-center">
            <hr />
            <hr />
            <h3>Reporte Semanal </h3>
            <hr />
            <hr />
        </div>

        <div class="row col-md-12">
            <%-- CHART SEMANAL --%>
            <div class="col-md-offset-2 col-md-6">

                <asp:Chart ID="chartGananciaSemanal" runat="server" Width="800" Height="400" CssClass="bg-light">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Column" LabelFormat="{0:c}" Color="#2e8456"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div class="col-md-offset-1 col-md-2">
                <br />
                <br />
                <asp:DropDownList ID="ddl_Ano_semanal" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="0">2019</asp:ListItem>
                    <asp:ListItem Value="01">2020</asp:ListItem>
                    <asp:ListItem Value="02">2021</asp:ListItem>
                    <asp:ListItem Value="03">2022</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddl_Semanal" runat="server" CssClass="form-control">
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
                <br />
                <asp:Button ID="Btn_Semanal" runat="server" Text="Buscar" class="btn btn-success btn-sm" />
            </div>
            <div class="row col-md-offset-2">
                <asp:Label ID="Lbl_Semanal" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
            <br />
            <br />
            <br />
            <br />
        </div>


        <div class="row text-center">
            <hr />
            <hr />
            <h3>Reporte Diario</h3>
            <hr />
            <hr />
            <hr />
        </div>
        <div class="row col-md-12">

            <%--CHART DIARIO--%>
            <div class="col-md-offset-2 col-md-6">

                <asp:Chart ID="chartGananciaDiario" runat="server" Width="800" Height="400" CssClass="bg-light">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Column" LabelFormat="{0:c}" Color="#2e8456"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </div>
            <div class="col-md-offset-1 col-md-2">
                <br />
                <br />
                <asp:DropDownList ID="ddl_Ano_diario" runat="server" CssClass="form-control">
                    <asp:ListItem Selected="True" Value="0">2019</asp:ListItem>
                    <asp:ListItem Value="01">2020</asp:ListItem>
                    <asp:ListItem Value="02">2021</asp:ListItem>
                    <asp:ListItem Value="03">2022</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddl_Diario" runat="server" CssClass="form-control">
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
                <br />
                <asp:Button ID="btn_buscarDiario" runat="server" Text="Buscar" class="btn btn-success btn-sm" />
            </div>
            <div class="row col-md-offset-2">
                <asp:Label ID="Lbl_Diario" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>



