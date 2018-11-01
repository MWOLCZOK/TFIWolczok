Imports Entidades
Imports Mapper



Public Class GestorFacturaBLL

    Dim facturaMPP As New FacturaMPP

    Public Function GenerarFactura(ByVal fact As FacturaEntidad) As Boolean
        Return facturaMPP.Alta(fact)

    End Function

End Class
