CREATE TABLE [dbo].[MEDIA_PLAN_DTL](
	[MEDIA_PLAN_DTL_ID] [int] IDENTITY(1,1) NOT NULL,
	[MEDIA_PLAN_ID] [int] NOT NULL,
	[SC_TYPE] [varchar](1) NOT NULL,
	[SC_CODE] [varchar](6) NOT NULL,
	[IS_ESTIMATE_GROSS] [bit] NOT NULL,
	[IS_CALENDAR_MONTH] [bit] NOT NULL,
	[INCLUDE_PRIM_DEMO] [bit] NOT NULL,
	[INCLUDE_SEC_DEMO] [bit] NOT NULL,
	[ENTER_BY_MONTH] [bit] NOT NULL,
	[TOTAL_FLAG] [bit] NOT NULL,
	[COLOR] [int] NOT NULL,
	[NOTES] [varchar](100) NULL,
	[USER_CREATED] [varchar](100) NOT NULL,
	[CREATED_DATE] [smalldatetime] NOT NULL,
	[USER_MODIFIED] [varchar](100) NULL,
	[MODIFIED_DATE] [smalldatetime] NULL,
 CONSTRAINT [PK_MEDIA_PLAN_DTL] PRIMARY KEY CLUSTERED 
(
	[MEDIA_PLAN_DTL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_DTL_MEDIA_PLAN] FOREIGN KEY([MEDIA_PLAN_ID])
REFERENCES [dbo].[MEDIA_PLAN] ([MEDIA_PLAN_ID])
GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL] CHECK CONSTRAINT [FK_MEDIA_PLAN_DTL_MEDIA_PLAN]
GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL]  WITH CHECK ADD  CONSTRAINT [FK_MEDIA_PLAN_DTL_SALES_CLASS] FOREIGN KEY([SC_CODE])
REFERENCES [dbo].[SALES_CLASS] ([SC_CODE])
GO

ALTER TABLE [dbo].[MEDIA_PLAN_DTL] CHECK CONSTRAINT [FK_MEDIA_PLAN_DTL_SALES_CLASS]
GO


