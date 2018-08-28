Public Class Bitacora

    Private _id_bitacora As Integer
    Public Property Id_Bitacora() As Integer
        Get
            Return _id_bitacora
        End Get
        Set(ByVal value As Integer)
            _id_bitacora = value
        End Set
    End Property

    Private _detalle As String
    Public Property Detalle() As String
        Get
            Return _detalle
        End Get
        Set(ByVal value As String)
            _detalle = value
        End Set
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
    Private _usuario As Entidades.UsuarioEntidad
    Public Property Usuario() As Entidades.UsuarioEntidad
        Get
            Return _usuario
        End Get
        Set(ByVal value As Entidades.UsuarioEntidad)
            _usuario = value
        End Set
    End Property

    Private _ip_usuario As String
    Public Property IP_Usuario() As String
        Get
            Return _ip_usuario
        End Get
        Set(ByVal value As String)
            _ip_usuario = value
        End Set
    End Property


    Private _browser As String
    Public Property Browser() As String
        Get
            Return _browser
        End Get
        Set(ByVal value As String)
            _browser = value
        End Set
    End Property

    Private _tipo_bitacora As Tipo_Bitacora
    Public Property Tipo_Bitacora() As Tipo_Bitacora
        Get
            Return _tipo_bitacora
        End Get
        Set(ByVal value As Tipo_Bitacora)
            _tipo_bitacora = value
        End Set
    End Property


    'Sub New(ByVal Midetalle As String, ByVal micodigo As Tipo_Bitacora, ByRef Usuario As UsuarioEntidad)
    '    Me.Detalle = Midetalle
    '    Me.Tipo_Bitacora = micodigo
    '    Me.Usuario = Usuario
    'End Sub


    Private _valor_anterior As String
    Public Property Valor_Anterior() As String
        Get
            Return _valor_anterior
        End Get
        Set(ByVal value As String)
            _valor_anterior = value
        End Set
    End Property

    Private _valor_posterior As String
    Public Property Valor_Posterior() As String
        Get
            Return _valor_posterior
        End Get
        Set(ByVal value As String)
            _valor_posterior = value
        End Set
    End Property

    Sub New(ByRef usu As UsuarioEntidad, ByVal detalle As String, ByVal Tipo_bit As Tipo_Bitacora, ByVal fec As DateTime, ByVal brws As String, ByVal IP As String, ByVal ValorAnterior As String, ByVal ValorPosterior As String, ByVal stack As String, ByVal exception As String, ByVal url As String)
        Me.Usuario = usu
        Me.Detalle = detalle
        Me.Tipo_Bitacora = Tipo_bit
        Me.Fecha = fec
        Me.Browser = brws
        Me.IP_Usuario = IP
        Me.Valor_Anterior = ValorAnterior
        Me.Valor_Posterior = ValorPosterior
        Me.StackTrace = stack
        Me.Exception = exception
        Me.URL = url

    End Sub

    
    Private _url As String
    Public Property URL() As String
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property

    Private _stacktrace As String
    Public Property StackTrace() As String
        Get
            Return _stacktrace
        End Get
        Set(ByVal value As String)
            _stacktrace = value
        End Set
    End Property
    Private _exception As String


    Public Property Exception() As String
        Get
            Return _exception
        End Get
        Set(ByVal value As String)
            _exception = value
        End Set
    End Property

    Sub New()

    End Sub




End Class
