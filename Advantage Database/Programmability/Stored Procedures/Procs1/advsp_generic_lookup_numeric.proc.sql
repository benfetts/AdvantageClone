
CREATE PROCEDURE [dbo].[advsp_generic_lookup_numeric] @numeric_id_in integer, @lookup_table_name varchar(25), @id_col_name varchar(50), 
	@desc_col_name varchar(50), @inactive_col_name varchar(50), @where_clause varchar(1000), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @sql_select VARCHAR(4000)

SELECT @ret_val = 0
SELECT @sql_select = ''

SELECT @sql_select = @sql_select + 'SELECT ' + @id_col_name + ' AS NUMERIC_ID, ' + @desc_col_name + ' AS DESCRIPTION '
SELECT @sql_select = @sql_select + '  FROM dbo.' + @lookup_table_name
SELECT @sql_select = @sql_select + ' WHERE ' + @id_col_name + ' = ' + CAST( @numeric_id_in AS VARCHAR(8))

IF ( @where_clause IS NOT NULL )
	SELECT @sql_select = @sql_select + @where_clause
	 
SELECT @sql_select = @sql_select + ' UNION ' 
SELECT @sql_select = @sql_select + 'SELECT ' + @id_col_name + ', ' + @desc_col_name
SELECT @sql_select = @sql_select + '  FROM dbo.' + @lookup_table_name
SELECT @sql_select = @sql_select + ' WHERE NOT EXISTS ( SELECT * FROM dbo.' + @lookup_table_name + ' WHERE ' + @id_col_name + ' = ' + CAST( @numeric_id_in AS VARCHAR(8)) + ' ) '

IF ( @where_clause IS NOT NULL )
	SELECT @sql_select = @sql_select + @where_clause

EXECUTE ( @sql_select )
