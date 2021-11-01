







CREATE PROCEDURE [dbo].[usp_wv_job_GetAgencyInfo]
@Location varchar(100)
AS

SELECT     *
FROM         LOCATIONS 
WHERE     (ID = @Location)
















