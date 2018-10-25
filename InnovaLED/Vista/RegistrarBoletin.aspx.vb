Imports System.IO
Imports Negocio
Imports Entidades


Public Class RegistrarBoletin

    Inherits System.Web.UI.Page

    Dim GestorboletinBLL As New BoletinBLL
    Dim GestorEncripBLL As New EncriptarBLL




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtenerTipoBoletin()

        End If
    End Sub

    Private Sub obtenerTipoBoletin()
        Try
            Me.ddl_TipoBoletin.DataSource = System.Enum.GetValues(GetType(Entidades.TipoBoletin))
            Me.ddl_TipoBoletin.DataBind()
        Catch ex As Exception
            Me.alertvalid.Visible = True
            Me.textovalid.InnerText = "Se ha producido un error al realizar la acción, por favor reintente."
            Me.success.Visible = False
        End Try

    End Sub


    Protected Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("Default.aspx")
    End Sub


    Protected Sub validadorSize_ServerValidate(source As Object, args As ServerValidateEventArgs)
        Dim filesize As Double = fu_imagenBoletin.FileContent.Length
        If filesize > 3000000 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If
    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try

            Dim _boletin As New Entidades.BoletinEntidad
            _boletin.Nombre = txt_Nombre.Text
            _boletin.Descripcion = txt_Descripcion.Text
            _boletin.Cuerpo = txt_Cuerpo.Text
            _boletin.TipoBoletin = [Enum].Parse(GetType(Entidades.TipoBoletin), ddl_TipoBoletin.SelectedValue, True)
            If _boletin.TipoBoletin = Entidades.TipoBoletin.Novedad Then
                _boletin.FechaFinVigencia = Me.datepicker.Text
            End If
            'CÓDIGO PARA LA IMAGEN
            Dim PostedFilesCollection As HttpFileCollection = Request.Files
            Dim PostedFile As HttpPostedFile = PostedFilesCollection(0)
            If PostedFile.FileName <> "" Then
                Dim MiDirPath As String = Server.MapPath("~/ImagenesBoletin")
                Me.CrearDirectorio(MiDirPath)
                Dim MiPathAGuardar As String = String.Format("{0}\{1}", MiDirPath, _boletin.Nombre & ".png")
                PostedFile.SaveAs(MiPathAGuardar)
                _boletin.Imagen = "~/ImagenesBoletin/" & _boletin.Nombre & ".png"
            Else
                _boletin.Imagen = ""
            End If

            GestorboletinBLL.Alta(_boletin)
            Me.success.Visible = True
            Me.success.InnerText = "Se ha dado de alta el boletín correctamente."
            Me.alertvalid.Visible = False
        Catch ex As Exception
            Me.alertvalid.Visible = True
            Me.alertvalid.InnerText = "Se ha verificado un error, por favor reintente"
            Me.success.Visible = False
        End Try
    End Sub




    Public Sub CrearDirectorio(ByVal paramPath As String)
        Try
            Dim MiDirectorio As DirectoryInfo = New DirectoryInfo(paramPath)
            If Not MiDirectorio.Exists Then
                MiDirectorio.Create()
            End If
        Catch ex As Exception
            Me.alertvalid.Visible = True
            Me.alertvalid.InnerText = "Se ha verificado un error, por favor reintente"
            Me.success.Visible = False
        End Try

    End Sub




    Protected Sub ddl_TipoBoletin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_TipoBoletin.SelectedIndexChanged
        If Me.ddl_TipoBoletin.SelectedItem.ToString = Entidades.TipoBoletin.Novedad.ToString Then
            Me.fechaFinVigencia.Visible = True
        Else
            Me.fechaFinVigencia.Visible = False
        End If
    End Sub



End Class