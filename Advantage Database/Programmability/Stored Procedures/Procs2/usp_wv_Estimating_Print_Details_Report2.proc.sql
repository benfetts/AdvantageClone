if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_Report2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_Report2]
GO






CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_Report2] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Quotes varchar(100),
@ReportType Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int, @Records int, @Count int, @CountRev int, @MaxRev int,
	@EstNum int,
	@EstCompNum int,
	@QuoteNum int,
	@RevNum int,
	@JobNum int,
	@JobCompNum int,
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
	@CPU decimal(15,3),
	@CPM decimal(15,3),
	@ExclEmpTime smallint,
	@ExclVendor smallint,
	@ExclIO smallint,
	@sumCT decimal(20,4),
	@ExclNonBill smallint

CREATE TABLE #est(
	RowID int IDENTITY(1, 1), 
	EstNo int,
	EstCompNo int,
	QuoteNo int,
	RevNo int)

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
	CPU         		decimal(15,3),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20),
	ESTCOMP				varchar(20),
	INOUT               char(1),
	FNC_ORDER           smallint,
	JOB_DUE_DATE        smalldatetime,
	AD_NBR				varchar(30),
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
	ESTIMATE_NUMBER		int,
	EST_LOG_DESC		varchar(60) NULL,
	EST_COMPONENT_NBR	smallint,
	EST_COMP_DESC		varchar(60) NULL,
	--EST_QUOTE_NBR		smallint,
	--EST_QUOTE_DESC		varchar(60) NULL,
	JOB_NUMBER			int,
	JOB_DESC			varchar(60) NULL,
	JOB_COMPONENT_NBR	smallint,
	JOB_COMP_DESC		varchar(60) NULL,
	--EST_REV_NBR 		smallint NULL,
	--SEQ_NBR 			int,
	FNC_CODE			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
	CONT_CODE           varchar(6),
	CONT_FML            varchar(100),
	CONT_ADDRESS1       varchar(40),
	CONT_ADDRESS2       varchar(40),
	CONT_CITY           varchar(30),
	CONT_STATE          varchar(10),
	CONT_ZIP            varchar(10),
	CONT_COUNTRY        varchar(20),
	CPU         		decimal(15,3),
	CPM         		decimal(15,3),
	ESTCOMPQUOTE		varchar(20),
	ESTCOMP				varchar(20),
	INOUT               char(1),
	FNC_ORDER           smallint,
	JOB_DUE_DATE        smalldatetime,
	AD_NBR				varchar(30),
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
	QUOTE_4_LINE_CONT_TOTAL  decimal(14,2),
	QUOTE_1_QTE_COMMENT varchar(MAX),
	QUOTE_2_QTE_COMMENT varchar(MAX),
	QUOTE_3_QTE_COMMENT varchar(MAX),
	QUOTE_4_QTE_COMMENT varchar(MAX))


SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0), @FunctionOption = ISNULL(FUNCTION_OPTION, ''), 
                      @GroupOption = ISNULL(GROUP_OPTION, ''), @SortOption = ISNULL(SORT_OPTION, ''), @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @Specs = ISNULL(SPECS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), 
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ContSeparate = ISNULL(CONT_SEPARATE, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
FROM        ESTIMATE_PRINT_DEF
WHERE     (UPPER(USER_ID) = UPPER(@UserID))

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
        

--SELECT * FROM #est

SELECT @client = CL_CODE, @division = DIV_CODE, @product = PRD_CODE
FROM ESTIMATE_LOG
WHERE ESTIMATE_NUMBER = @EstNo

SELECT @ProdConsFunc = PRD_CONSOL_FUNC
FROM PRODUCT
WHERE CL_CODE = @client AND DIV_CODE = @division AND PRD_CODE = @product

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
--SELECT @NumberRecords 
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
					        SELECT @sql2 = @sql2 + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ,'
					    End 
SELECT @sql2 = @sql2 + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION, '''', '''', '''', '''',
					 SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0))) AS TAX,'
					

