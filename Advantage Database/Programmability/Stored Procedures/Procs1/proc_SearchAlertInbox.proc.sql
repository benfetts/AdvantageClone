
CREATE PROCEDURE [dbo].[proc_SearchAlertInbox]
@SearchCriteria VARCHAR(100), 
@EmpCode VARCHAR(6)

AS


		IF ISNUMERIC(@SearchCriteria) = 0
		BEGIN
			SELECT ALERT_ID,
				   SUBJECT,
				   GENERATED,
				   PROCESSED,
				   [USER_NAME],
				   EMP_CODE,
				   PRIORITY,
				   TYPE,
				   CATEGORY,
				   ALERT_TYPE_ID,
				   ALERT_CAT_ID,
				   ATTACHMENTCOUNT,
				   ALERT_LEVEL,
				   OFFICE_CODE,
				   CL_CODE,
				   DIV_CODE,
				   PRD_CODE,
				   CMP_CODE,
				   JOB_NUMBER,
				   JOB_COMPONENT_NBR,
				   SENDER_EMP_CODE,
				   DISMISSED_DATE,
				   CL_NAME,
				   DIV_NAME,
				   PRD_DESCRIPTION,
				   CMP_NAME,
				   BODY,
				   LOWER_SUBJECT,
				   LOWER_BODY,
				   OFFICE_NAME,
				   JOB_DESC,
				   JOB_COMP_DESC,
				   ID,
				   GRP_OFFICE,
				   GRP_CLIENT,
				   GRP_DIVISION,
				   GRP_PRODUCT,
				   GRP_JOB,
				   GRP_COMPONENT,
				   GRP_ESTIMATE,
				   GRP_ESTIMATE_COMPONENT,
				   GRP_TASK,
				   GRP_CAMPAIGN,
				   GRP_PRIORITY,
				   GRP_DUE_DATE,
				   GRP_DUE_DATE_DISPLAY,
				   CMP_IDENTIFIER,
				   TASK_SEQ_NBR,
				   ALERT_STATE_NAME
			FROM   WV_MYALERTSLIST WITH(NOLOCK)
			WHERE  (
					   (LOWER_SUBJECT LIKE '%' + LOWER(@SearchCriteria) + '%')
					   OR (LOWER(USER_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%')
					   OR LOWER_BODY LIKE '%' + LOWER(@SearchCriteria)
					   OR (CAST(ID AS VARCHAR) = @SearchCriteria)
				   )
				   AND (EMP_CODE = @EmpCode);
		END

		IF ISNUMERIC(@SearchCriteria) = 1
		BEGIN
			SELECT ALERT_ID,
				   SUBJECT,
				   GENERATED,
				   PROCESSED,
				   [USER_NAME],
				   EMP_CODE,
				   PRIORITY,
				   TYPE,
				   CATEGORY,
				   ALERT_TYPE_ID,
				   ALERT_CAT_ID,
				   ATTACHMENTCOUNT,
				   ALERT_LEVEL,
				   OFFICE_CODE,
				   CL_CODE,
				   DIV_CODE,
				   PRD_CODE,
				   CMP_CODE,
				   JOB_NUMBER,
				   JOB_COMPONENT_NBR,
				   SENDER_EMP_CODE,
				   DISMISSED_DATE,
				   CL_NAME,
				   DIV_NAME,
				   PRD_DESCRIPTION,
				   CMP_NAME,
				   BODY,
				   LOWER_SUBJECT,
				   LOWER_BODY,
				   OFFICE_NAME,
				   JOB_DESC,
				   JOB_COMP_DESC,
				   ID,
				   GRP_OFFICE,
				   GRP_CLIENT,
				   GRP_DIVISION,
				   GRP_PRODUCT,
				   GRP_JOB,
				   GRP_COMPONENT,
				   GRP_ESTIMATE,
				   GRP_ESTIMATE_COMPONENT,
				   GRP_TASK,
				   GRP_CAMPAIGN,
				   GRP_PRIORITY,
				   GRP_DUE_DATE,
				   GRP_DUE_DATE_DISPLAY,
				   CMP_IDENTIFIER,
				   TASK_SEQ_NBR,
				   ALERT_STATE_NAME
			FROM   WV_MYALERTSLIST WITH(NOLOCK)
			WHERE  (
					   (LOWER_SUBJECT LIKE '%' + LOWER(@SearchCriteria) + '%')
					   OR (LOWER(USER_NAME) LIKE '%' + LOWER(@SearchCriteria) + '%')
					   OR LOWER_BODY LIKE '%' + LOWER(@SearchCriteria)
					   OR (CAST(ID AS VARCHAR) = @SearchCriteria)
					   OR (JOB_NUMBER = CAST(@SearchCriteria AS INTEGER))
					   OR (ID = CAST(@SearchCriteria AS INTEGER))
				   )
				   AND (EMP_CODE = @EmpCode);
		END



