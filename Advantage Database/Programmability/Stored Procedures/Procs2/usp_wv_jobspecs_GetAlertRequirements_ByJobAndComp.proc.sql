

CREATE PROCEDURE dbo.usp_wv_jobspecs_GetAlertRequirements_ByJobAndComp
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
		WHERE ALERT_CAT_ID=15
		
		UNION
	
		SELECT 'AutoEmailPromptOnUpdate' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=22
	
		UNION
	
		SELECT 'AutoEmailPromptOnRevision' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=16
	
		UNION
			
		SELECT 'ClientGetsEmailOnNewJS' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=15
		AND E_GROUP=@EmailGroup
	
		UNION
	
		SELECT 'ClientGetsEmailOnUpdateJS' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=22
		AND E_GROUP=@EmailGroup

		UNION
	
		SELECT 'ClientGetsEmailOnRevisionJS' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=16
		AND E_GROUP=@EmailGroup
	ELSE IF @EmailGroupProduct <> ''
		SELECT 'AgencyRequiredEmail' AS ReqDescript, ISNULL(AUTO_EMAIL,0) AS IsRequired
		FROM AGENCY
	
		UNION
	
		SELECT 'AutoEmailPromptOnNew' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=15
		
		UNION
	
		SELECT 'AutoEmailPromptOnUpdate' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=22
	
		UNION
	
		SELECT 'AutoEmailPromptOnRevision' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=16
	
		UNION
			
		SELECT 'ClientGetsEmailOnNewJS' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=15
		AND E_GROUP=@EmailGroup
	
		UNION
	
		SELECT 'ClientGetsEmailOnUpdateJS' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=22
		AND E_GROUP=@EmailGroup

		UNION
	
		SELECT 'ClientGetsEmailOnRevisionJS' AS ReqDescript, ISNULL(ACTIVE_FLAG,0) AS IsRequired
		FROM ALERT_GROUP
		WHERE ALERT_CAT_ID=16
		AND E_GROUP=@EmailGroup
	ELSE
		SELECT 'AgencyRequiredEmail' AS ReqDescript, ISNULL(AUTO_EMAIL,0) AS IsRequired
		FROM AGENCY
	
		UNION
	
		SELECT 'AutoEmailPromptOnNew' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=15
		
		UNION
	
		SELECT 'AutoEmailPromptOnUpdate' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=22
	
		UNION
	
		SELECT 'AutoEmailPromptOnRevision' AS ReqDescript, ISNULL(PROMPT,0) AS IsRequired
		FROM ALERT_CATEGORY
		WHERE ALERT_CAT_ID=16
	
		UNION
			
		SELECT 'ClientGetsEmailOnNewJS' AS ReqDescript, 0 AS IsRequired
	
		UNION
	
		SELECT 'ClientGetsEmailOnUpdateJS' AS ReqDescript, 0 AS IsRequired

		UNION
	
		SELECT 'ClientGetsEmailOnRevisionJS' AS ReqDescript, 0 AS IsRequired

