Imports Negocio
Imports Entidades
Imports System.Web.HttpContext

Public Class ReporteEncuestas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            cargarPreguntasEncuesta()
            cargarPreguntasFichaOpinion()
            Session("RespuestasSeleccionadas") = New List(Of RespuestaEncuestaEntidad)
            btn_buscar_Click(Nothing, Nothing)
        Else

        End If
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

    Dim encuestaBLL As New GestorPreguntaOpinionBLL


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