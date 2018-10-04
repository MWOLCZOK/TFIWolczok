<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Institucional.aspx.vb" Inherits="Vista.Institucional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="panel panel-info">
                <div class="panel-heading text-center">
                    <asp:Label ID="lblPanelNosotros" runat="server" font-size="20px" Text="¿Quienes somos?" CssClass="TituloPanel"></asp:Label>
                </div>
                <div class="panel-body FondoPanel ">
                    <div class="col-md-2 media" style="padding-bottom: 10px">
                        <asp:Image ID="LogoMenu" runat="server" ImageUrl="Imagenes/NewEdificio.jpg" CssClass="img-responsive" Height="160px" />
                    </div>
                    <div class="col-10">
                        <asp:Label ID="lblnosotros1"  runat="server" font-size="18px" Text="

Somos una empresa joven en el rubro de eficiencia energética en Latinoamérica, con proyección de estar entre los principales líderes de la luminaria LED.

Nuestro objetivo es brindar soluciones integrales y tecnológicas a empresas privadas en PROYECTOS LUMINOTECNICOS especialmente en aquellos enfocados al recambio tecnológico LED en Alumbrado Publico, Industrias, oficinas y residencial. Contamos con la capacidad de ofrecer los proyectos llave en mano ofreciendo materiales eléctricos e instalación

Cobertura geográfica: Contamos con una robusta estructura comercial, administrativa, logística y de soporte por cada región del país, que nos permite trasladar estos servicios a toda la Argentina.
"></asp:Label>
                    </div>
                    <br />
                    <br />

                    <div class="row  col-md-4">               

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
        </div>

                             
                        </div>
             
            
  
</asp:Content>


