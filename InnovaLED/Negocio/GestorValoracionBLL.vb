Imports Entidades
Imports Mapper



Public Class GestorvaloracionBLL

    Dim valoracionMPP As New valoracionMPP

    Public Function GenerarValoracion(ByVal coment As ValoracionEntidad) As Boolean
        Return valoracionMPP.Alta(coment)

    End Function
    Public Function BuscarvaloracionsProd(ByVal prod As ProductoEntidad) As List(Of ValoracionEntidad)
        Return valoracionMPP.BuscarvaloracionsProd(prod)

    End Function

    Public Function PuedeValorar(prod As ProductoEntidad, usu As UsuarioEntidad) As Boolean
        Return valoracionMPP.PuedeValorar(prod, usu)
    End Function
End Class
