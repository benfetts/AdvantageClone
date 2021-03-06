--GO
--GO
--GO
CREATE TABLE [dbo].[CONTRACT_DOCUMENTS](
	[CONTRACT_DOCUMENTS_ID] [int] IDENTITY(1,1) NOT NULL,
	[CONTRACT_ID] [int] NOT NULL,
	[DOCUMENT_ID] [int] NOT NULL,
 CONSTRAINT [PK_CONTRACT_DOCUMENTS] PRIMARY KEY CLUSTERED 
(
	[CONTRACT_DOCUMENTS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CONTRACT_DOCUMENTS] ADD CONSTRAINT [FK_CONTRACT_DOCUMENTS_CONTRACT]
	FOREIGN KEY([CONTRACT_ID]) REFERENCES [dbo].[CONTRACT] ([CONTRACT_ID])
GO

ALTER TABLE [dbo].[CONTRACT_DOCUMENTS] ADD CONSTRAINT [FK_CONTRACT_DOCUMENTS_DOCUMENT]
	FOREIGN KEY([DOCUMENT_ID]) REFERENCES [dbo].DOCUMENTS ([DOCUMENT_ID])
GO
