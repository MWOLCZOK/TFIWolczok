<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AgregarPerfil.aspx.vb" Inherits="Vista.GestionarPerfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="row">
        <br />
        <br />
    <asp:Label ID="lblroles" class="  col-md-offset-1 col-md-3" font-weight="lighter" font-size="24px" runat="server" Text="Label"></asp:Label>
        </div>
    <div class="row">
    <br />
    <asp:DropDownList ID="DropdwnrolesListar" CssClass="btn btn-default dropdown-toggle col-md-offset-1 col-md-2" runat="server">
    </asp:DropDownList>
    <br />
        </div>

        <div class="row">
            <br />
        <asp:Label ID="Lblpermisosactuales" Class="  col-md-offset-1 col-md-3" font-weight="lighter" font-size="24px" runat="server" Text="Label"></asp:Label>

        <asp:Label ID="Lblpermisosdisponibles" Class="  col-md-offset-4 col-md-3 " font-weight="lighter"  font-size="24px" runat="server" Text="Label"></asp:Label>
    <br />
    </div>

    <div class="row">
    <asp:ListBox ID="Lstperfilesactuales" Class=" col-md-offset-1 col-md-3" runat="server" Rows="20"></asp:ListBox>
       <asp:Button ID="Btnagregarrol" class="btn btn-info col-md-offset-1 col-md-1 btn-lg " runat="server" Text="Agregar"/>
       <asp:Button ID="Btnquitarrol" class="btn btn-info col-md-1  btn-lg" runat="server" Text="Quitar" />
       
         <asp:ListBox ID="Lsttodoslosperfiles" Class=" col-md-3 col-md-offset-1" runat="server" Rows="20"></asp:ListBox>
        
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

            <asp:Button ID="Btncrearrol"  Class=" btn btn-info col-md-offset-1 col-md-1 btn-sm" runat="server" Text="Button" />
            <asp:TextBox ID="Txtcrearrol" Class=" col-md-2" runat="server"></asp:TextBox>

            <asp:Button ID="Btneliminarrol" Class=" btn btn-info col-md-offset-4 col-md-1 btn-sm"  runat="server" Text="Button" />
            <asp:DropDownList ID="DropdwnrolesElim" class="btn btn-default dropdown-toggle col-md-2" runat="server">
            </asp:DropDownList>
            <br />
          <br />
          <br />
          <br />

    </div>



    

</asp:Content>
