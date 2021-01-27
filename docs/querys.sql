/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [COD_PRODUTO]
      ,[COD_COSIF]
      ,[COD_CLASSIFICACAO]
      ,[STA_STATUS]
  FROM [MovimentosManuais].[dbo].[PRODUTO_COSIF]

  insert into [MovimentosManuais].[dbo].[PRODUTO] values ('0001','descricao produto','1');
insert into [MovimentosManuais].[dbo].[PRODUTO_COSIF] values ('0001','00000000001','123456','1');

USE [MovimentosManuais]
GO

INSERT INTO [dbo].[MOVIMENTO_MANUAL]
           ([DAT_MES]
           ,[DAT_ANO]
           ,[NUM_LANCAMENTO]
           ,[COD_PRODUTO]
           ,[COD_COSIF]
           ,[DES_DESCRICAO]
           ,[DAT_MOVIMENTO]
           ,[COD_USUARIO]
           ,[VAL_VALOR])
     VALUES
           (05
           ,1994
           ,01
           ,'0001'
           ,'00000000001'
           ,'Descricao movimento'
           ,'2021-01-27T02:26:02'
           ,'1234567890'
           ,10.6
		   );
GO

