﻿Imports Entidades
Imports Mapper



Public Class GestorFacturaBLL

    Dim facturaMPP As New FacturaMPP

    Public Function GenerarFactura(ByVal fact As FacturaEntidad) As Boolean
        Return facturaMPP.Alta(fact)

    End Function

    Public Function TraerFacturasGestion() As List(Of FacturaEntidad)
        Return facturaMPP.TraerFacturasGestion()
    End Function

    Public Function TraerFacturasGestionxMes(ByVal paramMes As Integer) As List(Of FacturaEntidad)
        Return facturaMPP.TraerFacturasGestionxMes(paramMes)
    End Function

    Public Function ModificarFactura(facturaEntidad As FacturaEntidad) As Boolean
        Return facturaMPP.ModificarFactura(facturaEntidad)
    End Function

    Public Function TraerFacturasGestionPorUsuario(ByVal usu As UsuarioEntidad) As List(Of FacturaEntidad)
        Return facturaMPP.TraerFacturasGestionPorUsuario(usu)
    End Function

    Public Function ModificarFacturaPDF(ByVal fact As FacturaEntidad)
        Return facturaMPP.ModificarFacturaPDF(fact)
    End Function


End Class
