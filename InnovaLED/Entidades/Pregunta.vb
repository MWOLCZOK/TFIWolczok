Public Class Pregunta

    Public Enum eTipoPregunta
        Opinion = 1
        Desarrollo = 2
    End Enum

    Private _idPregunta As Integer
    Public Property ID_Pregunta() As Integer
        Get
            Return _idPregunta
        End Get
        Set(ByVal value As Integer)
            _idPregunta = value
        End Set
    End Property

    Private _enunciado As String
    Public Property Enunciado() As String
        Get
            Return _enunciado
        End Get
        Set(ByVal value As String)
            _enunciado = value
        End Set
    End Property

    Private _tipoPregunta As eTipoPregunta
    Public Property tipoPregunta() As eTipoPregunta
        Get
            Return _tipoPregunta
        End Get
        Set(ByVal value As eTipoPregunta)
            _tipoPregunta = value
        End Set
    End Property

    Private _respuesta As Respuesta
    Public Property respuesta() As Respuesta
        Get
            Return _respuesta
        End Get
        Set(ByVal value As Respuesta)
            _respuesta = value
        End Set
    End Property
End Class
