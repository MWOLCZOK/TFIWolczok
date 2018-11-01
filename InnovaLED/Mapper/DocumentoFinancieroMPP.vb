Imports System.Data.SqlClient
Imports Entidades
Imports DAL


Public Class DocumentoFinancieroMPP

    Public Function Alta(ByVal nota As DocumentoFinancieroEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into DocFinancieroEntidad (Descripcion,Monto,Tipo,ID_Usuario,BL) values (@Descripcion,@Monto,@Tipo,@ID_Usuario,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Descripcion", nota.Descripcion))
                .Add(New SqlParameter("@Monto", nota.Monto))
                .Add(New SqlParameter("@Tipo", nota.Tipo_Documento))
                .Add(New SqlParameter("@ID_Usuario", nota.Usuario.ID_Usuario))
                .Add(New SqlParameter("@BL", False))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function TraerDocumentoF(ByVal usu As UsuarioEntidad) As List(Of DocumentoFinancieroEntidad)
        Try

            Dim consulta As String = "Select * from DocFinancieroEntidad where ID_Usuario=@ID_Usuario and BL=0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", usu.ID_Usuario))
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


    Public Function Eliminar(ByRef nc As DocumentoFinancieroEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Update DocFinancieroEntidad Set BL=@BL where ID_Usuario= @ID_Usuario")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@BL", True))
                .Add(New SqlParameter("@ID_Usuario", nc.Usuario.ID_Usuario))

            End With
            Acceso.Escritura(Command)
            Command.Dispose()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function




End Class
