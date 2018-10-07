<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Faqs.aspx.vb" Inherits="Vista.Faqs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
        <br />

     <div class="row text-center col-md-12">
         <br />
         <div class="panel-heading text-center">
             <asp:label ID="Lbl_Garantia" runat="server" font-size="22px" Text="¿INNOVA LED CUENTA CON GARANTIA?" CssClass="TituloPanel"></asp:label>
         </div>
          <br />

         <div class="row">
             <asp:Label ID="Lbl_Garantia_descrip" runat="server" font-size="20px" text="Contamos con garantía de 12 meses por cada producto adquirido. También contamos con garantía extendida."></asp:label>
               <br />
               <br />
             
            </div>
         
    <br />
    <br />
    <br />
    

    <div class="row text-center">
        <div class="p-heading-03 panel-heading-light">
             <asp:label ID="Lbl_Devolucion" runat="server" font-size="22px" Text="¿EN CASO DE FALLA O ROTURA HAY CAMBIO?" CssClass="TituloPanel"></asp:label>
         </div>
    </div>

     <br />
    <div class="row">
             <asp:label ID="Lbl_Devolucion_Descripcion" runat="server" font-size="18px" text="Si, contamos con cambio. Una vez realizada la compra, tendrá de prueba una semana, en caso de falla de funcionamiento o falla de fábrica, se puede cambiar por el lugar donde retiró el producto." ></asp:label>
        </div>
   <br />
    <br />
    <br />

     <div class="row text-center">
        <div class="p-heading-03 panel-heading-light">
             <asp:label ID="Lbl_Puntos_De_Entrega" runat="server" font-size="22px" Text="¿CUALES SON LOS PUNTOS DE ENTREGA?" CssClass="TituloPanel"></asp:label>
         </div>
    </div>
     <br />
    <div class="row">
             <asp:label ID="Lbl_Puntos_De_Entrega_Descrip" runat="server" font-size="18px" text="Contamos con distintos puntos de entrega situados en Ciudad de Buenos Aires, Provincia de Gran Buenos Aires, Córdoba y Santa Fé. " ></asp:label>
        </div>
    <br />
    <br />
    <br />
     <div class="row text-center">
        <div class="p-heading-03 panel-heading-light">
             <asp:label ID="Lbl_Envios" runat="server" font-size="22px" Text="¿CUENTAN CON ENVIOS PROGRAMADOS?" CssClass="TituloPanel"></asp:label>
         </div>
    </div>

      <br />
    <div class="row">
             <asp:label ID="Lbl_Envios_Descrip" runat="server" font-size="18px" text="Sí, contamos con envios a domicilio, se pueden programar a en base a la disponibilidad del cliente." ></asp:label>
        </div>

       <br />
</div>



   
</asp:Content>


