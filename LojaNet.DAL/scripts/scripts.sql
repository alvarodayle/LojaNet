--Criando o banco de dados

CREATE DATABASE LojaNetDb;
GO

--Criando as tabelas

USE LojaNetDb;
GO

CREATE TABLE Cliente (
	Id varchar(50) PRIMARY KEY,
	Nome varchar(100),
	Email varchar(100),
	Telefone varchar(100)
);
GO

CREATE TABLE Pedido
(
	Id int Primary key identity(1,1),
	Data DateTime,
	ClienteId varchar(50),
	FormaPagamentoID int
)
GO

CREATE TABLE PedidoItem
(
	PedidoId int,
	Ordem int,
	ProdutoId varchar(50),
	Quantidade int,
	Preco money,
	Primary Key (PedidoId, Ordem)
)
GO

--Criando as procedures

CREATE PROCEDURE ClienteIncluir
	@Id varchar(50),
	@Nome varchar(100),
	@Email varchar(100),
	@Telefone varchar(100)


AS

INSERT INTO Cliente (Id, Nome, Email, Telefone)
VALUES (@Id, @Nome, @Email, @Telefone)

GO



CREATE PROCEDURE ClienteListar

AS

SELECT Id, Nome, Email, Telefone 
FROM Cliente

GO


CREATE PROCEDURE ClienteExcluir
	@Id varchar(50)

AS

DELETE FROM Cliente WHERE Id=@Id

GO


CREATE PROCEDURE ClienteObterPorId
	@Id varchar(50)

AS

SELECT Id, Nome, Email, Telefone
FROM Cliente
WHERE Id=@Id

GO

CREATE PROCEDURE ClienteObterPorEmail
	@Email varchar(100)

AS

SELECT Id, Nome, Email, Telefone
FROM Cliente
WHERE Email=@Email

GO

CREATE PROCEDURE ClienteAlterar
	@Id varchar(50),
	@Nome varchar(100),
	@Email varchar(100),
	@Telefone varchar(100)

AS

UPDATE Cliente
SET Nome=@Nome, Email=@Email, Telefone=@Telefone
WHERE Id=@Id

GO

CREATE PROCEDURE PedidoIncluir

	@Data DateTime,
	@ClienteId varchar(50)

AS

	INSERT INTO Pedido(Data, ClienteId)
	VALUES(@Data, @ClienteId)

	SELECT @@IDENTITY;

GO

CREATE PROCEDURE PedidoItemIncluir

	@PedidoId int,
	@Ordem int,
	@ProdutoId varchar(50),
	@Quantidade int,
	@Preco money

AS

	INSERT INTO PedidoItem (PedidoId, Ordem, ProdutoId, Quantidade, Preco)
	VALUES (@PedidoId, @Ordem, @ProdutoId, @Quantidade, @Preco)

GO

CREATE Procedure [dbo].[PedidoAlterar]
@Id int,
@Data DateTime,
@ClienteId varchar(50),
@FormaPagamentoId int

as

UPDATE Pedido set 
	ClienteId=@ClienteID, FormaPagamentoId=@FormaPagamentoId
Where Id=@Id

GO

Create Procedure [dbo].[PedidoExcluir]
@Id int

as

DELETE FROM PedidoItem Where PedidoId=@Id;
DELETE FROM Pedido Where Id=@Id;
GO

CREATE Procedure [dbo].[PedidoItemAlterar]

@PedidoId int,
@Ordem int,
@ProdutoId varchar(50),
@Quantidade int ,
@Preco money

as 

Update PedidoItem Set ProdutoId=@ProdutoId, Quantidade=@Quantidade, Preco=@Preco
Where PedidoId=@PedidoId and Ordem=@Ordem
GO

CREATE Procedure [dbo].[PedidoItemExcluir]

@PedidoId int,
@Ordem int

as 

DELETE FROM PedidoItem Where PedidoId=@PedidoId and Ordem=@Ordem
GO

CREATE Procedure [dbo].[PedidoItemExcluirExtras]

@PedidoId int,
@Ordem int

as 

DELETE FROM PedidoItem Where PedidoId=@PedidoId and Ordem>@Ordem
GO

CREATE Procedure [dbo].[PedidoItemObterPorPedidoId]

@PedidoId int


as 

Select PedidoItem.PedidoId, PedidoItem.Ordem, PedidoItem.ProdutoId,PedidoItem.Quantidade, PedidoItem.Preco, Produtoes.Nome ProdutoNome
FROM PedidoItem
  INNER JOIN Produtoes on Produtoes.Id=PedidoItem.ProdutoId
Where PedidoId=@PedidoId
Order By PedidoItem.Ordem
GO

CREATE Procedure [dbo].[PedidoListar]

as

Select Pedido.Id, Pedido.ClienteId, Pedido.FormaPagamentoId, Pedido.Data, Cliente.Nome as ClienteNome
FROM Pedido
 INNER JOIN Cliente ON Cliente.Id=Pedido.ClienteId


GO
CREATE Procedure [dbo].[PedidoObterPorId]
@Id int

as

Select Pedido.Id, PEdido.ClienteId, Pedido.FormaPagamentoId, Pedido.Data, Cliente.Nome ClienteNome
FROM Pedido
  INNER JOIN Cliente ON Cliente.Id=Pedido.ClienteId
Where Pedido.Id=@Id