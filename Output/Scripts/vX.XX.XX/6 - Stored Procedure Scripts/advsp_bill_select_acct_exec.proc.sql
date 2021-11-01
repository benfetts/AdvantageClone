CREATE PROCEDURE [dbo].[advsp_bill_select_acct_exec] 
	@bcc_id_in integer, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @selection TABLE (
	EMP_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	EMP_FML			varchar(64) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	cc_selected		smallint NULL
)

DECLARE @UserCode varchar(100), @EmployeeCode varchar(6), @HasOfficeLimitations bit, @IncludeMediaBillDates bit

IF @media_bill_date_from IS NOT NULL AND @media_bill_date_to IS NOT NULL
    SET @IncludeMediaBillDates = 1
ELSE
    SET @IncludeMediaBillDates = 0

SELECT @UserCode = UPPER(SUBSTRING(BILLING_USER, 1, LEN(BILLING_USER) - 2))
FROM dbo.BILLING_CMD_CENTER
WHERE BCC_ID = @bcc_id_in

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserCode)

IF EXISTS (SELECT 1 from dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode)
	SET @HasOfficeLimitations = 1
ELSE
	SEt @HasOfficeLimitations = 0

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( EMP_CODE, EMP_FML, cc_selected )
	SELECT DISTINCT ae.EMP_CODE, vae.EMP_FML, 1 
	FROM dbo.ACCOUNT_EXECUTIVE ae
		INNER JOIN dbo.V_ACTIVE_EMPLOYEE vae ON ae.EMP_CODE = vae.EMP_CODE
		INNER JOIN dbo.JOB_COMPONENT jc ON ae.EMP_CODE = jc.EMP_CODE
	WHERE jc.BCC_ID = @bcc_id_in
      AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND jc.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
	
INSERT INTO @selection ( EMP_CODE, EMP_FML, cc_selected )
SELECT DISTINCT ae.EMP_CODE, vae.EMP_FML, 0  
FROM dbo.ACCOUNT_EXECUTIVE ae
	INNER JOIN dbo.V_ACTIVE_EMPLOYEE vae ON ae.EMP_CODE = vae.EMP_CODE
	INNER JOIN dbo.JOB_COMPONENT jc ON ae.EMP_CODE = jc.EMP_CODE AND jc.BCC_ID IS NULL
WHERE NOT EXISTS (  SELECT 1 
					FROM @selection 
					WHERE EMP_CODE = ae.EMP_CODE
					AND cc_selected = 1 )
AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND jc.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

SELECT
	[EmployeeCode] = s.EMP_CODE,
	[EmployeeName] = s.EMP_FML,
	[IsSelected] = s.cc_selected
FROM @selection s
	INNER JOIN dbo.EMPLOYEE e ON s.EMP_CODE = e.EMP_CODE
WHERE (@HasOfficeLimitations = 0 OR (@HasOfficeLimitations = 1 AND e.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))))
ORDER BY s.EMP_CODE ASC, s.EMP_FML ASC
