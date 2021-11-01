if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_estimate_printing_dataset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_estimate_printing_dataset]
GO



CREATE PROCEDURE [dbo].[advsp_estimate_printing_dataset] 
@StartDate AS smalldatetime,
@EndDate AS smalldatetime

AS
DECLARE @Restrictions Int, @NumberRecords int, @RowCount int,
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
	@ProdConsFunc smallint,
	@client varchar(6), 
	@division varchar(6),
	@product varchar(6),
	@func varchar(6),
	@funcdesc varchar(30),
	@funcorder smallint,
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
	@MaxRev smallint,
	@ClientCode as varchar(6)
	

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
	FunctionCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	FunctionDescription varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SequenceNumber 			int,
	DetailComments		text,
	DetailCommentsHtml		text,
	SuppliedByCode	varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SuppliedByNotes	text,
	SuppliedByNotesHtml	text,
	EstimateQuantity	decimal(15,2),
	EstimateRate		decimal(15,4),
	EstimateExtAmount		decimal(15,2),
	--EST_REV_COMM_PCT	decimal(9,3),
	EstimateMarkupAmount		decimal(14,2),
	EstimateTotalAmount  		decimal(14,2),
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
	FunctionHeadingOrder		int,
	JobClientReference			varchar(30) NULL,
	SalesClassCode 			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	SalesClassDescription		varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AccountExecutiveCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	AccountExecutiveName          		varchar(100) NULL,
	ClientCode    		    varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientName			    varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientBillingAddress			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ClientBillingAddress2			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ClientBillingCity				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ClientBillingCounty			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ClientBillingState			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ClientBillingZip				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ClientBillingCountry			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionCode    		varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionName			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionBillingAddress			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    DivisionBillingAddress2			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    DivisionBillingCity				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    DivisionBillingCounty			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    DivisionBillingState			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    DivisionBillingZip				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    DivisionBillingCountry			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductDescription		varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductBillingAddress			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ProductBillingAddress2			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ProductBillingCity				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ProductBillingCounty			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ProductBillingState			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ProductBillingZip				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
    ProductBillingCountry			varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
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
	AdNumber		varchar(30),
	FunctionOption varchar(2),
	GroupOption  varchar(2),
	SortOption varchar(2),
	TaxSeparate smallint,
	CommissionSeparate smallint,
	ContingencySeparate smallint, 
	IncludeContingency smallint)

--SELECT     @DateToPrint = ISNULL(DATE_TO_PRINT, 0), @TaxSeparate = ISNULL(TAX_SEPARATE, 0), @TaxIndicator = ISNULL(TAX_INDICATOR, 0), @CommMUSeparate = ISNULL(COMM_MU_SEPARATE, 0), @CommMUIndicator = ISNULL(COMM_MU_INDICATOR, 0), @FunctionOption = ISNULL(FUNCTION_OPTION, ''), 
--                      @GroupOption = ISNULL(GROUP_OPTION, ''), @SortOption = ISNULL(SORT_OPTION, ''), @InsideDesc = ISNULL(INSIDE_CHG_DESC, ''), @OutsideDesc = ISNULL(OUTSIDE_CHG_DESC, ''), @EstComment = ISNULL(EST_COMMENT, 0), @EstCompComment = ISNULL(EST_COMP_COMMENT, 0), @QteComment = ISNULL(QTE_COMMENT, 0), 
--                      @RevComment = ISNULL(REV_COMMENT, 0), @FuncComment = ISNULL(FUNC_COMMENT, 0), @DefComment = ISNULL(DEF_FOOTER_COMMENT, 0), @CliRef = ISNULL(CLI_REF, 0), @AE = ISNULL(AE_NAME, 0), @SalesClass = ISNULL(PRT_SALES_CLASS, 0), @Specs = ISNULL(SPECS, 0), @JobOty = ISNULL(JOB_QTY, 0), @Contingency = ISNULL(CONTINGENCY, 0), 
--                      @SuppressZero = ISNULL(SUPPRESS_ZERO, 0), @NonBill = ISNULL(PRT_NONBILL, 0), @DivName = ISNULL(PRT_DIV_NAME, 0), @PrdName = ISNULL(PRT_PRD_NAME, 0), @QtyHrs = ISNULL(QTY_HRS, 0), @ContSeparate = ISNULL(CONT_SEPARATE, 0),
--                      @ConsoleOverride = ISNULL(CONSOL_OVERRIDE, 0), @SubTotOnly = ISNULL(SUBTOT_ONLY, 0), @ExclEmpTime = ISNULL(EXCL_EMP_TIME, 0), @ExclVendor = ISNULL(EXCL_VENDOR, 0), @ExclIO = ISNULL(EXCL_IO, 0), @ExclNonBill = ISNULL(EXCL_NONBILL,0)
--FROM        ESTIMATE_PRINT_DEF
--WHERE     (UPPER(USER_ID) = UPPER(@UserID))

