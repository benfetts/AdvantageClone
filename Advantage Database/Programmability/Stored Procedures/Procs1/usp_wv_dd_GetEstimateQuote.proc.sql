





CREATE PROCEDURE [dbo].[usp_wv_dd_GetEstimateQuote]
@Client varchar(6),
@Division varchar(6),
@Product varchar(6),
@UserID varchar(100),
@Estimate int,
@EstimateComp int
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

SELECT @sql = 'SELECT     RTRIM(LTRIM(STR(ESTIMATE_LOG.ESTIMATE_NUMBER)))+''-''+RTRIM(LTRIM(STR(ESTIMATE_COMPONENT.EST_COMPONENT_NBR)))+''-''+RTRIM(LTRIM(STR(ESTIMATE_QUOTE.EST_QUOTE_NBR))) AS Code, RTRIM(LTRIM(STR(ESTIMATE_LOG.ESTIMATE_NUMBER)))+''-''+RTRIM(LTRIM(STR(ESTIMATE_COMPONENT.EST_COMPONENT_NBR)))+''-''+RTRIM(LTRIM(STR(ESTIMATE_QUOTE.EST_QUOTE_NBR)))+ '' | '' + ISNULL(ESTIMATE_QUOTE.EST_QUOTE_DESC,'''') +'' | ''+ ESTIMATE_LOG.CL_CODE+'' - ''+ESTIMATE_LOG.DIV_CODE+'' - ''+ESTIMATE_LOG.PRD_CODE  AS Description
				FROM         ESTIMATE_COMPONENT INNER JOIN
									  ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER INNER JOIN
									  ESTIMATE_QUOTE ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_QUOTE.ESTIMATE_NUMBER AND 
									  ESTIMATE_COMPONENT.EST_COMPONENT_NBR = ESTIMATE_QUOTE.EST_COMPONENT_NBR'

			if @Restrictions > 0
				Begin
				   SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND 
										  ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
				End
			if @Client <> '' 
				Begin
				   SELECT @sql = @sql + ' WHERE (ESTIMATE_LOG.CL_CODE = @Client)'
				End
			if @Division <> '' 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.DIV_CODE = @Division)'
				End
			if @Product <> '' 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.PRD_CODE = @Product)'
				End
			if @Restrictions > 0
				Begin
				   SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				End
			if @Estimate > 0 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.ESTIMATE_NUMBER = @Estimate)'
				End
			if @EstimateComp > 0 
				Begin
				   SELECT @sql = @sql + ' AND (ESTIMATE_COMPONENT.EST_COMPONENT_NBR = @EstimateComp)'
				End
			
SELECT @sql = @sql + ' ORDER BY ESTIMATE_LOG.ESTIMATE_NUMBER DESC, ESTIMATE_COMPONENT.EST_COMPONENT_NBR'
SELECT @paramlist = '@Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @UserID Varchar(100), @Estimate int, @EstimateComp int'

EXEC sp_executesql @sql, @paramlist, @Client, @Product, @Division, @UserID, @Estimate, @EstimateComp
                                               
print @sql



