-- Crear la base de datos
CREATE DATABASE IF NOT EXISTS boletos_aereos;
USE boletos_aereos;

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(255) NOT NULL,
    NombreCompleto VARCHAR(150) NOT NULL,
    Email VARCHAR(100),
    Rol VARCHAR(20) NOT NULL,
    FechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    Activo BOOLEAN DEFAULT TRUE
);

-- Tabla de Aerolíneas
CREATE TABLE Aerolineas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Codigo VARCHAR(10) NOT NULL UNIQUE,
    Pais VARCHAR(50),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Activo BOOLEAN DEFAULT TRUE
);

-- Tabla de Aviones
CREATE TABLE Aviones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    AerolineaId INT NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    NumeroSerie VARCHAR(50) NOT NULL UNIQUE,
    CapacidadPasajeros INT NOT NULL,
    Activo BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (AerolineaId) REFERENCES Aerolineas(Id)
);

-- Tabla de Rutas
CREATE TABLE Rutas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CiudadOrigen VARCHAR(100) NOT NULL,
    CiudadDestino VARCHAR(100) NOT NULL,
    Distancia DECIMAL(10,2),
    DuracionEstimada TIME,
    Activo BOOLEAN DEFAULT TRUE
);

-- Tabla de Vuelos
CREATE TABLE Vuelos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    AerolineaId INT NOT NULL,
    RutaId INT NOT NULL,
    AvionId INT NOT NULL,
    NumeroVuelo VARCHAR(20) NOT NULL UNIQUE,
    FechaSalida DATETIME NOT NULL,
    FechaLlegada DATETIME NOT NULL,
    TarifaBase DECIMAL(10,2) NOT NULL,
    AsientosDisponibles INT NOT NULL,
    Estado VARCHAR(20) DEFAULT 'Programado',
    FOREIGN KEY (AerolineaId) REFERENCES Aerolineas(Id),
    FOREIGN KEY (RutaId) REFERENCES Rutas(Id),
    FOREIGN KEY (AvionId) REFERENCES Aviones(Id)
);

-- Tabla de Tripulación
CREATE TABLE Tripulacion (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Identificacion VARCHAR(50) NOT NULL UNIQUE,
    Cargo VARCHAR(50) NOT NULL,
    AerolineaId INT NOT NULL,
    FechaContratacion DATE,
    Activo BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (AerolineaId) REFERENCES Aerolineas(Id)
);

-- Tabla de Asignación de Tripulación a Vuelos
CREATE TABLE TripulacionVuelo (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    VueloId INT NOT NULL,
    TripulacionId INT NOT NULL,
    FOREIGN KEY (VueloId) REFERENCES Vuelos(Id),
    FOREIGN KEY (TripulacionId) REFERENCES Tripulacion(Id)
);

-- Tabla de Pasajeros
CREATE TABLE Pasajeros (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    NumeroPasaporte VARCHAR(50) NOT NULL UNIQUE,
    Nacionalidad VARCHAR(50),
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Tabla de Reservaciones
CREATE TABLE Reservaciones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PasajeroId INT NOT NULL,
    VueloId INT NOT NULL,
    CodigoReservacion VARCHAR(20) NOT NULL UNIQUE,
    NumeroAsiento VARCHAR(10),
    PreferenciaAsiento VARCHAR(50),
    EquipajeMano BOOLEAN DEFAULT FALSE,
    EquipajeBodega BOOLEAN DEFAULT FALSE,
    FechaReservacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    Estado VARCHAR(20) DEFAULT 'Pendiente',
    FOREIGN KEY (PasajeroId) REFERENCES Pasajeros(Id),
    FOREIGN KEY (VueloId) REFERENCES Vuelos(Id)
);

-- Tabla de Tarifas (cargos adicionales)
CREATE TABLE Tarifas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ReservacionId INT NOT NULL,
    TarifaBase DECIMAL(10,2) NOT NULL,
    CargoEquipajeMano DECIMAL(10,2) DEFAULT 0.00,
    CargoEquipajeBodega DECIMAL(10,2) DEFAULT 0.00,
    PorcentajeEquipajeMano DECIMAL(5,2) DEFAULT 10.00,
    PorcentajeEquipajeBodega DECIMAL(5,2) DEFAULT 20.00,
    Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ReservacionId) REFERENCES Reservaciones(Id)
);

-- Tabla de Pagos
CREATE TABLE Pagos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ReservacionId INT NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    MetodoPago VARCHAR(50) NOT NULL,
    NumeroTransaccion VARCHAR(100),
    FechaPago DATETIME DEFAULT CURRENT_TIMESTAMP,
    Estado VARCHAR(20) DEFAULT 'Completado',
    FOREIGN KEY (ReservacionId) REFERENCES Reservaciones(Id)
);

-- Tabla de Cancelaciones
CREATE TABLE Cancelaciones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ReservacionId INT NOT NULL,
    MotivoCancelacion TEXT,
    MontoReembolso DECIMAL(10,2),
    FechaCancelacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    ProcesadoPor INT,
    FOREIGN KEY (ReservacionId) REFERENCES Reservaciones(Id),
    FOREIGN KEY (ProcesadoPor) REFERENCES Usuarios(Id)
);

-- Insertar datos de ejemplo

-- Usuario administrador por defecto
INSERT INTO Usuarios (NombreUsuario, Contrasena, NombreCompleto, Email, Rol) 
VALUES ('admin', 'admin123', 'Administrador Sistema', 'admin@boletos.com', 'Administrador');

-- Aerolíneas de ejemplo
INSERT INTO Aerolineas (Nombre, Codigo, Pais, Telefono, Email) VALUES
('AeroSalvador', 'ASV', 'El Salvador', '2222-3333', 'info@aerosalvador.com'),
('Central American Airlines', 'CAA', 'Guatemala', '2555-4444', 'info@caa.com'),
('Pacific Air', 'PAC', 'Costa Rica', '2777-5555', 'contacto@pacificair.com');

-- Rutas de ejemplo
INSERT INTO Rutas (CiudadOrigen, CiudadDestino, Distancia, DuracionEstimada) VALUES
('San Salvador', 'Ciudad de Guatemala', 250.00, '01:00:00'),
('San Salvador', 'San José', 680.00, '02:00:00'),
('San Salvador', 'Managua', 350.00, '01:15:00'),
('Ciudad de Guatemala', 'San José', 920.00, '02:30:00');

-- Verificar las tablas creadas
SHOW TABLES;
USE boletos_aereos;

-- Ver usuarios
SELECT * FROM Usuarios;

-- Ver aerolíneas
SELECT * FROM Aerolineas;

-- Ver rutas
SELECT * FROM Rutas;
