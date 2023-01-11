USE [BlogDapper]
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([Id], [Nombre]) VALUES (1, N'Direccion General')
INSERT [dbo].[Area] ([Id], [Nombre]) VALUES (2, N'Informatica')
INSERT [dbo].[Area] ([Id], [Nombre]) VALUES (3, N'Administracion General')
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
SET IDENTITY_INSERT [dbo].[Departamento] ON 

INSERT [dbo].[Departamento] ([Id], [Nombre], [AreaId]) VALUES (1, N'Secretaria General', 1)
INSERT [dbo].[Departamento] ([Id], [Nombre], [AreaId]) VALUES (2, N'Sistemas', 2)
INSERT [dbo].[Departamento] ([Id], [Nombre], [AreaId]) VALUES (3, N'Finanzas', 3)
INSERT [dbo].[Departamento] ([Id], [Nombre], [AreaId]) VALUES (4, N'Redes', 2)
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (2, N'Encargado')
INSERT [dbo].[Perfil] ([Id], [Nombre]) VALUES (3, N'Apoyo')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellidos], [Email], [Contrasena], [PerfilId], [DepartamentoId]) VALUES (1, N'Jimmy Javier', N'Martinez', N'jimmyjavier@correo.com', N'Pa$$w0rd.', 1, 1)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellidos], [Email], [Contrasena], [PerfilId], [DepartamentoId]) VALUES (2, N'Esteban', N'Gutierrez', N'estebangutierrez@correo.com', N'Pa$$w0rd.', 2, 2)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellidos], [Email], [Contrasena], [PerfilId], [DepartamentoId]) VALUES (3, N'Sofia', N'Gonzalez', N'sofiagonzalez@correo.com', N'Pa$$w0rd.', 3, 1)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellidos], [Email], [Contrasena], [PerfilId], [DepartamentoId]) VALUES (4, N'Dulce', N'Perez', N'dulceperez@correo.com', N'Pa$$w0rd.', 1, 4)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellidos], [Email], [Contrasena], [PerfilId], [DepartamentoId]) VALUES (5, N'Alberto', N'Hernandez', N'albertohernandez@correo.com', N'Pa$$w0rd.', 2, 3)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO