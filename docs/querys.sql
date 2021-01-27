/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [COD_PRODUTO]
      ,[COD_COSIF]
      ,[COD_CLASSIFICACAO]
      ,[STA_STATUS]
  FROM [MovimentosManuais].[dbo].[PRODUTO_COSIF]

  insert into [MovimentosManuais].[dbo].[PRODUTO] values ('0001','descricao produto','1')
insert into [MovimentosManuais].[dbo].[PRODUTO_COSIF] values ('0001','00000000001','123456','1')