--SELECT @client = CL_CODE, @division = DIV_CODE, @product = PRD_CODE
--FROM ESTIMATE_LOG
--WHERE ESTIMATE_NUMBER = @EstNo

--SELECT @ProdConsFunc = PRD_CONSOL_FUNC
--FROM PRODUCT
--WHERE CL_CODE = @client AND DIV_CODE = @division AND PRD_CODE = @product

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
                              --INNER JOIN charlist_to_table(@Quotes, DEFAULT) c ON EQ.EST_QUOTE_NBR = c.vstr collate database_default
        WHERE  EL.EST_CREATE_DATE BETWEEN @StartDate AND @EndDate
        Group by EQ.ESTIMATE_NUMBER, EQ.EST_COMPONENT_NBR, 
		           EQ.EST_QUOTE_NBR

SET @NumberRecords = @@ROWCOUNT
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @EstNum = EstNo, @EstCompNum = EstCompNo, @QuoteNum = QuoteNo, @RevNum = RevNo
 FROM #est
 WHERE RowID = @RowCount


 
 SELECT @sql2 = 'INSERT INTO #estPrint SELECT EQ.ESTIMATE_NUMBER, EL.EST_LOG_DESC, EQ.EST_COMPONENT_NBR, EC.EST_COMP_DESC, EQ.EST_QUOTE_NBR, EQ.EST_QUOTE_DESC, JOB_LOG.JOB_NUMBER,
			JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ESTIMATE_REV.EST_REV_NBR,
			    E.FNC_CODE, FUNCTIONS.FNC_DESCRIPTION, E.SEQ_NBR, E.EST_FNC_COMMENT,E.EST_FNC_COMMENT_HTML, E.EST_REV_SUP_BY_CDE, E.EST_REV_SUP_BY_NTE,E.EST_REV_SUP_BY_HTML,
				 ISNULL(E.EST_REV_QUANTITY,0) AS EST_REV_QUANTITY,ISNULL(E.EST_REV_RATE,0.00), EST_REV_EXT_AMT, EXT_MARKUP_AMT, ISNULL(E.LINE_TOTAL,0) AS LINE_TOTAL,(ISNULL(EXT_CONTINGENCY,0)) AS EXT_CONTINGENCY, EXT_MU_CONT AS EXT_MU_CONT,
				 E.EST_FNC_TYPE, E.EMPLOYEE_TITLE_ID, FUNCTIONS.FNC_TYPE, E.EST_PHASE_ID, ISNULL(E.EST_PHASE_DESC, '''') as EST_PHASE_DESC,
				 FNC_HEADING.FNC_HEADING_ID, FNC_HEADING.FNC_HEADING_DESC, FNC_HEADING.FNC_HEADING_SEQ,
				 JOB_LOG.JOB_CLI_REF, EL.SC_CODE, SALES_CLASS.SC_DESCRIPTION, JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME + ISNULL('' '' + EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' '' + EMPLOYEE.EMP_LNAME, '''') AS AE,
					  EL.CL_CODE, CLIENT.CL_NAME,ISNULL(CL_BADDRESS1,''''), ISNULL(CL_BADDRESS2,''''), ISNULL(CL_BCITY,''''),ISNULL(CL_BCOUNTY,''''), ISNULL(CL_BSTATE,''''), ISNULL(CL_BZIP,''''),ISNULL(CL_BCOUNTRY,''''),
					  EL.DIV_CODE, DIVISION.DIV_NAME,ISNULL(DIVISION.DIV_BADDRESS1,''''), ISNULL(DIVISION.DIV_BADDRESS2,''''), ISNULL(DIVISION.DIV_BCITY,''''),ISNULL(DIVISION.DIV_BCOUNTY,''''), ISNULL(DIVISION.DIV_BSTATE,''''), ISNULL(DIVISION.DIV_BZIP,''''),ISNULL(DIV_BCOUNTRY,''''), 
					  EL.PRD_CODE, PRODUCT.PRD_DESCRIPTION,ISNULL(PRODUCT.PRD_BILL_ADDRESS1,''''), ISNULL(PRODUCT.PRD_BILL_ADDRESS2,''''), ISNULL(PRODUCT.PRD_BILL_CITY,''''),ISNULL(PRODUCT.PRD_BILL_COUNTY,''''), ISNULL(PRODUCT.PRD_BILL_STATE,''''), ISNULL(PRODUCT.PRD_BILL_ZIP,''''),ISNULL(PRODUCT.PRD_BILL_COUNTRY,''''),
				 EL.EST_LOG_COMMENT, EC.EST_COMP_COMMENT, EQ.EST_QTE_COMMENT, ESTIMATE_REV.EST_REV_COMMENT,EST_FTR_COMMENT,EST_LOG_COMMENT_HTML,EST_COMP_COMMENT_HTML,EST_QTE_COMMENT_HTML,EST_REV_COMMENT_HTML,EST_FTR_COMMENT_HTML,
				(ISNULL(E.EXT_STATE_RESALE,0) + ISNULL(E.EXT_COUNTY_RESALE,0) + ISNULL(E.EXT_CITY_RESALE,0) + ISNULL(E.EXT_NONRESALE_TAX,0) + ISNULL(E.EXT_STATE_CONT,0) + ISNULL(E.EXT_COUNTY_CONT,0) + ISNULL(E.EXT_CITY_CONT,0) + ISNULL(E.EXT_NR_CONT,0)),
				 ISNULL(ESTIMATE_REV.JOB_QTY,0) AS JOB_QTY, CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_CODE, CDP_CONTACT_HDR.CONT_FML, CDP_CONTACT_HDR.CONT_ADDRESS1, 
                      CDP_CONTACT_HDR.CONT_ADDRESS2, CDP_CONTACT_HDR.CONT_CITY, CDP_CONTACT_HDR.CONT_STATE, 
                      CDP_CONTACT_HDR.CONT_ZIP, CDP_CONTACT_HDR.CONT_COUNTRY,CDP_CONTACT_HDR.CONT_TELEPHONE,CDP_CONTACT_HDR.CONT_FAX,CDP_CONTACT_HDR.EMAIL_ADDRESS,CDP_CONTACT_HDR.CONT_TITLE, 0, 0, (Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))+''/''+Cast(EQ.EST_QUOTE_NBR AS VARCHAR(3))), (Cast(EQ.ESTIMATE_NUMBER AS VARCHAR(7))+''/''+Cast(EQ.EST_COMPONENT_NBR AS VARCHAR(3))),                    
				     CASE WHEN FUNCTIONS.FNC_TYPE = ''E'' THEN ''I''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''V'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''I'' THEN ''O''
                                                       WHEN FUNCTIONS.FNC_TYPE = ''C'' THEN ''C''
                                                       ELSE ''I'' END AS INOUT,
					 ISNULL(FUNCTIONS.FNC_ORDER,0) AS FNC_ORDER,JOB_COMPONENT.JOB_FIRST_USE_DATE, ISNULL(JOB_COMPONENT.AD_NBR,'''') AS AD_NBR,'''','''','''',0,0,0,0'                     
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
					  


print @sql2 + @sqlfrom + @sqlwhere
EXEC (@sql2 + @sqlfrom + @sqlwhere)
 

                 
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
--SELECT @JobQty,@sumCPU  
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

--UPDATE #estPrint
--SET LabelFromUDFTable1 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV1 ON JOB_LOG.UDV1_CODE = JOB_LOG_UDV1.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber)
--WHERE #estPrint.JobNumber IS not nULL

--UPDATE #estPrint
--SET LabelFromUDFTable2 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV2 ON JOB_LOG.UDV2_CODE = JOB_LOG_UDV2.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber)
--WHERE #estPrint.JobNumber IS not nULL

--UPDATE #estPrint
--SET LabelFromUDFTable3 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV3 ON JOB_LOG.UDV3_CODE = JOB_LOG_UDV3.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber)
--WHERE #estPrint.JobNumber IS not nULL

--UPDATE #estPrint
--SET LabelFromUDFTable4 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV4 ON JOB_LOG.UDV4_CODE = JOB_LOG_UDV4.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber)
--WHERE #estPrint.JobNumber IS not nULL

--UPDATE #estPrint
--SET LabelFromUDFTable5 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_LOG INNER JOIN JOB_LOG_UDV5 ON JOB_LOG.UDV5_CODE = JOB_LOG_UDV5.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber)
--WHERE #estPrint.JobNumber IS not nULL

--UPDATE #estPrint
--SET CompLabelFromUDFTable1 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_COMPONENT INNER JOIN JOB_CMP_UDV1 ON JOB_COMPONENT.UDV1_CODE = JOB_CMP_UDV1.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber AND JOB_COMPONENT_NBR = #estPrint.JobComponentNumber)
--WHERE #estPrint.JobNumber IS not nULL AND #estPrint.JobComponentNumber IS NOT NULL

--UPDATE #estPrint
--SET CompLabelFromUDFTable2 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_COMPONENT INNER JOIN JOB_CMP_UDV2 ON JOB_COMPONENT.UDV2_CODE = JOB_CMP_UDV2.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber AND JOB_COMPONENT_NBR = #estPrint.JobComponentNumber)
--WHERE #estPrint.JobNumber IS not nULL AND #estPrint.JobComponentNumber IS NOT NULL

--UPDATE #estPrint
--SET CompLabelFromUDFTable3 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_COMPONENT INNER JOIN JOB_CMP_UDV3 ON JOB_COMPONENT.UDV3_CODE = JOB_CMP_UDV3.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber AND JOB_COMPONENT_NBR = #estPrint.JobComponentNumber)
--WHERE #estPrint.JobNumber IS not nULL AND #estPrint.JobComponentNumber IS NOT NULL

--UPDATE #estPrint
--SET CompLabelFromUDFTable4 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_COMPONENT INNER JOIN JOB_CMP_UDV4 ON JOB_COMPONENT.UDV4_CODE = JOB_CMP_UDV4.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber AND JOB_COMPONENT_NBR = #estPrint.JobComponentNumber)
--WHERE #estPrint.JobNumber IS not nULL AND #estPrint.JobComponentNumber IS NOT NULL

--UPDATE #estPrint
--SET CompLabelFromUDFTable5 = (SELECT ISNULL(UDV_DESC,'') AS [DESC] FROM JOB_COMPONENT INNER JOIN JOB_CMP_UDV5 ON JOB_COMPONENT.UDV5_CODE = JOB_CMP_UDV5.UDV_CODE WHERE JOB_NUMBER = #estPrint.JobNumber AND JOB_COMPONENT_NBR = #estPrint.JobComponentNumber)
--WHERE #estPrint.JobNumber IS not nULL AND #estPrint.JobComponentNumber IS NOT NULL


SELECT @sql = 'SELECT ClientCode,ClientName,ClientBillingAddress,ClientBillingAddress2,ClientBillingCity,ClientBillingCounty,ClientBillingState,ClientBillingZip,ClientBillingCountry,
	DivisionCode,DivisionName,DivisionBillingAddress,DivisionBillingAddress2,DivisionBillingCity,DivisionBillingCounty,DivisionBillingState,DivisionBillingZip,DivisionBillingCountry,
	ProductCode,ProductDescription,ProductBillingAddress,ProductBillingAddress2,ProductBillingCity,ProductBillingCounty,ProductBillingState,ProductBillingZip,ProductBillingCountry,
	P.USER_DEFINED1 AS ProductUDF1, P.USER_DEFINED2 AS ProductUDF2, P.USER_DEFINED3 AS ProductUDF3, P.USER_DEFINED4 AS ProductUDF4, 
	EstimateNumber, EstimateDescription, EstimateComment,EstimateCommentHTML,EstimateComponentNumber,EstimateComponentDescription,EstimateComponentComment,EstimateComponentCommentHTML,
	EstimateContactID,EstimateContactCode,EstimateContactName,EstimateContactAddress1,EstimateContactAddress2,EstimateContactCity,EstimateContactState,
	EstimateContactZip,EstimateContactCountry,EstimateContactPhone,EstimateContactFax,EstimateContactEmail,EstimateContactTitle,QuoteNumber,QuoteDescription,QuoteComment,QuoteCommentHTML,RevisionNumber,RevisionComment,RevisionCommentHTML,DefaultComment,DefaultCommentHTML,EA.TYPE AS ApprovalType, 
		CASE EA.TYPE
			WHEN 1 THEN ''Internal''
			WHEN 2 THEN ''Client''
			WHEN 3 THEN ''Both''
		END AS ApprovalTypeDescription,	
		EA.CL_EST_APPR_BY AS ClientApprovalName, 
		EA.CL_EST_APPR_DATE AS ClientApprovalDate, 
		EA.IN_EST_APPR_BY AS InternalApprovalName, 
		EA.IN_EST_APPR_DATE AS InternalApprovalDate, JobNumber,JobDescription,JobClientReference,	
    JL.CMP_IDENTIFIER AS CampaignID, C.CMP_CODE AS CampaignCode, C.CMP_NAME AS CampaignName,SalesClassCode,SalesClassDescription,
    JL.CREATE_DATE AS JobCreateDate, JL.JOB_DATE_OPENED AS JobDateOpened,JobComponentNumber,JobComponentDescription,AccountExecutiveCode,AccountExecutiveName,
	JC.JOB_CL_PO_NBR AS JobClientPO, JC.JOB_COMP_DATE AS ComponentDateOpened,JobDueDate, JC.[START_DATE] AS JobStartDate,
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
		END AS JobProcessingControl, 
	FunctionType,FunctionHeadingID,FunctionHeadingDescription,FunctionHeadingOrder,FunctionCode,FunctionDescription,FunctionOrder,SequenceNumber,DetailComments,DetailCommentsHTML,
	SuppliedByCode,	CASE EstimateFunctionType
		WHEN ''E'' THEN E.EMP_FNAME + '' '' + E.EMP_LNAME
			ELSE V.VN_NAME
		END AS SuppliedByName,
	SuppliedByNotes,SuppliedByNotesHTML,
	EstimateQuantity,EstimateRate,EstimateExtAmount, EstimateExtAmount + EstimateTaxAmount AS EstimateNetAmount,
    EstimateExtAmount + EstimateTaxAmount AS EstimateCostAmount, EstimateTaxAmount,
	EstimateMarkupAmount,EstimateTotalAmount,EstimateContingencyAmount,EstimateMarkupContingency,
	EstimateFunctionType,CASE WHEN EP.EmployeeTitleID IS NULL AND EP.SuppliedByCode IS NOT NULL THEN E.EMPLOYEE_TITLE_ID ELSE EmployeeTitleID END AS EmployeeTitleID, CASE WHEN EP.EmployeeTitleID IS NULL AND EP.SuppliedByCode IS NOT NULL THEN E.EMP_TITLE ELSE EMPT.EMPLOYEE_TITLE END AS EmployeeTitle, EstimatePhaseID,EstimatePhaseDescription,JobQuantity,CPU,CPM,EstimateComponentQuote,EstimateComponent,InOut,AdNumber,
	JUDV1.UDV_DESC AS LabelFromUDFTable1,JUDV2.UDV_DESC AS LabelFromUDFTable2,JUDV3.UDV_DESC AS LabelFromUDFTable3,JUDV4.UDV_DESC AS LabelFromUDFTable4,JUDV5.UDV_DESC AS LabelFromUDFTable5,
	JCUDV1.UDV_DESC AS CompLabelFromUDFTable1,JCUDV2.UDV_DESC AS CompLabelFromUDFTable2,JCUDV3.UDV_DESC AS CompLabelFromUDFTable3,JCUDV4.UDV_DESC AS CompLabelFromUDFTable4,JCUDV5.UDV_DESC AS CompLabelFromUDFTable5'
SELECT @sqlfrom = ' FROM #estPrint EP INNER JOIN PRODUCT P ON EP.ClientCode = P.CL_CODE AND EP.DivisionCode = P.DIV_CODE AND EP.ProductCode = P.PRD_CODE
				  LEFT OUTER JOIN JOB_COMPONENT JC ON JC.JOB_NUMBER = EP.JobNumber AND JC.JOB_COMPONENT_NBR = EP.JobComponentNumber
				  LEFT OUTER JOIN JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER
				  LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JL.CMP_IDENTIFIER
				  LEFT OUTER JOIN VENDOR V ON EP.SuppliedByCode = V.VN_CODE
				  LEFT OUTER JOIN EMPLOYEE E ON EP.SuppliedByCode = E.EMP_CODE
				  LEFT OUTER JOIN V_ESTIMATEAPPR AS EA ON EA.ESTIMATE_NUMBER = EP.EstimateNumber AND EA.EST_COMPONENT_NBR = EP.EstimateComponentNumber
					AND EA.EST_QUOTE_NBR = EP.QuoteNumber AND EA.EST_REVISION_NBR = EP.RevisionNumber
				  LEFT OUTER JOIN [dbo].[JOB_LOG_UDV1] AS JUDV1 ON JUDV1.UDV_CODE = JL.UDV1_CODE LEFT OUTER JOIN
									[dbo].[JOB_LOG_UDV2] AS JUDV2 ON JUDV2.UDV_CODE = JL.UDV2_CODE LEFT OUTER JOIN
									[dbo].[JOB_LOG_UDV3] AS JUDV3 ON JUDV3.UDV_CODE = JL.UDV3_CODE LEFT OUTER JOIN
									[dbo].[JOB_LOG_UDV4] AS JUDV4 ON JUDV4.UDV_CODE = JL.UDV4_CODE LEFT OUTER JOIN
									[dbo].[JOB_LOG_UDV5] AS JUDV5 ON JUDV5.UDV_CODE = JL.UDV5_CODE LEFT OUTER JOIN
									[dbo].[JOB_CMP_UDV1] AS JCUDV1 ON JCUDV1.UDV_CODE = JC.UDV1_CODE LEFT OUTER JOIN
									[dbo].[JOB_CMP_UDV2] AS JCUDV2 ON JCUDV2.UDV_CODE = JC.UDV2_CODE LEFT OUTER JOIN
									[dbo].[JOB_CMP_UDV3] AS JCUDV3 ON JCUDV3.UDV_CODE = JC.UDV3_CODE LEFT OUTER JOIN
									[dbo].[JOB_CMP_UDV4] AS JCUDV4 ON JCUDV4.UDV_CODE = JC.UDV4_CODE LEFT OUTER JOIN
									[dbo].[JOB_CMP_UDV5] AS JCUDV5 ON JCUDV5.UDV_CODE = JC.UDV5_CODE LEFT OUTER JOIN
									EMPLOYEE_TITLE AS EMPT ON EMPT.EMPLOYEE_TITLE_ID = EP.EmployeeTitleID
	  WHERE 1=1'

SELECT @sqlfrom = @sqlfrom + ' ORDER BY EstimateNumber, EstimateComponentNumber, QuoteNumber, RevisionNumber'
SELECT @sqlfrom = @sqlfrom + ' , FunctionCode'



print @sql
EXEC (@sql + @sqlfrom)

DROP TABLE #est
DROP TABLE #estPrint























