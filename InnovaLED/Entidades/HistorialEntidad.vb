Public Class HistorialEntidad
    Private _nroDoc As Integer
    Public Property NroDoc() As Integer
        Get
            Return _nroDoc
        End Get
        Set(ByVal value As Integer)
            _nroDoc = value
        End Set
    End Property

    Private _TipoDoc As String
    Public Property Documento() As String
        Get
            Return _TipoDoc
        End Get
        Set(ByVal value As String)
            _TipoDoc = value
        End Set
    End Property

    Private _fechaEmision As Date
    Public Property FechaEmision() As Date
        Get
            Return _fechaEmision
        End Get
        Set(ByVal value As Date)
            _fechaEmision = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _estado As String
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property

    Private _debe As Single
    Public Property Debe() As Single
        Get
            Return _debe
        End Get
        Set(ByVal value As Single)
            _debe = value
        End Set
    End Property

    Private _haber As Single
    Public Property Haber() As Single
        Get
            Return _haber
        End Get
        Set(ByVal value As Single)
            _haber = value
        End Set
    End Property

    Private _pdf As Byte()
    Public Property PDF() As Byte()
        Get
            Return _pdf
        End Get
        Set(ByVal value As Byte())
            _pdf = value
        End Set
    End Property


    Public Overrides Function Equals(obj As Object) As Boolean
        Return Me._TipoDoc & " " & FechaEmision
    End Function


End Class
