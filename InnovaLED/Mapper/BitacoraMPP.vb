Public Class BitacoraMPP


    Public Function GuardarBitacora(ByRef Bitacora As Entidades.Bitacora) As Boolean

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
            Bita.StackTrace = row("Stacktrace")
            Bita.Exception = row("Exception")
            Dim usu As New Entidades.UsuarioEntidad
            usu.ID_Usuario = row("ID_Usuario")
            Bita.Usuario = New UsuarioMPP().BuscarUsuarioIDBitacora(usu)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub






End Class
