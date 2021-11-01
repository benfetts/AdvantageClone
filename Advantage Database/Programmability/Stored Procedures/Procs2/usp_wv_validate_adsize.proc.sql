
CREATE PROCEDURE [dbo].[usp_wv_validate_adsize] 
@AdSize as VarChar(6),
@MediaType as Varchar(1)

AS
Set NoCount On

Declare @RClient as Integer
Declare @ReturnMessage as VarChar(256)

If Exists(
SELECT SIZE_CODE
FROM AD_SIZE
Where SIZE_CODE = @AdSize AND MEDIA_TYPE = @MediaType
AND (INACTIVE_FLAG <> 1)
)
	Set @RClient = 1
Else
	Set @RClient = 0




 
IF @RClient    = 1
	set @ReturnMessage = 'Valid'
Else
	set @ReturnMessage = 'Invalid'


	Select @ReturnMessage
