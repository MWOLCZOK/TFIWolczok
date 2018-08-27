Imports Mapper
Imports System.Reflection
Imports Entidades
Imports System.Threading
Imports System.Globalization
Imports System.IO


Public Class BitacoraBLL

    Private BitacoraMPP As New Mapper.BitacoraMPP


    Public Function ListarBitacoras(Optional ByVal tipoBitacora As Tipo_Bitacora = Nothing, Optional ByVal Desde As Date = Nothing, Optional ByVal Hasta As Date = Nothing, Optional ByRef Usu As Entidades.UsuarioEntidad = Nothing) As List(Of Entidades.BitacoraAuditoria)
        Return BitacoraMPP.ConsultarBitacora(tipoBitacora, Desde, Hasta, Usu)
    End Function




    Public Shared Sub CrearBitacora(ByRef Bita As Bitacora, Optional ByRef ObjetoAnt As Object = Nothing, Optional ByRef ObjetoAct As Object = Nothing)
        Bita.Fecha = Bita.Fecha.AddMilliseconds(-Bita.Fecha.Millisecond)
        Dim p = Bita.Fecha.Millisecond
        Dim bitdal As New Mapper.BitacoraMPP
        Try
            If IsNothing(ObjetoAnt) And IsNothing(ObjetoAct) Then
                bitdal.GuardarBitacora(Bita)
            Else
                GenerarLeyenda(Bita, ObjetoAnt, ObjetoAct)
                bitdal.GuardarBitacora(Bita)
            End If
        Catch ex As Exception
            ArchivarBitacora(Bita)
        End Try
    End Sub


    Public Shared Sub ArchivarBitacora(ByRef Bitacora As Bitacora)
        Dim bitaudit As New Bitacora


        If Bitacora.GetType() = bitaudit.GetType Then
            Dim Jsonarray As SerializadorJSON(Of List(Of Bitacora)) = New SerializadorJSON(Of List(Of Bitacora))
            If File.Exists("Bitacora.json") Then
                Dim mistreamreader = File.Open("Bitacora.json", FileMode.Open, FileAccess.Read)
                Dim p As List(Of Bitacora) = Jsonarray.Deserializar(mistreamreader, New List(Of Bitacora))
                mistreamreader.Close()
                File.Delete("Bitacora.json")
                p.Add(Bitacora)
                Jsonarray.Serializar(p)
            Else
                Dim mistream = File.Open("Bitacora.json", FileMode.Create)
                Dim p As New List(Of Bitacora)
                p.Add(Bitacora)
                mistream.Close()
                Jsonarray.Serializar(p)
            End If
        End If
    End Sub

    Public Function makeLog(log As Entidades.Bitacora) As Boolean
        Return BitacoraMPP.GuardarBitacora(log)
    End Function




    'Continuar







End Class
