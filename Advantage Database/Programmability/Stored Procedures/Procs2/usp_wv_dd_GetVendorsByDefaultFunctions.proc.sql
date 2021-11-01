

CREATE PROCEDURE [dbo].[usp_wv_dd_GetVendorsByDefaultFunctions] 
@Functions varchar(4000)
AS


	SET NOCOUNT ON

	SELECT VN_CODE AS Code,
		   VN_CODE + ' - ' + VN_NAME AS [Description]
	FROM   VENDOR WITH(NOLOCK)
	WHERE  VN_ACTIVE_FLAG = 1
		   AND VN_CATEGORY = 'P'
		   AND EXISTS (
				   SELECT *
				   FROM   [dbo].[charlist_to_table] (@Functions, ',')
				   WHERE  DEF_FNC_CODE COLLATE DATABASE_DEFAULT = vstr COLLATE 
						  DATABASE_DEFAULT
			   )
	ORDER BY
		   VN_CODE;




