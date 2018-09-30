Public Class Respuesta

    Public Enum eRespuestaOpinion
        Excelente = 1
        Bueno = 2
        Regular = 3
        Malo = 4
        Pesimo = 5
    End Enum

    Private _id_respuesta As Integer
    Public Property ID_Respuesta() As Integer
        Get
            Return _id_respuesta
        End Get
        Set(ByVal value As Integer)
            _id_respuesta = value
        End Set
    End Property

    Private _respuestaTexto As String
    Public Property respuestaTexto() As String
        Get
            Return _respuestaTexto
        End Get
        Set(ByVal value As String)
            _respuestaTexto = value
        End Set
    End Property


End Class
