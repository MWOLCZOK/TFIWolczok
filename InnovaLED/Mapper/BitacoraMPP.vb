Imports System.Data.Sql
Imports System.Data.SqlClient
Imports DAL




Public Class BitacoraMPP


    Public Function GuardarBitacora(ByRef Bitacora As Entidades.Bitacora) As Boolean
        Try
            Dim Command As SqlCommand

            Command = Acceso.MiComando("insert into BitacoraEntidad (Tipo_Bitacora, Fecha, Detalle, ID_Usuario,IP_Usuario, WebBrowser, Valor_Anterior, Valor_Posterior) Output Inserted.ID_Bitacora values (@Tipo_Bitacora,@Fecha,@Descripcion,@id_usuario,@iP_usuario, @Browser,@Valor_Anterior,@Valor_Posterior)")
            With Command.Parameters
                .Add(New SqlParameter("@Valor_Anterior", Bitacora.Valor_Anterior))
                .Add(New SqlParameter("@Valor_Posterior", Bitacora.Valor_Posterior))
                .Add(New SqlParameter("@Descripcion", Bitacora.Detalle))
                .Add(New SqlParameter("@Fecha", Bitacora.Fecha))
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

    End Function


    Public Sub FormatearBitacora(ByVal Bita As Entidades.Bitacora, ByVal row As DataRow)
        Try
            Bita.Browser = row("WebBrowser")
            Bita.Detalle = row("Detalle")
            Bita.Fecha = row("Fecha")
            Bita.Id_Bitacora = row("ID_Bitacora_Auditoria")
            Bita.IP_Usuario = row("IP_Usuario")
            Bita.Tipo_Bitacora = row("Tipo_Bitacora")
            Bita.Valor_Anterior = row("Valor_Anterior")
            Bita.Valor_Posterior = row("Valor_Posterior")
            Bita.URL = row("URL")
            Dim usu As New Entidades.UsuarioEntidad
            usu.ID_Usuario = row("ID_Usuario")
            Bita.Usuario = New UsuarioMPP().BuscarUsuarioIDBitacora(usu)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub






End Class
