








CREATE PROCEDURE dbo.sp_billing_table_with_seq @ar_inv_nbr integer
AS

-- This procedure creates table [Billing Table with Seq]

SET NOCOUNT ON

DECLARE @ar_inv_date smalldatetime

SELECT @ar_inv_date = ( SELECT AR_INV_DATE FROM ACCT_REC WHERE AR_INV_NBR = @ar_inv_nbr AND AR_TYPE = 'IN' )

-- Temporary table to hold a list of all jobs that are involved on the selected invoice(s)
CREATE TABLE #ar_inv_joblist( [JOB_NUMBER] integer NULL, [JOB_COMPONENT_NBR] smallint NULL )

INSERT INTO #ar_inv_joblist
	SELECT DISTINCT arj.JOB_NUMBER, arj.JOB_COMPONENT_NBR
	  FROM dbo.ARINV_JOB arj
	 WHERE arj.AR_INV_NBR = @ar_inv_nbr

-- Temporary table to hold a list of invoices the jobs above appear on
CREATE TABLE #ar_inv_invlist( [AR_INV_NBR] integer NULL )

INSERT INTO #ar_inv_invlist
		SELECT arj.AR_INV_NBR
		  FROM #ar_inv_joblist arinvjob
  INNER JOIN dbo.ARINV_JOB arj 
		    ON arinvjob.JOB_NUMBER = arj.JOB_NUMBER
		   AND arinvjob.JOB_COMPONENT_NBR = arj.JOB_COMPONENT_NBR
  INNER JOIN dbo.ACCT_REC ar
		    ON arj.AR_TYPE = ar.AR_TYPE
		   AND arj.AR_INV_SEQ = ar.AR_INV_SEQ
		   AND arj.AR_INV_NBR = ar.AR_INV_NBR 
		 WHERE arj.AR_INV_DATE <= @ar_inv_date
		   AND ar.MANUAL_INV IS NULL
    GROUP BY arj.AR_INV_NBR
		HAVING MAX( arj.AR_TYPE ) <> 'VO'

CREATE TABLE #bill_invoice_amts( 	
	[DET_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[JOB_NUMBER]					integer NULL,
	[JOB_COMPONENT_NBR]			smallint NULL,
	[FNC_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_NBR]					integer NULL,
	[AR_INV_SEQ]					smallint NULL,
	[AR_TYPE]						varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	[AR_INV_DATE]					smalldatetime NULL,
	[EMP_HOURS]						decimal(15,2) NULL,
	[QUANTITY]						decimal(15,2) NULL, 
	[RATE]							decimal(15,2) NULL, 
	[EXT_AMT]			 			decimal(15,2) NULL, 
	[EXT_MARKUP_AMT]				decimal(15,2) NULL, 
	[TAX_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[EXT_NONRESALE_TAX]			decimal(15,2) NULL, 
	[EXT_STATE_RESALE]			decimal(15,2) NULL, 
	[EXT_COUNTY_RESALE]			decimal(15,2) NULL, 
	[EXT_CITY_RESALE]				decimal(15,2) NULL, 
	[LINE_TOTAL]					decimal(15,2) NULL, 
	[ET_ID]							integer NULL, 
	[AP_ID]							integer NULL, 
	[AP_SEQ]							smallint NULL, 
	[AP_LINE_NBR]					smallint NULL, 
	[IO_INV_NBR]					varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_INV_DATE]					smalldatetime NULL,
	[IO_DESC]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_COMMENT]					text COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_FEE_INVOICE]				smallint NULL 
)

INSERT INTO #bill_invoice_amts
		 SELECT 'AP', ap.JOB_NUMBER, ap.JOB_COMPONENT_NBR, ap.FNC_CODE, ap.AR_INV_NBR, ap.AR_INV_SEQ, NULL, 
				  ar.AR_INV_DATE, 0, SUM(ISNULL(ap.AP_PROD_QUANTITY, 0)), 0, SUM(ap.AP_PROD_EXT_AMT), 
				  SUM(ap.EXT_MARKUP_AMT), ap.TAX_CODE, SUM(ap.EXT_NONRESALE_TAX), SUM(ap.EXT_STATE_RESALE), SUM(ap.EXT_COUNTY_RESALE), 
				  SUM(ap.EXT_CITY_RESALE), SUM(ap.LINE_TOTAL), 0, ap.AP_ID, ap.AP_SEQ, ap.LINE_NUMBER, '0', NULL, NULL, NULL, 0
			FROM dbo.AP_PRODUCTION ap INNER JOIN dbo.ACCT_REC ar 
			  ON ap.AR_TYPE = ar.AR_TYPE 
			 AND ap.AR_INV_SEQ = ar.AR_INV_SEQ 
			 AND ap.AR_INV_NBR = ar.AR_INV_NBR
	     WHERE ar.AR_INV_NBR IN ( SELECT AR_INV_NBR FROM #ar_inv_invlist )
	  GROUP BY ap.JOB_NUMBER, ap.JOB_COMPONENT_NBR, ap.FNC_CODE, ap.AR_INV_NBR, ap.AR_INV_SEQ, ar.AR_INV_DATE, ap.AP_ID, 
				  ap.AP_SEQ, ap.TAX_CODE, ap.LINE_NUMBER
		 HAVING ap.AR_INV_SEQ <> 99

INSERT INTO #bill_invoice_amts
		 SELECT 'IO', ico.JOB_NUMBER, ico.JOB_COMPONENT_NBR, ico.FNC_CODE, ico.AR_INV_NBR, ico.AR_INV_SEQ, NULL, 
				  ar.AR_INV_DATE, 0, SUM(ISNULL(ico.IO_QTY, 0)), 0, SUM(ico.IO_AMOUNT), SUM(ico.EXT_MARKUP_AMT), 
				  NULL, 0, SUM(ico.EXT_STATE_RESALE), SUM(ico.EXT_COUNTY_RESALE), SUM(ico.EXT_CITY_RESALE), SUM(ico.LINE_TOTAL), 
				  0, 0, 0, 0, NULL, NULL, NULL, NULL, ico.FEE_INVOICE
			FROM dbo.INCOME_ONLY ico INNER JOIN dbo.ACCT_REC ar
			  ON ico.AR_TYPE = ar.AR_TYPE 
			 AND ico.AR_INV_SEQ = ar.AR_INV_SEQ 
			 AND ico.AR_INV_NBR = ar.AR_INV_NBR
	     WHERE ar.AR_INV_NBR IN ( SELECT AR_INV_NBR FROM #ar_inv_invlist )
	  GROUP BY ico.JOB_NUMBER, ico.JOB_COMPONENT_NBR, ico.FNC_CODE, ico.AR_INV_NBR, ico.AR_INV_SEQ, ar.AR_INV_DATE, ico.IO_INV_NBR, 
				  ico.IO_INV_DATE, ico.IO_DESC, ico.FEE_INVOICE
		 HAVING (ico.AR_INV_SEQ <> 99)

INSERT INTO #bill_invoice_amts
		 SELECT 'AB', ab.JOB_NUMBER, ab.JOB_COMPONENT_NBR, ab.FNC_CODE, ab.AR_INV_NBR, ab.AR_INV_SEQ, NULL, 
				  ar.AR_INV_DATE, 0, 0, 0, SUM(ab.ADV_BILL_NET_AMT), SUM(ab.EXT_MARKUP_AMT), ab.TAX_CODE, 
				  SUM(ab.EXT_NONRESALE_TAX), SUM(ab.EXT_STATE_RESALE), SUM(ab.EXT_COUNTY_RESALE), SUM(ab.EXT_CITY_RESALE), 
				  SUM(ab.LINE_TOTAL), 0, 0, 0, 0, '0', NULL, NULL, NULL, 0
			FROM dbo.ADVANCE_BILLING ab INNER JOIN dbo.ACCT_REC ar 
			  ON ab.AR_INV_NBR = ar.AR_INV_NBR 
			 AND ab.AR_INV_SEQ = ar.AR_INV_SEQ 
			 AND ab.AR_TYPE = ar.AR_TYPE
	     WHERE ar.AR_INV_NBR IN ( SELECT AR_INV_NBR FROM #ar_inv_invlist )
	  GROUP BY ab.JOB_NUMBER, ab.JOB_COMPONENT_NBR, ab.FNC_CODE, ab.AR_INV_NBR, ab.AR_INV_SEQ, ar.AR_INV_DATE, ab.TAX_CODE
		 HAVING (ab.AR_INV_SEQ <> 99)

INSERT INTO #bill_invoice_amts
		 SELECT 'ET', etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, etd.FNC_CODE, etd.AR_INV_NBR, etd.AR_INV_SEQ, NULL, 
				  ar.AR_INV_DATE, SUM(etd.EMP_HOURS), 0, 0, SUM(etd.TOTAL_BILL), SUM(etd.EXT_MARKUP_AMT), 
				  etd.TAX_CODE, 0, SUM(etd.EXT_STATE_RESALE), SUM(etd.EXT_COUNTY_RESALE), SUM(etd.EXT_CITY_RESALE), 
				  SUM(etd.LINE_TOTAL), etd.ET_ID, 0, 0, 0, '0', NULL, NULL, NULL, 0
			FROM dbo.EMP_TIME_DTL etd INNER JOIN dbo.ACCT_REC ar
			  ON etd.AR_INV_NBR = ar.AR_INV_NBR 
			 AND etd.AR_INV_SEQ = ar.AR_INV_SEQ 
			 AND etd.AR_TYPE = ar.AR_TYPE
	     WHERE ar.AR_INV_NBR IN ( SELECT AR_INV_NBR FROM #ar_inv_invlist )
	  GROUP BY etd.JOB_NUMBER, etd.JOB_COMPONENT_NBR, etd.FNC_CODE, etd.AR_INV_NBR, etd.AR_INV_SEQ, ar.AR_INV_DATE, etd.ET_ID, etd.TAX_CODE
		 HAVING (etd.AR_INV_SEQ <> 99)

INSERT INTO #bill_invoice_amts
       SELECT 'CO', acl.JOB_NUMBER, ISNULL(coop.JOB_COMPONENT, 1), coop.FNC_CODE, acl.AR_INV_NBR, acl.AR_INV_SEQ, ar.AR_TYPE, 
				  ar.AR_INV_DATE, 0, 0, 0, 
				  coop.LINE_TOTAL - ISNULL(coop.MARKUP_AMT, 0) - ISNULL(coop.STATE_TAX, 0) - ISNULL(coop.COUNTY_TAX, 0) - ISNULL(coop.CITY_TAX, 0), 
				  coop.MARKUP_AMT, NULL, 0, coop.STATE_TAX, coop.COUNTY_TAX, coop.CITY_TAX, coop.LINE_TOTAL, 0, 0, 0, 0, '0', NULL, NULL, NULL, 0
			FROM dbo.AR_COOP_LOG acl INNER JOIN dbo.AR_COOP_DTL coop
			  ON acl.COOP_ID = coop.COOP_ID INNER JOIN dbo.ACCT_REC ar 
			  ON acl.AR_INV_NBR = ar.AR_INV_NBR 
			 AND acl.AR_INV_SEQ = ar.AR_INV_SEQ
	     WHERE ar.AR_INV_NBR IN ( SELECT AR_INV_NBR FROM #ar_inv_invlist )

CREATE TABLE #billing_table_with_seq_mt_query( 	
	[JOB_NUMBER]					integer NULL,
	[JOB_COMPONENT_NBR]			integer NULL,
	[SC_DESCRIPTION]				varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Function Code]				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[ConsolFnc]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[PrdConsol]						varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[AR_INV_NBR]					integer NULL, 
	[AR_INV_SEQ]					smallint NULL, 
	[AR_INV_DATE]					smalldatetime NULL, 
	[Item Id]						integer NULL, 
	[ItemSeq Nbr]					integer NULL, 
	[Item Line Nbr]				integer NULL, 
	[Item Code]						varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Item]							varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Item Date]						smalldatetime NULL, 
	[Item Detail]					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,	 		
	[AP_DESC]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[EMP_HOURS]						decimal(15,2) NULL, 
	[QUANTITY]						decimal(15,2) NULL, 
	[Rate]							decimal(15,2) NULL, 
	[EXT_AMT]						decimal(15,2) NULL, 
	[EXT_MARKUP_AMT]				decimal(15,2) NULL, 
	[TAX_CODE]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[EXT_NONRESALE_TAX]			decimal(15,2) NULL, 
	[EXT_CITY_RESALE]				decimal(15,2) NULL, 
	[EXT_COUNTY_RESALE]			decimal(15,2) NULL, 
	[EXT_STATE_RESALE]			decimal(15,2) NULL, 
	[LINE_TOTAL]					decimal(15,2) NULL,
	[AP_COMMENT]					text COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_COMMENT]					text COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[IO_FEE_INVOICE]				integer NULL )

