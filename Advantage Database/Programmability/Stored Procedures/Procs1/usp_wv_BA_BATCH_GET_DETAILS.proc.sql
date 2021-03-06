SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_BA_BATCH_GET_DETAILS]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_BA_BATCH_GET_DETAILS]
GO
CREATE PROCEDURE [dbo].[usp_wv_BA_BATCH_GET_DETAILS] /*WITH ENCRYPTION*/
@BA_BATCH_ID AS INT,
@USER_CODE VARCHAR(100)
AS
/*=========== QUERY ===========*/
		DECLARE
			@LOAD_LEVEL AS VARCHAR(20),
			@HAS_LEVEL AS INT,
			@CAN_EDIT_CRITERIA AS BIT
			SET @LOAD_LEVEL = 'CDPC' --INITIATE TO "ALL"
			SET @HAS_LEVEL = 0
			SET @CAN_EDIT_CRITERIA = 1
			
		----SET LOAD LEVEL:
		----	Each level overrides the next.
		----	If all are null, it should stay at the default all level of "CDPC"

		--HAS CLIENT CODES?
		SELECT     
			@HAS_LEVEL = ISNULL(COUNT(1),0)
		FROM         
			BILL_APPR_BATCH_CDP WITH(NOLOCK)
		WHERE     
			(NOT (BILL_APPR_BATCH_CDP.CL_CODE IS NULL)) 
			AND (BILL_APPR_BATCH_CDP.BA_BATCH_ID = @BA_BATCH_ID);	
		IF @HAS_LEVEL > 0
		BEGIN
			SET @LOAD_LEVEL = 'CLIENT';
		END	
		--HAS DIVISION CODES?
		SELECT     
			@HAS_LEVEL = ISNULL(COUNT(1),0)
		FROM         
			BILL_APPR_BATCH_CDP WITH(NOLOCK)
		WHERE     
			(NOT (BILL_APPR_BATCH_CDP.DIV_CODE IS NULL)) 
			AND (BILL_APPR_BATCH_CDP.BA_BATCH_ID = @BA_BATCH_ID);	
		IF @HAS_LEVEL > 0
		BEGIN
			SET @LOAD_LEVEL = 'DIVISION';
		END	
		--HAS DIVISION CODES?
		SELECT     
			@HAS_LEVEL = ISNULL(COUNT(1),0)
		FROM         
			BILL_APPR_BATCH_CDP WITH(NOLOCK)
		WHERE     
			(NOT (BILL_APPR_BATCH_CDP.PRD_CODE IS NULL)) 
			AND (BILL_APPR_BATCH_CDP.BA_BATCH_ID = @BA_BATCH_ID);	
		IF @HAS_LEVEL > 0
		BEGIN
			SET @LOAD_LEVEL = 'PRODUCT';
		END	
		SELECT     
			@HAS_LEVEL = ISNULL(COUNT(1),0)
		FROM        
			BILL_APPR_BATCH_CMP WITH(NOLOCK)
		WHERE
			BILL_APPR_BATCH_CMP.BA_BATCH_ID = @BA_BATCH_ID;
		IF @HAS_LEVEL > 0
		BEGIN
			SET @LOAD_LEVEL = 'CAMPAIGN';
		END	
			
		DECLARE @JOB_BATCH_COUNT AS INTEGER
		
		SELECT @JOB_BATCH_COUNT = dbo.wvfn_get_batch_job_count(@BA_BATCH_ID, 1);
			
		--GET BATCH DATA (0):
		SELECT    
			@LOAD_LEVEL AS LOAD_LEVEL, BILL_APPR_BATCH.BA_BATCH_ID, BILL_APPR_BATCH.BA_BATCH_DESC, BILL_APPR_BATCH.BATCH_DATE, BILL_APPR_BATCH.CREATE_USER, BILL_APPR_BATCH.CREATE_DATE, 
			BILL_APPR_BATCH.MODIFY_USER, BILL_APPR_BATCH.MODIFY_DATE, BILL_APPR_BATCH.DATE_CUTOFF, BILL_APPR_BATCH.PERIOD_CUTOFF, BILL_APPR_BATCH.EMP_CODE, 
			ISNULL(EMPLOYEE.EMP_FNAME+' ','')+ISNULL(EMPLOYEE.EMP_MI+'. ','')+ISNULL(EMPLOYEE.EMP_LNAME,'') AS EMP_FML_NAME,
			ISNULL(INCL_NO_DTL,0) AS INCL_NO_DTL, ISNULL(INCL_NB,0) AS INCL_NB, ISNULL(INCL_FEE,0) AS INCL_FEE, ISNULL(INCL_INT,0) AS INCL_INT, ISNULL(INCL_NP,0) AS INCL_NP, ISNULL(INCL_MAG,0) AS INCL_MAG, 
			ISNULL(INCL_OD,0) AS INCL_OD, ISNULL(INCL_RA,0) AS INCL_RA, ISNULL(INCL_TV,0) AS INCL_TV, ISNULL(BA_EXISTS,0) AS BA_EXISTS, ISNULL(APPROVED,0) AS APPROVED, ISNULL(FINISHED,0) AS FINISHED, 
			ISNULL(APPR_METHOD,0) AS APPR_METHOD, ISNULL(BA_EXISTS,0) AS BA_EXISTS, ISNULL(BILLED_ANY,0) AS BILLED_ANY, ISNULL(BILLED_ALL,0) AS BILLED_ALL,
			dbo.wvfn_get_batch_status(BILL_APPR_BATCH.BA_BATCH_ID) AS STATUS,
			CASE
				WHEN EXISTS(SELECT * FROM ALERT WITH(NOLOCK) WHERE BA_BATCH_ID = BILL_APPR_BATCH.BA_BATCH_ID) THEN 'Sent'
				ELSE 'None'
			END AS ALERT_STATUS,		
			--CASE
			--	WHEN RTRIM(LTRIM(BILL_APPR_BATCH.CREATE_USER)) = RTRIM(LTRIM(@USER_CODE)) THEN 1
			--	ELSE 0
			--END 
			1 AS CAN_EDIT_BATCH,
			CASE
				WHEN APPROVED = 1 THEN 0
				WHEN FINISHED = 1 THEN 0
				WHEN BILLED_ANY = 1 THEN 0
				WHEN BILLED_ALL = 1 THEN 0
				ELSE 1
			END AS CAN_EDIT_CRITERIA,
			CASE
				WHEN APPROVED = 1 THEN 0
				WHEN FINISHED = 1 THEN 0
				WHEN BILLED_ANY = 1 THEN 0
				WHEN BILLED_ALL = 1 THEN 0
				WHEN BA_EXISTS = 1 THEN 0
				ELSE 1
			END AS CAN_DELETE, @JOB_BATCH_COUNT AS JOB_BATCH_COUNT, 
             SEC_USER.EMP_CODE AS CREATE_USER_EMP_CODE, BILL_APPR_BATCH.CREATE_USER AS CREATE_USER_NAME, 
			 ISNULL(A.USER_NAME,'') AS MODIFY_USER_NAME,
			 SEL_OPTION,
			 ISNULL(BILL_APPR_BATCH.MANAGER_TYPE, 0) AS MANAGER_TYPE -- 0=AE, 1=PM
            FROM        
                BILL_APPR_BATCH WITH (NOLOCK) INNER JOIN
                EMPLOYEE WITH (NOLOCK) ON BILL_APPR_BATCH.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
                SEC_USER WITH (NOLOCK)  ON UPPER(BILL_APPR_BATCH.CREATE_USER) = UPPER(SEC_USER.USER_CODE) LEFT OUTER JOIN
				SEC_USER A WITH (NOLOCK) ON UPPER(BILL_APPR_BATCH.MODIFY_USER) = UPPER(A.USER_CODE)
            WHERE     
                (BILL_APPR_BATCH.BA_BATCH_ID = @BA_BATCH_ID);
			
		--GET AE's (1):
		SELECT     
			AE_EMP_CODE AS SELECTED_VALUES, AE_EMP_CODE AS ALERT_DISPLAY
		FROM         
			BILL_APPR_BATCH_AE WITH(NOLOCK)
		WHERE
			BILL_APPR_BATCH_AE.BA_BATCH_ID = @BA_BATCH_ID;

		--GET PM's (2):
		SELECT     
			PM_EMP_CODE AS SELECTED_VALUES, PM_EMP_CODE AS ALERT_DISPLAY
		FROM         
			BILL_APPR_BATCH_PM WITH(NOLOCK)
		WHERE
			BILL_APPR_BATCH_PM.BA_BATCH_ID = @BA_BATCH_ID;

		--GET C/D/P/C (3)
		IF @LOAD_LEVEL = 'CDPC'
		BEGIN
			SELECT 'CDPC' AS SELECTED_VALUES, 'CDPC' AS ALERT_DISPLAY
		END	
		IF @LOAD_LEVEL = 'CLIENT'
		BEGIN
			SELECT     
				ISNULL(CL_CODE,'') AS SELECTED_VALUES,
				ISNULL(CL_CODE,'') AS ALERT_DISPLAY
			FROM
				BILL_APPR_BATCH_CDP WITH(NOLOCK)
			WHERE
				BILL_APPR_BATCH_CDP.BA_BATCH_ID = @BA_BATCH_ID;
		END	
		IF @LOAD_LEVEL = 'DIVISION'
		BEGIN
			SELECT     
				ISNULL(CL_CODE,'') + ':' + ISNULL(DIV_CODE,'') AS SELECTED_VALUES,
				ISNULL(CL_CODE,'') + ':' + ISNULL(DIV_CODE,'') AS ALERT_DISPLAY
			FROM
				BILL_APPR_BATCH_CDP WITH(NOLOCK)
			WHERE
				BILL_APPR_BATCH_CDP.BA_BATCH_ID = @BA_BATCH_ID;
		END	
		IF @LOAD_LEVEL = 'PRODUCT'
		BEGIN
			SELECT     
				ISNULL(CL_CODE,'') + ':' + ISNULL(DIV_CODE,'') + ':' + ISNULL(PRD_CODE,'') AS SELECTED_VALUES,
				ISNULL(CL_CODE,'') + ':' + ISNULL(DIV_CODE,'') + ':' + ISNULL(PRD_CODE,'') AS ALERT_DISPLAY
			FROM
				BILL_APPR_BATCH_CDP WITH(NOLOCK)
			WHERE
				BILL_APPR_BATCH_CDP.BA_BATCH_ID = @BA_BATCH_ID;
		END	
		IF @LOAD_LEVEL = 'CAMPAIGN'
		BEGIN
			SELECT     
				CAMPAIGN.CL_CODE + ':' + ISNULL(CAMPAIGN.DIV_CODE, '') + ':' + ISNULL(CAMPAIGN.PRD_CODE, '') 
				+ ':' + CAMPAIGN.CMP_CODE + ':' + CAST(CAMPAIGN.CMP_IDENTIFIER AS VARCHAR) AS SELECTED_VALUES,
								CAMPAIGN.CL_CODE + ':' + ISNULL(CAMPAIGN.DIV_CODE, '') + ':' + ISNULL(CAMPAIGN.PRD_CODE, '') 
				+ ':' + CAMPAIGN.CMP_CODE  AS ALERT_DISPLAY

			FROM         
				CAMPAIGN WITH (NOLOCK) INNER JOIN
				BILL_APPR_BATCH_CMP WITH (NOLOCK) ON CAMPAIGN.CMP_IDENTIFIER = BILL_APPR_BATCH_CMP.CMP_IDENTIFIER
			WHERE     
				(CAMPAIGN.CMP_TYPE = 2)
				AND BILL_APPR_BATCH_CMP.BA_BATCH_ID = @BA_BATCH_ID;
		END	

		--GET PAGE SETTINGS (4)
		SELECT     
			AGY_SETTINGS_CODE, 
			CONVERT(BIT,COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF)) AS AGY_SETTINGS_VALUE, 
			AGY_SETTINGS_DESC
		FROM         
			AGY_SETTINGS WITH (NOLOCK)
		WHERE 
			AGY_SETTINGS.AGY_SETTINGS_CODE = 'BA_JOB_LIST_SECT';	
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO