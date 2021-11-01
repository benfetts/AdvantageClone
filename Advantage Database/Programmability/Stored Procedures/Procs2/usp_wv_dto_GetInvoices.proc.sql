SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
if exists (select * from sysobjects where id = object_id(N'[dbo].[usp_wv_dto_GetInvoices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_GetInvoices]
GO

CREATE PROCEDURE [dbo].[usp_wv_dto_GetInvoices]
@UserID VarChar(100),  
@ClientCode VarChar(6),
@OfficeCode VarChar(6),
@DivisionCode VarChar(6),
@ProductCode VarChar(6),
@Group int,
@From varchar(3),
@InvCats varchar(100)
AS
/*=========== QUERY ===========*/
	SET NOCOUNT ON

	DECLARE 
		@C1 DECIMAL,
		@C2 DECIMAL,
		@C3 DECIMAL,
		@C4 DECIMAL,
		@C5 DECIMAL,
		@Total DECIMAL,
		@Restrictions INT, 
		@Group1 INT, 
		@Group2 INT, 
		@Group3 INT, 
		@Group4 INT, 
		@Grp1 VARCHAR(10), 
		@Grp2 VARCHAR(10), 
		@Grp3 VARCHAR(10), 
		@Grp4 VARCHAR(10),
		@sql VARCHAR(8000), 
		@sqlunion VARCHAR(4000), 
		@sqlunion2 VARCHAR(4000), 
		@InvNbr INT, 
		@ArType VARCHAR(3), 
		@ArInvSeq SMALLINT,
		@paramlist NVARCHAR(4000), 
		@EmpCode VARCHAR(6), 
		@NumberRecords INT, 
		@RowCount INT, 
		@RestrictionsOffice INT,
		@APPLICATION_NAME VARCHAR(15),
		@EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT
		;
		
	 --Create First Temp Table
	CREATE TABLE #temp (
		RowID INT IDENTITY(1, 1), 
		OfficeCode	VARCHAR(4), 
		OfficeName  VARCHAR(30),
		ClientCode  VARCHAR(6),
		ClientName  VARCHAR(40),
		DivisionCode  VARCHAR(6),
		DivisionName  VARCHAR(40),
		ProductCode  VARCHAR(6),
		ProductName  VARCHAR(40),
		AROpenAmt   DECIMAL(20,2),
		InvoiceDate	DATETIME,
		InvoiceNo	INTEGER, 
		InvoiceSeq  SMALLINT, 	
		[Type] VARCHAR(1),
		SalesClassCode VARCHAR(6),
		SalesClassName VARCHAR(30),
		JobNumber INT,
		JobDesc VARCHAR(60),
		JobCompNumber INT,
		JobCompDesc VARCHAR(60),
		ARDescription VARCHAR(MAX),
		[Collection] TEXT,
		DueDate DATETIME,
		ManualInvoice INT
	);

	CREATE TABLE #temp2 ( 
		CRAmt		DECIMAL(20,2),
		InvoiceNo	INTEGER, 
		InvoiceSeq  SMALLINT 
	);

	CREATE TABLE #Invoices (
		RowID INT IDENTITY(1, 1), 
		OfficeCode	VARCHAR(4), 
		OfficeName  VARCHAR(30),
		ClientCode  VARCHAR(6),
		ClientName  VARCHAR(40),
		DivisionCode  VARCHAR(6),
		DivisionName  VARCHAR(40),
		ProductCode  VARCHAR(6),
		ProductName  VARCHAR(40),
		InvoiceAmt   DECIMAL(20,2),
		InvoiceDate	DATETIME,
		InvoiceNo	INTEGER, 
		InvoiceSeq  SMALLINT, 	
		[Type] VARCHAR(1),
		SalesClassCode VARCHAR(6),
		SalesClassName VARCHAR(30),
		JobNumber INT,
		JobDesc VARCHAR(60),
		JobCompNumber INT,
		JobCompDesc VARCHAR(60),
		ARDescription VARCHAR(MAX),
		[Collection] TEXT,
		DueDate DATETIME,
		ManualInvoice INT,
		AttachmentCount INT
	);

	--Look for Client/Division/Product security
	SELECT @Restrictions = COUNT(*) 
	FROM SEC_CLIENT WITH(NOLOCK)
	WHERE UPPER(USER_ID) = UPPER(@UserID);

	SELECT @EmpCode = EMP_CODE
	FROM SEC_USER WITH(NOLOCK)
	WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @RestrictionsOffice = COUNT(*) 
	FROM EMP_OFFICE WITH(NOLOCK)
	WHERE EMP_CODE = @EmpCode;

	SELECT @EmpCode = EMP_CODE
	FROM SEC_USER WITH(NOLOCK)
	WHERE UPPER(USER_CODE) = UPPER(@UserID);

	SELECT 
		@EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EmpCode, 3); 
	--SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS;

	IF @From = 'mca'
	BEGIN
	
		SET @APPLICATION_NAME = 'MyClientAging';
			
	END
	ELSE
	BEGIN
	
		SET @APPLICATION_NAME = 'ClientAging';
			
	END

	SELECT @Group1 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp1 = VARIABLE_VALUE
    FROM APP_VARS WITH(NOLOCK) 
    WHERE APPLICATION = @APPLICATION_NAME AND VARIABLE_NAME = 'CAGroup1' AND UPPER(USERID) = UPPER(@UserID);

    SELECT @Group2 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp2 = VARIABLE_VALUE
    FROM APP_VARS WITH(NOLOCK) 
    WHERE APPLICATION = @APPLICATION_NAME AND VARIABLE_NAME = 'CAGroup2' AND UPPER(USERID) = UPPER(@UserID);

    SELECT @Group3 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp3 = VARIABLE_VALUE
    FROM APP_VARS WITH(NOLOCK) 
    WHERE APPLICATION = @APPLICATION_NAME AND VARIABLE_NAME = 'CAGroup3' AND UPPER(USERID) = UPPER(@UserID);

    SELECT @Group4 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp4 = VARIABLE_VALUE + '+'
    FROM APP_VARS WITH(NOLOCK) 
    WHERE APPLICATION = @APPLICATION_NAME AND VARIABLE_NAME = 'CAGroup4' AND UPPER(USERID) = UPPER(@UserID);


	SET @sql = '
						INSERT INTO #temp 
						SELECT 
							ACCT_REC.OFFICE_CODE, OFFICE.OFFICE_NAME, ACCT_REC.CL_CODE, CLIENT.CL_NAME, ACCT_REC.DIV_CODE, 
							DIVISION.DIV_NAME, ACCT_REC.PRD_CODE, PRODUCT.PRD_DESCRIPTION, ACCT_REC.AR_INV_AMOUNT,
							ACCT_REC.AR_INV_DATE AS InvoiceDate,
							ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_SEQ, ACCT_REC.REC_TYPE, ACCT_REC.SC_CODE, SALES_CLASS.SC_DESCRIPTION, ACCT_REC.JOB_NUMBER, 
							JOB_LOG.JOB_DESC, ACCT_REC.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, 
							CASE 
							WHEN (NOT JOB_LOG.JOB_NUMBER IS NULL AND NOT JOB_COMPONENT.JOB_COMPONENT_NBR IS NULL) THEN ''Job: '' + RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR, JOB_LOG.JOB_NUMBER), 6) + ''/'' + RIGHT(REPLICATE(''0'',2) + CONVERT(VARCHAR, JOB_COMPONENT.JOB_COMPONENT_NBR), 2) +'' - '' + JOB_COMPONENT.JOB_COMP_DESC 
							WHEN (NOT JOB_LOG.JOB_NUMBER IS NULL AND JOB_COMPONENT.JOB_COMPONENT_NBR IS NULL) THEN ''Job: '' + RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR, JOB_LOG.JOB_NUMBER), 6) + '' - '' + JOB_LOG.JOB_DESC 
							ELSE ISNULL(ACCT_REC.AR_DESCRIPTION,''N/A'')
							END AS AR_DESCRIPTION, 
							'''',
							CASE WHEN ACCT_REC.REC_TYPE = ''P'' THEN
							CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE ELSE
							CASE WHEN CL_P_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE END
							END
							ELSE
							CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE ELSE
							CASE WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_M_PAYDAYS,  ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE END

							END	
							END AS DUE_DATE, ISNULL(MANUAL_INV,0)
						FROM   ACCT_REC WITH(NOLOCK) INNER JOIN                      
							OFFICE WITH(NOLOCK) ON ACCT_REC.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN
							SALES_CLASS WITH(NOLOCK) ON ACCT_REC.SC_CODE = SALES_CLASS.SC_CODE LEFT OUTER JOIN								  
							JOB_COMPONENT WITH(NOLOCK) ON ACCT_REC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							ACCT_REC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
							JOB_LOG WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = ACCT_REC.JOB_NUMBER LEFT OUTER JOIN
							PRODUCT WITH(NOLOCK) ON PRODUCT.CL_CODE = ACCT_REC.CL_CODE AND PRODUCT.DIV_CODE = ACCT_REC.DIV_CODE 
							AND PRODUCT.PRD_CODE = ACCT_REC.PRD_CODE LEFT OUTER JOIN
							DIVISION WITH(NOLOCK) ON ACCT_REC.CL_CODE = DIVISION.CL_CODE AND ACCT_REC.DIV_CODE = DIVISION.DIV_CODE LEFT OUTER JOIN
							CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = CLIENT.CL_CODE LEFT OUTER JOIN
							AR_COLL_NOTES WITH(NOLOCK) ON ACCT_REC.AR_INV_NBR = AR_COLL_NOTES.AR_INV_NBR AND 
							ACCT_REC.AR_INV_SEQ = AR_COLL_NOTES.AR_INV_SEQ AND ACCT_REC.AR_TYPE = AR_COLL_NOTES.AR_TYPE
						';

	IF @Restrictions > 0
	BEGIN

		SET @sql = @sql + ' INNER JOIN SEC_CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE';
	    
	END
	IF @RestrictionsOffice > 0
	BEGIN

		SET @sql = @sql + ' INNER JOIN EMP_OFFICE WITH(NOLOCK) ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE';
	    
	END
	IF @InvCats <> '' AND @InvCats <> '%' AND (NOT (@InvCats IS NULL))
	BEGIN

		SET @sql = @sql + ' INNER JOIN charlist_to_table(''' + @InvCats + ''', DEFAULT) c ON ACCT_REC.INV_CAT = c.vstr collate database_default';
	    
	END
	IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 AND @From = 'mca'
	BEGIN

		SET @sql = @sql + ' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](3, ''' + @EmpCode + ''') AS DR ON DR.CL_CODE = ACCT_REC.CL_CODE 
							AND ((DR.DIV_CODE = ACCT_REC.DIV_CODE) OR (DR.DIV_CODE IS NULL)) 
							AND ((DR.PRD_CODE = ACCT_REC.PRD_CODE) OR (DR.PRD_CODE IS NULL)) ';
		
	END

	SET @sql = @sql + '	WHERE (ACCT_REC.VOID_FLAG = 0 OR ACCT_REC.VOID_FLAG IS NULL) AND (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL)';

	IF @OfficeCode <> '%' AND (NOT (@OfficeCode IS NULL))
		BEGIN

			SET @sql = @sql + ' AND ACCT_REC.OFFICE_CODE = ''' + @OfficeCode + '''';
	    
		END
		IF @ClientCode <> '%' AND (NOT (@ClientCode IS NULL))
		BEGIN

			SET @sql = @sql + ' AND ACCT_REC.CL_CODE = ''' + @ClientCode + '''';
	    
		END
		IF @DivisionCode <> '%' AND (NOT (@DivisionCode IS NULL))
		BEGIN

			SET @sql = @sql + ' AND ACCT_REC.DIV_CODE = ''' + @DivisionCode + '''';
	    
		END
		IF @ProductCode <> '%' AND (NOT (@ProductCode IS NULL))
		BEGIN

			SET @sql = @sql + ' AND ACCT_REC.PRD_CODE = ''' + @ProductCode + '''';
	    
		END        
		IF @RestrictionsOffice > 0
		BEGIN

			SET @sql = @sql + ' AND (EMP_OFFICE.EMP_CODE = ''' + @EmpCode + ''')';
	    
		END 
		IF @Restrictions > 0
		BEGIN

			SET @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) ';
	    
		END    

	IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 AND @From = 'mca'
	Begin
		SET @sqlunion = '
						UNION

						SELECT 
							ACCT_REC.OFFICE_CODE, OFFICE.OFFICE_NAME, ACCT_REC.CL_CODE, CLIENT.CL_NAME, ACCT_REC.DIV_CODE, 
							DIVISION.DIV_NAME, ACCT_REC.PRD_CODE, PRODUCT.PRD_DESCRIPTION, ACCT_REC.AR_INV_AMOUNT,
							ACCT_REC.AR_INV_DATE AS InvoiceDate,
							ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_SEQ, ACCT_REC.REC_TYPE, ACCT_REC.SC_CODE, SALES_CLASS.SC_DESCRIPTION, ACCT_REC.JOB_NUMBER, 
							JOB_LOG.JOB_DESC, ACCT_REC.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, 
							CASE 
							WHEN (NOT JOB_LOG.JOB_NUMBER IS NULL AND NOT JOB_COMPONENT.JOB_COMPONENT_NBR IS NULL) THEN ''Job: '' + RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR, JOB_LOG.JOB_NUMBER), 6) + ''/'' + RIGHT(REPLICATE(''0'',2) + CONVERT(VARCHAR, JOB_COMPONENT.JOB_COMPONENT_NBR), 2) +'' - '' + JOB_COMPONENT.JOB_COMP_DESC 
							WHEN (NOT JOB_LOG.JOB_NUMBER IS NULL AND JOB_COMPONENT.JOB_COMPONENT_NBR IS NULL) THEN ''Job: '' + RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR, JOB_LOG.JOB_NUMBER), 6) + '' - '' + JOB_LOG.JOB_DESC 
							ELSE ISNULL(ACCT_REC.AR_DESCRIPTION,''N/A'')
							END AS AR_DESCRIPTION, 
							'''',
							CASE WHEN ACCT_REC.REC_TYPE = ''P'' THEN
							CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE ELSE
							CASE WHEN CL_P_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE END
							END
							ELSE
							CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE ELSE
							CASE WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_M_PAYDAYS,  ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE END

							END	
							END AS DUE_DATE, ISNULL(MANUAL_INV,0)
						FROM   ACCT_REC WITH(NOLOCK) INNER JOIN                      
							OFFICE WITH(NOLOCK) ON ACCT_REC.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN
							SALES_CLASS WITH(NOLOCK) ON ACCT_REC.SC_CODE = SALES_CLASS.SC_CODE LEFT OUTER JOIN								  
							JOB_COMPONENT WITH(NOLOCK) ON ACCT_REC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							ACCT_REC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
							JOB_LOG WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = ACCT_REC.JOB_NUMBER LEFT OUTER JOIN
							PRODUCT WITH(NOLOCK) ON PRODUCT.CL_CODE = ACCT_REC.CL_CODE AND PRODUCT.DIV_CODE = ACCT_REC.DIV_CODE 
							AND PRODUCT.PRD_CODE = ACCT_REC.PRD_CODE LEFT OUTER JOIN
							DIVISION WITH(NOLOCK) ON ACCT_REC.CL_CODE = DIVISION.CL_CODE AND ACCT_REC.DIV_CODE = DIVISION.DIV_CODE LEFT OUTER JOIN
							CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = CLIENT.CL_CODE LEFT OUTER JOIN
							AR_COLL_NOTES WITH(NOLOCK) ON ACCT_REC.AR_INV_NBR = AR_COLL_NOTES.AR_INV_NBR AND 
							ACCT_REC.AR_INV_SEQ = AR_COLL_NOTES.AR_INV_SEQ AND ACCT_REC.AR_TYPE = AR_COLL_NOTES.AR_TYPE
						';

		IF @Restrictions > 0
		BEGIN

			SET @sqlunion = @sqlunion + ' INNER JOIN SEC_CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE';
	    
		END
		IF @RestrictionsOffice > 0
		BEGIN

			SET @sqlunion = @sqlunion + ' INNER JOIN EMP_OFFICE WITH(NOLOCK) ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE';
	    
		END
		IF @InvCats <> '' AND @InvCats <> '%' AND (NOT (@InvCats IS NULL))
		BEGIN

			SET @sqlunion = @sqlunion + ' INNER JOIN charlist_to_table(''' + @InvCats + ''', DEFAULT) c ON ACCT_REC.INV_CAT = c.vstr collate database_default';
	    
		END
		IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 AND @From = 'mca'
		BEGIN

			SET @sqlunion = @sqlunion + ' INNER JOIN (SELECT DISTINCT CL_CODE, DIV_CODE FROM [dbo].[fn_my_objects_get_dynamic_restrictions](3, ''' + @EmpCode + ''')) AS DR ON DR.CL_CODE = ACCT_REC.CL_CODE 
								AND ((DR.DIV_CODE = ACCT_REC.DIV_CODE) OR (DR.DIV_CODE IS NULL)) 
								AND ACCT_REC.PRD_CODE IS NULL ';
		
		END

		SET @sqlunion = @sqlunion + '	WHERE 
									(ACCT_REC.VOID_FLAG = 0 OR ACCT_REC.VOID_FLAG IS NULL)  
									AND (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL)';

		IF @OfficeCode <> '%' AND (NOT (@OfficeCode IS NULL))
		BEGIN

			SET @sqlunion = @sqlunion + ' AND ACCT_REC.OFFICE_CODE = ''' + @OfficeCode + '''';
	    
		END
		IF @ClientCode <> '%' AND (NOT (@ClientCode IS NULL))
		BEGIN

			SET @sqlunion = @sqlunion + ' AND ACCT_REC.CL_CODE = ''' + @ClientCode + '''';
	    
		END
		IF @DivisionCode <> '%' AND (NOT (@DivisionCode IS NULL))
		BEGIN

			SET @sqlunion = @sqlunion + ' AND ACCT_REC.DIV_CODE = ''' + @DivisionCode + '''';
	    
		END
		IF @ProductCode <> '%' AND (NOT (@ProductCode IS NULL))
		BEGIN

			SET @sqlunion = @sqlunion + ' AND ACCT_REC.PRD_CODE = ''' + @ProductCode + '''';
	    
		END        
		IF @RestrictionsOffice > 0
		BEGIN

			SET @sqlunion = @sqlunion + ' AND (EMP_OFFICE.EMP_CODE = ''' + @EmpCode + ''')';
	    
		END 
		IF @Restrictions > 0
		BEGIN

			SET @sqlunion = @sqlunion + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) ';
	    
		END    

		SET @sqlunion2 = '
						UNION

						SELECT 
							ACCT_REC.OFFICE_CODE, OFFICE.OFFICE_NAME, ACCT_REC.CL_CODE, CLIENT.CL_NAME, ACCT_REC.DIV_CODE, 
							DIVISION.DIV_NAME, ACCT_REC.PRD_CODE, PRODUCT.PRD_DESCRIPTION, ACCT_REC.AR_INV_AMOUNT,
							ACCT_REC.AR_INV_DATE AS InvoiceDate,
							ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_SEQ, ACCT_REC.REC_TYPE, ACCT_REC.SC_CODE, SALES_CLASS.SC_DESCRIPTION, ACCT_REC.JOB_NUMBER, 
							JOB_LOG.JOB_DESC, ACCT_REC.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, 
							CASE 
							WHEN (NOT JOB_LOG.JOB_NUMBER IS NULL AND NOT JOB_COMPONENT.JOB_COMPONENT_NBR IS NULL) THEN ''Job: '' + RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR, JOB_LOG.JOB_NUMBER), 6) + ''/'' + RIGHT(REPLICATE(''0'',2) + CONVERT(VARCHAR, JOB_COMPONENT.JOB_COMPONENT_NBR), 2) +'' - '' + JOB_COMPONENT.JOB_COMP_DESC 
							WHEN (NOT JOB_LOG.JOB_NUMBER IS NULL AND JOB_COMPONENT.JOB_COMPONENT_NBR IS NULL) THEN ''Job: '' + RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR, JOB_LOG.JOB_NUMBER), 6) + '' - '' + JOB_LOG.JOB_DESC 
							ELSE ISNULL(ACCT_REC.AR_DESCRIPTION,''N/A'')
							END AS AR_DESCRIPTION, 
							'''',
							CASE WHEN ACCT_REC.REC_TYPE = ''P'' THEN
							CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE ELSE
							CASE WHEN CL_P_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE END
							END
							ELSE
							CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE ELSE
							CASE WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_M_PAYDAYS,  ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE END

							END	
							END AS DUE_DATE, ISNULL(MANUAL_INV,0)
						FROM   ACCT_REC WITH(NOLOCK) INNER JOIN                      
							OFFICE WITH(NOLOCK) ON ACCT_REC.OFFICE_CODE = OFFICE.OFFICE_CODE LEFT OUTER JOIN
							SALES_CLASS WITH(NOLOCK) ON ACCT_REC.SC_CODE = SALES_CLASS.SC_CODE LEFT OUTER JOIN								  
							JOB_COMPONENT WITH(NOLOCK) ON ACCT_REC.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							ACCT_REC.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR LEFT OUTER JOIN
							JOB_LOG WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = ACCT_REC.JOB_NUMBER LEFT OUTER JOIN
							PRODUCT WITH(NOLOCK) ON PRODUCT.CL_CODE = ACCT_REC.CL_CODE AND PRODUCT.DIV_CODE = ACCT_REC.DIV_CODE 
							AND PRODUCT.PRD_CODE = ACCT_REC.PRD_CODE LEFT OUTER JOIN
							DIVISION WITH(NOLOCK) ON ACCT_REC.CL_CODE = DIVISION.CL_CODE AND ACCT_REC.DIV_CODE = DIVISION.DIV_CODE LEFT OUTER JOIN
							CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = CLIENT.CL_CODE LEFT OUTER JOIN
							AR_COLL_NOTES WITH(NOLOCK) ON ACCT_REC.AR_INV_NBR = AR_COLL_NOTES.AR_INV_NBR AND 
							ACCT_REC.AR_INV_SEQ = AR_COLL_NOTES.AR_INV_SEQ AND ACCT_REC.AR_TYPE = AR_COLL_NOTES.AR_TYPE
						';

		IF @Restrictions > 0
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' INNER JOIN SEC_CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE';
	    
		END
		IF @RestrictionsOffice > 0
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' INNER JOIN EMP_OFFICE WITH(NOLOCK) ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE';
	    
		END
		IF @InvCats <> '' AND @InvCats <> '%' AND (NOT (@InvCats IS NULL))
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' INNER JOIN charlist_to_table(''' + @InvCats + ''', DEFAULT) c ON ACCT_REC.INV_CAT = c.vstr collate database_default';
	    
		END
		IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 AND @From = 'mca'
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' INNER JOIN (SELECT DISTINCT CL_CODE FROM [dbo].[fn_my_objects_get_dynamic_restrictions](3, ''' + @EmpCode + ''')) AS DR ON DR.CL_CODE = ACCT_REC.CL_CODE 
								AND ACCT_REC.DIV_CODE IS NULL AND ACCT_REC.PRD_CODE IS NULL ';
		
		END

		SET @sqlunion2 = @sqlunion2 + '	WHERE 
									(ACCT_REC.VOID_FLAG = 0 OR ACCT_REC.VOID_FLAG IS NULL)  
									AND (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL)';

		IF @OfficeCode <> '%' AND (NOT (@OfficeCode IS NULL))
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' AND ACCT_REC.OFFICE_CODE = ''' + @OfficeCode + '''';
	    
		END
		IF @ClientCode <> '%' AND (NOT (@ClientCode IS NULL))
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' AND ACCT_REC.CL_CODE = ''' + @ClientCode + '''';
	    
		END
		IF @DivisionCode <> '%' AND (NOT (@DivisionCode IS NULL))
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' AND ACCT_REC.DIV_CODE = ''' + @DivisionCode + '''';
	    
		END
		IF @ProductCode <> '%' AND (NOT (@ProductCode IS NULL))
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' AND ACCT_REC.PRD_CODE = ''' + @ProductCode + '''';
	    
		END        
		IF @RestrictionsOffice > 0
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' AND (EMP_OFFICE.EMP_CODE = ''' + @EmpCode + ''')';
	    
		END 
		IF @Restrictions > 0
		BEGIN

			SET @sqlunion2 = @sqlunion2 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) ';
	    
		END    
	End




	 
	PRINT @sql + @sqlunion + @sqlunion2;
	--set @sql = @sql + @sqlunion + @sqlunion2
	--SET @paramlist = '@ClientCode VARCHAR(6),@OfficeCode VARCHAR(6),@DivisionCode VARCHAR(6),@ProductCode VARCHAR(6),@EmpCode VARCHAR(6), @UserID VARCHAR(100), @InvCats VARCHAR(100)';

	EXEC(@sql + @sqlunion + @sqlunion2) --sp_executesql @sql, @paramlist, @ClientCode, @OfficeCode, @DivisionCode, @ProductCode, @EmpCode, @UserID, @InvCats;

	IF @Restrictions > 0
	BEGIN

		INSERT INTO #temp2 
		SELECT  
			SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)), CR_CLIENT_DTL.AR_INV_NBR, CR_CLIENT_DTL.AR_INV_SEQ
		FROM 
			CR_CLIENT WITH(NOLOCK) 
			INNER JOIN CR_CLIENT_DTL WITH(NOLOCK) 
			ON CR_CLIENT.REC_ID = CR_CLIENT_DTL.REC_ID 
			AND CR_CLIENT.SEQ_NBR = CR_CLIENT_DTL.SEQ_NBR
			INNER JOIN SEC_CLIENT 
				ON CR_CLIENT.CL_CODE = SEC_CLIENT.CL_CODE AND CR_CLIENT_DTL.DIV_CODE = SEC_CLIENT.DIV_CODE AND CR_CLIENT_DTL.PRD_CODE = SEC_CLIENT.PRD_CODE
		WHERE 
			(UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
		GROUP BY 
			CR_CLIENT_DTL.AR_INV_NBR, CR_CLIENT_DTL.AR_INV_SEQ;
			
	END
	ELSE
		BEGIN         
		
			INSERT INTO #temp2 
			SELECT  
				SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)), CR_CLIENT_DTL.AR_INV_NBR, CR_CLIENT_DTL.AR_INV_SEQ
			FROM 
				CR_CLIENT_DTL WITH(NOLOCK)
			GROUP BY 
				CR_CLIENT_DTL.AR_INV_NBR, CR_CLIENT_DTL.AR_INV_SEQ;
					 
		END


	IF @Group = 1 
	BEGIN
		INSERT INTO #Invoices
		SELECT 
			OfficeCode, OfficeName, ClientCode, ClientName, DivisionCode, DivisionName, ProductCode,	ProductName,
			ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) AS InvoiceAmt, 
			InvoiceDate, #temp.InvoiceNo, #temp.InvoiceSeq, [Type], SalesClassCode,	
			SalesClassName, JobNumber, JobDesc, JobCompNumber, JobCompDesc, ARDescription,
			[Collection], DueDate, ManualInvoice,
			(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #temp.InvoiceNo AND AR_INV_SEQ = #temp.InvoiceSeq) AS AttachmentCount 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(#temp.DueDate >= DATEADD(Day, @Group2, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME)) 
			AND #temp.DueDate <= DATEADD(Day, @Group1 - 1, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME))) 
			AND (ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) <> 0)
		ORDER BY 
			InvoiceDate ASC, #temp.InvoiceNo;
			
	END
	IF @Group = 2
	BEGIN
		INSERT INTO #Invoices
		SELECT 
			OfficeCode, OfficeName, ClientCode, ClientName, DivisionCode, DivisionName, ProductCode,	ProductName,
			ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) AS InvoiceAmt, 
			InvoiceDate, #temp.InvoiceNo, #temp.InvoiceSeq, [Type], SalesClassCode,	
			SalesClassName, JobNumber, JobDesc, JobCompNumber, JobCompDesc, ARDescription,
			[Collection], DueDate, ManualInvoice,
			(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #temp.InvoiceNo AND AR_INV_SEQ = #temp.InvoiceSeq) AS AttachmentCount  
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(#temp.DueDate >= DATEADD(Day, @Group3, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME)) 
			AND #temp.DueDate <= DATEADD(Day, @Group2 - 1, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME))) 
			AND (ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) <> 0)  
		ORDER BY 
			InvoiceDate ASC, #temp.InvoiceNo;

	END
	IF @Group = 3
	BEGIN
		INSERT INTO #Invoices
		SELECT 
			OfficeCode, OfficeName, ClientCode, ClientName, DivisionCode, DivisionName, ProductCode,	ProductName,
			ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) AS InvoiceAmt, 
			InvoiceDate, #temp.InvoiceNo, #temp.InvoiceSeq, [Type], SalesClassCode,	
			SalesClassName, JobNumber, JobDesc, JobCompNumber, JobCompDesc, ARDescription,
			[Collection], DueDate, ManualInvoice,
			(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #temp.InvoiceNo AND AR_INV_SEQ = #temp.InvoiceSeq) AS AttachmentCount  
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(#temp.DueDate >= DATEADD(Day, @Group4, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME)) AND #temp.DueDate <= DATEADD(Day, @Group3 - 1, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME))) 
			AND (ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) <> 0) 
		ORDER BY 
			InvoiceDate ASC, #temp.InvoiceNo;
	    
	END
	IF @Group = 4
	BEGIN
		INSERT INTO #Invoices
		SELECT 
			OfficeCode, OfficeName, ClientCode, ClientName, DivisionCode, DivisionName, ProductCode,	ProductName,
			ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) AS InvoiceAmt, 
			InvoiceDate, #temp.InvoiceNo, #temp.InvoiceSeq, [Type], SalesClassCode,	
			SalesClassName, JobNumber, JobDesc, JobCompNumber, JobCompDesc, ARDescription,
			[Collection], DueDate, ManualInvoice,
			(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #temp.InvoiceNo AND AR_INV_SEQ = #temp.InvoiceSeq) AS AttachmentCount  
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(#temp.DueDate <= DATEADD(Day, @Group4 - 1, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME)) ) 
			AND (ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) <> 0) 
		ORDER BY 
			InvoiceDate ASC, #temp.InvoiceNo;
			
	END
	IF @Group = 0
	BEGIN
			INSERT INTO #Invoices
		SELECT 
			OfficeCode, OfficeName, ClientCode, ClientName, DivisionCode, DivisionName, ProductCode,	ProductName,
			ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) AS InvoiceAmt, 
			InvoiceDate, #temp.InvoiceNo, #temp.InvoiceSeq, [Type], SalesClassCode,	
			SalesClassName, JobNumber, JobDesc, JobCompNumber, JobCompDesc, ARDescription,
			[Collection], DueDate, ManualInvoice,
			(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #temp.InvoiceNo AND AR_INV_SEQ = #temp.InvoiceSeq) AS AttachmentCount  
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		 WHERE  
			(#temp.DueDate >= DATEADD(Day, @Group1, CAST(CONVERT(VARCHAR(8),getdate(),1) AS DATETIME))) 
			AND (ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) <> 0) 
		ORDER BY 
			InvoiceDate ASC, #temp.InvoiceNo;
			
	END
	IF @Group = 5
	BEGIN
		INSERT INTO #Invoices
		SELECT 
			OfficeCode, OfficeName, ClientCode, ClientName, DivisionCode, DivisionName, ProductCode,	ProductName,
			ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) AS InvoiceAmt, 
			InvoiceDate, #temp.InvoiceNo, #temp.InvoiceSeq, [Type], SalesClassCode,	
			SalesClassName, JobNumber, JobDesc, JobCompNumber, JobCompDesc, ARDescription,
			[Collection], DueDate, ManualInvoice,
			(SELECT COUNT(1) FROM ARINV_DOCUMENT WHERE AR_INV_NBR = #temp.InvoiceNo AND AR_INV_SEQ = #temp.InvoiceSeq) AS AttachmentCount  
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo AND #temp.InvoiceSeq = #temp2.InvoiceSeq 
		WHERE 
			(ISNULL(AROpenAmt,0) - ISNULL(CRAmt,0) <> 0)	
		ORDER BY 
			InvoiceDate ASC, #temp.InvoiceNo;
			
	END

	UPDATE #Invoices
	SET [Collection] = (SELECT COLLECT_NOTES FROM AR_COLL_NOTES AR WHERE (AR.AR_INV_NBR = #Invoices.InvoiceNo) AND (AR.AR_INV_SEQ = #Invoices.InvoiceSeq))          

	SELECT * FROM #Invoices

	DROP TABLE #temp;
	DROP TABLE #temp2;
	DROP TABLE #Invoices;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO