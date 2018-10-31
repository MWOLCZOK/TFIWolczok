Public Class Factura_RenglonEntidad

    Private _id_fact_renglon As Integer
    Public Property ID_Fact_Renglon() As Integer
        Get
            Return _id_fact_renglon
        End Get
        Set(ByVal value As Integer)
            _id_fact_renglon = value
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

    Private _producto As ProductoEntidad
    Public Property Producto() As ProductoEntidad
        Get
            Return _producto
        End Get
        Set(ByVal value As ProductoEntidad)
            _producto = value
        End Set
    End Property

    Private _compra As CompraEntidad
    Public Property Compra() As CompraEntidad
        Get
            Return _compra
        End Get
        Set(ByVal value As CompraEntidad)
            _compra = value
        End Set
    End Property





End Class
