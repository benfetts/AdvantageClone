
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_Report003_Combined]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_Report003_Combined]
GO



CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_Report003_Combined] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Comps varchar(100),
@Quotes varchar(100),
@ReportType Int,
@PrintID Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int, @Records int, @Count int, @CountRev int, @MaxRev int, @Recordquote int, @Countquote int, @CountRows int,
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
	@sqlNB nvarchar(4000),
	@sqlactual nvarchar(4000),
	@sqlactualFrom nvarchar(4000),
	@sqlactualwhere nvarchar(4000),
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
	@JobQty int,
	@sumCPU decimal(20,4),
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
	@crevcombined int,
	@functype varchar(1),
	@fncheadingid int,
	@fncheadingdesc varchar(60),
	@fncheadingseq int,
	@actual decimal(15,2),
	@QuoteDesc varchar(60),
	@CompNum int,
	@CompDesc varchar(60),
	@CPU decimal(15,3),
	@CPM decimal(15,3),
	@ExclEmpTime smallint,
	@ExclVendor smallint,
	@ExclIO smallint,
	@OneRev smallint, @EstDesc varchar(60), @EstCompDesc varchar(60), @EstQuoteDesc varchar(60), @JobDescp varchar(60), @JobCompDesc varchar(60),
                @JobCliRef varchar(30), @SCCode varchar(6), @SCDesc varchar(30), @AccE varchar(100), @ClCode varchar(6), @ClName varchar(40),
                @DivCode varchar(6), @DiviName varchar(40), @PrdCode varchar(6), @PrdDesc varchar(40), @CDPContactID int, @ContCode2 varchar(6),
                @ContFML2 varchar(100), @ContA12 varchar(40), @ContA22 varchar(40), @ContCity2 varchar(30), @ContState2 varchar(10), @ContZip2 varchar(10),	@ContCountry2 varchar(20),
                @ECQ varchar(20), @OneR smallint, @sCPU decimal(20,4), @sumCT decimal(20,4), @JobTempCode varchar(50),@ExclNonBill smallint

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
	RevCommentHtml text,
	DefaultComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DefaultCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL)

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
	
CREATE TABLE #ec(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo smallint)		
	
CREATE TABLE #jc(
	RowID int IDENTITY(1, 1), 
	JobNo int,
	JobCompNo smallint,
	EstNo int,
	EstCompNo smallint)	
	
CREATE TABLE #qva_NB ( 
    ESTIMATE_NUMBER		int,
    EST_COMPONENT_NBR	smallint,
    EST_QUOTE_NBR		smallint,
    EST_REV_NBR 		smallint NULL,
    JOB_NUMBER			int,
    JOB_COMPONENT_NBR	smallint,
	FNC_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_DESCRIPTION			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_TYPE      			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_ID		    int,
	FNC_HEADING_DESC	    varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_SEQ		    int,
	INOUT                   char(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_ORDER               smallint,		
	NB_Markup		    decimal(15,2),
	NB_Tax			    decimal(15,2),	
	NB_Amount				decimal(15,2))
	
CREATE TABLE #actual_total ( 
    ESTIMATE_NUMBER		int,
    EST_COMPONENT_NBR	smallint,
    EST_QUOTE_NBR		smallint,
    EST_REV_NBR 		smallint NULL,
    JOB_NUMBER			int,
    JOB_COMPONENT_NBR	smallint,
	FNC_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_DESCRIPTION			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_TYPE      			varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_ID		    int,
	FNC_HEADING_DESC	    varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_SEQ		    int,
	INOUT                   char(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_ORDER               smallint,	
	Actual_Markup		    decimal(15,2),
	Actual_Tax			    decimal(15,2),	
	Actual_Total			decimal(15,2))	
	
CREATE TABLE #quote(
	RowID int IDENTITY(1, 1), 
	CompNum int,
	CompDesc varchar(60),
	QuoteNum int,
	QuoteDesc varchar(60))		

CREATE TABLE #estPrint( 	
	RowID int IDENTITY(1, 1),
	ESTIMATE_NUMBER		int,
	EST_LOG_DESC		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_COMPONENT_NBR	smallint,
	EST_COMP_DESC		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_QUOTE_NBR		smallint,
	EST_QUOTE_DESC		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_NUMBER			int,
	JOB_DESC			varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	JOB_COMPONENT_NBR	smallint,
	JOB_COMP_DESC		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_REV_NBR 		smallint NULL,
	--SEQ_NBR 			int,
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_DESCRIPTION		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_FNC_COMMENT		text,
	EST_REV_SUP_BY_CDE	varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
	EST_FNC_TYPE		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EMPLOYEE_TITLE_ID	int,
	FNC_TYPE		    varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_PHASE_ID		smallint,
	EST_PHASE_DESC		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_ID		int,
	FNC_HEADING_DESC	varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_SEQ		int,
	JOB_CLI_REF			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_CODE 			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_DESCRIPTION		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AE          		varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_CODE    		    varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_NAME			    varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE    		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_NAME			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_DESCRIPTION		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_LOG_COMMENT		text,
	EST_COMP_COMMENT	text,
	EST_QTE_COMMENT		text,
	EST_REV_COMMENT     text,
	TAX				    decimal(15,2),
	--TAX_CODE            varchar(4) NULL,
	JOB_QTY             int,
	CDP_CONTACT_ID      int,
	CONT_CODE           varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_FML            varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ADDRESS1       varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ADDRESS2       varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_CITY           varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_STATE          varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ZIP            varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_COUNTRY        varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_TELEPHONE		varchar(13) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_FAX			varchar(13) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EMAIL_ADDRESS		varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_TITLE			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	INOUT               char(1),
	FNC_ORDER           smallint,
	JOB_DUE_DATE        smalldatetime,
	CMP_IDENTIFIER      int,
	CMP_CODE            varchar(6),
	CMP_NAME            varchar(128),
	ORIGINAL_AMT		decimal(15,2),
	REVISED_AMT		    decimal(15,2),
	FINAL_ACTUAL		decimal(15,2),
	ORIGINAL_MARKUP_AMT	decimal(14,2),
	ORIGINAL_CONT		decimal(14,2),
	ORIGINAL_MU_CONT 	decimal(14,2),
	ORIGINAL_TAX		decimal(15,2),
	ORIGINAL_JOB_QTY     int,
	ORIGINAL_CPU         decimal(15,3),
	ORIGINAL_CPM         decimal(15,3),
	ORIGINAL_LINE_TOTAL  decimal(14,2),
	ORIGINAL_LINE_CONT_TOTAL  decimal(14,2),
	REVISED_MARKUP_AMT	decimal(14,2),
	REVISED_CONT		decimal(14,2),
	REVISED_MU_CONT 	decimal(14,2),
	REVISED_TAX		    decimal(15,2),
	REVISED_JOB_QTY     int,
	REVISED_CPU         decimal(15,3),
	REVISED_CPM         decimal(15,3),
	REVISED_LINE_TOTAL  decimal(14,2),
	REVISED_LINE_CONT_TOTAL  decimal(14,2),
	ONE_REVISION        smallint,	
	Actual_Markup		decimal(15,2),
	Actual_Tax			decimal(15,2),
	Actual_Total        decimal(15,2),		
	NB_Markup		    decimal(15,2),
	NB_Tax			    decimal(15,2),
	NB_Total		decimal(15,2))

