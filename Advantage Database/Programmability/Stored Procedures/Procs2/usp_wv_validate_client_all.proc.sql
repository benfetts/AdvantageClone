
CREATE PROCEDURE [dbo].[usp_wv_validate_client_all] 
@Client as VarChar(6), 
@Division as VarChar(6), 
@Product as VarChar(6)

AS
Set NoCount On

Declare @RClient as Integer
Declare @ReturnMessage as VarChar(256)

If Exists(
SELECT CL_CODE
FROM CLIENT
Where CL_CODE = @Client 
)
	Set @RClient = 1
Else
	Set @RClient = 0




 
IF @RClient    = 1
	set @ReturnMessage = 'Valid'
Else
	set @ReturnMessage = 'Invalid'


	Select @ReturnMessage
