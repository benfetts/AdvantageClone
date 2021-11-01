IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_reports_ar_statements_product_003]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_reports_ar_statements_product_003]
GO




















/* CHANGE LOG:
==========================================================
CTB, 20060711:
    Made sure to initialize the OnAccountAmount if the
    select statement populating it returned 0 rows.
ST, 20060707:
	Converted all decimal datatypes to money
ST, 20060517:
	- Added switches:
	SET ANSI_NULLS ON
	SET ANSI_WARNINGS OFF
	SET ARITHABORT OFF
	SET ARITHIGNORE ON

*/





CREATE PROCEDURE [dbo].[usp_wv_reports_ar_statements_product_003] 
@ID VarChar(4000),
@PostPeriod VarChar(6),
@Location VarChar(6),
@AgedDate smalldatetime,
@Footer Varchar(400),
@OFFICE_CODES VARCHAR(8000),
@AgingDateType smallint


AS



--Creating a temp table to handle a multidimensional array past by the application for ClientID, DivID, ProductID, ContID, OnAccount, AddressUsed, Template

set nocount on

SET ANSI_NULLS ON
SET ANSI_WARNINGS OFF
SET ARITHABORT OFF
SET ARITHIGNORE ON

Declare @CR_ClientCode varchar(6)
Declare @CR_DivisionCode varchar(6)
Declare @CR_ProductCode varchar(6)
Declare @CR_ContactCode varchar(6)
Declare @CR_UseAddress varchar(1)
Declare @CR_IncludeOnAccount varchar(1)
Declare @CR_ClientName varchar(50) 
Declare @CR_DivisionName varchar(50)
Declare @CR_ProductDescription varchar(2000)
Declare @CR_FirstName varchar(50) 
Declare @CR_LastName varchar(50)
Declare @CR_SAddress1 varchar(50)
Declare @CR_SAddress2 varchar(50)
Declare @CR_SCity varchar(35) 
Declare @CR_SState varchar(2)
Declare @CR_SZip varchar(10)
Declare @CR_CAddress1 varchar(50)
Declare @CR_CAddress2 varchar(50)
Declare @CR_CCity varchar(35)
Declare @CR_CState varchar(2)
Declare @CR_CZip varchar(10) 
Declare @CR_InvoiceDate smalldatetime
Declare @CR_InvoiceNumber varchar(20) 
Declare @CR_SeqNo smallint
Declare @CR_JobNumber varchar(12)
Declare @CR_JobDescription varchar(250)
Declare @CR_ARDescription varchar(250)
Declare @CR_InvoiceAmount as money
Declare @CR_PostingPeriod varchar(6)
Declare @CR_DaysAged int
Declare @CR_Comments varchar(2000)
Declare @CR_OnAccountAmount  as Money
Declare @CR_OnAccount varchar(1)
Declare @CR_AddressUse varchar(1)
Declare @CR_Template varchar(1)
Declare @CR_AgencyName varchar(50)
Declare @CR_AgencyAddress1 varchar(50)
Declare @CR_AgencyAddress2 varchar(50)
Declare @CR_AgencyCity varchar(35)
Declare @CR_AgencyState varchar(10)
Declare @CR_AgencyZip varchar(10)
Declare @CR_AgencyPhone varchar(20) 
Declare @CR_AgencyFax varchar(20) 
Declare @CR_AgencyEmail varchar(60) 
Declare @CR_PrtHeader int 
Declare @CR_PrtAddr1 int 
Declare @CR_PrtAddr2 int
Declare @CR_PrtCity int 
Declare @CR_PrtState int
Declare @CR_PrtZip int 
Declare @CR_PrtPhone int 
Declare @CR_PrtFax int 
Declare @CR_PrtEmail int
Declare @CR_PrtFooter int 
Declare @CR_PrtFtrAddr1 int 
Declare @CR_PrtFtrAddr2 int 
Declare @CR_PrtFtrCity int 
Declare @CR_PrtFtrState int
Declare @CR_PrtFtrZip int 	
Declare @CR_PrtFtrPhone int 
Declare @CR_PrtFtrFax int 
Declare @CR_PrtFtrEmail int 
Declare @CR_PrtName int
Declare @CR_PrtFtrName int 
Declare @CR_LogoPath varchar(254)
Declare @CR_CurrentAR as Money
Declare @CR_OverThirtyAR as Money
Declare @CR_OverSixtyAR as Money
Declare @CR_TotalAR as Money
Declare @CR_REC_TYPE varchar(3)
Declare @CR_MANUAL_INV int
Declare @CR_ORDER_TYPE varchar(1)	
Declare @CDP_CONTACT_ID INT	

--Add Location to the Temp Table
declare @AgencyName varchar(50)
declare @AgencyAddress1 varchar(50)
declare @AgencyAddress2 varchar(50)
declare @AgencyCity varchar(35)
declare @AgencyState varchar(10)
declare @AgencyZip varchar(10)
declare @LogoPath varchar(254)
declare @AgencyPhone varchar(20)
declare @AgencyFax varchar(20)
declare @AgencyEmail varchar(60)
declare @PrtHeader int
declare @PrtAddr1 int
declare @PrtAddr2 int
declare @PrtCity int
declare @PrtState int
declare @PrtZip int
declare @PrtPhone int
declare @PrtFax int
declare @PrtEmail int
declare @PrtFooter int
declare @PrtFtrAddr1 int
declare @PrtFtrAddr2 int
declare @PrtFtrCity int
declare @PrtFtrState int
declare @PrtFtrZip int
declare @PrtFtrPhone int
declare @PrtFtrFax int
declare @PrtFtrEmail int
declare @PrtName int
declare @PrtFtrName int

declare @JobCount int
declare @ARCount int

Select @AgencyName = NAME, @AgencyAddress1 = isnull(ADDRESS1, ''), @AgencyAddress2 = ADDRESS2, @AgencyCity = isnull(CITY, ''), @AgencyState = isnull(STATE,''), @AgencyZip = isnull(ZIP, ''), 
@AgencyPhone = isnull(PHONE, ''), @AgencyFax = isnull(FAX, ''), @AgencyEmail = isnull(EMAIL, ''), @PrtHeader = PRT_HEADER, @PrtAddr1 = PRT_ADDR1, @PrtAddr2 = PRT_ADDR2,
@PrtCity = PRT_CITY, @PrtState = PRT_STATE, @PrtZip = PRT_ZIP, @PrtPhone = PRT_PHONE, @PrtFax = PRT_FAX, @PrtEmail = PRT_EMAIL,
@PrtFooter = PRT_FOOTER, @PrtFtrAddr1 = PRT_ADDR1_FTR, @PrtFtrAddr2 = PRT_ADDR2_FTR, @PrtFtrCity = PRT_CITY_FTR, @PrtFtrState = PRT_STATE_FTR,
@PrtFtrZip = PRT_ZIP_FTR, @PrtFtrPhone = PRT_PHONE_FTR, @PrtFtrFax = PRT_FAX_FTR, @PrtFtrEmail = PRT_EMAIL_FTR, @PrtName = PRT_NAME,
@PrtFtrName = PRT_NAME_FTR, @LogoPath = LOGO_PATH From LOCATIONS where ID = @Location and LOGO_LOCATION <> 'N'

-- @ID is the array we wish to parse

declare @pairseparator char(1)
declare @rowseparator char(1)
declare @separator_position int -- This is used to locate each separator character
declare @pairseparator_position int -- This is used to locate each separator character
declare @pairseparator_position1 int
declare @pairseparator_position2 int
declare @pairseparator_position3 int
declare @array_value varchar(1000) -- this holds each array value as it is returned
declare @pair_value1 varchar(6)
declare @pair_value2 varchar(6)
declare @pair_value3 varchar(6)
declare @pair_value4 varchar(6)
declare @pair_value5 varchar(1)
declare @pair_value6 varchar(1)
declare @pair_value7 varchar(1)

-- @pairseparator is the field separator charactor such as a comma
-- @rowseparator is the row separator charactor such as a semicolon

set @pairseparator = ','
set @rowseparator = ';'

