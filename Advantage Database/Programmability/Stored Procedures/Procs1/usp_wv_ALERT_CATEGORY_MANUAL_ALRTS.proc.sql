﻿
CREATE PROCEDURE [dbo].[usp_wv_ALERT_CATEGORY_MANUAL_ALRTS] /*WITH ENCRYPTION*/
AS
/*=========== QUERY ===========*/
	SELECT ALERT_CAT_ID,
		   ALERT_DESC
	FROM   ALERT_CATEGORY WITH(NOLOCK)
	WHERE  ALERT_TYPE_ID = 6 AND ALERT_CAT_ID NOT IN (28,29,30,31)
	ORDER BY
		   ALERT_DESC;
/*=========== QUERY ===========*/
