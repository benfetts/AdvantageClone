SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_campaign_search_estimate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_campaign_search_estimate]
GO


/***************************************************************************************
Webvantage
Retrieves list of campaigns for popup using filter parameters
22-Mar-2010 - jtg - Created

****************************************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_campaign_search_estimate] 
    @UserID			VARCHAR(100),
    @OfficeCode		VARCHAR(4),
    @ClientCode		VARCHAR(6),
    @DivisionCode	VARCHAR(6),
    @ProductCode	VARCHAR(6),
	@InclClosed		INTEGER
	
AS
If @OfficeCode IS NULL 
	set @OfficeCode = ''
If @ClientCode IS NULL 
	set @ClientCode = ''	
If	@DivisionCode IS NULL 
	set @DivisionCode = '' 	
If	@ProductCode  IS NULL 
	set @ProductCode = ''


DECLARE @Restrictions 	Int
DECLARE @sql 		varchar(4000)
DECLARE @sql_from 	varchar(4000)
DECLARE @sql_where 	varchar(4000)
DECLARE @InclClosedStr varchar(1)

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @COUNT AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @COUNT = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

if @InclClosed IS NULL Or @InclClosed = 0
	set @InclClosedStr = '0'
Else
	set @InclClosedStr = '1'

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)


--SET @sql = 'SELECT DISTINCT CAMPAIGN.CMP_CODE AS Code, CAMPAIGN.CMP_CODE + '' - '' + ISNULL(CAMPAIGN.CMP_NAME, '''') + '' | '' + ISNULL(CAMPAIGN.CL_CODE, '''') + '' - '' + ISNULL(CAMPAIGN.DIV_CODE, '''') + '' - '' + ISNULL(CAMPAIGN.PRD_CODE, '''')  AS Description '

SET @sql = 'SELECT DISTINCT CAMPAIGN.CMP_IDENTIFIER AS Code, '
--SET @sql = 'SELECT DISTINCT '
SET @sql = @sql + ' CASE '
SET @sql = @sql + '   WHEN CAMPAIGN.DIV_CODE IS NOT NULL AND CAMPAIGN.PRD_CODE IS NOT NULL THEN '
SET @sql = @sql + '		CAMPAIGN.CMP_CODE + '' - '' + ISNULL(CAMPAIGN.CMP_NAME, '''') + '' | '' + ISNULL(CAMPAIGN.CL_CODE, '''') + '' - '' + ISNULL(CAMPAIGN.DIV_CODE, '''') + '' - '' + ISNULL(CAMPAIGN.PRD_CODE, '''')   ' 
SET @sql = @sql + '   WHEN CAMPAIGN.DIV_CODE IS NOT NULL AND CAMPAIGN.PRD_CODE IS NULL THEN '
SET @sql = @sql + '		CAMPAIGN.CMP_CODE + '' - '' + ISNULL(CAMPAIGN.CMP_NAME, '''') + '' | '' + ISNULL(CAMPAIGN.CL_CODE, '''') + '' - '' + ISNULL(CAMPAIGN.DIV_CODE, '''')  '
SET @sql = @sql + '   WHEN CAMPAIGN.DIV_CODE IS NULL AND CAMPAIGN.PRD_CODE IS NULL THEN '
SET @sql = @sql + '		CAMPAIGN.CMP_CODE + '' - '' + ISNULL(CAMPAIGN.CMP_NAME, '''') + '' | '' + ISNULL(CAMPAIGN.CL_CODE, '''') ' 
SET @sql = @sql + ' END AS Description '

SET @sql_from = ' FROM CAMPAIGN '
SET @sql_where = ' WHERE 1=1 AND CAMPAIGN.DIV_CODE IS NOT NULL AND CAMPAIGN.PRD_CODE IS NOT NULL AND CMP_TYPE <> 1'
	
if @Restrictions > 0	
	Begin
	  SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON CAMPAIGN.CL_CODE = SEC_CLIENT.CL_CODE 
						AND ( CAMPAIGN.DIV_CODE = SEC_CLIENT.DIV_CODE OR CAMPAIGN.DIV_CODE IS NULL )
						AND ( CAMPAIGN.PRD_CODE = SEC_CLIENT.PRD_CODE OR CAMPAIGN.PRD_CODE IS NULL )'
	  		 
	  SET @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End
	
If @COUNT > 0
	SET @sql_from = @sql_from + ' INNER JOIN PRODUCT ON CAMPAIGN.CL_CODE = PRODUCT.CL_CODE 
						AND ( CAMPAIGN.DIV_CODE = PRODUCT.DIV_CODE OR CAMPAIGN.DIV_CODE IS NULL )
						AND ( CAMPAIGN.PRD_CODE = PRODUCT.PRD_CODE OR CAMPAIGN.PRD_CODE IS NULL )
						INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
		AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''' '

If @OfficeCode  <> ''
	SET @sql_where = @sql_where + ' AND CAMPAIGN.OFFICE_CODE = ''' + @OfficeCode + ''''

If @ClientCode  <> ''
	SET @sql_where = @sql_where + ' AND CAMPAIGN.CL_CODE = ''' + @ClientCode + ''''

If @DivisionCode <> ''
 Begin
	SET @sql_where = @sql_where + ' AND CAMPAIGN.DIV_CODE = ''' + @DivisionCode + ''''
	
	--If @Restrictions > 0
	--	SET @sql_from = @sql_from + ' AND CAMPAIGN.DIV_CODE = SEC_CLIENT.DIV_CODE'
 End		

If @ProductCode  <> ''
 Begin
	SET @sql_where = @sql_where + ' AND CAMPAIGN.PRD_CODE = ''' + @ProductCode + ''''
	
	--If @Restrictions > 0
	--	SET @sql_from = @sql_from + ' AND CAMPAIGN.PRD_CODE = SEC_CLIENT.PRD_CODE '
 End	
	
If @InclClosedStr = '0' 
	SET @sql_where = @sql_where + ' AND (CAMPAIGN.CMP_CLOSED = 0 OR CAMPAIGN.CMP_CLOSED IS NULL) '


SET @sql = @sql + @sql_from + @sql_where
set @sql = @sql + ' ORDER BY CMP_IDENTIFIER DESC'

EXEC(@sql)
PRINT(@sql)


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
