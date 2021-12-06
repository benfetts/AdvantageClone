if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_Report002_Combined]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_Report002_Combined]
GO







CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_Report002_Combined] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Comps varchar(100),
@Quotes varchar(100),
@ReportType Int,
@PrintID Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int, @Records int, @Count int, @CountRev int, @MaxRev int, @Recordquote int, @Countquote int,
	@EstNum int, @Font varchar(50), @Font2 varchar(10),
	@EstCompNum int,
	@QuoteNum int,
	@RevNum int,
	@JobNum int,
	@JobCompNum int,
	@FncCode varchar(6),
	@sql nvarchar(4000),
	@paramlist nvarchar(4000),
	@sql2 nvarchar(4000),
	@sql3 nvarchar(4000),
	@sqlfrom nvarchar(4000),
	@sqlwhere nvarchar(4000),
	@sqlgroupby nvarchar(4000),
	@sqlfrom2 nvarchar(4000),
	@sqlwhere2 nvarchar(4000),
	@sqlgroupby2 nvarchar(4000),
	@paramlist2 nvarchar(4000),
	@DateToPrint smallint,
	@TaxSeparate smallint,
	@TaxIndicator smallint,
	@CommMUSeparate smallint,
	@CommMUIndicator smallint,
	@FunctionOption varchar(2),
	@GroupOption varchar(2),
	@SortOption varchar(2),
	@InsideDesc varchar(30),
	@OutsideDesc varchar(30),
	@EstComment smallint,
	@EstCompComment smallint,
	@QteComment smallint,
	@RevComment smallint,
	@FuncComment smallint,
	@DefComment smallint,
	@CliRef smallint,
	@AE smallint,
	@SalesClass smallint,
	@Specs smallint,
	@JobOty smallint,
	@Contingency smallint,
	@SuppressZero smallint,
	@NonBill smallint,
	@DivName smallint,
	@PrdName smallint,
	@QtyHrs smallint,
	@SubTotOnly smallint,
	@ConsoleOverride smallint,
	@JobQty decimal(15,4),
	@sumCPU decimal(20,3),
	@ContSeparate smallint,
	@cpNum int,
	@qteNum int,
	@ProdConsFunc smallint,
	@client varchar(6), 
	@division varchar(6),
	@product varchar(6),
	@func varchar(6),
	@funcdesc varchar(30),
	@funcorder smallint,
	@jobnumber int,
	@jobdesc varchar(60),
	@cdpid int,
	@contcode varchar(6),
	@contfml varchar(100),
	@conta1 varchar(40),
	@conta2 varchar(40),
	@contcity varchar(30),
	@contstate varchar(10),
	@contzip varchar(10),
	@contcountry varchar(20),
	@contphone varchar(13),
	@contfax varchar(13),
	@contemail varchar(50),
	@conttitle varchar(40),
	@jobclientref varchar(30),
	@CPU decimal(15,3),
	@CPM decimal(15,3),
	@ExclEmpTime smallint,
	@ExclVendor smallint,
	@ExclIO smallint,
	@sumCT decimal(20,4),
	@ExclNonBill smallint,
	@ClientCode as varchar(6),
	@DivisionCode as varchar(6),
	@ProductCode as varchar(6),
	@OfficeCode as varchar(6)

CREATE TABLE #est(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int,
	EstComment text,
	EstCompComment text,
	QteComment text,
	RevComment text,
	EstCommentHtml text,
	EstCompCommentHtml text,
	QteCommentHtml text,
	RevCommentHtml text)

CREATE TABLE #estComments(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int,
	FunctionCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
	ConsolidationCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCompComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCompCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QteComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QteCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DetailComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DetailCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotes varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotesHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL)

CREATE TABLE #funcheading(
	RowID int IDENTITY(1, 1), 
	FuncHeadingID int,
	FuncHeadingDesc varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FuncHeadingSeq int,
	InactiveFlag smallint,
	HeadingID int 
)

INSERT INTO #funcheading
SELECT [FNC_HEADING_ID]
      ,[FNC_HEADING_DESC]
      ,[FNC_HEADING_SEQ]
      ,[INACTIVE_FLAG]
	  ,NULL FROM FNC_HEADING ORDER BY FNC_HEADING_SEQ, FNC_HEADING_DESC

CREATE TABLE #comps(
	RowID int IDENTITY(1, 1), 
	listpos int,
	comp int)

CREATE TABLE #quotes(
	RowID int IDENTITY(1, 1), 
	listpos int,
	quote int)

CREATE TABLE #estPrint( 	
	RowID int IDENTITY(1, 1),
	ESTIMATE_NUMBER		int,
	EST_LOG_DESC		varchar(60) NULL,
	EST_COMPONENT_NBR	smallint,
	EST_COMP_DESC		varchar(60) NULL,
	EST_QUOTE_NBR		smallint,
	EST_QUOTE_DESC		varchar(60) NULL,
	JOB_NUMBER			int,
	JOB_DESC			varchar(60) NULL,
	JOB_COMPONENT_NBR	smallint,
	JOB_COMP_DESC		varchar(60) NULL,
	EST_REV_NBR 		smallint NULL,
	--SEQ_NBR 			int,
	FNC_CODE			varchar(6) NULL,
	FNC_DESCRIPTION		varchar(30) NULL,
	EST_FNC_COMMENT		text,
	EST_REV_SUP_BY_CDE	varchar(6) NULL,
	EST_REV_SUP_BY_NTE	text,
	EST_REV_QUANTITY	decimal(15,2),
	EST_REV_RATE		decimal(15,4),
	EST_REV_EXT_AMT		decimal(15,2),
	--EST_REV_COMM_PCT	decimal(6,3),
	EXT_MARKUP_AMT		decimal(14,2),
	LINE_TOTAL  		decimal(14,2),
	--EST_REV_CONT_PCT	decimal(6,3),
	EXT_CONTINGENCY		decimal(14,2),
	EXT_MU_CONT 		decimal(14,2),
	--INCL_CPU			smallint,
	EST_FNC_TYPE		varchar(1) NULL,
	EMPLOYEE_TITLE_ID	int,
	FNC_TYPE		    varchar(1) NULL,
	EST_PHASE_ID		smallint,
	EST_PHASE_DESC		varchar(60) NULL,
	FNC_HEADING_ID		int,
	FNC_HEADING_DESC	varchar(60) NULL,
	FNC_HEADING_SEQ		int,
	JOB_CLI_REF			varchar(30) NULL,
	SC_CODE 			varchar(6) NULL,
	SC_DESCRIPTION		varchar(30) NULL,
	AE          		varchar(100) NULL,
	CL_CODE    		    varchar(6) NULL,
	CL_NAME			    varchar(40) NULL,
	DIV_CODE    		varchar(6) NULL,
	DIV_NAME			varchar(40) NULL,
	PRD_CODE			varchar(6) NULL,
	PRD_DESCRIPTION		varchar(40) NULL,
	EST_LOG_COMMENT		text,
	EST_COMP_COMMENT	text,
	EST_QTE_COMMENT		text,
	EST_REV_COMMENT     text,
	TAX				    decimal(15,2),
	--TAX_CODE            varchar(4) NULL,
	JOB_QTY             int,
	CDP_CONTACT_ID      int,
	CONT_CODE           varchar(6),
	CONT_FML            varchar(100),
	CONT_ADDRESS1       varchar(40),
	CONT_ADDRESS2       varchar(40),
	CONT_CITY           varchar(20),
	CONT_STATE          varchar(10),
	CONT_ZIP            varchar(10),
	CONT_COUNTRY        varchar(20),
	CONT_TELEPHONE		varchar(13) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_FAX			varchar(13) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EMAIL_ADDRESS		varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_TITLE			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CPU         		decimal(15,3),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20),
	ESTCOMP				varchar(20),
	INOUT               char(1),
	FNC_ORDER           smallint,
	CMP_IDENTIFIER      int,
	CMP_CODE            varchar(6),
	CMP_NAME            varchar(128),
	QUOTE_1				decimal(15,2),
	QUOTE_1_MU			decimal(14,2),
	QUOTE_1_CONT		decimal(14,2),
	QUOTE_1_MU_CONT 	decimal(14,2),
	QUOTE_1_TAX			decimal(15,2),
	QUOTE_1_JOB_QTY     int,
	QUOTE_1_CPU         decimal(15,3),
	QUOTE_1_CPM         decimal(15,3),
	QUOTE_1_LINE_TOTAL  decimal(14,2),
	QUOTE_2				decimal(15,2),
	QUOTE_2_MU			decimal(14,2),
	QUOTE_2_CONT		decimal(14,2),
	QUOTE_2_MU_CONT 	decimal(14,2),
	QUOTE_2_TAX			decimal(15,2),
	QUOTE_2_JOB_QTY     int,
	QUOTE_2_CPU         decimal(15,3),
	QUOTE_2_CPM         decimal(15,3),
	QUOTE_2_LINE_TOTAL  decimal(14,2),
	QUOTE_3				decimal(15,2),
	QUOTE_3_MU			decimal(14,2),
	QUOTE_3_CONT		decimal(14,2),
	QUOTE_3_MU_CONT 	decimal(14,2),
	QUOTE_3_TAX			decimal(15,2),
	QUOTE_3_JOB_QTY     int,
	QUOTE_3_CPU         decimal(15,3),
	QUOTE_3_CPM         decimal(15,3),
	QUOTE_3_LINE_TOTAL  decimal(14,2),
	QUOTE_4				decimal(15,2),
	QUOTE_4_MU			decimal(14,2),
	QUOTE_4_CONT		decimal(14,2),
	QUOTE_4_MU_CONT 	decimal(14,2),
	QUOTE_4_TAX			decimal(15,2),
	QUOTE_4_JOB_QTY     int,
	QUOTE_4_CPU         decimal(15,3),
	QUOTE_4_CPM         decimal(15,3),
	QUOTE_4_LINE_TOTAL  decimal(14,2),
	QUOTE_1_LINE_CONT_TOTAL  decimal(14,2),
	QUOTE_2_LINE_CONT_TOTAL  decimal(14,2),
	QUOTE_3_LINE_CONT_TOTAL  decimal(14,2),
	QUOTE_4_LINE_CONT_TOTAL  decimal(14,2))

CREATE TABLE #estPrintData( 	
	RowID int IDENTITY(1, 1),
	EstimateNumber		int,
	EstimateDescription		varchar(60) NULL,
	EstimateComponentNumber	smallint,
	EstimateComponentDescription		varchar(60) NULL,
	--EST_QUOTE_NBR		smallint,
	--EST_QUOTE_DESC		varchar(60) NULL,
	JobNumber			int,
	JobDescription			varchar(60) NULL,
	JobComponentNumber	smallint,
	JobComponentDescription		varchar(60) NULL,
	--EST_REV_NBR 		smallint NULL,
	--SEQ_NBR 			int,
	FunctionCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FunctionDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DetailComments		text,
	DetailCommentsHtml		text,
	--EST_REV_SUP_BY_CDE	varchar(6) NULL,
	SuppliedByNotes	text,
	SuppliedByNotesHtml	text,
	--EST_REV_QUANTITY	decimal(15,2),
	--EST_REV_RATE		decimal(15,3),
	--EST_REV_EXT_AMT		decimal(15,2),
	--EST_REV_COMM_PCT	decimal(6,3),
	--EXT_MARKUP_AMT		decimal(14,2),
	--LINE_TOTAL  		decimal(14,2),
	--EST_REV_CONT_PCT	decimal(6,3),
	--EXT_CONTINGENCY		decimal(14,2),
	--EXT_MU_CONT 		decimal(14,2),
	--INCL_CPU			smallint,
	EstimateFunctionType		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EmployeeTitleID	int,
	FunctionType		    varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimatePhaseID		smallint,
	EstimatePhaseDescription		varchar(60) NULL,
	FunctionHeadingID		int,
	FunctionHeadingDescription	varchar(60) NULL,
	FunctionHeadingSequence		int,
	JobClientReference			varchar(30) NULL,
	SalesClassCode 			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SalesClassDescription		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AccountExecutiveCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AccountExecutiveName          		varchar(100) NULL,
	ClientCode    		    varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientName			    varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionCode    		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionName			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductDescription		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateComment		text,
	EstimateComponentComment	text,
	QuoteComment		text,
	RevisionComment     text,
	DefaultComment      varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateCommentHtml		text,
	EstimateComponentCommentHtml	text,
	QuoteCommentHtml		text,
	RevisionCommentHtml     text,
	DefaultCommentHtml      varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	--TAX				    decimal(15,2),
	--TAX_CODE            varchar(4) NULL,
	JobQuantity             int,
	EstimateContactID      int,
	EstimateContactCode           varchar(6),
	EstimateContactName            varchar(100),
	EstimateContactAddress1       varchar(40),
	EstimateContactAddress2       varchar(40),
	EstimateContactCity           varchar(30),
	EstimateContactState          varchar(10),
	EstimateContactZip            varchar(10),
	EstimateContactCountry        varchar(20),
	EstimateContactPhone		  varchar(13),
	EstimateContactFax			  varchar(13),
	EstimateContactEmail		  varchar(50),
	EstimateContactTitle       varchar(40),
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	EstimateComponentQuote		varchar(20),
	EstimateComponent				varchar(20),
	InOut               char(1),
	FunctionOrder           smallint,
	EstimateCampaignID      int,
	EstimateCampaignCode            varchar(6),
	EstimateCampaignName           varchar(60),
	Quote1				decimal(15,2),
	Quote1Markup			decimal(14,2),
	Quote1Contingency		decimal(14,2),
	Quote1MarkupContingency 	decimal(14,2),
	Quote1Tax			decimal(15,2),
	Quote1JobQuantity     int,
	Quote1CPU         decimal(15,3),
	Quote1CPM         decimal(15,3),
	Quote1LineTotal  decimal(14,2),
	Quote2				decimal(15,2),
	Quote2Markup			decimal(14,2),
	Quote2Contingency		decimal(14,2),
	Quote2MarkupContingency 	decimal(14,2),
	Quote2Tax		decimal(15,2),
	Quote2JobQuantity     int,
	Quote2CPU         decimal(15,3),
	Quote2CPM         decimal(15,3),
	Quote2LineTotal  decimal(14,2),
	Quote3				decimal(15,2),
	Quote3Markup			decimal(14,2),
	Quote3Contingency		decimal(14,2),
	Quote3MarkupContingency 	decimal(14,2),
	Quote3Tax		decimal(15,2),
	Quote3JobQuantity     int,
	Quote3CPU         decimal(15,3),
	Quote3CPM         decimal(15,3),
	Quote3LineTotal  decimal(14,2),
	Quote4				decimal(15,2),
	Quote4Markup			decimal(14,2),
	Quote4Contingency		decimal(14,2),
	Quote4MarkupContingency 	decimal(14,2),
	Quote4Tax		decimal(15,2),
	Quote4JobQuantity     int,
	Quote4CPU         decimal(15,3),
	Quote4CPM         decimal(15,3),
	Quote4LineTotal  decimal(14,2),
	Quote1LineContingencyTotal  decimal(14,2),
	Quote2LineContingencyTotal  decimal(14,2),
	Quote3LineContingencyTotal  decimal(14,2),
	Quote4LineContingencyTotal  decimal(14,2),
	Quote1QuoteComment varchar(MAX),
	Quote1QuoteCommentHtml varchar(MAX),
	Quote2QuoteComment varchar(MAX),
	Quote2QuoteCommentHtml varchar(MAX),
	Quote3QuoteComment varchar(MAX),
	Quote3QuoteCommentHtml varchar(MAX),
	Quote4QuoteComment varchar(MAX),
	Quote4QuoteCommentHtml varchar(MAX),
	FunctionOption varchar(2),
	GroupOption  varchar(2),
	SortOption varchar(2),
	TaxSeparate smallint,
	CommissionSeparate smallint,
	ContingencySeparate smallint, 
	IncludeContingency smallint,
	PrintNonBillable smallint)

CREATE TABLE #estPrintCombined( 	
	RowID int IDENTITY(1, 1),
	EstimateNumber		int,
	EstimateDescription		varchar(60) NULL,	
	FunctionCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FunctionDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JobNumber			int,
	JobDescription			varchar(60) NULL,
	DetailComments		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DetailCommentsHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotes	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotesHtml	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateFunctionType		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EmployeeTitleID	int,
	FunctionType		    varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimatePhaseID		smallint,
	EstimatePhaseDescription		varchar(60) NULL,
	GroupingID		int,
	FunctionHeadingID		int,
	FunctionHeadingDescription	varchar(60) NULL,
	FunctionHeadingSequence		int,
	JobClientReference			varchar(30) NULL,
	SalesClassCode 			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SalesClassDescription		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientCode    		    varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientName			    varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionCode    		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionName			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductDescription		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateComment		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateComponentComment	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QuoteComment		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevisionComment     varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DefaultComment      varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateCommentHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateComponentCommentHtml	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QuoteCommentHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevisionCommentHtml     varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DefaultCommentHtml      varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JobQuantity             int,
	EstimateContactID      int,
	EstimateContactCode           varchar(6),
	EstimateContactName            varchar(100),
	EstimateContactAddress1       varchar(40),
	EstimateContactAddress2       varchar(40),
	EstimateContactCity           varchar(30),
	EstimateContactState          varchar(10),
	EstimateContactZip            varchar(10),
	EstimateContactCountry        varchar(20),
	EstimateContactPhone		  varchar(13),
	EstimateContactFax			  varchar(13),
	EstimateContactEmail		  varchar(50),
	EstimateContactTitle       varchar(40),
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	EstimateComponent				varchar(20),
	InOut               char(1),
	FunctionOrder           smallint,
	EstimateCampaignID      int,
	EstimateCampaignCode            varchar(6),
	EstimateCampaignName           varchar(60),
	Quote1				decimal(15,2),
	Quote1Markup			decimal(14,2),
	Quote1Contingency		decimal(14,2),
	Quote1MarkupContingency 	decimal(14,2),
	Quote1Tax			decimal(15,2),
	Quote1JobQuantity     int,
	Quote1CPU         decimal(15,3),
	Quote1CPM         decimal(15,3),
	Quote1LineTotal  decimal(14,2),
	Quote2				decimal(15,2),
	Quote2Markup			decimal(14,2),
	Quote2Contingency		decimal(14,2),
	Quote2MarkupContingency 	decimal(14,2),
	Quote2Tax		decimal(15,2),
	Quote2JobQuantity     int,
	Quote2CPU         decimal(15,3),
	Quote2CPM         decimal(15,3),
	Quote2LineTotal  decimal(14,2),
	Quote3				decimal(15,2),
	Quote3Markup			decimal(14,2),
	Quote3Contingency		decimal(14,2),
	Quote3MarkupContingency 	decimal(14,2),
	Quote3Tax		decimal(15,2),
	Quote3JobQuantity     int,
	Quote3CPU         decimal(15,3),
	Quote3CPM         decimal(15,3),
	Quote3LineTotal  decimal(14,2),
	Quote4				decimal(15,2),
	Quote4Markup			decimal(14,2),
	Quote4Contingency		decimal(14,2),
	Quote4MarkupContingency 	decimal(14,2),
	Quote4Tax		decimal(15,2),
	Quote4JobQuantity     int,
	Quote4CPU         decimal(15,3),
	Quote4CPM         decimal(15,3),
	Quote4LineTotal  decimal(14,2),
	Quote1LineContingencyTotal  decimal(14,2),
	Quote2LineContingencyTotal  decimal(14,2),
	Quote3LineContingencyTotal  decimal(14,2),
	Quote4LineContingencyTotal  decimal(14,2),
	Quote1QuoteComment varchar(MAX),
	Quote1QuoteCommentHtml varchar(MAX),
	Quote2QuoteComment varchar(MAX),
	Quote2QuoteCommentHtml varchar(MAX),
	Quote3QuoteComment varchar(MAX),
	Quote3QuoteCommentHtml varchar(MAX),
	Quote4QuoteComment varchar(MAX),
	Quote4QuoteCommentHtml varchar(MAX),
	FunctionOption varchar(2),
	GroupOption  varchar(2),
	SortOption varchar(2),
	TaxSeparate smallint,
	CommissionSeparate smallint,
	ContingencySeparate smallint, 
	IncludeContingency smallint,	
	LabelFromUDFTable1 varchar(40),
	LabelFromUDFTable2 varchar(40),
	LabelFromUDFTable3 varchar(40),
	LabelFromUDFTable4 varchar(40),
	LabelFromUDFTable5 varchar(40),
	CompLabelFromUDFTable1 varchar(40),
	CompLabelFromUDFTable2 varchar(40),
	CompLabelFromUDFTable3 varchar(40),
	CompLabelFromUDFTable4 varchar(40),
	CompLabelFromUDFTable5 varchar(40))

	
