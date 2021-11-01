if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Creative_Brief_Approval_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Creative_Brief_Approval_Update]
GO

CREATE PROCEDURE [dbo].[usp_wv_Creative_Brief_Approval_Update] 
@JobNum Int,
@JobCompNum SmallInt,
@ApprovedBy varchar(40),
@ApprovedComment varchar(MAX),
@UserCode varchar(100),
@ApprovalDate SMALLDATETIME,
@IsCP bit,
@CP_ID int

AS


if @IsCP = 1
BEGIN
	UPDATE CRTV_BRF_APPR 
	SET CB_APPR_COMMENT = @ApprovedComment,CB_APPR_USER_ID = '', CB_APPR_BY = @ApprovedBy, CB_APPR_DATE = @ApprovalDate
	WHERE JOB_NUMBER = @JobNum AND JOB_COMPONENT_NBR = @JobCompNum	
END
ELSE
BEGIN
	UPDATE CRTV_BRF_APPR 
	SET CB_APPR_COMMENT = @ApprovedComment,CB_APPR_USER_ID = @UserCode, CB_APPR_BY = @ApprovedBy, CB_APPR_DATE = @ApprovalDate
	WHERE JOB_NUMBER = @JobNum AND JOB_COMPONENT_NBR = @JobCompNum	
END


 







