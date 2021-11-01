

IF EXISTS
(
    SELECT *
    FROM dbo.sysobjects
    WHERE id = OBJECT_ID(N'[dbo].[usp_wv_ALERT_GET]')
          AND OBJECTPROPERTY(id, N'IsProcedure') = 1
)
    BEGIN
        DROP PROCEDURE [dbo].[usp_wv_ALERT_GET];
    END;
GO
CREATEPROCEDURE [dbo].[usp_wv_ALERT_GET] 

/*WITH ENCRYPTION*/

@ALERT_ID       INT,
@EMP_CODE       VARCHAR(6),
@CDP_CONTACT_ID INT,
@OFFSET         [DECIMAL](9, 3)
AS

/*=========== QUERY ===========*/
     BEGIN
         DECLARE @COMMENT_COUNT INT, @ATTACHMENT_COUNT INT, @IS_MY_ALERT_OPEN BIT, @IS_MY_ALERT_DISMISSED BIT, @IS_MY_ASSIGNMENT_OPEN BIT, @IS_MY_ASSIGNMENT_COMPLETED BIT, @READ_STATUS SMALLINT, @WAS_MARKED_READ BIT, @IS_ACTIVE TINYINT, @IS_ACTIVE_CP TINYINT;
         SET @IS_MY_ALERT_OPEN = 0;
         SET @IS_MY_ALERT_DISMISSED = 0;
         SET @IS_MY_ASSIGNMENT_OPEN = 0;
         SET @IS_MY_ASSIGNMENT_COMPLETED = 0;
         SET @WAS_MARKED_READ = 0;
	
	--GET COMMENT COUNT
         BEGIN
             SELECT @COMMENT_COUNT = COUNT(1)
             FROM ALERT_COMMENT WITH (NOLOCK)
             WHERE(ALERT_COMMENT.ALERT_ID = @ALERT_ID);
         END;
	--GET ATTACHMENT COUNT
         BEGIN
             SELECT @ATTACHMENT_COUNT = COUNT(1)
             FROM ALERT_ATTACHMENT WITH (NOLOCK)
             WHERE(ALERT_ATTACHMENT.ALERT_ID = @ALERT_ID);
         END;
	--CHECK STATUS RELATING TO EMPLOYEE/CLIENT
         BEGIN
             IF @CDP_CONTACT_ID IS NULL
                OR @CDP_CONTACT_ID = 0
                 BEGIN
                     IF EXISTS
(
    SELECT 1
    FROM ALERT_RCPT AS AR WITH (NOLOCK)
    WHERE AR.ALERT_ID = @ALERT_ID
          AND AR.EMP_CODE = @EMP_CODE
          AND (AR.CURRENT_NOTIFY = 0
               OR AR.CURRENT_NOTIFY IS NULL)
)
                         BEGIN
                             SET @IS_MY_ALERT_OPEN = 1;
                         END;
                     IF @IS_MY_ALERT_OPEN = 0
                         BEGIN
                             IF EXISTS
(
    SELECT 1
    FROM ALERT_RCPT_DISMISSED AS AR WITH (NOLOCK)
    WHERE AR.ALERT_ID = @ALERT_ID
          AND AR.EMP_CODE = @EMP_CODE
          AND (AR.CURRENT_NOTIFY = 0
               OR AR.CURRENT_NOTIFY IS NULL)
)
                                 BEGIN
                                     SET @IS_MY_ALERT_DISMISSED = 1;
                                 END;
                         END;
                     IF EXISTS
(
    SELECT 1
    FROM ALERT_RCPT AS AR WITH (NOLOCK)
    WHERE AR.ALERT_ID = @ALERT_ID
          AND AR.EMP_CODE = @EMP_CODE
          AND (AR.CURRENT_NOTIFY = 1)
)
                         BEGIN
                             SET @IS_MY_ASSIGNMENT_OPEN = 1;
                         END;
                     IF @IS_MY_ASSIGNMENT_OPEN = 0
                         BEGIN
                             IF EXISTS
