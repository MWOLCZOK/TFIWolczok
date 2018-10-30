Imports System.Data.SqlClient
Imports Entidades
Imports DAL


Public Class GestorDocumentoMPP

    Public Function TraerDocumentoF(ByVal usu As UsuarioEntidad) As List(Of DocumentoFinancieroEntidad)
        Try

            Dim consulta As String = "Select * from DocFinancieroEntidad where ID_Usuario=@ID_Usuario "
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", usu.ID_Usuario))
                '.Add(New SqlParameter("@ID_Doc", nc.ID))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaNC As List(Of DocumentoFinancieroEntidad) = New List(Of DocumentoFinancieroEntidad)
            For Each row As DataRow In dt.Rows
                Dim nc As DocumentoFinancieroEntidad = New DocumentoFinancieroEntidad
                FormatearDocumento(nc, row)
                ListaNC.Add(nc)
            Next
            Return ListaNC
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Sub FormatearDocumento(ByVal nc As DocumentoFinancieroEntidad, ByVal row As DataRow)
        Try
            nc.ID = row("ID_Doc")
            nc.Descripcion = row("Descripcion")
            nc.Monto = row("Monto")
            nc.Tipo_Documento = row("Tipo")
            nc.Usuario = (New Mapper.UsuarioMPP).BuscarUsuarioID(New Entidades.UsuarioEntidad With {.ID_Usuario = row("ID_Usuario")})
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




End Class
