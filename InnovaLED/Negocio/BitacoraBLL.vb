Imports Mapper
Imports System.Reflection
Imports Entidades
Imports System.Threading
Imports System.Globalization
Imports System.IO


Public Class BitacoraBLL

    Private BitacoraMPP As New Mapper.BitacoraMPP


    Public Function ListarBitacoras(Optional ByVal tipoBitacora As Tipo_Bitacora = Nothing, Optional ByVal Desde As Date = Nothing, Optional ByVal Hasta As Date = Nothing, Optional ByRef Usu As Entidades.UsuarioEntidad = Nothing) As List(Of Entidades.Bitacora)
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


    Private Shared Sub GenerarLeyenda(ByRef bita As Bitacora, ByVal ObjectoAnterior As Object, ByVal ObjetoActual As Object)
        Dim ParamtrosValorables As New Dictionary(Of String, String)
        ParamtrosValorables.Add("Traduccion", 1)

        Dim parametros As New Dictionary(Of String, String)
        Dim _type As Type = ObjectoAnterior.GetType()
        Dim properties() As PropertyInfo = _type.GetProperties()
        For Each _property As PropertyInfo In properties
            If _property.PropertyType.FullName.Contains("Entidades.") Then
                If Not _property.PropertyType.FullName.Contains("Collections.") Then
                    If _property.PropertyType.GetProperties.Count > 0 Then
                        For Each _property2 As PropertyInfo In _property.PropertyType.GetProperties
                            Dim Objeto As Object = _property.GetValue(ObjectoAnterior, Nothing)
                            If _property2.Name.Contains("ID") Then
                                parametros.Add(_property2.Name, _property2.GetValue(Objeto, Nothing).ToString)
                                Exit For
                            End If
                        Next
                    Else
                        parametros.Add(_property.Name, _property.GetValue(ObjectoAnterior, Nothing).ToString)
                    End If

                Else
                    Dim Objeto As Object = _property.GetValue(ObjectoAnterior, Nothing)
                    If Not IsNothing(Objeto) Then
                        For Each Obj As Object In Objeto
                            Dim _typ As Type = Obj.GetType()
                            Dim propertie() As PropertyInfo = _typ.GetProperties()
                            Dim Valor As String = Nothing
                            For Each _property3 As PropertyInfo In propertie
                                If ParamtrosValorables.ContainsKey(_property3.Name) Then
                                    Valor = _property3.GetValue(Obj, Nothing).ToString()
                                End If
                                If _property3.Name.Contains("ID") Then
                                    parametros.Add(_property3.Name & "_child_" & _property3.GetValue(Obj, Nothing).ToString, IIf(IsNothing(Valor), _property3.GetValue(Obj, Nothing).ToString, Valor))
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                End If
            Else
                parametros.Add(_property.Name, _property.GetValue(ObjectoAnterior, Nothing).ToString)
            End If
        Next
        Dim parametros2 As New Dictionary(Of String, String)
        Dim _type2 As Type = ObjetoActual.GetType()
        Dim properties3() As PropertyInfo = _type.GetProperties()
        For Each _property4 As PropertyInfo In properties3
            If _property4.PropertyType.FullName.Contains("Entidades.") Then
                If Not _property4.PropertyType.FullName.Contains("Collections.") Then
                    If _property4.PropertyType.GetProperties.Count > 0 Then
                        For Each _property5 As PropertyInfo In _property4.PropertyType.GetProperties
                            Dim Objeto As Object = _property4.GetValue(ObjetoActual, Nothing)
                            If _property5.Name.Contains("ID") Then
                                parametros2.Add(_property5.Name, _property5.GetValue(Objeto, Nothing).ToString)
                                Exit For
                            End If
                        Next
                    Else
                        parametros2.Add(_property4.Name, _property4.GetValue(ObjetoActual, Nothing).ToString)
                    End If
                Else
                    Dim Objeto As Object = _property4.GetValue(ObjetoActual, Nothing)
                    If Not IsNothing(Objeto) Then
                        For Each Obj As Object In Objeto
                            Dim _typ As Type = Obj.GetType()
                            Dim propertie() As PropertyInfo = _typ.GetProperties()
                            Dim Valor As String = Nothing
                            For Each _property3 As PropertyInfo In propertie
                                If ParamtrosValorables.ContainsKey(_property3.Name) Then
                                    Valor = _property3.GetValue(Obj, Nothing).ToString()
                                End If
                                If _property3.Name.Contains("ID") Then
                                    parametros2.Add(_property3.Name & "_child_" & _property3.GetValue(Obj, Nothing).ToString, IIf(IsNothing(Valor), _property3.GetValue(Obj, Nothing).ToString, Valor))
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                End If
            Else
                parametros2.Add(_property4.Name, _property4.GetValue(ObjetoActual, Nothing).ToString)
            End If
        Next
        Dim index As Integer = 0
        For Each propiedad In parametros.Keys
            If parametros2.ContainsKey(propiedad) Then
                If Not parametros(propiedad) = parametros2(propiedad) Then
                    bita.Valor_Anterior += propiedad & ": " & parametros(propiedad) & " - "
                    bita.Valor_Posterior += propiedad & ": " & parametros2(propiedad) & " - "
                End If
            Else
                bita.Valor_Anterior += propiedad & ": " & parametros(propiedad) & " - "
            End If
        Next
        For Each propiedad In parametros2.Keys
            If Not parametros.ContainsKey(propiedad) Then
                bita.Valor_Posterior += propiedad & ": " & parametros2(propiedad) & " - "
            End If
        Next
        If bita.Valor_Anterior.Length > 0 Then
            bita.Valor_Anterior = Left(bita.Valor_Anterior, bita.Valor_Anterior.Length - 3)
        End If
        If bita.Valor_Posterior.Length > 0 Then
            bita.Valor_Posterior = Left(bita.Valor_Posterior, bita.Valor_Posterior.Length - 3)
        End If
    End Sub




End Class
