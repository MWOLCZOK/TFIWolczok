Imports Mapper
Imports Entidades


Public Class BusquedaBLL

    Dim busquedaMPP As New BusquedaMPP

    Public Function BusquedaGlobal(ByVal palabra As String) As List(Of String)
        Return busquedaMPP.BusquedaGlobal(palabra)
    End Function



End Class