CREATE TABLE #estPrintData( 	
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
	--EST_REV_NBR 		smallint NULL,
	--SEQ_NBR 			int,
	FNC_CODE			varchar(6) NULL,
	FNC_DESCRIPTION		varchar(30) NULL,
	EST_FNC_COMMENT		text,
	--EST_REV_SUP_BY_CDE	varchar(6) NULL,
	EST_REV_SUP_BY_NTE	text,
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
	EST_FNC_TYPE		varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EMPLOYEE_TITLE_ID	int,
	FNC_TYPE		    varchar(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_PHASE_ID		smallint,
	EST_PHASE_DESC		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_ID		int,
	FNC_HEADING_DESC	varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_HEADING_SEQ		int,
	JOB_CLI_REF			varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_CODE 			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SC_DESCRIPTION		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AE          		varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_CODE    		    varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CL_NAME			    varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_CODE    		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DIV_NAME			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	PRD_DESCRIPTION		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EST_LOG_COMMENT		text,
	EST_COMP_COMMENT	text,
	EST_QTE_COMMENT		text,
	EST_REV_COMMENT     text,
	--TAX				    decimal(15,2),
	--TAX_CODE            varchar(4) NULL,
	JOB_QTY             int,
	CDP_CONTACT_ID      int,
	CONT_CODE           varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_FML            varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ADDRESS1       varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ADDRESS2       varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_CITY           varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_STATE          varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ZIP            varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_COUNTRY        varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_TELEPHONE		varchar(13) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_FAX			varchar(13) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EMAIL_ADDRESS		varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_TITLE			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	INOUT               char(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_ORDER           smallint,
	JOB_DUE_DATE        smalldatetime,
	CMP_IDENTIFIER      int,
	CMP_CODE            varchar(6),
	CMP_NAME            varchar(128),
	ORIGINAL_AMT		decimal(15,2),
	REVISED_AMT		    decimal(15,2),
	FINAL_ACTUAL		decimal(15,2),
	ORIGINAL_MARKUP_AMT	decimal(14,2),
	ORIGINAL_CONT		decimal(14,2),
	ORIGINAL_MU_CONT 	decimal(14,2),
	ORIGINAL_TAX		decimal(15,2),
	ORIGINAL_JOB_QTY     int,
	ORIGINAL_CPU         decimal(15,3),
	ORIGINAL_CPM         decimal(15,3),
	ORIGINAL_LINE_TOTAL  decimal(14,2),
	ORIGINAL_LINE_CONT_TOTAL  decimal(14,2),
	REVISED_MARKUP_AMT	decimal(14,2),
	REVISED_CONT		decimal(14,2),
	REVISED_MU_CONT 	decimal(14,2),
	REVISED_TAX		    decimal(15,2),
	REVISED_JOB_QTY     int,
	REVISED_CPU         decimal(15,3),
	REVISED_CPM         decimal(15,3),
	REVISED_LINE_TOTAL  decimal(14,2),
	REVISED_LINE_CONT_TOTAL  decimal(14,2),
	ONE_REVISION        smallint,	
	MAX_REVISION        smallint,	
	Actual_Markup		decimal(15,2),
	Actual_Tax			decimal(15,2),
	Actual_Total        decimal(15,2),		
	NB_Markup		    decimal(15,2),
	NB_Tax			    decimal(15,2),
	NB_Total		decimal(15,2))

CREATE TABLE #estPrintCombined( 	
	RowID int IDENTITY(1, 1),
	EstimateNumber		int,
	EstimateDescription		varchar(60) NULL,
	QuoteNumber		smallint,
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
	EstimateComponentQuote		int,
	InOut               char(1),
	FunctionOrder           smallint,
	EstimateCampaignID      int,
	EstimateCampaignCode            varchar(6),
	EstimateCampaignName           varchar(60),
	OriginalAmount		decimal(15,2),
	RevisedAmount		    decimal(15,2),
	FinalActual		decimal(15,2),
	OriginalMarkupAmount	decimal(14,2),
	OriginalContingency		decimal(14,2),
	OriginalMarkupContingency 	decimal(14,2),
	OriginalTax			decimal(15,2),
	OriginalJobQuantity     int,
	OriginalCPU         decimal(15,3),
	OriginalCPM         decimal(15,3),
	OriginalLineTotal  decimal(14,2),
	OriginalLineContingencyTotal  decimal(14,2),
	RevisedMarkupAmount	decimal(14,2),
	RevisedContingency		decimal(14,2),
	RevisedMarkupContingency 	decimal(14,2),
	RevisedTax		    decimal(15,2),
	RevisedJobQuantity     int,
	RevisedCPU         decimal(15,3),
	RevisedCPM         decimal(15,3),
	RevisedLineTotal  decimal(14,2),
	RevisedLineContingencyTotal  decimal(14,2),
	OneRevision       smallint,
	MaxRevision        smallint,	
	ActualMarkup		decimal(15,2),
	ActualTax			decimal(15,2),
	ActualTotal        decimal(15,2),		
	NonBillableMarkup		    decimal(15,2),
	NonBillableTax			    decimal(15,2),
	NonBillableTotal		decimal(15,2),
	FunctionOption varchar(2),
	GroupOption  varchar(2),
	SortOption varchar(2),
	TaxSeparate smallint,
	CommissionSeparate smallint,
	ContingencySeparate smallint, 
	IncludeContingency smallint,
	PrintNonBillable smallint,	
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

 if @ReportType = 7

    Begin
        INSERT INTO #est
        SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		                   EQ.EST_QUOTE_NBR, MAX(ESTIMATE_REV.EST_REV_NBR - 1), NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL
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
                WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @cpNum) AND (EQ.EST_QUOTE_NBR = @qteNum) AND (ESTIMATE_REV.EST_REV_NBR <> 0)
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		                   EQ.EST_QUOTE_NBR
		                   
         INSERT INTO #est
         SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		           EQ.EST_QUOTE_NBR, MAX(ESTIMATE_REV.EST_REV_NBR), NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL
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
        
    End
Else
    Begin
        INSERT INTO #est
                SELECT DISTINCT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		                   EQ.EST_QUOTE_NBR, ESTIMATE_REV.EST_REV_NBR, NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL
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
                WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @cpNum) AND (EQ.EST_QUOTE_NBR = @qteNum) AND 
                          (ESTIMATE_REV.EST_REV_NBR = 0 OR ESTIMATE_REV.EST_REV_NBR IN (SELECT MAX(ESTIMATE_REV.EST_REV_NBR)
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
                                    WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @cpNum) AND (EQ.EST_QUOTE_NBR = @qteNum) AND (ESTIMATE_REV.EST_REV_NBR <> 0)))
                
       
    End		           

	SET @Count = @Count + 1	
	SET @Countquote = @Countquote + 1

END

--SELECT * FROM #est

INSERT INTO #ec
SELECT DISTINCT EstNo, EstCompNo
FROM #est

SELECT @Records = COUNT(*) FROM #ec
SET @Count = 1

    WHILE @Count <= @Records
    BEGIN
    
    SELECT @EstNo = EstNo, @EstCompNo = EstCompNo
    FROM #ec
    WHERE RowID = @Count
    
    INSERT INTO #jc
    SELECT JOB_NUMBER, JOB_COMPONENT_NBR, @EstNo, @EstCompNo
    FROM JOB_COMPONENT
    WHERE ESTIMATE_NUMBER = @EstNo AND EST_COMPONENT_NBR = @EstCompNo
    
    
    SET @Count = @Count + 1
END

--Select * from #jc

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


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @EstNum = EstNo, @EstCompNum = EstCompNo, @QuoteNum = QuoteNo, @RevNum = RevNo
 FROM #est
 WHERE RowID = @RowCount
  
 SELECT @CountRev = COUNT(*)
 FROM #est
 WHERE EstNo = @EstNum AND EstCompNo = @EstCompNum AND QuoteNo = @QuoteNum 
 
 SELECT @MaxRev = MAX(RevNo)
 FROM #est
 WHERE EstNo = @EstNum AND EstCompNo = @EstCompNum AND QuoteNo = @QuoteNum
