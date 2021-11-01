
--> CreateV_DATABASE_SQLUSER_110901
CREATE VIEW [dbo].[V_DATABASE_SQLUSER]
AS

	SELECT 
		[name] = [name] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[principal_id],
		[type] = [type] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[type_desc] = [type_desc] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[default_schema_name] = [default_schema_name] COLLATE SQL_Latin1_General_CP1_CS_AS,
		[create_date],
		[modify_date],
		[owning_principal_id],
		[sid],
		[is_fixed_role]
	FROM 
		sys.database_principals
