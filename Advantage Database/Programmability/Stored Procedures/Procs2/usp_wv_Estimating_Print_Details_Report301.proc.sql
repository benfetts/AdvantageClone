if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Print_Details_Report301]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Print_Details_Report301]
GO







CREATE PROCEDURE [dbo].[usp_wv_Estimating_Print_Details_Report301] 
@EstNo Int,
@EstCompNo Int,
@UserID varchar(100),
@Quotes varchar(100)
--@Phase Int
AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int, @Font varchar(50), @Font2 varchar(10), @Font3 varchar(50),
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
	@ProdConsFunc smallint,
	@client varchar(6), 
	@division varchar(6),
	@product varchar(6),
	@func varchar(6),
	@funcdesc varchar(30),
	@funcorder smallint,
	@ContSeparate smallint,
	@ClientCode as varchar(6)

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
	RevCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DefaultComment varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DefaultCommentHtml varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL)

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
	FunctionCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FunctionDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
	--EST_PHASE_ID		smallint,
	--EST_PHASE_DESC		varchar(60) NULL,
	--FNC_HEADING_ID		int,
	--FNC_HEADING_DESC	varchar(60) NULL,
	--FNC_HEADING_SEQ		int,
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
	QuoteComment		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevisionComment     varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DefaultComment      varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	EstimateCommentHtml		text,
	EstimateComponentCommentHtml	text,
	QuoteCommentHtml		varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	RevisionCommentHtml     varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DefaultCommentHtml      varchar(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
	EstimateContactPhone		  varchar(13),
	EstimateContactFax			  varchar(13),
	EstimateContactEmail		  varchar(50),
	EstimateContactTitle       varchar(40),
	CPU         		decimal(15,4),
	CPM         		decimal(15,3),
	EstimateComponentQuote		varchar(20),
	EstimateComponent             varchar(20),
	InOut               char(1),
	FunctionOrder           smallint,
	JobDueDate        smalldatetime,
	JobClientPO       varchar(40),
	JobBudget  decimal(11,2),
	PIF varchar(MAX),
	FiscalPeriod varchar(MAX),
	FunctionOption varchar(2),
	GroupOption  varchar(2),
	SortOption varchar(2),
	TaxSeparate smallint,
	CommissionSeparate smallint,
	ContingencySeparate smallint, 
	IncludeContingency smallint,
	TacticID varchar(MAX))

SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0), @FunctionOption = ISNULL(FUNCTION_OPTION, ''), 
                      @GroupOption = ISNULL(GROUP_OPTION, ''), @SortOption = ISNULL(SORT_OPTION, ''), @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @Specs = ISNULL(SPECS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), 
                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0)
FROM        ESTIMATE_PRINT_DEF
WHERE     (UPPER(USER_ID) = UPPER(@UserID))

SELECT @client = CL_CODE, @division = DIV_CODE, @product = PRD_CODE
FROM ESTIMATE_LOG
WHERE ESTIMATE_NUMBER = @EstNo

SELECT @ProdConsFunc = PRD_CONSOL_FUNC
FROM PRODUCT
WHERE CL_CODE = @client AND DIV_CODE = @division AND PRD_CODE = @product

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
                              INNER JOIN charlist_to_table(@Quotes, DEFAULT) c ON EQ.EST_QUOTE_NBR = c.vstr collate database_default
        WHERE     (EQ.ESTIMATE_NUMBER = @EstNo) AND (EQ.EST_COMPONENT_NBR = @EstCompNo) 
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		           EQ.EST_QUOTE_NBR
		           
UPDATE #est SET EstComment = (SELECT ISNULL(EST_LOG_COMMENT,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompComment = (SELECT ISNULL(EST_COMP_COMMENT,'') FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteComment = (SELECT ISNULL(EST_QTE_COMMENT,'') FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevComment = (SELECT ISNULL(EST_REV_COMMENT,'') FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		           
UPDATE #est SET EstCommentHtml = (SELECT ISNULL(EST_LOG_COMMENT_HTML,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET EstCompCommentHtml = (SELECT ISNULL(EST_COMP_COMMENT_HTML,'') FROM ESTIMATE_COMPONENT WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR)
UPDATE #est SET QteCommentHtml = (SELECT ISNULL(EST_QTE_COMMENT_HTML,'') FROM ESTIMATE_QUOTE WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR)
UPDATE #est SET RevCommentHtml = (SELECT ISNULL(EST_REV_COMMENT_HTML,'') FROM ESTIMATE_REV WHERE EstNo = ESTIMATE_NUMBER AND EstCompNo = EST_COMPONENT_NBR AND QuoteNo = EST_QUOTE_NBR AND RevNo = EST_REV_NBR)		           
UPDATE #est SET DefaultComment = (SELECT ISNULL(EST_FTR_COMMENT,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)
UPDATE #est SET DefaultCommentHtml = (SELECT ISNULL(EST_FTR_COMMENT_HTML,'') FROM ESTIMATE_LOG WHERE EstNo = ESTIMATE_NUMBER)


