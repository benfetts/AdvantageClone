







CREATE PROCEDURE [dbo].[usp_wv_fnc_NonBillableFlag] 
@fnc_code varchar(6)
AS



Select ISNULL(FNC_NONBILL_FLAG,0)
FROM FUNCTIONS
WHERE FNC_CODE = @fnc_code
