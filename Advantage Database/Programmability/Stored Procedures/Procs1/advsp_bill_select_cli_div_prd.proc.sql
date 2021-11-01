CREATE PROCEDURE [dbo].[advsp_bill_select_cli_div_prd] 
	@bcc_id_in integer, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @selection TABLE (
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	PRD_DESC			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
	INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, PRD_DESC, cc_selected )
		 SELECT DISTINCT C.CL_CODE, C.DIV_CODE, C.PRD_CODE, PRD_DESCRIPTION, 1
		   FROM dbo.PRODUCT C INNER JOIN dbo.JOB_LOG A
		     ON C.CL_CODE = A.CL_CODE  
		    AND C.DIV_CODE = A.DIV_CODE 
		    AND C.PRD_CODE = A.PRD_CODE INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
		  WHERE B.BCC_ID = @bcc_id_in
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

INSERT INTO @selection ( CL_CODE, DIV_CODE, PRD_CODE, PRD_DESC, cc_selected )
SELECT DISTINCT P.CL_CODE, P.DIV_CODE, P.PRD_CODE, PRD_DESCRIPTION, 0
FROM dbo.PRODUCT P
	INNER JOIN dbo.CLIENT C ON P.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
	INNER JOIN dbo.DIVISION D ON P.CL_CODE = D.CL_CODE AND P.DIV_CODE = D.DIV_CODE AND D.ACTIVE_FLAG = 1
	INNER JOIN dbo.JOB_LOG A ON P.CL_CODE = A.CL_CODE AND P.DIV_CODE = A.DIV_CODE AND P.PRD_CODE = A.PRD_CODE
	INNER JOIN dbo.JOB_COMPONENT B ON A.JOB_NUMBER = B.JOB_NUMBER
WHERE P.ACTIVE_FLAG = 1 
AND B.BCC_ID IS NULL
AND NOT EXISTS (SELECT * 
				FROM @selection 
				WHERE CL_CODE = P.CL_CODE
				AND DIV_CODE = P.DIV_CODE
				AND PRD_CODE = P.PRD_CODE
				AND cc_selected = 1)
AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = d.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = s.PRD_DESC,
		[IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT c ON s.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION d ON s.CL_CODE = d.CL_CODE AND s.DIV_CODE = d.DIV_CODE
		INNER JOIN dbo.PRODUCT p ON s.CL_CODE = p.CL_CODE AND s.DIV_CODE = p.DIV_CODE AND s.PRD_CODE = p.PRD_CODE
		INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
										AND p.CL_CODE = sc.CL_CODE
										AND p.DIV_CODE = sc.DIV_CODE
										AND p.PRD_CODE = sc.PRD_CODE
	WHERE p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY s.CL_CODE ASC, s.DIV_CODE ASC, s.PRD_CODE ASC
ELSE
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = c.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = d.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = s.PRD_DESC,
		[IsSelected] = s.cc_selected
	FROM @selection s
		INNER JOIN dbo.CLIENT c ON s.CL_CODE = c.CL_CODE
		INNER JOIN dbo.DIVISION d ON s.CL_CODE = d.CL_CODE AND s.DIV_CODE = d.DIV_CODE
		INNER JOIN dbo.PRODUCT p ON s.CL_CODE = p.CL_CODE AND s.DIV_CODE = p.DIV_CODE AND s.PRD_CODE = p.PRD_CODE
	WHERE p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY s.CL_CODE ASC, s.DIV_CODE ASC, s.PRD_CODE ASC