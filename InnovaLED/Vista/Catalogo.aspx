<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Catalogo.aspx.vb" Inherits="Vista.Catalogo" MaintainScrollPositionOnPostback="true" %>

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
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Catalogo" font-size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                 </div>
            </div>
           <br />
           <br />
                                   
            </div>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>


         <%-- Content Media - Catalogo --%>

<div class="col-md-4">

<div class="panel-group">
<div class="panel-default">
<div class="panel-heading ">Búsqueda</div>
        <div class="panel-body">
 
<div class="row">
   <asp:Label ID="Lbl_marca" runat="server" Text="Marca:" CssClass="col-sm-4 control-label labelform"></asp:Label>
      <div class="col-md-8">         
             <asp:TextBox ID="txtmarca" runat="server" CssClass="form-control"></asp:TextBox>           
         </div>
    </div>
<br/>                 

<div class="row">
   <asp:Label ID="Lbl_modelo" runat="server" Text="Modelo:" CssClass="col-sm-4 control-label labelform"></asp:Label>
      <div class="col-md-8">
         <asp:TextBox ID="txtmodelo" runat="server" CssClass="form-control"></asp:TextBox>                 
        </div>
   </div>
<br/>


<div class="row">
   <asp:Label ID="Lbl_peso" runat="server" Text="Peso:" CssClass="col-sm-4 control-label labelform"></asp:Label>
      <div class="col-md-4">         
             <asp:TextBox ID="txtpesodesde" placeholder="Desde" runat="server" CssClass="form-control"></asp:TextBox>
      </div>
      <div class="col-md-4">
             <asp:TextBox ID="txtpesohasta" placeholder="Hasta" runat="server" CssClass="form-control"></asp:TextBox>           
     </div>
</div>
<br/>

<div class="row">
   <asp:Label ID="Lbl_precio" runat="server" Text="Precio:" CssClass="col-sm-4 control-label labelform"></asp:Label>
      <div class="col-md-4">         
             <asp:TextBox ID="txtpreciodesde" runat="server" placeholder="Desde" CssClass="form-control"></asp:TextBox>
      </div>
      <div class="col-md-4"> 
             <asp:TextBox ID="txtpreciohasta" runat="server" placeholder="Hasta" CssClass="form-control"></asp:TextBox>            
      </div>
</div>
<br/>


<div class="row">
   <asp:Label ID="Lbl_watt" runat="server" Text="Watt:" CssClass="col-sm-4 control-label labelform"></asp:Label>
      <div class="col-md-4">
                 <asp:TextBox ID="txtwattdesde" runat="server" placeholder="Desde" CssClass="form-control"></asp:TextBox>
       </div>
          <div class="col-md-4">
              <asp:TextBox ID="txtwatthasta" runat="server" placeholder="Hasta" CssClass="form-control"></asp:TextBox>
       </div>
</div>
<br/>

<div class="row">
     <asp:Label ID="Lbl_linea" runat="server" Text="Línea del Producto:" CssClass="col-sm-4 control-label labelform"></asp:Label>
          <div class="col-md-8">

                 <asp:DropDownList ID="DropDownLinea" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="ID_Linea" DataTextField="Nombre"></asp:DropDownList>
               </div>
       
</div>
<br/>

<div class="row">
     <asp:Label ID="Lbl_cat" runat="server" Text="Categoria Producto:" CssClass="col-sm-4 control-label labelform"></asp:Label>
          <div class="col-md-8">
              
                 <asp:DropDownList ID="DropDowncat" runat="server" CssClass="form-control" AutoPostBack="true" DataValueField="ID_CategoriaProducto" DataTextField="Nombre"></asp:DropDownList>
          
         </div>
</div>
<br/>



<div class="row">
            
<asp:button ID="btn_filtrar" runat="server" text="Filtrar" type="button" class="btn btn-success btn-lg col-md-12"></asp:button>
  
&nbsp;
</div>   
            

      
                   
</div> 

   
            
   
            
            
         
</div>
</div >


</div>

        <div id="ID_Catalogo" runat="server" class="col-md-8">
      

         </div>
      
</div>
   
    <asp:HiddenField ID="id_usuario" runat="server" />
</ContentTemplate>
  </asp:UpdatePanel>
   
</asp:Content>
