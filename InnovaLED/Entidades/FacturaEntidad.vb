
Public Class FacturaEntidad

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _cliente As UsuarioEntidad
    Public Property Cliente() As UsuarioEntidad
        Get
            Return _cliente
        End Get
        Set(ByVal value As UsuarioEntidad)
            _cliente = value
        End Set
    End Property

    Private _detalleFactura As List(Of CompraEntidad)
    Public Property DetalleFactura() As List(Of CompraEntidad)
        Get
            Return _detalleFactura
        End Get
        Set(ByVal value As List(Of CompraEntidad))
            _detalleFactura = value
        End Set
    End Property

    Private _montototal As Single
    Public ReadOnly Property MontoTotal() As Single
        Get
            Dim sum As Single
            For Each _subt In Me.DetalleFactura
                sum += _subt.Subtotal
            Next
            Return sum
        End Get

    End Property

    Private _fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _tipo_pago As Tipo_PagoEntidad
    Public Property Tipo_Pago() As Tipo_PagoEntidad
        Get
            Return _tipo_pago
        End Get
        Set(ByVal value As Tipo_PagoEntidad)
            _tipo_pago = value
        End Set
    End Property

    Private _estado As EstadoCompraEntidad
    Public Property Estado() As EstadoCompraEntidad
        Get
            Return _estado
        End Get
        Set(ByVal value As EstadoCompraEntidad)
            _estado = value
        End Set
    End Property



End Class
