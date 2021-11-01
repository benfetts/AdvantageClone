CREATE PROCEDURE [dbo].[advsp_sql_remove_indexes] 
	@TableName varchar(MAX),
	@IndexName varchar(MAX) = ''
AS
BEGIN

	DECLARE @ROW_COUNT AS integer
	DECLARE @ROW_ID AS integer
	DECLARE @Name AS varchar(MAX)
	DECLARE @SQLString AS varchar(MAX)

	CREATE TABLE #Indexes(ID int IDENTITY(1,1) PRIMARY KEY CLUSTERED, 
						  Name varchar(MAX))

	IF @IndexName = '' BEGIN

		INSERT INTO #Indexes
		SELECT name FROM sys.indexes WHERE object_id = OBJECT_ID(@TableName) AND [type] = 2 AND [is_unique] = 0

	END ELSE BEGIN 
	
		INSERT INTO #Indexes
		SELECT name FROM sys.indexes WHERE object_id = OBJECT_ID(@TableName) AND [type] = 2 AND [is_unique] = 0 AND name = @IndexName

	END
	
	SET @ROW_COUNT = @@ROWCOUNT
	SET @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN

		SELECT
			@Name = Name
		FROM 
			#Indexes
		WHERE
			ID = @ROW_ID

		SET @SQLString = 'DROP INDEX [' + @Name + '] ON ' + @TableName

		IF EXISTS (SELECT name FROM sys.indexes  WHERE name=@Name AND object_id = OBJECT_ID(@TableName)) BEGIN
		
			EXEC(@SQLString)
		 
		END

		SET @ROW_ID = @ROW_ID + 1
	
	END

END
GO