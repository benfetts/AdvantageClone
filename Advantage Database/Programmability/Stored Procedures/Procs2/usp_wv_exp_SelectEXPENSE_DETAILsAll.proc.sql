﻿























--region [dbo].[usp_wv_exp_SelectEXPENSE_DETAILsAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   smoreno using CodeSmith 3.0.5.387
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_wv_exp_SelectEXPENSE_DETAILsAll]
-- Date Generated: Tuesday, February 21, 2006
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_wv_exp_SelectEXPENSE_DETAILsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[EXPDETAILID],
	[INV_NBR],
	[LINE_NBR],
	[ITEM_DATE],
	[ITEM_DESC],
	[CC_FLAG],
	[CL_CODE],
	[DIV_CODE],
	[PRD_CODE],
	[JOB_NBR],
	[JOB_COMP_NBR],
	[FNC_CODE],
	[QTY],
	[RATE],
	[CC_AMT],
	[AMOUNT],
	[AP_COMMENT],
	[CREATE_USER_ID],
	[MOD_USER_ID],
	[MOD_DATE]
FROM
	[dbo].[EXPENSE_DETAIL]
Where LINE_NBR > 0
--endregion



















