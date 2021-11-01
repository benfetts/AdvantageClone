
/* Create ESTIMATE_REV_DET_API_TYPE */

--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_estimate_add_update_api]') AND type in (N'P', N'PC'))
--DROP PROCEDURE [dbo].[advsp_estimate_add_update_api]
--GO


IF TYPE_ID(N'ESTIMATE_REV_DET_API_TYPE') IS NOT NULL
	DROP TYPE [dbo].[ESTIMATE_REV_DET_API_TYPE]
GO

CREATE TYPE [dbo].[ESTIMATE_REV_DET_API_TYPE] AS TABLE
(	[ID] int, /* Unique Sequence 1,2,3,4,... */
	[FNC_CODE] [varchar](6) NULL,
	[EST_REV_COMM_PCT] [decimal](9, 3) NULL,
	[EST_REV_COMM_AMT] [decimal](15, 2) NULL,
	[EST_REV_QUANTITY] [decimal](15, 2) NULL,
	[EST_REV_RATE] [decimal](15, 4) NULL,
	[EST_REV_EXT_AMT] [decimal](15, 2) NULL,
	[EST_FNC_COMMENT] [varchar] (255)
) 
GO

GRANT EXECUTE ON TYPE::[ESTIMATE_REV_DET_API_TYPE] TO PUBLIC AS dbo
GO