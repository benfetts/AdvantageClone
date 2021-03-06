SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_qva_Campaign]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_qva_Campaign]
GO


CREATE PROCEDURE [dbo].[usp_wv_dto_qva_Campaign] 
@AE VARCHAR(MAX), 
@client VARCHAR(MAX), 
@division VARCHAR(MAX), 
@product VARCHAR(MAX), 
@TimeOnly Char(1),
@UserID VARCHAR(100),
@Search as VARCHAR(500),
@DO as VARCHAR(3),
@office VARCHAR(MAX),
@salesclass VARCHAR(MAX),
@manager VARCHAR(MAX),
@job VARCHAR(MAX),
@comp VARCHAR(MAX),
@campaign VARCHAR(MAX),
@group VARCHAR(10),
@quotetype VARCHAR(10)
AS
/*=========== QUERY ===========*/

	/* VARIABLES =====================================================================================================================================================================*/
	BEGIN
		DECLARE 
			@sql VARCHAR(MAX),
			@sql_from VARCHAR(MAX),
			@sql_where VARCHAR(MAX),
			@sql_groupby VARCHAR(MAX),
			@CLIENT_RESTRICTIONS INT,
			@OFFICE_RESTRICTIONS INT, 
			@Records INT, 
			@COUNT INT, 
			@jobnum INT, 
			@compnum INT, 
			@EMP_CODE VARCHAR(6),
			@QvaBreakoutAllNB VARCHAR(6),
			@QvaBreakoutNBForFT VARCHAR(6),
			@QvaBreakoutEmpTime VARCHAR(6),
			@QvaBreakoutIncomeOnly VARCHAR(6),
			@QvaBreakoutVendor VARCHAR(6),
			@ExcludeCA VARCHAR(6),
			@ExcludeIA VARCHAR(6),
			@InclClosedJobs VARCHAR(6),
			@ProcessingAll VARCHAR(6),
			@SalesTax VARCHAR(6),
			@LimitToMyJobs VARCHAR(6),
			@EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT,
			@APP_VARS_APPLICATION VARCHAR(15)
	END

	/* GET SECURITY SETTINGS =========================================================================================================================================================*/
	BEGIN
		SELECT @CLIENT_RESTRICTIONS = COUNT(*) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID);
		SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = UPPER(@UserID);
		SELECT @OFFICE_RESTRICTIONS = COUNT(*) FROM EMP_OFFICE WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE;
		SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EMP_CODE, 7); 
	END

	/* GET USER SETTINGS COMMON TO BOTH THE "MY" AND "ALL" OBJECTS ===================================================================================================================*/
	BEGIN
		SELECT @QvaBreakoutAllNB = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'QvaFilterBreakoutAllNB' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = 'QVA';
		IF @QvaBreakoutAllNB IS NULL OR @QvaBreakoutAllNB = ''
		BEGIN
			SET @QvaBreakoutAllNB = 'False'
		END
		SELECT @QvaBreakoutNBForFT = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'QvaFilterBreakoutNBForFT' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = 'QVA';
		IF @QvaBreakoutNBForFT IS NULL OR @QvaBreakoutNBForFT = ''
		BEGIN
			SET @QvaBreakoutNBForFT = 'False'
		END
		SELECT @QvaBreakoutEmpTime = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'QvaFilterEmployeeTime' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = 'QVA';
		IF @QvaBreakoutEmpTime IS NULL OR @QvaBreakoutEmpTime = ''
		BEGIN
			SET @QvaBreakoutEmpTime = 'False'
		END
		SELECT @QvaBreakoutIncomeOnly = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'QvaFilterIncomeOnly' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = 'QVA';
		IF @QvaBreakoutIncomeOnly IS NULL OR @QvaBreakoutIncomeOnly = ''
		BEGIN
			SET @QvaBreakoutIncomeOnly = 'False'
		END
		SELECT @QvaBreakoutVendor = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'QvaFilterVendor' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = 'QVA';
		IF @QvaBreakoutVendor IS NULL OR @QvaBreakoutVendor = ''
		BEGIN
			SET @QvaBreakoutVendor = 'False'
		END
	END

	/* GET USER SETTINGS THAT ARE SPECIFIC TO THE OBJECT =============================================================================================================================*/
	BEGIN
		IF @DO = 'All'
		BEGIN
	
			SET @APP_VARS_APPLICATION = 'ALL_QVA_DTO'
	
		END
		ELSE
		BEGIN
	
			SET @APP_VARS_APPLICATION = 'MY_QVA_DTO'
	
		END

		IF @DO = 'MyAll'
		BEGIN
			SET @DO = 'All'
		END

	SELECT @ExcludeCA = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'ExcludeCA' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = @APP_VARS_APPLICATION;
	IF @ExcludeCA IS NULL OR @ExcludeCA = ''
	BEGIN
		SET @ExcludeCA = 'False'
	END
	SELECT @ExcludeIA = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'ExcludeIA' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = @APP_VARS_APPLICATION;
	IF @ExcludeIA IS NULL OR @ExcludeIA = ''
	BEGIN
		SET @ExcludeIA = 'False'
	END
	SELECT @InclClosedJobs = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'InclClosedJobs' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = @APP_VARS_APPLICATION;
	IF @InclClosedJobs IS NULL OR @InclClosedJobs = ''
	BEGIN
		SET @InclClosedJobs = 'False'
	END
	SELECT @ProcessingAll = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'ProcessingAll' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = @APP_VARS_APPLICATION;
	IF @ProcessingAll IS NULL OR @ProcessingAll = ''
	BEGIN
		SET @ProcessingAll = 'False'
	END
	SELECT @SalesTax = VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'SalesTax' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = @APP_VARS_APPLICATION;
	IF @SalesTax IS NULL OR @SalesTax = ''
	BEGIN
		SET @SalesTax = 'False'
	END
	SELECT @LimitToMyJobs= VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE VARIABLE_NAME = 'LimitMyJobs' AND UPPER(USERID) = UPPER(@UserID) AND [APPLICATION] = @APP_VARS_APPLICATION;
	IF @LimitToMyJobs IS NULL OR @LimitToMyJobs = ''
	BEGIN
		SET @LimitToMyJobs = 'False'
	END
	END

	/* CREATE TEMP TABLES ============================================================================================================================================================*/
	BEGIN
	/* MAIN TABLE FOR DATA COLLECTION ================================================================================================================================================*/
	CREATE TABLE #QVA( 	
		CLI_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DIV_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PRD_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_ID				INT NULL,
		CMP_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_NAME			VARCHAR(128)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JOB_NUMBER			INT NULL,
		JOB_DESC			VARCHAR(100)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JOB_COMPONENT_NBR	SMALLINT NULL,
		JOB_COMP_DESC		VARCHAR(100)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		QUOTED				DECIMAL (14,2) NULL,
		ACTUAL				DECIMAL (14,2) NULL,
		QUOTED_HRS			DECIMAL(15,2) NULL,
		ACTUAL_HRS			DECIMAL(15,2) NULL,
		PERCENT_QUOTED      DECIMAL(15,2) NULL,
		FIRST_USE_DATE		DATETIME,
		TRAFFIC_STATUS		VARCHAR(30)
		);
	/* TABLE NEEDED TO ADD BACK IN RECORDS BASED ON DYNAMIC MANAGEMENT LEVELS FOR MY OBJECT DEF. ONLY USED ON "MY" OBJECT ============================================================*/
	CREATE TABLE #QVA_ALL( 	
		CLI_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DIV_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PRD_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CDP					VARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_ID				INT NULL,
		CMP_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_NAME			VARCHAR(128)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Campaign			VARCHAR(500)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Job					VARCHAR(500)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JobComp				VARCHAR(500)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JobAndComp			VARCHAR(2000)   COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		QUOTED				DECIMAL (14,2) NULL,
		ACTUAL				DECIMAL (14,2) NULL,
		JOB_NUMBER			INT NULL,
		JOB_COMPONENT_NBR	SMALLINT NULL,
		QUOTED_HRS			DECIMAL(15,2) NULL,
		ACTUAL_HRS			DECIMAL(15,2) NULL,
		PERCENT_QUOTED      DECIMAL(15,2) NULL,
		PERCENT_QUOTED_AMT      DECIMAL(15,2) NULL,
		FIRST_USE_DATE		DATETIME,
		TRAFFIC_STATUS		VARCHAR(30)
		);
	/* TABLE TO RETURN DATA TO AVOID HAVING TO GO INTO EVERY SINGLE INSERT STATEMENT WHEN USING MY OBJECT DEF ========================================================================*/
	CREATE TABLE #QVA_RETURN( 	
		CLI_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DIV_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		PRD_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CDP					VARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_ID				INT NULL,
		CMP_CODE			VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		CMP_NAME			VARCHAR(128)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Campaign			VARCHAR(500)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		Job					VARCHAR(500)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JobComp				VARCHAR(500)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		JobAndComp			VARCHAR(2000)   COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		QUOTED				DECIMAL (14,2) NULL,
		ACTUAL				DECIMAL (14,2) NULL,
		JOB_NUMBER			INT NULL,
		JOB_COMPONENT_NBR	SMALLINT NULL,
		QUOTED_HRS			DECIMAL(15,2) NULL,
		ACTUAL_HRS			DECIMAL(15,2) NULL,
		PERCENT_QUOTED      DECIMAL(15,2) NULL,
		PERCENT_QUOTED_AMT      DECIMAL(15,2) NULL,
		FIRST_USE_DATE		DATETIME,
		TRAFFIC_STATUS		VARCHAR(30)
		);
	/* TABLES FOR JOB/COMP LISTS =====================================================================================================================================================*/
	CREATE TABLE #jobs(
		RowID INT IDENTITY(1, 1), 
		listpos INT,
		job INT
		);
	CREATE TABLE #comps(
		RowID INT IDENTITY(1, 1), 
		listpos INT,
		comp INT
		);
	CREATE TABLE #jobcomps(
		RowID INT IDENTITY(1,1),
		Job INT,
		Comp INT
	);
	END

	/* SETUP LIST TABLES =============================================================================================================================================================*/
	BEGIN
	IF @job <> '' AND @comp <> ''
	BEGIN
	
		INSERT INTO #jobs 
		SELECT * FROM [dbo].[charlist_to_table] (
		  @job,',');

		INSERT INTO #comps 
		SELECT * FROM [dbo].[charlist_to_table] (
		  @comp,',');

		SELECT @Records = COUNT(*) FROM #jobs;
		SET @COUNT = 1;

		WHILE @COUNT <= @Records
		BEGIN
		
			SELECT @jobnum = job
			FROM #jobs
			WHERE RowID = @COUNT;

			SELECT @compnum = comp
			FROM #comps
			WHERE RowID = @COUNT;

			INSERT INTO #jobcomps (Job, Comp)
			VALUES (@jobnum,@compnum);

			SET @COUNT = @COUNT + 1	;
			
		END

	END
	END

	/* BEING PRIMARY DATA INSERTS ====================================================================================================================================================*/
	BEGIN
	BEGIN

	SET @sql = '				INSERT INTO #QVA
								SELECT  
									JOB_LOG.CL_CODE, 
									JOB_LOG.DIV_CODE, 
									JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,
									EMP_TIME_DTL.JOB_NUMBER, 
									JOB_LOG.JOB_DESC, 
									EMP_TIME_DTL.JOB_COMPONENT_NBR, 
								JOB_COMPONENT.JOB_COMP_DESC, 0,';
								
	IF @SalesTax = 'True'
	BEGIN
	
		SET @sql = @sql + ' SUM(EMP_TIME_DTL.LINE_TOTAL), ';
		
	END		
	ELSE
	BEGIN
	
		SET @sql = @sql + ' SUM(EMP_TIME_DTL.LINE_TOTAL) - (SUM(EXT_STATE_RESALE) + SUM(EXT_COUNTY_RESALE) + SUM(EXT_CITY_RESALE)), ';
		
	END		
		
	SET @sql = @sql + ' 0, ISNULL(SUM(EMP_TIME_DTL.EMP_HOURS), 0.00),0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION ';		
	SET @sql_from = ' FROM 
						JOB_LOG WITH(NOLOCK)
						INNER JOIN EMP_TIME_DTL WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER
						INNER JOIN JOB_COMPONENT WITH(NOLOCK) ON EMP_TIME_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER  
						AND EMP_TIME_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN JOB_TRAFFIC WITH(NOLOCK) ON 
						JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
						LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE 
						LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER ';
						
	IF @ExcludeCA = 'True'
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN ESTIMATE_APPROVAL WITH(NOLOCK) ON 
										JOB_COMPONENT.JOB_NUMBER = ESTIMATE_APPROVAL.JOB_NUMBER 
										AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_APPROVAL.JOB_COMPONENT_NBR ';

	END	
	IF @ExcludeIA = 'True'
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN ESTIMATE_INT_APPR WITH(NOLOCK) ON 
										JOB_COMPONENT.JOB_NUMBER = ESTIMATE_INT_APPR.JOB_NUMBER 
										AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_INT_APPR.JOB_COMPONENT_NBR '
	END	
	IF @client <> ''
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default';
		
	END	  
	IF @division <> ''
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default';
		
	END	  	
	IF @product <> ''
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default';
		
	END	  
	IF @AE <> ''  AND @DO = 'All'
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default';
		
	END	  
	IF @office <> '' AND @DO = 'All'
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default';
		
	END  
	IF @salesclass <> ''  AND @DO = 'All'
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default';
		
	END	 
	IF @manager <> ''  AND @DO = 'All'
	BEGIN
	
		SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j 
										ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default ';
	
	END
	IF @job <> '' AND @comp = ''
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default';
		
	END	 		  	  	  			   
	IF @job <> '' AND @comp <> ''
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR';
		
	END
	IF @campaign <> ''
	BEGIN
	
		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default';
		
	END
	
	--SELECT @ProcessingAll
	--SELECT @InclClosedJobs

	SET @sql_where = ' WHERE (EMP_TIME_DTL.EDIT_FLAG <> 1 OR EMP_TIME_DTL.EDIT_FLAG IS NULL) ';
	
	IF @ProcessingAll = 'True'
	BEGIN
	
		SET @sql_where = @sql_where + ' AND (JOB_COMPONENT.JOB_PROCESS_CONTRL = 1) ';
		
	END	
	
	IF @InclClosedJobs = 'False' AND @ProcessingAll = 'False'
	BEGIN
	
		SET @sql_where = @sql_where + ' AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)) ) ';
		
	END
	
	IF @QvaBreakoutAllNB = 'True' or (@QvaBreakoutNBForFT = 'True' AND @QvaBreakoutEmpTime = 'True')
	BEGIN
	
		SET @sql_where = @sql_where + ' AND (EMP_TIME_DTL.EMP_NON_BILL_FLAG = 0) ';
		
    END
    
	IF @CLIENT_RESTRICTIONS > 0
	BEGIN
	
	  SET @sql_from = @sql_from + '		INNER JOIN SEC_CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
										AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
										AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE ';
										
	  SET @sql_where = @sql_where +  '	AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') 
										AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) ';
	  
	END
	
	IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
	
		SET @sql_from = @sql_from + '	INNER JOIN EMP_OFFICE WITH(NOLOCK) ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE 
										AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

	SET @sql = @sql + @sql_from + @sql_where

	SET @sql = @sql + '					GROUP BY 
											JOB_LOG.CL_CODE, 
											JOB_LOG.DIV_CODE, 
											JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,
											EMP_TIME_DTL.JOB_NUMBER, 
											JOB_LOG.JOB_DESC, 
											EMP_TIME_DTL.JOB_COMPONENT_NBR, 
											JOB_COMPONENT.JOB_COMP_DESC, 
											JOB_COMPONENT.JOB_FIRST_USE_DATE, 
											TRAFFIC.TRF_DESCRIPTION ';
											
	PRINT (@sql);
	EXEC(@sql);	

	END
    
	BEGIN
	IF @TimeOnly <> 'E'
		BEGIN
		
			SET @sql = '	INSERT INTO #QVA
							SELECT JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, INCOME_ONLY.JOB_NUMBER, JOB_LOG.JOB_DESC, INCOME_ONLY.JOB_COMPONENT_NBR, 
							JOB_COMPONENT.JOB_COMP_DESC, 0,';
							
			IF @SalesTax = 'True'
			BEGIN
			
				SET @sql = @sql + ' SUM(INCOME_ONLY.LINE_TOTAL), ';
				
			END		
			ELSE
			BEGIN
			
				SET @sql = @sql + ' SUM(INCOME_ONLY.LINE_TOTAL) - (SUM(EXT_STATE_RESALE) + SUM(EXT_COUNTY_RESALE) + SUM(EXT_CITY_RESALE)),';
				
			END			
			
			SET @sql = @sql + ' 0, ISNULL(SUM(INCOME_ONLY.IO_QTY), 0.00),0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION  ';
		
			SET @sql_from = ' FROM 
								JOB_LOG WITH(NOLOCK)
								INNER JOIN INCOME_ONLY ON JOB_LOG.JOB_NUMBER = INCOME_ONLY.JOB_NUMBER
								INNER JOIN JOB_COMPONENT ON INCOME_ONLY.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER  
								AND	INCOME_ONLY.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN 
								JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
								LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER ';
								
			IF @ExcludeCA = 'True'
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN ESTIMATE_APPROVAL 
												ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_APPROVAL.JOB_NUMBER 
												AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_APPROVAL.JOB_COMPONENT_NBR ';
												
			END	
			IF @ExcludeIA = 'True'
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN ESTIMATE_INT_APPR 
												ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_INT_APPR.JOB_NUMBER 
												AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_INT_APPR.JOB_COMPONENT_NBR ';
												
			END	
			IF @client <> ''
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default ';
			END	  
			IF @division <> ''
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default ';
				
			END	  	
			IF @product <> ''
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default ';
				
			END	  
			IF @AE <> ''  AND @DO = 'All'
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default ';
				
			END	  
			IF @office <> '' AND @DO = 'All'
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default ';
				
			END  
			IF @salesclass <> ''  AND @DO = 'All' 
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default ';
				
			END	 
			IF @manager <> ''  AND @DO = 'All'
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default ';
		
			END  
			IF @job <> '' AND @comp = ''
			BEGIN
		
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default ';
		
			END	 		  	  	  	  			   
			IF @job <> '' AND @comp <> ''
			BEGIN
		
				SET @sql_from = @sql_from + '	INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR ';
		
			END
			IF @campaign <> ''
			BEGIN
		
				SET @sql_from = @sql_from + '	INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default ';
		
			END
			 
			IF @ProcessingAll = 'True'
			BEGIN
		
				SET @sql_where = ' WHERE JOB_COMPONENT.JOB_PROCESS_CONTRL = 1 ';
		
			END	
			ELSE
			BEGIN
		
				IF @InclClosedJobs = 'False'
				BEGIN
				
					SET @sql_where = ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) ';
					
				END
				ELSE
				BEGIN
				
					SET @sql_where = ' WHERE 1 = 1 ';
					
				END
		
			END	
		
			IF @QvaBreakoutAllNB = 'True' or (@QvaBreakoutNBForFT = 'True' AND @QvaBreakoutIncomeOnly = 'True')
			BEGIN
			
				SET @sql_where = @sql_where + '	AND INCOME_ONLY.NON_BILL_FLAG = 0 ';
				
			END
			
			IF @CLIENT_RESTRICTIONS > 0
			BEGIN
			
				SET @sql_from = @sql_from + '	INNER JOIN SEC_CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
												AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
												AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE ';
				SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)';
				
			END
		
			IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
			BEGIN
			
				SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE WITH(NOLOCK) ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
		
			END

			SET @sql = @sql + @sql_from + @sql_where;

			SET @sql = @sql + ' GROUP BY 
									JOB_LOG.CL_CODE, 
									JOB_LOG.DIV_CODE, 
									JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,
									INCOME_ONLY.JOB_NUMBER, 
									JOB_LOG.JOB_DESC, 
									INCOME_ONLY.JOB_COMPONENT_NBR, 
									JOB_COMPONENT.JOB_COMP_DESC, 
									JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION  ';
	
			PRINT (@sql);
			EXEC(@sql);	
		
			SET @sql = ' INSERT INTO #QVA
				SELECT     JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, AP_PRODUCTION.JOB_NUMBER, JOB_LOG.JOB_DESC, AP_PRODUCTION.JOB_COMPONENT_NBR, 
									  JOB_COMPONENT.JOB_COMP_DESC, 0,'
				IF @SalesTax = 'True'
					BEGIN
						SET @sql = @sql + ' SUM(AP_PRODUCTION.LINE_TOTAL),'
					END		
				ELSE
					BEGIN
						SET @sql = @sql + ' SUM(AP_PRODUCTION.LINE_TOTAL) - (SUM(EXT_STATE_RESALE) + SUM(EXT_COUNTY_RESALE) + SUM(EXT_CITY_RESALE)),'
					END			
				SET @sql = @sql + ' 0, ISNULL(SUM(AP_PRODUCTION.AP_PROD_QUANTITY), 0.00),0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION  '    
			
			SET @sql_from = ' FROM  JOB_LOG 
					INNER JOIN AP_PRODUCTION ON JOB_LOG.JOB_NUMBER = AP_PRODUCTION.JOB_NUMBER
					INNER JOIN JOB_COMPONENT ON AP_PRODUCTION.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER  
						   AND AP_PRODUCTION.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN 
									JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
									LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER '
			IF @ExcludeCA = 'True'
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN ESTIMATE_APPROVAL ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_APPROVAL.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_APPROVAL.JOB_COMPONENT_NBR'
				END	
			IF @ExcludeIA = 'True'
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN ESTIMATE_INT_APPR ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_INT_APPR.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_INT_APPR.JOB_COMPONENT_NBR'
				END		
			IF @client <> ''
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default'
				END	  
			IF @division <> ''
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default'
				END	  	
			IF @product <> ''
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default'
				END	  
			IF @AE <> ''  AND @DO = 'All'
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
				END	  
			IF @office <> '' AND @DO = 'All'
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
				END  
			IF @salesclass <> ''  AND @DO = 'All'
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default'
				END	 
			IF @manager <> ''  AND @DO = 'All'
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
				END  
			IF @job <> '' AND @comp = ''
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
				END	 		  	  	  	  			   
			IF @job <> '' AND @comp <> ''
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
				END	
			IF @campaign <> ''
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
				END  	 		   
					   
			IF @ProcessingAll = 'True'
				BEGIN
					SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
				END	
			ELSE
				BEGIN
					IF @InclClosedJobs = 'False'
						BEGIN
							SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
						END
					ELSE
						BEGIN
							SET @sql_where = ' Where 1=1 '
						END
				END		
		
			IF @QvaBreakoutAllNB = 'True' or (@QvaBreakoutNBForFT = 'True' AND @QvaBreakoutVendor = 'True')
				SET @sql_where = @sql_where + ' AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 0'
  
			IF @CLIENT_RESTRICTIONS > 0
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
								AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
								AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
					SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				END
			
			IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
				SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

			SET @sql = @sql + @sql_from + @sql_where

			SET @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, AP_PRODUCTION.JOB_NUMBER, JOB_LOG.JOB_DESC, AP_PRODUCTION.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION  '
			PRINT (@sql)
			EXEC(@sql)
			
			--Advance Billing
			--SET @sql = ' INSERT INTO #QVA
			--	SELECT     JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, ADVANCE_BILLING.JOB_NUMBER, JOB_LOG.JOB_DESC, ADVANCE_BILLING.JOB_COMPONENT_NBR, 
			--						  JOB_COMPONENT.JOB_COMP_DESC, 0,'
			--	IF @SalesTax = 'True'
			--		BEGIN
			--			SET @sql = @sql + ' SUM(ADVANCE_BILLING.LINE_TOTAL),'
			--		END		
			--	ELSE
			--		BEGIN
			--			SET @sql = @sql + ' SUM(ADVANCE_BILLING.LINE_TOTAL) - (SUM(EXT_STATE_RESALE) + SUM(EXT_COUNTY_RESALE) + SUM(EXT_CITY_RESALE)),'
			--		END			
			--	SET @sql = @sql + ' 0,0,0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION  '    
			
			--SET @sql_from = ' FROM  JOB_LOG 
			--		INNER JOIN ADVANCE_BILLING ON JOB_LOG.JOB_NUMBER = ADVANCE_BILLING.JOB_NUMBER
			--		INNER JOIN JOB_COMPONENT ON ADVANCE_BILLING.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER  
			--			   AND ADVANCE_BILLING.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN 
			--						JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
			--						LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE '
			--IF @ExcludeCA = 'True'
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN ESTIMATE_APPROVAL ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_APPROVAL.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_APPROVAL.JOB_COMPONENT_NBR'
			--	END	
			--IF @ExcludeIA = 'True'
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN ESTIMATE_INT_APPR ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_INT_APPR.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_INT_APPR.JOB_COMPONENT_NBR'
			--	END		
			--IF @client <> ''
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default'
			--	END	  
			--IF @division <> ''
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default'
			--	END	  	
			--IF @product <> ''
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default'
			--	END	  
			--IF @AE <> ''  AND @DO = 'All'
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
			--	END	  
			--IF @office <> '' AND @DO = 'All'
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
			--	END  
			--IF @salesclass <> ''  AND @DO = 'All'
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default'
			--	END	 
			--IF @manager <> ''  AND @DO = 'All'
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
			--	END  
			--IF @job <> '' AND @comp = ''
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
			--	END	 		  	  	  	  			   
			--IF @job <> '' AND @comp <> ''
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
			--	END	
			--IF @campaign <> ''
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
			--	END  	 		   
					   
			--IF @ProcessingAll = 'True'
			--	BEGIN
			--		SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
			--	END	
			--ELSE
			--	BEGIN
			--		IF @InclClosedJobs = 'False'
			--			BEGIN
			--				SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
			--			END
			--		ELSE
			--			BEGIN
			--				SET @sql_where = ' Where (ADVANCE_BILLING.AR_INV_NBR IS NOT NULL OR ADVANCE_BILLING.AB_FLAG = 3)  '
			--			END
			--	END		
		
			----IF @QvaBreakoutAllNB = 'True' or (@QvaBreakoutNBForFT = 'True' AND @QvaBreakoutVendor = 'True')
			----	SET @sql_where = @sql_where + ' AND AP_PRODUCTION.AP_PROD_NOBILL_FLG = 0'
  
			--IF @CLIENT_RESTRICTIONS > 0
			--	BEGIN
			--		SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
			--					AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
			--					AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
			--		SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			--	END
			
			--IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
			--	SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

			--SET @sql = @sql + @sql_from + @sql_where

			--SET @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, ADVANCE_BILLING.JOB_NUMBER, JOB_LOG.JOB_DESC, ADVANCE_BILLING.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION  '
			--PRINT (@sql)
			--EXEC(@sql)	

		END
	END
	
	if @quotetype = 'job'
	Begin
		--Jobs with Client or Internal Approvals
		BEGIN
	
		IF @ExcludeCA = 'True' AND @ExcludeIA = 'True'
			BEGIN
				SET @sql = 'INSERT INTO #QVA
				SELECT  JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,ESTIMATE_APPROVAL.JOB_NUMBER, 
						JOB_LOG.JOB_DESC, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										ESTIMATE_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR INNER JOIN
										JOB_LOG ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
										JOB_COMPONENT ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
										ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN 
										JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
										LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER '	
				IF @ExcludeIA = 'True'
					BEGIN
					  SET @sql_from = @sql_from + ' INNER JOIN ESTIMATE_INT_APPR ON JOB_COMPONENT.JOB_NUMBER = ESTIMATE_INT_APPR.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = ESTIMATE_INT_APPR.JOB_COMPONENT_NBR'
					END	 	
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				IF @AE <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
					END	  
				IF @office <> '' AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
					END  
				IF @salesclass <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				IF @manager <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
					END  
				IF @job <> '' AND @comp = ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
					END	 		  	  	  	  			   
				IF @job <> '' AND @comp <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
					END	
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END  	  	 
						
				IF @ProcessingAll = 'True'
					BEGIN
						SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
					END	
				ELSE
					BEGIN
						IF @InclClosedJobs = 'False'
							BEGIN
								SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
							END
						ELSE
							BEGIN
								SET @sql_where = ' Where 1=1 '
							END
					END	

				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''

			   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
	
				IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
					SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,ESTIMATE_APPROVAL.JOB_NUMBER, JOB_LOG.JOB_DESC, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '
				PRINT(@sql)
				EXEC(@sql)	
			END
		ELSE IF @ExcludeCA = 'True' AND @ExcludeIA = 'False'
			BEGIN
				SET @sql = 'INSERT INTO #QVA
				SELECT  JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, ESTIMATE_APPROVAL.JOB_NUMBER, 
						JOB_LOG.JOB_DESC, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										ESTIMATE_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR INNER JOIN
										JOB_LOG ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
										JOB_COMPONENT ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
										ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
										JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
										LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER '	
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				IF @AE <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
					END	  
				IF @office <> '' AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
					END  
				IF @salesclass <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				IF @manager <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
					END  
				IF @job <> '' AND @comp = ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
					END	 		    	  	  			   
				IF @job <> '' AND @comp <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
					END  
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END	  	 
						
				IF @ProcessingAll = 'True'
					BEGIN
						SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
					END	
				ELSE
					BEGIN
						IF @InclClosedJobs = 'False'
							BEGIN
								SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
							END
						ELSE
							BEGIN
								SET @sql_where = ' Where 1=1 '
							END
					END	

				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''

			   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
	
				IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
					SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,ESTIMATE_APPROVAL.JOB_NUMBER, JOB_LOG.JOB_DESC, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '
				PRINT(@sql)
				EXEC(@sql)	

			END
		ELSE IF @ExcludeCA = 'False' AND @ExcludeIA = 'True'
			BEGIN
				SET @sql = 'INSERT INTO #QVA
						SELECT  JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,ESTIMATE_INT_APPR.JOB_NUMBER, 
								JOB_LOG.JOB_DESC, ESTIMATE_INT_APPR.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										ESTIMATE_INT_APPR ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_INT_APPR.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_INT_APPR.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_INT_APPR.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_INT_APPR.EST_REVISION_NBR INNER JOIN
										JOB_LOG ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
										JOB_COMPONENT ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
										ESTIMATE_INT_APPR.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN 
										JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR 
										LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER '		
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				IF @AE <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
					END	  
				IF @office <> '' AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
					END  
				IF @salesclass <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				IF @manager <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
					END  
				IF @job <> '' AND @comp = ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
					END	 		  	  	  	  			   
				IF @job <> '' AND @comp <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
					END	 
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END 	  	 
						
				IF @ProcessingAll = 'True'
					BEGIN
						SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
					END	
				ELSE
					BEGIN
						IF @InclClosedJobs = 'False'
							BEGIN
								SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
							END
						ELSE
							BEGIN
								SET @sql_where = ' Where 1 = 1 '
							END
					END	

				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''

			   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
	
				IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
					SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, ESTIMATE_INT_APPR.JOB_NUMBER, JOB_LOG.JOB_DESC, ESTIMATE_INT_APPR.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '
	
				PRINT(@sql)
				EXEC(@sql)	

			END
		ELSE
			BEGIN

				SET @sql = 'INSERT INTO #QVA
				SELECT  JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, ESTIMATE_APPROVAL.JOB_NUMBER, 
						JOB_LOG.JOB_DESC, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										ESTIMATE_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR INNER JOIN
										JOB_LOG ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
										JOB_COMPONENT ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
										ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN 
										JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR 
										LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER '		
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				IF @AE <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
					END	  
				IF @office <> '' AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
					END  
				IF @salesclass <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				IF @manager <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
					END  
				IF @job <> '' AND @comp = ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
					END	 		    	  	  			   
				IF @job <> '' AND @comp <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
					END  
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END	  	 				
				IF @ProcessingAll = 'True'
					BEGIN
						SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
					END	
				ELSE
					BEGIN
						IF @InclClosedJobs = 'False'
							BEGIN
								SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
							END
						ELSE
							BEGIN
								SET @sql_where = ' Where 1=1 '
							END
					END		
				IF @TimeOnly <> ''
				BEGIN
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''
				END			   
				IF @CLIENT_RESTRICTIONS > 0
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
										AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
										AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
					SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				END	
				IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
					SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,ESTIMATE_APPROVAL.JOB_NUMBER, JOB_LOG.JOB_DESC, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '
				PRINT(@sql)
				EXEC(@sql)	

				SET @sql = 'INSERT INTO #QVA
						SELECT  JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,ESTIMATE_INT_APPR.JOB_NUMBER, 
								JOB_LOG.JOB_DESC, ESTIMATE_INT_APPR.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										ESTIMATE_INT_APPR ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_INT_APPR.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_INT_APPR.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_INT_APPR.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_INT_APPR.EST_REVISION_NBR INNER JOIN
										JOB_LOG ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
										JOB_COMPONENT ON ESTIMATE_INT_APPR.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
										ESTIMATE_INT_APPR.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN 
										JOB_TRAFFIC ON JOB_TRAFFIC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
										LEFT OUTER JOIN TRAFFIC WITH(NOLOCK) ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER '		
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON JOB_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON JOB_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON JOB_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				IF @AE <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
					END	  
				IF @office <> '' AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
					END  
				IF @salesclass <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON JOB_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				IF @manager <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
					END  
				IF @job <> '' AND @comp = ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
					END	 		  	  	  			   
				IF @job <> '' AND @comp <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
					END	  
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON JOB_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END	 				
				IF @ProcessingAll = 'True'
					BEGIN
						SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1 AND 
						(CAST(ESTIMATE_INT_APPR.JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(ESTIMATE_INT_APPR.JOB_COMPONENT_NBR AS VARCHAR(3)) NOT IN (SELECT CAST(JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(JOB_COMPONENT_NBR AS VARCHAR(3)) FROM ESTIMATE_APPROVAL)) '
					END	
				ELSE
					BEGIN
						IF @InclClosedJobs = 'False'
							BEGIN
								SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND 
						(CAST(ESTIMATE_INT_APPR.JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(ESTIMATE_INT_APPR.JOB_COMPONENT_NBR AS VARCHAR(3)) NOT IN (SELECT CAST(JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(JOB_COMPONENT_NBR AS VARCHAR(3)) FROM ESTIMATE_APPROVAL)) '
							END
						ELSE
							BEGIN
								SET @sql_where = ' Where 1=1 AND 
						(CAST(ESTIMATE_INT_APPR.JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(ESTIMATE_INT_APPR.JOB_COMPONENT_NBR AS VARCHAR(3)) NOT IN (SELECT CAST(JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(JOB_COMPONENT_NBR AS VARCHAR(3)) FROM ESTIMATE_APPROVAL)) '
							END
					END	
				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''	   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
				IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
					SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, JOB_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME,ESTIMATE_INT_APPR.JOB_NUMBER, JOB_LOG.JOB_DESC, ESTIMATE_INT_APPR.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_COMPONENT.JOB_FIRST_USE_DATE, TRAFFIC.TRF_DESCRIPTION '

				PRINT(@sql)
				EXEC(@sql)	
		
			END	

		END
	End
	if @quotetype = 'campaign'
	Begin
		--Campaigns with Client or Internal Approvals
		BEGIN
	
		IF @ExcludeCA = 'True' AND @ExcludeIA = 'True'
			BEGIN
				SET @sql = 'INSERT INTO #QVA
				SELECT  ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE, ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, NULL, NULL, NULL, NULL,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, NULL, NULL '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										EST_CAMP_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = EST_CAMP_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = EST_CAMP_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = EST_CAMP_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = EST_CAMP_APPROVAL.EST_REVISION_NBR INNER JOIN
										ESTIMATE_LOG ON ESTIMATE_LOG.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER 
										LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = ESTIMATE_LOG.CMP_IDENTIFIER '	
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON ESTIMATE_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON ESTIMATE_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON ESTIMATE_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				--IF @AE <> ''  AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
				--	END	  
				--IF @office <> '' AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
				--	END  
				IF @salesclass <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON ESTIMATE_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				--IF @manager <> ''  AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
				--	END  
				--IF @job <> '' AND @comp = ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
				--	END	 		  	  	  	  			   
				--IF @job <> '' AND @comp <> ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
				--	END	
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON ESTIMATE_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END  	  	 
						
				--IF @ProcessingAll = 'True'
				--	BEGIN
				--		SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
				--	END	
				--ELSE
				--	BEGIN
				--		IF @InclClosedJobs = 'False'
				--			BEGIN
				--				SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
				--			END
				--		ELSE
				--			BEGIN
								SET @sql_where = ' Where EST_CAMP_APPROVAL.APPR_TYPE IN (''C'',''I'') '
				--			END
				--	END	

				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''

			   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
	
				--IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
				--	SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE, ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME '
				PRINT(@sql)
				EXEC(@sql)	
			END
		ELSE IF @ExcludeCA = 'True' AND @ExcludeIA = 'False'
			BEGIN
				SET @sql = 'INSERT INTO #QVA
				SELECT  ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE,JOB_LOG.ESTIMATE_LOG, C.CMP_CODE, C.CMP_NAME, NULL, NULL, NULL, NULL,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, NULL, NULL '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										EST_CAMP_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = EST_CAMP_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = EST_CAMP_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = EST_CAMP_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = EST_CAMP_APPROVAL.EST_REVISION_NBR INNER JOIN
										ESTIMATE_LOG ON ESTIMATE_LOG.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER 
										LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = ESTIMATE_LOG.CMP_IDENTIFIER '		
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON ESTIMATE_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON ESTIMATE_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON ESTIMATE_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				--IF @AE <> ''  AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
				--	END	  
				--IF @office <> '' AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
				--	END  
				IF @salesclass <> ''  AND @DO = 'All'
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON ESTIMATE_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				--IF @manager <> ''  AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
				--	END  
				--IF @job <> '' AND @comp = ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
				--	END	 		    	  	  			   
				--IF @job <> '' AND @comp <> ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
				--	END  
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON ESTIMATE_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END	  	 
						
				--IF @ProcessingAll = 'True'
				--	BEGIN
				--		SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
				--	END	
				--ELSE
				--	BEGIN
				--		IF @InclClosedJobs = 'False'
				--			BEGIN
				--				SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
				--			END
				--		ELSE
				--			BEGIN
								SET @sql_where = ' Where EST_CAMP_APPROVAL.APPR_TYPE IN (''C'') '
				--			END
				--	END	

				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''

			   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
	
				--IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
				--	SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE, ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME '
				PRINT(@sql)
				EXEC(@sql)	

			END
		ELSE IF @ExcludeCA = 'False' AND @ExcludeIA = 'True'
			BEGIN
				SET @sql = 'INSERT INTO #QVA
						SELECT  ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE, ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, NULL, NULL, NULL, NULL,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, NULL,NULL '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										EST_CAMP_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = EST_CAMP_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = EST_CAMP_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = EST_CAMP_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = EST_CAMP_APPROVAL.EST_REVISION_NBR INNER JOIN
										ESTIMATE_LOG ON ESTIMATE_LOG.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER 
										LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = ESTIMATE_LOG.CMP_IDENTIFIER '				
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON ESTIMATE_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON ESTIMATE_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON ESTIMATE_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				--IF @AE <> '' 
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
				--	END	  
				--IF @office <> '' AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
				--	END  
				IF @salesclass <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON ESTIMATE_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				--IF @manager <> '' 
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
				--	END  
				--IF @job <> '' AND @comp = ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
				--	END	 		  	  	  	  			   
				--IF @job <> '' AND @comp <> ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
				--	END	 
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON ESTIMATE_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END 	  	 
						
				--IF @ProcessingAll = 'True'
				--	BEGIN
				--		SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
				--	END	
				--ELSE
				--	BEGIN
				--		IF @InclClosedJobs = 'False'
				--			BEGIN
				--				SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
				--			END
				--		ELSE
				--			BEGIN
								SET @sql_where = ' Where EST_CAMP_APPROVAL.APPR_TYPE IN (''I'') '
				--			END
				--	END	

				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''

			   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
	
				--IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
				--	SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE,ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME '
	
				PRINT(@sql)
				EXEC(@sql)	

			END
		ELSE
			BEGIN

				SET @sql = 'INSERT INTO #QVA
				SELECT  ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE,ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, NULL, NULL, NULL, NULL,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, NULL, NULL '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										EST_CAMP_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = EST_CAMP_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = EST_CAMP_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = EST_CAMP_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = EST_CAMP_APPROVAL.EST_REVISION_NBR INNER JOIN
										ESTIMATE_LOG ON ESTIMATE_LOG.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER 
										LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = ESTIMATE_LOG.CMP_IDENTIFIER '			
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON ESTIMATE_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON ESTIMATE_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON ESTIMATE_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				--IF @AE <> '' 
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
				--	END	  
				--IF @office <> '' AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
				--	END  
				IF @salesclass <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON ESTIMATE_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				--IF @manager <> '' 
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
				--	END  
				--IF @job <> '' AND @comp = ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
				--	END	 		    	  	  			   
				--IF @job <> '' AND @comp <> ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
				--	END  
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON ESTIMATE_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END	  	 				
				--IF @ProcessingAll = 'True'
				--	BEGIN
				--		SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1'
				--	END	
				--ELSE
				--	BEGIN
				--		IF @InclClosedJobs = 'False'
				--			BEGIN
				--				SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) '
				--			END
				--		ELSE
				--			BEGIN
								SET @sql_where = ' Where EST_CAMP_APPROVAL.APPR_TYPE IN (''C'') '
				--			END
				--	END		
				IF @TimeOnly <> ''
				BEGIN
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''
				END			   
				IF @CLIENT_RESTRICTIONS > 0
				BEGIN
					SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
										AND ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
										AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
					SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				END	
				--IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
				--	SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE, ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME '
				PRINT(@sql)
				EXEC(@sql)	

				SET @sql = 'INSERT INTO #QVA
						SELECT  ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE, ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME, NULL, NULL, NULL, NULL,'
					IF @SalesTax = 'True'
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL),'
						END		
					ELSE
						BEGIN
							SET @sql = @sql + ' SUM(ESTIMATE_REV_DET.LINE_TOTAL) - (SUM(ESTIMATE_REV_DET.EXT_STATE_RESALE) + SUM(ESTIMATE_REV_DET.EXT_COUNTY_RESALE) + SUM(ESTIMATE_REV_DET.EXT_CITY_RESALE)),'
						END			
					SET @sql = @sql + ' 0, ISNULL(SUM(ESTIMATE_REV_DET.EST_REV_QUANTITY), 0.00), 0,0, NULL, NULL '

				SET @sql_from = ' FROM	ESTIMATE_REV_DET INNER JOIN
										EST_CAMP_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = EST_CAMP_APPROVAL.ESTIMATE_NUMBER AND 
										ESTIMATE_REV_DET.EST_COMPONENT_NBR = EST_CAMP_APPROVAL.EST_COMPONENT_NBR AND 
										ESTIMATE_REV_DET.EST_QUOTE_NBR = EST_CAMP_APPROVAL.EST_QUOTE_NBR AND 
										ESTIMATE_REV_DET.EST_REV_NBR = EST_CAMP_APPROVAL.EST_REVISION_NBR INNER JOIN
										ESTIMATE_LOG ON ESTIMATE_LOG.ESTIMATE_NUMBER = ESTIMATE_REV_DET.ESTIMATE_NUMBER 
										LEFT OUTER JOIN CAMPAIGN C ON C.CMP_IDENTIFIER = ESTIMATE_LOG.CMP_IDENTIFIER '			
				IF @client <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @client + ''', DEFAULT) d ON ESTIMATE_LOG.CL_CODE = d.vstr collate database_default'
					END	  
				IF @division <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @division + ''', DEFAULT) e ON ESTIMATE_LOG.DIV_CODE = e.vstr collate database_default'
					END	  	
				IF @product <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @product + ''', DEFAULT) f ON ESTIMATE_LOG.PRD_CODE = f.vstr collate database_default'
					END	  
				--IF @AE <> '' 
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @AE + ''', DEFAULT) g ON JOB_COMPONENT.EMP_CODE = g.vstr collate database_default'
				--	END	  
				--IF @office <> '' AND @DO = 'All'
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @office + ''', DEFAULT) n ON JOB_LOG.OFFICE_CODE = n.vstr collate database_default'
				--	END  
				IF @salesclass <> '' 
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @salesclass + ''', DEFAULT) h ON ESTIMATE_LOG.SC_CODE = h.vstr collate database_default'
					END	 
				--IF @manager <> '' 
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @manager + ''', DEFAULT) j ON JOB_TRAFFIC.MGR_EMP_CODE = j.vstr collate database_default'
				--	END  
				--IF @job <> '' AND @comp = ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @job + ''', DEFAULT) k ON JOB_LOG.JOB_NUMBER = k.vstr collate database_default'
				--	END	 		  	  	  			   
				--IF @job <> '' AND @comp <> ''
				--	BEGIN
				--		SET @sql_from = @sql_from + ' INNER JOIN #jobcomps ON #jobcomps.Job = JOB_COMPONENT.JOB_NUMBER AND #jobcomps.Comp = JOB_COMPONENT.JOB_COMPONENT_NBR'
				--	END	  
				IF @campaign <> ''
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN charlist_to_table(''' + @campaign + ''', DEFAULT) m ON ESTIMATE_LOG.CMP_IDENTIFIER = m.vstr collate database_default'
					END	 				
				--IF @ProcessingAll = 'True'
				--	BEGIN
				--		SET @sql_where = ' Where JOB_COMPONENT.JOB_PROCESS_CONTRL = 1 AND 
				--		(CAST(ESTIMATE_INT_APPR.JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(ESTIMATE_INT_APPR.JOB_COMPONENT_NBR AS VARCHAR(3)) NOT IN (SELECT CAST(JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(JOB_COMPONENT_NBR AS VARCHAR(3)) FROM ESTIMATE_APPROVAL)) '
				--	END	
				--ELSE
				--	BEGIN
				--		IF @InclClosedJobs = 'False'
				--			BEGIN
				--				SET @sql_where = ' Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND 
				--		(CAST(ESTIMATE_INT_APPR.JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(ESTIMATE_INT_APPR.JOB_COMPONENT_NBR AS VARCHAR(3)) NOT IN (SELECT CAST(JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(JOB_COMPONENT_NBR AS VARCHAR(3)) FROM ESTIMATE_APPROVAL)) '
				--			END
				--		ELSE
				--			BEGIN
								SET @sql_where = ' Where EST_CAMP_APPROVAL.APPR_TYPE IN (''I'') '
				--		(CAST(ESTIMATE_INT_APPR.JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(ESTIMATE_INT_APPR.JOB_COMPONENT_NBR AS VARCHAR(3)) NOT IN (SELECT CAST(JOB_NUMBER AS VARCHAR(6)) + ''-'' + CAST(JOB_COMPONENT_NBR AS VARCHAR(3)) FROM ESTIMATE_APPROVAL)) '
				--			END
				--	END	
				IF @TimeOnly <> ''
					SET @sql_where = @sql_where + ' AND ESTIMATE_REV_DET.EST_FNC_TYPE = ''' +  @TimeOnly + ''''	   
				IF @CLIENT_RESTRICTIONS > 0
					BEGIN
						SET @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE 
											AND ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE 
											AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE '
		    
						SET @sql_where = @sql_where +  ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					END
				--IF @OFFICE_RESTRICTIONS > 0 AND @AE = ''
				--	SET @sql_from = @sql_from + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''

				SET @sql = @sql + @sql_from + @sql_where

				SET @sql = @sql + ' GROUP BY ESTIMATE_LOG.CL_CODE, ESTIMATE_LOG.DIV_CODE, ESTIMATE_LOG.PRD_CODE, ESTIMATE_LOG.CMP_IDENTIFIER, C.CMP_CODE, C.CMP_NAME '

				PRINT(@sql)
				EXEC(@sql)	
		
			END	

		END
	End	
	END
	
	/* INSERT COLLECTED RECORDS INTO THE RETURN TABLE ================================================================================================================================*/
	BEGIN

		IF @group = 'job'
		BEGIN
			INSERT INTO #QVA_RETURN
			SELECT DISTINCT
				CLI_CODE AS CL_CODE,
				DIV_CODE,
				PRD_CODE,
				CLI_CODE + '/' +  DIV_CODE +'/' +  PRD_CODE AS CDP, 
				NULL,
				NULL,
				NULL,
				NULL,
				(RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_NUMBER),6)) + ' - ' + JOB_DESC AS Job, 
				STR(JOB_NUMBER) + ' - ' + JOB_DESC AS [JobComp],
				(RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_NUMBER),6)) + ' - ' + JOB_DESC AS [JobAndComp],
				ISNULL(SUM(QUOTED),0) AS QUOTED, 
				ISNULL(SUM(ACTUAL),0) AS ACTUAL,
				JOB_NUMBER,
				JOB_COMPONENT_NBR, 
				SUM(QUOTED_HRS) AS QUOTED_HRS, 
				SUM(ACTUAL_HRS) AS ACTUAL_HRS, 
				ISNULL((SUM(ACTUAL_HRS)/NULLIF(SUM(QUOTED_HRS),0))*100,0) AS PERCENT_QUOTED, 
				ISNULL((SUM(ACTUAL)/NULLIF(SUM(QUOTED),0))*100,0) AS PERCENT_QUOTED_AMT, 
				NULL,NULL  
			FROM 
				#QVA
			WHERE 
				LOWER(CLI_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(DIV_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(PRD_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(JOB_DESC) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(STR(JOB_NUMBER)) LIKE '%' + LOWER(@Search) + '%' 
			GROUP BY 
				CLI_CODE, 
				DIV_CODE, 
				PRD_CODE, 
				JOB_NUMBER, 
				JOB_DESC,
				JOB_COMPONENT_NBR;
		END
		ELSE IF @group = 'campaign'
		BEGIN
			INSERT INTO #QVA_RETURN
			SELECT DISTINCT
				CLI_CODE AS CL_CODE,
				DIV_CODE,
				PRD_CODE,
				CLI_CODE + '/' +  DIV_CODE + '/' +  PRD_CODE AS CDP, 
				CMP_ID,
				CMP_CODE,
				CMP_NAME,
				CMP_CODE + ' - ' + CMP_NAME AS Campaign, 
				NULL,
				NULL, 
				NULL,
				ISNULL(SUM(QUOTED),0) AS QUOTED, 
				ISNULL(SUM(ACTUAL),0) AS ACTUAL,
				NULL,
				NULL, 
				SUM(QUOTED_HRS) AS QUOTED_HRS, 
				SUM(ACTUAL_HRS) AS ACTUAL_HRS, 
				ISNULL((SUM(ACTUAL_HRS)/NULLIF(SUM(QUOTED_HRS),0))*100,0) AS PERCENT_QUOTED, 
				ISNULL((SUM(ACTUAL)/NULLIF(SUM(QUOTED),0))*100,0) AS PERCENT_QUOTED_AMT, 
				NULL,NULL  
			FROM 
				#QVA
			WHERE 
				LOWER(CLI_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(DIV_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(PRD_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(CMP_NAME) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(STR(CMP_CODE)) LIKE '%' + LOWER(@Search) + '%' 
			GROUP BY 
				CLI_CODE, 
				DIV_CODE, 
				PRD_CODE, 
				CMP_ID,
				CMP_CODE,
				CMP_NAME;
		END
		ELSE
		BEGIN
			INSERT INTO #QVA_RETURN
			SELECT DISTINCT
				CLI_CODE AS CL_CODE,
				DIV_CODE,
				PRD_CODE,
				CLI_CODE + '/' +  DIV_CODE +'/' +  PRD_CODE AS CDP, 
				CMP_ID,
				CMP_CODE,
				CMP_NAME,
				CMP_CODE + ' - ' + CMP_NAME AS Campaign, 
				STR(JOB_NUMBER) + ' - ' + JOB_DESC AS Job, 
				STR(JOB_COMPONENT_NBR) + ' - ' + JOB_COMP_DESC AS [JobComp],
				( RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), JOB_COMPONENT_NBR),2) + ' - ' + JOB_COMP_DESC ) AS [JobAndComp],
				ISNULL(SUM(QUOTED),0) AS QUOTED, 
				ISNULL(SUM(ACTUAL),0) AS ACTUAL,
				JOB_NUMBER,
				JOB_COMPONENT_NBR, 
				SUM(QUOTED_HRS) AS QUOTED_HRS, 
				SUM(ACTUAL_HRS) AS ACTUAL_HRS, 
				ISNULL((SUM(ACTUAL_HRS)/NULLIF(SUM(QUOTED_HRS),0))*100,0) AS PERCENT_QUOTED, 
				ISNULL((SUM(ACTUAL)/NULLIF(SUM(QUOTED),0))*100,0) AS PERCENT_QUOTED_AMT, 
				FIRST_USE_DATE, TRAFFIC_STATUS   
			FROM 
				#QVA
			WHERE 
				LOWER(CLI_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(DIV_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(PRD_CODE) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(JOB_DESC) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(JOB_COMP_DESC) LIKE '%' + LOWER(@Search) + '%' 
				OR LOWER(STR(JOB_NUMBER)) LIKE '%' + LOWER(@Search) + '%' 
			GROUP BY 
				CLI_CODE, 
				DIV_CODE, 
				PRD_CODE, 
				JOB_NUMBER, 
				JOB_DESC, 
				JOB_COMPONENT_NBR, 
				JOB_COMP_DESC, 
				FIRST_USE_DATE,
				TRAFFIC_STATUS,
				CMP_ID,
				CMP_CODE,
				CMP_NAME ;
		END	
					
	END

	/* WORK IN THE MY OBJ DEF AND RETURN THE DATA=====================================================================================================================================*/
	BEGIN
		--SELECT * FROM #QVA_RETURN
		DECLARE
			@RESTRICT_ALERT_GROUP BIT,
			@RESTRICT_SCHEDULE_ASSIGNMENTS BIT,
			@RESTRICT_SCHEDULE_MANAGER BIT,
			@RESTRICT_TASK_ASSIGNEES BIT,
			@RESTRICT_ACCOUNT_EXECUTIVE BIT,
			@AGENCY_MANAGER_COLUMN VARCHAR(40),
			@JOB_TRAFFIC_MANAGER_COLUMN VARCHAR(40),
			@HAS_ACTIVE_RESTRICTION BIT,
			@NEEDS_OR BIT
		
		SELECT 
			@RESTRICT_ALERT_GROUP = A.ALERT_GROUP,
			@RESTRICT_SCHEDULE_ASSIGNMENTS = A.SCHEDULE_ASSIGNMENTS,
			@RESTRICT_SCHEDULE_MANAGER = A.SCHEDULE_MANAGER,
			@RESTRICT_TASK_ASSIGNEES = A.TASK_ASSIGNEES,
			@RESTRICT_ACCOUNT_EXECUTIVE = A.ACCOUNT_EXECUTIVE,
			@AGENCY_MANAGER_COLUMN = A.AGENCY_MANAGER_COLUMN,
			@JOB_TRAFFIC_MANAGER_COLUMN = A.JOB_TRAFFIC_MANAGER_COLUMN,
			@HAS_ACTIVE_RESTRICTION = A.HAS_ACTIVE_RESTRICTION
		FROM [dbo].[fn_my_objects_get_static_restrictions](7) AS A;

		IF @DO = 'My' -- THIS IS THE PATH WHEN PROCEDURE IS CALLED FROM THE "MY QVA" OBJECT
		BEGIN

			/* DATA TO MANAGE THE UNION QUERY NEEDED FOR DYNAMIC MANAGEMENT LEVELS AS DEFINED BY MY OBJ DEF ==========================================================================*/
			INSERT INTO #QVA_ALL
			EXEC [dbo].[usp_wv_dto_qva] @AE, @client, @division, @product, @TimeOnly, @UserID, @Search, 'MyAll', @office, @salesclass, @manager, @job, @comp, @campaign, @group, @quotetype, @DO;
			
			DECLARE @QVA_ALL_UNION VARCHAR(MAX)
			SET @QVA_ALL_UNION = ''

			IF @LimitToMyJobs = 'False'
			BEGIN

				SET @QVA_ALL_UNION = @QVA_ALL_UNION + '

				UNION

				SELECT #QVA_ALL.* 
				FROM #QVA_ALL
				INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](7, ''' + @EMP_CODE + ''') AS DR
				ON #QVA_ALL.CLI_CODE = DR.CL_CODE 
				AND ((#QVA_ALL.DIV_CODE = DR.DIV_CODE) OR (#QVA_ALL.DIV_CODE IS NULL)) 
				AND ((#QVA_ALL.PRD_CODE = DR.PRD_CODE) OR (#QVA_ALL.PRD_CODE IS NULL))


				'

			END
			/* END DATA TO MANAGE THE UNION QUERY NEEDED FOR DYNAMIC MANAGEMENT LEVELS AS DEFINED BY MY OBJ DEF ======================================================================*/
			--SELECT * FROM #QVA_ALL
			IF @HAS_ACTIVE_RESTRICTION = 1
			BEGIN				
				IF @group = 'job'
				Begin
					SET @sql = 'SELECT DISTINCT CLI_CODE,DIV_CODE, PRD_CODE,CDP,Job,'''' AS JobComp,JobAndComp AS JobAndComp, SUM(QUOTED) AS QUOTED,SUM(ACTUAL) AS ACTUAL,QVA.JOB_NUMBER,0 AS JOB_COMPONENT_NBR,
								SUM(QUOTED_HRS) AS QUOTED_HRS, SUM(ACTUAL_HRS) AS ACTUAL_HRS, CAST(ISNULL((SUM(ACTUAL_HRS)/NULLIF(SUM(QUOTED_HRS),0))*100,0) AS DECIMAL(15,2)) AS PERCENT_QUOTED, 
								CAST(ISNULL((SUM(ACTUAL)/NULLIF(SUM(QUOTED),0))*100,0) AS DECIMAL(15,2)) AS PERCENT_QUOTED_AMT, NULL AS FIRST_USE_DATE, NULL AS TRAFFIC_STATUS'
					SET @sql_groupby = ' GROUP BY CLI_CODE,DIV_CODE,PRD_CODE,CDP,QVA.JOB_NUMBER,Job,JobAndComp'
				End
				Else IF @group = 'campaign'
				Begin
					SET @sql = 'SELECT DISTINCT CLI_CODE,DIV_CODE, PRD_CODE,CDP,CMP_ID,CMP_CODE,CMP_NAME,Campaign AS Campaign,NULL AS Job,'''' AS JobComp,NULL AS JobAndComp, SUM(QUOTED) AS QUOTED,SUM(ACTUAL) AS ACTUAL,0 AS JOB_NUMBER,0 AS JOB_COMPONENT_NBR,
								SUM(QUOTED_HRS) AS QUOTED_HRS, SUM(ACTUAL_HRS) AS ACTUAL_HRS, CAST(ISNULL((SUM(ACTUAL_HRS)/NULLIF(SUM(QUOTED_HRS),0))*100,0) AS DECIMAL(15,2)) AS PERCENT_QUOTED, 
								CAST(ISNULL((SUM(ACTUAL)/NULLIF(SUM(QUOTED),0))*100,0) AS DECIMAL(15,2)) AS PERCENT_QUOTED_AMT, NULL AS FIRST_USE_DATE, NULL AS TRAFFIC_STATUS'
					SET @sql_groupby = ' GROUP BY CLI_CODE,DIV_CODE,PRD_CODE,CDP,CMP_ID,CMP_CODE,CMP_NAME,Campaign'
				End
				Else
				Begin
					SET @sql = 'SELECT DISTINCT QVA.* '
				End			
				SET @sql_from =  '	FROM #QVA_RETURN AS QVA '
				SET @sql_where = '	WHERE 1 = 1 '
				SET @sql_where = @sql_where + ' AND ( ';
				SET @NEEDS_OR = 0;

				IF @RESTRICT_ACCOUNT_EXECUTIVE = 1 and @group <> 'campaign'
				BEGIN
	    
					SET @sql_from = @sql_from + ' INNER JOIN JOB_COMPONENT AS JCAE ON QVA.JOB_NUMBER = JCAE.JOB_NUMBER AND QVA.JOB_COMPONENT_NBR = JCAE.JOB_COMPONENT_NBR';

					IF @NEEDS_OR = 1
					BEGIN
				
						SET @sql_where = @sql_where + ' OR ';
					
					END	
			
					SET @sql_where = @sql_where + ' (JCAE.EMP_CODE = ''' + @EMP_CODE + ''')';    
					SET @NEEDS_OR = 1;
			
				END
				IF @RESTRICT_ALERT_GROUP = 1 and @group <> 'campaign'
				BEGIN
	    
 					SET @sql_from = @sql_from + ' INNER JOIN JOB_COMPONENT AS JC ON QVA.JOB_NUMBER = JC.JOB_NUMBER AND QVA.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  LEFT OUTER JOIN EMAIL_GROUP AS EG ON EG.EMAIL_GR_CODE = JC.EMAIL_GR_CODE
												  AND (EG.INACTIVE_FLAG = 0 OR EG.INACTIVE_FLAG IS NULL) 
												  ';

					IF @NEEDS_OR = 1
					BEGIN
				
						SET @sql_where = @sql_where + ' OR ';
					
					END	
			
					SET @sql_where = @sql_where + ' (EG.EMP_CODE = ''' + @EMP_CODE + ''') ';
					SET @NEEDS_OR = 1;
	   
				END
				IF @RESTRICT_SCHEDULE_ASSIGNMENTS = 1 and @group <> 'campaign'
				BEGIN
	    
  					SET @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC JTASN ON QVA.JOB_NUMBER = JTASN.JOB_NUMBER AND QVA.JOB_COMPONENT_NBR = JTASN.JOB_COMPONENT_NBR ';

					IF @NEEDS_OR = 1
					BEGIN
				
						SET @sql_where = @sql_where + ' OR ';
					
					END	
			
					SET @sql_where = @sql_where + ' (
													JTASN.ASSIGN_1 = ''' + @EMP_CODE + '''
													OR JTASN.ASSIGN_2 = ''' + @EMP_CODE + '''
													OR JTASN.ASSIGN_3 = ''' + @EMP_CODE + '''
													OR JTASN.ASSIGN_4 = ''' + @EMP_CODE + '''
													OR JTASN.ASSIGN_5 = ''' + @EMP_CODE + ''') ';  
					SET @NEEDS_OR = 1;
			
				END
				IF @RESTRICT_SCHEDULE_MANAGER = 1 and @group <> 'campaign'
				BEGIN
	    
  					SET @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC JTMGR ON QVA.JOB_NUMBER = JTMGR.JOB_NUMBER AND QVA.JOB_COMPONENT_NBR = JTMGR.JOB_COMPONENT_NBR ';

					IF @NEEDS_OR = 1
					BEGIN
				
						SET @sql_where = @sql_where + ' OR ';
					
					END	
			
					SET @sql_where = @sql_where + ' (JTMGR.' + @JOB_TRAFFIC_MANAGER_COLUMN + ' = ''' + @EMP_CODE + ''')';
					SET @NEEDS_OR = 1;
			    
				END
				IF @RESTRICT_TASK_ASSIGNEES = 1 and @group <> 'campaign'
				BEGIN
	    
 					SET @sql_from = @sql_from + ' INNER JOIN JOB_TRAFFIC AS JTTA ON QVA.JOB_NUMBER = JTTA.JOB_NUMBER AND QVA.JOB_COMPONENT_NBR = JTTA.JOB_COMPONENT_NBR 
 												  LEFT OUTER JOIN JOB_TRAFFIC_DET AS JTDEMPS ON JTDEMPS.JOB_NUMBER = JTTA.JOB_NUMBER  
												  AND JTDEMPS.JOB_COMPONENT_NBR = JTTA.JOB_COMPONENT_NBR
												  LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS AS JTDEEMPS ON JTDEEMPS.JOB_NUMBER = JTDEMPS.JOB_NUMBER 
												  AND JTDEEMPS.JOB_COMPONENT_NBR = JTDEMPS.JOB_COMPONENT_NBR
												  AND JTDEEMPS.SEQ_NBR = JTDEMPS.SEQ_NBR
												';
											

					IF @NEEDS_OR = 1
					BEGIN
				
						SET @sql_where = @sql_where + ' OR ';
					
					END	
			
					SET @sql_where = @sql_where + ' (JTDEEMPS.EMP_CODE = ''' + @EMP_CODE + ''') ';   
					SET @NEEDS_OR = 1;
			
				END
			
	 			SET @sql_where = @sql_where + ' ) '		

				-- FINAL SELECT FOR "MY QVA" WHEN THERE ARE STATIC MY OBJ DEF CRITERIA CHECKED, AND POSSIBLY HAS DYNAMIC MANAGEMENT LEVEL (ACCOUNT_EXECUTIVE) TABLE
				--PRINT (@sql+ @sql_from + @sql_where + @sql_groupby + @QVA_ALL_UNION);
				EXEC (@sql+ @sql_from + @sql_where + @sql_groupby + @QVA_ALL_UNION);

			END
			ELSE
			BEGIN -- ALL STATIC RESTRICTIONS UNCHECED IN MY OBJ DEF.  SO SHORT OUT THE QUERY AND RETURN ONLY THE DYNAMIC MANAGEMENT LEVEL RECORDS
				
				SET @sql = 'SELECT QVA.* '
				SET @sql_from =  '	FROM #QVA_RETURN AS QVA '
				SET @sql_where = '	WHERE 0 = 1 ' -- SHORT OUT THE QUERY BUT RETURN THE HEADER COLUMNS

				-- FINAL SELECT FOR "MY QVA" WHEN NO STATIC MY OBJ DEF CRITERIA CHECKED, BUT POSSIBLY HAS DYNAMIC MANAGEMENT LEVEL (ACCOUNT_EXECUTIVE) TABLE
				EXEC (@sql+ @sql_from + @sql_where + @QVA_ALL_UNION);

			END

		END
		ELSE
		BEGIN -- THIS IS THE PATH WHEN PROCEDURE IS CALLED FROM THE "ALL QVA" OBJECT

			IF @group = 'job'
			Begin
				SET @sql = 'SELECT DISTINCT CLI_CODE,DIV_CODE, PRD_CODE,CDP,Job,'''' AS JobComp,JobAndComp AS JobAndComp, SUM(QUOTED) AS QUOTED,SUM(ACTUAL) AS ACTUAL,QVA.JOB_NUMBER,0 AS JOB_COMPONENT_NBR,
								SUM(QUOTED_HRS) AS QUOTED_HRS, SUM(ACTUAL_HRS) AS ACTUAL_HRS, ISNULL((SUM(ACTUAL_HRS)/NULLIF(SUM(QUOTED_HRS),0))*100,0) AS PERCENT_QUOTED, 
								ISNULL((SUM(ACTUAL)/NULLIF(SUM(QUOTED),0))*100,0) AS PERCENT_QUOTED_AMT, NULL AS FIRST_USE_DATE, NULL AS TRAFFIC_STATUS'
				SET @sql_groupby = ' GROUP BY CLI_CODE,DIV_CODE,PRD_CODE,CDP,QVA.JOB_NUMBER,Job,JobAndComp'
				SET @sql_from =  '	FROM #QVA_RETURN AS QVA '
				SET @sql_where = '	WHERE 1 = 1 '
				EXEC (@sql+ @sql_from + @sql_where + @sql_groupby);
			End
			Else IF @group = 'campaign'
			Begin				
				SET @sql = 'SELECT DISTINCT CLI_CODE,DIV_CODE, PRD_CODE,CDP,CMP_ID,CMP_CODE,CMP_NAME,Campaign AS Campaign,NULL AS Job,'''' AS JobComp,NULL AS JobAndComp, SUM(QUOTED) AS QUOTED,SUM(ACTUAL) AS ACTUAL,0 AS JOB_NUMBER,0 AS JOB_COMPONENT_NBR,
								SUM(QUOTED_HRS) AS QUOTED_HRS, SUM(ACTUAL_HRS) AS ACTUAL_HRS, ISNULL((SUM(ACTUAL_HRS)/NULLIF(SUM(QUOTED_HRS),0))*100,0) AS PERCENT_QUOTED, 
								ISNULL((SUM(ACTUAL)/NULLIF(SUM(QUOTED),0))*100,0) AS PERCENT_QUOTED_AMT, NULL AS FIRST_USE_DATE, NULL AS TRAFFIC_STATUS'
				SET @sql_groupby = ' GROUP BY CLI_CODE,DIV_CODE,PRD_CODE,CDP,CMP_ID,CMP_CODE,CMP_NAME,Campaign'
				SET @sql_from =  '	FROM #QVA_RETURN AS QVA '
				SET @sql_where = '	WHERE 1 = 1 '
				PRINT(@sql);
				EXEC (@sql+ @sql_from + @sql_where + @sql_groupby);
			End
			Else
			Begin
				SET @sql = 'SELECT DISTINCT QVA.* '
				SET @sql_from =  '	FROM #QVA_RETURN AS QVA '
				SET @sql_where = '	WHERE 1 = 1 ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR'
				EXEC (@sql+ @sql_from + @sql_where);
			End			
			


			--SET @sql = 'SELECT DISTINCT QVA.* '
			--SET @sql_from =  '	FROM #QVA_RETURN AS QVA '
			--SET @sql_where = '	WHERE 1 = 1 '
			--EXEC (@sql+ @sql_from + @sql_where);

		END		
    
	END

	/* DROP TEMP TABLES ==============================================================================================================================================================*/
	BEGIN
		DROP TABLE #QVA;
		DROP TABLE #QVA_ALL;
		DROP TABLE #QVA_RETURN;
		DROP TABLE #jobs;
		DROP TABLE #comps;
		DROP TABLE #jobcomps;
	END

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO