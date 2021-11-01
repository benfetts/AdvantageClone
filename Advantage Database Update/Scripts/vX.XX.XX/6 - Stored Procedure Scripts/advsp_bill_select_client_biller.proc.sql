CREATE PROCEDURE [dbo].[advsp_bill_select_client_biller] 
	@bcc_id_in integer, @ba_batch_id integer, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS

SET NOCOUNT ON

DECLARE @selection TABLE (
	BILLER_EMP_CODE		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
	INSERT INTO @selection ( BILLER_EMP_CODE, cc_selected )
		 SELECT DISTINCT C.BILLER_EMP_CODE, 1
		   FROM dbo.CLIENT C INNER JOIN dbo.JOB_LOG A
		     ON C.CL_CODE = A.CL_CODE INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
		  WHERE B.BCC_ID = @bcc_id_in
		    AND NULLIF(C.BILLER_EMP_CODE, '') IS NOT NULL
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

IF ( @ba_batch_id > 0 )
	INSERT INTO @selection ( BILLER_EMP_CODE, cc_selected )
		 SELECT DISTINCT C.BILLER_EMP_CODE, 0
		   FROM dbo.CLIENT C 
	 INNER JOIN dbo.JOB_LOG A
			 ON C.CL_CODE = A.CL_CODE 
	 INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
	 INNER JOIN dbo.BILL_APPR_CL D
			 ON C.CL_CODE = D.CL_CODE
	 INNER JOIN dbo.BILL_APPR E
		     ON D.BA_ID = E.BA_ID
	 INNER JOIN dbo.BILL_APPR_HDR BAH
			 ON E.BA_ID = BAH.BA_ID AND BAH.PROCESSED = 0
		  WHERE C.ACTIVE_FLAG = 1 
			AND B.BCC_ID IS NULL
			AND E.BA_BATCH_ID = @ba_batch_id
			AND NULLIF(C.BILLER_EMP_CODE, '') IS NOT NULL
			AND NOT EXISTS ( SELECT 1
							   FROM @selection 
							  WHERE BILLER_EMP_CODE = C.BILLER_EMP_CODE
								AND cc_selected = 1 )
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
ELSE		  
	INSERT INTO @selection ( BILLER_EMP_CODE, cc_selected )
		 SELECT DISTINCT C.BILLER_EMP_CODE, 0
		   FROM dbo.CLIENT C INNER JOIN dbo.JOB_LOG A
			 ON C.CL_CODE = A.CL_CODE INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
		  WHERE C.ACTIVE_FLAG = 1 
			AND B.BCC_ID IS NULL
			AND NULLIF(C.BILLER_EMP_CODE, '') IS NOT NULL
			AND NOT EXISTS ( SELECT 1
							   FROM @selection 
							  WHERE BILLER_EMP_CODE = C.BILLER_EMP_CODE
								AND cc_selected = 1 )
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SELECT
		[BillerEmployeeCode] = s.BILLER_EMP_CODE,
		[ClientBiller] = [dbo].[advfn_get_emp_name] ( s.BILLER_EMP_CODE, 'FML' ),
		[IsSelected] = s.cc_selected
	FROM @selection s
	WHERE EXISTS (  SELECT 1
					FROM dbo.CLIENT c 
						INNER JOIN dbo.DIVISION d ON d.CL_CODE = c.CL_CODE AND d.ACTIVE_FLAG = 1
						INNER JOIN dbo.PRODUCT p ON p.CL_CODE = c.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
						INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
															AND p.CL_CODE = sc.CL_CODE
															AND p.DIV_CODE = sc.DIV_CODE
															AND p.PRD_CODE = sc.PRD_CODE
					WHERE c.BILLER_EMP_CODE = s.BILLER_EMP_CODE
					AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
				 )
	ORDER BY s.BILLER_EMP_CODE
ELSE
	SELECT
		[BillerEmployeeCode] = s.BILLER_EMP_CODE,
		[ClientBiller] = [dbo].[advfn_get_emp_name] ( s.BILLER_EMP_CODE, 'FML' ),
		[IsSelected] = s.cc_selected
	FROM @selection s
	WHERE EXISTS (  SELECT 1
					FROM dbo.CLIENT c 
						INNER JOIN dbo.DIVISION d ON d.CL_CODE = c.CL_CODE AND d.ACTIVE_FLAG = 1
						INNER JOIN dbo.PRODUCT p ON p.CL_CODE = c.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
					WHERE c.BILLER_EMP_CODE = s.BILLER_EMP_CODE
					AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
				 )
	ORDER BY s.BILLER_EMP_CODE
GO