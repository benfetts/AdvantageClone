


























CREATE PROCEDURE [dbo].[usp_wv_dd_GetTaskDescriptions] AS
/* ORIGINAL:
SELECT     TRF_CODE as Code,  TRF_CODE + ' - ' + TRF_DESC as Description
FROM         TRAFFIC_FNC
*/

/* Restricted on Traffic function being not inactive in only TRAFFIC_FNC table */
SELECT
	TRF_CODE AS Code, TRF_CODE + ' - ' + TRF_DESC AS Description, TRF_INACTIVE, FNC_CODE
FROM
	TRAFFIC_FNC
WHERE
	((TRF_INACTIVE IS NULL) OR (TRF_INACTIVE = 0))


/* Restricted on Traffic function being not inactive AND function in FUNCTIONS table BOTH being not inactive) 
SELECT     
	TRAFFIC_FNC.TRF_CODE AS Code, TRAFFIC_FNC.TRF_CODE + ' - ' + TRAFFIC_FNC.TRF_DESC AS Description, 
	TRAFFIC_FNC.TRF_INACTIVE, TRAFFIC_FNC.FNC_CODE, FUNCTIONS.FNC_INACTIVE
FROM
	TRAFFIC_FNC INNER JOIN
	FUNCTIONS ON TRAFFIC_FNC.FNC_CODE = FUNCTIONS.FNC_CODE
WHERE
	((TRAFFIC_FNC.TRF_INACTIVE IS NULL) OR (TRAFFIC_FNC.TRF_INACTIVE = 0)) 
	AND ((FUNCTIONS.FNC_INACTIVE IS NULL) OR (FUNCTIONS.FNC_INACTIVE = 0))


*/




















