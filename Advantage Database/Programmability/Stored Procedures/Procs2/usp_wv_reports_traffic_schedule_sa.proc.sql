
/* 
CHANGE LOG:
==========================================================================
CT,  20060622: 
     Moved the task status column from the select list
     as well as group by statements of all selects
Sam, 20060425:
	changes to filter projected items.
	added field to temp table
	added field to all the selects
	added if statement at end to check for the filter param
BJL, 20060621: Changed job process control (status) to display description	
ATC, 20070626: Added Office Code restrictions to query
ATC, 20070702: Added more selections for Account Exec, Job Type, and Client Reference
ATC, 20080312: Added more selections for columns, dates, and date ranges.
==========================================================================
*/

CREATE PROCEDURE [dbo].[usp_wv_reports_traffic_schedule_sa]
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
@DueTime Char(1)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@sql2 nvarchar(4000),
		@paramlist nvarchar(4000),
		@paramlist2 nvarchar(4000)
-- ************* Create Temp Table ***********************
CREATE TABLE #report( 	
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
	JobCompNumber		int Null, 
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
	) 

		-- ******   List of Clients *************
		If @ClosedJobs = 'Y'
			Begin 
			-- ************ Include Closed Jobs ****************
					
				SELECT @sql2 = 'Insert Into #report
				SELECT  
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
				LEFT OUTER JOIN JOB_TRAFFIC_DET
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
							INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		         LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE'
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
			    
				SELECT @sql2 = @sql2 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
				        if @Manager <> 'All'
							Begin
								SELECT @sql2 = @sql2 + ' AND JOB_TRAFFIC.MGR_EMP_CODE = @Manager '
							End			
				
				 SELECT @sql2 = @sql2 + ' AND ((JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
						if @IncludeClosedStartDate <> '' and @IncludeClosedEndDate <> ''
							Begin
								SELECT @sql2 = @sql2 + ' OR (JOB_TRAFFIC.COMPLETED_DATE >= @IncludeClosedStartDate AND JOB_TRAFFIC.COMPLETED_DATE <= @IncludeClosedEndDate)'
							End
						if @ForJobDueDate = 'Y'
							Begin
								if @ForJobStartDate <> '' and @ForJobEndDate <> ''
									SELECT @sql2 = @sql2 + ' OR (JOB_COMPONENT.JOB_FIRST_USE_DATE >= @ForJobStartDate AND JOB_COMPONENT.JOB_FIRST_USE_DATE <= @ForJobEndDate)'
							End
						
					SELECT @sql2 = @sql2 + ') Group By    JOB_LOG.CL_CODE,
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
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG'

					SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @IncludeClosedStartDate DateTime, @IncludeClosedEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6)'

					EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @IncludeClosedStartDate, @IncludeClosedEndDate, @ClientCode, @OfficeCode, @Manager
						
					PRINT @sql2
			End
		Else
			Begin		
				-- ************ Exclude Closed Jobs ****************
				SELECT @sql2 = 'Insert Into #report
					SELECT   
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
				LEFT OUTER JOIN JOB_TRAFFIC_DET
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
				INNER JOIN JOB_TRAFFIC
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
							INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
				INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
		        LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE'
						If @ClientCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@ClientCode, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
							End
						if @OfficeCode <> ''
							Begin
								SELECT @sql2 = @sql2 + ' INNER JOIN charlist_to_table(@OfficeCode, DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
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
					JOB_COMPONENT.EMP_CODE, EMPLOYEE.EMP_FNAME, EMPLOYEE.EMP_MI, EMPLOYEE.EMP_LNAME,  
                      JOB_COMPONENT.JT_CODE, JOB_TYPE.JT_DESC, JOB_LOG.JOB_CLI_REF, JOB_TRAFFIC.COMPLETED_DATE, JOB_LOG.JOB_RUSH_CHARGES,
                      JOB_COMPONENT.JOB_MARKUP_PCT, JOB_COMPONENT.NOBILL_FLAG'

					SELECT @paramlist2 = '@ForJobDueDate char(1), @ForJobStartDate DateTime, @ForJobEndDate DateTime, @ClientCode varchar(4000), @OfficeCode varchar(4000), @Manager Varchar(6)'

					EXEC sp_executesql @sql2, @paramlist2, @ForJobDueDate, @ForJobStartDate, @ForJobEndDate, @ClientCode, @OfficeCode, @Manager
						
					PRINT @sql2
			End



