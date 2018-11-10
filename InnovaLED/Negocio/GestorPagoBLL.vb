Imports Entidades
Imports Mapper



Public Class GestorPagoBLL

    Dim pagoMPP As New PagoMPP

    Public Function Alta(ByVal pago As PagoEntidad, Optional ByVal notas As List(Of DocumentoFinancieroEntidad) = Nothing) As Boolean
        Try
            Return pagoMPP.Alta(pago, notas)
        Catch ex As Exception
        End Try
    End Function



End Class
