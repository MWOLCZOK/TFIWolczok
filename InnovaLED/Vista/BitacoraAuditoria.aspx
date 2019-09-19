<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="BitacoraAuditoria.aspx.vb" Inherits="Vista.ConsultarBitacoraAuditoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(function () {
            $("#datepicker1").datepicker();
            $("#datepicker2").datepicker();
        });

    </script>
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>



    <div class="container-fluid fondoGris">
        <br />

        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-warning  text-center" visible="false">
            <label runat="server" id="lblBitacora404" class="text-danger">No se encontraron Bitacoras para los filtros seleccionados</label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel-default panel-primary">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelBitacora" runat="server" Text="Bitácora" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
                <div class="panel-body">
                    <br />
                    <div class="form-inline">
                        <div class="col-md-2 col-md-offset-2">
                            <asp:Label ID="lblfechadesde" runat="server" Text="Fecha Desde:" CssClass="control-label labelform"></asp:Label>

                            <input runat="server" clientidmode="Static" class="form-control" type="text" id="datepicker1" readonly="true" name="datepicker1" />

                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblfechahasta" runat="server" Text="Fecha Hasta:" CssClass="control-label labelform"></asp:Label>

                            <input runat="server" clientidmode="Static" class="form-control" type="text" id="datepicker2" name="datepicker2" readonly="true" />

                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblusuario" runat="server" Text="Usuario Bitacora:" CssClass="control-label labelform"></asp:Label>
                            <asp:DropDownList ID="lstusuarios" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="ID_Usuario" DataTextField="NombreUsu"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lbltipoBitacora" runat="server" Text="Tipo Bitacora:" CssClass="control-label labelform"></asp:Label>

                            <asp:DropDownList ID="lsttipos" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="Tipo_Bitacora" DataTextField="Tipo_Bitacora"></asp:DropDownList>

                        </div>
                    </div>

                    <br />
                    <br />
                    <br />

                    <br />
                    <div class="col-md-2 col-md-offset-5">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-block btn-warning" />
                    </div>
                    <br />



                    <br />
                    <br />


                    <div class="form-horizontal">

                        <div class="form-group">
                            <div class="col-md-12">

                                <asp:GridView CssClass="table table-hover table-bordered table-responsive table-success " ID="gv_Bitacora" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Bitacora_PageIndexChanging" RowStyle-Height="40px">
                                    <HeaderStyle CssClass="thead-dark" />
                                    <PagerTemplate>
                                        <div class="col-md-4 text-left">
                                            <asp:Label ID="lblmostrarpag" runat="server" Text="Mostrar Pagina"></asp:Label>
                                            <asp:DropDownList ID="ddlPaging" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged" />
                                            <asp:Label ID="lblde" runat="server" Text="de"></asp:Label>
                                            <asp:Label ID="lbltotalpages" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="col-md-4 col-md-offset-4">
                                            <asp:Label ID="lblMostrar" runat="server" Text="Mostrar"></asp:Label>
                                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="margenPaginacion" OnSelectedIndexChanged="ddlPageSize_SelectedPageSizeChanged">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblRegistrosPag" runat="server" Text="Registros por Pagina"></asp:Label>
                                        </div>
                                    </PagerTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="ID_Bitacora" HeaderText="ID" />
                                        <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy HH:mm:ss}" />
                                        <asp:BoundField DataField="Usuario.NombreUsu" HeaderText="Usuario" />
                                        <asp:BoundField DataField="IP_Usuario" HeaderText="IP Usuario" />
                                        <asp:BoundField DataField="Tipo_Bitacora" HeaderText="Tipo Bitacora" />


                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                </div>


            </div>
        </div>

    </div>
    <%--     </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
