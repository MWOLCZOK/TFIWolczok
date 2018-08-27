Imports System.IO
Imports System.Web.HttpContext
Imports System.Environment
Imports System.Net
Imports Negocio





Public Class Login
    Inherits System.Web.UI.Page

    Private GestorUsu As New UsuarioBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim Cliente As New Entidades.UsuarioEntidad
        Dim IdiomaActual As Entidades.IdiomaEntidad
        Dim clienteLogeado As New Entidades.UsuarioEntidad
        If IsNothing(Current.Session("Cliente")) Then
            IdiomaActual = Application("Español")
        Else
            IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
        End If
        Try
            If Page.IsValid = True Then
                Cliente.NombreUsu = txtUsuario.Text
                Cliente.Password = txtPassword.Text
                clienteLogeado = GestorUsu.ExisteUsuario(Cliente)
                Dim Bitac As New BitacoraAuditoria(clienteLogeado, IdiomaActual.Palabras.Find(Function(p) p.Codigo = "BitacoraLoginSuccess1").Traduccion & clienteLogeado.NombreUsu & IdiomaActual.Palabras.Find(Function(p) p.Codigo = "BitacoraLoginSuccess2").Traduccion, Tipo_Bitacora.Login, Now, Request.UserAgent, Request.UserHostAddress, "", "")
                BitacoraBLL.CrearBitacora(Bitac)
                Current.Session("cliente") = clienteLogeado
                Me.success.Visible = True
                Me.alertvalid.Visible = False
                Response.Redirect("~/default.aspx", False)
            Else
                Me.alertvalid.Visible = True
                Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
                Me.success.Visible = False
            End If
        Catch UsuarioBloqueado As Negocio.ExceptionUsuarioBloqueado
            Me.alertvalid.Visible = True
            Me.textovalid.InnerText = UsuarioBloqueado.Mensaje(IdiomaActual)
            Me.success.Visible = False
        Catch UsuarioNoExiste As Negocio.ExceptionUsuarioNoExiste
            Me.alertvalid.Visible = True
            Me.textovalid.InnerText = UsuarioNoExiste.Mensaje(IdiomaActual)
            Me.success.Visible = False
        Catch Password As Negocio.ExceptionPasswordIncorrecta
            Me.alertvalid.Visible = True
            Me.textovalid.InnerText = Password.Mensaje(IdiomaActual)
            Me.success.Visible = False
            Dim Bitac As New BitacoraAuditoria(Cliente, IdiomaActual.Palabras.Find(Function(p) p.Codigo = "BitacoraLoginSuccess1").Traduccion & Cliente.NombreUsu & IdiomaActual.Palabras.Find(Function(p) p.Codigo = "BitacoraLoginSuccess3").Traduccion, Tipo_Bitacora.Login, Now, Request.UserAgent, Request.UserHostAddress, "", "")
            BitacoraBLL.CrearBitacora(Bitac)
        Catch ex As Exception
            Dim Bitac As New Entidades.BitacoraErrores(Cliente, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try
    End Sub




End Class