
CREATE PROCEDURE [dbo].[advsp_generic_lookup_alpha] 
	@alpha_code_in varchar(32),
	@lookup_table_name varchar(25), 
	@code_col_name varchar(50), 
	@desc_col_name varchar(50), 
	@inactive_clause varchar(100),
	@ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @sql_select VARCHAR(4000)

SELECT @ret_val = 0
SELECT @sql_select = ''

SELECT @sql_select = @sql_select + 'SELECT ' + @code_col_name + ' AS ALPHA_CODE, ' + @desc_col_name + ' AS DESCRIPTION '
SELECT @sql_select = @sql_select + '  FROM dbo.' + @lookup_table_name
SELECT @sql_select = @sql_select + ' WHERE ' + @code_col_name + ' = ''' + @alpha_code_in + ''' '
IF ( @inactive_clause > '' )
BEGIN
	SELECT @sql_select = 
					 @sql_select + '   AND ' + @inactive_clause
END
SELECT @sql_select = @sql_select + ' UNION ' 
SELECT @sql_select = @sql_select + 'SELECT ' + @code_col_name + ', ' + @desc_col_name 
SELECT @sql_select = @sql_select + '  FROM dbo.' + @lookup_table_name
SELECT @sql_select = @sql_select + ' WHERE NOT EXISTS ( SELECT * ' 
SELECT @sql_select = @sql_select + '					  FROM dbo.' + @lookup_table_name 
SELECT @sql_select = @sql_select + '					 WHERE ' + @code_col_name + ' = ''' + @alpha_code_in + ''' '
IF ( @inactive_clause > '' )
BEGIN
	SELECT @sql_select = 
					 @sql_select + '					   AND ' + @inactive_clause
END
SELECT @sql_select = @sql_select + ' ) '
IF ( @inactive_clause > '' )
BEGIN
	SELECT @sql_select = 
					 @sql_select + '   AND ' + @inactive_clause
END

EXECUTE ( @sql_select )
