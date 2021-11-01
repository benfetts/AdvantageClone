CREATE PROCEDURE [dbo].[advsp_ap_available_production_jobs]
	@user_code varchar(100), @office_code varchar(4) = NULL, @cl_code varchar(6) = NULL, @div_code varchar(6) = NULL, @prd_code varchar(6) = NULL, @include_closed_jobs as bit = 0
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @EmployeeCode varchar(6),
			@HasCDPLimits bit
	
	SET @HasCDPLimits = 0
	
	SELECT @EmployeeCode = EMP_CODE
	FROM dbo.SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@user_code)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@user_code)) > 0
		SET @HasCDPLimits = 1

	SELECT *
	FROM (
		SELECT DISTINCT
			[Number] = A.JOB_NUMBER,
			[Description] = JOB_DESC,
			[ClientCode] = A.CL_CODE,
			[DivisionCode] = A.DIV_CODE,
			[ProductCode] = A.PRD_CODE,
			[OfficeCode] = A.OFFICE_CODE,
			[IsClosed] = CAST(CASE WHEN B.JOB_PROCESS_CONTRL IN (6, 12) THEN 1 ELSE 0 END as bit)
		FROM	dbo.JOB_LOG A
			INNER JOIN dbo.JOB_COMPONENT B ON A.JOB_NUMBER = B.JOB_NUMBER
		WHERE	A.SC_CODE IS NOT NULL
		AND  	(
					(@include_closed_jobs = 0 AND B.JOB_PROCESS_CONTRL IN ( 1, 3, 4, 8, 9, 13 ))
				OR
					(@include_closed_jobs = 1)
				)
		AND		(@cl_code IS NULL OR A.CL_CODE = @cl_code)
		AND		(@div_code IS NULL OR A.DIV_CODE = @div_code)
		AND		(@prd_code IS NULL OR A.PRD_CODE = @prd_code)
		AND		(@office_code IS NULL OR A.OFFICE_CODE = @office_code)
		) JOBS
	WHERE
		(
		( @HasCDPLimits = 1 AND EXISTS (
										SELECT 1
										FROM dbo.SEC_CLIENT sc
										WHERE UPPER(sc.[USER_ID]) = UPPER(@user_code)
										AND sc.CL_CODE = JOBS.ClientCode
										AND sc.DIV_CODE = JOBS.DivisionCode
										AND sc.PRD_CODE = JOBS.ProductCode)
										AND JOBS.OfficeCode IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
									   )
		OR
		( @HasCDPLimits = 0 AND JOBS.OfficeCode IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode)))
		)
	ORDER BY
		JOBS.Number
END
GO