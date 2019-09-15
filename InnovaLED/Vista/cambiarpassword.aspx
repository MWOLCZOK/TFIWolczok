<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="cambiarpassword.aspx.vb" Inherits="Vista.cambiarpassword" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris">
        <br />
        <div class="row">
            <div id="alert" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
                <label runat="server" id="lbl_textovalid" class="text-danger"></label>
            </div>

            <div id="div_success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
                <label id="lbl_success" runat="server" class="text-success"></label>
            </div>
        </div>






        <div class="row">
            <%-- Panel de Cambios de Datos personales --%>
            <div class="col-md-6">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Modificacion de Datos Personales" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                    <br />
                    <div class="panel-body">
                        <div class="form-horizontal has-success  ">
                            <div class="form-group">
                                <asp:Label ID="lblapellido" runat="server" Text="Apellido:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtapellido" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtapellido" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblnombre" runat="server" Text="Nombre:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>                            

                            <div class="form-group">
                                <asp:Label ID="LblDNI" runat="server" Text="DNI:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="TxtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-1">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDNI" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group">
                                <asp:Label ID="Lblmail" runat="server" Text="Mail:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmail" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4 col-md-offset-4 ">
                                <asp:Button ClientIDMode="Static" ID="btnModificarDatosPersonales" name="btnModificar" runat="server" Text="Modificar Datos Personales" CssClass="btn btn-block btn-warning" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <%-- Panel de Cambio de Contraseña --%>
            <div class="col-md-6">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="Label3" runat="server" Text="Modificacion de Contraseña" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                    <br />
                    <div class="panel-body">
                        <div class="form-horizontal has-success  ">

                            <div class="form-group">
                                <asp:Label ID="Label6" runat="server" Text="Contraseña:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <input type="password" id="txtpass" runat="server" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label7" runat="server" Text="Nueva Contraseña:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <input type="password" id="newpass1" runat="server" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="Label8" runat="server" Text="Repetir Nueva Contraseña:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <input type="password" id="newpass2" runat="server" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>


                            <div class="col-md-4 col-md-offset-4 ">
                                <asp:Button ClientIDMode="Static" ID="btnModificarContraseña" name="btnModificarContraseña" runat="server" Text="Modificar Contraseña" CssClass="btn btn-block btn-info" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <br />

        <br />
    </div>
    <br />
    <br />


    <asp:HiddenField ID="id_usuario" runat="server" />

</asp:Content>
