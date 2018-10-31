Imports Entidades
Imports Mapper



Public Class GestorFacturaBLL

    Dim facturaMPP As New FacturaMPP

    Public Function GenerarFactura(ByVal cliente As UsuarioEntidad, ByVal DetalleCompra As CompraEntidad, ByVal fact As FacturaEntidad) As Boolean
        Return facturaMPP.Alta(cliente, DetalleCompra, fact)

    End Function

End Class
