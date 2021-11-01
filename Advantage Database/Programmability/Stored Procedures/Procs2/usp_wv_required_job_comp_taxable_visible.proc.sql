









CREATE PROCEDURE [dbo].[usp_wv_required_job_comp_taxable_visible] 

AS
DECLARE
@return int 

SELECT @return =
	CASE
		AGENCY.FLAG_TAX_JOBS WHEN 1 THEN 1
	ELSE
		0
	END	
FROM AGENCY

SELECT @return









