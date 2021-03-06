CREATE TABLE [dbo].[VENDOR_CONTRACT_CONTACTS](
	[VENDOR_CONTRACT_CONTACT_ID] [int] IDENTITY(1,1) NOT NULL,
	[VENDOR_CONTRACT_ID] [int] NOT NULL,
	[EMP_CODE] [varchar](6) NOT NULL,
	[INCLUDE_IN_ALERT] [bit] NOT NULL,
 CONSTRAINT [PK_VENDOR_CONTRACT_CONTACTS] PRIMARY KEY CLUSTERED 
(
	[VENDOR_CONTRACT_CONTACT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[VENDOR_CONTRACT_ID] ASC,
	[EMP_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_CONTACTS]  WITH CHECK ADD  CONSTRAINT [FK_VENDOR_CONTRACT_CONTACTS_CONTRACT] FOREIGN KEY([VENDOR_CONTRACT_ID])
REFERENCES [dbo].[VENDOR_CONTRACT] ([VENDOR_CONTRACT_ID])
GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_CONTACTS] CHECK CONSTRAINT [FK_VENDOR_CONTRACT_CONTACTS_CONTRACT]
GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_CONTACTS]  WITH CHECK ADD  CONSTRAINT [FK_VENDOR_CONTRACT_CONTACTS_EMP_CODE] FOREIGN KEY([EMP_CODE])
REFERENCES [dbo].[EMPLOYEE_CLOAK] ([EMP_CODE])
GO

ALTER TABLE [dbo].[VENDOR_CONTRACT_CONTACTS] CHECK CONSTRAINT [FK_VENDOR_CONTRACT_CONTACTS_EMP_CODE]
GO