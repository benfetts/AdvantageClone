CREATE PROC [advsp_media_manager_load_po_details]

	@CampaignIDList varchar(max),
	@ClientCodeList varchar(max),
	@ClientDivisionCodeList varchar(max),
	@ClientDivisionProductCodeList varchar(max),
	@JobNumberList varchar(max),
	@JobNumberComponentNumberList varchar(max),
	@PONumberList varchar(max),
	@AEDefaultEmployeeCodeList varchar(max),
	@AEJobEmployeeCodeList varchar(max),
	@UserCode varchar(100),
	@VendorCodeList varchar(max),
	@SelectForServiceRefresh bit = 0

AS

BEGIN

	SET NOCOUNT ON

	DECLARE @EmployeeCode varchar(6),
			@LimitedByOffice bit
	
	SET @LimitedByOffice = 0

	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@UserCode)
	
	IF EXISTS (SELECT * FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode)
		SET @LimitedByOffice = 1

	DECLARE @PO bit,
			@IncludeOrder bit, @IncludeQuote bit,
			@IncludeOrderLineDates bit, @OrderLineStartDate smalldatetime, @OrderLineEndDate smalldatetime,
			@IncludeJobMediaDateToBill bit, @JobMediaStartDate smalldatetime, @JobMediaEndDate smalldatetime,
			@LoadLockedOrders bit, @IncludeClosedOrders bit,
			@include_media_month bit,
			@media_month_start_date int, @media_month_end_date int --YYYYMM format

	SELECT @LoadLockedOrders = Custom1
	FROM dbo.V_SEC_PERMISSION
	WHERE ApplicationID = (SELECT SEC_APPLICATION_ID FROM dbo.SEC_APPLICATION WHERE NAME = 'Advantage')
	AND UserID = (SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserCode))
	AND ModuleCode = 'Media_MediaManager'

	SELECT
		@PO =SELECT_PO,
		@IncludeOrder = CASE WHEN INCLUDE_ORDER_QUOTE_BOTH IN (1,3) THEN 1 ELSE 0 END,
		@IncludeQuote = CASE WHEN INCLUDE_ORDER_QUOTE_BOTH IN (2,3) THEN 1 ELSE 0 END,
		@IncludeOrderLineDates = CASE WHEN FILTER_BY = 1 THEN 1 ELSE 0 END,
		@OrderLineStartDate = ORDER_LINE_START_DATE, @OrderLineEndDate = ORDER_LINE_END_DATE,
		@IncludeJobMediaDateToBill = CASE WHEN FILTER_BY = 2 THEN 1 ELSE 0 END,
		@JobMediaStartDate = JOB_MEDIA_START_DATE, @JobMediaEndDate  = JOB_MEDIA_END_DATE,
		@IncludeClosedOrders = INCLUDE_CLOSED_ORDERS,
		@include_media_month = CASE WHEN FILTER_BY = 3 THEN 1 ELSE 0 END,
		@media_month_start_date = CASE WHEN FILTER_BY = 3 THEN CAST(YEAR(MEDIA_MONTH_START) as varchar(4)) + RIGHT('0' + CAST(MONTH(MEDIA_MONTH_START) as varchar),2) ELSE NULL END,
		@media_month_end_date = CASE WHEN FILTER_BY = 3 THEN CAST(YEAR(MEDIA_MONTH_END) as varchar(4)) + RIGHT('0' + CAST(MONTH(MEDIA_MONTH_END) as varchar),2) ELSE NULL END
	FROM dbo.MEDIA_MGR_SEARCH_SETTING
	WHERE UPPER(MEDIA_MGR_SEARCH_SETTING_USER_CODE) = UPPER(@UserCode)
	
	IF ( @PO = 1 OR @SelectForServiceRefresh = 1 )
	BEGIN
		SELECT DISTINCT
			IssuedByCode = h.EMP_CODE,
			IssuedBy = ec.EMP_FNAME + ' ' + LTRIM(' ' + COALESCE(ec.EMP_MI, '') + ' ') + ec.EMP_LNAME,
			PONumber = h.PO_NUMBER, 
			PODescription = h.PO_DESCRIPTION,
			Revision = h.PO_REVISION,
			VendorCode = h.VN_CODE, 
			VendorName = v.VN_NAME,
			PODate = h.PO_DATE,
			POAmount = (SELECT SUM(PO_EXT_AMOUNT) FROM dbo.PURCHASE_ORDER_DET WHERE PO_NUMBER = h.PO_NUMBER),
			VendorContactCode = vc.VC_CODE,
			VendorContactName = vc.VC_FNAME + ' ' + LTRIM(' ' + COALESCE(vc.VC_MI, '') + ' ') + vc.VC_LNAME,
			VendorContactEmail = vc.EMAIL_ADDRESS,
			POStatus = (
							SELECT TOP 1 OS.STATUS_DESC 
							FROM
								(
								SELECT PURCHASE_ORDER_STATUS_ID, PO_NUMBER, REV_NBR, [STATUS], REVISED_DATE FROM dbo.PURCHASE_ORDER_STATUS WHERE [STATUS] <> 11
								) Statuses
									INNER JOIN dbo.ORDER_STATUS OS ON Statuses.[STATUS] = OS.[STATUS] 
							WHERE PO_NUMBER = h.PO_NUMBER AND REV_NBR = h.PO_REVISION
							ORDER BY REVISED_DATE DESC, PURCHASE_ORDER_STATUS_ID DESC
							),
		 	PaymentMethod = CASE WHEN COALESCE(v.VCC_STATUS, 0) = 1 AND v.SEND_VCC_WITH_MEDIA_ORDER = 1 THEN 'Virtual CC' ELSE 'Check' END,
			OrderAccepted = CAST(CASE WHEN os.PO_NUMBER IS NOT NULL THEN 1 ELSE 0 END as bit),
			VCCCardPOID = (SELECT VCC_CARD_PO_ID FROM dbo.VCC_CARD_PO WHERE PO_NUMBER = h.PO_NUMBER),
			VCCClearedAmount = COALESCE(cleared.CLEARED_AMOUNT, 0),
			DisplayPONumber = CASE
								WHEN h.PO_APPROVAL_FLAG IS NOT NULL THEN
									CASE
										WHEN h.PO_APPROVAL_FLAG = 0 OR h.PO_APPROVAL_FLAG IS NULL THEN '(Pending)'
										WHEN h.PO_APPROVAL_FLAG = 1 THEN '(Pending)'
										WHEN h.PO_APPROVAL_FLAG = 2 THEN CONVERT(VARCHAR(12), h.PO_NUMBER)
										WHEN h.PO_APPROVAL_FLAG = 3 THEN '(Denied)'
										ELSE CONVERT(VARCHAR(12), h.PO_NUMBER)
									END 
								ELSE
									CASE
										WHEN h.PO_APPR_RULE_CODE IS NULL OR h.PO_APPR_RULE_CODE = '' OR ec.PO_LIMIT IS NULL THEN CONVERT(VARCHAR(12), h.PO_NUMBER)
										WHEN h.EXCEED = 0 AND (h.PO_PRINTED = 0 OR h.PO_PRINTED IS NULL) THEN '(Incomplete)'
										WHEN h.EXCEED = 0 AND h.PO_PRINTED = 1 THEN CONVERT(VARCHAR(12), h.PO_NUMBER)
										WHEN h.EXCEED = 1 THEN '(Incomplete)'
										ELSE CONVERT(VARCHAR(12), h.PO_NUMBER)
									END
								END,
			NeedsApproval = CAST(CASE WHEN h.PO_APPROVAL_FLAG = 1 OR h.PO_APPROVAL_FLAG = 3 THEN 1 ELSE 0 END as bit),
			PaidWithOrderAmount = CAST(COALESCE(CASE WHEN COALESCE(cleared.CLEARED_AMOUNT, 0) <> 0 THEN cleared.CLEARED_AMOUNT
										WHEN COALESCE(cleared.CLEARED_AMOUNT, 0) = 0 AND COALESCE(pending.PENDING_AMOUNT, 0) <> 0 THEN pending.PENDING_AMOUNT
										WHEN COALESCE(cleared.CLEARED_AMOUNT, 0) = 0 AND COALESCE(pending.PENDING_AMOUNT, 0) = 0 THEN 
											(SELECT CARD_AMOUNT FROM dbo.VCC_CARD_PO WHERE PO_NUMBER = h.PO_NUMBER)
								END, 0) as decimal)
		FROM dbo.PURCHASE_ORDER h
			INNER JOIN dbo.PURCHASE_ORDER_DET d ON h.PO_NUMBER = d.PO_NUMBER AND @IncludeOrder = 1
			INNER JOIN dbo.VENDOR v ON ( h.VN_CODE = v.VN_CODE )
			LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON h.EMP_CODE = ec.EMP_CODE 
			LEFT OUTER JOIN dbo.JOB_LOG jl ON d.JOB_NUMBER = jl.JOB_NUMBER
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			LEFT OUTER JOIN dbo.PURCHASE_ORDER_STATUS os ON h.PO_NUMBER = os.PO_NUMBER AND h.PO_REVISION = os.REV_NBR AND os.[STATUS] = 5
			LEFT OUTER JOIN dbo.VEN_CONT vc ON h.VN_CODE = vc.VN_CODE AND h.VN_CONT_CODE = vc.VC_CODE AND COALESCE(vc.VC_INACTIVE_FLAG, 0) = 0
			LEFT OUTER JOIN (
						SELECT SUM(vcd.AMOUNT) AS CLEARED_AMOUNT, vc.PO_NUMBER
						FROM dbo.VCC_CARD_PO_DTL vcd
							INNER JOIN dbo.VCC_CARD_PO vc ON vcd.VCC_CARD_PO_ID = vc.VCC_CARD_PO_ID
						WHERE [ACTION] = 4
						GROUP BY vc.PO_NUMBER
						) cleared ON cleared.PO_NUMBER = h.PO_NUMBER
			LEFT OUTER JOIN (
						SELECT SUM(vcd.AMOUNT) AS PENDING_AMOUNT, vc.PO_NUMBER
						FROM dbo.VCC_CARD_PO_DTL vcd
							INNER JOIN dbo.VCC_CARD_PO vc ON vcd.VCC_CARD_PO_ID = vc.VCC_CARD_PO_ID
						WHERE [ACTION] = 3
						GROUP BY vc.PO_NUMBER
						) pending ON pending.PO_NUMBER = h.PO_NUMBER
		WHERE
			COALESCE(h.VOID_FLAG, 0) = 0
		AND	(h.PO_COMPLETE IS NULL OR h.PO_COMPLETE = 0)
		AND	(h.LOCK_USER = @UserCode OR @LoadLockedOrders = 1)
		AND ((
				( @IncludeOrderLineDates = 0 )
			OR
				( @IncludeOrderLineDates = 1 AND ( h.PO_DATE BETWEEN @OrderLineStartDate AND @OrderLineEndDate ) )
			)
			AND
			(
				( @IncludeJobMediaDateToBill = 0 )
			OR
				( @IncludeJobMediaDateToBill = 1 AND ( jc.MEDIA_BILL_DATE between @JobMediaStartDate AND @JobMediaEndDate ) )
			)
			AND
			(
				( @include_media_month = 0 )
			OR
				( @include_media_month = 1 AND (CAST(CAST(YEAR(COALESCE(h.PO_DATE, '1/1/1900')) as varchar(4)) + right('0'+ CAST(MONTH(COALESCE(h.PO_DATE, '1/1/1900')) as varchar(2)), 2) as int) BETWEEN @media_month_start_date and @media_month_end_date ))
			))
		AND (@CampaignIDList IS NULL OR (@CampaignIDList IS NOT NULL AND jl.CMP_IDENTIFIER IN (SELECT * FROM dbo.udf_split_list(@CampaignIDList, ','))))
		AND (@ClientCodeList IS NULL OR (@ClientCodeList IS NOT NULL AND jl.CL_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientCodeList, ','))))
		AND (@ClientDivisionCodeList IS NULL OR (@ClientDivisionCodeList IS NOT NULL AND jl.CL_CODE + '|' + jl.DIV_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionCodeList, ','))))
		AND (@ClientDivisionProductCodeList IS NULL OR (@ClientDivisionProductCodeList IS NOT NULL AND jl.CL_CODE + '|' + jl.DIV_CODE + '|' + jl.PRD_CODE IN (SELECT * FROM dbo.udf_split_list(@ClientDivisionProductCodeList, ','))))
		AND (@JobNumberList IS NULL OR (@JobNumberList IS NOT NULL
										AND d.JOB_NUMBER IS NOT NULL 
										AND d.JOB_NUMBER IN (SELECT * FROM dbo.udf_split_list(@JobNumberList, ','))))
		AND (@JobNumberComponentNumberList IS NULL OR (@JobNumberComponentNumberList IS NOT NULL
														AND d.JOB_NUMBER IS NOT NULL AND d.JOB_COMPONENT_NBR IS NOT NULL
														AND CAST(d.JOB_NUMBER AS varchar(20)) + '|' + CAST(d.JOB_COMPONENT_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@JobNumberComponentNumberList, ','))))
		AND (@PONumberList IS NULL OR (@PONumberList IS NOT NULL
											AND h.PO_NUMBER IS NOT NULL
											AND h.PO_NUMBER IN (SELECT * FROM dbo.udf_split_list(@PONumberList, ','))))
		AND (@AEJobEmployeeCodeList IS NULL OR (@AEJobEmployeeCodeList IS NOT NULL AND jc.EMP_CODE IN (SELECT * FROM dbo.udf_split_list(@AEJobEmployeeCodeList, ','))))
		AND (@VendorCodeList IS NULL OR (@VendorCodeList IS NOT NULL AND h.VN_CODE IN (SELECT * FROM dbo.udf_split_list(@VendorCodeList, ','))))
		AND
			(
				( @LimitedByOffice = 0 )
		OR
				( @LimitedByOffice = 1 AND v.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
			)
		OR ( @SelectForServiceRefresh = 1 AND EXISTS (
														SELECT 1
														FROM dbo.VCC_CARD_PO v
														WHERE v.PO_NUMBER = h.PO_NUMBER
														AND v.[STATUS] = 'A'
													))
	END

END