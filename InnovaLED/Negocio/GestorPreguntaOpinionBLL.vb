Imports Entidades
Imports Mapper


Public Class GestorPreguntaOpinionBLL

    Dim preguntaMPP As New PreguntaOpinionMPP

    Public Function Alta(paramPregunta As PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.Alta(paramPregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Modificar(paramPregunta As PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.Modificar(paramPregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Eliminar(paramPregunta As PreguntaOpinionEntidad)

        Try
            Return preguntaMPP.Eliminar(paramPregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TraerTodasPreguntasFichaOpinion(paramTipoPregunta As TipoPregunta) As List(Of PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.TraerTodasPreguntasFichaOpinion(paramTipoPregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TraerTodasPreguntasFichaOpinionRandom(paramTipoPregunta As TipoPregunta) As List(Of PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.TraerTodasPreguntasFichaOpinionRandom(paramTipoPregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TraerTodasPreguntasGraficos(paramTipoPregunta As TipoPregunta) As List(Of PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.TraerTodasPreguntasGraficos(paramTipoPregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Function





    Public Function TraerTodasLasPreguntas() As List(Of PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.TraerTodasLasPreguntas()
        Catch ex As Exception

        End Try
    End Function





    Public Function InsertarRespuesta(ByVal paramRespuesta As RespuestaEntidad)
        Try

            Return preguntaMPP.InsertarRespuesta(paramRespuesta)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TraerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of RespuestaEntidad)
        Return preguntaMPP.TraerRespuestas(paramPregunta)
    End Function


    'Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad, ByVal paramMes As Integer, ByVal paramAno As Integer) As List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad)
    '    Try
    '        If paramMes = 0 Then
    '            'TODOS LOS MESES, UN AÑO EN PARTICULAR
    '            Return preguntaMPP.obtenerRespuestas(paramPregunta, paramAno, True)
    '        ElseIf paramAno = 0 Then
    '            'TODOS LOS AÑOS, UN MES EN PARTICULAR
    '            Return preguntaMPP.obtenerRespuestas(paramPregunta, paramMes, False)
    '        Else
    '            'UN MES Y AÑO EN PARTICULAR
    '            Return preguntaMPP.obtenerRespuestas(paramPregunta, paramMes, paramAno)
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception
    '    End Try

    'End Function


    'Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad)
    '    Try
    '        Return preguntaMPP.obtenerRespuestas(paramPregunta)
    '    Catch ex As Exception
    '        Throw New Exception
    '    End Try

    'End Function


    Public Function obtenerPreguntas() As List(Of PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.obtenerPreguntas()
        Catch ex As Exception
            Throw New Exception
        End Try

    End Function

    'Public Function obtenerPreguntas(ByVal paramTipoPregunta As PreguntaOpinionEntidad.TipoRespuestasFichaOpinion) As List(Of PreguntaOpinionEntidad)
    '    Try
    '        Return preguntaMPP.obtenerPreguntas(paramTipoPregunta)
    '    Catch ex As Exception
    '        Throw New Exception
    '    End Try

    'End Function

    Public Function obtenerPreguntas(ByVal paramPregunta As PreguntaOpinionEntidad) As PreguntaOpinionEntidad

        Try
            Return preguntaMPP.obtenerPreguntas(paramPregunta)
        Catch ex As Exception
            Throw New Exception
        End Try

    End Function

    Public Function obtenerRespuestasGrafico(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of RespuestaEntidad)
        Try
            Return preguntaMPP.obtenerRespuestasgrafico(paramPregunta)
        Catch ex As Exception
            Throw New Exception
        End Try

    End Function










End Class
