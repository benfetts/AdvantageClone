
CREATE FUNCTION dbo.advtf_advance_bill_by_job
( @job_number integer, @job_component_nbr smallint )
RETURNS @adv_bill_job TABLE ( 
	ADV_BILL		bit NOT NULL,
	CALC_METHOD		smallint NULL,
	BILLED			decimal(15,2) NULL, 
	UNBILLED		decimal(15,2) NULL,
	INCOME_REC		decimal(15,2) NULL )
AS
BEGIN
	DECLARE @adv_bill bit, @calc_method smallint
	
	SELECT @adv_bill = ( SELECT COALESCE( AB_FLAG, 0 ) 
						   FROM dbo.JOB_COMPONENT 
						  WHERE ( JOB_NUMBER = @job_number ) 
						    AND ( JOB_COMPONENT_NBR = @job_component_nbr ))

	IF ( @adv_bill > 0 )
	BEGIN
		SELECT @adv_bill = 1
		SELECT @calc_method = ( SELECT TOP 1 CALC_METHOD
								  FROM dbo.ADVANCE_BILLING
								 WHERE ( JOB_NUMBER = @job_number ) 
								   AND ( JOB_COMPONENT_NBR = @job_component_nbr )
							  ORDER BY AB_ID DESC, SEQ_NBR DESC )
	END

	INSERT INTO @adv_bill_job( ADV_BILL, CALC_METHOD )
		 VALUES ( @adv_bill, @calc_method )

	 UPDATE @adv_bill_job
	    SET BILLED = ( SELECT COALESCE( SUM( LINE_TOTAL ), 0.00 )
						 FROM dbo.ADVANCE_BILLING
						WHERE ( JOB_NUMBER = @job_number ) 
						  AND ( JOB_COMPONENT_NBR = @job_component_nbr )
						  AND ( AR_INV_NBR IS NOT NULL ))

	 UPDATE @adv_bill_job
	    SET UNBILLED = ( SELECT COALESCE( SUM( LINE_TOTAL ), 0.00 )
						   FROM dbo.ADVANCE_BILLING
						  WHERE ( JOB_NUMBER = @job_number ) 
						    AND ( JOB_COMPONENT_NBR = @job_component_nbr )
						    AND ( AR_INV_NBR IS NULL ))

	 UPDATE @adv_bill_job
	    SET INCOME_REC = ( SELECT COALESCE( SUM( REC_AMT ), 0.00 )
						     FROM dbo.INCOME_REC
						    WHERE ( JOB_NUMBER = @job_number ) 
						      AND ( JOB_COMPONENT_NBR = @job_component_nbr ))

RETURN
END