--SELECT @EstNum,@EstCompNum, @QuoteNum
--SELECT @MaxRev
if @CountRev > 1
    Begin
        SET @crevcombined = 1
    End
    
 if @RevNum = @MaxRev
    Begin
        SELECT @Records = COUNT(*) FROM #jc
        SET @Count = 1

            WHILE @Count <= @Records
            BEGIN
            
            SELECT @JobNum = JobNo, @JobCompNum = JobCompNo, @EstNo = EstNo, @EstCompNo = EstCompNo
            FROM #jc
            WHERE RowID = @Count
            --SELECT @JobNum, @JobCompNum
           
            
            SELECT @sqlNB = 'INSERT INTO #qva_NB SELECT ''' + Cast(@EstNo AS Varchar(10)) + ''', ''' + Cast(@EstCompNo AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(5)) + ''','
                     if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			             Begin
			                SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, '''','
			             End
			         Else
			             Begin
			                SELECT @sqlNB = @sqlNB + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FNC_DESCRIPTION,'
			             End
			         if @GroupOption = 'T'
					    Begin
					        SELECT @sqlNB = @sqlNB + ' FUNCTIONS.FNC_TYPE,'
					    End
					 else
					    Begin
					        SELECT @sqlNB = @sqlNB + ' '''' AS FNC_TYPE,'
					    End
					 if @GroupOption = 'H'
					    Begin
					        SELECT @sqlNB = @sqlNB + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					    End
					 else
					    Begin
					        SELECT @sqlNB = @sqlNB + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
					    End
					 if @GroupOption = 'I'
					    Begin
					        SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ''I''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN ''C''
                                                       ELSE ''I'' END AS INOUT,'
					    End
					 else
					    Begin
					        SELECT @sqlNB = @sqlNB + ' ''I'' AS INOUT,'
					    End                
                     if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sqlNB = @sqlNB + ' 0 AS FNC_ORDER,'
                        End      
                     Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sqlNB = @sqlNB + ' 0 AS FNC_ORDER,'
                        End 
                     Else
                        Begin
	                        SELECT @sqlNB = @sqlNB + ' ISNULL(FUNCTIONS.FNC_ORDER,0) AS FNC_ORDER,'
                        End          
        SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ISNULL(SUM(EMP_TIME_DTL.EXT_MARKUP_AMT), 0.00)
                              WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Markup,
                              CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ISNULL(SUM(EMP_TIME_DTL.EXT_CITY_RESALE), 0.00) + ISNULL(SUM(EMP_TIME_DTL.EXT_STATE_RESALE), 0.00) + ISNULL(SUM(EMP_TIME_DTL.EXT_COUNTY_RESALE), 0.00)
                              WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Tax,                              
                              CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ISNULL(SUM(EMP_TIME_DTL.TOTAL_BILL), 0.00)
                              WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Amount
	        FROM         FUNCTIONS INNER JOIN
						          V_QUOTE_VS_ACTUAL ON FUNCTIONS.FNC_CODE = V_QUOTE_VS_ACTUAL.FNC_CODE INNER JOIN
						          JOB_COMPONENT ON V_QUOTE_VS_ACTUAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
						          V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
						          EMP_TIME_DTL ON V_QUOTE_VS_ACTUAL.FNC_CODE = EMP_TIME_DTL.FNC_CODE AND 
						          JOB_COMPONENT.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER AND 
						          JOB_COMPONENT.JOB_COMPONENT_NBR = EMP_TIME_DTL.JOB_COMPONENT_NBR LEFT OUTER JOIN
                                  FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID
	        WHERE     (V_QUOTE_VS_ACTUAL.JOB_NUMBER = ''' + Cast(@JobNum AS Varchar(10)) + ''') AND (V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = ''' + Cast(@JobCompNum AS Varchar(5)) + ''') AND 
						          (EMP_TIME_DTL.EMP_NON_BILL_FLAG = 1)'
					  
if @ExclEmpTime = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''E'''
End
if @ExclVendor = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''V'''
End
if @ExclIO = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''I'''
End
								   
	        SELECT @sqlNB = @sqlNB + ' GROUP BY'
	                    if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                        Begin
			                            SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, FUNCTIONS.FNC_TYPE'
			                        End
			                  Else
			                        Begin
			                            SELECT @sqlNB = @sqlNB + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, FUNCTIONS.FNC_TYPE'
			                        End	
					          if @GroupOption = 'H'
					            Begin
					                SELECT @sqlNB = @sqlNB + ', FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ'
					            End	  
                              if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ''
                                End      
                              Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ''
                                End       
                              Else
                                Begin
	                                SELECT @sqlNB = @sqlNB + ', FNC_ORDER'
                                End   
            print @sqlNB
	        EXEC (@sqlNB)
        	
        SET @sqlNB = ''	
        	
        	
        SELECT @sqlNB = 'INSERT INTO #qva_NB SELECT ''' + Cast(@EstNo AS Varchar(10)) + ''', ''' + Cast(@EstCompNo AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(5)) + ''','
                             if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                     Begin
			                        SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, '''','
			                     End
			                 Else
			                     Begin
			                        SELECT @sqlNB = @sqlNB + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FNC_DESCRIPTION,'
			                     End
			                 if @GroupOption = 'T'
					            Begin
					                SELECT @sqlNB = @sqlNB + ' FUNCTIONS.FNC_TYPE,'
					            End
					         else
					            Begin
					                SELECT @sqlNB = @sqlNB + ' '''' AS FNC_TYPE,'
					            End
					         if @GroupOption = 'H'
					            Begin
					                SELECT @sqlNB = @sqlNB + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					            End
					         else
					            Begin
					                SELECT @sqlNB = @sqlNB + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
					            End
					         if @GroupOption = 'I'
					            Begin
					                SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ''I''
                                                               WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ''O''
                                                               WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ''O''
                                                               WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN ''C''
                                                               ELSE ''I'' END AS INOUT,'
					            End
					         else
					            Begin
					                SELECT @sqlNB = @sqlNB + ' ''I'' AS INOUT,'
					            End                
                             if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ' 0 AS FNC_ORDER,'
                                End      
                             Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ' 0 AS FNC_ORDER,'
                                End 
                             Else
                                Begin
	                                SELECT @sqlNB = @sqlNB + ' ISNULL(FUNCTIONS.FNC_ORDER,0) AS FNC_ORDER,'
                                End          
                SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ISNULL(SUM(INCOME_ONLY.EXT_MARKUP_AMT), 0.00)
						                  WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Markup,
						                  CASE WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ISNULL(SUM(INCOME_ONLY.EXT_CITY_RESALE), 0.00) + ISNULL(SUM(INCOME_ONLY.EXT_STATE_RESALE), 0.00) + ISNULL(SUM(INCOME_ONLY.EXT_COUNTY_RESALE), 0.00) 
						                  WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Tax,						                  
						                  CASE WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ISNULL(SUM(INCOME_ONLY.IO_AMOUNT), 0.00)
						                  WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Amount
	                FROM         FUNCTIONS INNER JOIN
						                  V_QUOTE_VS_ACTUAL ON FUNCTIONS.FNC_CODE = V_QUOTE_VS_ACTUAL.FNC_CODE INNER JOIN
						                  JOB_COMPONENT ON V_QUOTE_VS_ACTUAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
						                  V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
						                  INCOME_ONLY ON V_QUOTE_VS_ACTUAL.FNC_CODE = INCOME_ONLY.FNC_CODE AND 
						                  JOB_COMPONENT.JOB_NUMBER = INCOME_ONLY.JOB_NUMBER AND 
						                  JOB_COMPONENT.JOB_COMPONENT_NBR = INCOME_ONLY.JOB_COMPONENT_NBR LEFT OUTER JOIN
                                          FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID 
	                WHERE     (V_QUOTE_VS_ACTUAL.JOB_NUMBER = ''' + Cast(@JobNum AS Varchar(10)) + ''') AND (V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = ''' + Cast(@JobCompNum AS Varchar(5)) + ''') AND 
						                  (INCOME_ONLY.NON_BILL_FLAG = 1)'
					  
if @ExclEmpTime = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''E'''
End
if @ExclVendor = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''V'''
End
if @ExclIO = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''I'''
End
								   
	        SELECT @sqlNB = @sqlNB + ' GROUP BY'
	                            if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                                Begin
			                                    SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, FUNCTIONS.FNC_TYPE'
			                                End
			                          Else
			                                Begin
			                                    SELECT @sqlNB = @sqlNB + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, FUNCTIONS.FNC_TYPE'
			                                End	
					                  if @GroupOption = 'H'
					                    Begin
					                        SELECT @sqlNB = @sqlNB + ', FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ'
					                    End	  
                                      if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                        Begin
	                                        SELECT @sqlNB = @sqlNB + ''
                                        End      
                                      Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                        Begin
	                                        SELECT @sqlNB = @sqlNB + ''
                                        End       
                                      Else
                                        Begin
	                                        SELECT @sqlNB = @sqlNB + ', FNC_ORDER'
                                        End   
                    print @sqlNB
	                EXEC (@sqlNB)	
                	
        SET @sqlNB = ''

        SELECT @sqlNB = 'INSERT INTO #qva_NB SELECT ''' + Cast(@EstNo AS Varchar(10)) + ''', ''' + Cast(@EstCompNo AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(5)) + ''','
                             if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                     Begin
			                        SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, '''','
			                     End
			                 Else
			                     Begin
			                        SELECT @sqlNB = @sqlNB + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FNC_DESCRIPTION,'
			                     End
			                 if @GroupOption = 'T'
					            Begin
					                SELECT @sqlNB = @sqlNB + ' FUNCTIONS.FNC_TYPE,'
					            End
					         else
					            Begin
					                SELECT @sqlNB = @sqlNB + ' '''' AS FNC_TYPE,'
					            End
					         if @GroupOption = 'H'
					            Begin
					                SELECT @sqlNB = @sqlNB + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					            End
					         else
					            Begin
					                SELECT @sqlNB = @sqlNB + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
					            End
					         if @GroupOption = 'I'
					            Begin
					                SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ''I''
                                                               WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ''O''
                                                               WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ''O''
                                                               WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN ''C''
                                                               ELSE ''I'' END AS INOUT,'
					            End
					         else
					            Begin
					                SELECT @sqlNB = @sqlNB + ' ''I'' AS INOUT,'
					            End                
                             if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ' 0 AS FNC_ORDER,'
                                End      
                             Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ' 0 AS FNC_ORDER,'
                                End 
                             Else
                                Begin
	                                SELECT @sqlNB = @sqlNB + ' ISNULL(FUNCTIONS.FNC_ORDER,0) AS FNC_ORDER,'
                                End          
        SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ISNULL(SUM(AP_PRODUCTION.EXT_MARKUP_AMT), 0.00)
						          WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Markup,
						          CASE WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ISNULL(SUM(AP_PRODUCTION.EXT_CITY_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_STATE_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_COUNTY_RESALE), 0.00)
						          WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Tax,
						          CASE WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ISNULL(SUM(AP_PRODUCTION.AP_PROD_EXT_AMT), 0.00)
						          WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS NB_Amount
	        FROM         FUNCTIONS INNER JOIN
						          V_QUOTE_VS_ACTUAL ON FUNCTIONS.FNC_CODE = V_QUOTE_VS_ACTUAL.FNC_CODE INNER JOIN
						          JOB_COMPONENT ON V_QUOTE_VS_ACTUAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
						          V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
						          AP_PRODUCTION ON V_QUOTE_VS_ACTUAL.FNC_CODE = AP_PRODUCTION.FNC_CODE AND 
						          JOB_COMPONENT.JOB_NUMBER = AP_PRODUCTION.JOB_NUMBER AND 
						          JOB_COMPONENT.JOB_COMPONENT_NBR = AP_PRODUCTION.JOB_COMPONENT_NBR LEFT OUTER JOIN
                                  FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID 
	        WHERE     (V_QUOTE_VS_ACTUAL.JOB_NUMBER = ''' + Cast(@JobNum AS Varchar(10)) + ''') AND (V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = ''' + Cast(@JobCompNum AS Varchar(5)) + ''') AND 
						          (AP_PRODUCTION.AP_PROD_NOBILL_FLG = 1)'
					  
if @ExclEmpTime = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''E'''
End
if @ExclVendor = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''V'''
End
if @ExclIO = 1
Begin
	SELECT @sqlNB = @sqlNB + ' AND FUNCTIONS.FNC_TYPE <> ''I'''