IF @PrintID = 0
BEGIN
	SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0), @FunctionOption = ISNULL(FUNCTION_OPTION, ''), 
                      @GroupOption = ISNULL(GROUP_OPTION, ''), @SortOption = ISNULL(SORT_OPTION, ''), @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @Specs = ISNULL(SPECS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), 
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ContSeparate = ISNULL(CONT_SEPARATE, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
	FROM        ESTIMATE_PRINT_DEF
	WHERE     (UPPER(USER_ID) = UPPER(@UserID))
END
ELSE
BEGIN
	SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0),
					  @FunctionOption = CASE WHEN ISNULL(FUNCTION_OPTION, '') = '1' THEN 'F'
										     WHEN ISNULL(FUNCTION_OPTION, '') = '2' THEN 'C'
											 WHEN ISNULL(FUNCTION_OPTION, '') = '3' THEN 'T'
											 WHEN ISNULL(FUNCTION_OPTION, '') = '4' THEN 'R'
											 WHEN ISNULL(FUNCTION_OPTION, '') = '5' THEN 'N' ELSE 'F' END, 
                      @GroupOption = CASE WHEN ISNULL(GROUP_OPTION, '') = '1' THEN 'N'
										  WHEN ISNULL(GROUP_OPTION, '') = '2' THEN 'T'
										  WHEN ISNULL(GROUP_OPTION, '') = '3' THEN 'H'
										  WHEN ISNULL(GROUP_OPTION, '') = '4' THEN 'HT'
										  WHEN ISNULL(GROUP_OPTION, '') = '5' THEN 'I'
										  WHEN ISNULL(GROUP_OPTION, '') = '6' THEN 'P' ELSE 'N' END,
					  @SortOption = CASE WHEN ISNULL(SORT_OPTION, '') = '1' THEN 'C'
										  WHEN ISNULL(SORT_OPTION, '') = '2' THEN 'O' ELSE 'N' END, @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), @ContSeparate = ISNULL(CONT_SEPARATE, 0),
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
	FROM        PROD_EST_DEF
	WHERE     PROD_EST_DEF_ID = @PrintID
END


SELECT @client = CL_CODE, @division = DIV_CODE, @product = PRD_CODE
FROM ESTIMATE_LOG
WHERE ESTIMATE_NUMBER = @EstNo

SELECT @ProdConsFunc = PRD_CONSOL_FUNC
FROM PRODUCT
WHERE CL_CODE = @client AND DIV_CODE = @division AND PRD_CODE = @product

INSERT INTO #comps 
SELECT * FROM [dbo].[charlist_to_table] (
  @Comps,',')

INSERT INTO #quotes 
SELECT * FROM [dbo].[charlist_to_table] (
  @Quotes,',')

SELECT @Records = COUNT(*) FROM #comps
SET @Count = 1
SELECT @Recordquote = COUNT(*) FROM #quotes
SET @Countquote = 1

WHILE @Count <= @Records
BEGIN

 SELECT @cpNum = comp
 FROM #comps
 WHERE RowID = @Count

 SELECT @qteNum = quote
 FROM #quotes
 WHERE RowID = @Countquote

         INSERT INTO #est
         SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		           EQ.EST_QUOTE_NBR, MAX(ESTIMATE_REV.EST_REV_NBR), NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL
                            FROM         ESTIMATE_QUOTE EQ INNER JOIN
                                                  ESTIMATE_REV ON EQ.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
                                                  EQ.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
                                                  EQ.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
                                                  ESTIMATE_COMPONENT EC ON EQ.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND 
                                                  EQ.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR INNER JOIN
                                                 ESTIMATE_LOG EL ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN
                                                  ESTIMATE_REV_DET E ON ESTIMATE_REV.ESTIMATE_NUMBER = E.ESTIMATE_NUMBER AND 
                                                  ESTIMATE_REV.EST_COMPONENT_NBR = E.EST_COMPONENT_NBR AND 
                                                  ESTIMATE_REV.EST_QUOTE_NBR = E.EST_QUOTE_NBR AND 
                                                  ESTIMATE_REV.EST_REV_NBR = E.EST_REV_NBR
                WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @cpNum) AND (EQ.EST_QUOTE_NBR = @qteNum)
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		                   EQ.EST_QUOTE_NBR
        
	SET @Count = @Count + 1	
	SET @Countquote = @Countquote + 1	           
END
--SELECT * FROM #est
UPDATE #est SET EstComment = (SELECT ISNULL(EST_LOG_COMMENT,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompComment = (SELECT ISNULL(EST_COMP_COMMENT,'') FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteComment = (SELECT ISNULL(EST_QTE_COMMENT,'') FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevComment = (SELECT ISNULL(EST_REV_COMMENT,'') FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		           
UPDATE #est SET EstCommentHtml = (SELECT ISNULL(EST_LOG_COMMENT_HTML,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompCommentHtml = (SELECT ISNULL(EST_COMP_COMMENT_HTML,'') FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteCommentHtml = (SELECT ISNULL(EST_QTE_COMMENT_HTML,'') FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevCommentHtml = (SELECT ISNULL(EST_REV_COMMENT_HTML,'') FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		        



SELECT @NumberRecords = COUNT(*) FROM #est
SET @RowCount = 1
SET @cpNum = 0
SET @Count = 1
WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @EstNum = EstNo, @EstCompNum = EstCompNo, @QuoteNum = QuoteNo, @RevNum = RevNo
 FROM #est
 WHERE RowID = @RowCount
 
 

if @cpNum <> 0
	Begin
	    if @cpNum <> @EstCompNum
	        Begin
	            SET @cpNum = @EstCompNum	
	            SET @Count = 1
	            --SET @RowCount = 1	            
	        End
	    Else
	        Begin
	            SET @cpNum = @EstCompNum	
	            --SET @RowCount = @RowCount + 1
	        End
	End 
