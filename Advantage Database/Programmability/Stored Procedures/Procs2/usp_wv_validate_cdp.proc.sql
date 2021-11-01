
CREATE PROCEDURE [dbo].[usp_wv_validate_cdp] 
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
SELECT CLIENT.CL_CODE
FROM CLIENT
Where CL_CODE = @Client 
AND (ACTIVE_FLAG = 1)
)
	Set @RClient = 1
Else
	Set @RClient = 0


If Exists(
SELECT DIVISION.DIV_CODE
FROM         DIVISION INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
Where CLIENT.CL_CODE = @Client
AND DIVISION.DIV_CODE = @Division 
AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
)
	Set @RDivision = 1
Else
	Set @RDivision = 0


If Exists(
SELECT PRODUCT.PRD_CODE
FROM         DIVISION INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN
                      PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
                      Where CLIENT.CL_CODE = @Client
AND DIVISION.DIV_CODE = @Division 
AND PRODUCT.PRD_CODE = @Product 
AND (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1) AND (PRODUCT.ACTIVE_FLAG = 1)
)
	Set @RProduct = 1
Else
	Set @RProduct = 0


 
IF @RClient + @RDivision + @RProduct  = 3
	set @ReturnMessage = 'Valid'
Else
	set @ReturnMessage = 'Invalid'


	Select @ReturnMessage



