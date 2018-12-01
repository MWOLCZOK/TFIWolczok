Imports DAL
Imports Entidades
Imports System.Data.SqlClient


Public Class BusquedaMPP

    Public Function BusquedaGlobal(ByVal Palabra As String) As List(Of String)
        Try
            Dim consulta As String = "Select * from PermisoBaseEntidad where URL like '%'+ @Palabra + '%'"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@Palabra", Palabra))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim lista As New List(Of String)
            For Each _dr As DataRow In dt.Rows
                Dim _palabra As String = _dr("URL")
                lista.Add(_palabra)
            Next
            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
