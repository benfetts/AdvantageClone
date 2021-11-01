







CREATE PROCEDURE [dbo].[usp_wv_reports_traffic_schedule_sa_getRoles]
@ClientCode as VarChar(4000),
@Task1 as VarChar(40),
@Task2 as VarChar(40),
@Task3 as VarChar(40),
@Task4 as VarChar(40),
@Task5 as VarChar(40),
@Task6 as VarChar(40),
@Task7 as VarChar(40),
@Task8 as VarChar(40),
@Task9 as VarChar(40),
@Task10 as VarChar(40),
@Task11 as VarChar(40),
@Task12 as VarChar(40),
@Task13 as VarChar(40),
@Task14 as VarChar(40),
@Task15 as VarChar(40),
@Task16 as VarChar(40),
@Task17 as VarChar(40),
@Task18 as VarChar(40),
@Task19 as VarChar(40),
@Task20 as VarChar(40),
@Task21 as VarChar(40),
@Task22 as VarChar(40),
@Task23 as VarChar(40),
@Task24 as VarChar(40),
@Task25 as VarChar(40),
@Task26 as VarChar(40),
@Task27 as VarChar(40),
@Task28 as VarChar(40),
@Task29 as VarChar(40),
@Task30 as VarChar(40),
@ClosedJobs as Char(1), 
@CompletedDates as Char(1),
@OnlyProjected as Char(1),
@OfficeCode VarChar(4000),
@StatusCodes VarChar(4000),
@DueDate Char(1),
@OriginalDueDate as Char(1),
@OrigDueDateCompDate as Char(1),
@DueDateCompDate as Char(1),
@EmpCode as Char(1),
@Sort1 as Varchar(100),
@Sort2 as Varchar(100),
@ForJobDueDate as Char(1),
@ForJobStartDate as Datetime,
@ForJobEndDate as Datetime,
@IncludeClosedStartDate DateTime,
@IncludeClosedEndDate DateTime,
@Manager as Varchar(6),
@DueTime Char(1),
@AEs as varchar(4000),
@UserID varchar(100),
@RlCodes as varchar(4000),
@CP int,
@CPID int
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@sql2 nvarchar(4000),
		@sql3 nvarchar(4000),
		@sql4 nvarchar(4000),
		@paramlist nvarchar(4000),
		@paramlist2 nvarchar(4000),
		@paramlist3 nvarchar(4000), @RestrictionsCP Int
-- ************* Create Temp Table ***********************
CREATE TABLE #report( 
    Manager         VarChar(100),	
	ProjectStartDate		Datetime,
	JobDueDate		Datetime, 
	JobStatus		VarChar(40),
	StatusCode		VarChar(11),
	ClientCode		VarChar(6),
	ClientName		VarChar(100),
	DivisionCode		VarChar(6),
	DivisionName		VarChar(100),
	ProductCode		VarChar(6),
	ProductName		VarChar(100),
	JobNumber		int NULL,
	JobDescription		VarChar(100),
	JobCompNumber		smallint Null, 
	JobCompDescription	VarChar(100),
	DateTitles		Varchar(100),
	Task1			VarChar(100),
	Task2			VarChar(100),
	Task3			VarChar(100),
	Task4			VarChar(100),
	Task5			VarChar(100),
	Task6			VarChar(100),
	Task7			VarChar(100),
	Task8			VarChar(100),
	Task9			VarChar(100),
	Task10			VarChar(100),
	Task11			VarChar(100),
	Task12			VarChar(100),
	Task13			VarChar(100),
	Task14			VarChar(100),
	Task15			VarChar(100),
	Task16			VarChar(100),
	Task17			VarChar(100),
	Task18			VarChar(100),
	Task19			VarChar(100),
	Task20			VarChar(100),
	Task21			VarChar(100),
	Task22			VarChar(100),
	Task23			VarChar(100),
	Task24			VarChar(100),
	Task25			VarChar(100),
	Task26			VarChar(100),
	Task27			VarChar(100),
	Task28			VarChar(100),
	Task29			VarChar(100),
	Task30			VarChar(100),
	TRFComments		Text,
	OnlyProjected		VarChar(5),
	AccExecutive    VarChar(100),
	JobType			VarChar(10),	
	JobTypeDesc		VarChar(30),
	ClientRef		VarChar(30),
	JobCompletedDate datetime,
	Rush			VarChar(10),
	JobMarkup		Decimal(15,3),
	JobNonBillFlag	VarChar(10)
--	SeqNbr			SmallInt,
--	FunctionCode	VarChar(10),
--	TaskStartDate	SmallDateTime,
--	TaskJobDueDate  SmallDateTime,
--	TaskJobRevDate	SmallDateTime,
--	TaskJobCompDate SmallDateTime,
--	TaskDueTime		Varchar(10),
--	TaskEmpCode     sql_variant
	) 

	SELECT @Restrictions = COUNT(*)
	FROM   SEC_CLIENT WITH(NOLOCK)
	WHERE  UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)

	Select @RestrictionsCP = Count(*) 
	FROM CP_SEC_CLIENT
	Where CDP_CONTACT_ID = @CPID;

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER

SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE

if @CP = 1
Begin

		-- ******   List of Clients *************
		If @ClosedJobs = 'Y'
			Begin 
			-- ************ Include Closed Jobs ****************
					
				SELECT @sql2 = 'Insert Into #report
				SELECT 
				    ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME, 
					JOB_COMPONENT.START_DATE,
					JOB_COMPONENT.JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_DESCRIPTION,
					TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
				NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, NULL,NULL,
					''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG
				FROM JOB_LOG
				INNER JOIN CLIENT
					ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION
					ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
					AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT
					ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
					AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
					AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT
					ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS 
					ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				INNER JOIN JOB_TRAFFIC
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				LEFT OUTER JOIN V_JOB_TRAFFIC_DET
					ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
							INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		         LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		         LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE INNER JOIN EMP_TRAFFIC_ROLE ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
						-- ****************** Check For List of Clients
					    If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@ClientCode, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						-- ******************* Check For List of Offices
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End	
						if @RlCodes<>'%' 
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@RlCodes, DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
							End						
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
						End	
			    
				SELECT @sql2 = @sql2 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
				        if @Manager <> 'All'
							Begin
								SELECT @sql2 = @sql2 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = @Manager '
							End			
				
				 SELECT @sql2 = @sql2 + ' AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql2 = @sql2 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= @IncludeClosedStartDate AND JOB_TRAFFIC.COMPLETED_DATE <= @IncludeClosedEndDate))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql2 = @sql2 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= @ForJobStartDate AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= @ForJobEndDate'
							End						
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql2 = @sql2 + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)'
						End			
						
					SELECT @sql2 = @sql2 + ' Group By    JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
					JOB_COMPONENT.START_DATE,
					JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_CODE,
					TRAFFIC.TRF_DESCRIPTION,
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME, 
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG, JOB_TRAFFIC.MGR_EMP_CODE'

					SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @IncludeClosedStartDate DateTime, @IncludeClosedEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000), @CPID int, @RlCodes as varchar(4000)'

					EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @IncludeClosedStartDate, @IncludeClosedEndDate, @ClientCode, @OfficeCode, @Manager, @AEs, @CPID, @RlCodes
						
					PRINT @sql2
			End
		Else
			Begin		
				-- ************ Exclude Closed Jobs ****************
				SELECT @sql2 = 'Insert Into #report
					SELECT 
				    ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME,    
					JOB_COMPONENT.START_DATE,
					JOB_COMPONENT.JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_DESCRIPTION,
					TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
				NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, NULL,NULL,
					''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG
				FROM JOB_LOG
				INNER JOIN CLIENT
					ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION
					ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
					AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT
					ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
					AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
					AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT
					ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS 
					ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				LEFT OUTER JOIN V_JOB_TRAFFIC_DET
					ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
				INNER JOIN JOB_TRAFFIC
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
							INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
		        LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		        LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE INNER JOIN EMP_TRAFFIC_ROLE ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
						If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@ClientCode, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End			
						if @RlCodes<>'%' 
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@RlCodes, DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
							End					
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
						End	
			    
				SELECT @sql2 = @sql2 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) 
				AND JOB_TRAFFIC.COMPLETED_DATE IS NULL'
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql2 = @sql2 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= @ForJobStartDate AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= @ForJobEndDate'
							End
						if @Manager <> 'All'
							Begin
								SELECT @sql2 = @sql2 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = @Manager '
							End						
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql2 = @sql2 + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)'
						End		
					SELECT @sql2 = @sql2 + ' Group By JOB_TRAFFIC.MGR_EMP_CODE, JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
					JOB_COMPONENT.START_DATE,
					JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_CODE,
					TRAFFIC.TRF_DESCRIPTION,
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG'

					SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000), @CPID int, @RlCodes as varchar(4000)'

					EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @ClientCode, @OfficeCode, @Manager, @AEs, @CPID, @RlCodes
						
					PRINT @sql2
			End
End
Else
Begin

		-- ******   List of Clients *************
		If @ClosedJobs = 'Y'
			Begin 
			-- ************ Include Closed Jobs ****************
					
				SELECT @sql2 = 'Insert Into #report
				SELECT 
				    ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME, 
					JOB_COMPONENT.START_DATE,
					JOB_COMPONENT.JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_DESCRIPTION,
					TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
				NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, NULL,NULL,
					''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG
				FROM JOB_LOG
				INNER JOIN CLIENT
					ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION
					ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
					AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT
					ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
					AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
					AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT
					ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS 
					ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				INNER JOIN JOB_TRAFFIC
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				LEFT OUTER JOIN V_JOB_TRAFFIC_DET
					ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
							INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		         LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		         LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE INNER JOIN EMP_TRAFFIC_ROLE ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
						-- ****************** Check For List of Clients
					    If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@ClientCode, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						-- ******************* Check For List of Offices
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End	
						if @RlCodes<>'%' 
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@RlCodes, DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
							End						
					IF @Restrictions > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End		
					If @RestrictionsOffice > 0
						Begin
							SELECT @sql2 = @sql2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
						End
			    
				SELECT @sql2 = @sql2 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
				        if @Manager <> 'All'
							Begin
								SELECT @sql2 = @sql2 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = @Manager '
							End			
				
				 SELECT @sql2 = @sql2 + ' AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql2 = @sql2 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= @IncludeClosedStartDate AND JOB_TRAFFIC.COMPLETED_DATE <= @IncludeClosedEndDate))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql2 = @sql2 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= @ForJobStartDate AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= @ForJobEndDate'
							End						
					IF @Restrictions > 0
						Begin
							SELECT @sql2 = @sql2 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End			
						
					SELECT @sql2 = @sql2 + ' Group By    JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
					JOB_COMPONENT.START_DATE,
					JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_CODE,
					TRAFFIC.TRF_DESCRIPTION,
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME, 
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG, JOB_TRAFFIC.MGR_EMP_CODE'

					SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @IncludeClosedStartDate DateTime, @IncludeClosedEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000), @UserID varchar(100), @RlCodes as varchar(4000)'

					EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @IncludeClosedStartDate, @IncludeClosedEndDate, @ClientCode, @OfficeCode, @Manager, @AEs, @UserID, @RlCodes
						
					PRINT @sql2
			End
		Else
			Begin		
				-- ************ Exclude Closed Jobs ****************
				SELECT @sql2 = 'Insert Into #report
					SELECT 
				    ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME,    
					JOB_COMPONENT.START_DATE,
					JOB_COMPONENT.JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_DESCRIPTION,
					TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
				NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL, NULL,NULL,
					''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG
				FROM JOB_LOG
				INNER JOIN CLIENT
					ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION
					ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
					AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT
					ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
					AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
					AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT
					ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS 
					ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				LEFT OUTER JOIN V_JOB_TRAFFIC_DET
					ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
				INNER JOIN JOB_TRAFFIC
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
							INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE
		        LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		        LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE INNER JOIN EMP_TRAFFIC_ROLE ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
						If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@ClientCode, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End			
						if @RlCodes<>'%' 
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@RlCodes, DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
							End					
					IF @Restrictions > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End		
					If @RestrictionsOffice > 0
						Begin
							SELECT @sql2 = @sql2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
						End
			    
				SELECT @sql2 = @sql2 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) 
				AND JOB_TRAFFIC.COMPLETED_DATE IS NULL'
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql2 = @sql2 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= @ForJobStartDate AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= @ForJobEndDate'
							End
						if @Manager <> 'All'
							Begin
								SELECT @sql2 = @sql2 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = @Manager '
							End						
					IF @Restrictions > 0
						Begin
							SELECT @sql2 = @sql2 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End		
					SELECT @sql2 = @sql2 + ' Group By JOB_TRAFFIC.MGR_EMP_CODE, JOB_LOG.CL_CODE,
					CLIENT.CL_NAME,
					JOB_LOG.DIV_CODE,
					DIVISION.DIV_NAME,
					JOB_LOG.PRD_CODE,
					PRODUCT.PRD_DESCRIPTION,
					JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_COMPONENT.JOB_COMPONENT_NBR,
					JOB_COMPONENT.JOB_COMP_DESC,
					JOB_COMPONENT.START_DATE,
					JOB_FIRST_USE_DATE,
					TRAFFIC.TRF_CODE,
					TRAFFIC.TRF_DESCRIPTION,
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG'

					SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000), @UserID varchar(100), @RlCodes as varchar(4000)'

					EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @ClientCode, @OfficeCode, @Manager, @AEs, @UserID, @RlCodes
						
					PRINT @sql2
			End
