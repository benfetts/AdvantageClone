IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_nontask_delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_nontask_delete]
GO




CREATE PROCEDURE [dbo].[usp_wv_nontask_delete]
	@TaskID int
--	@Type varchar(6),
--	@Date smalldatetime,
--	@Allday int,
--	@Nontaskdesc varchar(100),
--	@Starttime varchar(10),
--	@Endtime varchar(10),
--	@Hours decimal(15,2),
--	@Empcode varchar(6),
--	@Category varcher(10),
--	@JobNumber int,
--	@JobCompNumber smallint,
--	@Fnccode varchar(6)
AS

DELETE FROM [dbo].[EMP_NON_TASKS_EMPS] 
	WHERE
	[NON_TASK_ID] = @TaskID

DELETE FROM [dbo].[EMP_NON_TASKS] 
	WHERE
	[NON_TASK_ID] = @TaskID



















