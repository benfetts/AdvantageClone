SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetProductsAE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetProductsAE]
GO


CREATE PROCEDURE [dbo].[usp_wv_dd_GetProductsAE] 
@UserID VarChar(100) , 
@ClientCode VarChar(6), 
@DivisionCode VarChar(6),
@OBJECT_ID INT
AS
/*=========== QUERY ===========*/
	DECLARE 
	@RESTRICTIONS INT, 
	@EMP_CODE VARCHAR(6),
	@EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT,
	@SQL VARCHAR(MAX), @OfficeCount AS INTEGER;

	SET NOCOUNT ON

	SELECT @RESTRICTIONS = COUNT(*) 
	FROM SEC_CLIENT WITH(NOLOCK)
	WHERE UPPER(USER_ID) = UPPER(@UserID);

	SELECT @EMP_CODE = EMP_CODE
	FROM SEC_USER WITH(NOLOCK)
	WHERE UPPER(USER_CODE) = UPPER(@UserID);

	SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EMP_CODE, @OBJECT_ID); 

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;

	SET @SQL = '
	
		SELECT   
			DISTINCT  
			PRODUCT.PRD_CODE AS Code,
			PRODUCT.PRD_CODE + '' - '' + ISNULL(PRODUCT.PRD_DESCRIPTION, '''')  AS [Description],
			PRODUCT.CL_CODE + '':'' + PRODUCT.DIV_CODE + '':'' + PRODUCT.PRD_CODE AS SplitPK, 
			PRODUCT.CL_CODE + '' | '' + PRODUCT.DIV_CODE + '' | '' + PRODUCT.PRD_CODE + '' - '' + ISNULL(PRODUCT.PRD_DESCRIPTION, '''')  AS DescriptionWithExtra,
			PRODUCT.CL_CODE,
			PRODUCT.DIV_CODE
		FROM         
			CLIENT INNER JOIN
			DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE INNER JOIN
			PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE 

		'
		
		IF @RESTRICTIONS = 1
		BEGIN		
			
			SET @SQL = @SQL + '
			
			INNER JOIN SEC_CLIENT ON PRODUCT.CL_CODE = SEC_CLIENT.CL_CODE AND PRODUCT.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
			PRODUCT.PRD_CODE = SEC_CLIENT.PRD_CODE
			
			'
			
		END	

	IF @OfficeCount > 0
	BEGIN

		SET @SQL = @SQL + ' INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '

	END

	IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1
	BEGIN		
	
		SET @SQL = @SQL + ' 
		
			INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](' + CONVERT(VARCHAR, @OBJECT_ID) + ', ''' + @EMP_CODE + ''') AS DR
			
			'
			
		SET @SQL = @SQL + ' 
		
			ON PRODUCT.PRD_CODE = DR.PRD_CODE
			
			'
			
		IF NOT @ClientCode IS NULL AND RTRIM(LTRIM(@ClientCode)) <> ''
		BEGIN
		
			SET @SQL = @SQL + '		
			AND DIVISION.CL_CODE = DR.CL_CODE 
			'
		
		END
							
		IF NOT @DivisionCode IS NULL AND RTRIM(LTRIM(@DivisionCode)) <> ''
		BEGIN	
						
			SET @SQL = @SQL + ' AND DIVISION.DIV_CODE = DR.DIV_CODE '
			
		END				
	
	END	

		
		SET @SQL = @SQL + '
		
		WHERE     
			(PRODUCT.ACTIVE_FLAG = 1) 
			
		'
		
		IF @RESTRICTIONS = 1
		BEGIN
		
			SET @SQL = @SQL + '	
			
			AND SEC_CLIENT.USER_ID = UPPER(''' + @UserID + ''') 
			AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
			
			'
		
		END
		
		IF NOT @ClientCode IS NULL AND RTRIM(LTRIM(@ClientCode)) <> ''
		BEGIN
		
			SET @SQL = @SQL + '	
				AND (PRODUCT.CL_CODE = ''' + @ClientCode + ''') 
			'
		
		END
		IF NOT @DivisionCode IS NULL AND RTRIM(LTRIM(@DivisionCode)) <> ''
		BEGIN
		
			SET @SQL = @SQL + '	
				AND (PRODUCT.DIV_CODE = ''' + @DivisionCode + ''') 
			'
		
		END		
	
	--PRINT @SQL;	
	EXEC(@SQL);

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO