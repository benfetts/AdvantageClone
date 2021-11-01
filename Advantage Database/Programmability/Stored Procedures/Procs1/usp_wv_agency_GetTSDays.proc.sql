

























CREATE PROCEDURE [dbo].[usp_wv_agency_GetTSDays] 
@Days Integer OUTPUT
AS
SELECT    @Days = TS_DAYS_PER_WK
FROM         AGENCY

if @Days <> 7
	Begin
		Select @Days = 5
	End

