End
								   
	        SELECT @sqlNB = @sqlNB + ' GROUP BY'
	                    if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                        Begin
			                            SELECT @sqlNB = @sqlNB + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, FUNCTIONS.FNC_TYPE'
			                        End
			                  Else
			                        Begin
			                            SELECT @sqlNB = @sqlNB + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, FUNCTIONS.FNC_TYPE'
			                        End	
					          if @GroupOption = 'H'
					            Begin
					                SELECT @sqlNB = @sqlNB + ', FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ'
					            End	  
                              if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ''
                                End      
                              Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                Begin
	                                SELECT @sqlNB = @sqlNB + ''
                                End       
                              Else
                                Begin
	                                SELECT @sqlNB = @sqlNB + ', FNC_ORDER'
                                End   
            print @sqlNB
	        EXEC (@sqlNB)
                SET @sqlNB = ''
                
                
           
           SELECT @sqlactual = ' INSERT INTO #actual_total SELECT ''' + Cast(@EstNo AS Varchar(10)) + ''', ''' + Cast(@EstCompNo AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(5)) + ''','
                     if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			             Begin
			                SELECT @sqlactual = @sqlactual + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, '''','
			             End
			         Else
			             Begin
			                SELECT @sqlactual = @sqlactual + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FNC_DESCRIPTION,'
			             End			        
			         if @GroupOption = 'T'
					    Begin
					        SELECT @sqlactual = @sqlactual + ' FUNCTIONS.FNC_TYPE,'
					    End
					 else
					    Begin
					        SELECT @sqlactual = @sqlactual + ' '''' AS FNC_TYPE,'
					    End					   
					 if @GroupOption = 'H'
					    Begin
					        SELECT @sqlactual = @sqlactual + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					    End
					 else
					    Begin
					        SELECT @sqlactual = @sqlactual + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
					    End					 
					 if @GroupOption = 'I'
					    Begin
					        SELECT @sqlactual = @sqlactual + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ''I''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN ''C''
                                                       ELSE ''I'' END AS INOUT,'
					    End
					 else
					    Begin
					        SELECT @sqlactual = @sqlactual + ' ''I'' AS INOUT,'
					    End
					 if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sqlactual = @sqlactual + ' 0 AS FNC_ORDER,'
                        End      
                     Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sqlactual = @sqlactual + ' 0 AS FNC_ORDER,'
                        End 
                     Else
                        Begin
	                        SELECT @sqlactual = @sqlactual + ' ISNULL(FUNCTIONS.FNC_ORDER,0) AS FNC_ORDER,'
                        End         
                           
            SELECT @sqlactual = @sqlactual + ' CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ISNULL(SUM(EMP_TIME_DTL.EXT_MARKUP_AMT), 0.00)  
						   WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ISNULL(SUM(INCOME_ONLY.EXT_MARKUP_AMT), 0.00) 
					       WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ISNULL(SUM(AP_PRODUCTION.EXT_MARKUP_AMT), 0.00) 
					       WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS Actual_Markup, 
					       CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ISNULL(SUM(EMP_TIME_DTL.EXT_CITY_RESALE), 0.00) + ISNULL(SUM(EMP_TIME_DTL.EXT_STATE_RESALE), 0.00) + ISNULL(SUM(EMP_TIME_DTL.EXT_COUNTY_RESALE), 0.00)  
						   WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ISNULL(SUM(INCOME_ONLY.EXT_CITY_RESALE), 0.00) + ISNULL(SUM(INCOME_ONLY.EXT_STATE_RESALE), 0.00) + ISNULL(SUM(INCOME_ONLY.EXT_COUNTY_RESALE), 0.00)   
					       WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ISNULL(SUM(AP_PRODUCTION.EXT_CITY_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_STATE_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_COUNTY_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_NONRESALE_TAX), 0.00) 
					       WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN 0.00 END AS Actual_Tax,
					       CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ISNULL(SUM(EMP_TIME_DTL.TOTAL_BILL), 0.00)  
						                       WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ISNULL(SUM(INCOME_ONLY.IO_AMOUNT), 0.00) 
					                           WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ISNULL(SUM(AP_PRODUCTION.AP_PROD_EXT_AMT), 0.00) 
					                           WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN ISNULL(SUM(CLIENT_OOP.AMOUNT), 0.00) END AS Actual_Total'
            SELECT @sqlactualFrom = ' FROM FUNCTIONS INNER JOIN
                                          V_QUOTE_VS_ACTUAL ON FUNCTIONS.FNC_CODE = V_QUOTE_VS_ACTUAL.FNC_CODE INNER JOIN
                                          JOB_COMPONENT ON V_QUOTE_VS_ACTUAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
                                          V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
                                          EMP_TIME_DTL ON JOB_COMPONENT.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER AND 
                                          JOB_COMPONENT.JOB_COMPONENT_NBR = EMP_TIME_DTL.JOB_COMPONENT_NBR AND 
                                          V_QUOTE_VS_ACTUAL.FNC_CODE = EMP_TIME_DTL.FNC_CODE LEFT OUTER JOIN
                                          INCOME_ONLY ON JOB_COMPONENT.JOB_NUMBER = INCOME_ONLY.JOB_NUMBER AND 
                                          JOB_COMPONENT.JOB_COMPONENT_NBR = INCOME_ONLY.JOB_COMPONENT_NBR AND 
                                          V_QUOTE_VS_ACTUAL.FNC_CODE = INCOME_ONLY.FNC_CODE LEFT OUTER JOIN
                                          AP_PRODUCTION ON JOB_COMPONENT.JOB_NUMBER = AP_PRODUCTION.JOB_NUMBER AND 
                                          JOB_COMPONENT.JOB_COMPONENT_NBR = AP_PRODUCTION.JOB_COMPONENT_NBR AND 
                                          V_QUOTE_VS_ACTUAL.FNC_CODE = AP_PRODUCTION.FNC_CODE LEFT OUTER JOIN
                                          CLIENT_OOP ON JOB_COMPONENT.JOB_NUMBER = CLIENT_OOP.JOB_NUMBER AND 
                                          JOB_COMPONENT.JOB_COMPONENT_NBR = CLIENT_OOP.JOB_COMPONENT_NBR AND 
                                          V_QUOTE_VS_ACTUAL.FNC_CODE = CLIENT_OOP.FNC_CODE LEFT OUTER JOIN
                                          FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID'
             SELECT @sqlactualwhere = ' WHERE  (V_QUOTE_VS_ACTUAL.JOB_NUMBER = ''' + Cast(@JobNum AS Varchar(10)) + ''') AND (V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = ''' + Cast(@JobCompNum AS Varchar(5)) + ''')'
					  
if @ExclEmpTime = 1
Begin
	SELECT @sqlactualwhere = @sqlactualwhere + ' AND FUNCTIONS.FNC_TYPE <> ''E'''
End
if @ExclVendor = 1
Begin
	SELECT @sqlactualwhere = @sqlactualwhere + ' AND FUNCTIONS.FNC_TYPE <> ''V'''
End
if @ExclIO = 1
Begin
	SELECT @sqlactualwhere = @sqlactualwhere + ' AND FUNCTIONS.FNC_TYPE <> ''I'''
End
								   
	        SELECT @sqlactualwhere = @sqlactualwhere + ' GROUP BY'
	                        if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
			                            Begin
			                                SELECT @sqlactualwhere = @sqlactualwhere + ' CASE WHEN FUNCTIONS.FNC_CONSOLIDATION IS NULL THEN V_QUOTE_VS_ACTUAL.FNC_CODE ELSE FUNCTIONS.FNC_CONSOLIDATION END, FUNCTIONS.FNC_TYPE'
			                            End
			                      Else
			                            Begin
			                                SELECT @sqlactualwhere = @sqlactualwhere + ' V_QUOTE_VS_ACTUAL.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, FUNCTIONS.FNC_TYPE'
			                            End	
					              if @GroupOption = 'H'
					                Begin
					                    SELECT @sqlactualwhere = @sqlactualwhere + ', FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ'
					                End	  
                                  if @SortOption = 'O' AND ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                    Begin
	                                    SELECT @sqlactualwhere = @sqlactualwhere + ''
                                    End      
                                  Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                                    Begin
	                                    SELECT @sqlactualwhere = @sqlactualwhere + ''
                                    End       
                                  Else
                                    Begin
	                                    SELECT @sqlactualwhere = @sqlactualwhere + ', FNC_ORDER'
                                    End        
             print @sqlactual + @sqlactualFrom + @sqlactualwhere
	        EXEC (@sqlactual + @sqlactualFrom + @sqlactualwhere)
                SET @sqlactual = ''                
              
            
            SET @Count = @Count + 1
        END
    
                    
    End             
 
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
                      ISNULL(CDP_CONTACT_HDR.CONT_ZIP,''''), ISNULL(CDP_CONTACT_HDR.CONT_COUNTRY,''''),
					  ISNULL(CDP_CONTACT_HDR.CONT_TELEPHONE,''''),ISNULL(CDP_CONTACT_HDR.CONT_FAX,''''),ISNULL(CDP_CONTACT_HDR.EMAIL_ADDRESS,''''),ISNULL(CDP_CONTACT_HDR.CONT_TITLE,''''), 0, 0, CAST((Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(3))+''''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))) AS int),'                      
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
                    SELECT @sql2 = @sql2 + ' ISNULL(JOB_COMPONENT.JOB_FIRST_USE_DATE,''''), EL.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME,'          
					if (@RevNum = 0 AND @CountRev > 1) OR (@RevNum = 0 AND @crevcombined = 1)
						Begin
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End						
						End
					Else if @RevNum > 0 AND @CountRev > 1 AND @RevNum <> @MaxRev
					    Begin
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0'
							End						
					    End
					Else if @RevNum > 0 AND @CountRev > 1 AND @RevNum = @MaxRev
					    Begin
					    	if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 0'
							End			
						End
					Else
						Begin
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + (SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) + (SUM(E.EXT_CONTINGENCY) + SUM(E.EXT_MU_CONT)),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)) + SUM(E.EXT_MU_CONT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(E.EXT_MARKUP_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT) + SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' 0.00, SUM(E.EST_REV_EXT_AMT),
														 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))), 0, 0.00, 0.00, 0.00, 0.00, 1'
							End					
						End  