End


Update #report
Set  TRFComments = JOB_TRAFFIC.TRF_COMMENTS
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR

	
--don't filter
if @StatusCodes<>''
begin
 SELECT @sql = 'Select Manager,
    ProjectStartDate as [Job Start Date],
	JobDueDate as [Job Due Date1],
	JobCompletedDate as [Job Completed Date],
	ClientCode as [Client Code],
	ClientName as [Client],
	DivisionCode as [Division Code],
	DivisionName as [Division],
	ProductCode as [Product Code],
	ProductName as [Product],
	JobNumber as [Job Number],
	JobDescription as [Job],
	JobCompNumber as [Comp Number],
	JobCompDescription as [Component],
	ClientRef as [Client Reference],
	AccExecutive as [Account Executive],
	JobType as [Job Type],	
	JobTypeDesc as [Job Type Description],
	Rush,
	JobMarkup as [Job Markup],
	JobNonBillFlag as [Job Non Bill Flag],
	JobDueDate as [Job Due Date2],
	LEFT( JobStatus, 20 ) as [Job Status],
	DateTitles,
	Task1,
	Task2,			
	Task3,			
	Task4,			
	Task5,			
	Task6,			
	Task7,			
	Task8,			
	Task9,		
	Task10,			
	Task11,			
	Task12,			
	Task13,			
	Task14,			
	Task15,			
	Task16,			
	Task17,			
	Task18,			
	Task19,			
	Task20,			
	Task21,			
	Task22,			
	Task23,			
	Task24,			
	Task25,			
	Task26,			
	Task27,			
	Task28,			
	Task29,			
	Task30,
	TRFComments as [Traffic Comments]
	
   from #report
	
   JOIN charlist_to_table_tsa(@StatusCodes, DEFAULT) c ON #report.StatusCode = c.vstr collate database_default
   '--order by ' + @Sort1 + ',' + @Sort2
   
   SELECT @paramlist = '@Sort1 varchar(100), @Sort2 varchar(100), @StatusCodes varchar(4000)'

	EXEC sp_executesql @sql, @paramlist, @Sort1, @Sort2, @StatusCodes 
	
	PRINT @sql
end
else
begin
	SELECT @sql = 'Select Manager,
	ProjectStartDate as [Job Start Date],
	JobDueDate as [Job Due Date1],
	JobCompletedDate as [Job Completed Date],
	ClientCode as [Client Code],
	ClientName as [Client],
	DivisionCode as [Division Code],
	DivisionName as [Division],
	ProductCode as [Product Code],
	ProductName as [Product],
	JobNumber as [Job Number],
	JobDescription as [Job],
	JobCompNumber as [Comp Number],
	JobCompDescription as [Component],
	ClientRef as [Client Reference],
	AccExecutive as [Account Executive],
	JobType as [Job Type],	
	JobTypeDesc as [Job Type Description],
	Rush,
	JobMarkup as [Job Markup],
	JobNonBillFlag as [Job Non Bill Flag],
	JobDueDate as [Job Due Date2],
	LEFT( JobStatus, 20 ) as [Job Status],
	DateTitles,
	Task1,
	Task2,			
	Task3,			
	Task4,			
	Task5,			
	Task6,			
	Task7,			
	Task8,			
	Task9,		
	Task10,			
	Task11,			
	Task12,			
	Task13,			
	Task14,			
	Task15,			
	Task16,			
	Task17,			
	Task18,			
	Task19,			
	Task20,			
	Task21,			
	Task22,			
	Task23,			
	Task24,			
	Task25,			
	Task26,			
	Task27,			
	Task28,			
	Task29,			
	Task30,
	TRFComments as [Traffic Comments]
	
   from #report
   '--ORDER BY ' + @Sort1 + ',' + @Sort2
						

    SELECT @paramlist = '@Sort1 varchar(100), @Sort2 varchar(100)'

    EXEC sp_executesql @sql, @paramlist, @Sort1, @Sort2 
    	
    PRINT @sql 
end

if @CP = 1
Begin
If @ClosedJobs = 'Y'
	Begin 
		SELECT @sql3 = 'SELECT   ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + EM.EMP_FNAME + '' '' + ISNULL(EM.EMP_MI, '''') + '' '' + EM.EMP_LNAME AS Manager, 
                      JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE, JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, 
                      JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI, '''') + '' '' + EMPLOYEE.EMP_LNAME AS AE, 
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH, JOB_COMPONENT.JOB_MARKUP_PCT, 
                      CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.JOB_DUE_DATE, 
                      JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, E.EMP_CODE, dbo.udf_get_empl_name(E.EMP_CODE, ''FML'') AS EMP_NAME,
					  JOB_TRAFFIC_DET.TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, ''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE, TRAFFIC_ROLE.ROLE_DESC, JOB_TRAFFIC.TRF_COMMENTS
FROM         JOB_TRAFFIC INNER JOIN
                      JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
                      JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN JOB_TRAFFIC_DET_EMPS AS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN
                      EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE LEFT OUTER JOIN EMPLOYEE AS EM ON JOB_TRAFFIC.MGR_EMP_CODE = EM.EMP_CODE LEFT OUTER JOIN
                      TRAFFIC_ROLE ON EMP_TRAFFIC_ROLE.ROLE_CODE = TRAFFIC_ROLE.ROLE_CODE INNER JOIN #report ON JOB_TRAFFIC_DET.JOB_NUMBER = #report.JobNumber AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = #report.JobCompNumber'
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) c ON #report.StatusCode = c.vstr collate database_default'
							  End	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
								End	      
				 SELECT @sql3 = @sql3 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql3 = @sql3 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= ''' + CAST(@IncludeClosedStartDate AS Varchar(12)) + ''' AND JOB_TRAFFIC.COMPLETED_DATE <= ''' + CAST(@IncludeClosedEndDate AS Varchar(12)) + '''))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
							End  
							  
				SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IN (''' + @Task1 + ''',''' + @Task2 + ''',''' + @Task3 + ''',''' + @Task4 + ''',''' + @Task5 + ''',''' + @Task6 + ''',''' + @Task7 + ''',''' + @Task8 + ''',''' + @Task9 + ''',''' + @Task10 + ''',''' + @Task11 + ''',''' + @Task12 + ''',''' + @Task13 + ''',
							''' + @Task14 + ''',''' + @Task15 + ''',''' + @Task16 + ''',''' + @Task17 + ''',''' + @Task18 + ''',''' + @Task19 + ''',''' + @Task20 + ''',''' + @Task21 + ''',''' + @Task22 + ''',''' + @Task23 + ''',''' + @Task24 + ''',''' + @Task25 + ''',''' + @Task26 + ''',''' + @Task27 + ''',''' + @Task28 + ''',''' + @Task29 + ''',''' + @Task30 + '''))'
							
			    SELECT @sql4 = @sql4 + ' UNION
                                        SELECT JOB_TRAFFIC.JOB_NUMBER, JOB_TRAFFIC.JOB_COMPONENT_NBR, ISNULL(JOB_TRAFFIC_DET.SEQ_NBR,'''') AS SEQ_NBR, 
                                                              ISNULL(JOB_TRAFFIC_DET.FNC_CODE,'''') AS FNC_CODE, ISNULL(JOB_TRAFFIC_DET.TASK_START_DATE,'''') AS TASK_START_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_DUE_DATE,'''') AS JOB_DUE_DATE, 
                                                              ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE,'''') AS JOB_REVISED_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,'''') AS JOB_COMPLETED_DATE, ISNULL(E.EMP_CODE,'''') AS EMP_CODE, 
                                                              ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE,'''') AS TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME,''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE
		                                        FROM         JOB_TRAFFIC LEFT OUTER JOIN
							                                          JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
							                                          JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                                                                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN 
																	  JOB_TRAFFIC_DET_EMPS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND
																		E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND 
																		E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
						      If @ClientCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) f ON JOB_LOG.CL_CODE = f.vstr collate database_default'
							    End
						      if @OfficeCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							    End
							    
							  if @AEs <> '%'
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
								End
							    
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) e ON JOB_TRAFFIC.TRF_CODE = e.vstr collate database_default'
							  End  	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) h ON EMP_TRAFFIC_ROLE.ROLE_CODE = h.vstr collate database_default'
								End	  						
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql4 = @sql4 + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
						End	    
				 SELECT @sql4 = @sql4 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND (JOB_TRAFFIC_DET.SEQ_NBR IS NULL) AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL) '
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql4 = @sql4 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= ''' + CAST(@IncludeClosedStartDate AS Varchar(12)) + ''' AND JOB_TRAFFIC.COMPLETED_DATE <= ''' + CAST(@IncludeClosedEndDate AS Varchar(12)) + '''))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql4 = @sql4 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
							End  
					   if @Manager <> 'All'
							Begin
								    SELECT @sql4 = @sql4 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							End	
					 IF @RestrictionsCP > 0
						Begin
							SELECT @sql4 = @sql4 + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = ''' + CAST(@CPID AS VARCHAR(6)) + ''')'
						End		                                          
							                                          
			  	SELECT @sql3 = @sql3 + ' ORDER BY'-- EMP_TRAFFIC_ROLE.ROLE_CODE, E.EMP_CODE, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'	
			  		
					if @Sort1 = 'EmpRole'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE ASC,'
						End
					if @Sort1 = 'EmpRole DESC'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE DESC,'
						End
					
					if @Sort2 = 'Employee'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE ASC, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
					if @Sort2 = 'Employee DESC'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE DESC, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
			  	

					EXEC (@sql3 + @sql4)						
					
						
					--PRINT @sql3
					PRINT @sql4
	End
else
	Begin 
		SELECT @sql3 = 'SELECT   ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + EM.EMP_FNAME + '' '' + ISNULL(EM.EMP_MI, '''') + '' '' + EM.EMP_LNAME AS Manager, JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE, 
                      JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, 
                      ''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI, '''') + '' '' + EMPLOYEE.EMP_LNAME AS AE, JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, 
                      CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH, JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG, JOB_TRAFFIC_DET.SEQ_NBR, 
                      JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, E.EMP_CODE, dbo.udf_get_empl_name(E.EMP_CODE, ''FML'') AS EMP_NAME,
					  JOB_TRAFFIC_DET.TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, ''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE, TRAFFIC_ROLE.ROLE_DESC, JOB_TRAFFIC.TRF_COMMENTS
