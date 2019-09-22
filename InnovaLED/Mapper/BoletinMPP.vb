Imports System.Data.SqlClient
Imports Entidades
Imports DAL
Imports System.IO
Imports System.Net.Mail


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
            Boletin.ID = Acceso.Scalar(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub inscribirseBoletin(ByVal paramCorreo As String, ByVal paramTipo As List(Of TipoBoletin))
        Try
            For Each miTipoBoletin As Entidades.TipoBoletin In paramTipo
                Dim Command As SqlCommand = Acceso.MiComando("insert into Suscripcion values (@Mail, @ID_Tipoboletin,@BL)")
                With Command.Parameters
                    .Add(New SqlParameter("@Mail", paramCorreo))
                    .Add(New SqlParameter("@ID_Tipoboletin", CInt(miTipoBoletin)))
                    .Add(New SqlParameter("@BL", False))
                End With
                Acceso.Escritura(Command)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function DesinscribirseBoletin(ByVal paramCorreo As String) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Update Suscripcion set BL=@BL where Mail=@Mail")
            Dim ListaParametros As New List(Of String)
            With Command.Parameters
                .Add(New SqlParameter("@Mail", paramCorreo))
                .Add(New SqlParameter("@BL", True))
            End With
            Acceso.Escritura(Command)
            Command.Dispose()
            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function obtenerSubscriptores(ByVal _boletin As BoletinEntidad) As List(Of String)
        Try
            Dim _listaSubscriptores As New List(Of String)
            Dim Command As SqlCommand = Acceso.MiComando("Select s.Mail from Suscripcion as s where ID_TipoBoletin=@ID_TipoBoletin and BL=@BL and not exists (select bs.Mail from Boletin_Suscripcion as bs where bs.Mail=s.Mail and bs.ID_Boletin=@ID_Boletin)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_TipoBoletin", _boletin.TipoBoletin))
                .Add(New SqlParameter("@ID_Boletin", _boletin.ID))
                .Add(New SqlParameter("@BL", False))
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
            Dim Command As SqlCommand = Acceso.MiComando("Select * from Suscripcion where Mail=@Mail and BL=@BL")
            With Command.Parameters
                .Add(New SqlParameter("@Mail", paramCorreo))
                .Add(New SqlParameter("@BL", False))
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
            Dim Command As SqlCommand = Acceso.MiComando("select * from Boletin where BL=@BL and isnull(FechaFinVigencia,'29990101')>=getdate() order by FechaHora desc")
            With Command.Parameters
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
            Dim Command As SqlCommand = Acceso.MiComando("select * from Boletin where ID_Boletin=@ID_Boletin order by Fecha_Alta desc")
            With Command.Parameters
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


    Public Shared Sub VerificacionEnvioMail(ByVal _paramBoletin As BoletinEntidad)
        Try
            For Each Suscriptor In _paramBoletin.Suscriptores
                Dim Command As SqlCommand = Acceso.MiComando("insert into Boletin_Suscripcion (Mail, ID_Boletin, Fue_Enviado ) values (@Mail, @ID_Boletin,@Fue_Enviado)")
                With Command.Parameters
                    .Add(New SqlParameter("@Mail", Suscriptor))
                    .Add(New SqlParameter("@ID_boletin", _paramBoletin.ID))
                    .Add(New SqlParameter("@Fue_Enviado", True))
                End With
                Acceso.Escritura(Command)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Sub enviarMailNewsletter(ByVal body As String, ByVal _paramBoletin As BoletinEntidad, ByVal ruta As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Dim ruta2 As String = Acceso.BackupBoletin
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"})
            Correo.Attachments.Add(New Attachment(ruta & "\happy.png") With {.ContentId = "game-console2"})
            Correo.Attachments.Add(New Attachment(ruta2 & "\" & _paramBoletin.Nombre) With {.ContentId = "game-console"})
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})
            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"})
            Correo.IsBodyHtml = True
            For Each mail As String In _paramBoletin.Suscriptores
                Correo.To.Add(mail)
            Next
            Correo.Subject = _paramBoletin.Nombre
            body = body.Replace("{Nombre}", _paramBoletin.Nombre)
            body = body.Replace("{Cuerpo}", _paramBoletin.Cuerpo)
            Correo.Body = body
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("innovaled.company@gmail.com", "Tacho12345")
            smtp.EnableSsl = True
            smtp.Send(Correo)
            VerificacionEnvioMail(_paramBoletin)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub






























End Class
