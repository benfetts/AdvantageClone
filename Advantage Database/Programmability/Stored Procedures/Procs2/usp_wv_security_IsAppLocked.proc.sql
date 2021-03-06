if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_security_IsAppLocked]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_security_IsAppLocked]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE [dbo].[usp_wv_security_IsAppLocked] 
	@APP_CODE AS INT,
	@APP_ID_VALUE1 AS INT,
	@APP_ID_VALUE2 AS INT,
	@APP_ID_VALUE3 AS INT,
	@USER_CODE AS VARCHAR(100),
	@JOB_NUMBER AS INT,
	@JOB_COMPONENT_NBR AS SMALLINT,
	@SEQ_NBR AS SMALLINT

AS

	DECLARE
	@RETURN_USER_CODE AS VARCHAR(100)
	
	SET @RETURN_USER_CODE = '';
	SET @USER_CODE = UPPER(@USER_CODE);
	
	IF @APP_CODE = 0 --Estimating
	BEGIN
		SELECT @RETURN_USER_CODE = ISNULL(LOCKED_USER,'') FROM ESTIMATE_LOG WITH(NOLOCK) WHERE ESTIMATE_NUMBER = @APP_ID_VALUE1;
		SET @RETURN_USER_CODE = UPPER(@RETURN_USER_CODE)
		IF UPPER(RTRIM(LTRIM(@RETURN_USER_CODE))) = UPPER(RTRIM(LTRIM(@USER_CODE)))
		BEGIN
			SET @RETURN_USER_CODE = ''
		END
	END
	
	IF @APP_CODE = 1 --Project Schedule
	BEGIN
		SELECT @RETURN_USER_CODE = ISNULL(LOCKED_USER,'') FROM JOB_TRAFFIC WITH(NOLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;
			SET @RETURN_USER_CODE = UPPER(@RETURN_USER_CODE)
	IF UPPER(RTRIM(LTRIM(@RETURN_USER_CODE))) = UPPER(RTRIM(LTRIM(@USER_CODE)))
		BEGIN
			SET @RETURN_USER_CODE = ''
		END
	END
	
	--IF @APP_CODE = 2 --Job Jacket
	--BEGIN
	--	SELECT @RETURN_USER_CODE = ISNULL(LOCKED_USER,'') FROM JOB_LOG WITH(NOLOCK) WHERE JOB_NUMBER = @APP_ID_VALUE1;
	--	IF RTRIM(LTRIM(@RETURN_USER_CODE)) = RTRIM(LTRIM(@USER_CODE))
	--	BEGIN
	--		SET @RETURN_USER_CODE = ''
	--	END
	--END
	
	--IF @APP_CODE = 3 --Purchase Order
	--BEGIN
	--	SELECT @RETURN_USER_CODE = ISNULL(LOCKED_USER,'') FROM PURCHASE_ORDER WITH(NOLOCK) WHERE PO_NUMBER = @APP_ID_VALUE1;
	--	IF RTRIM(LTRIM(@RETURN_USER_CODE)) = RTRIM(LTRIM(@USER_CODE))
	--	BEGIN
	--		SET @RETURN_USER_CODE = ''
	--	END
	--END
	
	
	IF RTRIM(LTRIM(@RETURN_USER_CODE)) = ''
		BEGIN
			SELECT ISNULL(@RETURN_USER_CODE,'');
		END
	ELSE
		BEGIN
			SELECT @RETURN_USER_CODE =
				ISNULL(ISNULL(EMPLOYEE.EMP_FNAME+' ','') + ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,''),'')
			FROM
				SEC_USER WITH(NOLOCK) INNER JOIN
				EMPLOYEE WITH(NOLOCK) ON SEC_USER.EMP_CODE = EMPLOYEE.EMP_CODE
			WHERE
				(UPPER(SEC_USER.USER_CODE)  COLLATE SQL_Latin1_General_CP1_CS_AS = UPPER(@RETURN_USER_CODE) COLLATE SQL_Latin1_General_CP1_CS_AS );
			SELECT @RETURN_USER_CODE;	
		END
		
		
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

