Public Class DocumentoFinancieroEntidad

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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

    Private _monto As Single
    Public Property Monto() As Single
        Get
            Return _monto
        End Get
        Set(ByVal value As Single)
            _monto = value
        End Set
    End Property

    Private _tipodocumento As TipoDocumento
    Public Property Tipo_Documento() As TipoDocumento
        Get
            Return _tipodocumento
        End Get
        Set(ByVal value As TipoDocumento)
            _tipodocumento = value
        End Set
    End Property


    Private _cliente As UsuarioEntidad
    Public Property Usuario() As UsuarioEntidad
        Get
            Return _cliente
        End Get
        Set(ByVal value As UsuarioEntidad)
            _cliente = value
        End Set
    End Property

    Private _fecha As DateTime
    Public Property Fecha_Emision() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Private _bl As Boolean
    Public Property BL() As Boolean
        Get
            Return _bl
        End Get
        Set(ByVal value As Boolean)
            _bl = value
        End Set
    End Property



End Class
