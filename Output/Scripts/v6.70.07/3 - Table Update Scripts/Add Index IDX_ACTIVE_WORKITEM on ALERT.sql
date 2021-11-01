IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='IDX_ACTIVE_WORKITEM' AND object_id = OBJECT_ID('[dbo].[ALERT]'))
BEGIN
	CREATE NONCLUSTERED INDEX IDX_ACTIVE_WORKITEM ON [dbo].[ALERT] ([IS_WORK_ITEM], [IS_DRAFT]) INCLUDE ([ALERT_ID], [JOB_COMPONENT_NBR], [ALERT_LEVEL]);
END