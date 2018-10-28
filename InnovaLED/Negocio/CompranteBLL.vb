Imports Mapper
Imports Entidades



Public Class CompranteBLL

    'Dim comprobantempp As New ComprobanteMPP
    'Public Function altaComprobante(ByVal paramComprobante As Entidades.Comprobante) As Integer
    '    Try
    '        Return comprobantempp.altaComprobante(paramComprobante)
    '    Catch ex As Exception
    '        Throw New BLL.excepcionGenerica
    '    End Try
    'End Function

    'Public Function obtenerComprobanteNFactura(ByVal paramComprobante As Entidades.Comprobante) As Entidades.Comprobante
    '    Try
    '        Dim _comprobante As Entidades.Comprobante = _mpp.obtenerComprobanteNFactura(paramComprobante)
    '        _comprobante.valorTotal = _comprobante.Subtotal + _comprobante.IVA
    '        Dim _gestorNota As New BLL.NotaBLL
    '        For Each _nota As Entidades.Nota In _comprobante.Notas
    '            _comprobante.valorTotal = _comprobante.valorTotal - _nota.Descuento
    '        Next
    '        Return _comprobante
    '    Catch ex As Exception
    '        Throw New BLL.excepcionGenerica
    '    End Try
    'End Function

    'Public Function obtenerComprobante(ByVal paramComprobante As Entidades.Comprobante) As Entidades.Comprobante
    '    Try
    '        Return _mpp.obtenerComprobante(paramComprobante)
    '    Catch ex As Exception
    '        Throw New BLL.excepcionGenerica
    '    End Try
    'End Function

    'Public Function obtenerComprobante(ByVal paramPersona As Entidades.Persona) As List(Of Entidades.Comprobante)
    '    Try
    '        Return _mpp.obtenerComprobante(paramPersona)
    '    Catch ex As Exception
    '        Throw New BLL.excepcionGenerica
    '    End Try
    'End Function

    'Public Function obtenerComprobantesinPago(ByVal paramPersona As Entidades.Persona) As List(Of Entidades.Comprobante)
    '    Try
    '        Return _mpp.obtenerComprobantesinPago(paramPersona)
    '    Catch ex As Exception
    '        Throw New BLL.excepcionGenerica
    '    End Try
    'End Function

    'Public Function obtenerComprobante() As List(Of Entidades.Comprobante)
    '    Try
    '        Return _mpp.obtenerComprobante()
    '    Catch ex As Exception
    '        Throw New BLL.excepcionGenerica
    '    End Try
    'End Function





End Class
