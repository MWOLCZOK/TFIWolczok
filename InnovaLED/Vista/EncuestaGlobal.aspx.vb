Imports Entidades
Imports Negocio
Imports System.Web.HttpContext




Public Class EncuestaGlobal
    Inherits System.Web.UI.Page


    Dim GestorPreguntaOpinion As New GestorPreguntaOpinionBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarPreguntasOpiniones()
            'LlenarChart()
        End If
    End Sub

    Private Sub cargarPreguntasOpiniones()
        Try
            Dim _listapregunta As New List(Of PreguntaOpinionEntidad)
            _listapregunta = GestorPreguntaOpinion.TraerTodasPreguntasFichaOpinion(TipoPregunta.Encuesta)
            generarPreguntasOpinion(_listapregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub generarPreguntasOpinion(ByVal paramListadoRespuestas As List(Of PreguntaOpinionEntidad))
        'Try
        '    Dim _contador As Integer = 1
        '    For Each MiPregunta As PreguntaOpinionEntidad In paramListadoRespuestas
        '        Dim label As Label = Me.panelPreguntas.FindControl("lbl_pregunta" & _contador)
        '        Dim labelID As Label = Me.panelPreguntas.FindControl("id_" & _contador)
        '        label.Text = MiPregunta.Enunciado
        '        labelID.Text = MiPregunta.ID
        '        _contador += 1
        '    Next
        '    rb_pregunta1.DataSource = System.Enum.GetValues(GetType(RespuestaEntidad.TipoRespuestasCalidad))
        '    rb_pregunta1.DataBind()
        '    rb_pregunta2.DataSource = System.Enum.GetValues(GetType(RespuestaEntidad.TipoRespuestasCalidad))
        '    rb_pregunta2.DataBind()
        '    rb_pregunta3.DataSource = System.Enum.GetValues(GetType(RespuestaEntidad.TipoRespuestasCalidad))
        '    rb_pregunta3.DataBind()
        'Catch ex As Exception

        'End Try

    End Sub

    Private Function validarCuestionario() As Boolean
        Try
            For i = 1 To 3
                Dim radioButton As New RadioButtonList
                radioButton = DirectCast(Me.panelPreguntas.FindControl("rb_pregunta" & i), RadioButtonList)
                If radioButton.SelectedValue = "" Then
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        'Try
        '    If IsNothing(Current.Session("cliente")) Or IsDBNull(Current.Session("Cliente")) Then
        '        Me.alertvalid.Visible = True
        '        Me.alertvalid.InnerText = "Debe loguearse para continuar con la encuesta"
        '    Else

        '        Dim _listaRespuesta As New List(Of RespuestaEntidad)
        '        If validarCuestionario() = True Then
        '            For i = 1 To 3
        '                Dim _resp As New RespuestaEntidad
        '                _resp.Pregunta = New PreguntaOpinionEntidad With {.ID = DirectCast(Me.panelPreguntas.FindControl("id_" & i), Label).Text}  ' aca lo lleno con una instanacia de preguntaENtidad
        '                _resp.Valor_Respuesta = [Enum].Parse(GetType(RespuestaEntidad.TipoRespuestasCalidad), DirectCast(Me.panelPreguntas.FindControl("rb_pregunta" & i), RadioButtonList).SelectedValue) ' Para obtener el valor doe RBList necesito el Enum,parse porque sino toma el valor texto

        '                _resp.Usuario = Session("cliente")
        '                _listaRespuesta.Add(_resp)
        '            Next

        '            For Each _resp As RespuestaEntidad In _listaRespuesta
        '                GestorPreguntaOpinion.InsertarRespuesta(_resp)
        '            Next

        '            Me.success.Visible = True
        '            Me.success.InnerText = "¡Gracias por haber respondido ésta encuesta!"
        '        Else
        '            Me.alertvalid.InnerText = "Debe completar todos los campos"
        '            Me.alertvalid.Visible = True
        '        End If
        '    End If


        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

























End Class