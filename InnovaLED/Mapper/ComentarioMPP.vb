Imports DAL
Imports Entidades
Imports System.Data.SqlClient




Public Class ComentarioMPP


    Public Function Alta(ByVal comen As ComentarioEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Comentario_Producto (ID_Producto,ID_Usuario,Fecha,Texto,ID_Comentario_Pregunta) values (@ID_Producto, @ID_Usuario,@Fecha,@Texto, @ID_Comentario_Pregunta)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", comen.Producto.ID_Producto))
                .Add(New SqlParameter("@ID_Usuario", comen.Usuario.ID_Usuario))
                .Add(New SqlParameter("@Fecha", Now))
                .Add(New SqlParameter("@Texto", comen.Texto))
                If IsNothing(comen.Pregunta) Then
                    .Add(New SqlParameter("@ID_Comentario_Pregunta", DBNull.Value))
                Else
                    .Add(New SqlParameter("@ID_Comentario_Pregunta", comen.Pregunta.ID))
                End If
            End With

            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function BuscarComentariosSinRespuesta() As List(Of ComentarioEntidad)
        Try
            Dim consulta As String = "Select * from Comentario_Producto as cp1  left join Comentario_Producto as cp2 on cp1.ID_Comentario=cp2.ID_Comentario_Pregunta where cp1.ID_Comentario_Pregunta is null and cp2.ID_Comentario is null"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim listacomentario As New List(Of ComentarioEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _comentario As New ComentarioEntidad
                FormatearComentario(_comentario, _dr)
                listacomentario.Add(_comentario)
            Next
            Return listacomentario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarComentariosProd(ByVal Prod As ProductoEntidad) As List(Of ComentarioEntidad)
        Try
            Dim consulta As String = "Select * from Comentario_Producto as cp1 left join Comentario_Producto as cp2 on cp1.ID_Comentario_Pregunta=cp2.ID_Comentario where cp1.ID_Producto=@ID_Producto order by case isnull(cp1.ID_comentario_pregunta,0) when 0 then cp1.fecha else cp2.Fecha end"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", Prod.ID_Producto))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim listacomentario As New List(Of ComentarioEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _comentario As New ComentarioEntidad
                FormatearComentario(_comentario, _dr)
                listacomentario.Add(_comentario)
            Next
            Return listacomentario
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BuscarComentariosid(ByVal id As Integer) As ComentarioEntidad
        Try
            Dim consulta As String = "Select * from Comentario_Producto where ID_Comentario=@ID_Comentario"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Comentario", id))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                Dim Comentario As New ComentarioEntidad
                FormatearComentario(Comentario, dt.Rows(0))
                Return Comentario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub FormatearComentario(ByVal com As ComentarioEntidad, ByVal row As DataRow)
        Try
            com.ID = row("ID_Comentario")
            com.Usuario = (New UsuarioMPP).BuscarUsuarioID(New UsuarioEntidad With {.ID_Usuario = row("ID_Usuario")})
            com.Producto = (New ProductoMPP).TraerProducto(New ProductoEntidad With {.ID_Producto = row("ID_Producto")})
            com.Texto = row("Texto")
            com.Fecha = row("Fecha")
            If Not IsDBNull(row("ID_Comentario_Pregunta")) Then
                com.Pregunta = Me.BuscarComentariosid(row("ID_Comentario_Pregunta"))
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub








End Class
