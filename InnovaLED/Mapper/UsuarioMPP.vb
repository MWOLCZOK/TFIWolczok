Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Entidades
Imports DAL




Public Class UsuarioMPP

    Public Function Alta(ByRef Usuario As UsuarioEntidad) As Boolean
        Try

            Return True
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Public Function CrearToken(usu As UsuarioEntidad, ByVal registro As Boolean) As String

        If usu.ID_Usuario = 0 Then
            Dim Command As SqlCommand = Acceso.MiComando("Select top 1 ID_Usuario from Usuario where NombreUsuario=@NombreUsuario")
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
        Dim Command As SqlCommand = Acceso.MiComando("Select u.ID_Usuario,TK.ID_Token from Usuario as U inner join Token_Usuario as TK on U.ID_usuario=Tk.ID_Usuario where TK.Fecha_Expiro<getdate() or TK.ID_Token=@Token")
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
            Dim consulta As String = "Select Bloqueo,ID_Perfil from Usuario where ID_Usuario=@ID_Usuario"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Usuario", uSuario.ID_Usuario))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                uSuario.Bloqueo = dt.Rows(0)("Bloqueo")
                Dim GestorPermisos As New GestorPermisosMPP
                uSuario.Perfil = GestorPermisos.ConsultarporID(dt.Rows(0)("ID_Perfil"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Modificar(ByRef Usuario As UsuarioEntidad) As Boolean

        Return True
        Catch ex As Exception
        Throw ex
        End Try
    End Function





End Class
