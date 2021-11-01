


















CREATE PROCEDURE [dbo].[usp_wv_agency_AutoEstRev] 
@AutoEstRev Integer OUTPUT
AS

SELECT @AutoEstRev = ISNULL(AUTO_EST_REV,1) FROM AGENCY


















