


















CREATE PROCEDURE [dbo].[usp_wv_job_required_ApprovedEstimate] 
@Client varchar(6),
@Division varchar(6),
@Product varchar(6)
AS
--Return var
DECLARE @ThisReturn AS INTEGER
SELECT @ThisReturn = 0

--Check product table
SELECT     
	@ThisReturn = ISNULL(PRD_PROD_ESTIMATE, 0)
FROM    
	PRODUCT
WHERE
	(CL_CODE = @Client)
	AND (DIV_CODE = @Division)
	AND (PRD_CODE = @Product)

--If it is false or null in product table, @ThisReturn is zero
--so check the agency table
IF @ThisReturn = 0
	SELECT @ThisReturn = ISNULL(APPR_EST_REQ, 0)
	FROM AGENCY

--return the flag
--basically, logic is check the flag in product table, 
--if it is false  in the product table,
--	check the agency table and return the value in there
--else if it is true  in the product table, return true
SELECT @ThisReturn

















