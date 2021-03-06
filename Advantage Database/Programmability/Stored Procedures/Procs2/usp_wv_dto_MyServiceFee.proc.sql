
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_MyServiceFee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_MyServiceFee]
GO




CREATE PROCEDURE [dbo].[usp_wv_dto_MyServiceFee]  
(
	@StartPeriod varchar(6),
	@EndPeriod varchar(6),
	@UserID varchar(100),
	@IncludeClient bit = 1, 
	@IncludeDivision bit = 1, 
	@IncludeProduct bit = 1, 
	@IncludeCampaign bit = 1, 
	@IncludeSalesClass bit = 1, 
	@IncludeJobNumber bit = 1, 
	@IncludeFeeType bit = 1, 
	@IncludeFunctionCode bit = 1, 
	@IncludeFunctionHeading bit = 1 ,
	@IncludeFunctionConsolidation bit = 1,
	@IncludeEmployee bit = 1,
	@IncludeDate bit = 1,
	@DesktopObject smallint = 0,
	@ServiceFeeType varchar(6),
	@IncludePostPeriod bit = 1
)
AS
DECLARE @TotalDirect as decimal(12,2), @Restrictions Int,@StartDate smalldatetime, @EndDate smalldatetime, @MediaTypes varchar(30),
		@sql nvarchar(4000), @sql_where nvarchar(4000), @sql_where2 nvarchar(4000), @clcode varchar(6), @feetimeamount decimal(15,2), @client varchar(6),
		@paramlist nvarchar(4000), @NumberRecords int, @RowCount int, @StdFeeJobComp int, @sql_groupby nvarchar(4000),
		@StdFeeIncludeStandard int, @StdFeeIncludeProd int, @StdFeeIncludeMedia int, @StdIncludeStandard int, @StdIncludeProd int, @StdIncludeMedia int,
		@IncludeBroadcast int, @IncludeMagazine int, @IncludeNewspaper int, @IncludeInternet int, @IncludeOutofHome int, @EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT, @EMP_CODE VARCHAR(6),
		@StandardFeeSC int, @StandardFeeFunction int, @ProductionCommissionSC int, @ProductionCommissionFunction int, @ServiceFeeDefintion int,
		@ServiceFeeStandardFunctions int, @ServiceFeeStandardSalesClass int, @ServiceFeeProductionCommissionFunctions int, @ServiceFeeProductionCommissionSalesClass int,
		@FirstUserIDStandardFunctions varchar(100), @FirstUserIDStandardSalesClass varchar(100), @FirstUserIDProductionCommissionFunctions varchar(100), @FirstUserIDProductionCommissionSalesClass varchar(100)

		
SET @StdFeeJobComp = 0 
SET @StdFeeIncludeStandard = 0 
SET @StdFeeIncludeProd = 0 
SET @StdFeeIncludeMedia = 0 
SET @StdIncludeStandard = 0 
SET @StdIncludeProd = 0 
SET @StdIncludeMedia = 0
SET @IncludeBroadcast = 0 
SET @IncludeMagazine = 0 
SET @IncludeNewspaper = 0 
SET @IncludeInternet = 0 
SET @IncludeOutofHome = 0 
SET @StandardFeeSC = 0 
SET @StandardFeeFunction = 0 
SET @ProductionCommissionSC = 0 
SET @ProductionCommissionFunction = 0


SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = UPPER(@UserID);
SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EMP_CODE, 10); 

DECLARE @RestrictionsOffice AS INTEGER, @CDPRestrictions AS INTEGER
SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

SELECT @CDPRestrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER(SEC_CLIENT.USER_ID) LIKE UPPER(@UserID+'%')

DECLARE
	@RESTRICT_ACCOUNT_EXECUTIVE BIT,
	@HAS_ACTIVE_RESTRICTION BIT,
	@NEEDS_OR BIT;
				
SELECT 	
	@RESTRICT_ACCOUNT_EXECUTIVE = A.ACCOUNT_EXECUTIVE,   
	@HAS_ACTIVE_RESTRICTION = A.HAS_ACTIVE_RESTRICTION
FROM 
	[dbo].[fn_my_objects_get_static_restrictions](10) AS A;

SELECT @StartDate = PPSRTDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @StartPeriod

	SELECT @EndDate = PPENDDATE
	FROM POSTPERIOD
	WHERE PPPERIOD = @EndPeriod

SELECT @ServiceFeeDefintion = COUNT(*) FROM SERVICE_FEE_DEF WHERE UPPER(USER_ID) = UPPER(@UserID)
SELECT @ServiceFeeStandardFunctions = COUNT(*) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'STD_FEE_FUNC' AND UPPER(USER_ID) = UPPER(@UserID)
SELECT @ServiceFeeStandardSalesClass = COUNT(*) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'STD_FEE_SC' AND UPPER(USER_ID) = UPPER(@UserID)
SELECT @ServiceFeeProductionCommissionFunctions = COUNT(*) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'PROD_COMM_FUNC' AND UPPER(USER_ID) = UPPER(@UserID)
SELECT @ServiceFeeProductionCommissionSalesClass = COUNT(*) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'PROD_COMM_SC' AND UPPER(USER_ID) = UPPER(@UserID)

--SELECT @ServiceFeeStandardFunctions,@ServiceFeeStandardSalesClass,@ServiceFeeProductionCommissionFunctions,@ServiceFeeProductionCommissionSalesClass

if @ServiceFeeDefintion > 0
Begin
	SELECT @StdFeeJobComp = ISNULL(STD_FEE_JOB_COMP,0), @StdIncludeStandard = ISNULL(INCOME_ONLY_INCL,0), @StdIncludeProd = ISNULL([PRODUCT_COMM_INCL],0), @StdIncludeMedia = ISNULL([MEDIA_COMM_INCL],0),
		   @StdFeeIncludeStandard = ISNULL([FEETIME_TYPE_INCL_STD],0), @StdFeeIncludeProd = ISNULL([FEETIME_TYPE_INCL_PROD_COMM],0), @StdFeeIncludeMedia = ISNULL([FEETIME_TYPE_INCL_MEDIA_COMM],0),
		   @IncludeBroadcast = ISNULL([BROAD_COMM],0), @IncludeMagazine = ISNULL([MAG_COMM],0), @IncludeNewspaper = ISNULL([NEWS_COMM],0),
		   @IncludeInternet = ISNULL([INT_COMM],0), @IncludeOutofHome = ISNULL([OOH_COMM],0), @StandardFeeSC = ISNULL([STD_FEE_SC],0), @StandardFeeFunction = ISNULL([STD_FEE_FUNC],0),
		   @ProductionCommissionSC = ISNULL([PROD_COMM_SC],0), @ProductionCommissionFunction = ISNULL([PROD_COMM_FUNC],0)
	FROM SERVICE_FEE_DEF
	WHERE UPPER(USER_ID) = UPPER(@UserID)
End
Else
Begin
	SELECT TOP(1) @StdFeeJobComp = ISNULL(STD_FEE_JOB_COMP,0), @StdIncludeStandard = ISNULL(INCOME_ONLY_INCL,0), @StdIncludeProd = ISNULL([PRODUCT_COMM_INCL],0), @StdIncludeMedia = ISNULL([MEDIA_COMM_INCL],0),
		   @StdFeeIncludeStandard = ISNULL([FEETIME_TYPE_INCL_STD],0), @StdFeeIncludeProd = ISNULL([FEETIME_TYPE_INCL_PROD_COMM],0), @StdFeeIncludeMedia = ISNULL([FEETIME_TYPE_INCL_MEDIA_COMM],0),
		   @IncludeBroadcast = ISNULL([BROAD_COMM],0), @IncludeMagazine = ISNULL([MAG_COMM],0), @IncludeNewspaper = ISNULL([NEWS_COMM],0),
		   @IncludeInternet = ISNULL([INT_COMM],0), @IncludeOutofHome = ISNULL([OOH_COMM],0), @StandardFeeSC = ISNULL([STD_FEE_SC],0), @StandardFeeFunction = ISNULL([STD_FEE_FUNC],0),
		   @ProductionCommissionSC = ISNULL([PROD_COMM_SC],0), @ProductionCommissionFunction = ISNULL([PROD_COMM_FUNC],0)
	FROM SERVICE_FEE_DEF	
End

if @ServiceFeeStandardFunctions = 0
Begin
	SELECT TOP(1) @FirstUserIDStandardFunctions = UPPER(USER_ID) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'STD_FEE_FUNC'
End
if @ServiceFeeStandardSalesClass = 0
Begin
	SELECT TOP(1) @FirstUserIDStandardSalesClass = UPPER(USER_ID) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'STD_FEE_SC'
End
if @ServiceFeeProductionCommissionFunctions = 0
Begin
	SELECT TOP(1) @FirstUserIDProductionCommissionFunctions = UPPER(USER_ID) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'PROD_COMM_FUNC'
End
if @ServiceFeeProductionCommissionSalesClass = 0
Begin
	SELECT TOP(1) @FirstUserIDProductionCommissionSalesClass = UPPER(USER_ID) FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = 'PROD_COMM_SC'
End

--SELECT @FirstUserIDStandardFunctions,@FirstUserIDStandardSalesClass,@FirstUserIDProductionCommissionFunctions,@FirstUserIDProductionCommissionSalesClass

--SELECT @StdFeeJobComp, @StdIncludeStandard, @StdIncludeProd, @StdIncludeMedia,
--		   @StdFeeIncludeStandard, @StdFeeIncludeProd, @StdFeeIncludeMedia,
--		   @IncludeBroadcast, @IncludeMagazine, @IncludeNewspaper,
--		   @IncludeInternet, @IncludeOutofHome, @StandardFeeSC, @StandardFeeFunction,
--		   @ProductionCommissionSC, @ProductionCommissionFunction

SET @MediaTypes = ''
If @IncludeBroadcast = 1
Begin
	SELECT @MediaTypes = '''R'',''T'','
End
If @IncludeMagazine = 1
Begin
	If @MediaTypes = ''
	Begin
		SELECT @MediaTypes = '''M'','
	End
	Else
	Begin
		SELECT @MediaTypes = @MediaTypes + '''M'','
	End
End
If @IncludeNewspaper = 1
Begin
	If @MediaTypes = ''
	Begin
		SELECT @MediaTypes = '''N'','
	End
	Else
	Begin
		SELECT @MediaTypes = @MediaTypes + '''N'','
	End

End
If @IncludeInternet = 1
Begin
	If @MediaTypes = ''
	Begin
		SELECT @MediaTypes = '''I'','
	End
	Else
	Begin
		SELECT @MediaTypes = @MediaTypes + '''I'','
	End

End
If @IncludeOutofHome = 1
Begin
	If @MediaTypes = ''
	Begin
		SELECT @MediaTypes = '''O'','
	End
	Else
	Begin
		SELECT @MediaTypes = @MediaTypes + '''O'','
	End
End

if @MediaTypes <> ''
Begin
	SELECT @MediaTypes = LEFT(@MediaTypes,DATALENGTH(@MediaTypes)-1)
End

--SELECT @MediaTypes

		CREATE TABLE #SERVICE_FEE
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[ClientCode] varchar(6),
			[ClientDescription] varchar(40),
			[DivisionCode] varchar(6),
			[DivisionDescription] varchar(40),
			[ProductCode] varchar(6),
	        [ProductDescription] varchar(40),
			[CampaignID] int,
			[CampaignCode] varchar(6), 
			[CampaignName] varchar(128),
			[SalesClassCode] varchar(6),
			[SalesClassDescription] varchar(30),
			[JobNumber] int,
			[JobDescription] varchar(60),
			[ComponentNumber] smallint,	
			[JobComponent] varchar(20),
			[ComponentDescription] varchar(60),
			[FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[FunctionDescription] varchar(30),
			[FunctionType] varchar(1),
			[ServiceFeeTypeCode] varchar(6),
			[ServiceFeeTypeDescription] varchar(30),
			[FunctionHeading] varchar(60),
			[FunctionConsolidation] varchar(60),
			[EmployeeCode] varchar(6), 
			[EmployeeName] varchar(100),
			[FeeTimeType] varchar(50),
			[FeeDate] smalldatetime,
			[Description] varchar(100),
			[Comment] varchar(MAX),
			[PostPeriodCode] varchar(6),
			[FeeQuantity] decimal(18, 2),
			[FeeAmount] decimal(18, 2),
			[ReconciledHours] decimal(18, 2),
			[ReconciledAmount] decimal(18, 2),
			[UnreconciledHours] decimal(18, 2),
			[UnreconciledAmount] decimal(18, 2),
			[Hours] decimal(18, 2),
			[Amount] decimal(18, 2),
			[VarianceHours] decimal(15, 2),
			[VarianceAmount] decimal(15, 2),
        );

		CREATE TABLE #SERVICE_FEE_TOTAL
        (
	        [ID] [int] IDENTITY(1,1) NOT NULL,
			[ClientCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[ClientDescription] varchar(40),
			[DivisionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[DivisionDescription] varchar(40),
			[ProductCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	        [ProductDescription] varchar(40),
			[CampaignID] int,
			[CampaignCode] varchar(6), 
			[CampaignName] varchar(128),
			[SalesClassCode] varchar(6),
			[SalesClassDescription] varchar(30),
			[JobNumber] int,
			[JobDescription] varchar(60),
			[ComponentNumber] smallint,	
			[JobComponent] varchar(20),
			[ComponentDescription] varchar(60),
			[FunctionCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[FunctionDescription] varchar(30),
			[FunctionType] varchar(1),
			[ServiceFeeTypeCode] varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
			[ServiceFeeTypeDescription] varchar(30),
			[FunctionHeading] varchar(60),
			[FunctionConsolidation] varchar(60),
			[EmployeeCode] varchar(6), 
			[EmployeeName] varchar(100),
			[FeeTimeType] varchar(50),
			[FeeDate] smalldatetime,
			[Description] varchar(100),
			[Comment] varchar(MAX),
			[PostPeriodCode] varchar(6),
			[FeeQuantity] decimal(18, 2),
			[FeeAmount] decimal(18, 2),
			[ReconciledHours] decimal(18, 2),
			[ReconciledAmount] decimal(18, 2),
			[UnreconciledHours] decimal(18, 2),
			[UnreconciledAmount] decimal(18, 2),
			[Hours] decimal(18, 2),
			[Amount] decimal(18, 2),
			[VarianceHours] decimal(15, 2),
			[VarianceAmount] decimal(15, 2)
        );


--Standard	
SELECT @sql = 'INSERT INTO #SERVICE_FEE
	SELECT J.CL_CODE, C.CL_NAME,J.DIV_CODE, D.DIV_NAME,J.PRD_CODE, P.PRD_DESCRIPTION, ISNULL(J.CMP_IDENTIFIER,''''), ISNULL(CAMP.CMP_CODE,''''), ISNULL(CAMP.CMP_NAME,''''),
			 J.SC_CODE, SC.SC_DESCRIPTION, JC.JOB_NUMBER, J.JOB_DESC, JC.JOB_COMPONENT_NBR, RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + ''-'' + RIGHT(REPLICATE(''0'', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3),
			 JC.JOB_COMP_DESC, [IO].FNC_CODE, F.FNC_DESCRIPTION, F.FNC_TYPE, ISNULL(SFT.CODE,''''),ISNULL(SFT.DESCRIPTION,''''),FH.FNC_HEADING_DESC,ISNULL(CF.FNC_DESCRIPTION,''''), '''','''',
			 ''Standard Billed'', [IO].IO_INV_DATE,[IO].IO_DESC,ISNULL([IO].IO_COMMENT,''''),AR.AR_POST_PERIOD,
			 [IO].IO_QTY, [IO].IO_AMOUNT + [IO].EXT_MARKUP_AMT,0,0,0,0,0,0,0,0			
		FROM 
			[dbo].[INCOME_ONLY] AS [IO] LEFT OUTER JOIN 
			[dbo].[ACCT_REC] AS AR ON [IO].AR_INV_NBR = AR.AR_INV_NBR AND 
									  [IO].AR_INV_SEQ = AR.AR_INV_SEQ AND 
									  [IO].AR_TYPE = AR.AR_TYPE INNER JOIN
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = [IO].JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = [IO].JOB_COMPONENT_NBR INNER JOIN
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = [IO].JOB_NUMBER INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
									 D.DIV_CODE = J.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
									P.DIV_CODE = J.DIV_CODE AND
									P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = J.CMP_IDENTIFIER INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = [IO].FNC_CODE LEFT OUTER JOIN
			[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD
	WHERE 1=1'
			if @StandardFeeFunction = 1 AND @StandardFeeSC = 1
			Begin
				if @ServiceFeeStandardFunctions > 0
				Begin
					SELECT @sql = @sql + ' AND (([IO].FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + ''')) '
				End
				Else
				Begin
					if @FirstUserIDStandardFunctions IS NOT NULL
					Begin
						SELECT @sql = @sql + ' AND (([IO].FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDStandardFunctions + ''')) '
					End
					Else
					Begin
						SELECT @sql = @sql + ' AND (([IO].FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_FUNC'')) '
					End					
				End
				if @ServiceFeeStandardSalesClass > 0
				Begin
					SELECT @sql = @sql + ' OR ([IO].JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + '''))'
				End
				Else
				Begin
					if @FirstUserIDStandardSalesClass IS NOT NULL
					Begin
						SELECT @sql = @sql + ' OR ([IO].JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDStandardSalesClass + '''))'
					End
					Else
					Begin
						SELECT @sql = @sql + ' OR ([IO].JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_SC''))'
					End						
				End				
			End
			if @StandardFeeFunction = 1 AND @StandardFeeSC = 0
			Begin
				if @ServiceFeeStandardFunctions > 0
				Begin
					SELECT @sql = @sql + ' AND (([IO].FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + '''))'
				End
				Else
				Begin
					if @FirstUserIDStandardFunctions IS NOT NULL
					Begin
						SELECT @sql = @sql + ' AND (([IO].FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDStandardFunctions + ''')) '
					End
					Else
					Begin
						SELECT @sql = @sql + ' AND (([IO].FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_FUNC'')) '
					End						
				End				
			End
			if @StandardFeeFunction = 0 AND @StandardFeeSC = 1
			Begin
				if @ServiceFeeStandardSalesClass > 0
				Begin
					SELECT @sql = @sql + ' AND (([IO].JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + '''))'
				End
				Else
				Begin
					if @FirstUserIDStandardSalesClass IS NOT NULL
					Begin
						SELECT @sql = @sql + ' AND (([IO].JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDStandardSalesClass + '''))'
					End
					Else
					Begin
						SELECT @sql = @sql + ' AND (([IO].JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''STD_FEE_SC''))'
					End	
					
				End				
			End	
			if @StandardFeeFunction = 0 AND @StandardFeeSC = 0 AND @StdFeeJobComp = 1
			Begin
				SELECT @sql = @sql + ' AND (CAST([IO].JOB_NUMBER AS VARCHAR(10)) + ''|'' + CAST([IO].JOB_COMPONENT_NBR AS VARCHAR(4)) IN (SELECT CAST(JOB_COMPONENT.JOB_NUMBER AS VARCHAR(10)) + ''|'' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(4)) 
										FROM JOB_COMPONENT WHERE JOB_COMPONENT.SERVICE_FEE_FLAG = 1))'
			End	
			Else if @StandardFeeFunction = 0 AND @StandardFeeSC = 0 AND @StdFeeJobComp = 0
			Begin
				SELECT @sql = @sql + ''
			End
			Else
			Begin
				if @StdFeeJobComp = 1
					Begin
					   SELECT @sql = @sql + ' OR (CAST([IO].JOB_NUMBER AS VARCHAR(10)) + ''|'' + CAST([IO].JOB_COMPONENT_NBR AS VARCHAR(4)) IN (SELECT CAST(JOB_COMPONENT.JOB_NUMBER AS VARCHAR(10)) + ''|'' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(4)) 
										FROM JOB_COMPONENT WHERE JOB_COMPONENT.SERVICE_FEE_FLAG = 1)))'
					End
				Else
					Begin
						SELECT @sql = @sql + ') '
					End
			End
			SELECT @sql = @sql + ' AND AR.AR_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod '	

SELECT @paramlist = ' @StartPeriod varchar(6), @EndPeriod varchar(6), @UserID varchar(100)'
print @sql
EXEC sp_executesql @sql, @paramlist, @StartPeriod, @EndPeriod, @UserID
SET @sql = ''


