-- CREATE DATABASE ITM_Ventas;

USE ITM_Ventas;
GO

-- Insertar datos en Agencia
INSERT INTO Agencia (nombre) VALUES 
('ITM Medellín');

-- Insertar datos en Cliente
INSERT INTO Cliente (nombre, correo, telefono) VALUES
('Juan Pérez', 'juan.perez@example.com', '3001234567'),
('María López', 'maria.lopez@example.com', '3109876543'),
('Carlos Gómez', 'carlos.gomez@example.com', '3204567890'),
('Ana Ramírez', 'ana.ramirez@example.com', '3045678901');

-- Insertar datos en TipoComputador
INSERT INTO TipoComputador (descripcion) VALUES
('Escritorio'),
('Portátil'),
('Gamer'),
('Servidor');

-- Insertar datos en Computador
INSERT INTO Computador (id_tipo, procesador_marca, procesador_numero, disco_duro_tamano, memoria_tamano, componentes) VALUES
(1, 'Intel Core i5', 4, 512, 16, 'Mouse, Teclado, Monitor LED 24"'),
(2, 'AMD Ryzen 7', 8, 1024, 32, 'Mouse, Teclado retroiluminado'),
(3, 'Intel Core i9', 16, 2048, 64, 'Tarjeta gráfica RTX 4090, Mouse gaming, Teclado mecánico'),
(4, 'AMD EPYC', 32, 4096, 128, 'RAID de discos, Fuente redundante');

-- Insertar datos en Venta
INSERT INTO Venta (id_cliente, id_computador, id_agencia) VALUES
(1, 2, 1), -- Juan Pérez compró un portátil
(2, 3, 1), -- María López compró un computador gamer
(3, 1, 1), -- Carlos Gómez compró un equipo de escritorio
(4, 4, 1); -- Ana Ramírez compró un servidor