SELECT @sql2 = @sql2 + ', 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
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
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY,CDP_CONTACT_HDR.CONT_TELEPHONE,CDP_CONTACT_HDR.CONT_FAX,CDP_CONTACT_HDR.EMAIL_ADDRESS,CDP_CONTACT_HDR.CONT_TITLE, JOB_COMPONENT.JOB_FIRST_USE_DATE, EL.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME'
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
SELECT @sqlactual = ' UNION ALL SELECT ESTIMATE_NUMBER, NULL, EST_COMPONENT_NBR, NULL, EST_QUOTE_NBR, NULL, JOB_NUMBER, NULL, JOB_COMPONENT_NBR, NULL, EST_REV_NBR, FNC_CODE, FNC_DESCRIPTION,
			              '''', '''', '''', 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, FNC_TYPE, 0, FNC_TYPE, 0, '''',
			              FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ, NULL, 
			              NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '''', '''', '''', '''', 0.00, 0, 0, NULL, NULL, 
			              NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, INOUT, FNC_ORDER, NULL,NULL,NULL,NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 
			              0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0, Actual_Markup, Actual_Tax, Actual_Total, 0.00, 0.00, 0.00	
	FROM #actual_total WHERE (ESTIMATE_NUMBER = ''' + Cast(@EstNum AS Varchar(10)) + ''') AND (EST_COMPONENT_NBR = ''' + Cast(@EstCompNum AS Varchar(5)) + ''') AND 
                      (EST_QUOTE_NBR = ''' + Cast(@QuoteNum AS Varchar(5)) + ''') AND (EST_REV_NBR = ''' + Cast(@RevNum AS Varchar(5)) + ''')'

SELECT @sqlNB = ' UNION ALL SELECT ESTIMATE_NUMBER, NULL, EST_COMPONENT_NBR, NULL, EST_QUOTE_NBR, NULL, JOB_NUMBER, NULL, JOB_COMPONENT_NBR, NULL, EST_REV_NBR, FNC_CODE, FNC_DESCRIPTION,
			              '''', '''', '''', 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, FNC_TYPE, 0, FNC_TYPE, 0, '''',
			              FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ, NULL, 
			              NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '''', '''', '''', '''', 0.00, 0, 0, NULL, NULL, 
			              NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, INOUT, FNC_ORDER, NULL,NULL,NULL,NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 
			              0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, NB_Markup, NB_Tax, NB_Amount	
	FROM #qva_NB WHERE (ESTIMATE_NUMBER = ''' + Cast(@EstNum AS Varchar(10)) + ''') AND (EST_COMPONENT_NBR = ''' + Cast(@EstCompNum AS Varchar(5)) + ''') AND 
                      (EST_QUOTE_NBR = ''' + Cast(@QuoteNum AS Varchar(5)) + ''') AND (EST_REV_NBR = ''' + Cast(@RevNum AS Varchar(5)) + ''')'


if @ReportType = 3 Or @ReportType = 4
    Begin
        print @sqlactual	
	    EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby + @sqlactual + @sqlNB)
	    print @sqlNB
    End
Else
    Begin
        print @sql2 + @sqlfrom + @sqlwhere + @sqlgroupby	
	    EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby)	    
    End

	--print @sql2 + @sqlfrom + @sqlwhere + @sqlgroupby
	--EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby)


                 
SELECT DISTINCT @JobQty = JOB_QTY
FROM #estPrint 
WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                      (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
                      
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
     
if @RevNum = 0 AND @CountRev > 1
	Begin
	--SELECT 1
		UPDATE #estPrint
        SET ORIGINAL_LINE_TOTAL = @sumCPU, ORIGINAL_LINE_CONT_TOTAL = @sumCT, ORIGINAL_JOB_QTY = @JobQty
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
	End
Else if @RevNum > 0 AND @CountRev > 1 AND @RevNum <> @MaxRev
	Begin
	--SELECT 2
		UPDATE #estPrint
        SET ORIGINAL_LINE_TOTAL = @sumCPU, ORIGINAL_LINE_CONT_TOTAL = @sumCT, ORIGINAL_JOB_QTY = @JobQty
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum)
	End
Else if @RevNum > 0 AND @CountRev > 1 AND @RevNum = @MaxRev
	Begin
	--SELECT 3
		UPDATE #estPrint
        SET REVISED_LINE_TOTAL = @sumCPU, REVISED_LINE_CONT_TOTAL = @sumCT, REVISED_JOB_QTY = @JobQty
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum)
	End
Else
	Begin
	--SELECT 4
		UPDATE #estPrint
        SET REVISED_LINE_TOTAL = @sumCPU, REVISED_LINE_CONT_TOTAL = @sumCT, REVISED_JOB_QTY = @JobQty
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum)
	End     

--if @RevNum = 0
--	Begin
--		
--	End 
--Else
--	Begin
--	 
--	End 
		
 SET @RowCount = @RowCount + 1
END
--SELECT * FROM #estPrint

SELECT @NumberRecords = COUNT(*) FROM #estPrint
        SET @RowCount = 1  
                
        INSERT INTO #quote
        SELECT DISTINCT 0,'', EST_QUOTE_NBR, '' FROM #estPrint        
        
        SELECT @Records = COUNT(*) FROM #quote
        SET @Count = 1
        --SELECT DISTINCT @EstNo = ESTIMATE_NUMBER, @EstCompNo = EST_COMPONENT_NBR,
        --FROM #estPrint
        --WHERE ESTIMATE_NUMBER IS NOT NULL
        
        WHILE @Count <= @Records
        BEGIN
        
            SELECT @QuoteNum = QuoteNum--, @QuoteDesc = QuoteDesc, @CompNum = CompNum, @CompDesc = CompDesc
            FROM #quote
            WHERE RowID = @Count
            
            --SELECT * FROM #quote
            --SELECT @QuoteNum
            SELECT DISTINCT @EstDesc = EST_LOG_DESC, @EstCompDesc = EST_COMP_DESC, @EstQuoteDesc = EST_QUOTE_DESC, @JobDescp = JOB_DESC, @JobCompDesc = JOB_COMP_DESC,
                    @JobCliRef = JOB_CLI_REF, @SCCode = SC_CODE, @SCDesc = SC_DESCRIPTION, @AccE = AE, @ClCode = CL_CODE, @ClName = CL_NAME,
                    @DivCode = DIV_CODE, @DiviName = DIV_NAME, @PrdCode = PRD_CODE, @PrdDesc = PRD_DESCRIPTION, @CDPContactID = CDP_CONTACT_ID, @ContCode2 = CONT_CODE,
                    @ContFML2 = CONT_FML, @ContA12 = CONT_ADDRESS1, @ContA22 = CONT_ADDRESS2, @ContCity2 = CONT_CITY, @ContState2 = CONT_STATE, @ContZip2 = CONT_ZIP,
                    @ContCountry2 = CONT_COUNTRY, @ECQ = ESTCOMPQUOTE, @OneR = ONE_REVISION
             FROM #estPrint
             WHERE EST_QUOTE_NBR = @QuoteNum
             
            -- SELECT @EstDesc, @EstCompDesc, @EstQuoteDesc, @JobDescp, @JobCompDesc,
            --        @JobCliRef, @SCCode, @SCDesc, @AccE, @ClCode, @ClName,
            --        @DivCode, @DiviName, @PrdCode, @PrdDesc, @CDPContactID, @ContCode,
            --        @ContFML, @ContA1, @ContA2, @ContCity, @ContState, @ContZip,
            --        @ECQ, @OneR
            
            WHILE @RowCount <= @NumberRecords
            BEGIN                

             UPDATE #estPrint 
             SET EST_LOG_DESC = @EstDesc, EST_COMP_DESC = @EstCompDesc, EST_QUOTE_DESC = @EstQuoteDesc, JOB_DESC = @JobDescp, JOB_COMP_DESC = @JobCompDesc,
                 JOB_CLI_REF = @JobCliRef, SC_CODE = @SCCode, SC_DESCRIPTION = @SCDesc, AE = @AccE, CL_CODE = @ClCode, CL_NAME = @ClName,
                 DIV_CODE = @DivCode, DIV_NAME = @DiviName, PRD_CODE = @PrdCode, PRD_DESCRIPTION = @PrdDesc, CDP_CONTACT_ID = @CDPContactID, CONT_CODE = @ContCode2,
                 CONT_FML = @ContFML2, CONT_ADDRESS1 = @ContA12, CONT_ADDRESS2 = @ContA22, CONT_CITY = @ContCity2, CONT_STATE = @ContState2, CONT_ZIP = @ContZip2,
                 CONT_COUNTRY = @ContCountry2, ESTCOMPQUOTE = @ECQ, ONE_REVISION = @OneR
             WHERE EST_LOG_DESC IS NULL AND EST_QUOTE_NBR = @QuoteNum

            SET @RowCount = @RowCount + 1
            END
            
            SET @RowCount = 1
            SET @Count = @Count + 1
        END

