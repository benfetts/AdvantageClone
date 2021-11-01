
CREATE PROCEDURE [dbo].[usp_wv_dd_filter_campaign] 
@ClientCode		VarChar(6), 
@DivisionCode	VarChar(6), 
@ProductCode	VarChar(6),
@UserID			VARCHAR(100),
@InclClosed		INTEGER

AS
DECLARE @Restrictions INT,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
DECLARE @InclClosedStr varchar(1)		
		
SELECT @Restrictions = COUNT(*)  FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)

if @InclClosed = 0
	set @InclClosedStr = '0'
Else
	set @InclClosedStr = '1'
	

Set @sql = 'Select CMP_CODE as code, CMP_CODE + '' - '' + ISNULL(CMP_NAME, '''') as description'
Set @sql = @sql + ' From CAMPAIGN '
            
if @Restrictions > 0	
	Begin
	  SET @sql = @sql + ' INNER JOIN SEC_CLIENT ON CAMPAIGN.CL_CODE = SEC_CLIENT.CL_CODE 
						AND ( CAMPAIGN.DIV_CODE = SEC_CLIENT.DIV_CODE OR CAMPAIGN.DIV_CODE IS NULL )
						AND ( CAMPAIGN.PRD_CODE = SEC_CLIENT.PRD_CODE OR CAMPAIGN.PRD_CODE IS NULL ) AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End


SET @sql = @sql + ' Where CL_CODE = ''' + @ClientCode + '''
	AND (DIV_CODE = ''' + @DivisionCode + ''' OR DIV_CODE IS NULL)
	AND (PRD_CODE = ''' + @ProductCode + ''' OR PRD_CODE IS NULL) '
	
If @InclClosedStr = '0' 
	SET @sql = @sql + ' AND (CAMPAIGN.CMP_CLOSED = 0 OR CAMPAIGN.CMP_CLOSED IS NULL) '


EXEC(@sql)

