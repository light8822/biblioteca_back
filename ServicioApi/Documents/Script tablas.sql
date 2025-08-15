DROP TABLE IF EXISTS [Clientes]

CREATE TABLE [Clientes] (
  [id_cliente] int IDENTITY(1,1) primary key,
  [nombre] varchar(100),
  [apellido] varchar(100),
  [dni] varchar(100),
  [telefono] varchar(100),
  [correo] varchar(100),
  [estado] int,
  [clave] varchar(100),
  [direccion] varchar(100),
  [ubigeo] varchar(100)
);

DROP TABLE IF EXISTS [Transaccion]

CREATE TABLE [Transaccion] (
  [id_transact] int IDENTITY(1,1) primary key,
  [fecha_entrega] date,
  [fecha_retorno] date,
  [id_cliente] int,
  [id_estado] int,
  [id_tipotran] int,
  [direccion] varchar(100)
);

DROP TABLE IF EXISTS [Pagos]

CREATE TABLE [Pagos] (
  [id_pago] int IDENTITY(1,1) primary key,
  [cantidad] int,
  [id_cliente] int,
  [id_transaccion] varchar(100),
  [Fecha] date,
  [id_medio] int,
);

DROP TABLE IF EXISTS [Detalle_transaccion]

CREATE TABLE [Detalle_transaccion] (
  [id_detalle] int IDENTITY(1,1) primary key,
  [id_ejemplar] int,
  [id_transact] int
);

DROP TABLE IF EXISTS [Medio_pago]

CREATE TABLE [Medio_pago] (
  [id_medio] int IDENTITY(1,1) primary key,
  [nombre] int
);

DROP TABLE IF EXISTS [Tipo_transact]

CREATE TABLE [Tipo_transact] (
  [id_tipotran] int IDENTITY(1,1) primary key,
  [nombre] int
);

DROP TABLE IF EXISTS [Libros]

CREATE TABLE [Libros] (
  [id_libro] int IDENTITY(1,1) primary key,
  [nombre] varchar(100),
  [genero] varchar(100),
  [cantidad] int,
  [precio_alquiler] decimal (18,2),
  [precio_venta] decimal (18,2)
);

DROP TABLE IF EXISTS [Productos]

CREATE TABLE [Productos] (
  [id_producto] int IDENTITY(1,1) primary key,
  [nombre] varchar(100),
  [cantidad] int,
  [precio_venta] decimal
);

DROP TABLE IF EXISTS [Ejemplares]

CREATE TABLE [Ejemplares] (
  [id_ejemplar] int IDENTITY(1,1) primary key,
  [codigo] varchar(100),
  [estado] int,
  [tipo_prod] int,
  [id_item] int,
  [id_estante] int
);

DROP TABLE IF EXISTS [Estantes]

CREATE TABLE [Estantes] (
  [id_estante] int IDENTITY(1,1) primary key,
  [codigo] varchar(100),
  [categoria] varchar(100)
);

DROP TABLE IF EXISTS [Perfil]

CREATE TABLE [Perfil] (
  [id_perfil] int IDENTITY(1,1) primary key,
  [nombre] varchar(100),
  [usuarios] int,
  [clientes] int,
  [ventas] int,
  [reportes] int,
  [lista_negra] int
);

DROP TABLE IF EXISTS [Usuarios]

CREATE TABLE [Usuarios] (
  [id_user] int IDENTITY(1,1) primary key,
  [codigo] varchar(100),
  [clave] varchar(100),
  [estado] int,
  [correo] varchar(100),
  [id_perfil] int
);

INSERT INTO [dbo].[Usuarios]
           ([codigo]
           ,[clave]
           ,[estado]
           ,[correo]
           ,[id_perfil])
     VALUES
           ('mtorres'
           ,'123456'
           ,1
           ,'mtorres882@gmail.com'
           ,1)
GO

INSERT INTO [dbo].[Libros]
           ([nombre]
           ,[genero]
           ,[cantidad]
           ,[precio_alquiler]
           ,[precio_venta])
     VALUES
           ('Dracula, Bram Stoker'
           ,'Terror'
           ,'10'
           ,10.5
           ,65.5)
GO

