IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'MEDIA_PRINT_DEF' AND COLUMN_NAME = 'NP_INCLUDE_CIRC_QTY') BEGIN

    ALTER TABLE [dbo].[MEDIA_PRINT_DEF] ADD [NP_INCLUDE_CIRC_QTY] [bit] NOT NULL DEFAULT(0);
	
END
GO