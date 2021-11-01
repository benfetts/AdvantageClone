if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetRawData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetRawData]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetRawData]
(
	@EmpCode varchar(6),
	@StartDate SmallDateTime,
	@EndDate SmallDateTime,
	@Month int,
	@Office varchar(4000),
	@AE varchar(4000),
	@Client varchar(4000),	
	@Dept varchar(4000),
	@SalesClass varchar(4000),
	@JobType varchar(4000),
	@Period int,
	@YearValue varchar(2),
	@Level varchar(10),
	@UserID varchar(100),
	@CancelledCode VARCHAR(100),
	@IsCancelled VARCHAR(10),
	@Project varchar(20),
	@Dash varchar(10)
)
AS
Declare @sql nvarchar(4000),
		@paramlist nvarchar(4000), @PPMonth int, @no_of_Days int, @NumberRecords int, @RowCount int, @average decimal(5,2), @comps1 int, @comps2 int, @comps3 int, @comps4 int,
		@ws datetime, @dpname varchar(50),
		@Label varchar(50),
		@Label2 varchar(50),
		@Label3 varchar(50),
		@Label4 varchar(50),
		@Label5 varchar(50),
		@Label6 varchar(50),
		@Label7 varchar(50),
		@Label8 varchar(50),
		@Label9 varchar(50),
		@Label10 varchar(50)

DECLARE @Restrictions INT
DECLARE @OfficeRestrictions INT
DECLARE @EMP_CODE AS VARCHAR(6)

--Check restrictions:
SELECT @Restrictions = COUNT(*) FROM SEC_CLIENT WHERE UPPER([USER_ID]) = UPPER(@UserID)

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

