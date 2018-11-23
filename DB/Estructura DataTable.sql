
/* PUNTOS A TENER EN CUENTA PARA PROYECTO:

******************************************************************************************
* -NOMBRE DEL PROYECTO : (CIS) COMMERCIAL INFORMATION SYSTEM (SISTEMA DE INFORMACION COMERCIAL)*
*******************************************************************************************
 
 -TABLAS = 8 CARACTERES,  1 = INICIAL DEL PROYECT, 234 INICIAL MODULO, 567 INICIAL OBJECTO, 8 INICIAL TIPO (m MASTER, d DETALLE, r RELACION, 
  s SECUENTCIA, i IMAGEN ETC)
 -LAS TABLAS GENERALES, OSEA TABLAS QUE NO PERTENECEN A UN MODULO EN ESPECIFICO TENDRAN LAS LETRA 234 grl = GENERAL, POR MODULO SE CREARAN UNA TABLA
 -PARA NOTAS Y OTRA PARA ARCHIVOS ADJUNTOS.
 -AL CREAR O ALTERAR UNA TABLA SE DEBEN GUARDAR LOS SCRIPT PARA LUEGO SER UNIFICADOS EN EL SCRIPT GENERAL, ADEMAS DE INSERTAR LA DESCRIPCION DEL CAMPO EN 
  LAS TABLAS CORRESPONDIENTES AL DICCINARIO DE DATOS
 -SE CREARAN LAS TABLAS cgrltblm Y cgrlcolm PARA USAR LAS MISMAS COMO DICCIONARIO DE DATOS
 -LOS CODIGOS TANTOS EN SQL COMO EN C# DEBEN DOCUMENTARSE LO MAS CLARO POSIBLE, ASI CUALQUIER QUE REVISE LA DOCUMENTACION TENGA IDEA DE QUE REALIZA EL CODIGO
 -EL CODIGO A USAR PARA INSERTAR DATOS DESDE C# SIEMPRE DEBE INDICAR LOS CAMPOS EN LOS CUALES SE VAN A INSERTAR LA DATA
 -PARA LA CRACION DE INDEX USAREMOS NONCLUSTERED CUANDO EL INDICE SEA COMPUESTO (VARIOS CAMPOS), DE LO CONTRARIO USAREMOS EL CLUSTERED, EL ORDEN DE
  LOS CAMPOS ES SIEMPRE  PONER PRIMERO EL CAMPO QUE MENOS SE REPITE
 -INICIALES ESTRUCTRA DE CONTROL SQL: PK_ (PRIMARY KEY) FK_ (FOREIGN KEY) IX_ (INDEX) DF_ (CONSTRAINT DEFAULT)
 -LOS CAMPOS TIPO DECIMAL SIEMPRE LES DEFINIREMOS DEFAULT(0)
 -NOMENCLATURA COMPONENTES C#: frm(Formulario), lb(Label), txt(TextBox), btn(Button), cbx(ComboBox), rbt(Radio Button), lbx(ListBox), dtg(DataGrid),
  mtxt(MaskedTextBox), tab(TabControl), grb(GroupBox), pit(PictureBox)
 -LOS TextBox Y MaskedTextBox SIEMPRE DEBEN ESTAR EN MAYUSCULA
 -LOS LOOKUP SIEMPRE DEBEN TENER UNA OPCION PARA QUE EL USUARIO PUEDA AGREGAR NUEVOS REGISTROS.
 -SOLO SE USARA EL IDENTITY() PARA LAS TABLAS DE LOG, ESTO PARA QUE NO SALTE LA SECUENCIA DEBIDO A ERRORES.

 -CREAR HISTORICO PARA TODOS LOS MODULOS, ASI LOS REPORTES QUE TENGAN QUE MOSTRAR VALORES A FECHAS ANTERIORES NO TARDARAN TANTO EN GENERARSE.
 
 PARA EL REGISTRO DE FACTURA SE CREARA UN cxccliE CONTADO EL CUAL SE INDICARA EN UN PARAMETRO, ESTE cxccliE SOLO PUEDE USAR LA CONDICION DE PAGO
 A CONTADO, Y AL USAR EL MISMO SE HABILITARA UN BOTON CACTURAR DATOS EL CUAL LLAMARA EL PROGRAMA DATOS cxccliE CONTADO CUYOS CAMPOS SERAN TIPO IDEN, 
 IDENT, NOMBRE COMPLETO, DIRECCION, TELEFONO
*/
USE MASTER
GO

IF EXISTS(select * from sys.databases where name = 'CIS')
   BEGIN
        DROP DATABASE CIS
   END
GO

CREATE DATABASE [CIS] ON  PRIMARY 
       (NAME = N'CIS_Data',  FILENAME = N'C:\CIS\CIS.Mdf', SIZE = 5, MAXSIZE = UNLIMITED, FILEGROWTH = 10%) ,
       (NAME = N'CIS_Data1', FILENAME = N'C:\CIS\CIS.Ndf', SIZE = 5, MAXSIZE = UNLIMITED, FILEGROWTH = 10%) 
