


















CREATE PROCEDURE [dbo].[usp_wv_agency_copy_timesheet] 
@copyts Integer OUTPUT
AS

SELECT @copyts = COPY_TS FROM AGENCY


















