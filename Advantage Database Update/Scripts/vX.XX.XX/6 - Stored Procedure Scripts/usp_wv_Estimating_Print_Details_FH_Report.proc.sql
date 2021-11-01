if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_FH_Report]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_FH_Report]
GO




CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_FH_Report] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Quotes varchar(100),
@PrintID Int
--@Phase Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @Font varchar(50), @Font2 varchar(10), @RowCount int,
	@EstNum int,
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
	@JobQty int,
	@sumCPU decimal(20,3),
	@ExclEmpTime smallint,
	@ExclVendor smallint,
	@ExclIO smallint,
	@ContSeparate smallint,	
	@func varchar(6),
	@funcHeadingID int,
	@ExclNonBill smallint,
	@sCPU decimal(20,4),
	@sumCT decimal(20,4)

CREATE TABLE #est(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int,
	EstComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCompComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QteComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstCompCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	QteCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL)

CREATE TABLE #estComments(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int,
	FunctionCode		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,		
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
	--FNC_CODE			varchar(6) NULL,
	--FNC_DESCRIPTION		varchar(30) NULL,
	DetailComments		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DetailCommentsHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByCode	varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotes	text,
	SuppliedByNotesHtml	varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateQuantity	decimal(15,2),
	EstimateRate		decimal(15,4),
	EstimateExtAmount		decimal(15,2),
	--EST_REV_COMM_PCT	decimal(9,3),
	EstimateMarkupAmount		decimal(14,2),
	EstimateTotalAmount  		decimal(14,2),
	EstimateTotalContingencyAmount  		decimal(14,2),
	--EST_REV_CONT_PCT	decimal(6,3),
	EstimateContingencyAmount		decimal(14,2),
	EstimateMarkupContingency 		decimal(14,2),
	--INCL_CPU			smallint,
	--EST_FNC_TYPE		varchar(1) NULL,
	EmployeeTitleID	int,
	--FNC_TYPE		    varchar(1) NULL,
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
	EstimateCommentHtml		text,
	EstimateComponentCommentHtml	text,
	QuoteCommentHtml		text,
	RevisionCommentHtml     text,
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
	EstimateComponent             varchar(20),
	InOut               char(1),
	JobDueDate        smalldatetime,
	FunctionOption varchar(2),
	GroupOption  varchar(2),
	SortOption varchar(2),
	TaxSeparate smallint,
	CommissionSeparate smallint,
	ContingencySeparate smallint, 
	IncludeContingency smallint)

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
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
	FROM        PROD_EST_DEF
	WHERE     PROD_EST_DEF_ID = @PrintID
END

INSERT INTO #est
        SELECT EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR,
		           EQ.EST_QUOTE_NBR, MAX(ESTIMATE_REV.EST_REV_NBR), NULL,NULL,NULL,NULL, NULL,NULL,NULL,NULL
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
		           
UPDATE #est SET EstComment = (SELECT EST_LOG_COMMENT FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompComment = (SELECT EST_COMP_COMMENT FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteComment = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevComment = (SELECT EST_REV_COMMENT_HTML FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		           
UPDATE #est SET EstCommentHtml = (SELECT ISNULL(EST_LOG_COMMENT_HTML,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompCommentHtml = (SELECT ISNULL(EST_COMP_COMMENT_HTML,'') FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteCommentHtml = (SELECT ISNULL(EST_QTE_COMMENT_HTML,'') FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevCommentHtml = (SELECT ISNULL(EST_REV_COMMENT_HTML,'') FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		           