FROM         JOB_TRAFFIC INNER JOIN
                      JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
                      JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN JOB_TRAFFIC_DET_EMPS AS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN
                      EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
                      JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE LEFT OUTER JOIN EMPLOYEE AS EM ON JOB_TRAFFIC.MGR_EMP_CODE = EM.EMP_CODE LEFT OUTER JOIN TRAFFIC_ROLE ON EMP_TRAFFIC_ROLE.ROLE_CODE = TRAFFIC_ROLE.ROLE_CODE INNER JOIN #report ON JOB_TRAFFIC_DET.JOB_NUMBER = #report.JobNumber AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = #report.JobCompNumber '
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) c ON #report.StatusCode = c.vstr collate database_default'
							  End  	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
								End	 
							  
					SELECT @sql3 = @sql3 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)'						
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
							End		
			  SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IN (''' + @Task1 + ''',''' + @Task2 + ''',''' + @Task3 + ''',''' + @Task4 + ''',''' + @Task5 + ''',''' + @Task6 + ''',''' + @Task7 + ''',''' + @Task8 + ''',''' + @Task9 + ''',''' + @Task10 + ''',''' + @Task11 + ''',''' + @Task12 + ''',''' + @Task13 + ''',
							''' + @Task14 + ''',''' + @Task15 + ''',''' + @Task16 + ''',''' + @Task17 + ''',''' + @Task18 + ''',''' + @Task19 + ''',''' + @Task20 + ''',''' + @Task21 + ''',''' + @Task22 + ''',''' + @Task23 + ''',''' + @Task24 + ''',''' + @Task25 + ''',''' + @Task26 + ''',''' + @Task27 + ''',''' + @Task28 + ''',''' + @Task29 + ''',''' + @Task30 + '''))'
			  SELECT @sql4 = @sql4 + ' UNION
                                        SELECT JOB_TRAFFIC.JOB_NUMBER, JOB_TRAFFIC.JOB_COMPONENT_NBR, ISNULL(JOB_TRAFFIC_DET.SEQ_NBR,'''') AS SEQ_NBR, 
                                                              ISNULL(JOB_TRAFFIC_DET.FNC_CODE,'''') AS FNC_CODE, ISNULL(JOB_TRAFFIC_DET.TASK_START_DATE,'''') AS TASK_START_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_DUE_DATE,'''') AS JOB_DUE_DATE, 
                                                              ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE,'''') AS JOB_REVISED_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,'''') AS JOB_COMPLETED_DATE, ISNULL(E.EMP_CODE,'''') AS EMP_CODE, 
                                                              ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE,'''') AS TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME,''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE
		                                        FROM         JOB_TRAFFIC LEFT OUTER JOIN
							                                          JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
							                                          JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                                                                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN 
																	  JOB_TRAFFIC_DET_EMPS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND
																		E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND 
																		E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
                            
						      If @ClientCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) f ON JOB_LOG.CL_CODE = f.vstr collate database_default'
							    End
						      if @OfficeCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							    End
							    
							  if @AEs <> '%'
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
								End
							    
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) e ON JOB_TRAFFIC.TRF_CODE = e.vstr collate database_default'
							  End	  	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) h ON EMP_TRAFFIC_ROLE.ROLE_CODE = h.vstr collate database_default'
								End	 					
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql4 = @sql4 + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
						End	
							  
								SELECT @sql4 = @sql4 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC_DET.SEQ_NBR IS NULL)'						
									if @ForJobDueDate = 'Y'
										Begin
											if @ForJobStartDate <> '' and @ForJobEndDate <> ''
												SELECT @sql4 = @sql4 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
										End		
							        if @Manager <> 'All'
							            Begin
								            SELECT @sql4 = @sql4 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							            End     
									IF @RestrictionsCP > 0
										Begin
											SELECT @sql4 = @sql4 + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = ''' + CAST(@CPID AS VARCHAR(6)) + ''')'
										End			                             
			  SELECT @sql3 = @sql3 + ' ORDER BY'-- EMP_TRAFFIC_ROLE.ROLE_CODE, E.EMP_CODE, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'                                	
			  		if @Sort1 = 'Manager'
						Begin
							SELECT @sql3 = @sql3 + ' Manager,'
						End
					if @Sort1 = 'ProjectStartDate'
						Begin
							SELECT @sql3 = @sql3 + ' START_DATE,'
						End
					if @Sort1 = 'JobDueDate'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_FIRST_USE_DATE,'
						End
					if @Sort1 = 'ClientCode'
						Begin
							SELECT @sql3 = @sql3 + ' CL_CODE,'
						End
					if @Sort1 = 'ClientName'
						Begin
							SELECT @sql3 = @sql3 + ' CL_NAME,'
						End
					if @Sort1 = 'DivisionCode'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_CODE,'
						End
					if @Sort1 = 'DivisionName'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_NAME,'
						End
					if @Sort1 = 'ProductCode'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_CODE,'
						End
					if @Sort1 = 'ProductName'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_DESCRIPTION,'
						End
					if @Sort1 = 'JobNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_NUMBER,'
						End
					if @Sort1 = 'JobDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_DESC,'
						End
					if @Sort1 = 'JobCompNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMPONENT_NBR,'
						End
					if @Sort1 = 'JobCompDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMP_DESC,'
						End
					if @Sort1 = 'JobStatus'
						Begin
							SELECT @sql3 = @sql3 + ' TRF_DESCRIPTION,'
						End
					if @Sort1 = 'EmpRole'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE,'
						End
					if @Sort1 = 'EmpRole DESC'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE DESC,'
						End

					if @Sort2 = 'Manager'
						Begin
							SELECT @sql3 = @sql3 + ' Manager'
						End
					if @Sort2 = 'ProjectStartDate'
						Begin
							SELECT @sql3 = @sql3 + ' START_DATE'
						End
					if @Sort2 = 'JobDueDate'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_FIRST_USE_DATE'
						End
					if @Sort2 = 'ClientCode'
						Begin
							SELECT @sql3 = @sql3 + ' CL_CODE'
						End
					if @Sort2 = 'ClientName'
						Begin
							SELECT @sql3 = @sql3 + ' CL_NAME'
						End
					if @Sort2 = 'DivisionCode'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_CODE'
						End
					if @Sort2 = 'DivisionName'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_NAME'
						End
					if @Sort2 = 'ProductCode'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_CODE'
						End
					if @Sort2 = 'ProductName'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_DESCRIPTION'
						End
					if @Sort2 = 'JobNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_NUMBER'
						End
					if @Sort2 = 'JobDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_DESC'
						End
					if @Sort2 = 'JobCompNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMPONENT_NBR'
						End
					if @Sort2 = 'JobCompDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMP_DESC'
						End
					if @Sort2 = 'JobStatus'
						Begin
							SELECT @sql3 = @sql3 + ' TRF_DESCRIPTION'
						End
					if @Sort2 = 'Employee'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
					if @Sort2 = 'Employee DESC'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE DESC, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
							                                          
			  		
			  --SELECT @paramlist3 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime,
			  	--					  @Task1 Varchar(40),@Task2 Varchar(40),@Task3 Varchar(40),@Task4 Varchar(40),@Task5 Varchar(40),@Task6 Varchar(40),@Task7 Varchar(40),@Task8 Varchar(40),
			  	--					  @Task9 Varchar(40),@Task10 Varchar(40),@Task11 Varchar(40),@Task12 Varchar(40),@Task13 Varchar(40),@Task14 Varchar(40),@Task15 Varchar(40),@Task16 Varchar(40),
			  	--					  @Task17 Varchar(40),@Task18 Varchar(40),@Task19 Varchar(40),@Task20 Varchar(40),@Task21 Varchar(40),@Task22 Varchar(40),@Task23 Varchar(40),@Task24 Varchar(40),
			  		--				  @Task25 Varchar(40),@Task26 Varchar(40),@Task27 Varchar(40),@Task28 Varchar(40),@Task29 Varchar(40),@Task30 Varchar(40),@StatusCodes varchar(4000), 
			  		--				  @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6)'
			  						  
			  		--SELECT @sql3 = @sql3 + @sql4
	
					EXEC (@sql3 + @sql4)
			  						  
			  		---EXEC sp_executesql @sql3, @paramlist3, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate,@Task1,@Task2,@Task3,@Task4,@Task5,
					--			       @Task6,@Task7,@Task8,@Task9,@Task10,@Task11,@Task12,@Task13,@Task14,@Task15,@Task16,@Task17,@Task18,@Task19,@Task20,@Task21,@Task22,@Task23,@Task24,
					--			       @Task25,@Task26,@Task27,@Task28,@Task29,@Task30,@StatusCodes, @ClientCode, @OfficeCode, @Manager
						
					--
				PRINT @sql4	
	End
	PRINT @sql3
    --PRINT @sql4