CREATE TABLE #billing_table_with_seq( 	
	[Job Number]					integer NULL, 	
	[Comp Number]					integer NULL, 
	[Sales Class]					varchar(30) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Std Function Code]			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Function Code]				varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[PrdConsol]						varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Inv Nbr Numeric]				integer NULL, 
	[Invoice Number]				varchar(15) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Inv Nbr Seq]					integer NULL, 
	[InvSeqLink]					varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Invoice Date]					smalldatetime NULL, 
	[Item ID]						integer NULL, 
	[Item Seq Nbr]					integer NULL, 
	[Item Line Nbr]				integer NULL, 
	[Item Code]						varchar(10) NULL, 
	[Item]							varchar(50) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Item Date]						smalldatetime NULL, 
	[Item Detail]					varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[AP Desc]						varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Hours/Qty]						decimal(15,2) NULL, 
	[Quantity]						decimal(15,2) NULL, 
	[Rate]							decimal(15,2) NULL, 
	[Net]								decimal(15,2) NULL, 
	[Commission]					decimal(15,2) NULL, 				
	[Tax Code]						varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
	[Vendor Tax]					decimal(15,2) NULL, 
	[Resale City Tax]				decimal(15,2) NULL, 
	[Resale County Tax]			decimal(15,2) NULL, 
	[Resale State Tax]			decimal(15,2) NULL, 
	[Line Total] 					decimal(15,2) NULL,
	[Prior Hours/Qty]				decimal(15,2) NULL, 
	[Prior Net]						decimal(15,2) NULL, 
	[Prior Comm]					decimal(15,2) NULL, 
	[Prior Vendor Tax]			decimal(15,2) NULL, 
	[Prior Resale City Tax]		decimal(15,2) NULL, 
	[Prior Resale County Tax]	decimal(15,2) NULL, 
	[Prior Resale State Tax]	decimal(15,2) NULL, 
	[Prior Total]					decimal(15,2) NULL,
	[Estimate Net]					decimal(15,2) NULL, 
	[Estimate Comm]				decimal(15,2) NULL, 
	[Estimate Vendor Tax]		decimal(15,2) NULL, 
	[Estimate City Tax]			decimal(15,2) NULL, 
	[Estimate County Tax]		decimal(15,2) NULL, 
	[Estimate State Tax]			decimal(15,2) NULL, 
	[Estimate SubTotal]			decimal(15,2) NULL, 
	[Estimate Total]				decimal(15,2) NULL, 
	[Estimate Total NC]			decimal(15,2) NULL )

