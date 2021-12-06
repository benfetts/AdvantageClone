CREATE PROCEDURE [dbo].[advsp_ap_available_internet_orders] @vn_code varchar(6) = NULL, @office_code varchar(4) = NULL,
			@cl_code varchar(6) = NULL, @div_code varchar(6) = NULL, @prd_code varchar(6) = NULL, @batch_name varchar(50) = NULL,
			@source_code varchar(2) = NULL, @order_id int = NULL, @user_code varchar(100)
AS
-- 20160118 MJC do not allow QUOTEs to be selected
-- 20160721 MJC Apply office limits and CDP limits to Accounts Payable
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @EmployeeCode varchar(6),
			@HasCDPLimits bit,
			@HasOfficeLimits bit
	
	SET @HasCDPLimits = 0
	
	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@user_code)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@user_code)) > 0
		SET @HasCDPLimits = 1
	
	IF (SELECT COUNT(1) FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode) > 0
		SET @HasOfficeLimits = 1
	ELSE
		SET @HasOfficeLimits = 0

	DECLARE @BatchOrders TABLE (
		ORDER_NUMBER int NULL
	)
	
	IF @batch_name IS NOT NULL
		INSERT @BatchOrders 
		SELECT DISTINCT M.ORDER_NUMBER 
		FROM dbo.IMP_AP_HEADER H
			INNER JOIN dbo.IMP_AP_MEDIA M ON H.IMPORT_ID = M.IMPORT_ID 
		WHERE BATCH_NAME = @batch_name
		AND M.MEDIA_TYPE = 'I'
	
	DECLARE @ORDERS TABLE (
		[ClientCode] varchar(6) NULL,
		[DivisionCode] varchar(6) NULL,
		[ProductCode] varchar(6) NULL,
		[OrderNumber] int NULL,
		[LineNumber] smallint NULL,
		[InsertDate] smalldatetime NULL,
		[OrderDescription] varchar(40) NULL,
		[Placement] varchar(256) NULL,
		[LinkID] int NULL,
		[ClientPO] varchar(25) NULL,
		[VendorCode] varchar(6) NULL,
		[OfficeCode] varchar(4) NULL,
		[EndDate] smalldatetime NULL,
        [Type] varchar(6) NULL,
        [CampaignCode] varchar(6) NULL,
        [CampaignName] varchar(128) NULL
	)
	
	INSERT @ORDERS 
	SELECT DISTINCT
		[ClientCode] = A.CL_CODE,
		[DivisionCode] = A.DIV_CODE,
		[ProductCode] = A.PRD_CODE,
		[OrderNumber] = A.ORDER_NBR,
		[LineNumber] = O.LINE_NBR,
		[InsertDate] = O.[START_DATE],
		[OrderDescription] = A.ORDER_DESC,
		[Placement] = O.PLACEMENT_1,
		[LinkID] = A.LINK_ID,
		[ClientPO] = A.CLIENT_PO,
		[VendorCode] = A.VN_CODE,
		[OfficeCode] = D.OFFICE_CODE,
		[EndDate] = O.END_DATE,
        [Type] = O.INTERNET_TYPE,
        [CampaignCode] = C.CMP_CODE,
        [CampaignName] = C.CMP_NAME
	FROM
		[dbo].INTERNET_HEADER A 
		INNER JOIN [dbo].VENDOR B ON A.VN_CODE = B.VN_CODE
		INNER JOIN [dbo].INTERNET_DETAIL O ON A.ORDER_NBR = O.ORDER_NBR 
		INNER JOIN [dbo].PRODUCT D ON A.CL_CODE = D.CL_CODE AND A.DIV_CODE = D.DIV_CODE AND A.PRD_CODE = D.PRD_CODE
        LEFT OUTER JOIN [dbo].CAMPAIGN C ON A.CMP_IDENTIFIER = C.CMP_IDENTIFIER
	WHERE	
				A.MEDIA_TYPE IS NOT NULL
		AND		COALESCE(A.[STATUS], 0) = 0 -- 20160118 MJC do not allow QUOTEs to be selected
		AND		O.BILL_TYPE_FLAG <> 1
		AND   	A.ORD_PROCESS_CONTRL NOT IN (5,6,12)
		AND		O.ACTIVE_REV = 1
		AND  	(LINE_CANCELLED IS NULL OR LINE_CANCELLED = 0)
		AND		(@office_code IS NULL OR D.OFFICE_CODE = @office_code)
		AND		(@vn_code IS NULL OR A.VN_CODE = @vn_code OR B.VN_PAY_TO_CODE = @vn_code) 
		AND		(@cl_code IS NULL OR A.CL_CODE = @cl_code)
		AND		(@div_code IS NULL OR A.DIV_CODE = @div_code)
		AND		(@prd_code IS NULL OR A.PRD_CODE = @prd_code)
		AND		(@batch_name IS NULL OR (@batch_name IS NOT NULL AND A.ORDER_NBR IN (SELECT ORDER_NUMBER FROM @BatchOrders)))
		AND		(
					( @HasCDPLimits = 1 AND EXISTS (
													SELECT 1
													FROM dbo.SEC_CLIENT sc
													WHERE UPPER(sc.[USER_ID]) = UPPER(@user_code)
													AND sc.CL_CODE = A.CL_CODE
													AND sc.DIV_CODE = A.DIV_CODE
													AND sc.PRD_CODE = A.PRD_CODE)
													AND D.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
												   )
					OR
					( @HasCDPLimits = 0 AND D.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
				)
		AND
				(
					( @HasOfficeLimits = 1 AND B.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
				OR
					( @HasOfficeLimits = 0 )
				)

	IF @order_id IS NOT NULL AND @source_code IS NOT NULL
		SELECT O.*
		FROM @ORDERS O
			INNER JOIN dbo.PRINT_IMPORT_XREF PIX ON O.OrderNumber = PIX.ORDER_NBR AND PIX.IMPORT_ORDER_NBR = @order_id
													AND O.LineNumber = PIX.LINE_NBR AND PIX.IMPORTED_FROM = @source_code
													AND PIX.MEDIA_TYPE = 'I'
		ORDER BY
			[OrderNumber], [LineNumber]
	ELSE
		SELECT O.*
		FROM @ORDERS O
		ORDER BY
			[OrderNumber], [LineNumber]
			
END

GO
