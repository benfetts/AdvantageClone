IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PC_BATCH_INVOICE') BEGIN

CREATE TABLE [dbo].[PC_BATCH_INVOICE](
	[BATCH_ID] [int] NOT NULL,
	[USER_ID] [varchar](6) NOT NULL,
	[AP_ID] [int] NOT NULL,
	[INVOICE_NUMBER] [varchar](20) NULL,
	[PAYMENT_TYPE] [varchar](10) NULL,
	[INVOICE_TYPE] [varchar](50) NULL,
	[APPROVED_AMOUNT] [decimal](14, 2) NULL,
	[DISC_APPROVED_AMOUNT] [decimal](14, 2) NULL
) ON [PRIMARY]
END
GO
