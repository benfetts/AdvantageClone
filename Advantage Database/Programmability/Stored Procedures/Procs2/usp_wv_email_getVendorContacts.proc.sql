
CREATE PROCEDURE [dbo].[usp_wv_email_getVendorContacts] 
@IncludeAll int,
@Vendor varchar(6),
@Name varchar(100)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

if @IncludeAll = 1
	SELECT @sql = 'SELECT VEN_CONT.VN_CODE, VC_CODE, COALESCE (RTRIM(VC_FNAME) + '' '', '''') + COALESCE (VC_MI + ''. '', '''') + COALESCE (VC_LNAME, '''') AS FML, 
                      COALESCE (VC_LNAME + '', '', '''') + COALESCE (RTRIM(VC_FNAME), '''') AS LF, VC_INACTIVE_FLAG, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, VENDOR.VN_NAME
				   FROM dbo.VEN_CONT INNER JOIN
                      dbo.VENDOR ON dbo.VEN_CONT.VN_CODE = dbo.VENDOR.VN_CODE
				   WHERE 1=1'
			if @Vendor <> '' 
				   SELECT @sql = @sql + ' AND (VEN_CONT.VN_CODE = @Vendor)'
			if @Vendor = '' and @Name <> ''
				   SELECT @sql = @sql + ' AND (VENDOR.VN_NAME LIKE ''%' + @Name + '%'')'

if @IncludeAll <> 1
	SELECT @sql = 'SELECT VEN_CONT.VN_CODE, VC_CODE, COALESCE (RTRIM(VC_FNAME) + '' '', '''') + COALESCE (VC_MI + ''. '', '''') + COALESCE (VC_LNAME, '''') AS FML, 
                      COALESCE (VC_LNAME + '', '', '''') + COALESCE (RTRIM(VC_FNAME), '''') AS LF, VC_INACTIVE_FLAG, ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, VENDOR.VN_NAME
				   FROM dbo.VEN_CONT INNER JOIN
                      dbo.VENDOR ON dbo.VEN_CONT.VN_CODE = dbo.VENDOR.VN_CODE
				   WHERE EMAIL_ADDRESS IS NOT NULL'
			if @Vendor <> '' 
				   SELECT @sql = @sql + ' AND (VEN_CONT.VN_CODE = @Vendor)'
			if @Vendor = '' and @Name <> ''
				   SELECT @sql = @sql + ' AND (VENDOR.VN_NAME LIKE ''%' + @Name + '%'')'



SELECT @paramlist = '@Vendor VarChar(6)'

EXEC sp_executesql @sql, @paramlist, @Vendor 
 



	
