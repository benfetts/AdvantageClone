﻿
CREATE PROCEDURE [dbo].[usp_AdvanDB_Client] 

AS

SELECT  CL_CODE, CL_NAME
FROM        CLIENT
WHERE   ACTIVE_FLAG = 1

