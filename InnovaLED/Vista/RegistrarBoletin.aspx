<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="RegistrarBoletin.aspx.vb" Inherits="Vista.RegistrarBoletin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="JS/jquery-1.9.1.min.js"></script>
    <script src="JS/jquery-ui.js"></script>
    <link href="CSS/DateTimePicker.css" rel="stylesheet" type="text/css" />
    <script>
        $(function () {
            $("#contenidoPagina_datepicker").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <div class="fila">
            <div class="col-md-12">
                <div id="error" class="msj-error col-md-12" runat="server" visible="false">
                    <asp:Label ID="lbl_TituloError" runat="server" CssClass="label"></asp:Label>
                </div>
            </div>
        </div>
        <div class="fila">
            <div class="col-md-12">
                <div id="correcto" class="msj-ok col-md-12" runat="server" visible="false">
                    <asp:Label ID="lbl_AccionCorrecta" runat="server" CssClass="label"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="fila">
            <div class="col-md-10 col-md-offset-1">
                <div class="panel panel-verde">
                    <div class="panel-cabecera">
                        <asp:Label ID="cab_RegistrarBoletin" runat="server">Nuevo Boletin</asp:Label>
                    </div>
                    <div class="panel-cuerpo">
                        <br />
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="label">
                                    <asp:Label ID="lbl_Nombre" runat="server" CssClass="label">Nombre</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:TextBox ID="txt_Nombre" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txt_Nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="label">
                                    <asp:Label ID="lbl_Descripcion" runat="server" CssClass="label">Descripcion</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:TextBox ID="txt_Descripcion" runat="server" CssClass="caja-texto" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_asunto" runat="server"
                                    ControlToValidate="txt_Descripcion" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />

                        <div class="fila">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="label">
                                    <asp:Label ID="lbl_Cuerpo" runat="server" CssClass="label">Cuerpo</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:TextBox ID="txt_Cuerpo" runat="server" CssClass="caja-texto sinEditar" Height="250px" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_texto" runat="server"
                                    ControlToValidate="txt_Cuerpo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />

                        <div class="fila">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="label">
                                    <asp:Label ID="lbl_TipoBoletin" runat="server" CssClass="label">Tipo de Boletin</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:DropDownList ID="ddl_TipoBoletin" runat="server" CssClass="combo" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                            </div>
                        </div>
                        <div id="fechaFinVigencia" runat="server" visible="false">
                            <br />

                            <div class="fila">
                                <div class="col-md-2 col-md-offset-2">
                                    <div class="label">
                                        <asp:Label ID="lbl_FechaFinVigencia" runat="server" CssClass="label">Fecha Fin Vigencia</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="datepicker" runat="server" CssClass="caja-texto"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-md-offset-1">
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="fila">
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Label ID="lbl_SeleccionarImagenBoletin" runat="server" Text="Seleccionar Imagen" CssClass="label"></asp:Label>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:FileUpload ID="fu_imagenBoletin" runat="server" CssClass="label" />
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="fu_imagenBoletin" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fu_imagenBoletin" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="validadorSize" runat="server" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador" ControlToValidate="fu_imagenBoletin" OnServerValidate="validadorSize_ServerValidate"></asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="fila">
                        <div class="col-md-2 col-md-offset-3">
                            <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-aceptar btn-block" />
                        </div>
                        <div class="col-md-2 col-md-offset-2">
                            <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-cancelar btn-block" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
    <br />



</asp:Content>
