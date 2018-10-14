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
                <label id="lbl_success" runat="server" class="text-success">Se ha modificado el usuario correctamente.</label>
            </div>
        </div>



        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Modificacion de Datos Personales" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <%-- Sección Tabla Usuarios  --%>

            <div class="form-horizontal has-success col-md-6 ">
                <div class="form-group">
                    <asp:Label ID="lblapellido" runat="server" Text="Apellido:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                    <div class="col-md-4">
                        <div class="input-group">
                            <asp:TextBox ID="txtapellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-addon" id="basic-addon1"><span class="	glyphicon glyphicon-user" aria-hidden="true"></span></span>
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
                            <span class="input-group-addon" id="basic-addon2"><span class="	glyphicon glyphicon-user" aria-hidden="true"></span></span>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnombre" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblpass" runat="server" Text="Contraseña:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                    <div class="col-md-4">
                        <div class="input-group">
                            <input type="password" id="txtpass" runat="server" class="form-control" />
                            <span class="input-group-addon" id="basic-addon9"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
                        </div>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Nueva Contraseña:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                    <div class="col-md-4">
                        <div class="input-group">
                            <input type="password" id="newpass1" runat="server" class="form-control" />
                            <span class="input-group-addon" id="basic-addon9"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
                        </div>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Repetir Nueva Contraseña:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                    <div class="col-md-4">
                        <div class="input-group">
                            <input type="password" id="newpass2" runat="server" class="form-control" />
                            <span class="input-group-addon" id="basic-addon9"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
                        </div>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="LblDNI" runat="server" Text="DNI:" CssClass="col-sm-4 control-label labelform"></asp:Label>
                    <div class="col-md-4">
                        <div class="input-group">
                            <asp:TextBox ID="TxtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                            <span class="input-group-addon" id="basic-addon9"><span class="glyphicon glyphicon-lock" aria-hidden="true"></span></span>
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
                            <span class="input-group-addon" id="basic-addon8"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></span>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmail" ErrorMessage="*" EnableClientScript="false" Display="Dynamic" CssClass="textoValidacion"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>


            <br />
            <br />

            <div class="row">
                <div class="col-md-3 col-md-offset-1 ">
                    <asp:Button ClientIDMode="Static" ID="btnModificar" name="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-block btn-warning" />
                </div>
            </div>
            <br />
            <br />
        </div>
    </div>
    <br />
    <br />


    <asp:HiddenField ID="id_usuario" runat="server" />

</asp:Content>
