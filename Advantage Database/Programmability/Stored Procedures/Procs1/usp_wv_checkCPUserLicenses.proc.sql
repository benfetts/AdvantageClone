
CREATE PROCEDURE [dbo].[usp_wv_checkCPUserLicenses] 

AS

SELECT     COUNT(*) as UserCount
FROM       CP_USER 
	
	