LOG ON (NAME = N'CIS_Log',   FILENAME = N'C:\CIS\CIS.Log', SIZE = 5, MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
COLLATE SQL_Latin1_General_CP1_CI_AS 
GO
 

USE CIS
GO

CREATE TABLE cgrltblm (grltbl_codigo  CHAR(20)     NOT NULL, 
                       grltbl_descrip VARCHAR(100) NOT NULL 
                       CONSTRAINT PK_cgrltblm PRIMARY KEY CLUSTERED 
                                              (grltbl_codigo ASC)) ON [PRIMARY]
GO

CREATE TABLE cgrlcolm (grlcol_codigo  CHAR(20)     NOT NULL,
                       grlcol_descrip VARCHAR(100) NOT NULL, 
                       grltbl_codigo  CHAR(20)     NOT NULL 
                       CONSTRAINT PK_cgrlcolm PRIMARY KEY CLUSTERED 
                                              (grlcol_codigo ASC,
                                               grltbl_codigo ASC)) ON [PRIMARY]
GO

ALTER TABLE cgrlcolm  WITH CHECK ADD CONSTRAINT FK_cgrlcolm_cgrltblm FOREIGN KEY(grltbl_codigo)
                                     REFERENCES cgrltblm (grltbl_codigo)
GO

CREATE NONCLUSTERED INDEX IX_cgrlcolm ON cgrlcolm (grlcol_codigo, 
                                                   grltbl_codigo) 
GO

CREATE TABLE cgrlstsm (grlsts_codigo  INT     NOT NULL, 
                       grlsts_descrip VARCHAR(100) NOT NULL,
                       grltbl_codigo  CHAR(20) NOT NULL
                       CONSTRAINT PK_cgrlstsm PRIMARY KEY CLUSTERED 
                                              (grlsts_codigo ASC,
                                               grltbl_codigo ASC)) ON [PRIMARY]
GO

ALTER TABLE cgrlstsm  WITH CHECK ADD CONSTRAINT FK_cgrlstsm_cgrltblm FOREIGN KEY(grltbl_codigo)
                                     REFERENCES cgrltblm (grltbl_codigo)
GO

 
CREATE TABLE cinvadjm (invadj_id       INT  IDENTITY(1,1)   NOT NULL, 
                       invadj_idorig   INT NOT NULL,
                       grltbl_codigo   CHAR(20) NOT NULL,
                       invadj_seq      SMALLINT NOT NULL,
                       grlusr_codigo   CHAR(20) NOT NULL,
                       invadj_descrip  VARCHAR(100) NOT NULL,
                       invadj_file     IMAGE NOT NULL
                       CONSTRAINT PK_cinvadjm PRIMARY KEY CLUSTERED 
                                              (invadj_idorig ASC,
                                               grltbl_codigo ASC,
                                               invadj_seq ASC)) ON [PRIMARY]
GO

ALTER TABLE cinvadjm  WITH CHECK ADD CONSTRAINT FK_cinvadjm_cgrltblm FOREIGN KEY(grltbl_codigo)
                                     REFERENCES cgrltblm (grltbl_codigo)
GO

 
CREATE TABLE cinvnotm (invnot_id       INT  IDENTITY(1,1)   NOT NULL, 
                       invnot_idorig   INT NOT NULL,
                       grltbl_codigo   CHAR(20) NOT NULL,
                       invnot_seq      SMALLINT NOT NULL,
                       grlusr_codigo   CHAR(20) NOT NULL,
                       invnot_descrip  VARCHAR(50) NOT NULL,
                       invnot_nota     VARCHAR(3000) NOT NULL 
                       CONSTRAINT PK_cinvnotm PRIMARY KEY CLUSTERED 
                                              (invnot_idorig ASC,
                                               grltbl_codigo ASC,
                                               invnot_seq ASC)) ON [PRIMARY]
GO

ALTER TABLE cinvnotm  WITH CHECK ADD CONSTRAINT FK_cinvnotm_cgrltblm FOREIGN KEY(grltbl_codigo)
                                     REFERENCES cgrltblm (grltbl_codigo)
GO
  

CREATE TABLE cinvartm (invart_id      INT  IDENTITY(1,1) NOT NULL,
                       grlcia_codigo  CHAR(2)			 NOT NULL,
                       invart_codigo  CHAR(20)			 NOT NULL, 
                       invart_descrip VARCHAR(150)		 NOT NULL,
                       invart_exist   DECIMAL(14,6)		 NOT NULL DEFAULT(0), 
                       invart_separ   DECIMAL(14,6)		 NOT NULL DEFAULT(0),
                       invart_fechreg DATE				 NOT NULL,
                       invfam_codigo  CHAR(3),
                       grlsts_codigo  INT				 NOT NULL
                       CONSTRAINT PK_cinvartm PRIMARY KEY CLUSTERED 
                                              (invart_id ASC)) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_cinvartm ON cinvartm (invart_id, 
                                                   grlcia_codigo) 
GO

CREATE TABLE cinvarti (invart_id     INT NOT NULL,
                       invart_imagen IMAGE NOT NULL)
                       
GO
ALTER TABLE cinvarti  WITH CHECK ADD CONSTRAINT FK_cinvarti_cinvartm FOREIGN KEY(invart_id)
                                     REFERENCES cinvartm (invart_id)
GO


--<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  CARLOS  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

CREATE TABLE ccxcnotm (cxcnot_id			INT IDENTITY NOT NULL, 
					   cxcnot_idorig		INT			 NOT NULL, 
					   cgrltbl_codigo		CHAR(20)	 NOT NULL, 
					   cxcnot_nota			VARCHAR(20)	 NOT NULL, 
					   cxcnot_descrip		VARCHAR(300) NULL	 ,
					   CONSTRAINT PK_ccxcnotm PRIMARY KEY CLUSTERED (cxcnot_idorig  ASC, 
									cgrltbl_codigo ASC)) ON [PRIMARY]
GO

CREATE TABLE ccxcadjm (cxcadj_id			INT IDENTITY NOT NULL, 
					   cxcadj_idorig		INT			 NOT NULL, 
					   cgrltbl_codigo		CHAR(20)	 NOT NULL, 
					   cxcadj_seq			INT			 NOT NULL, 
					   grlusr_codiog        CHAR(10)	 NOT NULL,
					   cxcadj_descrip		VARCHAR(300) NULL	 
					   --cxcadj_file			
					   CONSTRAINT PK_ccxcadjm PRIMARY KEY CLUSTERED(cxcadj_idorig  ASC, 
									cgrltbl_codigo ASC, 
									cxcadj_seq	   ASC)) ON [PRIMARY]
GO                               

CREATE TABLE cgrlidem(grlide_Id		INT	IDENTITY		NOT NULL ,
					  grlide_nombre VARCHAR(20) NOT NULL ,
					  grlide_abrev  CHAR(3)		NOT NULL , 
					  grlsts_codigo INT			NOT NULL 
					   )

GO 
--DROP TABLE cgrlpaim
CREATE TABLE cgrlpaim (grlpai_codigo	 INT			 NOT NULL,
					   grlpai_nombre	 VARCHAR(100)	 NOT NULL,
					   grlpai_abrev		 CHAR(2)		 NOT NULL,
					   grlpai_codarea    VARCHAR(20)     NULL,
					   grlpai_gentilicio VARCHAR(60)     NULL,
					   grlpai_nomabrev   CHAR(2)		 NULL,
					   grlsts_codigo     INT			 NULL
					   CONSTRAINT PK_cgrlpaim PRIMARY KEY CLUSTERED 
											  (grlpai_codigo ASC) ) ON [PRIMARY]
GO

CREATE TABLE cgrlentm (grlent_ID		    INT	IDENTITY NOT NULL ,    ---ESTA TABLA NO LE PONDREMOS CAMPO CODIGO
					   grlent_nombre	    VARCHAR(50) NOT NULL , 
					   grlent_apellido	    VARCHAR(50)     NULL , 
					   grlent_tipo		    CHAR(1)		NOT NULL ,
					   grlent_tipoide		CHAR(3)		NOT NULL ,
					   --grlide_Id			INT			NOT NULL ,
					   grlent_identif       CHAR(20)    NOT NULL ,
					   grlpai_codigo		INT			NOT NULL ,
					   grlsts_codigo		INT			NOT NULL , 
					   CONSTRAINT PK_cgrlentm PRIMARY KEY CLUSTERED 
														  (grlent_ID  ASC)) ON [PRIMARY]
GO  

--ALTER TABLE cgrlentm WITH CHECK ADD CONSTRAINT  FK_cgrlentm_cgrlpaim FOREIGN KEY (grlpai_codigo)
--																	 REFERENCES cgrlpaim (grlpai_codigo)
--GO
--ALTER TABLE cgrlentm WITH CHECK ADD CONSTRAINT  FK_cgrlentm_cgrlidem FOREIGN KEY (grlide_Id)
--																	 REFERENCES cgrlidem(grlide_Id)

--ALTER TABLE cgrlentm WITH CHECK ADD CONSTRAINT  FK_cgrlentm_cgrlstsm FOREIGN KEY (grlsts_codigo)
																	 --REFERENCES cgrlstsm(grlsts_codigo)


--<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  CARLOS  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>




INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrltblm', 'TABLAS DEL SISTEMA')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlcolm', 'COLUMNAS DE LAS TABLAS DEL SISTEMA')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlstsm', 'ESTADOS CORRESPONDIENTES A UNA TABLA')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cinvadjm', 'TABLA ARCHIVOS ADJUNTO MODULO INV')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cinvnotm', 'TABLA NOTAS MODULO INV')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cinvartm', 'TABLA MAESTRA DE ARTICULOS')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cinvarti', 'TABLA IMAGENES DE ARTICULOS')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlpaim', 'TABLAS DE PAISES')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('ccxcnotm', 'TABLAS DE NOTAS DE FACTURAS')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('ccxcadjm', 'TABLAS DE ARCHIVOS ADJUNTOS')
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlentm', 'TABLAS DE MAESTRA DE ENTIDADES')	
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlidem', 'TABLAS DE MAESTRA DE IDENTIFICACIONES')	

GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'cgrltblm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltbl_descrip', 'DESCRIPCION TABLAS DEL SISTEMA', 'cgrltblm')
GO  

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcol_codigo', 'CODIGO COLUMNA', 'cgrlcolm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcol_descrip', 'DESCRIPCION COLUMNA', 'cgrlcolm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'cgrlcolm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_codigo', 'CODIGO ESTATUS TABLA', 'cgrlstsm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_descrip', 'DESCRIPCION ESTATUS TABLA', 'cgrlstsm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'cgrlstsm')
GO 


INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invadj_id', 'CODIGO INTERNO ARCHIVOS ADJUNTOS MODULO INV', 'cinvadjm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invadj_idorig', 'ID ORIGEN ARCHIVOS ADJUNTOS MODULO INV', 'cinvadjm') 
GO   
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'cinvadjm') 
GO    
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invadj_seq', 'SECUENCIA ARCHIVOS ADJUNTOS MODULO INV', 'cinvadjm') 
GO  
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlusr_codiog', 'USUARIO QUE AJUNTO EL ARCHIVO', 'cinvadjm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invadj_descrip', 'DESCRIPCION ARCHIVO ADJUNTO', 'cinvadjm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invadj_file', 'ARCHIVO DE ARCHIVOS ADJUNTOS MODULO INV', 'cinvadjm') 
GO                                  
     


INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invnot_id', 'CODIGO INTERNO NOTAS MODULO INV', 'cinvnotm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invnot_idorig', 'ID ORIGEN NOTAS MODULO INV', 'cinvnotm') 
GO   
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'cinvnotm') 
GO   
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invnot_seq', 'SECUENCIA NOTAS MODULO INV', 'cinvnotm') 
GO  
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlusr_codiog', 'USUARIO QUE REGISTRO LA NOTA', 'cinvnotm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invnot_descrip', 'DESCRIPCION CORTA NOTAS MODULO INV', 'cinvnotm') 
GO   
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invnot_nota', 'DESCRIPCION DETALLADA NOTAS MODULO INV', 'cinvnotm') 
GO                                  
                            
              

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invart_id', 'CODIGO INTERNO DEL ARTICULO', 'cinvartm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcia_codigo', 'COMPAÑIA A LA CUAL PERTENECE EL ARTICULO', 'cinvartm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invart_codigo', 'CODIGO ARTICULO REGISTRADO POR EL USUARIO ', 'cinvartm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invart_descrip', 'DESCRIPCION DEL ARTICULO', 'cinvartm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invart_exist', 'EXISTENCIA TOTAL DEL ARTICULO', 'cinvartm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invart_separ', 'SEPARACION TOTAL DEL ARTICULO', 'cinvartm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invfam_codigo', 'CODIGO FAMILA DE PRODUCTO', 'cinvartm')
GO
 INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_codigo', 'ESTATUS DEL ARTICULO', 'cinvartm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invart_id', 'CODIGO INTERNO DEL ARTICULO', 'cinvarti')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invart_imagen', 'IMAGEN ARTICULO', 'cinvarti')
GO


/*****************************************************************/
/************************AGREGADO*********************************/
/*****************************************************************/
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codigo', 'CODIGO DEL PAIS', 'cgrlpaim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_nombre', 'NOMBRE DEL PAIS', 'cgrlpaim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_abrev', 'ABREVIATRURA DEL PAIS', 'cgrlpaim')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codarea', 'CODIGOS DE AREA DEL PAIS', 'cgrlpaim')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_gentilicio', 'GENTILICIO DEL PAIS', 'cgrlpaim')
GO

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_nomabrev', 'NOMBRE ABREVIADO O INICIALES DEL PAIS', 'cgrlpaim')
GO
 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_codigo', 'ESTADO DEL REGISTRO PARA LA TABLA PAIS', 'cgrlpaim')     
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcnot_id', 'ID DE LA NOTA', 'ccxcnotm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcnot_idorig', 'ID ORIGEN DE LA FACTURA', 'ccxcnotm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('sgrltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'ccxcnotm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcnot_nota', 'NOMBRE NOTA', 'ccxcnotm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcnot_descrip', 'DESCRIPCION DE LA NOTA', 'ccxcnotm')
GO

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcadj_id', 'CODIGO INTERNO ARCHIVOS ADJUNTOS MODULO INV', 'ccxcadjm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcadj_idorig', 'ID ORIGEN ARCHIVOS ADJUNTOS MODULO INV', 'ccxcadjm') 
GO   
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cgrltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'cinvadjm') 
GO    
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcadj_seq', 'SECUENCIA ARCHIVOS ADJUNTOS MODULO CXC', 'ccxcadjm') 
GO  
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlusr_codiog', 'USUARIO QUE AJUNTO EL ARCHIVO', 'ccxcadjm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcadj_descrip', 'DESCRIPCION ARCHIVO ADJUNTO', 'ccxcadjm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcadj_file', 'ARCHIVO DE ARCHIVOS ADJUNTOS MODULO CXC', 'ccxcadjm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_ID', 'ID DE LA ENTIDAD', 'cgrlentm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_nombre', 'NOMBRE DE LA ENTIDAD', 'cgrlentm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_apellido', 'APELLIDO O SIGLAS DE LA ENTIDAD', 'cgrlentm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_tipo', 'TIPO DE ENTIDAD', 'cgrlentm') 

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_tipoide', 'TIPO DE IDENTIFICACION', 'cgrlentm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_identif', 'NUMERO DE IDENTIFICACION', 'cgrlentm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codigo', 'CODIGO DEL PAIS', 'cgrlentm') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_codigo', 'CODIGO ESTATUS ENTIDAD', 'cgrlentm') 
GO 

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlide_Id', 'ID DE LA IDENTIFICACION', 'cgrlidem') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlide_nombre', 'NOMBRE DE LA IDENTIFICACION', 'cgrlidem') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlide_abrev', 'ABREVIATURA DE LA IDENTIFICACION', 'cgrlidem') 
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_codigo', 'CODIGO ESTATUS IDENTIFICACION', 'cgrlidem') 
GO 


