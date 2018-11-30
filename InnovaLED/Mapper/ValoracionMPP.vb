Imports DAL
Imports Entidades
Imports System.Data.SqlClient




Public Class valoracionMPP


    Public Function Alta(ByVal valora As ValoracionEntidad) As Boolean
        Try
            Dim consulta2 As String = "Select Factura_Renglones.ID_Fact from Factura_Renglones inner join Factura on Factura.ID_Fact=Factura_Renglones.ID_Fact where ID_Prod=@ID_Producto and ID_Cliente=@ID_Usuario and not exists(select ID_Valoracion from Valoracion_Producto where Factura_Renglones.ID_Fact=ID_Factura and ID_Prod=ID_Producto)"
            Dim Command2 As SqlCommand = Acceso.MiComando(consulta2)
            With Command2.Parameters
                .Add(New SqlParameter("@ID_Producto", valora.Producto.ID_Producto))
                .Add(New SqlParameter("@ID_Usuario", valora.Usuario.ID_Usuario))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command2)
            If dt.Rows.Count > 0 Then
                valora.FacturaID = dt.Rows(0)("ID_Fact")
            End If
            Dim Command As SqlCommand = Acceso.MiComando("insert into Valoracion_Producto (ID_Producto,ID_Usuario,Fecha,Texto,Puntaje,ID_Factura) values (@ID_Producto, @ID_Usuario,@Fecha,@Texto, @Puntaje,@ID_Factura)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", valora.Producto.ID_Producto))
                .Add(New SqlParameter("@ID_Usuario", valora.Usuario.ID_Usuario))
                .Add(New SqlParameter("@Fecha", Now))
                .Add(New SqlParameter("@Texto", valora.Texto))
                .Add(New SqlParameter("@Puntaje", valora.Valor))
                .Add(New SqlParameter("@ID_Factura", valora.FacturaID))
            End With

            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PuedeValorar(prod As ProductoEntidad, usu As UsuarioEntidad) As Boolean
        Try
            Dim consulta As String = "Select Factura_Renglones.ID_Fact from Factura_Renglones inner join Factura on Factura.ID_Fact=Factura_Renglones.ID_Fact where ID_Prod=@ID_Producto and ID_Cliente=@ID_Usuario and not exists(select ID_Valoracion from Valoracion_Producto where Factura_Renglones.ID_Fact=ID_Factura and ID_Prod=ID_Producto)"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", prod.ID_Producto))
                .Add(New SqlParameter("@ID_Usuario", usu.ID_Usuario))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarvaloracionsProd(ByVal Prod As ProductoEntidad) As List(Of ValoracionEntidad)
        Try
            Dim consulta As String = "Select * from valoracion_Producto where ID_Producto=@ID_Producto order by Fecha"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", Prod.ID_Producto))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim listavaloracion As New List(Of ValoracionEntidad)
            For Each _dr As DataRow In dt.Rows
                Dim _valoracion As New ValoracionEntidad
                Formatearvaloracion(_valoracion, _dr)
                listavaloracion.Add(_valoracion)
            Next
            Return listavaloracion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Buscarvaloracionsid(ByVal id As Integer) As ValoracionEntidad
        Try
            Dim consulta As String = "Select * from valoracion_Producto where ID_valoracion=@ID_valoracion"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_valoracion", id))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                Dim valoracion As New ValoracionEntidad
                Formatearvaloracion(valoracion, dt.Rows(0))
                Return valoracion
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub Formatearvaloracion(ByVal valora As ValoracionEntidad, ByVal row As DataRow)
        Try
            valora.ID = row("ID_valoracion")
            valora.Usuario = (New UsuarioMPP).BuscarUsuarioID(New UsuarioEntidad With {.ID_Usuario = row("ID_Usuario")})
            valora.Producto = (New ProductoMPP).TraerProducto(New ProductoEntidad With {.ID_Producto = row("ID_Producto")})
            valora.Texto = row("Texto")
            valora.Fecha = row("Fecha")
            valora.Valor = row("Puntaje")
            valora.FacturaID = row("ID_Factura")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub








End Class
