






















CREATE PROCEDURE [dbo].[usp_client_GetEstimates_Client] 
@ClientCode Varchar(6)
AS

declare @DateApproved as datetime
declare @DateDismissed as datetime

SET NOCOUNT ON

SELECT dbo.fn_LZ(6, ESTIMATE_NUMBER)  as EstimateNbr, 
	EST_LOG_DESC as Description,
	EST_CREATE_DATE AS Date,
	@DateApproved as DateApproved,
	@DateDismissed as DateDismissed
FROM   ESTIMATE_LOG
WHERE     (CL_CODE = @ClientCode) 	
ORDER BY EST_CREATE_DATE DESC























