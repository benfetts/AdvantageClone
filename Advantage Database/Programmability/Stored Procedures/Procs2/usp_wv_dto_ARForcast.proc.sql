SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dto_ARForcast]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dto_ARForcast]
GO














/* 
BJL, 20060616: For cash forecast desktop object. Changed to get payments at the invoice level, not the total payment.
BJL, 20060622: Changed cutoff to two years.
*/

CREATE PROCEDURE [dbo].[usp_wv_dto_ARForcast] 
		@UserID        AS VARCHAR(100),
        @ClientCode    AS VARCHAR(6),
        @OFFICE_CODE AS VARCHAR(6)
AS


DECLARE @RESTRICTIONS  INT
DECLARE @RESTRICTIONSOFFICE  INT, @EmpCode varchar(6)

SET NOCOUNT ON
SET ANSI_NULLS ON
SET ANSI_WARNINGS OFF
SET ARITHABORT OFF
SET ARITHIGNORE ON

IF @ClientCode = '%' OR @ClientCode IS NULL
BEGIN
	SET @ClientCode = ''
END

IF @OFFICE_CODE = '%' OR @OFFICE_CODE IS NULL
BEGIN
	SET @OFFICE_CODE = ''
END


--Create First Temp Table
CREATE TABLE #temp
(
	Days         Integer,
	ClientCode   VARCHAR(6),
	AROpenAmt    DECIMAL(20, 2),
	CRAmt        DECIMAL(20, 2),
	InvoiceNo    Integer,
	InvoiceDate  DATETIME,
	OFFICE_CODE	 VARCHAR(4)
)

--Create Second Temp Table
CREATE TABLE #temp2
(
	ClientCode    VARCHAR(6),
	AvgDays       Integer,
	OpenAmt       DECIMAL(10, 2),
	TotalOpenAmt  DECIMAL(10, 2),
	ForcastDate   DATETIME,
	OFFICE_CODE	 VARCHAR(4)
)


--Look for Client/Division/Product security
SELECT @RESTRICTIONS = COUNT(*)
FROM   SEC_CLIENT WITH(NOLOCK)
WHERE  [USER_ID] = @UserID;

Select @EmpCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RESTRICTIONSOFFICE = COUNT(*)
FROM   EMP_OFFICE WITH(NOLOCK)
WHERE  [EMP_CODE] = @EmpCode;

DECLARE @SQL VARCHAR(8000)

SET @SQL = '
    INSERT INTO #temp
	SELECT  DATEDIFF([Day],MAX(ACCT_REC.AR_INV_DATE),MAX(CR_CLIENT.CR_CHECK_DATE)) AS Days,	
           ACCT_REC.CL_CODE AS ClientCode,
           NULL,
           NULL,
           ACCT_REC.AR_INV_NBR AS InvoiceNo,
           ACCT_REC.AR_INV_DATE AS InvoiceDate,
           ACCT_REC.OFFICE_CODE
    FROM   ACCT_REC WITH(NOLOCK)
           INNER JOIN CR_CLIENT_DTL WITH(NOLOCK)
                ON  CR_CLIENT_DTL.AR_INV_NBR = ACCT_REC.AR_INV_NBR
                    AND CR_CLIENT_DTL.AR_INV_SEQ = ACCT_REC.AR_INV_SEQ
                    AND CR_CLIENT_DTL.AR_TYPE = ACCT_REC.AR_TYPE
           INNER JOIN CR_CLIENT WITH(NOLOCK)
                ON  CR_CLIENT.REC_ID = CR_CLIENT_DTL.REC_ID
                    AND CR_CLIENT.SEQ_NBR = CR_CLIENT_DTL.SEQ_NBR LEFT OUTER JOIN
											  CLIENT ON ACCT_REC.CL_CODE = CLIENT.CL_CODE
'
IF @RESTRICTIONS > 0
BEGIN
	SET @SQL = @SQL + '
           INNER JOIN SEC_CLIENT WITH(NOLOCK)
                ON  ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE
                    AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE
                    AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE
'
END
IF @RESTRICTIONSOFFICE > 0
BEGIN
	SET @SQL = @SQL + '
           INNER JOIN EMP_OFFICE ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
'                    
   	
END

SET @SQL = @SQL + ' WHERE 1=1'

