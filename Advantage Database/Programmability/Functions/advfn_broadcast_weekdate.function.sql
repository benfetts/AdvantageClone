CREATE FUNCTION [dbo].[advfn_broadcast_weekdate]
(
	@NormalDate	DATETIME
)
RETURNS DATETIME
AS
BEGIN

	DECLARE @BroadcastDate DATETIME = NULL

	IF (@NormalDate IS NOT NULL) BEGIN
			
		SELECT TOP 1
			@BroadcastDate  = X.BRD_WEEK_START
		FROM 
			dbo.fn_BroadcastCal2('01/01/1996') X
		WHERE 
			X.BRD_WEEK_START <= @NormalDate AND X.BRD_WEEK_END >= @NormalDate
			
	END
	
	RETURN @BroadcastDate

END
GO


