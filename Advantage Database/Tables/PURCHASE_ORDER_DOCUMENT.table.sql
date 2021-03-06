CREATE TABLE [dbo].[PURCHASE_ORDER_DOCUMENT](
	[DOCUMENT_ID] [int] NOT NULL,
	[PO_NUMBER] [int] NOT NULL,
 CONSTRAINT [PK_PURCHASE_ORDER_DOCUMENT] PRIMARY KEY CLUSTERED 
(
	[DOCUMENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PURCHASE_ORDER_DOCUMENT]  WITH NOCHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_DOCUMENT_DOCUMENTS] FOREIGN KEY([DOCUMENT_ID])
REFERENCES [dbo].[DOCUMENTS] ([DOCUMENT_ID])
GO

ALTER TABLE [dbo].[PURCHASE_ORDER_DOCUMENT] CHECK CONSTRAINT [FK_PURCHASE_ORDER_DOCUMENT_DOCUMENTS]
GO

ALTER TABLE [dbo].[PURCHASE_ORDER_DOCUMENT]  WITH NOCHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_DOCUMENT_PURCHASE_ORDER] FOREIGN KEY([PO_NUMBER])
REFERENCES [dbo].[PURCHASE_ORDER] ([PO_NUMBER])
GO

ALTER TABLE [dbo].[PURCHASE_ORDER_DOCUMENT] CHECK CONSTRAINT [FK_PURCHASE_ORDER_DOCUMENT_PURCHASE_ORDER]
GO