Else
	Begin
       --SET @RowCount = @RowCount + 1	   
	   SET @cpNum = @EstCompNum	
	End 
 --SELECT @cpNum, @EstNum, @EstCompNum, @QuoteNum, @RevNum, @Count, @RowCount
 SELECT @sql2 = 'INSERT INTO #estPrint SELECT EQ.ESTIMATE_NUMBER, EL.EST_LOG_DESC, EQ.EST_COMPONENT_NBR, EC.EST_COMP_DESC, EQ.EST_QUOTE_NBR, EQ.EST_QUOTE_DESC, JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ESTIMATE_REV.EST_REV_NBR,'
			            if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                Begin
			                    SELECT @sql2 = @sql2 + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN E.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, '''','
			                End
			            Else
			                Begin
			                    SELECT @sql2 = @sql2 + ' E.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION,'
			                End                       
                      SELECT @sql2 = @sql2 + ' '''', '''', '''', SUM(ISNULL(E.EST_REV_QUANTITY,0)) AS EST_REV_QUANTITY, 0.00,
					 SUM(E.EST_REV_EXT_AMT) AS EST_REV_EXT_AMT, SUM(E.EXT_MARKUP_AMT) AS EXT_MARKUP_AMT, SUM(ISNULL(E.LINE_TOTAL,0)) AS LINE_TOTAL,
					 SUM(E.EXT_CONTINGENCY) AS EXT_CONTINGENCY, SUM(E.EXT_MU_CONT) AS EXT_MU_CONT,'
				     if @GroupOption = 'T'
					    Begin
					        SELECT @sql2 = @sql2 + ' E.EST_FNC_TYPE, 0, FUNCTIONS.FNC_TYPE,'
					    End
					 else
					    Begin
					        SELECT @sql2 = @sql2 + ' '''' AS EST_FNC_TYPE, 0, '''' AS FNC_TYPE,'
					    End 
					 if @GroupOption = 'P'
					    Begin
					        SELECT @sql2 = @sql2 + ' E.EST_PHASE_ID, ISNULL(E.EST_PHASE_DESC, '''') as EST_PHASE_DESC,'
					    End
					 else
					    Begin
					        SELECT @sql2 = @sql2 + ' '''' as EST_PHASE_ID, '''' as EST_PHASE_DESC,'
					    End
					 if @GroupOption = 'H'
					    Begin
					        SELECT @sql2 = @sql2 + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					    End
					 else
					    Begin
					        SELECT @sql2 = @sql2 + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
					    End 
SELECT @sql2 = @sql2 + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION, '''', '''', '''', '''',
					 SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0))) AS TAX,'
					

SELECT @sql2 = @sql2 + ' ISNULL(ESTIMATE_REV.JOB_QTY,0) AS JOB_QTY, ISNULL(CDP_CONTACT_HDR.CDP_CONTACT_ID,0), ISNULL(CDP_CONTACT_HDR.CONT_CODE,''''), ISNULL(CDP_CONTACT_HDR.CONT_FML,''''), ISNULL(CDP_CONTACT_HDR.CONT_ADDRESS1,''''), 
                      ISNULL(CDP_CONTACT_HDR.CONT_ADDRESS2,''''), ISNULL(CDP_CONTACT_HDR.CONT_CITY,''''), ISNULL(CDP_CONTACT_HDR.CONT_STATE,''''), 
                      ISNULL(CDP_CONTACT_HDR.CONT_ZIP,''''), ISNULL(CDP_CONTACT_HDR.CONT_COUNTRY,''''),ISNULL(CDP_CONTACT_HDR.CONT_TELEPHONE,''''),ISNULL(CDP_CONTACT_HDR.CONT_FAX,''''),ISNULL(CDP_CONTACT_HDR.EMAIL_ADDRESS,''''),ISNULL(CDP_CONTACT_HDR.CONT_TITLE,''''),
					   0, 0, (Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(7))+''/''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))), (Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(7))+''/''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))),'                      
				    if @GroupOption = 'I'
					    Begin
					        SELECT @sql2 = @sql2 + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ''I''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN ''C''
                                                       ELSE ''I'' END AS INOUT,'
					    End
					 else
					    Begin
					        SELECT @sql2 = @sql2 + ' ''I'' AS INOUT,'
					    End                      
                     if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sql2 = @sql2 + ' 0 AS FNC_ORDER,'
                        End      
                    Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sql2 = @sql2 + ' 0 AS FNC_ORDER,'
                        End 
                    Else
                        Begin
	                        SELECT @sql2 = @sql2 + ' ISNULL(FUNCTIONS.FNC_ORDER,0) AS FNC_ORDER,'
                        End  
					SELECT @sql2 = @sql2 + ' EL.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME, '                        	    
					if @Count = 1
						Begin
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)),
														 SUM(E.EXT_MARKUP_AMT), SUM(E.EXT_CONTINGENCY), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End						
						End
					Else if @Count = 2
					    Begin
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)),
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM(E.EXT_CONTINGENCY), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End						
					    End
					Else if @Count = 3
					    Begin
					    	if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)),
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End			
						End
					Else if @Count = 4
						Begin
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY)),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)),
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT),
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
							End					
						End  

SELECT @sqlfrom = '	FROM ESTIMATE_QUOTE EQ INNER JOIN
                      ESTIMATE_REV ON EQ.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
                      EQ.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
                      EQ.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
                      ESTIMATE_COMPONENT EC ON EQ.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND 
                      EQ.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR INNER JOIN
                      ESTIMATE_LOG EL ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN
                      ESTIMATE_REV_DET E ON ESTIMATE_REV.ESTIMATE_NUMBER = E.ESTIMATE_NUMBER AND 
                      ESTIMATE_REV.EST_COMPONENT_NBR = E.EST_COMPONENT_NBR AND 
                      ESTIMATE_REV.EST_QUOTE_NBR = E.EST_QUOTE_NBR AND 
                      ESTIMATE_REV.EST_REV_NBR = E.EST_REV_NBR INNER JOIN
                      FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
                      JOB_COMPONENT ON EC.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
                      EC.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR LEFT OUTER JOIN
                      FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN 
					  JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
					  SALES_CLASS ON EL.SC_CODE = SALES_CLASS.SC_CODE LEFT OUTER JOIN
                      EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
                      PRODUCT ON EL.CL_CODE = PRODUCT.CL_CODE AND EL.DIV_CODE = PRODUCT.DIV_CODE AND 
                      EL.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE LEFT OUTER JOIN
                      CDP_CONTACT_HDR ON EC.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID LEFT OUTER JOIN
					  CAMPAIGN ON CAMPAIGN.CMP_IDENTIFIER = EL.CMP_IDENTIFIER'

SELECT @sqlwhere = ' WHERE (EQ.ESTIMATE_NUMBER = ''' + Cast(@EstNum AS Varchar(10)) + ''') AND (EQ.EST_COMPONENT_NBR = ''' + Cast(@EstCompNum AS Varchar(5)) + ''') AND 
                      (EQ.EST_QUOTE_NBR = ''' + Cast(@QuoteNum AS Varchar(5)) + ''') AND (ESTIMATE_REV.EST_REV_NBR = ''' + Cast(@RevNum AS Varchar(5)) + ''')'
					  
if @ExclEmpTime = 1
Begin
	SELECT @sqlwhere = @sqlwhere + ' AND E.EST_FNC_TYPE <> ''E'''
End
if @ExclVendor = 1
Begin
	SELECT @sqlwhere = @sqlwhere + ' AND E.EST_FNC_TYPE <> ''V'''
End
if @ExclIO = 1
Begin
	SELECT @sqlwhere = @sqlwhere + ' AND E.EST_FNC_TYPE <> ''I'''
End
if @ExclNonBill = 1
Begin
	SELECT @sqlwhere = @sqlwhere + ' AND E.EST_NONBILL_FLAG = 0'
End

SELECT @sqlgroupby = ' GROUP BY EQ.ESTIMATE_NUMBER, EL.EST_LOG_DESC, EQ.EST_COMPONENT_NBR, EC.EST_COMP_DESC,
					  EQ.EST_QUOTE_NBR, EQ.EST_QUOTE_DESC, JOB_LOG.JOB_NUMBER, 
                      JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ESTIMATE_REV.EST_REV_NBR,'
                      if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                Begin
			                    SELECT @sqlgroupby = @sqlgroupby + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN E.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END,'
			                End
			          Else
			                Begin
			                    SELECT @sqlgroupby = @sqlgroupby + ' E.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION,'
			                End 
					  if @GroupOption = 'T'
					    Begin
					        SELECT @sqlgroupby = @sqlgroupby + ' E.EST_FNC_TYPE, FUNCTIONS.FNC_TYPE,'
					    End
					  if @GroupOption = 'I'
					    Begin
					        SELECT @sqlgroupby = @sqlgroupby + ' FUNCTIONS.FNC_TYPE,'
					    End
                      if @GroupOption = 'P'
					    Begin
					        SELECT @sqlgroupby = @sqlgroupby + ' E.EST_PHASE_ID, E.EST_PHASE_DESC,'
					    End		
					  if @GroupOption = 'H'
					    Begin
					        SELECT @sqlgroupby = @sqlgroupby + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					    End	  
SELECT @sqlgroupby = @sqlgroupby + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,		  
					  ESTIMATE_REV.JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY,CDP_CONTACT_HDR.CONT_TELEPHONE,CDP_CONTACT_HDR.CONT_FAX,CDP_CONTACT_HDR.EMAIL_ADDRESS,CDP_CONTACT_HDR.CONT_TITLE,EL.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME'
                      if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sqlgroupby = @sqlgroupby + ''
                        End      
                    Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sqlgroupby = @sqlgroupby + ''
                        End       
                    Else
                        Begin
	                        SELECT @sqlgroupby = @sqlgroupby + ' , FNC_ORDER'
                        End                        


	--print @sql2 + @sqlfrom + @sqlwhere + @sqlgroupby
	EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby)


                 
