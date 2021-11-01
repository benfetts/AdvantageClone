--9
IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MEDIA_PLAN_ESTIMATE_TEMPLATE') BEGIN

	CREATE TABLE [dbo].[MEDIA_PLAN_ESTIMATE_TEMPLATE](
		[MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] [int] IDENTITY(1,1) NOT NULL,
		[TYPE] [char](1) NOT NULL,
        [DESCRIPTION] [varchar](100) NOT NULL,
        [GOALS] [varchar](250) NOT NULL,        
        [IS_INACTIVE] [bit] NOT NULL,
        [IS_SYSTEM] [bit] NOT NULL,
	CONSTRAINT [PK_MEDIA_PLAN_ESTIMATE_TEMPLATE] PRIMARY KEY CLUSTERED 
	(
		[MEDIA_PLAN_ESTIMATE_TEMPLATE_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
	) ON [PRIMARY]

END
GO