USE MASTER
CREATE DATABASE TOTEM;
USE TOTEM;

CREATE TABLE TB_PALESTRA
(ID_PALESTRA INT IDENTITY PRIMARY KEY,
TITULO VARCHAR(100),
DESCRICAO VARCHAR(200),
PALESTRANTE VARCHAR(50),
DATA_PALESTRA DATETIME,
HORA_PALESTRA TIME,
TIPO_PALESTRA INT,
SITUACAO VARCHAR(1) DEFAULT N
)

/* PROCEDURE PARA INSER��O DE PALESTRA*/
/*DATA DE CRIA��O 08/02/2019 AUTOR= HUGO BARROS*/
GO
CREATE PROCEDURE FL_PALESTRA_INS
@TITULO VARCHAR(100),
@DESCRICAO VARCHAR(200),
@PALESTRANTE VARCHAR(50),
@DATA_PALESTRA DATETIME,
@HORA_PALESTRA TIME,
@TIPO_PALESTRA INT,
@ID_OUT INT OUTPUT
AS
INSERT INTO TB_PALESTRA
(TITULO,DESCRICAO,PALESTRANTE,DATA_PALESTRA,HORA_PALESTRA,TIPO_PALESTRA)
VALUES(@TITULO,@DESCRICAO,@PALESTRANTE,@DATA_PALESTRA,@HORA_PALESTRA, @TIPO_PALESTRA)
SET @ID_OUT = (SELECT SCOPE_IDENTITY())
RETURN @ID_OUT


/* PROCEDURE PARA INSER��O DE PALESTRA*/
/*DATA DE CRIA��O 28/04/2019 AUTOR= HUGO BARROS*/
go
CREATE PROCEDURE USP_TB_PALESTRA_UPD
@TITULO VARCHAR(100),
@DESCRICAO VARCHAR(200),
@PALESTRANTE VARCHAR(50),
@DATA_PALESTRA DATETIME,
@HORA_PALESTRA TIME,
@TIPO_PALESTRA INT,
@ID_PALESTRA INT
as
UPDATE TB_PALESTRA
SET 
TITULO = @TITULO ,
DESCRICAO  = @DESCRICAO,
PALESTRANTE	 = @PALESTRANTE,
DATA_PALESTRA = @DATA_PALESTRA,
HORA_PALESTRA = @HORA_PALESTRA,
TIPO_PALESTRA = @TIPO_PALESTRA
WHERE ID_PALESTRA = @ID_PALESTRA


go
CREATE TABLE TB_PERFIL
(
	ID INT IDENTITY(1,1) CONSTRAINT PK_TB_PERFIL PRIMARY KEY,
	DE_PERFIL VARCHAR (30)
)

INSERT INTO TB_PERFIL (DE_PERFIL) VALUES ('Administrador')
INSERT INTO TB_PERFIL (DE_PERFIL) VALUES ('Gestor')
INSERT INTO TB_PERFIL (DE_PERFIL) VALUES ('Usu�rio Comum')

go
CREATE TABLE TB_USUARIOS(
 USUA_ID INT IDENTITY(1,1) CONSTRAINT PK_TB_USUARIO PRIMARY KEY,
 USUA_DE_LOGIN VARCHAR (50) NOT NULL,
 USUA_DE_SENHA VARCHAR (100) NOT NULL,
 USUA_ID_PERFIL INT CONSTRAINT FK_TB_USUARIOS_TB_PERFIL REFERENCES TB_PERFIL(ID),
 USUA_DT_ULTIMO_ACESSO DATETIME
 )

  GO
 CREATE PROCEDURE USP_TB_USUARIOS_SEL
	@LOGIN VARCHAR(50),
	@SENHA VARCHAR(100)
	AS
	SELECT USUA_ID, USUA_DE_LOGIN, USUA_DE_SENHA, USUA_ID_PERFIL, USUA_DT_ULTIMO_ACESSO
	FROM TB_USUARIOS
	WHERE USUA_DE_LOGIN = @LOGIN AND USUA_DE_SENHA = @SENHA	
GO

CREATE PROCEDURE USP_TB_USUARIOS_INS
	@DE_LOGIN VARCHAR(50),
	@DE_SENHA VARCHAR(100),
	@ID_PERFIL INT,
	@ID_OUT int output
as 
INSERT INTO TB_USUARIOS
	(USUA_DE_LOGIN,
	USUA_DE_SENHA,
	USUA_ID_PERFIL,
	USUA_DT_ULTIMO_ACESSO) 
VALUES 
	(@DE_LOGIN,
	@DE_SENHA,
	@ID_PERFIL,
	GETDATE())
SET @ID_OUT = (SELECT SCOPE_IDENTITY())
RETURN @ID_OUT


GO
CREATE PROCEDURE USP_TB_USUARIOS_OBTER_TODOS
AS
SELECT USUA_ID, USUA_DE_LOGIN, USUA_DE_SENHA, USUA_DT_ULTIMO_ACESSO, USUA_ID_PERFIL, b.DE_PERFIL 
FROM TB_USUARIOS a
INNER JOIN TB_PERFIL b ON a.USUA_ID_PERFIL = b.ID

GO
CREATE PROCEDURE USP_TB_USUARIO_UPD
@DE_LOGIN VARCHAR(50),
@DE_SENHA VARCHAR(100),
@ID_PERFIL INT,
@ID INT
AS
UPDATE TB_USUARIOS SET 
USUA_DE_LOGIN = @DE_LOGIN,
USUA_DE_SENHA = @DE_SENHA,
USUA_ID_PERFIL = @ID_PERFIL
WHERE USUA_ID = @ID

go
CREATE PROCEDURE USP_TB_USUARIOS_DEL
@ID INT
AS
DELETE FROM TB_USUARIOS
WHERE USUA_ID = @ID

go
INSERT INTO TB_USUARIOS VALUES ('adm', '2c2c2c2c2c2c2c2c2c2c2c2c2c2c2c2c', 1, getdate())