--Production
SELECT @sql = 'INSERT INTO #SERVICE_FEE
	SELECT J.CL_CODE, C.CL_NAME, J.DIV_CODE, D.DIV_NAME, J.PRD_CODE, P.PRD_DESCRIPTION,ISNULL(J.CMP_IDENTIFIER,''''), ISNULL(CAMP.CMP_CODE,''''), ISNULL(CAMP.CMP_NAME,''''),
			 J.SC_CODE, SC.SC_DESCRIPTION, JC.JOB_NUMBER,J.JOB_DESC, JC.JOB_COMPONENT_NBR,RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR(20), JC.JOB_NUMBER), 6) + ''-'' + RIGHT(REPLICATE(''0'', 3) + CONVERT(VARCHAR(20), JC.JOB_COMPONENT_NBR), 3),
			 JC.JOB_COMP_DESC, AP.FNC_CODE, F.FNC_DESCRIPTION, F.FNC_TYPE, ISNULL(SFT.CODE,''''),ISNULL(SFT.DESCRIPTION,''''),FH.FNC_HEADING_DESC, ISNULL(CF.FNC_DESCRIPTION,''''), '''','''',
			 ''Production Billed'',APH.AP_INV_DATE,APH.AP_DESC,'''',AR.AR_POST_PERIOD,
			 ISNULL(AP.AP_PROD_QUANTITY, 0), AP.EXT_MARKUP_AMT,0,0,0,0,0,0,0,0
		FROM 
			[dbo].[JOB_COMPONENT] AS JC INNER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
			[dbo].[AP_PRODUCTION] AS AP ON AP.JOB_NUMBER = JC.JOB_NUMBER AND
										   AP.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR INNER JOIN 
			[dbo].[AP_HEADER] AS APH ON APH.AP_ID = AP.AP_ID AND 
										APH.AP_SEQ = AP.AP_SEQ LEFT OUTER JOIN 
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = AP.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = AP.AR_INV_SEQ AND 
									  AR.AR_TYPE = AP.AR_TYPE INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
									 D.DIV_CODE = J.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
									P.DIV_CODE = J.DIV_CODE AND
									P.PRD_CODE = J.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = J.SC_CODE INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = AP.FNC_CODE LEFT OUTER JOIN
			[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = J.CMP_IDENTIFIER LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION INNER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD
		WHERE AP.AP_PROD_NOBILL_FLG <> 1'
SELECT @sql = @sql + ' AND AR.AR_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod '	
			if @ProductionCommissionFunction = 1 AND @ProductionCommissionSC = 1
			Begin
				if @ServiceFeeProductionCommissionFunctions > 0
				Begin
					SELECT @sql = @sql + ' AND ((AP.FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + ''')) '
				End
				Else
				Begin
					if @FirstUserIDProductionCommissionFunctions IS NOT NULL
					Begin
						SELECT @sql = @sql + ' AND ((AP.FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDProductionCommissionFunctions + ''')) '
					End
					Else
					Begin
						SELECT @sql = @sql + ' AND ((AP.FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_FUNC'')) '
					End					
				End
				if @ServiceFeeProductionCommissionSalesClass > 0
				Begin
					SELECT @sql = @sql + ' OR (AP.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + ''')))'
				End
				Else
				Begin
					if @FirstUserIDProductionCommissionSalesClass IS NOT NULL
					Begin
						SELECT @sql = @sql + ' OR (AP.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDProductionCommissionSalesClass + ''')))'
					End
					Else
					Begin
						SELECT @sql = @sql + ' OR (AP.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_SC'')))'
					End						
				End				
			End
			if @ProductionCommissionFunction = 1 AND @ProductionCommissionSC = 0
			Begin
				if @ServiceFeeProductionCommissionFunctions > 0
				Begin
					SELECT @sql = @sql + ' AND ((AP.FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + ''')))'
				End
				Else
				Begin
					if @FirstUserIDProductionCommissionFunctions IS NOT NULL
					Begin
						SELECT @sql = @sql + ' AND ((AP.FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_FUNC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDProductionCommissionFunctions + '''))) '
					End
					Else
					Begin
						SELECT @sql = @sql + '  AND ((AP.FNC_CODE IN (SELECT DTL_CODE FROM SERVICE_FEE_DEF_DTL WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_FUNC''))) '
					End						
				End
				
			End
			if @ProductionCommissionFunction = 0 AND @ProductionCommissionSC = 1
			Begin
				if @ServiceFeeProductionCommissionSalesClass > 0
				Begin
					SELECT @sql = @sql + ' AND ((AP.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @UserID + ''')))'
				End
				Else
				Begin
					if @FirstUserIDProductionCommissionSalesClass IS NOT NULL
					Begin
						SELECT @sql = @sql + ' AND ((AP.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_SC'' AND SERVICE_FEE_DEF_DTL.USER_ID = ''' + @FirstUserIDProductionCommissionSalesClass + ''')))'
					End
					Else
					Begin
						SELECT @sql = @sql + ' AND ((AP.JOB_NUMBER IN (SELECT JOB_LOG.JOB_NUMBER FROM SERVICE_FEE_DEF_DTL INNER JOIN
													JOB_LOG ON SERVICE_FEE_DEF_DTL.DTL_CODE = JOB_LOG.SC_CODE
													WHERE SERVICE_FEE_DEF_DTL.DTL_TYPE = ''PROD_COMM_SC'')))'
					End	
					
				End	
				
			End		

SELECT @paramlist = ' @StartPeriod varchar(6), @EndPeriod varchar(6), @UserID varchar(100)'
print @sql
EXEC sp_executesql @sql, @paramlist, @StartPeriod, @EndPeriod, @UserID
SET @sql = ''


--Media
SELECT @sql = 'INSERT INTO #SERVICE_FEE
SELECT AR.CL_CODE, C.CL_NAME, AR.DIV_CODE, D.DIV_NAME, AR.PRD_CODE, P.PRD_DESCRIPTION, ISNULL(J.CMP_IDENTIFIER,''''), ISNULL(CAMP.CMP_CODE,''''), ISNULL(CAMP.CMP_NAME,''''),
			AR.SC_CODE, SC.SC_DESCRIPTION, ISNULL(JC.JOB_NUMBER,0), CASE WHEN J.JOB_DESC IS NULL THEN ''Media Commissions'' ELSE J.JOB_DESC END, ISNULL(JC.JOB_COMPONENT_NBR,0), 
			RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR(20), ISNULL(JC.JOB_NUMBER,0)), 6) + ''-'' + RIGHT(REPLICATE(''0'', 3) + CONVERT(VARCHAR(20), ISNULL(JC.JOB_COMPONENT_NBR,0)), 3),
			ISNULL(JC.JOB_COMP_DESC,''''), '''', ''Media Commissions'', '''',ISNULL(SFT.CODE,''''),ISNULL(SFT.DESCRIPTION,''''),''Media Commissions'',''Media Commissions'','''','''',
			''Media Billed'', AR.AR_INV_DATE, ''Media Commissions'','''',
			AR.AR_POST_PERIOD,0, AR.AR_COMM_AMT,0,0,0,0,0,0,0,0
		FROM  
			[dbo].[ACCT_REC] AR INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = AR.CL_CODE AND
									 D.DIV_CODE = AR.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = AR.CL_CODE AND
									P.DIV_CODE = AR.DIV_CODE AND
									P.PRD_CODE = AR.PRD_CODE LEFT OUTER JOIN
			[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = AR.JOB_NUMBER AND
										   JC.JOB_COMPONENT_NBR = AR.JOB_COMPONENT_NBR  LEFT OUTER JOIN 
			[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_CODE = AR.CMP_CODE INNER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD
		WHERE 
			(AR.AR_INV_SEQ = 0 OR 
			 AR.AR_INV_SEQ = 99) AND 
			(AR.MANUAL_INV = 0 OR 
			 AR.MANUAL_INV IS NULL)'
SELECT @sql = @sql + ' AND AR.AR_POST_PERIOD BETWEEN @StartPeriod AND @EndPeriod '		
if @MediaTypes <> ''
Begin
	SELECT @sql = @sql + ' AND AR.REC_TYPE IN (' + @MediaTypes + ')'
End
Else
Begin
	SELECT @sql = @sql + ' AND AR.REC_TYPE <> ''P'''
End

SELECT @paramlist = ' @StartPeriod varchar(6), @EndPeriod varchar(6), @UserID varchar(100)'
print @sql
EXEC sp_executesql @sql, @paramlist, @StartPeriod, @EndPeriod, @UserID
SET @sql = ''

--SELECT @sql = 'INSERT INTO #contract
--SELECT dbo.[CONTRACT].CL_CODE, dbo.CLIENT.CL_NAME, dbo.[CONTRACT].DIV_CODE, dbo.DIVISION.DIV_NAME, dbo.[CONTRACT].PRD_CODE, 
--                      dbo.PRODUCT.PRD_DESCRIPTION, dbo.CONTRACT_FEES.HOURS, dbo.CONTRACT_FEES.AMOUNT
--FROM dbo.[CONTRACT] INNER JOIN
--     dbo.CONTRACT_FEES ON dbo.[CONTRACT].CONTRACT_ID = dbo.CONTRACT_FEES.CONTRACT_ID INNER JOIN
--     dbo.SERVICE_FEE_TYPE ON dbo.CONTRACT_FEES.SERVICE_FEE_TYPE_ID = dbo.SERVICE_FEE_TYPE.SERVICE_FEE_TYPE_ID INNER JOIN
--     dbo.PRODUCT ON dbo.[CONTRACT].CL_CODE = dbo.PRODUCT.CL_CODE AND dbo.[CONTRACT].DIV_CODE = dbo.PRODUCT.DIV_CODE AND 
--     dbo.[CONTRACT].PRD_CODE = dbo.PRODUCT.PRD_CODE INNER JOIN
--     dbo.DIVISION ON dbo.[CONTRACT].CL_CODE = dbo.DIVISION.CL_CODE AND dbo.[CONTRACT].DIV_CODE = dbo.DIVISION.DIV_CODE INNER JOIN
--     dbo.CLIENT ON dbo.[CONTRACT].CL_CODE = dbo.CLIENT.CL_CODE
--WHERE ([CONTRACT].INACTIVE_FLAG = 0 OR [CONTRACT].INACTIVE_FLAG IS NULL) AND [CONTRACT].START_DATE BETWEEN @StartDate AND @EndDate'

--SELECT @paramlist = '@StartDate SmallDateTime, @EndDate SmallDateTime, @UserID varchar(100)'
--print @sql
--EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @UserID
--SET @sql = ''

--Actuals

If @ServiceFeeType = 'def'
Begin
INSERT INTO #SERVICE_FEE
 SELECT [ClientCode] = E2.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = E2.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = E2.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignID] = ISNULL(CAMP.CMP_IDENTIFIER,''),
			[CampaignCode] = ISNULL(CAMP.CMP_CODE,''), 
			[CampaignName] = ISNULL(CAMP.CMP_NAME,''),
			[SalesClassCode] = E2.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobNumber] = E2.JOB_NUMBER,
			[JobDescription] = E2.JOB_DESC,
			[ComponentNumber] = E2.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), E2.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), E2.JOB_COMPONENT_NBR), 3),
			[ComponentDescription] = E2.JOB_COMP_DESC, 
			[FunctionCode] = E2.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE,
			[ServiceFeeTypeCode] = ISNULL(E2.[E_DT_SFT_CODE],''),
			[ServiceFeeTypeDescription] = ISNULL(E2.[SFT_DESC],''),
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionConsolidation] = ISNULL(CF.FNC_DESCRIPTION,''),		
			[EmployeeCode] = ISNULL(E2.EMP_CODE,''),		
			[EmployeeName] = ISNULL(EMP.EmployeeName,''),
			[FeeTimeType] = CASE WHEN E2.FEE_TIME = 1 THEN 'Standard' 
								 WHEN E2.FEE_TIME = 2 THEN 'Production' 
								 ELSE 'Media' END,
			[FeeDate] = E2.EMP_DATE,
			[Description] = EMP.EmployeeName,
			[Comment] = ISNULL(E2.EMP_COMMENT,''),
			[PostPeriodCode] = (SELECT PPPERIOD FROM POSTPERIOD PP WHERE E2.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE),
			[FeeQuantity] = 0,
			[FeeAmount] = 0,
			[ReconciledHours] = SUM(E2.REC),
			[ReconciledAmount] = SUM(E2.RECTOTAL),
			[UnreconciledHours] = SUM(E2.UNREC),
			[UnreconciledAmount] = SUM(E2.UNRECTOTAL),
			[TotalHours] = SUM(E2.UNREC) + SUM(E2.REC),
			[TotalAmount] = SUM(E2.UNRECTOTAL) + SUM(E2.RECTOTAL),0,0
		FROM
			(SELECT
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				REC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')),      
				RECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')), 	
				UNREC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 	
				UNRECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,
				--E.EMP_NAME,
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			FROM
				(SELECT 
					J.CL_CODE, 
					J.DIV_CODE, 
					J.PRD_CODE,  
					JC.JOB_NUMBER,
					J.JOB_DESC,  
					JC.JOB_COMPONENT_NBR,
					JC.JOB_COMP_DESC, 
					J.CMP_IDENTIFIER, 
					J.SC_CODE,
					ETD.FNC_CODE,   
					ETD.FEE_REC_FLAG,  
					ETD.EMP_HOURS,      
					[TOTAL_BILL] = ISNULL(ETD.TOTAL_BILL, 0), 
					[EXT_MARKUP_AMT] = ISNULL(ETD.EXT_MARKUP_AMT, 0), 	
					ETD.FEE_TIME,
					ET.EMP_CODE,
					--[EMP_NAME] = COALESCE((RTRIM(ET.EMP_FNAME) + ' '),'') + COALESCE((ET.EMP_MI + '. '),'') + COALESCE(ET.EMP_LNAME,''),
					[EMP_COMMENT] = CAST(ETD.EMP_COMMENT AS varchar(MAX)),
					ET.EMP_DATE,
					[SERVICE_FEE_FLAG] = CAST(ISNULL(JC.SERVICE_FEE_FLAG, 0) AS bit),
					[ETD_DT_SFT_CODE] = ETD_DT.SERVICE_FEE_TYPE_CODE,
					[JC_SFT_CODE] = SFT.CODE,
					[E_DT_SFT_CODE] = E_DT.SERVICE_FEE_TYPE_CODE,
					[SFT_DESC] = SFT_DT.DESCRIPTION
				FROM  
					[dbo].[EMP_TIME] AS ET INNER JOIN 
					[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID INNER JOIN 
					[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND 
												   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN 
					[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
					[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS ETD_DT ON ETD_DT.DP_TM_CODE = ETD.DP_TM_CODE LEFT OUTER JOIN 
					[dbo].[EMPLOYEE] AS E ON E.EMP_CODE = ET.EMP_CODE LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS E_DT ON E_DT.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
					[dbo].[SERVICE_FEE_TYPE] AS SFT_DT ON SFT_DT.CODE = E_DT.SERVICE_FEE_TYPE_CODE
				WHERE 
					(ET.EMP_DATE BETWEEN @StartDate AND @EndDate) AND ETD.EMP_NON_BILL_FLAG = 1 AND 
					ETD.FEE_TIME IN (1, 2, 3)) AS E
			GROUP BY 
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,		
				--E.EMP_NAME,		
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			HAVING 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0) AS E2 INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = E2.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = E2.CL_CODE AND
									 D.DIV_CODE = E2.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = E2.CL_CODE AND
									P.DIV_CODE = E2.DIV_CODE AND
									P.PRD_CODE = E2.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = E2.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = E2.CMP_IDENTIFIER INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = E2.FNC_CODE LEFT OUTER JOIN 
			[dbo].[advtf_emp_names]() AS EMP ON EMP.EmployeeCode = E2.EMP_CODE LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION 
		GROUP BY
			E2.JOB_NUMBER,
			E2.CL_CODE,
			C.CL_NAME,
			E2.DIV_CODE,
			D.DIV_NAME,
			E2.PRD_CODE,
			P.PRD_DESCRIPTION,
			CAMP.CMP_IDENTIFIER,
			CAMP.CMP_CODE, 
			CAMP.CMP_NAME,
			E2.SC_CODE,
			SC.SC_DESCRIPTION,
			E2.JOB_DESC,
			E2.JOB_COMPONENT_NBR,
			E2.JOB_COMP_DESC, 
			E2.FNC_CODE,
			F.FNC_DESCRIPTION,
			F.FNC_TYPE,
			F.FNC_ORDER,
			E2.FEE_TIME,
			E2.EMP_DATE,
			E2.EMP_CODE,
			EMP.EmployeeName,
			E2.EMP_COMMENT,
			E2.SERVICE_FEE_FLAG,
			E2.[ETD_DT_SFT_CODE],
			E2.[JC_SFT_CODE],
			E2.[E_DT_SFT_CODE],
			E2.[SFT_DESC],
			FH.FNC_HEADING_DESC,
			FH.FNC_HEADING_SEQ,
			CF.FNC_DESCRIPTION,
			CF.FNC_TYPE,
			CF.FNC_ORDER
End
If @ServiceFeeType = 'time'
Begin
INSERT INTO #SERVICE_FEE
 SELECT [ClientCode] = E2.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = E2.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = E2.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignID] = ISNULL(CAMP.CMP_IDENTIFIER,''),
			[CampaignCode] = ISNULL(CAMP.CMP_CODE,''), 
			[CampaignName] = ISNULL(CAMP.CMP_NAME,''),
			[SalesClassCode] = E2.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobNumber] = E2.JOB_NUMBER,
			[JobDescription] = E2.JOB_DESC,
			[ComponentNumber] = E2.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), E2.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), E2.JOB_COMPONENT_NBR), 3),
			[ComponentDescription] = E2.JOB_COMP_DESC, 
			[FunctionCode] = E2.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE,
			[ServiceFeeTypeCode] = ISNULL(E2.[ETD_DT_SFT_CODE],''),
			[ServiceFeeTypeDescription] = ISNULL(E2.[SFT_DESC],''),
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionConsolidation] = ISNULL(CF.FNC_DESCRIPTION,''),	
			[EmployeeCode] = ISNULL(E2.EMP_CODE,''),		
			[EmployeeName] = ISNULL(EMP.EmployeeName,''),
			[FeeTimeType] = CASE WHEN E2.FEE_TIME = 1 THEN 'Standard' 
								 WHEN E2.FEE_TIME = 2 THEN 'Production' 
								 ELSE 'Media' END,
			[FeeDate] = E2.EMP_DATE,
			[Description] = EMP.EmployeeName,
			[Comment] = ISNULL(E2.EMP_COMMENT,''),
			[PostPeriodCode] = (SELECT PPPERIOD FROM POSTPERIOD PP WHERE E2.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE),
			[FeeQuantity] = 0,
			[FeeAmount] = 0,
			[ReconciledHours] = SUM(E2.REC),
			[ReconciledAmount] = SUM(E2.RECTOTAL),
			[UnreconciledHours] = SUM(E2.UNREC),
			[UnreconciledAmount] = SUM(E2.UNRECTOTAL),
			[TotalHours] = SUM(E2.UNREC) + SUM(E2.REC),
			[TotalAmount] = SUM(E2.UNRECTOTAL) + SUM(E2.RECTOTAL),0,0
		FROM
			(SELECT
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				REC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')),      
				RECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')), 	
				UNREC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 	
				UNRECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,
				--E.EMP_NAME,
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			FROM
				(SELECT 
					J.CL_CODE, 
					J.DIV_CODE, 
					J.PRD_CODE,  
					JC.JOB_NUMBER,
					J.JOB_DESC,  
					JC.JOB_COMPONENT_NBR,
					JC.JOB_COMP_DESC, 
					J.CMP_IDENTIFIER, 
					J.SC_CODE,
					ETD.FNC_CODE,   
					ETD.FEE_REC_FLAG,  
					ETD.EMP_HOURS,      
					[TOTAL_BILL] = ISNULL(ETD.TOTAL_BILL, 0), 
					[EXT_MARKUP_AMT] = ISNULL(ETD.EXT_MARKUP_AMT, 0), 	
					ETD.FEE_TIME,
					ET.EMP_CODE,
					--[EMP_NAME] = COALESCE((RTRIM(ET.EMP_FNAME) + ' '),'') + COALESCE((ET.EMP_MI + '. '),'') + COALESCE(ET.EMP_LNAME,''),
					[EMP_COMMENT] = CAST(ETD.EMP_COMMENT AS varchar(MAX)),
					ET.EMP_DATE,
					[SERVICE_FEE_FLAG] = CAST(ISNULL(JC.SERVICE_FEE_FLAG, 0) AS bit),
					[ETD_DT_SFT_CODE] = ETD_DT.SERVICE_FEE_TYPE_CODE,
					[JC_SFT_CODE] = SFT.CODE,
					[E_DT_SFT_CODE] = E_DT.SERVICE_FEE_TYPE_CODE,
					[SFT_DESC] = SFT_ETD_DT.DESCRIPTION
				FROM  
					[dbo].[EMP_TIME] AS ET INNER JOIN 
					[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID INNER JOIN 
					[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND 
												   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN 
					[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
					[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS ETD_DT ON ETD_DT.DP_TM_CODE = ETD.DP_TM_CODE LEFT OUTER JOIN 
					[dbo].[EMPLOYEE] AS E ON E.EMP_CODE = ET.EMP_CODE LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS E_DT ON E_DT.DP_TM_CODE = E.DP_TM_CODE LEFT OUTER JOIN
					[dbo].[SERVICE_FEE_TYPE] AS SFT_ETD_DT ON SFT_ETD_DT.CODE = ETD_DT.SERVICE_FEE_TYPE_CODE
				WHERE 
					(ET.EMP_DATE BETWEEN @StartDate AND @EndDate) AND ETD.EMP_NON_BILL_FLAG = 1 AND 
					ETD.FEE_TIME IN (1, 2, 3)) AS E
			GROUP BY 
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,		
				--E.EMP_NAME,		
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			HAVING 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0) AS E2 INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = E2.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = E2.CL_CODE AND
									 D.DIV_CODE = E2.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = E2.CL_CODE AND
									P.DIV_CODE = E2.DIV_CODE AND
									P.PRD_CODE = E2.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = E2.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = E2.CMP_IDENTIFIER INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = E2.FNC_CODE LEFT OUTER JOIN 
			[dbo].[advtf_emp_names]() AS EMP ON EMP.EmployeeCode = E2.EMP_CODE LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION 
		GROUP BY
			E2.JOB_NUMBER,
			E2.CL_CODE,
			C.CL_NAME,
			E2.DIV_CODE,
			D.DIV_NAME,
			E2.PRD_CODE,
			P.PRD_DESCRIPTION,
			CAMP.CMP_IDENTIFIER,
			CAMP.CMP_CODE, 
			CAMP.CMP_NAME,
			E2.SC_CODE,
			SC.SC_DESCRIPTION,
			E2.JOB_DESC,
			E2.JOB_COMPONENT_NBR,
			E2.JOB_COMP_DESC, 
			E2.FNC_CODE,
			F.FNC_DESCRIPTION,
			F.FNC_TYPE,
			F.FNC_ORDER,
			E2.FEE_TIME,
			E2.EMP_DATE,
			E2.EMP_CODE,
			EMP.EmployeeName,
			E2.EMP_COMMENT,
			E2.SERVICE_FEE_FLAG,
			E2.[ETD_DT_SFT_CODE],
			E2.[JC_SFT_CODE],
			E2.[E_DT_SFT_CODE],
			E2.[SFT_DESC],
			FH.FNC_HEADING_DESC,
			FH.FNC_HEADING_SEQ,
			CF.FNC_DESCRIPTION,
			CF.FNC_TYPE,
			CF.FNC_ORDER
End
If @ServiceFeeType = 'job'
Begin
INSERT INTO #SERVICE_FEE
 SELECT [ClientCode] = E2.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = E2.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = E2.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignID] = ISNULL(CAMP.CMP_IDENTIFIER,''),
			[CampaignCode] = ISNULL(CAMP.CMP_CODE,''), 
			[CampaignName] = ISNULL(CAMP.CMP_NAME,''),
			[SalesClassCode] = E2.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobNumber] = E2.JOB_NUMBER,
			[JobDescription] = E2.JOB_DESC,
			[ComponentNumber] = E2.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), E2.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), E2.JOB_COMPONENT_NBR), 3),
			[ComponentDescription] = E2.JOB_COMP_DESC, 
			[FunctionCode] = E2.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE,
			[ServiceFeeTypeCode] = ISNULL(E2.[JC_SFT_CODE],''),
			[ServiceFeeTypeDescription] = ISNULL(E2.[SFT_DESC],''),
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionConsolidation] = ISNULL(CF.FNC_DESCRIPTION,''),	
			[EmployeeCode] = ISNULL(E2.EMP_CODE,''),		
			[EmployeeName] = ISNULL(EMP.EmployeeName,''),
			[FeeTimeType] = CASE WHEN E2.FEE_TIME = 1 THEN 'Standard' 
								 WHEN E2.FEE_TIME = 2 THEN 'Production' 
								 ELSE 'Media' END,
			[FeeDate] = E2.EMP_DATE,
			[Description] = EMP.EmployeeName,
			[Comment] = ISNULL(E2.EMP_COMMENT,''),
			[PostPeriodCode] = (SELECT PPPERIOD FROM POSTPERIOD PP WHERE E2.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE),
			[FeeQuantity] = 0,
			[FeeAmount] = 0,
			[ReconciledHours] = SUM(E2.REC),
			[ReconciledAmount] = SUM(E2.RECTOTAL),
			[UnreconciledHours] = SUM(E2.UNREC),
			[UnreconciledAmount] = SUM(E2.UNRECTOTAL),
			[TotalHours] = SUM(E2.UNREC) + SUM(E2.REC),
			[TotalAmount] = SUM(E2.UNRECTOTAL) + SUM(E2.RECTOTAL),0,0
		FROM
			(SELECT
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				REC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')),      
				RECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')), 	
				UNREC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 	
				UNRECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,
				--E.EMP_NAME,
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			FROM
				(SELECT 
					J.CL_CODE, 
					J.DIV_CODE, 
					J.PRD_CODE,  
					JC.JOB_NUMBER,
					J.JOB_DESC,  
					JC.JOB_COMPONENT_NBR,
					JC.JOB_COMP_DESC, 
					J.CMP_IDENTIFIER, 
					J.SC_CODE,
					ETD.FNC_CODE,   
					ETD.FEE_REC_FLAG,  
					ETD.EMP_HOURS,      
					[TOTAL_BILL] = ISNULL(ETD.TOTAL_BILL, 0), 
					[EXT_MARKUP_AMT] = ISNULL(ETD.EXT_MARKUP_AMT, 0), 	
					ETD.FEE_TIME,
					ET.EMP_CODE,
					--[EMP_NAME] = COALESCE((RTRIM(ET.EMP_FNAME) + ' '),'') + COALESCE((ET.EMP_MI + '. '),'') + COALESCE(ET.EMP_LNAME,''),
					[EMP_COMMENT] = CAST(ETD.EMP_COMMENT AS varchar(MAX)),
					ET.EMP_DATE,
					[SERVICE_FEE_FLAG] = CAST(ISNULL(JC.SERVICE_FEE_FLAG, 0) AS bit),
					[ETD_DT_SFT_CODE] = ETD_DT.SERVICE_FEE_TYPE_CODE,
					[JC_SFT_CODE] = SFT.CODE,
					[E_DT_SFT_CODE] = E_DT.SERVICE_FEE_TYPE_CODE,
					[SFT_DESC] = SFT.DESCRIPTION
				FROM  
					[dbo].[EMP_TIME] AS ET INNER JOIN 
					[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID INNER JOIN 
					[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND 
												   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN 
					[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
					[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS ETD_DT ON ETD_DT.DP_TM_CODE = ETD.DP_TM_CODE LEFT OUTER JOIN 
					[dbo].[EMPLOYEE] AS E ON E.EMP_CODE = ET.EMP_CODE LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS E_DT ON E_DT.DP_TM_CODE = E.DP_TM_CODE
				WHERE 
					(ET.EMP_DATE BETWEEN @StartDate AND @EndDate) AND ETD.EMP_NON_BILL_FLAG = 1 AND 
					ETD.FEE_TIME IN (1, 2, 3)) AS E
			GROUP BY 
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,		
				--E.EMP_NAME,		
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			HAVING 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0) AS E2 INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = E2.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = E2.CL_CODE AND
									 D.DIV_CODE = E2.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = E2.CL_CODE AND
									P.DIV_CODE = E2.DIV_CODE AND
									P.PRD_CODE = E2.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = E2.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = E2.CMP_IDENTIFIER INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = E2.FNC_CODE LEFT OUTER JOIN 
			[dbo].[advtf_emp_names]() AS EMP ON EMP.EmployeeCode = E2.EMP_CODE LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION 
		GROUP BY
			E2.JOB_NUMBER,
			E2.CL_CODE,
			C.CL_NAME,
			E2.DIV_CODE,
			D.DIV_NAME,
			E2.PRD_CODE,
			P.PRD_DESCRIPTION,
			CAMP.CMP_IDENTIFIER,
			CAMP.CMP_CODE, 
			CAMP.CMP_NAME,
			E2.SC_CODE,
			SC.SC_DESCRIPTION,
			E2.JOB_DESC,
			E2.JOB_COMPONENT_NBR,
			E2.JOB_COMP_DESC, 
			E2.FNC_CODE,
			F.FNC_DESCRIPTION,
			F.FNC_TYPE,
			F.FNC_ORDER,
			E2.FEE_TIME,
			E2.EMP_DATE,
			E2.EMP_CODE,
			EMP.EmployeeName,
			E2.EMP_COMMENT,
			E2.SERVICE_FEE_FLAG,
			E2.[ETD_DT_SFT_CODE],
			E2.[JC_SFT_CODE],
			E2.[E_DT_SFT_CODE],
			E2.[SFT_DESC],
			FH.FNC_HEADING_DESC,
			FH.FNC_HEADING_SEQ,
			CF.FNC_DESCRIPTION,
			CF.FNC_TYPE,
			CF.FNC_ORDER
End		
If @ServiceFeeType = ''
Begin
INSERT INTO #SERVICE_FEE
 SELECT [ClientCode] = E2.CL_CODE,
			[ClientDescription] = C.CL_NAME,
			[DivisionCode] = E2.DIV_CODE,
			[DivisionDescription] = D.DIV_NAME,
			[ProductCode] = E2.PRD_CODE,
			[ProductDescription] = P.PRD_DESCRIPTION,
			[CampaignID] = ISNULL(CAMP.CMP_IDENTIFIER,''),
			[CampaignCode] = ISNULL(CAMP.CMP_CODE,''), 
			[CampaignName] = ISNULL(CAMP.CMP_NAME,''),
			[SalesClassCode] = E2.SC_CODE,
			[SalesClassDescription] = SC.SC_DESCRIPTION,
			[JobNumber] = E2.JOB_NUMBER,
			[JobDescription] = E2.JOB_DESC,
			[ComponentNumber] = E2.JOB_COMPONENT_NBR,
			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), E2.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), E2.JOB_COMPONENT_NBR), 3),
			[ComponentDescription] = E2.JOB_COMP_DESC, 
			[FunctionCode] = E2.FNC_CODE,
			[FunctionDescription] = F.FNC_DESCRIPTION,
			[FunctionType] = F.FNC_TYPE,
			[ServiceFeeTypeCode] = CASE WHEN ISNULL(E2.[JC_SFT_CODE],'') = '' THEN CASE WHEN ISNULL(E2.[ETD_DT_SFT_CODE],'') = '' THEN ISNULL(E2.[E_DT_SFT_CODE],'') ELSE ISNULL(E2.[ETD_DT_SFT_CODE],'') END ELSE ISNULL(E2.[JC_SFT_CODE],'') END,
			[ServiceFeeTypeDescription] = ISNULL(E2.[SFT_DESC],''),
			[FunctionHeading] = FH.FNC_HEADING_DESC,
			[FunctionConsolidation] = ISNULL(CF.FNC_DESCRIPTION,''),	
			[EmployeeCode] = ISNULL(E2.EMP_CODE,''),		
			[EmployeeName] = ISNULL(EMP.EmployeeName,''),
			[FeeTimeType] = CASE WHEN E2.FEE_TIME = 1 THEN 'Standard' 
								 WHEN E2.FEE_TIME = 2 THEN 'Production' 
								 ELSE 'Media' END,
			[FeeDate] = E2.EMP_DATE,
			[Description] = EMP.EmployeeName,
			[Comment] = ISNULL(E2.EMP_COMMENT,''),
			[PostPeriodCode] = (SELECT PPPERIOD FROM POSTPERIOD PP WHERE E2.EMP_DATE BETWEEN PP.PPSRTDATE AND PP.PPENDDATE),
			[FeeQuantity] = 0,
			[FeeAmount] = 0,
			[ReconciledHours] = SUM(E2.REC),
			[ReconciledAmount] = SUM(E2.RECTOTAL),
			[UnreconciledHours] = SUM(E2.UNREC),
			[UnreconciledAmount] = SUM(E2.UNRECTOTAL),
			[TotalHours] = SUM(E2.UNREC) + SUM(E2.REC),
			[TotalAmount] = SUM(E2.UNRECTOTAL) + SUM(E2.RECTOTAL),0,0
		FROM
			(SELECT
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				REC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')),      
				RECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')), 	
				UNREC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 	
				UNRECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,
				--E.EMP_NAME,
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			FROM
				(SELECT 
					J.CL_CODE, 
					J.DIV_CODE, 
					J.PRD_CODE,  
					JC.JOB_NUMBER,
					J.JOB_DESC,  
					JC.JOB_COMPONENT_NBR,
					JC.JOB_COMP_DESC, 
					J.CMP_IDENTIFIER, 
					J.SC_CODE,
					ETD.FNC_CODE,   
					ETD.FEE_REC_FLAG,  
					ETD.EMP_HOURS,      
					[TOTAL_BILL] = ISNULL(ETD.TOTAL_BILL, 0), 
					[EXT_MARKUP_AMT] = ISNULL(ETD.EXT_MARKUP_AMT, 0), 	
					ETD.FEE_TIME,
					ET.EMP_CODE,
					--[EMP_NAME] = COALESCE((RTRIM(ET.EMP_FNAME) + ' '),'') + COALESCE((ET.EMP_MI + '. '),'') + COALESCE(ET.EMP_LNAME,''),
					[EMP_COMMENT] = CAST(ETD.EMP_COMMENT AS varchar(MAX)),
					ET.EMP_DATE,
					[SERVICE_FEE_FLAG] = CAST(ISNULL(JC.SERVICE_FEE_FLAG, 0) AS bit),
					[ETD_DT_SFT_CODE] = ETD_DT.SERVICE_FEE_TYPE_CODE,
					[JC_SFT_CODE] = SFT.CODE,
					[E_DT_SFT_CODE] = E_DT.SERVICE_FEE_TYPE_CODE,
					[SFT_DESC] = SFT.DESCRIPTION
				FROM  
					[dbo].[EMP_TIME] AS ET INNER JOIN 
					[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID INNER JOIN 
					[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND 
												   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN 
					[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
					[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS ETD_DT ON ETD_DT.DP_TM_CODE = ETD.DP_TM_CODE LEFT OUTER JOIN 
					[dbo].[EMPLOYEE] AS E ON E.EMP_CODE = ET.EMP_CODE LEFT OUTER JOIN 
					[dbo].[DEPT_TEAM] AS E_DT ON E_DT.DP_TM_CODE = E.DP_TM_CODE
				WHERE 
					(ET.EMP_DATE BETWEEN @StartDate AND @EndDate) AND ETD.EMP_NON_BILL_FLAG = 1 AND 
					ETD.FEE_TIME IN (1, 2, 3)) AS E
			GROUP BY 
				E.CL_CODE, 
				E.DIV_CODE, 
				E.PRD_CODE,  
				E.JOB_NUMBER,
				E.JOB_DESC,  
				E.JOB_COMPONENT_NBR,
				E.JOB_COMP_DESC, 
				E.CMP_IDENTIFIER, 
				E.SC_CODE,
				E.FNC_CODE, 
				E.FEE_TIME,
				E.EMP_DATE,
				E.EMP_CODE,		
				--E.EMP_NAME,		
				E.EMP_COMMENT,
				E.SERVICE_FEE_FLAG,
				E.[ETD_DT_SFT_CODE],
				E.[JC_SFT_CODE],
				E.[E_DT_SFT_CODE],
				E.[SFT_DESC]
			HAVING 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0 OR 
				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0) AS E2 INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = E2.CL_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = E2.CL_CODE AND
									 D.DIV_CODE = E2.DIV_CODE INNER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = E2.CL_CODE AND
									P.DIV_CODE = E2.DIV_CODE AND
									P.PRD_CODE = E2.PRD_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = E2.SC_CODE LEFT OUTER JOIN 
			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = E2.CMP_IDENTIFIER INNER JOIN 
			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = E2.FNC_CODE LEFT OUTER JOIN 
			[dbo].[advtf_emp_names]() AS EMP ON EMP.EmployeeCode = E2.EMP_CODE LEFT OUTER JOIN
			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION 
		GROUP BY
			E2.JOB_NUMBER,
			E2.CL_CODE,
			C.CL_NAME,
			E2.DIV_CODE,
			D.DIV_NAME,
			E2.PRD_CODE,
			P.PRD_DESCRIPTION,
			CAMP.CMP_IDENTIFIER,
			CAMP.CMP_CODE, 
			CAMP.CMP_NAME,
			E2.SC_CODE,
			SC.SC_DESCRIPTION,
			E2.JOB_DESC,
			E2.JOB_COMPONENT_NBR,
			E2.JOB_COMP_DESC, 
			E2.FNC_CODE,
			F.FNC_DESCRIPTION,
			F.FNC_TYPE,
			F.FNC_ORDER,
			E2.FEE_TIME,
			E2.EMP_DATE,
			E2.EMP_CODE,
			EMP.EmployeeName,
			E2.EMP_COMMENT,
			E2.SERVICE_FEE_FLAG,
			E2.[ETD_DT_SFT_CODE],
			E2.[JC_SFT_CODE],
			E2.[E_DT_SFT_CODE],
			E2.[SFT_DESC],
			FH.FNC_HEADING_DESC,
			FH.FNC_HEADING_SEQ,
			CF.FNC_DESCRIPTION,
			CF.FNC_TYPE,
			CF.FNC_ORDER
End		

--INSERT INTO #SERVICE_FEE
-- SELECT [ClientCode] = E2.CL_CODE,
--			[ClientDescription] = C.CL_NAME,
--			[DivisionCode] = E2.DIV_CODE,
--			[DivisionDescription] = D.DIV_NAME,
--			[ProductCode] = E2.PRD_CODE,
--			[ProductDescription] = P.PRD_DESCRIPTION,
--			[CampaignID] = ISNULL(CAMP.CMP_IDENTIFIER,''),
--			[CampaignCode] = ISNULL(CAMP.CMP_CODE,''), 
--			[CampaignName] = ISNULL(CAMP.CMP_NAME,''),
--			[SalesClassCode] = E2.SC_CODE,
--			[SalesClassDescription] = SC.SC_DESCRIPTION,
--			[JobNumber] = E2.JOB_NUMBER,
--			[JobDescription] = E2.JOB_DESC,
--			[ComponentNumber] = E2.JOB_COMPONENT_NBR,
--			[JobComponent] = RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), E2.JOB_NUMBER), 6) + '-' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), E2.JOB_COMPONENT_NBR), 2),
--			[ComponentDescription] = E2.JOB_COMP_DESC, 
--			[FunctionCode] = E2.FNC_CODE,
--			[FunctionDescription] = F.FNC_DESCRIPTION,
--			[FunctionType] = F.FNC_TYPE,
--			[FunctionOrderNumber] = F.FNC_ORDER,
--			[EmployeeTimeEntryDepartmentTeamServiceFeeTypeCode] = ISNULL(E2.[ETD_DT_SFT_CODE],''),
--			[JobServiceFeeTypeCode] = ISNULL(E2.[JC_SFT_CODE],''),
--			[EmployeeDepartmentTeamServiceFeeTypeCode] = ISNULL(E2.[E_DT_SFT_CODE],''),
--			[FunctionHeading] = FH.FNC_HEADING_DESC,
--			[FunctionHeadingOrderNumber] = FH.FNC_HEADING_SEQ,
--			[FunctionConsolidation] = ISNULL(CF.FNC_DESCRIPTION,''),
--			[FunctionConsolidationType] = ISNULL(CF.FNC_TYPE,''),
--			[FunctionConsolidationOrderNumber] = ISNULL(CF.FNC_ORDER,''),		
--			[EmployeeCode] = ISNULL(E2.EMP_CODE,''),		
--			[EmployeeName] = ISNULL(EMP.EmployeeName,''),
--			[FeeTimeType] = CASE WHEN E2.FEE_TIME = 1 THEN 'Standard' 
--								 WHEN E2.FEE_TIME = 2 THEN 'Production' 
--								 ELSE 'Media' END,
--			[IsServiceFeeJob] = E2.SERVICE_FEE_FLAG,
--			[FeeDate] = E2.EMP_DATE,
--			[Description] = EMP.EmployeeName,
--			[Comment] = ISNULL(E2.EMP_COMMENT,''),
--			[MediaType] = '', 
--			[PostPeriodCode] = '',
--			[FeeQuantity] = 0,
--			[FeeAmount] = 0,
--			[ReconciledHours] = SUM(E2.REC),
--			[ReconciledAmount] = SUM(E2.RECTOTAL),
--			[UnreconciledHours] = SUM(E2.UNREC),
--			[UnreconciledAmount] = SUM(E2.UNRECTOTAL),
--			[TotalHours] = SUM(E2.UNREC) + SUM(E2.REC),
--			[TotalAmount] = SUM(E2.UNRECTOTAL) + SUM(E2.RECTOTAL),0,0
--		FROM
--			(SELECT
--				E.CL_CODE, 
--				E.DIV_CODE, 
--				E.PRD_CODE,  
--				E.JOB_NUMBER,
--				E.JOB_DESC,  
--				E.JOB_COMPONENT_NBR,
--				E.JOB_COMP_DESC, 
--				E.CMP_IDENTIFIER, 
--				E.SC_CODE,
--				E.FNC_CODE, 
--				REC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')),      
--				RECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')), 	
--				UNREC = SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 	
--				UNRECTOTAL = SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')), 
--				E.FEE_TIME,
--				E.EMP_DATE,
--				E.EMP_CODE,
--				--E.EMP_NAME,
--				E.EMP_COMMENT,
--				E.SERVICE_FEE_FLAG,
--				E.[ETD_DT_SFT_CODE],
--				E.[JC_SFT_CODE],
--				E.[E_DT_SFT_CODE]
--			FROM
--				(SELECT 
--					J.CL_CODE, 
--					J.DIV_CODE, 
--					J.PRD_CODE,  
--					JC.JOB_NUMBER,
--					J.JOB_DESC,  
--					JC.JOB_COMPONENT_NBR,
--					JC.JOB_COMP_DESC, 
--					J.CMP_IDENTIFIER, 
--					J.SC_CODE,
--					ETD.FNC_CODE,   
--					ETD.FEE_REC_FLAG,  
--					ETD.EMP_HOURS,      
--					[TOTAL_BILL] = ISNULL(ETD.TOTAL_BILL, 0), 
--					[EXT_MARKUP_AMT] = ISNULL(ETD.EXT_MARKUP_AMT, 0), 	
--					ETD.FEE_TIME,
--					ET.EMP_CODE,
--					--[EMP_NAME] = COALESCE((RTRIM(ET.EMP_FNAME) + ' '),'') + COALESCE((ET.EMP_MI + '. '),'') + COALESCE(ET.EMP_LNAME,''),
--					[EMP_COMMENT] = CAST(ETD.EMP_COMMENT AS varchar(MAX)),
--					ET.EMP_DATE,
--					[SERVICE_FEE_FLAG] = CAST(ISNULL(JC.SERVICE_FEE_FLAG, 0) AS bit),
--					[ETD_DT_SFT_CODE] = ETD_DT.SERVICE_FEE_TYPE_CODE,
--					[JC_SFT_CODE] = SFT.CODE,
--					[E_DT_SFT_CODE] = E_DT.SERVICE_FEE_TYPE_CODE
--				FROM  
--					[dbo].[EMP_TIME] AS ET INNER JOIN 
--					[dbo].[EMP_TIME_DTL] AS ETD ON ETD.ET_ID = ET.ET_ID INNER JOIN 
--					[dbo].[JOB_COMPONENT] AS JC ON JC.JOB_NUMBER = ETD.JOB_NUMBER AND 
--												   JC.JOB_COMPONENT_NBR = ETD.JOB_COMPONENT_NBR INNER JOIN 
--					[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
--					[dbo].[SERVICE_FEE_TYPE] AS SFT ON SFT.SERVICE_FEE_TYPE_ID = JC.SERVICE_FEE_TYPE_ID LEFT OUTER JOIN 
--					[dbo].[DEPT_TEAM] AS ETD_DT ON ETD_DT.DP_TM_CODE = ETD.DP_TM_CODE LEFT OUTER JOIN 
--					[dbo].[EMPLOYEE] AS E ON E.EMP_CODE = ET.EMP_CODE LEFT OUTER JOIN 
--					[dbo].[DEPT_TEAM] AS E_DT ON E_DT.DP_TM_CODE = E.DP_TM_CODE
--				WHERE 
--					(ET.EMP_DATE BETWEEN @StartDate AND @EndDate) AND ETD.EMP_NON_BILL_FLAG = 1 AND 
--					ETD.FEE_TIME IN (1, 2, 3)) AS E
--			GROUP BY 
--				E.CL_CODE, 
--				E.DIV_CODE, 
--				E.PRD_CODE,  
--				E.JOB_NUMBER,
--				E.JOB_DESC,  
--				E.JOB_COMPONENT_NBR,
--				E.JOB_COMP_DESC, 
--				E.CMP_IDENTIFIER, 
--				E.SC_CODE,
--				E.FNC_CODE, 
--				E.FEE_TIME,
--				E.EMP_DATE,
--				E.EMP_CODE,		
--				--E.EMP_NAME,		
--				E.EMP_COMMENT,
--				E.SERVICE_FEE_FLAG,
--				E.[ETD_DT_SFT_CODE],
--				E.[JC_SFT_CODE],
--				E.[E_DT_SFT_CODE]
--			HAVING 
--				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
--				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '1')) > 0 OR 
--				SUM(E.EMP_HOURS * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0 OR 
--				SUM((ISNULL(E.TOTAL_BILL,0) + ISNULL(E.EXT_MARKUP_AMT,0)) * CHARINDEX(CAST(E.FEE_REC_FLAG AS CHAR(1)), '0')) > 0) AS E2 INNER JOIN
--			[dbo].[CLIENT] AS C ON C.CL_CODE = E2.CL_CODE INNER JOIN
--			[dbo].[DIVISION] AS D ON D.CL_CODE = E2.CL_CODE AND
--									 D.DIV_CODE = E2.DIV_CODE INNER JOIN
--			[dbo].[PRODUCT] AS P ON P.CL_CODE = E2.CL_CODE AND
--									P.DIV_CODE = E2.DIV_CODE AND
--									P.PRD_CODE = E2.PRD_CODE LEFT OUTER JOIN
--			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = E2.SC_CODE LEFT OUTER JOIN 
--			[dbo].[CAMPAIGN] AS CAMP ON CAMP.CMP_IDENTIFIER = E2.CMP_IDENTIFIER INNER JOIN 
--			[dbo].[FUNCTIONS] AS F ON F.FNC_CODE = E2.FNC_CODE LEFT OUTER JOIN 
--			[dbo].[advtf_emp_names]() AS EMP ON EMP.EmployeeCode = E2.EMP_CODE LEFT OUTER JOIN
--			[dbo].[FNC_HEADING] AS FH ON FH.FNC_HEADING_ID = F.FNC_HEADING_ID LEFT OUTER JOIN
--			[dbo].[FUNCTIONS] AS CF ON CF.FNC_CODE = F.FNC_CONSOLIDATION 
--		GROUP BY
--			E2.JOB_NUMBER,
--			E2.CL_CODE,
--			C.CL_NAME,
--			E2.DIV_CODE,
--			D.DIV_NAME,
--			E2.PRD_CODE,
--			P.PRD_DESCRIPTION,
--			CAMP.CMP_IDENTIFIER,
--			CAMP.CMP_CODE, 
--			CAMP.CMP_NAME,
--			E2.SC_CODE,
--			SC.SC_DESCRIPTION,
--			E2.JOB_DESC,
--			E2.JOB_COMPONENT_NBR,
--			E2.JOB_COMP_DESC, 
--			E2.FNC_CODE,
--			F.FNC_DESCRIPTION,
--			F.FNC_TYPE,
--			F.FNC_ORDER,
--			E2.FEE_TIME,
--			E2.EMP_DATE,
--			E2.EMP_CODE,
--			EMP.EmployeeName,
--			E2.EMP_COMMENT,
--			E2.SERVICE_FEE_FLAG,
--			E2.[ETD_DT_SFT_CODE],
--			E2.[JC_SFT_CODE],
--			E2.[E_DT_SFT_CODE],
--			FH.FNC_HEADING_DESC,
--			FH.FNC_HEADING_SEQ,
--			CF.FNC_DESCRIPTION,
--			CF.FNC_TYPE,
--			CF.FNC_ORDER
 
 
		set @sql = 'INSERT INTO #SERVICE_FEE_TOTAL SELECT'
		If @IncludeClient = 1
		Begin
			set @sql = @sql+' [ClientCode],[ClientDescription],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [ClientCode],'''' AS [ClientDescription],'
		End
		If @IncludeDivision = 1 OR @DesktopObject = 1 OR @DesktopObject = 2
		Begin
			set @sql = @sql+' [DivisionCode],[DivisionDescription],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [DivisionCode],'''' AS [DivisionDescription],'
		End
		If @IncludeProduct = 1 OR @DesktopObject = 1 OR @DesktopObject = 2
		Begin
			set @sql = @sql+' [ProductCode],[ProductDescription],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [ProductCode],'''' AS [ProductDescription],'
		End
		If @IncludeCampaign = 1
		Begin
			set @sql = @sql+' [CampaignID],[CampaignCode],[CampaignName],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [CampaignID],'''' AS [CampaignCode],'''' AS [CampaignName],'
		End
		If @IncludeSalesClass = 1
		Begin
			set @sql = @sql+' [SalesClassCode],[SalesClassDescription],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [SalesClassCode],'''' AS [SalesClassDescription],'
		End
		If @IncludeJobNumber = 1
		Begin
			set @sql = @sql+' [JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [JobNumber],'''' AS [JobDescription],'''' AS [ComponentNumber],'''' AS [JobComponent],'''' AS [ComponentDescription],'
		End
		If @IncludeFunctionCode = 1
		Begin
			set @sql = @sql+' [FunctionCode],[FunctionDescription],[FunctionType],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionCode],'''' AS [FunctionDescription],'''' AS [FunctionType],'
		End
		If @IncludeFeeType = 1
		Begin
			set @sql = @sql+' [ServiceFeeTypeCode],[ServiceFeeTypeDescription],'					
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [ServiceFeeTypeCode],'''' AS [ServiceFeeTypeDescription],'
		End
		If @IncludeFunctionHeading = 1
		Begin
			set @sql = @sql+' [FunctionHeading],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionHeading],'
		End
		If @IncludeFunctionConsolidation = 1
		Begin
			set @sql = @sql+' [FunctionConsolidation],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionConsolidation],'
		End
		If @IncludeEmployee = 1
		Begin
			set @sql = @sql+' [EmployeeCode],[EmployeeName],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [EmployeeCode],'''' AS [EmployeeName],'
		End
		set @sql = @sql+' [FeeTimeType],'
		If @IncludeDate = 1
		Begin
			set @sql = @sql+' [FeeDate],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FeeDate],'
		End
		If @IncludeEmployee = 1
		Begin
			set @sql = @sql+' [Description],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [Description],'
		End
		set @sql = @sql+' [Comment],'
		if @IncludePostPeriod = 1
		Begin
			set @sql = @sql+' [PostPeriodCode],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [PostPeriodCode],'
		End
		set @sql = @sql+' SUM([FeeQuantity]),SUM([FeeAmount]),SUM([ReconciledHours]),SUM([ReconciledAmount]),SUM([UnreconciledHours]),SUM([UnreconciledAmount]),SUM([Hours]),
						  SUM([Amount]),SUM([VarianceHours]),SUM([FeeAmount]) - SUM([Amount])'

			
		set @sql = @sql+' FROM #SERVICE_FEE '

		set @sql_groupby = 'GROUP BY'
		If @IncludeClient = 1
		Begin
			set @sql_groupby = @sql_groupby+' [ClientCode],[ClientDescription],'
		End
		If @IncludeDivision = 1 OR @DesktopObject = 1 OR @DesktopObject = 2
		Begin
			set @sql_groupby = @sql_groupby+' [DivisionCode],[DivisionDescription],'
		End
		If @IncludeProduct = 1 OR @DesktopObject = 1 OR @DesktopObject = 2
		Begin
			set @sql_groupby = @sql_groupby+' [ProductCode],[ProductDescription],'
		End
		If @IncludeCampaign = 1
		Begin
			set @sql_groupby = @sql_groupby+' [CampaignID],[CampaignCode],[CampaignName],'
		End
		If @IncludeSalesClass = 1
		Begin
			set @sql_groupby = @sql_groupby+' [SalesClassCode],[SalesClassDescription],'
		End
		If @IncludeJobNumber = 1
		Begin
			set @sql_groupby = @sql_groupby+' [JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],'
		End
		If @IncludeFunctionCode = 1
		Begin
			set @sql_groupby = @sql_groupby+' [FunctionCode],[FunctionDescription],[FunctionType],'
		End
		If @IncludeFeeType = 1
		Begin
			set @sql_groupby = @sql_groupby+' [ServiceFeeTypeCode],[ServiceFeeTypeDescription],'
		End
		If @IncludeFunctionHeading = 1
		Begin
			set @sql_groupby = @sql_groupby+' [FunctionHeading],'
		End
		If @IncludeFunctionConsolidation = 1
		Begin
			set @sql_groupby = @sql_groupby+' [FunctionConsolidation],'
		End
		If @IncludeEmployee = 1
		Begin
			set @sql_groupby = @sql_groupby+' [EmployeeCode],[EmployeeName],[Description],'
		End
		set @sql_groupby = @sql_groupby+' [FeeTimeType],'
		If @IncludeDate = 1
		Begin
			set @sql_groupby = @sql_groupby+' [FeeDate],'
		End
		if @IncludePostPeriod = 1
		Begin
			set @sql_groupby = @sql_groupby+' [PostPeriodCode],'
		End
		set @sql_groupby = @sql_groupby+' [Comment]'


		If @sql_groupby <> 'GROUP BY'
		Begin
			 If @sql_groupby LIKE '%,'
			 Begin
				Set @sql_groupby = LEFT(@sql_groupby, LEN(@sql_groupby)-1)
			 End
			 SET @sql = @sql+@sql_groupby 
			 PRINT @sql
			 EXEC sp_executesql @sql
	 
		End
		Else
		Begin
			PRINT @sql
			EXEC sp_executesql @sql
		End

		--SELECT * FROM #SERVICE_FEE_TOTAL

