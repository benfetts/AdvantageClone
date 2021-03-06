SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_GetInvoiceBalance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_GetInvoiceBalance]
GO

CREATE PROCEDURE [dbo].[usp_wv_dto_GetInvoiceBalance]
@UserID VARCHAR(100),  
@ClientCode VARCHAR(6),
@OfficeCode VARCHAR(6),
@DivisionCode VARCHAR(6),
@ProductCode VARCHAR(6),
@From VARCHAR(3),
@InvCats VARCHAR(100)
AS
/*=========== QUERY ===========*/

	SET NOCOUNT ON;
	
	DECLARE 
		@C1 DECIMAL,
		@C2 DECIMAL,
		@C3 DECIMAL,
		@C4 DECIMAL,
		@C5 DECIMAL,
		@Total DECIMAL,
		@Restrictions INT, 
		@RestrictionsOffice INT, 
		@APPLICATION_NAME VARCHAR(15),
		@Group1 INT, 
		@Group2 INT, 
		@Group3 INT, 
		@Group4 INT, 
		@Grp1 VARCHAR(10), 
		@Grp2 VARCHAR(10), 
		@Grp3 VARCHAR(10), 
		@Grp4 VARCHAR(10),
		@sql NVARCHAR(4000), 
		@sql2 NVARCHAR(4000),
		@paramlist NVARCHAR(4000), 
		@paramlist2 NVARCHAR(4000), 
		@IncludeOver VARCHAR(7), 
		@EmpCode VARCHAR(6),
		@EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT

	 --Create First Temp Table
	CREATE TABLE #temp
	( 
		AROpenAmt         DECIMAL(20,2),
		InvoiceNo	INTEGER, 
		InvoiceSeq  SMALLINT, 
		InvoiceDate	DATETIME
	);

	CREATE TABLE #temp2
	( 
		CRAmt		DECIMAL(20,2),
		InvoiceNo	INTEGER, 
		InvoiceSeq  SMALLINT 
	);

	--Look for Client/Division/Product security
	SELECT 
		@Restrictions = COUNT(*) 
	FROM 
		SEC_CLIENT WITH(NOLOCK)
	WHERE 
		UPPER(USER_ID) = UPPER(@UserID);

	SELECT 
		@EmpCode = EMP_CODE
	FROM 
		SEC_USER WITH(NOLOCK)
	WHERE 
		UPPER(USER_CODE) = UPPER(@UserID);

	SELECT 
		@RestrictionsOffice = COUNT(*) 
	FROM 
		EMP_OFFICE
	WHERE 
		EMP_CODE = @EmpCode;

	SELECT 
		@EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EmpCode, 3); 
	--SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS;
	
	IF @From = 'mca'
	BEGIN
	
		SET @APPLICATION_NAME = 'MyClientAging'
			
	END
	ELSE
	BEGIN
	
		SET @APPLICATION_NAME = 'ClientAging'
			
	END
	

	SELECT 
		@Group1 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp1 = VARIABLE_VALUE
	FROM 
		APP_VARS WITH(NOLOCK)
	WHERE 
		[APPLICATION] = @APPLICATION_NAME 
		AND VARIABLE_NAME = 'CAGroup1' 
		AND UPPER(USERID) = UPPER(@UserID);

	SELECT 
		@Group2 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp2 = VARIABLE_VALUE
	FROM 
		APP_VARS WITH(NOLOCK)
	WHERE 
		[APPLICATION] = @APPLICATION_NAME 
		AND VARIABLE_NAME = 'CAGroup2' 
		AND UPPER(USERID) = UPPER(@UserID);

	SELECT 
		@Group3 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp3 = VARIABLE_VALUE
	FROM 
		APP_VARS WITH(NOLOCK)
	WHERE 
		[APPLICATION] = @APPLICATION_NAME 
		AND VARIABLE_NAME = 'CAGroup3' 
		AND UPPER(USERID) = UPPER(@UserID);

	SELECT 
		@Group4 = CAST(VARIABLE_VALUE AS INT) * -1, @Grp4 = VARIABLE_VALUE + '+'
	FROM 
		APP_VARS WITH(NOLOCK)
	WHERE 
		[APPLICATION] = @APPLICATION_NAME 
		AND VARIABLE_NAME = 'CAGroup4' 
		AND UPPER(USERID) = UPPER(@UserID);

	SELECT 
		@IncludeOver = VARIABLE_VALUE
	FROM 
		APP_VARS WITH(NOLOCK)
	WHERE 
		[APPLICATION] = @APPLICATION_NAME 
		AND VARIABLE_NAME = 'CAIncludeOver' 
		AND UPPER(USERID) = UPPER(@UserID);

	--SELECT @Group1, @Group2, @Group3, @Group4, @IncludeOver

	SET @sql = '	INSERT INTO #temp (AROpenAmt, InvoiceDate, InvoiceNo, InvoiceSeq)
					SELECT 
						SUM(DISTINCT ACCT_REC.AR_INV_AMOUNT), 
						CASE WHEN ACCT_REC.REC_TYPE = ''P'' THEN
							CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE
							CASE WHEN CL_P_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE 
							END 
						END
						ELSE
						CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE 
						CASE WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(Day, CL_M_PAYDAYS, ACCT_REC.AR_INV_DATE) 
							ELSE ACCT_REC.AR_INV_DATE 
							END
						END	
						END	AS InvoiceDate,
						ACCT_REC.AR_INV_NBR, ACCT_REC.AR_INV_SEQ
					FROM 
						ACCT_REC WITH(NOLOCK) INNER JOIN  CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = CLIENT.CL_CODE '
		                    
		                    
	IF @Restrictions > 0
	BEGIN

		SET @sql = @sql + ' INNER JOIN SEC_CLIENT WITH(NOLOCK) ON ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE '

	END
	IF @RestrictionsOffice > 0
	BEGIN

		SET @sql = @sql + ' INNER JOIN EMP_OFFICE ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE '
	    
	END
	IF @InvCats <> '' AND @InvCats <> '%' AND (NOT (@InvCats IS NULL))
	BEGIN

		SET @sql = @sql + ' INNER JOIN charlist_to_table(@InvCats, DEFAULT) c ON ACCT_REC.INV_CAT = c.vstr collate database_default'
	    
	END

	IF @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 AND @From = 'mca'
	BEGIN

		SET @sql = @sql + ' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](3, ''' + @EmpCode + ''') AS DR ON DR.CL_CODE = ACCT_REC.CL_CODE 
							AND ((DR.DIV_CODE = ACCT_REC.DIV_CODE) OR (ACCT_REC.DIV_CODE IS NULL)) 
							AND ((DR.PRD_CODE = ACCT_REC.PRD_CODE) OR (ACCT_REC.PRD_CODE IS NULL)) ';
		
	END

	SET @sql = @sql + ' WHERE 
							(ACCT_REC.VOID_FLAG = 0 OR ACCT_REC.VOID_FLAG IS NULL)  
							AND (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL) ';

	IF @OfficeCode <> '%' AND (NOT (@OfficeCode IS NULL))
	BEGIN

		SET @sql = @sql + ' AND ACCT_REC.OFFICE_CODE = @OfficeCode ';
	    
	END
	IF @ClientCode <> '%' AND (NOT (@ClientCode IS NULL))
	BEGIN

		SET @sql = @sql + ' AND ACCT_REC.CL_CODE = @ClientCode ';
	    
	END
	IF @DivisionCode <> '%' AND (NOT (@DivisionCode IS NULL))
	BEGIN

		SET @sql = @sql + ' AND ACCT_REC.DIV_CODE = @DivisionCode ';
	    
	END
	IF @ProductCode <> '%' AND (NOT (@ProductCode IS NULL))
	BEGIN

		SET @sql = @sql + ' AND ACCT_REC.PRD_CODE = @ProductCode ';
	    
	END        
	IF @RestrictionsOffice > 0
	BEGIN

		SET @sql = @sql + ' AND (EMP_OFFICE.EMP_CODE = @EmpCode) ';
	    
	END 
	IF @Restrictions > 0
	BEGIN

		SET @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) ';
	    
	END     
	        
	SET @sql = @sql + ' GROUP BY 
							ACCT_REC.CL_CODE, 
							ACCT_REC.AR_INV_NBR, 
							ACCT_REC.AR_INV_DATE,  
							ACCT_REC.AR_INV_NBR, 
							ACCT_REC.AR_INV_SEQ, 
							ACCT_REC.REC_TYPE, 
							CL_P_PAYDAYS, 
							CL_M_PAYDAYS, 
							ACCT_REC.DUE_DATE;';   

	SET @paramlist = '@ClientCode VARCHAR(6), @OfficeCode VARCHAR(6), @DivisionCode VARCHAR(6), @ProductCode VARCHAR(6), @EmpCode VARCHAR(6), @UserID VARCHAR(100), @InvCats VARCHAR(100)';

	PRINT @sql;
	EXEC sp_executesql @sql, @paramlist, @ClientCode, @OfficeCode, @DivisionCode, @ProductCode, @EmpCode, @UserID, @InvCats;
	    
	IF @Restrictions > 0
	BEGIN

		INSERT INTO #temp2 
		SELECT  
			SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)), 
			CR_CLIENT_DTL.AR_INV_NBR, 
			CR_CLIENT_DTL.AR_INV_SEQ
		FROM 
			CR_CLIENT WITH(NOLOCK)
			INNER JOIN CR_CLIENT_DTL WITH(NOLOCK) 
			ON CR_CLIENT.REC_ID = CR_CLIENT_DTL.REC_ID 
			AND CR_CLIENT.SEQ_NBR = CR_CLIENT_DTL.SEQ_NBR
			INNER JOIN SEC_CLIENT  WITH(NOLOCK)
			ON CR_CLIENT.CL_CODE = SEC_CLIENT.CL_CODE AND CR_CLIENT_DTL.DIV_CODE = SEC_CLIENT.DIV_CODE AND CR_CLIENT_DTL.PRD_CODE = SEC_CLIENT.PRD_CODE
		WHERE 
			(UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
		GROUP BY 
			CR_CLIENT_DTL.AR_INV_NBR, 
			CR_CLIENT_DTL.AR_INV_SEQ;
			
	END
	ELSE
	BEGIN         

		INSERT INTO #temp2 
		SELECT  
			SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)), 
			CR_CLIENT_DTL.AR_INV_NBR, 
			CR_CLIENT_DTL.AR_INV_SEQ
		FROM 
			CR_CLIENT_DTL WITH(NOLOCK)
		GROUP BY 
			CR_CLIENT_DTL.AR_INV_NBR, 
			CR_CLIENT_DTL.AR_INV_SEQ;  
		
	END

	IF @IncludeOver = 'False'
	BEGIN

		SELECT 
			@C1 =  SUM(ISNULL(AROpenAmt,0)) - SUM(ISNULL(CRAmt,0)) 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo 
			AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE  
			(InvoiceDate >= DATEADD(Day, @Group1, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME)));

		SELECT 
			@C2 =  SUM(ISNULL(AROpenAmt,0)) - SUM(ISNULL(CRAmt,0)) 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo 
			AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(InvoiceDate >= DATEADD(Day, @Group2, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME)) 
			AND InvoiceDate <= DATEADD(Day, @Group1 - 1, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME))); 

		SELECT 
			@C3 = SUM(ISNULL(AROpenAmt,0)) - SUM(ISNULL(CRAmt,0)) 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo 
			AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(InvoiceDate >= DATEADD(Day, @Group3, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME)) 
			AND InvoiceDate <= DATEADD(Day, @Group2 - 1, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME))); 

		SELECT 
			@C4 =  SUM(ISNULL(AROpenAmt,0)) - SUM(ISNULL(CRAmt,0)) 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo 
			AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(InvoiceDate >= DATEADD(Day, @Group4, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME)) 
			AND InvoiceDate <= DATEADD(Day, @Group3 - 1, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME))); 

		SELECT 
			@C5 =  SUM(ISNULL(AROpenAmt,0)) - SUM(ISNULL(CRAmt,0)) 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo 
			AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(InvoiceDate <= DATEADD(Day, @Group4 - 1, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME)) ); 

		SELECT 
			@Total =  SUM(ISNULL(AROpenAmt,0)) - SUM(ISNULL(CRAmt,0)) 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo 
			AND #temp.InvoiceSeq = #temp2.InvoiceSeq;
	        
	END
	ELSE
	BEGIN

		SELECT
			@C5 =  SUM(ISNULL(AROpenAmt,0)) - SUM(ISNULL(CRAmt,0)) 
		FROM 
			#temp
			LEFT OUTER JOIN #temp2
			ON #temp.InvoiceNo = #temp2.InvoiceNo 
			AND #temp.InvoiceSeq = #temp2.InvoiceSeq
		WHERE 
			(InvoiceDate <= DATEADD(Day, @Group4 - 1, CAST(CONVERT(VARCHAR(8),GETDATE(),1) AS DATETIME)));
	    
	END

	SET @sql2 = 'SELECT ISNULL(@C1, 0) AS [Current], ISNULL(@C2, 0) AS ''' + @Grp1 + ''', ISNULL(@C3, 0) AS ''' + @Grp2 + ''', ISNULL(@C4, 0) AS ''' + @Grp3 + ''', ISNULL(@C5, 0) AS ''' + @Grp4 + ''', ISNULL(@Total, 0) AS Total';
	SET @paramlist2 = '@C1 DECIMAL, @C2 DECIMAL, @C3 DECIMAL, @C4 DECIMAL, @C5 DECIMAL, @Total DECIMAL';

	--PRINT @sql2;
	EXEC sp_executesql @sql2, @paramlist2, @C1, @C2, @C3, @C4, @C5, @Total;

	DROP TABLE #temp;
	DROP TABLE #temp2;

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO