IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PC_TRANS_STATUS_CODE') BEGIN

CREATE TABLE [dbo].[PC_TRANS_STATUS_CODE](
	[TRANS_STATUS_CODE] [nvarchar](3) NULL,
	[TRANS_STATUS_DESC] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
