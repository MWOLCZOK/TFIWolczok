Imports System.IO
Imports System.Web.HttpContext
Imports Entidades
Public Class Restore
    Inherits System.Web.UI.Page
    Private nombreArchivo As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                CargarBackups()
            Catch ex As Exception


            End Try

        End If
    End Sub
    Private Sub CargarBackups()
        Dim Directory As New DirectoryInfo(System.Web.Configuration.WebConfigurationManager.AppSettings("RutaBackup").ToString())
        Dim fileinf As FileInfo() = Directory.GetFiles()
        Me.Backups.Items.Clear()

        For Each fri As FileInfo In fileinf
            If fri.Extension = ".bak" Then
                Dim item As New ListItem
                item.Text = fri.Name
                item.Value = fri.FullName
                Me.Backups.Items.Add(item)
            End If

        Next fri
    End Sub

    Protected Sub btnserver_Click(sender As Object, e As EventArgs) Handles btnserver.Click
        Dim gestorBK As New Negocio.BackupRestoreBLL
        Dim bkre = New Entidades.BackupRestoreEntidad("")
        bkre.Nombre = Me.Backups.SelectedValue

        Restore(bkre, True)
        AssumingDirectControl()
    End Sub
    Private Sub Restore(ByRef Bkre As Entidades.BackupRestoreEntidad, ByVal Servidor As Boolean)
        Try
            Dim gestorBK As New Negocio.BackupRestoreBLL
            Dim nombreArchivo As String = "BKP_from_Restore_InnovaLED_" & Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & ";" & Now.Minute & ";" & Now.Second
            Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")


            If gestorBK.RealizarRestore(Bkre) Then
                Dim IdiomaActual As Entidades.IdiomaEntidad
                If IsNothing(Current.Session("Cliente")) Then
                    IdiomaActual = Application("Español")
                Else
                    IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
                End If

                Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & " Realizó un restore de manera satisfactoria", Tipo_Bitacora.Restore, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)

                Negocio.BitacoraBLL.CrearBitacora(Bitac)
                Me.success.Visible = True
                Me.alertvalid.Visible = False
            End If
            If Servidor Then

            Else
                System.IO.File.Delete((System.Web.Configuration.WebConfigurationManager.AppSettings("RutaBackup").ToString() & "\restoreUpload"))
            End If
            AssumingDirectControl()
        Catch ex As Exception
            'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            'Dim Bitac As New Entidades.BitacoraErrores(clienteLogeado, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            'Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try

    End Sub

    Private Sub AssumingDirectControl()
        'cuando haga el restore tiro abajo todas las sesiones por seguridad, incluyendo la que está logueada.
        Current.Session.RemoveAll()
        Current.Session.Abandon()
        Response.Redirect("Default.aspx", False)
    End Sub

    Protected Sub btnlocal_Click(sender As Object, e As EventArgs) Handles btnlocal.Click
        FileUpload1.SaveAs(System.Web.Configuration.WebConfigurationManager.AppSettings("RutaBackup").ToString() & "\restoreUpload")

        Dim bkre = New Entidades.BackupRestoreEntidad("")
        bkre.Nombre = System.Web.Configuration.WebConfigurationManager.AppSettings("RutaBackup").ToString() & "\restoreUpload"
        Restore(bkre, False)
    End Sub

    Protected Sub hacerBackup(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            Dim gestorBK As New Negocio.BackupRestoreBLL
            nombreArchivo = "BKP_InnovaLED_" & Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & ";" & Now.Minute & ";" & Now.Second
            If gestorBK.CrearBackup("", nombreArchivo, Current.Session("cliente")) Then

                Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")

                Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & " Realizó un Backup de manera satisfactoria", Tipo_Bitacora.Backup, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                Negocio.BitacoraBLL.CrearBitacora(Bitac)
            End If
            ofrecerDownloadAlUsuario()
             CargarBackups()
        Catch ex As Exception
            'Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            'Dim Bitac As New Entidades.BitacoraErrores(clienteLogeado, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            'Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try

    End Sub
    Protected Sub ofrecerDownloadAlUsuario()
        Response.ContentType = "application/octet-stream"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & nombreArchivo + ".bak")
        Response.WriteFile(System.Web.Configuration.WebConfigurationManager.AppSettings("RutaBackup").ToString() + "/" + nombreArchivo + ".bak")
        Response.Flush()
    End Sub




End Class