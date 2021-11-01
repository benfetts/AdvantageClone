IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROOFING_STATUS]') AND type in (N'U'))
BEGIN
	DROP TABLE [dbo].[PROOFING_STATUS]
END
GO
CREATE TABLE [dbo].[PROOFING_STATUS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](50) NOT NULL,
	[IS_USER_DEFINED] [bit] NOT NULL,
	[IS_INACTIVE] [bit] NOT NULL,
	[SEQ_NBR] [smallint] NULL,
	[COLOR_CODE] [varchar](7) NULL,
 CONSTRAINT [PK_PROOFING_STATUS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PROOFING_STATUS] ADD  CONSTRAINT [DF_PROOFING_STATUS_IS_USER_DEFINED]  DEFAULT ((0)) FOR [IS_USER_DEFINED]
GO

ALTER TABLE [dbo].[PROOFING_STATUS] ADD  CONSTRAINT [DF_PROOFING_STATUS_IS_INACTIVE]  DEFAULT ((0)) FOR [IS_INACTIVE]
GO


