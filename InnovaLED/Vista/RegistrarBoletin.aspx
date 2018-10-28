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
    <br />
<div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
   <label runat="server" id="textovalid" class="text-danger"></label>
</div>
 <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
   <label id="lblsuccessmodprod" class="text-success"></label>
</div>
<div class="container-fluid fondoGris" >


<div class="row">
  <div class="col-md-12">
     <div class="panel panel-primary class">
       <div class="panel-heading text-center">
         <asp:Label ID="Lbl_GestionarProd" runat="server" Text="Newsletter" font-size="24px" CssClass="TituloPanel"></asp:Label>
       </div>
     </div>
 </div>
<br />
<br />                                 
</div>
<br />

        
            <div class="panel-group col-md-10 col-md-offset-1">
                <div class="panel-default">
                    <div class="panel-heading ">Nuevo Boletin</div>
                    <div class="panel-body">
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="row">
                                    <asp:Label ID="lbl_Nombre" runat="server" CssClass="col-sm-3 control-label labelform">Nombre</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-md-offset-1">
                                <asp:TextBox ID="txt_Nombre" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txt_Nombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="row">
                                    <asp:Label ID="lbl_Descripcion" runat="server" CssClass="col-sm-3 control-label labelform">Descripcion</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-3 col-md-offset-1">
                                <asp:TextBox ID="txt_Descripcion" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_asunto" runat="server"
                                    ControlToValidate="txt_Descripcion" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="row">
                                    <asp:Label ID="lbl_Cuerpo" runat="server" CssClass="col-sm-4 control-label labelform">Cuerpo</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:TextBox ID="txt_Cuerpo" runat="server" CssClass="form-control" Height="250px" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RequiredFieldValidator ID="requerido_txt_texto" runat="server"
                                    ControlToValidate="txt_Cuerpo" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-2 col-md-offset-2">
                                <div class="row">
                                    <asp:Label ID="lbl_TipoBoletin" runat="server" CssClass="col-sm-4 control-label labelform">Tipo de Boletin</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:DropDownList ID="ddl_TipoBoletin" runat="server" CssClass="btn-lg btn-default dropdown-toggle" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                            </div>
                        </div>
                        <div id="fechaFinVigencia" runat="server">
                            <br />

                            <div class="row">
                                <div class="col-md-2 col-md-offset-2">
                                    <div class="row">
                                        <asp:Label ID="lbl_FechaFinVigencia" runat="server" CssClass="col-sm-4 control-label labelform">Fecha Fin Vigencia</asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-5 col-md-offset-1">
                                    <asp:TextBox ID="datepicker" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-md-offset-1">
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Label ID="lbl_SeleccionarImagenBoletin" runat="server" Text="Seleccionar Imagen" CssClass="col-sm-4 control-label labelform"></asp:Label>
                            </div>
                            <div class="col-md-5 col-md-offset-1">
                                <asp:FileUpload ID="fu_imagenBoletin" runat="server" CssClass="btn btn-default btn-file" />
                            </div>
                            <div class="col-md-1 col-md-offset-1">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="fu_imagenBoletin" ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RegularExpressionValidator>
                               
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" ControlToValidate="datepicker" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RegularExpressionValidator>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fu_imagenBoletin" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="validadorSize" runat="server" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="validador" ControlToValidate="fu_imagenBoletin" OnServerValidate="validadorSize_ServerValidate"></asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-2 col-md-offset-3">
                            <asp:Button ID="btn_agregar" runat="server" Text="Agregar" CssClass="btn btn-lg btn-primary" />
                        </div>
                        <div class="col-md-2 col-md-offset-1">
                            <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar" CssClass="btn btn-lg btn-warning" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
       
    </div>
     
<br />



</asp:Content>
