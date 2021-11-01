IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PC_BATCH_STATUS_CODE') BEGIN

CREATE TABLE [dbo].[PC_BATCH_STATUS_CODE](
	[STATUS_CODE] [varchar](1) NOT NULL,
	[STATUS_CODE_DESC] [varchar](9) NOT NULL
) ON [PRIMARY]

END
GO

