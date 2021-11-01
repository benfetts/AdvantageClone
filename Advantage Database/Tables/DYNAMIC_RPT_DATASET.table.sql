﻿IF NOT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DYNAMIC_RPT_DATASET') BEGIN

CREATE TABLE [dbo].[DYNAMIC_RPT_DATASET](
	[DYNAMIC_RPT_DS_ID] [int] IDENTITY(1,1) NOT NULL,
	[DYNAMIC_REPORT_TYPE] [int] NOT NULL,
	[LAST_UPDATED] [smalldatetime] NULL,
	[UPDATED_BY] [varchar](100) NULL
 CONSTRAINT [PK_DYNAMIC_RPT_DATASET] PRIMARY KEY CLUSTERED 
(
	[DYNAMIC_RPT_DS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

END
GO