SET @NumberRecords = @@ROWCOUNT
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @EstNum = EstNo, @EstCompNum = EstCompNo, @QuoteNum = QuoteNo, @RevNum = RevNo
 FROM #est
 WHERE RowID = @RowCount

 
 SELECT @sql2 = 'INSERT INTO #estPrint SELECT EQ.ESTIMATE_NUMBER, EL.EST_LOG_DESC, EQ.EST_COMPONENT_NBR, EC.EST_COMP_DESC, EQ.EST_QUOTE_NBR, EQ.EST_QUOTE_DESC, JOB_LOG.JOB_NUMBER,
			JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ESTIMATE_REV.EST_REV_NBR,' 
                      --E.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION,'
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' E.EST_FNC_COMMENT,CASE WHEN ISNULL(CAST(E.EST_FNC_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN E.EST_FNC_COMMENT ELSE E.EST_FNC_COMMENT_HTML END, E.EST_REV_SUP_BY_CDE, E.EST_REV_SUP_BY_NTE,CASE WHEN ISNULL(CAST(E.EST_REV_SUP_BY_HTML AS VARCHAR(MAX)),'''') = '''' THEN E.EST_REV_SUP_BY_NTE ELSE E.EST_REV_SUP_BY_HTML END,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' '''', '''', '''', '''', '''', '
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
SELECT @sql2 = @sql2 + ' 0,'
                if @GroupOption = 'P'
					    Begin
					        SELECT @sql2 = @sql2 + ' E.EST_PHASE_ID, ISNULL(E.EST_PHASE_DESC, '''') as EST_PHASE_DESC,'
					    End
					 else
					    Begin
					        SELECT @sql2 = @sql2 + ' '''' as EST_PHASE_ID, '''' as EST_PHASE_DESC,'
					    End
SELECT @sql2 = @sql2 + ' ISNULL(FNC_HEADING.FNC_HEADING_ID,0) AS FNC_HEADING_ID, ISNULL(FNC_HEADING.FNC_HEADING_DESC,'''') AS FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ, JOB_LOG.JOB_CLI_REF,
					  EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,'
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' EL.EST_LOG_COMMENT, EC.EST_COMP_COMMENT, EQ.EST_QTE_COMMENT, ESTIMATE_REV.EST_REV_COMMENT,
												 CASE WHEN ISNULL(CAST(EL.EST_LOG_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN EL.EST_LOG_COMMENT ELSE EL.EST_LOG_COMMENT_HTML END,
												 CASE WHEN ISNULL(CAST(EC.EST_COMP_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN EC.EST_COMP_COMMENT ELSE EC.EST_COMP_COMMENT_HTML END,
												 CASE WHEN ISNULL(CAST(EQ.EST_QTE_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN EQ.EST_QTE_COMMENT ELSE EQ.EST_QTE_COMMENT_HTML END,
												 CASE WHEN ISNULL(CAST(ESTIMATE_REV.EST_REV_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN ESTIMATE_REV.EST_REV_COMMENT ELSE ESTIMATE_REV.EST_REV_COMMENT_HTML END,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' '''', '''', '''', '''', '''', '''', '''', '''','
					End
 
				if @FunctionOption = 'N'
					Begin
					   if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)),'
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
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 0
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End	
							if @TaxSeparate = 1 and @CommMUSeparate = 0 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End
							if @TaxSeparate = 0 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
							End
							if @TaxSeparate = 1 and @CommMUSeparate = 1 and @Contingency = 1 and @ContSeparate = 1
							Begin
								SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))),'
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

SELECT @sql2 = @sql2 + ' ISNULL(ESTIMATE_REV.JOB_QTY,0) AS JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, 
                      CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY, 0, 0, CAST((Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))+''''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))) AS int), (Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(7))+''/''+Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))),
                      '''' AS INOUT, JOB_COMPONENT.JOB_FIRST_USE_DATE,'''','''','''',0,0,0,0'

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


SELECT @sqlgroupby = ' GROUP BY EQ.ESTIMATE_NUMBER, EL.EST_LOG_DESC, EQ.EST_COMPONENT_NBR, EC.EST_COMP_DESC,
					  EQ.EST_QUOTE_NBR, EQ.EST_QUOTE_DESC, JOB_LOG.JOB_NUMBER, 
                      JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ESTIMATE_REV.EST_REV_NBR,
                      FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC,'
					  if @FunctionOption = 'R'
						Begin
							SELECT @sqlgroupby = @sqlgroupby + ' E.EST_REV_RATE,'
						End 
--SELECT @sqlgroupby = @sqlgroupby + ' E.EMPLOYEE_TITLE_ID,'
                      if @GroupOption = 'P'
					    Begin
					        SELECT @sqlgroupby = @sqlgroupby + ' E.EST_PHASE_ID, E.EST_PHASE_DESC,'
					    End 
SELECT @sqlgroupby = @sqlgroupby + 'FNC_HEADING.FNC_HEADING_SEQ, JOB_LOG.JOB_CLI_REF,
					  EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION,JOB_COMPONENT.EMP_CODE,  EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,		  
					  ESTIMATE_REV.JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY, JOB_COMPONENT.JOB_FIRST_USE_DATE'

if @FunctionOption = 'N' 
 Begin
	print @sql2 + @sqlfrom + @sqlwhere
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
        SET @sCPU = (@JobQty / 1000.00)
		--SELECT @sCPU
			UPDATE #estPrint
			SET CPM = (@sumCPU + @sumCT) / @sCPU
			WHERE     (EstimateNumber = @EstNum) AND (EstimateComponentNumber = @EstCompNum) AND 
                      (QuoteNumber = @QuoteNum) AND (RevisionNumber = @RevNum)  
End                     
  
		
 SET @RowCount = @RowCount + 1
END

if @PrintID = 0
BEGIN
	UPDATE #estPrint SET FunctionOption = (SELECT FUNCTION_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrint SET GroupOption = (SELECT GROUP_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
	UPDATE #estPrint SET SortOption = (SELECT SORT_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))
END
ELSE
BEGIN
	UPDATE #estPrint SET FunctionOption = @FunctionOption
	UPDATE #estPrint SET GroupOption = @GroupOption
	UPDATE #estPrint SET SortOption = @SortOption
END

UPDATE #estPrint SET TaxSeparate = @TaxSeparate, CommissionSeparate = @CommMUSeparate, ContingencySeparate = @ContSeparate, IncludeContingency = @Contingency

SET @Font = '<span style="font-family: Arial; font-size: 9pt;">'
SET @Font2 = '</span>'

UPDATE #estPrint SET EstimateComment = (SELECT EstComment FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)
UPDATE #estPrint SET EstimateComponentComment = (SELECT EstCompComment FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)
UPDATE #estPrint SET QuoteComment = (SELECT QteComment FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)
UPDATE #estPrint SET RevisionComment = (SELECT RevComment FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)
UPDATE #estPrint SET EstimateCommentHtml = (SELECT CASE WHEN EstCommentHtml = '' THEN  @Font + EstComment + @Font2 ELSE @Font + EstCommentHtml + @Font2 END FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)
UPDATE #estPrint SET EstimateComponentCommentHtml = (SELECT CASE WHEN EstCompCommentHtml = '' THEN  @Font + EstCompComment + @Font2 ELSE @Font + EstCompCommentHtml + @Font2 END FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)
UPDATE #estPrint SET QuoteCommentHtml = (SELECT CASE WHEN QteCommentHtml = '' THEN  @Font + QteComment + @Font2 ELSE @Font + QteCommentHtml + @Font2 END FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)
UPDATE #estPrint SET RevisionCommentHtml = (SELECT CASE WHEN RevCommentHtml = '' THEN  @Font + RevComment + @Font2 ELSE @Font + RevCommentHtml + @Font2 END FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)

if @FunctionOption <> 'N'
Begin

DECLARE @ENum int,@ECNum int, @FRate decimal(15,4),
	@QNum int,@DComment varchar(MAX),@DCommentHtml varchar(MAX),@SComment varchar(MAX),@SCommentHtml varchar(MAX),
	@RNum int, @FCode varchar(6), @ComponentComments varchar(MAX), @QuoteComments varchar(MAX), @DetailComments varchar(MAX), @SuppliedComments varchar(MAX),
	@ComponentCommentsHtml varchar(MAX), @QuoteCommentsHtml varchar(MAX), @DetailCommentsHtml varchar(MAX), @SuppliedCommentsHtml varchar(MAX), @RID int,
	@Comment varchar(MAX), @CommentHtml varchar(MAX)

	SET @DetailComments = ''
	SET @SuppliedComments = ''
	SET @DetailCommentsHtml = ''
	SET @SuppliedCommentsHtml = ''

SELECT @NumberRecords = COUNT(*) FROM #estPrint
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @ENum = EstimateNumber, @ECNum = EstimateComponentNumber, @QNum = QuoteNumber, @RNum = RevisionNumber, @funcHeadingID = FunctionHeadingID, @FRate = EstimateRate 
 FROM #estPrint
 WHERE RowID = @RowCount
 
 			DECLARE comment_col_cursor CURSOR FOR 	    
			SELECT ISNULL(E.EST_FNC_COMMENT,''),ISNULL(E.EST_REV_SUP_BY_NTE,''),ISNULL(E.EST_FNC_COMMENT_HTML,''),ISNULL(E.EST_REV_SUP_BY_HTML,'') 
			FROM ESTIMATE_REV_DET E INNER JOIN
                      FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
                      FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID
			WHERE (E.ESTIMATE_NUMBER = @ENum) AND (E.EST_COMPONENT_NBR = @ECNum)
								 AND (E.EST_QUOTE_NBR = @QNum) AND (E.EST_REV_NBR = @RNum) AND (FNC_HEADING.FNC_HEADING_ID = @funcHeadingID)
			OPEN comment_col_cursor

			FETCH NEXT FROM comment_col_cursor INTO @DComment,@SComment,@DCommentHtml,@SCommentHtml

			WHILE ( @@FETCH_STATUS <> -1 )
			BEGIN
				
				SELECT @DetailComments = @DetailComments + CHAR(13) + CHAR(10) + @DComment
				SELECT @SuppliedComments = @SuppliedComments + CHAR(13) + CHAR(10) + @SComment
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
		
				--SELECT @DCommentHtml,@DetailCommentsHtml
				--SELECT @SCommentHtml,@SuppliedCommentsHtml
				FETCH NEXT FROM comment_col_cursor INTO @DComment,@SComment,@DCommentHtml,@SCommentHtml
			END

			CLOSE comment_col_cursor
			DEALLOCATE comment_col_cursor
	
	    
	
	if @DetailCommentsHtml = ''
	Begin
		SELECT @DetailCommentsHtml = @DetailComments
	End

	if @SuppliedCommentsHtml = ''
	Begin
		SELECT @SuppliedCommentsHtml = @SuppliedComments
	End

	UPDATE #estPrint SET DetailComments = @DetailComments, SuppliedByNotes = @SuppliedComments, DetailCommentsHtml = @Font + @DetailCommentsHtml + @Font2, SuppliedByNotesHtml = @Font + @SuppliedCommentsHtml + @Font2 
	WHERE (#estPrint.EstimateNumber = @ENum) AND (#estPrint.EstimateComponentNumber = @ECNum) AND (#estPrint.QuoteNumber = @QNum) AND (#estPrint.RevisionNumber = @RNum) AND #estPrint.FunctionHeadingID = @funcHeadingID --AND #estPrint.EstimateRate = @FRate

	
	SET @DetailComments = ''
	SET @SuppliedComments = ''
	SET @DetailCommentsHtml = ''
	SET @SuppliedCommentsHtml = ''
 
 --SELECT @qteNum,@func
 --Select @Count  

 SET @RowCount = @RowCount + 1
 END

End
If @FunctionOption = 'N'
Begin
	UPDATE #estPrint SET DetailCommentsHtml = @Font + DetailCommentsHtml + @Font2
	UPDATE #estPrint SET SuppliedByNotesHtml = @Font + SuppliedByNotesHtml + @Font2
End

INSERT INTO #funcheading
SELECT [FNC_HEADING_ID]
      ,[FNC_HEADING_DESC]
      ,[FNC_HEADING_SEQ]
      ,[INACTIVE_FLAG]
	  ,NULL FROM FNC_HEADING ORDER BY FNC_HEADING_SEQ, FNC_HEADING_DESC

SELECT @sql = 'SELECT ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,
	P.USER_DEFINED1 AS ProductUDF1, P.USER_DEFINED2 AS ProductUDF2, P.USER_DEFINED3 AS ProductUDF3, P.USER_DEFINED4 AS ProductUDF4, 
	EstimateNumber, EstimateDescription, EstimateComment,EstimateCommentHtml,EstimateComponentNumber,EstimateComponentDescription,EstimateComponentComment,EstimateComponentCommentHtml,
	EstimateContactID,EstimateContactCode,EstimateContactName,EstimateContactAddress1,EstimateContactAddress2,EstimateContactCity,EstimateContactState,
	EstimateContactZip,EstimateContactCountry,QuoteNumber,QuoteDescription,QuoteComment,QuoteCommentHtml,RevisionNumber,RevisionComment,RevisionCommentHtml,EA.TYPE AS ApprovalType, 
		CASE EA.TYPE
			WHEN 1 THEN ''Internal''
			WHEN 2 THEN ''Client''
			WHEN 1 THEN ''Both''
		END AS ApprovalTypeDescription,	
		EA.CL_EST_APPR_BY AS ClientApprovalName, 
		EA.CL_EST_APPR_DATE AS ClientApprovalDate, 
		EA.IN_EST_APPR_BY AS InternalApprovalName, 
		EA.IN_EST_APPR_DATE AS InternalApprovalDate, JobNumber,JobDescription,JobClientReference,	
    JL.CMP_IDENTIFIER AS CampaignID, C.CMP_CODE AS CampaignCode, C.CMP_NAME AS CampaignName,SalesClassCode,SalesClassDescription,
    JL.CREATE_DATE AS JobCreateDate, JL.JOB_DATE_OPENED AS JobDateOpened,JobComponentNumber,JobComponentDescription,AccountExecutiveCode,AccountExecutiveName,
	JC.JOB_CL_PO_NBR AS JobClientPO, JC.JOB_COMP_DATE AS ComponentDateOpened, JobDueDate, JC.[START_DATE] AS JobStartDate,
    CASE JC.JOB_PROCESS_CONTRL 
			WHEN 1 THEN ''All Processing''
			WHEN 2 THEN ''No Processing''
			WHEN 3 THEN ''A/P and Billing''
			WHEN 4 THEN ''A/P, Time and Billing''
			WHEN 5 THEN ''Billing Only''
			WHEN 6 THEN ''Closed''
			WHEN 7 THEN ''Time and Billing''
			WHEN 8 THEN ''A/P, Time, I/O and Billing''
			WHEN 9 THEN ''A/P, I/O and Billing''
			WHEN 10 THEN ''I/O and Billing''
			WHEN 11 THEN ''Time, I/O and Billing''
			WHEN 12 THEN ''Archive''
		END AS JobProcessingControl, GroupingID = (SELECT RowID FROM #funcheading WHERE EP.FunctionHeadingID = #funcheading.FuncHeadingID), 
	'''' AS FunctionType,FunctionHeadingID,FunctionHeadingDescription,FunctionHeadingSequence,'''' AS FunctionCode,'''' AS FunctionDescription,NULL as FunctionOrder,NULL as SequenceNumber,DetailComments,DetailCommentsHtml,
	SuppliedByCode,	'''' AS SuppliedByName,
	SuppliedByNotes,SuppliedByNotesHtml,
	EstimateQuantity,EstimateRate,EstimateExtAmount, EstimateExtAmount + EstimateTaxAmount AS EstimateNetAmount,
    EstimateExtAmount + EstimateTaxAmount AS EstimateCostAmount, EstimateTaxAmount,
	EstimateMarkupAmount,EstimateTotalAmount,EstimateTotalContingencyAmount,EstimateContingencyAmount,EstimateMarkupContingency,
	'''' AS EstimateFunctionType,EmployeeTitleID,EstimatePhaseID,EstimatePhaseDescription,JobQuantity,CPU,CPM,EstimateComponentQuote,EstimateComponent,InOut,FunctionOption,GroupOption,SortOption,TaxSeparate,CommissionSeparate,ContingencySeparate,IncludeContingency
FROM #estPrint EP INNER JOIN PRODUCT P ON EP.ClientCode = P.CL_CODE AND EP.DivisionCode = P.DIV_CODE AND EP.ProductCode = P.PRD_CODE
				  LEFT OUTER JOIN JOB_COMPONENT JC ON JC.JOB_NUMBER = EP.JobNumber AND JC.JOB_COMPONENT_NBR = EP.JobComponentNumber
				  LEFT OUTER JOIN JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER
				  LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JL.CMP_IDENTIFIER
				  LEFT OUTER JOIN VENDOR V ON EP.SuppliedByCode = V.VN_CODE
				  LEFT OUTER JOIN EMPLOYEE E ON EP.SuppliedByCode = E.EMP_CODE
				  LEFT OUTER JOIN V_ESTIMATEAPPR AS EA ON EA.ESTIMATE_NUMBER = EP.EstimateNumber AND EA.EST_COMPONENT_NBR = EP.EstimateComponentNumber
					AND EA.EST_QUOTE_NBR = EP.QuoteNumber AND EA.EST_REVISION_NBR = EP.RevisionNumber
	  WHERE 1=1'
--SELECT @sql = 'SELECT * FROM #estPrint WHERE 1=1'


if @SuppressZero = 1 and @PrintID = 0
Begin
	SELECT @sql = @sql + ' AND EstimateExtAmount <> 0'
End

if @SuppressZero = 0 and @PrintID <> 0
Begin
	SELECT @sql = @sql + ' AND EstimateExtAmount <> 0'
End

SELECT @sql = @sql + ' ORDER BY EstimateNumber, EstimateComponentNumber, QuoteNumber, RevisionNumber'

if @GroupOption = 'T'
Begin
	SELECT @sql = @sql + ' , FunctionType'
End
if @GroupOption = 'H'
Begin
	SELECT @sql = @sql + ' , FunctionHeadingDescription'
End
if @GroupOption = 'HT'
Begin
	SELECT @sql = @sql + ' , FunctionHeadingSequence, FunctionHeadingDescription'
End
if @GroupOption = 'P'
Begin
	SELECT @sql = @sql + ' , EstimatePhaseDescription'
End
if @GroupOption = 'I'
Begin
	SELECT @sql = @sql + ' , InOut'
End


--if @SortOption = 'C'
--Begin
--	SELECT @sql = @sql + ' , FNC_CODE'
--End
if @SortOption = 'O'
Begin
	SELECT @sql = @sql + ' , FunctionOrder'
End


print @sql
EXEC (@sql)

DROP TABLE #est
DROP TABLE #estComments
DROP TABLE #estPrint
DROP TABLE #funcheading


--SELECT @sql = 'SELECT EQ.ESTIMATE_NUMBER, EL.EST_LOG_DESC, EQ.EST_COMPONENT_NBR, EC.EST_COMP_DESC,
--		   EQ.EST_QUOTE_NBR, EQ.EST_QUOTE_DESC, JOB_LOG.JOB_NUMBER, 
--                      JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ESTIMATE_REV.EST_REV_NBR, E.SEQ_NBR, 
--                      E.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, E.EST_FNC_COMMENT, E.EST_REV_SUP_BY_CDE, 
--                      E.EST_REV_SUP_BY_NTE, E.EST_REV_QUANTITY, E.EST_REV_RATE, 
--                      E.EST_REV_EXT_AMT, E.EST_REV_COMM_PCT, E.EXT_MARKUP_AMT, 
--                      E.LINE_TOTAL, E.EST_REV_CONT_PCT, E.EXT_CONTINGENCY,
--					  E.INCL_CPU, E.EST_FNC_TYPE, E.EMPLOYEE_TITLE_ID, FUNCTIONS.FNC_TYPE,
--					  E.EST_PHASE_ID, ISNULL(E.EST_PHASE_DESC, '''') as EST_PHASE_DESC, FNC_HEADING.FNC_HEADING_ID,
--					  FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ, JOB_LOG.JOB_CLI_REF,
--					  EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, 
--					  EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
--					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, 
--					  EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION, EL.EST_LOG_COMMENT, EC.EST_COMP_COMMENT, EQ.EST_QTE_COMMENT			  
--FROM         ESTIMATE_QUOTE EQ INNER JOIN
--                      ESTIMATE_REV ON EQ.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
--                      EQ.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
--                      EQ.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
--                      ESTIMATE_COMPONENT EC ON EQ.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND 
--                      EQ.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR INNER JOIN
--                      ESTIMATE_LOG EL ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN
--                      ESTIMATE_REV_DET E ON ESTIMATE_REV.ESTIMATE_NUMBER = E.ESTIMATE_NUMBER AND 
--                      ESTIMATE_REV.EST_COMPONENT_NBR = E.EST_COMPONENT_NBR AND 
--                      ESTIMATE_REV.EST_QUOTE_NBR = E.EST_QUOTE_NBR AND 
--                      ESTIMATE_REV.EST_REV_NBR = E.EST_REV_NBR INNER JOIN
--                      FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
--                      JOB_COMPONENT ON EC.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
--                      EC.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR LEFT OUTER JOIN
--                      FNC_HEADING ON FUNCTIONS.FNC_HEADING_ID = FNC_HEADING.FNC_HEADING_ID LEFT OUTER JOIN 
--					  JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
--					  SALES_CLASS ON ESTIMATE_LOG.SC_CODE = SALES_CLASS.SC_CODE LEFT OUTER JOIN
--                      EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE INNER JOIN
--                      PRODUCT ON EL.CL_CODE = PRODUCT.CL_CODE AND EL.DIV_CODE = PRODUCT.DIV_CODE AND 
--                      EL.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
--                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
--                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE
--WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @EstCompNo) AND 
--                      (EQ.EST_QUOTE_NBR = @QuoteNo) AND (ESTIMATE_REV.EST_REV_NBR = @RevNo)'

--if @Phase <> 0
--Begin
--	SELECT @sql = @sql + ' AND E.EST_PHASE_ID = @Phase'
--End
--if @@SuppressZero = 1
--Begin
--	SELECT @sql = @sql + ' AND E.EST_REV_EXT_AMT > 0'
--End
--
--if @SortOption = 'C'
--Begin
--	SELECT @sql = @sql + ' ORDER BY E.FNC_CODE'
--End
--if @SortOption = 'O'
--Begin
--	SELECT @sql = @sql + ' ORDER BY FUNCTIONS.FNC_ORDER'
--End
--
--
--SELECT @paramlist = '@EstNo int, @EstCompNo int, @QuoteNo int, @RevNo int'--, @Phase int'
--print @sql
--EXEC sp_executesql @sql, @paramlist, @EstNo, @EstCompNo, @QuoteNo, @RevNo--, @Phase



















