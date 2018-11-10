<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Encuesta.aspx.vb" Inherits="Vista.Encuesta" %>



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
            <label id="lblsuccessmodUser" class="text-success"></label>
        </div>

<div class="row"> 
    <div class="row text-center">
    <h1>¡Muchas gracias por su compra!</h1> 
    </div> 
    <br />
    <br />

     <div class="row text-center">
    <h3>Lo invitamos a responder una breve encuesta acerca de nuestro sitio</h3> 
    </div> 
    <br />
    <br />

    
            
                                   
</div>
    


      
</div>
   
  
   
</asp:Content>


