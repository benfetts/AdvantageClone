if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_Report3]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_Report3]
GO



CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_Report3] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Quotes varchar(100),
@ReportType Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int, @Records int, @Count int, @CountRev int, @MaxRev int, @CountRows int,
	@EstNum int,
	@EstCompNum int,
	@QuoteNum int,
	@RevNum int,
	@JobNum int,
	@JobCompNum int,
	@JobDueDate smalldatetime,
	@FncCode varchar(6),
	@sql nvarchar(4000),
	@paramlist nvarchar(4000),
	@sql2 nvarchar(4000),
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
	@JobQty decimal(15,4),
	@sumCPU decimal(20,4),
	@ContSeparate smallint,
	@ProdConsFunc smallint,
	@client varchar(6), 
	@division varchar(6),
	@product varchar(6),
	@func varchar(6),
	@funcdesc varchar(30),
	@funcorder smallint,
	@functype varchar(1),
	@fncheadingid int,
	@fncheadingdesc varchar(60),
	@fncheadingseq int,
	@actual decimal(15,2),
	@QuoteDesc varchar(60),
	@CompNum int,
	@CPU decimal(15,3),
	@CPM decimal(15,3),
	@ExclEmpTime smallint,
	@ExclVendor smallint,
	@ExclIO smallint,
	@OneRev smallint, @EstDesc varchar(60), @EstCompDesc varchar(60), @EstQuoteDesc varchar(60), @JobDesc varchar(60), @JobCompDesc varchar(60),
                @JobCliRef varchar(30), @SCCode varchar(6), @SCDesc varchar(30), @AccE varchar(100), @ClCode varchar(6), @ClName varchar(40),
                @DivCode varchar(6), @DiviName varchar(40), @PrdCode varchar(6), @PrdDesc varchar(40), @CDPContactID int, @ContCode varchar(6),
                @ContFML varchar(100), @ContA1 varchar(40), @ContA2 varchar(40), @ContCity varchar(30), @ContState varchar(10), @ContZip varchar(10),@ContCountry varchar(20),
                @ECQ varchar(20), @OneR smallint, @sCPU decimal(20,4), @sumCT decimal(20,4), @JobTempCode varchar(50),@ExclNonBill smallint

CREATE TABLE #est(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int)
	
CREATE TABLE #quote(
	RowID int IDENTITY(1, 1), 
	CompNum int,
	CompDesc varchar(60),
	QuoteNum int,
	QuoteDesc varchar(60))		
	
CREATE TABLE #qva_NB ( 
    ESTIMATE_NUMBER		int,
    EST_COMPONENT_NBR	smallint,
    EST_QUOTE_NBR		smallint,
    EST_REV_NBR 		smallint NULL,
    JOB_NUMBER			int,
    JOB_COMPONENT_NBR	smallint,
	JOB_DUE_DATE        smalldatetime,
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
	JOB_DUE_DATE        smalldatetime,
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
	CONT_CITY           varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_STATE          varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ZIP            varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_COUNTRY        varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	INOUT               char(1) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FNC_ORDER           smallint,
	JOB_DUE_DATE        smalldatetime,
	AD_NBR				varchar(30),
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
	--TAX				    decimal(15,2),
	--TAX_CODE            varchar(4) NULL,
	JOB_QTY             int,
	CDP_CONTACT_ID      int,
	CONT_CODE           varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_FML            varchar(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ADDRESS1       varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ADDRESS2       varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_CITY           varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_STATE          varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_ZIP            varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CONT_COUNTRY        varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	INOUT               char(1),
	FNC_ORDER           smallint,
	JOB_DUE_DATE        smalldatetime,
	AD_NBR				varchar(30),
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


SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0), @FunctionOption = ISNULL(FUNCTION_OPTION, ''), 
                      @GroupOption = ISNULL(GROUP_OPTION, ''), @SortOption = ISNULL(SORT_OPTION, ''), @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @Specs = ISNULL(SPECS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), 
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ContSeparate = ISNULL(CONT_SEPARATE, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
FROM        ESTIMATE_PRINT_DEF
WHERE     (UPPER(USER_ID) = UPPER(@UserID))

SELECT @client = CL_CODE, @division = DIV_CODE, @product = PRD_CODE
FROM ESTIMATE_LOG
WHERE ESTIMATE_NUMBER = @EstNo

SELECT @ProdConsFunc = PRD_CONSOL_FUNC
FROM PRODUCT
WHERE CL_CODE = @client AND DIV_CODE = @division AND PRD_CODE = @product

if @ReportType = 7
    Begin
        INSERT INTO #est
        SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		                   EQ.EST_QUOTE_NBR, MAX(ESTIMATE_REV.EST_REV_NBR - 1)
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
                                      INNER JOIN charlist_to_table(@Quotes, DEFAULT) c ON EQ.EST_QUOTE_NBR = c.vstr collate database_default
                WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @EstCompNo) AND (ESTIMATE_REV.EST_REV_NBR <> 0)
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		                   EQ.EST_QUOTE_NBR
		                   
         INSERT INTO #est
         SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		           EQ.EST_QUOTE_NBR, MAX(ESTIMATE_REV.EST_REV_NBR)
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
                                                  INNER JOIN charlist_to_table(@Quotes, DEFAULT) c ON EQ.EST_QUOTE_NBR = c.vstr collate database_default
                WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @EstCompNo)
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		                   EQ.EST_QUOTE_NBR
        
    End
