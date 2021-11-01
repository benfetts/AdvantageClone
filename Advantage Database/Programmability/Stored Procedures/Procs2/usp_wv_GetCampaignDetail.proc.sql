/****** Object:  StoredProcedure [dbo].[usp_wv_GetCampaignDetail]    Script Date: 3/21/2019 1:30:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/*
	exec usp_wv_GetCampaignDetail 86, 1
*/
create procedure [dbo].[usp_wv_GetCampaignDetail](
	@CampaignID as INTEGER,
	@ID as smallint
	)
as
BEGIN

	select cd.CMP_IDENTIFIER CampaignID
			,cd.LINE_NBR ID
			,cd.SC_CODE SalesClassCode
			,SC_DESCRIPTION SalesClassDesc
			,cd.POST_PERIOD PostPeriodCode
			,POSTPERIOD.PPDESC PostPeriodDesc
			,cd.DTL_CMP_TYPE CampaignDetailTypeCode
			,cd.DTL_CMP_TYPE CampaignDetailTypeDesc
			,cd.DP_TM_CODE DepartmentTeamCode
			,DEPT_TEAM.DP_TM_DESC DepartmentTeamDesc
			,cd.CMP_BILL_BUDGET BillingBudgetAmount
			,cd.CMP_INC_BUDGET IncomeBudgetAmount
			,cd.FNC_CODE FunctionCode
			,FUNCTIONS.FNC_DESCRIPTION FunctionDesc
			,cd.LAST_REV_DATE RevisedDate
			,cd.USER_ID UserCode
		from CAMPAIGN_DETAIL cd
			left join SALES_CLASS on SALES_CLASS.SC_CODE = cd.SC_CODE
			left join POSTPERIOD on POSTPERIOD.PPPERIOD = cd.POST_PERIOD
			left join DEPT_TEAM on DEPT_TEAM.DP_TM_CODE = cd.DP_TM_CODE
			left join FUNCTIONS on FUNCTIONS.FNC_CODE = cd.FNC_CODE
		where cd.CMP_IDENTIFIER = @CampaignID and cd.LINE_NBR = @ID
END



GO