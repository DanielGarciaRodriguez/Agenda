use Agenda;
GO

create table Contacto (
	[Id] [int] IDENTITY(1,1) NOT NULL Primary Key,
	[Nombre] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Telefono] [varchar](9) NOT NULL,
	[Observaciones] [nvarchar](500) NULL
);