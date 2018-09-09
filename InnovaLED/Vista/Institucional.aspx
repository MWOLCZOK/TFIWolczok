<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Institucional.aspx.vb" Inherits="Vista.Institucional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="panel panel-info">
                <div class="panel-heading text-center">
                    <asp:Label ID="lblPanelNosotros" runat="server" Text="¿Quienes somos?" CssClass="TituloPanel"></asp:Label>
                </div>
                <div class="panel-body FondoPanel ">
                    <div class="col-md-2 media" style="padding-bottom: 10px">
                        <asp:Image ID="LogoMenu" runat="server" ImageUrl="Imagenes/edificio.jpg" CssClass="img-responsive" Height="160px" />
                    </div>
                    <div class="col-md-10">
                        <asp:Label ID="lblnosotros1"  runat="server" Text="

Somos una empresa joven en el rubro de eficiencia energética en Latinoamérica, con proyección de estar entre los principales líderes de la luminaria LED.

Nuestro objetivo es brindar soluciones integrales y tecnológicas a empresas privadas en PROYECTOS LUMINOTECNICOS especialmente en aquellos enfocados al recambio tecnológico LED en Alumbrado Publico, Industrias, oficinas y residencial. Contamos con la capacidad de ofrecer los proyectos llave en mano ofreciendo materiales eléctricos e instalación

Cobertura geográfica: Contamos con una robusta estructura comercial, administrativa, logística y de soporte por cada región del país, que nos permite trasladar estos servicios a toda la Argentina.
"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


