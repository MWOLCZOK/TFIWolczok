<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Faqs.aspx.vb" Inherits="Vista.Faqs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid fondoGris" >
<br />
<div class="row">
  <div class="col-md-12">
     <div class="panel panel-primary class">
       <div class="panel-heading text-center">
         <asp:Label ID="lblPanelModUser" runat="server" Text="Preguntas Frecuentes" font-size="24px" CssClass="TituloPanel"></asp:Label>
       </div>
     </div>
   </div>
</div>
<br />

<div class="panel-body">

<div class="row text-left">
       <asp:label ID="Lbl_Led" runat="server" font-size="22px" Text="¿Qué son los LED?" CssClass="TituloPanel"></asp:label>
</div>
<br/>

<div class="row text-left">   
  <asp:Label ID="Lbl_Led_descrip" runat="server" font-size="18px" text="Los LED son diodos emisores de luz. Son componentes electrónicos que convierte la energía eléctrica directamente en luz mediante el movimiento de electrones dentro del material del diodo. Los LED son importantes porque, debido a su eficiencia y baja energía, comienzan a remplazar a la mayoría de las fuentes de luz convencionales."></asp:label>
</div>
<br />
<br />
<div class="row text-left">
       <asp:label ID="Lbl_Led_Resis" runat="server" font-size="22px" Text="¿Qué hace que los LED sean más resistentes que otras fuentes de luz?" CssClass="TituloPanel"></asp:label>
</div>
<br/>

<div class="row text-left">   
  <asp:Label ID="Lbl_Led_Resis_descrip" runat="server" font-size="18px" text="Los LED no tienen no gases, filamentos ni partes en movimiento que se gasten. Proporcionan luz mediante un proceso de un paso que tiene lugar dentro del diodo. No hay vidrio que se pueda romper ni contactos atornillados que se aflojen.."></asp:label>
</div>
<br />
<br />
<div class="row text-left">
       <asp:label ID="Lbl_Led_Ventajas" runat="server" font-size="22px" Text="¿Cuáles son las ventajas económicas de los LED con respecto a las fuentes de luz convencionales?" CssClass="TituloPanel"></asp:label>
</div>
<br/>

<div class="row text-left">   
  <asp:Label ID="Lbl_Led_Ventajas_descrip" runat="server" font-size="18px" text="Aunque el coste inicial de las fuentes de luz convencionales es menor que los LED, los costes de mantenimiento y operativos del LED son significativamente inferiores. Los LED, con una vida útil más larga, reduce los costes de mantenimiento y de sustitución de lámparas. . Como los LED se remplazan con menos frecuencia, el dueño gasta menos en lámparas y mano de obra. Los LED también consumen menos energía, por tanto el coste global de un sistema LED es significativamente inferior que los sistemas de iluminación convencionales. La mayoría de las aplicaciones con LED ofrecen un periodo de amortización de unos tres a cuatro años."></asp:label>
</div>
<br />
<br />
<div class="row text-left">
       <asp:label ID="Lbl_Led_Econo" runat="server" font-size="22px" Text="¿Cuáles son las ventajas económicas de los LED con respecto a las fuentes de luz convencionales?" CssClass="TituloPanel"></asp:label>
</div>
<br/>

<div class="row text-left">   
  <asp:Label ID="Lbl_Led_Econo_descrip" runat="server" font-size="18px" text="Aunque el coste inicial de las fuentes de luz convencionales es menor que los LED, los costes de mantenimiento y operativos del LED son significativamente inferiores. Los LED, con una vida útil más larga, reduce los costes de mantenimiento y de sustitución de lámparas. . Como los LED se remplazan con menos frecuencia, el dueño gasta menos en lámparas y mano de obra. Los LED también consumen menos energía, por tanto el coste global de un sistema LED es significativamente inferior que los sistemas de iluminación convencionales. La mayoría de las aplicaciones con LED ofrecen un periodo de amortización de unos tres a cuatro años."></asp:label>
</div>
<br />
<br />
<div class="row text-left">
       <asp:label ID="Lbl_Led_Verde" runat="server" font-size="22px" Text="¿Por qué los LED se consideran tecnología verde?" CssClass="TituloPanel"></asp:label>
</div>
<br/>

<div class="row text-left">   
  <asp:Label ID="Lbl_Led_Verde_descrip" runat="server" font-size="18px" text="Los LED son más eficientes que la mayoría de las fuentes de luz porque, en general, consumen menos energía en una tarea determinada o con un flujo luminoso específico. Además no contienen materiales peligrosos como el mercurio tóxico. Por otra parte, los LED tienen una vida útil más larga y también reducen la frecuencia del reciclado de las lámparas."></asp:label>
</div>
<br />
<br />

<div class="row text-left">
       <asp:label ID="Lbl_Garantia" runat="server" font-size="22px" Text="¿Innova LED cuenta con garantía?" CssClass="TituloPanel"></asp:label>
</div>
<br/>

<div class="row text-left">   
  <asp:Label ID="Lbl_Garantia_descrip" runat="server" font-size="18px" text="Contamos con garantía de 12 meses por cada producto adquirido. También contamos con garantía extendida."></asp:label>
</div>
<br />
<br />
<div class="row text-left">
  <asp:label ID="Lbl_Devolucion" runat="server" font-size="22px" Text="¿En caso de rotura o falla, hay cambio?" CssClass="TituloPanel"></asp:label>
</div>
<br />
<div class="row text-left">
         <asp:label ID="Lbl_Devolucion_Descripcion" runat="server" font-size="18px" text="Si, contamos con cambio. Una vez realizada la compra, tendrá de prueba una semana, en caso de falla de funcionamiento o falla de fábrica, se puede cambiar por el lugar donde retiró el producto." ></asp:label>
</div>
<br />
<br />

<div class="row text-left">
     <asp:label ID="Lbl_Puntos_De_Entrega" runat="server" font-size="22px" Text="¿Cuáles son los puntos de entrega?" CssClass="TituloPanel"></asp:label>
</div>
<br />
<div class="row text-left">
    <asp:label ID="Lbl_Puntos_De_Entrega_Descrip" runat="server" font-size="18px" text="Contamos con distintos puntos de entrega situados en Ciudad de Buenos Aires, Provincia de Gran Buenos Aires, Córdoba y Santa Fé. " ></asp:label>
</div>
<br />
<br />
<div class="row text-left">
   <asp:label ID="Lbl_Envios" runat="server" font-size="22px" Text="¿Cuentan con envío programado?" CssClass="TituloPanel"></asp:label>
</div>
<br />
<div class="row text-left">
    <asp:label ID="Lbl_Envios_Descrip" runat="server" font-size="18px" text="Sí, contamos con envios a domicilio, se pueden programar a en base a la disponibilidad del cliente." ></asp:label>
</div>
<br />
</div>
</div>
   
</asp:Content>


