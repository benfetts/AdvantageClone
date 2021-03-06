IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ALERT_NOTIFY_EMPS_GET_AVAILABLE]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_ALERT_NOTIFY_EMPS_GET_AVAILABLE]
GO
CREATE PROCEDURE [dbo].[usp_wv_ALERT_NOTIFY_EMPS_GET_AVAILABLE] /*WITH ENCRYPTION*/
@ALRT_NOTIFY_HDR_ID  INT,
@ALERT_STATE_ID      INT,
@ROLE_CODE           VARCHAR(6),
@EMAIL_GR_CODE       VARCHAR(50),
@USER_CODE           VARCHAR(100)
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE		
		@OfficeRestrictions AS INT,
		@EMP_CODE AS VARCHAR(6),
		@IS_CS BIT
	DECLARE
		@EMPS TABLE (EMP_CODE VARCHAR(6), EMP_FML VARCHAR(1000));

	SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@USER_CODE)
	SELECT @OfficeRestrictions = COUNT(1) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE;
	
	SELECT 
		@IS_CS =	CASE
						WHEN A.[TYPE] = 2 THEN CAST(1 AS BIT)
						ELSE CAST(0 AS BIT)
					END 
	FROM 
		ALERT_NOTIFY_HDR A WITH(NOLOCK)
	WHERE 
		A.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID;

	IF @ROLE_CODE IS NULL
	BEGIN
		SET @ROLE_CODE = '';
	END

	IF @EMAIL_GR_CODE IS NULL
	BEGIN
		SET @EMAIL_GR_CODE = '';
	END
	--NOT FILTERED
	IF @ROLE_CODE = '' AND @EMAIL_GR_CODE = ''
	BEGIN
		IF @OfficeRestrictions > 0
		BEGIN
			INSERT INTO @EMPS
			SELECT EMPLOYEE.EMP_CODE,
				   ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML
			FROM   EMPLOYEE WITH(NOLOCK) INNER JOIN
						EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			WHERE  (EMP_TERM_DATE IS NULL)
				   AND EMPLOYEE.EMP_CODE NOT IN (SELECT EMP_CODE
										FROM   ALERT_NOTIFY_EMPS WITH(NOLOCK)
										WHERE  ALERT_NOTIFY_EMPS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
											   AND ALERT_NOTIFY_EMPS.ALERT_STATE_ID = @ALERT_STATE_ID)
		END
		ELSE
		BEGIN
			INSERT INTO @EMPS
			SELECT EMPLOYEE.EMP_CODE,
				   ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML
			FROM   EMPLOYEE WITH(NOLOCK)
			WHERE  (EMP_TERM_DATE IS NULL)
				   AND EMP_CODE NOT IN (SELECT EMP_CODE
										FROM   ALERT_NOTIFY_EMPS WITH(NOLOCK)
										WHERE  ALERT_NOTIFY_EMPS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
											   AND ALERT_NOTIFY_EMPS.ALERT_STATE_ID = @ALERT_STATE_ID)
		END
	END		
	--FILTERED BY ROLE  
	IF @ROLE_CODE <> '' AND @EMAIL_GR_CODE = ''
	BEGIN
		IF @OfficeRestrictions > 0
		BEGIN
			INSERT INTO @EMPS
			SELECT EMPLOYEE.EMP_CODE,
				   ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML
			FROM   EMPLOYEE WITH(NOLOCK) INNER JOIN
						EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			WHERE  (EMP_TERM_DATE IS NULL)
				   AND EMPLOYEE.EMP_CODE NOT IN (SELECT EMP_CODE
										FROM   ALERT_NOTIFY_EMPS WITH(NOLOCK)
										WHERE  ALERT_NOTIFY_EMPS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
											   AND ALERT_NOTIFY_EMPS.ALERT_STATE_ID = @ALERT_STATE_ID)
				   AND EMPLOYEE.EMP_CODE IN (SELECT DISTINCT EMP_CODE
									FROM   EMP_TRAFFIC_ROLE WITH(NOLOCK)
									WHERE  ROLE_CODE = @ROLE_CODE)
		END
		ELSE
		BEGIN
			INSERT INTO @EMPS
			SELECT EMPLOYEE.EMP_CODE,
				   ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML
			FROM   EMPLOYEE WITH(NOLOCK)
			WHERE  (EMP_TERM_DATE IS NULL)
				   AND EMP_CODE NOT IN (SELECT EMP_CODE
										FROM   ALERT_NOTIFY_EMPS WITH(NOLOCK)
										WHERE  ALERT_NOTIFY_EMPS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
											   AND ALERT_NOTIFY_EMPS.ALERT_STATE_ID = @ALERT_STATE_ID)
				   AND EMP_CODE IN (SELECT DISTINCT EMP_CODE
									FROM   EMP_TRAFFIC_ROLE WITH(NOLOCK)
									WHERE  ROLE_CODE = @ROLE_CODE)
		END
		
	END	
	--FILTERED BY EMAIL GROUP	   
	IF @ROLE_CODE = '' AND @EMAIL_GR_CODE <> ''
	BEGIN
		IF @OfficeRestrictions > 0
		BEGIN
			INSERT INTO @EMPS
			SELECT EMPLOYEE.EMP_CODE,
				   ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML
			FROM   EMPLOYEE WITH(NOLOCK) INNER JOIN
						EMP_OFFICE ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			WHERE  (EMP_TERM_DATE IS NULL)
				   AND EMPLOYEE.EMP_CODE NOT IN (SELECT EMP_CODE
										FROM   ALERT_NOTIFY_EMPS WITH(NOLOCK)
										WHERE  ALERT_NOTIFY_EMPS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
											   AND ALERT_NOTIFY_EMPS.ALERT_STATE_ID = @ALERT_STATE_ID)
				   AND EMPLOYEE.EMP_CODE IN (SELECT DISTINCT EMP_CODE
									FROM   EMAIL_GROUP
									WHERE  EMAIL_GR_CODE = @EMAIL_GR_CODE
										   AND (
												   EMAIL_GROUP.INACTIVE_FLAG IS NULL
												   OR EMAIL_GROUP.INACTIVE_FLAG = 0
											   )
										   )
		END
		ELSE
		BEGIN
			INSERT INTO @EMPS
			SELECT EMPLOYEE.EMP_CODE,
				   ISNULL(EMPLOYEE.EMP_FNAME + ' ', '') + ISNULL(EMPLOYEE.EMP_MI + '. ', '') + ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML
			FROM   EMPLOYEE WITH(NOLOCK)
			WHERE  (EMP_TERM_DATE IS NULL)
				   AND EMP_CODE NOT IN (SELECT EMP_CODE
										FROM   ALERT_NOTIFY_EMPS WITH(NOLOCK)
										WHERE  ALERT_NOTIFY_EMPS.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID
											   AND ALERT_NOTIFY_EMPS.ALERT_STATE_ID = @ALERT_STATE_ID)
				   AND EMP_CODE IN (SELECT DISTINCT EMP_CODE
									FROM   EMAIL_GROUP
									WHERE  EMAIL_GR_CODE = @EMAIL_GR_CODE
										   AND (
												   EMAIL_GROUP.INACTIVE_FLAG IS NULL
												   OR EMAIL_GROUP.INACTIVE_FLAG = 0
											   )
										   )
		END
		
	END

	SELECT
		E.*
	FROM
		@EMPS E
	ORDER BY
		E.EMP_FML;
END
/*=========== QUERY ===========*/
