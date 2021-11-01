CREATE PROCEDURE [dbo].[advsp_bill_select_job] 
	@bcc_id_in integer, @ba_batch_id_in integer, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @selection TABLE (
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	JOB_NUMBER			integer NOT NULL,
	JOB_DESC			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL,
    DIV_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
    PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
    CMP_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    CMP_IDENTIFIER      integer NULL
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
BEGIN
	IF ( @ba_batch_id_in > 0 )
		INSERT INTO @selection ( CL_CODE, JOB_NUMBER, JOB_DESC, cc_selected, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
			 SELECT DISTINCT CL_CODE, A.JOB_NUMBER, JOB_DESC, 1, A.DIV_CODE, A.PRD_CODE, A.CMP_CODE, A.CMP_IDENTIFIER
			   FROM dbo.JOB_LOG A INNER JOIN dbo.JOB_COMPONENT B
				 ON A.JOB_NUMBER = B.JOB_NUMBER
			  WHERE EXISTS( SELECT 1
	       					  FROM dbo.BILL_APPR_HDR bah 
		       			INNER JOIN dbo.BILL_APPR ba 
		       					ON ( bah.BA_ID = ba.BA_ID )
							 WHERE bah.JOB_NUMBER = A.JOB_NUMBER 
							   AND ba.BA_BATCH_ID = @ba_batch_id_in
							   AND bah.PROCESSED = 0 )
				AND SC_CODE IS NOT NULL  
				AND	JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) 			   
				AND B.BCC_ID = @bcc_id_in
                AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
	ELSE
		INSERT INTO @selection ( CL_CODE, JOB_NUMBER, JOB_DESC, cc_selected, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
			 SELECT DISTINCT CL_CODE, A.JOB_NUMBER, JOB_DESC, 1, A.DIV_CODE, A.PRD_CODE, A.CMP_CODE, A.CMP_IDENTIFIER
			   FROM dbo.JOB_LOG A INNER JOIN dbo.JOB_COMPONENT B
				 ON A.JOB_NUMBER = B.JOB_NUMBER
			  WHERE SC_CODE IS NOT NULL  
				AND	JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) 			   
				AND B.BCC_ID = @bcc_id_in
                AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
END

IF ( @ba_batch_id_in > 0 )
	INSERT INTO @selection ( CL_CODE, JOB_NUMBER, JOB_DESC, cc_selected, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
		 SELECT DISTINCT CL_CODE, A.JOB_NUMBER, JOB_DESC, 0, A.DIV_CODE, A.PRD_CODE, A.CMP_CODE, A.CMP_IDENTIFIER
		   FROM dbo.JOB_LOG A INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
		  WHERE EXISTS( SELECT 1
       					  FROM dbo.BILL_APPR_HDR bah 
	       			INNER JOIN dbo.BILL_APPR ba 
	       					ON ( bah.BA_ID = ba.BA_ID )
						 WHERE bah.JOB_NUMBER = A.JOB_NUMBER 
						   AND ba.BA_BATCH_ID = @ba_batch_id_in
						   AND bah.PROCESSED = 0 )
			AND SC_CODE IS NOT NULL  
			AND	JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) 			   
			AND B.BCC_ID IS NULL
			AND NOT EXISTS ( SELECT 1
							   FROM @selection 
							  WHERE JOB_NUMBER = A.JOB_NUMBER
								AND cc_selected = 1 ) 
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
ELSE
	INSERT INTO @selection ( CL_CODE, JOB_NUMBER, JOB_DESC, cc_selected, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
		 SELECT DISTINCT CL_CODE, A.JOB_NUMBER, JOB_DESC, 0, A.DIV_CODE, A.PRD_CODE, A.CMP_CODE, A.CMP_IDENTIFIER
		   FROM dbo.JOB_LOG A INNER JOIN dbo.JOB_COMPONENT B
			 ON A.JOB_NUMBER = B.JOB_NUMBER
		  WHERE SC_CODE IS NOT NULL  
			AND	JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 ) 			   
			AND B.BCC_ID IS NULL
			AND NOT EXISTS ( SELECT 1
							   FROM @selection 
							  WHERE JOB_NUMBER = A.JOB_NUMBER
								AND cc_selected = 1 )
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND B.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = c.CL_NAME,
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = s.JOB_DESC,
		[IsSelected] = s.cc_selected,
        [DivisionCode] = s.DIV_CODE,
		[DivisionName] = d.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = p.PRD_DESCRIPTION,
        [CampaignCode] = s.CMP_CODE,
        [CampaignName] = cmp.CMP_NAME
	FROM @selection s
		INNER JOIN dbo.CLIENT c on s.CL_CODE = c.CL_CODE
        INNER JOIN dbo.DIVISION d on s.CL_CODE = d.CL_CODE AND s.DIV_CODE = d.DIV_CODE
        INNER JOIN dbo.PRODUCT p on s.CL_CODE = p.CL_CODE AND s.DIV_CODE = p.DIV_CODE AND s.PRD_CODE = p.PRD_CODE
        LEFT OUTER JOIN dbo.CAMPAIGN cmp ON s.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
		INNER JOIN dbo.JOB_LOG jl ON s.JOB_NUMBER = jl.JOB_NUMBER
		INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
										AND jl.CL_CODE = sc.CL_CODE
										AND jl.DIV_CODE = sc.DIV_CODE
										AND jl.PRD_CODE = sc.PRD_CODE
	WHERE jl.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY s.JOB_NUMBER DESC, s.CL_CODE ASC
ELSE
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = c.CL_NAME,
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = s.JOB_DESC,
		[IsSelected] = s.cc_selected,
        [DivisionCode] = s.DIV_CODE,
		[DivisionName] = d.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = p.PRD_DESCRIPTION,
        [CampaignCode] = s.CMP_CODE,
        [CampaignName] = cmp.CMP_NAME
	FROM @selection s
		INNER JOIN dbo.CLIENT c on s.CL_CODE = c.CL_CODE
        INNER JOIN dbo.DIVISION d on s.CL_CODE = d.CL_CODE AND s.DIV_CODE = d.DIV_CODE
        INNER JOIN dbo.PRODUCT p on s.CL_CODE = p.CL_CODE AND s.DIV_CODE = p.DIV_CODE AND s.PRD_CODE = p.PRD_CODE
        LEFT OUTER JOIN dbo.CAMPAIGN cmp ON s.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
		INNER JOIN dbo.JOB_LOG jl ON s.JOB_NUMBER = jl.JOB_NUMBER
	WHERE jl.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY s.JOB_NUMBER DESC, s.CL_CODE ASC
