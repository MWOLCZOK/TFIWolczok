<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarEncuestas.aspx.vb" Inherits="Vista.GestionarEncuestas" %>


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
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Gestión de Encuestas" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />


        </div>


        <div class="panel-group col-md-5">
            <div class="panel-default">
                <div class="panel-heading ">Encuesta</div>
                <div class="panel-body">
                    <br />
                    <br />
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:Label ID="lbl_Nombrepregunta" runat="server"  Font-Bold="true" Text="Pregunta"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Nombrepregunta" runat="server"  placeholder="Ingrese enunciado" CssClass="form-control" MaxLength="70"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Nombrepregunta" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:Label ID="Lbl_tipopreg" runat="server" Font-Bold="true" Text="Tipo de Pregunta"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddl_tipopregunta" runat="server" CssClass="btn-md btn-default dropdown-toggle form-control" AutoPostBack="false"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:Label ID="lbl_FechaFinVigencia2" runat="server" Text="Fecha Fin Vigencia" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="datepicker" runat="server" placeholder="DD/MM/AAAA" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="datepicker" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:Label ID="Lbl_rtas" runat="server" Text="Respuesta" Font-Bold="true"></asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_rtas" runat="server" MaxLength="50" placeholder="Ingrese respuesta" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btn_agregarrta" runat="server" Text="Agregar Respuesta" CssClass="btn btn-success btn-md" />
                        </div>
                    </div>
                    <br />
                    <br />


                    <div class="row">


                        <div class="col-md-4">

                            <asp:GridView CssClass="table table-hover table-bordered table-responsive table-active " ID="gv_respuestas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" RowStyle-Height="40px">
                                <HeaderStyle CssClass="thead-dark" />
                                <Columns>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Respuestas" />
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <div>
                                                <asp:ImageButton ID="btn_Respuestas" runat="server" CommandName="S" ImageUrl="~/Imagenes/clear.png" Height="18px" />
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>


                    <%-- <div class="row" id="Div_Encuesta" runat="server" visible="false">
                        <div class="col-md-4">
                            <div class="row">
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Lbl_muybueno" runat="server" Text="Muy bueno"></asp:Label>
                            </div>
                            <div class="row">
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Lbl_bueno" runat="server" Text="Bueno"></asp:Label>
                            </div>
                            <div class="row">
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Lbl_regular" runat="server" Text="Regular"></asp:Label>
                            </div>
                            <div class="row">
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Lbl_malo" runat="server" Text="Malo"></asp:Label>
                            </div>
                            <div class="row">
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Lbl_muymalo" runat="server" Text="Muy malo"></asp:Label>
                            </div>
                        </div>
                    </div>--%>
                </div>
                <br />

                <div class="col-md-offset-1">
                    <div class="row">
                        <asp:Button ID="btn_nuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btn-md col-md-2 " Visible="false" />
                        <asp:Button ID="btn_agregar" runat="server" Text="Agregar Pregunta" CssClass="btn btn-success btn-md col-md-4 col-md-offset-1" />
                        <asp:Button ID="btn_modificar" runat="server" Text="Modificar" CssClass="btn btn-info btn-md col-md-2 col-md-offset-1" Visible="false" />
                        <%-- <asp:Button ID="btn_eliminarPregunta" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-md col-md-2 col-md-offset-1" Visible="false" />--%>
                        <button id="btn_confirmar" runat="server" type="button" class="btn btn-danger btn-md col-md-2 col-md-offset-1" data-toggle="modal" data-target="#ConfirmacionModalTitle" visible="false">Eliminar</button>
                    </div>
                </div>
                <br />
            </div>
        </div>


        <%-- Modal de Confirmacion de Eliminación --%>
        <div class="modal-normal " id="ConfirmacionModalTitle" role="dialog">
            <div class="modal-dialog" role="document">

                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title Blanco" id="ModalTitle">Confirmar Eliminación</h5>
                    </div>


                    <div class="modal-body Blanco">
                        <label>¿Está seguro que desea realizar la operación de Eliminación?</label>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btneliminar" runat="server" CssClass="btn btn-primary" OnClick="btneliminar_Click" Text="Aceptar" />
                        <button id="btncerrar" type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                    </div>

                </div>
            </div>
        </div>


        <%-- Sección GRID Encuestas--%>

        <div class="col-md-5">
            <asp:GridView CssClass="table table-hover table-bordered table-responsive table-active " ID="gv_Encuestas" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" AllowPaging="true" PageSize="10" OnPageIndexChanging="gv_Encuestas_PageIndexChanging" RowStyle-Height="40px">
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
                    <asp:BoundField DataField="ID" HeaderText="Numero Encuesta" />
                    <asp:BoundField DataField="Enunciado" HeaderText="Enunciado" />
                    <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta" DataFormatString="{0:dd-MM-yyyy HH:mm:ss}" />
                    <asp:BoundField DataField="TipoPregunta" HeaderText="Tipo de Pregunta" />
                    <asp:BoundField DataField="FechaFinVigencia" HeaderText="Fecha Fin Vigencia" />
                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <div>
                                <asp:ImageButton ID="btn_editar" runat="server" CommandName="E" ImageUrl="~/Imagenes/edit.png" Height="18px" />
                            </div>
                        </ItemTemplate>
                        <HeaderStyle Width="100px"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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




