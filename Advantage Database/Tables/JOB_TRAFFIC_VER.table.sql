IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[JOB_TRAFFIC_VER]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE [dbo].[JOB_TRAFFIC_VER]
END

/****** Object:  Table [dbo].[JOB_TRAFFIC_VER]    Script Date: 8/9/2013 8:58:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[JOB_TRAFFIC_VER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JOB_NUMBER] [int] NOT NULL,
	[JOB_COMPONENT_NBR] [smallint] NOT NULL,
	[TRF_CODE] [varchar](10) NULL,
	[TRF_PRESET_CODE] [varchar](6) NULL,
	[TRF_COMMENTS] [text] NULL,
	[ASSIGN_1] [varchar](6) NULL,
	[ASSIGN_2] [varchar](6) NULL,
	[ASSIGN_3] [varchar](6) NULL,
	[ASSIGN_4] [varchar](6) NULL,
	[ASSIGN_5] [varchar](6) NULL,
	[COMPLETED_DATE] [smalldatetime] NULL,
	[DATE_DELIVERED] [smalldatetime] NULL,
	[DATE_SHIPPED] [smalldatetime] NULL,
	[RECEIVED_BY] [varchar](40) NULL,
	[REFERENCE] [varchar](150) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
SET ANSI_PADDING ON
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [MGR_EMP_CODE]  AS ([dbo].[udf_get_traffic_mgr]([JOB_NUMBER],[JOB_COMPONENT_NBR]))
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [LOCK_USER] [varchar](100) NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [LOCKED_USER] [varchar](100) NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [PERCENT_COMPLETE] [decimal](7, 3) NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [SCHEDULE_CALC] [int] NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [AUTO_UPDATE_STATUS] [bit] NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_SEQ_NBR] [tinyint] NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_NAME] [varchar](256) NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_COMMENT] [varchar](max) NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_ACTIVE_FLAG] [bit] NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_IS_CURRENT] [bit] NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_CREATED_BY_USER_CODE] [varchar](100) NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_CREATED] [smalldatetime] NULL
ALTER TABLE [dbo].[JOB_TRAFFIC_VER] ADD [VER_CREATED_COMMENT] [varchar](max) NULL
 CONSTRAINT [PK_JOB_TRAFFIC_VER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[JOB_TRAFFIC_VER]  WITH CHECK ADD  CONSTRAINT [FK_JOB_TRAFFIC_VER_TRAFFIC] FOREIGN KEY([TRF_CODE])
REFERENCES [dbo].[TRAFFIC] ([TRF_CODE])
GO

ALTER TABLE [dbo].[JOB_TRAFFIC_VER] CHECK CONSTRAINT [FK_JOB_TRAFFIC_VER_TRAFFIC]
GO
