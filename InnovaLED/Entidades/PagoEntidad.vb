Public Class PagoEntidad

    Private _id As Integer
    Public Property ID_Pago() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _factura As FacturaEntidad
    Public Property Factura() As FacturaEntidad
        Get
            Return _factura
        End Get
        Set(ByVal value As FacturaEntidad)
            _factura = value
        End Set
    End Property

    Private _fechaPago As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _fechaPago
        End Get
        Set(ByVal value As DateTime)
            _fechaPago = value
        End Set
    End Property

    Private _monto As Single
    Public Property Monto() As Single
        Get
            Return _monto
        End Get
        Set(ByVal value As Single)
            _monto = value
        End Set
    End Property

    Private _tipoPago As Tipo_PagoEntidad
    Public Property TipoPago() As Tipo_PagoEntidad
        Get
            Return _tipoPago
        End Get
        Set(ByVal value As Tipo_PagoEntidad)
            _tipoPago = value
        End Set
    End Property




End Class
