<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="PaginaGenerica.aspx.vb" Inherits="Vista.PaginaGenerica" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris" >
        <br />
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="textovalid" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessmodUser" class="text-success">El Usuario se creó correctamente.</label>
        </div>

<div class="row">
  <div class="col-md-12">
     <div class="panel panel-primary class">
       <div class="panel-heading text-center">
         <asp:Label ID="lblPanelModUser" runat="server" Text="Terminos y Condiciones" font-size="24px" CssClass="TituloPanel"></asp:Label>
       </div>
     </div>
 </div>
<br />
<br />    
         
                                   
</div>
    


      
</div>
   
  
   
</asp:Content>



