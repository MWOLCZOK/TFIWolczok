<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="PoliticasySeguridad.aspx.vb" Inherits="Vista.PoliticasySeguridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
        <br />

     <div class="row text-center col-md-12">
         <br />
         <div class="p-heading-03 panel-heading-light">
             <asp:label ID="LblEnquecasos" runat="server" font-size="22px" Text="¿EN QUÉ CASOS COMPARTIREMOS SUS DATOS?" CssClass="TituloPanel"></asp:label>
         </div>
          <br />

         <div class="row">
             <asp:Label ID="LblEnquecasosdescr" runat="server" font-size="20px" text="No compartiremos sus datos, salvo en los casos limitados descritos a continuación.
                             En caso de que sea necesario a los efectos de cumplir con los fines descritos en esta Política, podremos divulgar sus datos a las entidades siguientes:"></asp:label>
               <br />
               <br />
             <ul class="TituloPanel">
             <li>
             Afiliados de Innova LED: debido a nuestra naturaleza global, sus datos podrán ser compartidos con determinados afiliados de Innova LED. El acceso a sus datos dentro de Web se limitará a aquellas personas que tengan la necesidad de conocer la información.
             </li>

             <li>
                 
                Proveedores de servicios: al igual que muchas otras empresas, podríamos subcontratar determinadas actividades de tratamiento de los datos a proveedores externos de nuestra confianza que llevan a cabo funciones determinadas y nos presten servicios concretos, por ejemplo: proveedores de servicios TIC, de Socios comerciales: podremos compartir sus datos con socios comerciales de confianza para que puedan prestarle los servicios que solicite.
            
             </li>

             <li>Autoridades públicas y gubernamentales: cuando así se requiera por ley, o cuando sea necesario para salvaguardar nuestros derechos, podremos compartir sus datos con entidades reguladoras o con competencia sobre Innova LED.</li>
             <li>Asesores profesionales y otros: podremos compartir sus datos con terceros, incluidos asesores profesionales del tipo de bancos, aseguradoras, auditores, abogados, contables y otros asesores profesionales.</li>
             <li>Terceros en relación con operaciones corporativas: también podremos compartir sus datos oportunamente en el curso de operaciones societarias, por ejemplo en los procesos de venta de una empresa o de una parte de esta a otra entidad, o en cualquier operación de reorganización, fusión, creación de una empresa conjunta u otra transacción de enajenación de nuestro negocio, activos o acciones (lo que incluye casos en relación con cualquier procedimiento de concurso de acreedores o similar).</li>
             </ul>
            </div>
         
    <br />
    <br />
    <br />
    

    <div class="row text-center">
        <div class="p-heading-03 panel-heading-light">
             <asp:label ID="Lbldatosextraj" runat="server" font-size="22px" Text="¿TRANSFERIREMOS SUS DATOS AL EXTRANJERO?" CssClass="TituloPanel"></asp:label>
         </div>
    </div>

     <br />
    <div class="row">
             <asp:label ID="Lbldatosextrajdescr" runat="server" font-size="18px" text=" Debido a nuestra naturaleza, los datos que nos proporcione podrían ser transferidos a afiliados de Innova LED y a terceros de confianza, que podrían acceder a los mismos. Por ello, sus datos podrían ser tratados fuera del país en el que usted viva siempre que ello sea necesario para el cumplimiento de los fines descritos en el presente Aviso.
                 Si se encuentra en un país perteneciente al Espacio Económico Europeo, podremos transferir sus datos a países situados fuera del mismo. Algunos de estos países ofrecen un nivel de protección adecuado, según lo ha reconocido la Comisión Europea. Por lo que respecta a las transferencias desde el Espacio Económico Europeo hasta otros países que, según el criterio de la Comisión Europea, no proporcionan un nivel de protección adecuado, hemos implantado medidas adecuadas para proteger sus datos, como medidas organizativas y legales (por ejemplo, normas empresariales obligatorias y cláusulas contractuales estándares aprobadas por la Comisión Europea)." ></asp:label>
        </div>
   <br />
    <br />
    <br />

     <div class="row text-center">
        <div class="p-heading-03 panel-heading-light">
             <asp:label ID="Lbldurantecuantotiempo" runat="server" font-size="22px" Text="¿DURANTE CUÁNTO TIEMPO CONSERVAMOS SUS DATOS?" CssClass="TituloPanel"></asp:label>
         </div>
    </div>
     <br />
    <div class="row">
             <asp:label ID="Lbldurantecuantotiempodesc" runat="server" font-size="18px" text=" Conservaremos sus datos durante el periodo necesario para cumplir los fines para los que estos sean recabados (para obtener más información al respecto, consulte el apartado anterior “¿Cómo utilizamos sus datos?”). Tenga en cuenta que en determinados casos podría requerirse o permitirse por ley un plazo de conservación mayor." ></asp:label>
        </div>
    <br />
    <br />
    <br />
     <div class="row text-center">
        <div class="p-heading-03 panel-heading-light">
             <asp:label ID="Lblcomoprotegemossusdatos" runat="server" font-size="22px" Text="¿CÓMO PROTEGEMOS SUS DATOS?" CssClass="TituloPanel"></asp:label>
         </div>
    </div>

      <br />
    <div class="row">
             <asp:label ID="Lblcomoprotegemossusdatosdescr" runat="server" font-size="18px" text=" Adoptaremos medidas adecuadas para proteger sus datos de conformidad con las leyes y los reglamentos aplicables en materia de seguridad y protección de datos, incluyendo requerir a nuestros proveedores de servicios que usen medidas apropiadas para proteger la confidencialidad y seguridad de sus datos. Adoptaremos medidas técnicas y organizativas para evitar riesgos tales como la destrucción, pérdida, alteración y divulgación no autorizadas de sus datos, así como el acceso no autorizado a los mismos, todo ello en función de las posibilidades técnicas, los costos de implantación y la naturaleza de los datos objeto de protección." ></asp:label>
        </div>

       <br />
</div>


</asp:Content>
