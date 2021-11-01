﻿


















CREATE PROCEDURE [dbo].[usp_wv_dd_GetRolesByDesc] AS

SELECT ROLE_CODE AS Code, ROLE_CODE+ISNULL(' - '+ROLE_DESC,'') AS Description, ROLE_DESC
FROM TRAFFIC_ROLE WITH(NOLOCK)
WHERE  (INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG <> 1)
ORDER BY ROLE_DESC

















