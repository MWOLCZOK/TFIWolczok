Imports Entidades
Imports Negocio
Imports System.Web.HttpContext




Public Class EncuestaGlobal
    Inherits System.Web.UI.Page


    Dim GestorPreguntaOpinion As New GestorPreguntaOpinionBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarPreguntasOpiniones()
        Else
            cargarPreguntasOpiniones()
        End If
    End Sub

    Private Sub cargarPreguntasOpiniones()
        Try
            Dim _listapregunta As New List(Of PreguntaOpinionEntidad)
            _listapregunta = GestorPreguntaOpinion.TraerTodasPreguntasFichaOpinion(TipoPregunta.Encuesta)
            Session("Preguntas") = _listapregunta
            GenerarDiseño(_listapregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Function validarCuestionario() As Boolean
        Try
            For i = 1 To Session("Preguntas").Count
                Dim radioButton As New RadioButtonList
                radioButton = DirectCast(Me.preguntasdinamicas.FindControl("rb_pregunta" & i), RadioButtonList)
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
        Try
            If IsNothing(Current.Session("cliente")) Or IsDBNull(Current.Session("Cliente")) Then
                Me.alertvalid.Visible = True
                Me.alertvalid.InnerText = "Debe loguearse para continuar con la encuesta"
            Else

                Dim _listaRespuesta As New List(Of RespuestaEntidad)
                If validarCuestionario() = True Then
                    Dim cant As Integer = 1
                    For Each Pregunta As PreguntaOpinionEntidad In Session("Preguntas")
                        Dim _resp As New RespuestaEntidad
                        _resp.Pregunta = Pregunta
                        _resp.RespuestaEncuesta = New RespuestaEncuestaEntidad With {.ID = DirectCast(Me.preguntasdinamicas.FindControl("rb_pregunta" & cant), RadioButtonList).SelectedValue}
                        _resp.Usuario = Session("cliente")
                        GestorPreguntaOpinion.InsertarRespuesta(_resp)
                        cant += 1
                    Next

                    Me.alertvalid.Visible = False
                    Me.success.Visible = True
                    Me.success.InnerText = "¡Gracias por haber respondido ésta encuesta!"
                    Response.AddHeader("REFRESH", "5;URL=Default.aspx")
                Else
                    Me.alertvalid.InnerText = "Debe completar todos los campos"
                    Me.alertvalid.Visible = True
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GenerarDiseño(ByVal listapreguntas As List(Of PreguntaOpinionEntidad))
        preguntasdinamicas.Controls.Clear()
        Dim cant As Integer = 1
        For Each preg In listapreguntas
            Dim divh3 As HtmlGenericControl = New HtmlGenericControl("h3")
            Dim labelpregunta As Label = New Label
            labelpregunta.Text = preg.Enunciado
            divh3.Controls.Add(labelpregunta)
            Dim br1 As HtmlGenericControl = New HtmlGenericControl("br")
            Dim br2 As HtmlGenericControl = New HtmlGenericControl("br")
            Dim br3 As HtmlGenericControl = New HtmlGenericControl("br")
            Dim br4 As HtmlGenericControl = New HtmlGenericControl("br")
            Dim rblist As RadioButtonList = New RadioButtonList

            rblist.ID = "rb_pregunta" & cant
            rblist.DataTextField = "Descripcion"
            rblist.DataValueField = "ID"
            rblist.DataSource = preg.PosiblesRespuestas
            rblist.DataBind()
            rblist.Attributes.Add("class", "text-left")
            preguntasdinamicas.Controls.Add(divh3)
            preguntasdinamicas.Controls.Add(br1)
            preguntasdinamicas.Controls.Add(br2)
            preguntasdinamicas.Controls.Add(rblist)
            preguntasdinamicas.Controls.Add(br3)
            preguntasdinamicas.Controls.Add(br4)
            cant += 1
        Next
    End Sub

End Class