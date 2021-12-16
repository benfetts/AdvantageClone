IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH') BEGIN
    CREATE TABLE [dbo].[MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH](
	    [MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID] [int] IDENTITY(1,1) NOT NULL,
	    [USER_CODE] [varchar](100) NOT NULL,
	    [CRITERIA_NAME] [varchar](30) NOT NULL,
	    [REPORT_TYPE] [smallint] NOT NULL,
	    [MAX_RANK] [smallint] NULL,
	    [SHOW_PROGRAM_NAME] [bit] NOT NULL,
	    [GROUP_BY_DAYS_TIMES] [bit] NOT NULL,
	    [SUBTOTAL_BY_WEEKDAY_WEEKEND] [bit] NOT NULL,
        [SHARE_START_DATE] [smalldatetime] NULL,
        [SHARE_END_DATE] [smalldatetime] NULL,
        [HPUT_START_DATE] [smalldatetime] NULL,
        [HPUT_END_DATE] [smalldatetime] NULL,
     CONSTRAINT [PK_MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH] PRIMARY KEY CLUSTERED 
    (
	    [MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO