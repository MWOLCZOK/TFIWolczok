Imports Entidades
Imports Mapper



Public Class GestorPagoBLL

    Dim pagoMPP As New PagoMPP

    Public Function Alta(ByVal pago As PagoEntidad) As Boolean
        Try
            Return pagoMPP.Alta(pago)
        Catch ex As Exception
        End Try
    End Function



End Class
