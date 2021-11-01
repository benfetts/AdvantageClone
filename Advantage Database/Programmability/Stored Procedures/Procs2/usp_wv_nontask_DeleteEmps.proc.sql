IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_nontask_DeleteEmps]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_nontask_DeleteEmps]
GO




CREATE PROCEDURE [dbo].[usp_wv_nontask_DeleteEmps]
	@TaskID int
AS

DELETE FROM [dbo].[EMP_NON_TASKS_EMPS] 
	WHERE
	[NON_TASK_ID] = @TaskID



