SET @NumberRecords = @@ROWCOUNT
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
						SELECT @sql2 = @sql2 + ' (ISNULL(EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)) AS EXT_CONTINGENCY,'
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_CONTINGENCY,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0))) AS EXT_CONTINGENCY,'
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
--                if @GroupOption = 'P'
--					    Begin
--					        SELECT @sql2 = @sql2 + ' E.EST_PHASE_ID, ISNULL(E.EST_PHASE_DESC, '''') as EST_PHASE_DESC,'
--					    End
--					 else
--					    Begin
--					        SELECT @sql2 = @sql2 + ' '''' as EST_PHASE_ID, '''' as EST_PHASE_DESC,'
--					    End 
--			    if @GroupOption = 'H'
--					    Begin
--					        SELECT @sql2 = @sql2 + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
--					    End
--					 else
--					    Begin
--					        SELECT @sql2 = @sql2 + ' 0 as FNC_HEADING_ID, '''' as FNC_HEADING_DESC, 0 as FNC_HEADING_SEQ, '
--					    End 
SELECT @sql2 = @sql2 + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,'
				if @FunctionOption = 'N'
					Begin
						SELECT @sql2 = @sql2 + ' EL.EST_LOG_COMMENT, EC.EST_COMP_COMMENT, EQ.EST_QTE_COMMENT, ESTIMATE_REV.EST_REV_COMMENT,'''',
												 CASE WHEN ISNULL(CAST(EL.EST_LOG_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN EL.EST_LOG_COMMENT ELSE EL.EST_LOG_COMMENT_HTML END,
												 CASE WHEN ISNULL(CAST(EC.EST_COMP_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN EC.EST_COMP_COMMENT ELSE EC.EST_COMP_COMMENT_HTML END,
												 CASE WHEN ISNULL(CAST(EQ.EST_QTE_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN EQ.EST_QTE_COMMENT ELSE EQ.EST_QTE_COMMENT_HTML END,
												 CASE WHEN ISNULL(CAST(ESTIMATE_REV.EST_REV_COMMENT_HTML AS VARCHAR(MAX)),'''') = '''' THEN ESTIMATE_REV.EST_REV_COMMENT ELSE ESTIMATE_REV.EST_REV_COMMENT_HTML END,'''','
					End	
				Else
					Begin
						SELECT @sql2 = @sql2 + ' '''','''','''','''','''','''','''','''','''','''','
					End
 
				if @FunctionOption = 'N'
					Begin
					   SELECT @sql2 = @sql2 + ' (ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0)) AS TAX,'			  		
					End	
				Else
					Begin
					   SELECT @sql2 = @sql2 + ' SUM((ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0))) AS TAX,'					        
					End

SELECT @sql2 = @sql2 + ' ISNULL(ESTIMATE_REV.JOB_QTY,0) AS JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, 
                      CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY,CDP_CONTACT_HDR.CONT_TELEPHONE,CDP_CONTACT_HDR.CONT_FAX,CDP_CONTACT_HDR.EMAIL_ADDRESS,CDP_CONTACT_HDR.CONT_TITLE, 0, 0, (Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))+''/''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))), (Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(3))+''/''+Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))),'                      
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
SELECT @sql2 = @sql2 + ' JOB_COMPONENT.JOB_FIRST_USE_DATE, JOB_COMPONENT.JOB_CL_PO_NBR, JOB_COMPONENT.JOB_COMP_BUDGET_AM,'''','''','''','''','''',0,0,0,0,''''' 
SELECT @sqlfrom = '	FROM ESTIMATE_QUOTE AS EQ INNER JOIN
                      ESTIMATE_REV ON EQ.ESTIMATE_NUMBER = ESTIMATE_REV.ESTIMATE_NUMBER AND 
                      EQ.EST_COMPONENT_NBR = ESTIMATE_REV.EST_COMPONENT_NBR AND 
                      EQ.EST_QUOTE_NBR = ESTIMATE_REV.EST_QUOTE_NBR INNER JOIN
                      ESTIMATE_COMPONENT AS EC ON EQ.ESTIMATE_NUMBER = EC.ESTIMATE_NUMBER AND 
                      EQ.EST_COMPONENT_NBR = EC.EST_COMPONENT_NBR INNER JOIN
                      ESTIMATE_LOG AS EL ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN
                      ESTIMATE_REV_DET AS E ON ESTIMATE_REV.ESTIMATE_NUMBER = E.ESTIMATE_NUMBER AND 
                      ESTIMATE_REV.EST_COMPONENT_NBR = E.EST_COMPONENT_NBR AND ESTIMATE_REV.EST_QUOTE_NBR = E.EST_QUOTE_NBR AND 
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
                      CAMPAIGN ON JOB_LOG.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER LEFT OUTER JOIN
                      CDP_CONTACT_HDR ON EC.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID'

SELECT @sqlwhere = ' WHERE (EQ.ESTIMATE_NUMBER = ''' + Cast(@EstNum AS Varchar(10)) + ''') AND (EQ.EST_COMPONENT_NBR = ''' + Cast(@EstCompNum AS Varchar(5)) + ''') AND 
                      (EQ.EST_QUOTE_NBR = ''' + Cast(@QuoteNum AS Varchar(5)) + ''') AND (ESTIMATE_REV.EST_REV_NBR = ''' + Cast(@RevNum AS Varchar(5)) + ''')'


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
--                      if @GroupOption = 'P'
--					    Begin
--					        SELECT @sqlgroupby = @sqlgroupby + ' E.EST_PHASE_ID, E.EST_PHASE_DESC,'
--					    End	
--					  if @GroupOption = 'H'
--					    Begin
--					        SELECT @sqlgroupby = @sqlgroupby + ' FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,'
--					    End	  
SELECT @sqlgroupby = @sqlgroupby + ' JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, JOB_COMPONENT.EMP_CODE,EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME,
					  EL.CL_CODE, CLIENT.CL_NAME, EL.DIV_CODE, DIVISION.DIV_NAME, EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,		  
					  ESTIMATE_REV.JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY,CDP_CONTACT_HDR.CONT_TELEPHONE,CDP_CONTACT_HDR.CONT_FAX,CDP_CONTACT_HDR.EMAIL_ADDRESS,CDP_CONTACT_HDR.CONT_TITLE, JOB_COMPONENT.JOB_FIRST_USE_DATE, JOB_COMPONENT.JOB_CL_PO_NBR, JOB_COMPONENT.JOB_COMP_BUDGET_AM'
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
                      
SELECT @sumCPU = sum(E.LINE_TOTAL)
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
        UPDATE #estPrint
        SET CPU = (@sumCPU / @JobQty)
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
        UPDATE #estPrint
        SET CPM = CPU * 1000
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

UPDATE #estPrint SET FunctionOption = (SELECT FUNCTION_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))

UPDATE #estPrint SET GroupOption = (SELECT GROUP_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))

UPDATE #estPrint SET SortOption = (SELECT SORT_OPTION FROM ESTIMATE_PRINT_DEF WHERE UPPER([USER_ID]) = UPPER(@UserID))

UPDATE #estPrint SET TaxSeparate = @TaxSeparate, CommissionSeparate = @CommMUSeparate, ContingencySeparate = @ContSeparate, IncludeContingency = @Contingency

SET @Font = '<span style="font-family: Arial; font-size: 9pt;">'
SET @Font3 = '<span style="font-family: Arial; font-size: 8.25pt;">'
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
 SELECT @ENum = EstimateNumber, @ECNum = EstimateComponentNumber, @QNum = QuoteNumber, @RNum = RevisionNumber, @func = FunctionCode, @FRate = EstimateRate 
 FROM #estPrint
 WHERE RowID = @RowCount
 
 if (@ProdConsFunc = 1 AND @ConsoleOverride = 0) OR @FunctionOption = 'C'
	Begin
		if @FRate <> 0
		Begin
			DECLARE comment_col_cursor CURSOR FOR 	    
			SELECT ISNULL(E.EST_FNC_COMMENT,''),ISNULL(E.EST_REV_SUP_BY_NTE,''),ISNULL(E.EST_FNC_COMMENT_HTML,''),ISNULL(E.EST_REV_SUP_BY_HTML,'') 
			FROM ESTIMATE_REV_DET E  INNER JOIN
							  FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE
			WHERE (E.ESTIMATE_NUMBER = @ENum) AND (E.EST_COMPONENT_NBR = @ECNum) AND (E.EST_QUOTE_NBR = @QNum) AND (E.EST_REV_NBR = @RNum) 
				AND (E.FNC_CODE = @func OR FUNCTIONS.FNC_CONSOLIDATION = @func) AND (E.EST_REV_RATE = @FRate)
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
		End
		Else
		Begin
			DECLARE comment_col_cursor CURSOR FOR 	    
			SELECT ISNULL(E.EST_FNC_COMMENT,''),ISNULL(E.EST_REV_SUP_BY_NTE,''),ISNULL(E.EST_FNC_COMMENT_HTML,''),ISNULL(E.EST_REV_SUP_BY_HTML,'') 
			FROM ESTIMATE_REV_DET E  INNER JOIN
							  FUNCTIONS ON E.FNC_CODE = FUNCTIONS.FNC_CODE
			WHERE (E.ESTIMATE_NUMBER = @ENum) AND (E.EST_COMPONENT_NBR = @ECNum) AND (E.EST_QUOTE_NBR = @QNum) AND (E.EST_REV_NBR = @RNum) 
				AND (E.FNC_CODE = @func OR FUNCTIONS.FNC_CONSOLIDATION = @func)
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
		End		
	End
	Else
	Begin
		if @FRate <> 0
		Begin
			DECLARE comment_col_cursor CURSOR FOR 	    
			SELECT ISNULL(E.EST_FNC_COMMENT,''),ISNULL(E.EST_REV_SUP_BY_NTE,''),ISNULL(E.EST_FNC_COMMENT_HTML,''),ISNULL(E.EST_REV_SUP_BY_HTML,'') 
			FROM ESTIMATE_REV_DET E 
			WHERE (E.ESTIMATE_NUMBER = @ENum) AND (E.EST_COMPONENT_NBR = @ECNum)
								 AND (E.EST_QUOTE_NBR = @QNum) AND (E.EST_REV_NBR = @RNum) AND (E.FNC_CODE = @func) AND (E.EST_REV_RATE = @FRate)
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
		End
		Else
		Begin
			DECLARE comment_col_cursor CURSOR FOR 	    
			SELECT ISNULL(E.EST_FNC_COMMENT,''),ISNULL(E.EST_REV_SUP_BY_NTE,''),ISNULL(E.EST_FNC_COMMENT_HTML,''),ISNULL(E.EST_REV_SUP_BY_HTML,'') 
			FROM ESTIMATE_REV_DET E 
			WHERE (E.ESTIMATE_NUMBER = @ENum) AND (E.EST_COMPONENT_NBR = @ECNum)
								 AND (E.EST_QUOTE_NBR = @QNum) AND (E.EST_REV_NBR = @RNum) AND (E.FNC_CODE = @func)
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
		End
		
	End      
	

	if @DetailCommentsHtml = ''
	Begin
		SELECT @DetailCommentsHtml = @DetailComments
	End

	if @SuppliedCommentsHtml = ''
	Begin
		SELECT @SuppliedCommentsHtml = @SuppliedComments
	End


	UPDATE #estPrint SET DetailComments = @DetailComments, SuppliedByNotes = @SuppliedComments, DetailCommentsHtml = @Font + @DetailCommentsHtml + @Font2, SuppliedByNotesHtml = @Font + @SuppliedCommentsHtml + @Font2 
	WHERE (#estPrint.EstimateNumber = @ENum) AND (#estPrint.EstimateComponentNumber = @ECNum) AND (#estPrint.QuoteNumber = @QNum) AND (#estPrint.RevisionNumber = @RNum) AND #estPrint.FunctionCode = @func AND #estPrint.EstimateRate = @FRate

	
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

SELECT @ClientCode = CL_CODE FROM ESTIMATE_LOG WHERE ESTIMATE_NUMBER = @EstNo

UPDATE #estPrint SET DefaultComment = (SELECT CASE WHEN ISNULL(DefaultComment,'') = 'Standard Comment' THEN 
														CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates')
														   ELSE CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE APP_CODE = 'Estimates' AND [CLIENT_CODE] IS NULL) IS NOT NULL THEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE APP_CODE = 'Estimates' AND [CLIENT_CODE] IS NULL)
														   ELSE (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY) END END
											       WHEN ISNULL(DefaultComment,'') = 'Agency Defined' THEN (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY)
												   WHEN ISNULL(DefaultComment,'') = ''  THEN (SELECT ISNULL(EST_COMMENT,'') AS EST_COMMENT FROM AGENCY) 
											  ELSE ISNULL(DefaultComment,'') END 
									   FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)

UPDATE #estPrint SET DefaultCommentHtml = (SELECT CASE WHEN ISNULL(DefaultCommentHtml,'') = @Font3 + 'Standard Comment' + @Font2 THEN 
														CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates') IS NOT NULL THEN (SELECT @Font3 + CAST(STD_COMMENT AS VARCHAR(MAX)) + @Font2 FROM STD_COMMENT WHERE [CLIENT_CODE] = @ClientCode AND APP_CODE = 'Estimates')
														   ELSE CASE WHEN (SELECT STD_COMMENT FROM STD_COMMENT WHERE APP_CODE = 'Estimates' AND [CLIENT_CODE] IS NULL) IS NOT NULL THEN (SELECT @Font3 + CAST(STD_COMMENT AS VARCHAR(MAX)) + @Font2 FROM STD_COMMENT WHERE APP_CODE = 'Estimates' AND [CLIENT_CODE] IS NULL)
														   ELSE (SELECT @Font3 + CAST(ISNULL(EST_COMMENT,'') AS VARCHAR(MAX)) + @Font2 AS EST_COMMENT FROM AGENCY) END END
											       WHEN ISNULL(DefaultCommentHtml,'') = 'Agency Defined' THEN (SELECT @Font3 + CAST(ISNULL(EST_COMMENT,'') AS VARCHAR(MAX)) + @Font2 AS EST_COMMENT FROM AGENCY)
												   WHEN ISNULL(DefaultCommentHtml,'') = '' THEN (SELECT @Font3 + CAST(ISNULL(EST_COMMENT,'') AS VARCHAR(MAX)) + @Font2 AS EST_COMMENT FROM AGENCY)
											  ELSE @Font3 + ISNULL(DefaultCommentHtml,'') + @Font2 END 
									   FROM #est WHERE EstimateNumber = EstNo AND EstimateComponentNumber = EstCompNo AND QuoteNumber = QuoteNo AND RevisionNumber = RevNo)


--JVS
DECLARE @JN int, @JC smallint, @JVLabel varchar(25), @JobVerValue SQL_VARIANT

SELECT DISTINCT @JN = JobNumber, @JC = JobComponentNumber
FROM #estPrint

DECLARE jv_col_cursor CURSOR FOR 
		 SELECT      JOB_VER_TMPLT_DTL.JV_TMPLT_LABEL, JOB_VER_DTL.JOB_VER_VALUE
		FROM         JOB_VER_HDR INNER JOIN
							  JOB_VER_DTL ON JOB_VER_HDR.JOB_VER_HDR_ID = JOB_VER_DTL.JOB_VER_HDR_ID INNER JOIN
							  JOB_VER_TMPLT_HDR ON JOB_VER_HDR.JV_TMPLT_CODE = JOB_VER_TMPLT_HDR.JV_TMPLT_CODE INNER JOIN
							  JOB_VER_TMPLT_DTL ON JOB_VER_DTL.JV_TMPLT_DTL_ID = JOB_VER_TMPLT_DTL.JV_TMPLT_DTL_ID
		WHERE     (JOB_VER_HDR.JOB_NUMBER = @JN) AND (JOB_VER_HDR.JOB_COMPONENT_NBR = @JC)
	
	OPEN jv_col_cursor

	FETCH NEXT FROM jv_col_cursor INTO @JVLabel, @JobVerValue

	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN
		IF @JVLabel = 'PIF'
		BEGIN
			UPDATE #estPrint
			SET PIF = CAST(@JobVerValue AS VARCHAR(MAX))
		END
		IF @JVLabel = 'Fiscal Period'
		BEGIN
			UPDATE #estPrint
			SET FiscalPeriod = CAST(@JobVerValue AS VARCHAR(MAX))
		END
		IF @JVLabel = 'TACTIC ID'
		BEGIN
			UPDATE #estPrint
			SET TacticID = CAST(@JobVerValue AS VARCHAR(MAX))
		END
		
		FETCH NEXT FROM jv_col_cursor INTO @JVLabel, @JobVerValue
	END

	CLOSE jv_col_cursor
	DEALLOCATE jv_col_cursor

UPDATE #estPrint
SET QuoteComment = CASE WHEN QuoteComment = '' THEN RevisionComment ELSE QuoteComment + '<br />' + RevisionComment END

UPDATE #estPrint
SET QuoteCommentHtml = CASE WHEN QuoteCommentHtml = '' THEN RevisionCommentHtml ELSE QuoteCommentHtml + '<br />' + RevisionCommentHtml END

SELECT @sql = 'SELECT ClientCode,ClientName,DivisionCode,DivisionName,ProductCode,ProductDescription,
	P.USER_DEFINED1 AS ProductUDF1, P.USER_DEFINED2 AS ProductUDF2, P.USER_DEFINED3 AS ProductUDF3, P.USER_DEFINED4 AS ProductUDF4, P.PRD_ATTENTION AS ProductAttention, EstimateNumber, EstimateDescription, EstimateComment,
	EstimateCommentHtml,EstimateComponentNumber,EstimateComponentDescription,EstimateComponentComment,EstimateComponentCommentHtml,	EstimateContactID,EstimateContactCode,EstimateContactName,EstimateContactAddress1,EstimateContactAddress2,EstimateContactCity,EstimateContactState,
	EstimateContactZip,EstimateContactCountry,EstimateContactPhone,EstimateContactFax,EstimateContactEmail,EstimateContactTitle,QuoteNumber,QuoteDescription,QuoteComment,QuoteCommentHtml,RevisionNumber,RevisionComment,RevisionCommentHtml,DefaultComment,DefaultCommentHtml, JobNumber,JobDescription,JobClientReference,	
    SalesClassCode,SalesClassDescription, JobComponentNumber,JobComponentDescription,AccountExecutiveCode,AccountExecutiveName,
	JobClientPO, JobDueDate, JobBudget,PIF, FiscalPeriod,
	FunctionType,FunctionCode,FunctionDescription,FunctionOrder,DetailComments,DetailCommentsHtml,SuppliedByCode,
	CASE EstimateFunctionType
		WHEN ''E'' THEN E.EMP_FNAME + '' '' + E.EMP_LNAME
			ELSE V.VN_NAME
		END AS SuppliedByName,
	SuppliedByNotes,SuppliedByNotesHtml,EstimateQuantity,EstimateRate,EstimateExtAmount, 
    EstimateTaxAmount,	EstimateMarkupAmount,EstimateTotalAmount,EstimateTotalContingencyAmount,EstimateContingencyAmount,EstimateMarkupContingency,
	EstimateFunctionType,EmployeeTitleID,JobQuantity,CPU,CPM,EstimateComponentQuote,EstimateComponent,InOut,FunctionOption,GroupOption,SortOption,TaxSeparate,CommissionSeparate,ContingencySeparate,IncludeContingency,TacticID'
SELECT @sqlfrom = ' FROM #estPrint EP INNER JOIN PRODUCT P ON EP.ClientCode = P.CL_CODE AND EP.DivisionCode = P.DIV_CODE AND EP.ProductCode = P.PRD_CODE
				  LEFT OUTER JOIN VENDOR V ON EP.SuppliedByCode = V.VN_CODE LEFT OUTER JOIN EMPLOYEE E ON EP.SuppliedByCode = E.EMP_CODE'
SELECT @sqlwhere = ' WHERE 1=1'
if @SuppressZero = 1
Begin
	SELECT @sqlwhere = @sqlwhere + ' AND EstimateExtAmount <> 0'
End

SELECT @sqlwhere = @sqlwhere + ' ORDER BY EstimateNumber, EstimateComponentNumber, QuoteNumber, RevisionNumber'

if @GroupOption = 'T'
Begin
	SELECT @sqlwhere = @sqlwhere + ' , FunctionType'
End
if @GroupOption = 'H'
Begin
	SELECT @sqlwhere = @sqlwhere + ' , FunctionHeadingSequence, FunctionHeadingDescription'
End
if @GroupOption = 'P'
Begin
	SELECT @sqlwhere = @sqlwhere + ' , EstimatePhaseDescription'
End
if @GroupOption = 'I'
Begin
	SELECT @sqlwhere = @sqlwhere + ' , InOut'
End


if @SortOption = 'C'
Begin
	SELECT @sqlwhere = @sqlwhere + ' , FunctionCode'
End
if @SortOption = 'O'
Begin
	SELECT @sqlwhere = @sqlwhere + ' , FunctionOrder'
End


print @sql+@sqlfrom+@sqlwhere
EXEC (@sql+@sqlfrom+@sqlwhere)



--print @sql
--EXEC (@sql)

DROP TABLE #est
DROP TABLE #estPrint


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



















