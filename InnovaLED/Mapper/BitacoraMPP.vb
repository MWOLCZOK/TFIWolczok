Imports System.Data.Sql
Imports System.Data.SqlClient
Imports DAL




Public Class BitacoraMPP


    Public Function GuardarBitacora(ByRef Bitacora As Entidades.Bitacora) As Boolean
        Try
            Dim Command As SqlCommand

            Command = Acceso.MiComando("insert into BitacoraEntidad (Tipo_Bitacora, Fecha, Detalle, ID_Usuario,IP_Usuario, WebBrowser, Valor_Anterior, Valor_Posterior, URL) Output Inserted.ID_Bitacora values (@Tipo_Bitacora,@Fecha,@Detalle,@id_usuario,@iP_usuario, @Browser,@Valor_Anterior,@Valor_Posterior,@URL)")
            With Command.Parameters
                .Add(New SqlParameter("@Valor_Anterior", Bitacora.Valor_Anterior))
                .Add(New SqlParameter("@Valor_Posterior", Bitacora.Valor_Posterior))
                .Add(New SqlParameter("@Detalle", Bitacora.Detalle))
                .Add(New SqlParameter("@Fecha", Bitacora.Fecha))
                .Add(New SqlParameter("@URL", Bitacora.URL))
                If Not IsNothing(Bitacora.Usuario) Then
                    .Add(New SqlParameter("@id_usuario", Bitacora.Usuario.ID_Usuario))
                Else
                    .Add(New SqlParameter("@id_usuario", DBNull.Value))
                End If

                .Add(New SqlParameter("@Tipo_Bitacora", Bitacora.Tipo_Bitacora))
                .Add(New SqlParameter("@Browser", Bitacora.Browser))
                .Add(New SqlParameter("@IP_Usuario", Bitacora.IP_Usuario))
            End With
            Dim ListaParametros As New List(Of String)
            Bitacora.Id_Bitacora = Acceso.Scalar(Command)
            Command.Dispose()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarBitacora(Optional ByVal tipoBitacora As Entidades.Tipo_Bitacora = Nothing, Optional ByVal Desde As Date = Nothing, Optional ByVal Hasta As Date = Nothing, Optional ByRef Usu As Entidades.UsuarioEntidad = Nothing) As List(Of Entidades.Bitacora)
        Try
            Dim consulta As String = ""

            If Desde = DateTime.MinValue And Hasta = DateTime.MinValue Then
                consulta = "Select Top 50 "
            Else
                consulta = "Select "
            End If
            consulta += "URL, Valor_Anterior, Valor_Posterior, Detalle, Fecha, IP_Usuario, WebBrowser,Tipo_Bitacora, ID_Bitacora, ID_Usuario from BitacoraEntidad where Fecha between isnull(@desde,'19000101') and isnull(@hasta,'99990101') and ID_Usuario=isnull(@Usuario,ID_Usuario) and Tipo_Bitacora=isnull(@TipoBitacora,Tipo_Bitacora) order by ID_Bitacora DESC "

            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                If Not Desde = DateTime.MinValue And Not Hasta = DateTime.MinValue Then
                    .Add(New SqlParameter("@Desde", Desde))
                    .Add(New SqlParameter("@Hasta", Hasta))
                Else
                    .Add(New SqlParameter("@Desde", DBNull.Value))
                    .Add(New SqlParameter("@Hasta", DBNull.Value))
                End If
                If tipoBitacora > 0 Then
                    .Add(New SqlParameter("@TipoBitacora", tipoBitacora))
                Else
                    .Add(New SqlParameter("@TipoBitacora", DBNull.Value))
                End If
                If Not IsNothing(Usu) Then
                    If Usu.ID_Usuario > 0 Then
                        .Add(New SqlParameter("@Usuario", Usu.ID_Usuario))
                    Else
                        .Add(New SqlParameter("@Usuario", DBNull.Value))
                    End If
                Else
                    .Add(New SqlParameter("@Usuario", DBNull.Value))
                End If
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim listaBita As New List(Of Entidades.Bitacora)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim Bita As New Entidades.Bitacora
                    FormatearBitacora(Bita, dr)
                    listaBita.Add(Bita)
                Next
                Return listaBita
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub FormatearBitacora(ByVal Bita As Entidades.Bitacora, ByVal row As DataRow)
        Try
            Bita.Browser = row("WebBrowser")
            Bita.Detalle = row("Detalle")
            Bita.Fecha = row("Fecha")
            Bita.Id_Bitacora = row("ID_Bitacora")
            Bita.IP_Usuario = row("IP_Usuario")
            Bita.Tipo_Bitacora = row("Tipo_Bitacora")
            Bita.Valor_Anterior = row("Valor_Anterior")
            Bita.Valor_Posterior = row("Valor_Posterior")

            If Not IsDBNull(row("URL")) Then
                Bita.URL = row("URL")
            End If

            Dim usu As New Entidades.UsuarioEntidad
            usu.ID_Usuario = row("ID_Usuario")
            Bita.Usuario = New UsuarioMPP().BuscarUsuarioIDBitacora(usu)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




End Class
