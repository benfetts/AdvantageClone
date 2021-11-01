




















CREATE PROCEDURE [dbo].[usp_wv_validate_newjob] 
@Client as VarChar(6), 
@Division as VarChar(6), 
@Product as VarChar(6),
@SalesClass as VarChar(6)
AS
Set NoCount On

Declare @RClient as Integer
Declare @RDivision as Integer
Declare @RProduct as Integer
Declare @RSalesClass as Integer
Declare @ReturnMessage as VarChar(256)

Set @ReturnMessage = 'sucessful'

If Exists(
SELECT CL_CODE
FROM CLIENT
Where CL_CODE = @Client 
AND (ACTIVE_FLAG = 1)
)
	Set @RClient = 1
Else
	Begin 
	Set @RClient = 0
	Set @ReturnMessage = 'Invalid Client'
	End

If Exists(
SELECT DIV_CODE
FROM DIVISION
Where CL_CODE = @Client
AND DIV_CODE = @Division 
AND (ACTIVE_FLAG = 1)
)
	Set @RDivision = 1
Else
	Begin
	Set @RDivision = 0
	Set @ReturnMessage = 'Invalid Division'
	End

If Exists(
SELECT PRD_CODE
FROM PRODUCT
Where CL_CODE = @Client
AND DIV_CODE = @Division 
AND PRD_CODE = @Product 
AND (ACTIVE_FLAG = 1)
)
	Set @RProduct = 1
Else
	Begin
	Set @RProduct = 0
	Set @ReturnMessage = 'Invalid Product'
	End

 
If Exists(
SELECT SC_CODE
FROM SALES_CLASS
Where SC_CODE = @SalesClass 
AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
)
	Set @RSalesClass = 1
Else
	Begin
	Set @RSalesClass = 0
	Set @ReturnMessage = 'Invalid Sales Class'
	End

IF @RClient + @RDivision + @RProduct + @RSalesClass = 4
	Select @ReturnMessage
Else
	Select @ReturnMessage


















