Imports Negocio
Imports Entidades
Imports System.Web.HttpContext





Public Class GestionarEncuestas
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarDrop()
            CargarEncuestas()
            cargarPreguntasEncuesta()
            cargarPreguntasFichaOpinion()
            Session("RespuestasSeleccionadas") = New List(Of RespuestaEncuestaEntidad)
            btn_buscar_Click(Nothing, Nothing)
        Else

        End If

    End Sub

    Dim encuestaBLL As New GestorPreguntaOpinionBLL

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            If ValidarCampos() Then
                Dim GestorpreguntaBLL As New GestorPreguntaOpinionBLL
                Dim pregunta As New PreguntaOpinionEntidad
                pregunta.Enunciado = txt_Nombrepregunta.Text
                pregunta.TipoPregunta = [Enum].Parse(GetType(Entidades.TipoPregunta), ddl_tipopregunta.SelectedValue, True)
                pregunta.FechaFinVigencia = datepicker.Text
                pregunta.PosiblesRespuestas = Session("RespuestasSeleccionadas")
                If pregunta.PosiblesRespuestas.Count >= 2 Then
                    GestorpreguntaBLL.Alta(pregunta)
                    Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                    Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & " dio de alta la encuesta " & pregunta.Enunciado, Tipo_Bitacora.Alta, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    BitacoraBLL.CrearBitacora(Bitac)
                    Me.success.InnerText = "Se agregó la encuesta correctamente."
                    Me.success.Visible = True
                    Me.alertvalid.Visible = False
                Else
                    Me.alertvalid.Visible = True
                    Me.success.Visible = False
                    Me.alertvalid.InnerText = "Ingrese más de dos respuestas para continuar."
                End If
            Else
                    Me.alertvalid.Visible = True
                    Me.success.Visible = False
                Me.alertvalid.InnerText = "Complete todos los campos para continuar."
            End If

        Catch ex As Exception
        End Try
        CargarEncuestas()
        LimpiarControles()
        cargarPreguntasFichaOpinion()
        cargarPreguntasEncuesta()
    End Sub

    Public Function ValidarCampos() As Boolean
        If txt_Nombrepregunta.Text = "" Or datepicker.Text = "" Then
            Return False ' si alguno está vacio, devuelvo false
        Else
            Return True ' si está completo devuelve true
        End If

    End Function

    Public Sub LimpiarControles()
        Session("RespuestasSeleccionadas") = New List(Of RespuestaEncuestaEntidad)
        gv_respuestas.DataSource = Nothing
        gv_respuestas.DataBind()
        ddl_tipopregunta.ClearSelection()
        txt_Nombrepregunta.Text = ""
        datepicker.Text = ""
        txt_rtas.Text = ""
    End Sub



    Private Sub gv_Encuestas_DataBound(sender As Object, e As EventArgs) Handles gv_Encuestas.DataBound
        Try

            Try
                Dim ddl2 As DropDownList = CType(gv_Encuestas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Catch ex As Exception
                Return
            End Try

            Dim ddl As DropDownList = CType(gv_Encuestas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            Dim ddlpage As DropDownList = CType(gv_Encuestas.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            Dim txttotal As Label = CType(gv_Encuestas.BottomPagerRow.Cells(0).FindControl("lbltotalpages"), Label)

            ddlpage.ClearSelection()
            ddlpage.Items.FindByValue(gv_Encuestas.PageSize).Selected = True

            txttotal.Text = gv_Encuestas.PageCount

            For cnt As Integer = 0 To gv_Encuestas.PageCount - 1
                Dim curr As Integer = cnt + 1
                Dim item As New ListItem(curr.ToString())
                If cnt = gv_Encuestas.PageIndex Then
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
            For Each row As GridViewRow In gv_Encuestas.Rows
                Dim imagen3 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_editar"), System.Web.UI.WebControls.ImageButton)

                imagen3.CommandArgument = row.RowIndex


                If row.Cells(4).Text = "False" Then

                Else

                End If
                If row.Cells(5).Text = "False" Then

                    imagen3.Visible = False
                Else

                End If
            Next

            With gv_Encuestas.HeaderRow

            End With

            gv_Encuestas.BottomPagerRow.Visible = True
            gv_Encuestas.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gv_Respuestas_DataBound(sender As Object, e As EventArgs) Handles gv_respuestas.DataBound
        Try


            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            For Each row As GridViewRow In gv_respuestas.Rows
                Dim imagen1 As System.Web.UI.WebControls.ImageButton = DirectCast(row.FindControl("btn_Respuestas"), System.Web.UI.WebControls.ImageButton)

                imagen1.CommandArgument = row.RowIndex
            Next

            With gv_respuestas.HeaderRow

            End With

            gv_respuestas.BottomPagerRow.Visible = True
            gv_respuestas.BottomPagerRow.CssClass = "table-bottom-dark"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ModificarBoletin_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            If Not IsNothing(gv_Encuestas.HeaderRow) Then
                gv_Encuestas.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
        Catch ex As Exception

        End Try
    End Sub




    Private Sub gv_Encuestas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_Encuestas.RowCommand
        'Funcion para que luego de clickear en el Grid lo pase a los textbox
        Try

            Dim _pregunta As PreguntaOpinionEntidad = TryCast(Session("Preguntas"), List(Of PreguntaOpinionEntidad))(e.CommandArgument + (gv_Encuestas.PageIndex * gv_Encuestas.PageSize))
            Me.ID_encuesta.Value = e.CommandArgument
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            Select Case e.CommandName.ToString
                Case "E"
                    btn_agregar.Visible = False
                    btn_nuevo.Visible = True
                    btn_modificar.Visible = True
                    btn_confirmar.Visible = True
                    txt_Nombrepregunta.Text = _pregunta.Enunciado
                    datepicker.Text = _pregunta.FechaFinVigencia
                    ddl_tipopregunta.SelectedIndex = _pregunta.TipoPregunta - 1
                    Session("RespuestasSeleccionadas") = _pregunta.PosiblesRespuestas
                    gv_respuestas.DataSource = Nothing
                    gv_respuestas.DataSource = Session("RespuestasSeleccionadas")
                    gv_respuestas.DataBind()
            End Select
        Catch ex As Exception
        End Try

    End Sub

    Private Sub gv_Respuestas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv_respuestas.RowCommand

        Try
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            Dim RespuestaSeleccionada As RespuestaEncuestaEntidad = TryCast(Session("RespuestasSeleccionadas"), List(Of RespuestaEncuestaEntidad))(e.CommandArgument)

            Select Case e.CommandName.ToString
                Case "S"
                    TryCast(Session("RespuestasSeleccionadas"), List(Of Entidades.RespuestaEncuestaEntidad)).Remove(RespuestaSeleccionada)
                    gv_respuestas.DataSource = Nothing
                    gv_respuestas.DataSource = Session("RespuestasSeleccionadas")
                    gv_respuestas.DataBind()
            End Select
        Catch ex As Exception

        End Try
    End Sub



    Public Sub Ocultamiento()
        'btn_confirmar.Visible = False
        btn_modificar.Visible = False
        btn_agregar.Visible = True
        btn_nuevo.Visible = False
    End Sub


    Protected Sub gv_Newsletter_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarEncuestas()
            gv_Encuestas.PageIndex = e.NewPageIndex
            gv_Encuestas.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub ddlPaging_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Encuestas.BottomPagerRow.Cells(0).FindControl("ddlPaging"), DropDownList)
            gv_Encuestas.SetPageIndex(ddl.SelectedIndex)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlPageSize_SelectedPageSizeChanged(sender As Object, e As EventArgs)
        Try
            Dim ddl As DropDownList = CType(gv_Encuestas.BottomPagerRow.Cells(0).FindControl("ddlPageSize"), DropDownList)
            gv_Encuestas.PageSize = ddl.SelectedValue
            CargarEncuestas()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gv_Encuestas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Try
            CargarEncuestas()
            gv_Encuestas.PageIndex = e.NewPageIndex
            gv_Encuestas.DataBind()
        Catch ex As Exception

        End Try

    End Sub



    Public Sub CargarEncuestas()
        Dim _listapreguntas As List(Of PreguntaOpinionEntidad)
        _listapreguntas = encuestaBLL.TraerTodasLasPreguntas()
        If _listapreguntas.Count > 0 Then
            Session("Preguntas") = _listapreguntas
            Me.gv_Encuestas.DataSource = _listapreguntas
            Me.gv_Encuestas.DataBind()
        Else
        End If


    End Sub

    Public Sub CargarDrop()
        ddl_tipopregunta.DataSource = System.Enum.GetValues(GetType(TipoPregunta))
        ddl_tipopregunta.DataBind()
    End Sub


    Public Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Try

            Dim _pregunta As PreguntaOpinionEntidad = TryCast(Session("Preguntas"), List(Of PreguntaOpinionEntidad))(Me.ID_encuesta.Value + (gv_Encuestas.PageIndex * gv_Encuestas.PageSize))
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            encuestaBLL.Eliminar(_pregunta)
            Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
            Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & " elimino la encuesta " & _pregunta.Enunciado, Tipo_Bitacora.Baja, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
            BitacoraBLL.CrearBitacora(Bitac)
            Me.success.InnerText = "Se agregó la encuesta correctamente."
            Me.success.InnerText = "Se eliminó la encuesta correctamente."
            Me.success.Visible = True
            Me.alertvalid.Visible = False

        Catch ex As Exception
        End Try
        CargarDrop()
        CargarEncuestas()
        LimpiarControles()
        Ocultamiento()
        cargarPreguntasFichaOpinion()
        cargarPreguntasEncuesta()

    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Try
            Dim GestorpreguntaBLL As New GestorPreguntaOpinionBLL
            Dim _pregunta As PreguntaOpinionEntidad = TryCast(Session("Preguntas"), List(Of PreguntaOpinionEntidad))(Me.ID_encuesta.Value + (gv_Encuestas.PageIndex * gv_Encuestas.PageSize))
            '(Me.id_producto.Value + (gv_Productos.PageIndex * gv_Productos.PageSize)) esto es igual a la posición elegida +(el numero de pagina * la paginación que le puse) eso me devuelve el ID a eliminar, porque el que selecciono desde la grilla no es el ID sino la posicion.
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If

            _pregunta.Enunciado = txt_Nombrepregunta.Text
            _pregunta.TipoPregunta = [Enum].Parse(GetType(Entidades.TipoPregunta), ddl_tipopregunta.SelectedValue, True)
            _pregunta.FechaFinVigencia = datepicker.Text
            _pregunta.FechaAlta = Now
            _pregunta.PosiblesRespuestas = Session("RespuestasSeleccionadas")
            If _pregunta.PosiblesRespuestas.Count >= 2 Then

                If ValidarCampos() Then
                    GestorpreguntaBLL.Modificar(_pregunta)
                    Dim clienteLogeado As Entidades.UsuarioEntidad = Current.Session("cliente")
                    Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & " modificó la encuesta " & _pregunta.Enunciado, Tipo_Bitacora.Modificacion, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    BitacoraBLL.CrearBitacora(Bitac)
                    Me.success.InnerText = "Se Modificó la encuesta correctamente."
                    Me.alertvalid.Visible = False
                    Me.success.Visible = True
                    Ocultamiento()

                Else
                    Me.alertvalid.InnerText = "Complete todos los campos para continuar."
                    Me.alertvalid.Visible = True
                    Me.success.Visible = False
                End If
            Else
                Me.alertvalid.Visible = True
                Me.success.Visible = False
                Me.alertvalid.InnerText = "Ingrese más de dos respuestas para continuar."
            End If

        Catch ex As Exception
        End Try
        CargarEncuestas()
        cargarPreguntasFichaOpinion()
        cargarPreguntasEncuesta()
        LimpiarControles()
        CargarDrop()
    End Sub

    Protected Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        btn_confirmar.Visible = False
        btn_nuevo.Visible = False
        btn_agregar.Visible = True
        btn_modificar.Visible = False
        LimpiarControles()
    End Sub

    'CÓDIGO PARA REPORTE DE ENCUESTAS 

    Private Sub generarGrafico(ByVal respuestas As List(Of RespuestaEntidad), ByVal tipo As TipoPregunta)
        Try
            Dim script As String
            If tipo = TipoPregunta.Encuesta Then
                script = " $(document).ready(function () {
                 var ctx = document.getElementById(""chart-area"").getContext(""2d"");   
                    var pieData = [ "
            Else
                script = " $(document).ready(function () {
                 var ctx = document.getElementById(""chart-area2"").getContext(""2d"");   
                    var pieData = [ "
            End If

            Dim listaauxilar As New List(Of RespuestaEncuestaEntidad)
            For Each respuesta In respuestas
                If Not listaauxilar.Any(Function(p) p.ID = respuesta.RespuestaEncuesta.ID) Then
                    System.Threading.Thread.Sleep(50)
                    Dim color As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
                    System.Threading.Thread.Sleep(50)
                    Dim colorh As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
                    script += "{ value: " & respuestas.Where(Function(p) p.RespuestaEncuesta.ID = respuesta.RespuestaEncuesta.ID).Count() & ","
                    script += " color: " + """" + color + ""","
                    script += " highlight: " + """" + colorh + ""","
                    script += " label: """ + respuesta.RespuestaEncuesta.Descripcion + """},"
                    listaauxilar.Add(respuesta.RespuestaEncuesta)
                End If
            Next
            script +=
                  "  ];
                    window.myPie = new Chart(ctx).Pie(pieData);
                 }); "
            If tipo = TipoPregunta.Encuesta Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "encuestas", script, True)
            Else
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "opiniones", script, True)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            CargarGraficos()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub cargarPreguntasEncuesta()
        Try
            Dim _listapreguntas As List(Of PreguntaOpinionEntidad)
            _listapreguntas = encuestaBLL.TraerTodasPreguntasGraficos(TipoPregunta.Encuesta)
            If _listapreguntas.Count > 0 Then
                Session("EncuestasGraficos") = _listapreguntas
                Me.encuestas.DataSource = _listapreguntas
                Me.encuestas.DataBind()
            Else
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cargarPreguntasFichaOpinion()
        Try
            Dim _listapreguntas As List(Of PreguntaOpinionEntidad)
            _listapreguntas = encuestaBLL.TraerTodasPreguntasGraficos(TipoPregunta.Opinion)
            If _listapreguntas.Count > 0 Then
                'Session("EncuestasGraficos") = _listapreguntas
                Me.opinion.DataSource = _listapreguntas
                Me.opinion.DataBind()
            Else
            End If

        Catch ex As Exception
        End Try

    End Sub



    Protected Sub btn_agregarrta_Click(sender As Object, e As EventArgs) Handles btn_agregarrta.Click
        Try
            Dim Nuevarta As New RespuestaEncuestaEntidad
            Nuevarta.Descripcion = txt_rtas.Text
            TryCast(Session("RespuestasSeleccionadas"), List(Of Entidades.RespuestaEncuestaEntidad)).Add(Nuevarta)
            gv_respuestas.DataSource = Nothing
            gv_respuestas.DataSource = Session("RespuestasSeleccionadas")
            gv_respuestas.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_buscaropinion_Click(sender As Object, e As EventArgs) Handles btn_buscaropinion.Click
        Try
            CargarGraficos()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CargarGraficos()
        Dim gestorpregunta As New GestorPreguntaOpinionBLL
        generarGrafico(gestorpregunta.obtenerRespuestasGrafico(gestorpregunta.obtenerPreguntas(New PreguntaOpinionEntidad With {.ID = opinion.SelectedValue})), TipoPregunta.Opinion)
        generarGrafico(gestorpregunta.obtenerRespuestasGrafico(gestorpregunta.obtenerPreguntas(New PreguntaOpinionEntidad With {.ID = encuestas.SelectedValue})), TipoPregunta.Encuesta)
    End Sub
End Class