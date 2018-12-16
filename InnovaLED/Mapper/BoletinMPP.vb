Imports System.Data.SqlClient
Imports Entidades
Imports DAL

Public Class BoletinMPP

    Public Function Alta(ByRef Boletin As BoletinEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Boletin (Nombre,Descripcion,Cuerpo,ID_Tipoboletin,FechaHora,FechaFinVigencia,Imagen,BL) values (@Nombre, @Descripcion,@Cuerpo,@ID_Tipoboletin,@FechaHora,@FechaFinVigencia, @Imagen, @BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Nombre", Boletin.Nombre))
                .Add(New SqlParameter("@Descripcion", Boletin.Descripcion))
                .Add(New SqlParameter("@Cuerpo", Boletin.Cuerpo))
                .Add(New SqlParameter("@ID_Tipoboletin", Boletin.TipoBoletin))
                .Add(New SqlParameter("@FechaHora", Now))
                .Add(New SqlParameter("@Imagen", Boletin.Imagen))
                .Add(New SqlParameter("@BL", False))
                If Boletin.FechaFinVigencia <> "#12:00:00 AM#" Then

                    .Add(New SqlParameter("@FechaFinVigencia", Boletin.FechaFinVigencia))
                Else
                    .Add(New SqlParameter("@FechaFinVigencia", DBNull.Value))
                End If
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub inscribirseBoletin(ByVal paramCorreo As String, ByVal paramTipo As List(Of TipoBoletin))
        Try
            For Each miTipoBoletin As Entidades.TipoBoletin In paramTipo
                Dim Command As SqlCommand = Acceso.MiComando("insert into Suscripcion values (@Correo, @ID_TipoBoletin)")
                With Command.Parameters
                    .Add(New SqlParameter("@Correo", paramCorreo))
                    .Add(New SqlParameter("@ID_TipoBoletin", CInt(miTipoBoletin)))
                End With
                Acceso.Escritura(Command)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function obtenerSubscriptores(ByVal _idTipoBoletin As Integer) As List(Of String)
        Try
            Dim _listaSubscriptores As New List(Of String)
            Dim Command As SqlCommand = Acceso.MiComando("Select Mail from Suscripcion where ID_TipoBoletin=@ID_TipoBoletin")
            With Command.Parameters
                .Add(New SqlParameter("@ID_TipoBoletin", _idTipoBoletin))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)
            For Each dr As DataRow In _dt.Rows
                _listaSubscriptores.Add(dr.Item("Mail"))
            Next
            Return _listaSubscriptores
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function validarCorreo(ByVal paramCorreo As String) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Select * from Suscripcion where Mail=@Mail")
            With Command.Parameters
                .Add(New SqlParameter("@Mail", paramCorreo))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)
            If _dt.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function obtenerBoletinNovedad() As List(Of BoletinEntidad)
        Try
            Dim _listaBoletin As New List(Of BoletinEntidad)
            Dim Command As SqlCommand = Acceso.MiComando("select * from Boletin where ID_TipoBoletin=@ID_TipoBoletin and BL=@BL order by FechaHora desc")
            With Command.Parameters
                '4 = Tipo novedad de boletin
                .Add(New SqlParameter("@ID_TipoBoletin", 4))
                .Add(New SqlParameter("@BL", False))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)

            For Each midatarow As DataRow In _dt.Rows
                Dim MiBoletinEntidad As New BoletinEntidad
                Me.FormatearBoletin(MiBoletinEntidad, midatarow)
                _listaBoletin.Add(MiBoletinEntidad)
            Next
            Return _listaBoletin
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function obtenerBoletinNovedad(ByVal paramBoletin As BoletinEntidad) As BoletinEntidad
        Try
            Dim Command As SqlCommand = Acceso.MiComando("select * from Boletin where ID_Boletin=@ID_Boletin and ID_TipoBoletin=@ID_TipoBoletin order by Fecha_Alta desc")
            With Command.Parameters
                '4 = Tipo novedad de boletin
                .Add(New SqlParameter("@ID_TipoBoletin", 4))
                .Add(New SqlParameter("@ID_Boletin", paramBoletin.ID))
            End With
            Dim _dt As DataTable = Acceso.Lectura(Command)
            If _dt.Rows.Count = 1 Then
                Dim MiBoletinEntidad As New BoletinEntidad
                Me.FormatearBoletin(MiBoletinEntidad, _dt.Rows(0))
                Return MiBoletinEntidad
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function bajaNovedad(ByVal paramBoletin As BoletinEntidad)
        Try

            Dim Command As SqlCommand = Acceso.MiComando("Update Boletin Set BL=@BL where ID_Boletin=@ID_Boletin")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@BL", True))
                .Add(New SqlParameter("@ID_Boletin", paramBoletin.ID))
            End With
            Acceso.Escritura(Command)
            Command.Dispose()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Modificar(ByRef paramBoletin As BoletinEntidad) As Boolean

        Try
            Dim Command As SqlCommand = Acceso.MiComando("update Boletin set FechaFinVigencia=@FechaFinVigencia where ID_Boletin=@ID_Boletin and BL=@BL")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@FechaFinVigencia", paramBoletin.FechaFinVigencia))
                .Add(New SqlParameter("@ID_Boletin", paramBoletin.ID))
                .Add(New SqlParameter("@BL", False))

            End With
            Acceso.Escritura(Command)
            Command.Dispose()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FormatearBoletin(ByVal Boletin As BoletinEntidad, ByVal row As DataRow)
        Try
            Boletin.ID = row("ID_Boletin")
            Boletin.Nombre = row("Nombre")
            Boletin.Descripcion = row("Descripcion")
            Boletin.Cuerpo = row("Cuerpo")
            Boletin.TipoBoletin = row("ID_TipoBoletin")
            Boletin.FechaAlta = row("FechaHora")
            Boletin.Imagen = row("Imagen")
            If Boletin.TipoBoletin = TipoBoletin.Novedad Then
                Boletin.FechaFinVigencia = row("FechaFinVigencia")
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub






























End Class
