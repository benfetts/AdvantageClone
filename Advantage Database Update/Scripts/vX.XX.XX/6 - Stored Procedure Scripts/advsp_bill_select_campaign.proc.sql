CREATE PROCEDURE [dbo].[advsp_bill_select_campaign] 
	@bcc_id_in integer, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @selection TABLE (
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CMP_IDENTIFIER		integer NOT NULL,
	CMP_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	CMP_NAME			varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
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
	INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, cc_selected )
	SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.PRD_CODE, C.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, 1
	FROM dbo.CAMPAIGN C
		INNER JOIN dbo.JOB_LOG A ON C.CMP_IDENTIFIER = A.CMP_IDENTIFIER
		INNER JOIN dbo.JOB_COMPONENT B ON A.JOB_NUMBER = B.JOB_NUMBER
	WHERE B.BCC_ID = @bcc_id_in
    AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, cc_selected )
	SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.PRD_CODE, C.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, 0
	FROM dbo.CAMPAIGN C
		INNER JOIN dbo.JOB_LOG A ON C.CMP_IDENTIFIER = A.CMP_IDENTIFIER
		INNER JOIN dbo.JOB_COMPONENT B ON A.JOB_NUMBER = B.JOB_NUMBER
	WHERE ( CMP_CLOSED = 0 OR CMP_CLOSED IS NULL ) 
	AND B.BCC_ID IS NULL
	AND NOT EXISTS (SELECT 1
					FROM @selection 
					WHERE CMP_IDENTIFIER = C.CMP_IDENTIFIER
					AND cc_selected = 1 )
    AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[CampaignID] = s.CMP_IDENTIFIER,
		[CampaignCode] = s.CMP_CODE,
		[CampaignName] = s.CMP_NAME,
		[IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.CAMPAIGN CMP ON s.CMP_IDENTIFIER= CMP.CMP_IDENTIFIER
		LEFT OUTER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
		INNER JOIN dbo.SEC_CLIENT SC ON UPPER(SC.[USER_ID]) = @UserCode 
										AND s.CL_CODE = SC.CL_CODE
										AND (s.DIV_CODE IS NULL OR s.DIV_CODE = SC.DIV_CODE)
										AND (s.PRD_CODE IS NULL OR s.PRD_CODE = SC.PRD_CODE)
	WHERE (@HasOfficeLimitations = 0 OR (@HasOfficeLimitations = 1 AND CMP.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))))
	ORDER BY s.CL_CODE ASC, s.DIV_CODE ASC, s.PRD_CODE ASC, s.CMP_CODE ASC   
ELSE
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[CampaignID] = s.CMP_IDENTIFIER,
		[CampaignCode] = s.CMP_CODE,
		[CampaignName] = s.CMP_NAME,
		[IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.CAMPAIGN CMP ON s.CMP_IDENTIFIER= CMP.CMP_IDENTIFIER
		LEFT OUTER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
	WHERE (@HasOfficeLimitations = 0 OR (@HasOfficeLimitations = 1 AND CMP.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))))
	ORDER BY s.CL_CODE ASC, s.DIV_CODE ASC, s.PRD_CODE ASC, s.CMP_CODE ASC   