declare @AR_LINE_ITEM table (ClientCode varchar(6), DivisionCode varchar(6), ProductCode varchar(6), ContactCode varchar(6), UseAddress varchar(1), IncludeOnAccount varchar(1),
ClientName varchar(50), DivisionName varchar(50), ProductDescription varchar(2000), FirstName varchar(50), LastName varchar(50), SAddress1 varchar(50), SAddress2 varchar(50), 
SCity varchar(35), SState varchar(2), SZip varchar(10), CAddress1 varchar(50), CAddress2 varchar(50), CCity varchar(35), CState varchar(2), CZip varchar(10), InvoiceDate smalldatetime, InvoiceNumber varchar(6), InvoiceSeq smallint, Reference  varchar(6), 
Description varchar(200), InvoiceAmount Money, PostingPeriod varchar(6), DaysAged int, Comments varchar(2000), OnAccountAmount Money, OnAccount varchar(1), 
AddressUse varchar(1), Template varchar(1), AgencyName varchar(50), AgencyAddress1 varchar(50), AgencyAddress2 varchar(50), AgencyCity varchar(35), AgencyState varchar(10), AgencyZip varchar(10), 
AgencyPhone varchar(20), AgencyFax varchar(20), AgencyEmail varchar(60), PrtHeader int, PrtAddr1 int, PrtAddr2 int, PrtCity int, PrtState int, PrtZip int,  
PrtPhone int, PrtFax int, PrtEmail int, PrtFooter int, PrtFtrAddr1 int, PrtFtrAddr2 int, PrtFtrCity int, PrtFtrState int, 
PrtFtrZip int, PrtFtrPhone int, PrtFtrFax int, PrtFtrEmail int, PrtName int, PrtFtrName int, LogoPath varchar(254), 
CurrentAR Money, OverThirtyAR Money, OverSixtyAR Money, TotalAR Money, CDP_CONTACT_ID INT)

-- For my loop to work I need an extra separator at the end. I always look to the
-- left of the separator character for each array value
set @ID = @ID + @rowseparator

-- Loop through the string searching for separtor characters
while patindex('%' + @rowseparator + '%' , @ID) <> 0 
begin
-- patindex matches the a pattern against a string
select @separator_position = patindex('%' + @rowseparator + '%' , @ID)
select @array_value = left(@ID, @separator_position - 1)

select @pairseparator_position = charindex(@pairseparator, @array_value)
select @pairseparator_position1 = charindex(@pairseparator, @array_value, @pairseparator_position + 1 )
select @pairseparator_position2 = charindex(@pairseparator, @array_value, @pairseparator_position1 + 1 )
select @pairseparator_position3 = charindex(@pairseparator, @array_value, @pairseparator_position2 + 1 )
select @pair_value1 = substring(@array_value, @pairseparator_position - (@pairseparator_position - 1), @pairseparator_position - 1)
select @pair_value2 = substring(@array_value, charindex(@pairseparator, @array_value) + 1,charindex(@pairseparator, @array_value, charindex(@pairseparator, @array_value) + 1) - charindex(@pairseparator, @array_value) - 1)
select @pair_value3 = substring(@array_value, @pairseparator_position1 + 1,charindex(@pairseparator, @array_value, @pairseparator_position1 + 1) - @pairseparator_position1 - 1)
select @pair_value4 = substring(@array_value, @pairseparator_position2 + 1,charindex(@pairseparator, @array_value, @pairseparator_position2 + 1) - @pairseparator_position2 - 1)
select @pair_value5 = substring(@array_value, @pairseparator_position3 + 1,charindex(@pairseparator, @array_value, @pairseparator_position3 + 1) - @pairseparator_position3 - 1)
select @pair_value6 = substring(reverse(@array_value), charindex(@pairseparator, reverse(@array_value)) + 1, charindex(@pairseparator, reverse(@array_value), charindex(@pairseparator, reverse(@array_value)) + 1) - charindex(@pairseparator, reverse(@array_value)) - 1)
select @pair_value7 = substring(reverse(@array_value), 1, charindex(@pairseparator, reverse(@array_value)) - 1)

--Get Current, Over Thirty and Over 60 totals

declare @Current as Money
declare @OverThirty as Money
declare @OverSixty as Money 
declare @TotalAR as Money
declare @Rescrictions as Money
declare @TotalHours as Money

Set @Current = 0
Set @OverThirty = 0
Set @OverSixty = 0

declare @T_AR306090PAY table (tr_CL_CODE varchar(6), tr_DIV_CODE varchar(6), tr_PRD_CODE varchar(6), tr_INV_NBR int, tr_INV_SEQ smallint, CR_AMT Money)


IF OBJECT_ID('tempdb..#T_AR306090AMT') IS NOT NULL
BEGIN
	DROP TABLE #T_AR306090AMT
END
CREATE TABLE #T_AR306090AMT (t_CL_CODE varchar(6) COLLATE SQL_Latin1_General_Cp1_CI_AS, t_DIV_CODE varchar(6) COLLATE SQL_Latin1_General_Cp1_CI_AS, t_PRD_CODE varchar(6) COLLATE SQL_Latin1_General_Cp1_CI_AS, t_INV_NBR int, t_INV_SEQ smallint, t_PostPeriod varchar(6) COLLATE SQL_Latin1_General_Cp1_CI_AS, t_Bucket varchar(4) COLLATE SQL_Latin1_General_Cp1_CI_AS, AR_AMOUNT Money)
declare @T_AR306090 table (t_CL_CODE varchar(6), t_DIV_CODE varchar(6), t_PRD_CODE varchar(6), t_INV_NBR int, t_INV_SEQ smallint, t_PostPeriod varchar(6), t_Bucket varchar(4), AR_AMOUNT Money, CR_AMT Money)

delete  from @T_AR306090PAY
delete  from #T_AR306090AMT
delete  from @T_AR306090


DECLARE @SQL VARCHAR(8000), @PARAMS VARCHAR(8000)
IF @OFFICE_CODES IS NULL OR @OFFICE_CODES = '%'
BEGIN
	SET @OFFICE_CODES = ''
END

SET @SQL = '
INSERT INTO #T_AR306090AMT
SELECT ACCT_REC.CL_CODE,
       ACCT_REC.DIV_CODE,
       ACCT_REC.PRD_CODE,
       ACCT_REC.AR_INV_NBR,
       ACCT_REC.AR_INV_SEQ,
       ACCT_REC.AR_POST_PERIOD,
       ''00'',
       SUM(ACCT_REC.AR_INV_AMOUNT)
FROM   ACCT_REC
       INNER JOIN CLIENT
            ON  ACCT_REC.CL_CODE = CLIENT.CL_CODE
WHERE  ACCT_REC.AR_POST_PERIOD <= ''' + @PostPeriod + '''
       AND (ACCT_REC.CL_CODE LIKE ''' + @pair_value1 + ''')
       AND (ACCT_REC.DIV_CODE LIKE ''' + @pair_value2 + ''')
       AND (ACCT_REC.PRD_CODE LIKE ''' + @pair_value3 + ''')'

IF @AgingDateType = 1
Begin
	SET @SQL = @SQL + '
       AND (
               ACCT_REC.AR_INV_DATE >= DATEADD(DAY, -30, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))
           ) '
End

if @AgingDateType = 2
Begin
	SET @SQL = @SQL + '
       AND (
               CASE 
                    WHEN ACCT_REC.REC_TYPE = ''P'' THEN 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE CASE 
                                                           WHEN CL_P_PAYDAYS IS 
                                                                NOT NULL THEN 
                                                                DATEADD(DAY, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE)
                                                           ELSE ACCT_REC.AR_INV_DATE
                                                      END
					END
                    ELSE 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE 
							CASE 
                              WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(DAY, CL_M_PAYDAYS, ACCT_REC.AR_INV_DATE)
                              ELSE ACCT_REC.AR_INV_DATE
                         END
					END
               END >= DATEADD(DAY, -30, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))
           ) '
End



SET @SQL = @SQL + ' AND (ACCT_REC.VOID_FLAG = 0 OR ACCT_REC.VOID_FLAG IS NULL)
       AND (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL) '
IF @OFFICE_CODES <> ''
BEGIN
	SET @SQL = @SQL + ' AND (ACCT_REC.OFFICE_CODE IN (' + @OFFICE_CODES + ')) '
END              
SET @SQL = @SQL + '             
GROUP BY
       ACCT_REC.CL_CODE,
       ACCT_REC.DIV_CODE,
       ACCT_REC.PRD_CODE,
       ACCT_REC.AR_INV_NBR,
       ACCT_REC.AR_INV_SEQ,
       ACCT_REC.AR_POST_PERIOD
'
EXEC(@SQL);

SET @SQL = ''
SET @SQL = '
INSERT INTO #T_AR306090AMT
SELECT ACCT_REC.CL_CODE,
       ACCT_REC.DIV_CODE,
       ACCT_REC.PRD_CODE,
       ACCT_REC.AR_INV_NBR,
       ACCT_REC.AR_INV_SEQ,
       ACCT_REC.AR_POST_PERIOD,
       ''30'',
       SUM(ACCT_REC.AR_INV_AMOUNT)
