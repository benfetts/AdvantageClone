IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_nontask_new]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_nontask_new]
GO

CREATE PROCEDURE [dbo].[usp_wv_nontask_new]
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

--Declare @NextJobNumber Int
--Declare @OfficeCode VarChar(4)
--Declare @ProdMarkup Decimal(11,2)

INSERT INTO [dbo].[EMP_NON_TASKS] (
	[TYPE],
	[START_DATE],
	[END_DATE],
	[ALL_DAY],
	[NON_TASK_DESC],
	[START_TIME],
	[END_TIME],
	[HOURS], 
	[EMP_CODE],
	[CATEGORY],
	[JOB_NUMBER], 
	[JOB_COMPONENT_NBR],
	[FNC_CODE],
	[CL_CODE],
	[DIV_CODE],
	[PRD_CODE],
	[PRIORITY],
	[REMINDER],
	[RECURRENCE],
	[TASK_CODE],
	[NON_EMP_TASK_DESC],
	[RECURRENCE_PARENT],
	[CDP_CONTACT_ID],
	[NON_EMP_TASK_HTML]
) 
VALUES (
	@Type,
	@StartDate,
	@EndDate,
	@Allday,
	@Nontaskdesc,
	@Starttime,
	@Endtime,
	@Hours,
	@Empcode,
	@Category,
	@JobNumber,
	@JobCompNumber,
	@Fnccode,
	@ClientCode,
	@DivisionCode,
	@ProductCode,
	@Priority,
	@Reminder,
	@Recurrence,
	@TaskCode,
	@Description,
	@RecurrenceParent,
	@CDPContactID,
	@DescriptionHTML
)
SELECT SCOPE_IDENTITY()


