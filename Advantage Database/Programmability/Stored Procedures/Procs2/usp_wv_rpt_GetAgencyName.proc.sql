






















CREATE PROCEDURE [dbo].[usp_wv_rpt_GetAgencyName] 
@AgencyName varchar(50) OUTPUT

AS

SELECT    @AgencyName = NAME
FROM         AGENCY






















