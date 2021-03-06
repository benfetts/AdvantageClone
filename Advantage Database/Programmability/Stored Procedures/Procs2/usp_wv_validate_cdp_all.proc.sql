
CREATE PROCEDURE [dbo].[usp_wv_validate_cdp_all] 
@Client as VarChar(6), 
@Division as VarChar(6), 
@Product as VarChar(6)

AS
Set NoCount On

Declare @RClient as Integer
Declare @RDivision as Integer
Declare @RProduct as Integer
Declare @ReturnMessage as VarChar(256)

Set @ReturnMessage = 'Invalid'

If Exists(
SELECT CL_CODE
FROM CLIENT
Where CL_CODE = @Client 
)
	Set @RClient = 1
Else
	Set @RClient = 0


If Exists(
SELECT DIV_CODE
FROM DIVISION
Where CL_CODE = @Client
AND DIV_CODE = @Division 
)
	Set @RDivision = 1
Else
	Set @RDivision = 0


If Exists(
SELECT PRD_CODE
FROM PRODUCT
Where CL_CODE = @Client
AND DIV_CODE = @Division 
AND PRD_CODE = @Product 
)
	Set @RProduct = 1
Else
	Set @RProduct = 0


 
IF @RClient + @RDivision + @RProduct  = 3
	set @ReturnMessage = 'Valid'
Else
	set @ReturnMessage = 'Invalid'


	Select @ReturnMessage



