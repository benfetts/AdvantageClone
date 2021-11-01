
CREATE PROCEDURE [dbo].[usp_wv_email_getVendorReps] 
@IncludeAll int,
@Vendor varchar(6),
@Name varchar(100)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

if @IncludeAll = 1
	SELECT @sql = 'SELECT VEN_REP.VN_CODE, VR_CODE, COALESCE (RTRIM(VR_FNAME) + '' '', '''') + COALESCE (VR_MI + ''. '', '''') + COALESCE (VR_LNAME, '''') AS FML, 
                      COALESCE (VR_LNAME + '', '', '''') + COALESCE (RTRIM(VR_FNAME), '''') AS LF, VR_INACTIVE_FLAG, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, VENDOR.VN_NAME
				   FROM dbo.VEN_REP INNER JOIN
                      dbo.VENDOR ON dbo.VEN_REP.VN_CODE = dbo.VENDOR.VN_CODE
				   WHERE 1=1'
			if @Vendor <> '' 
				   SELECT @sql = @sql + ' AND (VEN_REP.VN_CODE = @Vendor)'
			if @Vendor = '' and @Name <> ''
				   SELECT @sql = @sql + ' AND (VENDOR.VN_NAME LIKE ''%' + @Name + '%'')'

if @IncludeAll <> 1
	SELECT @sql = 'SELECT VEN_REP.VN_CODE, VR_CODE, COALESCE (RTRIM(VR_FNAME) + '' '', '''') + COALESCE (VR_MI + ''. '', '''') + COALESCE (VR_LNAME, '''') AS FML, 
                      COALESCE (VR_LNAME + '', '', '''') + COALESCE (RTRIM(VR_FNAME), '''') AS LF, VR_INACTIVE_FLAG, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, VENDOR.VN_NAME
				   FROM dbo.VEN_REP INNER JOIN
                      dbo.VENDOR ON dbo.VEN_REP.VN_CODE = dbo.VENDOR.VN_CODE
				   WHERE EMAIL_ADDRESS IS NOT NULL'
			if @Vendor <> '' 
				   SELECT @sql = @sql + ' AND (VEN_REP.VN_CODE = @Vendor)'
			if @Vendor = '' and @Name <> ''
				   SELECT @sql = @sql + ' AND (VENDOR.VN_NAME LIKE ''%' + @Name + '%'')'



SELECT @paramlist = '@Vendor VarChar(6)'

EXEC sp_executesql @sql, @paramlist, @Vendor 
 



	
