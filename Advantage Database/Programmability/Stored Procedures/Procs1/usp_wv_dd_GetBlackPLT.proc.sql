﻿
CREATE PROCEDURE [dbo].[usp_wv_dd_GetBlackPLT] 

AS
SELECT 
    DISTINCT BLACKPLT_VER_CODE as code, BLACKPLT_VER_CODE + ' - ' + BLACKPLT_VER_DESC as description
FROM 
    BLACKPLT_VERSION
WHERE
    INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0
SET QUOTED_IDENTIFIER ON 
