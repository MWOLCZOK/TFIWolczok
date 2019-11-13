Imports System.Data.SqlClient
Imports Entidades
Imports DAL
Imports System.IO
Imports System.Web.HttpContext
Imports System.Web

Public Class DocumentoFinancieroMPP

    Public Function Alta(ByVal nota As DocumentoFinancieroEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into DocFinancieroEntidad (Descripcion,Monto,Tipo,ID_Usuario,Fecha_Emision,ID_Fact,BL) OUTPUT INSERTED.ID_Doc values (@Descripcion,@Monto,@Tipo,@ID_Usuario,@Fecha_Emision,@ID_Fact,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Descripcion", nota.Descripcion))
                .Add(New SqlParameter("@Monto", nota.Monto))
                .Add(New SqlParameter("@Tipo", nota.Tipo_Documento))
                .Add(New SqlParameter("@ID_Usuario", nota.Usuario.ID_Usuario))
                .Add(New SqlParameter("@Fecha_Emision", nota.Fecha_Emision))
                .Add(New SqlParameter("@ID_Fact", nota.Factura.ID))
                .Add(New SqlParameter("@BL", False))
            End With
            nota.ID = Acceso.Scalar(Command)

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
            nc.Fecha_Emision = row("Fecha_Emision")
            nc.Usuario = (New Mapper.UsuarioMPP).BuscarUsuarioID(New Entidades.UsuarioEntidad With {.ID_Usuario = row("ID_Usuario")})
            nc.Factura = (New FacturaMPP).BuscarFacturaID(New FacturaEntidad With {.ID = row("ID_Fact")})
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function Eliminar(ByRef notas As List(Of DocumentoFinancieroEntidad)) As Boolean
        Try
            For Each _nota As DocumentoFinancieroEntidad In notas

                Dim Command As SqlCommand = Acceso.MiComando("Update DocFinancieroEntidad Set BL=@BL where ID_Doc= @ID_Doc")
                Dim ListaParametros As New List(Of String)

                With Command.Parameters
                    .Add(New SqlParameter("@BL", True))
                    .Add(New SqlParameter("@ID_Doc", _nota.ID))

                End With
                Acceso.Escritura(Command)
                Command.Dispose()
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function








End Class
