<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Restore.aspx.vb" Inherits="Vista.Restore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="textovalid" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessRestore" class="text-success">Se Realizó la restauracion de la base de datos correctamente.</label>
        </div>
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-info">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelRestore" runat="server" Text="Restauración del Sistema" CssClass="TituloPanel"></asp:Label>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-md-12">
                                <h5 class="text-warning text-center"><strong>
                                    <asp:Label ID="lblinfobackup" runat="server" Text="Apretando el siguiente botón se generará un archivo de extensión .bak en el servidor y este podra ser descargado para su posterior utilizacion en la restauración de la base de datos."></asp:Label></strong></h5>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4 col-md-offset-4">
                                <%--<asp:Button ID="BtnBackup" runat="server" Text="Realizar Backup" CssClass="btn btn-block btn-warning" />--%>
                             <button id="btn_confirmar3" runat="server" type="button" class="btn btn-warning btn-md col-md-6 col-md-offset-1" data-toggle="modal" data-target="#ConfirmacionModalTitle3">Realizar Backup</button>
                            </div>
                            <br />
                        </div>
                        <br />
                        <br />


                        <div class="form-horizontal has-warning">

                            <div class="form-group">
                                <div class="col-md-12">
                                    <h5 class="text-warning text-center"><strong>
                                        <asp:Label ID="lblinforestore" runat="server" Text="Solamente se podrán ingresar archivos previamente generados por el sistema, de lo contrario no funcionará."></asp:Label></strong></h5>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblbackupserv" runat="server" Text="Backup en Servidor:" CssClass="col-sm-3 col-sm-offset-1 control-label labelform"></asp:Label>
                                <div class="col-md-7">
                                    <div class="input-group">
                                        <asp:DropDownList ID="Backups" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                                        <span class="input-group-addon" id="basic-addon10"><span class="glyphicon glyphicon-hdd" aria-hidden="true"></span></span>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblbackup" runat="server" Text="Ingresar Backup:" CssClass="col-sm-3 col-sm-offset-1 control-label labelform"></asp:Label>
                                <div class="col-md-7">
                                    <asp:FileUpload ID="FileUpload1" CssClass="btn btn-block btn-default" runat="server" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                           
                                <%--<asp:Button ID="btnserver" CssClass="btn btn-block btn-danger" runat="server" Text="Restaurar Backup Servidor" />--%>
                                <button id="btn_confirmar" runat="server" type="button" class="btn btn-danger btn-md col-md-4 col-md-offset-1" data-toggle="modal" data-target="#ConfirmacionModalTitle">Restaurar Backup Servidor</button>
                           
                         
<%--                                <asp:Button ID="btnlocal" CssClass="btn btn-block btn-warning" runat="server" Text="Restaurar Backup Importado" />--%>
                                <button id="btn_confirmar2" runat="server" type="button" class="btn btn-danger btn-md col-md-4 col-md-offset-1" data-toggle="modal" data-target="#ConfirmacionModalTitle2">Restaurar Backup Importado</button>
                            </div>
                       <%-- </div>--%>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />

    <%-- Modal de Confirmacion de Eliminación --%>
    <div class="modal-normal " id="ConfirmacionModalTitle" role="dialog">
        <div class="modal-dialog" role="document">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title Blanco" id="ModalTitle">Confirmar Restore</h5>
                </div>


                <div class="modal-body Blanco">
                    <label>¿Está seguro que desea realizar la operación de Restaurar Backup Servidor?</label>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnserver" runat="server" CssClass="btn btn-primary" OnClick="btnserver_Click" Text="Aceptar" />
                    <button id="btncerrar" type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                </div>

            </div>
        </div>
    </div>

    <div class="modal-normal " id="ConfirmacionModalTitle2" role="dialog">
        <div class="modal-dialog" role="document">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title Blanco" id="ModalTitle2">Confirmar Restore</h5>
                </div>


                <div class="modal-body Blanco">
                    <label>¿Está seguro que desea realizar la operación de Restaurar Backup Importado?</label>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnlocal" runat="server" CssClass="btn btn-primary" OnClick="btnlocal_Click" Text="Aceptar" />
                    <button id="btncerrar2" type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                </div>

            </div>
        </div>
    </div>

        <div class="modal-normal " id="ConfirmacionModalTitle3" role="dialog">
        <div class="modal-dialog" role="document">

            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title Blanco" id="ModalTitle3">Confirmar Backup</h5>
                </div>


                <div class="modal-body Blanco">
                    <label>¿Está seguro que desea realizar la operación de realizar Backup ?</label>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnbackup" runat="server" CssClass="btn btn-primary" OnClick="btnbackup_Click" Text="Aceptar" />
                    <button id="btncerrar3" type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