SELECT @sql = 'INSERT INTO #estPrintData 
				SELECT ESTIMATE_NUMBER, EST_LOG_DESC, EST_COMPONENT_NBR, EST_COMP_DESC, EST_QUOTE_NBR, EST_QUOTE_DESC, JOB_NUMBER,
				JOB_DESC, JOB_COMPONENT_NBR, JOB_COMP_DESC, FNC_CODE, FNC_DESCRIPTION, '''' AS EST_FNC_COMMENT,	'''' AS EST_REV_SUP_BY_NTE,
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
SELECT @sql = @sql + ' JOB_CLI_REF, SC_CODE, SC_DESCRIPTION, AE, CL_CODE, CL_NAME, DIV_CODE, DIV_NAME, PRD_CODE, PRD_DESCRIPTION, '''' AS EST_LOG_COMMENT, '''' AS EST_COMP_COMMENT, '''' AS EST_QTE_COMMENT,	'''' AS EST_REV_COMMENT,
				 0, CDP_CONTACT_ID, CONT_CODE, CONT_FML, CONT_ADDRESS1, CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY,CONT_TELEPHONE,CONT_FAX,EMAIL_ADDRESS,CONT_TITLE, 0, 0, ESTCOMPQUOTE, INOUT, FNC_ORDER, JOB_DUE_DATE,CMP_IDENTIFIER, CMP_CODE,CMP_NAME, SUM(ORIGINAL_AMT) AS ORIGINAL_AMT, SUM(REVISED_AMT) AS REVISED_AMT,				 
				 SUM(FINAL_ACTUAL) AS FINAL_ACTUAL, SUM(ORIGINAL_MARKUP_AMT) AS ORIGINAL_MARKUP_AMT, SUM(ORIGINAL_CONT) AS ORIGINAL_CONT, SUM(ORIGINAL_MU_CONT) AS ORIGINAL_MU_CONT, SUM(ORIGINAL_TAX) AS ORIGINAL_TAX, MAX(ORIGINAL_JOB_QTY) AS ORIGINAL_JOB_QTY, SUM(ORIGINAL_CPU) AS ORIGINAL_CPU, SUM(ORIGINAL_CPM) AS ORIGINAL_CPM,
				 MAX(ORIGINAL_LINE_TOTAL) AS ORIGINAL_LINE_TOTAL, MAX(ORIGINAL_LINE_CONT_TOTAL) AS ORIGINAL_LINE_CONT_TOTAL, SUM(REVISED_MARKUP_AMT) AS REVISED_MARKUP_AMT, SUM(REVISED_CONT) AS REVISED_CONT,
				 SUM(REVISED_MU_CONT) AS REVISED_MU_CONT, SUM(REVISED_TAX) AS REVISED_TAX, MAX(REVISED_JOB_QTY) AS REVISED_JOB_QTY, SUM(REVISED_CPU) AS REVISED_CPU, SUM(REVISED_CPM) AS REVISED_CPM, MAX(REVISED_LINE_TOTAL) AS REVISED_LINE_TOTAL, MAX(REVISED_LINE_CONT_TOTAL) AS REVISED_LINE_CONT_TOTAL, ONE_REVISION, 0, SUM(Actual_Markup), SUM(Actual_Tax), SUM(Actual_Total), SUM(NB_Markup), SUM(NB_Tax), SUM(NB_Total)'
				 
--if @CountRev > 1
--    Begin
--        SELECT @sql = @sql + ' ,0' --more than one revision
--    End
--Else
--    Begin
--        SELECT @sql = @sql + ' ,1' --one revision
--    End
SELECT @sqlfrom2 = ' FROM #estPrint' 
SELECT @sqlwhere2 = ' WHERE 1=1'

if @SuppressZero = 1 and @PrintID = 0
Begin
	SELECT @sqlwhere2 = @sqlwhere2 + ' AND (EST_REV_EXT_AMT <> 0 OR Actual_Total <> 0 OR NB_Total <> 0)'
End

if @SuppressZero = 0 and @PrintID <> 0
Begin
	SELECT @sqlwhere2 = @sqlwhere2 + ' AND (EST_REV_EXT_AMT <> 0 OR Actual_Total <> 0 OR NB_Total <> 0)'
End

SELECT @sqlgroupby2 = ' GROUP BY ESTIMATE_NUMBER, EST_LOG_DESC, EST_COMPONENT_NBR, EST_COMP_DESC, EST_QUOTE_NBR, EST_QUOTE_DESC, JOB_NUMBER, JOB_DESC, JOB_COMPONENT_NBR, JOB_COMP_DESC, FNC_CODE, FNC_DESCRIPTION,
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
                      CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY,CONT_TELEPHONE,CONT_FAX,EMAIL_ADDRESS,CONT_TITLE, ESTCOMPQUOTE, INOUT, FNC_ORDER, ONE_REVISION, JOB_DUE_DATE,CMP_IDENTIFIER,CMP_CODE,CMP_NAME'

SELECT @sqlgroupby2 = @sqlgroupby2 + ' ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR'

if @GroupOption = 'T'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , FNC_TYPE'
End
if @GroupOption = 'H'
Begin
	SELECT @sqlgroupby2 = @sqlgroupby2 + ' , FNC_HEADING_SEQ, FNC_HEADING_DESC'
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

print @sql + @sqlfrom2 + @sqlwhere2 + @sqlgroupby2
EXEC (@sql + @sqlfrom2 + @sqlwhere2 + @sqlgroupby2)

