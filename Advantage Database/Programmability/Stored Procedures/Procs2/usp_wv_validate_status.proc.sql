
CREATE PROCEDURE [dbo].[usp_wv_validate_status] 
@Status as VarChar(20)

AS
Set NoCount On

Declare @RClient as Integer
Declare @ReturnMessage as VarChar(256)

If Exists(
SELECT STATUS_CODE
FROM STATUS
Where STATUS_CODE = @Status
AND (ACTIVE = 1)
)
	Set @RClient = 1
Else
	Set @RClient = 0




 
IF @RClient    = 1
	set @ReturnMessage = 'Valid'
Else
	set @ReturnMessage = 'Invalid'


	Select @ReturnMessage