(
    SELECT 1
    FROM ALERT_RCPT_DISMISSED AS AR WITH (NOLOCK)
    WHERE AR.ALERT_ID = @ALERT_ID
          AND (AR.CURRENT_NOTIFY = 1)
) -- REMOVE EMP CODE TO ALLOW ALL
                                 BEGIN
                                     SET @IS_MY_ASSIGNMENT_COMPLETED = 1;
                                 END;
                         END;
                     IF @IS_MY_ALERT_OPEN = 1
                        OR @IS_MY_ASSIGNMENT_OPEN = 1
                         BEGIN
                             SELECT @READ_STATUS = COUNT(*)
                             FROM ALERT_RCPT AS AR WITH (NOLOCK)
                             WHERE AR.ALERT_ID = @ALERT_ID
                                   AND AR.EMP_CODE = @EMP_CODE
                                   AND ISNULL(AR.READ_ALERT, 0) = 0;
                             IF @READ_STATUS >= 1
                                 BEGIN
                                     UPDATE ALERT_RCPT WITH(ROWLOCK)
                                       SET
                                           READ_ALERT = 1
                                     WHERE ALERT_ID = @ALERT_ID
                                           AND EMP_CODE = @EMP_CODE;
                                     SET @WAS_MARKED_READ = 1;
                                 END;
                         END;
                     IF @IS_MY_ALERT_DISMISSED = 1
                        OR @IS_MY_ASSIGNMENT_COMPLETED = 1
                         BEGIN
                             SELECT @READ_STATUS = COUNT(*)
                             FROM ALERT_RCPT_DISMISSED AS AR WITH (NOLOCK)
                             WHERE AR.ALERT_ID = @ALERT_ID
                                   AND AR.EMP_CODE = @EMP_CODE
                                   AND ISNULL(AR.READ_ALERT, 0) = 0;
                             IF @READ_STATUS >= 1
                                 BEGIN
                                     UPDATE ALERT_RCPT_DISMISSED WITH(ROWLOCK)
                                       SET
                                           READ_ALERT = 1
                                     WHERE ALERT_ID = @ALERT_ID
                                           AND EMP_CODE = @EMP_CODE;
                                     SET @WAS_MARKED_READ = 1;
                                 END;
                         END;
                 END;
                 ELSE
                 BEGIN
                     IF EXISTS
(
    SELECT 1
    FROM CP_ALERT_RCPT AS AR WITH (NOLOCK)
    WHERE AR.ALERT_ID = @ALERT_ID
          AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID
          AND (AR.CURRENT_NOTIFY = 0
               OR AR.CURRENT_NOTIFY IS NULL)
)
                         BEGIN
                             SET @IS_MY_ALERT_OPEN = 1;
                         END;
                     IF @IS_MY_ALERT_OPEN = 0
                         BEGIN
                             IF EXISTS
