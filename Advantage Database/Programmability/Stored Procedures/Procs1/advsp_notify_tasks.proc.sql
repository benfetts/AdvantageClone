
CREATE PROCEDURE [dbo].[advsp_notify_tasks]
	@overdue_tasks			bit,												-- 0 = upcoming tasks, 1 = overdue tasks
	@upcoming_start			integer=0,											-- Min number of days before upcoming task is due (0-4)
	@upcoming_end			integer=1											-- Max number of days before upcoming task is due(0-4)
AS

SET NOCOUNT ON

DECLARE @sql varchar(4000)
DECLARE @sql_select varchar(1000)
DECLARE @sql_from varchar(1000)
DECLARE @sql_where varchar(1000)
DECLARE @sql_orderby varchar(1000)

SET @sql_where = 'WHERE (JC.JOB_PROCESS_CONTRL NOT IN (6,12)) AND (JT.COMPLETED_DATE IS NULL) AND (JTD.JOB_COMPLETED_DATE IS NULL)'

IF ( @overdue_tasks = 1 )
	BEGIN
		SET @sql_where = @sql_where + ' AND ((DATEDIFF(d, GETDATE(), JTD.JOB_REVISED_DATE)) < 0) '	
	END
ELSE
	BEGIN
		SET @sql_where = @sql_where + ' AND ((DATEDIFF(d, GETDATE(), JTD.JOB_REVISED_DATE)) >= ' + CONVERT(NVARCHAR, @upcoming_start) + ')'
		SET @sql_where = @sql_where + ' AND ((DATEDIFF(d, GETDATE(), JTD.JOB_REVISED_DATE)) <= ' + CONVERT(NVARCHAR, @upcoming_end)   + ') '
	END

SET @sql_select = 'SELECT EC.EMP_CODE, ' +											-- varchar(6), not null
				  'EC.SUPERVISOR_CODE, ' +											-- varchar(6), null
				  'EC.ALERT_EMAIL AS ALERT_EMAIL, ' +								-- smallint, null
                  'EC.EMP_EMAIL AS EMAIL, ' +										-- varchar(50), null
				  'C.CL_NAME AS CLIENT_NAME, ' +									-- varchar(40), null
				  'JC.JOB_NUMBER, ' +												-- integer, not null
				  'JC.JOB_COMPONENT_NBR AS COMPONENT_NUMBER, ' +					-- smallint, not null
				  'JL.JOB_DESC, ' +													-- varchar(60), null
				  'JC.JOB_COMP_DESC AS COMPONENT_DESC, ' +							-- varchar(60), not null
				  'JTD.TASK_DESCRIPTION AS TASK_DESC, ' +							-- varchar(40), null
				  'JTD.TASK_START_DATE AS START_DATE, ' +							-- smalldatetime, null
				  'JTD.JOB_REVISED_DATE AS DUE_DATE, ' +							-- smalldatetime, null
				  'JTDE.HOURS_ALLOWED, ' +											-- decimal(8,2), null
				  '[COMMENT] = JTD.FNC_COMMENTS, ' +								-- text, null
				  '(DATEDIFF(d, GETDATE(), JTD.JOB_REVISED_DATE)) AS DATE_DIFF '	-- integer, null

SET @sql_from = 'FROM [dbo].[JOB_COMPONENT] JC ' +
				'JOIN [dbo].[JOB_LOG] JL ON JC.JOB_NUMBER = JL.JOB_NUMBER ' +
				'JOIN [dbo].[JOB_TRAFFIC] JT ON JC.JOB_NUMBER = JT.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR ' +
				'JOIN [dbo].[JOB_TRAFFIC_DET] JTD ON JC.JOB_NUMBER = JTD.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR ' +
				'JOIN [dbo].[JOB_TRAFFIC_DET_EMPS] JTDE ON JC.JOB_NUMBER = JTDE.JOB_NUMBER AND JC.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = JTDE.SEQ_NBR ' +
				'JOIN [dbo].[CLIENT] C ON JL.CL_CODE = C.CL_CODE ' +
				'JOIN [dbo].[EMPLOYEE] EC ON JTDE.EMP_CODE = EC.EMP_CODE '

SET @sql_orderby = 'ORDER BY JTDE.EMP_CODE, ' +
				   'C.CL_NAME, ' +
				   'JC.JOB_NUMBER, ' +
				   'JC.JOB_COMPONENT_NBR, ' +
				   'JL.JOB_DESC, ' +
				   'JC.JOB_COMP_DESC, ' +
				   'JTD.TASK_DESCRIPTION '

SET @sql = @sql_select + @sql_from + @sql_where + @sql_orderby

EXECUTE ( @sql )
