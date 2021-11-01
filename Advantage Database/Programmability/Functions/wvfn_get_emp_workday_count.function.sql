

CREATE FUNCTION [dbo].[wvfn_get_emp_workday_count]
(
	@EMP_CODE    VARCHAR(6),
	@START_DATE  SMALLDATETIME,
	@END_DATE    SMALLDATETIME,
	@ALLOW_ZERO  BIT
)
RETURNS INT
AS
BEGIN

	DECLARE @TOTAL_DAYS        INT,
	        @CURR_DATE         SMALLDATETIME,
	        @CURR_DAY_OF_WEEK  INT,
	        @CTR               INT,
	        @WORKING_DAYS      INT
	        
    SET @START_DATE = CONVERT(
			       DATETIME,
			       CONVERT(CHAR(10), DATEPART(yyyy, @START_DATE), 101) 
			       +
			       '-' +
			       CONVERT(CHAR(10), DATEPART(mm, @START_DATE), 101) +
			       '-' +
			       CONVERT(CHAR(10), DATEPART(dd, @START_DATE), 101) +
			       ' 00:00:00' 
			       );
	        
	SET @END_DATE = CONVERT(
				   DATETIME,
				   CONVERT(CHAR(10), DATEPART(yyyy, @END_DATE), 101) 
				   +
				   '-' +
				   CONVERT(CHAR(10), DATEPART(mm, @END_DATE), 101) +
				   '-' +
				   CONVERT(CHAR(10), DATEPART(dd, @END_DATE), 101) +
				   ' 23:59:59' 
				   ) 
				   
	SET @TOTAL_DAYS = DATEDIFF(DAY, @START_DATE, @END_DATE)
	SET @CURR_DATE = @START_DATE
	SET @CTR = 0
	SET @WORKING_DAYS = 0
	WHILE @TOTAL_DAYS > 0
	BEGIN
		
--		--PRINT @CTR
		SET @CURR_DATE = DATEADD(DAY, @CTR , @START_DATE)
--		--PRINT @CURR_DATE
	    SET @CURR_DAY_OF_WEEK = DATEPART(weekday, @CURR_DATE)
