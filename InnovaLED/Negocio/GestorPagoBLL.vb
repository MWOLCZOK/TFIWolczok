﻿Imports Entidades
Imports Mapper



Public Class GestorPagoBLL

    Dim pagoMPP As New PagoMPP

    Public Function Alta(ByVal pago As PagoEntidad, Optional ByVal notas As List(Of DocumentoFinancieroEntidad) = Nothing) As Boolean
        Try
            Return pagoMPP.Alta(pago, notas)
        Catch ex As Exception
        End Try
    End Function

    Public Function ConsultaTarjeta(ByVal Nro_Tarjeta As String, ByVal Nombre_Ape As String, ByVal Fecha_expiracion As String, ByVal Codigo_Seguridad As Integer)
        Try
            Return pagoMPP.ConsultaTarjeta(Nro_Tarjeta, Nombre_Ape, Fecha_expiracion, Codigo_Seguridad)
        Catch ex As Exception

        End Try
    End Function



End Class
