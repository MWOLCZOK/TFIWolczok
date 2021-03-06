﻿Imports Entidades
Imports Mapper


Public Class BackupRestoreBLL

    Private _backuprestoredal As BackupRestoreMPP
    Private _backuprestoreentidad As BackupRestoreEntidad
    Private Bitacora As New BitacoraBLL

    Public Function CrearBackup(ByRef directorio As String, ByRef nombre As String, ByRef usuario As UsuarioEntidad) As Boolean
        Try
            Me._backuprestoreentidad = New BackupRestoreEntidad(nombre, usuario, directorio)
            Me._backuprestoredal = New BackupRestoreMPP
            If Me._backuprestoredal.RealizarBackup(Me._backuprestoreentidad) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function RealizarRestore(ByRef BackupEntidad As BackupRestoreEntidad) As Boolean
        Try
            _backuprestoredal = New BackupRestoreMPP
            If _backuprestoredal.RealizarRestore(BackupEntidad) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function




End Class