FROM   ACCT_REC
       INNER JOIN CLIENT
            ON  ACCT_REC.CL_CODE = CLIENT.CL_CODE
WHERE  ACCT_REC.AR_POST_PERIOD <= ''' + @PostPeriod + '''
       AND (ACCT_REC.CL_CODE LIKE ''' + @pair_value1 + ''')
       AND (ACCT_REC.DIV_CODE LIKE ''' + @pair_value2 + ''')
       AND (ACCT_REC.PRD_CODE LIKE ''' + @pair_value3 + ''')'

IF @AgingDateType = 1
Begin
	SET @SQL = @SQL + '
       AND (
               ACCT_REC.AR_INV_DATE >= DATEADD(DAY, -60, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))
               AND ACCT_REC.AR_INV_DATE <= DATEADD(DAY, -31, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))
           ) '
End

if @AgingDateType = 2
Begin
	SET @SQL = @SQL + '
       AND (
			   CASE 
                    WHEN ACCT_REC.REC_TYPE = ''P'' THEN 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE CASE 
                                                           WHEN CL_P_PAYDAYS IS 
                                                                NOT NULL THEN 
                                                                DATEADD(DAY, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE)
                                                           ELSE ACCT_REC.AR_INV_DATE
                                                      END
					END
                    ELSE 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE 
							CASE 
                              WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(DAY, CL_M_PAYDAYS, ACCT_REC.AR_INV_DATE)
                              ELSE ACCT_REC.AR_INV_DATE
                         END
					END
               END >= DATEADD(DAY, -60, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))
               AND CASE 
                        WHEN ACCT_REC.REC_TYPE = ''P'' THEN 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE CASE 
                                                           WHEN CL_P_PAYDAYS IS 
                                                                NOT NULL THEN 
                                                                DATEADD(DAY, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE)
                                                           ELSE ACCT_REC.AR_INV_DATE
                                                      END
					END
                    ELSE 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE 
							CASE 
                              WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(DAY, CL_M_PAYDAYS, ACCT_REC.AR_INV_DATE)
                              ELSE ACCT_REC.AR_INV_DATE
                         END
					END
                   END <= DATEADD(DAY, -31, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))              
           ) '
End



SET @SQL = @SQL + ' AND (ACCT_REC.VOID_FLAG = 0 OR ACCT_REC.VOID_FLAG IS NULL)
       AND (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL) '
IF @OFFICE_CODES <> ''
BEGIN
	SET @SQL = @SQL + ' AND (ACCT_REC.OFFICE_CODE IN (' + @OFFICE_CODES + ')) '
END              
SET @SQL = @SQL + '             
GROUP BY
       ACCT_REC.CL_CODE,
       ACCT_REC.DIV_CODE,
       ACCT_REC.PRD_CODE,
       ACCT_REC.AR_INV_NBR,
       ACCT_REC.AR_INV_SEQ,
       ACCT_REC.AR_POST_PERIOD
'
EXEC(@SQL);

SET @SQL = ''
SET @SQL = '
INSERT INTO #T_AR306090AMT
SELECT ACCT_REC.CL_CODE,
       ACCT_REC.DIV_CODE,
       ACCT_REC.PRD_CODE,
       ACCT_REC.AR_INV_NBR,
       ACCT_REC.AR_INV_SEQ,
       ACCT_REC.AR_POST_PERIOD,
       ''60'',
       SUM(ACCT_REC.AR_INV_AMOUNT)
FROM   ACCT_REC
       INNER JOIN CLIENT
            ON  ACCT_REC.CL_CODE = CLIENT.CL_CODE
WHERE  ACCT_REC.AR_POST_PERIOD <= ''' + @PostPeriod + '''
       AND (ACCT_REC.CL_CODE LIKE ''' + @pair_value1 + ''')
       AND (ACCT_REC.DIV_CODE LIKE ''' + @pair_value2 + ''')
       AND (ACCT_REC.PRD_CODE LIKE ''' + @pair_value3 + ''')'

IF @AgingDateType = 1
Begin
	SET @SQL = @SQL + '
       AND (
               ACCT_REC.AR_INV_DATE <= DATEADD(DAY, -61, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))
           ) '
End

if @AgingDateType = 2
Begin
	SET @SQL = @SQL + '
       AND (
               CASE 
                    WHEN ACCT_REC.REC_TYPE = ''P'' THEN 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE CASE 
                                                           WHEN CL_P_PAYDAYS IS 
                                                                NOT NULL THEN 
                                                                DATEADD(DAY, CL_P_PAYDAYS, ACCT_REC.AR_INV_DATE)
                                                           ELSE ACCT_REC.AR_INV_DATE
                                                      END
					END
                    ELSE 
					CASE WHEN ACCT_REC.DUE_DATE IS NOT NULL THEN ACCT_REC.DUE_DATE 
							ELSE 
							CASE 
                              WHEN CL_M_PAYDAYS IS NOT NULL THEN DATEADD(DAY, CL_M_PAYDAYS, ACCT_REC.AR_INV_DATE)
                              ELSE ACCT_REC.AR_INV_DATE
                         END
					END
               END <= DATEADD(DAY, -61, CAST('''+CAST(@AgedDate as varchar)+''' AS DATETIME))
           ) '
End



SET @SQL = @SQL + ' AND (ACCT_REC.VOID_FLAG = 0 OR ACCT_REC.VOID_FLAG IS NULL)
       AND (ACCT_REC.AR_INV_SEQ <> 99 OR ACCT_REC.AR_INV_SEQ IS NULL) '
IF @OFFICE_CODES <> ''
BEGIN
	SET @SQL = @SQL + ' AND (ACCT_REC.OFFICE_CODE IN (' + @OFFICE_CODES + ')) '
END              
SET @SQL = @SQL + '             
GROUP BY
       ACCT_REC.CL_CODE,
       ACCT_REC.DIV_CODE,
       ACCT_REC.PRD_CODE,
       ACCT_REC.AR_INV_NBR,
       ACCT_REC.AR_INV_SEQ,
       ACCT_REC.AR_POST_PERIOD
'
EXEC(@SQL);

SET @SQL = ''




insert into @T_AR306090PAY
SELECT t_CL_CODE, t_DIV_CODE, t_PRD_CODE, t_INV_NBR, t_INV_SEQ, (SUM(ISNULL(CR_CLIENT_DTL.CR_PAY_AMT, 0)) + sum(ISNULL(CR_CLIENT_DTL.CR_ADJ_AMT, 0)))
FROM  #T_AR306090AMT LEFT OUTER JOIN
	                      CR_CLIENT_DTL ON t_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND t_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ
group by   t_CL_CODE, t_DIV_CODE, t_PRD_CODE, t_INV_NBR, t_INV_SEQ

insert into @T_AR306090
Select t_CL_CODE, t_DIV_CODE, t_PRD_CODE, dbo.fn_LZ(6,t_INV_NBR), t_INV_SEQ, t_PostPeriod, t_Bucket, AR_AMOUNT, CR_AMT
From #T_AR306090AMT Left Outer Join @T_AR306090PAY on
t_INV_NBR = tr_INV_NBR AND t_INV_SEQ = tr_INV_SEQ

SELECT @Current = SUM(AR_AMOUNT - CR_AMT)
from @T_AR306090 where t_Bucket = '00'
group by t_CL_CODE, t_DIV_CODE, t_PRD_CODE 


SELECT @OverThirty = SUM(AR_AMOUNT - CR_AMT)
from @T_AR306090 where t_Bucket = '30'
group by t_CL_CODE, t_DIV_CODE, t_PRD_CODE 

SELECT @OverSixty = SUM(AR_AMOUNT - CR_AMT)
from @T_AR306090 where t_Bucket = '60'
group by t_CL_CODE, t_DIV_CODE, t_PRD_CODE 

Select @TotalAR = (Isnull(@Current, 0) + Isnull(@OverThirty, 0) + Isnull(@OverSixty, 0))
Select @Current = (Isnull(@Current, 0))
Select @OverThirty = (Isnull(@OverThirty, 0)) 
Select @OverSixty = (Isnull(@OverSixty, 0))

--## Getting all the On Account information for the clients
Declare @ClientCodeOA as varchar(6)
Declare @OnAccountAmount as Money

SELECT CR_CLIENT.CL_CODE as ClientCode,
	SUM(CR_ON_ACCT.CR_OA_AMT) as OnAcct
