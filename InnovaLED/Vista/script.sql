USE [master]
GO
/****** Object:  Database [InnovaLED]    Script Date: 12/9/2018 01:01:14 ******/
CREATE DATABASE [InnovaLED]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InnovaLED', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\InnovaLED.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'InnovaLED_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\InnovaLED_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [InnovaLED] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InnovaLED].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InnovaLED] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InnovaLED] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InnovaLED] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InnovaLED] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InnovaLED] SET ARITHABORT OFF 
GO
ALTER DATABASE [InnovaLED] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InnovaLED] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InnovaLED] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InnovaLED] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InnovaLED] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InnovaLED] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InnovaLED] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InnovaLED] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InnovaLED] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InnovaLED] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InnovaLED] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InnovaLED] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InnovaLED] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InnovaLED] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InnovaLED] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InnovaLED] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InnovaLED] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InnovaLED] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InnovaLED] SET  MULTI_USER 
GO
ALTER DATABASE [InnovaLED] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InnovaLED] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InnovaLED] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InnovaLED] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [InnovaLED] SET DELAYED_DURABILITY = DISABLED 
GO
USE [InnovaLED]
GO
/****** Object:  Table [dbo].[BackupRestoreEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BackupRestoreEntidad](
	[_directorio] [varchar](50) NULL,
	[_nombre] [varchar](50) NULL,
	[backupRestoreEntidadID] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BitacoraEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BitacoraEntidad](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Detalle] [varchar](250) NOT NULL,
	[Fecha] [datetime2](0) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[IP_Usuario] [nvarchar](250) NOT NULL,
	[WebBrowser] [nvarchar](200) NOT NULL,
	[Tipo_Bitacora] [varchar](200) NOT NULL,
	[Valor_Anterior] [varchar](250) NOT NULL,
	[Valor_Posterior] [varchar](250) NOT NULL,
	[URL] [nvarchar](max) NULL,
 CONSTRAINT [PK_BitacoraEntidad] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClienteEntidad](
	[CorreoElectronico] [varchar](50) NULL,
	[Domicilio] [varchar](50) NULL,
	[ID] [int] NULL,
	[RazonSocial] [varchar](50) NULL,
	[Telefono] [int] NULL,
	[clienteEntidadID] [int] NOT NULL,
	[presupuestoEntidadID] [int] NOT NULL,
	[facturaEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_ClienteEntidad] PRIMARY KEY CLUSTERED 
(
	[clienteEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Control]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Control](
	[ID_Control] [int] NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Control] PRIMARY KEY CLUSTERED 
(
	[ID_Control] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleFacturaEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFacturaEntidad](
	[Cantidad] [int] NULL,
	[Monto] [int] NULL,
	[facturaEntidadID] [int] NOT NULL,
	[detalleFacturaEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_DetalleFacturaEntidad] PRIMARY KEY CLUSTERED 
(
	[detalleFacturaEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetallePedidoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedidoEntidad](
	[Cantidad] [int] NULL,
	[detallePedidoEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_DetallePedidoEntidad] PRIMARY KEY CLUSTERED 
(
	[detallePedidoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DocFinancieroEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocFinancieroEntidad](
	[CUITProveedor] [int] NULL,
	[Descripcion] [varchar](50) NULL,
	[ID] [int] NULL,
	[Monto] [int] NULL,
	[TipoMonto] [int] NULL,
	[docFinancieroEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_DocFinancieroEntidad] PRIMARY KEY CLUSTERED 
(
	[docFinancieroEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnvioEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnvioEntidad](
	[FechayHora] [datetime] NULL,
	[Precio] [int] NULL,
	[envioEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_EnvioEntidad] PRIMARY KEY CLUSTERED 
(
	[envioEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FacturaEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaEntidad](
	[ID] [int] NULL,
	[MontoTotal] [int] NULL,
	[facturaEntidadID] [int] NOT NULL,
	[envioEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_FacturaEntidad] PRIMARY KEY CLUSTERED 
(
	[facturaEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdiomaEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IdiomaEntidad](
	[ID_Idioma] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
	[Editable] [varchar](250) NOT NULL,
	[Cultura] [nvarchar](250) NOT NULL,
	[BL] [bit] NOT NULL,
 CONSTRAINT [PK_IdiomaEntidad] PRIMARY KEY CLUSTERED 
(
	[ID_Idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JoinDetallePedidoEntidadToNotaPedidoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinDetallePedidoEntidadToNotaPedidoEntidad](
	[notaPedidoEntidadID] [int] NULL,
	[detallePedidoEntidadID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JoinProveedorEntidadToPagoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinProveedorEntidadToPagoEntidad](
	[pagoEntidadID] [int] NULL,
	[proveedorEntidadID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JoinTipoRecintoEntidadToRecintoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinTipoRecintoEntidadToRecintoEntidad](
	[recintoEntidadID] [int] NULL,
	[tipoRecintoEntidadID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JoinTransporteEntidadToEnvioEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JoinTransporteEntidadToEnvioEntidad](
	[envioEntidadID] [int] NULL,
	[transporteEntidadID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotaPedidoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotaPedidoEntidad](
	[ID] [int] NULL,
	[notaPedidoEntidadID] [int] NOT NULL,
	[Observacion] [varchar](50) NULL,
 CONSTRAINT [PK_NotaPedidoEntidad] PRIMARY KEY CLUSTERED 
(
	[notaPedidoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PagoEntidad](
	[Detalle] [varchar](50) NULL,
	[ID] [int] NULL,
	[Monto] [int] NULL,
	[pagoEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_PagoEntidad] PRIMARY KEY CLUSTERED 
(
	[pagoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PermisoBaseEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermisoBaseEntidad](
	[ID_Permiso] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[URL] [varchar](200) NOT NULL,
 CONSTRAINT [PK_PermisoBaseEntidad_1] PRIMARY KEY CLUSTERED 
(
	[ID_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PresupuestoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PresupuestoEntidad](
	[Monto] [int] NULL,
	[ID] [int] NULL,
	[recintoEntidadID] [int] NOT NULL,
	[presupuestoEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_PresupuestoEntidad] PRIMARY KEY CLUSTERED 
(
	[presupuestoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductoEntidad](
	[ID] [int] NULL,
	[Modelo] [varchar](50) NULL,
	[Peso] [int] NULL,
	[Precio] [int] NULL,
	[Watt] [int] NULL,
	[productoEntidadID] [int] NOT NULL,
	[recintoEntidadID] [int] NOT NULL,
	[stockEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_ProductoEntidad] PRIMARY KEY CLUSTERED 
(
	[productoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProveedorEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProveedorEntidad](
	[Correo] [varchar](50) NULL,
	[Domicilio] [varchar](50) NULL,
	[ID] [int] NULL,
	[RazonSocial] [varchar](50) NULL,
	[Telefono] [int] NULL,
	[proveedorEntidadID] [int] NOT NULL,
	[notaPedidoEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_ProveedorEntidad] PRIMARY KEY CLUSTERED 
(
	[proveedorEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecintoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecintoEntidad](
	[ConsumoWatt] [int] NULL,
	[ID] [int] NULL,
	[recintoEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_RecintoEntidad] PRIMARY KEY CLUSTERED 
(
	[recintoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolEntidad](
	[ID_Rol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RolEntidad] PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RolEntidad_PermisoBaseEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolEntidad_PermisoBaseEntidad](
	[ID_Rol] [int] NOT NULL,
	[ID_PermisoBase] [int] NOT NULL,
 CONSTRAINT [PK_RolEntidad_PermisoBaseEntidad] PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC,
	[ID_PermisoBase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockEntidad](
	[Cantidad] [int] NULL,
	[ID] [int] NULL,
	[stockEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_StockEntidad] PRIMARY KEY CLUSTERED 
(
	[stockEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tipo_LuminariaEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipo_LuminariaEntidad](
	[ID] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Tamaño] [int] NULL,
	[tipo_LuminariaEntidadID] [int] NOT NULL,
	[productoEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_Tipo_LuminariaEntidad] PRIMARY KEY CLUSTERED 
(
	[tipo_LuminariaEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPagoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPagoEntidad](
	[ID] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[tipoPagoEntidadID] [int] NOT NULL,
	[facturaEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_TipoPagoEntidad] PRIMARY KEY CLUSTERED 
(
	[tipoPagoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoRecintoEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoRecintoEntidad](
	[ID] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[tipoRecintoEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_TipoRecintoEntidad] PRIMARY KEY CLUSTERED 
(
	[tipoRecintoEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Token_Usuario]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token_Usuario](
	[ID_Usuario] [int] NOT NULL,
	[ID_Token] [nvarchar](50) NOT NULL,
	[Fecha_Expiro] [datetime2](0) NOT NULL,
	[Registro] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Traduccion]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traduccion](
	[ID_Control] [int] NOT NULL,
	[ID_Idioma] [int] NOT NULL,
	[Palabra] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Traduccion] PRIMARY KEY CLUSTERED 
(
	[ID_Control] ASC,
	[ID_Idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransporteEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransporteEntidad](
	[Disponibilidad] [int] NULL,
	[ID] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[transporteEntidadID] [int] NOT NULL,
 CONSTRAINT [PK_TransporteEntidad] PRIMARY KEY CLUSTERED 
(
	[transporteEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioEntidad](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[DNI] [int] NULL,
	[Mail] [varchar](50) NULL,
	[Fecha_Alta] [datetime] NULL,
	[Salt] [varchar](50) NULL,
	[Bloqueo] [bit] NULL,
	[Intentos] [int] NULL,
	[Idioma] [int] NULL,
	[BL] [bit] NULL,
	[Empleado] [bit] NULL,
 CONSTRAINT [PK_UsuarioEntidad] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioEntidad_RolEntidad]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioEntidad_RolEntidad](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[ID_Rol] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioEntidad_RolEntidad] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BitacoraEntidad] ON 

INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1, N'Test', CAST(N'2018-09-02 18:30:08.0000000' AS DateTime2), 3, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (2, N'Test2', CAST(N'2018-09-02 19:13:04.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (3, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-02 19:31:23.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (4, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-02 20:12:29.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (5, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-02 23:49:44.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (6, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-02 23:50:56.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (7, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:09:28.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (8, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:14:14.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (9, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:15:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (10, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:16:33.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (11, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:19:59.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (12, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:22:10.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (13, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:26:58.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (14, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:29:08.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (15, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:31:53.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (16, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:35:08.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (17, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:36:32.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (18, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:39:22.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (19, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:41:16.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (20, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:42:03.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (21, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 00:45:02.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (22, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 21:29:47.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (23, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 21:45:01.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (24, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 23:51:22.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (25, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 23:52:34.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (26, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 23:56:22.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (27, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 23:57:36.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (28, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-03 23:58:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (29, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:00:27.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (30, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:06:42.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (31, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:23:22.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (32, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:24:33.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (33, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:26:06.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (34, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:29:02.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (35, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:31:20.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (36, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:32:16.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (37, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 00:34:30.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (38, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 09:47:06.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (39, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 09:48:52.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (41, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 23:32:22.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (42, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-04 23:32:28.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (43, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 23:36:27.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (44, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-04 23:36:32.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (48, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-04 23:39:53.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (49, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-04 23:39:57.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (50, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 00:25:47.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (51, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 00:26:57.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', NULL)
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (60, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:21:45.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (61, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:21:48.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (64, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:24:37.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (68, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:26:01.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (69, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:26:03.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (70, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:27:26.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (71, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:30:06.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (72, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:45:55.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (73, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:45:57.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 90', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (75, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:47:41.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (76, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:47:44.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (77, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:47:54.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.Page_Load(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 14', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (79, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:50:47.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (80, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:50:49.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (82, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 21:53:28.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (83, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 21:53:31.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (84, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 22:08:06.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (85, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 22:08:09.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (87, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 22:13:23.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (88, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 22:15:01.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (90, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 22:22:13.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (91, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-05 22:22:17.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (92, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-05 23:47:53.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (93, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:00:03.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (94, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:01:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (95, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:01:55.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (96, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:04:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (97, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:10:07.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (98, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:13:27.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (99, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:15:09.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (100, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:17:05.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (101, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:19:02.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (102, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:25:09.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (103, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 00:27:34.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (104, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 14:18:51.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (105, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-06 14:19:01.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (106, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 14:20:34.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (107, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 14:21:23.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (108, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 14:32:51.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (109, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 14:37:33.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (110, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 16:48:50.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (111, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 21:23:51.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (112, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 21:37:02.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (113, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 21:39:12.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (114, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 21:40:03.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (115, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 21:46:08.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (116, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 21:48:07.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (119, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-06 21:50:02.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (120, N'holamundo', CAST(N'2018-09-06 21:52:51.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (121, N'holamundo2', CAST(N'2018-09-06 21:56:04.0000000' AS DateTime2), 6, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (122, N'holamundo3', CAST(N'2018-09-06 22:20:43.0000000' AS DateTime2), 7, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (123, N'holamundo4', CAST(N'2018-09-06 22:23:15.0000000' AS DateTime2), 8, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
GO
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (125, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 10:58:01.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (126, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 10:58:27.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (127, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 21:22:47.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (128, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:37:18.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (129, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:45:57.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (130, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:52:31.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (131, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:53:30.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (132, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:54:16.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (133, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:55:01.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (134, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:55:46.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (135, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 21:56:54.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (136, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:00:15.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (137, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:01:22.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (138, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:02:08.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (139, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:04:34.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (140, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:04:35.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (141, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:04:42.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (142, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:49:11.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (143, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 22:56:15.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (144, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 23:01:28.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (145, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 23:01:39.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (146, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 23:02:38.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (147, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 23:05:04.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (148, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 23:09:20.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (149, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 23:10:11.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (150, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 23:13:28.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (151, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 23:16:02.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (152, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 23:18:11.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (153, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 23:22:22.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (154, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 23:22:56.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (155, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-07 23:23:32.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (156, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 23:24:30.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (157, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-07 23:26:34.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (158, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-07 23:27:41.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (159, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-08 20:38:25.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (160, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-08 20:40:36.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (161, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-08 20:40:47.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (162, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-08 20:41:14.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (163, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-08 20:41:29.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (164, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-08 20:41:35.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (165, N'Object reference not set to an instance of an object.', CAST(N'2018-09-08 20:41:35.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   at Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) in C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:line 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (166, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-08 20:41:39.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (167, N'Object reference not set to an instance of an object.', CAST(N'2018-09-08 20:41:39.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   at Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) in C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:line 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (168, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-08 22:30:28.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (169, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-08 22:30:45.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (170, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 02:07:48.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (171, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 02:07:48.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (172, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 02:12:26.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (173, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 02:12:43.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (174, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 02:12:48.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (175, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 02:17:06.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (176, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 02:18:18.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (177, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-09 02:34:27.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1148, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-09 15:49:17.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Institucional.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1149, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 15:49:31.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1150, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-09 15:54:08.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1151, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 15:54:18.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 88', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1155, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 18:50:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1156, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:51:13.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1157, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:53:51.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1158, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:54:16.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1159, N'Object reference not set to an instance of an object.', CAST(N'2018-09-09 18:54:16.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   at Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) in C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:line 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1160, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:54:24.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1161, N'Object reference not set to an instance of an object.', CAST(N'2018-09-09 18:54:24.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   at Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) in C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:line 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1162, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:54:31.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1163, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:54:36.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1164, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:54:42.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1165, N'Object reference not set to an instance of an object.', CAST(N'2018-09-09 18:54:42.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   at Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) in C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:line 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1166, N'Referencia a objeto no establecida como instancia de un objeto.', CAST(N'2018-09-09 18:54:52.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'4', N'   en Vista.ConsultarBitacoraAuditoria.gv_Bitacora_DataBound(Object sender, EventArgs e) en C:\Users\mwolczok\source\repos\TFIWolczok\InnovaLED\Vista\BitacoraAuditoria.aspx.vb:línea 92', N'System.NullReferenceException', N'http://localhost:53926/BitacoraAuditoria.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1167, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:00:25.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1168, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:06:29.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1169, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:12:37.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1170, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:12:50.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1171, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:16:49.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1172, N'El usuario holamundo Se logueo correctamente', CAST(N'2018-09-09 19:32:13.0000000' AS DateTime2), 5, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1173, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:39:39.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1174, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:40:37.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1175, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:43:19.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1176, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:53:37.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1177, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:55:24.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1178, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 19:57:35.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1179, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 20:03:03.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1180, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 20:36:09.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1181, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 20:39:44.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/SeleccionarIdioma.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1182, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 20:49:11.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1183, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-09 20:51:59.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1184, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:20:35.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1185, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:24:13.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1186, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:25:32.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1187, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:30:24.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1188, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:36:29.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1189, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:47:46.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1190, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:52:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1191, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 20:56:16.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1192, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-10 23:47:11.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1193, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 00:04:24.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1194, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 00:13:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1195, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 00:15:48.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1196, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 13:23:45.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1197, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 13:41:44.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
GO
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1198, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 13:45:17.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1199, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 18:59:42.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1200, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 19:12:42.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1201, N'Se Creó el perfil de forma correctaDepositoBitacora correcta', CAST(N'2018-09-11 19:12:57.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'1', N'', N'', N'http://localhost:53926/AgregarPerfil.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1202, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 19:31:27.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1203, N'Se Creó el perfil de forma correctaDepositoBitacora correcta', CAST(N'2018-09-11 19:32:49.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'1', N'', N'', N'http://localhost:53926/AgregarPerfil.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1204, N'Se Creó el perfil de forma correctaDeposito1Bitacora correcta', CAST(N'2018-09-11 19:37:09.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'1', N'', N'', N'http://localhost:53926/AgregarPerfil.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1205, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 19:44:27.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1206, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 19:47:16.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1207, N'Se Creó el perfil de forma correctaDeposito3Bitacora correcta', CAST(N'2018-09-11 19:47:56.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'1', N'', N'', N'http://localhost:53926/AgregarPerfil.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1208, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 20:01:45.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1209, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 20:30:55.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1210, N'Se Creó el perfil de forma correctaDepositoBitacora correcta', CAST(N'2018-09-11 20:35:02.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'1', N'', N'', N'http://localhost:53926/AgregarPerfil.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1211, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 20:36:37.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1212, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 20:39:15.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1213, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 20:52:37.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1214, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 21:04:08.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1215, N'Se Creó el perfil de forma correctaTestingBitacora correcta', CAST(N'2018-09-11 21:07:32.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'1', N'', N'', N'http://localhost:53926/AgregarPerfil.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1216, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 21:08:17.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1217, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 21:23:19.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1218, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-11 23:48:37.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1219, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-12 00:34:18.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1220, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-12 00:38:49.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1221, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-12 00:45:04.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1222, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-12 00:47:24.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1223, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-12 00:56:53.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1224, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-12 00:57:40.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
INSERT [dbo].[BitacoraEntidad] ([ID_Bitacora], [Detalle], [Fecha], [ID_Usuario], [IP_Usuario], [WebBrowser], [Tipo_Bitacora], [Valor_Anterior], [Valor_Posterior], [URL]) VALUES (1225, N'El usuario Test2 Se logueo correctamente', CAST(N'2018-09-12 00:59:01.0000000' AS DateTime2), 4, N'::1', N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36', N'5', N'', N'', N'http://localhost:53926/Default.aspx')
SET IDENTITY_INSERT [dbo].[BitacoraEntidad] OFF
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (1, N'Registro', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (2, N'btnlogout', N'Button')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (3, N'lbl_success', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (4, N'lblcopyright', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (5, N'txtUser', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (6, N'txtPassword', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (7, N'btnolvidepass', N'Button')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (8, N'btncerrar', N'Button')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (9, N'txtapereg', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (10, N'txtUserreg', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (11, N'txtPasswordreg', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (12, N'txtmail', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (13, N'btnregistracion', N'Button')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (14, N'lblPanelNosotros', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (15, N'lblnosotros1', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (16, N'Home', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (17, N'Empresa', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (18, N'Institucional', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (19, N'PreguntasFrecuentes', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (20, N'PoliticasySeguridad', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (21, N'Catalogo', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (22, N'Novedades', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (23, N'SolucionLED', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (24, N'Facturacion', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (25, N'GenerarDocumento', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (26, N'PagoaProveedores', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (27, N'Proveedores', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (28, N'SolicitudPedido', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (29, N'ReporteStock', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (30, N'AlmyLog', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (31, N'ActualizarStock', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (32, N'CrearProducto', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (33, N'GenerarEnvio', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (34, N'GestionarRoles', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (35, N'GestiondeUsuario', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (36, N'CrearIdioma', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (37, N'GestiondeBitacora', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (38, N'MensajeTodos', N'Mensaje')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (39, N'HeaderDetalle', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (40, N'HeaderFecha', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (41, N'HeaderUsuario', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (42, N'HeaderIPUsuario', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (43, N'HeaderTipoBitacora', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (44, N'HeaderValorAnterior', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (45, N'HeaderValorPosterior', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (46, N'SeleccionarIdioma', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (47, N'ModificarIdioma', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (48, N'EliminarIdioma', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (49, N'AgregarPerfil', N'MenuItem')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (50, N'lblsuccessAddPerfil', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (51, N'lblPanelAddPerfil', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (52, N'lblnombreAddPerfil', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (53, N'btnAddPerfil', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (54, N'BitacoraAddPerfilSuccess1', N'Mensaje')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (55, N'BitacoraSuccesfully', N'Mensaje')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (56, N'AddPerfilError1', N'Mensaje')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (57, N'AddPerfilError2', N'Mensaje')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (58, N'lbl_TituloError', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (59, N'cab_adminPerfil', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (60, N'lbl_pagina', N'Label')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (61, N'ID', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (62, N'Nombre', N'BoundField')
INSERT [dbo].[Control] ([ID_Control], [Nombre], [Tipo]) VALUES (63, N'Acciones', N'BoundField')
SET IDENTITY_INSERT [dbo].[IdiomaEntidad] ON 

INSERT [dbo].[IdiomaEntidad] ([ID_Idioma], [Nombre], [Editable], [Cultura], [BL]) VALUES (1, N'Español', N'0', N'es-AR', 0)
INSERT [dbo].[IdiomaEntidad] ([ID_Idioma], [Nombre], [Editable], [Cultura], [BL]) VALUES (2, N'Ingles', N'1', N'en-US', 1)
INSERT [dbo].[IdiomaEntidad] ([ID_Idioma], [Nombre], [Editable], [Cultura], [BL]) VALUES (3, N'Ingles', N'1', N'en-US', 0)
SET IDENTITY_INSERT [dbo].[IdiomaEntidad] OFF
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (1, N'Catalogo', N'/Catalogo.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (2, N'Institucional', N'/Institucional.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (3, N'SolucionesLED', N'/GestionarSolucionesLED.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (4, N'GenerarPresupuesto', N'/GenerarPresupuesto.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (5, N'GenerarDocumento', N'/GenerarDocumento.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (6, N'Proveedores', N'/Proveedores.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (7, N'SolicitudPedido', N'/SolicitudPedido.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (8, N'ReporteStock', N'/ReporteStock.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (9, N'ActualizarStock', N'/ActualizarStock.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (10, N'CrearProducto', N'/CrearProducto.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (11, N'GenerarEnvio', N'/GenerarEnvio.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (12, N'GestionarRoles', N'/GestionarRoles.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (13, N'GestiondeUsuario', N'/GestiondeUsuario.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (14, N'CrearIdioma', N'/AgregarIdioma.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (15, N'GestiondeBitacora', N'/BitacoraAuditoria.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (16, N'NuestrosProductos', N'/ProductList.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (17, N'Faqs', N'/Faqs.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (18, N'PoliticasySeguridad', N'/PoliticasySeguridad.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (19, N'Home', N'/Default.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (20, N'AccesoRestringido', N'/AccesoRestringido.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (21, N'SeleccionarIdioma', N'/SeleccionarIdioma.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (22, N'ModificarIdioma', N'/ModificarIdioma.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (23, N'EliminarIdioma', N'/EliminarIdioma.aspx')
INSERT [dbo].[PermisoBaseEntidad] ([ID_Permiso], [Nombre], [URL]) VALUES (24, N'AgregarPerfil', N'/AgregarPerfil.aspx')
SET IDENTITY_INSERT [dbo].[RolEntidad] ON 

INSERT [dbo].[RolEntidad] ([ID_Rol], [Nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[RolEntidad] ([ID_Rol], [Nombre]) VALUES (2, N'Cliente')
SET IDENTITY_INSERT [dbo].[RolEntidad] OFF
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 1)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 2)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 3)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 4)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 5)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 6)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 7)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 8)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 9)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 10)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 11)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 12)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 13)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 14)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 15)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 16)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 17)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 18)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 19)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 20)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 21)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 22)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 23)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (1, 24)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 1)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 2)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 3)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 4)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 16)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 17)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 18)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 19)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 20)
INSERT [dbo].[RolEntidad_PermisoBaseEntidad] ([ID_Rol], [ID_PermisoBase]) VALUES (2, 21)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (2, N'IiqY5Yks3rOJrjkW78UzGOjayfdC14C', CAST(N'2018-09-03 17:32:17.0000000' AS DateTime2), 1)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (3, N'26tFgdp1IHpKy0YGdafc', CAST(N'2018-09-03 18:29:59.0000000' AS DateTime2), 1)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (4, N'2bbJEXm11n78AOoHqor3JevOl', CAST(N'2018-09-03 19:12:57.0000000' AS DateTime2), 1)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (4, N'MBarxgsUND0DxgF34dLko', CAST(N'2018-09-03 19:51:27.0000000' AS DateTime2), 0)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (5, N'bBSI0PmbQCInO41XfsJnm86aVa7qk', CAST(N'2018-09-07 21:52:51.0000000' AS DateTime2), 1)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (6, N'r5ehaQ9DouT682y9A7SfxAxXS61T', CAST(N'2018-09-07 21:56:04.0000000' AS DateTime2), 1)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (7, N'9Xwnu2MUGlm2qLud7kHb9', CAST(N'2018-09-07 22:20:43.0000000' AS DateTime2), 1)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (8, N'nW0P7ohwFUHfwl0OQUDRa1eVWv8IIA6', CAST(N'2018-09-07 22:23:15.0000000' AS DateTime2), 1)
INSERT [dbo].[Token_Usuario] ([ID_Usuario], [ID_Token], [Fecha_Expiro], [Registro]) VALUES (4, N'koVJcbgKWCDmMRVQaISJp5aMabepuNnLP1', CAST(N'2018-09-03 19:52:42.0000000' AS DateTime2), 0)
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (1, 1, N'Registro')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (1, 2, N'Registro')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (1, 3, N'Registry')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (2, 1, N'Logout')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (2, 2, N'Logout')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (2, 3, N'Logout')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (3, 1, N'Se Creó el Perfil correctamente.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (3, 2, N'Se Creó el Perfil correctamente.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (3, 3, N'The Pefil is created')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (4, 1, N'Trabajo Final de Ingenieria - Wolczok - 2018')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (4, 2, N'TP Fainal The Insheniery By Wolczok')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (4, 3, N'TP - TFI')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (5, 1, N'Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (5, 2, N'Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (5, 3, N'Usser')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (6, 1, N'Password')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (6, 2, N'Password')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (6, 3, N'Password')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (7, 1, N'Olvidé mi contraseña')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (7, 2, N'Olvidé mi contraseña')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (7, 3, N'Olvidé mi contraseña')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (8, 1, N'Cerrar')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (8, 2, N'Cerrar')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (8, 3, N'Cerrar')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (9, 1, N'Apellido')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (9, 2, N'Apellido')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (9, 3, N'Apellido')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (10, 1, N'UsuarioModal')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (10, 2, N'UsuarioModal')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (10, 3, N'UsuarioModal')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (11, 1, N'Password')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (11, 2, N'Password')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (11, 3, N'Password')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (12, 1, N'Correo Electrónico')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (12, 2, N'Correo Electrónico')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (12, 3, N'Correo Electrónico')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (13, 1, N'Aceptar')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (13, 2, N'Aceptar')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (13, 3, N'Aceptar')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (14, 1, N'¿Quienes somos?')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (14, 2, N'¿Quienes somos?')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (14, 3, N'¿Quienes somos?')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (15, 1, N'"Somos una empresa joven en el rubro de eficiencia energética en Latinoamérica, con proyección de estar entre los principales líderes de la luminaria LED.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (15, 2, N'"Somos una empresa joven en el rubro de eficiencia energética en Latinoamérica, con proyección de estar entre los principales líderes de la luminaria LED.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (15, 3, N'"Somos una empresa joven en el rubro de eficiencia energética en Latinoamérica, con proyección de estar entre los principales líderes de la luminaria LED.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (16, 1, N'Inicio')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (16, 2, N'Inicio')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (16, 3, N'Inicio')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (17, 1, N'Empresa')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (17, 2, N'Empresa')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (17, 3, N'Empresa')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (18, 1, N'Institucional')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (18, 2, N'Institucional')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (18, 3, N'Institucional')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (19, 1, N'Preguntas Frecuentes')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (19, 2, N'Preguntas Frecuentes')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (19, 3, N'Preguntas Frecuentes')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (20, 1, N'Politicas y Seguridad')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (20, 2, N'Politicas y Seguridad')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (20, 3, N'Politicas y Seguridad')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (21, 1, N'Nuestros Productos')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (21, 2, N'Nuestros Productos')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (21, 3, N'Nuestros Productos')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (22, 1, N'Novedades')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (22, 2, N'Novedades')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (22, 3, N'Novedades')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (23, 1, N'Solucion LED')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (23, 2, N'Solucion LED')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (23, 3, N'Solucion LED')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (24, 1, N'Facturacion')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (24, 2, N'Facturacion')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (24, 3, N'Facturacion')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (25, 1, N'Generar Documento')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (25, 2, N'Generar Documento')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (25, 3, N'Generar Documento')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (26, 1, N'Pago a Proveedores')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (26, 2, N'Pago a Proveedores')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (26, 3, N'Pago a Proveedores')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (27, 1, N'Proveedores')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (27, 2, N'Proveedores')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (27, 3, N'Proveedores')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (28, 1, N'Solicitud Pedido')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (28, 2, N'Solicitud Pedido')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (28, 3, N'Solicitud Pedido')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (29, 1, N'Reporte Stock')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (29, 2, N'Reporte Stock')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (29, 3, N'Reporte Stock')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (30, 1, N'Almacenes y Logistica')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (30, 2, N'Almacenes y Logistica')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (30, 3, N'Almacenes y Logistica')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (31, 1, N'Actualizar Stock')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (31, 2, N'Actualizar Stock')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (31, 3, N'Actualizar Stock')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (32, 1, N'Crear Producto')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (32, 2, N'Crear Producto')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (32, 3, N'Crear Producto')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (33, 1, N'Generar Envio')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (33, 2, N'Generar Envio')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (33, 3, N'Generar Envio')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (34, 1, N'Gestionar Roles')
GO
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (34, 2, N'Gestionar Roles')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (34, 3, N'Gestionar Roles')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (35, 1, N'Gestion de Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (35, 2, N'Gestion de Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (35, 3, N'Gestion de Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (36, 1, N'Crear Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (36, 2, N'Crear Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (36, 3, N'Crear Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (37, 1, N'Gestión de Bitácora')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (37, 2, N'Gestión de Bitácora')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (37, 3, N'Gestión de Bitácora')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (38, 1, N'Todos')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (38, 2, N'Todos')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (38, 3, N'Todos')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (39, 1, N'Detalle')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (39, 2, N'Detalle')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (39, 3, N'Detalle')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (40, 1, N'Fecha')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (40, 2, N'Fecha')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (40, 3, N'Fecha')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (41, 1, N'Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (41, 2, N'Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (41, 3, N'Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (42, 1, N'IP Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (42, 2, N'IP Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (42, 3, N'IP Usuario')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (43, 1, N'Tipo')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (43, 2, N'Tipo')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (43, 3, N'Tipo')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (44, 1, N'Valor Anterior')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (44, 2, N'Valor Anterior')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (44, 3, N'Valor Anterior')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (45, 1, N'Valor Posterior')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (45, 2, N'Valor Posterior')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (45, 3, N'Valor Posterior')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (46, 1, N'Seleccionar Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (46, 3, N'Seleccionar Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (47, 1, N'Modificar Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (47, 3, N'Modificar Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (48, 1, N'Eliminar Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (48, 3, N'Eliminar Idioma')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (49, 1, N'Agregar Perfil')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (49, 3, N'Agregar Perfil')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (50, 1, N'Se Creó el Perfil correctamente.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (50, 3, N'Se Creó el Perfil correctamente.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (51, 1, N'Crear Perfiles')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (51, 3, N'Crear Perfiles')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (52, 1, N'Nombre de Perfil')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (52, 3, N'Nombre de Perfil')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (53, 1, N'Crear Perfil')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (53, 3, N'Crear Perfil')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (54, 1, N'Se Creó el perfil de forma correcta')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (54, 3, N'Se Creó el perfil de forma correcta')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (55, 1, N'Bitacora correcta')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (55, 3, N'Bitacora correcta')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (56, 1, N'El nombre del perfil ya se encuentra en uso, por favor ingrese uno distinto.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (56, 3, N'El nombre del perfil ya se encuentra en uso, por favor ingrese uno distinto.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (57, 1, N'Debe seleccionar al menos un permiso para continuar.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (57, 3, N'Debe seleccionar al menos un permiso para continuar.')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (58, 1, N'Error')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (59, 1, N'Administración de Perfiles')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (60, 1, N'Página')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (61, 1, N'ID')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (62, 1, N'Nombre del Perfil')
INSERT [dbo].[Traduccion] ([ID_Control], [ID_Idioma], [Palabra]) VALUES (63, 1, N'Acciones')
SET IDENTITY_INSERT [dbo].[UsuarioEntidad] ON 

INSERT [dbo].[UsuarioEntidad] ([ID_Usuario], [NombreUsuario], [Password], [Nombre], [Apellido], [DNI], [Mail], [Fecha_Alta], [Salt], [Bloqueo], [Intentos], [Idioma], [BL], [Empleado]) VALUES (2, N'matias1', N'uol6zqwOcjSm7gH5/paUwMMP95A=', N'Matias', N'Wolczok', NULL, N'matias.wolczok@gmail.com', CAST(N'2018-09-02 17:14:09.000' AS DateTime), N'1025095243', 1, 0, 1, 0, 0)
INSERT [dbo].[UsuarioEntidad] ([ID_Usuario], [NombreUsuario], [Password], [Nombre], [Apellido], [DNI], [Mail], [Fecha_Alta], [Salt], [Bloqueo], [Intentos], [Idioma], [BL], [Empleado]) VALUES (3, N'Test', N'ljXJ8/tZrqt8dFDimewRbwVio04=', N'Test', N'Test', NULL, N'test@gmail.com', CAST(N'2018-09-02 18:29:58.000' AS DateTime), N'386429178', 1, 0, 1, 0, 0)
INSERT [dbo].[UsuarioEntidad] ([ID_Usuario], [NombreUsuario], [Password], [Nombre], [Apellido], [DNI], [Mail], [Fecha_Alta], [Salt], [Bloqueo], [Intentos], [Idioma], [BL], [Empleado]) VALUES (4, N'Test2', N'6iEbRpSDHf3cStb9jPDOq+5pT7k=', N'Matias', N'Wolczok', NULL, N'test@gmail.com', CAST(N'2018-09-02 19:12:56.000' AS DateTime), N'973300869', 0, 0, 1, 0, 0)
INSERT [dbo].[UsuarioEntidad] ([ID_Usuario], [NombreUsuario], [Password], [Nombre], [Apellido], [DNI], [Mail], [Fecha_Alta], [Salt], [Bloqueo], [Intentos], [Idioma], [BL], [Empleado]) VALUES (5, N'holamundo', N'WqCOci9CaPBW5J7VxC927YA3Qg0=', N'Hola', N'Mundo', NULL, N'holamundo@hotmail.com', CAST(N'2018-09-06 21:52:51.000' AS DateTime), N'174427313', 0, 0, 1, 0, 0)
INSERT [dbo].[UsuarioEntidad] ([ID_Usuario], [NombreUsuario], [Password], [Nombre], [Apellido], [DNI], [Mail], [Fecha_Alta], [Salt], [Bloqueo], [Intentos], [Idioma], [BL], [Empleado]) VALUES (6, N'holamundo2', N'yClJvvjfcKoigLuLsyi93yBSAPA=', N'Hola2', N'Mundo2', NULL, N'holamundo2@hotmail.com', CAST(N'2018-09-06 21:56:04.000' AS DateTime), N'1221261124', 0, 0, 1, 0, 0)
INSERT [dbo].[UsuarioEntidad] ([ID_Usuario], [NombreUsuario], [Password], [Nombre], [Apellido], [DNI], [Mail], [Fecha_Alta], [Salt], [Bloqueo], [Intentos], [Idioma], [BL], [Empleado]) VALUES (7, N'holamundo3', N'wl9qkhHoX0kYz3Xl14ewDF/PxAk=', N'Hola3', N'Mundo3', NULL, N'holamundo3@hotmail.com', CAST(N'2018-09-06 22:20:43.000' AS DateTime), N'721052899', 1, 0, 1, 0, 0)
INSERT [dbo].[UsuarioEntidad] ([ID_Usuario], [NombreUsuario], [Password], [Nombre], [Apellido], [DNI], [Mail], [Fecha_Alta], [Salt], [Bloqueo], [Intentos], [Idioma], [BL], [Empleado]) VALUES (8, N'holamundo4', N'OEJElP7eeMt2TsZdWT8WD04tVNE=', N'Hola4', N'Mundo4', NULL, N'holamundo4@hotmail.com', CAST(N'2018-09-06 22:23:14.000' AS DateTime), N'984832138', 1, 0, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[UsuarioEntidad] OFF
SET IDENTITY_INSERT [dbo].[UsuarioEntidad_RolEntidad] ON 

INSERT [dbo].[UsuarioEntidad_RolEntidad] ([ID_Usuario], [ID_Rol]) VALUES (4, 1)
INSERT [dbo].[UsuarioEntidad_RolEntidad] ([ID_Usuario], [ID_Rol]) VALUES (5, 2)
SET IDENTITY_INSERT [dbo].[UsuarioEntidad_RolEntidad] OFF
/****** Object:  Index [PK_BackupRestoreEntidad]    Script Date: 12/9/2018 01:01:14 ******/
CREATE NONCLUSTERED INDEX [PK_BackupRestoreEntidad] ON [dbo].[BackupRestoreEntidad]
(
	[backupRestoreEntidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tipo_LuminariaEntidad]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_LuminariaEntidad_ProductoEntidad] FOREIGN KEY([productoEntidadID])
