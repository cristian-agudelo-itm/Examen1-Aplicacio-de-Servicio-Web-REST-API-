-- CREATE DATABASE ITM_Ventas;

USE ITM_Ventas;
GO

-- Tabla Agencia
CREATE TABLE Agencia (
    id_agencia INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

-- Tabla Cliente
CREATE TABLE Cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    correo VARCHAR(100) UNIQUE NOT NULL,
    telefono VARCHAR(20) NOT NULL
);

-- Tabla TipoComputador
CREATE TABLE TipoComputador (
    id_tipo INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NOT NULL
);

-- Tabla Computador
CREATE TABLE Computador (
    id_computador INT IDENTITY(1,1) PRIMARY KEY,
    id_tipo INT NOT NULL,
    procesador_marca VARCHAR(50) NOT NULL,
    procesador_numero INT NOT NULL,
    disco_duro_tamano INT NOT NULL, -- en GB
    memoria_tamano INT NOT NULL, -- en GB
    componentes TEXT,
    FOREIGN KEY (id_tipo) REFERENCES TipoComputador(id_tipo)
);

-- Tabla Venta
CREATE TABLE Venta (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT NOT NULL,
    id_computador INT NOT NULL,
    fecha DATETIME DEFAULT GETDATE(),
    id_agencia INT NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_computador) REFERENCES Computador(id_computador),
    FOREIGN KEY (id_agencia) REFERENCES Agencia(id_agencia)
);