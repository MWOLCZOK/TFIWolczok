Imports System.Data.SqlClient
Imports DAL
Imports Entidades


Public Class ProductoMPP


    Public Function ActualizaImagen(imagen() As Byte, id_Producto As Integer) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("update ProductoEntidad set Imagen=@Imagen where ID_Producto=@ID_Producto")
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", id_Producto))
                .Add(New SqlParameter("@Imagen", imagen))
            End With
            Acceso.Escritura(Command)
            Command.Dispose()
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TraerProductosCatalogo(ByVal paginacion As Integer, Optional ByVal Modelo As String = Nothing, Optional ByVal Marca As String = Nothing, Optional ByVal PrecioHasta As Integer = Nothing, Optional ByVal PrecioDesde As Integer = Nothing, Optional ByVal LineaProducto As LineaProducto = Nothing, Optional ByVal CategoriaProducto As CategoriaProducto = Nothing) As List(Of ProductoEntidad)

        Try
            Dim consulta As String = "select * from ProductoEntidad where Precio between isnull(@PrecioDesde,0) and isnull(@PrecioHasta,999999999) and ID_Linea=isnull(@ID_Linea,ID_Linea) and ID_CategoriaProducto=isnull(@ID_CategoriaProducto,ID_CategoriaProducto) and Modelo like '%'+ isnull(@Modelo,Modelo) + '%' and Marca like '%'+ isnull(@Marca,Marca) + '%' AND BL=0 order by id_producto offset (@count) rows FETCH NEXT (@cant) ROWS ONLY"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@count", (paginacion - 1) * 5))
                .Add(New SqlParameter("@cant", 5))
                'Los IF debajo nos sirve para hacer consultas sin llenar todos los campos, para los filtros de busqueda de productos.
                If Not IsNothing(Modelo) Then
                    .Add(New SqlParameter("@Modelo", Modelo))
                Else
                    .Add(New SqlParameter("@Modelo", DBNull.Value))
                End If
                If Not IsNothing(Marca) Then
                    .Add(New SqlParameter("@Marca", Marca))
                Else
                    .Add(New SqlParameter("@Marca", DBNull.Value))
                End If

                .Add(New SqlParameter("@PrecioDesde", PrecioDesde))

                If PrecioHasta > 0 Then
                    .Add(New SqlParameter("@PrecioHasta", PrecioHasta))
                Else
                    .Add(New SqlParameter("@PrecioHasta", DBNull.Value))
                End If


                If Not IsNothing(LineaProducto) Then
                    If LineaProducto.ID_Linea > 0 Then
                        .Add(New SqlParameter("@ID_Linea", LineaProducto.ID_Linea))
                    Else
                        .Add(New SqlParameter("@ID_Linea", DBNull.Value))
                    End If
                Else
                    .Add(New SqlParameter("@ID_Linea", DBNull.Value))
                End If

                If Not IsNothing(CategoriaProducto) Then
                    If CategoriaProducto.ID_Categoria > 0 Then
                        .Add(New SqlParameter("@ID_CategoriaProducto", CategoriaProducto.ID_Categoria))
                    Else
                        .Add(New SqlParameter("@ID_CategoriaProducto", DBNull.Value))
                    End If
                Else
                    .Add(New SqlParameter("@ID_CategoriaProducto", DBNull.Value))
                End If

            End With

            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim Listaproducto As List(Of ProductoEntidad) = New List(Of ProductoEntidad)
            For Each row As DataRow In dt.Rows
                Dim Producto As ProductoEntidad = New ProductoEntidad
                FormatearProducto(Producto, row)
                Listaproducto.Add(Producto)
            Next
            Return Listaproducto
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TraerCantProductosCatalogo(ByVal paginacion As Integer, Optional ByVal Modelo As String = Nothing, Optional ByVal Marca As String = Nothing, Optional ByVal PrecioHasta As Integer = Nothing, Optional ByVal PrecioDesde As Integer = Nothing, Optional ByVal LineaProducto As LineaProducto = Nothing, Optional ByVal CategoriaProducto As CategoriaProducto = Nothing) As Integer

        Try
            Dim consulta As String = "select count(*) from ProductoEntidad where Precio between isnull(@PrecioDesde,0) and isnull(@PrecioHasta,999999999) and ID_Linea=isnull(@ID_Linea,ID_Linea) and ID_CategoriaProducto=isnull(@ID_CategoriaProducto,ID_CategoriaProducto) and Modelo like '%'+ isnull(@Modelo,Modelo) + '%' and Marca like '%'+ isnull(@Marca,Marca) + '%' AND BL=0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters

                'Los IF debajo nos sirve para hacer consultas sin llenar todos los campos, para los filtros de busqueda de productos.
                If Not IsNothing(Modelo) Then
                    .Add(New SqlParameter("@Modelo", Modelo))
                Else
                    .Add(New SqlParameter("@Modelo", DBNull.Value))
                End If
                If Not IsNothing(Marca) Then
                    .Add(New SqlParameter("@Marca", Marca))
                Else
                    .Add(New SqlParameter("@Marca", DBNull.Value))
                End If

                .Add(New SqlParameter("@PrecioDesde", PrecioDesde))

                If PrecioHasta > 0 Then
                    .Add(New SqlParameter("@PrecioHasta", PrecioHasta))
                Else
                    .Add(New SqlParameter("@PrecioHasta", DBNull.Value))
                End If

                If Not IsNothing(LineaProducto) Then
                    If LineaProducto.ID_Linea > 0 Then
                        .Add(New SqlParameter("@ID_Linea", LineaProducto.ID_Linea))
                    Else
                        .Add(New SqlParameter("@ID_Linea", DBNull.Value))
                    End If
                Else
                    .Add(New SqlParameter("@ID_Linea", DBNull.Value))
                End If

                If Not IsNothing(CategoriaProducto) Then
                    If CategoriaProducto.ID_Categoria > 0 Then
                        .Add(New SqlParameter("@ID_CategoriaProducto", CategoriaProducto.ID_Categoria))
                    Else
                        .Add(New SqlParameter("@ID_CategoriaProducto", DBNull.Value))
                    End If
                Else
                    .Add(New SqlParameter("@ID_CategoriaProducto", DBNull.Value))
                End If

            End With

            Dim dt As DataTable = Acceso.Lectura(Command)
            Return dt.Rows(0)(0) ' fila 0 , columna 0
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function Alta(ByRef Producto As ProductoEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("insert into ProductoEntidad (Marca,Modelo,Descripcion,Precio,Peso,Watt,Imagen,ID_Linea,ID_CategoriaProducto,BL) values (@Marca, @Modelo,@Descripcion,@Precio,@Peso,@Watt,@Imagen, @ID_Linea ,@ID_CategoriaProducto, @BL)")
            With Command.Parameters
                .Add(New SqlParameter("@Marca", Producto.Marca))
                .Add(New SqlParameter("@Modelo", Producto.Modelo))
                .Add(New SqlParameter("@Descripcion", Producto.Descripcion))
                .Add(New SqlParameter("@Precio", Producto.Precio))
                .Add(New SqlParameter("@Peso", Producto.Peso))
                .Add(New SqlParameter("@Watt", Producto.Watt))
                .Add(New SqlParameter("@Imagen", Producto.Imagen))
                .Add(New SqlParameter("@ID_Linea", Producto.LineaProducto.ID_Linea))
                .Add(New SqlParameter("@ID_CategoriaProducto", Producto.CategoriaProducto.ID_Categoria))
                .Add(New SqlParameter("@BL", False))
            End With
            Acceso.Escritura(Command)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Modificar(ByRef Producto As ProductoEntidad) As Boolean

        Try
            Dim Command As SqlCommand = Acceso.MiComando("update ProductoEntidad set Marca=@Marca, Modelo=@Modelo,Descripcion=@Descripcion, Precio=@Precio, Peso=@Peso, Watt=@Watt, Imagen=@Imagen, ID_Linea=@ID_Linea, ID_CategoriaProducto=ID_CategoriaProducto where ID_Producto=@ID_Producto and BL=@BL")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", Producto.ID_Producto))
                .Add(New SqlParameter("@Marca", Producto.Marca))
                .Add(New SqlParameter("@Modelo", Producto.Modelo))
                .Add(New SqlParameter("@Descripcion", Producto.Descripcion))
                .Add(New SqlParameter("@Precio", Producto.Precio))
                .Add(New SqlParameter("@Peso", Producto.Peso))
                .Add(New SqlParameter("@Watt", Producto.Watt))
                .Add(New SqlParameter("@Imagen", Producto.Imagen))
                .Add(New SqlParameter("@ID_Linea", Producto.LineaProducto.ID_Linea))
                .Add(New SqlParameter("@ID_CategoriaProducto", Producto.CategoriaProducto.ID_Categoria))
                .Add(New SqlParameter("@BL", False))

            End With
            Acceso.Escritura(Command)
            Command.Dispose()

            Return True
        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function Eliminar(ByRef Producto As ProductoEntidad) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("Update ProductoEntidad Set BL=@BL where ID_Producto = @ID_Producto")
            Dim ListaParametros As New List(Of String)

            With Command.Parameters
                .Add(New SqlParameter("@BL", True))
                .Add(New SqlParameter("@ID_Producto", Producto.ID_Producto))

            End With
            Acceso.Escritura(Command)
            Command.Dispose()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function TraerProducto(ByVal producto As ProductoEntidad) As ProductoEntidad
        Try
            Dim consulta As String = "Select * from ProductoEntidad where ID_Producto=@ID_Producto"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@ID_Producto", producto.ID_Producto))
            End With
            Dim dt As DataTable = Acceso.Lectura(Command)
            If dt.Rows.Count > 0 Then
                FormatearProducto(producto, dt.Rows(0))
                Return producto
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TraerTodosProductos() As List(Of ProductoEntidad)
        Try
            Dim consulta As String = "Select * from ProductoEntidad where BL=0 and ID_Producto <> 0"
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            Dim dt As DataTable = Acceso.Lectura(Command)
            Dim ListaProducto As List(Of ProductoEntidad) = New List(Of ProductoEntidad)
            For Each row As DataRow In dt.Rows
                Dim prod As ProductoEntidad = New ProductoEntidad
                FormatearProducto(prod, row)
                ListaProducto.Add(prod)
            Next
            Return ListaProducto
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidarNombre(ByVal Modelo As String) As Boolean
        Try
            Dim Command As SqlCommand = Acceso.MiComando("select Modelo from ProductoEntidad where Modelo=@Modelo")
            Command.Parameters.Add(New SqlParameter("@Modelo", Modelo))
            Dim DataTabla = Acceso.Lectura(Command)
            If DataTabla.Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ExisteModelo(ByVal Producto As ProductoEntidad) As Boolean
        Try
            Dim consulta As String = "Select * from ProductoEntidad  where Modelo= @Modelo and Marca=@Marca And BL = 0 "
            Dim Command As SqlCommand = Acceso.MiComando(consulta)
            With Command.Parameters
                .Add(New SqlParameter("@Modelo", Producto.Modelo))
                .Add(New SqlParameter("@Marca", Producto.Marca))
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




    Public Sub FormatearProducto(ByVal Producto As Entidades.ProductoEntidad, ByVal row As DataRow)
        Try

            Producto.ID_Producto = row("ID_Producto")
            Producto.Marca = row("Marca")
            Producto.Modelo = row("Modelo")
            Producto.Descripcion = row("Descripcion")
            Producto.Peso = row("Peso")
            Producto.Watt = row("Watt")
            Producto.Imagen = row("Imagen")
            Producto.Precio = row("Precio")
            Dim lineaproductoMPP As New LineaProductoMPP
            Producto.LineaProducto = lineaproductoMPP.obtenerLineaProducto(New LineaProducto With {.ID_Linea = row("ID_Linea")})
            Dim categoriaprodMPP As New CategoriaProductoMPP
            Producto.CategoriaProducto = categoriaprodMPP.obtenerCategoriaProducto(New CategoriaProducto With {.ID_Categoria = row("ID_CategoriaProducto")})


        Catch ex As Exception
            Throw ex
        End Try
    End Sub






End Class