(
    SELECT 1
    FROM CP_ALERT_RCPT_DISMISSED AS AR WITH (NOLOCK)
    WHERE AR.ALERT_ID = @ALERT_ID
          AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID
          AND (AR.CURRENT_NOTIFY = 0
               OR AR.CURRENT_NOTIFY IS NULL)
)
                                 BEGIN
                                     SET @IS_MY_ALERT_DISMISSED = 1;
                                 END;
                         END;
                     IF @IS_MY_ALERT_OPEN = 1
                         BEGIN
                             SELECT @READ_STATUS = READ_ALERT
                             FROM CP_ALERT_RCPT AS AR WITH (NOLOCK)
                             WHERE AR.ALERT_ID = @ALERT_ID
                                   AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID;
                             IF @READ_STATUS IS NULL
                                OR @READ_STATUS = 0
                                 BEGIN
                                     UPDATE CP_ALERT_RCPT WITH(ROWLOCK)
                                       SET
                                           READ_ALERT = 1
                                     WHERE ALERT_ID = @ALERT_ID
                                           AND CDP_CONTACT_ID = @CDP_CONTACT_ID;
                                     SET @WAS_MARKED_READ = 1;
                                 END;
                         END;
                     IF @IS_MY_ALERT_DISMISSED = 1
                         BEGIN
                             SELECT @READ_STATUS = READ_ALERT
                             FROM CP_ALERT_RCPT_DISMISSED AS AR WITH (NOLOCK)
                             WHERE AR.ALERT_ID = @ALERT_ID
                                   AND AR.CDP_CONTACT_ID = @CDP_CONTACT_ID;
                             IF @READ_STATUS IS NULL
                                OR @READ_STATUS = 0
                                 BEGIN
                                     UPDATE CP_ALERT_RCPT_DISMISSED WITH(ROWLOCK)
                                       SET
                                           READ_ALERT = 1
                                     WHERE ALERT_ID = @ALERT_ID
                                           AND CDP_CONTACT_ID = @CDP_CONTACT_ID;
                                     SET @WAS_MARKED_READ = 1;
                                 END;
                         END;
                 END;
         END;

	--GET THE ALERT
         BEGIN
             SELECT TOP (1) ALERT.ALERT_ID,
                            ALERT.ALERT_LEVEL,
                            CASE
                                WHEN ALERT_LEVEL = 'OF'
                                THEN 'Office'
                                WHEN ALERT_LEVEL = 'CL'
                                THEN 'Client'
                                WHEN ALERT_LEVEL = 'DI'
                                THEN 'Division'
                                WHEN ALERT_LEVEL = 'PR'
                                THEN 'Product'
                                WHEN ALERT_LEVEL = 'CM'
                                THEN 'Campaign'
                                WHEN ALERT_LEVEL = 'JO'
                                THEN 'Job'
                                WHEN(ALERT_LEVEL = 'JJ'
                                     OR ALERT_LEVEL = 'JC')
                                THEN 'Job Component'
                                WHEN ALERT_LEVEL = 'PS'
                                THEN 'Project Schedule'
                                WHEN ALERT_LEVEL = 'PST'
                                THEN 'Project Schedule Task'
                                WHEN ALERT_LEVEL = 'ES'
                                THEN 'Estimate'
                                WHEN ALERT_LEVEL = 'EST'
                                THEN 'Estimate Component'
                                WHEN ALERT_LEVEL = 'AB'
                                THEN 'Authorization to Buy'
                                ELSE ''
                            END AS ALERT_LEVEL_DISPLAY,
                            ALERT.ALERT_TYPE_ID,
                            ALERT_TYPE.ALERT_TYPE_DESC,
                            CASE @OFFSET
                                WHEN 0
                                THEN ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)
                                ELSE ISNULL(DATEADD(mi, (CONVERT(INT, @OFFSET) * 60) + (@OFFSET - CONVERT(INT, @OFFSET)), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED))
                            END AS GENERATED,
                            CASE @OFFSET
                                WHEN 0
                                THEN ALERT.GENERATED
                                ELSE ISNULL(DATEADD(mi, (CONVERT(INT, @OFFSET) * 60) + (@OFFSET - CONVERT(INT, @OFFSET)), ALERT.GENERATED), ALERT.GENERATED)
                            END AS ORIGINATED_DATE,
                            ALERT.CP_ALERT,
                            CASE
                                WHEN((ALERT.EMP_CODE IS NULL))
                                    AND (ALERT.ALERT_USER_CP IS NOT NULL)
                                THEN
