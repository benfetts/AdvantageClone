CREATE FUNCTION [dbo].[advfn_calculate_num_quarter_hours](@StartHour smallint, @EndHour smallint)
RETURNS int
WITH SCHEMABINDING
AS
BEGIN
	DECLARE @NUM_QTR_HRS int

	SELECT @NUM_QTR_HRS = (ENDHOUR - STARTHOUR) / 25
	FROM (
		SELECT
			STARTHOUR = @StartHour / 100 * 100 +
						CASE
							WHEN @StartHour % 100 = 0 THEN 0
							WHEN @StartHour % 100 between 0  and 14 THEN 0
							WHEN @StartHour % 100 between 15 and 29 THEN 25
							WHEN @StartHour % 100 between 30 and 44 THEN 50
							WHEN @StartHour % 100 between 45 and 59 THEN 75
						END,
			ENDHOUR = @EndHour / 100 * 100 +
						CASE
							WHEN @EndHour % 100 = 0 THEN 0
							WHEN @EndHour % 100 between 0  and 15 THEN 25
							WHEN @EndHour % 100 between 16 and 30 THEN 50
							WHEN @EndHour % 100 between 31 and 45 THEN 75
							WHEN @EndHour % 100 between 46 and 59 THEN 100
						END
	) data

	RETURN @NUM_QTR_HRS
END
GO