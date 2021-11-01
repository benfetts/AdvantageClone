
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.advsp_media_delete_order') AND type in (N'P', N'PC'))
DROP PROCEDURE dbo.advsp_media_delete_order
GO


CREATE PROCEDURE dbo.advsp_media_delete_order
	@media_type varchar(1),
	@order_nbr int,
	@line_nbr int,
	@ret_val int OUTPUT,
	@ret_val_s varchar(200) OUTPUT
AS

/* 
Used to verify and delete all media types

PJH 02/08/17 - Changed from " > 0" Per EC to 	IF (@ord_status NOT IN (0,1,2,4)) BEGIN
PJH 02/09/17 - Changed to VCC_CARD from MEDIA_MGR_GENERATED_REPORT
PJH 03/22/17 - Added Ad Server check for Internet
PJH 09/12/17 - Added Broadcast Worksheet Update
PJH 12/11/18 - Added INTERNET_PACKAGE_DETAIL
PJH 04/16/19 - Added (5351-1-114 - Delete any related document ID's and allow order to be deleted)
PJH 04/17/19 - Changed to IF (@ord_status IN (5))
PJH 04/18/19 - Added MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL & ...STAGING_DETAIL_DATE

STATUS - STATUS_DESC - ORDER_STATUS
0	Pending
1	Printed
2	Quote Generated
3	Quote Accepted
4	Order Generated
5	Order Accepted
6	Materials Delivered
7	Material Delivery Verified
8	Cancellation Generated
9	Cancellation Accepted
10	Cost Collected
11	Approved for Billing
12	Quote Received
13	Order Received
14	Cancellation Received

*/

DECLARE @documents TABLE(
	DOCUMENT_ID [int] NOT NULL,
	ORDER_NBR [int] NOT NULL
	)

DECLARE @date_time_w smalldatetime, @start_date_w smalldatetime
DECLARE @error_msg_w varchar(200)

DECLARE @ErMessage nvarchar(2048),
				@ErSeverity int,
				@ErState int

DECLARE @cnt int				
DECLARE @detail int, @ap int, @billed int, @bill_sel int, @vcc int, @ord_status int, @cci int, @imported int, @ad_server_id int, @document_id int