if @Dash = 'Stats'
Begin
	SELECT @Label=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV1'

	SELECT @Label2=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV2'

	SELECT @Label3=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV3'

	SELECT @Label4=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV4'

	SELECT @Label5=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV5'

	SELECT @Label6=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV1'

	SELECT @Label7=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV2'

	SELECT @Label8=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV3' 

	SELECT @Label9=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV4'

	SELECT @Label10=ISNULL(USER_LABEL,'')
	FROM UDV_LABEL
	WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV5'


	SELECT @sql = 'SELECT DASH_DATA_PROJ_HDR.OFFICE_CODE as [Office Code]
      ,OFFICE_NAME as [Office Name]
      ,DASH_DATA_PROJ_HDR.CL_CODE as [Client Code]
      ,CL_NAME as [Client Name]
      ,DASH_DATA_PROJ_HDR.DIV_CODE as [Division Code]
      ,DIV_NAME as [Division Name]
      ,DASH_DATA_PROJ_HDR.PRD_CODE as [Product Code]
      ,PRD_DESCRIPTION as [Product Description]
      ,CMP_CODE as [Campaign Code]
      ,CMP_NAME as [Campaign Name]
      ,CONVERT(char(12),CMP_BEGIN_DATE,101) as [Campaign Begin Date]
      ,CONVERT(char(12),CMP_END_DATE,101) as [Campaign End Date]
      ,CMP_BILL as [Campaign Bill]
      ,CMP_INC as [Campaign Inc]
      ,SC_CODE as [Sales Class Code]
      ,SC_DESCRIPTION as [Sales Class Description]
      ,JOB as [Job Number]
      ,JOB_DESC as [Job Description]
      ,JOB_COMMENTS as [Job Comments]
      ,BILL_COMMENT as [Bill Comment]
      ,JOB_CLI_REF as [Client Reference]'
	  if @Label <> '' 
	  Begin
		SELECT @sql = @sql + ' ,JOB_UDV1_CODE as [' + @Label + ' Code] ,JOB_UDV1_DESC as [' + @Label + ' Desc]'
	  End
	  if @Label2 <> '' 
	  Begin
		SELECT @sql = @sql + ' ,JOB_UDV2_CODE as [' + @Label2 + ' Code] ,JOB_UDV2_DESC as [' + @Label2 + ' Desc]'
	  End
	  if @Label3 <> '' 
	  Begin
		SELECT @sql = @sql + ' ,JOB_UDV3_CODE as [' + @Label3 + ' Code] ,JOB_UDV3_DESC as [' + @Label3 + ' Desc]'
	  End
	  if @Label4 <> '' 
	  Begin
		SELECT @sql = @sql + ' ,JOB_UDV4_CODE as [' + @Label4 + ' Code] ,JOB_UDV4_DESC as [' + @Label4 + ' Desc]'
	  End
	  if @Label5 <> '' 
	  Begin	  
		SELECT @sql = @sql + ' ,JOB_UDV5_CODE as [' + @Label5 + ' Code] ,JOB_UDV5_DESC as [' + @Label5 + ' Desc]'
	  End
	 SELECT @sql = @sql + ' ,JOB_COMPONENT_NBR as [Job Component Nbr]
      ,JOB_COMP_DESC as [Job Comp Desc]
      ,JOB_COMP_DATE as [Job Comp Create Date]
      ,JOB_FIRST_USE_DATE as [Job Due Date]
      ,JOB_COMP_COMMENTS as [Job Comp Comments]
      ,APPR_COMMENT as [Estimate Appr Comment]
      ,ACCT_EXEC as [Account Exec Code]
      ,EMP_LNAME as [AE LName]
      ,EMP_FNAME as [AE FName]
      ,EMP_MI as [AE MI]
      ,CLIENT_PO as [Client PO]
      ,DP_TM_CODE as [Dept Code]
      ,DP_TM_DESC as [Dept Desc]
      ,JOB_TYPE as [Job Type]
      ,JT_DESC as [Job Type Desc]
      ,BUDGET_AMT as [Budget Amt]'	  
	  if @Label6 <> '' 
	  Begin		
		SELECT @sql = @sql + ' ,COMP_UDV1_CODE as [' + @Label6 + ' Code] ,COMP_UDV1_DESC as [' + @Label6 + ' Desc]'
	  End
	  if @Label7 <> '' 
	  Begin
		SELECT @sql = @sql + ' ,COMP_UDV2_CODE as [' + @Label7 + ' Code] ,COMP_UDV2_DESC as [' + @Label7 + ' Desc]'
	  End
	  if @Label8 <> '' 
	  Begin
		SELECT @sql = @sql + ' ,COMP_UDV3_CODE as [' + @Label8 + ' Code] ,COMP_UDV3_DESC as [' + @Label8 + ' Desc]'
	  End
	  if @Label9 <> '' 
	  Begin
		SELECT @sql = @sql + ' ,COMP_UDV4_CODE as [' + @Label9 + ' Code] ,COMP_UDV4_DESC as [' + @Label9 + ' Desc]'
	  End
	  if @Label10 <> '' 
	  Begin
		SELECT @sql = @sql + ' ,COMP_UDV5_CODE as [' + @Label10 + ' Code] ,COMP_UDV5_DESC as [' + @Label10 + ' Desc] '
	  End
	SELECT @sql = @sql + ' ,DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL as [Job Process Control]
	  ,JOB_PROC_CONTROLS.JOB_PROCESS_DESC as [Job Process Desc]
      ,COMPLETED_DATE as [Completed Date] 
		FROM DASH_DATA_PROJ_HDR LEFT OUTER JOIN JOB_PROC_CONTROLS ON JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL = DASH_DATA_PROJ_HDR.JOB_PROCESS_CONTRL'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON DASH_DATA_PROJ_HDR.CL_CODE = SEC_CLIENT.CL_CODE AND DASH_DATA_PROJ_HDR.DIV_CODE = SEC_CLIENT.DIV_CODE AND DASH_DATA_PROJ_HDR.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = DASH_DATA_PROJ_HDR.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
					End
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON DASH_DATA_PROJ_HDR.OFFICE_CODE = o.vstr collate database_default'
					End
				if @Client <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON DASH_DATA_PROJ_HDR.CL_CODE = c.vstr collate database_default'
					End
				if @AE <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON DASH_DATA_PROJ_HDR.ACCT_EXEC = a.vstr collate database_default'
					End
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON DASH_DATA_PROJ_HDR.DP_TM_CODE = d.vstr collate database_default'
					End
				if @SalesClass <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON DASH_DATA_PROJ_HDR.SC_CODE = s.vstr collate database_default'
					End
				if @JobType <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON DASH_DATA_PROJ_HDR.JOB_TYPE = j.vstr collate database_default'
					End
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_HDR.JOB_COMP_DATE >= @StartDate) AND (DASH_DATA_PROJ_HDR.JOB_COMP_DATE <= @EndDate)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
End

