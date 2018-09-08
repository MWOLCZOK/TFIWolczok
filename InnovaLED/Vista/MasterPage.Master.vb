Imports System.IO

Imports System.Web.HttpContext
Imports System.Environment
Imports System.Net
Imports System.Globalization

Imports Entidades
Imports Negocio



Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private GestorUsu As New UsuarioBLL
    Dim Usuario As New Entidades.UsuarioEntidad

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        If IsNothing(Current.Session("cliente")) Or IsDBNull(Current.Session("Cliente")) Then
            Dim UsuarioInvitado As New Entidades.UsuarioEntidad
            CargarSinPerfilIdioma(UsuarioInvitado)
            VisibilidadAcceso(False)
            'TraducirPagina(UsuarioInvitado)
        Else
            Try
                Dim Usuario As Entidades.UsuarioEntidad = TryCast(Current.Session("cliente"), Entidades.UsuarioEntidad)
                CargarPerfil(Usuario)
                VisibilidadAcceso(True)
                'TraducirPagina(Usuario)
            Catch ex As Exception

            End Try
        End If
        
    End Sub



    Private Sub VisibilidadAcceso(B As Boolean)

        Me.lbl_NombredeUsuarioLogueado.Visible = B
        If B = True Then
            Me.lbl_NombredeUsuarioLogueado.Text = DirectCast(Session("cliente"), UsuarioEntidad).Apellido & ", " & DirectCast(Session("cliente"), UsuarioEntidad).Nombre
            YaLogueo.Visible = True
            NoLogueo.Visible = False
        Else
            YaLogueo.Visible = False
            NoLogueo.Visible = True

        End If

    End Sub

    Private Sub ArmarMenuCompleto()
        Me.Menu.Items.Add(New MenuItem("Home", "Home", Nothing, "/Default.aspx"))

        Me.Menu.Items.Add(New MenuItem("Empresa", "Empresa"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("¿Quienes Somos?", "Institucional", Nothing, "/Institucional.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Faqs", "Faqs", Nothing, "/Faqs.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Politicas y Seguridad", "PoliticasySeguridad", Nothing, "/PoliticasySeguridad.aspx"))

        Me.Menu.Items.Add(New MenuItem("Catalogo", "Catalogo"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Nuestros Productos", "Catalogo", Nothing, "/Catalogo.aspx"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Novedades", "Novedades", Nothing, "/Novedades.aspx"))



        Me.Menu.Items.Add(New MenuItem("Solución LED", "IngPrev"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Soluciones LED", "SolucionesLED", Nothing, "/GestionarSolucionesLED.aspx"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Generar Presupuesto", "GenerarPresupuesto", Nothing, "/GenerarPresupuesto.aspx"))


        Me.Menu.Items.Add(New MenuItem("Facturacion", "Facturacion"))
        Me.Menu.Items.Item(4).ChildItems.Add(New MenuItem("Generar Documento", "GenerarDocumento", Nothing, "/GenerarDocumento.aspx"))
        Me.Menu.Items.Item(4).ChildItems.Add(New MenuItem("Pago a Proveedores", "PagoaProveedores", Nothing, "/PagoaProveedores.aspx"))


        Me.Menu.Items.Add(New MenuItem("Compras", "Compras"))
        Me.Menu.Items.Item(5).ChildItems.Add(New MenuItem("Proveedores", "Proveedores", Nothing, "/Proveedores.aspx"))
        Me.Menu.Items.Item(5).ChildItems.Add(New MenuItem("Solicitud Pedido", "SolicitudPedido", Nothing, "/SolicitudPedido.aspx"))
        Me.Menu.Items.Item(5).ChildItems.Add(New MenuItem("Reporte Stock", "ReporteStock", Nothing, "/ReporteStock.aspx"))


        Me.Menu.Items.Add(New MenuItem("Almacenes y Logística", "AlmyLog"))
        Me.Menu.Items.Item(6).ChildItems.Add(New MenuItem("Actualizar Stock", "ActualizarStock", Nothing, "/ActualizarStock.aspx"))
        Me.Menu.Items.Item(6).ChildItems.Add(New MenuItem("Crear Producto", "CrearProducto", Nothing, "/CrearProducto.aspx"))
        Me.Menu.Items.Item(6).ChildItems.Add(New MenuItem("Generar Envío", "GenerarEnvio", Nothing, "/GenerarEnvio.aspx"))

        Me.Menu.Items.Add(New MenuItem("Seguridad", "Seguridad"))

        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Gestionar Roles", "GestionarRoles", Nothing, "/GestionarRoles.aspx"))
        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Gestion de Usuario", "GestiondeUsuario", Nothing, "/GestiondeUsuario.aspx"))
        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Gestion Idioma", "CrearIdioma", Nothing, "/CrearIdioma.aspx"))
        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Gestión de Bitácora", "GestiondeBitacora", Nothing, "/BitacoraAuditoria.aspx"))


    End Sub

    Private Sub CargarSinPerfilIdioma(ByRef UsuarioInvitado As Entidades.UsuarioEntidad)

        Me.Menu.Items.Add(New MenuItem("Home", "Home", Nothing, "/Default.aspx"))

        Me.Menu.Items.Add(New MenuItem("Empresa", "Empresa"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("¿Quienes Somos?", "Institusional", Nothing, "/Institucional.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Faqs", "Faqs", Nothing, "/Faqs.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Politicas y Seguridad", "PoliticasySeguridad", Nothing, "/PoliticasySeguridad.aspx"))

        Me.Menu.Items.Add(New MenuItem("Catalogo", "Catalogo"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Nuestros Productos", "Catalogo", Nothing, "/Catalogo.aspx"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Novedades", "Novedades", Nothing, "/Novedades.aspx"))

    End Sub


    Private Sub CargarPerfil(ByRef Usuario As Entidades.UsuarioEntidad)

        Dim GestorUsuario As New Negocio.UsuarioBLL

        'GestorUsuario.RefrescarUsuario(Usuario)

        'If Usuario.Bloqueo = True Then
        '    Current.Session("cliente") = Nothing
        '    Response.Redirect("/Default.aspx", False)
        'End If


        Me.Menu.Items.Clear()
        ArmarMenuCompleto()
        Dim listaAremover As New List(Of MenuItem)
        For Each pagina As MenuItem In Menu.Items
            If pagina.ChildItems.Count > 0 Then
                RecursividadMenu(pagina, Usuario, listaAremover)
            Else

                If Usuario.ValidarURL(pagina.NavigateUrl) = False Then
                    listaAremover.Add(pagina)
                End If
            End If
        Next
        For Each item As MenuItem In listaAremover
            Menu.Items.Remove(item)
            For Each subnivel As MenuItem In Menu.Items
                subnivel.ChildItems.Remove(item)
            Next
        Next
        If Usuario.ValidarURL(Me.Page.Request.FilePath) = False Then
            Response.Redirect("AccesoRestringido.aspx", False)
        End If
    End Sub


    Private Sub RecursividadMenu(ByRef pagina As MenuItem, ByRef Usuario As Entidades.UsuarioEntidad, ByRef ListaAremover As List(Of MenuItem))
        Dim flag As Integer = 0
        For Each paginadentro As MenuItem In pagina.ChildItems
            If paginadentro.ChildItems.Count > 0 Then
                RecursividadMenu(paginadentro, Usuario, ListaAremover)
            Else
                If Not Usuario.ValidarURL(paginadentro.NavigateUrl) Then
                    ListaAremover.Add(paginadentro)
                    flag += 1
                End If
            End If
        Next
        If flag = pagina.ChildItems.Count Then
            ListaAremover.Add(pagina)
        End If
    End Sub










    Public Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim Cliente As New Entidades.UsuarioEntidad
        Dim IdiomaActual As Entidades.IdiomaEntidad
        Dim clienteLogeado As New Entidades.UsuarioEntidad
        If IsNothing(Current.Session("Cliente")) Then
            IdiomaActual = Application("Español")
        Else
            'IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
        End If
        Try
            If Page.IsValid = True Then
                Cliente.NombreUsu = txtUser.Value
                Cliente.Password = txtPassword.Value
                clienteLogeado = GestorUsu.ExisteUsuario(Cliente)
                Dim Bitac As New Bitacora(clienteLogeado, "El usuario " & clienteLogeado.NombreUsu & " Se logueo correctamente", Tipo_Bitacora.Login, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                BitacoraBLL.CrearBitacora(Bitac)
                Session("cliente") = clienteLogeado
                Usuario = DirectCast(Session("cliente"), Entidades.UsuarioEntidad)


                Me.success.Visible = True
                Me.success.InnerText = "Se ha logueado correctamente"
                Me.alertvalid.Visible = False

                VisibilidadAcceso(True)

                'Response.Redirect(Default., False)
                Response.Redirect(Request.Url.ToString, False)

            End If
        Catch ex As Exception
            VisibilidadAcceso(False)

            '        Me.success.Visible = True
            '        Me.alertvalid.Visible = False
            '        Response.Redirect("~/default.aspx", False)
            '    Else
            '        Me.aert
            '        Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
            '        Me.success.Visible = False
            '    End If
            'Catch UsuarioBloqueado As Negocio.ExceptionUsuarioBloqueado
            '    Me.alertvalid.Visible = True
            '    Me.textovalid.InnerText = UsuarioBloqueado.Mensaje(IdiomaActual)
            '    Me.success.Visible = False
            'Catch UsuarioNoExiste As Negocio.ExceptionUsuarioNoExiste
            '    Me.alertvalid.Visible = True
            '    Me.textovalid.InnerText = UsuarioNoExiste.Mensaje(IdiomaActual)
            '    Me.success.Visible = False
            'Catch Password As Negocio.ExceptionPasswordIncorrecta
            '    Me.alertvalid.Visible = True
            '    Me.textovalid.InnerText = Password.Mensaje(IdiomaActual)
            '    Me.success.Visible = False

            'Catch ex As Exception
            '    Dim Bitac As New Entidades.Bitacora(Cliente, ex.Message, Entidades.Tipo_Bitacora.Errores, Now, Request.UserAgent, Request.UserHostAddress, ex.StackTrace, ex.GetType().ToString, Request.Url.ToString)
            '    Negocio.BitacoraBLL.CrearBitacora(Bitac)
        End Try

    End Sub


    Public Sub btnregistracion_Click(sender As Object, e As EventArgs) Handles btnregistracion.Click
        Dim GestorCliente As New Negocio.UsuarioBLL
        Dim usu As New Entidades.UsuarioEntidad
        Dim IdiomaActual As Entidades.IdiomaEntidad
        If IsNothing(Current.Session("Cliente")) Then
            IdiomaActual = Application("Español")
        Else
            IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
        End If
        Try

            If Page.IsValid = True Then

                If IsValidEmail(txtmail.Value) Then
                    usu.Mail = txtmail.Value

                Else
                    Return
                End If

                Dim PassSalt As List(Of String) = Negocio.EncriptarBLL.EncriptarPassword(txtPasswordreg.Value)
                usu.Nombre = txtnombrereg.Value
                usu.NombreUsu = txtUserreg.Value
                usu.Apellido = txtapereg.Value
                usu.Salt = PassSalt.Item(0)
                usu.Password = PassSalt.Item(1)
                usu.Idioma = New Entidades.IdiomaEntidad With {.ID_Idioma = 1}
                'usu.Perfil = New Entidades.PermisoCompuestoEntidad With {.ID_Permiso = 0}
                usu.FechaAlta = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                usu.Empleado = False
                usu.Bloqueo = True
                If GestorCliente.Alta(usu) Then
                    Dim Bitac As New Bitacora(usu, usu.NombreUsu, Tipo_Bitacora.Login, Now, Request.UserAgent, Request.UserHostAddress, "", "", Request.Url.ToString)
                    BitacoraBLL.CrearBitacora(Bitac)
                    'Me.success.Visible = True
                    'Me.alertvalid.Visible = False
                    'Me.txtusuario.Text = ""
                    EnviarMailRegistro(GestorCliente.GEtToken(usu.ID_Usuario))
                End If
            Else
                'Me.alertvalid.Visible = True
                'Me.textovalid.InnerText = IdiomaActual.Palabras.Find(Function(p) p.Codigo = "FieldValidator1").Traduccion
                'Me.success.Visible = False
            End If
        Catch nombreuso As Negocio.ExceptionNombreEnUso
            'Me.alertvalid.Visible = True
            'Me.textovalid.InnerText = nombreuso.Mensaje(IdiomaActual)
            'Me.success.Visible = False
        Catch ex As Exception


        End Try



    End Sub


    Public Sub btnolvidepass_Click(sender As Object, e As EventArgs) Handles btnolvidepass.Click
        Response.Redirect("~/RecuperarPassword.aspx", False)

    End Sub






    Private Sub EnviarMailRegistro(ByVal token As String)
        Dim body As String = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplates/registracion.html"))
        Dim ruta As String = HttpContext.Current.Server.MapPath("Imagenes")
        Dim ur As Uri = Request.Url
        Negocio.MaillingBLL.enviarMailRegistroUsuario(token, body, ruta, Replace(ur.AbsoluteUri, ur.AbsolutePath, ""))
    End Sub




    Dim invalid As Boolean = False

    Public Function IsValidEmail(strIn As String) As Boolean
        ' funcion para validar correo 
        invalid = False
        If String.IsNullOrEmpty(strIn) Then Return False

        Try
            strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf Me.DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try

        If invalid Then Return False


        Try
            Return Regex.IsMatch(strIn,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                   RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try


    End Function

    Private Function DomainMapper(match As Match) As String
        Try
            ' IdnMapping class with default property values.
            Dim idn As New IdnMapping()

            Dim domainName As String = match.Groups(2).Value
            Try
                domainName = idn.GetAscii(domainName)
            Catch e As ArgumentException
                invalid = True
            End Try
            Return match.Groups(1).Value + domainName
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Sub btnlogout_Click(sender As Object, e As EventArgs) Handles btnlogout.Click

        Session("cliente") = Nothing
        VisibilidadAcceso(False)
        Response.Redirect("Default.aspx", False)

    End Sub
End Class