USE [BlogDapper]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Asunto] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Contenido] [nvarchar](max) NOT NULL,
	[Aprobado] [bit] NOT NULL,
	[PublicacionId] [int] NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[AreaId] [int] NOT NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publicacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
	[Resumen] [nvarchar](max) NOT NULL,
	[Contenido] [nvarchar](max) NOT NULL,
	[Etiquetas] [nvarchar](max) NOT NULL,
	[UsuarioId] [int] NULL,
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellidos] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Contrasena] [nvarchar](max) NOT NULL,
	[PerfilId] [int] NOT NULL,
	[DepartamentoId] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Comentario_Publicacion_PublicacionId] FOREIGN KEY([PublicacionId])
REFERENCES [dbo].[Publicacion] ([Id])
GO
ALTER TABLE [dbo].[Comentario] CHECK CONSTRAINT [FK_Comentario_Publicacion_PublicacionId]
GO
ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_Area_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Departamento] CHECK CONSTRAINT [FK_Departamento_Area_AreaId]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Usuario_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Usuario_UsuarioId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Departamento_DepartamentoId] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Departamento_DepartamentoId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil_PerfilId] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil_PerfilId]
GO
/****** Object:  StoredProcedure [dbo].[spCreatePublicacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spCreatePublicacion] 
	@Id int output,
	@Titulo	varchar(max),
	@Resumen	varchar(max),	
	@Contenido	varchar(max),
	@Etiquetas		varchar(max),
	@UsuarioId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    BEGIN
		INSERT INTO [dbo].[Publicacion]
           ([Titulo]
           ,[Resumen]
           ,[Contenido]
           ,[Etiquetas]
           ,[UsuarioId])
		VALUES
           (@Titulo,
           @Resumen, 
           @Contenido,
           @Etiquetas,
           @UsuarioId);
		SET @Id = cast(scope_identity() as int)
	END;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeletePublicacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spDeletePublicacion] 	
	@Id int
AS
BEGIN	
    
	DELETE
	FROM [dbo].[Publicacion]
	WHERE [Id]=@Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllPublicacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spGetAllPublicacion] 	
AS
BEGIN	
    
	SELECT [Id], [Titulo], [Resumen],
        [Contenido], [Etiquetas], [UsuarioId]        
	FROM [dbo].[Publicacion]
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPublicacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetPublicacion]
	@Id int
AS
BEGIN
	SELECT [Id],[Titulo],[Resumen],[Contenido],[Etiquetas],[UsuarioId]
	FROM [dbo].[Publicacion]
	WHERE Id = @Id;	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPublicacionConComentarios]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spGetPublicacionConComentarios] 	
	@Id int
AS
BEGIN	
    
	SELECT [Id],[Titulo],[Resumen],
		[Contenido],[Etiquetas],[UsuarioId]
	FROM [dbo].[Publicacion]
	WHERE Id = @Id;	

	SELECT [Id], [Asunto], [Email],
		[Contenido],[Aprobado],[PublicacionId]
	FROM [dbo].[Comentario] 
	WHERE [PublicacionId] = @Id;
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPublicacionesConComentarios]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spGetPublicacionesConComentarios] 		
AS
BEGIN	
    
	SELECT * FROM Publicacion P
        LEFT JOIN Comentario C ON C.PublicacionId=P.Id
	
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPublicacionesPaginacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spGetPublicacionesPaginacion] 
	@pageIndex int,
	@pageSize int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [Id], [Titulo], [Resumen],
        [Contenido], [Etiquetas], [UsuarioId]        
	FROM [dbo].[Publicacion]
	ORDER BY Titulo
	OFFSET (@pageIndex-1)*@pageSize ROWS
    FETCH NEXT @pageSize ROWS ONLY
	
END
GO
/****** Object:  StoredProcedure [dbo].[spMostrarUsuarioPublicacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMostrarUsuarioPublicacion] @Id int
AS

SELECT U.Id,U.Nombre,U.Apellidos,U.Email,D.Nombre as Departamento, A.Nombre as Area
FROM Usuario U 
LEFT JOIN Publicacion P ON U.Id=P.UsuarioId
LEFT JOIN Departamento D ON D.Id=U.DepartamentoId
LEFT JOIN Area A ON A.Id=D.AreaId
WHERE P.Id=@Id


GO
/****** Object:  StoredProcedure [dbo].[spUpdatePublicacion]    Script Date: 24/05/2022 18:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[spUpdatePublicacion] 
	@Id int,
	@Titulo	varchar(max),
	@Resumen	varchar(max),	
	@Contenido	varchar(max),
	@Etiquetas		varchar(max)	
AS
BEGIN	
    
	UPDATE [dbo].[Publicacion]
        SET [Titulo]=@Titulo,
        [Resumen]=@Resumen,
        [Contenido]=@Contenido,
        [Etiquetas]=@Etiquetas        
	WHERE [Id]=@Id
	
END
GO
