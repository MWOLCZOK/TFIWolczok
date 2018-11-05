Imports Entidades
Imports Mapper



Public Class GestorComentarioBLL

    Dim ComentarioMPP As New ComentarioMPP

    Public Function GenerarComentario(ByVal coment As ComentarioEntidad) As Boolean
        Return ComentarioMPP.Alta(coment)

    End Function
    Public Function BuscarComentariosProd(ByVal prod As ProductoEntidad) As List(Of ComentarioEntidad)
        Return ComentarioMPP.BuscarComentariosProd(prod)

    End Function
End Class
