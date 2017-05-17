USE [master]
GO
/****** Object:  Database [Poligamy]    Script Date: 16/05/2017 21:17:47 ******/
CREATE DATABASE [Poligamy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Poligamy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Poligamy.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Poligamy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Poligamy_log.ldf' , SIZE = 6272KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[Acceso]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Administrador_Supermercado]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Afiliado]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Beneficiario]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Cajero_Supermercado]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Compra]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[CompraDetalle]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Permiso]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Persona]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 16/05/2017 21:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
	[precioUnitario] [numeric](18, 0) NOT NULL,
 CONSTRAINT [pk_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Red_Supermercado]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Supermercado]    Script Date: 16/05/2017 21:17:47 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/05/2017 21:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[nombreUsuario] [nvarchar](50) NOT NULL,
	[contrasena] [nvarchar](10) NOT NULL,
	[idPersona] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Afiliado] ON 

INSERT [dbo].[Afiliado] ([id], [cupo], [idPersona]) VALUES (1, CAST(34234 AS Numeric(8, 0)), 7)
INSERT [dbo].[Afiliado] ([id], [cupo], [idPersona]) VALUES (2, CAST(100000 AS Numeric(8, 0)), 8)
SET IDENTITY_INSERT [dbo].[Afiliado] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (7, 56756756, N'gsf', N'fsdfsdf', N'dgsdf', N'gdsfg', CAST(3424234 AS Numeric(11, 0)), N'sdgdg')
INSERT [dbo].[Persona] ([id], [identificacion], [nombres], [apellidos], [ciudadResidencia], [direccionResidencia], [numeroTelefono], [email]) VALUES (8, 1234567890, N'Juan', N'Rojas', N'Madrid', N'Calle 22 # 3 - 23', CAST(3102336084 AS Numeric(11, 0)), N'egeda9@gmail.com')
SET IDENTITY_INSERT [dbo].[Persona] OFF
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
