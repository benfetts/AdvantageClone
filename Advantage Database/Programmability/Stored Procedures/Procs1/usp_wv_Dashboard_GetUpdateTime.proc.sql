﻿

CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetUpdateTime]

AS

SELECT  DISTINCT   DATA_UPDATE
FROM         DASH_DATA_EMP_TIME