CREATE TABLE cgrlprvm (grlprv_codigo INT		  NOT NULL, 
					   grlprv_nombre VARCHAR(100) NOT NULL,
					   grlpai_codigo INT		  NOT NULL 					   
					   CONSTRAINT PK_cgrlprvm PRIMARY KEY CLUSTERED
											  (grlprv_codigo ASC,

											   grlpai_codigo ASC )ON [PRIMARY])
GO

INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlprvm', 'TABLA DE PROVINCIAS')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlprv_codigo', 'CODIGO DE LA PROVINCIA', 'cgrlprvm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlprv_nombre', 'NOMBRE DE LA PROVINCIA', 'cgrlprvm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codigo', 'NOMBRE PAIS DE LA PROVINCIA', 'cgrlprvm') 
GO

CREATE TABLE cgrlcium (grlcui_codigo INT		  NOT NULL,
					   grlcui_nombre VARCHAR(100) NOT NULL,
					   grlpai_codigo INT		  NOT NULL,
					   grlprv_codigo INT		  NOT NULL 
					   CONSTRAINT PK_cgrlcium PRIMARY KEY CLUSTERED
											  (grlcui_codigo ASC)ON [PRIMARY])

GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlcium', 'TABLA DE CIUDADES')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcui_codigo', 'CODIGO DE LA CIUDAD', 'cgrlcium') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcui_nombre', 'NOMBRE DE LA CIUDAD', 'cgrlcium') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codigo', 'CODIGO DEL PAIS', 'cgrlcium') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlprv_codigo', 'CODIGO DE LA PROVINCIA', 'cgrlcium') 
GO


CREATE TABLE cgrlsetm (grlset_codigo INT		  NOT NULL,
					   grlset_nombre VARCHAR(100) NOT NULL,
					   grlpai_codigo INT		  NOT NULL,
					   grlciu_codigo INT		  NOT NULL
					   CONSTRAINT PK_cgrlsetm PRIMARY KEY CLUSTERED
											  (grlset_codigo ASC,
											   grlciu_codigo ASC))ON [PRIMARY]
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlsetm', 'TABLA DE SECTORES')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlset_codigo', 'CODIGO DEL SECTOR', 'cgrlsetm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlset_nombre', 'NOMBRE DEL SECTOR', 'cgrlsetm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codigo', 'CODIGO DEL PAIS', 'cgrlsetm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('admciu_codigo', 'CODIGO DE LA CIUDAD', 'cgrlsetm') 
GO

CREATE TABLE cgrllocm (grlloc_codigo CHAR(6)	  NOT NULL,
					   grlloc_nombre VARCHAR(100) NOT NULL,
					   grlprv_codigo INT		  NOT NULL
					   CONSTRAINT PK_cgrllocm PRIMARY KEY CLUSTERED
											  (grlloc_codigo,grlprv_codigo))ON [PRIMARY]
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrllocm', 'TABLA DE LOCALIDADES')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlloc_codigo', 'CODIGO DE LA LOCALIDAD', 'cgrllocm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlloc_nombre', 'NOMBRE DE LA LOCALIDAD', 'cgrllocm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlprv_codigo', 'CODIGO DE LA PROVINCIA', 'cgrllocm') 
GO


CREATE TABLE cgrlusom (grluso_codigo CHAR(3)	  NOT NULL,
					   grluso_nombre VARCHAR(100) NOT NULL
					   CONSTRAINT PK_cgrlusom PRIMARY KEY CLUSTERED
											  (grluso_codigo ASC))ON [PRIMARY]
GO 
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlusom', 'TABLA LUGARES DE USO DE DIRECCIONES Y TELEFONOS EJ. OFI')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grluso_codigo', 'CODIGO DEL LUGAR DE USO', 'cgrlusom') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grluso_nombre', 'NOMBRE DEL LUGAR DE USO', 'cgrlusom') 
GO


CREATE TABLE cgrldird (grlent_ID		INT			NOT NULL,
					   grluso_codigo	CHAR(3)		NOT NULL,
					   grlpai_codigo	INT			NOT NULL,
					   grlprv_codigo	INT			NOT NULL, 
					   grlcui_codigo	INT			NOT NULL,
					   grlset_codigo	INT			NULL	,
					   grldir_calle		VARCHAR(100)NOT NULL,
					   grldir_numero	INT			NULL    ,
					   grldir_edificio  VARCHAR(60) NULL	
					   CONSTRAINT PK_cgrldird PRIMARY KEY CLUSTERED
											  (grlent_ID	 ASC,
											   grlpai_codigo ASC,
											   grlcui_codigo ASC
											   ))ON [PRIMARY]
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrldird', 'TABLA DE DIRECCIONES')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_ID', 'ID DE LA ENTIDAD', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grluso_codigo', 'CODIGO DEL LUGAR DE USO EJ. (OFI,OF1,OF2,RES,RE1,RE2,NEG)', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codigo', 'CODIGO DE PAIS', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlprv_codigo', 'CODIGO DE LA PROVINCIA', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcui_codigo', 'CODIGO DE LA CIUDAD', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlset_codigo', 'CODIGO DEL SECTOR', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grldir_calle', 'NOMBRE DE LA CALLE', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grldir_numero', 'NUMERO DE LA DIRECCION', 'cgrldird') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grldir_edificio', 'EDIFICION DE LA DIRECCION', 'cgrldird') 
GO


CREATE TABLE cgrltiptm(grltipt_codigo CHAR(3) NOT NULL,
					   grltipt_nombre VARCHAR(30) NOT NULL
					   CONSTRAINT PK_cgrltiptm PRIMARY KEY CLUSTERED 
											   (grltipt_codigo ASC))ON [PRIMARY]
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrltiptm', 'TABLA DE TIPOS DE TELEFONOS')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltipt_codigo', 'CODIGO DEL TIPO DE TELEFONO', 'cgrltiptm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltipt_nombre', 'NOMBRE DEL TIPO', 'cgrltiptm') 
GO

CREATE TABLE cgrlteld (grlent_ID	  INT		NOT NULL,
					   grltipt_codigo CHAR(3)   NOT NULL,
					   grltel_area    CHAR(6)   NOT NULL,
					   grltel_numero  CHAR(10)  NOT NULL,
					   grltel_ext     CHAR(4)   NOT NULL,
					   grluso_codigo  CHAR(3)	NOT NULL,
					   grlpai_codigo  INT		NOT NULL
					   CONSTRAINT PK_cgrlteld PRIMARY KEY CLUSTERED
											  (grltel_area,grltel_numero))ON [PRIMARY]
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlteld', 'TABLA DE TELEFONOS')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_ID', 'ID DE LA ENTIDAD ', 'cgrlteld') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltipt_codigo', 'CODIGO DEL TIPO DE TELEFONO', 'cgrlteld') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltel_area', 'AREA DEL TELEFONO', 'cgrlteld') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltel_numero', 'NUMERO DEL TELEFONO', 'cgrlteld') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltel_ext', 'NUMERO DE EXTENCION ', 'cgrlteld') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grluso_codigo', 'LUGAR DE USO DEL TELEFONO', 'cgrlteld') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpai_codigo', 'PAIS DEL TELEFONO', 'cgrlteld') 
GO


CREATE TABLE ccxcvinm (cxcvin_codigo CHAR(3)	 NOT NULL,
					   cxcvin_nombre VARCHAR(30) NOT NULL
					   CONSTRAINT PK_ccxcvinm PRIMARY KEY CLUSTERED
											  (cxcvin_codigo ASC))ON [PRIMARY]
GO

INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('ccxcvinm', 'TABLA DE VINCULOS DE CLIENTE')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcvin_codigo', 'CODIGO DEL VINCULO', 'ccxcvinm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcvin_nombre', 'NOMBRE DEL VINCULO', 'ccxcvinm') 
GO


CREATE TABLE cgrlstcvm (
						grlstcv_codigo  CHAR(1)		 NOT NULL,
						grlstcv_nombre  VARCHAR(20)	 NOT NULL,
						grlstcv_Id		INT IDENTITY NOT NULL
						CONSTRAINT PK_cgrlstcvm PRIMARY KEY CLUSTERED (grlstcv_Id ASC) ) ON [PRIMARY]
GO 
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlstcvm', 'TABLA DE ESTADO CIVIL')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlstcv_Id', 'ID DE ESTADO CIVIL', 'cgrlstcvm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlstcv_codigo', 'CODIGO DE ESTADO CIVIL', 'cgrlstcvm') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlstcv_nombre', 'NOMBRE DE ESTADO CIVIL', 'cgrlstcvm') 
GO

CREATE TABLE ccxctclim(cxctcli_codigo	CHAR(2)			NOT NULL,
					   cxctcli_nombre	VARCHAR(30)		NOT NULL,
					   cxctcli_sec		INT				NOT NULL
					   CONSTRAINT PK_ccxctclim PRIMARY KEY CLUSTERED (cxctcli_codigo ASC) )ON [PRIMARY]
GO 

INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('ccxctclim', 'TABLA DE MAESTRA DE TIPOS DE CLIENTE')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxctcli_codigo', 'TIPO DE CLIENTE', 'ccxctclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxctcli_nombre', 'NOMBRE TIPO DE CLIENTE', 'ccxctclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxctcli_sec', 'SECUENCIA TIPO DE CLIENTE', 'ccxctclim') 
GO

CREATE TABLE ccxcclim (grlent_ID      INT		   NOT NULL, 
					   cxccli_nombre  VARCHAR(100)  NOT NULL,
					   cxccli_fecing  SMALLDATETIME NOT NULL,
					   grlsts_codigo  INT           NOT NULL,
					   cxcvin_codigo  CHAR(2)		    NULL,
					   grlstcv_codigo CHAR(1)			NULL,
					   cxccli_sexo    CHAR(1)           NULL,
					   cxctcli_codigo CHAR(2)		NOT NULL,
					   cxccli_Codigo  INT			NOT NULL,
					   cxccli_fecnac  SMALLDATETIME     NULL,

					   CONSTRAINT PK_ccxcclim PRIMARY KEY CLUSTERED 
											  (grlent_ID ASC))ON [PRIMARY]
GO


--ALTER TABLE ccxcclim WITH CHECK ADD CONSTRAINT FK_ccxcclim_cgrlentm FOREIGN KEY (grlent_ID)
--																	REFERENCES cgrlentm(grlent_ID)
--GO

--ALTER TABLE ccxcclim WITH CHECK ADD CONSTRAINT FK_ccxcclim_cgrlstsm FOREIGN KEY (grlsts_codigo)
--																	REFERENCES cgrlstsm(grlsts_codigo)
--GO

--ALTER TABLE ccxcclim WITH CHECK ADD CONSTRAINT FK_ccxcclim_ccxcvinm FOREIGN KEY (cxcvin_codigo)
--																	REFERENCES ccxcvinm (cxcvin_codigo)
--GO 

--ALTER TABLE ccxcclim with CHECK ADD CONSTRAINT FK_ccxcclim_cgrlstcvm FOREIGN KEY (grlstcv_codigo)
--																	 REFERENCES cgrlstcvm(grlstcv_codigo)
--GO

--ALTER TABLE ccxcclim WITH CHECK ADD CONSTRAINT FK_ccxcclim_ccxctclim FOREIGN KEY (cxctcli_codigo)
--														    REFERENCES ccxctclim (cxctcli_codigo)
--GO


INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('ccxcclim', 'TABLA DE MAESTRA DE CLIENTE')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_ID', 'ID DE LA ENTIAD', 'ccxcclim') 
GO

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxccli_nombre', 'NOMBRE DEL CLIENTE', 'ccxcclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxccli_fecing', 'FECHA DE INGRESO DEL CLIENTE', 'ccxcclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_codigo', 'CODIGO ESTATUS DEL CLIENTE', 'ccxcclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxcvin_codigo', 'CODIGO DEL VINCULO', 'ccxcclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlstcv_codigo', 'CODIGO DEL ESTADO CIVIL', 'ccxcclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxccli_sexo', 'SEXO DEL CLIENTE', 'ccxcclim') 
GO

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxctcli_codigo', 'TIPO DEL CLIENTE', 'ccxcclim') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('cxccli_fecnac', 'FECHA DE NACIMIENTO DEL CLIENTE', 'ccxcclim') 
GO

CREATE TABLE cgrlcond (grlent_ID INT , grlcon_id INT, grlcon_parentesco VARCHAR(20)
						CONSTRAINT PK_cgrlcond PRIMARY KEY CLUSTERED (grlent_ID ASC,
																	  grlcon_id ASC) ) ON [PRIMARY]
GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlcond', 'TABLA DE CONTACTOS DE CLIENTES')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlent_ID', 'ID DE LA ENTIAD', 'cgrlcond') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcon_id', 'ID DEL CONTACTO', 'cgrlcond') 
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlcon_parentesco', 'PARENTESCO O TIPO DE RELACION CON EL CONTACTO', 'cgrlcond') 
GO


CREATE TABLE cgrlseqs (grlseq_ID       INT  IDENTITY(1,1) NOT NULL,
                       grltbl_codigo   CHAR(20)			  NOT NULL,
                       grlseq_Ultseq   INT				  NOT NULL
                       CONSTRAINT PK_cgrlseqs PRIMARY KEY CLUSTERED 
                                              (grlseq_ID ASC)) ON [PRIMARY]
GO 
--ALTER TABLE cgrlseqs  WITH CHECK ADD CONSTRAINT FK_cgrlseqs_cgrltblm FOREIGN KEY(grltbl_codigo)
--                                     REFERENCES cgrltblm (grltbl_codigo)
--GO
INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlseqs', 'TABLAS DEL SECUENCIAS')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlseq_ID', 'ID DE LA SECUENCIA', 'cgrlseqs')
GO  
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grltbl_codigo', 'CODIGO TABLAS DEL SISTEMA', 'cgrlseqs')
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlseq_Ultseq', 'ULTIMA SECUENCIA UTILIZADA', 'cgrlseqs')
GO  
/********************************************************************************************/
/****************************Luis Miguel****************************************************************/
/********************************************************************************************/


CREATE TABLE cgrlmodm (grlmod_codigo  CHAR(3)      NOT NULL, 
                       grlmod_descrip VARCHAR(100) NOT NULL, 
                       CONSTRAINT PK_cgrlmodm PRIMARY KEY CLUSTERED 
                                              (grlmod_codigo ASC )) ON [PRIMARY]
GO

--INSERTAR MODULO
INSERT INTO cgrlmodm (grlmod_codigo, grlmod_descrip)
              VALUES ('INV', 'MODULO INVENTARIO')
GO              
INSERT INTO cgrlmodm (grlmod_codigo, grlmod_descrip)
              VALUES ('EFT', 'MODULO EFECTIVO')
GO


--INSERTAR ESTADOS
INSERT INTO cgrlstsm (grlsts_codigo, grlsts_descrip, grltbl_codigo)
              VALUES (0, 'INACTIVO', 'cinvartm')
GO              
INSERT INTO cgrlstsm (grlsts_codigo, grlsts_descrip, grltbl_codigo)
              VALUES (1, 'ACTIVO', 'cinvartm')
