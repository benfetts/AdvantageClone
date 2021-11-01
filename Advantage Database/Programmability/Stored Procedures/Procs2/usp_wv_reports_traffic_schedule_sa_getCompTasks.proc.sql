







CREATE PROCEDURE [dbo].[usp_wv_reports_traffic_schedule_sa_getCompTasks]
@ClientCode as VarChar(4000),
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
	TRFComments		Text,
	OnlyProjected		VarChar(5),
	AccExecutive    VarChar(100),
	JobType			VarChar(10),	
	JobTypeDesc		VarChar(30),
	ClientRef		VarChar(30),
	JobCompletedDate datetime,
	Rush			VarChar(10),
	JobMarkup		Decimal(15,3),
	JobNonBillFlag	VarChar(10),
	SeqNbr			SmallInt,
	FunctionCode	VarChar(10) COLLATE database_default,
	FunctionDesc	VarChar(40),
	TaskStartDate	SmallDateTime,
	TaskJobDueDate  SmallDateTime,
	TaskJobRevDate	SmallDateTime,
	TaskJobCompDate SmallDateTime,
	TaskEmpCode     varchar(50),
	TaskCompDate	SmallDateTime,
	TaskDueTime		Varchar(10),
	TaskComment		Text,
	CDP				Varchar(500),
	JOBCOMP			Varchar(10),
	JobOrder		smallint	
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
				SELECT ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME, JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE,	TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE,	PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER,	JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
					NULL,NULL,NULL,''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG,
					  JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME,
					  NULL, CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP, (Cast(JOB_LOG.JOB_NUMBER AS VARCHAR(7))+''/''+Cast(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3))), JOB_TRAFFIC_DET.JOB_ORDER
				FROM JOB_LOG
				INNER JOIN CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION	ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE	AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE	AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE	AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				LEFT OUTER JOIN JOB_TRAFFIC_DET	ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
				INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		         LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		         LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE'
						-- ****************** Check For List of Clients
					    If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						-- ******************* Check For List of Offices
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @AEs + ''', DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End					
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
						End	
							
			    
				SELECT @sql3 = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
				        if @Manager <> 'All'
							Begin
								SELECT @sql3 = @sql3 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							End			
				
				 SELECT @sql3 = @sql3 + ' AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql3 = @sql3 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= ''' + Cast(@IncludeClosedStartDate AS Varchar(12)) + ''' AND JOB_TRAFFIC.COMPLETED_DATE <= ''' + Cast(@IncludeClosedEndDate AS Varchar(12)) + '''))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + Cast(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + Cast(@ForJobEndDate AS Varchar(12)) + ''''
							End
				SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IS NOT NULL)'	
					 IF @RestrictionsCP > 0
						Begin
							SELECT @sql3 = @sql3 + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = ''' + CAST(@CPID AS VARCHAR(6)) + ''')'
						End		 		
					SELECT @sql3 = @sql3 + ' Group By    JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.START_DATE, JOB_FIRST_USE_DATE, TRAFFIC.TRF_CODE, TRAFFIC.TRF_DESCRIPTION,
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME, JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG, JOB_TRAFFIC.MGR_EMP_CODE, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME, JOB_TRAFFIC_DET.JOB_ORDER'

					--SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @IncludeClosedStartDate DateTime, @IncludeClosedEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000)'
                   
					--EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @IncludeClosedStartDate, @IncludeClosedEndDate, @ClientCode, @OfficeCode, @Manager, @AEs
					
					EXEC(@sql2 + @sql3)
						
					PRINT @sql2
			End
		Else
			Begin		
				-- ************ Exclude Closed Jobs ****************
				SELECT @sql2 = 'Insert Into #report
					SELECT ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME, JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE,	PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER,	JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
					NULL,NULL,NULL,''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG,
					  JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME,
					  NULL, CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP, (Cast(JOB_LOG.JOB_NUMBER AS VARCHAR(7))+''/''+Cast(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3))), JOB_TRAFFIC_DET.JOB_ORDER
				FROM JOB_LOG
				INNER JOIN CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION	ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE	AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE	AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE	AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				LEFT OUTER JOIN JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
				INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER	AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		        LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		        LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE'
						If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @AEs + ''', DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End					
					IF @RestrictionsCP > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
						End	
			    
				SELECT @sql3 = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) 
				AND JOB_TRAFFIC.COMPLETED_DATE IS NULL'
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + Cast(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + Cast(@ForJobEndDate AS Varchar(12)) + ''''
							End
						if @Manager <> 'All'
							Begin
								SELECT @sql3 = @sql3 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							End
				SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IS NOT NULL)'	
					 IF @RestrictionsCP > 0
						Begin
							SELECT @sql3 = @sql3 + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = ''' + CAST(@CPID AS VARCHAR(6)) + ''')'
						End		 
					SELECT @sql3 = @sql3 + ' Group By   JOB_TRAFFIC.MGR_EMP_CODE, JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE,DIVISION.DIV_NAME,	JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,	JOB_COMPONENT.START_DATE, JOB_FIRST_USE_DATE, TRAFFIC.TRF_CODE, TRAFFIC.TRF_DESCRIPTION, JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES, JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME, JOB_TRAFFIC_DET.JOB_ORDER'

					--SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000)'
                     
					--EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @ClientCode, @OfficeCode, @Manager, @AEs
					
					EXEC(@sql2 + @sql3)
						
					PRINT @sql4
			End