--SELECT DISTINCT @JobQty = JOB_QTY
--FROM #estPrint 
--WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
--                      (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
                      
SELECT @sumCPU = sum(E.LINE_TOTAL), @sumCT = SUM(E.LINE_TOTAL_CONT)
FROM         ESTIMATE_QUOTE EQ INNER JOIN
                      ESTIMATE_REV ON EQ.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
                      EQ.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
                      EQ.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
                      ESTIMATE_COMPONENT EC ON EQ.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND 
                      EQ.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR INNER JOIN
                      ESTIMATE_LOG EL ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN
                      ESTIMATE_REV_DET E ON ESTIMATE_REV.ESTIMATE_NUMBER = E.ESTIMATE_NUMBER AND 
                      ESTIMATE_REV.EST_COMPONENT_NBR = E.EST_COMPONENT_NBR AND 
                      ESTIMATE_REV.EST_QUOTE_NBR = E.EST_QUOTE_NBR AND 
                      ESTIMATE_REV.EST_REV_NBR = E.EST_REV_NBR INNER JOIN
                      FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
                      JOB_COMPONENT ON EC.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
                      EC.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR LEFT OUTER JOIN 
					  JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
WHERE     (EQ.ESTIMATE_NUMBER = @EstNum) AND (EQ.EST_COMPONENT_NBR = @EstCompNum) AND 
                      (EQ.EST_QUOTE_NBR = @QuoteNum) AND (ESTIMATE_REV.EST_REV_NBR = @RevNum) AND E.INCL_CPU = 1 
     
if @Count = 1
Begin
    UPDATE #estPrint
        SET QUOTE_1_LINE_TOTAL = @sumCPU, QUOTE_1_LINE_CONT_TOTAL = @sumCT
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End  
if @Count = 2
Begin
    UPDATE #estPrint
        SET QUOTE_2_LINE_TOTAL = @sumCPU, QUOTE_2_LINE_CONT_TOTAL = @sumCT
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End  
if @Count = 3
Begin
    UPDATE #estPrint
        SET QUOTE_3_LINE_TOTAL = @sumCPU, QUOTE_3_LINE_CONT_TOTAL = @sumCT
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End  
if @Count = 4
Begin
    UPDATE #estPrint
        SET QUOTE_4_LINE_TOTAL = @sumCPU, QUOTE_4_LINE_CONT_TOTAL = @sumCT
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End     
	


        SET @Count = @Count + 1
        --SET @Count = 0

        SET @RowCount = @RowCount + 1
        --SET @Count = @Count + 1
 
 
END
--SELECT * FROM #estPrint

SELECT @sql = 'INSERT INTO #estPrintData 
				SELECT ESTIMATE_NUMBER, EST_LOG_DESC, EST_COMPONENT_NBR, EST_COMP_DESC, JOB_NUMBER,
				JOB_DESC, JOB_COMPONENT_NBR, JOB_COMP_DESC, FNC_CODE, FNC_DESCRIPTION, '''' AS EST_FNC_COMMENT,'''','''' AS EST_REV_SUP_BY_NTE,'''',
				 EST_FNC_TYPE, EMPLOYEE_TITLE_ID, FNC_TYPE,'
				 if @GroupOption = 'P'
					    Begin
					        SELECT @sql = @sql + ' EST_PHASE_ID, EST_PHASE_DESC,'
					    End
					 else
					    Begin
					        SELECT @sql = @sql + ' '''', '''','
					    End
				 if @GroupOption = 'H'
					    Begin
					        SELECT @sql = @sql + ' FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ,'
					    End
					 else
					    Begin
					        SELECT @sql = @sql + ' 0, '''', 0,'
					    End
SELECT @sql = @sql + ' JOB_CLI_REF, SC_CODE, SC_DESCRIPTION, '''',AE, CL_CODE, CL_NAME, DIV_CODE, DIV_NAME, PRD_CODE, PRD_DESCRIPTION, '''' AS EST_LOG_COMMENT, '''' AS EST_COMP_COMMENT, '''' AS EST_QTE_COMMENT,	'''' AS EST_REV_COMMENT,'''','''','''','''','''','''',
				 0, CDP_CONTACT_ID, CONT_CODE, CONT_FML, CONT_ADDRESS1, CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY,CONT_TELEPHONE,CONT_FAX,EMAIL_ADDRESS,CONT_TITLE, 0, 0, 0, ESTCOMP, INOUT, FNC_ORDER, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, SUM(QUOTE_1) AS QUOTE_1, SUM(QUOTE_1_MU) AS QUOTE_1_MU,				 
				 SUM(QUOTE_1_CONT) AS QUOTE_1_CONT, SUM(QUOTE_1_MU_CONT) AS QUOTE_1_MU_CONT, SUM(QUOTE_1_TAX) AS QUOTE_1_TAX, SUM(QUOTE_1_JOB_QTY) AS QUOTE_1_JOB_QTY, SUM(QUOTE_1_CPU) AS QUOTE_1_CPU, SUM(QUOTE_1_CPM) AS QUOTE_1_CPM, SUM(QUOTE_1_LINE_TOTAL) AS QUOTE_1_LINE_TOTAL, 
				 SUM(QUOTE_2) AS QUOTE_2, SUM(QUOTE_2_MU) AS QUOTE_2_MU, SUM(QUOTE_2_CONT) AS QUOTE_2_CONT, SUM(QUOTE_2_MU_CONT) AS QUOTE_2_MU_CONT, SUM(QUOTE_2_TAX) AS QUOTE_2_TAX, SUM(QUOTE_2_JOB_QTY) AS QUOTE_2_JOB_QTY, SUM(QUOTE_2_CPU) AS QUOTE_2_CPU, SUM(QUOTE_4_CPM) AS QUOTE_2_CPM, SUM(QUOTE_2_LINE_TOTAL) AS QUOTE_2_LINE_TOTAL, 
				 SUM(QUOTE_3) AS QUOTE_3, SUM(QUOTE_3_MU) AS QUOTE_3_MU, SUM(QUOTE_3_CONT) AS QUOTE_3_CONT, SUM(QUOTE_3_MU_CONT) AS QUOTE_3_MU_CONT, SUM(QUOTE_3_TAX) AS QUOTE_3_TAX, SUM(QUOTE_3_JOB_QTY) AS QUOTE_3_JOB_QTY, SUM(QUOTE_3_CPU) AS QUOTE_3_CPU, SUM(QUOTE_3_CPM) AS QUOTE_3_CPM, SUM(QUOTE_3_LINE_TOTAL) AS QUOTE_3_LINE_TOTAL,  
				 SUM(QUOTE_4) AS QUOTE_4, SUM(QUOTE_4_MU) AS QUOTE_4_MU, SUM(QUOTE_4_CONT) AS QUOTE_4_CONT, SUM(QUOTE_4_MU_CONT) AS QUOTE_4_MU_CONT, SUM(QUOTE_4_TAX) AS QUOTE_4_TAX, SUM(QUOTE_4_JOB_QTY) AS QUOTE_4_JOB_QTY, SUM(QUOTE_4_CPU) AS QUOTE_4_CPU, SUM(QUOTE_4_CPM) AS QUOTE_4_CPM, SUM(QUOTE_4_LINE_TOTAL) AS QUOTE_4_LINE_TOTAL,
				 SUM(QUOTE_1_LINE_CONT_TOTAL) AS QUOTE_1_LINE_CONT_TOTAL, SUM(QUOTE_2_LINE_CONT_TOTAL) AS QUOTE_3_LINE_CONT_TOTAL, SUM(QUOTE_3_LINE_CONT_TOTAL) AS QUOTE_3_LINE_CONT_TOTAL, SUM(QUOTE_4_LINE_CONT_TOTAL) AS QUOTE_4_LINE_CONT_TOTAL,
				 '''','''','''','''','''','''','''','''','''','''','''',0,0,0,0,0'
				 

SELECT @sqlfrom2 = ' FROM #estPrint' 
SELECT @sqlwhere2 = ' WHERE 1=1'

if @SuppressZero = 1 and @PrintID = 0
Begin
	SELECT @sqlwhere2 = @sqlwhere2 + ' AND EST_REV_EXT_AMT <> 0'
End

if @SuppressZero = 0 and @PrintID <> 0
Begin
	SELECT @sqlwhere2 = @sqlwhere2 + ' AND EST_REV_EXT_AMT <> 0'
End

SELECT @sqlgroupby2 = ' GROUP BY ESTIMATE_NUMBER, EST_LOG_DESC, EST_COMPONENT_NBR, EST_COMP_DESC, JOB_NUMBER, JOB_DESC, JOB_COMPONENT_NBR, JOB_COMP_DESC, FNC_CODE, FNC_DESCRIPTION,
				 EST_FNC_TYPE, EMPLOYEE_TITLE_ID, FNC_TYPE,'
				 if @GroupOption = 'P'
					    Begin
					        SELECT @sqlgroupby2 = @sqlgroupby2 + ' EST_PHASE_ID, EST_PHASE_DESC,'
					    End
			     if @GroupOption = 'H'
					    Begin
					        SELECT @sqlgroupby2 = @sqlgroupby2 + ' FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ,'
					    End	
SELECT @sqlgroupby2 = @sqlgroupby2 + ' JOB_CLI_REF, SC_CODE, SC_DESCRIPTION, AE, CL_CODE, CL_NAME, DIV_CODE, DIV_NAME, PRD_CODE, PRD_DESCRIPTION, CDP_CONTACT_ID, CONT_CODE, CONT_FML, CONT_ADDRESS1, 
                      CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY,CONT_TELEPHONE,CONT_FAX,EMAIL_ADDRESS,CONT_TITLE, ESTCOMP, INOUT, FNC_ORDER, CMP_IDENTIFIER, CMP_CODE, CMP_NAME'

SELECT @sqlgroupby2 = @sqlgroupby2 + ' ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR'

if @GroupOption = 'T'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , FNC_TYPE'
End
if @GroupOption = 'H'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , FNC_HEADING_DESC'
End
if @GroupOption = 'P'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , EST_PHASE_DESC'
End
if @GroupOption = 'I'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , INOUT'
End


if @SortOption = 'C'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , FNC_CODE'
End
if @SortOption = 'O'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , FNC_ORDER'
End

--print @sql + @sqlfrom2 + @sqlwhere2 + @sqlgroupby2
EXEC (@sql + @sqlfrom2 + @sqlwhere2 + @sqlgroupby2)

--SELECT * FROM #estPrintData

SELECT @NumberRecords = COUNT(*) FROM #estPrintData
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @func = FunctionCode
 FROM #estPrintData
 WHERE RowID = @RowCount

 SELECT @funcdesc = FNC_DESCRIPTION, @funcorder = FNC_ORDER
 FROM FUNCTIONS
 WHERE FNC_CODE = @func
 
UPDATE #estPrintData 
SET FunctionDescription = @funcdesc, FunctionOrder = @funcorder
WHERE FunctionCode = @func

SELECT @sumCPU = Quote1LineTotal, @sumCT = Quote1LineContingencyTotal
FROM #estPrintData
WHERE Quote1LineTotal <> 0

UPDATE #estPrintData
SET Quote1LineTotal = @sumCPU
WHERE Quote1LineTotal = 0

SELECT @JobQty = Quote1JobQuantity
FROM #estPrintData
WHERE Quote1JobQuantity <> 0

UPDATE #estPrintData
SET Quote1JobQuantity = @JobQty
WHERE Quote1JobQuantity = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET Quote1CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
			UPDATE #estPrintData
			SET Quote1CPM = (@sumCPU + @sumCT) / (@JobQty / 1000) 
End              

SET @sumCPU = 0
SET @sumCT = 0
SELECT @sumCPU = Quote2LineTotal, @sumCT = Quote2LineContingencyTotal
FROM #estPrintData
WHERE Quote2LineTotal <> 0

UPDATE #estPrintData
SET Quote2LineTotal = @sumCPU
WHERE Quote2LineTotal = 0

SET @JobQty = 0
SELECT @JobQty = Quote2JobQuantity
FROM #estPrintData
WHERE Quote2JobQuantity <> 0

UPDATE #estPrintData
SET Quote2JobQuantity = @JobQty
WHERE Quote2JobQuantity = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET Quote2CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
			UPDATE #estPrintData
			SET Quote2CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)
End          

SET @sumCPU = 0
SET @sumCT = 0
SELECT @sumCPU = Quote3LineTotal, @sumCT = Quote3LineContingencyTotal
FROM #estPrintData
WHERE Quote3LineTotal <> 0

UPDATE #estPrintData
SET Quote3LineTotal = @sumCPU
WHERE Quote3LineTotal = 0

SET @JobQty = 0
SELECT @JobQty = Quote3JobQuantity
FROM #estPrintData
WHERE Quote3JobQuantity <> 0

UPDATE #estPrintData
SET Quote3JobQuantity = @JobQty
WHERE Quote3JobQuantity = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET Quote3CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
			UPDATE #estPrintData
			SET Quote3CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)
End     

SET @sumCPU = 0
SET @sumCT = 0
SELECT @sumCPU = Quote4LineTotal, @sumCT = Quote4LineContingencyTotal
FROM #estPrintData
WHERE Quote4LineTotal <> 0

UPDATE #estPrintData
SET Quote4LineTotal = @sumCPU
WHERE Quote4LineTotal = 0

SET @JobQty = 0
SELECT @JobQty = Quote4JobQuantity
FROM #estPrintData
WHERE Quote4JobQuantity <> 0

UPDATE #estPrintData
SET Quote4JobQuantity = @JobQty
WHERE Quote4JobQuantity = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET Quote4CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
			UPDATE #estPrintData
			SET Quote4CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)
        
End                

SET @RowCount = @RowCount + 1
END

--Quote Comments
SELECT @NumberRecords = COUNT(*) FROM #est
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN

	SELECT @EstNum = EstNo, @EstCompNum = EstCompNo, @QuoteNum = QuoteNo, @RevNum = RevNo
	 FROM #est
	 WHERE RowID = @RowCount

	if @RowCount = 1
	Begin
		UPDATE #estPrintData
		SET Quote1QuoteComment = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
		UPDATE #estPrintData
		SET Quote1QuoteCommentHtml = (SELECT EST_QTE_COMMENT_HTML FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
		
	End
	if @RowCount = 2
	Begin
		UPDATE #estPrintData
		SET Quote2QuoteComment = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
		UPDATE #estPrintData
		SET Quote2QuoteCommentHtml = (SELECT EST_QTE_COMMENT_HTML FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
	End
	if @RowCount = 3
	Begin
		UPDATE #estPrintData
		SET Quote3QuoteComment = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
		UPDATE #estPrintData
		SET Quote3QuoteCommentHtml = (SELECT EST_QTE_COMMENT_HTML FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
	End
	if @RowCount = 4
	Begin
		UPDATE #estPrintData
		SET Quote4QuoteComment = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
		UPDATE #estPrintData
		SET Quote4QuoteCommentHtml = (SELECT EST_QTE_COMMENT_HTML FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
	End

	SET @RowCount = @RowCount + 1
END

SET @jobnumber = 0
SET @jobdesc = ''
SET @jobclientref = ''
SELECT DISTINCT @jobnumber = ISNULL(JOB_NUMBER, 0), @jobdesc = ISNULL(JOB_DESC, ''), @jobclientref = ISNULL(JOB_CLI_REF,'')
 FROM #estPrint
 WHERE JOB_NUMBER IS NOT NULL

SELECT DISTINCT @cdpid = ISNULL(CDP_CONTACT_ID, 0), @contcode = ISNULL(CONT_CODE, ''),
				 @contfml = ISNULL(CONT_FML, ''), @conta1 = ISNULL(CONT_ADDRESS1, ''),
				 @conta2 = ISNULL(CONT_ADDRESS2, ''), @contcity = ISNULL(CONT_CITY, ''),
				 @contstate = ISNULL(CONT_STATE, ''), @contzip = ISNULL(CONT_ZIP, ''), 
				 @contcountry = ISNULL(CONT_COUNTRY,''), @contphone = ISNULL(CONT_TELEPHONE,''),
				 @contfax = ISNULL(CONT_FAX,''), @contemail = ISNULL(EMAIL_ADDRESS,''),
				 @conttitle = ISNULL(CONT_TITLE,'')
FROM #estPrint
WHERE CDP_CONTACT_ID IS NOT NULL
--SELECT * FROM #estPrintData

SELECT @sql3 = ' INSERT INTO #estPrintCombined SELECT EstimateNumber, EstimateDescription, FunctionCode, FunctionDescription, ''' + Cast(@jobnumber AS Varchar(7)) + ''' AS JobNumber, '''' AS JobDescription,'
SELECT @sql3 = @sql3 + ' '''','''','''','''',EstimateFunctionType, EmployeeTitleID, FunctionType,'
                if @GroupOption = 'P'
					    Begin
					        SELECT @sql3 = @sql3 + ' EstimatePhaseID, EstimatePhaseDescription,'
					    End
					 else
					    Begin
					        SELECT @sql3 = @sql3 + ' '''' as EstimatePhaseID, '''' as EstimatePhaseDescription,'
					    End 
			    if @GroupOption = 'H'
					    Begin
					        SELECT @sql3 = @sql3 + ' (SELECT RowID FROM #funcheading WHERE #estPrintData.FunctionHeadingID = #funcheading.FuncHeadingID), FunctionHeadingID, FunctionHeadingDescription, FunctionHeadingSequence,'
					    End
					 else
					    Begin
					        SELECT @sql3 = @sql3 + ' 0,0 as FunctionHeadingID, '''' as FunctionHeadingDescription, 0 as FunctionHeadingSequence, '
					    End 
SELECT @sql3 = @sql3 + ' ''' + @jobclientref + ''' AS JobClientReference, SalesClassCode, SalesClassDescription, ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,'''','''','''','''','''','''','''','''','''','''','
SELECT @sql3 = @sql3 + ' SUM(JobQuantity) AS JobQuantity, ''' + Cast(@cdpid AS Varchar(5)) + ''' AS EstimateContactID, '''' AS EstimateContactCode, '''' AS EstimateContactName, '''' AS EstimateContactAddress1,
				 '''' AS EstimateContactAddress2, '''' AS EstimateContactCity, '''' AS EstimateContactState, '''' AS EstimateContactZip, '''' AS EstimateContactCountry,
				 '''' AS EstimateContactPhone,'''' AS EstimateContactFax,'''' AS EstimateContactEmail,'''' AS EstimateContactTitle,SUM(CPU) AS CPU, SUM(CPM) AS CPM, 
				 '''',InOut, FunctionOrder,EstimateCampaignID, EstimateCampaignCode, EstimateCampaignName, SUM(Quote1) AS Quote1, SUM(Quote1Markup) AS Quote1Markup, SUM(Quote1Contingency) AS Quote1Contingency, SUM(Quote1MarkupContingency) AS Quote1MarkupContingency,
				 SUM(Quote1Tax) AS Quote1Tax, SUM(Quote1JobQuantity) AS Quote1JobQuantity, SUM(Quote1CPU) AS Quote1CPU, SUM(Quote1CPM) AS Quote1CPM, SUM(Quote1LineTotal) AS Quote1LineTotal, 
				 SUM(Quote2) AS Quote2, SUM(Quote2Markup) AS Quote2Markup, SUM(Quote2Contingency) AS Quote2Contingency, SUM(Quote2MarkupContingency) AS Quote2MarkupContingency, 
				 SUM(Quote2Tax) AS Quote2Tax, SUM(Quote2JobQuantity) AS Quote2JobQuantity, SUM(Quote2CPU) AS Quote2CPU, SUM(Quote2CPM) AS Quote2CPM, SUM(Quote2LineTotal) AS Quote2LineTotal,  
				 SUM(Quote3) AS Quote3, SUM(Quote3Markup) AS Quote3Markup, SUM(Quote3Contingency) AS Quote3Contingency, SUM(Quote3MarkupContingency) AS Quote3MarkupContingency, 
				 SUM(Quote3Tax) AS Quote3Tax, SUM(Quote3JobQuantity) AS Quote3JobQuantity, SUM(Quote3CPU) AS Quote3CPU, SUM(Quote3CPM) AS Quote3CPM, SUM(Quote3LineTotal) AS Quote3LineTotal, 
				 SUM(Quote4) AS Quote4, SUM(Quote4Markup) AS Quote4Markup, SUM(Quote4Contingency) AS Quote4Contingency, SUM(Quote4MarkupContingency) AS Quote4MarkupContingency, 
				 SUM(Quote4Tax) AS Quote4Tax, SUM(Quote4JobQuantity) AS Quote4JobQuantity, SUM(Quote4CPU) AS Quote4CPU, SUM(Quote4CPM) AS Quote4CPM, SUM(Quote4LineTotal) AS Quote4LineTotal,
				 SUM(Quote1LineContingencyTotal) AS Quote1LineContingencyTotal, SUM(Quote2LineContingencyTotal) AS Quote3LineContingencyTotal, SUM(Quote3LineContingencyTotal) AS Quote3LineContingencyTotal, SUM(Quote4LineContingencyTotal) AS Quote4LineContingencyTotal,
				 Quote1QuoteComment,Quote1QuoteCommentHtml,Quote2QuoteComment,Quote2QuoteCommentHtml,Quote3QuoteComment,Quote3QuoteCommentHtml,Quote4QuoteComment,Quote4QuoteCommentHtml,'''','''','''',0,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL
			  FROM #estPrintData WHERE 1=1'

SELECT @sql3 = @sql3 + ' GROUP BY EstimateNumber, EstimateDescription, FunctionCode, FunctionDescription, EstimateFunctionType, EmployeeTitleID, FunctionType,'
                      if @GroupOption = 'P'
					    Begin
					        SELECT @sql3 = @sql3 + ' EstimatePhaseID, EstimatePhaseDescription,'
					    End	
					  if @GroupOption = 'H'
					    Begin
					        SELECT @sql3 = @sql3 + ' FunctionHeadingID, FunctionHeadingDescription, FunctionHeadingSequence,'
					    End	  
SELECT @sql3 = @sql3 + ' SalesClassCode, SalesClassDescription, ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,
							 InOut, FunctionOrder,EstimateCampaignID, EstimateCampaignCode, EstimateCampaignName,Quote1QuoteComment,Quote1QuoteCommentHtml,Quote2QuoteComment,Quote2QuoteCommentHtml,Quote3QuoteComment,Quote3QuoteCommentHtml,Quote4QuoteComment,Quote4QuoteCommentHtml'

SELECT @sql3 = @sql3 + ' ORDER BY EstimateNumber'

if @GroupOption = 'T'
Begin
	SELECT @sql3 = @sql3 + ' , FunctionType'
End
if @GroupOption = 'H'
Begin
	SELECT @sql3 = @sql3 + ' , FunctionHeadingSequence, FunctionHeadingDescription'
End
if @GroupOption = 'P'
Begin
	SELECT @sql3 = @sql3 + ' , EstimatePhaseDescription'
End
if @GroupOption = 'I'
Begin
	SELECT @sql3 = @sql3 + ' , InOut'
End


if @SortOption = 'C'
Begin
	SELECT @sql3 = @sql3 + ' , FunctionCode'
End
if @SortOption = 'O'
Begin
	SELECT @sql3 = @sql3 + ' , FunctionOrder'
End
					  
print @sql3
EXEC (@sql3)


if @PrintID = 0
BEGIN
	UPDATE #estPrintCombined SET FunctionOption = (SELECT FUNCTION_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrintCombined SET GroupOption = (SELECT GROUP_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrintCombined SET SortOption = (SELECT SORT_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
END
ELSE
BEGIN
	UPDATE #estPrintCombined SET FunctionOption = @FunctionOption
	UPDATE #estPrintCombined SET GroupOption = @GroupOption
	UPDATE #estPrintCombined SET SortOption = @SortOption
END

--UPDATE #estPrintCombined SET PrintNonBillable = (SELECT PRT_NONBILL FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
UPDATE #estPrintCombined SET JobDescription = (SELECT TOP 1 JOB_DESC FROM JOB_LOG JL INNER JOIN JOB_COMPONENT JC ON JL.JOB_NUMBER = JC.JOB_NUMBER WHERE JC.ESTIMATE_NUMBER = #estPrintCombined.EstimateNumber)
UPDATE #estPrintCombined SET TaxSeparate = @TaxSeparate, CommissionSeparate = @CommMUSeparate, ContingencySeparate = @ContSeparate, IncludeContingency = @Contingency
UPDATE #estPrintcombined SET EstimateContactName = @contfml
UPDATE #estPrintcombined SET EstimateContactCode = @contcode
UPDATE #estPrintcombined SET EstimateContactAddress1 = @conta1
UPDATE #estPrintcombined SET EstimateContactAddress2 = @conta2
UPDATE #estPrintcombined SET EstimateContactCity = @contcity
UPDATE #estPrintcombined SET EstimateContactState = @contstate
UPDATE #estPrintcombined SET EstimateContactZip = @contzip
UPDATE #estPrintcombined SET EstimateContactCountry = @contcountry
UPDATE #estPrintcombined SET EstimateContactPhone = @contphone
UPDATE #estPrintcombined SET EstimateContactFax = @contfax
UPDATE #estPrintcombined SET EstimateContactEmail = @contemail
UPDATE #estPrintcombined SET EstimateContactTitle = @conttitle

--UPDATE #estPrintCombined SET EstimateComment = (SELECT TOP 1 EstComment FROM #est WHERE EstimateNumber = EstNo )
--UPDATE #estPrintData SET EstimateComponentComment = (SELECT TOP 1 EstCompComment FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo)-- AND QuoteNumber = QuoteNo AND MaxRevision = RevNo)

--UPDATE #estPrintCombined SET EstimateCommentHtml = (SELECT TOP 1 EstCommentHtml FROM #est WHERE EstimateNumber = EstNo)
--UPDATE #estPrintData SET EstimateComponentCommentHtml = (SELECT TOP 1 EstCompCommentHtml FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo)-- AND QuoteNumber = QuoteNo AND MaxRevision = RevNo)

SET @Font = '<span style="font-family: Arial; font-size: 9pt;">'
SET @Font2 = '</span>'

DECLARE @ENum int,@EComment varchar(MAX),@ECommentHtml varchar(MAX),@ECComment varchar(MAX),@ECCommentHtml varchar(MAX),
	@ECNum int,@QComment varchar(MAX),@QCommentHtml varchar(MAX),@RComment varchar(MAX),@RCommentHtml varchar(MAX),
	@QNum int,@DComment varchar(MAX),@DCommentHtml varchar(MAX),@SComment varchar(MAX),@SCommentHtml varchar(MAX),
	@RNum int, @FCode varchar(6), @ComponentComments varchar(MAX), @QuoteComments varchar(MAX), @DetailComments varchar(MAX), @SuppliedComments varchar(MAX),
	@ComponentCommentsHtml varchar(MAX), @QuoteCommentsHtml varchar(MAX), @DetailCommentsHtml varchar(MAX), @SuppliedCommentsHtml varchar(MAX), @RID int,
	@Comment varchar(MAX), @CommentHtml varchar(MAX)

SET @ComponentComments = ''
SET @QuoteComments = ''
SET @DetailComments = ''
SET @SuppliedComments = ''
SET @ComponentCommentsHtml = ''
SET @QuoteCommentsHtml = ''
SET @DetailCommentsHtml = ''
SET @SuppliedCommentsHtml = ''
SET @Comment = ''
SET @CommentHtml = ''

INSERT INTO #estComments
SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, EQ.EST_QUOTE_NBR, ESTIMATE_REV.EST_REV_NBR, E.FNC_CODE, FUNCTIONS.FNC_CONSOLIDATION,				
			ISNULL(EL.EST_LOG_COMMENT,'') AS EST_LOG_COMMENT, ISNULL(EL.EST_LOG_COMMENT_HTML,'') AS EST_LOG_COMMENT_HTML, 
			ISNULL(EC.EST_COMP_COMMENT,'') AS EST_COMP_COMMENT, ISNULL(EC.EST_COMP_COMMENT_HTML,'') AS EST_COMP_COMMENT_HTML,
			ISNULL(EQ.EST_QTE_COMMENT,'') AS EST_QTE_COMMENT, ISNULL(EQ.EST_QTE_COMMENT_HTML,'') AS EST_QTE_COMMENT_HTML,
			ISNULL(ESTIMATE_REV.EST_REV_COMMENT,'') AS EST_REV_COMMENT, ISNULL(ESTIMATE_REV.EST_REV_COMMENT_HTML,'') AS EST_REV_COMMENT_HTML,
			ISNULL(E.EST_FNC_COMMENT,'') AS EST_FNC_COMMENT, ISNULL(E.EST_FNC_COMMENT_HTML,'') AS EST_FNC_COMMENT_HTML,
			ISNULL(E.EST_REV_SUP_BY_NTE,'') AS EST_REV_SUP_BY_NTE, ISNULL(E.EST_REV_SUP_BY_HTML,'') AS EST_REV_SUP_BY_HTML
	FROM         ESTIMATE_QUOTE EQ INNER JOIN
						  ESTIMATE_REV ON EQ.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
						  EQ.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
						  EQ.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
						  ESTIMATE_COMPONENT EC ON EQ.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND 
						  EQ.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR INNER JOIN
						  ESTIMATE_LOG EL ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN
						  ESTIMATE_REV_DET E ON ESTIMATE_REV.ESTIMATE_NUMBER = E.ESTIMATE_NUMBER AND 
						  ESTIMATE_REV.EST_COMPONENT_NBR = E.EST_COMPONENT_NBR AND 
						  ESTIMATE_REV.EST_QUOTE_NBR = E.EST_QUOTE_NBR AND 
						  ESTIMATE_REV.EST_REV_NBR = E.EST_REV_NBR INNER JOIN
						  FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
						  JOB_COMPONENT ON EC.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
						  EC.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR LEFT OUTER JOIN 
						  JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
	WHERE     (EQ.ESTIMATE_NUMBER =@EstNo) AND EQ.EST_COMPONENT_NBR IN (SELECT comp FROM #comps) AND EQ.EST_QUOTE_NBR IN (SELECT quote FROM #quotes)

SELECT @NumberRecords = COUNT(*) FROM #est
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN

SELECT @ECComment = EstCompComment
FROM #est
WHERE RowID = @RowCount

SELECT @ECCommentHtml = EstCompCommentHtml
FROM #est
WHERE RowID = @RowCount

if @ECComment <> @Comment
Begin
	SELECT @ComponentComments = @ComponentComments + CHAR(13) + @ECComment
End

If @ECCommentHtml <> @CommentHtml
Begin
	SELECT @ComponentCommentsHtml = @ComponentCommentsHtml + CHAR(13) + @ECCommentHtml
End

SET @Comment = @ECComment
SET @CommentHtml = @ECCommentHtml

SET @RowCount = @RowCount + 1
END

UPDATE #estPrintcombined SET EstimateComment = (SELECT TOP 1 EstComment FROM #estComments WHERE EstimateNumber = EstNo)
UPDATE #estPrintcombined SET EstimateCommentHtml = (SELECT TOP 1 CASE WHEN EstCommentHtml = '' THEN @Font + EstComment + @Font2 ELSE @Font + EstCommentHtml + @Font2 END FROM #estComments WHERE EstimateNumber = EstNo)
UPDATE #estPrintcombined SET EstimateComponentComment = @ComponentComments
UPDATE #estPrintcombined SET EstimateComponentCommentHtml = CASE WHEN @ComponentCommentsHtml = '' THEN @ComponentComments ELSE @Font + @ComponentCommentsHtml + @Font2 END

SELECT @NumberRecords = COUNT(*) FROM #estPrintcombined
SET @RowCount = 1
--SELECT * FROM #estComments

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @func = FunctionCode 
 FROM #estPrintcombined
 WHERE RowID = @RowCount

 if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
 Begin
	SELECT @Count = Count(*)
	FROM #estComments
	WHERE (#estComments.EstNo = @EstNo) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func)
 End
 Else
 Begin
	SELECT @Count = Count(*)
	 FROM #estComments
	 WHERE (#estComments.EstNo = @EstNo) AND (#estComments.FunctionCode = @func)
 End
 

 --SELECT @func
 --Select @Count

 If @Count > 1
 Begin
	if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
	Begin
		DECLARE comment_col_cursor CURSOR FOR 
		SELECT RowID,EstNo,EstCompNo,QuoteNo,RevNo,FunctionCode,EstComment,
				EstCommentHtml,EstCompComment,EstCompCommentHtml,QteComment,QteCommentHtml,RevComment,RevCommentHtml,
				DetailComment,DetailCommentHtml,SuppliedByNotes,SuppliedByNotesHtml FROM #estComments e --INNER JOIN
									  --FUNCTIONS ON e.FunctionCode = FUNCTIONS.FNC_CODE 
		WHERE (e.EstNo = @EstNo) AND (e.FunctionCode = @func OR e.ConsolidationCode = @func)
		OPEN comment_col_cursor

		FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml

		WHILE ( @@FETCH_STATUS <> -1 )
		BEGIN
		
			--SELECT @QuoteComments = @QuoteComments + CHAR(13) + CHAR(10) + @QComment
			SELECT @DetailComments = @DetailComments + CHAR(13) + CHAR(10) + @DComment
			SELECT @SuppliedComments = @SuppliedComments + CHAR(13) + CHAR(10) + @SComment		
			if @QCommentHtml <> ''
			Begin
				if @QuoteCommentsHtml <> ''
				Begin
					SELECT @QuoteCommentsHtml = @QuoteCommentsHtml + '</br>' + @QCommentHtml	
				End
				Else 
				Begin
					SELECT @QuoteCommentsHtml = @QCommentHtml
				End	
			End	
			if @DCommentHtml <> ''
			Begin
				if @DetailCommentsHtml <> ''
				Begin
					SELECT @DetailCommentsHtml = @DetailCommentsHtml + '</br>' + @DCommentHtml
				End
				Else 
				Begin
					SELECT @DetailCommentsHtml = @DCommentHtml
				End		
			End
			if @SCommentHtml <> ''
			Begin
				if @SuppliedCommentsHtml <> ''
				Begin
					SELECT @SuppliedCommentsHtml = @SuppliedCommentsHtml + '</br>' + @SCommentHtml
				End
				Else 
				Begin
					SELECT @SuppliedCommentsHtml = @SCommentHtml
				End		
			End

			FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml
		END

		CLOSE comment_col_cursor
		DEALLOCATE comment_col_cursor

		--if @QuoteCommentsHtml = ''
		--Begin
		--	SELECT @QuoteCommentsHtml = @QuoteComments
		--End

		if @DetailCommentsHtml = ''
		Begin
			SELECT @DetailCommentsHtml = @DetailComments
		End

		if @SuppliedCommentsHtml = ''
		Begin
			SELECT @SuppliedCommentsHtml = @SuppliedComments
		End

		UPDATE #estPrintcombined SET  DetailComments = @DetailComments, SuppliedByNotes = @SuppliedComments, DetailCommentsHtml = @Font + @DetailCommentsHtml + @Font2, SuppliedByNotesHtml = @Font + @SuppliedCommentsHtml + @Font2 
		WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND #estPrintcombined.FunctionCode = @func

		SET @QuoteComments = ''
		SET @DetailComments = ''
		SET @SuppliedComments = ''
		SET @QuoteCommentsHtml = ''
		SET @DetailCommentsHtml = ''
		SET @SuppliedCommentsHtml = ''
	End
	Else
	Begin
		DECLARE comment_col_cursor CURSOR FOR 
		SELECT RowID,EstNo,EstCompNo,QuoteNo,RevNo,FunctionCode,EstComment,
				EstCommentHtml,EstCompComment,EstCompCommentHtml,QteComment,QteCommentHtml,RevComment,RevCommentHtml,
				DetailComment,DetailCommentHtml,SuppliedByNotes,SuppliedByNotesHtml FROM #estComments e WHERE (e.EstNo = @EstNo) AND (e.QuoteNo = @qteNum) AND e.FunctionCode = @func 
		OPEN comment_col_cursor

		FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml

		WHILE ( @@FETCH_STATUS <> -1 )
		BEGIN
		
			--SELECT @QuoteComments = @QuoteComments + CHAR(13) + CHAR(10) + @QComment
			SELECT @DetailComments = @DetailComments + CHAR(13) + CHAR(10) + @DComment
			SELECT @SuppliedComments = @SuppliedComments + CHAR(13) + CHAR(10) + @SComment		
			--if @QCommentHtml <> ''
			--Begin
			--	SELECT @QuoteCommentsHtml = @QuoteCommentsHtml + '</br>' + @QCommentHtml	
			--End				
			if @DCommentHtml <> ''
			Begin
				if @DetailCommentsHtml <> ''
				Begin
					SELECT @DetailCommentsHtml = @DetailCommentsHtml + '</br>' + @DCommentHtml
				End
				Else 
				Begin
					SELECT @DetailCommentsHtml = @DCommentHtml
				End		
			End
			if @SCommentHtml <> ''
			Begin
				if @SuppliedCommentsHtml <> ''
				Begin
					SELECT @SuppliedCommentsHtml = @SuppliedCommentsHtml + '</br>' + @SCommentHtml
				End
				Else 
				Begin
					SELECT @SuppliedCommentsHtml = @SCommentHtml
				End		
			End

			FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml
		END

		CLOSE comment_col_cursor
		DEALLOCATE comment_col_cursor

		--if @QuoteCommentsHtml = ''
		--Begin
		--	SELECT @QuoteCommentsHtml = @QuoteComments
		--End

		if @DetailCommentsHtml = ''
		Begin
			SELECT @DetailCommentsHtml = @DetailComments
		End

		if @SuppliedCommentsHtml = ''
		Begin
			SELECT @SuppliedCommentsHtml = @SuppliedComments
		End

		UPDATE #estPrintcombined SET DetailComments = @DetailComments, SuppliedByNotes = @SuppliedComments, DetailCommentsHtml = @Font + @DetailCommentsHtml + @Font2, SuppliedByNotesHtml = @Font + @SuppliedCommentsHtml + @Font2 
		WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND #estPrintcombined.FunctionCode = @func

		SET @QuoteComments = ''
		SET @DetailComments = ''
		SET @SuppliedComments = ''
		SET @QuoteCommentsHtml = ''
		SET @DetailCommentsHtml = ''
		SET @SuppliedCommentsHtml = ''
	End
	

 End
 Else
 Begin
	--UPDATE #estPrintcombined SET QuoteComment = (SELECT QteComment FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND #estComments.FunctionCode = @func)
	--WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET DetailComments = (SELECT DetailComment FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND #estComments.FunctionCode = @func)
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET SuppliedByNotes = (SELECT SuppliedByNotes FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND #estComments.FunctionCode = @func)
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND #estPrintcombined.FunctionCode = @func
	--UPDATE #estPrintcombined SET QuoteCommentHtml = (SELECT @Font + QteCommentHtml + @Font2 FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND #estComments.FunctionCode = @func)
	--WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET DetailCommentsHtml = (SELECT CASE WHEN DetailCommentsHtml = '' THEN  @Font + DetailComments + @Font2 ELSE @Font + DetailCommentHtml + @Font2 END FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND #estComments.FunctionCode = @func)
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET SuppliedByNotesHtml = (SELECT CASE WHEN SuppliedByNotesHtml = '' THEN  @Font + SuppliedByNotes + @Font2 ELSE @Font + SuppliedByNotesHtml + @Font2 END FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND #estComments.FunctionCode = @func)
	WHERE (#estPrintcombined.EstimateNumber = @EstNo)  AND #estPrintcombined.FunctionCode = @func
 End

  

 SET @RowCount = @RowCount + 1
END


--SELECT @ClientCode = CL_CODE FROM ESTIMATE_LOG WHERE ESTIMATE_NUMBER = @EstNo

--UPDATE #estPrintCombined SET DefaultComment = (SELECT TOP 1 CASE WHEN ISNULL(DefaultComment,'') = 'Standard Comment' THEN 
--														CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates')
--														   ELSE CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE APP_CODE = 'Estimates')
--														   ELSE (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY) END END
--											       WHEN ISNULL(DefaultComment,'') = 'Agency Defined' THEN (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY)
--											  ELSE ISNULL(DefaultComment,'') END 
--									   FROM #est WHERE EstimateNumber = EstNo)--  AND QuoteNumber = QuoteNo AND MaxRevision = RevNo)

--UPDATE #estPrintCombined SET DefaultCommentHtml = (SELECT TOP 1 CASE WHEN ISNULL(DefaultCommentHtml,'') = 'Standard Comment' THEN 
--														CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates')
--														   ELSE CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE APP_CODE = 'Estimates')
--														   ELSE (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY) END END
--											       WHEN ISNULL(DefaultCommentHtml,'') = 'Agency Defined' THEN (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY)
--											  ELSE ISNULL(DefaultCommentHtml,'') END 
--									   FROM #est WHERE EstimateNumber = EstNo)--  AND QuoteNumber = QuoteNo AND MaxRevision = RevNo)

SELECT @JobNum = ISNULL(JOB_NUMBER,0), @JobCompNum = ISNULL(JOB_COMPONENT_NBR,0)
FROM JOB_COMPONENT
WHERE ESTIMATE_NUMBER = @EstNo AND EST_COMPONENT_NBR = @EstCompNo

SELECT @ClientCode = CL_CODE, @DivisionCode = DIV_CODE, @ProductCode = PRD_CODE FROM ESTIMATE_LOG WHERE ESTIMATE_NUMBER = @EstNo

if @JobNum > 0
Begin
	SELECT @OfficeCode = ISNULL(OFFICE_CODE,'') FROM JOB_LOG WHERE JOB_NUMBER = @JobNum
End
Else
Begin
	SELECT @OfficeCode = ISNULL(OFFICE_CODE,'') FROM PRODUCT WHERE CL_CODE = @ClientCode AND DIV_CODE = @DivisionCode AND PRD_CODE = @ProductCode
End



--UPDATE #estPrintData SET DefaultComment = (SELECT CASE WHEN ISNULL(DefaultComment,'') = 'Standard Comment' THEN 
--														CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') 
--															 WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates') 
--															 WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') 
--															 WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates')
--														   ELSE (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY) END 
--											       WHEN ISNULL(DefaultComment,'') = 'Agency Defined' THEN (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY)
--												   WHEN ISNULL(DefaultComment,'') = ''  THEN (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY) 
--											  ELSE ISNULL(DefaultComment,'') END 
--									   FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo) --AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)

--UPDATE #estPrintData SET DefaultCommentHtml = (SELECT CASE WHEN ISNULL(DefaultCommentHtml,'') = @Font + 'Standard Comment' + @Font2 THEN 
--														CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT @Font + CAST(STD_COMMENT AS VARCHAR(MAX)) + @Font2 FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') 
--															 WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT @Font + CAST(STD_COMMENT AS VARCHAR(MAX)) + @Font2 FROM STD_COMMENT WHERE [OFFICE_CODE] = @OfficeCode AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates') 
--															 WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT @Font + CAST(STD_COMMENT AS VARCHAR(MAX)) + @Font2 FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates')
--															 WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT @Font + CAST(STD_COMMENT AS VARCHAR(MAX)) + @Font2 FROM STD_COMMENT WHERE [OFFICE_CODE] IS NULL AND [CLIENT_CODE] IS NULL AND APP_CODE = 'Estimates')
--														   ELSE(SELECT @Font + CAST(ISNULL(EST_COMMENT,'') AS VARCHAR(MAX)) + @Font2 AS EST_COMMENT FROM AGENCY) END
--											       WHEN ISNULL(DefaultCommentHtml,'') = 'Agency Defined' THEN (SELECT @Font + CAST(ISNULL(EST_COMMENT,'') AS VARCHAR(MAX)) + @Font2 AS EST_COMMENT FROM AGENCY)
--												   WHEN ISNULL(DefaultCommentHtml,'') = '' THEN (SELECT @Font + CAST(ISNULL(EST_COMMENT,'') AS VARCHAR(MAX)) + @Font2 AS EST_COMMENT FROM AGENCY)
--											  ELSE @Font + ISNULL(DefaultCommentHtml,'') + @Font2 END 
--									   FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo) --AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)

UPDATE #estPrintcombined
SET LabelFromUDFTable1 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV1 ON JOB_LOG.UDV1_CODE = JOB_LOG_UDV1.UDV_CODE WHERE JOB_NUMBER = #estPrintcombined.JobNumber)
WHERE #estPrintcombined.JobNumber IS not nULL

UPDATE #estPrintcombined
SET LabelFromUDFTable2 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV2 ON JOB_LOG.UDV2_CODE = JOB_LOG_UDV2.UDV_CODE WHERE JOB_NUMBER = #estPrintcombined.JobNumber)
WHERE #estPrintcombined.JobNumber IS not nULL

UPDATE #estPrintcombined
SET LabelFromUDFTable3 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV3 ON JOB_LOG.UDV3_CODE = JOB_LOG_UDV3.UDV_CODE WHERE JOB_NUMBER = #estPrintcombined.JobNumber)
WHERE #estPrintcombined.JobNumber IS not nULL

UPDATE #estPrintcombined
SET LabelFromUDFTable4 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV4 ON JOB_LOG.UDV4_CODE = JOB_LOG_UDV4.UDV_CODE WHERE JOB_NUMBER = #estPrintcombined.JobNumber)
WHERE #estPrintcombined.JobNumber IS not nULL

UPDATE #estPrintcombined
SET LabelFromUDFTable5 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV5 ON JOB_LOG.UDV5_CODE = JOB_LOG_UDV5.UDV_CODE WHERE JOB_NUMBER = #estPrintcombined.JobNumber)
WHERE #estPrintcombined.JobNumber IS not nULL

SELECT * FROM #estPrintCombined


DROP TABLE #est
DROP TABLE #estPrint
DROP TABLE #estPrintData
DROP TABLE #estPrintCombined
DROP TABLE #funcheading





















