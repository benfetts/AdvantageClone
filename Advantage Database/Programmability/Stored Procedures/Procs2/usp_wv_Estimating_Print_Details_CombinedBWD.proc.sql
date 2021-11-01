if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_CombinedBWD]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_CombinedBWD]
GO


CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_CombinedBWD] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Comps varchar(100),
@Quotes varchar(100),
@Groupby varchar(2)

--@Phase Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int, @Records int, @Count int, @Recordquote int, @Countquote int,
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
	@conttitle varchar(40),
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
	@ExclNonBill smallint

CREATE TABLE #est(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int)

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
	CONT_CITY           varchar(30),
	CONT_STATE          varchar(10),
	CONT_ZIP            varchar(10),
	CONT_COUNTRY        varchar(20),
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20),
	INOUT               char(1),
	FNC_ORDER           smallint,
	JOB_CL_PO_NBR       varchar(40),
	EMP_TITLE           varchar(50),
	CONT_TITLE           varchar(40))

SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0), @FunctionOption = ISNULL(FUNCTION_OPTION, ''), 
                      @GroupOption = ISNULL(GROUP_OPTION, ''), @SortOption = ISNULL(SORT_OPTION, ''), @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @Specs = ISNULL(SPECS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), @ContSeparate = ISNULL(CONT_SEPARATE, 0), 
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
FROM        ESTIMATE_PRINT_DEF
WHERE     (UPPER(USER_ID) = UPPER(@UserID))

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
			WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @cpNum) AND (EQ.EST_QUOTE_NBR = @qteNum)
			Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
					   EQ.EST_QUOTE_NBR

	SET @Count = @Count + 1	
	SET @Countquote = @Countquote + 1	           
