CREATE PROCEDURE [dbo].[advsp_bcc_other_user_media] @bcc_id_in integer

AS
BEGIN
	DECLARE @BILLING_USER varchar(100),
			@EmployeeCode varchar(6),
			@HasOfficeLimits bit

	SET NOCOUNT ON
	
	SELECT @BILLING_USER = SUBSTRING(BILLING_USER,1,LEN(BILLING_USER) - 2)
	FROM dbo.BILLING_CMD_CENTER 
	WHERE BCC_ID = @bcc_id_in 
	
	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	where UPPER(USER_CODE) = UPPER(@BILLING_USER)

	IF (SELECT COUNT(1) FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode) > 0
		SET @HasOfficeLimits = 1
	ELSE
		SET @HasOfficeLimits = 0

	SELECT
		[BillingCommandCenterID] = bcc.BCC_ID,
		[BillingUser] = SUBSTRING(bcc.BILLING_USER,1,LEN(bcc.BILLING_USER) - 2),
		[EmployeeName] = dbo.advfn_get_emp_name( su.EMP_CODE, 'FML' ),
		[MediaFrom] = vmh.MEDIA_FROM, 
		[OrderNumber] = bol.ORDER_NBR,
		[LineNumber] = bol.LINE_NBR, 
		[ClientCode] = vmh.CL_CODE, 
		[DivisionCode] = vmh.DIV_CODE, 
		[ProductCode] = vmh.PRD_CODE,
		[BatchName] = bcc.BATCH_NAME,
		[BillingUserRaw] = bcc.BILLING_USER
	FROM dbo.BCC_ORDER_LINE bol 
		INNER JOIN dbo.BILLING_CMD_CENTER bcc ON ( bcc.BCC_ID = bol.BCC_ID ) 
		INNER JOIN dbo.V_MEDIA_HDR vmh ON ( vmh.ORDER_NBR = bol.ORDER_NBR )
		LEFT OUTER JOIN dbo.SEC_USER su ON ( UPPER(SUBSTRING(bcc.BILLING_USER,1,LEN(bcc.BILLING_USER) - 2)) = UPPER(su.USER_CODE) )
		LEFT OUTER JOIN dbo.EMPLOYEE_CLOAK ec ON su.EMP_CODE = ec.EMP_CODE
	WHERE
		bcc.MEDIA_FLAG = 1 
	AND bcc.BCC_ID <> @bcc_id_in
	AND	UPPER(SUBSTRING(bcc.BILLING_USER,1,LEN(bcc.BILLING_USER) - 2)) <> UPPER(@BILLING_USER)
	AND (
			su.EMP_CODE IS NULL  --other user cannot be found
		OR
			(
				( @HasOfficeLimits = 1 AND ec.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
			OR
				( @HasOfficeLimits = 0 )
			)
		)
	ORDER BY
		bcc.BILLING_USER ASC, vmh.MEDIA_FROM, bol.ORDER_NBR DESC, bol.LINE_NBR ASC
  
END

GO
