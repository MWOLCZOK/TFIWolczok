Imports System.Web.HttpContext
Imports Entidades
Imports Negocio



Public Class cambiarPassword
    Inherits System.Web.UI.Page

    Private Sub Gestionar_Usuario_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            oUsuarioLogueado = DirectCast(Session("cliente"), UsuarioEntidad)
            oUsuarioLogueado.Password = txtpass.Value
            Dim GestorUsu As New UsuarioBLL
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
                    Me.div_success.Visible = True
                    Me.alert.Visible = False
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


    End Sub
End Class