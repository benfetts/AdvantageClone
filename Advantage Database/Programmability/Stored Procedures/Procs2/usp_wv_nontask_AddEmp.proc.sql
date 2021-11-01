IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_nontask_AddEmp]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_nontask_AddEmp]
GO

CREATE PROCEDURE [dbo].[usp_wv_nontask_AddEmp]
	@ID int,
	@EmpCode varchar(6),
	@Email varchar(50)
AS

INSERT INTO [dbo].[EMP_NON_TASKS_EMPS] (
	[NON_TASK_ID],
	[EMP_CODE],
	[EMAIL_ADDRESS]
) 
VALUES (
	@ID,
	@EmpCode,
	@Email
)
SELECT SCOPE_IDENTITY()