End
Else
Begin
-- ******   List of Clients *************
		If @ClosedJobs = 'Y'
			Begin 
			-- ************ Include Closed Jobs ****************
					
				SELECT @sql2 = 'Insert Into #report
				SELECT ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME, JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE,	TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE,	PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER,	JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
					NULL,NULL,NULL,''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG,
					  JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME,
					  NULL, CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP, (Cast(JOB_LOG.JOB_NUMBER AS VARCHAR(7))+''/''+Cast(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3))), JOB_TRAFFIC_DET.JOB_ORDER
				FROM JOB_LOG
				INNER JOIN CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION	ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE	AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE	AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE	AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				LEFT OUTER JOIN JOB_TRAFFIC_DET	ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
				INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		         LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		         LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE'
						-- ****************** Check For List of Clients
					    If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						-- ******************* Check For List of Offices
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @AEs + ''', DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End					
					IF @Restrictions > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End	
					If @RestrictionsOffice > 0
						Begin
							SELECT @sql2 = @sql2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
						End
							
			    
				SELECT @sql3 = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
				        if @Manager <> 'All'
							Begin
								SELECT @sql3 = @sql3 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							End			
				
				 SELECT @sql3 = @sql3 + ' AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql3 = @sql3 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= ''' + Cast(@IncludeClosedStartDate AS Varchar(12)) + ''' AND JOB_TRAFFIC.COMPLETED_DATE <= ''' + Cast(@IncludeClosedEndDate AS Varchar(12)) + '''))'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + Cast(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + Cast(@ForJobEndDate AS Varchar(12)) + ''''
							End
				SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IS NOT NULL)'	
					 IF @Restrictions > 0
						Begin
							SELECT @sql3 = @sql3 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End		 		
					SELECT @sql3 = @sql3 + ' Group By    JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.START_DATE, JOB_FIRST_USE_DATE, TRAFFIC.TRF_CODE, TRAFFIC.TRF_DESCRIPTION,
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME, JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG, JOB_TRAFFIC.MGR_EMP_CODE, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME, JOB_TRAFFIC_DET.JOB_ORDER'

					--SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @IncludeClosedStartDate DateTime, @IncludeClosedEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000)'
                   
					--EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @IncludeClosedStartDate, @IncludeClosedEndDate, @ClientCode, @OfficeCode, @Manager, @AEs
					
					EXEC(@sql2 + @sql3)
						
					PRINT @sql2
			End
		Else
			Begin		
				-- ************ Exclude Closed Jobs ****************
				SELECT @sql2 = 'Insert Into #report
					SELECT ''('' + JOB_TRAFFIC.MGR_EMP_CODE + '') '' + E.EMP_FNAME + '' '' + ISNULL(E.EMP_MI,'''') + '' '' + E.EMP_LNAME, JOB_COMPONENT.START_DATE, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION, TRAFFIC.TRF_CODE,
					JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE,	PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER,	JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,
					NULL,NULL,NULL,''('' + JOB_COMPONENT.EMP_CODE + '') '' + EMPLOYEE.EMP_FNAME + '' '' + ISNULL(EMPLOYEE.EMP_MI,'''') + '' '' + EMPLOYEE.EMP_LNAME AS AE,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, CASE WHEN JOB_LOG.JOB_RUSH_CHARGES = 1 THEN ''X'' ELSE '''' END AS RUSH,
                      JOB_COMPONENT.JOB_MARKUP_PCT, CASE WHEN JOB_COMPONENT.NOBILL_FLAG = 1 THEN ''X'' ELSE '''' END AS NOBILL_FLAG,
					  JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME,
					  NULL, CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP, (Cast(JOB_LOG.JOB_NUMBER AS VARCHAR(7))+''/''+Cast(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3))), JOB_TRAFFIC_DET.JOB_ORDER
				FROM JOB_LOG
				INNER JOIN CLIENT ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN DIVISION	ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE	AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
				INNER JOIN PRODUCT ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE	AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE	AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				INNER JOIN JOB_PROC_CONTROLS ON JOB_COMPONENT.JOB_PROCESS_CONTRL = JOB_PROC_CONTROLS.JOB_PROCESS_CONTRL 
				LEFT OUTER JOIN JOB_TRAFFIC_DET ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
				INNER JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER	AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
				INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		        LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
		        LEFT OUTER JOIN EMPLOYEE E ON JOB_TRAFFIC.MGR_EMP_CODE = E.EMP_CODE'
						If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @ClientCode + ''', DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @OfficeCode + ''', DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
							End
							
						if @AEs <> '%'
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(''' + @AEs + ''', DEFAULT) e ON JOB_COMPONENT.EMP_CODE = e.vstr collate database_default'
							End					
					IF @Restrictions > 0
						Begin
							SELECT @sql2 = @sql2 + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
						End	
					If @RestrictionsOffice > 0
						Begin
							SELECT @sql2 = @sql2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
						End
			    
				SELECT @sql3 = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) 
				AND JOB_TRAFFIC.COMPLETED_DATE IS NULL'
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql3 = @sql3 + ' AND JOB_COMPONENT.JOB_FIRST_USE_DATE >= ''' + Cast(@ForJobStartDate AS Varchar(12)) + ''' AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= ''' + Cast(@ForJobEndDate AS Varchar(12)) + ''''
							End
						if @Manager <> 'All'
							Begin
								SELECT @sql3 = @sql3 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = ''' + @Manager + ''' '
							End
				SELECT @sql3 = @sql3 + ' AND (JOB_TRAFFIC_DET.FNC_CODE IS NOT NULL)'	
					 IF @Restrictions > 0
						Begin
							SELECT @sql3 = @sql3 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
						End		 
					SELECT @sql3 = @sql3 + ' Group By   JOB_TRAFFIC.MGR_EMP_CODE, JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE,DIVISION.DIV_NAME,	JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,	JOB_COMPONENT.START_DATE, JOB_FIRST_USE_DATE, TRAFFIC.TRF_CODE, TRAFFIC.TRF_DESCRIPTION, JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME, E.EMP_FNAME, E.EMP_MI, E.EMP_LNAME,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES, JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION, JOB_TRAFFIC_DET.TASK_START_DATE, 
                      JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.TEMP_COMP_DATE, JOB_TRAFFIC_DET.REVISED_DUE_TIME, JOB_TRAFFIC_DET.JOB_ORDER'

					--SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6), @AEs VarChar(4000)'
                     
					--EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @ClientCode, @OfficeCode, @Manager, @AEs
					
					EXEC(@sql2 + @sql3)
						
					PRINT @sql4
			End
End

		



Update #report
Set  TRFComments = JOB_TRAFFIC.TRF_COMMENTS
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR

Update #report
Set  TaskComment = JOB_TRAFFIC_DET.FNC_COMMENTS
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR		
		AND #report.SeqNbr = JOB_TRAFFIC_DET.SEQ_NBR
		AND #report.FunctionCode = JOB_TRAFFIC_DET.FNC_CODE

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
	TRFComments as [Traffic Comments],
	SeqNbr,
	FunctionCode,
	FunctionDesc,
	TaskStartDate,
	TaskJobDueDate,
	TaskJobRevDate,
	TaskJobCompDate,
	TaskEmpCode,
	TaskCompDate,
	TaskDueTime,
	TaskComment,
	CDP,
	JOBCOMP,
	JobOrder	
	
   from #report
	
   JOIN charlist_to_table_tsa(@StatusCodes, DEFAULT) c ON #report.StatusCode = c.vstr collate database_default'

   if @OrigDueDateCompDate = 'Y'
   Begin
	 SELECT @sql = @sql + ' order by ClientCode,DivisionCode,ProductCode,JobNumber,JobCompNumber,TaskJobDueDate,JobOrder,SeqNbr'
   End
   if @DueDateCompDate = 'Y'
   Begin
	 SELECT @sql = @sql + ' order by ClientCode,DivisionCode,ProductCode,JobNumber,JobCompNumber,TaskJobRevDate,JobOrder,SeqNbr'
   End
  
   
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
	TRFComments as [Traffic Comments],
	SeqNbr,
	FunctionCode,
	FunctionDesc,
	TaskStartDate,
	TaskJobDueDate,
	TaskJobRevDate,
	TaskJobCompDate,
	TaskEmpCode,
	TaskCompDate,
	TaskDueTime,
	TaskComment,
	CDP,
	JOBCOMP,
	JobOrder
	
   from #report'
   if @OrigDueDateCompDate = 'Y'
   Begin
	 SELECT @sql = @sql + ' ORDER BY ClientCode,DivisionCode,ProductCode,JobNumber,JobCompNumber,TaskJobDueDate,JobOrder,SeqNbr'
   End
   if @DueDateCompDate = 'Y'
   Begin
	 SELECT @sql = @sql + ' ORDER BY ClientCode,DivisionCode,ProductCode,JobNumber,JobCompNumber,TaskJobRevDate,JobOrder,SeqNbr'
   End
   
						

    SELECT @paramlist = '@Sort1 varchar(100), @Sort2 varchar(100)'

    EXEC sp_executesql @sql, @paramlist, @Sort1, @Sort2 
    	
    PRINT @sql 
end


	
    
DECLARE @SQL5 AS NVARCHAR(4000)  
SET @SQL5 = ''
SELECT @SQL5 = @SQL5 + 'SELECT TRF_CODE, TRF_DESC,CASE WHEN LEN(TRF_DESC) > 15 THEN SUBSTRING(ISNULL(TRF_DESC,''''),0,16)+''...'' ELSE TRF_DESC END AS TRF_DESC_SHORT FROM TRAFFIC_FNC WITH(NOLOCK) '
--SELECT @SQL5 = @SQL5 + ' WHERE  (TRAFFIC_FNC.FNC_CODE IN (''' + @Task1 + ''',''' + @Task2 + ''',''' + @Task3 + ''',''' + @Task4 + ''',''' + @Task5 + ''',''' + @Task6 + ''',''' + @Task7 + ''',''' + @Task8 + ''',''' + @Task9 + ''',''' + @Task10 + ''',''' + @Task11 + ''',''' + @Task12 + ''',''' + @Task13 + ''',
--							''' + @Task14 + ''',''' + @Task15 + ''',''' + @Task16 + ''',''' + @Task17 + ''',''' + @Task18 + ''',''' + @Task19 + ''',''' + @Task20 + ''',''' + @Task21 + ''',''' + @Task22 + ''',''' + @Task23 + ''',''' + @Task24 + ''',''' + @Task25 + ''',''' + @Task26 + ''',''' + @Task27 + ''',''' + @Task28 + ''',''' + @Task29 + ''',''' + @Task30 + '''))'
EXEC (@SQL5) 
   	  

drop table #report













