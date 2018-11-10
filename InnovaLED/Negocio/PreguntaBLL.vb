Public Class PreguntaBLL

    Public Sub Alta(ByVal paramPregunta As Entidades.PreguntaOpinion)
        Try
            MiPreguntaOpinionMPP.Alta(paramPregunta)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try
    End Sub

    Public Sub Modificar(ByVal paramPregunta As Entidades.PreguntaOpinion)
        Try
            MiPreguntaOpinionMPP.Modificar(paramPregunta)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try
    End Sub

    Public Sub guardarEncuesta(ByVal paramListaPregunta As List(Of Entidades.PreguntaOpinion), ByVal paramUsuario As Entidades.Usuario)
        Try
            MiPreguntaOpinionMPP.guardarEncuesta(paramListaPregunta, paramUsuario)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try
    End Sub



    Public Function ListarPreguntaOpinion(ByVal paramTipoPregunta As Entidades.PreguntaOpinion.TipoPreguntaOpinion) As List(Of Entidades.PreguntaOpinion)
        Try
            Return MiPreguntaOpinionMPP.ListarPreguntaOpinion(paramTipoPregunta)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try

    End Function


    Public Function obtenerPreguntas() As List(Of Entidades.PreguntaOpinion)
        Try
            Return MiPreguntaOpinionMPP.obtenerPreguntas()
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try

    End Function

    Public Function obtenerPreguntas(ByVal paramTipoPregunta As Entidades.PreguntaOpinion.TipoPreguntaOpinion) As List(Of Entidades.PreguntaOpinion)
        Try
            Return MiPreguntaOpinionMPP.obtenerPreguntas(paramTipoPregunta)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try

    End Function

    Public Function obtenerPreguntas(ByVal paramPregunta As Entidades.PreguntaOpinion) As Entidades.PreguntaOpinion

        Try
            Return MiPreguntaOpinionMPP.obtenerPreguntas(paramPregunta)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try

    End Function


    Public Function obtenerRespuestas(ByVal paramPregunta As Entidades.PreguntaOpinion) As List(Of Entidades.PreguntaOpinion.etipoRespuesta)
        Try
            Return MiPreguntaOpinionMPP.obtenerRespuestas(paramPregunta)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try

    End Function

    Public Sub bajaPregunta(ByVal paramPregunta As Entidades.PreguntaOpinion)
        Try
            MiPreguntaOpinionMPP.bajaPregunta(paramPregunta)
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try

    End Sub

    Public Function obtenerRespuestas(ByVal paramPregunta As Entidades.PreguntaOpinion, ByVal paramMes As Integer, ByVal paramAno As Integer) As List(Of Entidades.PreguntaOpinion.etipoRespuesta)
        Try
            If paramMes = 0 Then
                'TODOS LOS MESES, UN AÑO EN PARTICULAR
                Return MiPreguntaOpinionMPP.obtenerRespuestas(paramPregunta, paramAno, True)
            ElseIf paramAno = 0 Then
                'TODOS LOS AÑOS, UN MES EN PARTICULAR
                Return MiPreguntaOpinionMPP.obtenerRespuestas(paramPregunta, paramMes, False)
            Else
                'UN MES Y AÑO EN PARTICULAR
                Return MiPreguntaOpinionMPP.obtenerRespuestas(paramPregunta, paramMes, paramAno)
            End If
        Catch ex As Exception
            Throw New BLL.excepcionGenerica
        End Try

    End Function



End Class
