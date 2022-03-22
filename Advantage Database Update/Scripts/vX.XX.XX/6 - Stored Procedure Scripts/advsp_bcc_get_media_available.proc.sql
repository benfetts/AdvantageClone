CREATE PROCEDURE [dbo].[advsp_bcc_get_media_available] @bcc_id_in integer, @billing_user varchar(100), @m_select_by smallint, 
	@incl_unbilled_only bit, @incl_zero_spots bit, @date_to_use smallint,
	@newspaper bit, @magazine bit, @internet bit, @out_of_home bit,
	@radio bit, @radio_daily bit, @radio_monthly bit, @television bit, @tv_daily bit, @tv_monthly bit,
	@m_start_date smalldatetime, @m_cutoff_date smalldatetime, @brdcast_date1 smalldatetime, @brdcast_date2 smalldatetime, @incl_legacy bit,
	@job_media_date_from smalldatetime, @job_media_date_to smalldatetime
AS
--07/15/16 MJC added Office Level and CDP Level Security
SET NOCOUNT ON

DECLARE @UserCode varchar(100), @EmployeeCode varchar(6), @HasOfficeLimitations bit

SELECT @UserCode = UPPER(SUBSTRING(BILLING_USER, 1, LEN(BILLING_USER) - 2))
FROM dbo.BILLING_CMD_CENTER
WHERE BCC_ID = @bcc_id_in

SELECT @EmployeeCode = EMP_CODE
FROM dbo.SEC_USER
WHERE UPPER(USER_CODE) = @UserCode

IF EXISTS (SELECT 1 from dbo.EMP_OFFICE WHERE EMP_CODE = @EmployeeCode)
	SET @HasOfficeLimitations = 1
ELSE
	SEt @HasOfficeLimitations = 0

DECLARE @selection TABLE (
	selection_id	int identity( 1, 1 ) NOT NULL,
	ORDER_NBR		int NOT NULL,
	LINE_NBR		int NOT NULL,
	BCC_ID			int NULL,
	BRDCAST_YEAR	int NULL,
	BRDCAST_MONTH	int NULL,
	CMP_IDENTIFIER	int NULL,
	CL_CODE			varchar(6) NULL,
	DIV_CODE		varchar(6) NULL,
	PRD_CODE		varchar(6) NULL,
	ORDER_DESC		varchar(40) NULL,
	MEDIA_FROM		varchar(11) NULL,
	CLIENT_PO		varchar(25) NULL,
	MARKET_CODE		varchar(10) NULL
)

DECLARE @brd_mth1 smalldatetime, @brd_mth2 smalldatetime

IF ( ISDATE( @brdcast_date1 ) = 1 )
	SELECT @brd_mth1 = @brdcast_date1

IF ( ISDATE( @brdcast_date2 ) = 1 )
	SELECT @brd_mth2 = @brdcast_date2

