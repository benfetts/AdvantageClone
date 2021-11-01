IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PC_PAYMENT_TYPE') BEGIN

CREATE TABLE [dbo].[PC_PAYMENT_TYPE](
	[PAYMENT_TYPE] [varchar](10) NOT NULL,
	[PAYMENT_TYPE_DESC] [varchar](50) NOT NULL
) ON [PRIMARY]
END
GO