if @Dash = 'Client'
Begin
	SELECT @sql = 'SELECT DASH_DATA_PROJ_DTL.JOB_NUMBER as [JOB NUMBER],DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR as [JOB COMPONENT NBR],FNC_TYPE as [FUNCTION TYPE],FNC_CODE as [FUNCTION CODE],FNC_DESC as [FUNCTION DESC]
      ,DATE as [DATE],POST_PERIOD as [POST PERIOD],ITEM_CODE as [ITEM CODE],ITEM_DESC as [ITEM DESC],DETAIL_COMMENT as [DETAIL COMMENT],HOURS_QTY as [HOURS QTY],TOTAL_BILL as [AMOUNT],BILL_AMT as [AMOUNT PLUS MARKUP/DOWN],EXT_MARKUP_AMT as [MARKUP/DOWN AMOUNT]
      ,RESALE_TAX as [RESALE TAX],TOTAL as [TOTAL],AR_POST_PERIOD as [POST PERIOD BILLED],AR_INV_NBR as [AR INV NBR],AR_TYPE as [AR TYPE],GLEXACT_BILL as [GLEXACT BILL],EST_HOURS_QTY as [ESTIMATE HOURS QTY],EST_TOTAL as [ESTIMATE TOTAL]
      ,EST_CONT_AMT as [ESTIMATE CONT AMT],EST_NONRESALE_TAX as [EST NONRESALE TAX],EST_RESALE_TAX as [EXT RESALE TAX],EST_MARKUP_AMT as [ESTIMATE MARKUP AMT],EST_NB_FLAG as [EST NB FLAG],EST_FEE_TIME as [ESTIMATE FEE TIME FLAG]
      ,BILLED_AMT as [BILLED AMT],BILLED_AMT_RESALE as [BILLED AMT RESALE],BILLED_HRS_QTY as [BILLED HRS QTY],FEE_TIME_AMT as [FEE TIME AMT],FEE_TIME_HRS as [FEE TIME HRS]
      ,UNBILLED_AMT as [UNBILLED AMT],UNBILLED_AMT_RESALE as [UNBILLED AMT RESALE],UNBILLED_HRS_QTY as [UNBILLED HRS QTY],NB_AMT as [NB AMT],NB_QTY as [NB QTY],NEW_BIZ as [NEW BIZ FLAG],AGENCY as [AGENCY FLAG]
	   FROM DASH_DATA_PROJ_DTL INNER JOIN
						 JOB_COMPONENT ON JOB_COMPONENT.JOB_NUMBER = DASH_DATA_PROJ_DTL.JOB_NUMBER AND 
						 JOB_COMPONENT.JOB_COMPONENT_NBR = DASH_DATA_PROJ_DTL.JOB_COMPONENT_NBR INNER JOIN
						 JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeRestrictions > 0
					Begin
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
					End
				if @Office <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Office, DEFAULT) o ON JOB_LOG.OFFICE_CODE = o.vstr collate database_default'
					End
				if @Client <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Client, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
					End
				if @AE <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AE, DEFAULT) a ON JOB_COMPONENT.EMP_CODE = a.vstr collate database_default'
					End
				if @Dept <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@Dept, DEFAULT) d ON JOB_COMPONENT.DP_TM_CODE = d.vstr collate database_default'
					End
				if @SalesClass <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@SalesClass, DEFAULT) s ON JOB_LOG.SC_CODE = s.vstr collate database_default'
					End
				if @JobType <> ''
					Begin
						SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@JobType, DEFAULT) j ON JOB_COMPONENT.JT_DESC = j.vstr collate database_default'
					End
		SELECT @sql = @sql + ' WHERE (DASH_DATA_PROJ_DTL.DATE >= @StartDate) AND (DASH_DATA_PROJ_DTL.DATE <= @EndDate)'
				IF @Restrictions > 0
					Begin
						SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
		SELECT @paramlist = '@StartDate SmallDatetime, @EndDate SmallDatetime, @Dept varchar(4000), @Office varchar(4000), @Month int, @Level varchar(10), @UserID varchar(100), @EMP_CODE AS VARCHAR(6), @Client varchar(4000), @AE varchar(4000), @SalesClass varchar(4000), @JobType varchar(4000)'
		print @sql
		EXEC sp_executesql @sql, @paramlist, @StartDate, @EndDate, @Dept, @Office, @Month, @Level, @UserID, @EMP_CODE, @Client, @AE, @SalesClass, @JobType
End






GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

