<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="AgregarPerfil.aspx.vb" Inherits="Vista.GestionarPerfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblroles" runat="server" Text="Label"></asp:Label>

    <br />
    <asp:DropDownList ID="Dropdwnroles" runat="server">
    </asp:DropDownList>
    <br />
    <br />

    <div class="row col-md-12 ">
    <asp:ListBox ID="Lstperfilesactuales" Class=" col-md-offset-1 col-md-3" runat="server"></asp:ListBox>
       <asp:Button ID="Btnagregarrol" class="btn btn-info col-md-offset-1 col-md-1 btn-lg " runat="server" Text="Agregar"/>
       <asp:Button ID="Btnquitarrol" class="btn btn-info col-md-1  btn-lg" runat="server" Text="Quitar" />
      
         <asp:ListBox ID="Lsttodoslosperfiles" Class=" col-md-3 col-md-offset-1" runat="server"></asp:ListBox>
        
     </div>



    

</asp:Content>
