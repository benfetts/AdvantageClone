














/* CHANGE LOG:
==========================================================
ST, 20060510:
	- created this sproc to check if taxable flag is set in AGENCY for job comps
*/

CREATE PROCEDURE [dbo].[usp_wv_required_job_comp_taxable]  


@CLI_CODE varchar(6)

AS
DECLARE
@return int 
SELECT @return =
	CASE 
		CLIENT.TAX_FLAG_R WHEN 1 THEN 1 --first check the client table, if it is 1 then it is true and thus overrides AGENCY setting
	ELSE  
		(SELECT ISNULL(AGENCY.TAX_FLAG_R,0) FROM AGENCY) --else in CLIENT table it is null or zero (or something else) so check AGENCY TABLE
	END 
FROM CLIENT
WHERE CLIENT.CL_CODE = @CLI_CODE
SELECT @return













