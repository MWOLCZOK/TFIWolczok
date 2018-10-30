Imports Entidades
Imports System.Data.SqlClient
Imports DAL

Public Class ClienteMPP


    Public Function obtenerCliente(ByVal cliente As ClienteEntidad) As ClienteEntidad
        Try
            Dim consulta As String = "Select * from ClienteEntidad where ID_Cliente=@ID_Cliente"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Cliente", cliente.ID_Cliente))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                FormatearCliente(cliente, dt.Rows(0))
                Return cliente
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub FormatearCliente(ByVal cliente As ClienteEntidad, ByVal row As DataRow)

        Try
            cliente.ID_Cliente = row("ID_Cliente")
            cliente.DomicilioFacturacion = row("DomicilioFacturacion")
            Dim usu As New UsuarioEntidad
            usu.Nombre = row("Nombre")
            usu.Apellido = row("Apellido")
            usu.DNI = row("DNI")
            usu.Mail = row("Mail")
            cliente.Telefono = row("Telefono")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
