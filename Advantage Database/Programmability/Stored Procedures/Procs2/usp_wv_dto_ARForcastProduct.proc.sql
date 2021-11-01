SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_ARForcastProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_ARForcastProduct]
GO
/* 
BJL, 20060616: For cash forecast desktop object. Changed to get payments at the invoice level, not the total payment.
BJL, 20060622: Changed cutoff to two years.
*/

CREATE PROCEDURE [dbo].[usp_wv_dto_ARForcastProduct] 
	@UserID			AS VARCHAR(100),
	@ClientCode		AS VARCHAR(6),
	@OFFICE_CODE	AS VARCHAR(6),
	@DivisionCode	AS VARCHAR(6),
	@ProductCode	AS VARCHAR(6),
	@From			AS VARCHAR(3)
AS
/*=========== QUERY ===========*/
	DECLARE 
		@RESTRICTIONS  INT,
		@RESTRICTIONSOFFICE  INT, 
		@EmpCode VARCHAR(6),
		@EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT
		
	SET NOCOUNT ON
	SET ANSI_NULLS ON
	SET ANSI_WARNINGS OFF
	SET ARITHABORT ON; --for OPTION (RECOMPILE)
	SET ARITHIGNORE ON

	IF @ClientCode = '%' OR @ClientCode IS NULL
	BEGIN
		SET @ClientCode = '';
	END

	IF @DivisionCode = '%' OR @DivisionCode IS NULL
	BEGIN
		SET @DivisionCode = '';
	END

	IF @ProductCode = '%' OR @ProductCode IS NULL
	BEGIN
		SET @ProductCode = '';
	END

	IF @OFFICE_CODE = '%' OR @OFFICE_CODE IS NULL
	BEGIN
		SET @OFFICE_CODE = '';
	END

	--Create First Temp Table
	CREATE TABLE #temp_cr
	(
		[Days]			INTEGER,
		ClientCode		VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DivisionCode	VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		ProductCode		VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		InvoiceNo		INTEGER,
		InvoiceDate		DATETIME,
		OFFICE_CODE		VARCHAR(4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL
	);

	CREATE TABLE #temp_openinvoices
	(
		[Days]			INTEGER,
		ClientCode		VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DivisionCode	VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		ProductCode		VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		AROpenAmt		DECIMAL(20, 2),
		CRAmt			DECIMAL(20, 2),
		InvoiceNo		INTEGER,
		InvoiceDate		DATETIME,
		OFFICE_CODE		VARCHAR(4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL
	);

	--Create Second Temp Table
	CREATE TABLE #temp2
	(
		ClientCode		VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		DivisionCode	VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		ProductCode		VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
		AvgDays			INTEGER,
		OpenAmt			DECIMAL(20, 2),
		TotalOpenAmt	DECIMAL(20, 2),
		ForcastDate		DATETIME,
		OFFICE_CODE		VARCHAR(4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL
	)


	--Look for Client/Division/Product security
	SELECT @RESTRICTIONS = COUNT(*)
	FROM   SEC_CLIENT WITH(NOLOCK)
	WHERE  [USER_ID] = @UserID;

	SELECT @EmpCode = EMP_CODE
	FROM SEC_USER WITH(NOLOCK)
	WHERE UPPER(USER_CODE) = UPPER(@UserID);

	SELECT @RESTRICTIONSOFFICE = COUNT(*)
	FROM   EMP_OFFICE WITH(NOLOCK)
	WHERE  [EMP_CODE] = @EmpCode;

	SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EmpCode, 2); 
	--SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = 0

	DECLARE
		@RESTRICT_ACCOUNT_EXECUTIVE BIT,
		@HAS_ACTIVE_RESTRICTION BIT,
		@NEEDS_OR BIT;
				
	SELECT 	
		@RESTRICT_ACCOUNT_EXECUTIVE = A.ACCOUNT_EXECUTIVE,   
		@HAS_ACTIVE_RESTRICTION = A.HAS_ACTIVE_RESTRICTION
	FROM 
		[dbo].[fn_my_objects_get_static_restrictions](2) AS A;

	DECLARE @SQL VARCHAR(MAX);

	--SET @SQL = '
		INSERT INTO #temp_cr
		SELECT DATEDIFF([Day],MAX(ACCT_REC.AR_INV_DATE),MAX(CR_CLIENT.CR_CHECK_DATE)) AS Days,
			ACCT_REC.CL_CODE AS ClientCode,
			ISNULL(ACCT_REC.DIV_CODE,'*') AS DivisionCode,
			ISNULL(ACCT_REC.PRD_CODE,'*') AS ProductCode,
			ACCT_REC.AR_INV_NBR AS InvoiceNo,
			ACCT_REC.AR_INV_DATE AS InvoiceDate,
			ACCT_REC.OFFICE_CODE
		FROM   
			ACCT_REC WITH(NOLOCK)
				INNER JOIN CR_CLIENT_DTL WITH(NOLOCK)
					ON  CR_CLIENT_DTL.AR_INV_NBR = ACCT_REC.AR_INV_NBR
					AND CR_CLIENT_DTL.AR_INV_SEQ = ACCT_REC.AR_INV_SEQ
					AND CR_CLIENT_DTL.AR_TYPE = ACCT_REC.AR_TYPE
				INNER JOIN CR_CLIENT WITH(NOLOCK)
					ON  CR_CLIENT.REC_ID = CR_CLIENT_DTL.REC_ID
					AND CR_CLIENT.SEQ_NBR = CR_CLIENT_DTL.SEQ_NBR 
				LEFT OUTER JOIN CLIENT
					ON ACCT_REC.CL_CODE = CLIENT.CL_CODE
		WHERE
			(
				( @RESTRICTIONS = 0 )
			  OR
				( @RESTRICTIONS > 0 AND EXISTS (
												SELECT 1
												FROM SEC_CLIENT sc
												WHERE sc.CL_CODE = ACCT_REC.CL_CODE
												AND	sc.DIV_CODE = ACCT_REC.DIV_CODE
												AND sc.PRD_CODE = ACCT_REC.PRD_CODE
												AND UPPER(sc.USER_ID) = UPPER(@UserID)
												AND (sc.TIME_ENTRY = 0 OR sc.TIME_ENTRY IS NULL)
											  ))
			)
		AND (
				( @RESTRICTIONSOFFICE = 0 )
			  OR
			    ( @RESTRICTIONSOFFICE > 0 AND EXISTS (
														SELECT 1
														FROM EMP_OFFICE eo
														WHERE eo.OFFICE_CODE = ACCT_REC.OFFICE_CODE
														AND eo.EMP_CODE = @EmpCode 
													 ))
			)
		AND ( @OFFICE_CODE = '' OR ACCT_REC.OFFICE_CODE = @OFFICE_CODE )
		AND ( @ClientCode = '' OR ACCT_REC.CL_CODE = @ClientCode )
		AND ( @DivisionCode = '' OR ACCT_REC.DIV_CODE = @DivisionCode )
		AND ( @ProductCode = '' OR ACCT_REC.PRD_CODE = @ProductCode )
		GROUP BY
			   ACCT_REC.CL_CODE,
			   ACCT_REC.DIV_CODE,
			   ACCT_REC.PRD_CODE,	
			   ACCT_REC.AR_INV_NBR,
			   ACCT_REC.AR_INV_DATE,
			   --CR_CLIENT.CR_CHECK_DATE,
			   ACCT_REC.AR_INV_SEQ,
			   ACCT_REC.AR_TYPE,
			   ACCT_REC.VOID_FLAG,
			   ACCT_REC.OFFICE_CODE,
			   ACCT_REC.DUE_DATE,
			   CL_P_PAYDAYS,
			   CL_M_PAYDAYS,
			   ACCT_REC.REC_TYPE
		HAVING (ACCT_REC.AR_INV_SEQ <> 99) 
			   AND (ACCT_REC.AR_TYPE = 'IN') 
			   AND (ACCT_REC.VOID_FLAG <> 1 OR ACCT_REC.VOID_FLAG IS NULL) 
			   AND (DATEDIFF([day], ACCT_REC.AR_INV_DATE, GETDATE()) < 730)

	--'

	--IF @RESTRICTIONS > 0
	--BEGIN

	--	SET @SQL = @SQL + '
	--		INNER JOIN SEC_CLIENT WITH(NOLOCK)
	--		ON  ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE
	--		AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE
	--		AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE
	--	';
		
	--END
	--IF @RESTRICTIONSOFFICE > 0
	--BEGIN

	--	SET @SQL = @SQL + '
	--		INNER JOIN EMP_OFFICE ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
	--	';
		
	--END                    

	--SET @SQL = @SQL + ' WHERE 1 = 1 '

	--IF @OFFICE_CODE <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' AND (ACCT_REC.OFFICE_CODE = ''' + @OFFICE_CODE + ''')';
		
	--END
	--IF @RESTRICTIONS > 0
	--BEGIN
	--	SET @SQL = @SQL + '
	--		   AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	--'
	--END
	--IF @RESTRICTIONSOFFICE > 0
	--BEGIN
	--	SET @SQL = @SQL + '
	--		   AND (EMP_OFFICE.EMP_CODE = ''' + @EmpCode + ''')
	--'  	
	--END

	--SET @SQL = @SQL + '
	--	GROUP BY
	--		   ACCT_REC.CL_CODE,
	--		   ACCT_REC.DIV_CODE,
	--		   ACCT_REC.PRD_CODE,	
	--		   ACCT_REC.AR_INV_NBR,
	--		   ACCT_REC.AR_INV_DATE,
	--		   CR_CLIENT.CR_CHECK_DATE,
	--		   ACCT_REC.AR_INV_SEQ,
	--		   ACCT_REC.AR_TYPE,
	--		   ACCT_REC.VOID_FLAG,
	--		   ACCT_REC.OFFICE_CODE,
	--		   ACCT_REC.DUE_DATE,
	--		   CL_P_PAYDAYS,
	--		   CL_M_PAYDAYS,
	--		   ACCT_REC.REC_TYPE
	--	HAVING (ACCT_REC.AR_INV_SEQ <> 99) 
	--		   AND (ACCT_REC.AR_TYPE = ''IN'') 
	--		   AND (ACCT_REC.VOID_FLAG <> 1 OR ACCT_REC.VOID_FLAG IS NULL) 
	--		   AND (DATEDIFF([day], ACCT_REC.AR_INV_DATE, GETDATE()) < 730)
	           
	--';
	--IF @ClientCode <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' AND ACCT_REC.CL_CODE = ''' + @ClientCode + '''';
		
	--END

	--IF @DivisionCode <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' AND ACCT_REC.DIV_CODE = ''' + @DivisionCode + '''';
		
	--END

	--IF @ProductCode <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' AND ACCT_REC.PRD_CODE = ''' + @ProductCode + '''';
		
	--END

	--PRINT @SQL;
	--EXEC(@SQL);

	--SET @SQL = ''
	--SET @SQL = '
				--INSERT INTO #temp
				INSERT #temp_openinvoices
				SELECT 
					NULL,
					ACCT_REC.CL_CODE,
					ISNULL(ACCT_REC.DIV_CODE,'*') AS DivisionCode,
					ISNULL(ACCT_REC.PRD_CODE,'*') AS ProductCode,
					SUM(ACCT_REC.AR_INV_AMOUNT),
					CRAmt = (
							SELECT ISNULL(
											SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + SUM(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)),
											0
										 )
							FROM   CR_CLIENT_DTL WITH(NOLOCK)
							WHERE  CR_CLIENT_DTL.AR_INV_NBR = ACCT_REC.AR_INV_NBR
							AND CR_CLIENT_DTL.AR_INV_SEQ = ACCT_REC.AR_INV_SEQ
							AND CR_CLIENT_DTL.AR_TYPE = ACCT_REC.AR_TYPE
					),
					ACCT_REC.AR_INV_NBR AS InvoiceNum,
					ACCT_REC.AR_INV_DATE AS InvoiceDate,
					ACCT_REC.OFFICE_CODE
				FROM   ACCT_REC WITH(NOLOCK)
				--'
				WHERE
					(
						( @RESTRICTIONS = 0 )
					OR
						( @RESTRICTIONS > 0 AND EXISTS (
														SELECT 1
														FROM SEC_CLIENT sc
														WHERE sc.CL_CODE = ACCT_REC.CL_CODE
														AND sc.DIV_CODE = ACCT_REC.DIV_CODE
														AND sc.PRD_CODE = ACCT_REC.PRD_CODE
														AND UPPER(sc.USER_ID) = UPPER(@UserID)
														AND (sc.TIME_ENTRY = 0 OR sc.TIME_ENTRY IS NULL)
													   ))
					)
				AND (
						( @RESTRICTIONSOFFICE = 0 )
					OR
						( @RESTRICTIONSOFFICE > 0 AND EXISTS (
																SELECT 1
																FROM EMP_OFFICE eo
																WHERE eo.OFFICE_CODE = ACCT_REC.OFFICE_CODE
																AND eo.EMP_CODE = @EmpCode
															 ) )
					)
				AND ( ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL )
				AND ( ACCT_REC.VOID_FLAG <> 1 OR ACCT_REC.VOID_FLAG IS NULL )
				AND ( @ClientCode = '' OR ACCT_REC.CL_CODE = @ClientCode )
				AND ( @DivisionCode = '' OR ACCT_REC.DIV_CODE = @DivisionCode )
				AND ( @ProductCode = '' OR ACCT_REC.PRD_CODE = @ProductCode )
				AND ( @OFFICE_CODE = '' OR ACCT_REC.OFFICE_CODE = @OFFICE_CODE )
				GROUP BY
				   ACCT_REC.CL_CODE,
				   ACCT_REC.DIV_CODE,
				   ACCT_REC.PRD_CODE,
				   ACCT_REC.AR_INV_NBR,
				   ACCT_REC.AR_INV_SEQ,
				   ACCT_REC.AR_TYPE,
				   ACCT_REC.AR_INV_DATE,
				   ACCT_REC.OFFICE_CODE,
				   ACCT_REC.VOID_FLAG

	--IF @RESTRICTIONS > 0
	--BEGIN

	--	SET @SQL = @SQL + '
	--			INNER JOIN SEC_CLIENT WITH(NOLOCK)
	--			ON  ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE
	--			AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE
	--			AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE
	--			';
	--END
	--IF @RESTRICTIONSOFFICE > 0
	--BEGIN

	--	SET @SQL = @SQL + '
	--			INNER JOIN EMP_OFFICE ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
	--			';                    
	   	
	--END

	--SET @SQL = @SQL + '
	--			WHERE  
	--				(ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL) 
	--				AND (ACCT_REC.VOID_FLAG <> 1 OR ACCT_REC.VOID_FLAG IS NULL)
	--			';

	--IF @RESTRICTIONS > 0
	--BEGIN

	--	SET @SQL = @SQL + '
	--			   AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) 
	--			   AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	--			   ';
				   
	--END
	--IF @RESTRICTIONSOFFICE > 0
	--BEGIN

	--	SET @SQL = @SQL + '
	--				AND (EMP_OFFICE.EMP_CODE = ''' + @EmpCode + ''')
	--				';  	
					
	--END
	--IF @ClientCode <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' 
	--				AND ACCT_REC.CL_CODE = ''' + @ClientCode + '''';
					
	--END
	--IF @DivisionCode <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' 
	--				AND ACCT_REC.DIV_CODE = ''' + @DivisionCode + '''';
					
	--END
	--IF @ProductCode <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' 
	--				AND ACCT_REC.PRD_CODE = ''' + @ProductCode + '''';
		
	--END
	--IF @OFFICE_CODE <> ''
	--BEGIN

	--	SET @SQL = @SQL + ' 
	--				AND (ACCT_REC.OFFICE_CODE = ''' + @OFFICE_CODE + ''')';
	--END

	--SET @SQL = @SQL + '
	--	GROUP BY
	--		   ACCT_REC.CL_CODE,
	--		   ACCT_REC.DIV_CODE,
	--		   ACCT_REC.PRD_CODE,
	--		   ACCT_REC.AR_INV_NBR,
	--		   ACCT_REC.AR_INV_SEQ,
	--		   ACCT_REC.AR_TYPE,
	--		   ACCT_REC.AR_INV_DATE,
	--		   ACCT_REC.OFFICE_CODE,
	--		   ACCT_REC.VOID_FLAG
	--	';


	--PRINT @SQL;
	--EXEC(@SQL)

CREATE CLUSTERED INDEX [tmp_cdp] ON #temp_cr
(
	[ClientCode],
	[DivisionCode],
	[ProductCode]
)

CREATE CLUSTERED INDEX [tmp_cdp] ON #temp_openinvoices
(
	[ClientCode],
	[DivisionCode],
	[ProductCode]
)


	INSERT INTO #temp2
	  (
		ClientCode,
		DivisionCode,
		ProductCode,
		AvgDays,
		OpenAmt,
		ForcastDate,
		OFFICE_CODE
	  )
	SELECT ClientCode, DivisionCode, ProductCode,
		   AvgDays = (
			   SELECT ISNULL(AVG(B.Days) * SIGN(ABS(SIGN(AVG(B.Days)) + 1)), 0)
			   FROM   #temp_cr B
			   WHERE  B.ClientCode = #temp_openinvoices.ClientCode
			   AND (B.DivisionCode = #temp_openinvoices.DivisionCode OR B.DivisionCode = '*') 
			   AND (B.ProductCode = #temp_openinvoices.ProductCode OR B.ProductCode = '*')
		   ),
		   COALESCE(AROpenAmt, 0) - COALESCE(CRAmt, 0),
		   InvoiceDate,
		   OFFICE_CODE
	FROM   #temp_openinvoices 
	WHERE COALESCE(AROpenAmt, 0) - COALESCE(CRAmt, 0) <> 0
	OPTION (RECOMPILE)

	--DELETE 
	--FROM   #temp2
	--WHERE  (OpenAmt = 0.00);

	UPDATE #temp2
	SET    ForcastDate = CASE 
							  WHEN DATEADD(DAY, AvgDays, ForcastDate) < GETDATE() THEN GETDATE()
							  ELSE DATEADD(DAY, AvgDays, ForcastDate)
						 END,
		   TotalOpenAmt = (
			   SELECT ISNULL(SUM(B.OpenAmt), 0)
			   FROM   #temp2 B
			   WHERE  B.ClientCode = #temp2.ClientCode AND (B.DivisionCode = #temp2.DivisionCode) AND (B.ProductCode = #temp2.ProductCode)
		   );
		  
--SELECT * FROM #temp2

	SET @SQL = ''
	SET @SQL = '
		SELECT #temp2.ClientCode,
			   #temp2.DivisionCode,	
			   #temp2.ProductCode,
			   #temp2.AvgDays,
			   SUM(#temp2.OpenAmt) AS OpenAmt,
			   #temp2.TotalOpenAmt,
			   #temp2.ForcastDate,
			   #temp2.OFFICE_CODE
		FROM   #temp2 '

	IF (@EMPLOYEE_HAS_MGMT_RESTRICTIONS = 1 OR @RESTRICT_ACCOUNT_EXECUTIVE = 1) AND @From = 'mar'
	BEGIN

		SET @SQL = @SQL + ' INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](2, ''' + @EmpCode + ''') AS DR ON DR.CL_CODE = #temp2.ClientCode 
		AND ((#temp2.DivisionCode = DR.DIV_CODE) OR (#temp2.DivisionCode = ''*'' )) 
		AND ((#temp2.ProductCode = DR.PRD_CODE) OR (#temp2.ProductCode = ''*'')) ';

	END	
			
	SET @SQL = @SQL + '	WHERE  1 = 1 AND #temp2.OpenAmt <> 0 AND #temp2.TotalOpenAmt <> 0';

	IF @ClientCode <> ''
	BEGIN
		SET @SQL = @SQL + ' AND #temp2.ClientCode = ''' + @ClientCode + '''';
	END
	IF @DivisionCode <> ''
	BEGIN
		SET @SQL = @SQL + ' AND #temp2.DivisionCode = ''' + @DivisionCode + '''';
	END
	IF @ProductCode <> ''
	BEGIN
		SET @SQL = @SQL + ' AND #temp2.ProductCode = ''' + @ProductCode + '''';
	END
	IF @OFFICE_CODE <> ''
	BEGIN

		SET @SQL = @SQL + ' AND (#temp2.OFFICE_CODE = ''' + @OFFICE_CODE + ''')';
		
	END		

	SET @SQL = @SQL + ' 
		GROUP BY
			   #temp2.ClientCode,
			   #temp2.DivisionCode,	
			   #temp2.ProductCode,
			   #temp2.AvgDays,
			   #temp2.TotalOpenAmt,
			   #temp2.ForcastDate,
			   #temp2.OFFICE_CODE
		ORDER BY
			   #temp2.ClientCode,
			   #temp2.DivisionCode,	
			   #temp2.ProductCode;
	'
	PRINT(@SQL);
	EXEC(@SQL);

	DROP TABLE #temp_cr;
	DROP TABLE #temp_openinvoices;
	DROP TABLE #temp2;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO