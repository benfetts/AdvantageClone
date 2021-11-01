IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_email_getProductRecipients]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_email_getProductRecipients]
GO

CREATE PROCEDURE [dbo].[usp_wv_email_getProductRecipients] 
@IncludeAll int,
@Client VarChar(6),
@Division VarChar(6),
@Product Varchar(6),
@Name varchar(100),
@NameDiv varchar(100),
@NamePrd varchar(100),
@CP INT,
@CPID INT
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

If @CP = 1
Begin
	if @IncludeAll = 1
		SELECT @sql = 'SELECT PRD_CONTACT.CL_CODE, PRD_CONTACT.DIV_CODE, PRD_CONTACT.PRD_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') 
							  + COALESCE (CONT_LNAME, '''') AS FML, COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, 
							  ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME, 
							  DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
					   FROM dbo.PRD_CONTACT INNER JOIN
						  PRODUCT ON PRD_CONTACT.CL_CODE = PRODUCT.CL_CODE AND PRD_CONTACT.DIV_CODE = PRODUCT.DIV_CODE AND 
						  PRD_CONTACT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
						  DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
						  CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
					   WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) '
				if @Client <> '' 
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.CL_CODE = @Client)'
						 if @Division = '' and @NameDiv <> ''
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Division <> '' 				   
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.DIV_CODE = @Division)'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Product <> '' 
					   SELECT @sql = @sql + ' AND (PRD_CONTACT.PRD_CODE = @Product)'
				if @Client = '' 
					   Begin
						 if @Name <> ''
							   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name + '%'')'
						 if @NameDiv <> ''			
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End

	if @IncludeAll <> 1
		SELECT @sql = 'SELECT PRD_CONTACT.CL_CODE, PRD_CONTACT.DIV_CODE, PRD_CONTACT.PRD_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') 
							  + COALESCE (CONT_LNAME, '''') AS FML, COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, 
							  ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME, 
							  DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
					   FROM dbo.PRD_CONTACT INNER JOIN
						  PRODUCT ON PRD_CONTACT.CL_CODE = PRODUCT.CL_CODE AND PRD_CONTACT.DIV_CODE = PRODUCT.DIV_CODE AND 
						  PRD_CONTACT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
						  DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
						  CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
					   WHERE EMAIL_ADDRESS IS NOT NULL AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) '
				if @Client <> '' 
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.CL_CODE = @Client)'
						 if @Division = '' and @NameDiv <> ''
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Division <> '' 				   
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.DIV_CODE = @Division)'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Product <> '' 
					   SELECT @sql = @sql + ' AND (PRD_CONTACT.PRD_CODE = @Product)'
				if @Client = '' 
					   Begin
						 if @Name <> ''
							   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name + '%'')'
						 if @NameDiv <> ''			
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End
End
Else
Begin
	if @IncludeAll = 1
		SELECT @sql = 'SELECT PRD_CONTACT.CL_CODE, PRD_CONTACT.DIV_CODE, PRD_CONTACT.PRD_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') 
							  + COALESCE (CONT_LNAME, '''') AS FML, COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, 
							  ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME, 
							  DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
					   FROM dbo.PRD_CONTACT INNER JOIN
						  PRODUCT ON PRD_CONTACT.CL_CODE = PRODUCT.CL_CODE AND PRD_CONTACT.DIV_CODE = PRODUCT.DIV_CODE AND 
						  PRD_CONTACT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
						  DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
						  CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
					   WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)'
				if @Client <> '' 
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.CL_CODE = @Client)'
						 if @Division = '' and @NameDiv <> ''
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Division <> '' 				   
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.DIV_CODE = @Division)'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Product <> '' 
					   SELECT @sql = @sql + ' AND (PRD_CONTACT.PRD_CODE = @Product)'
				if @Client = '' 
					   Begin
						 if @Name <> ''
							   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name + '%'')'
						 if @NameDiv <> ''			
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End

	if @IncludeAll <> 1
		SELECT @sql = 'SELECT PRD_CONTACT.CL_CODE, PRD_CONTACT.DIV_CODE, PRD_CONTACT.PRD_CODE, CONT_CODE, COALESCE (RTRIM(CONT_FNAME) + '' '', '''') + COALESCE (CONT_MI + ''. '', '''') 
							  + COALESCE (CONT_LNAME, '''') AS FML, COALESCE (CONT_LNAME + '', '', '''') + COALESCE (RTRIM(CONT_FNAME), '''') AS LF, 
							  ISNULL(EMAIL_ADDRESS, '''') AS EMAIL, CLIENT.CL_NAME, 
							  DIVISION.DIV_NAME, PRODUCT.PRD_DESCRIPTION
					   FROM dbo.PRD_CONTACT INNER JOIN
						  PRODUCT ON PRD_CONTACT.CL_CODE = PRODUCT.CL_CODE AND PRD_CONTACT.DIV_CODE = PRODUCT.DIV_CODE AND 
						  PRD_CONTACT.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
						  DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
						  CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
					   WHERE EMAIL_ADDRESS IS NOT NULL AND (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0)'
				if @Client <> '' 
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.CL_CODE = @Client)'
						 if @Division = '' and @NameDiv <> ''
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Division <> '' 				   
					   Begin
						 SELECT @sql = @sql + ' AND (PRD_CONTACT.DIV_CODE = @Division)'
						 if @Product = '' and @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End	
				if @Product <> '' 
					   SELECT @sql = @sql + ' AND (PRD_CONTACT.PRD_CODE = @Product)'
				if @Client = '' 
					   Begin
						 if @Name <> ''
							   SELECT @sql = @sql + ' AND (CLIENT.CL_NAME LIKE ''%' + @Name + '%'')'
						 if @NameDiv <> ''			
							   SELECT @sql = @sql + ' AND (DIVISION.DIV_NAME LIKE ''%' + @NameDiv + '%'')'
						 if @NamePrd <> ''
							   SELECT @sql = @sql + ' AND (PRODUCT.PRD_DESCRIPTION LIKE ''%' + @NamePrd + '%'')'
					   End
End



SELECT @paramlist = '@Client VarChar(6),@Division VarChar(6),@Product VarChar(6), @Name VarChar(100), @NameDiv VarChar(100), @NamePrd Varchar(100)'

print(@sql)
EXEC sp_executesql @sql, @paramlist, @Client, @Division, @Product, @Name, @NameDiv, @NamePrd 



	
