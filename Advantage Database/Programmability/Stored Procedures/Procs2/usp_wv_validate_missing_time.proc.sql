
CREATE PROCEDURE [dbo].[usp_wv_validate_missing_time] 
@EMP_CODE		VARCHAR(6),
@ThisDate		DateTime
AS

SELECT COUNT(*) AS CT
FROM MISSING_TIME_HDR
WHERE @ThisDate >= START_DATE AND @ThisDate < = END_DATE




