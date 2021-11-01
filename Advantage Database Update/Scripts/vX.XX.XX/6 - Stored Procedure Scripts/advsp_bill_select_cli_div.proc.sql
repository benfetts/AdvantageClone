CREATE PROCEDURE [dbo].[advsp_bill_select_cli_div] 
	@bcc_id_in integer, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @selection TABLE (
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_NAME			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

DECLARE @UserCode varchar(100), @EmployeeCode varchar(6), @IncludeMediaBillDates bit

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

IF ( @bcc_id_in IS NOT NULL )
	INSERT INTO @selection ( CL_CODE, DIV_CODE, DIV_NAME, cc_selected )
		 SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.DIV_NAME, 1
		   FROM dbo.DIVISION C INNER JOIN dbo.JOB_LOG A
		     ON C.CL_CODE = A.CL_CODE  
		    AND C.DIV_CODE = A.DIV_CODE INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
		  WHERE B.BCC_ID = @bcc_id_in
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
		  
INSERT INTO @selection ( CL_CODE, DIV_CODE, DIV_NAME, cc_selected )
SELECT DISTINCT D.CL_CODE, D.DIV_CODE, D.DIV_NAME, 0
FROM dbo.DIVISION D
	INNER JOIN dbo.CLIENT C ON D.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
	INNER JOIN dbo.JOB_LOG A ON D.CL_CODE = D.CL_CODE AND D.DIV_CODE = D.DIV_CODE
	INNER JOIN dbo.JOB_COMPONENT B ON A.JOB_NUMBER = B.JOB_NUMBER
WHERE D.ACTIVE_FLAG = 1 
AND B.BCC_ID IS NULL
AND NOT EXISTS (SELECT * 
				FROM @selection 
				WHERE CL_CODE = D.CL_CODE
				AND DIV_CODE = D.DIV_CODE
				AND cc_selected = 1)
AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = s.DIV_NAME,
		[IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT c ON s.CL_CODE = c.CL_CODE
	WHERE EXISTS (  SELECT 1
					FROM dbo.PRODUCT p
						INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
															AND p.CL_CODE = sc.CL_CODE
															AND p.DIV_CODE = sc.DIV_CODE
															AND p.PRD_CODE = sc.PRD_CODE
					WHERE p.CL_CODE = s.CL_CODE 
					AND p.DIV_CODE = s.DIV_CODE
					AND p.ACTIVE_FLAG = 1
					AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
				 )
	ORDER BY s.CL_CODE, s.DIV_CODE, s.DIV_NAME
ELSE
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = s.DIV_NAME,
		[IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT c ON s.CL_CODE = c.CL_CODE
	WHERE EXISTS (  SELECT 1
					FROM dbo.PRODUCT p
					WHERE p.CL_CODE = s.CL_CODE 
					AND p.DIV_CODE = s.DIV_CODE
					AND p.ACTIVE_FLAG = 1
					AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
				 )
	ORDER BY s.CL_CODE, s.DIV_CODE, s.DIV_NAME