Imports Entidades
Imports Mapper


Public Class PreguntaOpinionBLL

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

    Public Function TraerTodasPreguntasFichaOpinion(paramTipoPregunta As PreguntaOpinionEntidad.TipoPreguntaOpinion) As List(Of PreguntaOpinionEntidad)
        Try
            Return preguntaMPP.TraerTodasPreguntasFichaOpinion(paramTipoPregunta)
        Catch ex As Exception
            Throw ex
        End Try

    End Function





    Public Function InsertarRespuesta(ByVal paramRespuesta As RespuestaEntidad)
        Try

            Return preguntaMPP.InsertarRespuesta(paramRespuesta)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Class
