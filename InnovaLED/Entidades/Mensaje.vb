Public Class Mensaje

    Private _id_Mensaje As Integer
    Public Property ID_Mensaje() As Integer
        Get
            Return _id_Mensaje
        End Get
        Set(ByVal value As Integer)
            _id_Mensaje = value
        End Set
    End Property

    Private _asunto As String
    Public Property Asunto() As String
        Get
            Return _asunto
        End Get
        Set(ByVal value As String)
            _asunto = value
        End Set
    End Property

    Private _texto As String
    Public Property Texto() As String
        Get
            Return _texto
        End Get
        Set(ByVal value As String)
            _texto = value
        End Set
    End Property

    Private _emisor As Entidades.UsuarioEntidad
    Public Property Emisor() As Entidades.UsuarioEntidad
        Get
            Return _emisor
        End Get
        Set(ByVal value As Entidades.UsuarioEntidad)
            _emisor = value
        End Set
    End Property

    Private _receptor As Entidades.UsuarioEntidad
    Public Property Receptor() As Entidades.UsuarioEntidad
        Get
            Return _receptor
        End Get
        Set(ByVal value As Entidades.UsuarioEntidad)
            _receptor = value
        End Set
    End Property

    Private _fecha_hora_envio As DateTime
    Public Property Fecha_Hora_Envio() As DateTime
        Get
            Return _fecha_hora_envio
        End Get
        Set(ByVal value As DateTime)
            _fecha_hora_envio = value
        End Set
    End Property


    Private _fecha_hora_leido As DateTime
    Public Property Fecha_Hora_Leido() As DateTime
        Get
            Return _fecha_hora_leido
        End Get
        Set(ByVal value As DateTime)
            _fecha_hora_leido = value
        End Set
    End Property


    Private _bl_Emisor As Boolean
    Public Property BL_Emisor() As Boolean
        Get
            Return _bl_Emisor
        End Get
        Set(ByVal value As Boolean)
            _bl_Emisor = value
        End Set
    End Property

    Private _bl_Receptor As Boolean
    Public Property BL_Receptor() As Boolean
        Get
            Return _bl_Receptor
        End Get
        Set(ByVal value As Boolean)
            _bl_Receptor = value
        End Set
    End Property

    Private _leido As Boolean
    Public Property Leido() As Boolean
        Get
            Return _leido
        End Get
        Set(ByVal value As Boolean)
            _leido = value
        End Set
    End Property

    Private _mensajePadre As Mensaje
    Public Property mensajePadre() As Mensaje
        Get
            Return _mensajePadre
        End Get
        Set(ByVal value As Mensaje)
            _mensajePadre = value
        End Set
    End Property


End Class
