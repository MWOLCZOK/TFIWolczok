Imports Entidades
Imports Mapper



Public Class GestorProductoBLL

    Private ProductoMPP As New ProductoMPP
    Private ProductoEntidad As New ProductoEntidad

    Public Function Alta(ByVal Producto As ProductoEntidad) As Boolean
        Try
            If Not Me.ExisteModelo(Producto) Then
                If ProductoMPP.Alta(Producto) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Throw New ExceptionNombreEnUso
            End If

        Catch NombreUso As ExceptionNombreEnUso
            Throw NombreUso
        Catch FalloConexion As InvalidOperationException

            Throw FalloConexion
        Catch ex As Exception

            Throw ex
        End Try
    End Function


    Public Function Modificar(ByVal Producto As ProductoEntidad) As Boolean
        Try
            If ProductoMPP.Modificar(Producto) Then
                Return True
            Else
                Return False
            End If
        Catch FalloConexion As InvalidOperationException

            Throw FalloConexion
        Catch ex As Exception

        End Try

    End Function


    Public Function Eliminar(ByVal Producto As ProductoEntidad) As Boolean
        Try
            If ProductoMPP.Eliminar(Producto) Then
                Return True
            Else
                Return False
            End If
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TraerProducto(ByVal prod As ProductoEntidad) As ProductoEntidad
        Return ProductoMPP.TraerProducto(prod)

    End Function

    Public Function TraerTodosProductos() As List(Of ProductoEntidad)
        Return ProductoMPP.TraerTodosProductos()

    End Function


    Public Function ValidarNombre(ByVal Modelo As String) As Boolean
        Try

            ProductoMPP.ValidarNombre(Modelo)
        Catch FalloConexion As InvalidOperationException
            Throw FalloConexion
        Catch ex As Exception
            'BitacoraBLL.CrearBitacora("El Metodo " & ex.TargetSite.ToString & " generó un error. Su mensaje es: " & ex.Message, TipoBitacora.Errores, (New UsuarioEntidad With {.ID_Usuario = 0, .Nombre = "Sistema"}))
            Throw ex
        End Try
    End Function


    Public Function ExisteModelo(prod As ProductoEntidad) As Boolean
        Try
            Return (New ProductoMPP).ExisteModelo(prod)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ActualizaImagen(imagen() As Byte, id_Producto As Integer)
        ProductoMPP.ActualizaImagen(imagen, id_Producto)
    End Sub


    Public Function TraerProductosCatalogo(paginacion As Integer, Optional ByVal Modelo As String = Nothing, Optional ByVal Marca As String = Nothing, Optional ByVal PrecioHasta As Integer = Nothing, Optional ByVal PrecioDesde As Integer = Nothing, Optional ByVal PesoHasta As Integer = Nothing, Optional ByVal PesoDesde As Integer = Nothing, Optional ByVal WattHasta As Integer = Nothing, Optional ByVal WattDesde As Integer = Nothing, Optional ByVal LineaProducto As Entidades.LineaProducto = Nothing, Optional ByVal CategoriaProducto As Entidades.CategoriaProducto = Nothing) As List(Of Entidades.ProductoEntidad)
        Return ProductoMPP.TraerProductosCatalogo(paginacion, Modelo, Marca, PrecioHasta, PrecioDesde, PesoHasta, PesoDesde, WattHasta, WattDesde, LineaProducto, CategoriaProducto)

    End Function


    Public Function TraerCantProductosCatalogo(paginacion As Integer, Optional ByVal Modelo As String = Nothing, Optional ByVal Marca As String = Nothing, Optional ByVal PrecioHasta As Integer = Nothing, Optional ByVal PrecioDesde As Integer = Nothing, Optional ByVal PesoHasta As Integer = Nothing, Optional ByVal PesoDesde As Integer = Nothing, Optional ByVal WattHasta As Integer = Nothing, Optional ByVal WattDesde As Integer = Nothing, Optional ByVal LineaProducto As Entidades.LineaProducto = Nothing, Optional ByVal CategoriaProducto As Entidades.CategoriaProducto = Nothing) As Integer
        Return ProductoMPP.TraerCantProductosCatalogo(paginacion, Modelo, Marca, PrecioHasta, PrecioDesde, PesoHasta, PesoDesde, WattHasta, WattDesde, LineaProducto, CategoriaProducto)

    End Function






End Class
