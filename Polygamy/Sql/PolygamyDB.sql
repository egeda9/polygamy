USE [master]
GO
/****** Object:  Database [Poligamy]    Script Date: 30/05/2017 21:48:59 ******/
CREATE DATABASE [Poligamy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Poligamy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Poligamy.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Poligamy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Poligamy_log.ldf' , SIZE = 8384KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Poligamy] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Poligamy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Poligamy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Poligamy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Poligamy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Poligamy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Poligamy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Poligamy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Poligamy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Poligamy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Poligamy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Poligamy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Poligamy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Poligamy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Poligamy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Poligamy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Poligamy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Poligamy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Poligamy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Poligamy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Poligamy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Poligamy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Poligamy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Poligamy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Poligamy] SET RECOVERY FULL 
GO
ALTER DATABASE [Poligamy] SET  MULTI_USER 
GO
ALTER DATABASE [Poligamy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Poligamy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Poligamy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Poligamy] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Poligamy] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Poligamy', N'ON'
GO
USE [Poligamy]
GO
/****** Object:  Table [dbo].[Acceso]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acceso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPermiso] [int] NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_Acceso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Administrador_Supermercado]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador_Supermercado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idSupermercado] [int] NULL,
	[idPersona] [int] NULL,
 CONSTRAINT [PK_AdminSupermercado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Afiliado]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Afiliado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cupo] [numeric](8, 0) NULL,
	[idPersona] [int] NULL,
 CONSTRAINT [pk_Afiliado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Beneficiario]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idAfiliado] [int] NOT NULL,
	[cupo] [numeric](8, 0) NOT NULL,
	[fechaCompraInicio] [datetime] NOT NULL,
	[fechaCompraFin] [datetime] NOT NULL,
	[idPersona] [int] NOT NULL,
	[activo] [bit] NULL,
 CONSTRAINT [pk_Beneficiario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cajero_Supermercado]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cajero_Supermercado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numeroCaja] [int] NOT NULL,
	[idPersona] [int] NOT NULL,
	[idSupermercado] [int] NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Compra]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idSupermercado] [int] NOT NULL,
	[idBeneficiario] [int] NULL,
	[fecha] [datetime] NULL,
	[total] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CompraDetalle]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraDetalle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [nchar](10) NULL,
	[idCompra] [int] NULL,
 CONSTRAINT [pk_CompraDetalle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persona]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identificacion] [int] NOT NULL,
	[nombres] [nvarchar](50) NOT NULL,
	[apellidos] [nvarchar](50) NOT NULL,
	[ciudadResidencia] [nvarchar](100) NOT NULL,
	[direccionResidencia] [nvarchar](50) NOT NULL,
	[numeroTelefono] [numeric](11, 0) NOT NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [pk_Persona] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
	[precioUnitario] [numeric](18, 0) NOT NULL,
 CONSTRAINT [pk_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Red_Supermercado]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Red_Supermercado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RedSupermercado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Rol__6ABCB5E06A30C649] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supermercado]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supermercado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ciudad] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[idRedSupermercado] [int] NOT NULL,
 CONSTRAINT [PK_Supermercado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/05/2017 21:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[nombreUsuario] [nvarchar](50) NOT NULL,
	[contrasena] [nvarchar](100) NOT NULL,
	[idPersona] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Acceso] ON 

INSERT [dbo].[Acceso] ([id], [idPermiso], [idRol]) VALUES (2, 1, 5)
INSERT [dbo].[Acceso] ([id], [idPermiso], [idRol]) VALUES (3, 2, 5)
INSERT [dbo].[Acceso] ([id], [idPermiso], [idRol]) VALUES (4, 3, 5)
INSERT [dbo].[Acceso] ([id], [idPermiso], [idRol]) VALUES (5, 2, 4)
SET IDENTITY_INSERT [dbo].[Acceso] OFF
SET IDENTITY_INSERT [dbo].[Administrador_Supermercado] ON 

INSERT [dbo].[Administrador_Supermercado] ([id], [idSupermercado], [idPersona]) VALUES (1, 1, 2)
INSERT [dbo].[Administrador_Supermercado] ([id], [idSupermercado], [idPersona]) VALUES (2, 2, 4)
INSERT [dbo].[Administrador_Supermercado] ([id], [idSupermercado], [idPersona]) VALUES (3, 3, 5)
INSERT [dbo].[Administrador_Supermercado] ([id], [idSupermercado], [idPersona]) VALUES (4, 5, 9)
INSERT [dbo].[Administrador_Supermercado] ([id], [idSupermercado], [idPersona]) VALUES (5, 6, 10)
SET IDENTITY_INSERT [dbo].[Administrador_Supermercado] OFF
SET IDENTITY_INSERT [dbo].[Afiliado] ON 

INSERT [dbo].[Afiliado] ([id], [cupo], [idPersona]) VALUES (1, CAST(9491677 AS Numeric(8, 0)), 11)
INSERT [dbo].[Afiliado] ([id], [cupo], [idPersona]) VALUES (2, CAST(2000000 AS Numeric(8, 0)), 18)
INSERT [dbo].[Afiliado] ([id], [cupo], [idPersona]) VALUES (1001, CAST(4894499 AS Numeric(8, 0)), 1003)
INSERT [dbo].[Afiliado] ([id], [cupo], [idPersona]) VALUES (1002, CAST(3500000 AS Numeric(8, 0)), 1004)
INSERT [dbo].[Afiliado] ([id], [cupo], [idPersona]) VALUES (1003, CAST(6929666 AS Numeric(8, 0)), 1005)
SET IDENTITY_INSERT [dbo].[Afiliado] OFF
SET IDENTITY_INSERT [dbo].[Beneficiario] ON 

INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (1, 1, CAST(350000 AS Numeric(8, 0)), CAST(N'2017-05-13 00:00:00.000' AS DateTime), CAST(N'2017-05-31 00:00:00.000' AS DateTime), 14, 0)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (2, 1, CAST(200000 AS Numeric(8, 0)), CAST(N'2017-05-06 00:00:00.000' AS DateTime), CAST(N'2017-05-27 00:00:00.000' AS DateTime), 15, 0)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (3, 1, CAST(150000 AS Numeric(8, 0)), CAST(N'2017-05-07 00:00:00.000' AS DateTime), CAST(N'2017-05-27 00:00:00.000' AS DateTime), 16, 1)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (4, 1, CAST(450000 AS Numeric(8, 0)), CAST(N'2017-05-05 00:00:00.000' AS DateTime), CAST(N'2017-05-31 00:00:00.000' AS DateTime), 17, 0)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (1001, 2, CAST(500000 AS Numeric(8, 0)), CAST(N'2017-06-01 00:00:00.000' AS DateTime), CAST(N'2017-06-30 00:00:00.000' AS DateTime), 1001, 1)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (1002, 2, CAST(500000 AS Numeric(8, 0)), CAST(N'2017-05-17 00:00:00.000' AS DateTime), CAST(N'2017-06-17 00:00:00.000' AS DateTime), 1002, 1)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (1003, 1003, CAST(250000 AS Numeric(8, 0)), CAST(N'2017-05-25 00:00:00.000' AS DateTime), CAST(N'2017-06-30 00:00:00.000' AS DateTime), 1006, 1)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (1004, 1002, CAST(200000 AS Numeric(8, 0)), CAST(N'2017-07-28 00:00:00.000' AS DateTime), CAST(N'2017-08-30 00:00:00.000' AS DateTime), 1007, 1)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (1005, 1001, CAST(1000000 AS Numeric(8, 0)), CAST(N'2017-01-01 00:00:00.000' AS DateTime), CAST(N'2017-12-31 00:00:00.000' AS DateTime), 1008, 1)
INSERT [dbo].[Beneficiario] ([id], [idAfiliado], [cupo], [fechaCompraInicio], [fechaCompraFin], [idPersona], [activo]) VALUES (1006, 1003, CAST(750000 AS Numeric(8, 0)), CAST(N'2017-06-01 00:00:00.000' AS DateTime), CAST(N'2017-12-31 00:00:00.000' AS DateTime), 1009, 1)
SET IDENTITY_INSERT [dbo].[Beneficiario] OFF
SET IDENTITY_INSERT [dbo].[Compra] ON 

INSERT [dbo].[Compra] ([id], [idSupermercado], [idBeneficiario], [fecha], [total]) VALUES (1002, 3, 1003, CAST(N'2017-05-30 21:31:39.643' AS DateTime), CAST(70334 AS Numeric(18, 0)))
INSERT [dbo].[Compra] ([id], [idSupermercado], [idBeneficiario], [fecha], [total]) VALUES (1003, 6, 1005, CAST(N'2017-05-30 21:32:57.620' AS DateTime), CAST(105501 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Compra] OFF
SET IDENTITY_INSERT [dbo].[CompraDetalle] ON 

INSERT [dbo].[CompraDetalle] ([id], [idProducto], [cantidad], [idCompra]) VALUES (1002, 3, N'1         ', 1002)
INSERT [dbo].[CompraDetalle] ([id], [idProducto], [cantidad], [idCompra]) VALUES (1003, 13, N'2         ', 1002)
INSERT [dbo].[CompraDetalle] ([id], [idProducto], [cantidad], [idCompra]) VALUES (1004, 73, N'1         ', 1003)
INSERT [dbo].[CompraDetalle] ([id], [idProducto], [cantidad], [idCompra]) VALUES (1005, 76, N'1         ', 1003)
SET IDENTITY_INSERT [dbo].[CompraDetalle] OFF
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([id], [nombre]) VALUES (1, N'Administracion')
INSERT [dbo].[Permiso] ([id], [nombre]) VALUES (2, N'Compras')
INSERT [dbo].[Permiso] ([id], [nombre]) VALUES (3, N'Reportes')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (0, 0, N' ', N' ', N' ', N' ', CAST(0 AS Numeric(11, 0)), N' ')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (2, 1090427627, N'EDWIN YAMIT', N'ARCHILA REYES', N'Bogotá', N'Cl 23 # 124 - 45', CAST(3347640 AS Numeric(11, 0)), N'jagiguvexe@alienware13.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (4, 1090437589, N'JENNIFER TARAZONA', N'ALBARRACIN', N'Bogotá', N'Cra 45 # 14 - 32', CAST(3431223 AS Numeric(11, 0)), N'vabozoke@klipschx12.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (5, 1092340228, N'JESUS ORESTE', N'FORGIONY SANTOS ', N'Bogotá', N'Cra 3 # 18- 45', CAST(6918654 AS Numeric(11, 0)), N'muwonimi@akgq701.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (9, 63561224, N'LUZ HELENA', N'MORALES MENDOZA', N'Medellín', N'Cra 20 No. 37-54', CAST(2186507 AS Numeric(11, 0)), N'cujuf@honor-8.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (10, 79523397, N'JAIRO ELIAS', N'OSORIO RODRIGUEZ', N'Cali', N'Cl 20 # 14-37/39', CAST(3394949 AS Numeric(11, 0)), N'salix@axon7zte.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (11, 2899818, N'GERARDO MESIAS', N'ANDRADE', N'Bogotá', N'Calle 22 # 3 - 23', CAST(4773058 AS Numeric(11, 0)), N'zorofanuve@ipdeer.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (14, 10517940, N'YOLANDA DEL CARMEN', N'ARCOS LEGARDA', N'Cauca', N'Calle 12 # 2-59.', CAST(2498177 AS Numeric(11, 0)), N'tayevidu@getapet.net')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (15, 34544560, N'GLORIA INES', N'AVILA GONZALEZ', N'Melgar', N'Carrera 7a N° 22-47', CAST(3420388 AS Numeric(11, 0)), N'gafisasefu@haydoo.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (16, 98765432, N'ALBA NANCY', N'FERNANDEZ', N'Almaguer', N'Carrera 6 No. 54 - 04', CAST(890765 AS Numeric(11, 0)), N'woketokop@lucyu.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (17, 34537008, N'LEYLA MILENA', N'LLANTEN', N'Dibulia', N'Calle 63 No. 9-60', CAST(786543 AS Numeric(11, 0)), N'bixolawe@getapet.net')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (18, 25270934, N'FERNANDO ELIECER', N'CRUZ GALLO ', N'El Molino', N'Cr.9 # 74-99', CAST(1234567 AS Numeric(11, 0)), N'veboniho@refurhost.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1001, 63483237, N'MARTHA ELIANA', N'MENDOZA BECERRA', N'Bogotá', N'Cl.70a # 10-68', CAST(2813627 AS Numeric(11, 0)), N'cosuwexe@dnsdeer.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1002, 34557202, N'MARIA ALEXANDRA', N'MUNOZ CAMPO', N'Anapoima', N'Calle 9 Nº 4-93', CAST(3127368 AS Numeric(11, 0)), N'wumer@dnsdeer.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1003, 10533991, N'JULIO CESAR', N'ORTIZ VELASCO', N'Bogotá', N'Calle 54 7-26', CAST(2121429 AS Numeric(11, 0)), N'tuvudawi@ipdeer.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1004, 16687546, N'EDIER HUMBERTO', N'PEREZ', N'Medellín', N'Calle 94 # 7-48', CAST(6107782 AS Numeric(11, 0)), N'tareruxi@lilylee.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1005, 10544098, N'VICTOR HUGO', N'RENDON', N'Aguachica', N'Calle 9 Nº 4-93', CAST(2813627 AS Numeric(11, 0)), N'bivalu@dnsdeer.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1006, 25270727, N'NIDIA', N'SATIZABAL CASTILLO', N'Soacha', N'Cl.70a # 10-68', CAST(3101863 AS Numeric(11, 0)), N'dakumihub@ipdeer.com')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1007, 34539672, N'OLGA ADRIANA', N'VALDES CANENCIO', N'Villeta', N'Calle 45A 14-62', CAST(3366410 AS Numeric(11, 0)), N'vigewepele@micsocks.net')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1008, 25274823, N'CLAUDIA GIOVANN', N'VIVEROS TOBAR', N'Zipaquirá', N'Cr.13 # 14-69', CAST(2828180 AS Numeric(11, 0)), N'pubopenuvi@micsocks.net')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (1009, 34526987, N'LILIANA', N'ZURA ORDONEZ', N'Sopó', N'Calle 23 A No. 19-86', CAST(3412128 AS Numeric(11, 0)), N'gowocoda@dnsdeer.com')
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (1, N'Té Dharamsala', CAST(57546 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (2, N'Cerveza tibetana Barley', CAST(60743 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (3, N'Sirope de regaliz', CAST(31970 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (4, N'Especias Cajun del chef Anton', CAST(70334 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (5, N'Mezcla Gumbo del chef Anton', CAST(67137 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (6, N'Mermelada de grosellas de la abuela', CAST(79925 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (7, N'Peras secas orgánicas del tío Bob', CAST(95910 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (8, N'Salsa de arándanos Northwoods', CAST(127880 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (9, N'Buey Mishi Kobe', CAST(310109 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (10, N'Pez espada', CAST(99107 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (11, N'Queso Cabrales', CAST(67137 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (12, N'Queso Manchego La Pastora', CAST(121486 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (13, N'Algas Konbu', CAST(19182 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (14, N'Cuajada de judías', CAST(73531 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (15, N'Salsa de soja baja en sodio', CAST(51152 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (16, N'Postre de merengue Pavlova', CAST(54349 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (17, N'Cordero Alice Springs', CAST(124683 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (18, N'Langostinos tigre Carnarvon', CAST(201411 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (19, N'Pastas de té de chocolate', CAST(294124 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (20, N'Mermelada de Sir Rodney''s', CAST(258957 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (21, N'Bollos de Sir Rodney''s', CAST(31970 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (22, N'Pan de centeno crujiente estilo Gustaf''s', CAST(67137 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (23, N'Pan fino', CAST(28773 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (24, N'Refresco Guaraná Fantástica', CAST(15985 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (25, N'Crema de chocolate y nueces NuNuCa', CAST(44758 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (26, N'Ositos de goma Gumbär', CAST(99107 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (27, N'Chocolate Schoggi', CAST(140668 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (28, N'Col fermentada Rössle', CAST(147062 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (29, N'Salchicha Thüringer', CAST(396428 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (30, N'Arenque blanco del noroeste', CAST(83122 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (31, N'Queso gorgonzola Telino', CAST(41561 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (32, N'Queso Mascarpone Fabioli', CAST(102304 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (33, N'Queso de cabra', CAST(9591 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (34, N'Cerveza Sasquatch', CAST(44758 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (35, N'Cerveza negra Steeleye', CAST(57546 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (36, N'Escabeche de arenque', CAST(60743 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (37, N'Salmón ahumado Gravad', CAST(83122 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (38, N'Vino Côte de Blaye', CAST(844008 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (39, N'Licor verde Chartreuse', CAST(57546 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (40, N'Carne de cangrejo de Boston', CAST(57546 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (41, N'Crema de almejas estilo Nueva Inglaterra', CAST(31970 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (42, N'Tallarines de Singapur', CAST(44758 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (43, N'Café de Malasia', CAST(147062 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (44, N'Azúcar negra Malacca', CAST(60743 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (45, N'Arenque ahumado', CAST(31970 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (46, N'Arenque salado', CAST(38364 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (47, N'Galletas Zaanse', CAST(31970 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (48, N'Chocolate holandés', CAST(41561 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (49, N'Regaliz', CAST(63940 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (50, N'Chocolate blanco', CAST(51152 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (51, N'Manzanas secas Manjimup', CAST(169441 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (52, N'Cereales para Filo', CAST(22379 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (53, N'Empanada de carne', CAST(105501 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (54, N'Empanada de cerdo', CAST(22379 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (55, N'Paté chino', CAST(76728 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (56, N'Gnocchi de la abuela Alicia', CAST(121486 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (57, N'Raviolis Angelo', CAST(63940 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (58, N'Caracoles de Borgoña', CAST(41561 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (59, N'Raclet de queso Courdavault', CAST(175835 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (60, N'Camembert Pierrot', CAST(108698 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (61, N'Sirope de arce', CAST(92713 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (62, N'Tarta de azúcar', CAST(156653 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (63, N'Sandwich de vegetales', CAST(140668 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (64, N'Bollos de pan de Wimmer', CAST(105501 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (65, N'Salsa de pimiento picante de Luisiana', CAST(67137 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (66, N'Especias picantes de Luisiana', CAST(54349 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (67, N'Cerveza Laughing Lumberjack', CAST(44758 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (68, N'Barras de pan de Escocia', CAST(41561 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (69, N'Queso Gudbrandsdals', CAST(115092 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (70, N'Cerveza Outback', CAST(47955 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (71, N'Crema de queso Fløtemys', CAST(70334 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (72, N'Queso Mozzarella Giovanni', CAST(111895 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (73, N'Caviar rojo', CAST(47955 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (74, N'Queso de soja Longlife', CAST(31970 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (75, N'Cerveza Klosterbier Rhönbräu', CAST(25576 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (76, N'Licor Cloudberry', CAST(57546 AS Numeric(18, 0)))
INSERT [dbo].[Producto] ([id], [descripcion], [precioUnitario]) VALUES (77, N'Salsa verde original Frankfurter', CAST(41561 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[Producto] OFF
SET IDENTITY_INSERT [dbo].[Red_Supermercado] ON 

INSERT [dbo].[Red_Supermercado] ([id], [nombre]) VALUES (1, N'Polygamy Red de Supermercados')
SET IDENTITY_INSERT [dbo].[Red_Supermercado] OFF
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([id], [nombre], [descripcion]) VALUES (0, N'admin', N' ')
INSERT [dbo].[Rol] ([id], [nombre], [descripcion]) VALUES (4, N'Cajero', N'')
INSERT [dbo].[Rol] ([id], [nombre], [descripcion]) VALUES (5, N'Administrador', N'')
SET IDENTITY_INSERT [dbo].[Rol] OFF
SET IDENTITY_INSERT [dbo].[Supermercado] ON 

INSERT [dbo].[Supermercado] ([id], [ciudad], [direccion], [idRedSupermercado]) VALUES (1, N'Bogotá', N'Cra 1 # 1 -2', 1)
INSERT [dbo].[Supermercado] ([id], [ciudad], [direccion], [idRedSupermercado]) VALUES (2, N'Bogotá', N'Cra 2 # 2 - 3', 1)
INSERT [dbo].[Supermercado] ([id], [ciudad], [direccion], [idRedSupermercado]) VALUES (3, N'Bogotá', N'Calle 14 # 56- 78', 1)
INSERT [dbo].[Supermercado] ([id], [ciudad], [direccion], [idRedSupermercado]) VALUES (5, N'Medellín', N'Calle 23 # 123- 12', 1)
INSERT [dbo].[Supermercado] ([id], [ciudad], [direccion], [idRedSupermercado]) VALUES (6, N'Cali', N'Trans 23 # 13 - 14', 1)
SET IDENTITY_INSERT [dbo].[Supermercado] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [idRol], [nombreUsuario], [contrasena], [idPersona]) VALUES (0, 0, N'admin', N'.v^????E:???>???#???~???U??n', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
ALTER TABLE [dbo].[Acceso]  WITH CHECK ADD  CONSTRAINT [FK_Acceso_Permiso] FOREIGN KEY([idPermiso])
REFERENCES [dbo].[Permiso] ([id])
GO
ALTER TABLE [dbo].[Acceso] CHECK CONSTRAINT [FK_Acceso_Permiso]
GO
ALTER TABLE [dbo].[Acceso]  WITH CHECK ADD  CONSTRAINT [FK_Acceso_Rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Acceso] CHECK CONSTRAINT [FK_Acceso_Rol]
GO
ALTER TABLE [dbo].[Administrador_Supermercado]  WITH CHECK ADD  CONSTRAINT [FK_Administrador_Supermercado_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Administrador_Supermercado] CHECK CONSTRAINT [FK_Administrador_Supermercado_Persona]
GO
ALTER TABLE [dbo].[Administrador_Supermercado]  WITH CHECK ADD  CONSTRAINT [FK_Administrador_Supermercado_Supermercado] FOREIGN KEY([idSupermercado])
REFERENCES [dbo].[Supermercado] ([id])
GO
ALTER TABLE [dbo].[Administrador_Supermercado] CHECK CONSTRAINT [FK_Administrador_Supermercado_Supermercado]
GO
ALTER TABLE [dbo].[Afiliado]  WITH CHECK ADD  CONSTRAINT [FK_Afiliado_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Afiliado] CHECK CONSTRAINT [FK_Afiliado_Persona]
GO
ALTER TABLE [dbo].[Beneficiario]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiario_Afiliado] FOREIGN KEY([idAfiliado])
REFERENCES [dbo].[Afiliado] ([id])
GO
ALTER TABLE [dbo].[Beneficiario] CHECK CONSTRAINT [FK_Beneficiario_Afiliado]
GO
ALTER TABLE [dbo].[Beneficiario]  WITH CHECK ADD  CONSTRAINT [FK_Beneficiario_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Beneficiario] CHECK CONSTRAINT [FK_Beneficiario_Persona]
GO
ALTER TABLE [dbo].[Cajero_Supermercado]  WITH CHECK ADD  CONSTRAINT [FK_Cajero_Supermercado_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Cajero_Supermercado] CHECK CONSTRAINT [FK_Cajero_Supermercado_Persona]
GO
ALTER TABLE [dbo].[Cajero_Supermercado]  WITH CHECK ADD  CONSTRAINT [FK_Cajero_Supermercado_Supermercado] FOREIGN KEY([idSupermercado])
REFERENCES [dbo].[Supermercado] ([id])
GO
ALTER TABLE [dbo].[Cajero_Supermercado] CHECK CONSTRAINT [FK_Cajero_Supermercado_Supermercado]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Beneficiario] FOREIGN KEY([idBeneficiario])
REFERENCES [dbo].[Beneficiario] ([id])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Beneficiario]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Supermercado1] FOREIGN KEY([idSupermercado])
REFERENCES [dbo].[Supermercado] ([id])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Supermercado1]
GO
ALTER TABLE [dbo].[CompraDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CompraDetalle_Compra] FOREIGN KEY([idCompra])
REFERENCES [dbo].[Compra] ([id])
GO
ALTER TABLE [dbo].[CompraDetalle] CHECK CONSTRAINT [FK_CompraDetalle_Compra]
GO
ALTER TABLE [dbo].[CompraDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CompraDetalle_Producto1] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[CompraDetalle] CHECK CONSTRAINT [FK_CompraDetalle_Producto1]
GO
ALTER TABLE [dbo].[Supermercado]  WITH CHECK ADD  CONSTRAINT [FK_Supermercado_Red_Supermercado] FOREIGN KEY([idRedSupermercado])
REFERENCES [dbo].[Red_Supermercado] ([id])
GO
ALTER TABLE [dbo].[Supermercado] CHECK CONSTRAINT [FK_Supermercado_Red_Supermercado]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([id])
REFERENCES [dbo].[Rol] ([id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
USE [master]
GO
ALTER DATABASE [Poligamy] SET  READ_WRITE 
GO
