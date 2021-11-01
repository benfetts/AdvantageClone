CREATE PROCEDURE [dbo].[advsp_sql_column_prepare] 
	@TABLE_NAME		varchar(128),
	@COLUMN_NAME	varchar(128)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @sql varchar(max)
	
	--statistics
	DECLARE @statsinfo TABLE (statname varchar(128), cols varchar(max))
	INSERT INTO @statsinfo EXEC sp_helpstats @TABLE_NAME

	SET @sql = ''
	SELECT @sql=@sql + 'DROP STATISTICS [' + @TABLE_NAME + '].[' + statname + ']; ' 
	FROM @statsinfo 
	WHERE cols LIKE '%' + @COLUMN_NAME + '%'

	IF NULLIF(@sql,'') IS NOT NULL
		EXEC (@sql)

	--constraints
	SET @sql = ''
	SELECT @sql=@sql + 'ALTER TABLE [' + Tab.name + '] DROP CONSTRAINT [' + sysobjects.name + ']; '
	FROM sysobjects 
		INNER JOIN (SELECT name, id FROM sysobjects WHERE xtype = 'U') As Tab
			ON Tab.id = sysobjects.parent_obj  
		INNER JOIN sysconstraints ON sysconstraints.constid = sysobjects.id
		INNER JOIN syscolumns Col ON Col.colid = sysconstraints.colid And Col.id = Tab.id
	WHERE Tab.name = @TABLE_NAME
	AND Col.name = @COLUMN_NAME

	IF NULLIF(@sql,'') IS NOT NULL
		EXEC (@sql)

	--PK Constraint
	set @sql = ''
	SELECT @sql=@sql + 'ALTER TABLE [' + @TABLE_NAME + '] DROP CONSTRAINT [' + i.name + ']; '
	FROM sys.indexes i
		inner join sys.index_columns ic  ON i.object_id = ic.object_id AND i.index_id = ic.index_id
		inner join sys.columns c ON ic.object_id = c.object_id AND c.column_id = ic.column_id
	WHERE i.is_primary_key = 1
	AND i.object_id = OBJECT_ID('dbo.[' + @TABLE_NAME + ']')
	AND c.name = @COLUMN_NAME
	
	IF NULLIF(@sql,'') IS NOT NULL
		EXEC (@sql)
		
	--indexes
	set @sql = ''
	SELECT @sql=@sql + 'DROP INDEX [' + @TABLE_NAME + '].[' + i.name + ']; '
	FROM sys.indexes i
		inner join sys.index_columns ic  ON i.object_id = ic.object_id AND i.index_id = ic.index_id
		inner join sys.columns c ON ic.object_id = c.object_id AND c.column_id = ic.column_id
	WHERE i.is_primary_key = 0
	AND i.object_id = OBJECT_ID('dbo.[' + @TABLE_NAME + ']')
	AND c.name = @COLUMN_NAME
	
	IF NULLIF(@sql,'') IS NOT NULL
		EXEC (@sql)

END
GO
