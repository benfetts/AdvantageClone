
/****** Object:  Table [dbo].[EST_PRINT_DEF]    Script Date: 11/12/2014 10:21:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[EST_PRINT_DEF](
	[EST_PRINT_DEF_ID] [int] IDENTITY(1,1) NOT NULL,
	[CLIENT_OR_DEF] [smallint] NULL,
	[CL_CODE] [varchar](6) NULL,
	[DIV_CODE] [varchar](6) NULL,
	[PRD_CODE] [varchar](6) NULL,
	[SELECT_BY] [varchar](2) NULL,
	[DATE_TO_PRINT] [smallint] NULL,
	[TAX_SEPARATE] [smallint] NULL,
	[TAX_INDICATOR] [smallint] NULL,
	[COMM_MU_SEPARATE] [smallint] NULL,
	[COMM_MU_INDICATOR] [smallint] NULL,
	[FUNCTION_OPTION] [varchar](2) NULL,
	[GROUP_OPTION] [varchar](2) NULL,
	[SORT_OPTION] [varchar](2) NULL,
	[INSIDE_CHG_DESC] [varchar](30) NULL,
	[OUTSIDE_CHG_DESC] [varchar](30) NULL,
	[EST_COMMENT] [smallint] NULL,
	[EST_COMP_COMMENT] [smallint] NULL,
	[QTE_COMMENT] [smallint] NULL,
	[REV_COMMENT] [smallint] NULL,
	[FUNC_COMMENT] [smallint] NULL,
	[DEF_FOOTER_COMMENT] [smallint] NULL,
	[CLI_REF] [smallint] NULL,
	[AE_NAME] [smallint] NULL,
	[PRT_SALES_CLASS] [smallint] NULL,
	[SPECS] [smallint] NULL,
	[JOB_QTY] [smallint] NULL,
	[CONTINGENCY] [smallint] NULL,
	[SUPPRESS_ZERO] [smallint] NULL,
	[LOCATION_ID] [varchar](6) NULL,
	[LOGO_PATH] [varchar](254) NULL,
	[REPORT_FORMAT] [varchar](50) NULL,
	[PRT_NONBILL] [smallint] NULL,
	[PRT_DIV_NAME] [smallint] NULL,
	[PRT_PRD_NAME] [smallint] NULL,
	[QTY_HRS] [smallint] NULL,
	[CONSOL_OVERRIDE] [smallint] NULL,
	[SUBTOT_ONLY] [smallint] NULL,
	[PRT_CPU] [smallint] NULL,
	[PRT_CPM] [smallint] NULL,
	[RPT_TITLE] [varchar](30) NULL,
	[SUP_BY_NOTES] [smallint] NULL,
	[CONT_SEPARATE] [smallint] NULL,
	[SIGNATURE] [smallint] NULL,
	[HIDE_COMP_DESC] [smallint] NULL,
	[HIDE_REVISION] [smallint] NULL,
	[JOB_DUE_DATE] [smallint] NULL,
	[USE_EMP_SIG] [smallint] NULL,
	[EXCL_EMP_TIME] [smallint] NULL,
	[EXCL_VENDOR] [smallint] NULL,
	[EXCL_IO] [smallint] NULL,
	[EXCL_SIGNATURES] [int] NULL,
	[CMP_SUMMARY] [int] NULL,
	[VENDOR_DESC] [int] NULL,
	[EXCL_NONBILL] [smallint] NULL,
	[CDP_ADDRESS] [varchar](10) NULL,
	[INCL_RATE] [smallint] NULL,
	[COMBINE_COMPS] [smallint] NULL,
	[PRT_CL_NAME] [smallint] NULL,
	[FNC_COMMENT] [smallint] NULL,
 CONSTRAINT [PK_EST_PRT_DEF] PRIMARY KEY CLUSTERED 
(
	[EST_PRINT_DEF_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


