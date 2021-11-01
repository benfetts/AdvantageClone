﻿

















/* CHANGE LOG:
==========================================================
Sam, 20060501:
	Add the ISNULL check to both active query and the original.
	Tried different parts of the INACTIVE_FLAG filter to get results expected.


*/

CREATE PROCEDURE [dbo].[usp_wv_dd_jc_udf5] 
AS
SELECT DISTINCT UDV_CODE as code, UDV_CODE + ' - ' + ISNULL(UDV_DESC,'(No description set!)')  as description
FROM JOB_CMP_UDV5
WHERE
 (INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG <> 1)

















