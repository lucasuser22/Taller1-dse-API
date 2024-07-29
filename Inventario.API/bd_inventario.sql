CREATE DATABASE Inventario;
GO

USE Inventario;
GO

CREATE TABLE Categoria (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50)
);
GO

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50) not null,
    Precio DECIMAL(5,2) not null,
	Stock INT not null,
	Id_Categoria INT FOREIGN KEY(Id_Categoria) REFERENCES Categoria(Id)
);
GO

