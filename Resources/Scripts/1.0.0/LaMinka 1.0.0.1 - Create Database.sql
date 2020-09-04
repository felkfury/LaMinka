USE [master]
GO
/****** Object:  Database [LaMinka]    Script Date: 8/30/2020 6:14:57 PM ******/
CREATE DATABASE [LaMinka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LaMinka', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCAL\MSSQL\DATA\LaMinka.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LaMinka_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCAL\MSSQL\DATA\LaMinka_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LaMinka] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LaMinka].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LaMinka] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LaMinka] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LaMinka] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LaMinka] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LaMinka] SET ARITHABORT OFF 
GO
ALTER DATABASE [LaMinka] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LaMinka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LaMinka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LaMinka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LaMinka] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LaMinka] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LaMinka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LaMinka] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LaMinka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LaMinka] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LaMinka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LaMinka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LaMinka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LaMinka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LaMinka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LaMinka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LaMinka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LaMinka] SET RECOVERY FULL 
GO
ALTER DATABASE [LaMinka] SET  MULTI_USER 
GO
ALTER DATABASE [LaMinka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LaMinka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LaMinka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LaMinka] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LaMinka] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LaMinka', N'ON'
GO
ALTER DATABASE [LaMinka] SET QUERY_STORE = OFF
GO
USE [LaMinka]
GO
/****** Object:  Schema [dbv]    Script Date: 8/30/2020 6:14:57 PM ******/
CREATE SCHEMA [dbv]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[IdUserAlta] [int] NULL,
	[IdUserModif] [int] NOT NULL,
	[IdUserBaja] [int] NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaModif] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
	[Activo] [bit] NOT NULL,
	[AlertaPedidoEnCamino] [bit] NULL,
	[AlertaHabilitaPedido] [bit] NULL,
	[MismoUltimoPedido] [bit] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteDomicilio]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteDomicilio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[EsPrincipal] [bit] NOT NULL,
	[PreguntarPor] [nvarchar](150) NULL,
	[Caracteristicas] [nvarchar](500) NULL,
	[Calle] [nvarchar](150) NOT NULL,
	[Numero] [nvarchar](10) NOT NULL,
	[Depto] [nchar](10) NULL,
	[EntreCalle] [nvarchar](150) NULL,
	[EntreCalle2] [nvarchar](150) NULL,
	[Latitud] [int] NOT NULL,
	[Longitud] [int] NOT NULL,
	[Localidad] [nvarchar](150) NOT NULL,
	[IdUserAlta] [int] NULL,
	[IdUserModif] [int] NOT NULL,
	[IdUserBaja] [int] NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaModif] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_ClienteDomicilios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaquetePedido]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaquetePedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaEntrega] [smalldatetime] NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdUserAlta] [int] NULL,
	[IdUserModif] [int] NOT NULL,
	[IdUserBaja] [int] NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaModif] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
	[Activo] [bit] NOT NULL,
	[FechaApertura] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_PaquetePedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaquetePedidoProducto]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaquetePedidoProducto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaquetePedido] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
 CONSTRAINT [PK_PaquetePedidoProductos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaquetePedidoReparto]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaquetePedidoReparto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaquetePedido] [int] NOT NULL,
	[IdRepartidor] [int] NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[Posición] [int] NOT NULL,
	[FechaEntrega] [smalldatetime] NULL,
	[Comentarios] [nvarchar](500) NULL,
 CONSTRAINT [PK_PaquetePedidoReparto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaquetePedidoRepartoEstado]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaquetePedidoRepartoEstado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaquetePedidoRepartoEstado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaquetePedido] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdClienteDomicilio] [int] NOT NULL,
	[FechaPedido] [smalldatetime] NOT NULL,
	[IdUserAlta] [int] NULL,
	[IdUserModif] [int] NOT NULL,
	[IdUserBaja] [int] NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaModif] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoDetalle]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdProductoValor] [int] NOT NULL,
 CONSTRAINT [PK_PedidoDetalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](200) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[FotoUrl] [nvarchar](500) NULL,
	[IdUserAlta] [int] NULL,
	[IdUserModif] [int] NOT NULL,
	[IdUserBaja] [int] NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaModif] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoValor]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoValor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [nvarchar](150) NOT NULL,
	[Importe] [money] NOT NULL,
	[IdUserAlta] [int] NULL,
	[IdUserModif] [int] NOT NULL,
	[IdUserBaja] [int] NOT NULL,
	[FechaAlta] [smalldatetime] NULL,
	[FechaModif] [smalldatetime] NULL,
	[FechaBaja] [smalldatetime] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoValores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DocumentNumber] [varchar](80) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Password] [varchar](100) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[UserToken] [varchar](200) NULL,
	[CreationDate] [datetime] NOT NULL,
	[BirthDate] [smalldatetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[ZonaPoligono] [nvarchar](500) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRole] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbv].[DatabaseExecution]    Script Date: 8/30/2020 6:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbv].[DatabaseExecution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Version] [nvarchar](max) NULL,
	[Script] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[ExecutionDate] [datetime] NOT NULL,
	[EnforceExecution] [bit] NOT NULL,
 CONSTRAINT [PK_dbv.DatabaseExecution] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Repartidor')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Name], [LastName], [Email], [DocumentNumber], [PhoneNumber], [Password], [EmailConfirmed], [Active], [UserToken], [CreationDate], [BirthDate], [IsDeleted], [ZonaPoligono]) VALUES (1, N'Admin', N'Admin', N'user@admin.com', N'43769948M', N'02926 407104', N'5TfqJcyG1V8=', 1, 1, NULL, CAST(N'2020-08-03T14:59:05.613' AS DateTime), CAST(N'1990-01-01T00:00:00' AS SmallDateTime), 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 
