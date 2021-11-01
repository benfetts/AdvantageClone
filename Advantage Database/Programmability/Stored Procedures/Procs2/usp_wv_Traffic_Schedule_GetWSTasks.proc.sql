


CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetWSTasks]
	@JobNumber INT,
	@JobCompNumber INT,
	@USER_ID AS VARCHAR(100),
	@EMP_CODE AS VARCHAR(6),
	@TASK_CODE AS VARCHAR(10),
	@ROLE_CODE AS VARCHAR(6),
	@IncludeCompletedTasks as Char(1),
	@IncludeOnlyPendingTasks as Char(1),
	@ExcludeProjectedTasks as Char(1),
	@CUT_OFF_DATE AS VARCHAR(15) = NULL,
	@PHASE_FILTER AS VARCHAR(50)  = ''
	
AS
DECLARE 
        @Rescrictions INT,
		@sql NVARCHAR(4000),
		@sql2 NVARCHAR(4000),
		@paramlist NVARCHAR(4000),
		@paramlist2 NVARCHAR(4000),
		@USE_VIEW SMALLINT
		
		IF DATALENGTH(@EMP_CODE) > 0-- OR DATALENGTH(@TASK_CODE) > 0 OR DATALENGTH(@ROLE_CODE) > 0 
		    BEGIN
		        SET @USE_VIEW = 1
		    END
		ELSE
		    BEGIN
		        SET @USE_VIEW = 0
		    END

CREATE TABLE #report( 	
	JobNumber		INT NULL,
	JobDescription		VARCHAR(100),
	JobCompNumber		INT NULL, 
	JobCompDescription	VARCHAR(100),
	Task		  VARCHAR(10),
	TaskDescription VARCHAR(40),
	TaskStartDate SMALLDATETIME,
	OriginalJobDueDate	  SMALLDATETIME,
	JobDueDate	  SMALLDATETIME,
	JobCompletedDate  SMALLDATETIME,
	EmpCode VARCHAR(6),
	SeqNum INT,
	FncComments	 TEXT
	) 	

