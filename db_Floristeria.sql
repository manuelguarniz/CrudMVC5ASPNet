USE [master]
GO
/****** Object:  Database [db_floristeria]    Script Date: 03/05/2016 02:07:47 a.m. ******/
CREATE DATABASE [db_floristeria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_floristeria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\db_floristeria.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_floristeria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\db_floristeria_log.ldf' , SIZE = 1344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_floristeria] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_floristeria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_floristeria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_floristeria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_floristeria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_floristeria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_floristeria] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_floristeria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_floristeria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_floristeria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_floristeria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_floristeria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_floristeria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_floristeria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_floristeria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_floristeria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_floristeria] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_floristeria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_floristeria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_floristeria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_floristeria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_floristeria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_floristeria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_floristeria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_floristeria] SET RECOVERY FULL 
GO
ALTER DATABASE [db_floristeria] SET  MULTI_USER 
GO
ALTER DATABASE [db_floristeria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_floristeria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_floristeria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_floristeria] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [db_floristeria] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_floristeria', N'ON'
GO
USE [db_floristeria]
GO
/****** Object:  Table [dbo].[AlmacenProductos]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AlmacenProductos](
	[idAlmacenProductos] [int] IDENTITY(1,1) NOT NULL,
	[descripcionALPR] [varchar](255) NULL,
	[procedencia] [varchar](128) NULL,
	[fechaCompraALPR] [date] NOT NULL,
	[mesCompraALPR] [date] NOT NULL,
	[tiempoConservacionALPR] [text] NULL,
	[importeCompraALPR] [numeric](10, 2) NOT NULL,
	[stockALPR] [text] NULL,
	[idProdMes] [int] NOT NULL,
 CONSTRAINT [PK_ALMP] PRIMARY KEY CLUSTERED 
(
	[idAlmacenProductos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriaProducto](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[descripcionCat] [varchar](255) NULL,
 CONSTRAINT [PK_CATEPRO] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombreCli] [varchar](255) NULL,
	[apellidoCli] [varchar](255) NULL,
	[telefonoCli] [varchar](16) NULL,
	[dniCli] [varchar](16) NULL,
	[correoCli] [varchar](128) NULL,
	[usuarioCli] [varchar](255) NULL,
	[passwordCli] [varchar](255) NULL,
	[activoCli] [bit] NULL,
 CONSTRAINT [PK_CLI] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ComposicionProducto]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComposicionProducto](
	[idComposicion] [int] IDENTITY(1,1) NOT NULL,
	[idAlmacenProductos] [int] NULL,
	[id_producto] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleFacturacion]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFacturacion](
	[idDetalleFact] [int] IDENTITY(1,1) NOT NULL,
	[idFacturacion] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidadPedido] [int] NOT NULL,
	[importeVenta] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_DETFAC] PRIMARY KEY CLUSTERED 
(
	[idDetalleFact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetallePedidoProducto]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DetallePedidoProducto](
	[idDetallePedidoProd] [int] IDENTITY(1,1) NOT NULL,
	[idPedidoProd] [int] NULL,
	[idProducto] [int] NULL,
	[cantidadPedido] [numeric](10, 2) NOT NULL,
	[direccionPedido] [varchar](200) NULL,
	[incrementoDistancia] [decimal](10, 0) NOT NULL,
	[entregaEfectivaPed] [binary](1) NOT NULL,
 CONSTRAINT [PK_DETPEPR] PRIMARY KEY CLUSTERED 
(
	[idDetallePedidoProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombreEmp] [varchar](255) NULL,
	[apellidosEmp] [varchar](255) NULL,
	[telefonoEmp] [varchar](16) NULL,
	[dniEmp] [varchar](16) NULL,
	[correoEmp] [varchar](128) NULL,
	[usuarioEmp] [varchar](255) NULL,
	[passwordEmp] [varchar](255) NULL,
	[activoEmp] [bit] NULL,
 CONSTRAINT [PK_EMP] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FacturacionProducto]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturacionProducto](
	[idFacturacion] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[fechaFact] [date] NOT NULL,
 CONSTRAINT [PK_FACPRO] PRIMARY KEY CLUSTERED 
(
	[idFacturacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoProducto]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoProducto](
	[iPedidoProd] [int] IDENTITY(1,1) NOT NULL,
	[idFacturacion] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[fechaPedido] [date] NOT NULL,
	[fechaEntrega] [date] NOT NULL,
 CONSTRAINT [PK_PEPRO] PRIMARY KEY CLUSTERED 
(
	[iPedidoProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productoMes]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[productoMes](
	[idProdMes] [int] IDENTITY(1,1) NOT NULL,
	[descripcionMes] [varchar](16) NULL,
	[destacamientoMes] [varchar](255) NULL,
	[colorProdMes] [varchar](64) NULL,
	[importeCompraALPR] [numeric](10, 2) NOT NULL,
	[incremento] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PROMES] PRIMARY KEY CLUSTERED 
(
	[idProdMes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[detalleProducto] [text] NULL,
	[tiempoElab] [text] NULL,
	[incrementoxProduccion] [numeric](10, 2) NOT NULL,
	[disponibilidad] [bit] NULL,
	[cantidadDisponible] [numeric](10, 2) NOT NULL,
	[idCategoria] [int] NOT NULL,
	[imagen] [varchar](300) NULL,
	[descripcionProducto] [varchar](300) NULL,
 CONSTRAINT [PK_PRO] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] ON 

GO
INSERT [dbo].[CategoriaProducto] ([idCategoria], [descripcionCat]) VALUES (1, N'ARREGLOS PERSONALIZADOS')
GO
INSERT [dbo].[CategoriaProducto] ([idCategoria], [descripcionCat]) VALUES (2, N'RAMOS')
GO
INSERT [dbo].[CategoriaProducto] ([idCategoria], [descripcionCat]) VALUES (3, N'TORTAS')
GO
INSERT [dbo].[CategoriaProducto] ([idCategoria], [descripcionCat]) VALUES (4, N'CENTROS DE MESA')
GO
SET IDENTITY_INSERT [dbo].[CategoriaProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

GO
INSERT [dbo].[Cliente] ([idCliente], [nombreCli], [apellidoCli], [telefonoCli], [dniCli], [correoCli], [usuarioCli], [passwordCli], [activoCli]) VALUES (1, N'JULIO', N'VERNALE SIFUENTES', N'987654321', N'12345678', N'JVERNALES@EXAMPLE.COM', N'JBERNALES', N'123', 0)
GO
INSERT [dbo].[Cliente] ([idCliente], [nombreCli], [apellidoCli], [telefonoCli], [dniCli], [correoCli], [usuarioCli], [passwordCli], [activoCli]) VALUES (2, N'MARIA', N'ALVARADO MELLIDO', N'987654321', N'12345678', N'MALVARADO@EXAMPLE.COM', N'MALVARADO', N'123', 1)
GO
INSERT [dbo].[Cliente] ([idCliente], [nombreCli], [apellidoCli], [telefonoCli], [dniCli], [correoCli], [usuarioCli], [passwordCli], [activoCli]) VALUES (3, N'LUPITA', N'TORRES LUJAN', N'987654321', N'12345678', N'LTORRES@EXAMPLE.COM', N'LTORRES', N'123', 1)
GO
INSERT [dbo].[Cliente] ([idCliente], [nombreCli], [apellidoCli], [telefonoCli], [dniCli], [correoCli], [usuarioCli], [passwordCli], [activoCli]) VALUES (4, N'NEWTON', N'GUARNIZ CRUZ', N'123456', N'12345678', N'NEWTON_123@HOTMAIL.COM', N'NEWTON', N'123', 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

GO
INSERT [dbo].[Empleado] ([idEmpleado], [nombreEmp], [apellidosEmp], [telefonoEmp], [dniEmp], [correoEmp], [usuarioEmp], [passwordEmp], [activoEmp]) VALUES (1, N'manuel', N'guarniz', N'044271634', N'71854508', N'onesevendevelopment@hotmail.com', N'oneseven', N'asd', 1)
GO
INSERT [dbo].[Empleado] ([idEmpleado], [nombreEmp], [apellidosEmp], [telefonoEmp], [dniEmp], [correoEmp], [usuarioEmp], [passwordEmp], [activoEmp]) VALUES (2, N'jordan', N'dias castillo', N'942001177', N'73662017', N'smit.d.c@hotmail.com', N'smitsdc', N'123', 0)
GO
INSERT [dbo].[Empleado] ([idEmpleado], [nombreEmp], [apellidosEmp], [telefonoEmp], [dniEmp], [correoEmp], [usuarioEmp], [passwordEmp], [activoEmp]) VALUES (3, N'newton', N'guarniz', N'1875410', N'71854526', N'newton_456_cancer@hotmail.com', N'dumm', N'123', 1)
GO
SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

GO
INSERT [dbo].[Productos] ([idProducto], [detalleProducto], [tiempoElab], [incrementoxProduccion], [disponibilidad], [cantidadDisponible], [idCategoria], [imagen], [descripcionProducto]) VALUES (1, N'retrt', N'15m', CAST(0.10 AS Numeric(10, 2)), 1, CAST(0.00 AS Numeric(10, 2)), 2, N'rosa.png', N'rosa')
GO
INSERT [dbo].[Productos] ([idProducto], [detalleProducto], [tiempoElab], [incrementoxProduccion], [disponibilidad], [cantidadDisponible], [idCategoria], [imagen], [descripcionProducto]) VALUES (2, N'fgdfgdfg', N'15m', CAST(0.10 AS Numeric(10, 2)), 1, CAST(0.00 AS Numeric(10, 2)), 1, N'17- 4 centros de mesa para bodas.jpg', N'17- 4 centros de mesa para bodas')
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
ALTER TABLE [dbo].[AlmacenProductos]  WITH CHECK ADD  CONSTRAINT [FK_PROMES_ALMP] FOREIGN KEY([idProdMes])
REFERENCES [dbo].[productoMes] ([idProdMes])
GO
ALTER TABLE [dbo].[AlmacenProductos] CHECK CONSTRAINT [FK_PROMES_ALMP]
GO
ALTER TABLE [dbo].[ComposicionProducto]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([idProducto])
GO
ALTER TABLE [dbo].[ComposicionProducto]  WITH CHECK ADD  CONSTRAINT [FK_COMPRO_ALMP] FOREIGN KEY([idAlmacenProductos])
REFERENCES [dbo].[AlmacenProductos] ([idAlmacenProductos])
GO
ALTER TABLE [dbo].[ComposicionProducto] CHECK CONSTRAINT [FK_COMPRO_ALMP]
GO
ALTER TABLE [dbo].[ComposicionProducto]  WITH CHECK ADD  CONSTRAINT [PK_COMPRO] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([idProducto])
GO
ALTER TABLE [dbo].[ComposicionProducto] CHECK CONSTRAINT [PK_COMPRO]
GO
ALTER TABLE [dbo].[DetalleFacturacion]  WITH CHECK ADD  CONSTRAINT [FK_COMPRO_FACPRO] FOREIGN KEY([idFacturacion])
REFERENCES [dbo].[FacturacionProducto] ([idFacturacion])
GO
ALTER TABLE [dbo].[DetalleFacturacion] CHECK CONSTRAINT [FK_COMPRO_FACPRO]
GO
ALTER TABLE [dbo].[DetallePedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_DETPEPR_PEPRO] FOREIGN KEY([idPedidoProd])
REFERENCES [dbo].[PedidoProducto] ([iPedidoProd])
GO
ALTER TABLE [dbo].[DetallePedidoProducto] CHECK CONSTRAINT [FK_DETPEPR_PEPRO]
GO
ALTER TABLE [dbo].[DetallePedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_DETPEPR_PRO] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([idProducto])
GO
ALTER TABLE [dbo].[DetallePedidoProducto] CHECK CONSTRAINT [FK_DETPEPR_PRO]
GO
ALTER TABLE [dbo].[FacturacionProducto]  WITH CHECK ADD  CONSTRAINT [FK_FACPRO_CLI] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[FacturacionProducto] CHECK CONSTRAINT [FK_FACPRO_CLI]
GO
ALTER TABLE [dbo].[FacturacionProducto]  WITH CHECK ADD  CONSTRAINT [FK_FACPRO_EMP] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[FacturacionProducto] CHECK CONSTRAINT [FK_FACPRO_EMP]
GO
ALTER TABLE [dbo].[PedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_PEPRO_CLI] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[PedidoProducto] CHECK CONSTRAINT [FK_PEPRO_CLI]
GO
ALTER TABLE [dbo].[PedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_PEPRO_EMP] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[PedidoProducto] CHECK CONSTRAINT [FK_PEPRO_EMP]
GO
ALTER TABLE [dbo].[PedidoProducto]  WITH CHECK ADD  CONSTRAINT [FK_PEPRO_FACPRO] FOREIGN KEY([idFacturacion])
REFERENCES [dbo].[FacturacionProducto] ([idFacturacion])
GO
ALTER TABLE [dbo].[PedidoProducto] CHECK CONSTRAINT [FK_PEPRO_FACPRO]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_PRO_CATEPRO] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[CategoriaProducto] ([idCategoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_PRO_CATEPRO]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActivarClientes]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActivarClientes]
	@prmintIdCli int
AS
	UPDATE Cliente
	SET 
		activoCli = 1
	WHERE
		idCliente = @prmintIdCli

GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarClientes]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[sp_AgregarClientes]
	@prmstrNombreCli varchar(255),
	@prmstrApellidoCli varchar(255),
	@prmstrTelefonoCli varchar(16),
	@prmstrDniCli varchar(16),
	@prmstrCorreoCli varchar(128),
	@pdmstrUsuarioCli varchar(255),
	@prmstrPasswordCli varchar(255)
AS
	INSERT INTO Cliente(nombreCli, apellidoCli, telefonoCli, dniCli,
	correoCli, usuarioCli, passwordCli, activoCli)
	VALUES(@prmstrNombreCli,@prmstrApellidoCli,@prmstrTelefonoCli,@prmstrDniCli,
	@prmstrCorreoCli,@pdmstrUsuarioCli,@prmstrPasswordCli,1)

GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarClientes]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[sp_BuscarClientes]
@prmintIdCliente int
AS
	SELECT idCliente, nombreCli, apellidoCli, telefonoCli, dniCli, correoCli, usuarioCli, passwordCli, activoCli
	FROM Cliente
	WHERE (idCliente = @prmintIdCliente OR @prmintIdCliente = 0) AND activoCli = 1

GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarProductos]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BuscarProductos]
@prmintIdProduc int
AS
	SELECT p.idProducto,p.descripcionProducto, p.detalleProducto, p.tiempoElab, p.incrementoxProduccion,
			p.disponibilidad,p.cantidadDisponible, c.idCategoria, c.descripcionCat, p.imagen
	FROM Productos p INNER JOIN CategoriaProducto c
		ON p.idCategoria = c.idCategoria
	WHERE (p.idProducto = @prmintIdProduc OR @prmintIdProduc = 0)

GO
/****** Object:  StoredProcedure [dbo].[sp_EditarClientes]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[sp_EditarClientes]
	@prmintIdCli int,
	@prmstrNombreCli varchar(255),
	@prmstrApellidoCli varchar(255),
	@prmstrTelefonoCli varchar(16),
	@prmstrDniCli varchar(16),
	@prmstrCorreoCli varchar(128),
	@pdmstrUsuarioCli varchar(255),
	@prmstrPasswordCli varchar(255)
AS
	UPDATE Cliente
	SET 
		nombreCli = @prmstrNombreCli,
		apellidoCli = @prmstrApellidoCli,
		telefonoCli = @prmstrTelefonoCli,
		dniCli = @prmstrDniCli,
		correoCli = @prmstrCorreoCli,
		usuarioCli = @pdmstrUsuarioCli,
		passwordCli = @prmstrPasswordCli
	WHERE
		idCliente = @prmintIdCli

GO
/****** Object:  StoredProcedure [dbo].[sp_EditarProductos]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditarProductos]
	@prmintIdProd int,
	@prmstrDescipcion varchar(255),
	@prmstrDetalleProducto text,
	@prmstrTiempoElaboracion text,
	@prmnumIncremento numeric(10,2),
	@prmboolDisponibilidad bit,
	@prmnumCantidad numeric(10,2),
	@prmintIdCate int,
	@prmstrImagen varchar(300)
AS
	UPDATE Productos
	SET
		descripcionProducto = @prmstrDescipcion,
		detalleProducto = @prmstrDetalleProducto,
		tiempoElab = @prmstrTiempoElaboracion,
		incrementoxProduccion = @prmnumIncremento,
		disponibilidad = @prmboolDisponibilidad,
		cantidadDisponible = @prmnumCantidad,
		idCategoria = @prmintIdCate,
		imagen = @prmstrImagen
	WHERE
		idProducto = @prmintIdProd

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarClientes]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarClientes]
	@prmintIdCli int
AS
	UPDATE Cliente
	SET 
		activoCli = 0
	WHERE
		idCliente = @prmintIdCli

GO
/****** Object:  StoredProcedure [dbo].[sp_IngresarProductos]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_IngresarProductos]
@prmstrDescipcion varchar(255),
@prmstrDetalleProducto text,
@prmstrTiempoElaboracion text,
@prmnumIncremento numeric(10,2),
@prmboolDisponibilidad bit,
@prmnumCantidad numeric(10,2),
@prmintIdCate int,
@prmstrImagen varchar(300)
AS
	INSERT INTO Productos(descripcionProducto, detalleProducto, tiempoElab, incrementoxProduccion,
		disponibilidad, cantidadDisponible, idCategoria, imagen)
	VALUES (@prmstrDescipcion,@prmstrDetalleProducto,@prmstrTiempoElaboracion,@prmnumIncremento,
		@prmboolDisponibilidad,@prmnumCantidad,@prmintIdCate,@prmstrImagen)

GO
/****** Object:  StoredProcedure [dbo].[sp_listarCategorias]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listarCategorias]
AS
	SELECT idCategoria, descripcionCat FROM CategoriaProducto

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarProductosCategorias]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListarProductosCategorias]
@prmsintId int
AS
	SELECT p.idProducto,p.descripcionProducto, p.detalleProducto, p.tiempoElab, p.incrementoxProduccion,
			p.disponibilidad,p.cantidadDisponible, c.idCategoria, c.descripcionCat, p.imagen
	FROM Productos p INNER JOIN CategoriaProducto c
		ON p.idCategoria = c.idCategoria
	WHERE (p.idProducto = @prmsintId OR @prmsintId = 0)

GO
/****** Object:  StoredProcedure [dbo].[sp_VerEliminadosClientes]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_VerEliminadosClientes]
@prmintIdCliente int
AS
	SELECT idCliente, nombreCli, apellidoCli, telefonoCli, dniCli, correoCli, usuarioCli, passwordCli, activoCli
	FROM Cliente
	WHERE (idCliente = @prmintIdCliente OR @prmintIdCliente = 0) AND activoCli = 0

GO
/****** Object:  StoredProcedure [dbo].[sp_VerificarAcceso]    Script Date: 03/05/2016 02:07:47 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_VerificarAcceso]
@prmstrUsuario varchar(255),
@prmstrPassword varchar(255)
AS
	SELECT idEmpleado, nombreEmp, apellidosEmp, telefonoEmp, dniEmp, correoEmp, activoEmp
	FROM [dbo].[Empleado]
	WHERE usuarioEmp = @prmstrUsuario AND passwordEmp = @prmstrPassword

GO
USE [master]
GO
ALTER DATABASE [db_floristeria] SET  READ_WRITE 
GO
