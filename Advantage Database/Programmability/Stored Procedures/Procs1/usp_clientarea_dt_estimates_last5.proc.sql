






















CREATE PROCEDURE [dbo].[usp_clientarea_dt_estimates_last5] 
@ClientCode Varchar(6)
AS

SET NOCOUNT ON

SELECT TOP 5 
	dbo.fn_LZ(6, ESTIMATE_NUMBER) as EstimateNbr, 
	EST_LOG_DESC as Description,
	EST_CREATE_DATE AS Date
FROM   ESTIMATE_LOG
WHERE     (CL_CODE = @ClientCode) 	
ORDER BY EST_CREATE_DATE DESC























