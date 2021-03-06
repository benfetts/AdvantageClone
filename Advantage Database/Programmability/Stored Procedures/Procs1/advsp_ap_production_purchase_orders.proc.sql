CREATE PROCEDURE [dbo].[advsp_ap_production_purchase_orders]
	@vn_code						varchar(6) = NULL,
	@include_job_process_control	bit = 1,
	@user_code						varchar(100),
	@include_completed_po			bit = 0
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @EmployeeCode varchar(6),
			@HasOfficeLimits bit
	
	SET @HasOfficeLimits = 0
	
	IF @user_code IS NOT NULL BEGIN
		SELECT @EmployeeCode = EMP_CODE
		FROM dbo.SEC_USER
		WHERE UPPER(USER_CODE) = UPPER(@user_code)

		IF (SELECT COUNT(1) FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode) > 0
			SET @HasOfficeLimits = 1
	
	END

	SELECT
		[Number] = O.PO_NUMBER,
		[Description] = O.PO_DESCRIPTION,
		[Date] = O.PO_DATE,
		[DueDate] = O.PO_DUE_DATE,
		[Status] = POSTATUS.PSTATUS,
		[POTotal] = SUM(COALESCE(D.PO_EXT_AMOUNT,0)),
		[POBalance] = SUM(COALESCE(D.PO_EXT_AMOUNT,0)) - SUM(COALESCE(A.AP_PROD_EXT_AMT, 0)),
		[WorkComplete] = CASE COALESCE(O.PO_WORK_COMPLETE , 0)
							WHEN 1 THEN 'Yes'
							ELSE 'No' END,
		[VendorCode] = O.VN_CODE,
		[POComplete] = CAST(CASE WHEN O.PO_COMPLETE = 1 OR D.PO_COMPLETE = 1 THEN 1 ELSE 0 END AS bit)
	FROM
		[dbo].PURCHASE_ORDER O
		INNER JOIN [dbo].PURCHASE_ORDER_DET D ON O.PO_NUMBER = D.PO_NUMBER 
		LEFT OUTER JOIN [dbo].AP_PRODUCTION A ON D.PO_NUMBER = A.PO_NUMBER AND D.LINE_NUMBER = A.PO_LINE_NUMBER AND	(A.MODIFY_DELETE IS NULL OR A.MODIFY_DELETE=0)
		INNER JOIN (SELECT PO_NUMBER,
						CASE
							WHEN PO_APPR_RULE_CODE IS NULL THEN 'None'
							WHEN PO_APPR_RULE_CODE IS NOT NULL AND PO_APPROVAL_FLAG = 1 THEN 'Pending'
							WHEN PO_APPR_RULE_CODE IS NOT NULL AND PO_APPROVAL_FLAG = 2 THEN 'Approved'
							WHEN PO_APPR_RULE_CODE IS NOT NULL AND PO_APPROVAL_FLAG = 3 THEN 'Denied'
							WHEN PO_APPR_RULE_CODE IS NOT NULL AND COALESCE(PO_APPROVAL_FLAG,0) = 0 AND COALESCE(PO_PRINTED,0) = 0 THEN 'Incomplete'
							WHEN PO_APPR_RULE_CODE IS NOT NULL AND COALESCE(PO_APPROVAL_FLAG,0) = 0 AND PO_PRINTED = 1 THEN 'None'
						END AS PSTATUS
					FROM dbo.PURCHASE_ORDER) POSTATUS ON POSTATUS.PO_NUMBER = O.PO_NUMBER
		INNER JOIN [dbo].JOB_COMPONENT JC ON D.JOB_NUMBER = JC.JOB_NUMBER AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR

	WHERE
				(@vn_code IS NULL OR VN_CODE = @vn_code)
		AND		(VOID_FLAG IS NULL OR VOID_FLAG = 0)
		AND		(
				((@include_completed_po = 0) AND (O.PO_COMPLETE IS NULL OR O.PO_COMPLETE = 0) AND (D.PO_COMPLETE IS NULL OR D.PO_COMPLETE = 0))
			OR 
				(@include_completed_po = 1 AND ((O.PO_COMPLETE = 1 OR D.PO_COMPLETE = 1) OR (O.PO_COMPLETE IS NULL OR O.PO_COMPLETE = 0) AND (D.PO_COMPLETE IS NULL OR D.PO_COMPLETE = 0)))
				)
		AND		D.JOB_NUMBER IS NOT NULL
		AND		(@include_job_process_control = 0 OR (@include_job_process_control = 1 AND JC.JOB_PROCESS_CONTRL IN (1, 3, 4, 8, 9, 13)))
		AND		(
				( @HasOfficeLimits = 1 AND EXISTS (
												SELECT 1
												FROM dbo.VENDOR
												WHERE VN_CODE = O.VN_CODE
												AND OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
											   ))
				OR
				( @HasOfficeLimits = 0 )
				)
	GROUP BY
		O.PO_NUMBER, O.PO_DESCRIPTION, O.PO_DATE, O.PO_DUE_DATE, POSTATUS.PSTATUS, O.PO_WORK_COMPLETE, O.VN_CODE, O.PO_COMPLETE, D.PO_COMPLETE 
	ORDER BY
		O.PO_NUMBER

END

GO