END

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
						SELECT @sql2 = @sql2 + ' E.EST_REV_RATE,'
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
SELECT @sql2 = @sql2 + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
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
                      ISNULL(CDP_CONTACT_HDR.CONT_ZIP,''''), ISNULL(CDP_CONTACT_HDR.CONT_COUNTRY,''''), 0, 0, (Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(7))+''/''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))),'                      
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
	                        SELECT @sql2 = @sql2 + ' 0 AS FNC_ORDER'
                        End      
                    Else if ((@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C')
                        Begin
	                        SELECT @sql2 = @sql2 + ' 0 AS FNC_ORDER'
                        End 
                    Else
                        Begin
	                        SELECT @sql2 = @sql2 + ' ISNULL(FUNCTIONS.FNC_ORDER,0) AS FNC_ORDER'
                        End      
SELECT @sql2 = @sql2 + ', JOB_COMPONENT.JOB_CL_PO_NBR, EMPLOYEE.EMP_TITLE, ISNULL(CDP_CONTACT_HDR.CONT_TITLE,'''')'
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
					 -- if @FunctionOption = 'R'
						--Begin
							SELECT @sqlgroupby = @sqlgroupby + ' E.EST_REV_RATE,'
						--End
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
SELECT @sqlgroupby = @sqlgroupby + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,		  
					  ESTIMATE_REV.JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY, JOB_COMPONENT.JOB_CL_PO_NBR, EMPLOYEE.EMP_TITLE, CDP_CONTACT_HDR.CONT_TITLE'
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
	--print @sql2 + @sqlfrom + @sqlwhere + @sqlgroupby
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
     
if @JobQty = 0
    Begin
        UPDATE #estPrint
        SET CPU = 0
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum)
    End
Else
    Begin
		SET @sCPU = (@sumCPU / @JobQty)
        UPDATE #estPrint
        SET CPU = @sCPU
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum)
    End                 
 
if @JobQty = 0
Begin
        UPDATE #estPrint
        SET CPM = 0
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End
Else
Begin
		SET @sCPU = (@JobQty / 1000)
		--SELECT @sCPU
			UPDATE #estPrint
			SET CPM = (@sumCPU + @sumCT) / @sCPU
			WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
								  (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End                     
  
		
 SET @RowCount = @RowCount + 1
END

SELECT @NumberRecords = COUNT(*) FROM #estPrint
SET @RowCount = 1


WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @func = FNC_CODE
 FROM #estPrint
 WHERE RowID = @RowCount

 SELECT @funcdesc = FNC_DESCRIPTION, @funcorder = FNC_ORDER
 FROM FUNCTIONS
 WHERE FNC_CODE = @func
 
UPDATE #estPrint 
SET FNC_DESCRIPTION = @funcdesc, FNC_ORDER = @funcorder
WHERE FNC_CODE = @func

 

SET @RowCount = @RowCount + 1
END


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
	SELECT DISTINCT @jobnumber = JOB_NUMBER, @jobdesc =  ISNULL(JOB_DESC,''), @jobclientref = ISNULL(JOB_CLI_REF,'')
	 FROM #estPrint
	 WHERE JOB_NUMBER IS NOT NULL

	SELECT DISTINCT @cdpid = CDP_CONTACT_ID, @contcode = ISNULL(CONT_CODE,''), @contfml = ISNULL(CONT_FML,''), @conta1 = ISNULL(CONT_ADDRESS1,''), @conta2 = ISNULL(CONT_ADDRESS2,''), @contcity = ISNULL(CONT_CITY,''), @contstate = ISNULL(CONT_STATE,''), @contzip = ISNULL(CONT_ZIP,''), @contcountry = ISNULL(CONT_COUNTRY,''), @conttitle = ISNULL(CONT_TITLE,'')
	FROM #estPrint
	WHERE CDP_CONTACT_ID IS NOT NULL


	SELECT @sql = 'SELECT ESTIMATE_NUMBER, EST_LOG_DESC, EST_QUOTE_NBR, FNC_CODE, FNC_DESCRIPTION, ''' + Cast(@jobnumber AS Varchar(7)) + ''' AS JOB_NUMBER, ''' + @jobdesc + ''' AS JOB_DESC,'
					if @FunctionOption = 'N'
						Begin
							SELECT @sql = @sql + ' '''' AS EST_FNC_COMMENT, '''' AS EST_REV_SUP_BY_CDE, '''' AS EST_REV_SUP_BY_NTE, '
						End	
					Else
						Begin
							SELECT @sql = @sql + ' '''' AS EST_FNC_COMMENT, '''' AS EST_REV_SUP_BY_CDE, '''' AS EST_REV_SUP_BY_NTE, '
						End 
	SELECT @sql = @sql + ' SUM(EST_REV_QUANTITY) AS EST_REV_QUANTITY, EST_REV_RATE, SUM(EST_REV_EXT_AMT) AS EST_REV_EXT_AMT,
					 SUM(EXT_MARKUP_AMT) AS EXT_MARKUP_AMT, SUM(LINE_TOTAL) AS LINE_TOTAL, SUM(EXT_CONTINGENCY) AS EXT_CONTINGENCY, SUM(EXT_MU_CONT) AS EXT_MU_CONT, EST_FNC_TYPE, EMPLOYEE_TITLE_ID,
					 FNC_TYPE,'
					if @GroupOption = 'P'
							Begin
								SELECT @sql = @sql + ' EST_PHASE_ID, EST_PHASE_DESC,'
							End
						 else
							Begin
								SELECT @sql = @sql + ' '''' as EST_PHASE_ID, '''' as EST_PHASE_DESC,'
							End 
					if @GroupOption = 'H' OR @GroupOption = 'HT'
							Begin
								SELECT @sql = @sql + ' FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ,'
							End
						 else
							Begin
								SELECT @sql = @sql + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
							End 
	SELECT @sql = @sql + ' ''' + @jobclientref + ''' AS JOB_CLI_REF, SC_CODE, SC_DESCRIPTION, CL_CODE, CL_NAME, DIV_CODE, DIV_NAME, PRD_CODE, PRD_DESCRIPTION,'
					if @FunctionOption = 'N'
						Begin
							SELECT @sql = @sql + ' '''' AS EST_LOG_COMMENT, '''' AS EST_COMP_COMMENT, '''' AS EST_QTE_COMMENT, '''' AS EST_REV_COMMENT,'
						End	
					Else
						Begin
							SELECT @sql = @sql + ' '''' AS EST_LOG_COMMENT, '''' AS EST_COMP_COMMENT, '''' AS EST_QTE_COMMENT, '''' AS EST_REV_COMMENT,'
						End
	SELECT @sql = @sql + ' SUM(TAX) AS TAX, SUM(JOB_QTY) AS JOB_QTY, ''' + Cast(@cdpid AS Varchar(5)) + ''' AS CDP_CONTACT_ID, ''' + @contcode + ''' AS CONT_CODE, ''' + @contfml + ''' AS CONT_FML, ''' + @conta1 + ''' AS CONT_ADDRESS1,
					 ''' + @conta2 + ''' AS CONT_ADDRESS2, ''' + @contcity + ''' AS CONT_CITY, ''' + @contstate + ''' AS CONT_STATE, ''' + @contzip + ''' AS CONT_ZIP, ''' + @contcountry + ''' AS CONT_COUNTRY, SUM(CPU) AS CPU, SUM(CPM) AS CPM, 
					 ESTCOMPQUOTE, INOUT, FNC_ORDER, JOB_CL_PO_NBR, EMP_TITLE, ''' + @conttitle + ''' AS CONT_TITLE
				  FROM #estPrint WHERE 1=1'

	--if @Phase <> 0
	--Begin
	--	SELECT @sql = @sql + ' AND E.EST_PHASE_ID = @Phase'
	--End
	if @SuppressZero = 1
	Begin
		SELECT @sql = @sql + ' AND EST_REV_EXT_AMT <> 0'
	End

	SELECT @sql = @sql + ' GROUP BY ESTIMATE_NUMBER, EST_LOG_DESC, EST_QUOTE_NBR,
						  FNC_CODE, FNC_DESCRIPTION, EST_REV_RATE, EST_FNC_TYPE, EMPLOYEE_TITLE_ID, FNC_TYPE,'
						  if @GroupOption = 'P'
							Begin
								SELECT @sql = @sql + ' EST_PHASE_ID, EST_PHASE_DESC,'
							End	
						  if @GroupOption = 'H' OR @GroupOption = 'HT'
							Begin
								SELECT @sql = @sql + ' FNC_HEADING_ID, FNC_HEADING_DESC, FNC_HEADING_SEQ,'
							End	  
	SELECT @sql = @sql + ' SC_CODE, SC_DESCRIPTION, CL_CODE, CL_NAME, DIV_CODE, 
						  DIV_NAME, PRD_CODE, PRD_DESCRIPTION, ESTCOMPQUOTE, INOUT, FNC_ORDER, JOB_CL_PO_NBR, EMP_TITLE'

	SELECT @sql = @sql + ' ORDER BY ESTIMATE_NUMBER, EST_QUOTE_NBR'

	if @GroupOption = 'T'
	Begin
		SELECT @sql = @sql + ' , FNC_TYPE'
	End
	if @GroupOption = 'H' OR @GroupOption = 'HT'
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

DROP TABLE #est
DROP TABLE #estPrint
DROP TABLE #comps
DROP TABLE #quotes



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

















