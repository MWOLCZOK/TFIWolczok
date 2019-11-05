Imports Negocio
Imports Entidades
Imports System.Web.UI.DataVisualization.Charting




Public Class Reportes_TR_Chat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarChartReporteTiempos()
        LlenarChartChatsRespondidos()
    End Sub

    Dim chatBLL As New GestorChatBLL

    Private Sub LlenarChartReporteTiempos()

        Dim listChat As List(Of MensajeChatEntidad)
        listChat = chatBLL.TraerMensajesChatParaReporte()

        If listChat.Count = 0 Then
            Me.divChartTiempoDeRespuesta.InnerHtml = "No se encontró información"
            Me.divChartTiempoDeRespuesta.Visible = True
        Else

            Dim horaTemp
            Dim res As Integer
            Dim resTOT As Integer
            Dim prom As Integer


            For Each r As MensajeChatEntidad In listChat
                If horaTemp = 0 Then
                    horaTemp = r.Fecha.Minute
                Else
                    res = r.Fecha.Minute - horaTemp
                    resTOT = resTOT + res
                End If
            Next

            prom = resTOT / listChat.Count
            Dim Serie1 = chartTiempoDeRespuesta.Series("Series1")
            Serie1.Points.Clear()
            Serie1.Points.AddXY(listChat.Count, prom)
            chartTiempoDeRespuesta.Series(0).ChartType = SeriesChartType.Column
            Dim ChartArea = chartTiempoDeRespuesta.ChartAreas("ChartArea1")
            ChartArea.AxisY.Title = "Tiempo promedio de respuesta (Minutos)"
            ChartArea.AxisX.Title = "Cantidad de Mensajes "
            '//y si lo quiero en 3D
            chartTiempoDeRespuesta.ChartAreas(0).Area3DStyle.Enable3D = True


        End If
    End Sub

    Private Sub LlenarChartChatsRespondidos()
        Dim listChatRespondidos As New List(Of ChatEntidad)
        Dim chatBLL As New GestorChatBLL
        listChatRespondidos = chatBLL.TraerChats()
        Dim Respondidos As Integer
        Dim NoRespondidos As Integer
        For Each chat As ChatEntidad In listChatRespondidos

            If chat.Empleado.ID_Usuario = 4 Then
                Respondidos = Respondidos + 1

            Else
                NoRespondidos = NoRespondidos + 1

            End If

        Next

        Try
            Dim script As String

            script = " $(document).ready(function () {
                 var ctx = document.getElementById(""chart-area1"").getContext(""2d"");   
                    var pieData = [ "

            System.Threading.Thread.Sleep(50)
            Dim color As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
                    System.Threading.Thread.Sleep(50)
                    Dim colorh As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
            script += "{ value: " & Respondidos & ","
            script += " color: " + """" + color + ""","
            script += " highlight: " + """" + colorh + ""","
            script += " label: ""Respondidos""},"

            System.Threading.Thread.Sleep(50)
            Dim color2 As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
            System.Threading.Thread.Sleep(50)
            Dim colorh2 As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
            script += "{ value: " & NoRespondidos & ","
            script += " color: " + """" + color2 + ""","
            script += " highlight: " + """" + colorh2 + ""","
            script += " label: ""No Respondidos""},"

            script +=
                  "  ];
                    window.myPie = new Chart(ctx).Pie(pieData);
                 }); "

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "chats", script, True)

        Catch ex As Exception
        End Try

    End Sub








End Class