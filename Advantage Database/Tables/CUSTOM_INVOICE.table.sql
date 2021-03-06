CREATE TABLE [dbo].[CUSTOM_INVOICE](
	[CUSTOM_INVOICE_ID] [int] IDENTITY(1,1) NOT NULL,
	[TYPE] [int] NOT NULL,
	[DESCRIPTION] [varchar](50) NOT NULL,
	[CREATED_BY] [varchar](100) NOT NULL,
	[CREATED_DATE] [smalldatetime] NOT NULL,
	[UPDATED_BY] [varchar](100) NOT NULL,
	[UPDATED_DATE] [smalldatetime] NOT NULL,
	[REPORT_DEF] [varchar](max) NOT NULL,
 CONSTRAINT [PK_CUSTOM_INVOICE] PRIMARY KEY CLUSTERED 
(
	[CUSTOM_INVOICE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
