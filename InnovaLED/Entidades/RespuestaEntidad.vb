Public Class RespuestaEntidad



    Private _respuestaEncuesta As RespuestaEncuestaEntidad
    Public Property RespuestaEncuesta As RespuestaEncuestaEntidad
        Get
            Return _respuestaEncuesta
        End Get
        Set(ByVal value As RespuestaEncuestaEntidad)
            _respuestaEncuesta = value
        End Set
    End Property



    Private _id As Integer
    Public Property ID_Respuesta() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _pregunta As PreguntaOpinionEntidad
    Public Property Pregunta() As PreguntaOpinionEntidad
        Get
            Return _pregunta
        End Get
        Set(ByVal value As PreguntaOpinionEntidad)
            _pregunta = value
        End Set
    End Property

    Private _id_usuario As UsuarioEntidad
    Public Property Usuario() As UsuarioEntidad
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As UsuarioEntidad)
            _id_usuario = value
        End Set
    End Property

    Private _Valor_Respuesta As Integer
    Public Property Valor_Respuesta() As Integer
        Get
            Return _Valor_Respuesta
        End Get
        Set(ByVal value As Integer)
            _Valor_Respuesta = value
        End Set
    End Property




End Class
