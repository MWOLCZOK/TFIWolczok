Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Entidades
Imports DAL




Public Class UsuarioMPP

    Dim acc As New DAL.Acceso


    'Public Function alta(Unsuario As Entidades.UsuarioEntidad) As String
    '    Dim parametros(2) As SqlParameter
    '    parametros(0) = acc.crearparametros("@NombreUsuario", Unsuario.NombreUsu)
    '    parametros(1) = acc.crearparametros("@apellido", unpasajero.apellido)
    '    parametros(2) = acc.crearparametros("@direccion", unpasajero.direccion)

    '    Return acc.escribir("PASAJERO_ALTA", parametros)
    'End Function

    Public Function Alta(ByRef Usuario As UsuarioEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into UsuarioEntidad (NombreUsuario,Password,Nombre,Apellido,DNI,Fecha_Alta,Salt,Bloqueo,Intentos,Idioma,mail,Empleado,BL) OUTPUT INSERTED.ID_Usuario values (@NombreUsuario, @Password,@Nombre,@Apellido,@DNI,@Fecha_Alta ,@Salt, @Bloqueo, @Intento, @Idioma,@mail,@Empleado,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@NombreUsuario", Usuario.NombreUsu))
                .Add(New SqlParameter("@Password", Usuario.Password))
                .Add(New SqlParameter("@Nombre", Usuario.Nombre))
                .Add(New SqlParameter("@Apellido", Usuario.Apellido))
                .Add(New SqlParameter("@DNI", Usuario.DNI))
                .Add(New SqlParameter("@Fecha_Alta", Usuario.FechaAlta))
                .Add(New SqlParameter("@Salt", Usuario.Salt))
                .Add(New SqlParameter("@Bloqueo", Usuario.Bloqueo))
                .Add(New SqlParameter("@Intento", Usuario.Intento))
                .Add(New SqlParameter("@Idioma", Usuario.Idioma.ID_Idioma))
                .Add(New SqlParameter("@Mail", Usuario.Mail))
                .Add(New SqlParameter("@Empleado", Usuario.Empleado))
                .Add(New SqlParameter("@BL", False))
            End With

            Usuario.ID_Usuario = Acceso.Scalar(Command)
            'Command.Dispose()

            For Each rol As RolEntidad In Usuario.Rol
                Dim Command3 As SqlCommand = Acceso.MiComando("insert into UsuarioEntidad_RolEntidad values (@ID_Usuario,@ID_Rol)")
                With Command3.Parameters
                    .Add(New SqlParameter("@ID_Usuario", Usuario.ID_Usuario))
                    .Add(New SqlParameter("@ID_Rol", rol.ID_Rol))

                End With
                Acceso.Escritura(Command3)
            Next


            If Usuario.Bloqueo = True Then
                CrearToken(Usuario, True)


            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function CrearToken(usu As UsuarioEntidad, ByVal registro As Boolean) As String

        If usu.ID_Usuario = 0 Then
            Dim Command As SqlCommand = Acceso.MiComando("Select top 1 ID_Usuario from UsuarioEntidad where NombreUsuario=@NombreUsuario")
            With Command.Parameters
                .Add(New SqlParameter("@NombreUsuario", usu.NombreUsu))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                usu.ID_Usuario = dt.Rows(0)("ID_Usuario")
            End If
            Command.Dispose()
        End If

        Dim Command3 As SqlCommand = Acceso.MiComando("insert into Token_Usuario (ID_Token,ID_Usuario,Fecha_Expiro,Registro) values (@Token,@Usuario,@Fecha,@Registro)")
        Dim r As New Random
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        Dim cnt As Integer = r.Next(20, 35)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        With Command3.Parameters
            .Add(New SqlParameter("@Token", sb.ToString()))
            .Add(New SqlParameter("@Fecha", DateAdd(DateInterval.Day, 1, Now())))
            .Add(New SqlParameter("@Usuario", usu.ID_Usuario))
            .Add(New SqlParameter("@Registro", registro))
        End With
        Acceso.Escritura(Command3)
        Command3.Dispose()
        Return sb.ToString()
    End Function

    Public Sub LimpiarTokens(ByVal token As String)
        Dim Command As SqlCommand = Acceso.MiComando("Select u.ID_Usuario,TK.ID_Token from UsuarioEntidad as U inner join Token_Usuario as TK on U.ID_usuario=Tk.ID_Usuario where TK.Fecha_Expiro<getdate() or TK.ID_Token=@Token")
        With Command.Parameters
            .Add(New SqlParameter("@Token", token))
        End With
        Dim dt As DataTable = Acceso.Lectura(Command)
        Command.Dispose()
        For Each rw As DataRow In dt.Rows
            Dim CommandEliminacion As SqlCommand = Acceso.MiComando("Delete Token_Usuario where ID_token=@token and ID_usuario=@Usuario")
            With CommandEliminacion.Parameters
                .Add(New SqlParameter("@Token", rw("ID_Token")))
                .Add(New SqlParameter("@Usuario", rw("ID_Usuario")))
            End With
            Acceso.Escritura(CommandEliminacion)
        Next
    End Sub

    Public Function RefrescarUsuario(uSuario As UsuarioEntidad) As UsuarioEntidad
        Try
            Dim consulta As String = "Select Bloqueo from UsuarioEntidad where ID_Usuario=@ID_Usuario"

            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", uSuario.ID_Usuario))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                uSuario.Bloqueo = dt.Rows(0)("Bloqueo")
                Dim GestorPermisos As New GestorPermisosMPP
                uSuario.Rol = GestorPermisos.ConsultarporIDUsuario(uSuario.ID_Usuario)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Modificar(ByRef Usuario As UsuarioEntidad) As Boolean

        Try
            Dim Command As SqlCommand = Acceso.MiComando("update UsuarioEntidad set NombreUsuario=@NombreUsuario, Idioma=@Idioma where ID_Usuario=@ID_Usuario and BL=@BL")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", Usuario.ID_Usuario))
                .Add(New SqlParameter("@NombreUsuario", Usuario.NombreUsu))
                .Add(New SqlParameter("@Idioma", Usuario.Idioma.ID_Idioma))

                .Add(New SqlParameter("@BL", False))

            End With
            Acceso.Escritura(Command)
            Command.Dispose()


            Dim Command2 As SqlCommand = Acceso.MiComando("delete from UsuarioEntidad_RolEntidad where ID_Usuario=@ID_Usuario")
                With Command2.Parameters
                    .Add(New SqlParameter("@ID_Usuario", Usuario.ID_Usuario))
                End With
            Acceso.Escritura(Command2)
            Command2.Dispose()
            For Each rol As RolEntidad In Usuario.Rol
                Dim Command3 As SqlCommand = Acceso.MiComando("insert into UsuarioEntidad_RolEntidad values (@ID_Usuario,@ID_Rol)")
                With Command3.Parameters
                    .Add(New SqlParameter("@ID_Usuario", Usuario.ID_Usuario))
                    .Add(New SqlParameter("@ID_Rol", rol.ID_Rol))

                End With
                Acceso.Escritura(Command3)
            Next
            Return True
        Catch ex As Exception
            Throw ex
        End Try


    End Function








    Public Function GetToken(ByVal ID_usuario As Integer) As String
        Dim Command As SqlCommand = Acceso.MiComando("Select TOP 1 ID_Token from Token_Usuario inner join UsuarioEntidad on UsuarioEntidad.ID_Usuario=Token_Usuario.ID_Usuario where Token_Usuario.ID_Usuario=@Usuario and Fecha_Expiro>Getdate() and UsuarioEntidad.Bloqueo = 1 order by Fecha_Expiro desc")
        With Command.Parameters
            .Add(New SqlParameter("@Usuario", ID_usuario))
        End With
        Dim dt As DataTable = Acceso.Lectura(Command)
        Return dt.Rows(0)("ID_Token")
        Command.Dispose()
    End Function

    Public Function GetTokenUser(ByVal token As String) As Integer
        Dim Command As SqlCommand = Acceso.MiComando("Select TOP 1 Token_Usuario.ID_Usuario, UsuarioEntidad.NombreUsuario from Token_Usuario inner join UsuarioEntidad on UsuarioEntidad.ID_Usuario=Token_Usuario.ID_Usuario where ID_Token=@Token and Fecha_Expiro>Getdate()  order by Fecha_Expiro desc")
        With Command.Parameters
            .Add(New SqlParameter("@Token", token))
        End With
        Dim dt As DataTable = Acceso.Lectura(Command)
        Command.Dispose()
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("ID_Usuario")
        Else
            Return Nothing
        End If


    End Function

    Public Function Eliminar(ByRef Usuario As UsuarioEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Update UsuarioEntidad Set BL=@BL where ID_Usuario = @ID_Usuario")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@BL", True))
                .Add(New SqlParameter("@ID_Usuario", Usuario.ID_Usuario))

            End With
            Acceso.Escritura(Command)
            Command.Dispose()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TraerUsuario(ByVal Usuario As Entidades.UsuarioEntidad) As Entidades.UsuarioEntidad
        Try
            Dim GestorPermisos As New GestorPermisosMPP
            Usuario.Rol = GestorPermisos.ConsultarporIDUsuario(Usuario.ID_Usuario)
            Dim GestorIdioma As New IdiomaMPP
            Usuario.Idioma = GestorIdioma.ConsultarPorID(Usuario.Idioma.ID_Idioma)
            Return Usuario
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ExisteUsuario(ByVal Usuario As Entidades.UsuarioEntidad) As Entidades.UsuarioEntidad
        Try
            Dim consulta As String = "Select * from UsuarioEntidad  where NombreUsuario= @NombreUsuario And BL = 0 "
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@NombreUsuario", Usuario.NombreUsu))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                FormatearUsuario(Usuario, dt.Rows(0))
                Return Usuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BuscarUsuarioID(ByVal Usuario As Entidades.UsuarioEntidad) As Entidades.UsuarioEntidad
        Try
            Dim consulta As String = "Select * from UsuarioEntidad where ID_Usuario=@ID_Usuario"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", Usuario.ID_Usuario))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                FormatearUsuario(Usuario, dt.Rows(0))
                Return Usuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BuscarUsuarioIDBitacora(ByVal Usuario As Entidades.UsuarioEntidad) As Entidades.UsuarioEntidad
        Try
            Dim consulta As String = "Select * from UsuarioEntidad where ID_Usuario= @ID_Usuario"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", Usuario.ID_Usuario))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                FormatearUsuario(Usuario, dt.Rows(0))
                Return Usuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function VerificarPassword(ByVal Usuario As Entidades.UsuarioEntidad) As Boolean
        Try
            Dim consulta As String = "Select * from UsuarioEntidad where NombreUsuario= @NombreUsuario And Password= @Password And BL = 0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@NombreUsuario", Usuario.NombreUsu))
                .Add(New SqlParameter("@Password", Usuario.Password))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CambiarPassword(ByVal Usuario As Entidades.UsuarioEntidad) As Boolean
        Try

            Dim consulta As String = "update UsuarioEntidad set Password = @Password, salt= @Salt where ID_Usuario=@Usuario And BL = 0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
          
            With Command.Parameters
                .Add(New SqlParameter("@Usuario", Usuario.ID_Usuario))
                .Add(New SqlParameter("@Salt", Usuario.Salt))
                .Add(New SqlParameter("@Password", Usuario.Password))

            End With
            Acceso.Escritura(Command)

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ResetearIntentos(ByVal Usuario As Entidades.UsuarioEntidad)
        Try
            Dim Consulta As String = "update UsuarioEntidad set Intentos = @Intentos where NombreUsuario=@NombreUsuario and BL=0"
            Dim Command = Acceso.MiComando(Consulta)
            Usuario.Intento = 0
           
            With Command.Parameters
                .Add(New SqlParameter("@Intentos", Usuario.Intento))
                .Add(New SqlParameter("@NombreUsuario", Usuario.NombreUsu))

            End With

            Acceso.Escritura(Command)



        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function Bloquear(ByVal Usuario As Entidades.UsuarioEntidad) As Boolean
        Try
            If Usuario.Bloqueo = True Then
                Dim Consulta As String = "update UsuarioEntidad set Bloqueo = 0 where ID_Usuario=@Usuario and BL = 0"
                Dim Command = Acceso.MiComando(Consulta)
                Usuario.Bloqueo = False
              
                With Command.Parameters
                    .Add(New SqlParameter("@Usuario", Usuario.ID_Usuario))

                End With
                Acceso.Escritura(Command)
                Usuario.Bloqueo = False
                ResetearIntentos(Usuario)


                Return False
            Else
                Dim Consulta As String = "update UsuarioEntidad set Bloqueo = 1 where ID_Usuario=@Usuario and BL = 0"
                Dim Command = Acceso.MiComando(Consulta)
                Usuario.Bloqueo = True
                 
                With Command.Parameters
                    .Add(New SqlParameter("@Usuario", Usuario.ID_Usuario))

                End With
                Acceso.Escritura(Command)




                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SumarIntentos(ByVal Usuario As Entidades.UsuarioEntidad)
        Try
            Dim Consulta As String = "update UsuarioEntidad set Intentos = @Intentos, where NombreUsuario=@NombreUsuario and BL = 0"
            Dim Command = Acceso.MiComando(Consulta)
            
            With Command.Parameters
                .Add(New SqlParameter("@Intentos", Usuario.Intento))
                .Add(New SqlParameter("@NombreUsuario", Usuario.NombreUsu))
            End With
            Usuario = TraerUsuario(Usuario)



            Acceso.Escritura(Command)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function TraerUsuariosIdioma(ByVal id_idioma As Integer) As List(Of UsuarioEntidad)
        Try
            Dim consulta As String = "Select * from UsuarioEntidad where Bloqueo=0 and BL=0 and ID_Usuario <> 0 and ID_Idioma=@ID_Idioma"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Idioma", id_idioma))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaUsuario As List(Of UsuarioEntidad) = New List(Of UsuarioEntidad)
            For Each row As DataRow In dt.Rows
                Dim Usuario As UsuarioEntidad = New UsuarioEntidad
                FormatearUsuario(Usuario, row)
                ListaUsuario.Add(Usuario)
            Next
            Return ListaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TraerUsuariosPerfil(ByRef ID_Perfil As Integer) As List(Of UsuarioEntidad)
        Try
            Dim consulta As String = "Select * from UsuarioEntidad where Bloqueo=0 and BL=0 and ID_Usuario <> 0 and ID_Perfil=@ID_Perfil"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Perfil", ID_Perfil))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaUsuario As List(Of UsuarioEntidad) = New List(Of UsuarioEntidad)
            For Each row As DataRow In dt.Rows
                Dim Usuario As UsuarioEntidad = New UsuarioEntidad
                FormatearUsuario(Usuario, row)
                Usuario.Password = row.Item(2)
                ListaUsuario.Add(Usuario)
            Next
            Return ListaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TraerUsuarios() As List(Of UsuarioEntidad)
        Try
            Dim consulta As String = "Select * from UsuarioEntidad where Bloqueo=0 and BL=0 and ID_Usuario <> 0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaUsuario As List(Of UsuarioEntidad) = New List(Of UsuarioEntidad)
            For Each row As DataRow In dt.Rows
                Dim Usuario As UsuarioEntidad = New UsuarioEntidad
                FormatearUsuario(Usuario, row)
                ListaUsuario.Add(Usuario)
            Next
            Return ListaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TraerUsuariosParaBloqueo(ByRef Usuari As Entidades.UsuarioEntidad) As List(Of UsuarioEntidad)
        'Try
        '    Dim consulta As String = "Select Usuario.*, Permiso.Nombre as PermN,Idioma.Nombre as IdioN from UsuarioEntidad inner join Permiso on ID_Rol=ID_Perfil inner join Idioma on Usuario.ID_Idioma=Idioma.ID_Idioma where ID_Usuario <>0 and ID_Usuario <>@ID_Usuario and Usuario.BL=0"
        '    Dim Command As SqlCommand = Acceso.MiComando(consulta)
        '    With Command.Parameters
        '        .Add(New SqlParameter("@ID_Usuario", Usuari.ID_Usuario))
        '    End With
        '    Dim dt As DataTable = Acceso.Lectura(Command)
        '    Dim ListaUsuario As List(Of UsuarioEntidad) = New List(Of UsuarioEntidad)
        '    For Each row As DataRow In dt.Rows
        '        Dim Usuario As UsuarioEntidad = New UsuarioEntidad
        '        FormatearUsuario(Usuario, row)
        '        Usuario.Idioma.Nombre = row("IdioN")
        '        Usuario.Rol.Nombre = row("PermN")
        '        ListaUsuario.Add(Usuario)
        '    Next
        '    Return ListaUsuario
        'Catch ex As Exception
        '    Throw ex
        'End Try



        Try
            Dim consulta As String = "Select * from UsuarioEntidad where BL=0 and ID_Usuario <> 0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaUsuario As List(Of UsuarioEntidad) = New List(Of UsuarioEntidad)
            For Each row As DataRow In dt.Rows
                Dim Usuario As UsuarioEntidad = New UsuarioEntidad
                FormatearUsuario(Usuario, row)
                ListaUsuario.Add(Usuario)
            Next
            Return ListaUsuario
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub PerfilEliminadoActualizacion()
        Dim Command As SqlCommand = Acceso.MiComando("Select * from UsuarioEntidad where Perfil = @PerfilEliminado and BL =@BL")
        With Command.Parameters
            .Add(New SqlParameter("@PerfilEliminado", 0))
            .Add(New SqlParameter("@BL", False))
        End With
        Dim TableUsuarios As DataTable = Acceso.Lectura(Command)
        For Each row As DataRow In TableUsuarios.Rows
            Dim usuario As UsuarioEntidad = New UsuarioEntidad
            Dim UsuarioDAL As UsuarioMPP = New UsuarioMPP
            usuario.NombreUsu = row.Item(1)
            usuario = TraerUsuario(usuario)

            Dim Command2 As SqlCommand = Acceso.MiComando("update Usuario set DVH=@DVH where ID_Usuario = @ID_Usuario and BL = @BL")

            Dim ListaParametros As New List(Of String)
            Acceso.AgregarParametros(usuario, ListaParametros)
            ListaParametros.Add(False.ToString) 'Agregado de Baja Logica

            With Command2.Parameters
                .Add(New SqlParameter("@ID_Usuario", usuario.ID_Usuario))
                .Add(New SqlParameter("@BL", False))

            End With
            Acceso.Escritura(Command2)

        Next
        Command.Dispose()
    End Sub

    Public Sub IdiomaEliminadoActualizacion()
        'Dim Command As SqlCommand = Acceso.MiComando("Select * from UsuarioEntidad where Idioma = @Idioma and BL =@BL")
        'With Command.Parameters
        '    .Add(New SqlParameter("@Idioma", 1))
        '    .Add(New SqlParameter("@BL", False))
        'End With
        'Dim TableUsuarios As DataTable = Acceso.Lectura(Command)
        'For Each row As DataRow In TableUsuarios.Rows
        '    Dim usuario As UsuarioEntidad = New UsuarioEntidad
        '    Dim UsuarioDAL As UsuarioDAL = New UsuarioDAL
        '    usuario.NombreUsu = row.Item(1)
        '    usuario = TraerUsuario(usuario)
        '    Dim Command2 As SqlCommand = Acceso.MiComando("update Usuario set DVH=@DVH where ID_Usuario = @ID_Usuario and BL = @BL")

        '    Dim ListaParametros As New List(Of String)
        '    Acceso.AgregarParametros(usuario, ListaParametros)
        '    ListaParametros.Add(False.ToString) 'Agregado de Baja Logica

        '    With Command2.Parameters
        '        .Add(New SqlParameter("@ID_Usuario", usuario.ID_Usuario))
        '        .Add(New SqlParameter("@BL", False))
        '        .Add(New SqlParameter("@DVH", DigitoVerificadorDAL.CalcularDVH(ListaParametros)))
        '    End With
        '    Acceso.Escritura(Command2)

        'Next
        'Command.Dispose()
    End Sub


    Public Sub FormatearUsuario(ByVal Usuario As Entidades.UsuarioEntidad, ByVal row As DataRow)
        Try

            Usuario.ID_Usuario = row("ID_Usuario")
            Usuario.NombreUsu = row("NombreUsuario")
            Usuario.Apellido = row("Apellido")
            Usuario.Nombre = row("Nombre")
            Usuario.FechaAlta = row("Fecha_Alta")
            Usuario.Salt = row("Salt")
            Usuario.Password = row("Password")
            Usuario.Intento = row("Intentos")
            Usuario.Bloqueo = row("Bloqueo")
            Usuario.Idioma = New Entidades.IdiomaEntidad With {.ID_Idioma = row("Idioma")}
            TraerUsuario(Usuario)
            Usuario.Empleado = row("Empleado")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ProbarConectividad() As Boolean
        Try
            Dim MiConecction As New SqlCommand
            MiConecction.Connection = Acceso.MiConexion
            MiConecction.Connection.Open()
            If MiConecction.Connection.State = ConnectionState.Open Then
                MiConecction.Connection.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function




























End Class
