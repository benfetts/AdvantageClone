
CREATE FUNCTION [dbo].[fn_invoice_list_to_job_table] 
(	
	@list_option tinyint, @list varchar(4000)
)
RETURNS @joblist TABLE (JOB_NUMBER int, JOB_COMPONENT_NBR smallint)
AS
BEGIN
	IF @list_option = 0
		BEGIN 
		INSERT @joblist
		SELECT DISTINCT arj.JOB_NUMBER, arj.JOB_COMPONENT_NBR
		FROM dbo.ARINV_JOB arj
		JOIN dbo.fn_intlist_to_table(@list) l 
			ON arj.AR_INV_NBR = l.number
		END
	ELSE 
		BEGIN
		INSERT @joblist
		SELECT DISTINCT jc.JOB_NUMBER, jc.JOB_COMPONENT_NBR
		FROM dbo.JOB_COMPONENT jc
		JOIN dbo.fn_charlist_to_table2(@list) l 
			ON jc.BILLING_USER = l.vstr
		END
RETURN
END
