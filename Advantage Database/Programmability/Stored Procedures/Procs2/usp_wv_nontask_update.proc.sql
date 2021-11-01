IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_nontask_update]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_nontask_update]
GO




CREATE PROCEDURE [dbo].[usp_wv_nontask_update]
	@TaskID int,
	@Type varchar(6),
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@Allday int,
	@Nontaskdesc varchar(100),
	@Starttime datetime,
	@Endtime datetime,
	@Hours decimal(15,2),
	@Empcode varchar(6),
	@Category varchar(10),
	@JobNumber int,
	@JobCompNumber smallint,
	@Fnccode varchar(6),
	@ClientCode varchar(6),
	@DivisionCode varchar(6),
	@ProductCode varchar(6),
	@Priority smallint,
	@Reminder nvarchar(255),
	@Recurrence nvarchar(1024),
	@TaskCode varchar(6),
	@Description text,
	@RecurrenceParent int,
	@CDPContactID int,
	@DescriptionHTML text
AS

UPDATE [dbo].[EMP_NON_TASKS] SET
	[TYPE] = @Type,
	[START_DATE] = @StartDate,
	[END_DATE] = @EndDate,
	[ALL_DAY] = @Allday,
	[NON_TASK_DESC] = @Nontaskdesc,
	[START_TIME] = @Starttime,
	[END_TIME] = @Endtime,
	[HOURS] = @Hours, 
	[EMP_CODE] = @Empcode,
	[CATEGORY] = @Category,
	[JOB_NUMBER] = @JobNumber, 
	[JOB_COMPONENT_NBR] = @JobCompNumber,
	[FNC_CODE] = @Fnccode,
	[CL_CODE] = @ClientCode,
	[DIV_CODE] = @DivisionCode,
	[PRD_CODE] = @ProductCode,
	[PRIORITY] = @Priority,
	[REMINDER] = @Reminder,
	[RECURRENCE] = @Recurrence,
	[TASK_CODE] = @TaskCode,
	[NON_EMP_TASK_DESC] = @Description,
	[RECURRENCE_PARENT] = @RecurrenceParent,
	[CDP_CONTACT_ID] = @CDPContactID,
	[NON_EMP_TASK_HTML] = @DescriptionHTML
WHERE
	[NON_TASK_ID] = @TaskID



















