
CREATE PROCEDURE [dbo].[usp_wv_validate_apinvoice] 
@APInvoice as Varchar(20)

AS
Set NoCount On

Declare @RClient as Integer
Declare @ReturnMessage as VarChar(256)

If Exists(
SELECT     AP_INV_VCHR
FROM         dbo.AP_HEADER
WHERE     AP_INV_VCHR = @APInvoice AND ((DELETE_FLAG = 0) OR (DELETE_FLAG IS NULL))
)
	Set @RClient = 1
Else
	Set @RClient = 0




 
IF @RClient    = 1
	set @ReturnMessage = 'Valid'
Else
	set @ReturnMessage = 'Invalid'


	Select @ReturnMessage
