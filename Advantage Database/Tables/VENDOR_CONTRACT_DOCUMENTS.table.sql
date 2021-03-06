CREATE TABLE [dbo].[VENDOR_CONTRACT_DOCUMENTS](
	[VENDOR_CONTRACT_DOCUMENTS_ID] [int] IDENTITY(1,1) NOT NULL,
	[VENDOR_CONTRACT_ID] [int] NOT NULL,
	[DOCUMENT_ID] [int] NOT NULL,
 CONSTRAINT [PK_VENDOR_CONTRACT_DOCUMENTS] PRIMARY KEY CLUSTERED 
(
	[VENDOR_CONTRACT_DOCUMENTS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_VENDOR_CONTRACT_DOCUMENTS_CONTRACT] FOREIGN KEY([VENDOR_CONTRACT_ID])
REFERENCES [dbo].[VENDOR_CONTRACT] ([VENDOR_CONTRACT_ID])
GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_DOCUMENTS] CHECK CONSTRAINT [FK_VENDOR_CONTRACT_DOCUMENTS_CONTRACT]
GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_VENDOR_CONTRACT_DOCUMENTS_DOCUMENT] FOREIGN KEY([DOCUMENT_ID])
REFERENCES [dbo].[DOCUMENTS] ([DOCUMENT_ID])
GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_DOCUMENTS] CHECK CONSTRAINT [FK_VENDOR_CONTRACT_DOCUMENTS_DOCUMENT]
GO
