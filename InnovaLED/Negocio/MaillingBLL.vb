﻿Imports System.IO
Imports System.Net.Mail




Public Class MaillingBLL

    Public Shared Sub enviarMailRegistroUsuario(ByVal token As String, ByVal body As String, ByVal ruta As String, ByVal ubicacionserver As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"}) ' Es la imagen del titulo
            Correo.Attachments.Add(New Attachment(ruta & "\luz-led.png") With {.ContentId = "knight"}) ' Es la imagen deo cuerpo (espadas)
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})

            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"}) ' Es el banner, medio del mail.
            Dim variable As String() = body.Split("$$$")
            variable(0) = variable(0) & ubicacionserver & "/ConfirmarRegistracion.aspx?tok=" & token
            body = variable(0) & variable(3)
            Correo.IsBodyHtml = True
            Correo.To.Add("matias.wolczok2@gmail.com")
            Correo.Subject = "InnovaLED - Registro de Usuario"
            Correo.Body = body
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub enviarMailRecupero(ByVal token As String, ByVal body As String, ByVal ruta As String, ByVal ubicacionserver As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"})
            Correo.Attachments.Add(New Attachment(ruta & "\idea.png") With {.ContentId = "game-console"})
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})

            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"})
            Dim variable As String() = body.Split("$$$")
            variable(0) = variable(0) & ubicacionserver & "/ConfirmarRecupero.aspx?tok=" & token
            body = variable(0) & variable(3)
            Correo.IsBodyHtml = True
            Correo.To.Add("matias.wolczok2@gmail.com")
            Correo.Subject = "InnovaLED - Recuperación de contraseña de Usuario"
            Correo.Body = body
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