End
Else
Begin
If @ClosedJobs = 'Y'
	Begin 
		SELECT @sql3 = 'SELECT   ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + EM.EMP_FNAME + '' '' + ISNULL(EM.EMP_MI, '''') + '' '' + EM.EMP_LNAME AS Manager, 
                      JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE, JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, 
                      JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, ''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI, '''') + '' '' + EMPLOYEE.EMP_LNAME AS AE, 
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH, JOB_COMPONENT.JOB_MARKUP_PCT, 
                      CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.JOB_DUE_DATE, 
                      JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, E.EMP_CODE, dbo.udf_get_empl_name(E.EMP_CODE, ''FML'') AS EMP_NAME,
					  JOB_TRAFFIC_DET.TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, ''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE, TRAFFIC_ROLE.ROLE_DESC, JOB_TRAFFIC.TRF_COMMENTS
FROM         JOB_TRAFFIC INNER JOIN
                      JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
                      JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN JOB_TRAFFIC_DET_EMPS AS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN
                      EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE LEFT OUTER JOIN EMPLOYEE AS EM ON JOB_TRAFFIC.MGR_EMP_CODE = EM.EMP_CODE LEFT OUTER JOIN
                      TRAFFIC_ROLE ON EMP_TRAFFIC_ROLE.ROLE_CODE = TRAFFIC_ROLE.ROLE_CODE INNER JOIN #report ON JOB_TRAFFIC_DET.JOB_NUMBER = #report.JobNumber AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = #report.JobCompNumber'
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) c ON #report.StatusCode = c.vstr collate database_default'
							  End	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
								End	      
				 SELECT @sql3 = @sql3 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql3 = @sql3 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= ''' + CAST(@IncludeClosedStartDate AS Varchar(12)) + ''' AND JOB_TRAFFIC.COMPLETED_DATE <= ''' + CAST(@IncludeClosedEndDate AS Varchar(12)) + '''))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
							End  
							  
				SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IN (''' + @Task1 + ''',''' + @Task2 + ''',''' + @Task3 + ''',''' + @Task4 + ''',''' + @Task5 + ''',''' + @Task6 + ''',''' + @Task7 + ''',''' + @Task8 + ''',''' + @Task9 + ''',''' + @Task10 + ''',''' + @Task11 + ''',''' + @Task12 + ''',''' + @Task13 + ''',
							''' + @Task14 + ''',''' + @Task15 + ''',''' + @Task16 + ''',''' + @Task17 + ''',''' + @Task18 + ''',''' + @Task19 + ''',''' + @Task20 + ''',''' + @Task21 + ''',''' + @Task22 + ''',''' + @Task23 + ''',''' + @Task24 + ''',''' + @Task25 + ''',''' + @Task26 + ''',''' + @Task27 + ''',''' + @Task28 + ''',''' + @Task29 + ''',''' + @Task30 + '''))'
							
			    SELECT @sql4 = @sql4 + ' UNION
                                        SELECT JOB_TRAFFIC.JOB_NUMBER, JOB_TRAFFIC.JOB_COMPONENT_NBR, ISNULL(JOB_TRAFFIC_DET.SEQ_NBR,'''') AS SEQ_NBR, 
                                                              ISNULL(JOB_TRAFFIC_DET.FNC_CODE,'''') AS FNC_CODE, ISNULL(JOB_TRAFFIC_DET.TASK_START_DATE,'''') AS TASK_START_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_DUE_DATE,'''') AS JOB_DUE_DATE, 
                                                              ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE,'''') AS JOB_REVISED_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,'''') AS JOB_COMPLETED_DATE, ISNULL(E.EMP_CODE,'''') AS EMP_CODE, 
                                                              ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE,'''') AS TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME,''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE
		                                        FROM         JOB_TRAFFIC LEFT OUTER JOIN
							                                          JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
							                                          JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                                                                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN 
																	  JOB_TRAFFIC_DET_EMPS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND
																		E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND 
																		E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
						      If @ClientCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) f ON JOB_LOG.CL_CODE = f.vstr collate database_default'
							    End
						      if @OfficeCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							    End
							    
							  if @AEs <> '%'
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
								End
							    
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) e ON JOB_TRAFFIC.TRF_CODE = e.vstr collate database_default'
							  End  	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) h ON EMP_TRAFFIC_ROLE.ROLE_CODE = h.vstr collate database_default'
								End	  						
					IF @Restrictions > 0
						Begin
							SELECT @sql4 = @sql4 + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End	  	
					If @RestrictionsOffice > 0
						Begin
							SELECT @sql2 = @sql2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
						End  
				 SELECT @sql4 = @sql4 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND (JOB_TRAFFIC_DET.SEQ_NBR IS NULL) AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL) '
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql4 = @sql4 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= ''' + CAST(@IncludeClosedStartDate AS Varchar(12)) + ''' AND JOB_TRAFFIC.COMPLETED_DATE <= ''' + CAST(@IncludeClosedEndDate AS Varchar(12)) + '''))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql4 = @sql4 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
							End  
					   if @Manager <> 'All'
							Begin
								    SELECT @sql4 = @sql4 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							End	
					 IF @Restrictions > 0
						Begin
							SELECT @sql4 = @sql4 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End		                                          
							                                          
			  	SELECT @sql3 = @sql3 + ' ORDER BY'-- EMP_TRAFFIC_ROLE.ROLE_CODE, E.EMP_CODE, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'	
			  		
					if @Sort1 = 'EmpRole'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE ASC,'
						End
					if @Sort1 = 'EmpRole DESC'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE DESC,'
						End
					
					if @Sort2 = 'Employee'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE ASC, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
					if @Sort2 = 'Employee DESC'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE DESC, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
			  	

					EXEC (@sql3 + @sql4)						
					
						
					--PRINT @sql3
					PRINT @sql4
	End
else
	Begin 
		SELECT @sql3 = 'SELECT   ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + EM.EMP_FNAME + '' '' + ISNULL(EM.EMP_MI, '''') + '' '' + EM.EMP_LNAME AS Manager, JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE, 
                      JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, 
                      ''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI, '''') + '' '' + EMPLOYEE.EMP_LNAME AS AE, JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, 
                      CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH, JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG, JOB_TRAFFIC_DET.SEQ_NBR, 
                      JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, E.EMP_CODE, dbo.udf_get_empl_name(E.EMP_CODE, ''FML'') AS EMP_NAME,
					  JOB_TRAFFIC_DET.TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, ''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE, TRAFFIC_ROLE.ROLE_DESC, JOB_TRAFFIC.TRF_COMMENTS
