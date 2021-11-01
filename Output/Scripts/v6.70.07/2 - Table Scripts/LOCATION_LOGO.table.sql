IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'LOCATION_LOGO')
BEGIN

	CREATE TABLE [dbo].[LOCATION_LOGO](
		[LOCATION_LOGO_ID] [INT] IDENTITY(1,1) NOT NULL,
		[LOCATION_ID] [VARCHAR](6) NOT NULL,
		[LOCATION_LOGO_TYPE_ID] [INT] NOT NULL,
		[IMAGE] [IMAGE] NOT NULL,
		[THUMBNAIL] [IMAGE] NULL,
		[IS_ACTIVE] [BIT] NOT NULL,
		[CREATE_DATE] [SMALLDATETIME] NOT NULL,
		[USER_CODE] [VARCHAR](100) NOT NULL
	 CONSTRAINT [PK_LOCATION_LOGO] PRIMARY KEY CLUSTERED 
	(
		[LOCATION_LOGO_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

END
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LOCATION_LOGO_LOCATIONS]') AND parent_object_id = OBJECT_ID(N'[dbo].[LOCATION_LOGO]'))
BEGIN

	ALTER TABLE [dbo].[LOCATION_LOGO]  WITH CHECK ADD  CONSTRAINT [FK_LOCATION_LOGO_LOCATIONS] FOREIGN KEY([LOCATION_ID]) REFERENCES [dbo].[LOCATIONS] ([ID]);
	ALTER TABLE [dbo].[LOCATION_LOGO] CHECK CONSTRAINT [FK_LOCATION_LOGO_LOCATIONS];

END
GO

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LOCATION_LOGO_LOCATION_LOGO_TYPE]') AND parent_object_id = OBJECT_ID(N'[dbo].[LOCATION_LOGO]'))
BEGIN

	ALTER TABLE [dbo].[LOCATION_LOGO]  WITH CHECK ADD  CONSTRAINT [FK_LOCATION_LOGO_LOCATION_LOGO_TYPE] FOREIGN KEY([LOCATION_LOGO_TYPE_ID]) REFERENCES [dbo].[LOGO_TYPE] ([LOCATION_LOGO_TYPE_ID]);
	ALTER TABLE [dbo].[LOCATION_LOGO] CHECK CONSTRAINT [FK_LOCATION_LOGO_LOCATION_LOGO_TYPE];

END
GO
