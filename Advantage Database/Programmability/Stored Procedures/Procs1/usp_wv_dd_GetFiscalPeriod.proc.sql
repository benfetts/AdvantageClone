﻿
CREATE PROCEDURE [dbo].[usp_wv_dd_GetFiscalPeriod] 

AS
SELECT 
    DISTINCT FISCAL_PERIOD_CODE as code, FISCAL_PERIOD_CODE + ' - ' + FISCAL_PERIOD_DESC as description
FROM 
    FISCAL_PERIOD
WHERE
    INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0
SET QUOTED_IDENTIFIER ON 