IF @USE_VIEW = 0
    BEGIN
                SELECT @sql = 'INSERT INTO #report 
				                SELECT   
					                JOB_LOG.JOB_NUMBER,
						                JOB_LOG.JOB_DESC,
						                JOB_COMPONENT.JOB_COMPONENT_NBR,
						                JOB_COMPONENT.JOB_COMP_DESC, JOB_TRAFFIC_DET.FNC_CODE, JOB_TRAFFIC_DET.TASK_DESCRIPTION,
						                JOB_TRAFFIC_DET.TASK_START_DATE, JOB_TRAFFIC_DET.JOB_DUE_DATE, JOB_TRAFFIC_DET.JOB_REVISED_DATE, JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,
						                JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.SEQ_NBR, NULL
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
					                INNER JOIN JOB_TRAFFIC_DET
						                ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER
						                AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
					                INNER JOIN JOB_TRAFFIC
						                ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
						                AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
							                INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
					                INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
					                LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE			
					                WHERE
										   JOB_TRAFFIC_DET.JOB_NUMBER = @JobNumber AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobCompNumber'
									IF DATALENGTH(@TASK_CODE) > 0 
										BEGIN
											SELECT @sql = @sql + ' AND JOB_TRAFFIC_DET.FNC_CODE = @TASK_CODE'
										END	
									IF DATALENGTH(@ROLE_CODE) > 0 
										BEGIN
											SELECT @sql = @sql + ' AND JOB_TRAFFIC_DET.TRF_ROLE = @ROLE_CODE'
										END   
									IF @IncludeOnlyPendingTasks = 'Y'
										BEGIN
											SELECT @sql = @sql + ' AND JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL'
											SET @IncludeCompletedTasks = 'N'
										END								
									IF @IncludeCompletedTasks = 'N'
										BEGIN
											SELECT @sql = @sql + ' AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL'
										END	
									IF @ExcludeProjectedTasks = 'Y'
										BEGIN
											SELECT @sql = @sql + ' AND (JOB_TRAFFIC_DET.TASK_STATUS <> ''P'' OR JOB_TRAFFIC_DET.TASK_STATUS IS NULL)'
										END	    
									IF DATALENGTH(@CUT_OFF_DATE) > 0
										BEGIN
											SELECT @sql = @sql + ' AND (NOT (JOB_TRAFFIC_DET.JOB_REVISED_DATE IS NULL)) AND (JOB_TRAFFIC_DET.JOB_REVISED_DATE <= CONVERT(DATETIME, ''' + @CUT_OFF_DATE +   ' 23:59:00'', 102)) '
										END		

                                    IF @PHASE_FILTER = 'is_null'
                                    BEGIN
		                                    SELECT @sql = @sql + ' AND JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID IS NULL '
                                    END
                                    IF ISNUMERIC(@PHASE_FILTER) = 1
                                    BEGIN
		                                    SELECT @sql = @sql + ' AND JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = ' + @PHASE_FILTER
                                    END
										
													
				                    SELECT @sql = @sql + ' GROUP BY 
						                JOB_LOG.JOB_NUMBER,
						                JOB_LOG.JOB_DESC,
						                JOB_COMPONENT.JOB_COMPONENT_NBR,
						                JOB_COMPONENT.JOB_COMP_DESC,
						                JOB_TRAFFIC_DET.FNC_CODE,
					                    JOB_TRAFFIC_DET.TASK_DESCRIPTION,
						                JOB_TRAFFIC_DET.TASK_START_DATE, 
						                JOB_TRAFFIC_DET.JOB_DUE_DATE, 
						                JOB_TRAFFIC_DET.JOB_REVISED_DATE, 
						                JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,JOB_TRAFFIC_DET.EMP_CODE, JOB_TRAFFIC_DET.SEQ_NBR, JOB_TRAFFIC_DET.JOB_ORDER
					                ORDER BY 
					                JOB_TRAFFIC_DET.JOB_ORDER ASC, JOB_TRAFFIC_DET.JOB_REVISED_DATE ASC, JOB_TRAFFIC_DET.SEQ_NBR ASC'
                SELECT @paramlist = '@JobNumber int, @JobCompNumber int, @TASK_CODE VARCHAR(10), @ROLE_CODE VARCHAR(6)'
                EXEC sp_executesql @sql, @paramlist, @JobNumber, @JobCompNumber, @TASK_CODE, @ROLE_CODE   
    END
