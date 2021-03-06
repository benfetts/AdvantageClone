
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_GrossIncome]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_GrossIncome]
GO




CREATE PROCEDURE [dbo].[usp_wv_dto_GrossIncome]  
(
	@StartPeriod varchar(6),
	@EndPeriod varchar(6),
	@OfficeCode varchar(6),
	@SalesClassCode varchar(6),
	@Level smallint,
	@USER_ID VARCHAR(100),
	@Group varchar(6),
	@DesktopObject smallint,
	@IncludeManualInvoices bit = 1, 
	@IncludeGLEntries bit = 1

)
AS
DECLARE @TotalDirect as decimal(12,2), @Restrictions Int,@StartDate smalldatetime, @EndDate smalldatetime, @AlertSharePercent decimal(12,3),
		@sql nvarchar(4000), @clcode varchar(6), @feetimeamount decimal(15,2), @client varchar(6), @TotalGross decimal(15,2),
		@paramlist nvarchar(4000), @NumberRecords int, @RowCount int, @StdFeeJobComp int, @sqlWhere nvarchar(4000),
		@StdFeeIncludeStandard int, @StdFeeIncludeProd int, @StdFeeIncludeMedia int, @EMP_CODE AS VARCHAR(6), @COUNT AS INTEGER, @EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT
	
   	SELECT @StartDate = PPSRTDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @StartPeriod

	SELECT @EndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @EndPeriod

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@USER_ID)
	SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EMP_CODE, 11);
	SELECT @COUNT = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	DECLARE
		@RESTRICT_ACCOUNT_EXECUTIVE BIT,
		@HAS_ACTIVE_RESTRICTION BIT,
		@NEEDS_OR BIT;
				
	SELECT 	
		@RESTRICT_ACCOUNT_EXECUTIVE = A.ACCOUNT_EXECUTIVE,   
		@HAS_ACTIVE_RESTRICTION = A.HAS_ACTIVE_RESTRICTION
	FROM 
		[dbo].[fn_my_objects_get_static_restrictions](11) AS A;

	SELECT @AlertSharePercent = ISNULL(CAST(AGY_SETTINGS_VALUE AS DECIMAL(12,3)),0)
	FROM AGY_SETTINGS
	WHERE AGY_SETTINGS_CODE = 'CLI_INC_ALERT_PCT'

	CREATE TABLE #GROSS_INCOME_CPL 
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[OfficeCode] varchar(4),
			[OfficeDescription] varchar(30),
			[ClientCode] varchar(6),
			[ClientDescription] varchar(40),
			[DivisionCode] varchar(6),
			[DivisionDescription] varchar(40),
			[ProductCode] varchar(6),
	        [ProductDescription] varchar(40),
			[Type] varchar(3),
			[SalesClassCode] varchar(6),
			[SalesClassDescription] varchar(30),
			[CampaignID] int,
			[CampaignCode] varchar(6), 
			[CampaignName] varchar(128),
			[PostingPeriod] varchar(6),
			[Year] int,
			[DefaultAECode] varchar(6),
			[DefaultAEName] varchar(100),
			[ProductUDF1] varchar(50),
			[ProductUDF2] varchar(50),
			[ProductUDF3] varchar(50),
			[ProductUDF4] varchar(50),
			[InvoiceNumber] int,
			[InvoiceSequence] smallint,
			[MediaType] varchar(1),
			[JobNumber] int,
			[JobDescription] varchar(60),
			[ComponentNumber] smallint,
			[ComponentDescription] varchar(60),
			[OrderNumber] int,
			[LineNumber] smallint,
			[BilledFee] decimal(18, 2),
			[BilledTime] decimal(18, 2),
			[BilledCommission] decimal(18, 2),
			[BilledCostOfSales] decimal(18, 2),
			[BilledIncomeRec] decimal(18,2),
			[ManualSale] decimal(18,2), 
			[ManualCOS] decimal(18,2),
			[GLSales] decimal(18,2),
			[GLCostOfSales] decimal(18,2),
			[GLDirectExpense] decimal(18,2),
			[BilledTotal] decimal(18,2),
			[TotalGrossIncome] decimal(18,2),
			[GrossIncomePercent] decimal(18,2),
			[ManualInvoice] smallint
        );

	CREATE TABLE #GROSS_INCOME_CPL_TOTAL --MASTER TABLE TO RETURN
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[OfficeCode] varchar(4),
			[OfficeDescription] varchar(30),
			[ClientCode] varchar(6),
			[ClientDescription] varchar(40),
			[DivisionCode] varchar(6),
			[DivisionDescription] varchar(40),
			[ProductCode] varchar(6),
	        [ProductDescription] varchar(40),
			[Type] varchar(3),
			[SalesClassCode] varchar(6),
			[SalesClassDescription] varchar(30),
			[CampaignID] int,
			[CampaignCode] varchar(6), 
			[CampaignName] varchar(128),
			[PostingPeriod] varchar(6),
			[Year] int,
			[DefaultAECode] varchar(6),
			[DefaultAEName] varchar(100),
			[ProductUDF1] varchar(50),
			[ProductUDF2] varchar(50),
			[ProductUDF3] varchar(50),
			[ProductUDF4] varchar(50),
			[InvoiceNumber] int,
			[InvoiceSequence] smallint,
			[MediaType] varchar(1),
			[JobNumber] int,
			[JobDescription] varchar(60),
			[ComponentNumber] smallint,
			[ComponentDescription] varchar(60),
			[OrderNumber] int,
			[LineNumber] smallint,
			[BilledFee] decimal(18, 2),
			[BilledTime] decimal(18, 2),
			[BilledCommission] decimal(18, 2),
			[BilledCostOfSales] decimal(18, 2),
			[BilledIncomeRec] decimal(18,2),
			[ManualSale] decimal(18,2), 
			[ManualCOS] decimal(18,2),
			[GLSales] decimal(18,2),
			[GLCostOfSales] decimal(18,2),
			[GLDirectExpense] decimal(18,2),
			[BilledTotal] decimal(18,2),
			[TotalGrossIncome] decimal(18,2),
			[GrossIncomePercent] decimal(18,2)
        );        

		--BIlled Information
		set @sql =  'INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(AR.OFFICE_CODE,''''), ISNULL(O.OFFICE_NAME,''''), ISNULL(AR.CL_CODE,''''), ISNULL(C.CL_NAME,''''), ISNULL(AR.DIV_CODE,''''), ISNULL(D.DIV_NAME,''''), ISNULL(AR.PRD_CODE,''''), ISNULL(P.PRD_DESCRIPTION,''''), 
			CASE WHEN ISNULL(AR.MEDIA_TYPE,''P'') <> ''P'' THEN ''M'' ELSE ''P'' END, AR.SC_CODE, SC_DESCRIPTION, ISNULL(JL.CMP_IDENTIFIER,''''), ISNULL(CAMP.CMP_CODE,''''), ISNULL(CAMP.CMP_NAME,''''), AR.SALE_POST_PERIOD, SUBSTRING(AR.SALE_POST_PERIOD,1,4) AS [YEAR],
			AE.EMP_CODE, COALESCE((RTRIM(EMP.EMP_FNAME)+'' ''),'''')+COALESCE((EMP.EMP_MI+''. ''),'''')+COALESCE(EMP.EMP_LNAME,''''),P.USER_DEFINED1,P.USER_DEFINED2,P.USER_DEFINED3,P.USER_DEFINED4,
			AR.AR_INV_NBR, AR.AR_INV_SEQ, CASE WHEN ISNULL(AR.MEDIA_TYPE,''P'') <> ''P'' THEN ''M'' ELSE ''P'' END, ISNULL(AR.JOB_NUMBER,0), ISNULL(JL.JOB_DESC,''''), ISNULL(AR.JOB_COMPONENT_NBR,0), ISNULL(JC.JOB_COMP_DESC,''''), ISNULL(AR.ORDER_NBR,0), ISNULL(AR.ORDER_LINE_NBR,0),
			CASE WHEN AR.FNC_TYPE = ''I'' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.INC_ONLY_AMT,0)+ISNULL(AR.AB_SALE_AMT,0)+ISNULL(AR.ADDITIONAL_AMT,0) END ELSE 
					CASE WHEN ISNULL(AR.MEDIA_TYPE,''P'') <> ''P'' THEN ISNULL(AR.ADDITIONAL_AMT,0) ELSE 0 END END AS BILLED_FEE_IO,
			CASE WHEN AR.FNC_TYPE = ''E'' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_INC_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.EMP_TIME_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END ELSE 
					CASE WHEN ISNULL(AR.MEDIA_TYPE,''P'') <> ''P'' THEN 0 ELSE 0 END END AS BILLED_TIME,
			CASE WHEN AR.FNC_TYPE = ''V'' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.AB_COMMISSION_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) ELSE ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0)+ISNULL(AR.AB_SALE_AMT,0) END ELSE
					CASE WHEN ISNULL(AR.MEDIA_TYPE,''P'') <> ''P'' THEN ISNULL(AR.COMMISSION_AMT,0)+ISNULL(AR.REBATE_AMT,0) ELSE 0 END END AS BILLED_COMMISSION,
			CASE WHEN AR.FNC_TYPE = ''V'' THEN
				CASE WHEN AR.AB_REC_FLAG = 2 THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.AB_COST_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) END ELSE
					CASE WHEN ISNULL(AR.MEDIA_TYPE,''P'') <> ''P'' THEN ISNULL(AR.COST_AMT,0)+ISNULL(AR.NET_CHARGE_AMT,0)+ISNULL(AR.DISCOUNT_AMT,0)+ISNULL(AR.NON_RESALE_AMT,0) ELSE 0 END END AS BILLED_COST,
			0,0,0,0,0,0,0,0,0,0
		FROM AR_SUMMARY AR INNER JOIN
			 PRODUCT P ON P.PRD_CODE = AR.PRD_CODE AND P.DIV_CODE = AR.DIV_CODE AND P.CL_CODE = AR.CL_CODE INNER JOIN
			 DIVISION D ON D.DIV_CODE = P.DIV_CODE AND D.CL_CODE = P.CL_CODE INNER JOIN
			 CLIENT C ON C.CL_CODE = D.CL_CODE INNER JOIN
			 OFFICE O ON O.OFFICE_CODE = AR.OFFICE_CODE INNER JOIN
			 SALES_CLASS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			 JOB_COMPONENT JC ON AR.JOB_NUMBER = JC.JOB_NUMBER AND AR.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN 
			 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN 
			 CAMPAIGN AS CAMP ON CAMP.CMP_IDENTIFIER = JL.CMP_IDENTIFIER'
		IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @DesktopObject = 2
		Begin
			set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](11, ''' + @EMP_CODE + ''') AS DR
				ON AR.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
				AND ((AR.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
				AND ((AR.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'	
		End
		set @sqlWhere = ' WHERE AR.SALE_POST_PERIOD BETWEEN ''' + @StartPeriod + ''' AND ''' + @EndPeriod + ''' AND (AR.AR_INV_SEQ = 99 OR AR.AR_INV_SEQ = 0) AND AR.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS)'
		if @OfficeCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND AR.OFFICE_CODE = ''' + @OfficeCode + ''''
		End
		Else
		Begin
			IF @COUNT > 0 
			  Begin
				set @sql = @sql + ' INNER JOIN EMP_OFFICE ON O.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
			  End				
		End
		if @SalesClassCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND AR.SC_CODE = ''' + @SalesClassCode + ''''
		End
		set @sql = @sql + @sqlWhere	
		Print (@sql)
		EXEC ( @sql )

		--Billed Income Rec
		set @sql = ''
		set @sql =  'INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(AR_SUMMARY.OFFICE_CODE,''''), ISNULL(OFFICE.OFFICE_NAME,''''), ISNULL(AR_SUMMARY.CL_CODE,''''), ISNULL(CLIENT.CL_NAME,''''), ISNULL(AR_SUMMARY.DIV_CODE,''''), ISNULL(DIVISION.DIV_NAME,''''), ISNULL(AR_SUMMARY.PRD_CODE,''''), ISNULL(PRODUCT.PRD_DESCRIPTION,''''), ISNULL([MEDIA_TYPE],''P''), 
			   AR_SUMMARY.SC_CODE, SALES_CLASS.SC_DESCRIPTION, AR_SUMMARY.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME, AR_SUMMARY.SALE_POST_PERIOD, POSTPERIOD.PPGLYEAR, AE.EMP_CODE, 
			   EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME], 
			   ISNULL(PRODUCT.USER_DEFINED1,''''),ISNULL(PRODUCT.USER_DEFINED2,''''), ISNULL(PRODUCT.USER_DEFINED3,''''), ISNULL(PRODUCT.USER_DEFINED4,''''),
			   AR_SUMMARY.AR_INV_NBR, AR_SUMMARY.AR_INV_SEQ, AR_SUMMARY.MEDIA_TYPE, ISNULL(AR_SUMMARY.JOB_NUMBER,0), ISNULL(JL.JOB_DESC,''''), ISNULL(AR_SUMMARY.JOB_COMPONENT_NBR,0), ISNULL(JC.JOB_COMP_DESC,''''), ISNULL(AR_SUMMARY.ORDER_NBR,0), ISNULL(AR_SUMMARY.ORDER_LINE_NBR,0),
			   0,0,0,0,Sum(ISNULL([AB_SALE_AMT],0)) AS BilledIncomeRec,0,0,0,0,0,0,0,0,0
		FROM AR_SUMMARY INNER JOIN 
			 OFFICE ON AR_SUMMARY.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT JOIN 
			 AGENCY_CLIENTS ON AR_SUMMARY.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 POSTPERIOD ON AR_SUMMARY.SALE_POST_PERIOD = POSTPERIOD.PPPERIOD LEFT JOIN 
			 SALES_CLASS ON AR_SUMMARY.SC_CODE = SALES_CLASS.SC_CODE LEFT JOIN 
			 CAMPAIGN ON AR_SUMMARY.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER INNER JOIN 
			 CLIENT ON AR_SUMMARY.CL_CODE = CLIENT.CL_CODE INNER JOIN 
			 DIVISION ON (AR_SUMMARY.DIV_CODE = DIVISION.DIV_CODE) AND (AR_SUMMARY.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (AR_SUMMARY.PRD_CODE = PRODUCT.PRD_CODE) AND (AR_SUMMARY.DIV_CODE = PRODUCT.DIV_CODE) AND (AR_SUMMARY.CL_CODE = PRODUCT.CL_CODE) LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
			 JOB_COMPONENT JC ON AR_SUMMARY.JOB_NUMBER = JC.JOB_NUMBER AND AR_SUMMARY.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER'
		IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @DesktopObject = 2
		Begin
			set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](11, ''' + @EMP_CODE + ''') AS DR
				ON AR_SUMMARY.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
				AND ((AR_SUMMARY.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
				AND ((AR_SUMMARY.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'	
		End
		set @sqlWhere = ' WHERE (((AR_SUMMARY.FNC_TYPE)=''R'') AND ((AR_SUMMARY.SALE_POST_PERIOD) BETWEEN ''' + @StartPeriod + ''' AND ''' + @EndPeriod + ''') AND ((AGENCY_CLIENTS.CL_CODE) Is Null))'
		if @OfficeCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND AR_SUMMARY.OFFICE_CODE = ''' + @OfficeCode + ''''
		End
		Else
		Begin
			IF @COUNT > 0 
			  Begin
				set @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
			  End				
		End
		if @SalesClassCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND AR_SUMMARY.SC_CODE = ''' + @SalesClassCode + ''''
		End
		set @sqlWhere = @sqlWhere + ' GROUP BY AR_SUMMARY.OFFICE_CODE, OFFICE.OFFICE_NAME, AR_SUMMARY.CL_CODE, CLIENT.CL_NAME, AR_SUMMARY.DIV_CODE, DIVISION.DIV_NAME, AR_SUMMARY.PRD_CODE, PRODUCT.PRD_DESCRIPTION, 
			 ISNULL([MEDIA_TYPE],''P''), AR_SUMMARY.SC_CODE, SALES_CLASS.SC_DESCRIPTION, AR_SUMMARY.CMP_IDENTIFIER, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME, AR_SUMMARY.SALE_POST_PERIOD, 
			 POSTPERIOD.PPGLYEAR, AE.EMP_CODE, EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME], 
			 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4, AR_SUMMARY.AR_INV_NBR, AR_SUMMARY.AR_INV_SEQ, AR_SUMMARY.MEDIA_TYPE, ISNULL(AR_SUMMARY.JOB_NUMBER,0), ISNULL(JL.JOB_DESC,''''),
			 ISNULL(AR_SUMMARY.JOB_COMPONENT_NBR,0), ISNULL(JC.JOB_COMP_DESC,''''), ISNULL(AR_SUMMARY.ORDER_NBR,0), ISNULL(AR_SUMMARY.ORDER_LINE_NBR,0)'
		set @sql = @sql + @sqlWhere	
		Print (@sql)
		EXEC ( @sql )	 
		
		--Manual Invoices
	if @IncludeManualInvoices = 1
	Begin
		set @sql = ''
		set @sql =  'INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(ACCT_REC.OFFICE_CODE,''''), ISNULL(OFFICE.OFFICE_NAME,''''), ISNULL(ACCT_REC.CL_CODE,''''), ISNULL(CLIENT.CL_NAME,''''), ISNULL(ACCT_REC.DIV_CODE,''''), ISNULL(DIVISION.DIV_NAME,''''), ISNULL(ACCT_REC.PRD_CODE,''''), ISNULL(PRODUCT.PRD_DESCRIPTION,''''), CASE WHEN [REC_TYPE] = ''M'' THEN ''M'' ELSE ''P'' END, ACCT_REC.SC_CODE, 
			   SALES_CLASS.SC_DESCRIPTION, Null AS CampaignID,Null AS CampaignCode, Null AS CampaignName,ACCT_REC.AR_POST_PERIOD, POSTPERIOD.PPGLYEAR, AE.EMP_CODE, 
			   EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME] AS [Default AE Name],ISNULL(PRODUCT.USER_DEFINED1,''''),ISNULL(PRODUCT.USER_DEFINED2,''''), ISNULL(PRODUCT.USER_DEFINED3,''''), ISNULL(PRODUCT.USER_DEFINED4,''''),
			   ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_SEQ, CASE WHEN [REC_TYPE] = ''M'' THEN ''M'' ELSE ''P'' END, ISNULL(ACCT_REC.JOB_NUMBER,0), ISNULL(JL.JOB_DESC,''''), ISNULL(ACCT_REC.JOB_COMPONENT_NBR,0), ISNULL(JC.JOB_COMP_DESC,''''), NULL, NULL,
			   0,0,0,0,0,
			   CASE WHEN SUM([AR_INV_AMOUNT]) = 0 THEN CASE WHEN SUM([AR_SALE_AMT]) IS NULL THEN 0 ELSE SUM([AR_SALE_AMT]) END ELSE SUM([AR_INV_AMOUNT]-(ISNULL([AR_STATE_AMT],0)+ISNULL([AR_COUNTY_AMT],0)+ISNULL([AR_CITY_AMT],0))) END AS ManualSale,
			   Sum(ISNULL([AR_COS_AMT],0)) AS ManualCOS,0,0,0,0,0,0,1
		FROM ACCT_REC INNER JOIN 
			 OFFICE ON ACCT_REC.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT JOIN 
			 SALES_CLASS ON ACCT_REC.SC_CODE = SALES_CLASS.SC_CODE INNER JOIN 
			 POSTPERIOD ON ACCT_REC.AR_POST_PERIOD = POSTPERIOD.PPPERIOD INNER JOIN 
			 CLIENT ON ACCT_REC.CL_CODE = CLIENT.CL_CODE INNER JOIN 
			 DIVISION ON (ACCT_REC.DIV_CODE = DIVISION.DIV_CODE) AND (ACCT_REC.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (ACCT_REC.PRD_CODE = PRODUCT.PRD_CODE) AND (ACCT_REC.DIV_CODE = PRODUCT.DIV_CODE) AND (ACCT_REC.CL_CODE = PRODUCT.CL_CODE) LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE LEFT OUTER JOIN
			 JOB_COMPONENT JC ON ACCT_REC.JOB_NUMBER = JC.JOB_NUMBER AND ACCT_REC.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			 JOB_LOG JL ON JL.JOB_NUMBER = JC.JOB_NUMBER'
		IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @DesktopObject = 2
		Begin
			set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](11, ''' + @EMP_CODE + ''') AS DR
				ON ACCT_REC.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
				AND ((ACCT_REC.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
				AND ((ACCT_REC.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'	
		End
		set @sqlWhere = ' WHERE (ACCT_REC.MANUAL_INV = 1) AND ((ACCT_REC.AR_POST_PERIOD) BETWEEN ''' + @StartPeriod + ''' AND ''' + @EndPeriod + ''') AND (ACCT_REC.CL_CODE NOT IN (SELECT DISTINCT CL_CODE FROM AGENCY_CLIENTS))'
		if @OfficeCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND ACCT_REC.OFFICE_CODE = ''' + @OfficeCode + ''''
		End
		Else
		Begin
			IF @COUNT > 0 
			  Begin
				set @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
			  End				
		End
		if @SalesClassCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND ACCT_REC.SC_CODE = ''' + @SalesClassCode + ''''
		End
		set @sqlWhere = @sqlWhere + ' GROUP BY ACCT_REC.OFFICE_CODE, OFFICE.OFFICE_NAME, ACCT_REC.CL_CODE, CLIENT.CL_NAME, ACCT_REC.DIV_CODE, DIVISION.DIV_NAME, ACCT_REC.PRD_CODE, PRODUCT.PRD_DESCRIPTION,
			 CASE WHEN [REC_TYPE] = ''M'' THEN ''M'' ELSE ''P'' END,ACCT_REC.SC_CODE, SALES_CLASS.SC_DESCRIPTION,ACCT_REC.AR_POST_PERIOD,POSTPERIOD.PPGLYEAR, AE.EMP_CODE,
			 EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME],
			 PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4, ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_SEQ, CASE WHEN [REC_TYPE] = ''M'' THEN ''M'' ELSE ''P'' END, ISNULL(ACCT_REC.JOB_NUMBER,0), ISNULL(JL.JOB_DESC,''''),
			 ISNULL(ACCT_REC.JOB_COMPONENT_NBR,0), ISNULL(JC.JOB_COMP_DESC,'''')'
		set @sql = @sql + @sqlWhere	
		Print (@sql)
		EXEC ( @sql )	 
		
	End
	
	--GL Entries
	if @IncludeGLEntries = 1
	Begin
		--GL Entry Sales
		set @sql = ''
		set @sql =  'INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(PRODUCT.OFFICE_CODE,''''), ISNULL(OFFICE.OFFICE_NAME,''''), ISNULL(GLENTTRL.CL_CODE,''''), ISNULL(CLIENT.CL_NAME,''''), ISNULL(GLENTTRL.DIV_CODE,''''), ISNULL(DIVISION.DIV_NAME,''''), ISNULL(GLENTTRL.PRD_CODE,''''), ISNULL(PRODUCT.PRD_DESCRIPTION,''''), ''G'' AS Type, 
			   GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, Null AS CampaignID, Null AS CampaignCode, Null AS CampaignName, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
			   EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME] AS [Default AE Name], 
			   ISNULL(PRODUCT.USER_DEFINED1,''''),ISNULL(PRODUCT.USER_DEFINED2,''''), ISNULL(PRODUCT.USER_DEFINED3,''''), ISNULL(PRODUCT.USER_DEFINED4,''''), NULL,NULL, ''G'', NULL, NULL, NULL, NULL, NULL, NULL,
			   0,0,0,0,0,0,0,Sum([GLETAMT]*-1) AS [GL Entry Sales],0,0,0,0,0,0
		FROM GLENTTRL INNER JOIN 
			 GLENTHDR ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT INNER JOIN 
			 GLACCOUNT ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE INNER JOIN 
			 POSTPERIOD ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD INNER JOIN 
			 GLSOURCE ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE LEFT JOIN 
			 AGENCY_CLIENTS ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 CLIENT ON GLENTTRL.CL_CODE = CLIENT.CL_CODE INNER JOIN  
			 DIVISION ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE) AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE) AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE) AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
			 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE	LEFT OUTER JOIN 
				 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
						AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1 LEFT OUTER JOIN
				 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE'
		IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @DesktopObject = 2
		Begin
			set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](11, ''' + @EMP_CODE + ''') AS DR
				ON GLENTTRL.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
				AND ((GLENTTRL.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
				AND ((GLENTTRL.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'	
		End
		set @sqlWhere = ' WHERE (((GLENTTRL.GLETSOURCE) IN (''JE'',''RJ'',''IJ'',''BD'',''BV'')) AND ((GLACCOUNT.GLATYPE) In (''8'',''9'')) AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null) AND ((AGENCY_CLIENTS.CL_CODE) Is Null) AND ((GLENTHDR.GLEHPP) BETWEEN ''' + @StartPeriod + ''' AND ''' + @EndPeriod + '''))'
		if @OfficeCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND PRODUCT.OFFICE_CODE = ''' + @OfficeCode + ''''
		End
		Else
		Begin
			IF @COUNT > 0 
			  Begin
				set @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
			  End				
		End
		set @sqlWhere = @sqlWhere + ' GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, 
			 PRODUCT.PRD_DESCRIPTION, GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE,
			 EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME],
			  PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4'
		set @sql = @sql + @sqlWhere	
		Print (@sql)
		EXEC ( @sql )	

		--GL Entry Cost of Sales 
		set @sql = ''
		set @sql =  'INSERT INTO #GROSS_INCOME_CPL
		SELECT ISNULL(PRODUCT.OFFICE_CODE,''''), ISNULL(OFFICE.OFFICE_NAME,''''), ISNULL(GLENTTRL.CL_CODE,''''), ISNULL(CLIENT.CL_NAME,''''), ISNULL(GLENTTRL.DIV_CODE,''''), ISNULL(DIVISION.DIV_NAME,''''), ISNULL(GLENTTRL.PRD_CODE,''''), ISNULL(PRODUCT.PRD_DESCRIPTION,''''), ''G'' AS Type,
			   GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, Null AS CampaignID, Null AS CampaignCode, Null AS CampaignName, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
			   EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME] AS [Default AE Name], 
			   ISNULL(PRODUCT.USER_DEFINED1,''''),ISNULL(PRODUCT.USER_DEFINED2,''''), ISNULL(PRODUCT.USER_DEFINED3,''''), ISNULL(PRODUCT.USER_DEFINED4,''''), NULL,NULL, ''G'', NULL, NULL, NULL, NULL, NULL, NULL,
			   0,0,0,0,0,0,0,0,SUM(GLENTTRL.GLETAMT) AS [GL Entry Cost],0,0,0,0,0
		FROM GLENTTRL INNER JOIN 
			 GLENTHDR ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT INNER JOIN 
			 GLACCOUNT ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE INNER JOIN 
			 POSTPERIOD ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD INNER JOIN 
			 GLSOURCE ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE LEFT JOIN 
			 AGENCY_CLIENTS ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
			 CLIENT ON GLENTTRL.CL_CODE = CLIENT.CL_CODE INNER JOIN 
			 DIVISION ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE) AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
			 PRODUCT ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE) AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE) AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
			 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
			 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
					AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
			 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE'
		IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @DesktopObject = 2
		Begin
			set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](11, ''' + @EMP_CODE + ''') AS DR
				ON GLENTTRL.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
				AND ((GLENTTRL.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
				AND ((GLENTTRL.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'	
		End
		set @sqlWhere = ' WHERE (((GLENTTRL.GLETSOURCE) In (''JE'',''BD'',''RJ'',''BV'',''IJ'',''CR'',''OR'')) AND ((GLACCOUNT.GLATYPE)=''13'') AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null) AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) AND ((GLENTHDR.GLEHPP) BETWEEN ''' + @StartPeriod + ''' AND ''' + @EndPeriod + ''')'
		if @OfficeCode <> ''
		Begin
			set @sqlWhere = @sqlWhere + ' AND PRODUCT.OFFICE_CODE = ''' + @OfficeCode + ''''
		End
		Else
		Begin
			IF @COUNT > 0 
			  Begin
				set @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
						AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
			  End				
		End
		set @sqlWhere = @sqlWhere + ' GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, 
			 PRODUCT.PRD_DESCRIPTION, GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE,
			 EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME],
			  PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4'
		set @sql = @sql + @sqlWhere	
		Print (@sql)
		EXEC ( @sql )	
		
		--GL Entry Direct Expense 
		--set @sql = ''
		--set @sql =  'INSERT INTO #GROSS_INCOME_CPL
		--SELECT PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, PRODUCT.PRD_DESCRIPTION, ''G'' AS Type,
		--	   GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, Null AS CampaignID, Null AS CampaignCode, Null AS CampaignName, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE, 
		--	   EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME] AS [Default AE Name], 
		--	   ISNULL(PRODUCT.USER_DEFINED1,''''),ISNULL(PRODUCT.USER_DEFINED2,''''), ISNULL(PRODUCT.USER_DEFINED3,''''), ISNULL(PRODUCT.USER_DEFINED4,''''), NULL, ''G'', NULL, NULL, NULL, NULL, NULL, NULL,
		--	   0,0,0,0,0,0,0,0,0,SUM(GLENTTRL.GLETAMT) AS [GL Entry Direct Expense],0,0,0
		--FROM GLENTTRL INNER JOIN 
		--	 GLENTHDR ON GLENTTRL.GLETXACT = GLENTHDR.GLEHXACT INNER JOIN 
		--	 GLACCOUNT ON GLENTTRL.GLETCODE = GLACCOUNT.GLACODE INNER JOIN 
		--	 POSTPERIOD ON GLENTHDR.GLEHPP = POSTPERIOD.PPPERIOD INNER JOIN 
		--	 GLSOURCE ON GLENTTRL.GLETSOURCE = GLSOURCE.GLSRCODE LEFT JOIN 
		--	 AGENCY_CLIENTS ON GLENTTRL.CL_CODE = AGENCY_CLIENTS.CL_CODE INNER JOIN 
		--	 CLIENT ON GLENTTRL.CL_CODE = CLIENT.CL_CODE INNER JOIN 
		--	 DIVISION ON (GLENTTRL.DIV_CODE = DIVISION.DIV_CODE) AND (GLENTTRL.CL_CODE = DIVISION.CL_CODE) INNER JOIN 
		--	 PRODUCT ON (GLENTTRL.PRD_CODE = PRODUCT.PRD_CODE) AND (GLENTTRL.DIV_CODE = PRODUCT.DIV_CODE) AND (GLENTTRL.CL_CODE = PRODUCT.CL_CODE) INNER JOIN 
		--	 OFFICE ON PRODUCT.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN 
		--	 ACCOUNT_EXECUTIVE AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE
		--			AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) AND AE.DEFAULT_AE = 1  LEFT OUTER JOIN
		--	 EMPLOYEE AS EMP ON EMP.EMP_CODE = AE.EMP_CODE'
		--IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 AND @DesktopObject = 2
		--Begin
		--	set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](11, ''' + @EMP_CODE + ''') AS DR
		--		ON GLENTTRL.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
		--		AND ((GLENTTRL.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
		--		AND ((GLENTTRL.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'	
		--End
		--set @sqlWhere = ' WHERE (((GLENTTRL.GLETSOURCE) In (''JE'',''RJ'')) AND ((GLACCOUNT.GLATYPE)=''14'') AND ((GLENTHDR.GLEHPOSTSUM) Is Not Null) AND ((AGENCY_CLIENTS.CL_CODE) Is Null)) AND ((GLENTHDR.GLEHPP) BETWEEN ''' + @StartPeriod + ''' AND ''' + @EndPeriod + ''')'
		--if @OfficeCode <> ''
		--Begin
		--	set @sqlWhere = @sqlWhere + ' AND PRODUCT.OFFICE_CODE = ''' + @OfficeCode + ''''
		--End
		--Else
		--Begin
		--	IF @COUNT > 0 
		--	  Begin
		--		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
		--				AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
		--	  End				
		--End
		--set @sqlWhere = @sqlWhere + ' GROUP BY PRODUCT.OFFICE_CODE, OFFICE.OFFICE_NAME, GLENTTRL.CL_CODE, CLIENT.CL_NAME, GLENTTRL.DIV_CODE, DIVISION.DIV_NAME, GLENTTRL.PRD_CODE, 
		--	 PRODUCT.PRD_DESCRIPTION, GLENTTRL.GLETSOURCE, GLSOURCE.GLSRDESC, GLENTHDR.GLEHPP, [POSTPERIOD].[PPGLYEAR], AE.EMP_CODE,
		--	 EMP.[EMP_FNAME] + '' '' + CASE WHEN EMP.[EMP_MI] IS NOT NULL THEN EMP.[EMP_MI] + ''. '' ELSE NULL END + EMP.[EMP_LNAME],
		--	  PRODUCT.USER_DEFINED1, PRODUCT.USER_DEFINED2, PRODUCT.USER_DEFINED3, PRODUCT.USER_DEFINED4'
		--set @sql = @sql + @sqlWhere	
		--Print (@sql)
		--EXEC ( @sql )	
	End

	--SELECT * FROM #GROSS_INCOME_CPL
	SELECT @TotalGross = (SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales]))
	FROM #GROSS_INCOME_CPL
	--SELECT @TotalGross
	if @Level = 0	
	Begin
		If @Group = 'c'
		Begin
			SELECT [ClientCode],[ClientDescription],
			(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) AS TotalGrossIncome,
			ClientSharePercent = CASE
			WHEN NOT @TotalGross IS NULL AND @TotalGross > 0 THEN (((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) / @TotalGross) * 100)
			ELSE 0
			END
			FROM #GROSS_INCOME_CPL
			GROUP BY [ClientCode],[ClientDescription]
			ORDER BY [ClientDescription]
		End
		If @Group = 'cdp'
		Begin
			SELECT [ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],
			(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) AS TotalGrossIncome,
			ClientSharePercent = CASE
			WHEN NOT @TotalGross IS NULL AND @TotalGross > 0 THEN (((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) / @TotalGross) * 100)
			ELSE 0
			END
			FROM #GROSS_INCOME_CPL
			GROUP BY [ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription]
			ORDER BY [ClientDescription],[DivisionDescription],[ProductDescription]
		End
		
	End
	If @Level = 1
	Begin
		If @Group = 'c'
		Begin
			SELECT [ClientCode],[ClientDescription],(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) AS TotalGrossIncome,
			CASE WHEN ISNULL([Type],'P') = 'P' THEN 'Production' 
			     WHEN ISNULL([Type],'P') = 'G' THEN 'General Ledger' Else 'Media' End AS [Type]
			FROM #GROSS_INCOME_CPL
			GROUP BY [ClientCode],[ClientDescription],[Type]	
			ORDER BY [ClientDescription],[Type]
		End
		If @Group = 'cdp'
		Begin
			SELECT [ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],
			(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) AS TotalGrossIncome,
			CASE WHEN ISNULL([Type],'P') = 'P' THEN 'Production'
			     WHEN ISNULL([Type],'P') = 'G' THEN 'General Ledger' Else 'Media' End AS [Type]
			FROM #GROSS_INCOME_CPL
			GROUP BY [ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[Type]	
			ORDER BY [ClientDescription],[DivisionDescription],[ProductDescription],[Type]
		End
	End
	if @Level = 2
	Begin
		If @Group = 'c'
		Begin
			SELECT [ClientCode],[ClientDescription],[OfficeCode],[OfficeDescription],[PostingPeriod],[InvoiceNumber],[InvoiceSequence],CASE WHEN ISNULL([Type],'P') = 'P' THEN 'Production'
			     WHEN ISNULL([Type],'P') = 'G' THEN 'General Ledger' Else 'Media' End AS [Type],[MediaType],
				CASE WHEN [MediaType] = 'M' AND [ManualInvoice] = 1 THEN 'Media'
					 WHEN [MediaType] = 'M' AND [ManualInvoice] = 0 THEN 'Magazine'
					 WHEN [MediaType] = 'N' THEN 'Newspaper'
					 WHEN [MediaType] = 'R' THEN 'Radio'
					 WHEN [MediaType] = 'T' THEN 'Television'
					 WHEN [MediaType] = 'O' THEN 'Out of Home'
					 WHEN [MediaType] = 'I' THEN 'Internet'
					 WHEN [MediaType] = 'P' THEN 'Production'
					 WHEN [MediaType] = 'G' THEN 'General Ledger' ELSE 'Production' END AS [Media],[SalesClassCode],[SalesClassDescription],
					 [JobNumber],[JobDescription],[ComponentNumber],[ComponentDescription],[OrderNumber],[LineNumber],
					 (SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales])) AS BilledAmount,
					 SUM([BilledCostOfSales]) + SUM([ManualCOS]) + SUM([GLCostofSales]) AS BilledCostOfSale, (SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) AS TotalGrossIncome, 
					 CASE WHEN (SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales])) > 0 
							THEN ((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales]))/(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales]))) * 100
							 ELSE 0 END AS GrossIncomePercent,
					(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #GROSS_INCOME_CPL.[InvoiceNumber] AND AR_INV_SEQ = #GROSS_INCOME_CPL.[InvoiceSequence]) AS AttachmentCount 
			FROM #GROSS_INCOME_CPL
			GROUP BY [ClientCode],[ClientDescription],[MediaType],[OfficeCode],[OfficeDescription],[PostingPeriod],[InvoiceNumber],[InvoiceSequence],[Type],[MediaType],[SalesClassCode],[SalesClassDescription],
					 [JobNumber],[JobDescription],[ComponentNumber],[ComponentDescription],[OrderNumber],[LineNumber],[ManualInvoice]
			ORDER BY [ClientDescription]
		End
		If @Group = 'cdp'
		Begin
			SELECT [ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],
			[OfficeCode],[OfficeDescription],[PostingPeriod],[InvoiceNumber],[InvoiceSequence],CASE WHEN ISNULL([Type],'P') = 'P' THEN 'Production' 
			     WHEN ISNULL([Type],'P') = 'G' THEN 'General Ledger'Else 'Media' End AS [Type],[MediaType],
				CASE WHEN [MediaType] = 'M' AND [ManualInvoice] = 1 THEN 'Media'
					 WHEN [MediaType] = 'M' AND [ManualInvoice] = 0 THEN 'Magazine'
					 WHEN [MediaType] = 'N' THEN 'Newspaper'
					 WHEN [MediaType] = 'R' THEN 'Radio'
					 WHEN [MediaType] = 'T' THEN 'Television'
					 WHEN [MediaType] = 'O' THEN 'Out of Home'
					 WHEN [MediaType] = 'I' THEN 'Internet'
					 WHEN [MediaType] = 'P' THEN 'Production'
					 WHEN [MediaType] = 'G' THEN 'General Ledger' ELSE 'Production' END AS [Media],[SalesClassCode],[SalesClassDescription],
					 [JobNumber],[JobDescription],[ComponentNumber],[ComponentDescription],[OrderNumber],[LineNumber],
					 (SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales])) AS BilledAmount,
					 SUM([BilledCostOfSales]) + SUM([ManualCOS]) + SUM([GLCostofSales]) AS BilledCostOfSale, (SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales])) AS TotalGrossIncome, 
					 CASE WHEN (SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales])) > 0 
							THEN ((SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledIncomeRec])+SUM([ManualSale])-SUM([ManualCOS])+SUM([GLSales])-SUM([GLCostofSales]))/(SUM([BilledFee])+SUM([BilledTime])+SUM([BilledCommission])+SUM([BilledCostOfSales])+SUM([BilledIncomeRec])+SUM([ManualSale])+SUM([GLSales]))) * 100
							 ELSE 0 END AS GrossIncomePercent,
					(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #GROSS_INCOME_CPL.[InvoiceNumber] AND AR_INV_SEQ = #GROSS_INCOME_CPL.[InvoiceSequence]) AS AttachmentCount 
			FROM #GROSS_INCOME_CPL
			GROUP BY [ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[MediaType],[OfficeCode],[OfficeDescription],[PostingPeriod],[InvoiceNumber],[InvoiceSequence],[Type],[MediaType],[SalesClassCode],[SalesClassDescription],
					 [JobNumber],[JobDescription],[ComponentNumber],[ComponentDescription],[OrderNumber],[LineNumber],[ManualInvoice]
			ORDER BY [ClientDescription],[DivisionDescription],[ProductDescription]
		End
	End
DROP TABLE #GROSS_INCOME_CPL
DROP TABLE #GROSS_INCOME_CPL_TOTAL