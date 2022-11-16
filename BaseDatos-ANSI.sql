USE [Productos]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 15/11/2022 7:20:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Codigo_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Estado_Producto] [varchar](100) NOT NULL,
	[Fecha_Fabricacion] [date] NOT NULL,
	[Fecha_Validez] [date] NOT NULL,
	[Codigo_Proveedor] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Codigo_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 15/11/2022 7:20:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Codigo_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Codigo_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (1, N'Leche deslactosada 1litro', N'Activo', CAST(N'2022-11-11' AS Date), CAST(N'2023-11-10' AS Date), 1)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (2, N'Arroz Diana de 1kg', N'Activo', CAST(N'2022-10-10' AS Date), CAST(N'2023-11-09' AS Date), 2)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (3, N'Café Juan valdez 500 gramos', N'Activo', CAST(N'2022-10-12' AS Date), CAST(N'2023-12-12' AS Date), 3)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (4, N'Huevos KIKE 30 Unidades', N'Activo', CAST(N'2022-11-11' AS Date), CAST(N'2023-11-12' AS Date), 4)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (5, N'Arroz de coco Diana de 1kg', N'Activo', CAST(N'2022-10-10' AS Date), CAST(N'2023-11-09' AS Date), 2)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (6, N'Café Gourmet Juan valdez de 500 gramos', N'Activo', CAST(N'2022-10-12' AS Date), CAST(N'2023-12-12' AS Date), 3)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (7, N'Leche entera de 1litro', N'Activo', CAST(N'2022-11-11' AS Date), CAST(N'2023-11-10' AS Date), 1)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (8, N'Huevos KIKE 12 Unidades', N'Activo', CAST(N'2022-11-11' AS Date), CAST(N'2023-11-12' AS Date), 4)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (9, N'Salchicha Ranchera 12 unidades', N'Activo', CAST(N'2022-10-11' AS Date), CAST(N'2023-12-12' AS Date), 5)
INSERT [dbo].[Producto] ([Codigo_Producto], [Descripcion], [Estado_Producto], [Fecha_Fabricacion], [Fecha_Validez], [Codigo_Proveedor]) VALUES (12, N'Prueba', N'Activo', CAST(N'2022-11-14' AS Date), CAST(N'2022-11-15' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([Codigo_Proveedor], [Nombre], [Descripcion], [Telefono]) VALUES (1, N'Colanta', N'Empresa manejadora para importacion de leche.', N'3006338992')
INSERT [dbo].[Proveedor] ([Codigo_Proveedor], [Nombre], [Descripcion], [Telefono]) VALUES (2, N'Arroz Diana', N'Empresa colombiana de arroz ', N'3118989898')
INSERT [dbo].[Proveedor] ([Codigo_Proveedor], [Nombre], [Descripcion], [Telefono]) VALUES (3, N'Juan Valdez', N'Empresa colombiana de cafeteros', N'3215658989')
INSERT [dbo].[Proveedor] ([Codigo_Proveedor], [Nombre], [Descripcion], [Telefono]) VALUES (4, N'Huevos kike', N'Empresa comercializadora de huevo', N'3158987744')
INSERT [dbo].[Proveedor] ([Codigo_Proveedor], [Nombre], [Descripcion], [Telefono]) VALUES (5, N'Zenu', N'Empresa comercializadora de carnes frias', N'3125658651')
INSERT [dbo].[Proveedor] ([Codigo_Proveedor], [Nombre], [Descripcion], [Telefono]) VALUES (7, N'Prueba', N'Empresa manejadora para importacion de leche.', N'3006338992')
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor] FOREIGN KEY([Codigo_Proveedor])
REFERENCES [dbo].[Proveedor] ([Codigo_Proveedor])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor]
GO