ELSE
    BEGIN
 
                SELECT @sql = 'INSERT INTO #report 
				                SELECT   
					                JOB_LOG.JOB_NUMBER,
						                JOB_LOG.JOB_DESC,
						                JOB_COMPONENT.JOB_COMPONENT_NBR,
						                JOB_COMPONENT.JOB_COMP_DESC, V_JOB_TRAFFIC_DET.FNC_CODE, V_JOB_TRAFFIC_DET.TASK_DESCRIPTION,
						                V_JOB_TRAFFIC_DET.TASK_START_DATE, V_JOB_TRAFFIC_DET.JOB_DUE_DATE, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,
						                V_JOB_TRAFFIC_DET.EMP_CODE, V_JOB_TRAFFIC_DET.SEQ_NBR, NULL
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
					                INNER JOIN V_JOB_TRAFFIC_DET
						                ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
						                AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
					                INNER JOIN JOB_TRAFFIC
						                ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
						                AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
							                INNER JOIN TRAFFIC ON TRAFFIC.TRF_CODE = JOB_TRAFFIC.TRF_CODE
					                INNER JOIN EMPLOYEE ON JOB_COMPONENT.EMP_CODE = EMPLOYEE.EMP_CODE 
					                LEFT OUTER JOIN JOB_TYPE ON JOB_COMPONENT.JT_CODE = JOB_TYPE.JT_CODE
					                LEFT OUTER JOIN
									TASK_TRAFFIC_ROLE  WITH(NOLOCK)ON V_JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE LEFT OUTER JOIN
									EMP_TRAFFIC_ROLE  WITH(NOLOCK)ON V_JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE			
					                WHERE
										   V_JOB_TRAFFIC_DET.JOB_NUMBER = @JobNumber AND V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JobCompNumber
										   AND V_JOB_TRAFFIC_DET.EMP_CODE = @EMP_CODE'
									IF DATALENGTH(@TASK_CODE) > 0 
										BEGIN
											SELECT @sql = @sql + ' AND V_JOB_TRAFFIC_DET.FNC_CODE = @TASK_CODE'
										END	
									IF DATALENGTH(@ROLE_CODE) > 0 
										BEGIN
											SELECT @sql = @sql + ' AND TASK_TRAFFIC_ROLE.ROLE_CODE = @ROLE_CODE'
										END 		
									IF @IncludeCompletedTasks = 'N'
										BEGIN
											SELECT @sql = @sql + ' AND V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL'
										END	
									IF @IncludeOnlyPendingTasks = 'Y'
										BEGIN
											SELECT @sql = @sql + ' AND V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL'
										END											
									IF @ExcludeProjectedTasks = 'Y'
										BEGIN
											SELECT @sql = @sql + ' AND (V_JOB_TRAFFIC_DET.TASK_STATUS <> ''P'' OR V_JOB_TRAFFIC_DET.TASK_STATUS IS NULL)' 
										END	    
									IF DATALENGTH(@CUT_OFF_DATE) > 0
										BEGIN
											SELECT @sql = @sql + ' AND (NOT (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE IS NULL)) AND (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE <= CONVERT(DATETIME, ''' + @CUT_OFF_DATE +   ' 23:59:00'', 102)) '
										END			


                                    IF @PHASE_FILTER = 'is_null'
                                    BEGIN
		                                    SELECT @sql = @sql + ' AND V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID IS NULL '
                                    END
                                    IF ISNUMERIC(@PHASE_FILTER) = 1
                                    BEGIN
		                                    SELECT @sql = @sql + ' AND V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = ' + @PHASE_FILTER
                                    END
										


				                    SELECT @sql = @sql + ' GROUP BY 
						                JOB_LOG.JOB_NUMBER,
						                JOB_LOG.JOB_DESC,
						                JOB_COMPONENT.JOB_COMPONENT_NBR,
						                JOB_COMPONENT.JOB_COMP_DESC,
						                V_JOB_TRAFFIC_DET.FNC_CODE,
					                    V_JOB_TRAFFIC_DET.TASK_DESCRIPTION,
						                V_JOB_TRAFFIC_DET.TASK_START_DATE, 
						                V_JOB_TRAFFIC_DET.JOB_DUE_DATE, 
						                V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, 
						                V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,V_JOB_TRAFFIC_DET.EMP_CODE, V_JOB_TRAFFIC_DET.SEQ_NBR, V_JOB_TRAFFIC_DET.JOB_ORDER
					                ORDER BY 
					                V_JOB_TRAFFIC_DET.JOB_ORDER, V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, V_JOB_TRAFFIC_DET.SEQ_NBR'
                SELECT @paramlist = '@JobNumber int, @JobCompNumber int, @EMP_CODE VARCHAR(6), @TASK_CODE VARCHAR(10), @ROLE_CODE VARCHAR(6)'
                EXEC sp_executesql @sql, @paramlist, @JobNumber, @JobCompNumber, @EMP_CODE, @TASK_CODE, @ROLE_CODE    
    
    
    END
						
PRINT @sql
				
	

UPDATE #report
SET FncComments = JOB_TRAFFIC_DET.FNC_COMMENTS
FROM #report
	INNER JOIN JOB_TRAFFIC_DET
	    ON #report.JobNumber = JOB_TRAFFIC_DET.JOB_NUMBER
	    AND #report.JobCompNumber = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
		AND #report.SeqNum = JOB_TRAFFIC_DET.SEQ_NBR



SELECT 
    JobNumber,
	JobDescription,
	JobCompNumber,
	JobCompDescription,
	Task,
	TaskDescription,
	TaskStartDate,	
	OriginalJobDueDate,
	JobDueDate,
	JobCompletedDate,
	EmpCode,
	SeqNum,
	FncComments	
FROM 
    #report
   
DROP TABLE #report