Else
    Begin
        INSERT INTO #est
        SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		                   EQ.EST_QUOTE_NBR, MIN(ESTIMATE_REV.EST_REV_NBR)
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
                                      INNER JOIN charlist_to_table(@Quotes, DEFAULT) c ON EQ.EST_QUOTE_NBR = c.vstr collate database_default
                WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @EstCompNo)
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		                   EQ.EST_QUOTE_NBR
		                   
         INSERT INTO #est
         SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		           EQ.EST_QUOTE_NBR, MAX(ESTIMATE_REV.EST_REV_NBR)
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
                                                  INNER JOIN charlist_to_table(@Quotes, DEFAULT) c ON EQ.EST_QUOTE_NBR = c.vstr collate database_default
                WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @EstCompNo) AND (ESTIMATE_REV.EST_REV_NBR <> 0)
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		                   EQ.EST_QUOTE_NBR
        
     End		           
--SELECT * FROM #est

SELECT @JobNum = JOB_NUMBER, @JobCompNum = JOB_COMPONENT_NBR, @JobDueDate = JOB_FIRST_USE_DATE
FROM JOB_COMPONENT
WHERE ESTIMATE_NUMBER = @EstNo AND EST_COMPONENT_NBR = @EstCompNo

if @JobNum is null
    Begin
        SET @JobNum = 0
    End
if @JobCompNum is null
    Begin
        SET @JobCompNum = 0
    End
if @JobDueDate is null
    Begin
        SET @JobDueDate = ''
    End

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

--SELECT @MaxRev, @CountRev
--SELECT @JobNum, @JobCompNum

if @RevNum = @MaxRev
    Begin
        SELECT @sqlNB = 'INSERT INTO #qva_NB SELECT ''' + Cast(@EstNum AS Varchar(10)) + ''', ''' + Cast(@EstCompNum AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(10)) + ''', ''' + Cast(@JobDueDate AS Varchar(12)) + ''','
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
        	
        	
        SELECT @sqlNB = 'INSERT INTO #qva_NB SELECT ''' + Cast(@EstNum AS Varchar(10)) + ''', ''' + Cast(@EstCompNum AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(10)) + ''', ''' + Cast(@JobDueDate AS Varchar(12)) + ''','
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

        SELECT @sqlNB = 'INSERT INTO #qva_NB SELECT ''' + Cast(@EstNum AS Varchar(10)) + ''', ''' + Cast(@EstCompNum AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(10)) + ''', ''' + Cast(@JobDueDate AS Varchar(12)) + ''','
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
						          CASE WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ISNULL(SUM(AP_PRODUCTION.EXT_CITY_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_STATE_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_COUNTY_RESALE), 0.00) + ISNULL(SUM(AP_PRODUCTION.EXT_NONRESALE_TAX), 0.00)
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
                
              
           
           SELECT @sqlactual = ' INSERT INTO #actual_total SELECT ''' + Cast(@EstNum AS Varchar(10)) + ''', ''' + Cast(@EstCompNum AS Varchar(5)) + ''', ''' + Cast(@QuoteNum AS Varchar(5)) + ''', ''' + Cast(@RevNum AS Varchar(5)) + ''', ''' + Cast(@JobNum AS Varchar(10)) + ''', ''' + Cast(@JobCompNum AS Varchar(5)) + ''', ''' + Cast(@JobDueDate AS Varchar(12)) + ''','
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
            SELECT @sqlactual = @sqlactual + 'CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ISNULL(SUM(EMP_TIME_DTL.EXT_MARKUP_AMT), 0.00)  
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
    SELECT @sqlactualwhere = ' WHERE (V_QUOTE_VS_ACTUAL.JOB_NUMBER = ''' + Cast(@JobNum AS Varchar(10)) + ''') AND (V_QUOTE_VS_ACTUAL.JOB_COMPONENT_NBR = ''' + Cast(@JobCompNum AS Varchar(5)) + ''')'
					  
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
                                       
             print (@sqlactual + @sqlactualFrom + @sqlactualwhere)
	        EXEC (@sqlactual + @sqlactualFrom + @sqlactualwhere)
                SET @sqlactual = ''  
                                      
    End
--SELECT * FROM #actual_total

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
					        SELECT @sql2 = @sql2 + ' ISNULL(E.EST_PHASE_ID,0) as EST_PHASE_ID, ISNULL(E.EST_PHASE_DESC, '''') as EST_PHASE_DESC,'
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
					