REFERENCES [dbo].[ProductoEntidad] ([productoEntidadID])
GO
ALTER TABLE [dbo].[Tipo_LuminariaEntidad] CHECK CONSTRAINT [FK_Tipo_LuminariaEntidad_ProductoEntidad]
GO
ALTER TABLE [dbo].[TipoPagoEntidad]  WITH CHECK ADD  CONSTRAINT [FK_TipoPagoEntidad_FacturaEntidad] FOREIGN KEY([facturaEntidadID])
REFERENCES [dbo].[FacturaEntidad] ([facturaEntidadID])
GO
ALTER TABLE [dbo].[TipoPagoEntidad] CHECK CONSTRAINT [FK_TipoPagoEntidad_FacturaEntidad]
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_permiso]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_permiso]
(
	@IsNull__id Int,
	@Original__id int,
	@IsNull__nombre Int,
	@Original__nombre varchar(50),
	@IsNull__url Int,
	@Original__url varchar(50),
	@Original_permisoBaseEntidadID int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [PermisoBaseEntidad] WHERE (((@IsNull__id = 1 AND [_id] IS NULL) OR ([_id] = @Original__id)) AND ((@IsNull__nombre = 1 AND [_nombre] IS NULL) OR ([_nombre] = @Original__nombre)) AND ((@IsNull__url = 1 AND [_url] IS NULL) OR ([_url] = @Original__url)) AND ([permisoBaseEntidadID] = @Original_permisoBaseEntidadID))
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_rol]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_rol]
(
	@Original_permisoBaseEntidadID int,
	@Original_rolEntidadID int,
	@Original_usuarioEntidadID int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [RolEntidad] WHERE (([permisoBaseEntidadID] = @Original_permisoBaseEntidadID) AND ([rolEntidadID] = @Original_rolEntidadID) AND ([usuarioEntidadID] = @Original_usuarioEntidadID))
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_usuario]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_usuario]
(
	@IsNull_Apellido Int,
	@Original_Apellido varchar(50),
	@IsNull_Contraseña Int,
	@Original_Contraseña varchar(50),
	@IsNull_DNI Int,
	@Original_DNI int,
	@IsNull_Mail Int,
	@Original_Mail varchar(50),
	@IsNull_Nombre Int,
	@Original_Nombre varchar(50),
	@IsNull_NombreUsuario Int,
	@Original_NombreUsuario varchar(50),
	@IsNull_Rol Int,
	@Original_Rol varchar(50),
	@Original_usuarioEntidadID int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [UsuarioEntidad] WHERE (((@IsNull_Apellido = 1 AND [Apellido] IS NULL) OR ([Apellido] = @Original_Apellido)) AND ((@IsNull_Contraseña = 1 AND [Contraseña] IS NULL) OR ([Contraseña] = @Original_Contraseña)) AND ((@IsNull_DNI = 1 AND [DNI] IS NULL) OR ([DNI] = @Original_DNI)) AND ((@IsNull_Mail = 1 AND [Mail] IS NULL) OR ([Mail] = @Original_Mail)) AND ((@IsNull_Nombre = 1 AND [Nombre] IS NULL) OR ([Nombre] = @Original_Nombre)) AND ((@IsNull_NombreUsuario = 1 AND [NombreUsuario] IS NULL) OR ([NombreUsuario] = @Original_NombreUsuario)) AND ((@IsNull_Rol = 1 AND [Rol] IS NULL) OR ([Rol] = @Original_Rol)) AND ([usuarioEntidadID] = @Original_usuarioEntidadID))
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_permiso]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_permiso]
(
	@_id int,
	@_nombre varchar(50),
	@_url varchar(50),
	@permisoBaseEntidadID int
)
AS
	SET NOCOUNT OFF;
