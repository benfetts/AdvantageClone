CREATE PROCEDURE [dbo].[advsp_rate_flag_entry_load]
	@BillingRateLevelID AS smallint,
	@EmployeeCode AS varchar(6) = '',
	@ShowInactives AS bit = 1
AS
BEGIN

	SELECT 
		[ID] = BR.BILLING_RATE_ID,
		[BillingRateLevelID] = BR.BILL_RATE_PREC_ID,
		[EmployeeCode] = BR.EMP_CODE,
		[EmployeeName] = COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,''),
		[FunctionCode] = BR.FNC_CODE,
		[FunctionDescription] = F.FNC_DESCRIPTION,
		[FunctionType] = F.FNC_TYPE,
		[ClientCode] = BR.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = BR.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = BR.PRD_CODE,
		[ProductName] = P.PRD_DESCRIPTION,
		[ProductOfficeCode] = P.OFFICE_CODE,
		[SalesClassCode] = BR.SC_CODE,
		[SalesClassDescription] = SC.SC_DESCRIPTION,
		[EffectiveDate] = BR.EFFECTIVE_DATE,
		[RateAmount] = BR.BILLING_RATE,
		[IsNonBillable] = BR.NOBILL_FLAG,
		[IsFeeTime] = BR.FEE_TIME,
		[IsTaxCommission] = BR.TAX_COMM_FLAGS,
		[IsCommission] = BR.COMMISSION,
		[IsTax] = BR.TAX_FLAG,
		[TaxCode] = BR.TAX_CODE,
		[IsInactive] = BR.INACTIVE_FLAG,
		[EmployeeTitleID] = BR.EMPLOYEE_TITLE_ID,
		[CurrentEmployeeTitleID] = E.EMPLOYEE_TITLE_ID,
		[EmployeeOfficeCode] = E.OFFICE_CODE
	FROM 
		[dbo].[BILLING_RATE] AS BR LEFT OUTER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS E ON E.EMP_CODE = BR.EMP_CODE LEFT OUTER JOIN
		[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = BR.FNC_CODE LEFT OUTER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = BR.CL_CODE LEFT OUTER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = BR.CL_CODE AND
								 D.DIV_CODE = BR.DIV_CODE LEFT OUTER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = BR.CL_CODE AND
								P.DIV_CODE = BR.DIV_CODE AND
								P.PRD_CODE = BR.PRD_CODE LEFT OUTER JOIN
		[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = BR.SC_CODE
	WHERE
		BR.BILL_RATE_PREC_ID = @BillingRateLevelID AND
		1 = CASE WHEN ISNULL(@EmployeeCode, '') = '' THEN 1 ELSE CASE WHEN BR.EMP_CODE = @EmployeeCode THEN 1 ELSE 0 END END AND
		1 = CASE WHEN ISNULL(@ShowInactives, 1) = 1 THEN 1 ELSE CASE WHEN BR.INACTIVE_FLAG IS NULL OR BR.INACTIVE_FLAG = 0 THEN 1 ELSE 0 END END

END

GO