INTO	#AR_OnAccountDetail
FROM	CR_CLIENT 
	LEFT OUTER JOIN CR_ON_ACCT 
	ON CR_CLIENT.REC_ID = CR_ON_ACCT.REC_ID 
	AND CR_CLIENT.SEQ_NBR = CR_ON_ACCT.SEQ_NBR
WHERE	CR_CLIENT.REC_ID = CR_ON_ACCT.REC_ID
	AND CR_CLIENT.SEQ_NBR = CR_ON_ACCT.SEQ_NBR and
CR_CLIENT.CL_CODE = @pair_value1 and CR_ON_ACCT.DIV_CODE = @pair_value2 and CR_ON_ACCT.PRD_CODE = @pair_value3
GROUP BY
	CR_CLIENT.CL_CODE	
HAVING	SUM(CR_ON_ACCT.CR_OA_AMT)<>0

If @@ROWCOUNT > 0
   BEGIN
   select @ClientCodeOA = ClientCode, @OnAccountAmount = OnAcct from #AR_OnAccountDetail
   END
Else
   BEGIN
   SELECT @ClientCodeOA = '', @OnAccountAmount = 0
   END

IF OBJECT_ID('tempdb..#TEMP_AR_STATEMENT_LINE_OFFICES') IS NOT NULL
BEGIN
	DROP TABLE #TEMP_AR_STATEMENT_LINE_OFFICES
END
CREATE TABLE #TEMP_AR_STATEMENT_LINE_OFFICES
(
	OFFICE_CODE VARCHAR(4)		
)
IF @OFFICE_CODES <> ''
	BEGIN
		SET @SQL = 'INSERT INTO #TEMP_AR_STATEMENT_LINE_OFFICES SELECT OFFICE_CODE FROM OFFICE WHERE (OFFICE_CODE IN (' + @OFFICE_CODES + '));'
	END
ELSE
	BEGIN
		SET @SQL = 'INSERT INTO #TEMP_AR_STATEMENT_LINE_OFFICES SELECT OFFICE_CODE FROM OFFICE;'
	END
EXEC(@SQL);



Declare AR_STATEMENT_LINE CURSOR FOR
Select   PRODUCT_AR_STMT.CL_CODE as ClientCode, 
	PRODUCT_AR_STMT.DIV_CODE as DivisionCode, 
	PRODUCT_AR_STMT.PRD_CODE as ProductCode, 
	PRODUCT_AR_STMT.CDP_CONTACT_ID,
	PRODUCT_AR_STMT.CONT_CODE as ContactCode,
	PRODUCT_AR_STMT.USE_ADDRESS as UseAddress,
	PRODUCT_AR_STMT.INCL_ON_ACCT as IncludeOnAccount,
	C.CL_NAME AS ClientName, 
	D.DIV_NAME AS DivisionName,
	P.PRD_DESCRIPTION AS ProductDescription,
	CON.CONT_FNAME as FirstName, 
	CON.CONT_LNAME as LastName,
	P.PRD_STATE_ADDR1 as SAddress1,
	P.PRD_STATE_ADDR2 as SAddress2,
	P.PRD_STATE_CITY as SCity, 
	P.PRD_STATE_STATE as SState,
	P.PRD_STATE_ZIP as SZip,  
	CON.CONT_ADDRESS1 as CAddress1,
	CON.CONT_ADDRESS2 as CAddress2,
	CON.CONT_CITY as CCity, 
	CON.CONT_STATE as CState,
	CON.CONT_ZIP as CZip, 
	AR.AR_INV_DATE as InvoiceDate, 
	dbo.fn_LZ(6,AR.AR_INV_NBR) as InvoiceNumber,
	AR.AR_INV_SEQ, 
	--dbo.fn_LZ(6,AR.JOB_NUMBER) as JobNumber, 
	--J.JOB_DESC as JobDescription,
	'' as JobNumber, 
	'' as JobDescription,
	AR.AR_DESCRIPTION,
	SUM(DISTINCT AR.AR_INV_AMOUNT) as InvoiceAmount,	
	AR.AR_POST_PERIOD AS PostingPeriod,
	DATEDIFF(day, AR.AR_INV_DATE, @AgedDate) as DaysAged,
	(Select Cast(COMMENT as Varchar(2000)) From AGENCY_COMMENTS Where COMMENT_TYPE = 'AUTO_AR_STATEMENT') as Comments,
	OnAccountAmount = isnull(@OnAccountAmount, 0),
	OnAccount = @pair_value5,
	AddressUse = @pair_value6,
	Template = @pair_value7,
	AgencyName = @AgencyName,
	AgencyAddress1 = @AgencyAddress1,
	AgencyAddress2 = @AgencyAddress2,
	AgencyCity = @AgencyCity,
	AgencyState = @AgencyState,
	AgencyZip = @AgencyZip,	AgencyPhone = @AgencyPhone, 
	AgencyFax = @AgencyFax, 
	AgencyEmail = @AgencyEmail, 
	PrtHeader = @PrtHeader, 
	PrtAddr1 = @PrtAddr1, 
	PrtAddr2 = @PrtAddr2,
	PrtCity = @PrtCity, 
	PrtState = @PrtState, 
	PrtZip = @PrtZip, 
	PrtPhone = @PrtPhone, 
	PrtFax = @PrtFax, 
	PrtEmail = @PrtEmail,
	PrtFooter = @PrtFooter, 
	PrtFtrAddr1 = @PrtFtrAddr1, 
	PrtFtrAddr2 = @PrtFtrAddr2, 
	PrtFtrCity = @PrtFtrCity, 
	PrtFtrState = @PrtFtrState,
	PrtFtrZip = @PrtFtrZip, 	
	PrtFtrPhone = @PrtFtrPhone, 
	PrtFtrFax = @PrtFtrFax, 
	PrtFtrEmail = @PrtFtrEmail, 
	PrtName = @PrtName,
	PrtFtrName = @PrtFtrName, 
	LogoPath = @LogoPath,
	CurrentAR = @Current,
	OverThirtyAR = @OverThirty,
	OverSixtyAR = @OverSixty,
	TotalAR = @TotalAR,
	AR.REC_TYPE,
	AR.MANUAL_INV,
	ARINV_MEDIA.ORDER_TYPE				
from PRODUCT_AR_STMT	
	inner join ACCT_REC AR
		on AR.CL_CODE = PRODUCT_AR_STMT.CL_CODE
		and AR.DIV_CODE = PRODUCT_AR_STMT.DIV_CODE
		and AR.PRD_CODE = PRODUCT_AR_STMT.PRD_CODE
LEFT OUTER JOIN CR_CLIENT_DTL 
		ON AR.AR_INV_NBR = CR_CLIENT_DTL.AR_INV_NBR AND 
		AR.AR_INV_SEQ = CR_CLIENT_DTL.AR_INV_SEQ AND 
	              AR.AR_TYPE = CR_CLIENT_DTL.AR_TYPE
	LEFT OUTER JOIN ARINV_MEDIA 
		on AR.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR AND AR.REC_TYPE <> 'C'
	LEFT Outer Join @T_AR306090 
		on AR.AR_INV_NBR = t_INV_NBR and AR.AR_INV_SEQ = t_INV_SEQ
	Inner Join CLIENT C 
		on C.CL_CODE = PRODUCT_AR_STMT.CL_CODE
	Inner Join DIVISION D 
		on D.CL_CODE = PRODUCT_AR_STMT.CL_CODE
		and D.DIV_CODE = PRODUCT_AR_STMT.DIV_CODE		
	Inner Join PRODUCT P 
		on P.CL_CODE = PRODUCT_AR_STMT.CL_CODE
		and P.DIV_CODE = PRODUCT_AR_STMT.DIV_CODE
		and P.PRD_CODE = PRODUCT_AR_STMT.PRD_CODE
	LEFT OUTER JOIN JOB_LOG J
		ON J.JOB_NUMBER = AR.JOB_NUMBER
	Inner Join CDP_CONTACT_HDR CON
		ON CON.CDP_CONTACT_ID = PRODUCT_AR_STMT.CDP_CONTACT_ID
