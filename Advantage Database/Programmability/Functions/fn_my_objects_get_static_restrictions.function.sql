--DROP FUNCTION [dbo].[fn_my_objects_get_static_restrictions]
CREATE FUNCTION [dbo].[fn_my_objects_get_static_restrictions] (@OBJECT_ID AS INT)
RETURNS @STATIC_RESTRICTIONS TABLE 
(
	ALERT_GROUP BIT,
	SCHEDULE_ASSIGNMENTS BIT,
	SCHEDULE_MANAGER BIT,
	TASK_ASSIGNEES BIT,
	ACCOUNT_EXECUTIVE BIT,
	AGENCY_MANAGER_COLUMN VARCHAR(40),
	JOB_TRAFFIC_MANAGER_COLUMN VARCHAR(40),
	HAS_ACTIVE_RESTRICTION BIT
)
AS
BEGIN

	DECLARE
		@ALERT_GROUP BIT,
		@SCHEDULE_ASSIGNMENTS BIT,
		@SCHEDULE_MANAGER BIT,
		@TASK_ASSIGNEES BIT,
		@ACCOUNT_EXECUTIVE BIT,
		@AGENCY_MANAGER_COLUMN VARCHAR(40),
		@JOB_TRAFFIC_MANAGER_COLUMN VARCHAR(40),
		@HAS_ACTIVE_RESTRICTION BIT

	SELECT @ALERT_GROUP = ISNULL(A.CHECKED, 0)
	FROM 
		[dbo].[fn_my_objects_get_object_definitions] (@OBJECT_ID, 0) AS A
	WHERE
		A.IS_STATIC = 1 
		AND A.DEFINITION_ID = 1;
	SELECT @SCHEDULE_ASSIGNMENTS = ISNULL(A.CHECKED, 0)
	FROM 
		[dbo].[fn_my_objects_get_object_definitions] (@OBJECT_ID, 0) AS A
	WHERE
		A.IS_STATIC = 1 
		AND A.DEFINITION_ID = 2;
		
	SELECT @SCHEDULE_MANAGER = ISNULL(A.CHECKED, 0)
	FROM 
		[dbo].[fn_my_objects_get_object_definitions] (@OBJECT_ID, 0) AS A
	WHERE
		A.IS_STATIC = 1 
		AND A.DEFINITION_ID = 3;
		
	SELECT @TASK_ASSIGNEES = ISNULL(A.CHECKED, 0)
	FROM 
		[dbo].[fn_my_objects_get_object_definitions] (@OBJECT_ID, 0) AS A
	WHERE
		A.IS_STATIC = 1 
		AND A.DEFINITION_ID = 4;

	SELECT @ACCOUNT_EXECUTIVE = B.CHECKED
	FROM ( 
	SELECT ISNULL(CHECKED, 0) AS CHECKED FROM
	[dbo].[fn_my_objects_get_object_definitions] (@OBJECT_ID, 0) AS A
	WHERE UPPER(A.DEFINITION_DESCRIPTION) LIKE '%ACC%EX%' ) AS B;

	SELECT @AGENCY_MANAGER_COLUMN = CONVERT(VARCHAR, AGY_SETTINGS.AGY_SETTINGS_VALUE) 
	FROM 
		AGY_SETTINGS WITH(NOLOCK) 
	WHERE 
		AGY_SETTINGS.AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL';	

	IF NOT @AGENCY_MANAGER_COLUMN IS NULL
	BEGIN

		SELECT @JOB_TRAFFIC_MANAGER_COLUMN = 'ASSIGN_' + SUBSTRING(@AGENCY_MANAGER_COLUMN, LEN(@AGENCY_MANAGER_COLUMN) , 1);
		
	END
	ELSE
	BEGIN

		SELECT @AGENCY_MANAGER_COLUMN = 'TR_TITLE1';
		SELECT @JOB_TRAFFIC_MANAGER_COLUMN = 'ASSIGN_1';
		
	END

	SET @ALERT_GROUP = ISNULL(@ALERT_GROUP, 0);
	SET @SCHEDULE_ASSIGNMENTS = ISNULL(@SCHEDULE_ASSIGNMENTS, 0);
	SET @SCHEDULE_MANAGER = ISNULL(@SCHEDULE_MANAGER, 0);
	SET @TASK_ASSIGNEES = ISNULL(@TASK_ASSIGNEES, 0);
	SET @ACCOUNT_EXECUTIVE = ISNULL(@ACCOUNT_EXECUTIVE, 0);
	SET @HAS_ACTIVE_RESTRICTION = 0;

	IF @ALERT_GROUP = 1 OR @SCHEDULE_ASSIGNMENTS = 1 OR @SCHEDULE_MANAGER = 1 OR @TASK_ASSIGNEES = 1 OR @ACCOUNT_EXECUTIVE = 1
	BEGIN
		SET @HAS_ACTIVE_RESTRICTION = 1;
	END

	INSERT INTO @STATIC_RESTRICTIONS (ALERT_GROUP, SCHEDULE_ASSIGNMENTS, SCHEDULE_MANAGER, TASK_ASSIGNEES, ACCOUNT_EXECUTIVE, AGENCY_MANAGER_COLUMN, JOB_TRAFFIC_MANAGER_COLUMN, HAS_ACTIVE_RESTRICTION)
	VALUES( @ALERT_GROUP, @SCHEDULE_ASSIGNMENTS, @SCHEDULE_MANAGER, @TASK_ASSIGNEES, @ACCOUNT_EXECUTIVE, @AGENCY_MANAGER_COLUMN, @JOB_TRAFFIC_MANAGER_COLUMN, @HAS_ACTIVE_RESTRICTION)
		
RETURN

END
