
CREATE PROCEDURE [dbo].[usp_wv_Estimating_CountHeaderComponents] 
	@EST_NUMBER INT
AS
DECLARE
	@THE_COUNT SMALLINT
	
        SELECT @THE_COUNT = ISNULL( COUNT(1),0) FROM ESTIMATE_COMPONENT WITH(NOLOCK) WHERE  ESTIMATE_COMPONENT.ESTIMATE_NUMBER = @EST_NUMBER 
                IF @THE_COUNT = 1
	                BEGIN
		                SELECT EST_COMPONENT_NBR FROM ESTIMATE_COMPONENT WITH(NOLOCK) WHERE ESTIMATE_NUMBER = @EST_NUMBER	
	                END
                IF @THE_COUNT = 0
	                BEGIN
		                SELECT 0 AS EST_COMPONENT_NBR
	                END
                IF @THE_COUNT > 1
	                BEGIN
		                SELECT -1 AS EST_COMPONENT_NBR
	                END
    
	

