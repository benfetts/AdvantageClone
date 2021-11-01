CREATE PROCEDURE [dbo].[advsp_bill_select_comp] 
	@bcc_id_in integer, @ba_batch_id_in integer, @bill_user_in varchar(100), @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @selection TABLE (
	JOB_NUMBER			integer NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL,
	JOB_COMP_DESC		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	cc_selected			smallint NULL,
	ROWID				int NOT NULL,
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
		INSERT INTO @selection ( JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, cc_selected, ROWID, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
			 SELECT DISTINCT A.JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, 1, A.ROWID, B.DIV_CODE, B.PRD_CODE, B.CMP_CODE, B.CMP_IDENTIFIER
			   FROM dbo.JOB_COMPONENT A INNER JOIN dbo.JOB_LOG B  
				 ON A.JOB_NUMBER = B.JOB_NUMBER 
			  WHERE EXISTS ( SELECT 1
							   FROM dbo.BILL_APPR_HDR bah INNER JOIN dbo.BILL_APPR ba 
							   	 ON ( bah.BA_ID = ba.BA_ID ) 
							  WHERE bah.JOB_NUMBER = A.JOB_NUMBER 
								AND bah.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR 
								AND ba.BA_BATCH_ID = @ba_batch_id_in
								AND bah.PROCESSED = 0 )
				AND JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
				AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )  				
				AND A.BCC_ID = @bcc_id_in
                AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
	ELSE
		INSERT INTO @selection ( JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, cc_selected, ROWID, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
			 SELECT DISTINCT A.JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, 1, A.ROWID, B.DIV_CODE, B.PRD_CODE, B.CMP_CODE, B.CMP_IDENTIFIER
			   FROM dbo.JOB_COMPONENT A INNER JOIN dbo.JOB_LOG B  
				 ON A.JOB_NUMBER = B.JOB_NUMBER 
			  WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
				AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )  				
				AND A.BCC_ID = @bcc_id_in
                AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
END

IF ( @ba_batch_id_in > 0 )
	INSERT INTO @selection ( JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, cc_selected, ROWID, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
		 SELECT DISTINCT A.JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, 0, A.ROWID, B.DIV_CODE, B.PRD_CODE, B.CMP_CODE, B.CMP_IDENTIFIER
		   FROM dbo.JOB_COMPONENT A INNER JOIN dbo.JOB_LOG B  
			 ON A.JOB_NUMBER = B.JOB_NUMBER  
		  WHERE EXISTS ( SELECT 1
						   FROM dbo.BILL_APPR_HDR bah INNER JOIN dbo.BILL_APPR ba 
						   	 ON ( bah.BA_ID = ba.BA_ID ) 
						  WHERE bah.JOB_NUMBER = A.JOB_NUMBER 
							AND bah.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR 
							AND ba.BA_BATCH_ID = @ba_batch_id_in
							AND bah.PROCESSED = 0 )
			AND JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
			AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )  				
			AND A.BCC_ID IS NULL  				 
			AND NOT EXISTS ( SELECT 1
							   FROM @selection 
							  WHERE JOB_NUMBER = A.JOB_NUMBER
							    AND JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR 
								AND cc_selected = 1 )
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

ELSE
	INSERT INTO @selection ( JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, cc_selected, ROWID, DIV_CODE, PRD_CODE, CMP_CODE, CMP_IDENTIFIER )
		 SELECT DISTINCT A.JOB_NUMBER, JOB_COMPONENT_NBR, JOB_COMP_DESC, CL_CODE, 0, A.ROWID, B.DIV_CODE, B.PRD_CODE, B.CMP_CODE, B.CMP_IDENTIFIER
		   FROM dbo.JOB_COMPONENT A INNER JOIN dbo.JOB_LOG B  
			 ON A.JOB_NUMBER = B.JOB_NUMBER 
		  WHERE JOB_PROCESS_CONTRL IN ( 1, 3, 4, 5, 7, 8, 9, 10, 11 )
			AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )  				
			AND A.BCC_ID IS NULL
			AND NOT EXISTS ( SELECT 1
							   FROM @selection 
							  WHERE JOB_NUMBER = A.JOB_NUMBER
							    AND JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR 
								AND cc_selected = 1 )
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SELECT
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC,
		[JobComponentNumber] = s.JOB_COMPONENT_NBR,
		[ComponentDescription] = s.JOB_COMP_DESC,
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
        [IsSelected] = s.cc_selected,
		[ID] = s.ROWID,
        [DivisionCode] = s.DIV_CODE,
		[DivisionName] = d.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = p.PRD_DESCRIPTION,
        [CampaignCode] = s.CMP_CODE,
        [CampaignName] = cmp.CMP_NAME
	FROM @selection s
		INNER JOIN dbo.JOB_LOG JL ON s.JOB_NUMBER = JL.JOB_NUMBER
		INNER JOIN dbo.CLIENT C ON JL.CL_CODE = C.CL_CODE
        INNER JOIN dbo.DIVISION d on s.CL_CODE = d.CL_CODE AND s.DIV_CODE = d.DIV_CODE
        INNER JOIN dbo.PRODUCT p on s.CL_CODE = p.CL_CODE AND s.DIV_CODE = p.DIV_CODE AND s.PRD_CODE = p.PRD_CODE
        LEFT OUTER JOIN dbo.CAMPAIGN cmp ON s.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
		INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
										AND JL.CL_CODE = sc.CL_CODE
										AND JL.DIV_CODE = sc.DIV_CODE
										AND JL.PRD_CODE = sc.PRD_CODE
	WHERE JL.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY s.JOB_NUMBER DESC, s.JOB_COMPONENT_NBR ASC 
ELSE
	SELECT
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC,
		[JobComponentNumber] = s.JOB_COMPONENT_NBR,
		[ComponentDescription] = s.JOB_COMP_DESC,
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[IsSelected] = s.cc_selected,
		[ID] = s.ROWID,
        [DivisionCode] = s.DIV_CODE,
		[DivisionName] = d.DIV_NAME,
        [ProductCode] = s.PRD_CODE,
		[ProductDescription] = p.PRD_DESCRIPTION,
        [CampaignCode] = s.CMP_CODE,
        [CampaignName] = cmp.CMP_NAME
	FROM @selection s
		INNER JOIN dbo.JOB_LOG JL ON s.JOB_NUMBER = JL.JOB_NUMBER
		INNER JOIN dbo.CLIENT C ON JL.CL_CODE = C.CL_CODE
        INNER JOIN dbo.DIVISION d on s.CL_CODE = d.CL_CODE AND s.DIV_CODE = d.DIV_CODE
        INNER JOIN dbo.PRODUCT p on s.CL_CODE = p.CL_CODE AND s.DIV_CODE = p.DIV_CODE AND s.PRD_CODE = p.PRD_CODE
        LEFT OUTER JOIN dbo.CAMPAIGN cmp ON s.CMP_IDENTIFIER = cmp.CMP_IDENTIFIER
	WHERE JL.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY s.JOB_NUMBER DESC, s.JOB_COMPONENT_NBR ASC 