-- Magazine *********************************************************************************************************************************************
IF ( @magazine = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, bol.BCC_ID, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Magazine', h.CLIENT_PO, h.MARKET_CODE
	FROM dbo.MAGAZINE_HEADER h
		INNER JOIN dbo.MAGAZINE_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND (COALESCE(d.LINE_CANCELLED, 0) = 0 OR d.BILL_CANCELLED = 1 )
		LEFT OUTER JOIN dbo.BCC_ORDER_LINE bol ON bol.ORDER_NBR = d.ORDER_NBR AND bol.LINE_NBR = d.LINE_NBR AND (bol.BCC_ID IS NULL OR bol.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
	AND COALESCE(h.[STATUS], 0) = 0
	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
    AND d.ACTIVE_REV = 1
	AND (
		(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 2 AND ( d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 3 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
		)
	AND (
		( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
		OR
		( @incl_unbilled_only = 0 )
		)
	OR bol.BCC_ID = @bcc_id_in
END

-- Newspaper *********************************************************************************************************************************************
IF ( @newspaper = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, bol.BCC_ID, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Newspaper', h.CLIENT_PO, h.MARKET_CODE
	FROM dbo.NEWSPAPER_HEADER h
		INNER JOIN dbo.NEWSPAPER_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND (COALESCE(d.LINE_CANCELLED, 0) = 0 OR d.BILL_CANCELLED = 1 )
		LEFT OUTER JOIN dbo.BCC_ORDER_LINE bol ON bol.ORDER_NBR = d.ORDER_NBR AND bol.LINE_NBR = d.LINE_NBR AND (bol.BCC_ID IS NULL OR bol.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
	AND	COALESCE(h.[STATUS], 0) = 0
	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
    AND d.ACTIVE_REV = 1
	AND (
		(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 2 AND ( d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 3 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
		)
	AND (
		( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
		OR
		( @incl_unbilled_only = 0 )
		)
	OR bol.BCC_ID = @bcc_id_in
END

-- Out of home *********************************************************************************************************************************************
IF ( @out_of_home = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, bol.BCC_ID, CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Out of Home', h.CLIENT_PO, h.MARKET_CODE
	FROM dbo.OUTDOOR_HEADER h
		INNER JOIN dbo.OUTDOOR_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND (COALESCE(d.LINE_CANCELLED, 0) = 0 OR d.BILL_CANCELLED = 1 )
		LEFT OUTER JOIN dbo.BCC_ORDER_LINE bol ON bol.ORDER_NBR = d.ORDER_NBR AND bol.LINE_NBR = d.LINE_NBR AND (bol.BCC_ID IS NULL OR bol.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
	AND	COALESCE(h.[STATUS], 0) = 0
	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
    AND d.ACTIVE_REV = 1
	AND (
		(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 2 AND ( d.POST_DATE BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 3 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
		)
	AND (
		( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
		OR
		( @incl_unbilled_only = 0 )
		)
	OR bol.BCC_ID = @bcc_id_in
END

-- Internet *********************************************************************************************************************************************
IF ( @internet = 1 )
BEGIN
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, bol.BCC_ID, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Internet', h.CLIENT_PO, h.MARKET_CODE
	FROM dbo.INTERNET_HEADER h
		INNER JOIN dbo.INTERNET_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND (COALESCE(d.LINE_CANCELLED, 0) = 0 OR d.BILL_CANCELLED = 1 )
		LEFT OUTER JOIN dbo.BCC_ORDER_LINE bol ON bol.ORDER_NBR = d.ORDER_NBR AND bol.LINE_NBR = d.LINE_NBR AND (bol.BCC_ID IS NULL OR bol.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
	AND	COALESCE(h.[STATUS], 0) = 0
	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
    AND d.ACTIVE_REV = 1 
	AND (
		(@date_to_use = 1 AND ( d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 2 AND ( d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@date_to_use = 3 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ))
		)
	AND (
		( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
		OR
		( @incl_unbilled_only = 0 )
		)
	OR bol.BCC_ID = @bcc_id_in
END

-- Radio *********************************************************************************************************************************************
IF ( @radio = 1 )
BEGIN
	IF ( @radio_monthly = 1 AND @incl_legacy = 1 )
	BEGIN
		INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BRDCAST_YEAR, BRDCAST_MONTH, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
		SELECT DISTINCT h.ORDER_NBR, CASE WHEN @m_select_by = 8 THEN vd.LINE_NBR ELSE 0 END, vd.BRDCAST_YEAR, vd.MONTH_IND, bob.BCC_ID, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Radio*', h.CLIENT_PO, h.MARKET_CODE
		FROM dbo.RADIO_DETAIL1 d
			INNER JOIN dbo.V_RADIO_DETAIL1 vd ON ( d.ORDER_NBR = vd.ORDER_NBR )
												AND ( d.LINE_NBR = vd.LINE_NBR )
												AND ( d.SEQ_NBR = vd.SEQ_NBR )
												AND ( d.BRDCAST_YEAR = vd.BRDCAST_YEAR )
			LEFT OUTER JOIN dbo.BCC_ORDER_BRDCAST bob ON bob.ORDER_NBR = vd.ORDER_NBR AND bob.BRDCAST_YEAR = vd.BRDCAST_YEAR AND bob.BRDCAST_MONTH = vd.MONTH_IND AND (
							( @m_select_by = 8 AND bob.LINE_NBR = vd.LINE_NBR)
							OR
							( @m_select_by <> 8 )
							) AND (bob.BCC_ID IS NULL OR bob.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
			INNER JOIN dbo.RADIO_HEADER h ON ( d.ORDER_NBR = h.ORDER_NBR )
												AND ( h.REV_NBR = ( SELECT vmomrs.MAX_REV
																	FROM (
																		SELECT d.ORDER_NBR, d.LINE_NBR, d.REV_NBR as MAX_REV, MAX(d.SEQ_NBR) as MAX_SEQ
																		FROM dbo.RADIO_DETAIL1 AS d
																		WHERE d.REV_NBR = ( SELECT MAX(d2.REV_NBR) 
																							FROM dbo.RADIO_DETAIL1 AS d2
																							WHERE d.ORDER_NBR = d2.ORDER_NBR 
																							AND d.LINE_NBR = d2.LINE_NBR )
																		GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR) vmomrs
																	WHERE vmomrs.ORDER_NBR = h.ORDER_NBR
																	AND vmomrs.LINE_NBR = d.LINE_NBR ))
		WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		AND	COALESCE(h.[STATUS], 0) = 0
		AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
		AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
		AND	( CAST( CAST( vd.MONTH_IND AS varchar(2)) + '/01/' + CAST( vd.BRDCAST_YEAR AS varchar(4)) AS smalldatetime ) BETWEEN @brd_mth1 AND @brd_mth2 )
		AND (
			( @incl_unbilled_only = 1 AND vd.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
	END
		
	-- Radio (New)
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, bol.BCC_ID, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'Radio', h.CLIENT_PO, h.MARKET_CODE
	FROM dbo.RADIO_HDR h
		INNER JOIN dbo.RADIO_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND (COALESCE(d.LINE_CANCELLED, 0) = 0 OR d.BILL_CANCELLED = 1 )
		LEFT OUTER JOIN dbo.BCC_ORDER_LINE bol ON bol.ORDER_NBR = d.ORDER_NBR AND bol.LINE_NBR = d.LINE_NBR AND (bol.BCC_ID IS NULL OR bol.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
	AND	COALESCE(h.[STATUS], 0) = 0
	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
	AND ( d.BILLING_AMT <> 0.00 OR ( @incl_zero_spots = 1 AND d.TOTAL_SPOTS <> 0 ))
    AND d.ACTIVE_REV = 1
	-- BEGIN Date criteria
	AND 
		(
		(@radio_daily = 1 AND @date_to_use = 1 AND ( h.UNITS = 'DB' AND d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@radio_daily = 1 AND @date_to_use = 2 AND ( h.UNITS = 'DB' AND d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@radio_monthly = 1 AND @date_to_use <> 3 AND ( h.UNITS IN ( 'BM', 'CM' ) AND ( CAST(CAST( d.MONTH_NBR as varchar(2)) + '/01/' + CAST( d.YEAR_NBR as varchar(4)) as smalldatetime) BETWEEN @brd_mth1 AND @brd_mth2)))
		OR
		(@date_to_use = 3 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ) AND ( (@radio_daily = 1 AND h.UNITS = 'DB') OR (@radio_monthly = 1 AND h.UNITS IN ( 'BM', 'CM' ))))
		)
	-- END Date criteria
	AND (
		( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
		OR
		( @incl_unbilled_only = 0 )
		)
	OR bol.BCC_ID = @bcc_id_in
END

-- Television *********************************************************************************************************************************************
IF ( @television = 1 )
BEGIN
	IF ( @tv_monthly = 1 AND @incl_legacy = 1 )
	BEGIN
		INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BRDCAST_YEAR, BRDCAST_MONTH, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
		SELECT DISTINCT h.ORDER_NBR, CASE WHEN @m_select_by = 8 THEN vd.LINE_NBR ELSE 0 END, vd.BRDCAST_YEAR, vd.MONTH_IND, bob.BCC_ID, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'TV*', h.CLIENT_PO, h.MARKET_CODE
		FROM dbo.TV_DETAIL1 d
			INNER JOIN dbo.V_TV_DETAIL1 vd ON ( d.ORDER_NBR = vd.ORDER_NBR )
											AND ( d.LINE_NBR = vd.LINE_NBR )
											AND ( d.SEQ_NBR = vd.SEQ_NBR )
											AND ( d.BRDCAST_YEAR = vd.BRDCAST_YEAR )
			LEFT OUTER JOIN dbo.BCC_ORDER_BRDCAST bob ON bob.ORDER_NBR = vd.ORDER_NBR AND bob.BRDCAST_YEAR = vd.BRDCAST_YEAR AND bob.BRDCAST_MONTH = vd.MONTH_IND AND (
							( @m_select_by = 8 AND bob.LINE_NBR = vd.LINE_NBR)
							OR
							( @m_select_by <> 8 )
							) AND (bob.BCC_ID IS NULL OR bob.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
			INNER JOIN dbo.TV_HEADER h ON ( d.ORDER_NBR = h.ORDER_NBR )
											AND ( h.REV_NBR = ( SELECT vmomrs.MAX_REV
																FROM (
																	SELECT d.ORDER_NBR, d.LINE_NBR, d.REV_NBR as MAX_REV, MAX(d.SEQ_NBR) as MAX_SEQ
																	FROM dbo.TV_DETAIL1 AS d
																	WHERE d.REV_NBR = ( SELECT MAX(d2.REV_NBR) 
																						FROM dbo.TV_DETAIL1 AS d2
																						WHERE d.ORDER_NBR = d2.ORDER_NBR 
																						AND d.LINE_NBR = d2.LINE_NBR )	
																	GROUP BY d.ORDER_NBR, d.LINE_NBR, d.REV_NBR) vmomrs
																WHERE vmomrs.ORDER_NBR = h.ORDER_NBR
																AND vmomrs.LINE_NBR = d.LINE_NBR ))
		WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		AND	COALESCE(h.[STATUS], 0) = 0
		AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
		AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
		AND	( CAST( CAST( vd.MONTH_IND AS varchar(2)) + '/01/' + CAST( vd.BRDCAST_YEAR AS varchar(4)) AS smalldatetime ) BETWEEN @brd_mth1 AND @brd_mth2 )
		AND (
			( @incl_unbilled_only = 1 AND vd.AR_INV_NBR IS NULL )
			OR
			( @incl_unbilled_only = 0 )
			)
	END
	
	-- TV (New)
	INSERT INTO @selection ( ORDER_NBR, LINE_NBR, BCC_ID, CMP_IDENTIFIER, CL_CODE, DIV_CODE, PRD_CODE, ORDER_DESC, MEDIA_FROM, CLIENT_PO, MARKET_CODE )
	SELECT DISTINCT d.ORDER_NBR, d.LINE_NBR, bol.BCC_ID, h.CMP_IDENTIFIER, h.CL_CODE, h.DIV_CODE, h.PRD_CODE, h.ORDER_DESC, 'TV', h.CLIENT_PO, h.MARKET_CODE
	FROM dbo.TV_HDR h
		INNER JOIN dbo.TV_DETAIL d ON h.ORDER_NBR = d.ORDER_NBR AND (COALESCE(d.LINE_CANCELLED, 0) = 0 OR d.BILL_CANCELLED = 1 )
		LEFT OUTER JOIN dbo.BCC_ORDER_LINE bol ON bol.ORDER_NBR = d.ORDER_NBR AND bol.LINE_NBR = d.LINE_NBR AND (bol.BCC_ID IS NULL OR bol.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
		LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE (h.BCC_ID IS NULL OR h.BCC_ID = @bcc_id_in OR @bcc_id_in IS NULL)
	AND	COALESCE(h.[STATUS], 0) = 0
	AND h.ORD_PROCESS_CONTRL IN ( 1, 5 )
	AND ( d.BILLING_AMT <> 0.00 OR ( @incl_zero_spots = 1 AND d.TOTAL_SPOTS <> 0 ))
    AND d.ACTIVE_REV = 1
	-- BEGIN Date criteria
	AND 
		(
		(@tv_daily = 1 AND @date_to_use = 1 AND ( h.UNITS = 'DB' AND d.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@tv_daily = 1 AND @date_to_use = 2 AND ( h.UNITS = 'DB' AND d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
		OR
		(@tv_monthly = 1 AND @date_to_use <> 3 AND ( h.UNITS IN ( 'BM', 'CM' ) AND ( CAST(CAST( d.MONTH_NBR as varchar(2)) + '/01/' + CAST( d.YEAR_NBR as varchar(4)) as smalldatetime) BETWEEN @brd_mth1 AND @brd_mth2)))
		OR
		(@date_to_use = 3 AND ( COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_from and @job_media_date_to ) AND ( (@tv_daily = 1 AND h.UNITS = 'DB') OR (@tv_monthly = 1 AND h.UNITS IN ( 'BM', 'CM' ))))
		)
	-- END Date criteria
	AND (
		( @incl_unbilled_only = 1 AND d.AR_INV_NBR IS NULL )
		OR
		( @incl_unbilled_only = 0 )
		)
	OR bol.BCC_ID = @bcc_id_in
END

CREATE TABLE #AvailableSelections (
	ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientName varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	DivisionName varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ProductDescription varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CampaignID int NULL,
	CampaignCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	CampaignName varchar(128) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	OrderNumber int NULL,
	OrderDescription varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	LineNumber int NULL,
	MediaFrom varchar(11) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	ClientPO varchar(25) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MarketCode varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MarketDescription varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	IsSelected bit NOT NULL
)

IF @m_select_by = 0  --all eligible orders

	SELECT * 
	--INTO ##selection
	FROM @selection

ELSE IF @m_select_by = 1 BEGIN --campaign

	INSERT INTO #AvailableSelections (ClientCode, ClientName, DivisionCode, DivisionName, ProductCode, ProductDescription, CampaignID, CampaignCode, CampaignName, IsSelected)
	SELECT DISTINCT
		[ClientCode] = CMP.CL_CODE,
		[ClientName] = C.CL_NAME,
        [DivisionCode] = CMP.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = CMP.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
        [CampaignID] = s.CMP_IDENTIFIER,
        [CampaignCode] = CMP.CMP_CODE,
        [CampaignName] = CMP.CMP_NAME,
        [IsSelected] = CAST(COALESCE(s.BCC_ID,0) as bit)
	FROM @selection s
		INNER JOIN dbo.CAMPAIGN CMP ON s.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER 
		INNER JOIN dbo.CLIENT C ON CMP.CL_CODE = C.CL_CODE
		LEFT OUTER JOIN dbo.DIVISION D ON CMP.CL_CODE = D.CL_CODE AND CMP.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON CMP.CL_CODE = P.CL_CODE AND CMP.DIV_CODE = P.DIV_CODE AND CMP.PRD_CODE = P.PRD_CODE
	WHERE s.BCC_ID IS NOT NULL

	UNION

	SELECT DISTINCT
		[ClientCode] = CMP.CL_CODE,
		[ClientName] = C.CL_NAME,
        [DivisionCode] = CMP.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
        [ProductCode] = CMP.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
        [CampaignID] = s.CMP_IDENTIFIER,
        [CampaignCode] = CMP.CMP_CODE,
        [CampaignName] = CMP.CMP_NAME,
        [IsSelected] = CAST(COALESCE(s.BCC_ID,0) as bit)
	FROM @selection s
		INNER JOIN dbo.CAMPAIGN CMP ON s.CMP_IDENTIFIER = CMP.CMP_IDENTIFIER AND COALESCE(CMP.CMP_CLOSED, 0) = 0
		INNER JOIN dbo.CLIENT C ON CMP.CL_CODE = C.CL_CODE
		LEFT OUTER JOIN dbo.DIVISION D ON CMP.CL_CODE = D.CL_CODE AND CMP.DIV_CODE = D.DIV_CODE
		LEFT OUTER JOIN dbo.PRODUCT P ON CMP.CL_CODE = P.CL_CODE AND CMP.DIV_CODE = P.DIV_CODE AND CMP.PRD_CODE = P.PRD_CODE
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE CMP_IDENTIFIER = s.CMP_IDENTIFIER
						AND BCC_ID IS NOT NULL)
	OPTION (RECOMPILE)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
		SELECT *
		FROM #AvailableSelections s
			INNER JOIN dbo.CAMPAIGN CMP ON s.CampaignID = CMP.CMP_IDENTIFIER
			INNER JOIN dbo.SEC_CLIENT SC ON UPPER(SC.[USER_ID]) = @UserCode 
										AND s.ClientCode = SC.CL_CODE
										AND (s.DivisionCode IS NULL OR s.DivisionCode = SC.DIV_CODE)
										AND (s.ProductCode IS NULL OR s.ProductCode = SC.PRD_CODE)
		WHERE (@HasOfficeLimitations = 0 OR (@HasOfficeLimitations = 1 AND CMP.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))))
		ORDER BY ClientCode, DivisionCode, ProductCode, CampaignName
	ELSE
		SELECT *
		FROM #AvailableSelections s
			INNER JOIN dbo.CAMPAIGN CMP ON s.CampaignID = CMP.CMP_IDENTIFIER
		WHERE (@HasOfficeLimitations = 0 OR (@HasOfficeLimitations = 1 AND CMP.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))))
		ORDER BY ClientCode, DivisionCode, ProductCode, CampaignName
	--ORDER BY 1, 3, 5, 8 

END ELSE IF @m_select_by = 2 BEGIN --client

	INSERT INTO #AvailableSelections (ClientCode, ClientName, IsSelected)
	SELECT DISTINCT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
	WHERE s.BCC_ID IS NOT NULL

	UNION

	SELECT DISTINCT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE CL_CODE = s.CL_CODE
						AND BCC_ID IS NOT NULL)
	OPTION (RECOMPILE)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
						FROM dbo.DIVISION d
							INNER JOIN dbo.PRODUCT p ON p.CL_CODE = d.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
							INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
																AND p.CL_CODE = sc.CL_CODE
																AND p.DIV_CODE = sc.DIV_CODE
																AND p.PRD_CODE = sc.PRD_CODE
						WHERE d.CL_CODE = s.ClientCode
						AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
					 )
		ORDER BY ClientCode, ClientName
	ELSE
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
						FROM dbo.DIVISION d
							INNER JOIN dbo.PRODUCT p ON p.CL_CODE = d.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
						WHERE d.CL_CODE = s.ClientCode
						AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
					 )
		ORDER BY ClientCode, ClientName
	--ORDER BY 1, 2 

END ELSE IF @m_select_by = 3 BEGIN --client/division

	INSERT INTO #AvailableSelections (ClientCode, ClientName, DivisionCode, DivisionName, IsSelected)
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
	WHERE s.BCC_ID IS NOT NULL

	UNION

	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE AND D.ACTIVE_FLAG = 1
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE CL_CODE = s.CL_CODE
						AND DIV_CODE = s.DIV_CODE
						AND BCC_ID IS NOT NULL)	
	OPTION (RECOMPILE)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
						FROM dbo.PRODUCT p
							INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
																AND p.CL_CODE = sc.CL_CODE
																AND p.DIV_CODE = sc.DIV_CODE
																AND p.PRD_CODE = sc.PRD_CODE
						WHERE p.CL_CODE = s.ClientCode 
						AND p.DIV_CODE = s.DivisionCode
						AND p.ACTIVE_FLAG = 1
						AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
					 )
		ORDER BY ClientCode, DivisionCode, DivisionName
	ELSE
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
						FROM dbo.PRODUCT p
						WHERE p.CL_CODE = s.ClientCode 
						AND p.DIV_CODE = s.DivisionCode
						AND p.ACTIVE_FLAG = 1
						AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
					 )
		ORDER BY ClientCode, DivisionCode, DivisionName
	--ORDER BY 1, 3, 4

END ELSE IF @m_select_by = 4 BEGIN --client/division/product

	INSERT INTO #AvailableSelections (ClientCode, ClientName, DivisionCode, DivisionName, ProductCode, ProductDescription, IsSelected)
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE
	WHERE s.BCC_ID IS NOT NULL

	UNION

	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE AND D.ACTIVE_FLAG = 1
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE AND P.ACTIVE_FLAG = 1
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE CL_CODE = s.CL_CODE
						AND DIV_CODE = s.DIV_CODE
						AND PRD_CODE = s.PRD_CODE
						AND BCC_ID IS NOT NULL)
	OPTION (RECOMPILE)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
		SELECT *
		FROM #AvailableSelections s
			INNER JOIN dbo.PRODUCT p ON s.ClientCode = p.CL_CODE AND s.DivisionCode = p.DIV_CODE AND s.ProductCode = p.PRD_CODE
			INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
											AND s.ClientCode = sc.CL_CODE
											AND s.DivisionCode = sc.DIV_CODE
											AND s.ProductCode = sc.PRD_CODE
		WHERE p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
		ORDER BY ClientCode, DivisionCode, ProductCode
	ELSE
		SELECT *
		FROM #AvailableSelections s
			INNER JOIN dbo.PRODUCT p ON s.ClientCode = p.CL_CODE AND s.DivisionCode = p.DIV_CODE AND s.ProductCode = p.PRD_CODE
		WHERE p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
		ORDER BY ClientCode, DivisionCode, ProductCode
	--ORDER BY 1, 3, 5

END ELSE IF @m_select_by = 5 BEGIN --order number

	INSERT INTO #AvailableSelections (ClientCode, ClientName, OrderNumber, OrderDescription, MediaFrom, IsSelected)
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[OrderNumber] = s.ORDER_NBR,
		[OrderDescription] = s.ORDER_DESC,
		[MediaFrom] = s.MEDIA_FROM,
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
	WHERE s.BCC_ID IS NOT NULL

	UNION

	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[OrderNumber] = s.ORDER_NBR,
		[OrderDescription] = s.ORDER_DESC,
		[MediaFrom] = s.MEDIA_FROM,
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE ORDER_NBR = s.ORDER_NBR
						AND BCC_ID IS NOT NULL)
	OPTION (RECOMPILE)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
						FROM dbo.DIVISION d
							INNER JOIN dbo.PRODUCT p ON p.CL_CODE = d.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
							INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
																AND p.CL_CODE = sc.CL_CODE
																AND p.DIV_CODE = sc.DIV_CODE
																AND p.PRD_CODE = sc.PRD_CODE
						WHERE d.CL_CODE = s.ClientCode
						AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
					 )
		ORDER BY MediaFrom, OrderNumber DESC
	ELSE
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
						FROM dbo.DIVISION d
							INNER JOIN dbo.PRODUCT p ON p.CL_CODE = d.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
						WHERE d.CL_CODE = s.ClientCode
						AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
					 )
		ORDER BY MediaFrom, OrderNumber DESC
	--ORDER BY 5, 3 DESC 

END ELSE IF @m_select_by = 6 BEGIN --client PO

	INSERT INTO #AvailableSelections (ClientPO, ClientCode, ClientName, DivisionCode, DivisionName, ProductCode, ProductDescription, IsSelected)
	SELECT
		[ClientPO] = s.CLIENT_PO,
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE AND D.ACTIVE_FLAG = 1
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE AND P.ACTIVE_FLAG = 1
	WHERE s.BCC_ID IS NOT NULL
	AND s.CLIENT_PO IS NOT NULL

	UNION

	SELECT
		[ClientPO] = s.CLIENT_PO,
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[DivisionCode] = s.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[ProductCode] = s.PRD_CODE,
		[ProductDescription] = P.PRD_DESCRIPTION,
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
		INNER JOIN dbo.DIVISION D ON s.CL_CODE = D.CL_CODE AND s.DIV_CODE = D.DIV_CODE AND D.ACTIVE_FLAG = 1
		INNER JOIN dbo.PRODUCT P ON s.CL_CODE = P.CL_CODE AND s.DIV_CODE = P.DIV_CODE AND s.PRD_CODE = P.PRD_CODE AND P.ACTIVE_FLAG = 1
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE CLIENT_PO = s.CLIENT_PO
						AND CL_CODE = s.CL_CODE
						AND DIV_CODE = s.DIV_CODE
						AND PRD_CODE = s.PRD_CODE
						AND BCC_ID IS NOT NULL)
	AND s.CLIENT_PO IS NOT NULL
	OPTION (RECOMPILE)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
		SELECT *
		FROM #AvailableSelections s
			INNER JOIN dbo.PRODUCT p ON s.ClientCode = p.CL_CODE AND s.DivisionCode = p.DIV_CODE AND s.ProductCode = p.PRD_CODE
			INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
											AND s.ClientCode = sc.CL_CODE
											AND s.DivisionCode = sc.DIV_CODE
											AND s.ProductCode = sc.PRD_CODE
		WHERE p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
		ORDER BY ClientPO
	ELSE
		SELECT *
		FROM #AvailableSelections s
			INNER JOIN dbo.PRODUCT p ON s.ClientCode = p.CL_CODE AND s.DivisionCode = p.DIV_CODE AND s.ProductCode = p.PRD_CODE
		WHERE p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
		ORDER BY ClientPO
	--ORDER BY 1

END ELSE IF @m_select_by = 7  --market

	SELECT 
		[MarketCode] = s.MARKET_CODE,
		[MarketDescription] = M.MARKET_DESC,
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.MARKET M ON s.MARKET_CODE = M.MARKET_CODE
	WHERE s.BCC_ID IS NOT NULL

	UNION

	SELECT 
		[MarketCode] = s.MARKET_CODE,
		[MarketDescription] = M.MARKET_DESC,
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.MARKET M ON s.MARKET_CODE = M.MARKET_CODE AND COALESCE(M.INACTIVE_FLAG, 0) = 0
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE MARKET_CODE = s.MARKET_CODE
						AND BCC_ID IS NOT NULL)
	ORDER BY 1, 2
	OPTION (RECOMPILE)

ELSE IF @m_select_by = 8 BEGIN --line number

	INSERT INTO #AvailableSelections (ClientCode, ClientName, OrderNumber, LineNumber, OrderDescription, MediaFrom, IsSelected)
	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[OrderNumber] = s.ORDER_NBR,
		[LineNumber] = s.LINE_NBR,
		[OrderDescription] = s.ORDER_DESC,
		[MediaFrom] = s.MEDIA_FROM,
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
	WHERE s.BCC_ID IS NOT NULL

	UNION

	SELECT
		[ClientCode] = s.CL_CODE,
		[ClientName] = C.CL_NAME,
		[OrderNumber] = s.ORDER_NBR,
		[LineNumber] = s.LINE_NBR,
		[OrderDescription] = s.ORDER_DESC,
		[MediaFrom] = s.MEDIA_FROM,
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE ORDER_NBR = s.ORDER_NBR
						AND LINE_NBR = s.LINE_NBR
						AND BCC_ID IS NOT NULL)
	OPTION (RECOMPILE)

	IF (SELECT COUNT(1) FROM dbo.SEC_CLIENT WHERE UPPER([USER_ID]) = @UserCode) > 0
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
						FROM dbo.DIVISION d
							INNER JOIN dbo.PRODUCT p ON p.CL_CODE = d.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
							INNER JOIN dbo.SEC_CLIENT sc ON UPPER(sc.[USER_ID]) = @UserCode 
																AND p.CL_CODE = sc.CL_CODE
																AND p.DIV_CODE = sc.DIV_CODE
																AND p.PRD_CODE = sc.PRD_CODE
						WHERE d.CL_CODE = s.ClientCode
						AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
					 )
		ORDER BY MediaFrom, OrderNUmber DESC, LineNumber
	ELSE
		SELECT *
		FROM #AvailableSelections s
		WHERE EXISTS (  SELECT 1
								FROM dbo.DIVISION d
									INNER JOIN dbo.PRODUCT p ON p.CL_CODE = d.CL_CODE AND p.DIV_CODE = d.DIV_CODE AND p.ACTIVE_FLAG = 1
								WHERE d.CL_CODE = s.ClientCode
								AND p.OFFICE_CODE IN (SELECT OFFICE_CODE FROM dbo.advtf_employee_office_limits (@EmployeeCode))
							 )
		ORDER BY MediaFrom, OrderNUmber DESC, LineNumber
	--ORDER BY 6, 3 DESC, 4

END ELSE IF @m_select_by = 9  --client biller

	SELECT 
		[BillerEmployeeCode] = C.BILLER_EMP_CODE,
		[ClientBiller] = [dbo].[advfn_get_emp_name] ( C.BILLER_EMP_CODE, 'FML' ),
		[IsSelected] = CAST(1 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
	WHERE s.BCC_ID IS NOT NULL
	AND NULLIF(C.BILLER_EMP_CODE, '') IS NOT NULL

	UNION

	SELECT 
		[BillerEmployeeCode] = C.BILLER_EMP_CODE,
		[ClientBiller] = [dbo].[advfn_get_emp_name] ( C.BILLER_EMP_CODE, 'FML' ),
		[IsSelected] = CAST(0 as bit)
	FROM @selection s
		INNER JOIN dbo.CLIENT C ON s.CL_CODE = C.CL_CODE AND C.ACTIVE_FLAG = 1
	WHERE NOT EXISTS (SELECT 1
						FROM @selection
						WHERE CL_CODE = s.CL_CODE
						AND BCC_ID IS NOT NULL)
	AND NULLIF(C.BILLER_EMP_CODE, '') IS NOT NULL
	ORDER BY 1, 2
	OPTION (RECOMPILE)

GO
