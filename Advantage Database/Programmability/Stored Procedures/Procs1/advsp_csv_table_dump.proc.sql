
CREATE PROCEDURE dbo.advsp_csv_table_dump @table_name varchar(50), @inc_col_title bit, @sql_where varchar(6000), @ret_val integer OUTPUT
AS

-- BJL 2011/06/21 - Because each version of SQL Server has different export tools, I wanted to right something generic that I could
--					control the output for. 

DECLARE @j integer, @cols integer, @colname varchar(50), @rowid integer, @is_last bit
DECLARE @line varchar(8000), @sql varchar(8000), @dtype smallint, @is_alpha bit

CREATE TABLE #csv_col (	
	csv_col_id			integer IDENTITY( 1, 1 ) NOT NULL, 
	colname				varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	xtype				smallint, 
	is_alpha			bit 
)

CREATE TABLE #csv_row (	
	csv_row_id			integer IDENTITY( 1, 1 ) NOT NULL, 
	is_title			bit, 
	tablename			varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	csv_row_data		text COLLATE SQL_Latin1_General_CP1_CS_AS 
) 

INSERT INTO #csv_col ( colname, xtype, is_alpha )
	 SELECT c.[name], c.xtype, 
			CASE WHEN c.collation IS NULL THEN 0 ELSE 1 END
	   FROM dbo.[sysobjects] o INNER JOIN dbo.[syscolumns] c
		 ON o.id = c.id
	  WHERE o.xtype = 'U'
		AND o.[name] = @table_name
   ORDER BY c.colorder ASC		

SELECT @cols = ( SELECT COUNT( * ) FROM #csv_col )

SET @sql = 'INSERT INTO #csv_row ( is_title, tablename, csv_row_data ) SELECT 0,''' + @table_name + ''',' 
SET @j = 1
SET @line = ''
SET @is_last = 0

WHILE ( @j <= @cols )
BEGIN
	SELECT @colname = ( SELECT colname FROM #csv_col WHERE csv_col_id = @j )
	SELECT @dtype = ( SELECT xtype FROM #csv_col WHERE csv_col_id = @j )
	SELECT @is_alpha = ( SELECT is_alpha FROM #csv_col WHERE csv_col_id = @j )
	
	SET @line = @line + @colname
	
	IF ( @j < @cols )
		SET @line = @line + '|'
	ELSE
		SET @is_last = 1
			
	IF ( @dtype IN ( 35, 35 ))
	
		IF @is_last = 1 BEGIN
		
			SET @sql = @sql + 'ISNULL(CAST(' + @colname + ' AS varchar(8000)),''''))'	
		
		END ELSE BEGIN
		
			SET @sql = @sql + 'ISNULL(CAST(' + @colname + ' AS varchar(8000)),'''')+''|''+'	
			
		END
		
	ELSE 	
		SET @sql = @sql + 'dbo.fn_idsa(' + @colname + ',' + CAST( @is_alpha AS char(1)) + ',' + CAST( @is_last AS char(1)) + ')+'
		
	SET @j = @j + 1
END

-- If column titles setting is turned on, set the first row to them
IF ( @inc_col_title = 1 )
	INSERT INTO #csv_row ( is_title, tablename, csv_row_data ) VALUES ( 1, @table_name, @line )	
	
SET @sql = LEFT( @sql, LEN( @sql ) - 1 )
SET @sql = @sql + ' FROM dbo.' + @table_name 

IF ( @sql_where > '' )
	SET @sql = @sql + ' ' + @sql_where
	
--SELECT @sql

EXECUTE ( @sql )

SELECT csv_row_id, is_title, tablename, csv_row_data
  FROM #csv_row ORDER BY csv_row_id ASC