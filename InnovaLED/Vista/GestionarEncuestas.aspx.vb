Imports Negocio
Imports Entidades
Imports System.Web.HttpContext





Public Class GestionarEncuestas
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CargarDrop()
            CargarEncuestas() ' Carga encuestas para el Grid del ABM
            obtenerPreguntasOpinion() ' Gráfico Torta Encuesta - Gráfico 1
            cargarDDLAno() ' Carga DropDown de año
            obtenerPreguntasEncuesta()
            obtenerSeleccionado() ' Gráfico Torta Ficha Opinion -Gráfico 2
            Session("RespuestasSeleccionadas") = New List(Of RespuestaEncuestaEntidad)
        Else


        End If

    End Sub

    Dim encuestaBLL As New GestorPreguntaOpinionBLL

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            Dim GestorpreguntaBLL As New GestorPreguntaOpinionBLL
            Dim pregunta As New PreguntaOpinionEntidad
            pregunta.Enunciado = txt_Nombrepregunta.Text
            pregunta.TipoPregunta = [Enum].Parse(GetType(Entidades.TipoPregunta), ddl_tipopregunta.SelectedValue, True)
            pregunta.FechaFinVigencia = datepicker.Text
            pregunta.PosiblesRespuestas = Session("RespuestasSeleccionadas")
            GestorpreguntaBLL.Alta(pregunta)
            Me.success.InnerText = "Se agregó la encuesta correctamente."
            Me.success.Visible = True
            Me.alertvalid.Visible = False
        Catch ex As Exception
        End Try
        CargarEncuestas()
        LimpiarControles()
    End Sub

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
                    btn_modificar.Visible = True
                    btn_eliminarPregunta.Visible = True
                    txt_Nombrepregunta.Text = _pregunta.Enunciado
                    datepicker.Text = _pregunta.FechaFinVigencia
                    ddl_tipopregunta.ClearSelection()
                    Session("RespuestasSeleccionadas") = _pregunta.PosiblesRespuestas
                    gv_respuestas.DataSource = Nothing
                    gv_respuestas.DataSource = Session("RespuestasSeleccionadas")
                    gv_respuestas.DataBind()
            End Select
        Catch ex As Exception
        End Try
        'Ocultamiento()
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
        btn_eliminarPregunta.Visible = False
        btn_modificar.Visible = False
        btn_agregar.Visible = True
        'btn_nuevo.Visible = True
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


    Protected Sub btn_eliminarPregunta_Click(sender As Object, e As EventArgs) Handles btn_eliminarPregunta.Click
        Try
            'Dim _pregunta As PreguntaOpinionEntidad = TryCast(Session("Preguntas"), List(Of PreguntaOpinionEntidad))(Me.ID_encuesta.Value + (gv_Encuestas.PageIndex * gv_Encuestas.PageSize))
            Dim _pregunta As PreguntaOpinionEntidad = TryCast(Session("Preguntas"), List(Of PreguntaOpinionEntidad))(Me.ID_encuesta.Value + (gv_Encuestas.PageIndex * gv_Encuestas.PageSize))

            '(Me.id_producto.Value + (gv_Productos.PageIndex * gv_Productos.PageSize)) esto es igual a la posición elegida +(el numero de pagina * la paginación que le puse) eso me devuelve el ID a eliminar, porque el que selecciono desde la grilla no es el ID sino la posicion.
            Dim IdiomaActual As Entidades.IdiomaEntidad
            If IsNothing(Current.Session("Cliente")) Then
                IdiomaActual = Application("Español")
            Else
                IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
            End If
            encuestaBLL.Eliminar(_pregunta)
            Me.success.InnerText = "Se eliminó la encuesta correctamente."
            Me.success.Visible = True
            Me.alertvalid.Visible = False

        Catch ex As Exception
        End Try
        CargarDrop()
        CargarEncuestas()
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
            GestorpreguntaBLL.Modificar(_pregunta)
            Me.success.InnerText = "Se Modificó la encuesta correctamente."
            Me.alertvalid.Visible = False
        Catch ex As Exception
        End Try
        CargarEncuestas()
    End Sub

    Protected Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        btn_eliminarPregunta.Visible = False
        btn_nuevo.Visible = False
        btn_agregar.Visible = True
        btn_modificar.Visible = False
        LimpiarControles()
    End Sub



    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_tipopregunta.SelectedIndexChanged

        'If ddl_tipopregunta.SelectedItem.ToString = TipoPregunta.Encuesta.ToString Then
        '    Me.Div_Encuesta.Visible = True
        '    Me.Div_Opinion.Visible = False
        'Else
        '    Me.Div_Opinion.Visible = True
        '    Me.Div_Encuesta.Visible = False
        'End If
    End Sub

    'CÓDIGO PARA REPORTE DE ENCUESTAS 

    Private Sub obtenerPreguntasOpinion(ByVal paramMes As Integer, ByVal paramAno As Integer)
        'Try
        '    Dim _satisfecho As Integer = 0
        '    Dim _insatisfecho As Integer = 0
        '    Dim _listaPreguntaOpinion As List(Of PreguntaOpinionEntidad) = encuestaBLL.TraerTodasLasPreguntas
        '    For Each _preguntaOpinion As PreguntaOpinionEntidad In _listaPreguntaOpinion
        '        Dim _listaRespuesta As List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad) = encuestaBLL.obtenerRespuestas(_preguntaOpinion, paramMes, paramAno)
        '        For Each _respuestaOpinion As PreguntaOpinionEntidad.TipoRespuestasCalidad In _listaRespuesta
        '            If _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Bueno Or _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Excelente Then
        '                _satisfecho += 1
        '            ElseIf _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Malo Or _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Pesimo Then
        '                _insatisfecho += 1
        '            End If
        '        Next
        '    Next
        '    generarGrafico(_satisfecho, _insatisfecho)
        '    generarDataGridView(_satisfecho, _insatisfecho)
        'Catch ex As Exception
        'End Try

    End Sub


    Private Sub generarGrafico(ByVal _satisfecho As Integer, ByVal _insatisfecho As Integer)
        Try
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "script", "cargarGraficoTorta(" & _satisfecho & "," & _insatisfecho & ");", True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub generarDataGridView(_satisfecho, _insatisfecho)
        Me.valor_satisfecho.Text = _satisfecho
        Me.valor_insatisfecho.Text = _insatisfecho
    End Sub


    Private Sub cargarDDLAno()
        Try
            Dim _item2 As New ListItem
            _item2.Value = 0
            _item2.Text = "Todos"
            Me.ddl_Ano.Items.Add(_item2)
            Dim fecInicial As Integer = 2018
            For i = fecInicial To Year(Today)
                Dim _item As New ListItem
                _item.Value = i
                _item.Text = i.ToString
                Me.ddl_Ano.Items.Add(_item)
            Next
        Catch ex As Exception
        End Try


    End Sub


    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            If (Me.ddl_Ano.SelectedValue = 0) And (Me.ddl_Mes.SelectedValue = 0) Then
                obtenerPreguntasOpinion()
            Else
                obtenerPreguntasOpinion(CInt(Me.ddl_Mes.SelectedValue), CInt(Me.ddl_Ano.SelectedValue))
            End If
        Catch ex As Exception
        End Try
        obtenerSeleccionado() ' Gráfico Torta Ficha Opinion -Gráfico 2
    End Sub


    Private Sub obtenerPreguntasOpinion()
        'Try
        '    Dim _satisfecho As Integer = 0
        '    Dim _insatisfecho As Integer = 0
        '    Dim _listaPreguntaOpinion As List(Of PreguntaOpinionEntidad) = encuestaBLL.obtenerPreguntas
        '    For Each _preguntaOpinion As PreguntaOpinionEntidad In _listaPreguntaOpinion
        '        Dim _listaRespuesta As List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad) = encuestaBLL.obtenerRespuestas(_preguntaOpinion)
        '        For Each _respuestaOpinion As PreguntaOpinionEntidad.TipoRespuestasCalidad In _listaRespuesta
        '            If _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Bueno Or _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Excelente Then
        '                _satisfecho += 1
        '            ElseIf _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Malo Or _respuestaOpinion = PreguntaOpinionEntidad.TipoRespuestasCalidad.Pesimo Then
        '                _insatisfecho += 1
        '            End If
        '        Next
        '    Next
        '    generarGrafico(_satisfecho, _insatisfecho)
        '    generarDataGridView(_satisfecho, _insatisfecho)
        'Catch ex As Exception
        'End Try

    End Sub



    'CÓDIGO PARA REPORTE DE FICHA OPINION


    Private Sub obtenerPreguntasEncuesta()
        'Try
        '    Me.ddl_PreguntaEncuesta.DataSource = encuestaBLL.obtenerPreguntas(TipoPregunta.Opinion)
        '    Me.ddl_PreguntaEncuesta.DataValueField = "ID"
        '    Me.ddl_PreguntaEncuesta.DataTextField = "Enunciado"
        '    Me.ddl_PreguntaEncuesta.DataBind()
        'Catch ex As Exception
        'End Try

    End Sub

    Private Sub generarGrafico2(ByVal _Si As Integer, ByVal _No As Integer, ByVal _Quizas As Integer)
        Try
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "script2", "cargarGraficoTortaSINO(" & _Si & "," & _No & ", " & _Quizas & ");", True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub obtenerSeleccionado()
        'Try
        '    Dim _preguntaSeleccionada As New PreguntaOpinionEntidad
        '    _preguntaSeleccionada.ID = Me.ddl_PreguntaEncuesta.SelectedValue
        '    _preguntaSeleccionada = encuestaBLL.obtenerPreguntas(_preguntaSeleccionada)
        '    Dim _listaRespuesta As List(Of PreguntaOpinionEntidad.TipoRespuestasFichaOpinion) = encuestaBLL.obtenerRespuestasFO(_preguntaSeleccionada)
        '    calcularValoresGrafico(_listaRespuesta)
        'Catch ex As Exception
        'End Try

    End Sub


    'Public Sub calcularValoresGrafico(ByVal paramListaRespuesta As List(Of PreguntaOpinionEntidad.TipoRespuestasFichaOpinion))
    '    'Try
    '    '    Dim _si As Integer = 0
    '    '    Dim _no As Integer = 0
    '    '    Dim _quizas As Integer = 0


    '    '    For Each _respuesta As PreguntaOpinionEntidad.TipoRespuestasFichaOpinion In paramListaRespuesta
    '    '        If _respuesta = PreguntaOpinionEntidad.TipoRespuestasFichaOpinion.Si Then
    '    '            _si += 1
    '    '        ElseIf _respuesta = PreguntaOpinionEntidad.TipoRespuestasFichaOpinion.No Then
    '    '            _no += 1
    '    '        ElseIf _respuesta = PreguntaOpinionEntidad.TipoRespuestasFichaOpinion.Quizas Then
    '    '            _quizas += 1
    '    '        End If
    '    '    Next
    '    '    generarGrafico2(_si, _no, _quizas)
    '    '    generarDataGridView2(_si, _no, _quizas)
    '    'Catch ex As Exception

    '    'End Try

    'End Sub

    Private Sub generarDataGridView2(_si, _no, _quizas)
        Me.valor_Si.Text = _si
        Me.valor_No.Text = _no
        Me.valor_Quizas.Text = _quizas

    End Sub


    Private Sub ddl_PreguntaEncuesta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_PreguntaEncuesta.SelectedIndexChanged
        obtenerSeleccionado()
        obtenerPreguntasOpinion() ' Gráfico Torta Encuesta - Gráfico 1
    End Sub

    Protected Sub btn_agregarrta_Click(sender As Object, e As EventArgs) Handles btn_agregarrta.Click
        Dim Nuevarta As New RespuestaEncuestaEntidad
        Nuevarta.Descripcion = txt_rtas.Text
        TryCast(Session("RespuestasSeleccionadas"), List(Of Entidades.RespuestaEncuestaEntidad)).Add(Nuevarta)
        gv_respuestas.DataSource = Nothing
        gv_respuestas.DataSource = Session("RespuestasSeleccionadas")
        gv_respuestas.DataBind()
    End Sub
End Class

