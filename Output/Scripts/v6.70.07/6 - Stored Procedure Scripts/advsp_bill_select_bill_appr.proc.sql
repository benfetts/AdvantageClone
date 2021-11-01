CREATE PROCEDURE [dbo].[advsp_bill_select_bill_appr] 
	@bcc_id_in integer, @ba_batch_id_in integer, @finished bit, @media_bill_date_from smalldatetime = NULL, @media_bill_date_to smalldatetime = NULL
AS
--07/14/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON;

DECLARE @selection TABLE (
	BA_HDR_ID			integer NOT NULL,
	BA_ID				integer NOT NULL,
	JOB_NUMBER			integer NOT NULL,
	JOB_COMPONENT_NBR	smallint NOT NULL,
	BA_CL_DESC			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	BA_BATCH_ID			integer NULL,	
	cc_selected			smallint NULL,
	BA_BATCH_DESC		varchar(50) NULL
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
		INSERT INTO @selection ( BA_HDR_ID, BA_ID, BA_CL_DESC, BA_BATCH_ID, JOB_NUMBER, JOB_COMPONENT_NBR, cc_selected, BA_BATCH_DESC )
			 SELECT DISTINCT B.BA_HDR_ID, C.BA_ID, D.BA_CL_DESC, E.BA_BATCH_ID, B.JOB_NUMBER, B.JOB_COMPONENT_NBR, 1, E.BA_BATCH_DESC
			   FROM dbo.BILL_APPR C 
		 INNER JOIN dbo.BILL_APPR_BATCH E
			     ON C.BA_BATCH_ID = E.BA_BATCH_ID AND E.APPROVED = 1
	LEFT OUTER JOIN dbo.BILL_APPR_CL D
			     ON C.BA_ID = D.BA_ID 
		 INNER JOIN dbo.BILL_APPR_HDR B
			     ON C.BA_ID = B.BA_ID 
		 INNER JOIN dbo.JOB_COMPONENT A
			     ON B.JOB_NUMBER = A.JOB_NUMBER
			    AND B.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
			    AND B.BA_ID = A.SELECTED_BA_ID
			  WHERE C.BA_BATCH_ID = @ba_batch_id_in
				AND A.BCC_ID = @bcc_id_in
                AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
	ELSE
		INSERT INTO @selection ( BA_HDR_ID, BA_ID, BA_CL_DESC, BA_BATCH_ID, JOB_NUMBER, JOB_COMPONENT_NBR, cc_selected, BA_BATCH_DESC )
			 SELECT DISTINCT B.BA_HDR_ID, C.BA_ID, D.BA_CL_DESC, E.BA_BATCH_ID, B.JOB_NUMBER, B.JOB_COMPONENT_NBR, 1, E.BA_BATCH_DESC
			   FROM dbo.BILL_APPR C 
	INNER JOIN dbo.BILL_APPR_BATCH E
			     ON C.BA_BATCH_ID = E.BA_BATCH_ID AND (E.FINISHED = @finished OR E.FINISHED = 0) AND E.APPROVED = 1
	LEFT OUTER JOIN dbo.BILL_APPR_CL D
			     ON C.BA_ID = D.BA_ID 
		 INNER JOIN dbo.BILL_APPR_HDR B
			     ON C.BA_ID = B.BA_ID 
		 INNER JOIN dbo.JOB_COMPONENT A
			     ON B.JOB_NUMBER = A.JOB_NUMBER
			    AND B.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
			    AND B.BA_ID = A.SELECTED_BA_ID 
			  WHERE A.BCC_ID = @bcc_id_in		
		  	    AND B.PROCESSED = 0
                AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
END

IF ( @ba_batch_id_in > 0 )
	INSERT INTO @selection ( BA_HDR_ID, BA_ID, BA_CL_DESC, BA_BATCH_ID, JOB_NUMBER, JOB_COMPONENT_NBR, cc_selected, BA_BATCH_DESC )
		 SELECT DISTINCT B.BA_HDR_ID, C.BA_ID, D.BA_CL_DESC, E.BA_BATCH_ID, B.JOB_NUMBER, B.JOB_COMPONENT_NBR, 0, E.BA_BATCH_DESC
		   FROM dbo.BILL_APPR C 
	 INNER JOIN dbo.BILL_APPR_BATCH E
		     ON C.BA_BATCH_ID = E.BA_BATCH_ID AND E.APPROVED = 1
			 AND E.BILLED_ALL = 0
LEFT OUTER JOIN dbo.BILL_APPR_CL D
		     ON C.BA_ID = D.BA_ID 
	 INNER JOIN dbo.BILL_APPR_HDR B
		     ON C.BA_ID = B.BA_ID 
	 INNER JOIN dbo.JOB_COMPONENT A
		     ON B.JOB_NUMBER = A.JOB_NUMBER
		    AND B.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
		  WHERE C.BA_BATCH_ID = @ba_batch_id_in
			AND B.PROCESSED = 0
			AND B.APPR_STATUS IS NULL
			AND A.BCC_ID IS NULL
			AND A.SELECTED_BA_ID IS NULL
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
			--AND NOT EXISTS ( SELECT * 
			--				   FROM @selection 
			--				  WHERE BA_ID = C.BA_ID 
			--				    AND JOB_NUMBER = A.JOB_NUMBER
			--				    AND JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
			--					AND cc_selected = 1 )  
ELSE
	INSERT INTO @selection ( BA_HDR_ID, BA_ID, BA_CL_DESC, BA_BATCH_ID, JOB_NUMBER, JOB_COMPONENT_NBR, cc_selected, BA_BATCH_DESC )
		 SELECT DISTINCT B.BA_HDR_ID, C.BA_ID, D.BA_CL_DESC, E.BA_BATCH_ID, B.JOB_NUMBER, B.JOB_COMPONENT_NBR, 0, E.BA_BATCH_DESC
		   FROM dbo.BILL_APPR C 
     INNER JOIN dbo.BILL_APPR_BATCH E
		     ON C.BA_BATCH_ID = E.BA_BATCH_ID AND (E.FINISHED = @finished OR E.FINISHED = 0) AND E.APPROVED = 1
		    AND E.BILLED_ALL = 0 
LEFT OUTER JOIN dbo.BILL_APPR_CL D
		     ON C.BA_ID = D.BA_ID 
	 INNER JOIN dbo.BILL_APPR_HDR B
		     ON C.BA_ID = B.BA_ID 
	 INNER JOIN dbo.JOB_COMPONENT A
		     ON B.JOB_NUMBER = A.JOB_NUMBER
		    AND B.JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
		  WHERE B.PROCESSED = 0
		    AND B.APPR_STATUS IS NULL
			AND A.BCC_ID IS NULL
			AND A.SELECTED_BA_ID IS NULL
            AND (@IncludeMediaBillDates = 0 OR (@IncludeMediaBillDates = 1 AND A.MEDIA_BILL_DATE BETWEEN @media_bill_date_from AND @media_bill_date_to))
			--AND NOT EXISTS ( SELECT * 
			--				   FROM @selection 
			--				  WHERE BA_ID = C.BA_ID 
			--				    AND JOB_NUMBER = A.JOB_NUMBER
			--				    AND JOB_COMPONENT_NBR = A.JOB_COMPONENT_NBR
			--					AND cc_selected = 1 )

IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
	SELECT DISTINCT
		[BillingApprovalID] = s.BA_ID,
		[BillingApprovalClientName] = s.BA_CL_DESC,
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC,
		[JobComponentNumber] = s.JOB_COMPONENT_NBR,
		[ComponentDescription] = JC.JOB_COMP_DESC,
		[BillingApprovalBatchID] = s.BA_BATCH_ID,
		[IsSelected] = s.cc_selected,
		[BillingApprovalHeaderID] = s.BA_HDR_ID,
		[BatchDescription] = s.BA_BATCH_DESC
	FROM @selection s
		INNER JOIN dbo.JOB_COMPONENT JC ON s.JOB_NUMBER = JC.JOB_NUMBER AND s.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
		INNER JOIN dbo.JOB_LOG JL ON JC.JOB_NUMBER = JL.JOB_NUMBER
		INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
										AND JL.CL_CODE = sc.CL_CODE
										AND JL.DIV_CODE = sc.DIV_CODE
										AND JL.PRD_CODE = sc.PRD_CODE
	WHERE JL.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY BA_ID DESC
ELSE
	SELECT DISTINCT
		[BillingApprovalID] = s.BA_ID,
		[BillingApprovalClientName] = s.BA_CL_DESC,
		[JobNumber] = s.JOB_NUMBER,
		[JobDescription] = JL.JOB_DESC,
		[JobComponentNumber] = s.JOB_COMPONENT_NBR,
		[ComponentDescription] = JC.JOB_COMP_DESC,
		[BillingApprovalBatchID] = s.BA_BATCH_ID,
		[IsSelected] = s.cc_selected,
		[BillingApprovalHeaderID] = s.BA_HDR_ID,
		[BatchDescription] = s.BA_BATCH_DESC
	FROM @selection s
		INNER JOIN dbo.JOB_COMPONENT JC ON s.JOB_NUMBER = JC.JOB_NUMBER AND s.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
		INNER JOIN dbo.JOB_LOG JL ON JC.JOB_NUMBER = JL.JOB_NUMBER
	WHERE JL.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
	ORDER BY BA_ID DESC