INSERT INTO [PermisoBaseEntidad] ([_id], [_nombre], [_url], [permisoBaseEntidadID]) VALUES (@_id, @_nombre, @_url, @permisoBaseEntidadID);
	
SELECT _id, _nombre, _url, permisoBaseEntidadID FROM PermisoBaseEntidad WHERE (permisoBaseEntidadID = @permisoBaseEntidadID)
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_rol]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_rol]
(
	@permisoBaseEntidadID int,
	@rolEntidadID int,
	@usuarioEntidadID int
)
AS
	SET NOCOUNT OFF;
INSERT INTO [RolEntidad] ([permisoBaseEntidadID], [rolEntidadID], [usuarioEntidadID]) VALUES (@permisoBaseEntidadID, @rolEntidadID, @usuarioEntidadID);
	
SELECT permisoBaseEntidadID, rolEntidadID, usuarioEntidadID FROM RolEntidad WHERE (rolEntidadID = @rolEntidadID)
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_usuario]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_insert_usuario]
(
	@Apellido varchar(50),
	@Contraseña varchar(50),
	@DNI int,
	@Mail varchar(50),
	@Nombre varchar(50),
	@NombreUsuario varchar(50),
	@Rol varchar(50),
	@usuarioEntidadID int
)
AS
	SET NOCOUNT OFF;
