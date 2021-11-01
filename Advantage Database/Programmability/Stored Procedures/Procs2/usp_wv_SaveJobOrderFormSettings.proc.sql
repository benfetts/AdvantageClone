

CREATE PROCEDURE [dbo].[usp_wv_SaveJobOrderFormSettings]
@UserID Varchar(100),
@JobOrderForm smallint,
@OmitEmptyFields smallint,
@TrafficAssignments smallint,
@TitleTA Varchar(100),
@TrafficSchedule smallint,
@TitleTS Varchar(100),
@DueDateOnly smallint,
@MilestonesOnly smallint,
@MilestoneTitle Varchar(100),
@EmployAssignments smallint,
@LocationID Varchar(6),
@ReportPlacement Varchar(1),
@CreativeBrief smallint,
@ApprovedByCB smallint,
@TitleCB Varchar(100),
@JobSpecs smallint,
@ApprovedByJS smallint,
@TitleJS Varchar(100),
@SchedComments smallint,
@VendorSpecs smallint,
@MediaSpecs smallint,
@JobVersions smallint,
@OmitEmptyFieldsCB smallint,
@OmitEmptyFieldsJV smallint,
@OmitEmptyFieldsJS smallint
AS

INSERT INTO [dbo].[PRINT_JOB_ORDER_DEF] (
	[USER_ID]
    ,[JOB_ORDER_FORM]
    ,[JOB_MAIN]
    ,[JOB_SPEC_OPTS]
    ,[JOB_USER_FLDS]
    ,[COMP_MAIN]
    ,[COMP_LAYOUT]
    ,[COMP_USER_FLDS]
    ,[COMP_ACCT]
    ,[JOB_COMMENT]
    ,[JOB_BILL_COMMENT]
    ,[COMP_COMMENT]
    ,[CREATIVE_INSTR]
    ,[SHIPPING_INSTR]
    ,[TRAFFIC_SCHED]
    ,[MILESTONE]
    ,[DUE_DATE]
    ,[EMPL_ASSIGN]
    ,[TRAFFIC_GENERAL_ASSIGN]
    ,[OMIT_EMPTY_FLDS]
    ,[TRAFFIC_SCHED_TITLE]
    ,[SCHED_MILESTONE_TITLE]
    ,[KEY_ASSIGN_TITLE]
    ,[JOB_ORDER_TITLE]
    ,[CREATIVE_BRIEF_TITLE]
    ,[JOB_SPEC_TITLE]
    ,[REPORT_TITLE_PLACEMENT]
    ,[LOCATION_ID]
    ,[LOGO_PATH]
    ,[REPORT_FORMAT]
    ,[CREATIVE_BRIEF]
    ,[CREATIVE_BRIEF_AO]
    ,[JOB_SPECS]
    ,[JOB_SPECS_AO]
    ,[SCHED_COMMENTS]
	,[VENDOR_SPECS]
	,[MEDIA_SPECS]
	,[JOB_VERSIONS]
	,[OMIT_EMPTY_FLDS_CB]
	,[OMIT_EMPTY_FLDS_JV]
	,[OMIT_EMPTY_FLDS_JS]
) 
VALUES (
	@UserID,	
	@JobOrderForm,
	0,0,0,0,0,0,0,0,0,0,0,0,
	@TrafficSchedule,
	@MilestonesOnly,
	@DueDateOnly,
	@EmployAssignments,
	@TrafficAssignments,
	@OmitEmptyFields,
	@TitleTS,
	@MilestoneTitle,
	@TitleTA,
	'',
	@TitleCB,
	@TitleJS,
	@ReportPlacement,	
	@LocationID,
	'',2,
	@CreativeBrief,
	@ApprovedByCB,	
	@JobSpecs,
	@ApprovedByJS,
	@SchedComments,
	@VendorSpecs,
	@MediaSpecs,
	@JobVersions,
	@OmitEmptyFieldsCB,
	@OmitEmptyFieldsJV,
	@OmitEmptyFieldsJS	
)


