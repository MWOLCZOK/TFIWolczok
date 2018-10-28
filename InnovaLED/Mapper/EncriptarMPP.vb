Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.ComponentModel
Public Class EncriptarMPP
    Public Shared Function Encriptar(ByVal paramTexto As String) As String
        Dim CyphMode As CipherMode = CipherMode.ECB
        Dim Key As String = "INNOVALED"
        Try
            Dim Des As New TripleDESCryptoServiceProvider
            Dim InputbyteArray() As Byte = Encoding.Default.GetBytes(paramTexto)
            Dim hashMD5 As New MD5CryptoServiceProvider
            Des.Key = hashMD5.ComputeHash(Encoding.Default.GetBytes(Key))
            Des.Mode = CyphMode
            Dim ms As MemoryStream = New MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateEncryptor(), CryptoStreamMode.Write)
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()
            Dim ret As StringBuilder = New StringBuilder
            Dim b() As Byte = ms.ToArray
            ms.Close()
            Dim I As Integer
            For I = 0 To UBound(b)
                ret.AppendFormat("{0:X2}", b(I))
            Next
            Return ret.ToString
        Catch ex As System.Security.Cryptography.CryptographicException
            Throw ex
        End Try
    End Function

    Public Shared Function Desencriptar(ByVal paramTexto As String) As String
        Dim CyphMode As CipherMode = CipherMode.ECB
        Dim Key As String = "INNOVALED"
        Try
            If paramTexto = String.Empty Then
                Return ""
            Else
                Dim Des As New TripleDESCryptoServiceProvider
                Dim InputbyteArray(CType(paramTexto.Length / 2 - 1, Integer)) As Byte
                Dim hashMD5 As New MD5CryptoServiceProvider
                Des.Key = hashMD5.ComputeHash(Encoding.Default.GetBytes(Key))
                Des.Mode = CyphMode
                Dim X As Integer
                For X = 0 To InputbyteArray.Length - 1
                    Dim IJ As Int32 = (Convert.ToInt32(paramTexto.Substring(X * 2, 2), 16))
                    Dim BT As New ByteConverter
                    InputbyteArray(X) = New Byte
                    InputbyteArray(X) = CType(BT.ConvertTo(IJ, GetType(Byte)), Byte)
                Next
                Dim ms As MemoryStream = New MemoryStream
                Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateDecryptor(), CryptoStreamMode.Write)
                cs.Write(InputbyteArray, 0, InputbyteArray.Length)
                cs.FlushFinalBlock()
                Dim ret As StringBuilder = New StringBuilder
                Dim B() As Byte = ms.ToArray
                ms.Close()
                Dim I As Integer
                For I = 0 To UBound(B)
                    ret.Append(Chr(B(I)))
                Next
                Return ret.ToString
            End If
        Catch ex As System.Security.Cryptography.CryptographicException
            Throw ex
        End Try
    End Function


End Class