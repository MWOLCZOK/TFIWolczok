Public Class DocumentoFinanciero

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

    Private _nro As Integer
    Public Property Nro_nota() As Integer
        Get
            Return _nro
        End Get
        Set(ByVal value As Integer)
            _nro = value
        End Set
    End Property


    Public Enum TipoDocumento
        Positivo = 1 ' Credito
        Negativo = 2 ' Debito

    End Enum

End Class
