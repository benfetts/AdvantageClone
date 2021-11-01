if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_Report_Combined]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_Report_Combined]
GO



CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_Report_Combined] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Comps varchar(100),
@Quotes varchar(100),
@Groupby varchar(2),
@PrintID Int

--@Phase Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int, @Records int, @Count int, @Recordquote int, @Countquote int, @CountRow int, @MaxRev int,
	@EstNum int, @Font varchar(50), @Font2 varchar(10),
	@EstCompNum int,
	@QuoteNum int,
	@RevNum int,
	@sql nvarchar(4000),
	@paramlist nvarchar(4000),
	@sql2 nvarchar(4000),
	@sqlfrom nvarchar(4000),
	@sqlwhere nvarchar(4000),
	@sqlgroupby nvarchar(4000),
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
	@sumCPU decimal(20,4),
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
	@jobclientref varchar(30),
	@ExclEmpTime smallint,
	@ExclVendor smallint,
	@ExclIO smallint,
	@ContSeparate smallint,
	@sCPU decimal(20,4),
	@sumCT decimal(20,4),
	@JobNum int,
	@JobCompNum int,
	@JobTempCode varchar(50),
	@ExclNonBill smallint, 
	@IncludeRateMarkup as smallint

CREATE TABLE #est(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int,	
	EstComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCompComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCompCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QteComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QteCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL)

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
	
CREATE TABLE #sums( 	
	FNC_CODE    		varchar(6) NULL,
	sumEST_REV_QUANTITY	decimal(15,2),
	sumEST_REV_EXT_AMT	decimal(15,2),
	sumEXT_MARKUP_AMT	decimal(14,2),
	sumLINE_TOTAL  		decimal(14,2),
	sumEXT_CONTINGENCY	decimal(14,2),
	sumTAX				decimal(15,2),
	sumJOB_QTY          int)

CREATE TABLE #estPrint( 	
    RowID int IDENTITY(1, 1), 
	EstimateNumber		int,
	EstimateDescription		varchar(60) NULL,
	EstimateComponentNumber	smallint,
	EstimateComponentDescription		varchar(60) NULL,
	QuoteNumber		smallint,
	QuoteDescription		varchar(60) NULL,
	JobNumber			int,
	JobDescription			varchar(60) NULL,
	JobComponentNumber	smallint,
	JobComponentDescription		varchar(60) NULL,
	RevisionNumber 		smallint NULL,
	--SEQ_NBR 			int,
	FunctionCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FunctionDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DetailComments		text,
	SuppliedByCode	varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotes	text,
	EstimateQuantity	decimal(15,2),
	EstimateRate		decimal(15,4),
	EstimateExtAmount		decimal(15,2),
	--EST_REV_COMM_PCT	decimal(6,3),
	EstimateMarkupAmount		decimal(14,2),
	EstimateTotalAmount  		decimal(14,2),
	EstimateTotalContingencyAmount  		decimal(14,2),
	--EST_REV_CONT_PCT	decimal(6,3),
	EstimateContingencyAmount		decimal(14,2),
	EstimateMarkupContingency 		decimal(14,2),
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
	EstimateTaxAmount				    decimal(15,2),
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
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	EstimateComponentQuote		varchar(20),
	InOut               char(1),
	FunctionOrder           smallint,
	JobDueDate        smalldatetime,
	AdNumber		varchar(30),
	FunctionOption varchar(2),
	GroupOption  varchar(2),
	SortOption varchar(2),
	TaxSeparate smallint,
	CommissionSeparate smallint,
	ContingencySeparate smallint, 
	IncludeContingency smallint)

CREATE TABLE #estPrintcombined( 	
    RowID int IDENTITY(1, 1), 
	EstimateNumber		int,
	EstimateDescription		varchar(60) NULL,
	QuoteNumber		smallint,
	FunctionCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FunctionDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	--QuoteDescription		varchar(60) NULL,
	JobNumber			int,
	JobDescription			varchar(60) NULL,
	--JobComponentNumber	smallint,
	--JobComponentDescription		varchar(60) NULL,
	--RevisionNumber 		smallint NULL,
	--SEQ_NBR 			int,
	DetailComments		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DetailCommentsHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByCode	varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotes	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotesHtml	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateQuantity	decimal(15,2),
	EstimateRate		decimal(15,4),
	EstimateExtAmount		decimal(15,2),
	--EST_REV_COMM_PCT	decimal(6,3),
	EstimateMarkupAmount		decimal(14,2),
	EstimateTotalAmount  		decimal(14,2),
	EstimateTotalContingencyAmount  		decimal(14,2),
	--EST_REV_CONT_PCT	decimal(6,3),
	EstimateContingencyAmount		decimal(14,2),
	EstimateMarkupContingency 		decimal(14,2),
	--INCL_CPU			smallint,
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
	--AccountExecutiveCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	--AccountExecutiveName          		varchar(100) NULL,
	ClientCode    		    varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientName			    varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionCode    		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionName			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductDescription		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateComment		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateCommentHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateComponentComment	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateComponentCommentHtml	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QuoteComment		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QuoteCommentHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevisionComment     varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevisionCommentHtml     varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateTaxAmount				    decimal(15,2),
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
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	EstimateComponentQuote		int,
	InOut               char(1),
	FunctionOrder           smallint,
	--JobDueDate        smalldatetime,
	--AdNumber		varchar(30),
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
	CompLabelFromUDFTable5 varchar(40),
	ApprovalType int, 
	IncludeRateMarkup smallint,
	EstimateRateMarkup		decimal(15,4))


IF @PrintID = 0
BEGIN
	SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0), @FunctionOption = ISNULL(FUNCTION_OPTION, ''), 
                      @GroupOption = ISNULL(GROUP_OPTION, ''), @SortOption = ISNULL(SORT_OPTION, ''), @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @Specs = ISNULL(SPECS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), @ContSeparate = ISNULL(CONT_SEPARATE, 0), 
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
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
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0), @IncludeRateMarkup = ISNULL(INCL_RATE_MARKUP,0)
	FROM        PROD_EST_DEF
	WHERE     PROD_EST_DEF_ID = @PrintID
END

SELECT @client = CL_CODE, @division = DIV_CODE, @product = PRD_CODE
FROM ESTIMATE_LOG
WHERE ESTIMATE_NUMBER = @EstNo

SELECT @ProdConsFunc = PRD_CONSOL_FUNC
FROM PRODUCT
WHERE CL_CODE = @client AND DIV_CODE = @division AND PRD_CODE = @product

if @Comps NOT LIKE '%,'
BEGIN
	SET @Comps = @Comps + ','
END

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

UPDATE #est SET EstComment = (SELECT ISNULL(EST_LOG_COMMENT,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompComment = (SELECT ISNULL(EST_COMP_COMMENT,'') FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteComment = (SELECT ISNULL(EST_QTE_COMMENT,'') FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevComment = (SELECT ISNULL(EST_REV_COMMENT,'') FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		           
UPDATE #est SET EstCommentHtml = (SELECT ISNULL(EST_LOG_COMMENT_HTML,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompCommentHtml = (SELECT ISNULL(EST_COMP_COMMENT_HTML,'') FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteCommentHtml = (SELECT ISNULL(EST_QTE_COMMENT_HTML,'') FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevCommentHtml = (SELECT ISNULL(EST_REV_COMMENT_HTML,'') FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		        

--SELECT * FROM #est

SELECT @NumberRecords = COUNT(*) FROM #est
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @EstNum = EstNo, @EstCompNum = EstCompNo, @QuoteNum = QuoteNo, @RevNum = RevNo
 FROM #est
 WHERE RowID = @RowCount

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
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + '  '''', '''', '''', '
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' '''', '''', '''', '
					End
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' ISNULL(E.EST_REV_QUANTITY,0) AS EST_REV_QUANTITY,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM(ISNULL(E.EST_REV_QUANTITY,0)) AS EST_REV_QUANTITY,'
					End				
				if @FunctionOption = 'R'
					Begin
						SELECT @sql2 = @sql2 + ' E.EST_REV_RATE,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' 0.00,'
					End			
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' EST_REV_EXT_AMT,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM(E.EST_REV_EXT_AMT) AS EST_REV_EXT_AMT,'
					End
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' EXT_MARKUP_AMT,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM(E.EXT_MARKUP_AMT) AS EXT_MARKUP_AMT,'
					End
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' ISNULL(E.LINE_TOTAL,0) AS LINE_TOTAL,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM(ISNULL(E.LINE_TOTAL,0)) AS LINE_TOTAL,'
					End
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' ISNULL(E.LINE_TOTAL_CONT,0) AS LINE_TOTAL_CONT,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM(ISNULL(E.LINE_TOTAL_CONT,0)) AS LINE_TOTAL_CONT,'
					End
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' (ISNULL(EXT_CONTINGENCY,0)) AS EXT_CONTINGENCY,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM(ISNULL(E.EXT_CONTINGENCY,0)) AS EXT_CONTINGENCY,'
					End
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' EXT_MU_CONT AS EXT_MU_CONT,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM(E.EXT_MU_CONT) AS EXT_MU_CONT,'
					End	
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
			    if @GroupOption = 'H' OR @GroupOption = 'HT'
					    Begin
					        SELECT @sql2 = @sql2 + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					    End
					 else
					    Begin
					        SELECT @sql2 = @sql2 + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
					    End 
SELECT @sql2 = @sql2 + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,'
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' '''', '''', '''', '''','
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' '''', '''', '''', '''','
					End
 
				if @FunctionOption = 'N'
					Begin
					   if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End					
					   --SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)) AS TAX,'			  		
					End	
				Else
					Begin
					   if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End				
					   --SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) AS TAX,'					        
					End

SELECT @sql2 = @sql2 + ' ISNULL(ESTIMATE_REV.JOB_QTY,0) AS JOB_QTY, ISNULL(CDP_CONTACT_HDR.CDP_CONTACT_ID,0), ISNULL(CDP_CONTACT_HDR.CONT_CODE,''''), ISNULL(CDP_CONTACT_HDR.CONT_FML,''''), ISNULL(CDP_CONTACT_HDR.CONT_ADDRESS1,''''), 
                      ISNULL(CDP_CONTACT_HDR.CONT_ADDRESS2,''''), ISNULL(CDP_CONTACT_HDR.CONT_CITY,''''), ISNULL(CDP_CONTACT_HDR.CONT_STATE,''''), 
                      ISNULL(CDP_CONTACT_HDR.CONT_ZIP,''''), ISNULL(CDP_CONTACT_HDR.CONT_COUNTRY,''''), 0, 0, CAST((Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(7))+''''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))) AS int),'                      
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
SELECT @sql2 = @sql2 + ' JOB_COMPONENT.JOB_FIRST_USE_DATE, ISNULL(JOB_COMPONENT.AD_NBR,'''') AS AD_NBR,'''','''','''',0,0,0,0'     
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
                      CDP_CONTACT_HDR ON EC.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID'

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
					  if @FunctionOption = 'R'
						Begin
							SELECT @sqlgroupby = @sqlgroupby + ' E.EST_REV_RATE,'
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
					  if @GroupOption = 'H' OR @GroupOption = 'HT'
					    Begin
					        SELECT @sqlgroupby = @sqlgroupby + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
					    End	  
SELECT @sqlgroupby = @sqlgroupby + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,		  
					  ESTIMATE_REV.JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY, JOB_COMPONENT.JOB_FIRST_USE_DATE,JOB_COMPONENT.AD_NBR'
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

if @FunctionOption = 'N' 
 Begin
	--print @sql2 + @sqlfrom + @sqlwhere
	EXEC (@sql2 + @sqlfrom + @sqlwhere)
 End
Else
 Begin
	print @sql2 + @sqlfrom + @sqlwhere + @sqlgroupby
	EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby)
 End

                 
SELECT DISTINCT @JobQty = JobQuantity
FROM #estPrint 
WHERE     (EstimateNumber = @EstNum) AND (EstimateComponentNumber = @EstCompNum) AND 
                      (QuoteNumber = @QuoteNum) AND (RevisionNumber = @RevNum) 
                      
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
     
if @JobQty = 0
    Begin
        UPDATE #estPrint
        SET CPU = 0
        WHERE     (EstimateNumber = @EstNum) AND (EstimateComponentNumber = @EstCompNum) AND 
                      (QuoteNumber = @QuoteNum) AND (RevisionNumber = @RevNum)
    End
Else
    Begin
		SET @sCPU = (@sumCPU / @JobQty)
        UPDATE #estPrint
        SET CPU = @sCPU
        WHERE     (EstimateNumber = @EstNum) AND (EstimateComponentNumber = @EstCompNum) AND 
                      (QuoteNumber = @QuoteNum) AND (RevisionNumber = @RevNum)
    End                 
 
if @JobQty = 0
Begin
        UPDATE #estPrint
        SET CPM = 0
        WHERE     (EstimateNumber = @EstNum) AND (EstimateComponentNumber = @EstCompNum) AND 
                      (QuoteNumber = @QuoteNum) AND (RevisionNumber = @RevNum) 
End
Else
Begin
		SET @sCPU = (@JobQty / 1000)
		--SELECT @sCPU
			UPDATE #estPrint
			SET CPM = (@sumCPU + @sumCT) / @sCPU
			WHERE     (EstimateNumber = @EstNum) AND (EstimateComponentNumber = @EstCompNum) AND 
                      (QuoteNumber = @QuoteNum) AND (RevisionNumber = @RevNum) 
End                     
  
		
 SET @RowCount = @RowCount + 1
END

SELECT @NumberRecords = COUNT(*) FROM #estPrint
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @func = FunctionCode
 FROM #estPrint
 WHERE RowID = @RowCount

 SELECT @funcdesc = FNC_DESCRIPTION, @funcorder = FNC_ORDER
 FROM FUNCTIONS
 WHERE FNC_CODE = @func
 
UPDATE #estPrint 
SET FunctionDescription = @funcdesc, FunctionOrder = @funcorder
WHERE FunctionCode = @func

 

SET @RowCount = @RowCount + 1
END

--SELECT * FROM #estPrint
if @Groupby = 'jc'
Begin
	SELECT @sql = 'SELECT * FROM #estPrint ORDER BY  ESTIMATE_NUMBER, EST_QUOTE_NBR, EST_COMPONENT_NBR'

	if @GroupOption = 'T'
	Begin
		SELECT @sql = @sql + ' , FNC_TYPE'
	End
	if @GroupOption = 'H'
	Begin
		SELECT @sql = @sql + ' , FNC_HEADING_SEQ, FNC_HEADING_DESC'
	End
	if @GroupOption = 'P'
	Begin
		SELECT @sql = @sql + ' , EST_PHASE_DESC'
	End

	if @SortOption = 'C'
	Begin
		SELECT @sql = @sql + ' , FNC_CODE'
	End
	if @SortOption = 'O'
	Begin
		SELECT @sql = @sql + ' , FNC_ORDER'
	End


	print @sql
	EXEC (@sql)

End
Else
Begin
	SET @jobnumber = 0
	SET @jobdesc = ''
	SET @jobclientref = ''
	SELECT DISTINCT @jobnumber = JobNumber, @jobdesc =  ISNULL(JobDescription,''), @jobclientref = ISNULL(JobClientReference,'')
	 FROM #estPrint
	 WHERE JobNumber IS NOT NULL

	SELECT DISTINCT @cdpid = EstimateContactID, @contcode = ISNULL(EstimateContactCode,''), @contfml = ISNULL(EstimateContactName,''), @conta1 = ISNULL(EstimateContactAddress1,''), @conta2 = ISNULL(EstimateContactAddress2,''), @contcity = ISNULL(EstimateContactCity,''), @contstate = ISNULL(EstimateContactState,''), @contzip = ISNULL(EstimateContactZip,''), @contcountry = ISNULL(EstimateContactCountry,'')
	FROM #estPrint
	WHERE EstimateContactID IS NOT NULL


	SELECT @sql = 'INSERT INTO #estPrintcombined SELECT EstimateNumber,EstimateDescription,QuoteNumber,FunctionCode,FunctionDescription, ''' + Cast(@jobnumber AS Varchar(7)) + ''' AS JobNumber, '''' AS JobDescription,'
					if @FunctionOption = 'N'
						Begin
							SELECT @sql = @sql + ' '''' AS DetailComments,'''', '''' AS SuppliedByCode, '''' AS SuppliedByNotes,'''', '
						End	
					Else
						Begin
							SELECT @sql = @sql + ' '''' AS DetailComments,'''', '''' AS SuppliedByCode, '''' AS SuppliedByNotes,'''', '
						End 
	SELECT @sql = @sql + ' SUM(EstimateQuantity) AS EstimateQuantity, EstimateRate, SUM(EstimateExtAmount) AS EstimateExtAmount,
					 SUM(EstimateMarkupAmount) AS EstimateMarkupAmount, SUM(EstimateTotalAmount) AS EstimateTotalAmount, SUM(EstimateTotalContingencyAmount) AS EstimateTotalContingencyAmount, SUM(EstimateContingencyAmount) AS EstimateContingencyAmount, SUM(EstimateMarkupContingency) AS EstimateMarkupContingency, EstimateFunctionType, EmployeeTitleID,
					 FunctionType,'
					if @GroupOption = 'P'
							Begin
								SELECT @sql = @sql + ' EstimatePhaseID, EstimatePhaseDescription,'
							End
						 else
							Begin
								SELECT @sql = @sql + ' '''' as EstimatePhaseID, '''' as EstimatePhaseDescription,'
							End 
					if @GroupOption = 'H' OR @GroupOption = 'HT'
							Begin
								SELECT @sql = @sql + ' (SELECT RowID FROM #funcheading WHERE #estPrint.FunctionHeadingID = #funcheading.FuncHeadingID), FunctionHeadingID, FunctionHeadingDescription, FunctionHeadingSequence,'
							End
						 else
							Begin
								SELECT @sql = @sql + ' 0,0 as FunctionHeadingID, '''' as FunctionHeadingDescription, 0 as FunctionHeadingSequence, '
							End 
	SELECT @sql = @sql + ' ''' + @jobclientref + ''' AS JobClientReference, SalesClassCode, SalesClassDescription, ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,'
					if @FunctionOption = 'N'
						Begin
							SELECT @sql = @sql + ' '''' AS EstimateComment,'''', '''' AS EstimateComponentComment,'''', '''' AS QuoteComment,'''', '''' AS RevisionComment,'''','
						End	
					Else
						Begin
							SELECT @sql = @sql + ' '''' AS EstimateComment,'''', '''' AS EstimateComponentComment,'''', '''' AS QuoteComment,'''', '''' AS RevisionComment,'''','
						End
	SELECT @sql = @sql + ' SUM(EstimateTaxAmount) AS EstimateTaxAmount, SUM(JobQuantity) AS JobQuantity, ''' + Cast(@cdpid AS Varchar(5)) + ''' AS EstimateContactID, '''' AS EstimateContactCode, '''' AS EstimateContactName, '''' AS EstimateContactAddress1,
					 '''' AS EstimateContactAddress2, '''' AS EstimateContactCity, '''' AS EstimateContactState, '''' AS EstimateContactZip, '''' AS EstimateContactCountry, SUM(CPU) AS CPU, SUM(CPM) AS CPM, 
					 EstimateComponentQuote, InOut, FunctionOrder,'''','''','''',0,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, CASE WHEN ISNULL(SUM(EstimateQuantity),0) = 0 THEN 0 ELSE CAST(((SUM(EstimateExtAmount) + SUM(EstimateMarkupAmount)) / SUM(EstimateQuantity)) AS DECIMAL(18,4)) END AS EstimateRateMarkup
				  FROM #estPrint WHERE 1=1'

	--if @Phase <> 0
	--Begin
	--	SELECT @sql = @sql + ' AND E.EST_PHASE_ID = @Phase'
	--End
	
	if @SuppressZero = 1 and @PrintID = 0
	Begin
		SELECT @sql = @sql + ' AND EstimateExtAmount <> 0'
	End

	if @SuppressZero = 0 and @PrintID <> 0
	Begin
		SELECT @sql = @sql + ' AND EstimateExtAmount <> 0'
	End

	SELECT @sql = @sql + ' GROUP BY EstimateNumber,EstimateDescription,QuoteNumber,FunctionCode,FunctionDescription, EstimateRate, EstimateFunctionType, EmployeeTitleID, FunctionType,'
						  if @GroupOption = 'P'
							Begin
								SELECT @sql = @sql + ' EstimatePhaseID, EstimatePhaseDescription,'
							End	
						  if @GroupOption = 'H' OR @GroupOption = 'HT'
							Begin
								SELECT @sql = @sql + ' FunctionHeadingID, FunctionHeadingDescription, FunctionHeadingSequence,'
							End	  
	SELECT @sql = @sql + ' SalesClassCode, SalesClassDescription, ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription, EstimateComponentQuote, InOut, FunctionOrder'

	SELECT @sql = @sql + ' ORDER BY EstimateNumber, QuoteNumber'

	if @GroupOption = 'T'
	Begin
		SELECT @sql = @sql + ' , FunctionType'
	End
	if @GroupOption = 'H' OR @GroupOption = 'HT'
	Begin
		SELECT @sql = @sql + ' , FunctionHeadingSequence, FunctionHeadingDescription'
	End
	if @GroupOption = 'P'
	Begin
		SELECT @sql = @sql + ' , EstimatePhaseDescription'
	End

	if @SortOption = 'C'
	Begin
		SELECT @sql = @sql + ' , FunctionCode'
	End
	if @SortOption = 'O'
	Begin
		SELECT @sql = @sql + ' , FunctionOrder'
	End


	print @sql
	EXEC (@sql)

End

UPDATE #estPrintcombined SET JobDescription = (SELECT JOB_DESC FROM JOB_LOG WHERE JOB_NUMBER = #estPrintcombined.JobNumber)
UPDATE #estPrintcombined SET EstimateContactName = @contfml
UPDATE #estPrintcombined SET EstimateContactCode = @contcode
UPDATE #estPrintcombined SET EstimateContactAddress1 = @conta1
UPDATE #estPrintcombined SET EstimateContactAddress2 = @conta2
UPDATE #estPrintcombined SET EstimateContactCity = @contcity
UPDATE #estPrintcombined SET EstimateContactState = @contstate
UPDATE #estPrintcombined SET EstimateContactZip = @contzip
UPDATE #estPrintcombined SET EstimateContactCountry = @contcountry

SET @Font = '<span style="font-family: Arial; font-size: 9pt;">'
SET @Font2 = '</span>'


if @PrintID = 0
BEGIN
	UPDATE #estPrintcombined SET FunctionOption = (SELECT FUNCTION_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrintcombined SET GroupOption = (SELECT GROUP_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrintcombined SET SortOption = (SELECT SORT_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
END
ELSE
BEGIN
	UPDATE #estPrintcombined SET FunctionOption = @FunctionOption
	UPDATE #estPrintcombined SET GroupOption = @GroupOption
	UPDATE #estPrintcombined SET SortOption = @SortOption
	UPDATE #estPrintcombined SET IncludeRateMarkup = @IncludeRateMarkup
END

UPDATE #estPrintcombined SET TaxSeparate = @TaxSeparate, CommissionSeparate = @CommMUSeparate, ContingencySeparate = @ContSeparate, IncludeContingency = @Contingency

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

--SELECT * FROM #quotes

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
	WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND EQ.EST_COMPONENT_NBR IN (SELECT comp FROM #comps) AND EQ.EST_QUOTE_NBR IN (SELECT quote FROM #quotes)

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
 

 --SELECT @Count,@qteNum,@func,@ProdConsFunc,@ConsoleOverride,@FunctionOption
 --Select @Count

 --SELECT * FROM #estComments

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
			--SELECT @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml
			
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
	--SELECT * FROM #estComments
		DECLARE comment_col_cursor CURSOR FOR 
		SELECT RowID,EstNo,EstCompNo,QuoteNo,RevNo,FunctionCode,EstComment,
				EstCommentHtml,EstCompComment,EstCompCommentHtml,QteComment,QteCommentHtml,RevComment,RevCommentHtml,
				DetailComment,DetailCommentHtml,SuppliedByNotes,SuppliedByNotesHtml FROM #estComments e WHERE (e.EstNo = @EstNo) AND (e.QuoteNo = @qteNum) AND e.FunctionCode = @func AND (e.RevNo = @MaxRev) 
		OPEN comment_col_cursor

		FETCH NEXT FROM comment_col_cursor INTO @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml

		WHILE ( @@FETCH_STATUS <> -1 )
		BEGIN
			--SELECT @RID, @ENum, @ECNum, @QNum, @RNum, @FCode, @EComment,@ECommentHtml,@ECComment,@ECCommentHtml,@QComment,@QCommentHtml,@RComment,@RCommentHtml,@DComment,@DCommentHtml,@SComment,@SCommentHtml
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

--UPDATE #estPrintcombined
--SET ApprovalType = (SELECT EA.TYPE FROM V_ESTIMATEAPPR AS EA WHERE EA.ESTIMATE_NUMBER = #estPrintcombined.EstimateNumber AND EA.EST_QUOTE_NBR = #estPrintcombined.QuoteNumber AND EA.EST_REVISION_NBR = #estPrintcombined.RevisionNumber)

SELECT * FROM #estPrintcombined

DROP TABLE #est
DROP TABLE #estComments
DROP TABLE #estPrint
DROP TABLE #estPrintcombined
DROP TABLE #comps
DROP TABLE #quotes
DROP TABLE #funcheading



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



















