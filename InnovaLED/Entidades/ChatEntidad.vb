Public Class ChatEntidad
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _usuario As UsuarioEntidad
    Public Property Usuario() As UsuarioEntidad
        Get
            Return _usuario
        End Get
        Set(ByVal value As UsuarioEntidad)
            _usuario = value
        End Set
    End Property
    Private _empleado As UsuarioEntidad
    Public Property Empleado() As UsuarioEntidad
        Get
            Return _empleado
        End Get
        Set(ByVal value As UsuarioEntidad)
            _empleado = value
        End Set
    End Property

    Private _mensajechat As New List(Of MensajeChatEntidad)
    Public Property MensajesChat() As List(Of MensajeChatEntidad)
        Get
            Return _mensajechat
        End Get
        Set(ByVal value As List(Of MensajeChatEntidad))
            _mensajechat = value
        End Set
    End Property

End Class
