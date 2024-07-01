# SEGUNDO PARCIAL LABO II | CRUD - Gaseosas

## Sobre mi

Hola me llamo César Pumacayo y este es mi primer proyecto CRUD desarrollado con todo lo abarcado de la UTN FRA en el lenguaje C#.

## Resumen
Una breve descripcion de mi proyecto es que cumple todas las funciones de un CRUD (Create, Read, Update, Delete). La aplicación incluye un inicio de sesión, donde los usuarios pueden autenticarse, y una interfaz gráfica intuitiva para realizar las distintas operaciones CRUD.

## Objetivo

El proyecto inicia en un FrmLogin donde tendrás que poner uno de los siguientes datos del [Usuario](https://drive.google.com/file/d/1dzJEBSH9uR34Oiy_KvGOkDJFkfiZipUm/view?usp=sharing:) (correo y clave):

Ejemplo:
~~~ 
"correo":cgorgen@vendedor.com 
"clave":"123abc45"
~~~ 


Una vez logueado, se abre el formulario principal (FrmCRUD) que permite realizar las siguientes operaciones:

- CRUD:

    - Cargar: Se abrirá una nueva ventana para agregar nuevas gaseosas a la lista.

    - Modificar: Se abrirá una nueva ventana para editar los detalles de una gaseosa existente.
    - Eliminar:Se abrirá una nueva ventana para borrar una gaseosa de la lista.
- Ordenar:

    - Ascendente: Ordenar las gaseosas por precio o cantidad en orden ascendente.
    
    - Descendente: Ordenar las gaseosas por precio o cantidad en orden descendente.
*Clave resaltar que solo podras agregar 5 gaseosas en la lista*

- Registros de Login: Visualizar un historial de los inicios de sesión de los usuarios con la fecha (año, mes, día, hora, segundos) y el nombre y apellido del usuario.

- Guardar: Guardar la lista actual de gaseosas en un archivo.

- Abrir: Abrir un archivo existente con una lista de gaseosas.

- Confirmacion de cierre: Aparecerá un cuadro de diálogo de confirmación que te dará la oportunidad de cancelar la acción si cambias de opinión sobre cerrar el CRUD.


#### Segundo parcial: 
En esta segunda parte se agrego:
- Utilización de distintos perfiles.
- Persistir información sobre una base de datos.
- Utilización de Generics.
- Utilización de eventos propios.
- Manejo de excepciones (propias y de sistema).
- Realización de pruebas unitarias.
- Manejo del Task.
- Aplicacion de interfaces (Genericas y no Genericas)
Ahora el FrmLogin mostrara el CRUD segun la jerarquia de los usuarios (vendedor, supervisor y admin):

- el perfil de administrador pueda realizar el CRUD (Create, Read, Update y Delete) completo.
- el perfil de supervisor pueda realizar solamente ‘CRU’ (Create, Read y Update)
- el perfil de vendedor solo pueda realizar el ‘R’ (Read).

La lista de Gaseosa ahora se agregara en una sola tabla (Tabla_Gaseosa) de Base de datos (gaseosas_bd), en donde cada gaseosa agregada se guardará automaticamente en registro.xml ademas de mostrar los registros al hacer click al boton "Mostrar Registros BD"

### Instrucciones para Uso
Antes de iniciar las operaciones de agregar, modificar o eliminar, se debe hacer clic en el botón "Mostrar Registros BD" para asegurarse de que la base de datos esté abierta y actualizada.

--- 
### Diagrama de Entidades

![DiagramaEntidades](https://github.com/CesarPumacayo/Pumacayo.Cesar.PrimerParcial/assets/98622455/e94d4da1-1c41-4b72-8b87-85696defe530)

### Diagrama de Interfaz

![DiagramaInterfaz](https://github.com/CesarPumacayo/Pumacayo.Cesar.PrimerParcial/assets/98622455/852f0486-6c4e-4cc3-97fe-0bc1fe9d91b2)

### Script (Gaseosas.sql)

~~~ 
USE [master]
GO
/****** Object:  Database [gaseosas_bd]    Script Date: 1/7/2024 17:09:26 ******/
CREATE DATABASE [gaseosas_bd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gaseosas_bd', FILENAME = N'C:\SQLData\gaseosas_bd.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gaseosas_bd_log', FILENAME = N'C:\SQLData\gaseosas_bd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [gaseosas_bd] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gaseosas_bd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gaseosas_bd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gaseosas_bd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gaseosas_bd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gaseosas_bd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gaseosas_bd] SET ARITHABORT OFF 
GO
ALTER DATABASE [gaseosas_bd] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [gaseosas_bd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gaseosas_bd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gaseosas_bd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gaseosas_bd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gaseosas_bd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gaseosas_bd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gaseosas_bd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gaseosas_bd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gaseosas_bd] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gaseosas_bd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gaseosas_bd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gaseosas_bd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gaseosas_bd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gaseosas_bd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gaseosas_bd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gaseosas_bd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gaseosas_bd] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [gaseosas_bd] SET  MULTI_USER 
GO
ALTER DATABASE [gaseosas_bd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gaseosas_bd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gaseosas_bd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gaseosas_bd] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gaseosas_bd] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [gaseosas_bd] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [gaseosas_bd] SET QUERY_STORE = ON
GO
ALTER DATABASE [gaseosas_bd] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [gaseosas_bd]
GO
/****** Object:  Table [dbo].[Tabla_Gaseosa]    Script Date: 1/7/2024 17:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tabla_Gaseosa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo_botella] [nvarchar](50) NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[cantidad] [int] NOT NULL,
	[exceso_azucar] [bit] NULL,
	[litros] [float] NULL,
	[tipo_sabor] [nvarchar](50) NULL,
	[exceso_calorias] [bit] NULL,
	[retornable] [bit] NULL,
	[codigo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Tabla_Gaseosa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tabla_Gaseosa] ON 

INSERT [dbo].[Tabla_Gaseosa] ([id], [tipo_botella], [precio], [cantidad], [exceso_azucar], [litros], [tipo_sabor], [exceso_calorias], [retornable], [codigo]) VALUES (70, N'Plastico', CAST(4800.00 AS Decimal(18, 2)), 1, 1, 2.5, NULL, NULL, NULL, NULL)
INSERT [dbo].[Tabla_Gaseosa] ([id], [tipo_botella], [precio], [cantidad], [exceso_azucar], [litros], [tipo_sabor], [exceso_calorias], [retornable], [codigo]) VALUES (71, N'Lata', CAST(1500.00 AS Decimal(18, 2)), 1, NULL, NULL, N'Cola', 0, NULL, NULL)
INSERT [dbo].[Tabla_Gaseosa] ([id], [tipo_botella], [precio], [cantidad], [exceso_azucar], [litros], [tipo_sabor], [exceso_calorias], [retornable], [codigo]) VALUES (72, N'Vidrio', CAST(5800.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, 0, CAST(9119.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tabla_Gaseosa] OFF
GO
USE [master]
GO
ALTER DATABASE [gaseosas_bd] SET  READ_WRITE 
GO
~~~ 