BEGIN TRY

	SET @ret_val = 0
	
	IF @line_nbr = 0 SET @line_nbr = NULL
	
	SET @error_msg_w = ''

	IF @media_type = 'N' BEGIN
		SELECT @cnt = COUNT(1)
		FROM NEWSPAPER_HEADER A LEFT JOIN NEWSPAPER_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND (ACTIVE_REV = 1 OR @line_nbr IS NULL)
		
		IF COALESCE(@cnt, 0) > 0 BEGIN		
			SELECT @detail = COUNT(1) FROM NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ap = COUNT(1) FROM AP_NEWSPAPER WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @billed = COUNT(1) FROM NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr AND AR_INV_NBR IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @bill_sel = COUNT(1) FROM NEWSPAPER_HEADER WHERE ORDER_NBR = @order_nbr AND BCC_ID IS NOT NULL
			SELECT @bill_sel = @bill_sel + COUNT(1) FROM NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr AND BILLING_USER IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ord_status = COUNT(1) FROM NEWSPAPER_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND ([STATUS] IN (5)) --NOT IN (0,1,2,4)) --PJH 04/17/19
			SELECT @imported = COUNT(1) FROM NEWSPAPER_HEADER WHERE LINK_ID IS NOT NULL 
				AND (ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = @order_nbr)   
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM ATB_REV_DTL_ORDER WHERE ORDER_NBR = @order_nbr))
				AND ORDER_NBR = @order_nbr 
			SELECT @document_id = COUNT(1) FROM NEWSPAPER_DOCUMENT WHERE ORDER_NBR = @order_nbr
		END 
	END	
	IF @media_type = 'M' BEGIN
		SELECT @cnt = COUNT(1)
		FROM MAGAZINE_HEADER A LEFT JOIN MAGAZINE_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND (ACTIVE_REV = 1 OR @line_nbr IS NULL)
		
		IF COALESCE(@cnt, 0) > 0 BEGIN		
			SELECT @detail = COUNT(1) FROM MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ap = COUNT(1) FROM AP_MAGAZINE WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @billed = COUNT(1) FROM MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr AND AR_INV_NBR IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @bill_sel = COUNT(1) FROM MAGAZINE_HEADER WHERE ORDER_NBR = @order_nbr AND BCC_ID IS NOT NULL
			SELECT @bill_sel = @bill_sel + COUNT(1) FROM MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr AND BILLING_USER IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ord_status = COUNT(1) FROM MAGAZINE_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND ([STATUS] IN (5)) --NOT IN (0,1,2,4)) --PJH 04/17/19
			SELECT @imported = COUNT(1) FROM MAGAZINE_HEADER WHERE LINK_ID IS NOT NULL 
				AND (ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = @order_nbr)   
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM ATB_REV_DTL_ORDER WHERE ORDER_NBR = @order_nbr))
				AND ORDER_NBR = @order_nbr 
			SELECT @document_id = COUNT(1) FROM MAGAZINE_DOCUMENT WHERE ORDER_NBR = @order_nbr
		END	
	END
	IF @media_type = 'I' BEGIN
		SELECT @cnt = COUNT(1)
		FROM INTERNET_HEADER A LEFT JOIN INTERNET_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND (ACTIVE_REV = 1 OR @line_nbr IS NULL)
		
		IF COALESCE(@cnt, 0) > 0 BEGIN		
			SELECT @detail = COUNT(1) FROM INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ap = COUNT(1) FROM AP_INTERNET WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @billed = COUNT(1) FROM INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr AND AR_INV_NBR IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @bill_sel = COUNT(1) FROM INTERNET_HEADER WHERE ORDER_NBR = @order_nbr AND BCC_ID IS NOT NULL
			SELECT @bill_sel = @bill_sel + COUNT(1) FROM INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr AND BILLING_USER IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ord_status = COUNT(1) FROM INTERNET_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND ([STATUS] IN (5)) --NOT IN (0,1,2,4)) --PJH 04/17/19
			SELECT @imported = COUNT(1) FROM INTERNET_HEADER WHERE LINK_ID IS NOT NULL 
				AND (ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = @order_nbr)   
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM ATB_REV_DTL_ORDER WHERE ORDER_NBR = @order_nbr))
				AND ORDER_NBR = @order_nbr 
			SELECT @ad_server_id = COUNT(1) FROM INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr AND AD_SERVER_PLACEMENT_ID IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @document_id = COUNT(1) FROM INTERNET_DOCUMENT WHERE ORDER_NBR = @order_nbr
		END	
	END
	IF @media_type = 'O' BEGIN
		SELECT @cnt = COUNT(1)
		FROM OUTDOOR_HEADER A LEFT JOIN OUTDOOR_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND (ACTIVE_REV = 1 OR @line_nbr IS NULL)
		
		IF COALESCE(@cnt, 0) > 0 BEGIN		
			SELECT @detail = COUNT(1) FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ap = COUNT(1) FROM AP_OUTDOOR WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @billed = COUNT(1) FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND AR_INV_NBR IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @bill_sel = COUNT(1) FROM OUTDOOR_HEADER WHERE ORDER_NBR = @order_nbr AND BCC_ID IS NOT NULL
			SELECT @bill_sel = @bill_sel + COUNT(1) FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND BILLING_USER IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ord_status = COUNT(1) FROM OUTDOOR_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND ([STATUS] IN (5)) --NOT IN (0,1,2,4)) --PJH 04/17/19
			SELECT @imported = COUNT(1) FROM OUTDOOR_HEADER WHERE LINK_ID IS NOT NULL 
				AND (ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = @order_nbr)   
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM ATB_REV_DTL_ORDER WHERE ORDER_NBR = @order_nbr))
				AND ORDER_NBR = @order_nbr 
			SELECT @document_id = COUNT(1) FROM OUTDOOR_DOCUMENT WHERE ORDER_NBR = @order_nbr
		END	
	END
	IF @media_type = 'R' BEGIN
		SELECT @cnt = COUNT(1)
		FROM RADIO_HDR A LEFT JOIN RADIO_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND (ACTIVE_REV = 1 OR @line_nbr IS NULL)
		
		IF COALESCE(@cnt, 0) > 0 BEGIN		
			SELECT @detail = COUNT(1) FROM  RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ap = COUNT(1) FROM AP_RADIO WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @billed = COUNT(1) FROM  RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND AR_INV_NBR IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @bill_sel = COUNT(1) FROM  RADIO_HDR WHERE ORDER_NBR = @order_nbr AND BCC_ID IS NOT NULL
			SELECT @bill_sel = @bill_sel + COUNT(1) FROM  RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND BILLING_USER IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ord_status = COUNT(1) FROM RADIO_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND ([STATUS] IN (5)) --NOT IN (0,1,2,4)) --PJH 04/17/19
			SELECT @imported = COUNT(1) FROM RADIO_HDR WHERE LINK_ID IS NOT NULL 
				AND (ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = @order_nbr)   
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM ATB_REV_DTL_ORDER WHERE ORDER_NBR = @order_nbr)
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE WHERE ORDER_NBR = @order_nbr))
				AND ORDER_NBR = @order_nbr 
			SELECT @document_id = COUNT(1) FROM RADIO_DOCUMENT WHERE ORDER_NBR = @order_nbr
		END	
	END
	IF @media_type = 'T' BEGIN
		SELECT @cnt = COUNT(1)
		FROM TV_HDR A LEFT JOIN TV_DETAIL B ON A.ORDER_NBR = B.ORDER_NBR
		WHERE A.ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND (ACTIVE_REV = 1 OR @line_nbr IS NULL)
		
		IF COALESCE(@cnt, 0) > 0 BEGIN		
			SELECT @detail = COUNT(1) FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ap = COUNT(1) FROM AP_TV WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @billed = COUNT(1) FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND AR_INV_NBR IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @bill_sel = COUNT(1) FROM TV_HDR WHERE ORDER_NBR = @order_nbr AND BCC_ID IS NOT NULL
			SELECT @bill_sel = @bill_sel + COUNT(1) FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND BILLING_USER IS NOT NULL AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
			SELECT @ord_status = COUNT(1) FROM TV_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) AND ([STATUS] IN (5)) --NOT IN (0,1,2,4)) --PJH 04/17/19
			SELECT @imported = COUNT(1) FROM TV_HDR WHERE LINK_ID IS NOT NULL 
				AND (ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_PLAN_DTL_LEVEL_LINE_DATA WHERE ORDER_NBR = @order_nbr)   
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM ATB_REV_DTL_ORDER WHERE ORDER_NBR = @order_nbr)
						AND ORDER_NBR NOT IN (SELECT COALESCE(ORDER_NBR,0) FROM MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE WHERE ORDER_NBR = @order_nbr))
				AND ORDER_NBR = @order_nbr 
			SELECT @document_id = COUNT(1) FROM TV_DOCUMENT WHERE ORDER_NBR = @order_nbr
		END	
	END					
	
	SELECT @vcc = COUNT(1) FROM VCC_CARD WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
	SELECT @cci = COUNT(1) FROM COLLECTED_COST_INFO WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
	
	SELECT @cnt '@cnt', @order_nbr '@order_nbr', @line_nbr '@line_nbr'
	
	IF COALESCE(@cnt, 0) = 0 BEGIN
		SET @error_msg_w = 'No matching order/line.'
		GOTO ERROR_MSG
	END
	
	SELECT @date_time_w=GETDATE()

	IF (@ap > 0)  BEGIN 
		SET @error_msg_w = 'Can''t delete an order/line with associated AP records.'
	END

	IF (@billed > 0)  BEGIN 
		IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
		SET @error_msg_w = @error_msg_w + 'Can''t delete a billed order/line.'
	END
	
	IF (@bill_sel > 0)  BEGIN 
		IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
		SET @error_msg_w = @error_msg_w + 'Can''t delete an order/line that is selected for billing.'
	END	
	
	IF (@vcc > 0)  BEGIN 
		IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
		SET @error_msg_w = @error_msg_w + 'Can''t delete an order/line that is associated with Virtual Credit Card records.'
	END		
	
	IF (@cci > 0)  BEGIN 
		IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
		SET @error_msg_w = @error_msg_w + 'Can''t delete an order/line that is associated with Collected Cost information.'
	END			
	
	/* PJH 04/17/19 - Changed */
	IF (@ord_status > 0)  BEGIN 
		IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
		SET @error_msg_w = @error_msg_w + 'Can''t delete an order/line that has an Order Accepted status.'
	END		
	
	IF (@imported > 0)  BEGIN 
		IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
		SET @error_msg_w = @error_msg_w + 'Can''t delete an order/line that was imported.'
	END		
	
	IF (@ad_server_id > 0)  BEGIN 
		IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
		SET @error_msg_w = @error_msg_w + 'Can''t delete an order/line that has an associated Ad Server ID.'
	END		
	
	/* PJH 04/16/19 - Commented */
	--IF (@document_id > 0)  BEGIN 
	--	IF @error_msg_w IS NOT NULL SET @error_msg_w = @error_msg_w + CHAR(13)
	--	SET @error_msg_w = @error_msg_w + 'Can''t delete an order/line that has an associated Document ID.'
	--END				
	
	IF LEN(@error_msg_w) > 0 OR @error_msg_w <> '' BEGIN
		GOTO ERROR_MSG
	END
	
	SELECT CAST(@order_nbr AS int) '@order_nbr', @media_type '@media_type'
	
	/* GENERAL TABLES */
	
	DELETE FROM PRINT_IMPORT_XREF WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
	DELETE FROM BRD_IMPORT_XREF WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
	
	UPDATE MEDIA_PLAN_DTL_LEVEL_LINE_DATA 
	SET ORDER_NBR = NULL, ORDER_LINE_NBR = NULL, ORDER_ID = NULL, ORDER_LINE_ID = NULL, HAS_PENDING_ORDERS = 0
	WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)

	UPDATE ATB_REV_DTL_ORDER 
	SET ORDER_NBR = NULL, ORDER_LINE_NBR = NULL, ORDER_ID = NULL, ORDER_LINE_ID = NULL
	WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)

	/* PJH 04/18/19 - Added MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE */
	DELETE AA 
	FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE AA	
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL BB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID = BB.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON BB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	WHERE AB.ORDER_NBR = @order_nbr --AND (AB.ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)

	/* PJH 04/18/19 - Added MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL */
	DELETE AA 
	FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL AA	
	INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
	WHERE AB.ORDER_NBR = @order_nbr --AND (AB.ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)

	/* PJH 09/12/17 - Added Broadcast Worksheet */
	/** Update Worksheet **/
	UPDATE MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE 
	SET ORDER_NBR = NULL, ORDER_LINE_NBR = NULL, LINK_ID = NULL, LINK_LINE_ID = NULL, MEDIA_BROADCAST_WORKSHEET_ORDER_STATUS_ID = 1 
	WHERE ORDER_NBR = @order_nbr AND (ORDER_LINE_NBR = @line_nbr OR @line_nbr IS NULL)
	
	UPDATE PRINT_EST_DTL SET ORDER_NBR = NULL, STATUS = 'Estimate' WHERE ORDER_NBR = @order_nbr
	
	--DELETE FROM COLLECTED_COST_INFO WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
	DELETE FROM MEDIA_RPT_DATES WHERE ORDER_NBR = @order_nbr
	DELETE FROM ORD_PROCESS_LOG WHERE ORDER_NBR = @order_nbr

	IF @media_type = 'N' BEGIN	
		/* PJH 04/16/19 - Added */
		INSERT INTO @documents SELECT DOCUMENT_ID, ORDER_NBR FROM NEWSPAPER_DOCUMENT WHERE ORDER_NBR = @order_nbr
		DELETE FROM NEWSPAPER_DOCUMENT WHERE ORDER_NBR = @order_nbr 
		DELETE FROM DOCUMENTS WHERE DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM @documents)

		DELETE FROM NEWSPAPER_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM NEWSPAPER_COMMENTS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM NEWSPAPER_OTH_CHGS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM ZIP_CODE WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL) /* PJH 06/20/16 */
		IF @line_nbr IS NULL
			DELETE FROM NEWSPAPER_HEADER WHERE ORDER_NBR = @order_nbr
	END
	
	IF @media_type = 'M' BEGIN	
		/* PJH 04/16/19 - Added */
		INSERT INTO @documents SELECT DOCUMENT_ID, ORDER_NBR FROM MAGAZINE_DOCUMENT WHERE ORDER_NBR = @order_nbr
		DELETE FROM MAGAZINE_DOCUMENT WHERE ORDER_NBR = @order_nbr 
		DELETE FROM DOCUMENTS WHERE DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM @documents)

		DELETE FROM MAGAZINE_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM MAGAZINE_COMMENTS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		IF @line_nbr IS NULL
			DELETE FROM MAGAZINE_HEADER WHERE ORDER_NBR = @order_nbr
	END	
	
	IF @media_type = 'I' BEGIN	
		/* PJH 12/11/18 - Added INTERNET_PACKAGE_DETAIL */
		/* PJH 04/16/19 - Added */
		INSERT INTO @documents SELECT DOCUMENT_ID, ORDER_NBR FROM INTERNET_DOCUMENT WHERE ORDER_NBR = @order_nbr
		DELETE FROM INTERNET_DOCUMENT WHERE ORDER_NBR = @order_nbr 
		DELETE FROM DOCUMENTS WHERE DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM @documents)

		DELETE FROM INTERNET_PACKAGE_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM INTERNET_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM INTERNET_COMMENTS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		IF @line_nbr IS NULL
			DELETE FROM INTERNET_HEADER WHERE ORDER_NBR = @order_nbr
	END		
	
	IF @media_type = 'O' BEGIN	
		/* PJH 04/16/19 - Added */
		INSERT INTO @documents SELECT DOCUMENT_ID, ORDER_NBR FROM OUTDOOR_DOCUMENT WHERE ORDER_NBR = @order_nbr
		DELETE FROM OUTDOOR_DOCUMENT WHERE ORDER_NBR = @order_nbr 
		DELETE FROM DOCUMENTS WHERE DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM @documents)

		DELETE FROM OUTDOOR_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM OUTDOOR_COMMENTS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		IF @line_nbr IS NULL
			DELETE FROM OUTDOOR_HEADER WHERE ORDER_NBR = @order_nbr
	END		
	
	IF @media_type = 'R' BEGIN	
		/* PJH 04/16/19 - Added */
		INSERT INTO @documents SELECT DOCUMENT_ID, ORDER_NBR FROM RADIO_DOCUMENT WHERE ORDER_NBR = @order_nbr
		DELETE FROM RADIO_DOCUMENT WHERE ORDER_NBR = @order_nbr 
		DELETE FROM DOCUMENTS WHERE DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM @documents)

		DELETE FROM RADIO_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM RADIO_COMMENTS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM RADIO_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		IF @line_nbr IS NULL
			DELETE FROM RADIO_HDR WHERE ORDER_NBR = @order_nbr
	END			
	
	IF @media_type = 'T' BEGIN	
		/* PJH 04/16/19 - Added */
		INSERT INTO @documents SELECT DOCUMENT_ID, ORDER_NBR FROM TV_DOCUMENT WHERE ORDER_NBR = @order_nbr
		DELETE FROM TV_DOCUMENT WHERE ORDER_NBR = @order_nbr 
		DELETE FROM DOCUMENTS WHERE DOCUMENT_ID IN (SELECT DOCUMENT_ID FROM @documents)

		DELETE FROM TV_ORDER_STATUS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM TV_COMMENTS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM TV_DETAIL_UNITS WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		DELETE FROM TV_DETAIL WHERE ORDER_NBR = @order_nbr AND (LINE_NBR = @line_nbr OR @line_nbr IS NULL)
		IF @line_nbr IS NULL
			DELETE FROM TV_HDR WHERE ORDER_NBR = @order_nbr
	END				
	
	GOTO END_IT
		
	/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN		

			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	/**************************** FINISHED PROCESSING *********************************************************************/	
	END_IT: --Do Nothing
	
	IF @line_nbr IS NULL
		SET @ret_val_s = 'Order Deleted!'
	Else
		SET @ret_val_s = 'Order Line Deleted!'
	
END TRY

BEGIN CATCH

	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'   /* DEBUG */	
	
	IF @ErState = 1 	
		SET @ret_val = 50000 -- Advise msg
	ELSE 	
		SET @ret_val = -1 -- Error msg
	
	SET @ret_val_s = @ErMessage

END CATCH


RETURN

SELECT 'HELP - How did I get here??'
GO

GRANT EXECUTE ON [advsp_media_delete_order] TO PUBLIC AS dbo