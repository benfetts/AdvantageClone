














/* CHANGE LOG:
==========================================================
ST, 20050505:
	- modified the part of query that gets the markup percentage from the product table
	- original code commented out
	- my changes are commented down below also
*/


CREATE PROCEDURE [dbo].[usp_wv_job_new]
--   Job 
	@CL_CODE varchar(6),
	@DIV_CODE varchar(6),
	@PRD_CODE varchar(6),
	@SC_CODE varchar(6),
	@USER_ID varchar(100),
	@JOB_DESC varchar(60),
-- Job Component
	@EMP_CODE varchar(6),
	@JOB_COMP_DESC varchar(60)
AS

SET NOCOUNT ON

Begin Transaction

Declare @NextJobNumber Int
Declare @OfficeCode VarChar(4)
Declare @ProdMarkup Decimal(11,2)
Declare @JobReqEst SmallInt

-- Markup Pct
/* ST:
This is what I found originally:

Select @ProdMarkup = PRD_PROD_MARKUP
From PRODUCT
	Inner Join JOB_LOG
	On PRODUCT.CL_CODE = JOB_LOG.CL_CODE
	AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
	AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
Where JOB_LOG.JOB_NUMBER = 18
*/
/*
ST: I don't see why the joins are needed since it is a new job, a job doesn't exist to join on
	additionally, the next select statement is how he gets the next Job_Number value...can't use one before it's created....?
	unless this was written for use elsewhere...searched entire app for this sproc's name and found only the one instance on the "new job" page, ...JobTemplate_New.aspx
*/
Select @ProdMarkup = ISNULL(PRD_PROD_MARKUP,0)
From PRODUCT
Where 
	PRD_CODE = @PRD_CODE
	AND CL_CODE = @CL_CODE
	AND DIV_CODE = @DIV_CODE

---Get Number
SELECT    @NextJobNumber = LAST_NBR + 1
FROM         ASSIGN_NBR
WHERE     (COLUMNNAME = 'JOB_NUMBER')

--Get Office Code
SELECT @OfficeCode = OFFICE_CODE
FROM PRODUCT
WHERE 
	PRD_CODE = @PRD_CODE
	AND CL_CODE = @CL_CODE
	AND DIV_CODE = @DIV_CODE

--Get Require Estimate flag (Check product, then agency if necessary)
SELECT @JobReqEst = ISNULL(PRD_PROD_ESTIMATE,0)
From PRODUCT
Where 
	PRD_CODE = @PRD_CODE
	AND CL_CODE = @CL_CODE
	AND DIV_CODE = @DIV_CODE

if @JobReqEst = 0
Begin
	SELECT @JobReqEst = ISNULL(APPR_EST_REQ, 0)
	From AGENCY
End

INSERT INTO [dbo].[JOB_LOG] (
	[JOB_NUMBER],
	[CL_CODE],
	[DIV_CODE],
	[PRD_CODE],
	[SC_CODE],
	[USER_ID],
	[JOB_DESC], 
	[OFFICE_CODE],
	[CREATE_DATE],
	[JOB_DATE_OPENED], 
	[JOB_ESTIMATE_REQ]
) 
VALUES (
	@NextJobNumber,
	@CL_CODE,
	@DIV_CODE,
	@PRD_CODE,
	@SC_CODE,
	@USER_ID,
	@JOB_DESC,
	@OfficeCode,
	GetDate(),
	Convert(Varchar(10) , GetDate(), 101), 
	@JobReqEst
)

If @@Error > 0 Goto Error

INSERT INTO [dbo].[JOB_COMPONENT] (
	[JOB_NUMBER],
	[JOB_COMPONENT_NBR],
	[EMP_CODE],
	[JOB_COMP_DESC],
	[JOB_SPEC_TYPE], 
	[JOB_PROCESS_CONTRL],
	[JOB_COMP_DATE],
	JOB_MARKUP_PCT
) 

VALUES (
	@NextJobNumber,
	1,
	@EMP_CODE,
	@JOB_COMP_DESC,
	0,1,
	Convert(Varchar(10) , GetDate(), 101), 
	@ProdMarkup
)

If @@Error > 0 Goto Error

Update ASSIGN_NBR
Set LAST_NBR = @NextJobNumber
WHERE     (COLUMNNAME = 'JOB_NUMBER')

If @@Error > 0 Goto Error
Commit Transaction

Select @NextJobNumber

Error:
Rollback Transaction
--endregion