--[Billing Table with Seq MT-Query] Underlying select query for current and prior data linking to related SYSADM tables
 INSERT INTO #billing_table_with_seq_mt_query
		SELECT bia.JOB_NUMBER, 
				 bia.JOB_COMPONENT_NBR, 
				 sc.SC_DESCRIPTION, 
				 bia.FNC_CODE AS [Function Code], 
				 COALESCE( f.FNC_CONSOLIDATION, f.FNC_CODE ) AS [ConsolFnc], 
				 COALESCE( p.PRD_DESCRIPTION, '0' ) AS [PrdConsol],
				 bia.AR_INV_NBR, 
				 bia.AR_INV_SEQ, 
				 bia.AR_INV_DATE, 
				 [Item Id] = CASE bia.DET_TYPE WHEN 'AP' THEN bia.AP_ID END,
				 [ItemSeq Id] = CASE bia.DET_TYPE WHEN 'AP' THEN bia.AP_SEQ END,
				 bia.AP_LINE_NBR AS [Item Line Nbr], 
				 [Item Code] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN aph.VN_FRL_EMP_CODE
										WHEN 'ET' THEN et.EMP_CODE
									END,
				 [Item] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN v.VN_NAME
										WHEN 'ET' THEN e.EMP_FNAME + ' ' + e.EMP_LNAME
										WHEN 'IO' THEN bia.IO_DESC
										WHEN 'AB' THEN 'Advance Billing'
									END,				 
				 [Item Date] = CASE bia.DET_TYPE 
										WHEN 'AP' THEN aph.AP_INV_DATE
										WHEN 'ET' THEN et.EMP_DATE
										WHEN 'IO' THEN bia.IO_INV_DATE
										WHEN 'AB' THEN bia.AR_INV_DATE
									END,				 				 
				 [Item Detail] = CASE bia.DET_TYPE WHEN 'IO' THEN bia.IO_DESC END,
				 aph.AP_DESC, 
				 bia.EMP_HOURS, 
				 bia.QUANTITY, 
				 CAST( 0 AS decimal( 15,2 )) AS [Rate], 
				 bia.EXT_AMT, 
				 bia.EXT_MARKUP_AMT, 
				 bia.TAX_CODE, 
				 bia.EXT_NONRESALE_TAX, 
				 bia.EXT_CITY_RESALE, 
				 bia.EXT_COUNTY_RESALE, 
				 bia.EXT_STATE_RESALE, 
				 bia.LINE_TOTAL, 
				 apc.AP_COMMENT, 
				 bia.IO_COMMENT, 
				 bia.IO_FEE_INVOICE
		  FROM #bill_invoice_amts AS bia 
		  JOIN dbo.JOB_LOG AS jl
			 ON bia.JOB_NUMBER = jl.JOB_NUMBER
		  JOIN dbo.JOB_COMPONENT AS jc
			 ON bia.JOB_NUMBER = jc.JOB_NUMBER
			AND bia.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		  JOIN dbo.PRODUCT AS p
			 ON jl.CL_CODE = p.CL_CODE
			AND jl.DIV_CODE = p.DIV_CODE
			AND jl.PRD_CODE = p.PRD_CODE
		  JOIN dbo.[FUNCTIONS] AS f
			 ON bia.FNC_CODE = f.FNC_CODE
 	LEFT JOIN dbo.AP_HEADER aph
			 ON bia.AP_ID = aph.AP_ID
			AND bia.AP_SEQ = aph.AP_SEQ
	LEFT JOIN dbo.VENDOR v
			 ON aph.VN_FRL_EMP_CODE = v.VN_CODE
	LEFT JOIN dbo.EMP_TIME et
			 ON bia.ET_ID = et.ET_ID
	LEFT JOIN dbo.EMPLOYEE e
			 ON et.EMP_CODE = e.EMP_CODE
	LEFT JOIN dbo.AP_PROD_COMMENTS apc
			 ON bia.AP_ID = apc.AP_ID
			AND bia.AP_LINE_NBR = apc.LINE_NUMBER
   LEFT JOIN dbo.SALES_CLASS sc
			 ON jl.SC_CODE = sc.SC_CODE

