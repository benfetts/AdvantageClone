﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_validate_JobCompIsViewable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_validate_JobCompIsViewable]
GO
CREATE PROCEDURE [dbo].[usp_wv_validate_JobCompIsViewable]
@JobNum INT,
@JobCompNum INT,
@UserID VARCHAR(20),
@FromApp VARCHAR(100)	
AS
/*=========== QUERY ===========*/
	DECLARE 
		@IsViewable INT,
		@ClientRestrictions INT,
		@OfficeRestrictions INT,
		@EMP_CODE AS VARCHAR(6),
		@JOB_OFFICE_CODE AS VARCHAR(4)

	SELECT @EMP_CODE = (SELECT TOP 1 EMP_CODE FROM [dbo].[SEC_USER] WITH (NOLOCK) WHERE UPPER([USER_CODE]) = UPPER(@UserID));
	SELECT @OfficeRestrictions = COUNT(1) FROM EMP_OFFICE WITH (NOLOCK) WHERE EMP_CODE = @EMP_CODE;
	SELECT @ClientRestrictions = COUNT(1) FROM SEC_CLIENT WITH (NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID)

	SELECT @IsViewable = 1;

	IF @OfficeRestrictions > 0
	BEGIN
		SELECT 
			@JOB_OFFICE_CODE = JL.OFFICE_CODE
		FROM
			JOB_LOG JL WITH(NOLOCK)
			INNER JOIN PRODUCT P ON JL.CL_CODE = P.CL_CODE AND JL.DIV_CODE = P.DIV_CODE AND JL.PRD_CODE = P.PRD_CODE
		WHERE
			JL.JOB_NUMBER = @JobNum;

		SELECT 
			@IsViewable = COUNT(1) 
		FROM 
			EMP_OFFICE EO WITH(NOLOCK) 
		WHERE 
			EO.EMP_CODE = @EMP_CODE AND EO.OFFICE_CODE = @JOB_OFFICE_CODE;
	END

	IF @IsViewable = 1
	BEGIN
		SET @IsViewable = 0;
		IF @ClientRestrictions > 0	
		BEGIN
			IF @FromApp = 'ts'
			BEGIN
				SELECT DISTINCT 
					@IsViewable = ISNULL(JOB_LOG.JOB_NUMBER, 0)
				FROM JOB_LOG WITH (NOLOCK) 
					INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
					INNER JOIN SEC_CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
				WHERE     
					JOB_LOG.JOB_NUMBER = @JobNum 
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobCompNum
 					AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID);
			END
			ELSE
			BEGIN
				SELECT DISTINCT 
					@IsViewable = ISNULL(JOB_LOG.JOB_NUMBER, 0)
				FROM JOB_LOG WITH (NOLOCK) 
					INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
					INNER JOIN SEC_CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
				WHERE     
					JOB_LOG.JOB_NUMBER = @JobNum 
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobCompNum
 					AND UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID) 
					AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL);
			END		
		END
		ELSE
		BEGIN
			SELECT DISTINCT 
				@IsViewable = ISNULL(JOB_LOG.JOB_NUMBER,0)
			FROM         
				JOB_LOG WITH (NOLOCK) 
				INNER JOIN JOB_COMPONENT WITH (NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
			WHERE     
				JOB_LOG.JOB_NUMBER = @JobNum
				AND JOB_COMPONENT.JOB_COMPONENT_NBR = @JobCompNum;
		END
	END
	
	SELECT ISNULL(@IsViewable,0);
/*=========== QUERY ===========*/