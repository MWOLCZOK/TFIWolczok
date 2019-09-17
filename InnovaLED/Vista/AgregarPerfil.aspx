<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AgregarPerfil.aspx.vb" Inherits="Vista.GestionarPerfiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary class">
                <div class="panel-heading text-center">
                    <asp:Label ID="lblPanelModUser" runat="server" Text="Gestionar Roles" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br />


    <div class="row">
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="lbl_textovalid" class="text-danger"></label>
        </div>

        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lbl_success" runat="server" class="text-success"></label>
        </div>

        <asp:Label ID="lblroles" class="  col-md-offset-1 col-md-3" font-weight="lighter" Font-Size="24px" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="dropdown">
        <br />
        <asp:DropDownList ID="DropdwnrolesListar" Class="btn btn-default dropdown-toggle col-md-offset-1 col-md-2" DataTextField="Nombre" DataValueField="ID_Rol" runat="server" AutoPostBack="true" Height="25px" Width="200px">
        </asp:DropDownList>
        <br />
    </div>


    <div class="row">
        <br />
        <asp:Label ID="Lblpermisosactuales" Class="  col-md-offset-1 col-md-3" font-weight="lighter" Font-Size="24px" runat="server" Text="Label"></asp:Label>

        <asp:Label ID="Lblpermisosdisponibles" Class="  col-md-offset-4 col-md-3 " font-weight="lighter" Font-Size="24px" runat="server" Text="Label"></asp:Label>
        <br />
    </div>

    <div class="row">
        <asp:ListBox ID="Lstperfilesactuales" Class=" col-md-offset-1 col-md-3" runat="server" Rows="20" DataTextField="Nombre" DataValueField="ID_Permiso" AutoPostBack="true"></asp:ListBox>
        <asp:Button ID="Btnagregarrol" class="btn btn-info col-md-offset-1 col-md-1 btn-lg " runat="server" Text="Agregar" />
        <asp:Button ID="Btnquitarrol" class="btn btn-info col-md-1  btn-lg" runat="server" Text="Quitar" />

        <asp:ListBox ID="Lsttodoslosperfiles" Class=" col-md-3 col-md-offset-1" DataTextField="Nombre" DataValueField="ID_Permiso" runat="server" Rows="20" AutoPostBack="true"></asp:ListBox>

    </div>

    <div class="row">
        <br />
        <br />
        <asp:Button ID="Btnaceptar" Class=" btn btn-success col-md-offset-8 col-md-1 btn-sm" runat="server" Text="Button" />
        <asp:Button ID="Btncancelar" Class=" btn btn-default col-md-offset-1 col-md-1 btn-sm" runat="server" Text="Button" />
        <br />
        <br />
        <br />
        <br />
    </div>


    <div class="row">

        <asp:Button ID="Btncrearrol" Class=" btn btn-info col-md-offset-1 col-md-1 btn-sm" runat="server" Text="Button" />
        <asp:TextBox ID="Txtcrearrol" Class=" col-md-2" runat="server"></asp:TextBox>      
        <button id="btn_confirmar" runat="server" type="button" class="btn btn-danger btn-md col-md-1 col-md-offset-1" data-toggle="modal" data-target="#ConfirmacionModalTitle">Eliminar</button>
        <asp:DropDownList ID="DropdwnrolesElim" class="btn btn-default dropdown-toggle col-md-2" runat="server" Height="25px" Width="200px">
        </asp:DropDownList>

        <br />
        <br />
        <br />
        <br />

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
    </div>





</asp:Content>