GO

 

 CREATE TABLE cgrlparm( grlpar_codigo   CHAR(3) NOT NULL,
                       grlpar_descrip  VARCHAR(300) NOT NULL,
                       grlmod_codigo   CHAR(3) NOT NULL, 
                       grlpar_tipo     SMALLINT NOT NULL,  --(1= General, 2 = Sucursal, 3 =(si el mod = inv then Almacen, Mod = EFT then CtaBancaria))
                       grlpar_modiftip SMALLINT NOT NULL
                       CONSTRAINT PK_cgrlparm PRIMARY KEY CLUSTERED 
                                              (grlpar_codigo ASC,
                                               grlmod_codigo ASC)) ON [PRIMARY]  
GO
ALTER TABLE cgrlparm  WITH CHECK ADD CONSTRAINT FK_cgrlparm_cgrlmodm FOREIGN KEY(grlmod_codigo)
                                     REFERENCES cgrlmodm (grlmod_codigo)
GO

INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlparm', 'MAESTRA PARAMETROS DEL SISTEMA')
GO

INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpar_codigo', 'CODIGO DEL PARAMETRO', 'cgrlparm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpar_descrip', 'DESCRIPCION DEL PARAMETRO', 'cgrlparm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlmod_codigo', 'CODIGO MODULO DEL PARAMETRO', 'cgrlparm')
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpar_tipo', 'TIPO DE PARAMETRO(1= GENERAL, 2 = SUCURSAL, 3 =(MOD = INV THEN ALMACEN, MOD = EFT THEN CTABANCARIA)) ', 'cgrlparm')
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpar_modiftip', 'MODIFICAR TIPO PARAMETRO', 'cgrlparm')
GO 

CREATE TABLE cgrlpard( grlpar_codigo   CHAR(3)  NOT NULL,
                       grlmod_codigo   CHAR(3)  NOT NULL, 
                       grlpar_seq      SMALLINT NOT NULL, 
                       admsuc_codigo   CHAR(3)  NULL, 
                       invalm_codigo   CHAR(3)  NULL,
                       eftbco_codigo   CHAR(3)  NULL,
                       grlpar_valor    VARCHAR(50)NOT NULL
                       CONSTRAINT PK_cgrlpard PRIMARY KEY CLUSTERED 
                                              (grlpar_codigo ASC,
                                               grlmod_codigo ASC,
                                               grlpar_seq    ASC)) ON [PRIMARY]  
GO  

INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlpard', 'DETALLE PARAMETROS DEL SISTEMA')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpar_codigo', 'CODIGO DEL PARAMETRO', 'cgrlpard')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlmod_codigo', 'MODULO AL QUE PERTENECE EL PARAMETRO', 'cgrlpard')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpar_seq', 'SEQUENCIA DETALLE PARAMETRO', 'cgrlpard')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('admsuc_codigo', 'CODIGO SUCURSAL', 'cgrlpard')
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('invalm_codigo', 'CODIGO ALMACEN', 'cgrlpard')
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('eftbco_codigo', 'CODIGO CUENTA BANCARIA', 'cgrlpard')
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlpar_valor', 'VALOR DEL PARAMETRO', 'cgrlpard')
GO  

CREATE TABLE cgrlusrm( grlusr_codigo   CHAR(20)     NOT NULL,
                       grlusr_nombre   VARCHAR(100) NOT NULL, 
                       admsuc_codigo   CHAR(3)      NOT NULL, 
                       grlsts_codigo   INT          NOT NULL 
                       CONSTRAINT PK_cgrlusrm PRIMARY KEY CLUSTERED 
                                              (grlusr_codigo ASC )) ON [PRIMARY] 
GO


INSERT INTO cgrltblm (grltbl_codigo, grltbl_descrip)
              VALUES ('cgrlusrm', 'TABLA MAESTRA DE USUARIOS')

			  
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlusr_codigo', 'CODIGO DEL USUARIO', 'cgrlusrm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlusr_nombre', 'NOMBRE DEL USUARIO', 'cgrlusrm')
GO
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('admsuc_codigo', 'SUCURSAL EN LA CUAL ESTA LOGEADO EL USUARIO', 'cgrlusrm')
GO 
INSERT INTO cgrlcolm (grlcol_codigo, grlcol_descrip, grltbl_codigo)
              VALUES ('grlsts_codigo', 'ESTADO USUARIO', 'cgrlusrm')
GO 


--INSERTAR PARAMETROS
INSERT INTO cgrlparm (grlpar_codigo, grlpar_descrip, grlmod_codigo, grlpar_tipo, grlpar_modiftip)
              VALUES ('MTC', 'METODO DE COSTO: U = UEPS, P = PEPS A = PROMEDIO ', 'INV', 1, 0)
GO
INSERT INTO cgrlpard (grlpar_codigo, grlmod_codigo, grlpar_seq, admsuc_codigo, invalm_codigo, eftbco_codigo, grlpar_valor)
              VALUES ('MTC', 'INV', 1, NULL, NULL, NULL, 'A')
GO

--USUARIOS
INSERT INTO cgrlusrm (grlusr_codigo, grlusr_nombre, admsuc_codigo, grlsts_codigo)
              VALUES ('admin', 'ADMINISTRATOR', '001', 1)
 GO 



