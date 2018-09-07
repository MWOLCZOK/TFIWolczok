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

        'If Usuario.NombreUsu IsNot Nothing Then
        '    VisibilidadAcceso(False)
        '    ArmarMenuCompleto()
        'Else
        '    VisibilidadAcceso(True)
        'End If


        'If Not IsPostBack Then
        '    Me.Menu.Items.Clear()
        '    'ArmarMenuCompleto()
        'End If

        'If Usuario IsNot Nothing Then
        '    CargarSinPerfilIdioma(Usuario)

        'End If
        Me.Menu.Items.Clear()
        ArmarMenuCompleto()



    End Sub



    Private Sub VisibilidadAcceso(B As Boolean)

        If B = True Then
            panelLoginOFF.Visible = True
            panelLoginON.Visible = False
            btnlogout.Visible = False
            lbl_NombredeUsuarioLogueado.Visible = False
            Lbl_apellidoUsuarioLogueado.Visible = False

        Else
            panelLoginOFF.Visible = False
            panelLoginON.Visible = True
            btnlogout.Visible = True
            lbl_NombredeUsuarioLogueado.Visible = True
            Lbl_apellidoUsuarioLogueado.Visible = True
        End If

    End Sub

    Private Sub ArmarMenuCompleto()
        Me.Menu.Items.Add(New MenuItem("Home", "Home", Nothing, "/Default.aspx"))
        Me.Menu.Items.Add(New MenuItem("Seguridad", "Seg"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Gestionar Roles", "GestionarRoles", Nothing, "/GestionarRoles.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Gestion de Usuario", "GestiondeUsuario", Nothing, "/GestiondeUsuario.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Crear Idioma", "CrearIdioma", Nothing, "/CrearIdioma.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Cambiar Contraseña", "CambiarContraseña", Nothing, "/CambiarContraseña.aspx"))
        Me.Menu.Items.Item(1).ChildItems.Add(New MenuItem("Gestión de Bitácora", "GestiondeBitacora", Nothing, "/BitacoraAuditoria.aspx"))


        Me.Menu.Items.Add(New MenuItem("Arma tu Solución LED", "IngPrev"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Soluciones LED", "GestionarSolucionesLED", Nothing, "/GestionarSolucionesLED.aspx"))
        Me.Menu.Items.Item(2).ChildItems.Add(New MenuItem("Generar Presupuesto", "GenerarPresupuesto", Nothing, "/GenerarPresupuesto.aspx"))


        Me.Menu.Items.Add(New MenuItem("Ventas", "Ventas"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Crear Nuevo Cliente", "CrearNuevoCliente", Nothing, "/CrearNuevoCliente.aspx"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Cargar Venta", "CargarVenta", Nothing, "/CargarVenta.aspx"))
        Me.Menu.Items.Item(3).ChildItems.Add(New MenuItem("Cobro", "Cobro", Nothing, "/Cobro.aspx"))


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

        Me.Menu.Items.Add(New MenuItem("Institucional", "Inst"))
        Me.Menu.Items.Item(7).ChildItems.Add(New MenuItem("Institucional", "Institucional", Nothing, "/Institucional.aspx"))


    End Sub

    Private Sub CargarSinPerfilIdioma(ByRef UsuarioInvitado As Entidades.UsuarioEntidad)

        Me.Menu.Items.Add(New MenuItem("Home", "Home", Nothing, "/Default.aspx"))
            Me.Menu.Items.Add(New MenuItem("Empresa", "Institucional", Nothing, "/Institucional.aspx"))
            Me.Menu.Items.Add(New MenuItem("Nuestros Productos", "Nuestos Productos", Nothing, "/Catalogo.aspx"))
            Me.Menu.Items.Add(New MenuItem("¿Quienes Somos?", "¿Quienes Somos?", Nothing, "/Institucional.aspx"))
            Me.Menu.Items.Add(New MenuItem("Novedades", "Novedades", Nothing, "/Novedades.aspx"))
            Me.Menu.Items.Add(New MenuItem("Newsletter", "Newsletter", Nothing, "/Newsletter.aspx"))

    End Sub







    Public Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim Cliente As New Entidades.UsuarioEntidad
        Dim IdiomaActual As Entidades.IdiomaEntidad
        Dim clienteLogeado As New Entidades.UsuarioEntidad
        If IsNothing(Current.Session("Cliente")) Then
            IdiomaActual = Application("Español")
        Else
            IdiomaActual = Application(TryCast(Current.Session("Cliente"), Entidades.UsuarioEntidad).Idioma.Nombre)
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
                Me.lbl_NombredeUsuarioLogueado.Visible = True
                Me.Lbl_apellidoUsuarioLogueado.Visible = True
                Me.lbl_NombredeUsuarioLogueado.Text = DirectCast(Session("cliente"), Entidades.UsuarioEntidad).Nombre
                Me.Lbl_apellidoUsuarioLogueado.Text = DirectCast(Session("cliente"), Entidades.UsuarioEntidad).Apellido & ", "
                Me.success.Visible = True
                Me.success.InnerText = "Se ha logueado correctamente"
                Me.alertvalid.Visible = False
                If Usuario.NombreUsu IsNot Nothing Then
                    VisibilidadAcceso(False)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

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
        If Not IsNothing(Session("Usuario")) Then
            Session.Remove("Usuario")
            'Me.menuVertical.Items.Clear()
            'Me.armarMenuBasico()
            Response.Redirect("Index.aspx")
            'Me.opcionesUsuario.Visible = False
            Lbl_apellidoUsuarioLogueado.Visible = False
            lbl_NombredeUsuarioLogueado.Visible = False
            Me.Usuario = Nothing

        End If
    End Sub
End Class