SELECT @sql2 = @sql2 + ' ISNULL(ESTIMATE_REV.JOB_QTY,0) AS JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, 
                      CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY, 0, 0, (Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))+''/''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))), (Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(7))+''/''+Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))),'                      
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
                    SELECT @sql2 = @sql2 + ' JOB_COMPONENT.JOB_FIRST_USE_DATE, ISNULL(JOB_COMPONENT.AD_NBR,'''') AS AD_NBR, EL.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME,'    
					if @RowCount = 1
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
														 SUM(E.EXT_MARKUP_AMT), SUM(ISNULL(E.EXT_CONTINGENCY,0)), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
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
					Else if @RowCount = 2
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
														 SUM(E.EXT_MARKUP_AMT), SUM((ISNULL(E.EXT_CONTINGENCY,0))), SUM(E.EXT_MU_CONT), SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))), ISNULL(ESTIMATE_REV.JOB_QTY,0), 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00'
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
					Else if @RowCount = 3
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
					Else if @RowCount = 4
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
								SELECT @sql2 = @sql2 + ' 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 00, 0.00, 0.00, 0.00, SUM(E.EST_REV_EXT_AMT) + SUM(ISNULL(E.EXT_CONTINGENCY,0)),
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


	print @sql2 + @sqlfrom + @sqlwhere + @sqlgroupby
	EXEC (@sql2 + @sqlfrom + @sqlwhere + @sqlgroupby)


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
if @RowCount = 1
Begin
    UPDATE #estPrint
        SET QUOTE_1_LINE_TOTAL = @sumCPU, QUOTE_1_LINE_CONT_TOTAL = @sumCT
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End  
if @RowCount = 2
Begin
    UPDATE #estPrint
        SET QUOTE_2_LINE_TOTAL = @sumCPU, QUOTE_2_LINE_CONT_TOTAL = @sumCT
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End  
if @RowCount = 3
Begin
    UPDATE #estPrint
        SET QUOTE_3_LINE_TOTAL = @sumCPU, QUOTE_3_LINE_CONT_TOTAL = @sumCT
        WHERE     (ESTIMATE_NUMBER = @EstNum) AND (EST_COMPONENT_NBR = @EstCompNum) AND 
                              (EST_QUOTE_NBR = @QuoteNum) AND (EST_REV_NBR = @RevNum) 
End  
if @RowCount = 4
Begin
    UPDATE #estPrint
        SET QUOTE_4_LINE_TOTAL = @sumCPU, QUOTE_4_LINE_CONT_TOTAL = @sumCT
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

SELECT @sql = 'INSERT INTO #estPrintData 
				SELECT ESTIMATE_NUMBER, EST_LOG_DESC, EST_COMPONENT_NBR, EST_COMP_DESC, JOB_NUMBER,
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
				 0, CDP_CONTACT_ID, CONT_CODE, CONT_FML, CONT_ADDRESS1, CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY, 0, 0, 0, ESTCOMP, INOUT, FNC_ORDER, JOB_DUE_DATE, AD_NBR, CMP_IDENTIFIER, CMP_CODE, CMP_NAME, SUM(QUOTE_1) AS QUOTE_1, SUM(QUOTE_1_MU) AS QUOTE_1_MU,				 
				 SUM(QUOTE_1_CONT) AS QUOTE_1_CONT, SUM(QUOTE_1_MU_CONT) AS QUOTE_1_MU_CONT, SUM(QUOTE_1_TAX) AS QUOTE_1_TAX, SUM(QUOTE_1_JOB_QTY) AS QUOTE_1_JOB_QTY, SUM(QUOTE_1_CPU) AS QUOTE_1_CPU, SUM(QUOTE_1_CPM) AS QUOTE_1_CPM, SUM(QUOTE_1_LINE_TOTAL) AS QUOTE_1_LINE_TOTAL, 
				 SUM(QUOTE_2) AS QUOTE_2, SUM(QUOTE_2_MU) AS QUOTE_2_MU, SUM(QUOTE_2_CONT) AS QUOTE_2_CONT, SUM(QUOTE_2_MU_CONT) AS QUOTE_2_MU_CONT, SUM(QUOTE_2_TAX) AS QUOTE_2_TAX, SUM(QUOTE_2_JOB_QTY) AS QUOTE_2_JOB_QTY, SUM(QUOTE_2_CPU) AS QUOTE_2_CPU,
				 SUM(QUOTE_2_CPM) AS QUOTE_2_CPM,  SUM(QUOTE_2_LINE_TOTAL) AS QUOTE_2_LINE_TOTAL, SUM(QUOTE_3) AS QUOTE_3, SUM(QUOTE_3_MU) AS QUOTE_3_MU, SUM(QUOTE_3_CONT) AS QUOTE_3_CONT, SUM(QUOTE_3_MU_CONT) AS QUOTE_3_MU_CONT, SUM(QUOTE_3_TAX) AS QUOTE_3_TAX, SUM(QUOTE_3_JOB_QTY) AS QUOTE_3_JOB_QTY,
				 SUM(QUOTE_3_CPU) AS QUOTE_3_CPU, SUM(QUOTE_3_CPM) AS QUOTE_3_CPM, SUM(QUOTE_3_LINE_TOTAL) AS QUOTE_3_LINE_TOTAL, SUM(QUOTE_4) AS QUOTE_4, SUM(QUOTE_4_MU) AS QUOTE_4_MU, SUM(QUOTE_4_CONT) AS QUOTE_4_CONT, SUM(QUOTE_4_MU_CONT) AS QUOTE_4_MU_CONT, SUM(QUOTE_4_TAX) AS QUOTE_4_TAX,
				 SUM(QUOTE_4_JOB_QTY) AS QUOTE_4_JOB_QTY, SUM(QUOTE_4_CPU) AS QUOTE_4_CPU, SUM(QUOTE_4_CPM) AS QUOTE_4_CPM, SUM(QUOTE_4_LINE_TOTAL) AS QUOTE_4_LINE_TOTAL, SUM(QUOTE_1_LINE_CONT_TOTAL) AS QUOTE_1_LINE_CONT_TOTAL, SUM(QUOTE_2_LINE_CONT_TOTAL) AS QUOTE_3_LINE_CONT_TOTAL, SUM(QUOTE_3_LINE_CONT_TOTAL) AS QUOTE_3_LINE_CONT_TOTAL, SUM(QUOTE_4_LINE_CONT_TOTAL) AS QUOTE_4_LINE_CONT_TOTAL,
				 '''' AS QUOTE_1_QTE_COMMENT,'''' AS QUOTE_2_QTE_COMMENT,'''' AS QUOTE_3_QTE_COMMENT,'''' AS QUOTE_4_QTE_COMMENT'
				 
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
                      CONT_ADDRESS2, CONT_CITY, CONT_STATE, CONT_ZIP, CONT_COUNTRY, ESTCOMP, INOUT, FNC_ORDER, JOB_DUE_DATE, AD_NBR, CMP_IDENTIFIER, CMP_CODE, CMP_NAME'

SELECT @sqlgroupby2 = @sqlgroupby2 + ' ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR'

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
 SELECT @func = FNC_CODE
 FROM #estPrintData
 WHERE RowID = @RowCount

 SELECT @funcdesc = FNC_DESCRIPTION, @funcorder = FNC_ORDER
 FROM FUNCTIONS
 WHERE FNC_CODE = @func
 
UPDATE #estPrintData 
SET FNC_DESCRIPTION = @funcdesc, FNC_ORDER = @funcorder
WHERE FNC_CODE = @func

SELECT @sumCPU = QUOTE_1_LINE_TOTAL, @sumCT = QUOTE_1_LINE_CONT_TOTAL
FROM #estPrintData
WHERE QUOTE_1_LINE_TOTAL <> 0

UPDATE #estPrintData
SET QUOTE_1_LINE_TOTAL = @sumCPU
WHERE QUOTE_1_LINE_TOTAL = 0

SELECT @JobQty = QUOTE_1_JOB_QTY
FROM #estPrintData
WHERE QUOTE_1_JOB_QTY <> 0

UPDATE #estPrintData
SET QUOTE_1_JOB_QTY = @JobQty
WHERE QUOTE_1_JOB_QTY = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET QUOTE_1_CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
		UPDATE #estPrintData
		SET QUOTE_1_CPM = (@sumCPU + @sumCT) / (@JobQty / 1000) 
End         

SET @sumCPU = 0
SET @sumCT = 0
SELECT @sumCPU = QUOTE_2_LINE_TOTAL, @sumCT = QUOTE_2_LINE_CONT_TOTAL
FROM #estPrintData
WHERE QUOTE_2_LINE_TOTAL <> 0

UPDATE #estPrintData
SET QUOTE_2_LINE_TOTAL = @sumCPU
WHERE QUOTE_2_LINE_TOTAL = 0

SET @JobQty = 0
SELECT @JobQty = QUOTE_2_JOB_QTY
FROM #estPrintData
WHERE QUOTE_2_JOB_QTY <> 0

UPDATE #estPrintData
SET QUOTE_2_JOB_QTY = @JobQty
WHERE QUOTE_2_JOB_QTY = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET QUOTE_2_CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
			UPDATE #estPrintData
			SET QUOTE_2_CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)
End        

SET @sumCPU = 0
SET @sumCT = 0
SELECT @sumCPU = QUOTE_3_LINE_TOTAL, @sumCT = QUOTE_3_LINE_CONT_TOTAL
FROM #estPrintData
WHERE QUOTE_3_LINE_TOTAL <> 0

UPDATE #estPrintData
SET QUOTE_3_LINE_TOTAL = @sumCPU
WHERE QUOTE_3_LINE_TOTAL = 0

SET @JobQty = 0
SELECT @JobQty = QUOTE_3_JOB_QTY
FROM #estPrintData
WHERE QUOTE_3_JOB_QTY <> 0

UPDATE #estPrintData
SET QUOTE_3_JOB_QTY = @JobQty
WHERE QUOTE_3_JOB_QTY = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET QUOTE_3_CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
			UPDATE #estPrintData
			SET QUOTE_3_CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)
End    

SET @sumCPU = 0
SET @sumCT = 0
SELECT @sumCPU = QUOTE_4_LINE_TOTAL, @sumCT = QUOTE_4_LINE_CONT_TOTAL
FROM #estPrintData
WHERE QUOTE_4_LINE_TOTAL <> 0

UPDATE #estPrintData
SET QUOTE_4_LINE_TOTAL = @sumCPU
WHERE QUOTE_4_LINE_TOTAL = 0

SET @JobQty = 0
SELECT @JobQty = QUOTE_4_JOB_QTY
FROM #estPrintData
WHERE QUOTE_4_JOB_QTY <> 0

UPDATE #estPrintData
SET QUOTE_4_JOB_QTY = @JobQty
WHERE QUOTE_4_JOB_QTY = 0

SET @CPU = 0
if @JobQty <> 0
Begin
        UPDATE #estPrintData
        SET QUOTE_4_CPU = (@sumCPU / @JobQty)
        SET @CPU = (@sumCPU / @JobQty)
End 
if @JobQty <> 0
Begin
			UPDATE #estPrintData
			SET QUOTE_4_CPM = (@sumCPU + @sumCT) / (@JobQty / 1000)        
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
		SET QUOTE_1_QTE_COMMENT = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
		
	End
	if @RowCount = 2
	Begin
		UPDATE #estPrintData
		SET QUOTE_2_QTE_COMMENT = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
	End
	if @RowCount = 3
	Begin
		UPDATE #estPrintData
		SET QUOTE_3_QTE_COMMENT = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
	End
	if @RowCount = 4
	Begin
		UPDATE #estPrintData
		SET QUOTE_4_QTE_COMMENT = (SELECT EST_QTE_COMMENT FROM ESTIMATE_QUOTE EQC
								   WHERE EQC.ESTIMATE_NUMBER = @EstNum AND
									  EQC.EST_COMPONENT_NBR = @EstCompNum AND
									  EQC.EST_QUOTE_NBR = @QuoteNum)
	End

	SET @RowCount = @RowCount + 1
END


SELECT * FROM #estPrintData ORDER BY ESTIMATE_NUMBER, EST_COMPONENT_NBR,FNC_ORDER



DROP TABLE #est
DROP TABLE #estPrint
DROP TABLE #estPrintData





