Update #report
Set  TRFComments = JOB_TRAFFIC.TRF_COMMENTS
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR

If @CompletedDates = 'Y'
Begin
	-- **********  This is to show Completed Dates ***********

Update #report
Set Task1 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL


Update #report
Set Task2 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task3 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task4 =   convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task5 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task6 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task7 =   convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task8 =   convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task9 =   convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task10 =   convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task11 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task12 =   convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task13 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL


Update #report
Set Task14 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task15 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task16 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER

	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task17 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task18 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task19 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task20 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task21 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task22 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task23 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task24 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task25 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task26 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task27 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task28 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task29 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL


Update #report
Set Task30 =  convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL		

END
if @DueDate = 'Y'
Begin
-- ********************   Show Due Date and X for Completed ******************

Update #report
Set Task1 = convert(char, JOB_REVISED_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1

Update #report
Set Task1 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task2 = convert(char, JOB_REVISED_DATE, 101)
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2

Update #report
Set Task2 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task3 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3

Update #report
Set Task3 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task4 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4

Update #report
Set Task4 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task5 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5


Update #report
Set Task5 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task6 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6

Update #report
Set Task6 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task7 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7

Update #report
Set Task7 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task8 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8

Update #report
Set Task8 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task9 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9

Update #report
Set Task9 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task10 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10

Update #report
Set Task10 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task11 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11

Update #report
Set Task11 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task12 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12

Update #report
Set Task12 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task13 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13

Update #report
Set Task13 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task14 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14

Update #report
Set Task14 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task15 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15

Update #report
Set Task15 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task16 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16


Update #report
Set Task16 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER

	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task17 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17

Update #report
Set Task17 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task18 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18

Update #report
Set Task18 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task19 =  convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19

Update #report
Set Task19 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task20 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20

Update #report
Set Task20 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task21 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21

Update #report
Set Task21 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task22 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22

Update #report
Set Task22 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task23 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23

Update #report
Set Task23 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task24 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24

Update #report
Set Task24 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task25 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25

Update #report
Set Task25 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task26 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26

Update #report
Set Task26 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task27 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27

Update #report
Set Task27 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL
Update #report
Set Task28 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28

Update #report
Set Task28 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task29 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29

Update #report
Set Task29 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task30 = convert(char, JOB_REVISED_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30

Update #report
Set Task30 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL
-- *****************************************************

End

if @OriginalDueDate = 'Y'
Begin
-- ********************   Show Original Due Date and X for Completed ******************

Update #report
Set Task1 = convert(char, JOB_DUE_DATE, 101) 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1

Update #report
Set Task1 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task2 = convert(char, JOB_DUE_DATE, 101)
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2

Update #report
Set Task2 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task3 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3

Update #report
Set Task3 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task4 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4

Update #report
Set Task4 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task5 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5


Update #report
Set Task5 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task6 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6

Update #report
Set Task6 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task7 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7

Update #report
Set Task7 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task8 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8

Update #report
Set Task8 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task9 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9

Update #report
Set Task9 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task10 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10

Update #report
Set Task10 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task11 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11

Update #report
Set Task11 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task12 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12

Update #report
Set Task12 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task13 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13

Update #report
Set Task13 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task14 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14

Update #report
Set Task14 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task15 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15

Update #report
Set Task15 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task16 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16


Update #report
Set Task16 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER

	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task17 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17

Update #report
Set Task17 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task18 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18

Update #report
Set Task18 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task19 =  convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19

Update #report
Set Task19 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task20 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20

Update #report
Set Task20 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task21 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21

Update #report
Set Task21 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task22 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22

Update #report
Set Task22 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task23 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23

Update #report
Set Task23 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task24 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24

Update #report
Set Task24 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task25 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25

Update #report
Set Task25 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task26 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26

Update #report
Set Task26 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task27 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27

Update #report
Set Task27 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL
Update #report
Set Task28 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28

Update #report
Set Task28 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task29 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29

Update #report
Set Task29 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL

Update #report
Set Task30 = convert(char, JOB_DUE_DATE, 101) 
 From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30

Update #report
Set Task30 =  'X'
From #report
	INNER JOIN JOB_TRAFFIC
	    ON #report.JobNumber = JOB_TRAFFIC.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC.JOB_COMPONENT_NBR
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30
AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE Is Not NULL
-- *****************************************************

End

If @OrigDueDateCompDate = 'Y'
Begin
	-- **********  This is to show Original and Completed Dates ***********

Update #report
Set Task1 = convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1


Update #report
Set Task2 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2

Update #report
Set Task3 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3

Update #report
Set Task4 =   convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4

Update #report
Set Task5 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5

Update #report
Set Task6 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6

Update #report
Set Task7 =   convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7

Update #report
Set Task8 =   convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8

Update #report
Set Task9 =   convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9

Update #report
Set Task10 =   convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10

Update #report
Set Task11 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11

Update #report
Set Task12 =   convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12

Update #report
Set Task13 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13

Update #report
Set Task14 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14

Update #report
Set Task15 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15

Update #report
Set Task16 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16

Update #report
Set Task17 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17

Update #report
Set Task18 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18

Update #report
Set Task19 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19

Update #report
Set Task20 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20

Update #report
Set Task21 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21

Update #report
Set Task22 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22

Update #report
Set Task23 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23

Update #report
Set Task24 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24

Update #report
Set Task25 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25

Update #report
Set Task26 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26

Update #report
Set Task27 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27

Update #report
Set Task28 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28

Update #report
Set Task29 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29


Update #report
Set Task30 =  convert(char, JOB_DUE_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30		

END

If @DueDateCompDate = 'Y'
Begin
	-- **********  This is to show Revised Due and Completed Dates ***********

Update #report
Set Task1 = convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1


Update #report
Set Task2 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2

Update #report
Set Task3 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3

Update #report
Set Task4 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4

Update #report
Set Task5 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5

Update #report
Set Task6 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6

Update #report
Set Task7 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7

Update #report
Set Task8 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8

Update #report
Set Task9 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9

Update #report
Set Task10 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10

Update #report
Set Task11 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11

Update #report
Set Task12 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12

Update #report
Set Task13 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13

Update #report
Set Task14 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14

Update #report
Set Task15 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15

Update #report
Set Task16 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16

Update #report
Set Task17 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17

Update #report
Set Task18 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18

Update #report
Set Task19 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19

Update #report
Set Task20 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20

Update #report
Set Task21 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21

Update #report
Set Task22 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22

Update #report
Set Task23 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23

Update #report
Set Task24 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24

Update #report
Set Task25 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25

Update #report
Set Task26 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26

Update #report
Set Task27 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27

Update #report
Set Task28 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28

Update #report
Set Task29 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29


Update #report
Set Task30 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(convert(char, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101), '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30		

END

If @DueTime = 'Y'
Begin
	-- **********  This is to show Revised Due Date and Revised Due Time ***********

Update #report
Set Task1 = convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1


Update #report
Set Task2 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2

Update #report
Set Task3 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3

Update #report
Set Task4 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4

Update #report
Set Task5 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5

Update #report
Set Task6 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6

Update #report
Set Task7 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7

Update #report
Set Task8 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8

Update #report
Set Task9 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9

Update #report
Set Task10 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10

Update #report
Set Task11 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11

Update #report
Set Task12 =   convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12

Update #report
Set Task13 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13

Update #report
Set Task14 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14

Update #report
Set Task15 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15

Update #report
Set Task16 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16

Update #report
Set Task17 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17

Update #report
Set Task18 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18

Update #report
Set Task19 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19

Update #report
Set Task20 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20

Update #report
Set Task21 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21

Update #report
Set Task22 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22

Update #report
Set Task23 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23

Update #report
Set Task24 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24

Update #report
Set Task25 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25

Update #report
Set Task26 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26

Update #report
Set Task27 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27

Update #report
Set Task28 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '')
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28

Update #report
Set Task29 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29


Update #report
Set Task30 =  convert(char, JOB_REVISED_DATE, 101) + '-' + ISNULL(JOB_TRAFFIC_DET.REVISED_DUE_TIME, '') 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30		

END

If @EmpCode = 'Y'
Begin
	-- **********  This is to show Employee Code ***********

Update #report
Set Task1 = ISNULL(Cast(Task1 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task1

Update #report
Set Task2 = ISNULL(Cast(Task2 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5)) 
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task2

Update #report
Set Task3 = ISNULL(Cast(Task3 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task3

Update #report
Set Task4 = ISNULL(Cast(Task4 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task4

Update #report
Set Task5 = ISNULL(Cast(Task5 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task5

Update #report
Set Task6 = ISNULL(Cast(Task6 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task6

Update #report
Set Task7 = ISNULL(Cast(Task7 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task7

Update #report
Set Task8 = ISNULL(Cast(Task8 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task8

Update #report
Set Task9 = ISNULL(Cast(Task9 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task9

Update #report
Set Task10 = ISNULL(Cast(Task10 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task10

Update #report
Set Task11 = ISNULL(Cast(Task11 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task11

Update #report
Set Task12 = ISNULL(Cast(Task12 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task12

Update #report
Set Task13 = ISNULL(Cast(Task13 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task13

Update #report
Set Task14 = ISNULL(Cast(Task14 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task14

Update #report
Set Task15 = ISNULL(Cast(Task15 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task15

Update #report
Set Task16 = ISNULL(Cast(Task16 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task16

Update #report
Set Task17 = ISNULL(Cast(Task17 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task17

Update #report
Set Task18 = ISNULL(Cast(Task18 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task18

Update #report
Set Task19 = ISNULL(Cast(Task19 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task19

Update #report
Set Task20 = ISNULL(Cast(Task20 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task20

Update #report
Set Task21 = ISNULL(Cast(Task21 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task21

Update #report
Set Task22 = ISNULL(Cast(Task22 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task22

Update #report
Set Task23 = ISNULL(Cast(Task23 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task23

Update #report
Set Task24 = ISNULL(Cast(Task24 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task24

Update #report
Set Task25 = ISNULL(Cast(Task25 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task25

Update #report
Set Task26 = ISNULL(Cast(Task26 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task26

Update #report
Set Task27 = ISNULL(Cast(Task27 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task27

Update #report
Set Task28 = ISNULL(Cast(Task28 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task28

Update #report
Set Task29 = ISNULL(Cast(Task29 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task29


Update #report
Set Task30 = ISNULL(Cast(Task30 as varchar(100)) COLLATE database_default, '') + '-' + ISNULL(JOB_TRAFFIC_DET.EMP_CODE, '') + '-' + Cast(JOB_TRAFFIC_DET.SEQ_NBR as varchar(5))
From #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
Where JOB_TRAFFIC_DET.FNC_CODE = @Task30		

END

--don't filter
if @StatusCodes<>''
begin
 SELECT @sql = 'Select ProjectStartDate as [Job Start Date],
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
   order by ' + @Sort1 + ',' + @Sort2
   
   SELECT @paramlist = '@Sort1 varchar(100), @Sort2 varchar(100), @StatusCodes varchar(4000)'

	EXEC sp_executesql @sql, @paramlist, @Sort1, @Sort2, @StatusCodes 
	
	PRINT @sql
end
else
begin
	SELECT @sql = 'Select ProjectStartDate as [Job Start Date],
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
   order by ' + @Sort1 + ',' + @Sort2
						

SELECT @paramlist = '@Sort1 varchar(100), @Sort2 varchar(100)'

EXEC sp_executesql @sql, @paramlist, @Sort1, @Sort2 
	
PRINT @sql   		
   
   		
   	  
end
drop table #report

SET QUOTED_IDENTIFIER ON 
