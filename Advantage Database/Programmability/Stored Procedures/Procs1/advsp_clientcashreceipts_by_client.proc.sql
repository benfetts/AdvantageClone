CREATE PROC [dbo].[advsp_clientcashreceipts_by_client]
	@ClientCode varchar(6), @UserCode varchar(100)
AS

BEGIN
	DECLARE @EmployeeCode varchar(6),
			@HasOfficeLimits bit

	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@UserCode)

	IF (SELECT COUNT(1) FROM dbo.advtf_employee_office_limits(@EmployeeCode)) > 0
		SET @HasOfficeLimits = 1
	ELSE
		SET @HasOfficeLimits = 0

	SELECT
		ID = cc.REC_ID,
		SequenceNumber = cc.SEQ_NBR,
		Bank = b.BK_DESCRIPTION,
		CheckNumber = cc.CR_CHECK_NBR,
		PostPeriodCode = cc.POST_PERIOD,
		CheckDate = cc.CR_CHECK_DATE,
		CheckAmount = cc.CR_CHECK_AMT,
		DepositDate = cc.CR_DEP_DATE,
		GLACode = cc.GLACODE,
		OnAccountAmount = onacct.CR_OA_AMT
	FROM dbo.CR_CLIENT cc
		INNER JOIN dbo.BANK b ON cc.BK_CODE = b.BK_CODE
		LEFT OUTER JOIN (
						SELECT CR_OA_AMT, REC_ID, SEQ_NBR
						FROM dbo.CR_ON_ACCT
						WHERE CR_OA_DIST IS NULL
						) onacct ON cc.REC_ID = onacct.REC_ID AND cc.SEQ_NBR = onacct.SEQ_NBR
	WHERE cc.CL_CODE = @ClientCode 
	AND (cc.[STATUS] IS NULL OR cc.[STATUS] <> 'D')
	AND
		(
		( @HasOfficeLimits = 1 AND b.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
		OR
		( @HasOfficeLimits = 0 )
		)
END
GO
