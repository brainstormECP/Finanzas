
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/03/2023 11:48:11
-- Generated from EDMX file: C:\projects\personal\Finanzas\Finanzas\Models\FinanzasModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [finanzas];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FKAlmacen650471]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Almacen] DROP CONSTRAINT [FK_FKAlmacen650471];
GO
IF OBJECT_ID(N'[dbo].[FK_FKAlmacen795546]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Almacen] DROP CONSTRAINT [FK_FKAlmacen795546];
GO
IF OBJECT_ID(N'[dbo].[FK_FKCompraProd505569]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompraProducto] DROP CONSTRAINT [FK_FKCompraProd505569];
GO
IF OBJECT_ID(N'[dbo].[FK_FKCompraProd527192]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompraProducto] DROP CONSTRAINT [FK_FKCompraProd527192];
GO
IF OBJECT_ID(N'[dbo].[FK_FKCompraProd845775]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompraProducto] DROP CONSTRAINT [FK_FKCompraProd845775];
GO
IF OBJECT_ID(N'[dbo].[FK_FKCuentas36608]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuentas] DROP CONSTRAINT [FK_FKCuentas36608];
GO
IF OBJECT_ID(N'[dbo].[FK_FKEscuelaDom17470]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EscuelaDominical] DROP CONSTRAINT [FK_FKEscuelaDom17470];
GO
IF OBJECT_ID(N'[dbo].[FK_FKEscuelaDom783010]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EscuelaDominical] DROP CONSTRAINT [FK_FKEscuelaDom783010];
GO
IF OBJECT_ID(N'[dbo].[FK_FKGastoFinan245216]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoFinanzas] DROP CONSTRAINT [FK_FKGastoFinan245216];
GO
IF OBJECT_ID(N'[dbo].[FK_FKGastoFinan518235]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoFinanzas] DROP CONSTRAINT [FK_FKGastoFinan518235];
GO
IF OBJECT_ID(N'[dbo].[FK_FKGastoFinan854732]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoFinanzas] DROP CONSTRAINT [FK_FKGastoFinan854732];
GO
IF OBJECT_ID(N'[dbo].[FK_FKGastoFinan990835]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoFinanzas] DROP CONSTRAINT [FK_FKGastoFinan990835];
GO
IF OBJECT_ID(N'[dbo].[FK_FKIngresoFin123343]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngresoFinanzas] DROP CONSTRAINT [FK_FKIngresoFin123343];
GO
IF OBJECT_ID(N'[dbo].[FK_FKIngresoFin191449]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngresoFinanzas] DROP CONSTRAINT [FK_FKIngresoFin191449];
GO
IF OBJECT_ID(N'[dbo].[FK_FKIngresoFin249625]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngresoFinanzas] DROP CONSTRAINT [FK_FKIngresoFin249625];
GO
IF OBJECT_ID(N'[dbo].[FK_FKIngresoFin745088]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngresoFinanzas] DROP CONSTRAINT [FK_FKIngresoFin745088];
GO
IF OBJECT_ID(N'[dbo].[FK_FKMisiones810133]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Misiones] DROP CONSTRAINT [FK_FKMisiones810133];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPersona44495]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_FKPersona44495];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPersona52500]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persona] DROP CONSTRAINT [FK_FKPersona52500];
GO
IF OBJECT_ID(N'[dbo].[FK_FKProducto768955]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK_FKProducto768955];
GO
IF OBJECT_ID(N'[dbo].[FK_FKSalidaAlma282847]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalidaAlmacen] DROP CONSTRAINT [FK_FKSalidaAlma282847];
GO
IF OBJECT_ID(N'[dbo].[FK_FKSalidaAlma377447]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalidaAlmacen] DROP CONSTRAINT [FK_FKSalidaAlma377447];
GO
IF OBJECT_ID(N'[dbo].[FK_FKSalidaAlma910466]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalidaAlmacen] DROP CONSTRAINT [FK_FKSalidaAlma910466];
GO
IF OBJECT_ID(N'[dbo].[FK_FKSubconcept379535]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubconceptoGasto] DROP CONSTRAINT [FK_FKSubconcept379535];
GO
IF OBJECT_ID(N'[dbo].[FK_FKUsuario38509]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_FKUsuario38509];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Almacen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Almacen];
GO
IF OBJECT_ID(N'[dbo].[CategoriaPersona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoriaPersona];
GO
IF OBJECT_ID(N'[dbo].[CompraProducto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompraProducto];
GO
IF OBJECT_ID(N'[dbo].[ConceptoGasto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConceptoGasto];
GO
IF OBJECT_ID(N'[dbo].[ConceptoIngreso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConceptoIngreso];
GO
IF OBJECT_ID(N'[dbo].[Cuentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuentas];
GO
IF OBJECT_ID(N'[dbo].[EscuelaDominical]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EscuelaDominical];
GO
IF OBJECT_ID(N'[dbo].[GastoFinanzas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GastoFinanzas];
GO
IF OBJECT_ID(N'[dbo].[IngresoFinanzas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IngresoFinanzas];
GO
IF OBJECT_ID(N'[dbo].[Misiones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Misiones];
GO
IF OBJECT_ID(N'[dbo].[Persona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persona];
GO
IF OBJECT_ID(N'[dbo].[Producto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto];
GO
IF OBJECT_ID(N'[dbo].[Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rol];
GO
IF OBJECT_ID(N'[dbo].[SalidaAlmacen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalidaAlmacen];
GO
IF OBJECT_ID(N'[dbo].[SubconceptoGasto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubconceptoGasto];
GO
IF OBJECT_ID(N'[dbo].[TemaPredicacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemaPredicacion];
GO
IF OBJECT_ID(N'[dbo].[TipoAyuda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoAyuda];
GO
IF OBJECT_ID(N'[dbo].[TipoMoneda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoMoneda];
GO
IF OBJECT_ID(N'[dbo].[UnidadMedida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UnidadMedida];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Almacen'
CREATE TABLE [dbo].[Almacen] (
    [id] int IDENTITY(1,1) NOT NULL,
    [cantidad] int  NOT NULL,
    [precio] decimal(19,4)  NOT NULL,
    [Productoid] int  NOT NULL,
    [TipoMonedaid] int  NOT NULL
);
GO

-- Creating table 'CategoriaPersona'
CREATE TABLE [dbo].[CategoriaPersona] (
    [id] int IDENTITY(1,1) NOT NULL,
    [categoria] varchar(255)  NOT NULL
);
GO

-- Creating table 'CompraProducto'
CREATE TABLE [dbo].[CompraProducto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Cuentasid] int  NOT NULL,
    [Productoid] int  NOT NULL,
    [fecha] datetime  NOT NULL,
    [cantidad] int  NOT NULL,
    [importe] decimal(19,4)  NOT NULL,
    [Usuarioid] int  NOT NULL
);
GO

-- Creating table 'ConceptoGasto'
CREATE TABLE [dbo].[ConceptoGasto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [concepto] varchar(255)  NOT NULL
);
GO

-- Creating table 'ConceptoIngreso'
CREATE TABLE [dbo].[ConceptoIngreso] (
    [id] int IDENTITY(1,1) NOT NULL,
    [concepto] varchar(255)  NOT NULL,
    [calcularPorciento] bit  NOT NULL
);
GO

-- Creating table 'Cuentas'
CREATE TABLE [dbo].[Cuentas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(100)  NOT NULL,
    [importe] decimal(19,4)  NOT NULL,
    [TipoMonedaid] int  NOT NULL,
    [descriptcion] varchar(255)  NULL,
    [activo] bit  NOT NULL
);
GO

-- Creating table 'EscuelaDominical'
CREATE TABLE [dbo].[EscuelaDominical] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [asistencia] int  NOT NULL,
    [TemaPredicacionid] int  NOT NULL,
    [Usuarioid] int  NOT NULL
);
GO

-- Creating table 'GastoFinanzas'
CREATE TABLE [dbo].[GastoFinanzas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Cuentasid] int  NOT NULL,
    [ConceptoGastoid] int  NOT NULL,
    [SubconceptoGastoid] int  NULL,
    [fecha] datetime  NOT NULL,
    [importe] decimal(19,4)  NOT NULL,
    [descripcion] varchar(255)  NULL,
    [Usuarioid] int  NOT NULL
);
GO

-- Creating table 'IngresoFinanzas'
CREATE TABLE [dbo].[IngresoFinanzas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Cuentasid] int  NOT NULL,
    [ConceptoIngresoid] int  NOT NULL,
    [fecha] datetime  NOT NULL,
    [importe] decimal(19,4)  NOT NULL,
    [descripcion] varchar(255)  NULL,
    [Usuarioid] int  NOT NULL,
    [Personaid] int  NULL
);
GO

-- Creating table 'Misiones'
CREATE TABLE [dbo].[Misiones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [lugar] varchar(255)  NOT NULL,
    [Personaid] int  NOT NULL
);
GO

-- Creating table 'Persona'
CREATE TABLE [dbo].[Persona] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ci] varchar(11)  NOT NULL,
    [nombre] varchar(100)  NOT NULL,
    [apellido1] varchar(100)  NOT NULL,
    [apellido2] varchar(100)  NULL,
    [fechaNacimiento] datetime  NOT NULL,
    [miembro] bit  NOT NULL,
    [fechaBautismo] datetime  NULL,
    [fechaConversion] datetime  NULL,
    [CategoriaPersonaid] int  NOT NULL,
    [Misionesid] int  NULL,
    [activo] bit  NOT NULL
);
GO

-- Creating table 'Producto'
CREATE TABLE [dbo].[Producto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(255)  NOT NULL,
    [descripcion] varchar(255)  NULL,
    [UnidadMedidaid] int  NOT NULL
);
GO

-- Creating table 'Rol'
CREATE TABLE [dbo].[Rol] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreRol] varchar(50)  NOT NULL
);
GO

-- Creating table 'SalidaAlmacen'
CREATE TABLE [dbo].[SalidaAlmacen] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [cantidad] int  NOT NULL,
    [Almacenid] int  NOT NULL,
    [TipoAyudaid] int  NOT NULL,
    [Usuarioid] int  NOT NULL
);
GO

-- Creating table 'SubconceptoGasto'
CREATE TABLE [dbo].[SubconceptoGasto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [subconcepto] varchar(255)  NOT NULL,
    [ConceptoGastoid] int  NOT NULL
);
GO

-- Creating table 'TemaPredicacion'
CREATE TABLE [dbo].[TemaPredicacion] (
    [id] int IDENTITY(1,1) NOT NULL,
    [tema] varchar(255)  NOT NULL
);
GO

-- Creating table 'TipoAyuda'
CREATE TABLE [dbo].[TipoAyuda] (
    [id] int IDENTITY(1,1) NOT NULL,
    [tipo] varchar(100)  NOT NULL,
    [descripcion] varchar(255)  NULL
);
GO

-- Creating table 'TipoMoneda'
CREATE TABLE [dbo].[TipoMoneda] (
    [id] int IDENTITY(1,1) NOT NULL,
    [siglas] varchar(5)  NOT NULL,
    [moneda] varchar(255)  NOT NULL
);
GO

-- Creating table 'UnidadMedida'
CREATE TABLE [dbo].[UnidadMedida] (
    [id] int IDENTITY(1,1) NOT NULL,
    [siglas] varchar(10)  NOT NULL,
    [unidad] varchar(50)  NOT NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombreUsuario] varchar(100)  NOT NULL,
    [pass] varchar(50)  NOT NULL,
    [Rolid] int  NOT NULL,
    [activo] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Almacen'
ALTER TABLE [dbo].[Almacen]
ADD CONSTRAINT [PK_Almacen]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CategoriaPersona'
ALTER TABLE [dbo].[CategoriaPersona]
ADD CONSTRAINT [PK_CategoriaPersona]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CompraProducto'
ALTER TABLE [dbo].[CompraProducto]
ADD CONSTRAINT [PK_CompraProducto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ConceptoGasto'
ALTER TABLE [dbo].[ConceptoGasto]
ADD CONSTRAINT [PK_ConceptoGasto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ConceptoIngreso'
ALTER TABLE [dbo].[ConceptoIngreso]
ADD CONSTRAINT [PK_ConceptoIngreso]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cuentas'
ALTER TABLE [dbo].[Cuentas]
ADD CONSTRAINT [PK_Cuentas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'EscuelaDominical'
ALTER TABLE [dbo].[EscuelaDominical]
ADD CONSTRAINT [PK_EscuelaDominical]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'GastoFinanzas'
ALTER TABLE [dbo].[GastoFinanzas]
ADD CONSTRAINT [PK_GastoFinanzas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'IngresoFinanzas'
ALTER TABLE [dbo].[IngresoFinanzas]
ADD CONSTRAINT [PK_IngresoFinanzas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Misiones'
ALTER TABLE [dbo].[Misiones]
ADD CONSTRAINT [PK_Misiones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Persona'
ALTER TABLE [dbo].[Persona]
ADD CONSTRAINT [PK_Persona]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Producto'
ALTER TABLE [dbo].[Producto]
ADD CONSTRAINT [PK_Producto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rol'
ALTER TABLE [dbo].[Rol]
ADD CONSTRAINT [PK_Rol]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SalidaAlmacen'
ALTER TABLE [dbo].[SalidaAlmacen]
ADD CONSTRAINT [PK_SalidaAlmacen]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SubconceptoGasto'
ALTER TABLE [dbo].[SubconceptoGasto]
ADD CONSTRAINT [PK_SubconceptoGasto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TemaPredicacion'
ALTER TABLE [dbo].[TemaPredicacion]
ADD CONSTRAINT [PK_TemaPredicacion]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TipoAyuda'
ALTER TABLE [dbo].[TipoAyuda]
ADD CONSTRAINT [PK_TipoAyuda]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TipoMoneda'
ALTER TABLE [dbo].[TipoMoneda]
ADD CONSTRAINT [PK_TipoMoneda]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'UnidadMedida'
ALTER TABLE [dbo].[UnidadMedida]
ADD CONSTRAINT [PK_UnidadMedida]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TipoMonedaid] in table 'Almacen'
ALTER TABLE [dbo].[Almacen]
ADD CONSTRAINT [FK_FKAlmacen650471]
    FOREIGN KEY ([TipoMonedaid])
    REFERENCES [dbo].[TipoMoneda]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAlmacen650471'
CREATE INDEX [IX_FK_FKAlmacen650471]
ON [dbo].[Almacen]
    ([TipoMonedaid]);
GO

-- Creating foreign key on [Productoid] in table 'Almacen'
ALTER TABLE [dbo].[Almacen]
ADD CONSTRAINT [FK_FKAlmacen795546]
    FOREIGN KEY ([Productoid])
    REFERENCES [dbo].[Producto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAlmacen795546'
CREATE INDEX [IX_FK_FKAlmacen795546]
ON [dbo].[Almacen]
    ([Productoid]);
GO

-- Creating foreign key on [Almacenid] in table 'SalidaAlmacen'
ALTER TABLE [dbo].[SalidaAlmacen]
ADD CONSTRAINT [FK_FKSalidaAlma377447]
    FOREIGN KEY ([Almacenid])
    REFERENCES [dbo].[Almacen]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKSalidaAlma377447'
CREATE INDEX [IX_FK_FKSalidaAlma377447]
ON [dbo].[SalidaAlmacen]
    ([Almacenid]);
GO

-- Creating foreign key on [CategoriaPersonaid] in table 'Persona'
ALTER TABLE [dbo].[Persona]
ADD CONSTRAINT [FK_FKPersona44495]
    FOREIGN KEY ([CategoriaPersonaid])
    REFERENCES [dbo].[CategoriaPersona]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPersona44495'
CREATE INDEX [IX_FK_FKPersona44495]
ON [dbo].[Persona]
    ([CategoriaPersonaid]);
GO

-- Creating foreign key on [Productoid] in table 'CompraProducto'
ALTER TABLE [dbo].[CompraProducto]
ADD CONSTRAINT [FK_FKCompraProd505569]
    FOREIGN KEY ([Productoid])
    REFERENCES [dbo].[Producto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCompraProd505569'
CREATE INDEX [IX_FK_FKCompraProd505569]
ON [dbo].[CompraProducto]
    ([Productoid]);
GO

-- Creating foreign key on [Cuentasid] in table 'CompraProducto'
ALTER TABLE [dbo].[CompraProducto]
ADD CONSTRAINT [FK_FKCompraProd527192]
    FOREIGN KEY ([Cuentasid])
    REFERENCES [dbo].[Cuentas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCompraProd527192'
CREATE INDEX [IX_FK_FKCompraProd527192]
ON [dbo].[CompraProducto]
    ([Cuentasid]);
GO

-- Creating foreign key on [Usuarioid] in table 'CompraProducto'
ALTER TABLE [dbo].[CompraProducto]
ADD CONSTRAINT [FK_FKCompraProd845775]
    FOREIGN KEY ([Usuarioid])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCompraProd845775'
CREATE INDEX [IX_FK_FKCompraProd845775]
ON [dbo].[CompraProducto]
    ([Usuarioid]);
GO

-- Creating foreign key on [ConceptoGastoid] in table 'GastoFinanzas'
ALTER TABLE [dbo].[GastoFinanzas]
ADD CONSTRAINT [FK_FKGastoFinan245216]
    FOREIGN KEY ([ConceptoGastoid])
    REFERENCES [dbo].[ConceptoGasto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKGastoFinan245216'
CREATE INDEX [IX_FK_FKGastoFinan245216]
ON [dbo].[GastoFinanzas]
    ([ConceptoGastoid]);
GO

-- Creating foreign key on [ConceptoGastoid] in table 'SubconceptoGasto'
ALTER TABLE [dbo].[SubconceptoGasto]
ADD CONSTRAINT [FK_FKSubconcept379535]
    FOREIGN KEY ([ConceptoGastoid])
    REFERENCES [dbo].[ConceptoGasto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKSubconcept379535'
CREATE INDEX [IX_FK_FKSubconcept379535]
ON [dbo].[SubconceptoGasto]
    ([ConceptoGastoid]);
GO

-- Creating foreign key on [ConceptoIngresoid] in table 'IngresoFinanzas'
ALTER TABLE [dbo].[IngresoFinanzas]
ADD CONSTRAINT [FK_FKIngresoFin191449]
    FOREIGN KEY ([ConceptoIngresoid])
    REFERENCES [dbo].[ConceptoIngreso]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKIngresoFin191449'
CREATE INDEX [IX_FK_FKIngresoFin191449]
ON [dbo].[IngresoFinanzas]
    ([ConceptoIngresoid]);
GO

-- Creating foreign key on [TipoMonedaid] in table 'Cuentas'
ALTER TABLE [dbo].[Cuentas]
ADD CONSTRAINT [FK_FKCuentas36608]
    FOREIGN KEY ([TipoMonedaid])
    REFERENCES [dbo].[TipoMoneda]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKCuentas36608'
CREATE INDEX [IX_FK_FKCuentas36608]
ON [dbo].[Cuentas]
    ([TipoMonedaid]);
GO

-- Creating foreign key on [Cuentasid] in table 'GastoFinanzas'
ALTER TABLE [dbo].[GastoFinanzas]
ADD CONSTRAINT [FK_FKGastoFinan518235]
    FOREIGN KEY ([Cuentasid])
    REFERENCES [dbo].[Cuentas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKGastoFinan518235'
CREATE INDEX [IX_FK_FKGastoFinan518235]
ON [dbo].[GastoFinanzas]
    ([Cuentasid]);
GO

-- Creating foreign key on [Cuentasid] in table 'IngresoFinanzas'
ALTER TABLE [dbo].[IngresoFinanzas]
ADD CONSTRAINT [FK_FKIngresoFin249625]
    FOREIGN KEY ([Cuentasid])
    REFERENCES [dbo].[Cuentas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKIngresoFin249625'
CREATE INDEX [IX_FK_FKIngresoFin249625]
ON [dbo].[IngresoFinanzas]
    ([Cuentasid]);
GO

-- Creating foreign key on [Usuarioid] in table 'EscuelaDominical'
ALTER TABLE [dbo].[EscuelaDominical]
ADD CONSTRAINT [FK_FKEscuelaDom17470]
    FOREIGN KEY ([Usuarioid])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKEscuelaDom17470'
CREATE INDEX [IX_FK_FKEscuelaDom17470]
ON [dbo].[EscuelaDominical]
    ([Usuarioid]);
GO

-- Creating foreign key on [TemaPredicacionid] in table 'EscuelaDominical'
ALTER TABLE [dbo].[EscuelaDominical]
ADD CONSTRAINT [FK_FKEscuelaDom783010]
    FOREIGN KEY ([TemaPredicacionid])
    REFERENCES [dbo].[TemaPredicacion]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKEscuelaDom783010'
CREATE INDEX [IX_FK_FKEscuelaDom783010]
ON [dbo].[EscuelaDominical]
    ([TemaPredicacionid]);
GO

-- Creating foreign key on [Usuarioid] in table 'GastoFinanzas'
ALTER TABLE [dbo].[GastoFinanzas]
ADD CONSTRAINT [FK_FKGastoFinan854732]
    FOREIGN KEY ([Usuarioid])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKGastoFinan854732'
CREATE INDEX [IX_FK_FKGastoFinan854732]
ON [dbo].[GastoFinanzas]
    ([Usuarioid]);
GO

-- Creating foreign key on [SubconceptoGastoid] in table 'GastoFinanzas'
ALTER TABLE [dbo].[GastoFinanzas]
ADD CONSTRAINT [FK_FKGastoFinan990835]
    FOREIGN KEY ([SubconceptoGastoid])
    REFERENCES [dbo].[SubconceptoGasto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKGastoFinan990835'
CREATE INDEX [IX_FK_FKGastoFinan990835]
ON [dbo].[GastoFinanzas]
    ([SubconceptoGastoid]);
GO

-- Creating foreign key on [Usuarioid] in table 'IngresoFinanzas'
ALTER TABLE [dbo].[IngresoFinanzas]
ADD CONSTRAINT [FK_FKIngresoFin123343]
    FOREIGN KEY ([Usuarioid])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKIngresoFin123343'
CREATE INDEX [IX_FK_FKIngresoFin123343]
ON [dbo].[IngresoFinanzas]
    ([Usuarioid]);
GO

-- Creating foreign key on [Personaid] in table 'IngresoFinanzas'
ALTER TABLE [dbo].[IngresoFinanzas]
ADD CONSTRAINT [FK_FKIngresoFin745088]
    FOREIGN KEY ([Personaid])
    REFERENCES [dbo].[Persona]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKIngresoFin745088'
CREATE INDEX [IX_FK_FKIngresoFin745088]
ON [dbo].[IngresoFinanzas]
    ([Personaid]);
GO

-- Creating foreign key on [Personaid] in table 'Misiones'
ALTER TABLE [dbo].[Misiones]
ADD CONSTRAINT [FK_FKMisiones810133]
    FOREIGN KEY ([Personaid])
    REFERENCES [dbo].[Persona]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKMisiones810133'
CREATE INDEX [IX_FK_FKMisiones810133]
ON [dbo].[Misiones]
    ([Personaid]);
GO

-- Creating foreign key on [Misionesid] in table 'Persona'
ALTER TABLE [dbo].[Persona]
ADD CONSTRAINT [FK_FKPersona52500]
    FOREIGN KEY ([Misionesid])
    REFERENCES [dbo].[Misiones]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPersona52500'
CREATE INDEX [IX_FK_FKPersona52500]
ON [dbo].[Persona]
    ([Misionesid]);
GO

-- Creating foreign key on [UnidadMedidaid] in table 'Producto'
ALTER TABLE [dbo].[Producto]
ADD CONSTRAINT [FK_FKProducto768955]
    FOREIGN KEY ([UnidadMedidaid])
    REFERENCES [dbo].[UnidadMedida]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKProducto768955'
CREATE INDEX [IX_FK_FKProducto768955]
ON [dbo].[Producto]
    ([UnidadMedidaid]);
GO

-- Creating foreign key on [Rolid] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_FKUsuario38509]
    FOREIGN KEY ([Rolid])
    REFERENCES [dbo].[Rol]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKUsuario38509'
CREATE INDEX [IX_FK_FKUsuario38509]
ON [dbo].[Usuario]
    ([Rolid]);
GO

-- Creating foreign key on [TipoAyudaid] in table 'SalidaAlmacen'
ALTER TABLE [dbo].[SalidaAlmacen]
ADD CONSTRAINT [FK_FKSalidaAlma282847]
    FOREIGN KEY ([TipoAyudaid])
    REFERENCES [dbo].[TipoAyuda]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKSalidaAlma282847'
CREATE INDEX [IX_FK_FKSalidaAlma282847]
ON [dbo].[SalidaAlmacen]
    ([TipoAyudaid]);
GO

-- Creating foreign key on [Usuarioid] in table 'SalidaAlmacen'
ALTER TABLE [dbo].[SalidaAlmacen]
ADD CONSTRAINT [FK_FKSalidaAlma910466]
    FOREIGN KEY ([Usuarioid])
    REFERENCES [dbo].[Usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKSalidaAlma910466'
CREATE INDEX [IX_FK_FKSalidaAlma910466]
ON [dbo].[SalidaAlmacen]
    ([Usuarioid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------