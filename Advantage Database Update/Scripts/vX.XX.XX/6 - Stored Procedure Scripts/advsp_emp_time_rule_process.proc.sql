CREATE PROCEDURE [dbo].[advsp_emp_time_rule_process] @process_yr smallint, @process_mo tinyint, @ret_val integer OUTPUT, @user_id varchar(100)
AS
SET NOCOUNT ON

 /* IS USED IN .Net AT THIS POINT - \AdvantageFramework\Database\Procedures\EmployeeView.vb */

-- Identify the current Advantage user
IF ISNULL(@user_id, '') > '' BEGIN
	SET @user_id = UPPER(@user_id)
END
ELSE BEGIN
	SET @user_id = ''
	--SELECT @user_id = UPPER(dbo.78())
END

SELECT @user_id 

DECLARE @process_date_str varchar(10), @process_date smalldatetime, @last_id integer

SET @ret_val = 0

SET @process_date_str = ( CAST( @process_yr AS varchar(4)) + '-' + CAST( @process_mo AS varchar(2)) + '-01' )

IF( ISDATE( @process_date_str ) = 1 )
	SET @process_date = CAST( @process_date_str AS smalldatetime )
ELSE
	SET @ret_val = -1
		
IF ( @ret_val = 0 )
BEGIN
	-- Get each employee and their TIME_RULE_ID
		 SELECT trh.TIME_RULE_ID,
				trd.TIME_RULE_DTL_ID,
				e.EMP_CODE, 
				DATEADD( dd, -1, e.EMP_DATE ) AS EMP_DATE, 
				e.EMP_TERM_DATE,
				e.VAC_FROM_DATE AS FROM_DATE, 
				e.VAC_TO_DATE AS TO_DATE,
				trh.NON_PROD_TYPE, 
				COALESCE( e.VAC_HRS, 0 ) AS HRS_TO_DATE, 
				CAST( NULL AS decimal( 9, 3 )) AS HRS_USED,
				dbo.advfn_get_service_months( DATEADD( dd, -1, e.EMP_DATE ), @process_date ) AS SERVICE_MONTHS,
				CAST( NULL AS integer ) AS SERVICE_YRS,
				CAST( NULL AS smallint ) AS SERVICE_RMNDR,
				CAST( NULL AS decimal( 9, 3 )) AS AFTER_HRS,
				COALESCE( trd.HOURS_TO_APPLY, 0.000 ) AS HOURS_TO_APPLY, 
				trd.MIN_YEARS, 
				trh.EQUAL_QUALIFIES, 
				trd.MAXIMUM_HOURS, 
				trh.INCLUDE_HOURS_USED,
				trh.APPEND_REPLACE,
				trh.COUNT_SERVICE_THRU
		   INTO #emp_time_rule
		   FROM dbo.EMPLOYEE e 
	 INNER JOIN dbo.TIME_RULE_HDR trh 
			 ON ( trh.TIME_RULE_ID = e.VAC_TIME_RULE_ID 
				 OR ( e.VAC_TIME_RULE_ID IS NULL AND trh.DEFAULT_RULE = 1 )) 
	 INNER JOIN dbo.TIME_RULE_DTL trd
			 ON ( trd.TIME_RULE_ID = trh.TIME_RULE_ID )
		  WHERE trh.NON_PROD_TYPE = 1
			AND trh.INACTIVE_FLAG = 0
			AND trd.INACTIVE_FLAG = 0
	   ORDER BY e.EMP_CODE ASC, trh.TIME_RULE_ID ASC, trd.MIN_YEARS DESC
   
	INSERT INTO #emp_time_rule ( TIME_RULE_ID, TIME_RULE_DTL_ID, EMP_CODE, EMP_DATE, EMP_TERM_DATE, 
								 FROM_DATE, TO_DATE, NON_PROD_TYPE, HRS_TO_DATE, HRS_USED, SERVICE_MONTHS, 
								 SERVICE_YRS, SERVICE_RMNDR, AFTER_HRS, HOURS_TO_APPLY, MIN_YEARS, EQUAL_QUALIFIES, 
								 MAXIMUM_HOURS, INCLUDE_HOURS_USED, APPEND_REPLACE, COUNT_SERVICE_THRU )
		 SELECT trh.TIME_RULE_ID, trd.TIME_RULE_DTL_ID, e.EMP_CODE, DATEADD( dd, -1, e.EMP_DATE ), e.EMP_TERM_DATE,
				e.SICK_FROM_DATE, e.SICK_TO_DATE, trh.NON_PROD_TYPE, COALESCE( e.SICK_HRS, 0 ), NULL,	
				dbo.advfn_get_service_months( DATEADD( dd, -1, e.EMP_DATE ), @process_date ), NULL, NULL, NULL, 
				COALESCE( trd.HOURS_TO_APPLY, 0.000 ), trd.MIN_YEARS, trh.EQUAL_QUALIFIES, trd.MAXIMUM_HOURS, 
				trh.INCLUDE_HOURS_USED, trh.APPEND_REPLACE, trh.COUNT_SERVICE_THRU
		   FROM dbo.EMPLOYEE e 
	 INNER JOIN dbo.TIME_RULE_HDR trh 
			 ON ( trh.TIME_RULE_ID = e.SICK_TIME_RULE_ID 
				 OR ( e.SICK_TIME_RULE_ID IS NULL AND trh.DEFAULT_RULE = 1 )) 
	 INNER JOIN dbo.TIME_RULE_DTL trd
			 ON ( trd.TIME_RULE_ID = trh.TIME_RULE_ID )
		  WHERE trh.NON_PROD_TYPE = 2
			AND trh.INACTIVE_FLAG = 0
			AND trd.INACTIVE_FLAG = 0
	   ORDER BY e.EMP_CODE ASC, trh.TIME_RULE_ID ASC, trd.MIN_YEARS DESC

	INSERT INTO #emp_time_rule ( TIME_RULE_ID, TIME_RULE_DTL_ID, EMP_CODE, EMP_DATE, EMP_TERM_DATE, 
								 FROM_DATE, TO_DATE, NON_PROD_TYPE, HRS_TO_DATE, HRS_USED, SERVICE_MONTHS, 
								 SERVICE_YRS, SERVICE_RMNDR, AFTER_HRS, HOURS_TO_APPLY, MIN_YEARS, EQUAL_QUALIFIES, 
								 MAXIMUM_HOURS, INCLUDE_HOURS_USED, APPEND_REPLACE, COUNT_SERVICE_THRU )
		 SELECT trh.TIME_RULE_ID, trd.TIME_RULE_DTL_ID, e.EMP_CODE, DATEADD( dd, -1, e.EMP_DATE ), e.EMP_TERM_DATE,
				e.PERS_FROM_DATE, e.PERS_TO_DATE, trh.NON_PROD_TYPE, COALESCE( e.PERS_HRS, 0 ), NULL, 
				dbo.advfn_get_service_months( DATEADD( dd, -1, e.EMP_DATE ), @process_date ), NULL, NULL, NULL, 
				COALESCE( trd.HOURS_TO_APPLY, 0.000 ), trd.MIN_YEARS, trh.EQUAL_QUALIFIES, trd.MAXIMUM_HOURS, 
				trh.INCLUDE_HOURS_USED, trh.APPEND_REPLACE,	trh.COUNT_SERVICE_THRU
		   FROM dbo.EMPLOYEE e 
	 INNER JOIN dbo.TIME_RULE_HDR trh 
			 ON ( trh.TIME_RULE_ID = e.PERS_TIME_RULE_ID 
				 OR ( e.PERS_TIME_RULE_ID IS NULL AND trh.DEFAULT_RULE = 1 )) 
	 INNER JOIN dbo.TIME_RULE_DTL trd
			 ON ( trd.TIME_RULE_ID = trh.TIME_RULE_ID )
		  WHERE trh.NON_PROD_TYPE = 3
			AND trh.INACTIVE_FLAG = 0
			AND trd.INACTIVE_FLAG = 0

	UPDATE #emp_time_rule
	   SET SERVICE_YRS = SERVICE_MONTHS / 12,
		   SERVICE_RMNDR = SERVICE_MONTHS % 12
     
	-- Get rid of non-qualifying rows
	DELETE FROM #emp_time_rule
	 WHERE ( SERVICE_MONTHS < ( MIN_YEARS * 12 ))

	DELETE FROM #emp_time_rule
	 WHERE ( EQUAL_QUALIFIES = 0 )
	   AND ( SERVICE_MONTHS = ( MIN_YEARS * 12 )) 
	   
	DELETE FROM #emp_time_rule
	 WHERE YEAR( EMP_TERM_DATE ) < @process_yr       

	DELETE FROM #emp_time_rule
	 WHERE YEAR( EMP_TERM_DATE ) = @process_yr
	   AND MONTH( EMP_TERM_DATE ) < @process_mo      

	DELETE FROM #emp_time_rule
	 WHERE YEAR( EMP_DATE ) > @process_yr       

	DELETE FROM #emp_time_rule
	 WHERE YEAR( EMP_DATE ) = @process_yr
	   AND MONTH( EMP_DATE ) > @process_mo      

   DELETE FROM #emp_time_rule
	  WHERE EXISTS ( SELECT *
					   FROM #emp_time_rule etr
					  WHERE etr.TIME_RULE_ID = #emp_time_rule.TIME_RULE_ID
						AND etr.EMP_CODE = #emp_time_rule.EMP_CODE 
						AND etr.MIN_YEARS > #emp_time_rule.MIN_YEARS )

	-- Retain only the highest hours to apply within each time rule
	--DELETE FROM #emp_time_rule
	--	  WHERE EXISTS ( SELECT *
	--					   FROM #emp_time_rule etr
	--					  WHERE etr.TIME_RULE_ID = #emp_time_rule.TIME_RULE_ID
	--						AND etr.EMP_CODE = #emp_time_rule.EMP_CODE 
	--						AND etr.HOURS_TO_APPLY > #emp_time_rule.HOURS_TO_APPLY )

	UPDATE #emp_time_rule
	   SET HRS_USED = ( COALESCE( 
	   				  ( SELECT SUM( etn.EMP_HOURS )
	                      FROM dbo.EMP_TIME_NP etn
					INNER JOIN dbo.EMP_TIME et 
							ON et.ET_ID = etn.ET_ID
						   AND et.EMP_CODE = #emp_time_rule.EMP_CODE 
					INNER JOIN dbo.TIME_CATEGORY tc 
							ON tc.CATEGORY = etn.CATEGORY
						   AND tc.VAC_SICK_FLAG = #emp_time_rule.NON_PROD_TYPE
	                     WHERE ( et.EMP_DATE BETWEEN #emp_time_rule.FROM_DATE AND #emp_time_rule.TO_DATE )), 0.00 ))
                             
	-- Replace
	UPDATE #emp_time_rule
	   SET AFTER_HRS = HOURS_TO_APPLY
	 WHERE APPEND_REPLACE <> 1

	-- Accrue (no maximum limit)
	UPDATE #emp_time_rule
	   SET AFTER_HRS = ( HRS_TO_DATE + HOURS_TO_APPLY )
	 WHERE APPEND_REPLACE = 1
 	   AND AFTER_HRS IS NULL
	   AND MAXIMUM_HOURS IS NULL

	-- Accrue (well under maximum)
	UPDATE #emp_time_rule
	   SET AFTER_HRS = ( HRS_TO_DATE + HOURS_TO_APPLY ) 
	 WHERE APPEND_REPLACE = 1
	   AND AFTER_HRS IS NULL
	   AND MAXIMUM_HOURS IS NOT NULL	    
	   AND (( HRS_TO_DATE + HOURS_TO_APPLY ) <= ( MAXIMUM_HOURS + HRS_USED ))   

	-- Accrue (over/slightly under maximum)
	UPDATE #emp_time_rule
	   SET AFTER_HRS = ( MAXIMUM_HOURS + HRS_USED )   
	 WHERE APPEND_REPLACE = 1
	   AND AFTER_HRS IS NULL
	   AND MAXIMUM_HOURS IS NOT NULL	    
	   AND (( HRS_TO_DATE + HOURS_TO_APPLY ) > ( MAXIMUM_HOURS + HRS_USED ))

		UPDATE dbo.EMPLOYEE_CLOAK
		   SET VAC_HRS = ( etr.AFTER_HRS )
		  FROM dbo.EMPLOYEE_CLOAK ec 
	INNER JOIN #emp_time_rule etr 
			ON ( ec.EMP_CODE = etr.EMP_CODE ) 
		   AND ( etr.NON_PROD_TYPE = 1 )
	 
		UPDATE dbo.EMPLOYEE_CLOAK
		   SET SICK_HRS = ( etr.AFTER_HRS )
		  FROM dbo.EMPLOYEE_CLOAK ec 
	INNER JOIN #emp_time_rule etr 
			ON ( ec.EMP_CODE = etr.EMP_CODE ) 
		   AND ( etr.NON_PROD_TYPE = 2 )

		UPDATE dbo.EMPLOYEE_CLOAK
		   SET PERS_HRS = ( etr.AFTER_HRS )
		  FROM dbo.EMPLOYEE_CLOAK ec 
	INNER JOIN #emp_time_rule etr 
			ON ( ec.EMP_CODE = etr.EMP_CODE ) 
		   AND ( etr.NON_PROD_TYPE = 3 )
		   
	INSERT INTO dbo.TIME_RULE_LOG ( PROCESSED_BY, PROCESS_MONTH, PROCESS_YEAR )
		 SELECT @user_id, @process_mo, @process_yr
		 
	SET @last_id = @@IDENTITY
	
	INSERT INTO dbo.TIME_RULE_ITEM_LOG ( TIME_RULE_LOG_ID, TIME_RULE_ID, TIME_RULE_DTL_ID, 
										 EMP_CODE, HOURS_BEFORE, HOURS_AFTER, HOURS_USED )
	     SELECT @last_id, TIME_RULE_ID, TIME_RULE_DTL_ID, EMP_CODE, HRS_TO_DATE, AFTER_HRS, HRS_USED
	       FROM #emp_time_rule
	
	  SELECT * 
		FROM #emp_time_rule
	ORDER BY NON_PROD_TYPE ASC, EMP_CODE ASC, TIME_RULE_ID ASC, MIN_YEARS DESC

	DROP TABLE #emp_time_rule	
END		

GO