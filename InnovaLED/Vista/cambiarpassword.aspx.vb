Imports System.Web.HttpContext
Imports Entidades
Imports Negocio



Public Class cambiarPassword
    Inherits System.Web.UI.Page

    Private Sub Gestionar_Usuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Session.Timeout = 1

        If Not IsPostBack Then
            Try
                CargarUsuario()


            Catch ex As Exception

            End Try

        End If
    End Sub



    Private Sub CargarUsuario()
        Dim oUsuario As New Entidades.UsuarioEntidad
        oUsuario = DirectCast(Session("cliente"), UsuarioEntidad)
        Me.txtapellido.Text = oUsuario.Apellido
        Me.TxtDNI.Text = oUsuario.DNI
        Me.txtmail.Text = oUsuario.Mail
        Me.txtnombre.Text = oUsuario.Nombre
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim oUsuarioLogueado As New Entidades.UsuarioEntidad
            Dim GestorCliente As New Negocio.UsuarioBLL
            oUsuarioLogueado = DirectCast(Session("cliente"), UsuarioEntidad)
            oUsuarioLogueado.Password = txtpass.Value
            Dim GestorUsu As New UsuarioBLL
            Dim mailingBLL As New Negocio.MailingBLL
            If Not GestorUsu.ExisteUsuario(oUsuarioLogueado) Is Nothing Then
                If Me.newpass1.Value = Me.newpass2.Value Then
                    Dim PassSalt As List(Of String) = Negocio.EncriptarBLL.EncriptarPassword(newpass1.Value)
                    oUsuarioLogueado.Salt = PassSalt.Item(0)
                    oUsuarioLogueado.Password = PassSalt.Item(1)
                    oUsuarioLogueado.Nombre = Me.txtnombre.Text
                    oUsuarioLogueado.Apellido = Me.txtapellido.Text
                    oUsuarioLogueado.DNI = Me.TxtDNI.Text
                    oUsuarioLogueado.Mail = Me.txtmail.Text
                    GestorUsu.ModificarUsuarioLogueado(oUsuarioLogueado)
                    enviarMailCambioContraseñaUsuario(oUsuarioLogueado)

                    Me.div_success.Visible = True
                    Me.alert.Visible = False
                    lbl_success.InnerText = "Se ha modificado el perfil satisfactoriamente."

                Else
                    'no coinciden los passwords
                    Me.div_success.Visible = False
                    Me.alert.Visible = True
                    Me.lbl_textovalid.InnerText = "Las nuevas contraseñas deben coincidir entre sí"
                End If

            End If
        Catch ex As Exception
            'contraseña incorrecta
            Me.div_success.Visible = False
            Me.alert.Visible = True
            Me.lbl_textovalid.InnerText = "Contraseña ingresada incorrecta"

        End Try

        'AssumingDirectControl()
    End Sub


    'Private Sub enviarMailCambioContraseñaUsuario(ByVal usu As UsuarioEntidad)
    '    Dim body As String = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplates/Cambio_Contraseña.html"))
    '    Dim ruta As String = HttpContext.Current.Server.MapPath("Imagenes")
    '    Dim ur As Uri = Request.Url
    '    Negocio.MailingBLL.enviarMailCambioContraseñaUsuario(usu, body, ruta, Replace(ur.AbsoluteUri, ur.AbsolutePath, ""))
    'End Sub

    Public Sub enviarMailCambioContraseñaUsuario(ByVal usu As UsuarioEntidad)
        Try
            Dim ruta As String = HttpContext.Current.Server.MapPath("Imagenes")
            MailingBLL.enviarMailCambioContraseñaUsuario(usu, ruta)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AssumingDirectControl()
        'Current.Session.Remove(Session("cliente"))

        ''this.page.se
        '''cuando haga el restore tiro abajo todas las sesiones por seguridad, incluyendo la que está logueada.
        Current.Session.RemoveAll()
        Current.Session.Abandon()
        Response.Redirect("Default.aspx", False)
    End Sub





End Class