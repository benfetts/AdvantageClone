if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_GetEstimateComp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_GetEstimateComp]
GO





CREATE PROCEDURE [dbo].[usp_wv_dd_GetEstimateComp]
@Client varchar(6),
@Division varchar(6),
@Product varchar(6),
@UserID varchar(100),
@Estimate int,
@JobNum int,
@JobComp int
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT @sql = 'SELECT     RTRIM(LTRIM(STR(ESTIMATE_LOG.ESTIMATE_NUMBER)))+''-''+RTRIM(LTRIM(STR(ESTIMATE_COMPONENT.EST_COMPONENT_NBR))) AS Code, RTRIM(LTRIM(STR(ESTIMATE_LOG.ESTIMATE_NUMBER)))+''-''+RTRIM(LTRIM(STR(ESTIMATE_COMPONENT.EST_COMPONENT_NBR)))+ '' | '' + ESTIMATE_COMPONENT.EST_COMP_DESC +'' | ''+ ESTIMATE_LOG.CL_CODE+'' - ''+ESTIMATE_LOG.DIV_CODE+'' - ''+ESTIMATE_LOG.PRD_CODE  AS Description
				FROM         ESTIMATE_COMPONENT INNER JOIN
							  ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER LEFT OUTER JOIN
							  JOB_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
							  ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR INNER JOIN
						  PRODUCT ON PRODUCT.CL_CODE = ESTIMATE_LOG.CL_CODE AND PRODUCT.DIV_CODE = ESTIMATE_LOG.DIV_CODE AND PRODUCT.PRD_CODE = ESTIMATE_LOG.PRD_CODE'

			if @Restrictions > 0
				Begin
				   SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND 
										  ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
				End
			IF @OfficeCount > 0
				BEGIN
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
				END
			SELECT @sql = @sql + ' WHERE ((JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) OR JOB_COMPONENT.ESTIMATE_NUMBER IS NULL)'
			if @Client <> '' 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.CL_CODE = @Client)'
				End
			if @Division <> '' 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.DIV_CODE = @Division)'
				End
			if @Product <> '' 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.PRD_CODE = @Product)'
				End
			if @JobNum <> 0 
				Begin
				   SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_NUMBER = @JobNum)'
				End
			if @JobComp <> 0 
				Begin
				   SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)'
				End
			if @Restrictions > 0
				Begin
				   SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				End
			if @Estimate > 0 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.ESTIMATE_NUMBER = @Estimate)'
				End
			
SELECT @sql = @sql + ' ORDER BY ESTIMATE_LOG.ESTIMATE_NUMBER DESC, ESTIMATE_COMPONENT.EST_COMPONENT_NBR'
SELECT @paramlist = '@Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @UserID Varchar(100), @Estimate int, @JobNum int, @JobComp int'

EXEC sp_executesql @sql, @paramlist, @Client, @Product, @Division, @UserID, @Estimate, @JobNum, @JobComp
                                               
print @sql



