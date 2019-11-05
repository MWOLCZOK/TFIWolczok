Imports Entidades
Imports Negocio
Imports System.Web.HttpContext




Public Class EncuestaGlobal
    Inherits System.Web.UI.Page


    Dim GestorPreguntaOpinion As New GestorPreguntaOpinionBLL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("PreguntasEncuestasRandom") = New List(Of PreguntaOpinionEntidad)
            cargarPreguntasOpiniones()
        Else
            cargarPreguntasOpiniones()
            Me.btn_enviar.Visible = False
        End If
    End Sub

    Private Sub cargarPreguntasOpiniones()
        Try

            Dim _listapregunta As New List(Of PreguntaOpinionEntidad)
            If Session("PreguntasEncuestasRandom").count = 0 Then
                _listapregunta = GestorPreguntaOpinion.TraerTodasPreguntasFichaOpinionRandom(TipoPregunta.Encuesta)
                Session("PreguntasEncuestasRandom") = _listapregunta
                If _listapregunta.Count = 0 Then
                    Me.alertvalid.Visible = True
                    Me.alertvalid.InnerText = "Por el momento no hay encuestas disponibles para mostrar."
                    Me.success.Visible = False
                Else
                    GenerarDiseño(_listapregunta)
                End If
            Else
                GenerarDiseño(Session("PreguntasEncuestasRandom"))
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Function validarCuestionario() As Boolean
        Try
            For i = 1 To Session("PreguntasEncuestasRandom").Count
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
            Dim _listaRespuesta As New List(Of RespuestaEntidad)
            If validarCuestionario() = True Then
                    Dim cant As Integer = 1
                For Each Pregunta As PreguntaOpinionEntidad In Session("PreguntasEncuestasRandom")
                    Dim _resp As New RespuestaEntidad
                    _resp.Pregunta = Pregunta
                    _resp.RespuestaEncuesta = New RespuestaEncuestaEntidad With {.ID = DirectCast(Me.preguntasdinamicas.FindControl("rb_pregunta" & cant), RadioButtonList).SelectedValue}
                    _resp.Usuario = Session("cliente")
                    GestorPreguntaOpinion.InsertarRespuesta(_resp)
                    Dim gestorpregunta As New GestorPreguntaOpinionBLL
                    generarGrafico(gestorpregunta.obtenerRespuestasGrafico(Pregunta), "chart-area" & cant)
                    cant += 1
                Next

                Me.alertvalid.Visible = False
                    Me.success.Visible = True
                Me.success.InnerText = "¡Gracias por haber respondido ésta encuesta!"
                Session("PreguntasEncuestasRandom") = New List(Of PreguntaOpinionEntidad)


            Else
                    Me.alertvalid.InnerText = "Debe completar todos los campos"
                Me.alertvalid.Visible = True
                btn_enviar.Visible = True
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


    Private Sub generarGrafico(ByVal respuestas As List(Of RespuestaEntidad), ByVal nombrechart As String)
        Try
            Dim script As String

            script = " $(document).ready(function () {
                 var ctx = document.getElementById(""" & nombrechart & """).getContext(""2d"");   
                    var pieData = [ "

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

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "encuestas" & nombrechart, script, True)

        Catch ex As Exception
        End Try
    End Sub














End Class