--Append query to populate columns with current data based on [Billing Table with Seq MT-Query]
	INSERT INTO #billing_table_with_seq ( [Job Number], [Comp Number], [Sales Class], [Std Function Code], [Function Code], [PrdConsol], 
					[Inv Nbr Numeric], [Invoice Number], [Inv Nbr Seq], [InvSeqLink], [Invoice Date], [Item ID], [Item Seq Nbr], [Item Line Nbr], 
					[Item Code], [Item], [Item Date], [Item Detail], [AP Desc], [Hours/Qty], [Quantity], [Rate], [Net], [Commission], [Tax Code], 
					[Vendor Tax], [Resale City Tax], [Resale County Tax], [Resale State Tax], [Line Total] )
		  SELECT btwsmq.JOB_NUMBER, 
					btwsmq.JOB_COMPONENT_NBR, 
					btwsmq.SC_DESCRIPTION, 
					btwsmq.[Function Code], 
					btwsmq.ConsolFnc, 
					btwsmq.PrdConsol, 
					btwsmq.AR_INV_NBR, 
					CAST( btwsmq.AR_INV_NBR AS varchar(12)) + '-' + CAST( btwsmq.AR_INV_SEQ AS varchar(4)),
					btwsmq.AR_INV_SEQ, 
					CAST( btwsmq.AR_INV_NBR AS varchar(12)) + CAST( btwsmq.AR_INV_SEQ AS varchar(4)),					
					btwsmq.AR_INV_DATE, 
					btwsmq.[Item Id], 
					btwsmq.[ItemSeq Nbr], 
					btwsmq.[Item Line Nbr], 
					btwsmq.[Item Code], 
					btwsmq.[Item], 
					btwsmq.[Item Date], 
					btwsmq.[Item Detail], 		
					btwsmq.AP_DESC, 
					btwsmq.EMP_HOURS, 
					btwsmq.QUANTITY, 
					btwsmq.Rate, 
					btwsmq.EXT_AMT, 
					btwsmq.EXT_MARKUP_AMT, 
					btwsmq.TAX_CODE, 
					btwsmq.EXT_NONRESALE_TAX, 
					btwsmq.EXT_CITY_RESALE, 
					btwsmq.EXT_COUNTY_RESALE, 
					btwsmq.EXT_STATE_RESALE, 
					btwsmq.LINE_TOTAL
			 FROM #billing_table_with_seq_mt_query AS btwsmq
	      WHERE btwsmq.AR_INV_NBR = @ar_inv_nbr