--select * from #estPrintData

        SELECT @NumberRecords = COUNT(*) FROM #estPrintData
        SET @RowCount = 1


        WHILE @RowCount <= @NumberRecords
        BEGIN
          SET @sumCPU = 0
		 SET @sumCT = 0
		 SET @JobQty = 0

		 SELECT @EstNum = ESTIMATE_NUMBER, @EstCompNum = EST_COMPONENT_NBR, @QuoteNum = EST_QUOTE_NBR
		 FROM #estPrintData
		 WHERE RowID = @RowCount

		 UPDATE #estPrintData
		 SET JOB_DUE_DATE = CASE WHEN JOB_DUE_DATE = '' THEN NULL ELSE JOB_DUE_DATE END
			
         SELECT @func = FNC_CODE
         FROM #estPrintData
         WHERE RowID = @RowCount

         SELECT @funcdesc = FNC_DESCRIPTION, @funcorder = FNC_ORDER
         FROM FUNCTIONS
         WHERE FNC_CODE = @func
         
        UPDATE #estPrintData 
        SET FNC_DESCRIPTION = @funcdesc, FNC_ORDER = @funcorder
        WHERE FNC_CODE = @func

		SELECT @sumCPU = ORIGINAL_LINE_TOTAL, @sumCT = ORIGINAL_LINE_CONT_TOTAL
		FROM #estPrintData
		WHERE ORIGINAL_LINE_TOTAL <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)

		UPDATE #estPrintData
		SET ORIGINAL_LINE_TOTAL = @sumCPU
		WHERE ORIGINAL_LINE_TOTAL = 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)

		SELECT @JobQty = ORIGINAL_JOB_QTY
		FROM #estPrintData
		WHERE ORIGINAL_JOB_QTY <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)

		UPDATE #estPrintData
		SET ORIGINAL_JOB_QTY = @JobQty
		WHERE ORIGINAL_JOB_QTY = 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)
		
		SET @CPU = 0
		if @JobQty <> 0
		Begin
				UPDATE #estPrintData
				SET ORIGINAL_CPU = (@sumCPU / @JobQty)
				WHERE ORIGINAL_LINE_TOTAL <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)
				SET @CPU = (@sumCPU / @JobQty)
		End 
		if @JobQty <> 0
		Begin
					UPDATE #estPrintData
					SET ORIGINAL_CPM = (@sumCPU + @sumCT) / (CAST(@JobQty AS DECIMAL(15,3)) / 1000) 
					WHERE ORIGINAL_LINE_TOTAL <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)
		End         

		SET @sumCPU = 0
		SET @sumCT = 0
		SET @JobQty = 0

		SELECT @sumCPU = REVISED_LINE_TOTAL, @sumCT = REVISED_LINE_CONT_TOTAL
		FROM #estPrintData
		WHERE REVISED_LINE_TOTAL <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)

		UPDATE #estPrintData
		SET REVISED_LINE_TOTAL = @sumCPU
		WHERE REVISED_LINE_TOTAL = 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)

		SELECT @JobQty = REVISED_JOB_QTY
		FROM #estPrintData
		WHERE REVISED_JOB_QTY <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)

		UPDATE #estPrintData
		SET REVISED_JOB_QTY = @JobQty
		WHERE REVISED_JOB_QTY = 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)
		
		SET @CPU = 0
		if @JobQty <> 0
		Begin
				UPDATE #estPrintData
				SET REVISED_CPU = (@sumCPU / @JobQty)
				WHERE REVISED_LINE_TOTAL <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)
				SET @CPU = (@sumCPU / @JobQty)
		End 
		if @JobQty <> 0
		Begin
					UPDATE #estPrintData
					SET REVISED_CPM = (@sumCPU + @sumCT) / (CAST(@JobQty AS DECIMAL(15,3)) / 1000) 
					WHERE REVISED_LINE_TOTAL <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)
				
		End         

        SET @RowCount = @RowCount + 1
        END
        
        SET @jobnumber = 0
        SET @jobdesc = ''
        SET @jobclientref = ''
        SELECT DISTINCT @jobnumber = JOB_NUMBER, @jobdesc = ISNULL(JOB_DESC,''), @jobclientref = ISNULL(JOB_CLI_REF,'')
         FROM #estPrint
         WHERE JOB_NUMBER IS NOT NULL
       --SELECT @jobnumber
                
           
        
        SELECT DISTINCT @cdpid = ISNULL(CDP_CONTACT_ID, 0), @contcode = ISNULL(CONT_CODE, ''), @contfml = ISNULL(CONT_FML, ''),
		 @conta1 = ISNULL(CONT_ADDRESS1, ''), @conta2 = ISNULL(CONT_ADDRESS2, ''), @contcity = ISNULL(CONT_CITY, ''),
		 @contstate = ISNULL(CONT_STATE, ''), @contzip = ISNULL(CONT_ZIP, ''), @contcountry = ISNULL(CONT_COUNTRY,''),
		 @contphone = ISNULL(CONT_TELEPHONE,''), @contfax = ISNULL(CONT_FAX,''), @contemail = ISNULL(EMAIL_ADDRESS,''),
		 @conttitle = ISNULL(CONT_TITLE,'')
        FROM #estPrint
        WHERE CDP_CONTACT_ID IS NOT NULL
        --SELECT * FROM #estPrintData
        if @crevcombined = 1
            Begin
                UPDATE #estPrintData 
                SET ONE_REVISION = 0
            End

        SELECT @sql3 = 'INSERT INTO #estPrintCombined SELECT ESTIMATE_NUMBER, EST_LOG_DESC, EST_QUOTE_NBR, FNC_CODE, FNC_DESCRIPTION, ''' + Cast(@jobnumber AS Varchar(7)) + ''' AS JOB_NUMBER, '''' AS JOB_DESC,'
		SELECT @sql3 = @sql3 + ' '''','''','''','''',EST_FNC_TYPE, EMPLOYEE_TITLE_ID, FNC_TYPE,'
                        if @GroupOption = 'P'
					            Begin
					                SELECT @sql3 = @sql3 + ' EST_PHASE_ID, EST_PHASE_DESC,'
					            End
					         else
					            Begin
					                SELECT @sql3 = @sql3 + ' '''' as EST_PHASE_ID, '''' as EST_PHASE_DESC,'
					            End 
			            if @GroupOption = 'H'
					            Begin
					                SELECT @sql3 = @sql3 + ' (SELECT RowID FROM #funcheading WHERE #estPrintData.FNC_HEADING_ID = #funcheading.FuncHeadingID), FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ,'
					            End
					         else
					            Begin
					                SELECT @sql3 = @sql3 + ' 0,0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
					            End 
					                
        SELECT @sql3 = @sql3 + ' ''' + @jobclientref + ''' AS JOB_CLI_REF, SC_CODE, SC_DESCRIPTION, CL_CODE, CL_NAME, DIV_CODE, DIV_NAME, PRD_CODE, PRD_DESCRIPTION,'''','''','''','''','''','''','''','''','''','''','
		SELECT @sql3 = @sql3 + ' SUM(JOB_QTY) AS JOB_QTY, ''' + Cast(@cdpid AS Varchar(5)) + ''' AS CDP_CONTACT_ID, '''' AS CONT_CODE, '''' AS CONT_FML, '''' AS CONT_ADDRESS1,
				         '''' AS CONT_ADDRESS2, '''' AS CONT_CITY, '''' AS CONT_STATE, '''' AS CONT_ZIP, '''' AS CONT_COUNTRY,
						'''' AS EstimateContactPhone,'''' AS EstimateContactFax,'''' AS EstimateContactEmail,'''' AS EstimateContactTitle, SUM(CPU) AS CPU, SUM(CPM) AS CPM, 
				         ESTCOMPQUOTE, INOUT, FNC_ORDER,CMP_IDENTIFIER, CMP_CODE, CMP_NAME, SUM(ORIGINAL_AMT) AS ORIGINAL_AMT, SUM(REVISED_AMT) AS REVISED_AMT, SUM(FINAL_ACTUAL) AS FINAL_ACTUAL, SUM(ORIGINAL_MARKUP_AMT) AS ORIGINAL_MARKUP_AMT,
				         SUM(ORIGINAL_CONT) AS ORIGINAL_CONT, SUM(ORIGINAL_MU_CONT) AS ORIGINAL_MU_CONT, SUM(ORIGINAL_TAX) AS ORIGINAL_TAX, MAX(ORIGINAL_JOB_QTY) AS ORIGINAL_JOB_QTY, SUM(ORIGINAL_CPU) AS ORIGINAL_CPU, SUM(ORIGINAL_CPM) AS ORIGINAL_CPM, MAX(ORIGINAL_LINE_TOTAL) AS ORIGINAL_LINE_TOTAL, MAX(ORIGINAL_LINE_CONT_TOTAL) AS ORIGINAL_LINE_CONT_TOTAL, SUM(REVISED_MARKUP_AMT) AS REVISED_MARKUP_AMT, SUM(REVISED_CONT) AS REVISED_CONT,
				         SUM(REVISED_MU_CONT) AS REVISED_MU_CONT, SUM(REVISED_TAX) AS REVISED_TAX, MAX(REVISED_JOB_QTY) AS REVISED_JOB_QTY, SUM(REVISED_CPU) AS REVISED_CPU, SUM(REVISED_CPM) AS REVISED_CPM, MAX(REVISED_LINE_TOTAL) AS REVISED_LINE_TOTAL, MAX(REVISED_LINE_CONT_TOTAL) AS REVISED_LINE_CONT_TOTAL, ONE_REVISION, MAX_REVISION, SUM(Actual_Markup) AS Actual_Markup, SUM(Actual_Tax) AS Actual_Tax, SUM(Actual_Total) AS Actual_Total, SUM(NB_Markup) AS NB_Markup, SUM(NB_Tax) AS NB_Tax, SUM(NB_Total) AS NB_Total,
						 '''','''','''',0,0,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL
			          FROM #estPrintData WHERE 1=1'
   
        SELECT @sql3 = @sql3 + ' GROUP BY ESTIMATE_NUMBER, EST_LOG_DESC, EST_QUOTE_NBR, FNC_CODE, FNC_DESCRIPTION, EST_FNC_TYPE, EMPLOYEE_TITLE_ID, FNC_TYPE,'
                              if @GroupOption = 'P'
					            Begin
					                SELECT @sql3 = @sql3 + ' EST_PHASE_ID, EST_PHASE_DESC,'
					            End	
					          if @GroupOption = 'H'
					            Begin
					                SELECT @sql3 = @sql3 + ' FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ,'
					            End	  
        SELECT @sql3 = @sql3 + ' SC_CODE, SC_DESCRIPTION, CL_CODE, CL_NAME, DIV_CODE, 
					          DIV_NAME, PRD_CODE, PRD_DESCRIPTION, ESTCOMPQUOTE, INOUT, FNC_ORDER,CMP_IDENTIFIER, CMP_CODE, CMP_NAME, ONE_REVISION, MAX_REVISION'

		SELECT @sql3 = @sql3 + ' ORDER BY ESTIMATE_NUMBER, EST_QUOTE_NBR'

		if @GroupOption = 'T'
		Begin
			SELECT @sql3 = @sql3 + ' , FNC_TYPE'
		End
		if @GroupOption = 'H'
		Begin
			SELECT @sql3 = @sql3 + ' , FNC_HEADING_SEQ, FNC_HEADING_DESC'
		End
		if @GroupOption = 'P'
		Begin
			SELECT @sql3 = @sql3 + ' , EST_PHASE_DESC'
		End
		if @GroupOption = 'I'
		Begin
			SELECT @sql3 = @sql3 + ' , INOUT'
		End


		if @SortOption = 'C'
		Begin
			SELECT @sql3 = @sql3 + ' , FNC_CODE'
		End
		if @SortOption = 'O'
		Begin
			SELECT @sql3 = @sql3 + ' , FNC_ORDER'
		End
        					  
        print @sql3
        EXEC (@sql3)

if @PrintID = 0
BEGIN
	UPDATE #estPrintCombined SET FunctionOption = (SELECT FUNCTION_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrintCombined SET GroupOption = (SELECT GROUP_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrintCombined SET SortOption = (SELECT SORT_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrintCombined SET PrintNonBillable = (SELECT PRT_NONBILL FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
END
ELSE
BEGIN
	UPDATE #estPrintCombined SET FunctionOption = @FunctionOption
	UPDATE #estPrintCombined SET GroupOption = @GroupOption
	UPDATE #estPrintCombined SET SortOption = @SortOption
	UPDATE #estPrintCombined SET PrintNonBillable = @NonBill
END

UPDATE #estPrintCombined SET TaxSeparate = @TaxSeparate, CommissionSeparate = @CommMUSeparate, ContingencySeparate = @ContSeparate, IncludeContingency = @Contingency
UPDATE #estPrintCombined SET JobDescription = (SELECT TOP 1 JOB_DESC FROM JOB_LOG JL INNER JOIN JOB_COMPONENT JC ON JL.JOB_NUMBER = JC.JOB_NUMBER WHERE JC.ESTIMATE_NUMBER = #estPrintCombined.EstimateNumber)
UPDATE #estPrintCombined SET MaxRevision = (SELECT MAX(EST_REV_NBR) FROM ESTIMATE_REV_DET E WHERE (E.ESTIMATE_NUMBER = #estPrintCombined.EstimateNumber) AND (E.EST_QUOTE_NBR = #estPrintCombined.QuoteNumber))
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


SET @Font = '<span style="font-family: Arial; font-size: 9pt;">'
SET @Font2 = '</span>'

DECLARE @ENum int,@EComment varchar(MAX),@ECommentHtml varchar(MAX),@ECComment varchar(MAX),@ECCommentHtml varchar(MAX),
	@ECNum int,@QComment varchar(MAX),@QCommentHtml varchar(MAX),@RComment varchar(MAX),@RCommentHtml varchar(MAX),
	@QNum int,@DComment varchar(MAX),@DCommentHtml varchar(MAX),@SComment varchar(MAX),@SCommentHtml varchar(MAX),
	@RNum int, @FCode varchar(6), @ComponentComments varchar(MAX), @QuoteComments varchar(MAX), @DetailComments varchar(MAX), @SuppliedComments varchar(MAX),
	@ComponentCommentsHtml varchar(MAX), @QuoteCommentsHtml varchar(MAX), @DetailCommentsHtml varchar(MAX), @SuppliedCommentsHtml varchar(MAX), @RID int,
	@Comment varchar(MAX), @CommentHtml varchar(MAX), @QC varchar(MAX), @QCHtml varchar(MAX)

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
SET @QC = ''
SET @QCHtml = ''

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

	--SELECT * FROM #estComments

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

