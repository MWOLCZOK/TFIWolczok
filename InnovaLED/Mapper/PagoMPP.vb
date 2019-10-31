Imports DAL
Imports Entidades
Imports System.Data.SqlClient


Public Class PagoMPP


    Public Function Alta(ByVal pago As PagoEntidad, Optional ByVal notas As List(Of DocumentoFinancieroEntidad) = Nothing) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into Pago (ID_Fact,TipoPago,Fecha,BL) values (@ID_Fact,@TipoPago,@Fecha,@BL)")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Fact", pago.Factura.ID))
                .Add(New SqlParameter("TipoPago", pago.TipoPago))
                .Add(New SqlParameter("Fecha", pago.Fecha))
                .Add(New SqlParameter("BL", False))
            End With
            Acceso.Escritura(Command)

            'Asigno Notas a Factura
            If Not IsNothing(notas) Then ' "Si no es nada, que prosiga con lo que viene"


                For Each _nota As DocumentoFinancieroEntidad In notas
                    Dim Command3 As SqlCommand = Acceso.MiComando("insert into Factura_DocFinanciero (ID_Fact,ID_DocFinanciero,Monto,Fecha) values (@ID_Fact,@ID_DocFinanciero,@Monto,@Fecha)")
                    With Command3.Parameters
                        .Add(New SqlParameter("@ID_Fact", pago.Factura.ID))
                        .Add(New SqlParameter("@ID_DocFinanciero", _nota.ID))
                        .Add(New SqlParameter("@Monto", _nota.Monto))
                        .Add(New SqlParameter("@Fecha", Now))
                    End With
                    Acceso.Escritura(Command3)
                Next

                ''Genero una variable y recorro la lista

                'Dim SumNotas As Single = 0
                'For Each notascredito As DocumentoFinancieroEntidad In notas
                '    SumNotas = SumNotas + notascredito.Monto
                'Next

                ''Aca pregunto, si el total de las notas es mayor al monto de la factura total, generar la NC.
                'If SumNotas > pago.Factura.MontoTotal Then
                '    Dim Nota_CredMPP As New DocumentoFinancieroMPP
                '    Dim Nota_Cred_Entidad As New DocumentoFinancieroEntidad
                '    Nota_Cred_Entidad.Descripcion = "Nota de Credito generada por diferencia en compra a favor de Cliente."
                '    Nota_Cred_Entidad.Tipo_Documento = 1
                '    Nota_Cred_Entidad.Monto = SumNotas - pago.Factura.MontoTotal
                '    Nota_Cred_Entidad.Usuario = pago.Factura.Cliente
                '    Nota_CredMPP.Alta(Nota_Cred_Entidad)
                'End If
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub FormatearPago(ByVal Pago As PagoEntidad, ByVal row As DataRow)
        Try
            Pago.ID_Pago = row("ID_Pago")
            Pago.Factura = (New FacturaMPP).BuscarFacturaID(New FacturaEntidad With {.ID = row("ID_Fact")})
            Pago.TipoPago = row("TipoPago")
            Pago.Fecha = row("Fecha")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ConsultaTarjeta(ByVal Nro_Tarjeta As String, ByVal Nombre_Ape As String, ByVal Fecha_expiracion As String, ByVal Codigo_Seguridad As Integer)
        Try
            Dim consulta As String = "Select * from Tarjeta where  Nro_Tarjeta=@Nro_Tarjeta and Nombre_Ape=@Nombre_Ape and Fecha_expiracion=@Fecha_expiracion and Codigo_Seguridad=@Codigo_Seguridad and Bloqueada=0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@Nro_Tarjeta", Nro_Tarjeta))
                .Add(New SqlParameter("@Nombre_Ape", Nombre_Ape))
                .Add(New SqlParameter("@Fecha_expiracion", Fecha_expiracion))
                .Add(New SqlParameter("@Codigo_Seguridad", Codigo_Seguridad))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

            Return False
        End Try
    End Function




End Class
