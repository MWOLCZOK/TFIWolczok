Imports Entidades
Imports Mapper



Public Class GestorPagoBLL

    Dim pagoMPP As New PagoMPP

    Public Function Alta(ByVal DetalleCompra As CompraEntidad, ByVal Fact As FacturaEntidad) As Boolean
        Try
            Return pagoMPP.Alta(DetalleCompra, Fact)
        Catch ex As Exception
        End Try
    End Function



End Class