Where AR.AR_POST_PERIOD <= @PostPeriod and PRODUCT_AR_STMT.CL_CODE = @pair_value1 and 
	PRODUCT_AR_STMT.DIV_CODE = @pair_value2 and 
	PRODUCT_AR_STMT.PRD_CODE = @pair_value3 and
	PRODUCT_AR_STMT.CONT_CODE = @pair_value4  AND (AR.VOID_FLAG = 0 OR
             AR.VOID_FLAG IS NULL) AND (AR.AR_INV_SEQ <> 99 OR AR.AR_INV_SEQ IS NULL)
             AND (AR.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group By PRODUCT_AR_STMT.CL_CODE,
	PRODUCT_AR_STMT.DIV_CODE,
	PRODUCT_AR_STMT.PRD_CODE,
	PRODUCT_AR_STMT.CDP_CONTACT_ID,
	PRODUCT_AR_STMT.CONT_CODE,
	PRODUCT_AR_STMT.USE_ADDRESS,
	PRODUCT_AR_STMT.INCL_ON_ACCT,
	C.CL_NAME, 
	D.DIV_NAME,
	P.PRD_DESCRIPTION,
	CON.CONT_FNAME,
	CON.CONT_LNAME,
	P.PRD_STATE_ADDR1,
	P.PRD_STATE_ADDR2,
	P.PRD_STATE_CITY, 
	P.PRD_STATE_STATE,
	P.PRD_STATE_ZIP,  
	CON.CONT_ADDRESS1,
	CON.CONT_ADDRESS2,
	CON.CONT_CITY, 
	CON.CONT_STATE,
	CON.CONT_ZIP, 
	AR.AR_INV_DATE, 
	AR.AR_INV_NBR, 
	AR.AR_INV_SEQ,
	AR.JOB_NUMBER, 
	J.JOB_DESC,
	AR.AR_DESCRIPTION,
	AR.AR_POST_PERIOD,
	AR.REC_TYPE,
	AR.MANUAL_INV,
	ARINV_MEDIA.ORDER_TYPE		
HAVING SUM(DISTINCT AR.AR_INV_AMOUNT) - sum(distinct (isnull(CR_AMT, 0)))  <> 0

OPEN AR_STATEMENT_LINE

FETCH NEXT FROM AR_STATEMENT_LINE into
@CR_ClientCode,
@CR_DivisionCode,
@CR_ProductCode,
@CDP_CONTACT_ID,
@CR_ContactCode,
@CR_UseAddress,
@CR_IncludeOnAccount,
@CR_ClientName,
@CR_DivisionName, 
@CR_ProductDescription, 
@CR_FirstName,  
@CR_LastName, 
@CR_SAddress1, 
@CR_SAddress2, 
@CR_SCity,  
@CR_SState, 
@CR_SZip, 
@CR_CAddress1, 
@CR_CAddress2, 
@CR_CCity, 
@CR_CState, 
@CR_CZip, 
@CR_InvoiceDate, 
@CR_InvoiceNumber,
@CR_SeqNo,  
@CR_JobNumber, 
@CR_JobDescription,
@CR_ARDescription,

@CR_InvoiceAmount, 
@CR_PostingPeriod, 
@CR_DaysAged, 
@CR_Comments, 
@CR_OnAccountAmount, 
@CR_OnAccount, 
@CR_AddressUse, 

@CR_Template, 
@CR_AgencyName, 
@CR_AgencyAddress1, 
@CR_AgencyAddress2, 
@CR_AgencyCity, 
@CR_AgencyState, 
@CR_AgencyZip, 
@CR_AgencyPhone,  
@CR_AgencyFax, 
@CR_AgencyEmail,
@CR_PrtHeader, 
@CR_PrtAddr1,  
@CR_PrtAddr2, 
@CR_PrtCity,  
@CR_PrtState, 
@CR_PrtZip,  
@CR_PrtPhone, 
@CR_PrtFax,  
@CR_PrtEmail, 
@CR_PrtFooter,  
@CR_PrtFtrAddr1, 
@CR_PrtFtrAddr2,  
@CR_PrtFtrCity, 
@CR_PrtFtrState, 
@CR_PrtFtrZip, 	
@CR_PrtFtrPhone, 
@CR_PrtFtrFax, 
@CR_PrtFtrEmail, 
@CR_PrtName, 
@CR_PrtFtrName, 
@CR_LogoPath, 
@CR_CurrentAR, 
@CR_OverThirtyAR, 
@CR_OverSixtyAR, 
@CR_TotalAR,
@CR_REC_TYPE,
@CR_MANUAL_INV,
@CR_ORDER_TYPE

SELECT @ARCount = @@CURSOR_ROWS
--SELECT @ARCount
if @ARCount = 0 and @OnAccountAmount <> 0
Begin
	INSERT INTO @AR_LINE_ITEM
	Select TOP 1 PRODUCT_AR_STMT.CL_CODE as ClientCode, 
		PRODUCT_AR_STMT.DIV_CODE as DivisionCode, 
		PRODUCT_AR_STMT.PRD_CODE as ProductCode, 
		PRODUCT_AR_STMT.CONT_CODE as ContactCode,
		PRODUCT_AR_STMT.USE_ADDRESS as UseAddress,
		PRODUCT_AR_STMT.INCL_ON_ACCT as IncludeOnAccount,
		C.CL_NAME AS ClientName, 
		D.DIV_NAME AS DivisionName,
		P.PRD_DESCRIPTION AS ProductDescription,
		CON.CONT_FNAME as FirstName, 
		CON.CONT_LNAME as LastName,
		P.PRD_STATE_ADDR1 as SAddress1,
		P.PRD_STATE_ADDR2 as SAddress2,
		P.PRD_STATE_CITY as SCity, 
		P.PRD_STATE_STATE as SState,
		P.PRD_STATE_ZIP as SZip,  
		CON.CONT_ADDRESS1 as CAddress1,
		CON.CONT_ADDRESS2 as CAddress2,
		CON.CONT_CITY as CCity, 
		CON.CONT_STATE as CState,
		CON.CONT_ZIP as CZip, 
		NULL as InvoiceDate, 
		'' as InvoiceNumber, 
		'' as InvoiceSeq, 
		--dbo.fn_LZ(6,AR.JOB_NUMBER) as JobNumber, 
		--J.JOB_DESC as JobDescription,
		'' as JobNumber, 
		'' as JobDescription,
		0 as InvoiceAmount,	
		'' AS PostingPeriod,
		0 as DaysAged,
		(Select Cast(COMMENT as Varchar(2000)) From AGENCY_COMMENTS Where COMMENT_TYPE = 'AUTO_AR_STATEMENT') as Comments,
		OnAccountAmount = isnull(@OnAccountAmount, 0),
		OnAccount = @pair_value5,
		AddressUse = @pair_value6,
		Template = @pair_value7,
		AgencyName = ISNULL(@AgencyName,''),
		AgencyAddress1 = ISNULL(@AgencyAddress1,''),
		AgencyAddress2 = ISNULL(@AgencyAddress2,''),
		AgencyCity = ISNULL(@AgencyCity,''),
		AgencyState = ISNULL(@AgencyState,''),
		AgencyZip = ISNULL(@AgencyZip,''),
		AgencyPhone = ISNULL(@AgencyPhone,''), 
		AgencyFax = ISNULL(@AgencyFax,''), 
		AgencyEmail = ISNULL(@AgencyEmail,''), 
		PrtHeader = ISNULL(@PrtHeader,0), 
		PrtAddr1 = ISNULL(@PrtAddr1,0), 
		PrtAddr2 = ISNULL(@PrtAddr2,0),
		PrtCity = ISNULL(@PrtCity,0), 
		PrtState = ISNULL(@PrtState,0), 
		PrtZip = ISNULL(@PrtZip,0), 
		PrtPhone = ISNULL(@PrtPhone,0), 
		PrtFax = ISNULL(@PrtFax,0), 
		PrtEmail = ISNULL(@PrtEmail,0),
		PrtFooter = ISNULL(@PrtFooter,0), 
		PrtFtrAddr1 = ISNULL(@PrtFtrAddr1,0), 
		PrtFtrAddr2 = ISNULL(@PrtFtrAddr2,0), 
		PrtFtrCity = ISNULL(@PrtFtrCity,0), 
		PrtFtrState = ISNULL(@PrtFtrState,0),
		PrtFtrZip = ISNULL(@PrtFtrZip,0), 	
		PrtFtrPhone = ISNULL(@PrtFtrPhone,0), 
		PrtFtrFax = ISNULL(@PrtFtrFax,0), 
		PrtFtrEmail = ISNULL(@PrtFtrEmail,0), 
		PrtName = ISNULL(@PrtName,0),
		PrtFtrName = ISNULL(@PrtFtrName,0), 
		LogoPath = @LogoPath,
		CurrentAR = @Current,
		OverThirtyAR = @OverThirty,
		OverSixtyAR = @OverSixty,
		TotalAR = @TotalAR,
		PRODUCT_AR_STMT.CDP_CONTACT_ID
from PRODUCT_AR_STMT
	Inner Join CLIENT C 
		on C.CL_CODE = PRODUCT_AR_STMT.CL_CODE
	Inner Join DIVISION D 
		on D.CL_CODE = PRODUCT_AR_STMT.CL_CODE
		and D.DIV_CODE = PRODUCT_AR_STMT.DIV_CODE		
	Inner Join PRODUCT P 
		on P.CL_CODE = PRODUCT_AR_STMT.CL_CODE
		and P.DIV_CODE = PRODUCT_AR_STMT.DIV_CODE
		and P.PRD_CODE = PRODUCT_AR_STMT.PRD_CODE
	Inner Join CDP_CONTACT_HDR CON
		ON CON.CDP_CONTACT_ID = PRODUCT_AR_STMT.CDP_CONTACT_ID
Where PRODUCT_AR_STMT.CL_CODE = @pair_value1 and 
	PRODUCT_AR_STMT.DIV_CODE = @pair_value2 and 
	PRODUCT_AR_STMT.PRD_CODE = @pair_value3 and
	PRODUCT_AR_STMT.CONT_CODE = @pair_value4
Group By PRODUCT_AR_STMT.CL_CODE,
	PRODUCT_AR_STMT.DIV_CODE,
	PRODUCT_AR_STMT.PRD_CODE,
	PRODUCT_AR_STMT.CDP_CONTACT_ID,
	PRODUCT_AR_STMT.CONT_CODE,
	PRODUCT_AR_STMT.USE_ADDRESS,
	PRODUCT_AR_STMT.INCL_ON_ACCT,
	C.CL_NAME, 
	D.DIV_NAME,
	P.PRD_DESCRIPTION,
	CON.CONT_FNAME,
	CON.CONT_LNAME,
	P.PRD_STATE_ADDR1,
	P.PRD_STATE_ADDR2,
	P.PRD_STATE_CITY, 
	P.PRD_STATE_STATE,
	P.PRD_STATE_ZIP,  
	CON.CONT_ADDRESS1,
	CON.CONT_ADDRESS2,
	CON.CONT_CITY, 
	CON.CONT_STATE,
	CON.CONT_ZIP
End
 
while @@FETCH_STATUS=0
Begin

--If REC_TYPE = P then leave job description and reference
if @CR_REC_TYPE = 'P'
BEGIN	
	--SELECT @JobCount = Count(*) FROM ARINV_JOB WHERE AR_INV_NBR = @CR_InvoiceNumber
	SELECT @JobCount = COUNT(*) FROM (SELECT DISTINCT JOB_NUMBER FROM ARINV_JOB WHERE AR_INV_NBR = @CR_InvoiceNumber) A
	if @JobCount > 1
	Begin
		Set @CR_JobNumber = isnull(@CR_JobNumber, 'Various Jobs')
	End	
	if @JobCount = 1
	Begin
		Set @CR_JobNumber = (SELECT DISTINCT dbo.fn_LZ(6,ARINV_JOB.JOB_NUMBER) FROM ARINV_JOB WHERE AR_INV_NBR = @CR_InvoiceNumber)
		Set @CR_JobDescription = (SELECT JOB_DESC FROM JOB_LOG WHERE JOB_NUMBER = @CR_JobNumber)
	End	
	if @CR_JobNumber = '' 
	begin
		Set @CR_JobDescription = 'Various Jobs'
	end 
END

if @CR_REC_TYPE = 'C'
BEGIN	
	Set @CR_JobDescription = 'Various'	 
END

--IF MANUAL_INV = 1 then
IF @CR_MANUAL_INV = 1
BEGIN
Set @CR_JobNumber = '' 
Set @CR_JobDescription = @CR_ARDescription 
END

--IF REC_TYPE<>P  AND ORDER_TYPE = I PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null) and @CR_ORDER_TYPE = 'I' 
Begin
Declare INTERNET_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,max(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference, 'Internet' as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ --INNER JOIN INTERNET_HEADER ON INTERNET_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR INNER JOIN VENDOR ON VENDOR.VN_CODE = INTERNET_HEADER.VN_CODE
where ARINV_MEDIA.ORDER_TYPE = 'I'  and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, INTERNET_HEADER.ORDER_DESC
	
OPEN INTERNET_LINE

	FETCH NEXT FROM INTERNET_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM INTERNET_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE INTERNET_LINE

	DEALLOCATE INTERNET_LINE

End

--IF REC_TYPE<>P AND ORDER_TYPE = M PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null) and @CR_ORDER_TYPE = 'M' 
Begin
Declare MAG_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,min(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference,  'Magazine'  as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ --INNER JOIN MAG_HEADER ON MAG_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR INNER JOIN VENDOR ON VENDOR.VN_CODE = MAG_HEADER.VN_CODE
where ORDER_TYPE = 'M' and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, MAG_HEADER.ORDER_DESC

OPEN MAG_LINE

	FETCH NEXT FROM MAG_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM MAG_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE MAG_LINE

	DEALLOCATE MAG_LINE

End


--ST: 20061017
--IF REC_TYPE<>P AND ORDER_TYPE = M PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null) and @CR_ORDER_TYPE = 'M' 
Begin
Declare MAGAZINE_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,min(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference,  'Magazine'  as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ --INNER JOIN MAGAZINE_HEADER ON MAGAZINE_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR INNER JOIN VENDOR ON VENDOR.VN_CODE = MAGAZINE_HEADER.VN_CODE
where ORDER_TYPE = 'M' and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, MAGAZINE_HEADER.ORDER_DESC

OPEN MAGAZINE_LINE

	FETCH NEXT FROM MAGAZINE_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM MAGAZINE_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE MAGAZINE_LINE

	DEALLOCATE MAGAZINE_LINE

End


--IF REC_TYPE<>P  AND ORDER_TYPE = O PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null)  and @CR_ORDER_TYPE = 'O' 
Begin
Declare OUTDOOR_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,min(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference, 'Outdoor'  as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ --INNER JOIN OUTDOOR_HEADER ON OUTDOOR_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR INNER JOIN VENDOR ON VENDOR.VN_CODE = OUTDOOR_HEADER.VN_CODE
where ORDER_TYPE = 'O'  and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, OUTDOOR_HEADER.ORDER_DESC

OPEN OUTDOOR_LINE

	FETCH NEXT FROM OUTDOOR_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM OUTDOOR_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE OUTDOOR_LINE

	DEALLOCATE OUTDOOR_LINE

End

--IF REC_TYPE<>P  AND ORDER_TYPE = N PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null)  and @CR_ORDER_TYPE = 'N' 
Begin
Declare NEWS_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,min(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference, 'Newspaper' as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ  --INNER JOIN NEWS_HEADER ON NEWS_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR INNER JOIN VENDOR ON VENDOR.VN_CODE = NEWS_HEADER.VN_CODE
where ORDER_TYPE = 'N'  and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, NEWS_HEADER.ORDER_DESC

OPEN NEWS_LINE

	FETCH NEXT FROM NEWS_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM NEWS_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE NEWS_LINE

	DEALLOCATE NEWS_LINE

End

--ST
--IF REC_TYPE<>P  AND ORDER_TYPE = N PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null)  and @CR_ORDER_TYPE = 'N' 
Begin
Declare NEWSPAPER_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,min(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference, 'Newspaper' as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ  --INNER JOIN NEWSPAPER_HEADER ON NEWSPAPER_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR INNER JOIN VENDOR ON VENDOR.VN_CODE = NEWSPAPER_HEADER.VN_CODE
where ORDER_TYPE = 'N'  and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, NEWSPAPER_HEADER.ORDER_DESC

OPEN NEWSPAPER_LINE

	FETCH NEXT FROM NEWSPAPER_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM NEWSPAPER_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE NEWSPAPER_LINE

	DEALLOCATE NEWSPAPER_LINE

End




--IF REC_TYPE<>P   AND ORDER_TYPE = R PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null) and @CR_ORDER_TYPE = 'R' 
Begin
Declare RADIO_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,min(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference, 'Radio'  as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ -- Left Outer JOIN (SELECT RADIO_HEADER.ORDER_DESC + ' ' + isnull(VENDOR.VN_NAME, '') AS ORDER_DESC, RADIO_HEADER.ORDER_NBR FROM RADIO_HEADER INNER JOIN VENDOR ON RADIO_HEADER.VN_CODE = VENDOR.VN_CODE WHERE RADIO_HEADER.REV_NBR = (SELECT MAX(RADIO_HEADER.REV_NBR) FROM RADIO_HEADER INNER JOIN ARINV_MEDIA ON RADIO_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR WHERE ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber)) RH on RH.ORDER_NBR = ARINV_MEDIA.ORDER_NBR
where ORDER_TYPE = 'R' and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, RH.ORDER_DESC

OPEN RADIO_LINE

	FETCH NEXT FROM RADIO_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM RADIO_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE RADIO_LINE

	DEALLOCATE RADIO_LINE

End

--IF REC_TYPE<>P  AND ORDER_TYPE = T PRINT ORDER DESCRIPTION

If (@CR_REC_TYPE <> 'P' or @CR_REC_TYPE is null)  and @CR_ORDER_TYPE = 'T'
Begin
Declare TV_LINE CURSOR FOR
SELECT case When count(*) = 1 Then (convert(varchar(6),dbo.fn_LZ(6,min(ARINV_MEDIA.ORDER_NBR)))) else ' ' end as Reference, 'Television'  as DESCRIPTION
FROM ARINV_MEDIA INNER JOIN ACCT_REC ON ACCT_REC.AR_INV_NBR = ARINV_MEDIA.AR_INV_NBR and ACCT_REC.AR_INV_SEQ = ARINV_MEDIA.AR_INV_SEQ-- Left Outer JOIN (SELECT TV_HEADER.ORDER_DESC + ' ' + isnull(VENDOR.VN_NAME, '') AS ORDER_DESC, TV_HEADER.ORDER_NBR FROM TV_HEADER INNER JOIN VENDOR ON TV_HEADER.VN_CODE = VENDOR.VN_CODE WHERE TV_HEADER.REV_NBR = (SELECT MAX(TV_HEADER.REV_NBR) FROM TV_HEADER INNER JOIN ARINV_MEDIA ON TV_HEADER.ORDER_NBR = ARINV_MEDIA.ORDER_NBR WHERE ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber)) TV on TV.ORDER_NBR = ARINV_MEDIA.ORDER_NBR
where ORDER_TYPE = 'T' and ACCT_REC.AR_INV_NBR = @CR_InvoiceNumber and ARINV_MEDIA.LINE_NBR = (select max(ARINV_MEDIA.LINE_NBR) From ARINV_MEDIA where ARINV_MEDIA.AR_INV_NBR = @CR_InvoiceNumber) 
AND (ACCT_REC.OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS IN (SELECT OFFICE_CODE COLLATE SQL_Latin1_General_Cp1_CI_AS FROM #TEMP_AR_STATEMENT_LINE_OFFICES))
Group by ARINV_MEDIA.ORDER_TYPE, ACCT_REC.AR_DESCRIPTION, ARINV_MEDIA.AR_INV_NBR, ARINV_MEDIA.AR_INV_SEQ--, TV.ORDER_DESC

OPEN TV_LINE

	FETCH NEXT FROM TV_LINE into @CR_JobNumber, @CR_JobDescription
	WHILE @@FETCH_STATUS=0
	Begin
		     
	
		FETCH NEXT FROM TV_LINE into @CR_JobNumber, @CR_JobDescription
	END

	CLOSE TV_LINE

	DEALLOCATE TV_LINE

End

INSERT INTO @AR_LINE_ITEM (ClientCode, DivisionCode, ProductCode, CDP_CONTACT_ID, ContactCode, UseAddress, IncludeOnAccount,
ClientName, DivisionName, ProductDescription, FirstName, LastName, SAddress1, SAddress2, 
SCity, SState, SZip, CAddress1, CAddress2, CCity, CState, CZip, InvoiceDate, InvoiceNumber, InvoiceSeq, Reference, 
Description, InvoiceAmount, PostingPeriod, DaysAged, Comments, OnAccountAmount, OnAccount, 
AddressUse, Template, AgencyName, AgencyAddress1, AgencyAddress2, AgencyCity, AgencyState, AgencyZip, 
AgencyPhone, AgencyFax, AgencyEmail, PrtHeader, PrtAddr1, PrtAddr2, PrtCity, PrtState, PrtZip,  
PrtPhone, PrtFax, PrtEmail, PrtFooter, PrtFtrAddr1, PrtFtrAddr2, PrtFtrCity, PrtFtrState, 
PrtFtrZip, PrtFtrPhone, PrtFtrFax, PrtFtrEmail, PrtName, PrtFtrName, LogoPath, 
CurrentAR, OverThirtyAR, OverSixtyAR, TotalAR)
Values (@CR_ClientCode, @CR_DivisionCode, @CR_ProductCode, @CDP_CONTACT_ID, @CR_ContactCode,
@CR_UseAddress, @CR_IncludeOnAccount, @CR_ClientName, @CR_DivisionName, 
@CR_ProductDescription, @CR_FirstName, @CR_LastName, @CR_SAddress1, 
@CR_SAddress2, @CR_SCity, @CR_SState, @CR_SZip, @CR_CAddress1, @CR_CAddress2, 
@CR_CCity, @CR_CState, @CR_CZip, @CR_InvoiceDate, @CR_InvoiceNumber, @CR_SeqNo, 
@CR_JobNumber, @CR_JobDescription, @CR_InvoiceAmount, @CR_PostingPeriod, 
@CR_DaysAged, @CR_Comments, @CR_OnAccountAmount, @CR_OnAccount, @CR_AddressUse, 
@CR_Template, @CR_AgencyName, @CR_AgencyAddress1, @CR_AgencyAddress2, 
@CR_AgencyCity, @CR_AgencyState, @CR_AgencyZip, @CR_AgencyPhone,  
@CR_AgencyFax, @CR_AgencyEmail, @CR_PrtHeader, @CR_PrtAddr1, @CR_PrtAddr2, 
@CR_PrtCity, @CR_PrtState, @CR_PrtZip, @CR_PrtPhone, @CR_PrtFax, @CR_PrtEmail, 
@CR_PrtFooter, @CR_PrtFtrAddr1, @CR_PrtFtrAddr2, @CR_PrtFtrCity, 
@CR_PrtFtrState, @CR_PrtFtrZip, @CR_PrtFtrPhone, @CR_PrtFtrFax, 
@CR_PrtFtrEmail, @CR_PrtName, @CR_PrtFtrName, @CR_LogoPath, @CR_CurrentAR, 
@CR_OverThirtyAR, @CR_OverSixtyAR, @CR_TotalAR)
-- CR_ADJ_AMT
	Declare PAYMENT_LINE CURSOR FOR

	SELECT  (isnull(CR_CLIENT_DTL.CR_PAY_AMT,0) + isnull(CR_CLIENT_DTL.CR_ADJ_AMT,0)) as CR_AMT, 
	case When isnull(CR_CLIENT_DTL.CR_ADJ_AMT,0) > 0 
	Then ('Payment Received - Check #' + CR_CLIENT.CR_CHECK_NBR + '  (ADJ. INC.)') 
	else ('Payment Received - Check #' + CR_CLIENT.CR_CHECK_NBR) end as Description , 
	CONVERT(CHAR(10), CR_CHECK_DATE, 101) as CR_CHECK_DATE  
	FROM CR_CLIENT_DTL inner join CR_CLIENT  
	ON CR_CLIENT.REC_ID = CR_CLIENT_DTL.REC_ID AND CR_CLIENT.SEQ_NBR = CR_CLIENT_DTL.SEQ_NBR
  	WHERE CR_CLIENT_DTL.AR_INV_NBR = @CR_InvoiceNumber and CR_CLIENT_DTL.AR_INV_SEQ = @CR_SeqNo

	OPEN PAYMENT_LINE

	FETCH NEXT FROM PAYMENT_LINE into @CR_InvoiceAmount, @CR_JobDescription, @CR_InvoiceDate
	WHILE @@FETCH_STATUS=0
	Begin
		INSERT INTO @AR_LINE_ITEM (ClientCode, DivisionCode, ProductCode, CDP_CONTACT_ID, ContactCode, UseAddress, IncludeOnAccount,
		ClientName, DivisionName, ProductDescription, FirstName, LastName, SAddress1, SAddress2, 
		SCity, SState, SZip, CAddress1, CAddress2, CCity, CState, CZip, InvoiceDate, InvoiceNumber, InvoiceSeq, Reference, 
		Description, InvoiceAmount, PostingPeriod, DaysAged, Comments, OnAccountAmount, OnAccount, 
		AddressUse, Template, AgencyName, AgencyAddress1, AgencyAddress2, AgencyCity, AgencyState, AgencyZip, 
		AgencyPhone, AgencyFax, AgencyEmail, PrtHeader, PrtAddr1, PrtAddr2, PrtCity, PrtState, PrtZip,  
		PrtPhone, PrtFax, PrtEmail, PrtFooter, PrtFtrAddr1, PrtFtrAddr2, PrtFtrCity, PrtFtrState, 
		PrtFtrZip, PrtFtrPhone, PrtFtrFax, PrtFtrEmail, PrtName, PrtFtrName, LogoPath, 
		CurrentAR, OverThirtyAR, OverSixtyAR, TotalAR)
		Values (@CR_ClientCode, @CR_DivisionCode, @CR_ProductCode, @CDP_CONTACT_ID,  @CR_ContactCode,
		@CR_UseAddress, @CR_IncludeOnAccount, @CR_ClientName, @CR_DivisionName, 
		@CR_ProductDescription, @CR_FirstName, @CR_LastName, @CR_SAddress1, 
		@CR_SAddress2, @CR_SCity, @CR_SState, @CR_SZip, @CR_CAddress1, @CR_CAddress2, 
		@CR_CCity, @CR_CState, @CR_CZip, @CR_InvoiceDate, ' ', ' ',  
		'CR', @CR_JobDescription, (@CR_InvoiceAmount * -1), @CR_PostingPeriod, 
		@CR_DaysAged, @CR_Comments, @CR_OnAccountAmount, @CR_OnAccount, @CR_AddressUse, 
		@CR_Template, @CR_AgencyName, @CR_AgencyAddress1, @CR_AgencyAddress2, 
		@CR_AgencyCity, @CR_AgencyState, @CR_AgencyZip, @CR_AgencyPhone,  
		@CR_AgencyFax, @CR_AgencyEmail, @CR_PrtHeader, @CR_PrtAddr1, @CR_PrtAddr2, 
		@CR_PrtCity, @CR_PrtState, @CR_PrtZip, @CR_PrtPhone, @CR_PrtFax, @CR_PrtEmail, 
		@CR_PrtFooter, @CR_PrtFtrAddr1, @CR_PrtFtrAddr2, @CR_PrtFtrCity, 
		@CR_PrtFtrState, @CR_PrtFtrZip, @CR_PrtFtrPhone, @CR_PrtFtrFax, 
		@CR_PrtFtrEmail, @CR_PrtName, @CR_PrtFtrName, @CR_LogoPath, @CR_CurrentAR, 
		@CR_OverThirtyAR, @CR_OverSixtyAR, @CR_TotalAR)

	       	
		FETCH NEXT FROM PAYMENT_LINE into @CR_InvoiceAmount, @CR_JobDescription, @CR_InvoiceDate
	END

	CLOSE PAYMENT_LINE

	DEALLOCATE PAYMENT_LINE



FETCH NEXT FROM AR_STATEMENT_LINE into
@CR_ClientCode,
@CR_DivisionCode,
@CR_ProductCode,
@CDP_CONTACT_ID,
@CR_ContactCode,
@CR_UseAddress,
@CR_IncludeOnAccount,
@CR_ClientName,
@CR_DivisionName, 
@CR_ProductDescription, 
@CR_FirstName,  
@CR_LastName, 
@CR_SAddress1, 
@CR_SAddress2, 
@CR_SCity,  
@CR_SState, 
@CR_SZip, 
@CR_CAddress1, 
@CR_CAddress2, 
@CR_CCity, 
@CR_CState, 
@CR_CZip, 
@CR_InvoiceDate, 
@CR_InvoiceNumber, 
@CR_SeqNo, 
@CR_JobNumber, 
@CR_JobDescription,
@CR_ARDescription,  
@CR_InvoiceAmount, 
@CR_PostingPeriod, 
@CR_DaysAged, 
@CR_Comments, 
@CR_OnAccountAmount, 
@CR_OnAccount, 
@CR_AddressUse, 
@CR_Template, 
@CR_AgencyName, 
@CR_AgencyAddress1, 
@CR_AgencyAddress2, 
@CR_AgencyCity, 
@CR_AgencyState, 
@CR_AgencyZip, 
@CR_AgencyPhone,  
@CR_AgencyFax, 
@CR_AgencyEmail,
@CR_PrtHeader, 
@CR_PrtAddr1,  
@CR_PrtAddr2, 
@CR_PrtCity,  
@CR_PrtState, 
@CR_PrtZip,  
@CR_PrtPhone, 
@CR_PrtFax,  
@CR_PrtEmail, 
@CR_PrtFooter,  
@CR_PrtFtrAddr1, 
@CR_PrtFtrAddr2,  
@CR_PrtFtrCity, 
@CR_PrtFtrState, 
@CR_PrtFtrZip, 	
@CR_PrtFtrPhone, 
@CR_PrtFtrFax, 
@CR_PrtFtrEmail, 
@CR_PrtName, 
@CR_PrtFtrName, 
@CR_LogoPath, 
@CR_CurrentAR, 
@CR_OverThirtyAR, 
@CR_OverSixtyAR, 
@CR_TotalAR,
@CR_REC_TYPE,
@CR_MANUAL_INV,
@CR_ORDER_TYPE

END
CLOSE AR_STATEMENT_LINE

DEALLOCATE AR_STATEMENT_LINE
Drop Table #AR_OnAccountDetail
--insert the select statement before this line.
select @array_value = stuff(@array_value, 1, @pairseparator_position, '')

-- This replaces what we just processed with and empty string
select @ID = stuff(@ID, 1, @separator_position, '')
end
--end of Temp Table creation

	Select
	ClientCode, DivisionCode, ProductCode, CDP_CONTACT_ID,
	ContactCode, UseAddress, IncludeOnAccount,
	ClientName, DivisionName, ProductDescription, FirstName, LastName, SAddress1, isnull(SAddress2, '@@@') as SAddress2, 
	SCity, SState, SZip, CAddress1, isnull(CAddress2, '@@@') as CAddress2, CCity, CState, CZip, InvoiceDate, InvoiceNumber, InvoiceSeq, Reference, 
	Description, InvoiceAmount, PostingPeriod, DaysAged, Comments, OnAccountAmount, OnAccount, 
	AddressUse, Template,  isnull(AgencyName, ' ') as AgencyName, isnull(AgencyAddress1, ' ') as AgencyAddress1, isnull(AgencyAddress2, ' ') as AgencyAddress2, isnull(AgencyCity, ' ') as AgencyCity, isnull(AgencyState, ' ') as AgencyState, isnull(AgencyZip,' ') as AgencyZip, 
	isnull(AgencyPhone, ' ') as AgencyPhone, isnull(AgencyFax, ' ') as AgencyFax, isnull(AgencyEmail, ' ') as AgencyEmail, isnull(PrtHeader, 0) as PrtHeader, isnull(PrtAddr1, 0) as PrtAddr1, isnull(PrtAddr2, 0) as PrtAddr2, isnull(PrtCity, 0) as PrtCity, isnull(PrtState, 0) as PrtState, isnull(PrtZip, 0) as PrtZip,  
	isnull(PrtPhone, 0) as PrtPhone, isnull(PrtFax, 0) as PrtFax, isnull(PrtEmail, 0) as PrtEmail, isnull(PrtFooter, 0) as PrtFooter, isnull(PrtFtrAddr1, 0) as PrtFtrAddr1, isnull(PrtFtrAddr2, 0) as PrtFtrAddr2, isnull(PrtFtrCity, 0) as PrtFtrCity, isnull(PrtFtrState, 0) as PrtFtrState, 
	isnull(PrtFtrZip, 0) as PrtFtrZip, isnull(PrtFtrPhone, 0) as PrtFtrPhone, isnull(PrtFtrFax, 0) as PrtFtrFax, isnull(PrtFtrEmail, 0) as PrtFtrEmail, isnull(PrtName, 0) as PrtName, isnull(PrtFtrName, 0) as PrtFtrName, LogoPath, 
	convert(money, CurrentAR) as CurrentAR, convert(money, OverThirtyAR) as OverThirtyAR, convert(money, OverSixtyAR) as OverSixtyAR, convert(money, TotalAR) as TotalAR
	,ISNULL(ClientCode,'')+ISNULL(DivisionCode,'')+ISNULL(ProductCode,'')+CAST(ISNULL(CDP_CONTACT_ID,0) AS VARCHAR)+ISNULL(ContactCode,'') AS GROUPING_KEY
	from @AR_LINE_ITEM
	Order by ClientCode, DivisionCode, ProductCode, ContactCode, Convert(Datetime, InvoiceDate, 101), InvoiceNumber, InvoiceSeq



DROP TABLE #T_AR306090AMT
DROP TABLE #TEMP_AR_STATEMENT_LINE_OFFICES