(
    SELECT CONT_FML
    FROM CDP_CONTACT_HDR WITH (NOLOCK)
    WHERE CDP_CONTACT_ID = CAST(ALERT.ALERT_USER AS INT)
)
                                ELSE SEC_USER.[USER_NAME]
                            END AS USER_NAME,
                            ALERT.ALERT_USER,
                            ALERT.EMP_CODE,
                            ALERT.OFFICE_CODE,
                            OFFICE.OFFICE_NAME,
                            ALERT.OFFICE_CODE+' - '+OFFICE.OFFICE_NAME AS OFFICE_DISPLAY,
                            ALERT.CL_CODE,
                            CLIENT.CL_NAME,
                            ALERT.CL_CODE+' - '+CLIENT.CL_NAME AS CLIENT_DISPLAY,
                            ALERT.DIV_CODE,
                            DIVISION.DIV_NAME,
                            ALERT.DIV_CODE+' - '+DIVISION.DIV_NAME AS DIVISION_DISPLAY,
                            ALERT.PRD_CODE,
                            PRODUCT.PRD_DESCRIPTION,
                            ALERT.PRD_CODE+' - '+PRODUCT.PRD_DESCRIPTION AS PRODUCT_DISPLAY,
                            ALERT.CMP_IDENTIFIER,
                            CAMPAIGN.CMP_CODE,
                            CAMPAIGN.CMP_NAME,
                            CAMPAIGN.CMP_CODE+' - '+CAMPAIGN.CMP_NAME AS CAMPAIGN_DISPLAY,
                            ALERT.JOB_NUMBER,
                            JOB_LOG.JOB_DESC,
                            RIGHT(REPLICATE('0', 6)+CONVERT(VARCHAR(20), ALERT.JOB_NUMBER), 6)+' - '+JOB_LOG.JOB_DESC AS JOB_DISPLAY,
                            ALERT.JOB_COMPONENT_NBR,
                            JOB_COMPONENT.JOB_COMP_DESC,
                            RIGHT(REPLICATE('0', 3)+CONVERT(VARCHAR(20), ALERT.JOB_COMPONENT_NBR), 3)+' - '+JOB_COMPONENT.JOB_COMP_DESC AS JOB_COMPONENT_DISPLAY,
                            CASE
                                WHEN JOB_TRAFFIC_DET.FNC_CODE IS NULL
                                THEN JOB_TRAFFIC_DET.TASK_DESCRIPTION
                                ELSE JOB_TRAFFIC_DET.FNC_CODE+' - '+TRAFFIC_FNC.TRF_DESC
                            END AS TASK_FUNCTION_DISPLAY,
                            ALERT.ESTIMATE_NUMBER,
                            ESTIMATE_LOG.EST_LOG_DESC,
                            RIGHT(REPLICATE('0', 6)+CONVERT(VARCHAR(20), ALERT.ESTIMATE_NUMBER), 6)+' - '+ESTIMATE_LOG.EST_LOG_DESC AS ESTIMATE_DISPLAY,
                            ALERT.EST_COMPONENT_NBR,
                            ESTIMATE_COMPONENT.EST_COMP_DESC,
                            RIGHT(REPLICATE('0', 2)+CONVERT(VARCHAR(20), ALERT.EST_COMPONENT_NBR), 2)+' - '+ESTIMATE_COMPONENT.EST_COMP_DESC AS ESTIMATE_COMPONENT_DISPLAY,
                            ALERT.ALERT_CAT_ID,
                            ALERT_CATEGORY.ALERT_DESC AS CATEGORY_DISPLAY,
                            ISNULL(ALERT.PRIORITY, 2) AS PRIORITY,
                            CASE
                                WHEN ALERT.PRIORITY = 1
                                THEN 'Highest'
                                WHEN ALERT.PRIORITY = 2
                                THEN 'High'
                                WHEN ALERT.PRIORITY = 3
                                THEN 'Normal'
                                WHEN ALERT.PRIORITY = 4
                                THEN 'Low'
                                WHEN ALERT.PRIORITY = 5
                                THEN 'Lowest'
                                ELSE 'Normal'
                            END AS PRIORITY_DISPLAY,
                            ALERT.[START_DATE],
                            ALERT.DUE_DATE,
                            ALERT.TIME_DUE,
                            ALERT.SUBJECT,
                            ALERT.BODY,
                            ALERT.BODY_HTML,
                            ALERT.ALRT_NOTIFY_HDR_ID,
                            ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,
                            ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME AS ALERT_NOTIFY_HDR_DISPLAY,
                            ALERT.ALERT_STATE_ID,
                            ALERT_STATES.ALERT_STATE_NAME,
                            ALERT_STATES.ALERT_STATE_NAME AS ALERT_STATE_DISPLAY,
                            ALERT.ALERT_SEQ_NBR,
                            COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) AS ID,
                            CASE
                                WHEN(ALERT.ALRT_NOTIFY_HDR_ID > 0)
                                    AND (ALERT.ALERT_STATE_ID > 0)
                                THEN 1
                                ELSE 0
                            END AS IS_ALERT_ASSIGNMENT,
                            ISNULL(@COMMENT_COUNT, 0) AS COMMENT_COUNT,
                            ALERT.VER,
                            ALERT.BUILD,
                            ISNULL(@ATTACHMENT_COUNT, 0) AS ATTACHMENT_COUNT,
                            SOFTWARE_VERSION.VERSION AS VERSION_DISPLAY,
                            SOFTWARE_BUILD.BUILD AS BUILD_DISPLAY,
                            ALERT.TASK_SEQ_NBR,
                            ALERT.AP_ID,
                            ALERT.AP_SEQ,
                            ISNULL(@IS_MY_ALERT_OPEN, 0) AS IS_MY_ALERT_OPEN,
                            ISNULL(@IS_MY_ALERT_DISMISSED, 0) AS IS_MY_ALERT_DISMISSED,
                            ISNULL(@IS_MY_ASSIGNMENT_OPEN, 0) AS IS_MY_ASSIGNMENT_OPEN,
                            ISNULL(@IS_MY_ASSIGNMENT_COMPLETED, 0) AS IS_MY_ASSIGNMENT_COMPLETED,
                            ALERT.ATB_REV_ID,
                            ATB_REV.ATB_NUMBER,
                            [ATB_REV_NBR] = ATB_REV.REV_NBR,
                            [ATB_DISPLAY] = RIGHT(REPLICATE('0', 6)+CONVERT(VARCHAR(20), ATB_REV.ATB_NUMBER), 6)+' - '+RIGHT(REPLICATE('0', 3)+CONVERT(VARCHAR(20), ATB_REV.REV_NBR), 3)+' '+ATB_REV.ATB_DESCRIPTION,
                            ISNULL(@WAS_MARKED_READ, 0) AS WAS_MARKED_READ,
                            CASE
                                WHEN(NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL
                                     AND ALERT.ALRT_NOTIFY_HDR_ID > 0)
                                    AND (NOT ALERT.ALERT_STATE_ID IS NULL
                                         AND ALERT.ALERT_STATE_ID > 0)
                                THEN CAST(1 AS BIT)
                                ELSE CAST(0 AS BIT)
                            END AS IS_ROUTED_ASSIGNMENT,
                            ALERT.ASSIGNED_EMP_CODE,
                            ALERT.LAST_ASSIGNED_EMP_CODE,
                            CAST(ISNULL(ALERT.ASSIGN_COMPLETED, 0) AS BIT) AS ASSIGN_COMPLETED,
                            CAST(ISNULL(ALERT.IS_WORK_ITEM, 0) AS BIT) AS IS_WORK_ITEM
             FROM CLIENT WITH (NOLOCK)
                  RIGHT OUTER JOIN TRAFFIC_FNC WITH (NOLOCK)
                  LEFT OUTER JOIN JOB_TRAFFIC_DET WITH (NOLOCK) ON TRAFFIC_FNC.TRF_CODE = JOB_TRAFFIC_DET.FNC_CODE
                  RIGHT OUTER JOIN ESTIMATE_LOG WITH (NOLOCK)
                  RIGHT OUTER JOIN ALERT_NOTIFY_HDR WITH (NOLOCK)
                  RIGHT OUTER JOIN SEC_USER WITH (NOLOCK)
                  RIGHT OUTER JOIN SOFTWARE_VERSION
                  RIGHT OUTER JOIN SOFTWARE_BUILD
                  RIGHT OUTER JOIN ALERT WITH (NOLOCK)
                  INNER JOIN ALERT_TYPE WITH (NOLOCK) ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID
                  INNER JOIN ALERT_CATEGORY WITH (NOLOCK) ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID ON SOFTWARE_BUILD.VERSION_ID = ALERT.VER
                                                                                                                 AND SOFTWARE_BUILD.BUILD_ID = ALERT.BUILD ON SOFTWARE_VERSION.VERSION_ID = ALERT.VER ON SEC_USER.EMP_CODE = ALERT.EMP_CODE
                  LEFT OUTER JOIN ALERT_STATES WITH (NOLOCK) ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID ON ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID = ALERT.ALRT_NOTIFY_HDR_ID
                  LEFT OUTER JOIN ESTIMATE_COMPONENT WITH (NOLOCK) ON ALERT.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER
                                                                      AND ALERT.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR ON ESTIMATE_LOG.ESTIMATE_NUMBER = ALERT.ESTIMATE_NUMBER ON JOB_TRAFFIC_DET.SEQ_NBR = ALERT.TASK_SEQ_NBR
                                                                                                                                                                                                    AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = ALERT.JOB_COMPONENT_NBR
                                                                                                                                                                                                    AND JOB_TRAFFIC_DET.JOB_NUMBER = ALERT.JOB_NUMBER
                  LEFT OUTER JOIN JOB_COMPONENT WITH (NOLOCK) ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
                                                                 AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
                  LEFT OUTER JOIN PRODUCT WITH (NOLOCK) ON ALERT.CL_CODE = PRODUCT.CL_CODE
                                                           AND ALERT.DIV_CODE = PRODUCT.DIV_CODE
                                                           AND ALERT.PRD_CODE = PRODUCT.PRD_CODE
                  LEFT OUTER JOIN JOB_LOG WITH (NOLOCK) ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
                  LEFT OUTER JOIN CAMPAIGN WITH (NOLOCK) ON ALERT.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER
                  LEFT OUTER JOIN OFFICE WITH (NOLOCK) ON ALERT.OFFICE_CODE = OFFICE.OFFICE_CODE
                  LEFT OUTER JOIN DIVISION WITH (NOLOCK) ON ALERT.CL_CODE = DIVISION.CL_CODE
                                                            AND ALERT.DIV_CODE = DIVISION.DIV_CODE ON CLIENT.CL_CODE = ALERT.CL_CODE
                  LEFT OUTER JOIN ATB_REV WITH (NOLOCK) ON ALERT.ATB_REV_ID = ATB_REV.ATB_REV_ID
             WHERE(ALERT.ALERT_ID = @ALERT_ID);
         END;

	--GET THE COMMENTS
         BEGIN
             EXEC [dbo].[advsp_alert_load_comments]
                  @ALERT_ID,
				  0,
                  @EMP_CODE,
                  @OFFSET,
                  NULL;
         END;

	--GET THE ASSIGNMENT
         BEGIN
             SELECT ALERT.ALERT_ID,
                    ALERT.ALRT_NOTIFY_HDR_ID,
                    ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,
                    ALERT.ALERT_STATE_ID,
                    ALERT_STATES.ALERT_STATE_NAME,
                    ALERT_RCPT.EMP_CODE,
                    ISNULL(EMPLOYEE.EMP_FNAME+' ', '')+ISNULL(EMPLOYEE.EMP_MI+'. ', '')+ISNULL(EMPLOYEE.EMP_LNAME, '') AS ASSIGN_EMP_FML,
                    ALERT_RCPT.CURRENT_NOTIFY,
                    ALERT_RCPT.PROCESSED
             FROM ALERT WITH (NOLOCK)
                  INNER JOIN ALERT_NOTIFY_HDR WITH (NOLOCK) ON ALERT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID
                  INNER JOIN ALERT_RCPT WITH (NOLOCK) ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
                  INNER JOIN EMPLOYEE WITH (NOLOCK) ON ALERT_RCPT.EMP_CODE = EMPLOYEE.EMP_CODE
                  INNER JOIN ALERT_STATES WITH (NOLOCK) ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID
             WHERE(ALERT_RCPT.CURRENT_NOTIFY = 1)
                  AND (ALERT.ALERT_ID = @ALERT_ID)
             UNION
             SELECT ALERT.ALERT_ID,
                    ALERT.ALRT_NOTIFY_HDR_ID,
                    ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,
                    ALERT.ALERT_STATE_ID,
                    ALERT_STATES.ALERT_STATE_NAME,
                    ALERT_RCPT_DISMISSED.EMP_CODE,
                    ISNULL(EMPLOYEE.EMP_FNAME+' ', '')+ISNULL(EMPLOYEE.EMP_MI+'. ', '')+ISNULL(EMPLOYEE.EMP_LNAME, '') AS ASSIGN_EMP_FML,
                    ALERT_RCPT_DISMISSED.CURRENT_NOTIFY,
                    ALERT_RCPT_DISMISSED.PROCESSED
             FROM ALERT WITH (NOLOCK)
                  INNER JOIN ALERT_NOTIFY_HDR WITH (NOLOCK) ON ALERT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID
                  INNER JOIN ALERT_RCPT_DISMISSED WITH (NOLOCK) ON ALERT.ALERT_ID = ALERT_RCPT_DISMISSED.ALERT_ID
                  INNER JOIN EMPLOYEE WITH (NOLOCK) ON ALERT_RCPT_DISMISSED.EMP_CODE = EMPLOYEE.EMP_CODE
                  INNER JOIN ALERT_STATES WITH (NOLOCK) ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID
             WHERE(ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 1)
                  AND (ALERT.ALERT_ID = @ALERT_ID);
         END;
         IF @CDP_CONTACT_ID IS NULL
            OR @CDP_CONTACT_ID = 0
             BEGIN
                 SELECT @IS_ACTIVE = ISNULL(COUNT(1), 0)
                 FROM ALERT_RCPT
                 WHERE ALERT_ID = @ALERT_ID
                       AND EMP_CODE = @EMP_CODE;
                 IF @IS_ACTIVE > 0
                     BEGIN
                         SELECT ALERT.ALERT_ID,
                                ALERT_RCPT.EMP_CODE,
                                ISNULL(EMPLOYEE.EMP_FNAME+' ', '')+ISNULL(EMPLOYEE.EMP_MI+'. ', '')+ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML,
                                ALERT_RCPT.CURRENT_NOTIFY,
                                ALERT_RCPT.PROCESSED,
                                ALERT_RCPT.NEW_ALERT,
                                ALERT_RCPT.READ_ALERT
                         FROM ALERT WITH (NOLOCK)
                              INNER JOIN ALERT_RCPT WITH (NOLOCK) ON ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID
                              INNER JOIN EMPLOYEE WITH (NOLOCK) ON ALERT_RCPT.EMP_CODE = EMPLOYEE.EMP_CODE
                         WHERE((ALERT_RCPT.CURRENT_NOTIFY = 0)
                               OR (ALERT_RCPT.CURRENT_NOTIFY IS NULL))
                              AND (ALERT.ALERT_ID = @ALERT_ID)
                              AND ALERT_RCPT.EMP_CODE = @EMP_CODE;
                     END;
                 IF @IS_ACTIVE = 0
                     BEGIN
                         SELECT ALERT.ALERT_ID,
                                ALERT_RCPT_DISMISSED.EMP_CODE,
                                ISNULL(EMPLOYEE.EMP_FNAME+' ', '')+ISNULL(EMPLOYEE.EMP_MI+'. ', '')+ISNULL(EMPLOYEE.EMP_LNAME, '') AS EMP_FML,
                                ALERT_RCPT_DISMISSED.CURRENT_NOTIFY,
                                ALERT_RCPT_DISMISSED.PROCESSED,
                                ALERT_RCPT_DISMISSED.NEW_ALERT,
                                ALERT_RCPT_DISMISSED.READ_ALERT
                         FROM ALERT WITH (NOLOCK)
                              INNER JOIN ALERT_RCPT_DISMISSED WITH (NOLOCK) ON ALERT.ALERT_ID = ALERT_RCPT_DISMISSED.ALERT_ID
                              INNER JOIN EMPLOYEE WITH (NOLOCK) ON ALERT_RCPT_DISMISSED.EMP_CODE = EMPLOYEE.EMP_CODE
                         WHERE((ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 0)
                               OR (ALERT_RCPT_DISMISSED.CURRENT_NOTIFY IS NULL))
                              AND (ALERT.ALERT_ID = @ALERT_ID)
                              AND ALERT_RCPT_DISMISSED.EMP_CODE = @EMP_CODE;
                     END;
             END;
             ELSE
             BEGIN
                 SELECT @IS_ACTIVE_CP = ISNULL(COUNT(1), 0)
                 FROM CP_ALERT_RCPT
                 WHERE ALERT_ID = @ALERT_ID
                       AND CDP_CONTACT_ID = @CDP_CONTACT_ID;
                 IF @IS_ACTIVE_CP > 0
                     BEGIN
                         SELECT ALERT.ALERT_ID,
                                CP_ALERT_RCPT.CDP_CONTACT_ID AS EMP_CODE,
                                CDP_CONTACT_HDR.CONT_FML AS EMP_FML,
                                CP_ALERT_RCPT.CURRENT_NOTIFY,
                                CP_ALERT_RCPT.PROCESSED,
                                CP_ALERT_RCPT.NEW_ALERT,
                                CP_ALERT_RCPT.READ_ALERT
                         FROM ALERT WITH (NOLOCK)
                              INNER JOIN CP_ALERT_RCPT WITH (NOLOCK) ON ALERT.ALERT_ID = CP_ALERT_RCPT.ALERT_ID
                              INNER JOIN CDP_CONTACT_HDR WITH (NOLOCK) ON CP_ALERT_RCPT.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
                         WHERE((CP_ALERT_RCPT.CURRENT_NOTIFY = 0)
                               OR (CP_ALERT_RCPT.CURRENT_NOTIFY IS NULL))
                              AND (ALERT.ALERT_ID = @ALERT_ID)
                              AND CP_ALERT_RCPT.CDP_CONTACT_ID = @CDP_CONTACT_ID;
                         UPDATE CP_ALERT_RCPT WITH(ROWLOCK)
                           SET
                               READ_ALERT = 1
                         WHERE ALERT_ID = @ALERT_ID
                               AND CDP_CONTACT_ID = @CDP_CONTACT_ID;
                     END;
                 IF @IS_ACTIVE_CP = 0
                     BEGIN
                         SELECT ALERT.ALERT_ID,
                                CP_ALERT_RCPT_DISMISSED.CDP_CONTACT_ID AS EMP_CODE,
                                CDP_CONTACT_HDR.CONT_FML AS EMP_FML,
                                CP_ALERT_RCPT_DISMISSED.CURRENT_NOTIFY,
                                CP_ALERT_RCPT_DISMISSED.PROCESSED,
                                CP_ALERT_RCPT_DISMISSED.NEW_ALERT,
                                CP_ALERT_RCPT_DISMISSED.READ_ALERT
                         FROM ALERT WITH (NOLOCK)
                              INNER JOIN CP_ALERT_RCPT_DISMISSED WITH (NOLOCK) ON ALERT.ALERT_ID = CP_ALERT_RCPT_DISMISSED.ALERT_ID
                              INNER JOIN CDP_CONTACT_HDR WITH (NOLOCK) ON CP_ALERT_RCPT_DISMISSED.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID
                         WHERE((CP_ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 0)
                               OR (CP_ALERT_RCPT_DISMISSED.CURRENT_NOTIFY IS NULL))
                              AND (ALERT.ALERT_ID = @ALERT_ID)
                              AND CP_ALERT_RCPT_DISMISSED.CDP_CONTACT_ID = @CDP_CONTACT_ID;
                         UPDATE CP_ALERT_RCPT_DISMISSED WITH(ROWLOCK)
                           SET
                               READ_ALERT = 1
                         WHERE ALERT_ID = @ALERT_ID
                               AND CDP_CONTACT_ID = @CDP_CONTACT_ID;
                     END;
             END;

	--GET RECIPIENTS
         BEGIN
             EXEC usp_wv_ALERT_GET_RECIPIENTS
                  @ALERT_ID;
         END;

	--GET ATTACHMENT LIST
         BEGIN
             EXEC usp_wv_ALERT_GET_ATTACHMENTS
                  @ALERT_ID,
                  @EMP_CODE,
                  @OFFSET;
         END;
     END;
/*=========== QUERY ===========*/