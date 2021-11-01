


















/*
ST, 20060614:
Added to get account number lookup in job component in job jacket
*/


CREATE PROCEDURE [dbo].[usp_wv_dd_jc_AccountNumber] 
AS


SELECT 
	DISTINCT ACCT_NBR AS code
	, ACCT_NBR + ' - ' + ISNULL(ACCT_NBR_DESC, '') AS description

FROM         
	ACCT_NUMBER

WHERE     
	(ACTIVE = 1)

ORDER BY 
	ACCT_NBR ASC


















