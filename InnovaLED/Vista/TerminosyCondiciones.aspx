<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="TerminosyCondiciones.aspx.vb" Inherits="Vista.TerminosyCondiciones" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris" >
        <br />
   

<div class="row">
  <div class="col-md-12">
     <div class="panel panel-primary class">
       <div class="panel-heading text-center">
         <asp:Label ID="lblPanelModUser" runat="server" Text="Terminos y Condiciones" font-size="24px" CssClass="TituloPanel"></asp:Label>
       </div>
     </div>
   </div>
  </div>

<br />
<br />

<div class="panel-body">
    
<div class="row text-left">
   <div class="p-heading-03 panel-heading-light">
       <asp:label ID="Lbl_Aceptacion" runat="server" font-size="22px" Text="1.Aceptación de las Condiciones de Uso" CssClass="TituloPanel"></asp:label>
   </div>
</div>    
<br />
<div class="row">
  <asp:label ID="Lbl_Aceptacion_Desc" runat="server" font-size="18px" text="Al acceder a este Sitio Web o usarlo acepta vincularse legalmente con las Condiciones de Uso y todos los términos y condiciones incluidos en este documento o a los que se haga referencia en él, además de con cualquier otro término y condición que se establezca en este Sitio Web. Si NO está de acuerdo con todas estas condiciones, NO debe acceder a este Sitio Web ni utilizarlo." ></asp:label>
</div>
<br />
<br />
<br />
<div class="row text-left">
   <div class="p-heading-03 panel-heading-light">
       <asp:label ID="Lbl_Modificacion_Cond" runat="server" font-size="22px" Text="2.Modificación de las condiciones" CssClass="TituloPanel"></asp:label>
   </div>
</div>    
<br />
<div class="row">
  <asp:label ID="Lbl_Modificacion_Cond_Desc" runat="server" font-size="18px" text="Innova LED podrá modificar estas Condiciones de Uso en cualquier momento. Las condiciones de uso modificadas empezarán a estar vigentes en el momento de su publicación. Si continúa accediendo al Sitio Web o utilizándolo después de la publicación de las condiciones modificadas, se dará por supuesto que las acepta. Innova LED le recomienda que revise con regularidad todos los términos y condiciones aplicables.

Innova LED se reserva el derecho de suspender, modificar o actualizar el Sitio Web o el Contenido del Sitio Web en cualquier momento sin previo aviso. Asimismo se detalla que se reserva el derecho de restringir, rechazar o terminar el acceso de cualquier persona al Sitio Web o a cualquier parte de él con efecto inmediato y sin previo aviso, en cualquier momento y por cualquier motivo, a su entera discreción." ></asp:label>
</div>
<br />
<br />
<br />
<div class="row text-left">
   <div class="p-heading-03 panel-heading-light">
       <asp:label ID="Lbl_Politica" runat="server" font-size="22px" Text="3.Política de privacidad" CssClass="TituloPanel"></asp:label>
   </div>
</div>    
<br />
<div class="row">
  <asp:label ID="Lbl_Politica_Desc" runat="server" font-size="18px" text="La información personal que nos proporcione o se recopile a través de este Sitio Web se utilizará únicamente de acuerdo con la política de privacidad de Philips Lighting y las presentes Condiciones de Uso están sujetas a la política de privacidad publicada en este Sitio Web." ></asp:label>
</div>
<br />
<br />
<br />
<div class="row text-left">
   <div class="p-heading-03 panel-heading-light">
       <asp:label ID="Lbl_Registro" runat="server" font-size="22px" Text="4.Registro" CssClass="TituloPanel"></asp:label>
   </div>
</div>    
<br />
<div class="row">
  <asp:label ID="Lbl_Registro_Desc" runat="server" font-size="18px" text="El acceso a ciertas áreas del Sitio Web y el uso de determinadas funciones o características de este pueden requerir el registro como usuario. Dicho registro es totalmente gratuito. 
Cuando se registre, debe elegir un identificador o nombre de usuario único y una contraseña. También debe indicar una dirección de correo electrónico exclusiva, válida, actual y comprobable. No se permiten nombres de usuario y direcciones de correo electrónico duplicados. Por este motivo, si el nombre o la dirección indicados ya están en uso, se le pedirá que elija otros. Le enviaremos un mensaje de correo electrónico de confirmación con la información del registro. Si por algún motivo no se pudiese entregar la información, podrían rechazarse o quedar interrumpidos el acceso y el uso de áreas, funciones o características que requieran dicho registro. Deberá actualizar o corregir inmediatamente los datos del registro. Usted es el único responsable de mantener la confidencialidad de su contraseña. Por nuestra parte, nos reservamos el derecho de cambiar el nombre de usuario o eliminar el Contenido que haya enviado al Sitio Web, o incluso rechazar o cancelar su registro, si elige un nombre de usuario que, a nuestra entera discreción, consideremos obsceno, indecente, abusivo o inapropiado por algún otro motivo. Usted es también el único responsable de restringir el acceso a sus equipos. Acepta su condición de responsable de todas las actividades que tengan lugar con su cuenta, nombre de usuario o contraseña debido a su conducta, pasividad o negligencia. Si llegase a ser consciente de cualquier conducta sospechosa o no autorizada con su cuenta, nombre de usuario y/o contraseña, acepta ponerse en contacto con Innova LED inmediatamente por correo electrónico a soporte@innovaled.com. Podemos, según nuestro propio criterio, impedir los registros procedentes de cualquier servicio de correo electrónico o ISP." ></asp:label>
</div>
<br />
<br />
<br />
<div class="row">
  <asp:label ID="Lbl_actualizacion" runat="server" font-size="18px" text="Gracias por registrarse en nuestro sitio web." ></asp:label>
  <br />
  <br />
  <asp:label ID="Lbl_actualizacion2" runat="server" font-size="18px"  text="Ultima actualizacion: Septiembre de 2018" ></asp:label>
</div>
<br />
<br />
<br /> 
      
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
</div>
</div>  
                                 

   
  
   
</asp:Content>
