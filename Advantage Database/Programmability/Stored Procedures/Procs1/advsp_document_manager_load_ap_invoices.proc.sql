CREATE PROC advsp_document_manager_load_ap_invoices
	@user_code varchar(100), @show_with_document bit, @show_without_document bit
AS
BEGIN
	DECLARE @EmployeeCode varchar(6),
			@HasOfficeLimits bit
	
	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@user_code)
	
	IF (SELECT COUNT(1) FROM dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode) > 0
		SET @HasOfficeLimits = 1
	ELSE
		SET @HasOfficeLimits = 0

	SELECT DISTINCT
		[ID] = AH.AP_ID,
		[VendorCode] = AH.VN_FRL_EMP_CODE,
		[VendorName] = V.VN_NAME,
		[InvoiceNumber] = AH.AP_INV_VCHR, 
		[InvoiceDescription] = AH.AP_DESC,
		[InvoiceDate] = AH.AP_INV_DATE,
		[OfficeCode] = AH.OFFICE_CODE,
		[OfficeName] = O.OFFICE_NAME
	FROM dbo.AP_HEADER AH
		INNER JOIN dbo.VENDOR V ON AH.VN_FRL_EMP_CODE = V.VN_CODE
		LEFT OUTER JOIN dbo.OFFICE O ON AH.OFFICE_CODE = O.OFFICE_CODE
	WHERE
		(
			( @HasOfficeLimits = 1 
				AND (V.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
				AND (O.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
			)
		OR
			( @HasOfficeLimits = 0 )
		)
	AND
		(
			( @show_with_document = 1 AND @show_without_document = 1)
		OR
			( @show_with_document = 1 AND @show_without_document = 0 AND AH.AP_ID IN (SELECT AP_ID FROM dbo.AP_DOCUMENTS))
		OR
			( @show_with_document = 0 AND @show_without_document = 1 AND AH.AP_ID NOT IN (SELECT AP_ID FROM dbo.AP_DOCUMENTS))
		)
	ORDER BY AH.AP_INV_DATE DESC
END
GO
