SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetDivisionsAE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetDivisionsAE]
GO
/*****************************************************************
Gets Divisions for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetDivisionsAE] 
@UserID VarChar(100) , 
@ClientCode VarChar(6),
@OBJECT_ID INT
AS
/*=========== QUERY ===========*/
	SET NOCOUNT ON
	
	DECLARE 
	@RESTRICTIONS INT, 
	@EMP_CODE VARCHAR(6),
	@EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT, @OfficeCount AS INTEGER;

	SELECT @RESTRICTIONS = COUNT(*) 
	FROM SEC_CLIENT WITH(NOLOCK)
	WHERE UPPER(USER_ID) = UPPER(@UserID);
	
	SELECT @EMP_CODE = EMP_CODE
	FROM SEC_USER WITH(NOLOCK)
	WHERE UPPER(USER_CODE) = UPPER(@UserID);
	
	SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EMP_CODE, @OBJECT_ID); 

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;

	DECLARE @SQL VARCHAR(MAX);
	
	SET @SQL = '
	
		SELECT     
			DISTINCT DIVISION.DIV_CODE AS Code,  
			DIVISION.DIV_CODE + '' - '' + ISNULL(DIVISION.DIV_NAME, '''')  AS Description,
			DIVISION.CL_CODE + '':'' + DIVISION.DIV_CODE AS SplitPK,
			DIVISION.CL_CODE + '' | '' + DIVISION.DIV_CODE + '' - '' + ISNULL(DIVISION.DIV_NAME, '''')  AS DescriptionWithExtra,
			DIVISION.CL_CODE
		FROM        
			CLIENT INNER JOIN
			DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE
			 
		'
		
	IF @RESTRICTIONS > 0
	BEGIN		
	
		SET @SQL = @SQL + ' INNER JOIN SEC_CLIENT ON DIVISION.CL_CODE = SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = SEC_CLIENT.DIV_CODE '
	
	END	
	
	IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1
	BEGIN		
	
		SET @SQL = @SQL + ' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](' + CONVERT(VARCHAR, @OBJECT_ID) + ', ''' + @EMP_CODE + ''') AS DR
							ON DIVISION.CL_CODE = DR.CL_CODE AND DIVISION.DIV_CODE = DR.DIV_CODE '
	
	END	

	IF @OfficeCount > 0
	BEGIN

		SET @SQL = @SQL + ' INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE 
							INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '

	END
			
	SET @SQL = @SQL +'
		
		WHERE     
			(DIVISION.ACTIVE_FLAG = 1) 
			AND (CLIENT.ACTIVE_FLAG = 1) 
		'
		
	IF (NOT @ClientCode IS NULL) AND RTRIM(LTRIM(@ClientCode)) <> ''
	BEGIN 
		SET @SQL = @SQL + ' AND (CLIENT.CL_CODE = ''' + @ClientCode + ''') '
	END
	
	IF @RESTRICTIONS > 0
	BEGIN		
	
		SET @SQL = @SQL +' 
					
			AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) 
			AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) 
	
		'	
	END
	
	EXEC(@SQL);

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO