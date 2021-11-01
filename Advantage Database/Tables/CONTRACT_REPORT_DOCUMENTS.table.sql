CREATE TABLE [dbo].[CONTRACT_REPORT_DOCUMENTS](
	[CONTRACT_REPORT_DOCUMENTS_ID] [int] IDENTITY(1,1) NOT NULL,
	[CONTRACT_REPORT_ID] [int] NOT NULL,
	[DOCUMENT_ID] [int] NOT NULL,
 CONSTRAINT [PK_CONTRACT_REPORT_DOCUMENTS] PRIMARY KEY CLUSTERED 
(
	[CONTRACT_REPORT_DOCUMENTS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CONTRACT_REPORT_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_CONTRACT_REPORT_DOCUMENTS_CONTRACT] FOREIGN KEY([CONTRACT_REPORT_ID])
REFERENCES [dbo].[CONTRACT_REPORT] ([CONTRACT_REPORT_ID])
GO

ALTER TABLE [dbo].[CONTRACT_REPORT_DOCUMENTS] CHECK CONSTRAINT [FK_CONTRACT_REPORT_DOCUMENTS_CONTRACT]
GO

ALTER TABLE [dbo].[CONTRACT_REPORT_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_CONTRACT_REPORT_DOCUMENTS_DOCUMENT] FOREIGN KEY([DOCUMENT_ID])
REFERENCES [dbo].[DOCUMENTS] ([DOCUMENT_ID])
GO

ALTER TABLE [dbo].[CONTRACT_REPORT_DOCUMENTS] CHECK CONSTRAINT [FK_CONTRACT_REPORT_DOCUMENTS_DOCUMENT]
GO


