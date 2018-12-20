Public Class Pregunta_Respuesta

    Private _id_Respuesta As Integer
    Public Property ID_Respuesta() As Integer
        Get
            Return _id_Respuesta
        End Get
        Set(ByVal value As Integer)
            _id_Respuesta = value
        End Set
    End Property

    Private _valor As Integer
    Public Property Valor_Respuesta() As Integer
        Get
            Return _valor
        End Get
        Set(ByVal value As Integer)
            _valor = value
        End Set
    End Property



End Class