--[Prior Filter by Job Number] select query to identify qualifying invoice numbers for prior data for selected invoices to print
CREATE TABLE #prior_filter_by_job ( 
	AR_INV_NBR 				integer NULL,
	AR_INV_SEQ 				integer NULL,
	JOB_NUMBER				integer NULL,
	JOB_COMPONENT_NBR		integer NULL,
	AR_INV_DATE 			smalldatetime NULL
)

INSERT INTO #prior_filter_by_job
		  SELECT DISTINCT
					bia.AR_INV_NBR,
					bia.AR_INV_SEQ, 
					bia.JOB_NUMBER, 
					bia.JOB_COMPONENT_NBR, 
					bia.AR_INV_DATE
			 FROM #bill_invoice_amts bia
			WHERE bia.AR_INV_NBR = @ar_inv_nbr
		GROUP BY bia.AR_INV_NBR,
					bia.AR_INV_SEQ, 
					bia.JOB_NUMBER, 
					bia.JOB_COMPONENT_NBR, 
					bia.AR_INV_DATE
		  HAVING bia.AR_INV_SEQ = 0


--Append query to populate columns with prior data based on [Billing Table with Seq MT-Query]
	INSERT INTO #billing_table_with_seq ( [Job Number], [Comp Number], [Sales Class], [Std Function Code], [Function Code], [PrdConsol], 
					[Inv Nbr Numeric], [Invoice Number], [Inv Nbr Seq], [InvSeqLink], [Invoice Date], [Item ID], [Item Seq Nbr], [Item Line Nbr], 
					[Item Code], [Item], [Item Date], [Item Detail], [AP Desc], [Prior Hours/Qty], [Prior Net], [Prior Comm],
					[Tax Code], [Prior Vendor Tax], [Prior Resale City Tax], [Prior Resale County Tax], [Prior Resale State Tax], [Prior Total] )
		  SELECT btwsmq.JOB_NUMBER, 
					btwsmq.JOB_COMPONENT_NBR, 
					btwsmq.SC_DESCRIPTION, 
					btwsmq.[Function Code], 
					btwsmq.[ConsolFnc], 
					btwsmq.[PrdConsol], 
					pfbj.AR_INV_NBR, 
					CONVERT( varchar(12), pfbj.AR_INV_NBR ) + '-' + CONVERT( varchar(4), pfbj.AR_INV_SEQ ) AS [InvNbr], 
					pfbj.AR_INV_SEQ, 
					CONVERT( varchar(12), pfbj.AR_INV_NBR ) + CONVERT( varchar(4), pfbj.AR_INV_SEQ ) AS [InvSeqLink], 
					pfbj.AR_INV_DATE, 
					btwsmq.[Item Id], 
					btwsmq.[ItemSeq Nbr], 
					btwsmq.[Item Line Nbr], 
					btwsmq.[Item Code], 
					btwsmq.[Item], 
					btwsmq.[Item Date], 
					btwsmq.[Item Detail], 
					btwsmq.AP_DESC, 
					btwsmq.EMP_HOURS, 
					btwsmq.EXT_AMT, 
					btwsmq.EXT_MARKUP_AMT, 
					NULL AS TAX_CODE, 
					btwsmq.EXT_NONRESALE_TAX, 
					btwsmq.EXT_CITY_RESALE, 
					btwsmq.EXT_COUNTY_RESALE, 
					btwsmq.EXT_STATE_RESALE, 
					btwsmq.LINE_TOTAL
			 FROM #prior_filter_by_job pfbj
			 JOIN	#billing_table_with_seq_mt_query btwsmq
				ON pfbj.JOB_COMPONENT_NBR = btwsmq.JOB_COMPONENT_NBR 
			  AND pfbj.JOB_NUMBER = btwsmq.JOB_NUMBER
			WHERE pfbj.AR_INV_DATE <= @ar_inv_date 
			  AND pfbj.AR_INV_NBR > btwsmq.AR_INV_NBR
			   

