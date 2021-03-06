﻿Imports System.IO
Imports System.Net.Mail
Imports Entidades



Imports System.Web

Public Class MailingBLL

    Public Shared Sub enviarMailRegistroUsuario(ByVal token As String, ByVal body As String, ByVal ruta As String, ByVal ubicacionserver As String, ByVal usu As UsuarioEntidad)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"}) ' Es la imagen del titulo
            Correo.Attachments.Add(New Attachment(ruta & "\Email_Lock.png") With {.ContentId = "knight"}) ' Es la imagen deo cuerpo (espadas)
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})

            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"}) ' Es el banner, medio del mail.

            Dim variable As String() = body.Split("$$$")
            variable(0) = variable(0) & ubicacionserver & "/ConfirmarRegistracion.aspx?tok=" & token
            body = variable(0) & variable(3)

            Correo.IsBodyHtml = True
            'Correo.From = New System.Net.Mail.MailAddress("innovaled.company@gmail.com", "Innova LED") esta línea la comentamos porque ya la toma desde el WEBCONFIG
            Correo.To.Add(usu.Mail)
            Correo.Subject = "Confirmación Registro de Usuario - InnovaLED"
            'Correo.Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplates/Registracion.html"))
            Correo.Body = body
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            'smtp.Host = "smtp.gmail.com" esta línea la comentamos porque ya la toma desde el WEBCONFIG
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("innovaled.company@gmail.com", EncriptarBLL.Desencriptar(System.Web.Configuration.WebConfigurationManager.AppSettings("passwordInnovaLed").ToString()))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub enviarMailRecupero(ByVal token As String, ByVal body As String, ByVal ruta As String, ByVal ubicacionserver As String, usu As UsuarioEntidad)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"})
            Correo.Attachments.Add(New Attachment(ruta & "\Email_Lock_Recupero.png") With {.ContentId = "game-console"})
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})

            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"})
            Dim variable As String() = body.Split("$$$")
            variable(0) = variable(0) & ubicacionserver & "/ConfirmarRecupero.aspx?tok=" & token
            body = variable(0) & variable(3)
            Correo.IsBodyHtml = True
            Correo.To.Add(usu.Mail)
            Correo.Subject = "Recupero de contraseña de Usuario - InnovaLED"
            Correo.Body = body
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("innovaled.company@gmail.com", EncriptarBLL.Desencriptar(System.Web.Configuration.WebConfigurationManager.AppSettings("passwordInnovaLed").ToString()))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    'Esto se paso al boletinMPP para poder llamar a acceso.ruta

    'Public Shared Sub enviarMailNewsletter(ByVal body As String, ByVal _paramBoletin As BoletinEntidad, ByVal ruta As String)
    '    Try
    '        Dim Correo As New System.Net.Mail.MailMessage()


    '        'Dim ruta2 As String = 



    '        Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
    '        Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"})
    '        'Correo.Attachments.Add(New Attachment(_paramBoletin.Imagen) With {.ContentId = "game-console"})
    '        Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
    '        Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
    '        Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})


    '        Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"})
    '        Correo.IsBodyHtml = True
    '        For Each mail As String In _paramBoletin.Suscriptores
    '            Correo.To.Add(mail)
    '        Next
    '        Correo.Subject = _paramBoletin.Nombre
    '        body = body.Replace("{Nombre}", _paramBoletin.Nombre)
    '        body = body.Replace("{Cuerpo}", _paramBoletin.Cuerpo)
    '        Correo.Body = body
    '        Correo.Priority = System.Net.Mail.MailPriority.Normal
    '        Dim smtp As New System.Net.Mail.SmtpClient
    '        smtp.Host = "smtp.gmail.com"
    '        smtp.Port = 587
    '        smtp.Credentials = New System.Net.NetworkCredential("innovaled.company@gmail.com", EncriptarBLL.Desencriptar("DE7F5F9AB2626DD9F622DDF9E9FA2EC5"))
    '        smtp.EnableSsl = True
    '        smtp.Send(Correo)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Public Shared Sub enviarMailCambioContraseñaUsuario(ByVal usu As UsuarioEntidad, ByVal ruta As String) ' Funciona OK
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"})
            Correo.Attachments.Add(New Attachment(ruta & "\Lock.png") With {.ContentId = "game-console"})
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})

            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"})
            Correo.IsBodyHtml = True
            'Correo.From = New System.Net.Mail.MailAddress("innovaled.company@gmail.com", "Innova LED") esta línea la comentamos porque ya la toma desde el WEBCONFIG

            Correo.To.Add(usu.Mail)

            Correo.Subject = "Cambio de Contraseña - Innova LED"
            Correo.Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplates/Cambio_Contraseña.html"))
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            'smtp.Host = "smtp.gmail.com" esta línea la comentamos porque ya la toma desde el WEBCONFIG
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("innovaled.company@gmail.com", EncriptarBLL.Desencriptar("DE7F5F9AB2626DD9F622DDF9E9FA2EC5"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub enviarMailFactura(ByVal body As String, ByVal ruta As String, usu As UsuarioEntidad, ByVal PDF As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"})
            Correo.Attachments.Add(New Attachment(ruta & "\seo.png") With {.ContentId = "game-console"}) ' logo de la factura
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})

            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"})
            Correo.Attachments.Add(New Attachment(PDF))
            Correo.IsBodyHtml = True
            Correo.To.Add(usu.Mail)
            Correo.Subject = "Comprabante de Compra - InnovaLED"
            Correo.Body = body
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("innovaled.company@gmail.com", EncriptarBLL.Desencriptar("DE7F5F9AB2626DD9F622DDF9E9FA2EC5"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub enviarNotadeCredito(ByVal body As String, ByVal ruta As String, usu As UsuarioEntidad, ByVal PDF As String)
        Try
            Dim Correo As New System.Net.Mail.MailMessage()
            Correo.Attachments.Add(New Attachment(ruta & "\twitter.png") With {.ContentId = "twitter"})
            Correo.Attachments.Add(New Attachment(ruta & "\bulb.png") With {.ContentId = "logo"})
            Correo.Attachments.Add(New Attachment(ruta & "\seo.png") With {.ContentId = "game-console"}) ' logo de la factura
            Correo.Attachments.Add(New Attachment(ruta & "\facebook.png") With {.ContentId = "facebook"})
            Correo.Attachments.Add(New Attachment(ruta & "\blue.png") With {.ContentId = "lkdn"})
            Correo.Attachments.Add(New Attachment(ruta & "\red.png") With {.ContentId = "pint"})

            Correo.Attachments.Add(New Attachment(ruta & "\bannermail.jpg") With {.ContentId = "banner"})
            Correo.Attachments.Add(New Attachment(PDF))
            Correo.IsBodyHtml = True
            Correo.To.Add(usu.Mail)
            Correo.Subject = "Comprabante de Nota de Crédito - InnovaLED"
            Correo.Body = body
            Correo.Priority = System.Net.Mail.MailPriority.Normal
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("innovaled.company@gmail.com", EncriptarBLL.Desencriptar("DE7F5F9AB2626DD9F622DDF9E9FA2EC5"))
            smtp.EnableSsl = True
            smtp.Send(Correo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub







End Class
