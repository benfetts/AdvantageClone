if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Creative_Brief_Approval_Add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Creative_Brief_Approval_Add]
GO

CREATE PROCEDURE [dbo].[usp_wv_Creative_Brief_Approval_Add] 
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
	INSERT INTO CRTV_BRF_APPR (JOB_NUMBER, JOB_COMPONENT_NBR, CB_APPR_BY, CB_APPR_COMMENT, CB_APPR_USER_ID, CB_APPR_DATE, CB_APPR_USER_ID_CP)
	VALUES (@JobNum, @JobCompNum, @ApprovedBy, @ApprovedComment, '', @ApprovalDate, @CP_ID)
END
ELSE
BEGIN
	INSERT INTO CRTV_BRF_APPR (JOB_NUMBER, JOB_COMPONENT_NBR, CB_APPR_BY, CB_APPR_COMMENT, CB_APPR_USER_ID, CB_APPR_DATE, CB_APPR_USER_ID_CP)
	VALUES (@JobNum, @JobCompNum, @ApprovedBy, @ApprovedComment, @UserCode, @ApprovalDate, NULL)
END


 







