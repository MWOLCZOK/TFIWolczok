Imports System.IO
Imports Negocio
Imports Entidades
Imports System.Web.HttpContext



Public Class RegistrarBoletin

    Inherits System.Web.UI.Page

    Dim GestorboletinBLL As New BoletinBLL
    Dim GestorEncripBLL As New EncriptarBLL




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            obtenerTipoBoletin()
            CargarBoletin()

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
                _boletin.FechaFinVigencia = Me.datepicker.Text ' esto está así porque las novedades vencen, las otras no, entonces en el mapper, no inserta la fecha.
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





    Private Sub gv_Newsletter_DataBound(sender As Object, e As EventArgs) Handles gv_Newsletter.DataBound
        Try

            Try
                Dim ddl2 As DropDownList = CType(gv_Newsletter.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_Newsletter.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_Newsletter.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_Newsletter.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_Newsletter.PageSize).Selected = True

            txttotal.Text = gv_Newsletter.PageCount

            For cnt As Integer = 0 To gv_Newsletter.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Newsletter.PageIndex Then
                    item.Selected = True
                End If

                ddl.Items.Add(item)

            Next cnt
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            For Each row As GridViewRow In gv_Newsletter.Rows
                Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Bloquear"), System.Web.UI.WebControls.ImageButton)
                Dim imagen2 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_desbloqueo"), System.Web.UI.WebControls.ImageButton)
                Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_editar"), System.Web.UI.WebControls.ImageButton)

                imagen1.CommandArgument = row.RowIndex
                imagen2.CommandArgument = row.RowIndex
                imagen3.CommandArgument = row.RowIndex


                If row.Cells(4).Text = "False" Then
                    'row.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjNoBloqueado").Traduccion
                Else
                    'row.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjBloqueado").Traduccion
                End If
                If row.Cells(5).Text = "False" Then
                    'row.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjNo").Traduccion
                    imagen3.Visible = False
                Else
                    'row.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "MsjSi").Traduccion
                End If
            Next

            With gv_Newsletter.HeaderRow
                '.Cells(0).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderID").Traduccion
                '.Cells(1).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderNombreUsuario").Traduccion
                '.Cells(2).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderIdioma").Traduccion
                '.Cells(3).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderBloqueo").Traduccion
                '.Cells(4).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderEmpleado").Traduccion
                '.Cells(5).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderFechaAlta").Traduccion
                '.Cells(6).Text = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "HeaderAcciones").Traduccion
            End With

            gv_Newsletter.BottomPagerRow.Visible = True
            gv_Newsletter.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_Usuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_Newsletter.RowCommand
        'Funcion para que luego de clickear en el Grid lo pase a los textbox
        Try

            Dim boletinBLL As New Negocio.BoletinBLL
            Dim Boletin As Entidades.BoletinEntidad = TryCast(Session("Boletin"), List(Of Entidades.BoletinEntidad))(e.CommandArgument + (gv_Newsletter.PageIndex * gv_Newsletter.PageSize))
            Me.id_newsletter.Value = e.CommandArgument
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Select Case e.CommandName.ToString
                Case "E"
                    'txtusuario.Text = Usuario.NombreUsu
                    'txtapellido.Text = Usuario.Apellido
                    'txtnombre.Text = Usuario.Nombre
                    'txtnomusuario.Text = Usuario.NombreUsu
                    'TxtDNI.Text = Usuario.DNI
                    'txtmail.Text = Usuario.Mail



            End Select
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub gv_Newsletter_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarBoletin()
            gv_Newsletter.PageIndex = e.NewPageIndex
            gv_Newsletter.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Newsletter.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Newsletter.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Newsletter.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_Newsletter.PageSize = ddl.SelectedValue
            CargarBoletin()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarBoletin()
        Dim _listaBoletin As List(Of BoletinEntidad)
        _listaBoletin = GestorboletinBLL.ObtenerBoletinNovedad()
        Me.gv_Newsletter.DataSource = _listaBoletin
        Me.gv_Newsletter.DataBind()

    End Sub



End Class