If @DesktopObject = 1 OR @DesktopObject = 2
 Begin
	SET @sql = ''
	SET @sql_where = ''
	SET @sql_where2 = ''
	if @IncludeClient = 1 and @IncludeDivision = 0 and @IncludeProduct = 0
	Begin
		set @sql = @sql+' SELECT ClientCode, ClientDescription, SUM(FeeAmount) AS FeeAmount,'	
		If @IncludeFeeType = 1
		Begin
			set @sql = @sql+' [ServiceFeeTypeCode],[ServiceFeeTypeDescription],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [ServiceFeeTypeCode],'''' AS [ServiceFeeTypeDescription],'
		End
		If @IncludeCampaign = 1
		Begin
			set @sql = @sql+' [CampaignID],[CampaignCode],[CampaignName],'
		End
		Else
		Begin
			set @sql = @sql+' 0 AS [CampaignID],'''' AS [CampaignCode],'''' AS [CampaignName],'
		End
		If @IncludeJobNumber = 1
		Begin
			set @sql = @sql+' [JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],'
		End
		Else
		Begin
			set @sql = @sql+' 0 AS [JobNumber],'''' AS [JobDescription], CAST(1 AS smallint) AS [ComponentNumber],'''' AS [JobComponent],'''' AS [ComponentDescription],'
		End
		If @IncludeFunctionCode = 1
		Begin
			set @sql = @sql+' [FunctionCode],[FunctionDescription],[FunctionType],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionCode],'''' AS [FunctionDescription],'''' AS [FunctionType],'
		End
		If @IncludeFunctionHeading = 1
		Begin
			set @sql = @sql+' [FunctionHeading],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionHeading],'
		End
		If @IncludeFunctionConsolidation = 1
		Begin
			set @sql = @sql+' [FunctionConsolidation],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionConsolidation],'
		End
		If @IncludeEmployee = 1
		Begin
			set @sql = @sql+' [EmployeeCode],[EmployeeName],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [EmployeeCode],'''' AS [EmployeeName],'
		End
		If @IncludeDate = 1
		Begin
			set @sql = @sql+' [FeeDate],'
		End
		Else
		Begin
			set @sql = @sql+' NULL AS [FeeDate],'
		End
		if @IncludePostPeriod = 1
		Begin
			set @sql = @sql+' [PostPeriodCode],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [PostPeriodCode],'
		End
		set @sql = @sql+' SUM([Hours]) AS [Hours], SUM(Amount) AS Amount, (SUM(FeeAmount) - SUM(Amount)) AS VarianceAmount, SUM(VarianceHours) AS VarianceHours,'''' AS [DivisionCode],'''' AS [DivisionDescription], '''' AS [ProductCode],'''' AS [ProductDescription],'''' AS [Description], '''' AS [SalesClassCode],'''' AS [SalesClassDescription], '''' AS [FeeTimeType],'''' AS [FeeTimeType], '''' AS [Description],'''' AS [Comment],
						SUM(FeeQuantity) AS FeeQuantity,SUM([ReconciledHours]) AS [ReconciledHours],SUM([ReconciledAmount]) AS [ReconciledAmount],SUM([UnreconciledHours]) AS [UnreconciledHours],SUM([UnreconciledAmount]) AS [UnreconciledAmount], 0 AS ID'
		set @sql = @sql+' FROM #SERVICE_FEE_TOTAL ' 
		IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @DesktopObject = 2
		Begin
			set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](10, ''' + @EMP_CODE + ''') AS DR
				ON #SERVICE_FEE_TOTAL.ClientCode COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
				AND ((#SERVICE_FEE_TOTAL.DivisionCode COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
				AND ((#SERVICE_FEE_TOTAL.ProductCode COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'	
		End
		If @RestrictionsOffice > 0
		Begin
			set @sql = @sql+' INNER JOIN DIVISION ON #SERVICE_FEE_TOTAL.ClientCode = DIVISION.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = DIVISION.DIV_CODE INNER JOIN
                           PRODUCT ON #SERVICE_FEE_TOTAL.ClientCode = PRODUCT.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = PRODUCT.DIV_CODE AND #SERVICE_FEE_TOTAL.ProductCode = PRODUCT.PRD_CODE INNER JOIN 
						   EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
		End
		If @CDPRestrictions > 0 and @RestrictionsOffice > 0
		Begin
			set @sql = @sql + ' INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE'
		End
		Else If @CDPRestrictions > 0 and @RestrictionsOffice = 0
		Begin
			set @sql = @sql+' INNER JOIN DIVISION ON #SERVICE_FEE_TOTAL.ClientCode = DIVISION.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = DIVISION.DIV_CODE INNER JOIN
                           PRODUCT ON #SERVICE_FEE_TOTAL.ClientCode = PRODUCT.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = PRODUCT.DIV_CODE AND #SERVICE_FEE_TOTAL.ProductCode = PRODUCT.PRD_CODE
						   INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE'	
		End

		set @sql_where = @sql_where+' WHERE ('	
		
		if @StdIncludeStandard = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Standard Billed'')'
		End
		if @StdIncludeProd = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Production Billed'')'
		End
		Else if @StdIncludeProd = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Production Billed'')'
		End
		if @StdIncludeMedia = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Media Billed'')'
		End
		Else if @StdIncludeMedia = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Media Billed'')'
		End
		if @StdFeeIncludeStandard = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Standard'')'
		End
		Else if @StdFeeIncludeStandard = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Standard'')'
		End
		if @StdFeeIncludeProd = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Production'')'
		End
		Else if @StdFeeIncludeProd = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Production'')'
		End
		if @StdFeeIncludeMedia = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Media'')'
		End
		Else if @StdFeeIncludeMedia = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Media'')'
		End
		If @CDPRestrictions > 0
		Begin
			set @sql_where2 = @sql_where2 + ')  AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
		End
		Else
		Begin
			set @sql_where2 = @sql_where2 + ')'
		End
		if @sql_where2 <> '' AND @sql_where2 <> ')' 
		Begin
			set @sql = @sql+@sql_where+@sql_where2
		End
			
		--if @StdFeeIncludeStandard = 1 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 0
		--Begin
		--	 set @sql = @sql+' AND (FeeTimeType = ''Standard'' OR FeeTimeType = ''Standard Billed'' OR FeeTimeType = ''Media Billed'' OR FeeTimeType = ''Production Billed'')'
		--End
		--if @StdFeeIncludeStandard = 1 and @StdFeeIncludeProd = 1 and @StdFeeIncludeMedia = 0
		--Begin
		--	set @sql = @sql+' AND ((FeeTimeType = ''Standard'' OR FeeTimeType = ''Standard Billed'' OR FeeTimeType = ''Media Billed'') OR (FeeTimeType = ''Production'' OR FeeTimeType = ''Production Billed''))'
		--End
		--if @StdFeeIncludeStandard = 1 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 1
		--Begin
		--	set @sql = @sql+' AND ((FeeTimeType = ''Standard'' OR FeeTimeType = ''Standard Billed'' OR FeeTimeType = ''Production Billed'') OR (FeeTimeType = ''Media'' OR FeeTimeType = ''Media Billed''))'
		--End
		--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 1 and @StdFeeIncludeMedia = 1
		--Begin
		--	set @sql = @sql+' AND ((FeeTimeType = ''Production'' OR FeeTimeType = ''Production Billed'' OR FeeTimeType = ''Standard Billed'') OR (FeeTimeType = ''Media'' OR FeeTimeType = ''Media Billed''))'
		--End	
		--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 1
		--Begin
		--	set @sql = @sql+' AND (FeeTimeType = ''Media'' OR FeeTimeType = ''Media Billed'' OR FeeTimeType = ''Production Billed'' OR FeeTimeType = ''Standard Billed'')'
		--End
		--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 1 and @StdFeeIncludeMedia = 0
		--Begin
		--	set @sql = @sql+' AND (FeeTimeType = ''Production'' OR FeeTimeType = ''Production Billed'' OR FeeTimeType = ''Media Billed'' OR FeeTimeType = ''Standard Billed'')'
		--End
		--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 0
		--Begin
		--	set @sql = @sql+' AND FeeTimeType = ''Production Billed'' OR FeeTimeType = ''Media Billed'' OR FeeTimeType = ''Standard Billed'''
		--End
		set @sql = @sql+' GROUP BY ClientCode, ClientDescription,'
		If @IncludeFeeType = 1
		Begin
			set @sql = @sql+' [ServiceFeeTypeCode],[ServiceFeeTypeDescription],'
		End
		If @IncludeCampaign = 1
		Begin
			set @sql = @sql+' [CampaignID],[CampaignCode],[CampaignName],'
		End
		If @IncludeJobNumber = 1
		Begin
			set @sql = @sql+' [JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],'
		End
		If @IncludeFunctionCode = 1
		Begin
			set @sql = @sql+' [FunctionCode],[FunctionDescription],[FunctionType],'
		End
		If @IncludeFunctionHeading = 1
		Begin
			set @sql = @sql+' [FunctionHeading],'
		End
		If @IncludeFunctionConsolidation = 1
		Begin
			set @sql = @sql+' [FunctionConsolidation],'
		End
		If @IncludeEmployee = 1
		Begin
			set @sql = @sql+' [EmployeeCode],[EmployeeName],'
		End
		If @IncludeDate = 1
		Begin
			set @sql = @sql+' [FeeDate],'
		End
		if @IncludePostPeriod = 1
		Begin
			set @sql = @sql+' [PostPeriodCode],'
		End

	End
	if @IncludeClient = 1 and @IncludeDivision = 1 and @IncludeProduct = 1
	Begin
		set @sql = @sql+'SELECT ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription,'
		If @IncludeFeeType = 1
		Begin
			set @sql = @sql+' [ServiceFeeTypeCode],[ServiceFeeTypeDescription],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [ServiceFeeTypeCode],'''' AS [ServiceFeeTypeDescription],'
		End
		If @IncludeCampaign = 1
		Begin
			set @sql = @sql+' [CampaignID],[CampaignCode],[CampaignName],'
		End
		Else
		Begin
			set @sql = @sql+' 0 AS [CampaignID],'''' AS [CampaignCode],'''' AS [CampaignName],'
		End
		If @IncludeJobNumber = 1
		Begin
			set @sql = @sql+' [JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],'
		End
		Else
		Begin
			set @sql = @sql+' 0 AS [JobNumber],'''' AS [JobDescription], CAST(1 AS smallint) AS [ComponentNumber],'''' AS [JobComponent],'''' AS [ComponentDescription],'
		End
		If @IncludeFunctionCode = 1
		Begin
			set @sql = @sql+' [FunctionCode],[FunctionDescription],[FunctionType],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionCode],'''' AS [FunctionDescription],'''' AS [FunctionType],'
		End
		If @IncludeFunctionHeading = 1
		Begin
			set @sql = @sql+' [FunctionHeading],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionHeading],'
		End
		If @IncludeFunctionConsolidation = 1
		Begin
			set @sql = @sql+' [FunctionConsolidation],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [FunctionConsolidation],'
		End
		If @IncludeEmployee = 1
		Begin
			set @sql = @sql+' [EmployeeCode],[EmployeeName],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [EmployeeCode],'''' AS [EmployeeName],'
		End
		If @IncludeDate = 1
		Begin
			set @sql = @sql+' [FeeDate],'
		End
		Else
		Begin
			set @sql = @sql+' NULL AS [FeeDate],'
		End
		if @IncludePostPeriod = 1
		Begin
			set @sql = @sql+' [PostPeriodCode],'
		End
		Else
		Begin
			set @sql = @sql+' '''' AS [PostPeriodCode],'
		End
		set @sql = @sql+'  SUM(FeeAmount) AS FeeAmount, SUM([Hours]) AS [Hours], SUM(Amount) AS Amount, (SUM(FeeAmount) - SUM(Amount)) AS VarianceAmount, SUM(VarianceHours) AS VarianceHours,'''' AS [DivisionCode],'''' AS [DivisionDescription], '''' AS [ProductCode],'''' AS [ProductDescription],'''' AS [Description], '''' AS [SalesClassCode],'''' AS [SalesClassDescription], '''' AS [FeeTimeType],'''' AS [FeeTimeType], '''' AS [Description],'''' AS [Comment],
						SUM(FeeQuantity) AS FeeQuantity,SUM([ReconciledHours]) AS [ReconciledHours],SUM([ReconciledAmount]) AS [ReconciledAmount],SUM([UnreconciledHours]) AS [UnreconciledHours],SUM([UnreconciledAmount]) AS [UnreconciledAmount], 0 AS ID'
		set @sql = @sql+' FROM #SERVICE_FEE_TOTAL ' 
		IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @DesktopObject = 2
		Begin
			set @sql = @sql+' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](10, ''' + @EMP_CODE + ''') AS DR
				ON #SERVICE_FEE_TOTAL.ClientCode COLLATE SQL_Latin1_General_CP1_CS_AS = DR.CL_CODE 
				AND ((#SERVICE_FEE_TOTAL.DivisionCode COLLATE SQL_Latin1_General_CP1_CS_AS = DR.DIV_CODE)) 
				AND ((#SERVICE_FEE_TOTAL.ProductCode COLLATE SQL_Latin1_General_CP1_CS_AS = DR.PRD_CODE))'		
		End
		If @RestrictionsOffice > 0
		Begin
			set @sql = @sql+' INNER JOIN DIVISION ON #SERVICE_FEE_TOTAL.ClientCode = DIVISION.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = DIVISION.DIV_CODE INNER JOIN
                           PRODUCT ON #SERVICE_FEE_TOTAL.ClientCode = PRODUCT.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = PRODUCT.DIV_CODE AND #SERVICE_FEE_TOTAL.ProductCode = PRODUCT.PRD_CODE INNER JOIN 
						   EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
		End
		If @CDPRestrictions > 0 and @RestrictionsOffice > 0
		Begin
			set @sql = @sql + ' INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = PRODUCT.CL_CODE AND SEC_CLIENT.DIV_CODE = PRODUCT.DIV_CODE AND SEC_CLIENT.PRD_CODE = PRODUCT.PRD_CODE'
		End
		Else If @CDPRestrictions > 0 and @RestrictionsOffice = 0
		Begin
			set @sql = @sql+' INNER JOIN DIVISION ON #SERVICE_FEE_TOTAL.ClientCode = DIVISION.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = DIVISION.DIV_CODE INNER JOIN
                           PRODUCT ON #SERVICE_FEE_TOTAL.ClientCode = PRODUCT.CL_CODE AND #SERVICE_FEE_TOTAL.DivisionCode = PRODUCT.DIV_CODE AND #SERVICE_FEE_TOTAL.ProductCode = PRODUCT.PRD_CODE
						   INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = #SERVICE_FEE_TOTAL.ClientCode AND SEC_CLIENT.DIV_CODE = #SERVICE_FEE_TOTAL.DivisionCode AND SEC_CLIENT.PRD_CODE = #SERVICE_FEE_TOTAL.ProductCode'	
		End
		set @sql_where = @sql_where+' WHERE ('	
		
		if @StdIncludeStandard = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Standard Billed'')'
		End
		if @StdIncludeProd = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Production Billed'')'
		End
		Else if @StdIncludeProd = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Production Billed'')'
		End
		if @StdIncludeMedia = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Media Billed'')'
		End
		Else if @StdIncludeMedia = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Media Billed'')'
		End
		if @StdFeeIncludeStandard = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Standard'')'
		End
		Else if @StdFeeIncludeStandard = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Standard'')'
		End
		if @StdFeeIncludeProd = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Production'')'
		End
		Else if @StdFeeIncludeProd = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Production'')'
		End
		if @StdFeeIncludeMedia = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Media'')'
		End
		Else if @StdFeeIncludeMedia = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Media'')'
		End		
		If @CDPRestrictions > 0
		Begin
			set @sql_where2 = @sql_where2 + ')  AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
		End
		Else
		Begin
			set @sql_where2 = @sql_where2 + ')'
		End
		if @sql_where2 <> '' AND @sql_where2 <> ')' 
		Begin
			set @sql = @sql+@sql_where+@sql_where2
		End
		set @sql = @sql+' GROUP BY ClientCode, ClientDescription, DivisionCode, DivisionDescription, ProductCode, ProductDescription,'
		If @IncludeFeeType = 1
		Begin
			set @sql = @sql+' [ServiceFeeTypeCode],[ServiceFeeTypeDescription],'
		End
		If @IncludeCampaign = 1
		Begin
			set @sql = @sql+' [CampaignID],[CampaignCode],[CampaignName],'
		End
		If @IncludeJobNumber = 1
		Begin
			set @sql = @sql+' [JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],'
		End
		If @IncludeFunctionCode = 1
		Begin
			set @sql = @sql+' [FunctionCode],[FunctionDescription],[FunctionType],'
		End
		If @IncludeFunctionHeading = 1
		Begin
			set @sql = @sql+' [FunctionHeading],'
		End
		If @IncludeFunctionConsolidation = 1
		Begin
			set @sql = @sql+' [FunctionConsolidation],'
		End
		If @IncludeEmployee = 1
		Begin
			set @sql = @sql+' [EmployeeCode],[EmployeeName],'
		End
		If @IncludeDate = 1
		Begin
			set @sql = @sql+' [FeeDate],'
		End
		if @IncludePostPeriod = 1
		Begin
			set @sql = @sql+' [PostPeriodCode],'
		End
	End

	If @sql LIKE '%,'
	Begin
		Set @sql = LEFT(@sql, LEN(@sql)-1)
	End
	
	PRINT @sql
	EXEC sp_executesql @sql
 End
 Else
 Begin
	SET @sql = ''
	SET @sql_where = ''
	SET @sql_where2 = ''
	set @sql = @sql+' SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
			[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
			[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = ''1900-01-01 00:00:00'' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
			[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL'

	set @sql_where = @sql_where+' WHERE'	
		
		if @StdIncludeStandard = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Standard Billed'')'
		End
		if @StdIncludeProd = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Production Billed'')'
		End
		Else if @StdIncludeProd = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Production Billed'')'
		End
		if @StdIncludeMedia = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Media Billed'')'
		End
		Else if @StdIncludeMedia = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Media Billed'')'
		End
		if @StdFeeIncludeStandard = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Standard'')'
		End
		Else if @StdFeeIncludeStandard = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Standard'')'
		End
		if @StdFeeIncludeProd = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Production'')'
		End
		Else if @StdFeeIncludeProd = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Production'')'
		End
		if @StdFeeIncludeMedia = 1 and @sql_where2 <> ''
		Begin
			 set @sql_where2 = @sql_where2+' OR (FeeTimeType = ''Media'')'
		End
		Else if @StdFeeIncludeMedia = 1
		Begin
			 set @sql_where2 = @sql_where2+' (FeeTimeType = ''Media'')'
		End

		if @sql_where2 <> ''
		Begin
			set @sql = @sql+@sql_where+@sql_where2
		End

	PRINT @sql
	EXEC sp_executesql @sql

	--if @StdFeeIncludeStandard = 1 and @StdFeeIncludeProd = 1 and @StdFeeIncludeMedia = 1
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL
	--End
	--if @StdFeeIncludeStandard = 1 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 0
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL WHERE (FeeTimeType = 'Standard' OR FeeTimeType = 'Standard Billed' OR FeeTimeType = 'Media Billed' OR FeeTimeType = 'Production Billed')
	--End
	--if @StdFeeIncludeStandard = 1 and @StdFeeIncludeProd = 1 and @StdFeeIncludeMedia = 0
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL WHERE (FeeTimeType = 'Standard' OR FeeTimeType = 'Standard Billed' OR FeeTimeType = 'Media Billed') OR (FeeTimeType = 'Production' OR FeeTimeType = 'Production Billed')
	--End
	--if @StdFeeIncludeStandard = 1 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 1
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL WHERE (FeeTimeType = 'Standard' OR FeeTimeType = 'Standard Billed' OR FeeTimeType = 'Production Billed') OR (FeeTimeType = 'Media' OR FeeTimeType = 'Media Billed')
	--End
	--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 1 and @StdFeeIncludeMedia = 1
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL WHERE (FeeTimeType = 'Production' OR FeeTimeType = 'Production Billed' OR FeeTimeType = 'Standard Billed') OR (FeeTimeType = 'Media' OR FeeTimeType = 'Media Billed')
	--End	
	--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 1
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL WHERE (FeeTimeType = 'Media' OR FeeTimeType = 'Media Billed' OR FeeTimeType = 'Production Billed' OR FeeTimeType = 'Standard Billed')
	--End
	--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 1 and @StdFeeIncludeMedia = 0
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL WHERE (FeeTimeType = 'Production' OR FeeTimeType = 'Production Billed' OR FeeTimeType = 'Media Billed' OR FeeTimeType = 'Standard Billed')
	--End
	--if @StdFeeIncludeStandard = 0 and @StdFeeIncludeProd = 0 and @StdFeeIncludeMedia = 0
	--Begin
	--	SELECT [ID],[ClientCode],[ClientDescription],[DivisionCode],[DivisionDescription],[ProductCode],[ProductDescription],[CampaignID],[CampaignCode],[CampaignName],[SalesClassCode],[SalesClassDescription],
	--		[JobNumber],[JobDescription],[ComponentNumber],[JobComponent],[ComponentDescription],[FunctionCode],[FunctionDescription],[FunctionType],[ServiceFeeTypeCode],[ServiceFeeTypeDescription],
	--		[FunctionHeading],[FunctionConsolidation],[EmployeeCode],[EmployeeName],[FeeTimeType],CASE WHEN [FeeDate] = '1900-01-01 00:00:00' THEN NULL ELSE [FeeDate] END AS [FeeDate],[Description],[Comment],[PostPeriodCode],[FeeQuantity],[FeeAmount],[ReconciledHours],[ReconciledAmount],
	--		[UnreconciledHours],[UnreconciledAmount],[Hours],[Amount],[VarianceHours],[VarianceAmount] FROM #SERVICE_FEE_TOTAL WHERE FeeTimeType = 'Production Billed' OR FeeTimeType = 'Media Billed' OR FeeTimeType = 'Standard Billed'
	--End
	
 End

		


DROP TABLE #SERVICE_FEE
DROP TABLE #SERVICE_FEE_TOTAL