FROM         JOB_TRAFFIC INNER JOIN
                      JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
                      JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN JOB_TRAFFIC_DET_EMPS AS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN
                      EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE INNER JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN TRAFFIC ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN
                      JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE LEFT OUTER JOIN EMPLOYEE AS EM ON JOB_TRAFFIC.MGR_EMP_CODE = EM.EMP_CODE LEFT OUTER JOIN TRAFFIC_ROLE ON EMP_TRAFFIC_ROLE.ROLE_CODE = TRAFFIC_ROLE.ROLE_CODE INNER JOIN #report ON JOB_TRAFFIC_DET.JOB_NUMBER = #report.JobNumber AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = #report.JobCompNumber '
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) c ON #report.StatusCode = c.vstr collate database_default'
							  End  	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql3 = @sql3 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) f ON EMP_TRAFFIC_ROLE.ROLE_CODE = f.vstr collate database_default'
								End	 
							  
					SELECT @sql3 = @sql3 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)'						
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
							End		
			  SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IN (''' + @Task1 + ''',''' + @Task2 + ''',''' + @Task3 + ''',''' + @Task4 + ''',''' + @Task5 + ''',''' + @Task6 + ''',''' + @Task7 + ''',''' + @Task8 + ''',''' + @Task9 + ''',''' + @Task10 + ''',''' + @Task11 + ''',''' + @Task12 + ''',''' + @Task13 + ''',
							''' + @Task14 + ''',''' + @Task15 + ''',''' + @Task16 + ''',''' + @Task17 + ''',''' + @Task18 + ''',''' + @Task19 + ''',''' + @Task20 + ''',''' + @Task21 + ''',''' + @Task22 + ''',''' + @Task23 + ''',''' + @Task24 + ''',''' + @Task25 + ''',''' + @Task26 + ''',''' + @Task27 + ''',''' + @Task28 + ''',''' + @Task29 + ''',''' + @Task30 + '''))'
			  SELECT @sql4 = @sql4 + ' UNION
                                        SELECT JOB_TRAFFIC.JOB_NUMBER, JOB_TRAFFIC.JOB_COMPONENT_NBR, ISNULL(JOB_TRAFFIC_DET.SEQ_NBR,'''') AS SEQ_NBR, 
                                                              ISNULL(JOB_TRAFFIC_DET.FNC_CODE,'''') AS FNC_CODE, ISNULL(JOB_TRAFFIC_DET.TASK_START_DATE,'''') AS TASK_START_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_DUE_DATE,'''') AS JOB_DUE_DATE, 
                                                              ISNULL(JOB_TRAFFIC_DET.JOB_REVISED_DATE,'''') AS JOB_REVISED_DATE, ISNULL(JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,'''') AS JOB_COMPLETED_DATE, ISNULL(E.EMP_CODE,'''') AS EMP_CODE, 
                                                              ISNULL(JOB_TRAFFIC_DET.TEMP_COMP_DATE,'''') AS TEMP_COMP_DATE, ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME,''NOTIME'') AS REVISED_DUE_TIME, EMP_TRAFFIC_ROLE.ROLE_CODE
		                                        FROM         JOB_TRAFFIC LEFT OUTER JOIN
							                                          JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
							                                          JOB_COMPONENT ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							                                          JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
                                                                      JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN 
																	  JOB_TRAFFIC_DET_EMPS E ON E.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND
																		E.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR AND 
																		E.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR INNER JOIN EMP_TRAFFIC_ROLE ON E.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE'
                            
						      If @ClientCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) f ON JOB_LOG.CL_CODE = f.vstr collate database_default'
							    End
						      if @OfficeCode <> ''
							    Begin
								    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							    End
							    
							  if @AEs <> '%'
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(@AEs, DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
								End
							    
							  if @StatusCodes<>''
							  Begin
							    SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table_tsa(''' + @StatusCodes + ''', DEFAULT) e ON JOB_TRAFFIC.TRF_CODE = e.vstr collate database_default'
							  End	  	
							if @RlCodes<>'%' 
								Begin
									SELECT @sql4 = @sql4 + ' INNER JOIN charlist_to_table(''' + @RlCodes + ''', DEFAULT) h ON EMP_TRAFFIC_ROLE.ROLE_CODE = h.vstr collate database_default'
								End	 					
					IF @Restrictions > 0
						Begin
							SELECT @sql4 = @sql4 + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End		
					If @RestrictionsOffice > 0
						Begin
							SELECT @sql2 = @sql2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
						End
							  
								SELECT @sql4 = @sql4 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL) AND (JOB_TRAFFIC_DET.SEQ_NBR IS NULL)'						
									if @ForJobDueDate = 'Y'
										Begin
											if @ForJobStartDate <> '' and @ForJobEndDate <> ''
												SELECT @sql4 = @sql4 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + CAST(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + CAST(@ForJobEndDate AS Varchar(12)) + ''''
										End		
							        if @Manager <> 'All'
							            Begin
								            SELECT @sql4 = @sql4 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							            End     
									IF @Restrictions > 0
										Begin
											SELECT @sql4 = @sql4 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
										End			                             
			  SELECT @sql3 = @sql3 + ' ORDER BY'-- EMP_TRAFFIC_ROLE.ROLE_CODE, E.EMP_CODE, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'                                	
			  		if @Sort1 = 'Manager'
						Begin
							SELECT @sql3 = @sql3 + ' Manager,'
						End
					if @Sort1 = 'ProjectStartDate'
						Begin
							SELECT @sql3 = @sql3 + ' START_DATE,'
						End
					if @Sort1 = 'JobDueDate'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_FIRST_USE_DATE,'
						End
					if @Sort1 = 'ClientCode'
						Begin
							SELECT @sql3 = @sql3 + ' CL_CODE,'
						End
					if @Sort1 = 'ClientName'
						Begin
							SELECT @sql3 = @sql3 + ' CL_NAME,'
						End
					if @Sort1 = 'DivisionCode'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_CODE,'
						End
					if @Sort1 = 'DivisionName'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_NAME,'
						End
					if @Sort1 = 'ProductCode'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_CODE,'
						End
					if @Sort1 = 'ProductName'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_DESCRIPTION,'
						End
					if @Sort1 = 'JobNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_NUMBER,'
						End
					if @Sort1 = 'JobDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_DESC,'
						End
					if @Sort1 = 'JobCompNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMPONENT_NBR,'
						End
					if @Sort1 = 'JobCompDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMP_DESC,'
						End
					if @Sort1 = 'JobStatus'
						Begin
							SELECT @sql3 = @sql3 + ' TRF_DESCRIPTION,'
						End
					if @Sort1 = 'EmpRole'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE,'
						End
					if @Sort1 = 'EmpRole DESC'
						Begin
							SELECT @sql3 = @sql3 + ' EMP_TRAFFIC_ROLE.ROLE_CODE DESC,'
						End

					if @Sort2 = 'Manager'
						Begin
							SELECT @sql3 = @sql3 + ' Manager'
						End
					if @Sort2 = 'ProjectStartDate'
						Begin
							SELECT @sql3 = @sql3 + ' START_DATE'
						End
					if @Sort2 = 'JobDueDate'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_FIRST_USE_DATE'
						End
					if @Sort2 = 'ClientCode'
						Begin
							SELECT @sql3 = @sql3 + ' CL_CODE'
						End
					if @Sort2 = 'ClientName'
						Begin
							SELECT @sql3 = @sql3 + ' CL_NAME'
						End
					if @Sort2 = 'DivisionCode'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_CODE'
						End
					if @Sort2 = 'DivisionName'
						Begin
							SELECT @sql3 = @sql3 + ' DIV_NAME'
						End
					if @Sort2 = 'ProductCode'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_CODE'
						End
					if @Sort2 = 'ProductName'
						Begin
							SELECT @sql3 = @sql3 + ' PRD_DESCRIPTION'
						End
					if @Sort2 = 'JobNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_NUMBER'
						End
					if @Sort2 = 'JobDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_DESC'
						End
					if @Sort2 = 'JobCompNumber'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMPONENT_NBR'
						End
					if @Sort2 = 'JobCompDescription'
						Begin
							SELECT @sql3 = @sql3 + ' JOB_COMP_DESC'
						End
					if @Sort2 = 'JobStatus'
						Begin
							SELECT @sql3 = @sql3 + ' TRF_DESCRIPTION'
						End
					if @Sort2 = 'Employee'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
					if @Sort2 = 'Employee DESC'
						Begin
							SELECT @sql3 = @sql3 + ' E.EMP_CODE DESC, JOB_TRAFFIC_DET.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR'
						End
							                                          
			  		
			  --SELECT @paramlist3 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime,
			  	--					  @Task1 Varchar(40),@Task2 Varchar(40),@Task3 Varchar(40),@Task4 Varchar(40),@Task5 Varchar(40),@Task6 Varchar(40),@Task7 Varchar(40),@Task8 Varchar(40),
			  	--					  @Task9 Varchar(40),@Task10 Varchar(40),@Task11 Varchar(40),@Task12 Varchar(40),@Task13 Varchar(40),@Task14 Varchar(40),@Task15 Varchar(40),@Task16 Varchar(40),
			  	--					  @Task17 Varchar(40),@Task18 Varchar(40),@Task19 Varchar(40),@Task20 Varchar(40),@Task21 Varchar(40),@Task22 Varchar(40),@Task23 Varchar(40),@Task24 Varchar(40),
			  		--				  @Task25 Varchar(40),@Task26 Varchar(40),@Task27 Varchar(40),@Task28 Varchar(40),@Task29 Varchar(40),@Task30 Varchar(40),@StatusCodes varchar(4000), 
			  		--				  @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6)'
			  						  
			  		--SELECT @sql3 = @sql3 + @sql4
	
					EXEC (@sql3 + @sql4)
			  						  
			  		---EXEC sp_executesql @sql3, @paramlist3, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate,@Task1,@Task2,@Task3,@Task4,@Task5,
					--			       @Task6,@Task7,@Task8,@Task9,@Task10,@Task11,@Task12,@Task13,@Task14,@Task15,@Task16,@Task17,@Task18,@Task19,@Task20,@Task21,@Task22,@Task23,@Task24,
					--			       @Task25,@Task26,@Task27,@Task28,@Task29,@Task30,@StatusCodes, @ClientCode, @OfficeCode, @Manager
						
					--
				PRINT @sql4	
	End
	PRINT @sql3
    --PRINT @sql4
End


  		

Select '' AS [Role],
	'' as [Employee],
	'' as [Manager], 
    '' as [Job Start Date],
	'' as [Job Due Date1],
	'' as [Job Completed Date],
	'' as [Client Code],
	'' as [Client],
	'' as [Division Code],
	'' as [Division],
	'' as [Product Code],
	'' as [Product],
	'' as [Job Number],
	'' as [Job],
	'' as [Comp Number],
	'' as [Component],
	'' as [Client Reference],
	'' as [Account Executive],
	'' as [Job Type],	
	'' as [Job Type Description],
	'' as Rush,
	'' as [Job Markup],
	'' as [Job Non Bill Flag],
	'' as [Job Due Date2],
	'' as [Job Status],
	'' as DateTitles,
	'' as Task1,
	'' as Task2,			
	'' as Task3,			
	'' as Task4,			
	'' as Task5,			
	'' as Task6,			
	'' as Task7,			
	'' as Task8,			
	'' as Task9,		
	'' as Task10,			
	'' as Task11,			
	'' as Task12,			
	'' as Task13,			
	'' as Task14,			
	'' as Task15,			
	'' as Task16,			
	'' as Task17,			
	'' as Task18,			
	'' as Task19,			
	'' as Task20,			
	'' as Task21,			
	'' as Task22,			
	'' as Task23,			
	'' as Task24,			
	'' as Task25,			
	'' as Task26,			
	'' as Task27,			
	'' as Task28,			
	'' as Task29,			
	'' as Task30,
	'' as [Traffic Comments]	
	
    
DECLARE @SQL5 AS NVARCHAR(4000)  
SET @SQL5 = ''
SELECT @SQL5 = @SQL5 + 'SELECT TRF_CODE, TRF_DESC,CASE WHEN LEN(TRF_DESC) > 15 THEN SUBSTRING(ISNULL(TRF_DESC,''''),0,16)+''...'' ELSE TRF_DESC END AS TRF_DESC_SHORT FROM TRAFFIC_FNC WITH(NOLOCK) '
--SELECT @SQL5 = @SQL5 + ' WHERE  (TRAFFIC_FNC.FNC_CODE IN (''' + @Task1 + ''',''' + @Task2 + ''',''' + @Task3 + ''',''' + @Task4 + ''',''' + @Task5 + ''',''' + @Task6 + ''',''' + @Task7 + ''',''' + @Task8 + ''',''' + @Task9 + ''',''' + @Task10 + ''',''' + @Task11 + ''',''' + @Task12 + ''',''' + @Task13 + ''',
--							''' + @Task14 + ''',''' + @Task15 + ''',''' + @Task16 + ''',''' + @Task17 + ''',''' + @Task18 + ''',''' + @Task19 + ''',''' + @Task20 + ''',''' + @Task21 + ''',''' + @Task22 + ''',''' + @Task23 + ''',''' + @Task24 + ''',''' + @Task25 + ''',''' + @Task26 + ''',''' + @Task27 + ''',''' + @Task28 + ''',''' + @Task29 + ''',''' + @Task30 + '''))'
EXEC (@SQL5) 
   	  

drop table #report