--	    --PRINT @CURR_DAY_OF_WEEK
	    IF (
	           @CURR_DAY_OF_WEEK = 1
	           AND EXISTS (
	                   SELECT EMP_CODE
	                   FROM   EMPLOYEE WITH(NOLOCK)
	                   WHERE  EMP_CODE = @EMP_CODE
	                          AND EMP_WORK_DAYS LIKE '%Sun%'
	               )
	       )
	       AND (
	               NOT EXISTS(
	                   SELECT NON_TASK_ID
	                   FROM   EMP_NON_TASKS WITH(NOLOCK)
	                   WHERE  TYPE = 'H'
                            AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
                            AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
                            AND ALL_DAY = 1
	               )
	       )
	       AND (
	               NOT EXISTS(
						SELECT     EMP_NON_TASKS.NON_TASK_ID
						FROM         EMP_NON_TASKS WITH (NOLOCK) INNER JOIN
						TIME_CATEGORY WITH (NOLOCK) ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
						WHERE 
							(TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
							AND (EMP_NON_TASKS.EMP_CODE = @EMP_CODE)
							AND TYPE = 'A'
							AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
							AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
							AND ALL_DAY = 1	               
							)
	       )
	    BEGIN
	    	----PRINT 'YES '+CAST(@CURR_DATE AS VARCHAR(50))
	        SET @WORKING_DAYS = @WORKING_DAYS + 1
	    END
	    
	    IF (
	           @CURR_DAY_OF_WEEK = 2
	           AND EXISTS (
	                   SELECT EMP_CODE
	                   FROM   EMPLOYEE WITH(NOLOCK)
	                   WHERE  EMP_CODE = @EMP_CODE
	                          AND EMP_WORK_DAYS LIKE '%Mon%'
	               )
	       )
	       AND (
	               NOT EXISTS(
	                   SELECT NON_TASK_ID
	                   FROM   EMP_NON_TASKS WITH(NOLOCK)
	                   WHERE  TYPE = 'H'
                            AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
                            AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
                            AND ALL_DAY = 1
	               )
	           )
	       AND (
	               NOT EXISTS(
						SELECT     EMP_NON_TASKS.NON_TASK_ID
						FROM         EMP_NON_TASKS WITH (NOLOCK) INNER JOIN
						TIME_CATEGORY WITH (NOLOCK) ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
						WHERE 
							(TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
							AND (EMP_NON_TASKS.EMP_CODE = @EMP_CODE)
							AND TYPE = 'A'
							AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
							AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
							AND ALL_DAY = 1	               
							)
	       )
	    BEGIN
	    	----PRINT 'YES '+CAST(@CURR_DATE AS VARCHAR(50))
	        SET @WORKING_DAYS = @WORKING_DAYS + 1
	    END
	    
	    IF (
	           @CURR_DAY_OF_WEEK = 3
	           AND EXISTS (
	                   SELECT EMP_CODE
	                   FROM   EMPLOYEE WITH(NOLOCK)
	                   WHERE  EMP_CODE = @EMP_CODE
	                          AND EMP_WORK_DAYS LIKE '%Tue%'
	               )
	       )
	       AND (
	               NOT EXISTS(
	                   SELECT NON_TASK_ID
	                   FROM   EMP_NON_TASKS WITH(NOLOCK)
	                   WHERE  TYPE = 'H'
                            AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
                            AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
                            AND ALL_DAY = 1
	               )
	           )
	       AND (
	               NOT EXISTS(
						SELECT     EMP_NON_TASKS.NON_TASK_ID
						FROM         EMP_NON_TASKS WITH (NOLOCK) INNER JOIN
						TIME_CATEGORY WITH (NOLOCK) ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
						WHERE 
							(TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
							AND (EMP_NON_TASKS.EMP_CODE = @EMP_CODE)
							AND TYPE = 'A'
							AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
							AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
							AND ALL_DAY = 1	               
							)
	       )
	    BEGIN
	    	----PRINT 'YES '+CAST(@CURR_DATE AS VARCHAR(50))
	        SET @WORKING_DAYS = @WORKING_DAYS + 1
	    END
	    
	    IF (
	           @CURR_DAY_OF_WEEK = 4
	           AND EXISTS (
	                   SELECT EMP_CODE
	                   FROM   EMPLOYEE WITH(NOLOCK)
	                   WHERE  EMP_CODE = @EMP_CODE
	                          AND EMP_WORK_DAYS LIKE '%Wed%'
	               )
	       )
	       AND (
	               NOT EXISTS(
	                   SELECT NON_TASK_ID
	                   FROM   EMP_NON_TASKS WITH(NOLOCK)
	                   WHERE  TYPE = 'H'
                            AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
                            AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
                            AND ALL_DAY = 1
	               )
	           )
	       AND (
	               NOT EXISTS(
						SELECT     EMP_NON_TASKS.NON_TASK_ID
						FROM         EMP_NON_TASKS WITH (NOLOCK) INNER JOIN
						TIME_CATEGORY WITH (NOLOCK) ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
						WHERE 
							(TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
							AND (EMP_NON_TASKS.EMP_CODE = @EMP_CODE)
							AND TYPE = 'A'
							AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
							AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
							AND ALL_DAY = 1	               
							)
	       )
	    BEGIN
	    	----PRINT 'YES '+CAST(@CURR_DATE AS VARCHAR(50))
	        SET @WORKING_DAYS = @WORKING_DAYS + 1
	    END
	    
	    IF (
	           @CURR_DAY_OF_WEEK = 5
	           AND EXISTS (
	                   SELECT EMP_CODE
	                   FROM   EMPLOYEE WITH(NOLOCK)
	                   WHERE  EMP_CODE = @EMP_CODE
	                          AND EMP_WORK_DAYS LIKE '%Thu%'
	               )
	       )
	       AND (
	               NOT EXISTS(
	                   SELECT NON_TASK_ID
	                   FROM   EMP_NON_TASKS WITH(NOLOCK)
	                   WHERE  TYPE = 'H'
                            AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
                            AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
                            AND ALL_DAY = 1
	               )
	           )
	       AND (
	               NOT EXISTS(
						SELECT     EMP_NON_TASKS.NON_TASK_ID
						FROM         EMP_NON_TASKS WITH (NOLOCK) INNER JOIN
						TIME_CATEGORY WITH (NOLOCK) ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
						WHERE 
							(TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
							AND (EMP_NON_TASKS.EMP_CODE = @EMP_CODE)
							AND TYPE = 'A'
							AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
							AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
							AND ALL_DAY = 1	               
							)
	       )
	    BEGIN
	    	----PRINT 'YES '+CAST(@CURR_DATE AS VARCHAR(50))
	        SET @WORKING_DAYS = @WORKING_DAYS + 1
	    END
	    
	    IF (
	           @CURR_DAY_OF_WEEK = 6
	           AND EXISTS (
	                   SELECT EMP_CODE
	                   FROM   EMPLOYEE WITH(NOLOCK)
	                   WHERE  EMP_CODE = @EMP_CODE
	                          AND EMP_WORK_DAYS LIKE '%Fri%'
	               )
	       )
	       AND (
	               NOT EXISTS(
	                   SELECT NON_TASK_ID
	                   FROM   EMP_NON_TASKS WITH(NOLOCK)
	                   WHERE  TYPE = 'H'
                            AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
                            AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
                            AND ALL_DAY = 1
	               )
	           )
	       AND (
	               NOT EXISTS(
						SELECT     EMP_NON_TASKS.NON_TASK_ID
						FROM         EMP_NON_TASKS WITH (NOLOCK) INNER JOIN
						TIME_CATEGORY WITH (NOLOCK) ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
						WHERE 
							(TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
							AND (EMP_NON_TASKS.EMP_CODE = @EMP_CODE)
							AND TYPE = 'A'
							AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
							AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
							AND ALL_DAY = 1	               
							)
	       )
	    BEGIN
	    	----PRINT 'YES '+CAST(@CURR_DATE AS VARCHAR(50))
	        SET @WORKING_DAYS = @WORKING_DAYS + 1
	    END
	    
	    IF (
	           @CURR_DAY_OF_WEEK = 7
	           AND EXISTS (
	                   SELECT EMP_CODE
	                   FROM   EMPLOYEE WITH(NOLOCK)
	                   WHERE  EMP_CODE = @EMP_CODE
	                          AND EMP_WORK_DAYS LIKE '%Sat%'
	               )
	       )
	       AND (
	               NOT EXISTS(
	                   SELECT NON_TASK_ID
	                   FROM   EMP_NON_TASKS WITH(NOLOCK)
	                   WHERE  TYPE = 'H'
                            AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
                            AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
                            AND ALL_DAY = 1
	               )
	           )
	       AND (
	               NOT EXISTS(
						SELECT     EMP_NON_TASKS.NON_TASK_ID
						FROM         EMP_NON_TASKS WITH (NOLOCK) INNER JOIN
						TIME_CATEGORY WITH (NOLOCK) ON EMP_NON_TASKS.CATEGORY = TIME_CATEGORY.CATEGORY
						WHERE 
							(TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
							AND (EMP_NON_TASKS.EMP_CODE = @EMP_CODE)
							AND TYPE = 'A'
							AND DATEPART(dayofyear,@CURR_DATE) BETWEEN DATEPART(dayofyear,[START_DATE]) AND DATEPART(dayofyear,[END_DATE]) 
							AND DATEPART(yy,[START_DATE]) = DATEPART(yy,@CURR_DATE)
							AND ALL_DAY = 1	               
							)
	       )
	    BEGIN
	    	----PRINT 'YES '+CAST(@CURR_DATE AS VARCHAR(50))
			SET @WORKING_DAYS = @WORKING_DAYS + 1
	    END		
		SET @CTR = @CTR + 1
	    SET @TOTAL_DAYS = @TOTAL_DAYS - 1
	END
	
	
	
	
	IF @WORKING_DAYS = 0
	   AND @ALLOW_ZERO = 0
	BEGIN
	    SET @WORKING_DAYS = 1
	END
	




	RETURN @WORKING_DAYS
END