IF @OFFICE_CODE <> ''
BEGIN
	SET @SQL = @SQL + ' AND (ACCT_REC.OFFICE_CODE = ''' + @OFFICE_CODE + ''')'
END
IF @RESTRICTIONS > 0
BEGIN
	SET @SQL = @SQL + '
           AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
'
END
IF @RESTRICTIONSOFFICE > 0
BEGIN
	SET @SQL = @SQL + '
           AND (EMP_OFFICE.EMP_CODE = ''' + @EmpCode + ''')
'  	
END


SET @SQL = @SQL + '
    GROUP BY
           ACCT_REC.CL_CODE,
           ACCT_REC.AR_INV_NBR,
           ACCT_REC.AR_INV_DATE,
           ACCT_REC.AR_INV_SEQ,
           ACCT_REC.AR_TYPE,
           ACCT_REC.VOID_FLAG,
           ACCT_REC.OFFICE_CODE,
		   ACCT_REC.DUE_DATE,
		   CL_P_PAYDAYS,
		   CL_M_PAYDAYS,
		   ACCT_REC.REC_TYPE
    HAVING (ACCT_REC.AR_INV_SEQ <> 99) 
           AND (ACCT_REC.AR_TYPE = ''IN'') 
           AND (ACCT_REC.VOID_FLAG <> 1 OR ACCT_REC.VOID_FLAG IS NULL) 
           AND (DATEDIFF([day], ACCT_REC.AR_INV_DATE, GETDATE()) < 730)
'
IF @ClientCode <> ''
BEGIN
	SET @SQL = @SQL + ' AND ACCT_REC.CL_CODE = ''' + @ClientCode + ''''
END

PRINT @SQL
EXEC(@SQL)

SET @SQL = ''
SET @SQL = '
    INSERT INTO #temp
    SELECT NULL,
           ACCT_REC.CL_CODE,
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
    '
IF @RESTRICTIONS > 0
BEGIN
	SET @SQL = @SQL + '
           INNER JOIN SEC_CLIENT WITH(NOLOCK)
                ON  ACCT_REC.CL_CODE = SEC_CLIENT.CL_CODE
                    AND ACCT_REC.DIV_CODE = SEC_CLIENT.DIV_CODE
                    AND ACCT_REC.PRD_CODE = SEC_CLIENT.PRD_CODE
'
END
IF @RESTRICTIONSOFFICE > 0
BEGIN
	SET @SQL = @SQL + '
           INNER JOIN EMP_OFFICE ON ACCT_REC.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
'                    
   	
END
SET @SQL = @SQL + '
    WHERE  (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL) AND (ACCT_REC.VOID_FLAG <> 1 OR ACCT_REC.VOID_FLAG IS NULL)
'
IF @RESTRICTIONS > 0
BEGIN
	SET @SQL = @SQL + '
           AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
'
END
IF @RESTRICTIONSOFFICE > 0
BEGIN
	SET @SQL = @SQL + '
           AND (EMP_OFFICE.EMP_CODE = ''' + @EmpCode + ''')
'  	
END
IF @ClientCode <> ''
BEGIN
	SET @SQL = @SQL + ' AND ACCT_REC.CL_CODE = ''' + @ClientCode + ''''
END
IF @OFFICE_CODE <> ''
BEGIN
	SET @SQL = @SQL + ' AND (ACCT_REC.OFFICE_CODE = ''' + @OFFICE_CODE + ''')'
END
SET @SQL = @SQL + '
    GROUP BY
           ACCT_REC.CL_CODE,
           ACCT_REC.AR_INV_NBR,
           ACCT_REC.AR_INV_SEQ,
           ACCT_REC.AR_TYPE,
           ACCT_REC.AR_INV_DATE,
           ACCT_REC.OFFICE_CODE,
		   ACCT_REC.VOID_FLAG
'
--PRINT @SQL
EXEC(@SQL)

INSERT INTO #temp2
  (
    ClientCode,
    AvgDays,
    OpenAmt,
    ForcastDate,
    OFFICE_CODE
  )
SELECT ClientCode,
       AvgDays = (
           SELECT ISNULL(AVG(B.Days) * SIGN(ABS(SIGN(AVG(B.Days)) + 1)), 0)
           FROM   #temp B
           WHERE  B.ClientCode = #temp.ClientCode
       ),
       ISNULL(ISNULL(AROpenAmt, 0) - ISNULL(CRAmt, 0), 0),
       InvoiceDate,
       OFFICE_CODE
FROM   #temp;

DELETE 
FROM   #temp2
WHERE  (OpenAmt = 0.00);

UPDATE #temp2
SET    ForcastDate = CASE 
                          WHEN DATEADD(DAY, AvgDays, ForcastDate) < GETDATE() THEN GETDATE()
                          ELSE DATEADD(DAY, AvgDays, ForcastDate)
                     END,
       TotalOpenAmt = (
           SELECT ISNULL(SUM(B.OpenAmt), 0)
           FROM   #temp2 B
           WHERE  B.ClientCode = #temp2.ClientCode
       );

SET @SQL = ''
SET @SQL = '
	SELECT #temp2.ClientCode,
		   #temp2.AvgDays,
		   SUM(#temp2.OpenAmt) AS OpenAmt,
		   #temp2.TotalOpenAmt,
		   #temp2.ForcastDate,
		   #temp2.OFFICE_CODE
	FROM   #temp2
	WHERE  1 = 1 AND #temp2.OpenAmt <> 0 AND #temp2.TotalOpenAmt <> 0'
IF @ClientCode <> ''
BEGIN
	SET @SQL = @SQL + ' AND #temp2.ClientCode = ''' + @ClientCode + ''''
END
IF @OFFICE_CODE <> ''
BEGIN
	SET @SQL = @SQL + ' AND (#temp2.OFFICE_CODE = ''' + @OFFICE_CODE + ''')'
END
SET @SQL = @SQL + ' 
	GROUP BY
		   #temp2.ClientCode,
		   #temp2.AvgDays,
		   #temp2.TotalOpenAmt,
		   #temp2.ForcastDate,
		   #temp2.OFFICE_CODE
	ORDER BY
		   #temp2.ClientCode;
'
EXEC(@SQL);

DROP TABLE #temp;
DROP TABLE #temp2;




GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