INSERT INTO [dbo].[Libros]
           ([nombre]
           ,[genero]
           ,[cantidad]
           ,[precio_alquiler]
           ,[precio_venta])
     VALUES
           ('Frankenstein, Mary Shelley'
           ,'Terror'
           ,'10'
           ,10.5
           ,65.5)
GO

INSERT INTO [dbo].[Libros]
           ([nombre]
           ,[genero]
           ,[cantidad]
           ,[precio_alquiler]
           ,[precio_venta])
     VALUES
           ('El Gato Negro, Edgar Allan Poe'
           ,'Terror'
           ,'10'
           ,10.5
           ,65.5)
GO

INSERT INTO [dbo].[Libros]
           ([nombre]
           ,[genero]
           ,[cantidad]
           ,[precio_alquiler]
           ,[precio_venta])
     VALUES
           ('La llamada de Cthulhu, H.P. Lovecraft'
           ,'Terror'
           ,'10'
           ,10.5
           ,65.5)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0001'
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0002' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0003' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0004' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0005' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0006' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0007' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0008' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0009' 
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0010' 
           ,1
           ,1
           ,1
           ,1)
GO

select a.*,b.* from Ejemplares a inner join Libros b on a.id_item = b.id_libro

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0011'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0012'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0013'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0014'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0015'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0016'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0017'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0018'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0019'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0020'  
           ,1
           ,1
           ,2
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0021'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0022'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0023'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0024'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0025'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0026'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0027'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0028'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0029'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0030'   
           ,1
           ,1
           ,3 
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0031'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0032'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0033'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0034'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0035'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0036'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0037'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0038'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0039'    
           ,1
           ,1
           ,4  
           ,1)
GO

INSERT INTO [dbo].[Ejemplares]
           ([codigo]
           ,[estado]
           ,[tipo_prod]
           ,[id_item]
           ,[id_estante])
     VALUES
           ('C0040'    
           ,1
           ,1
           ,4  
           ,1)
GO


INSERT INTO [dbo].[Estantes]
           ([codigo]
           ,[categoria])
     VALUES
           ('E001'
           ,'Terror')
GO

INSERT INTO [dbo].[Estantes]
           ([codigo]
           ,[categoria])
     VALUES
           ('E002'
           ,'Fantasia')
GO

INSERT INTO [dbo].[Estantes]
           ([codigo]
           ,[categoria])
     VALUES
           ('E003'
           ,'Ciencia Ficcion')
GO

INSERT INTO [dbo].[Perfil]
           ([nombre]
           ,[usuarios]
           ,[clientes]
           ,[ventas]
           ,[reportes]
           ,[lista_negra])
     VALUES
           ('admin'
           ,1
           ,1
           ,1
           ,1
           ,1)
GO

INSERT INTO [dbo].[Perfil]
           ([nombre]
           ,[usuarios]
           ,[clientes]
           ,[ventas]
           ,[reportes]
           ,[lista_negra])
     VALUES
           ('viewer'
           ,0
           ,0
           ,0
           ,1
           ,0)
GO

INSERT INTO [dbo].[Perfil]
           ([nombre]
           ,[usuarios]
           ,[clientes]
           ,[ventas]
           ,[reportes]
           ,[lista_negra])
     VALUES
           ('soporte'
           ,1
           ,1
           ,1
           ,0
           ,0)
GO

INSERT INTO [dbo].[Clientes]
           ([nombre]
           ,[apellido]
           ,[dni]
           ,[telefono]
           ,[correo]
           ,[estado]
           ,[clave]
           ,[direccion]
           ,[ubigeo])
     VALUES
           ('Benjamin'
           ,'Torres'
           ,'99999'
           ,'99999'
           ,'bentorres@gmail.com'
           ,1
           ,'123456'
           ,'Calle Amsterdam 169'
           ,'150101')
GO

INSERT INTO [dbo].[Clientes]
           ([nombre]
           ,[apellido]
           ,[dni]
           ,[telefono]
           ,[correo]
           ,[estado]
           ,[clave]
           ,[direccion]
           ,[ubigeo])
     VALUES
           ('Bruce'
           ,'Wayne'
           ,'99999'
           ,'99999'
           ,'bwayne@gmail.com'
           ,1
           ,'123456'
           ,'Wayne Mannor E 189 N 559'
           ,'150101')
GO