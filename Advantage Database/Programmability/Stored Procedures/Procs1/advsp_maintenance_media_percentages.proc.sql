CREATE PROCEDURE [dbo].[advsp_maintenance_media_percentages] @user_code varchar(100)

AS
BEGIN

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

	SELECT
		[ClientCode] = P.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = P.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = PRD_CODE,
		[ProductDescription] = PRD_DESCRIPTION,
		[RadioRebate] = PRD_RADIO_REBATE,
		[TVRebate] = PRD_TV_REBATE,
		[MagazineRebate] = PRD_MAG_REBATE,
		[NewspaperRebate] = PRD_NEWS_REBATE,
		[OutdoorRebate] = PRD_OTDR_REBATE,
		[InternetRebate] = PRD_MISC_REBATE,
		[RadioMarkup] = PRD_RADIO_COMM,
		[TVMarkup] = PRD_TV_COMM,
		[MagazineMarkup] = PRD_MAG_COMM,
		[NewspaperMarkup] = PRD_NEWS_COMM,
		[OutdoorMarkup] = PRD_OTDR_COMM,
		[InternetMarkup] = PRD_MISC_COMM
	FROM dbo.PRODUCT P
		INNER JOIN dbo.CLIENT C ON C.CL_CODE = P.CL_CODE AND C.ACTIVE_FLAG = 1
		INNER JOIN dbo.DIVISION D ON D.CL_CODE = P.CL_CODE AND D.DIV_CODE = P.DIV_CODE AND D.ACTIVE_FLAG = 1
	WHERE
			P.ACTIVE_FLAG = 1
	AND		(
					( @HasCDPLimits = 1 AND EXISTS (
													SELECT 1
													FROM dbo.SEC_CLIENT sc
													WHERE UPPER(sc.[USER_ID]) = UPPER(@user_code)
													AND sc.CL_CODE = P.CL_CODE
													AND sc.DIV_CODE = P.DIV_CODE
													AND sc.PRD_CODE = P.PRD_CODE)
													AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
												   )
					OR
					( @HasCDPLimits = 0 AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
				)
		AND
				(
					( @HasOfficeLimits = 1 AND P.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits(@EmployeeCode)))
				OR
					( @HasOfficeLimits = 0 )
				)
END
GO
