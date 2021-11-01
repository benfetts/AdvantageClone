
CREATE PROCEDURE [dbo].[usp_wv_validate_vendor] 
@Vendor as VarChar(6)

AS
Set NoCount On

Declare @RClient as Integer
Declare @ReturnMessage as VarChar(256)

If Exists(
SELECT VN_CODE
FROM VENDOR
Where VN_CODE = @Vendor
AND (VN_ACTIVE_FLAG = 1)
)
	Set @RClient = 1
Else
	Set @RClient = 0




 
IF @RClient    = 1
	set @ReturnMessage = 'Valid'
Else
	set @ReturnMessage = 'Invalid'


	Select @ReturnMessage