--Append query to populate columns with estimate data
CREATE TABLE #bill_estimate_amts ( 
	JOB_NUMBER 							integer NULL,
	JOB_COMPONENT_NBR					integer NULL,
	FNC_CODE 							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	EST_REV_QUANTITY					decimal(15,2) NULL,
	EST_REV_RATE						decimal(15,3) NULL,
	EST_REV_EXT_AMT					decimal(15,2) NULL,
	EST_REV_EXT_MARKUP_AMT			decimal(15,2) NULL,
	EST_REV_EXT_NONRESALE_TAX		decimal(15,2) NULL,
	EST_REV_EXT_STATE_RESALE		decimal(15,2) NULL,
	EST_REV_EXT_COUNTY_RESALE		decimal(15,2) NULL,
	EST_REV_EXT_CITY_RESALE			decimal(15,2) NULL,
	EST_REV_LINE_TOTAL				decimal(15,2) NULL )

INSERT INTO #bill_estimate_amts
	 SELECT ea.JOB_NUMBER, 
			  ea.JOB_COMPONENT_NBR, 
			  erd.FNC_CODE, 
           CAST( SUM( COALESCE( erd.EST_REV_QUANTITY, 0 )) AS decimal(15,2)) AS EST_REV_QUANTITY, 
			  CAST( 0 AS decimal(15,3)) AS EST_REV_RATE, 
           CAST( SUM( COALESCE( erd.EST_REV_EXT_AMT, 0 ) + COALESCE( erd.EXT_CONTINGENCY, 0 )) AS decimal(15,2)) AS EST_REV_EXT_AMT, 
			  CAST( SUM( COALESCE( erd.EXT_MARKUP_AMT, 0 ) + COALESCE( erd.EXT_MU_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_MARKUP_AMT, 
           CAST( SUM( COALESCE( erd.EXT_NONRESALE_TAX, 0 ) + COALESCE( erd.EXT_NR_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_NONRESALE_TAX, 
           CAST( SUM( COALESCE( erd.EXT_STATE_RESALE, 0 ) + COALESCE( erd.EXT_STATE_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_STATE_RESALE, 
           CAST( SUM( COALESCE( erd.EXT_COUNTY_RESALE, 0 ) + COALESCE( erd.EXT_COUNTY_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_COUNTY_RESALE, 
           CAST( SUM( COALESCE( erd.EXT_CITY_RESALE, 0 ) + COALESCE( erd.EXT_CITY_CONT, 0 )) AS decimal(15,2)) AS EST_REV_EXT_CITY_RESALE, 
           CAST( SUM( COALESCE( erd.LINE_TOTAL, 0 ) + COALESCE( erd.LINE_TOTAL_CONT, 0 )) AS decimal(15,2)) AS EST_REV_LINE_TOTAL
		FROM dbo.ESTIMATE_APPROVAL ea 
INNER JOIN dbo.ESTIMATE_REV_DET erd
		  ON ea.EST_REVISION_NBR = erd.EST_REV_NBR 
		 AND ea.EST_QUOTE_NBR = erd.EST_QUOTE_NBR 
	    AND ea.EST_COMPONENT_NBR = erd.EST_COMPONENT_NBR 
	    AND ea.ESTIMATE_NUMBER = erd.ESTIMATE_NUMBER
	  WHERE EXISTS( SELECT * 
							FROM dbo.ARINV_JOB arj 
						  WHERE arj.JOB_NUMBER = ea.JOB_NUMBER 
							 AND arj.JOB_COMPONENT_NBR = ea.JOB_COMPONENT_NBR 
							 AND arj.AR_INV_NBR = @ar_inv_nbr )
  GROUP BY ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, erd.FNC_CODE

	INSERT INTO #billing_table_with_seq ( [Job Number], [Comp Number], [Sales Class], [Std Function Code], [Function Code], [PrdConsol], 
					[Inv Nbr Numeric], [Invoice Number], [InvSeqLink], [Invoice Date], [Estimate Net], [Estimate Comm], [Estimate Vendor Tax], 
					[Estimate City Tax], [Estimate County Tax], [Estimate State Tax], [Estimate SubTotal], [Estimate Total], [Estimate Total NC] )
		  SELECT bea.JOB_NUMBER, 
					bea.JOB_COMPONENT_NBR, 
					sc.SC_DESCRIPTION, 
					bea.FNC_CODE,
					COALESCE( f.FNC_CONSOLIDATION, f.FNC_CODE ) AS [ConsolFnc], 
					COALESCE( p.PRD_DESCRIPTION, '0' ) AS [PrdConsol], 
					@ar_inv_nbr,
					CONVERT( varchar(12), @ar_inv_nbr ) + '-0' AS [InvNbr], 
					CONVERT( varchar(12), @ar_inv_nbr ) + '0' AS [InvSeqLink], 
					@ar_inv_date,
					bea.EST_REV_EXT_AMT, 
					bea.EST_REV_EXT_MARKUP_AMT, 
					bea.EST_REV_EXT_NONRESALE_TAX, 
					bea.EST_REV_EXT_CITY_RESALE, 
					bea.EST_REV_EXT_COUNTY_RESALE, 
					bea.EST_REV_EXT_STATE_RESALE, 
					0 AS [Estimate SubTotal], 
					bea.EST_REV_LINE_TOTAL,
					0 AS [Estimate Total NC]
			 FROM #ar_inv_joblist arij
	 		 JOIN #bill_estimate_amts bea
				ON arij.JOB_NUMBER = bea.JOB_NUMBER
			  AND arij.JOB_COMPONENT_NBR = bea.JOB_COMPONENT_NBR
			 JOIN JOB_COMPONENT jc
				ON bea.JOB_NUMBER = jc.JOB_NUMBER
			  AND bea.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	 		 JOIN JOB_LOG jl 
				ON jc.JOB_NUMBER = jl.JOB_NUMBER
			 JOIN SALES_CLASS sc
				ON jl.SC_CODE = sc.SC_CODE
	 		 JOIN PRODUCT p
				ON jl.CL_CODE = p.CL_CODE
			  AND jl.DIV_CODE = p.DIV_CODE
			  AND jl.PRD_CODE = p.PRD_CODE
	 		 JOIN [FUNCTIONS] f
				ON bea.FNC_CODE = f.FNC_CODE

end_tran:

SELECT *
  FROM #billing_table_with_seq

DROP TABLE #bill_invoice_amts
DROP TABLE #prior_filter_by_job
DROP TABLE #billing_table_with_seq_mt_query
DROP TABLE #ar_inv_joblist
DROP TABLE #ar_inv_invlist
DROP TABLE #bill_estimate_amts
DROP TABLE #billing_table_with_seq
