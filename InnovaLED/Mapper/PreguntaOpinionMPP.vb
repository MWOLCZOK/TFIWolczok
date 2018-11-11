Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Entidades
Imports DAL
Public Class PreguntaOpinionMPP

    Public Function Alta(ByVal parampregunta As PreguntaOpinionEntidad)
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Pregunta_Opinion (Enunciado,Tipo,Fecha_Alta,Fecha_Fin_Vigencia,BL) values (@Enunciado,@Tipo,@Fecha_Alta,@Fecha_Fin_Vigencia,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Enunciado", parampregunta.Enunciado))
                .Add(New SqlParameter("@Tipo", parampregunta.TipoPregunta))
                .Add(New SqlParameter("@Fecha_Alta", parampregunta.FechaAlta))
                .Add(New SqlParameter("@Fecha_Fin_Vigencia", parampregunta.FechaFinVigencia))
                .Add(New SqlParameter("@BL", False))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Modificar(ByVal paramPregunta As PreguntaOpinionEntidad)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Pregunta", paramPregunta.ID)
            MisParametros.Add("@TipoPregunta", paramPregunta.TipoPregunta)
            MisParametros.Add("@FechaFinVigencia", paramPregunta.FechaFinVigencia)
            DAL.Conexion.ExecuteNonQuery("modificar_PreguntaOpinion", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub bajaPregunta(ByVal paramPregunta As PreguntaOpinionEntidad)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@ID_Pregunta", paramPregunta.ID)
            MisParametros.Add("@BL", True)
            DAL.Conexion.ExecuteNonQuery("baja_PreguntaOpinion", MisParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub guardarEncuesta(ByVal paramListaPregunta As List(Of PreguntaOpinionEntidad), ByVal paramUsuario As Entidades.Usuario)
        Try
            Dim MiComando As SqlCommand
            For Each _pregunta As PreguntaOpinionEntidad In paramListaPregunta
                MiComando = DAL.Conexion.retornaComando("insert into Respuesta_Opinion values (@Cod_Respuesta, @Cod_Pregunta, @ID_Usuario, @Valor_Respuesta, @Fecha_Alta)")
                Dim _codRespuesta As Integer = DAL.Conexion.ObtenerID("Respuesta_Opinion", "Cod_Respuesta")
                With MiComando.Parameters
                    .Add(New SqlParameter("@Cod_Respuesta", _codRespuesta))
                    .Add(New SqlParameter("@Cod_Pregunta", _pregunta.ID))
                    .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
                    .Add(New SqlParameter("@Valor_Respuesta", _pregunta.Respuesta))
                    .Add(New SqlParameter("@Fecha_Alta", Now))
                End With
                DAL.Conexion.ExecuteNonQuery(MiComando)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Function ListarPreguntaOpinion(ByVal paramTipoPregunta As PreguntaOpinionEntidad.TipoPreguntaOpinion) As List(Of PreguntaOpinionEntidad)
        Try
            Dim MisParametros As New Hashtable
            MisParametros.Add("@TipoPregunta", paramTipoPregunta)
            MisParametros.Add("@BL", False)

            Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("consultarPreguntaOpinion", MisParametros)

            For Each dr As DataRow In _dt.Rows
                Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
                Me.FormatearPreguntaOpinion(dr, _MiPreguntaOpinion)
                _listapreguntaopinion.Add(_MiPreguntaOpinion)
            Next
            Return _listapreguntaopinion
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FormatearPreguntaOpinion(paramdatarow As DataRow, parampreguntaopinion As PreguntaOpinionEntidad)
        Try
            parampreguntaopinion.ID = paramdatarow("Cod_Pregunta")
            parampreguntaopinion.Enunciado = paramdatarow("Enunciado")
            parampreguntaopinion.TipoPregunta = paramdatarow("Tipo")
            parampreguntaopinion.FechaAlta = paramdatarow("Fecha_Alta")
            parampreguntaopinion.FechaFinVigencia = paramdatarow("Fecha_Fin_Vigencia")
            parampreguntaopinion.BL = paramdatarow("BL")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function obtenerPreguntas(ByVal paramTipoPregunta As PreguntaOpinionEntidad.TipoPreguntaOpinion) As List(Of PreguntaOpinionEntidad)
        Try
            Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("	select * from pregunta_opinion where Tipo=@ID_TipoPregunta and BL=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@BL", False))
                .Add(New SqlParameter("@ID_TipoPregunta", paramTipoPregunta))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
                Me.FormatearPreguntaOpinion(dr, _MiPreguntaOpinion)
                _listapreguntaopinion.Add(_MiPreguntaOpinion)
            Next
            Return _listapreguntaopinion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function obtenerPreguntas() As List(Of PreguntaOpinionEntidad)
        Try
            Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("	select * from pregunta_opinion where BL=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
                Me.FormatearPreguntaOpinion(dr, _MiPreguntaOpinion)
                _listapreguntaopinion.Add(_MiPreguntaOpinion)
            Next
            Return _listapreguntaopinion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function obtenerPreguntas(ByVal paramPregunta As PreguntaOpinionEntidad) As PreguntaOpinionEntidad
        Try
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Pregunta_Opinion where Cod_Pregunta=@Cod_Pregunta and BL=@BL")
            With MiComando.Parameters
                .Add(New SqlParameter("@Cod_Pregunta", paramPregunta.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            If _dt.Rows.Count = 1 Then
                Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
                Me.FormatearPreguntaOpinion(_dt.Rows(0), _MiPreguntaOpinion)
                Return _MiPreguntaOpinion
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of PreguntaOpinionEntidad.etipoRespuesta)
        Try
            Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.etipoRespuesta)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select Valor_Respuesta from respuesta_opinion where Cod_Pregunta=@Cod_Pregunta")
            With MiComando.Parameters
                .Add(New SqlParameter("@Cod_Pregunta", paramPregunta.ID))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _MirespuestaOpinion As PreguntaOpinionEntidad.etipoRespuesta = dr.Item("Valor_Respuesta")
                _listaRespuestas.Add(_MirespuestaOpinion)
            Next
            Return _listaRespuestas
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad, ByVal paramMes As Integer, ByVal paramAno As Integer) As List(Of PreguntaOpinionEntidad.etipoRespuesta)
        Try
            Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.etipoRespuesta)
            Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select Valor_Respuesta from respuesta_opinion where Cod_Pregunta=@Cod_Pregunta And Year(Fecha_Alta)=@Ano And MONTH(Fecha_Alta)=@Mes")
            With MiComando.Parameters
                .Add(New SqlParameter("@Cod_Pregunta", paramPregunta.ID))
                .Add(New SqlParameter("@Ano", paramAno))
                .Add(New SqlParameter("@Mes", paramMes))
            End With
            Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
            For Each dr As DataRow In _dt.Rows
                Dim _MirespuestaOpinion As PreguntaOpinionEntidad.etipoRespuesta = dr.Item("Valor_Respuesta")
                _listaRespuestas.Add(_MirespuestaOpinion)
            Next
            Return _listaRespuestas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad, ByVal paramvalor As Integer, ByVal paramIndicador As Boolean) As List(Of PreguntaOpinionEntidad.etipoRespuesta)
        Try
            Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.etipoRespuesta)
            Dim MiComando As SqlCommand
            If paramIndicador = True Then
                MiComando = DAL.Conexion.retornaComando("select Valor_Respuesta from respuesta_opinion where Cod_Pregunta = @Cod_Pregunta And Year(Fecha_Alta)=@Ano ORDER BY respuesta_opinion.Cod_Pregunta")
                With MiComando.Parameters
                    .Add(New SqlParameter("@Cod_Pregunta", paramPregunta.ID))
                    .Add(New SqlParameter("@Ano", paramvalor))
                End With
                Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
                For Each dr As DataRow In _dt.Rows
                    Dim _MirespuestaOpinion As PreguntaOpinionEntidad.etipoRespuesta = dr.Item("Valor_Respuesta")
                    _listaRespuestas.Add(_MirespuestaOpinion)
                Next
                Return _listaRespuestas
            Else
                MiComando = DAL.Conexion.retornaComando("select Valor_Respuesta from respuesta_opinion where Cod_Pregunta = @Cod_Pregunta And MONTH(Fecha_Alta)=@Mes ORDER BY respuesta_opinion.Cod_Pregunta")
                With MiComando.Parameters
                    .Add(New SqlParameter("@Cod_Pregunta", paramPregunta.ID))
                    .Add(New SqlParameter("@Mes", paramvalor))
                End With
                Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
                For Each dr As DataRow In _dt.Rows
                    Dim _MirespuestaOpinion As PreguntaOpinionEntidad.etipoRespuesta = dr.Item("Valor_Respuesta")
                    _listaRespuestas.Add(_MirespuestaOpinion)
                Next
                Return _listaRespuestas
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function





End Class