INSERT INTO [UsuarioEntidad] ([Apellido], [Contraseña], [DNI], [Mail], [Nombre], [NombreUsuario], [Rol], [usuarioEntidadID]) VALUES (@Apellido, @Contraseña, @DNI, @Mail, @Nombre, @NombreUsuario, @Rol, @usuarioEntidadID);
	
SELECT Apellido, Contraseña, DNI, Mail, Nombre, NombreUsuario, Rol, usuarioEntidadID FROM UsuarioEntidad WHERE (usuarioEntidadID = @usuarioEntidadID)
GO
/****** Object:  StoredProcedure [dbo].[sp_select_permiso]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_permiso]
AS
	SET NOCOUNT ON;
select * from PermisoBaseEntidad
GO
/****** Object:  StoredProcedure [dbo].[sp_select_rol]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_rol]
AS
	SET NOCOUNT ON;
select * from RolEntidad
GO
/****** Object:  StoredProcedure [dbo].[sp_select_usuario]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_select_usuario]
AS
	SET NOCOUNT ON;
select * from UsuarioEntidad
GO
/****** Object:  StoredProcedure [dbo].[sp_update_permiso]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_permiso]
(
	@_id int,
	@_nombre varchar(50),
	@_url varchar(50),
	@permisoBaseEntidadID int,
	@IsNull__id Int,
	@Original__id int,
	@IsNull__nombre Int,
	@Original__nombre varchar(50),
	@IsNull__url Int,
	@Original__url varchar(50),
	@Original_permisoBaseEntidadID int
)
AS
	SET NOCOUNT OFF;
UPDATE [PermisoBaseEntidad] SET [_id] = @_id, [_nombre] = @_nombre, [_url] = @_url, [permisoBaseEntidadID] = @permisoBaseEntidadID WHERE (((@IsNull__id = 1 AND [_id] IS NULL) OR ([_id] = @Original__id)) AND ((@IsNull__nombre = 1 AND [_nombre] IS NULL) OR ([_nombre] = @Original__nombre)) AND ((@IsNull__url = 1 AND [_url] IS NULL) OR ([_url] = @Original__url)) AND ([permisoBaseEntidadID] = @Original_permisoBaseEntidadID));
	
SELECT _id, _nombre, _url, permisoBaseEntidadID FROM PermisoBaseEntidad WHERE (permisoBaseEntidadID = @permisoBaseEntidadID)
GO
/****** Object:  StoredProcedure [dbo].[sp_update_rol]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_rol]
(
	@permisoBaseEntidadID int,
	@rolEntidadID int,
	@usuarioEntidadID int,
	@Original_permisoBaseEntidadID int,
	@Original_rolEntidadID int,
	@Original_usuarioEntidadID int
)
AS
	SET NOCOUNT OFF;
UPDATE [RolEntidad] SET [permisoBaseEntidadID] = @permisoBaseEntidadID, [rolEntidadID] = @rolEntidadID, [usuarioEntidadID] = @usuarioEntidadID WHERE (([permisoBaseEntidadID] = @Original_permisoBaseEntidadID) AND ([rolEntidadID] = @Original_rolEntidadID) AND ([usuarioEntidadID] = @Original_usuarioEntidadID));
	
SELECT permisoBaseEntidadID, rolEntidadID, usuarioEntidadID FROM RolEntidad WHERE (rolEntidadID = @rolEntidadID)
GO
/****** Object:  StoredProcedure [dbo].[sp_update_usuario]    Script Date: 12/9/2018 01:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_update_usuario]
(
	@Apellido varchar(50),
	@Contraseña varchar(50),
	@DNI int,
	@Mail varchar(50),
	@Nombre varchar(50),
	@NombreUsuario varchar(50),
	@Rol varchar(50),
	@usuarioEntidadID int,
	@IsNull_Apellido Int,
	@Original_Apellido varchar(50),
	@IsNull_Contraseña Int,
	@Original_Contraseña varchar(50),
	@IsNull_DNI Int,
	@Original_DNI int,
	@IsNull_Mail Int,
	@Original_Mail varchar(50),
	@IsNull_Nombre Int,
	@Original_Nombre varchar(50),
	@IsNull_NombreUsuario Int,
	@Original_NombreUsuario varchar(50),
	@IsNull_Rol Int,
	@Original_Rol varchar(50),
	@Original_usuarioEntidadID int
)
AS
	SET NOCOUNT OFF;
UPDATE [UsuarioEntidad] SET [Apellido] = @Apellido, [Contraseña] = @Contraseña, [DNI] = @DNI, [Mail] = @Mail, [Nombre] = @Nombre, [NombreUsuario] = @NombreUsuario, [Rol] = @Rol, [usuarioEntidadID] = @usuarioEntidadID WHERE (((@IsNull_Apellido = 1 AND [Apellido] IS NULL) OR ([Apellido] = @Original_Apellido)) AND ((@IsNull_Contraseña = 1 AND [Contraseña] IS NULL) OR ([Contraseña] = @Original_Contraseña)) AND ((@IsNull_DNI = 1 AND [DNI] IS NULL) OR ([DNI] = @Original_DNI)) AND ((@IsNull_Mail = 1 AND [Mail] IS NULL) OR ([Mail] = @Original_Mail)) AND ((@IsNull_Nombre = 1 AND [Nombre] IS NULL) OR ([Nombre] = @Original_Nombre)) AND ((@IsNull_NombreUsuario = 1 AND [NombreUsuario] IS NULL) OR ([NombreUsuario] = @Original_NombreUsuario)) AND ((@IsNull_Rol = 1 AND [Rol] IS NULL) OR ([Rol] = @Original_Rol)) AND ([usuarioEntidadID] = @Original_usuarioEntidadID));
	
SELECT Apellido, Contraseña, DNI, Mail, Nombre, NombreUsuario, Rol, usuarioEntidadID FROM UsuarioEntidad WHERE (usuarioEntidadID = @usuarioEntidadID)
GO
USE [master]
GO
ALTER DATABASE [InnovaLED] SET  READ_WRITE 
GO