UPDATE #estPrintcombined SET EstimateComment = (SELECT TOP 1 EstComment FROM #estComments WHERE EstimateNumber = EstNo AND QuoteNumber = QuoteNo)
UPDATE #estPrintcombined SET EstimateCommentHtml = (SELECT TOP 1 CASE WHEN EstCommentHtml = '' THEN @Font + EstComment + @Font2 ELSE @Font + EstCommentHtml + @Font2 END FROM #estComments WHERE EstimateNumber = EstNo AND QuoteNumber = QuoteNo)
UPDATE #estPrintcombined SET EstimateComponentComment = @ComponentComments
UPDATE #estPrintcombined SET EstimateComponentCommentHtml = CASE WHEN @ComponentCommentsHtml = '' THEN @ComponentComments ELSE @Font + @ComponentCommentsHtml + @Font2 END

SELECT @NumberRecords = COUNT(*) FROM #estPrintcombined
SET @RowCount = 1
--SELECT * FROM #estComments

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @qteNum = QuoteNumber, @func = FunctionCode 
 FROM #estPrintcombined
 WHERE RowID = @RowCount

 SELECT @MaxRev = MAX(EST_REV_NBR)
 FROM ESTIMATE_REV_DET E
 WHERE (E.ESTIMATE_NUMBER = @EstNo) AND (E.EST_QUOTE_NBR = @qteNum)

 if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
 Begin
	SELECT @Count = Count(*)
	FROM #estComments
	WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func) AND (#estComments.RevNo = @MaxRev)
 End
 Else
 Begin
	SELECT @Count = Count(*)
	FROM #estComments
	WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func) AND (#estComments.RevNo = @MaxRev)
 End
 

 --SELECT @qteNum,@func
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
		WHERE (e.EstNo = @EstNo) AND (e.QuoteNo = @qteNum) AND (e.FunctionCode = @func OR e.ConsolidationCode = @func) AND (e.RevNo = @MaxRev)
		OPEN comment_col_cursor

		FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml

		WHILE ( @@FETCH_STATUS <> -1 )
		BEGIN
		
			if @QC <> @QComment
			BEGIN
				SELECT @QuoteComments = @QuoteComments + CHAR(13) + CHAR(10) + @QComment
			END
			SELECT @DetailComments = @DetailComments + CHAR(13) + CHAR(10) + @DComment
			SELECT @SuppliedComments = @SuppliedComments + CHAR(13) + CHAR(10) + @SComment		
			if @QCommentHtml <> '' AND @QCHtml <> @QCommentHtml
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
			SELECT @QC = @QComment
			SELECT @QCHtml = @QCommentHtml

			FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml
		END

		CLOSE comment_col_cursor
		DEALLOCATE comment_col_cursor

		if @QuoteCommentsHtml = ''
		Begin
			SELECT @QuoteCommentsHtml = @QuoteComments
		End

		if @DetailCommentsHtml = ''
		Begin
			SELECT @DetailCommentsHtml = @DetailComments
		End

		if @SuppliedCommentsHtml = ''
		Begin
			SELECT @SuppliedCommentsHtml = @SuppliedComments
		End

		UPDATE #estPrintcombined SET QuoteComment = @QuoteComments, DetailComments = @DetailComments, SuppliedByNotes = @SuppliedComments, QuoteCommentHtml = @Font + @QuoteCommentsHtml + @Font2, DetailCommentsHtml = @Font + @DetailCommentsHtml + @Font2, SuppliedByNotesHtml = @Font + @SuppliedCommentsHtml + @Font2 
		WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func

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
				DetailComment,DetailCommentHtml,SuppliedByNotes,SuppliedByNotesHtml FROM #estComments e WHERE (e.EstNo = @EstNo) AND (e.QuoteNo = @qteNum) AND (e.FunctionCode = @func) AND (e.RevNo = @MaxRev)
		OPEN comment_col_cursor

		FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml

		WHILE ( @@FETCH_STATUS <> -1 )
		BEGIN
		
			if @QC <> @QComment
			BEGIN
				SELECT @QuoteComments = @QuoteComments + CHAR(13) + CHAR(10) + @QComment
			END
			SELECT @DetailComments = @DetailComments + CHAR(13) + CHAR(10) + @DComment
			SELECT @SuppliedComments = @SuppliedComments + CHAR(13) + CHAR(10) + @SComment		
			if @QCommentHtml <> '' AND @QCHtml <> @QCommentHtml
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
			SELECT @QC = @QComment
			SELECT @QCHtml = @QCommentHtml

			FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml
		END

		CLOSE comment_col_cursor
		DEALLOCATE comment_col_cursor

		if @QuoteCommentsHtml = ''
		Begin
			SELECT @QuoteCommentsHtml = @QuoteComments
		End

		if @DetailCommentsHtml = ''
		Begin
			SELECT @DetailCommentsHtml = @DetailComments
		End

		if @SuppliedCommentsHtml = ''
		Begin
			SELECT @SuppliedCommentsHtml = @SuppliedComments
		End

		UPDATE #estPrintcombined SET QuoteComment = @QuoteComments, DetailComments = @DetailComments, SuppliedByNotes = @SuppliedComments, QuoteCommentHtml = @Font + @QuoteCommentsHtml + @Font2, DetailCommentsHtml = @Font + @DetailCommentsHtml + @Font2, SuppliedByNotesHtml = @Font + @SuppliedCommentsHtml + @Font2 
		WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func

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
	UPDATE #estPrintcombined SET QuoteComment = (SELECT QteComment FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func) AND (#estComments.RevNo = @MaxRev))
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET DetailComments = (SELECT DetailComment FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func) AND (#estComments.RevNo = @MaxRev))
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET SuppliedByNotes = (SELECT SuppliedByNotes FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func) AND (#estComments.RevNo = @MaxRev))
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET QuoteCommentHtml = (SELECT CASE WHEN QteCommentHtml = '' THEN  @Font + QteComment + @Font2 ELSE @Font + QteCommentHtml + @Font2 END FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func) AND (#estComments.RevNo = @MaxRev))
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET DetailCommentsHtml = (SELECT CASE WHEN DetailCommentsHtml = '' THEN  @Font + DetailComments + @Font2 ELSE @Font + DetailCommentHtml + @Font2 END FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func) AND (#estComments.RevNo = @MaxRev))
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
	UPDATE #estPrintcombined SET SuppliedByNotesHtml = (SELECT CASE WHEN SuppliedByNotesHtml = '' THEN  @Font + SuppliedByNotes + @Font2 ELSE @Font + SuppliedByNotesHtml + @Font2 END FROM #estComments WHERE (#estComments.EstNo = @EstNo) AND (#estComments.QuoteNo = @qteNum) AND (#estComments.FunctionCode = @func OR #estComments.ConsolidationCode = @func) AND (#estComments.RevNo = @MaxRev))
	WHERE (#estPrintcombined.EstimateNumber = @EstNo) AND (#estPrintcombined.QuoteNumber = @qteNum) AND #estPrintcombined.FunctionCode = @func
 End

  

 SET @RowCount = @RowCount + 1
END


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


SELECT * FROM #estPrintcombined


   
	SELECT @JobNum = ISNULL(JOB_NUMBER,0), @JobCompNum = ISNULL(JOB_COMPONENT_NBR,0), @JobTempCode = ISNULL(JOB_TMPLT_CODE,'')
		FROM JOB_COMPONENT
		WHERE ESTIMATE_NUMBER = @EstNo AND EST_COMPONENT_NBR = @EstCompNo

		IF @JobNum IS NOT NULL
		BEGIN
			IF @JobTempCode <> '' AND (SELECT COUNT(*) FROM JOB_TMPLT_DTL WHERE JOB_TMPLT_CODE = @JobTempCode AND (ITEM_CODE = 'JOB_LOG.UDV1_CODE' OR ITEM_CODE = 'JOB_LOG.UDV2_CODE')) > 0
			BEGIN
				SELECT (SELECT ISNULL(LABEL,'') FROM JOB_TMPLT_DTL WHERE JOB_TMPLT_CODE = @JobTempCode AND ITEM_CODE = 'JOB_LOG.UDV1_CODE') AS LABEL1,
				(SELECT ISNULL(UDV_DESC,'') FROM JOB_LOG INNER JOIN JOB_LOG_UDV1 ON JOB_LOG.UDV1_CODE = JOB_LOG_UDV1.UDV_CODE WHERE JOB_NUMBER = @JobNum) AS DESC1,
				(SELECT ISNULL(LABEL,'') FROM JOB_TMPLT_DTL WHERE JOB_TMPLT_CODE = @JobTempCode AND ITEM_CODE = 'JOB_LOG.UDV2_CODE') AS LABEL2,
				(SELECT ISNULL(UDV_DESC,'') FROM JOB_LOG INNER JOIN JOB_LOG_UDV2 ON JOB_LOG.UDV2_CODE = JOB_LOG_UDV2.UDV_CODE WHERE JOB_NUMBER = @JobNum) AS DESC2
			END
			ELSE
			BEGIN
				SELECT (SELECT ISNULL(USER_LABEL,'') AS LABEL FROM UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV1') AS LABEL1,
				(SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV1 ON JOB_LOG.UDV1_CODE = JOB_LOG_UDV1.UDV_CODE WHERE JOB_NUMBER = @JobNum) AS DESC1,
				(SELECT ISNULL(USER_LABEL,'') AS LABEL FROM UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV2') AS LABEL2,
				(SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV2 ON JOB_LOG.UDV2_CODE = JOB_LOG_UDV2.UDV_CODE WHERE JOB_NUMBER = @JobNum) AS DESC2
			END
		END

DROP TABLE #est
DROP TABLE #estPrint
DROP TABLE #estPrintData
DROP TABLE #estPrintCombined
DROP TABLE #comps
DROP TABLE #quotes
DROP TABLE #jc
DROP TABLE #ec
DROP TABLE #qva_NB
DROP TABLE #actual_total
DROP TABLE #quote
DROP TABLE #funcheading





















