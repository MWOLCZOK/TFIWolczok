<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Institucional.aspx.vb" Inherits="Vista.Institucional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid fondoGris">
     <br />
<div class="row">
  <div class="col-md-12">
     <div class="panel panel-primary class">
       <div class="panel-heading text-center">
         <asp:Label ID="lblPanelModUser" runat="server" Text="¿Quienes Somos?" font-size="24px" CssClass="TituloPanel"></asp:Label>
       </div>
     </div>
  </div>
</div>

<br />
<div class="row">
  <div class="panel panel-info">
      <div class="panel-body">
          <div class="col-md-2 media" style="padding-bottom: 10px">
              <asp:Image ID="LogoMenu" runat="server" ImageUrl="Imagenes/NewEdificio.jpg" CssClass="img-responsive" Height="160px" />
           </div>
           <div class="col-10">
             <asp:Label ID="lblnosotros1"  runat="server" font-size="18px" Text="Somos una empresa joven, que comenzó sus actividades a principios del 2014 gracias a un grupo de jovenes ingenieros dedicados a la mejora de la iluminación y la calidad humana.

Estamos radicados en Argentina y nuestro principal punto de venta es Buenos Aires, Capital Federal.

Nuestro enfoque de la tecnología digital nos permite conectar luces LED a controles, redes, dispositivos y aplicaciones. Ahora, los clientes pueden crear asombrosas experiencias de iluminación y obtener excelentes resultados empresariales ahorrando un 80% de energía en comparación con las bombillas tradicionales."></asp:Label>
           </div>
<br />
<br />
    </div>
  </div>
</div>
    
<div class="row  col-md-4 col-md-offset-2">            
   <div class="panel panel-info">                   
      <div class="panel-heading text-center">
         <div class="panel-heading text-center">
            <asp:Label ID="LblMision" runat="server" font-size="22px" Text="Misión" class="container"></asp:Label>
          </div>
            <asp:Label ID="LblMisionDescripcion" runat="server" font-size="18px" Text="Comercializar soluciones tecnológicas de luminarias LED con productos inteligentes, abarcando el territorio de la ciudad de Buenos Aires, Provincia de Gran Buenos Aires, Córdoba y Santa Fé. Asimismo, tomamos el compromiso con el medio ambiente y la calidad de vida de la gente, proporcionando así productos con la mayor vida útil y ahorro de energía para nuestros clientes. " CssClass="TituloPanel"></asp:Label>
       </div>
    </div>
</div>
                         
                    
<div class="row col-md-offset-1 col-md-4">               
   <div class="panel panel-info">                 
      <div class="panel-heading text-center">
         <div class="panel-heading text-center">
           <asp:Label ID="LblVision" runat="server" font-size="22px" Text="Visión" class="container"></asp:Label>
         </div>
         <asp:Label ID="LblVisionDescripcion" runat="server" font-size="18px" Text="Ser una empresa reconocida por la excelencia de nuestros productos, comprometida con mejorar la calidad de vida, ofreciendo luminarias con tecnología LED de la más alta calidad, propocionando así productos con la mayor vida útil y el mayor ahorro de energía en todo el país." CssClass="TituloPanel"></asp:Label>
        </div>
    </div>
</div>

</div>

</asp:Content>


