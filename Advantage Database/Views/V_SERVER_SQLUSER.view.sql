
--> CreateV_SERVER_SQLUSER_110901
CREATE VIEW [dbo].[V_SERVER_SQLUSER]
AS

	SELECT 
		[name] = [name] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[principal_id],
		[sid],
		[type] = [type] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[type_desc] = [type_desc] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[is_disabled],
		[create_date],
		[modify_date],
		[default_database_name] = [default_database_name] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[default_language_name] = [default_language_name] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[credential_id]
	FROM
		sys.server_principals
		
