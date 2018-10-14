Imports Entidades
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports DAL

Public Class NovedadMPP
    Public Sub altaNovedad(ByVal paramNovedad As Entidades.Novedad)
        Try
            Dim Command As SqlCommand
            Command = Acceso.MiComando("insert into NovedadEntidad (Tipo_Novedad,Nombre,Descripcion,Cuerpo,Imagen,Fecha_Alta,Fecha_Fin_Vigencia,BL) Output Inserted.ID_Novedad values (@Tipo_Novedad,@Nombre,@Descripcion,@Cuerpo,@Imagen,@Fecha_Alta,@Fecha_Fin_Vigencia,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Tipo_Novedad", paramNovedad.Tipo_Novedad))
                .Add(New SqlParameter("@Nombre", paramNovedad.Nombre))
                .Add(New SqlParameter("@Descripcion", paramNovedad.Descripcion))
                .Add(New SqlParameter("@Cuerpo", paramNovedad.Cuerpo))
                .Add(New SqlParameter("@Imagen", paramNovedad.Imagen))
                .Add(New SqlParameter("@Fecha_Alta", paramNovedad.Fecha_Alta))
                .Add(New SqlParameter("@Fecha_Fin_Vigencia", paramNovedad.Fecha_Alta))
                .Add(New SqlParameter("@BL", paramNovedad.BL))

                '
            End With
            Dim ListaParametros As New List(Of String)
            Acceso.Scalar(Command)
            Command.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub bajaNovedad(ByVal paramNovedad As Entidades.Novedad)
        Try
            Dim CommandDel As SqlCommand = Acceso.MiComando("Update NovedadEntidad set BL=@BL where ID_Novedad = @ID_Novedad")
            With CommandDel.Parameters
                .Add(New SqlParameter("@ID_Novedad", paramNovedad.ID_Novedad))
                .Add(New SqlParameter("@BL", True))
            End With
            Acceso.Escritura(CommandDel)
            CommandDel.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub modificarNovedad(ByVal paramNovedad As Entidades.Novedad)
        Try
            Dim CommandDel As SqlCommand = Acceso.MiComando("Update NovedadEntidad set Nombre=@Nombre, Descripcion=@Descripcion, Cuerpo=@Cuerpo, Imagen=@Imagen, Fecha_Fin_Vigencia=@Fecha_Fin_Vigencia where ID_Novedad = @ID_Novedad")
            With CommandDel.Parameters
                .Add(New SqlParameter("@ID_Novedad", paramNovedad.ID_Novedad))
                .Add(New SqlParameter("@Nombre", paramNovedad.Nombre))
                .Add(New SqlParameter("@Descripcion", paramNovedad.Descripcion))
                .Add(New SqlParameter("@Cuerpo", paramNovedad.Cuerpo))
                .Add(New SqlParameter("@Imagen", paramNovedad.Imagen))
                .Add(New SqlParameter("@Fecha_Fin_Vigencia", paramNovedad.Fecha_Fin_Vigencia))
            End With
            Acceso.Escritura(CommandDel)
            CommandDel.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function obtenerSuscriptores(ByVal paramNovedad As Entidades.Novedad) As List(Of String)
        Try
            Dim listaCorreosElectronicos As New List(Of String)
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select Mail from Suscriptor where bl= 0 and Tipo_Novedad=@Tipo_Novedad")
            With Command.Parameters
                .Add(New SqlParameter("@Tipo_Novedad", paramNovedad.Tipo_Novedad))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each _dr As DataRow In _dt.Rows
                listaCorreosElectronicos.Add(_dr("Mail"))
            Next
            Return listaCorreosElectronicos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerNovedades() As List(Of Entidades.Novedad)
        Try
            Dim listaNovedades As List(Of Entidades.Novedad) = New List(Of Entidades.Novedad)
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select * from NovedadEntidad where bl= 0")
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each _dr As DataRow In _dt.Rows
                listaNovedades.Add(generarEntidad(_dr))
            Next
            Return listaNovedades
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerNovedadesVigentes() As List(Of Entidades.Novedad)
        Try
            Dim listaNovedades As List(Of Entidades.Novedad) = New List(Of Entidades.Novedad)
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select * from NovedadEntidad where fecha_fin_vigencia <= getdate() and bl= 0")
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each _dr As DataRow In _dt.Rows
                listaNovedades.Add(generarEntidad(_dr))
            Next
            Return listaNovedades
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerNovedad(ByVal paramNovedad As Entidades.Novedad) As Entidades.Novedad
        Try
            Dim Command As SqlCommand
            Command = Acceso.MiComando("Select * from NovedadEntidad where ID_Novedad=@ID_Novedad")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Novedad", paramNovedad.ID_Novedad))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)
            Return generarEntidad(_dt.Rows(0))
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function generarEntidad(ByVal row As DataRow) As Entidades.Novedad
        Dim _novedad As Entidades.Novedad = New Entidades.Novedad
        _novedad.ID_Novedad = row("ID_Novedad")
        _novedad.Tipo_Novedad = row("Tipo_Novedad")
        _novedad.Nombre = row("Nombre")
        _novedad.Descripcion = row("Descripcion")
        _novedad.Cuerpo = row("Cuerpo")
        _novedad.Imagen = row("Imagen")
        _novedad.Fecha_Alta = row("Fecha_Alta")
        _novedad.Fecha_Fin_Vigencia = row("Fecha_Fin_Vigencia")
        Return _novedad
    End Function


End Class