GO
INSERT [dbo].[UserRole] ([Id], [IdRole], [IdUser]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ClienteDomicilio]  WITH CHECK ADD  CONSTRAINT [FK_ClienteDomicilios_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[ClienteDomicilio] CHECK CONSTRAINT [FK_ClienteDomicilios_Clientes]
GO
ALTER TABLE [dbo].[PaquetePedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_PaquetePedidoProductos_PaquetePedido] FOREIGN KEY([IdPaquetePedido])
REFERENCES [dbo].[PaquetePedido] ([Id])
GO
ALTER TABLE [dbo].[PaquetePedidoProducto] CHECK CONSTRAINT [FK_PaquetePedidoProductos_PaquetePedido]
GO
ALTER TABLE [dbo].[PaquetePedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_PaquetePedidoProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[PaquetePedidoProducto] CHECK CONSTRAINT [FK_PaquetePedidoProductos_Productos]
GO
ALTER TABLE [dbo].[PaquetePedidoReparto]  WITH CHECK ADD  CONSTRAINT [FK_PaquetePedidoReparto_PaquetePedido] FOREIGN KEY([IdPaquetePedido])
REFERENCES [dbo].[PaquetePedido] ([Id])
GO
ALTER TABLE [dbo].[PaquetePedidoReparto] CHECK CONSTRAINT [FK_PaquetePedidoReparto_PaquetePedido]
GO
ALTER TABLE [dbo].[PaquetePedidoReparto]  WITH CHECK ADD  CONSTRAINT [FK_PaquetePedidoReparto_PaquetePedidoRepartoEstado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[PaquetePedidoRepartoEstado] ([Id])
GO
ALTER TABLE [dbo].[PaquetePedidoReparto] CHECK CONSTRAINT [FK_PaquetePedidoReparto_PaquetePedidoRepartoEstado]
GO
ALTER TABLE [dbo].[PaquetePedidoReparto]  WITH CHECK ADD  CONSTRAINT [FK_PaquetePedidoReparto_Pedidos] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[PaquetePedidoReparto] CHECK CONSTRAINT [FK_PaquetePedidoReparto_Pedidos]
GO
ALTER TABLE [dbo].[PaquetePedidoReparto]  WITH CHECK ADD  CONSTRAINT [FK_PaquetePedidoReparto_User] FOREIGN KEY([IdRepartidor])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PaquetePedidoReparto] CHECK CONSTRAINT [FK_PaquetePedidoReparto_User]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_ClienteDomicilios] FOREIGN KEY([IdClienteDomicilio])
REFERENCES [dbo].[ClienteDomicilio] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedidos_ClienteDomicilios]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedidos_Clientes]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_PaquetePedido] FOREIGN KEY([IdPaquetePedido])
REFERENCES [dbo].[PaquetePedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedidos_PaquetePedido]
GO
ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PedidoDetalle_Pedidos] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[PedidoDetalle] CHECK CONSTRAINT [FK_PedidoDetalle_Pedidos]
GO
ALTER TABLE [dbo].[ProductoValor]  WITH CHECK ADD  CONSTRAINT [FK_ProductoValores_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[ProductoValor] CHECK CONSTRAINT [FK_ProductoValores_Productos]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
USE [master]
GO
ALTER DATABASE [LaMinka] SET  READ_WRITE 
GO
