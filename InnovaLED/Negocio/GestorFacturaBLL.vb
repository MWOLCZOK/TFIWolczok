Imports Entidades
Imports Mapper



Public Class GestorFacturaBLL

    Dim facturaMPP As New FacturaMPP

    Public Function GenerarFactura(ByVal cliente As UsuarioEntidad, ByVal DetalleCompra As CompraEntidad)
        Return facturaMPP.Alta(cliente, DetalleCompra)

    End Function

End Class
