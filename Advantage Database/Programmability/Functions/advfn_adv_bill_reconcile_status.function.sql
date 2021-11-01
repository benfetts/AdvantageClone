
CREATE FUNCTION [dbo].[advfn_adv_bill_reconcile_status] ( @job_number integer, @job_component_nbr smallint )
RETURNS tinyint
AS
BEGIN
	DECLARE @reconcile_status tinyint
	DECLARE @method_desc varchar(30)
	DECLARE @rows integer
	DECLARE @ab_flag smallint
	
	SELECT @reconcile_status = 0
	
	SELECT @ab_flag = ( SELECT AB_FLAG FROM dbo.JOB_COMPONENT WHERE JOB_NUMBER = @job_number AND JOB_COMPONENT_NBR = @job_component_nbr )
	
	IF ( @ab_flag IS NOT NULL ) AND ( @ab_flag <> 0 )
	BEGIN
		SELECT @rows = ( SELECT COUNT( * )  
						  FROM dbo.ADVANCE_BILLING ab
						 WHERE ab.JOB_NUMBER = @job_number
						   AND ab.JOB_COMPONENT_NBR = @job_component_nbr
						   AND ab.AR_INV_NBR IS NULL
						   AND ab.AB_FLAG = 6 )
						   
		IF ( @rows = 0 )
		BEGIN
			SELECT @rows = ( SELECT COUNT( * )  
							   FROM dbo.ADVANCE_BILLING ab
							  WHERE ab.JOB_NUMBER = @job_number
								AND ab.JOB_COMPONENT_NBR = @job_component_nbr
								AND ab.AB_FLAG = 3
								AND ( ab.AR_INV_VOID IS NULL OR ab.AR_INV_VOID = 0 ))
								
			IF ( @rows = 0 )					
			BEGIN
				SELECT @method_desc = ( SELECT TOP 1 ab.METHOD_DESC   
										  FROM dbo.ADVANCE_BILLING ab
										 WHERE ab.JOB_NUMBER = @job_number
										   AND ab.JOB_COMPONENT_NBR = @job_component_nbr
										   AND ab.AB_FLAG IN( 4, 5 )
										   AND ( ab.AR_INV_VOID IS NULL OR ab.AR_INV_VOID = 0 )
									  ORDER BY ab.CREATE_DATE DESC )
				                      
				IF ( @method_desc = 'Reconcile to actual' )
					SELECT @reconcile_status = 1                      
				
				IF ( @method_desc = 'Reconcile to quote' )
					SELECT @reconcile_status = 2
					
				IF ( @method_desc = 'Reconcile to billed' )
					SELECT @reconcile_status = 4
			END
			ELSE
				SELECT @reconcile_status = 3		
		END
		ELSE
			SELECT @reconcile_status = 5
	END	

RETURN @reconcile_status
END
