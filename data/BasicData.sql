--  This file contains the basic data for the application

-- Inserting roles and users
INSERT INTO finanzas.dbo.Rol
    (nombreRol)
VALUES
    (N'Administrador'),
    (N'Secretaria'),
    (N'Tesorero'),
    (N'Todos');

INSERT INTO finanzas.dbo.Usuario
    (nombreUsuario,pass,Rolid,activo)
VALUES
    (N'admin', N'IJfGn71UwZDNh8XrPR58qg==', 1, 1),
    (N'secretaria', N'IJfGn71UwZDNh8XrPR58qg==', 3, 1),
    (N'tesorero', N'IJfGn71UwZDNh8XrPR58qg==', 2, 1),
    (N'todos', N'IJfGn71UwZDNh8XrPR58qg==', 4, 1);

-- Inserting categories, concepts, types, units and missions
INSERT INTO finanzas.dbo.CategoriaPersona
    (categoria)
VALUES
    (N'Miembro'),
    (N'Invitado');

INSERT INTO finanzas.dbo.ConceptoGasto
    (concepto)
VALUES
    (N'Merienda'),
    (N'Material educativo'),
    (N'Pago de salario');

INSERT INTO finanzas.dbo.SubconceptoGasto
    (subconcepto,ConceptoGastoid)
VALUES
    (N'Libros', 2),
    (N'Lapices', 2);

INSERT INTO finanzas.dbo.ConceptoIngreso
    (concepto,calcularPorciento)
VALUES
    (N'Diezmos', 0),
    (N'Ofrendas', 0),
    (N'Donaciones', 0);

INSERT INTO finanzas.dbo.TipoAyuda
    (tipo,descripcion)
VALUES
    (N'Misericordia', N'Ayuda del ministerio de misericordia');

INSERT INTO finanzas.dbo.TipoMoneda
    (siglas,moneda)
VALUES
    (N'MN', N'Moneda nacional');

INSERT INTO finanzas.dbo.UnidadMedida
    (siglas,unidad)
VALUES
    (N'Kg', N'Kilogramo'),
    (N'm2', N'Metros cuadrados'),
    (N'm', N'Metros'),
    (N'cm', N'Centímetros');

-- Inserting people
INSERT INTO finanzas.dbo.Persona
    (ci,nombre,apellido1,apellido2,fechaNacimiento,miembro,fechaBautismo,fechaConversion,CategoriaPersonaid,Misionesid,activo)
VALUES
    (N'85121222245', N'Pedro', N'Perez', N'Acosta', '1993-09-01 00:00:00.0', 1, '2018-09-07 00:00:00.0', '2017-09-07 00:00:00.0', 1, NULL, 1),
    (N'85121222259', N'Juana', N'Garcia', N'Perez', '1993-09-03 00:00:00.0', 1, '2018-09-07 00:00:00.0', '2017-09-07 00:00:00.0', 1, NULL, 1),
    (N'85121222249', N'Pedro', N'Garcia', N'Acosta', '1993-09-03 00:00:00.0', 0, NULL, '2017-09-07 00:00:00.0', 1, NULL, 1);

INSERT INTO finanzas.dbo.Misiones
    (lugar,Personaid)
VALUES
    (N'Matanzas', 1);

UPDATE finanzas.dbo.Persona
SET Misionesid = 1;

-- Inserting accounts

INSERT INTO finanzas.dbo.Cuentas
    (nombre,importe,TipoMonedaid,descriptcion,activo)
VALUES
    (N'Misericordia', 8000.0000, 1, N'Cuenta para ayudas de misericordia', 1),
    (N'Ingresos', 500.0000, 1, N'Ingresos', 1),
    (N'Gastos generales', 9700.0000, 1, N'Gastos generales', 1),
    (N'Escuela dominical', 5000.0000, 1, N'Gastos de escuela dominical', 1);

INSERT INTO finanzas.dbo.GastoFinanzas
    (Cuentasid,ConceptoGastoid,SubconceptoGastoid,fecha,importe,descripcion,Usuarioid)
VALUES
    (3, 2, 1, '2023-09-03 00:00:00.0', 300.0000, N'Compra de libros nuevos para niños', 1),
    (1, 1, NULL, '2023-09-03 00:00:00.0', 2000.0000, N'Id de compra: [1] Compra de Productos del proyecto un grano de arena', 1);

INSERT INTO finanzas.dbo.IngresoFinanzas
    (Cuentasid,ConceptoIngresoid,fecha,importe,descripcion,Usuarioid,Personaid)
VALUES
    (2, 2, '2023-09-04 00:00:00.0', 500.0000, N'Ofrenda', 1, NULL);

-- Inserting products and transactions

INSERT INTO finanzas.dbo.Producto
    (nombre,descripcion,UnidadMedidaid)
VALUES
    (N'Cemento', N'Cemento a granel', 1),
    (N'Arena', N'Arena gruesa', 2);

INSERT INTO finanzas.dbo.Almacen
    (cantidad,precio,Productoid,TipoMonedaid)
VALUES
    (9, 200.0000, 1, 1);

INSERT INTO finanzas.dbo.CompraProducto
    (Cuentasid,Productoid,fecha,cantidad,importe,Usuarioid)
VALUES
    (1, 1, '2023-09-03 00:00:00.0', 10, 2000.0000, 1);

INSERT INTO finanzas.dbo.SalidaAlmacen
    (fecha,cantidad,Almacenid,TipoAyudaid,Usuarioid)
VALUES
    ('2023-09-03 00:00:00.0', 1, 1, 1, 1);