SELECT @sql2 = @sql2 + ' ISNULL(ESTIMATE_REV.JOB_QTY,0) AS JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, 
                      CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY, 0, 0, (Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))+''/''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))),'                      
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
                    SELECT @sql2 = @sql2 + ' ISNULL(JOB_COMPONENT.JOB_FIRST_USE_DATE,''''), ISNULL(JOB_COMPONENT.AD_NBR,'''') AS AD_NBR, EL.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME,'      
					if @RevNum = 0 AND @CountRev > 1
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
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY, JOB_COMPONENT.JOB_FIRST_USE_DATE, JOB_COMPONENT.AD_NBR, EL.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME'
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
			              NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, INOUT, FNC_ORDER, JOB_DUE_DATE, '''', NULL, NULL, NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 
			              0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0, Actual_Markup, Actual_Tax, Actual_Total, 0.00, 0.00, 0.00	
	FROM #actual_total WHERE (ESTIMATE_NUMBER = ''' + Cast(@EstNum AS Varchar(10)) + ''') AND (EST_COMPONENT_NBR = ''' + Cast(@EstCompNum AS Varchar(5)) + ''') AND 
                      (EST_QUOTE_NBR = ''' + Cast(@QuoteNum AS Varchar(5)) + ''') AND (EST_REV_NBR = ''' + Cast(@RevNum AS Varchar(5)) + ''')'

SELECT @sqlNB = ' UNION ALL SELECT ESTIMATE_NUMBER, NULL, EST_COMPONENT_NBR, NULL, EST_QUOTE_NBR, NULL, JOB_NUMBER, NULL, JOB_COMPONENT_NBR, NULL, EST_REV_NBR, FNC_CODE, FNC_DESCRIPTION,
			              '''', '''', '''', 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, FNC_TYPE, 0, FNC_TYPE, 0, '''',
			              FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ, NULL, 
			              NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '''', '''', '''', '''', 0.00, 0, 0, NULL, NULL, 
			              NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, INOUT, FNC_ORDER, JOB_DUE_DATE, '''', NULL, NULL, NULL, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 
			              0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, NB_Markup, NB_Tax, NB_Amount	
	FROM #qva_NB WHERE (ESTIMATE_NUMBER = ''' + Cast(@EstNum AS Varchar(10)) + ''') AND (EST_COMPONENT_NBR = ''' + Cast(@EstCompNum AS Varchar(5)) + ''') AND 
                      (EST_QUOTE_NBR = ''' + Cast(@QuoteNum AS Varchar(5)) + ''') AND (EST_REV_NBR = ''' + Cast(@RevNum AS Varchar(5)) + ''')'

if @ReportType = 3 Or @ReportType = 4
    Begin
        print (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby + @sqlactual + @sqlNB)
	    EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby + @sqlactual + @sqlNB)
	    print @sqlNB
    End
Else
    Begin
        print @sql2 + @sqlfrom + @sqlwhere + @sqlgroupby	
	    EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby)	    
    End
	

                 
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
     
--SELECT @RevNum, @CountRev, @MaxRev
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

--if @JobQty = 0
--    Begin
--        UPDATE #estPrint
--        SET CPU = 0
--        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
--                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum)
--    End
--Else
--    Begin
--		SET @sCPU = (@sumCPU / @JobQty)
--        UPDATE #estPrint
--        SET CPU =  @sCPU
--        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
--                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum)
--    End                 
 
--if @JobQty = 0
--Begin
--        UPDATE #estPrint
--        SET CPM = 0
--        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
--                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
--End
--Else
--Begin
--        UPDATE #estPrint
--        SET CPM = @sumCPU / (@JobQty / 1000)
--        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
--                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
--End                     


 SET @RowCount = @RowCount + 1
END

--SELECT * FROM #qva_NB

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
            SELECT DISTINCT @EstDesc = EST_LOG_DESC, @EstCompDesc = EST_COMP_DESC, @EstQuoteDesc = EST_QUOTE_DESC, @JobDesc = JOB_DESC, @JobCompDesc = JOB_COMP_DESC,
                    @JobCliRef = JOB_CLI_REF, @SCCode = SC_CODE, @SCDesc = SC_DESCRIPTION, @AccE = AE, @ClCode = CL_CODE, @ClName = CL_NAME,
                    @DivCode = DIV_CODE, @DiviName = DIV_NAME, @PrdCode = PRD_CODE, @PrdDesc = PRD_DESCRIPTION, @CDPContactID = CDP_CONTACT_ID, @ContCode = CONT_CODE,
                    @ContFML = CONT_FML, @ContA1 = CONT_ADDRESS1, @ContA2 = CONT_ADDRESS2, @ContCity = CONT_CITY, @ContState = CONT_STATE, @ContZip = CONT_ZIP,
                    @ContCountry = CONT_COUNTRY, @ECQ = ESTCOMPQUOTE, @OneR = ONE_REVISION
             FROM #estPrint
             WHERE EST_QUOTE_NBR = @QuoteNum
             
             --SELECT @EstDesc, @EstCompDesc, @EstQuoteDesc, @JobDesc, @JobCompDesc,
             --       @JobCliRef, @SCCode, @SCDesc, @AccE, @ClCode, @ClName,
             --       @DivCode, @DiviName, @PrdCode, @PrdDesc, @CDPContactID, @ContCode,
             --       @ContFML, @ContA1, @ContA2, @ContCity, @ContState, @ContZip,
             --       @ECQ, @OneR
            
            WHILE @RowCount <= @NumberRecords
            BEGIN                

             UPDATE #estPrint 
             SET EST_LOG_DESC = @EstDesc, EST_COMP_DESC = @EstCompDesc, EST_QUOTE_DESC = @EstQuoteDesc, JOB_DESC = @JobDesc, JOB_COMP_DESC = @JobCompDesc,
                 JOB_CLI_REF = @JobCliRef, SC_CODE = @SCCode, SC_DESCRIPTION = @SCDesc, AE = @AccE, CL_CODE = @ClCode, CL_NAME = @ClName,
                 DIV_CODE = @DivCode, DIV_NAME = @DiviName, PRD_CODE = @PrdCode, PRD_DESCRIPTION = @PrdDesc, CDP_CONTACT_ID = @CDPContactID, CONT_CODE = @ContCode,
                 CONT_FML = @ContFML, CONT_ADDRESS1 = @ContA1, CONT_ADDRESS2 = @ContA2, CONT_CITY = @ContCity, CONT_STATE = @ContState, CONT_ZIP = @ContZip,
                 CONT_COUNTRY = @ContCountry, ESTCOMPQUOTE = @ECQ, ONE_REVISION = @OneR
             WHERE EST_LOG_DESC IS NULL AND EST_QUOTE_NBR = @QuoteNum

            SET @RowCount = @RowCount + 1
            END
            
            SET @RowCount = 1
            SET @Count = @Count + 1
        END
        
        
--SELECT * FROM #estPrint
      

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
				 0, CDP_CONTACT_ID, CONT_CODE, CONT_FML, CONT_ADDRESS1, CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY, 0, 0, ESTCOMPQUOTE, INOUT, FNC_ORDER, JOB_DUE_DATE, AD_NBR, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, SUM(ORIGINAL_AMT) AS ORIGINAL_AMT, SUM(REVISED_AMT) AS REVISED_AMT,				 
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

if @SuppressZero = 1
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
                      CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY, ESTCOMPQUOTE, INOUT, FNC_ORDER, JOB_DUE_DATE, AD_NBR, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, ONE_REVISION'

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
					SET ORIGINAL_CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)
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
					SET REVISED_CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)
					WHERE REVISED_LINE_TOTAL <> 0 AND (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND (EST_QUOTE_NBR = @QuoteNum)
				
		End         

        SET @RowCount = @RowCount + 1
        END

        --SELECT * FROM #estPrintData
    
		if @GroupOption = 'T'
		Begin
			if @SortOption = 'C'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, FNC_TYPE, FNC_CODE
			End
			if @SortOption = 'O'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, FNC_TYPE, FNC_ORDER
			End
		End
		if @GroupOption = 'H'
		Begin
			if @SortOption = 'C'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, FNC_HEADING_SEQ, FNC_HEADING_DESC, FNC_CODE
			End
			if @SortOption = 'O'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, FNC_HEADING_SEQ, FNC_HEADING_DESC, FNC_ORDER
			End
		End
		if @GroupOption = 'P'
		Begin
			if @SortOption = 'C'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, EST_PHASE_DESC, FNC_CODE
			End
			if @SortOption = 'O'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, EST_PHASE_DESC, FNC_ORDER
			End
		End
		if @GroupOption = 'I'
		Begin
			if @SortOption = 'C'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, INOUT, FNC_CODE
			End
			if @SortOption = 'O'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, INOUT, FNC_ORDER
			End
		End
		if @GroupOption = 'N' or @GroupOption = ''
		Begin
			if @SortOption = 'C'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, FNC_CODE
			End
			if @SortOption = 'O'
			Begin
				SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR, EST_QUOTE_NBR, FNC_ORDER
			End
		End

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
DROP TABLE #qva_NB





















