Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Entidades
Imports DAL
Public Class PreguntaOpinionMPP

    Public Function Alta(ByVal parampregunta As PreguntaOpinionEntidad)
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Pregunta_Opinion (Enunciado,Tipo,Fecha_Alta,Fecha_Fin_Vigencia,BL) OUTPUT INSERTED.ID_Pregunta values (@Enunciado,@Tipo,@Fecha_Alta,@Fecha_Fin_Vigencia,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Enunciado", parampregunta.Enunciado))
                .Add(New SqlParameter("@Tipo", parampregunta.TipoPregunta))
                .Add(New SqlParameter("@Fecha_Alta", Now))
                .Add(New SqlParameter("@Fecha_Fin_Vigencia", parampregunta.FechaFinVigencia))
                .Add(New SqlParameter("@BL", False))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Modificar(ByVal paramPregunta As PreguntaOpinionEntidad)
        Try
            Dim Command As SqlCommand = Acceso.MiComando("update Pregunta_Opinion set Enunciado=@Enunciado, Tipo=@Tipo, Fecha_Alta=@Fecha_Alta, Fecha_Fin_Vigencia=@Fecha_Fin_Vigencia   where ID_Pregunta=@ID_Pregunta and BL=@BL")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
                .Add(New SqlParameter("@Enunciado", paramPregunta.Enunciado))
                .Add(New SqlParameter("@Tipo", paramPregunta.TipoPregunta))
                .Add(New SqlParameter("@Fecha_Alta", paramPregunta.FechaAlta))
                .Add(New SqlParameter("@Fecha_Fin_Vigencia", paramPregunta.FechaFinVigencia))
                .Add(New SqlParameter("@BL", False))
            End With
            Acceso.Escritura(Command)
            Command.Dispose()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function Eliminar(ByVal paramPregunta As PreguntaOpinionEntidad)
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Update Pregunta_Opinion Set BL=@BL where ID_Pregunta=@ID_Pregunta")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@BL", True))
                .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))

            End With
            Acceso.Escritura(Command)
            Command.Dispose()

            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TraerTodasPreguntasFichaOpinion(paramTipoPregunta As TipoPregunta) As List(Of PreguntaOpinionEntidad)
        Try
            Dim consulta As String = "Select * from Pregunta_Opinion where BL=@BL and Tipo=@Tipo"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@Tipo", paramTipoPregunta))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaPregunta As List(Of PreguntaOpinionEntidad) = New List(Of PreguntaOpinionEntidad)
            For Each row As DataRow In dt.Rows
                Dim preg As PreguntaOpinionEntidad = New PreguntaOpinionEntidad
                FormatearPreguntaOpinion(preg, row)
                ListaPregunta.Add(preg)
            Next
            Return ListaPregunta
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TraerTodasLasPreguntas() As List(Of PreguntaOpinionEntidad)
        Try
            Dim consulta As String = "Select * from Pregunta_Opinion where BL=@BL"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@BL", False))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaPregunta As List(Of PreguntaOpinionEntidad) = New List(Of PreguntaOpinionEntidad)
            For Each row As DataRow In dt.Rows
                Dim preg As PreguntaOpinionEntidad = New PreguntaOpinionEntidad
                FormatearPreguntaOpinion(preg, row)
                ListaPregunta.Add(preg)
            Next
            Return ListaPregunta
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    'Revisar que se cambiaron parametos de la BD
    Public Function InsertarRespuesta(ByVal paramRespuesta As RespuestaEntidad)
        Try

            Dim Command As SqlCommand = Acceso.MiComando("insert into Respuesta_Opinion (ID_Pregunta,ID_Usuario,Valor_Respuesta,Fecha_Alta) values (@ID_Pregunta,@ID_Usuario,@Valor_Respuesta,@Fecha_Alta)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Pregunta", paramRespuesta.Pregunta.ID))
                .Add(New SqlParameter("@ID_Usuario", paramRespuesta.Usuario.ID_Usuario))
                .Add(New SqlParameter("@Valor_Respuesta", paramRespuesta.Valor_Respuesta))
                .Add(New SqlParameter("@Fecha_Alta", Now))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    'Public Sub guardarEncuesta(ByVal paramListaPregunta As List(Of PreguntaOpinionEntidad), ByVal paramUsuario As Entidades.Usuario)
    '    Try
    '        Dim MiComando As SqlCommand
    '        For Each _pregunta As PreguntaOpinionEntidad In paramListaPregunta
    '            MiComando = DAL.Conexion.retornaComando("insert into Respuesta_Opinion values (@Cod_Respuesta, @ID_Pregunta, @ID_Usuario, @Valor_Respuesta, @Fecha_Alta)")
    '            Dim _codRespuesta As Integer = DAL.Conexion.ObtenerID("Respuesta_Opinion", "Cod_Respuesta")
    '            With MiComando.Parameters
    '                .Add(New SqlParameter("@Cod_Respuesta", _codRespuesta))
    '                .Add(New SqlParameter("@ID_Pregunta", _pregunta.ID))
    '                .Add(New SqlParameter("@ID_Usuario", paramUsuario.ID))
    '                .Add(New SqlParameter("@Valor_Respuesta", _pregunta.Respuesta))
    '                .Add(New SqlParameter("@Fecha_Alta", Now))
    '            End With
    '            DAL.Conexion.ExecuteNonQuery(MiComando)
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub



    'Public Function ListarPreguntaOpinion(ByVal paramTipoPregunta As PreguntaOpinionEntidad.TipoPreguntaOpinion) As List(Of PreguntaOpinionEntidad)
    '    Try
    '        Dim MisParametros As New Hashtable
    '        MisParametros.Add("@TipoPregunta", paramTipoPregunta)
    '        MisParametros.Add("@BL", False)

    '        Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable("consultarPreguntaOpinion", MisParametros)

    '        For Each dr As DataRow In _dt.Rows
    '            Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
    '            Me.FormatearPreguntaOpinion(dr, _MiPreguntaOpinion)
    '            _listapreguntaopinion.Add(_MiPreguntaOpinion)
    '        Next
    '        Return _listapreguntaopinion
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Sub FormatearPreguntaOpinion(ByVal parampreguntaopinion As PreguntaOpinionEntidad, ByVal row As DataRow)
        Try
            parampreguntaopinion.ID = row("ID_Pregunta")
            parampreguntaopinion.Enunciado = row("Enunciado")
            parampreguntaopinion.TipoPregunta = row("Tipo")
            parampreguntaopinion.FechaAlta = row("Fecha_Alta")
            parampreguntaopinion.FechaFinVigencia = row("Fecha_Fin_Vigencia")
            parampreguntaopinion.BL = row("BL")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub




    'Public Function obtenerPreguntas(ByVal paramTipoPregunta As PreguntaOpinionEntidad.TipoPreguntaOpinion) As List(Of PreguntaOpinionEntidad)
    '    Try
    '        Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("	select * from pregunta_opinion where Tipo=@ID_TipoPregunta and BL=@BL")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@BL", False))
    '            .Add(New SqlParameter("@ID_TipoPregunta", paramTipoPregunta))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each dr As DataRow In _dt.Rows
    '            Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
    '            Me.FormatearPreguntaOpinion(dr, _MiPreguntaOpinion)
    '            _listapreguntaopinion.Add(_MiPreguntaOpinion)
    '        Next
    '        Return _listapreguntaopinion
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function obtenerPreguntas() As List(Of PreguntaOpinionEntidad)
    '    Try
    '        Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("	select * from pregunta_opinion where BL=@BL")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@BL", False))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each dr As DataRow In _dt.Rows
    '            Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
    '            Me.FormatearPreguntaOpinion(dr, _MiPreguntaOpinion)
    '            _listapreguntaopinion.Add(_MiPreguntaOpinion)
    '        Next
    '        Return _listapreguntaopinion
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function obtenerPreguntas(ByVal paramPregunta As PreguntaOpinionEntidad) As PreguntaOpinionEntidad
    '    Try
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select * from Pregunta_Opinion where ID_Pregunta=@ID_Pregunta and BL=@BL")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
    '            .Add(New SqlParameter("@BL", False))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        If _dt.Rows.Count = 1 Then
    '            Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
    '            Me.FormatearPreguntaOpinion(_dt.Rows(0), _MiPreguntaOpinion)
    '            Return _MiPreguntaOpinion
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of PreguntaOpinionEntidad.etipoRespuesta)
    '    Try
    '        Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.etipoRespuesta)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select Valor_Respuesta from respuesta_opinion where ID_Pregunta=@ID_Pregunta")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each dr As DataRow In _dt.Rows
    '            Dim _MirespuestaOpinion As PreguntaOpinionEntidad.etipoRespuesta = dr.Item("Valor_Respuesta")
    '            _listaRespuestas.Add(_MirespuestaOpinion)
    '        Next
    '        Return _listaRespuestas
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


    'Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad, ByVal paramMes As Integer, ByVal paramAno As Integer) As List(Of PreguntaOpinionEntidad.etipoRespuesta)
    '    Try
    '        Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.etipoRespuesta)
    '        Dim MiComando As SqlCommand = DAL.Conexion.retornaComando("select Valor_Respuesta from respuesta_opinion where ID_Pregunta=@ID_Pregunta And Year(Fecha_Alta)=@Ano And MONTH(Fecha_Alta)=@Mes")
    '        With MiComando.Parameters
    '            .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
    '            .Add(New SqlParameter("@Ano", paramAno))
    '            .Add(New SqlParameter("@Mes", paramMes))
    '        End With
    '        Dim _dt As DataTable = DAL.Conexion.ExecuteDataTable(MiComando)
    '        For Each dr As DataRow In _dt.Rows
    '            Dim _MirespuestaOpinion As PreguntaOpinionEntidad.etipoRespuesta = dr.Item("Valor_Respuesta")
    '            _listaRespuestas.Add(_MirespuestaOpinion)
    '        Next
    '        Return _listaRespuestas
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


    'esta consulta para revisar.

    'Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad, ByVal paramvalor As Integer, ByVal paramIndicador As Boolean) As List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad)
    '    'Try
    '    '    Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad)

    '    '    If paramIndicador = True Then
    '    '        Dim consulta As String = "Select Valor_Respuesta from Respuesta_Opinion where ID_Pregunta = @ID_Pregunta And Year(Fecha_Alta)=@Ano ORDER BY Respuesta_Opinion.ID_Pregunta"
    '    '        Dim Command As SqlCommand = Acceso.MiComando(consulta)
    '    '        With Command.Parameters
    '    '            .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
    '    '            .Add(New SqlParameter("@Ano", paramvalor))
    '    '        End With
    '    '        Dim _dt As DataTable = Acceso.Lectura(Command)
    '    '        For Each dr As DataRow In _dt.Rows
    '    '            Dim _MirespuestaOpinion As PreguntaOpinionEntidad.TipoRespuestasCalidad = dr.Item("Valor_Respuesta")
    '    '            _listaRespuestas.Add(_MirespuestaOpinion)
    '    '        Next
    '    '        Return _listaRespuestas
    '    '    Else
    '    '        Dim consulta2 As String = "select Valor_Respuesta from respuesta_opinion where ID_Pregunta = @ID_Pregunta And MONTH(Fecha_Alta)=@Mes ORDER BY respuesta_opinion.ID_Pregunta"
    '    '        Dim Command2 As SqlCommand = Acceso.MiComando(consulta2)
    '    '        With Command2.Parameters
    '    '            .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
    '    '            .Add(New SqlParameter("@Mes", paramvalor))
    '    '        End With
    '    '        Dim _dt As DataTable = Acceso.Lectura(Command2)
    '    '        For Each dr As DataRow In _dt.Rows
    '    '            Dim _MirespuestaOpinion As PreguntaOpinionEntidad.TipoRespuestasCalidad = dr.Item("Valor_Respuesta")
    '    '            _listaRespuestas.Add(_MirespuestaOpinion)
    '    '        Next
    '    '        Return _listaRespuestas
    '    '    End If
    '    'Catch ex As Exception
    '    '    Throw ex
    '    'End Try
    'End Function



    'Public Function obtenerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad)
    'Try
    '    Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.TipoRespuestasCalidad)
    '    Dim consulta As String = "Select Valor_Respuesta from Respuesta_Opinion where ID_Pregunta=@ID_Pregunta"
    '    Dim Command As SqlCommand = Acceso.MiComando(consulta)
    '    With Command.Parameters
    '        .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
    '    End With
    '    Dim _dt As DataTable = Acceso.Lectura(Command)
    '    For Each dr As DataRow In _dt.Rows
    '        Dim _MirespuestaOpinion As PreguntaOpinionEntidad.TipoRespuestasCalidad = dr.Item("Valor_Respuesta")
    '        _listaRespuestas.Add(_MirespuestaOpinion)
    '    Next
    '    Return _listaRespuestas
    'Catch ex As Exception
    '    Throw ex
    'End Try
    'End Function


    Public Function obtenerPreguntas() As List(Of PreguntaOpinionEntidad)
        Try
            Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
            Dim consulta As String = "	select * from pregunta_opinion where BL=@BL"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each dr As DataRow In _dt.Rows
                Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
                Me.FormatearPreguntaOpinion(_MiPreguntaOpinion, dr)
                _listapreguntaopinion.Add(_MiPreguntaOpinion)
            Next
            Return _listapreguntaopinion
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function TraerRespuestas(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of RespuestaEntidad)
        Try
            Dim consulta As String = "Select * from Respuesta_Opinion where ID_Pregunta=@ID_Pregunta"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))

            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaRespuesta As List(Of RespuestaEntidad) = New List(Of RespuestaEntidad)
            For Each row As DataRow In dt.Rows
                Dim _resp As RespuestaEntidad = New RespuestaEntidad
                FormatearRespuestaOpinion(_resp, row)
                ListaRespuesta.Add(_resp)
            Next
            Return ListaRespuesta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FormatearRespuestaOpinion(ByVal paramRespuesta As RespuestaEntidad, ByVal row As DataRow)
        Try
            paramRespuesta.ID_Respuesta = row("ID_Respuesta")
            paramRespuesta.Pregunta = New Entidades.PreguntaOpinionEntidad With {.ID = row("ID_Pregunta")}
            paramRespuesta.Usuario = New Entidades.UsuarioEntidad With {.ID_Usuario = row("ID_Usuario")}
            paramRespuesta.Valor_Respuesta = row("Valor_Respuesta")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    'Public Function obtenerPreguntas(ByVal paramTipoPregunta As PreguntaOpinionEntidad.TipoRespuestasFichaOpinion) As List(Of PreguntaOpinionEntidad)
    '    Try
    '        Dim _listapreguntaopinion As New List(Of PreguntaOpinionEntidad)
    '        Dim consulta As String = " Select * from Pregunta_Opinion where Tipo=@TipoPregunta and BL=@BL"
    '        Dim Command As SqlCommand = Acceso.MiComando(consulta)
    '        With Command.Parameters
    '            .Add(New SqlParameter("@BL", False))
    '            .Add(New SqlParameter("@TipoPregunta", paramTipoPregunta))
    '        End With
    '        Dim _dt As DataTable = Acceso.Lectura(Command)
    '        For Each dr As DataRow In _dt.Rows
    '            Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
    '            Me.FormatearPreguntaOpinion(_MiPreguntaOpinion, dr)
    '            _listapreguntaopinion.Add(_MiPreguntaOpinion)
    '        Next
    '        Return _listapreguntaopinion
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function


    Public Function obtenerPreguntas(ByVal paramPregunta As PreguntaOpinionEntidad) As PreguntaOpinionEntidad
        Try
            Dim consulta As String = " select * from Pregunta_Opinion where ID_Pregunta=@ID_Pregunta and BL=@BL"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)
            If _dt.Rows.Count = 1 Then
                Dim _MiPreguntaOpinion As New PreguntaOpinionEntidad
                Me.FormatearPreguntaOpinion(_MiPreguntaOpinion, _dt.Rows(0))
                Return _MiPreguntaOpinion
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    'Public Function obtenerRespuestasFO(ByVal paramPregunta As PreguntaOpinionEntidad) As List(Of PreguntaOpinionEntidad.TipoRespuestasFichaOpinion)
    '    Try
    '        Dim _listaRespuestas As New List(Of PreguntaOpinionEntidad.TipoRespuestasFichaOpinion)
    '        Dim consulta As String = "select Valor_Respuesta from respuesta_opinion where ID_Pregunta=@ID_Pregunta"
    '        Dim Command As SqlCommand = Acceso.MiComando(consulta)
    '        With Command.Parameters
    '            .Add(New SqlParameter("@ID_Pregunta", paramPregunta.ID))
    '        End With
    '        Dim _dt As DataTable = Acceso.Lectura(Command)
    '        For Each dr As DataRow In _dt.Rows
    '            Dim _MirespuestaOpinion As PreguntaOpinionEntidad.TipoRespuestasFichaOpinion = dr.Item("Valor_Respuesta")
    '            _listaRespuestas.Add(_MirespuestaOpinion)
    '        Next
    '        Return _listaRespuestas
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

















End Class
