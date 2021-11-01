

CREATE PROCEDURE dbo.usp_wv_Job_Template_GetAlertRequirements_ByJobAndComp
	@Client VarChar(6),
	@Division VarChar(6),
	@Product VarChar(6),
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR INT
AS	
DECLARE
	@EmailGroup varchar(50),
	@EmailGroupProduct varchar(50)

	SELECT @EmailGroup = EMAIL_GR_CODE FROM JOB_COMPONENT WHERE JOB_NUMBER = @JOB_NUMBER and JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
	Select @EmailGroupProduct = EMAIL_GR_CODE From PRODUCT
				Where CL_CODE = @Client and 
				DIV_CODE = @Division and
				PRD_CODE = @Product

	IF @EmailGroup <> '' 
		SELECT 'AgencyRequiredEmail' AS ReqDescript, ISNULL(AUTO_EMAIL,0) AS IsRequired
		FROM AGENCY
	
		UNION
	
		SELECT 'AutoEmailPromptOnNew' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=3
	
		UNION
	
		SELECT 'AutoEmailPromptOnUpdate' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=4
	
		UNION
			
		SELECT 'ClientGetsEmailOnNew' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=3
		AND E_GROUP=@EmailGroup
	
		UNION
	
		SELECT 'ClientGetsEmailOnUpdate' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=4
		AND E_GROUP=@EmailGroup
	ELSE IF @EmailGroupProduct <> ''
		SELECT 'AgencyRequiredEmail' AS ReqDescript, ISNULL(AUTO_EMAIL,0) AS IsRequired
		FROM AGENCY
	
		UNION
	
		SELECT 'AutoEmailPromptOnNew' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=3
	
		UNION
	
		SELECT 'AutoEmailPromptOnUpdate' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=4
	
		UNION
			
		SELECT 'ClientGetsEmailOnNew' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=3
		AND E_GROUP=@EmailGroupProduct
	
		UNION
	
		SELECT 'ClientGetsEmailOnUpdate' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=4
		AND E_GROUP=@EmailGroupProduct
	ELSE
		SELECT 'AgencyRequiredEmail' AS ReqDescript, ISNULL(AUTO_EMAIL,0) AS IsRequired
		FROM AGENCY
	
		UNION
	
		SELECT 'AutoEmailPromptOnNew' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=3
	
		UNION
	
		SELECT 'AutoEmailPromptOnUpdate' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=4
	
		UNION
			
		SELECT 'ClientGetsEmailOnNew' AS ReqDescript, 0 AS IsRequired
	
		UNION
	
		SELECT 'ClientGetsEmailOnUpdate' AS ReqDescript, 0 AS IsRequired



