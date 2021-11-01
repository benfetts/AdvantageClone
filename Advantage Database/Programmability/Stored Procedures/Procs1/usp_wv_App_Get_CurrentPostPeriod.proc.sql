























--------------------------------------------------------------------------------------------------
-- Gets The Current Posting Period
--------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[usp_wv_App_Get_CurrentPostPeriod] 
@PostPeriod VarChar(6) OUTPUT
AS

SET NOCOUNT ON

SELECT @PostPeriod = PPPERIOD
FROM POSTPERIOD WHERE PPARCURMTH = 'C'























