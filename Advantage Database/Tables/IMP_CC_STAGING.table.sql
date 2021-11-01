CREATE TABLE [dbo].[IMP_CC_STAGING](
	[ROW_ID] [int] IDENTITY(1,1) NOT NULL,
	[BATCH_NAME] [varchar](50) NOT NULL,
	[ACCOUNT_NUMBER] [varchar](30) NULL,
	[EMP_CODE] [varchar](6) NULL,
	[EMP_FNAME] [varchar](30) NULL,
	[EMP_LNAME] [varchar](30) NULL,
	[EXP_DATE] [datetime] NULL,
	[EXP_DESC] [varchar](30) NULL,
	[EXP_DTL] [text] NULL,
	[ITEM_DATE] [datetime] NULL,
	[CL_CODE] [varchar](6) NULL,
	[DIV_CODE] [varchar](6) NULL,
	[PRD_CODE] [varchar](6) NULL,
	[JOB_NUMBER] [int] NULL,
	[JOB_COMPONENT_NUMBER] [smallint] NULL,
	[FNC_CODE] [varchar](6) NULL,
	[QTY] [int] NULL,
	[RATE] [decimal](10, 3) NULL,
	[AMOUNT] [decimal](10, 3) NULL,
	[CC_FLAG] [bit] NULL,
 CONSTRAINT [PK_IMP_CC_STAGING] PRIMARY KEY CLUSTERED 
(
	[ROW_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]