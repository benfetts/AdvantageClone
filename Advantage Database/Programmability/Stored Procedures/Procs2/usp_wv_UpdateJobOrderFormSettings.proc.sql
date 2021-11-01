


CREATE PROCEDURE [dbo].[usp_wv_UpdateJobOrderFormSettings]
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

UPDATE PRINT_JOB_ORDER_DEF SET
	[JOB_ORDER_FORM] = @JobOrderForm,
	[TRAFFIC_SCHED] = @TrafficSchedule,
	[MILESTONE] = @MilestonesOnly, 
	[DUE_DATE] = @DueDateOnly,
	[EMPL_ASSIGN] = @EmployAssignments,
	[OMIT_EMPTY_FLDS] = @OmitEmptyFields,
	[TRAFFIC_SCHED_TITLE] = @TitleTS,
    [SCHED_MILESTONE_TITLE] = @MilestoneTitle,
	[CREATIVE_BRIEF_TITLE] = @TitleCB,
	[JOB_SPEC_TITLE] = @TitleJS,
	[REPORT_TITLE_PLACEMENT] = @ReportPlacement,
	[LOCATION_ID] = @LocationID,
	[CREATIVE_BRIEF] = @CreativeBrief,
    [CREATIVE_BRIEF_AO] = @ApprovedByCB,
	[JOB_SPECS] = @JobSpecs,
	[JOB_SPECS_AO] = @ApprovedByJS, 
	[TRAFFIC_GENERAL_ASSIGN] = @TrafficAssignments,
	[KEY_ASSIGN_TITLE] = @TitleTA ,
	[SCHED_COMMENTS] = @SchedComments,
	[VENDOR_SPECS] = @VendorSpecs,
	[MEDIA_SPECS] = @MediaSpecs,
	[JOB_VERSIONS] = @JobVersions,
	[OMIT_EMPTY_FLDS_CB] = @OmitEmptyFieldsCB,
	[OMIT_EMPTY_FLDS_JV] = @OmitEmptyFieldsJV,
	[OMIT_EMPTY_FLDS_JS] = @OmitEmptyFieldsJS 
WHERE   UPPER(USER_ID) = UPPER(@UserID)




