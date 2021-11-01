﻿IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_account_executive]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_dd_account_executive]
GO

CREATE PROCEDURE [dbo].[usp_wv_dd_account_executive]
@Client AS VARCHAR(6), 
@Division AS VARCHAR(6), 
@Product AS VARCHAR(6),
@USER_CODE AS VARCHAR(100),
@OfficeCode AS VARCHAR(6) = null
AS
	--EXEC [dbo].[usp_wv_dd_account_executive] '','','','sysadm',''
/*=========== QUERY ===========*/
	DECLARE 
		@OfficeRestrictions AS INT,	@ClientRestrictions INT,
		@EMP_CODE AS VARCHAR(6),
		@COMPARE_OFFCE AS BIT

	SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@USER_CODE);
	SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;

	Select @ClientRestrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@USER_CODE)

	if @OfficeCode = ''
		SET @OfficeCode = NULL

	if @Client = ''
		SET @Client = NULL
	if @Division = ''
		SET @Division = NULL
	if @Product = ''
		SET @Product = NULL

	SET @COMPARE_OFFCE = 0

	if @OfficeCode is not null and @Client is null and @Division is null and @Product is null
		SET @COMPARE_OFFCE = 1

	IF @OfficeRestrictions > 0
	BEGIN
		IF @ClientRestrictions > 0
		BEGIN
			SELECT DISTINCT 
				ACCOUNT_EXECUTIVE.EMP_CODE AS Code, 
				ACCOUNT_EXECUTIVE.EMP_CODE+ISNULL(' - '+V_ACTIVE_EMPLOYEE.EMP_FML,'') AS [Description]
				,V_ACTIVE_EMPLOYEE.EMP_FML Name
			FROM
				ACCOUNT_EXECUTIVE 
				INNER JOIN V_ACTIVE_EMPLOYEE ON ACCOUNT_EXECUTIVE.EMP_CODE = V_ACTIVE_EMPLOYEE.EMP_CODE
				INNER JOIN PRODUCT P ON ACCOUNT_EXECUTIVE.CL_CODE = P.CL_CODE AND ACCOUNT_EXECUTIVE.DIV_CODE = P.DIV_CODE AND ACCOUNT_EXECUTIVE.PRD_CODE = P.PRD_CODE
				INNER JOIN EMP_OFFICE EO ON P.OFFICE_CODE = EO.OFFICE_CODE
				INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = ACCOUNT_EXECUTIVE.CL_CODE AND SEC_CLIENT.DIV_CODE = ACCOUNT_EXECUTIVE.DIV_CODE AND SEC_CLIENT.PRD_CODE = ACCOUNT_EXECUTIVE.PRD_CODE
				INNER JOIN EMPLOYEE_CLOAK on EMPLOYEE_CLOAK.EMP_CODE = ACCOUNT_EXECUTIVE.EMP_CODE
			WHERE 
				(INACTIVE_FLAG <> 1 OR INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)
				AND ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') = CASE WHEN @COMPARE_OFFCE = 1 THEN @OfficeCode ELSE ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') END
				AND (ACCOUNT_EXECUTIVE.CL_CODE = ISNULL(@Client,ACCOUNT_EXECUTIVE.CL_CODE)) 
				AND (ACCOUNT_EXECUTIVE.DIV_CODE = ISNULL(@Division,ACCOUNT_EXECUTIVE.DIV_CODE))
				AND (ACCOUNT_EXECUTIVE.PRD_CODE = ISNULL(@Product,ACCOUNT_EXECUTIVE.PRD_CODE))
				AND EO.EMP_CODE = @EMP_CODE AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@USER_CODE) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
				order by V_ACTIVE_EMPLOYEE.EMP_FML
		END
		ELSE
		BEGIN
			SELECT DISTINCT 
				ACCOUNT_EXECUTIVE.EMP_CODE AS Code, 
				ACCOUNT_EXECUTIVE.EMP_CODE+ISNULL(' - '+V_ACTIVE_EMPLOYEE.EMP_FML,'') AS [Description]
				,V_ACTIVE_EMPLOYEE.EMP_FML Name
			FROM
				ACCOUNT_EXECUTIVE 
				INNER JOIN V_ACTIVE_EMPLOYEE ON ACCOUNT_EXECUTIVE.EMP_CODE = V_ACTIVE_EMPLOYEE.EMP_CODE
				INNER JOIN PRODUCT P ON ACCOUNT_EXECUTIVE.CL_CODE = P.CL_CODE AND ACCOUNT_EXECUTIVE.DIV_CODE = P.DIV_CODE AND ACCOUNT_EXECUTIVE.PRD_CODE = P.PRD_CODE
				INNER JOIN EMP_OFFICE EO ON P.OFFICE_CODE = EO.OFFICE_CODE
				INNER JOIN EMPLOYEE_CLOAK on EMPLOYEE_CLOAK.EMP_CODE = ACCOUNT_EXECUTIVE.EMP_CODE
			WHERE 
				(INACTIVE_FLAG <> 1 OR INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)
				AND ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') = CASE WHEN @COMPARE_OFFCE = 1 THEN @OfficeCode ELSE ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') END
				AND (ACCOUNT_EXECUTIVE.CL_CODE = ISNULL(@Client,ACCOUNT_EXECUTIVE.CL_CODE)) 
				AND (ACCOUNT_EXECUTIVE.DIV_CODE = ISNULL(@Division,ACCOUNT_EXECUTIVE.DIV_CODE))
				AND (ACCOUNT_EXECUTIVE.PRD_CODE = ISNULL(@Product,ACCOUNT_EXECUTIVE.PRD_CODE))
				AND EO.EMP_CODE = @EMP_CODE
				order by V_ACTIVE_EMPLOYEE.EMP_FML
		END				
	END
	ELSE
	BEGIN
		IF @ClientRestrictions > 0
		BEGIN
			SELECT DISTINCT 
				ACCOUNT_EXECUTIVE.EMP_CODE AS Code, 
				ACCOUNT_EXECUTIVE.EMP_CODE+ISNULL(' - '+V_ACTIVE_EMPLOYEE.EMP_FML,'') AS [Description]
				,V_ACTIVE_EMPLOYEE.EMP_FML Name
			FROM
				ACCOUNT_EXECUTIVE 
				INNER JOIN V_ACTIVE_EMPLOYEE ON ACCOUNT_EXECUTIVE.EMP_CODE = V_ACTIVE_EMPLOYEE.EMP_CODE
				INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = ACCOUNT_EXECUTIVE.CL_CODE AND SEC_CLIENT.DIV_CODE = ACCOUNT_EXECUTIVE.DIV_CODE AND SEC_CLIENT.PRD_CODE = ACCOUNT_EXECUTIVE.PRD_CODE
				INNER JOIN EMPLOYEE_CLOAK on EMPLOYEE_CLOAK.EMP_CODE = ACCOUNT_EXECUTIVE.EMP_CODE
			WHERE 
				(INACTIVE_FLAG <> 1 OR INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)
				AND ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') = CASE WHEN @COMPARE_OFFCE = 1 THEN @OfficeCode ELSE ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') END
				AND (ACCOUNT_EXECUTIVE.CL_CODE = ISNULL(@Client,ACCOUNT_EXECUTIVE.CL_CODE)) 
				AND (ACCOUNT_EXECUTIVE.DIV_CODE = ISNULL(@Division,ACCOUNT_EXECUTIVE.DIV_CODE))
				AND (ACCOUNT_EXECUTIVE.PRD_CODE = ISNULL(@Product,ACCOUNT_EXECUTIVE.PRD_CODE))
				AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@USER_CODE) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
				order by V_ACTIVE_EMPLOYEE.EMP_FML

		END
		ELSE
		BEGIN
		
			SELECT DISTINCT 
				ACCOUNT_EXECUTIVE.EMP_CODE AS Code, 
				ACCOUNT_EXECUTIVE.EMP_CODE+ISNULL(' - '+V_ACTIVE_EMPLOYEE.EMP_FML,'') AS [Description]
				,V_ACTIVE_EMPLOYEE.EMP_FML Name
			FROM
				ACCOUNT_EXECUTIVE 
				INNER JOIN V_ACTIVE_EMPLOYEE ON ACCOUNT_EXECUTIVE.EMP_CODE = V_ACTIVE_EMPLOYEE.EMP_CODE
				INNER JOIN EMPLOYEE_CLOAK on EMPLOYEE_CLOAK.EMP_CODE = ACCOUNT_EXECUTIVE.EMP_CODE
			WHERE 
				(INACTIVE_FLAG <> 1 OR INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)
				AND ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') = CASE WHEN @COMPARE_OFFCE = 1 THEN @OfficeCode ELSE ISNULL(EMPLOYEE_CLOAK.OFFICE_CODE,'') END
				AND (ACCOUNT_EXECUTIVE.CL_CODE = ISNULL(@Client,ACCOUNT_EXECUTIVE.CL_CODE)) 
				AND (ACCOUNT_EXECUTIVE.DIV_CODE = ISNULL(@Division,ACCOUNT_EXECUTIVE.DIV_CODE))
				AND (ACCOUNT_EXECUTIVE.PRD_CODE = ISNULL(@Product,ACCOUNT_EXECUTIVE.PRD_CODE))
				order by V_ACTIVE_EMPLOYEE.EMP_FML
		END				
	END