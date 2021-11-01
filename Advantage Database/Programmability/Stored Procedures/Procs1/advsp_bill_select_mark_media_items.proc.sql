CREATE PROCEDURE [dbo].[advsp_bill_select_mark_media_items] 
	@billing_user varchar(100),	@order_number_in integer, @line_number_in smallint, 
	@inv_date_in smalldatetime, @post_period_in varchar(6), @radio_in smallint, 
	@television_in smallint, @magazine_in smallint,	@internet_in smallint, @out_of_home_in smallint, 
	@newspaper_in smallint, @m_start_date_in smalldatetime, @m_cutoff_date_in smalldatetime,
	@date_to_use_in smallint, @brdcast_date1_in smalldatetime, @brdcast_date2_in smalldatetime, 
	@incl_zero_spots_in bit, @ret_val integer OUTPUT, @amount_selected_for_billing decimal(18,2) OUTPUT
AS

SET NOCOUNT ON

DECLARE @sql_upd_billing varchar(4000), @total_rows integer
DECLARE @radio2_rows integer, @tv2_rows integer, @radio_rows integer, @tv_rows integer 
DECLARE @mag_rows integer, @news_rows integer, @inet_rows integer, @ooh_rows integer  
DECLARE @m_select_by smallint, @bcc_flag smallint, @bill_media_type smallint, @month_ind tinyint
DECLARE @selection smallint, @adjustments smallint, @inv_assign smallint, @inv_print smallint 
DECLARE	@inv_date smalldatetime, @post_period varchar(6), @media smallint, @media_table varchar(8) 
DECLARE @brdcast_date1 smalldatetime, @brdcast_date2 smalldatetime, @m_cutoff_date smalldatetime
DECLARE @order_process_contrl smallint, @cl_code varchar(6), @div_code varchar(6), @prd_code varchar(6)
DECLARE @radio_pre_post smallint, @tv_pre_post smallint, @ooh_pre_post smallint, @inet_pre_post smallint
DECLARE @news_pre_post smallint, @mag_pre_post smallint, @radio_setup smallint, @tv_setup smallint 
DECLARE	@ooh_setup smallint, @inet_setup smallint, @news_setup smallint, @mag_setup smallint
DECLARE @rev_nbr smallint, @seq_nbr smallint, @brdcast_year integer, @brdcast_yr1 integer, @brdcast_yr2 integer
DECLARE @months_yr1 varchar(36), @months_yr2 varchar(36), @month_short varchar(3), @date_to_use smallint
DECLARE @m_start_date smalldatetime, @job_media_date_start smalldatetime, @job_media_date_end smalldatetime
DECLARE @tv_daily bit, @tv_monthly bit, @radio_daily bit, @radio_monthly bit

--CREATE TABLE #broadcast ( 
--	ORDER_NBR		integer NOT NULL,
--	LINE_NBR		smallint NOT NULL,
--	REV_NBR			smallint NOT NULL,
--	SEQ_NBR			smallint NOT NULL,
--	BRDCAST_YEAR	integer NOT NULL,
--	MONTH_IND		smallint NULL,
--	MONTH_SHORT		varchar(3) NULL )
	
SET @ret_val = 0
SET @sql_upd_billing = ''

DECLARE media_hdr_cursor CURSOR FOR
 SELECT vmh.ORD_PROCESS_CONTRL, UPPER( vmh.MEDIA_FROM )
   FROM dbo.V_MEDIA_HDR vmh 
  WHERE vmh.ORDER_NBR = @order_number_in
  FOR READ ONLY

OPEN media_hdr_cursor
FETCH NEXT FROM media_hdr_cursor INTO @order_process_contrl, @media_table

IF ( @@FETCH_STATUS = 0 )
BEGIN
	IF ( @order_process_contrl IS NULL OR ( @order_process_contrl NOT IN ( 1, 5 )))
		SET @ret_val = -2
	IF ( @media_table = 'MAG' OR @media_table = 'NEWS' )
		SET @ret_val = -5	
END
ELSE	-- The order was not found
	SET @ret_val = -25
	
CLOSE media_hdr_cursor
DEALLOCATE media_hdr_cursor

SELECT
	@job_media_date_start = JOB_MEDIA_BILL_DATE_FROM,
	@job_media_date_end = JOB_MEDIA_BILL_DATE_TO,
	@tv_daily = TV_DAILY, @tv_monthly = TV_MONTHLY, @radio_daily = RADIO_DAILY, @radio_monthly = RADIO_MONTHLY
FROM dbo.BILLING_CMD_CENTER
WHERE BILLING_USER = @billing_user 

IF ( @ret_val = 0 )
BEGIN

	DECLARE billing_cursor CURSOR FOR
	 SELECT SELECTION, ADJUSTMENTS, INV_ASSIGN, INV_PRINT, INV_DATE, POST_PERIOD, 
			M_SELECT_BY, MEDIA, DATE_TO_USE, M_START_DATE, M_CUTOFF_DATE, 
			M_CUTOFF_MONTH1, M_CUTOFF_MONTH2, BCC_FLAG
	   FROM dbo.BILLING 
	  WHERE BILLING_USER = @billing_user
	  FOR READ ONLY

	OPEN billing_cursor
	FETCH NEXT FROM billing_cursor INTO @selection, @adjustments, @inv_assign, @inv_print, 
		@inv_date, @post_period, @m_select_by, @media, @date_to_use, @m_start_date, 
		@m_cutoff_date,	@brdcast_date1, @brdcast_date2, @bcc_flag 

	IF ( @@FETCH_STATUS = 0 )
	BEGIN
		IF ( @inv_assign = 1 )
			SET @ret_val = -3
		ELSE
		BEGIN
			IF ( @bcc_flag = 0 )
				SET @ret_val = -4
			ELSE
			BEGIN
				IF ( @media = 0 OR @media IS NULL )
				BEGIN
					-- If media is not already selected, use the values passed in
					SET @m_select_by = 8
					SET @date_to_use = @date_to_use_in
					SET @m_start_date = @m_start_date_in
					SET @m_cutoff_date = @m_cutoff_date_in
					SET @brdcast_date1 = @brdcast_date1_in
					SET @brdcast_date2 = @brdcast_date2_in
					SET @inv_date = @inv_date_in
					SET @post_period = @post_period_in
				END				

				SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + 'UPDATE dbo.BILLING '
				SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	SET M_SELECT_BY = ' + CAST( @m_select_by AS varchar(1)) + ', '
				IF ( @date_to_use IS NOT NULL )
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	DATE_TO_USE = ' + CAST( @date_to_use AS varchar(1)) + ', '				
				IF ( @m_start_date IS NOT NULL )
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	M_START_DATE = ''' + CONVERT( varchar(10), @m_start_date, 101 ) + ''', '
				IF ( @m_cutoff_date IS NOT NULL )
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	M_CUTOFF_DATE = ''' + CONVERT( varchar(10), @m_cutoff_date, 101 ) + ''', '
				IF ( @brdcast_date1 IS NOT NULL )	
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	M_CUTOFF_MONTH1 = ''' + CONVERT( varchar(10), @brdcast_date1, 101 ) + ''', '
				IF ( @brdcast_date2 IS NOT NULL )
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	M_CUTOFF_MONTH2 = ''' + CONVERT( varchar(10), @brdcast_date2, 101 ) + ''', '
				IF ( @radio_in = 1 )
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	RADIO = 1, '
				IF ( @television_in = 1 )	
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	TELEVISION = 1, '
				IF ( @magazine_in = 1 ) 	
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	MAGAZINE = 1, '
				IF ( @newspaper_in = 1 )	
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	NEWSPAPER = 1, '
				IF ( @out_of_home_in = 1 )	
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	OUTDOOR = 1, '
				IF ( @internet_in = 1 )	
					SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	INTERNET = 1, '
				SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		MEDIA = 1 '
				SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + ' WHERE BILLING_USER = ''' + @billing_user + ''' '
				  
			END	
		END
	END
	ELSE
	BEGIN
		-- No billing record, use values passed in
		SET @m_select_by = 8
		SET @date_to_use = @date_to_use_in
		SET @m_start_date = @m_start_date_in
		SET @m_cutoff_date = @m_cutoff_date_in
		SET @brdcast_date1 = @brdcast_date1_in
		SET @brdcast_date2 = @brdcast_date2_in
		SET @inv_date = @inv_date_in
		SET @post_period = @post_period_in
		
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	INSERT INTO dbo.BILLING ( BILLING_USER, SELECTION, APPROVAL_OL,'
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		APPROVAL_PRN, ADJUSTMENTS, INV_ASSIGN, INV_PRINT, INV_DATE,'
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		POST_PERIOD, SELECT_BY, MEDIA, PRODUCTION, SERVICE_FEES, '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		FIRST_INV, LAST_INV, P_EMPTIME_DATE, P_CUTOFF_PP, M_SELECT_BY,'
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		DATE_TO_USE, M_START_DATE, M_CUTOFF_DATE,'
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		NEWSPAPER, MAGAZINE, RADIO, TELEVISION, OUTDOOR,'
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		M_CUTOFF_MONTH1, M_CUTOFF_MONTH2, P_INCOMEONLY_DATE, P_ADVBILL_DATE,'
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '		INTERNET, INC_NO_DTL, AB_JOBS_ONLY, BCC_FLAG ) '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '	 VALUES ( ''' + @billing_user + ''', 1, NULL, NULL, NULL, NULL, NULL, '  
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + CONVERT( varchar(10), @inv_date, 101 ) + ''', '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + @post_period + ''', 1, 1, 0, 0, NULL, NULL, NULL, NULL, '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ' + CAST( @m_select_by AS varchar(1)) + ', '
		IF ( @date_to_use IS NOT NULL )
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ' + CAST( @date_to_use AS varchar(1)) + ', '
		ELSE
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  NULL, '						
		IF ( @m_start_date IS NOT NULL )
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + CONVERT( varchar(10), @m_start_date, 101 ) + ''', '
		ELSE
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  NULL, '		
		IF ( @m_cutoff_date IS NOT NULL )
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + CONVERT( varchar(10), @m_cutoff_date, 101 ) + ''', '
		ELSE
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  NULL, '		
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ' + CAST( @newspaper_in AS varchar(1)) + ', '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ' + CAST( @magazine_in AS varchar(1)) + ', '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ' + CAST( @radio_in AS varchar(1)) + ', '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ' + CAST( @television_in AS varchar(1)) + ', '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ' + CAST( @out_of_home_in AS varchar(1)) + ', '
		IF ( @brdcast_date1_in IS NOT NULL )			
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + CONVERT( varchar(10), @brdcast_date1_in, 101 ) + ''', '
		ELSE
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  NULL, '
		IF ( @brdcast_date2_in IS NOT NULL )			
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  ''' + CONVERT( varchar(10), @brdcast_date2_in, 101 ) + ''', '
		ELSE		        
			SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  NULL, '
		SELECT @sql_upd_billing = @sql_upd_billing + CHAR(13) + '			  NULL, NULL, ' + CAST( @internet_in AS varchar(1)) + ', NULL, NULL, 1 ) '
	END
	
	CLOSE billing_cursor
	DEALLOCATE billing_cursor

END

SET @m_select_by = 8

IF ( @ret_val = 0 )
BEGIN
	
	DECLARE product_cursor CURSOR FOR
	 SELECT DISTINCT A.CL_CODE, A.DIV_CODE, A.PRD_CODE,	C.PRD_RADIO_PRE_POST, C.PRD_TV_PRE_POST,
			C.PRD_OTDR_PRE_POST, C.PRD_MISC_PRE_POST, C.PRD_NEWS_PRE_POST, C.PRD_MAG_PRE_POST,
			C.RADIO_SETUP_COMPLETE, C.TV_SETUP_COMPLETE, C.OOH_SETUP_COMPLETE, C.INET_SETUP_COMPLETE,
			C.NEWS_SETUP_COMPLETE, C.MAG_SETUP_COMPLETE, B.BILL_MEDIA_TYPE
	   FROM dbo.V_MEDIA_HDR A 
 INNER JOIN dbo.PRODUCT C ON ( A.CL_CODE = C.CL_CODE ) AND ( A.DIV_CODE = C.DIV_CODE ) AND ( A.PRD_CODE = C.PRD_CODE )
 INNER JOIN dbo.AGENCY B ON ( A.ORDER_NBR = @order_number_in )
	FOR READ ONLY
	 
	OPEN product_cursor 
	FETCH NEXT FROM product_cursor INTO @cl_code, @div_code, @prd_code, @radio_pre_post, @tv_pre_post,
		@ooh_pre_post, @inet_pre_post, @news_pre_post, @mag_pre_post, @radio_setup, @tv_setup, 
		@ooh_setup, @inet_setup, @news_setup, @mag_setup, @bill_media_type

	IF ( @@FETCH_STATUS <> 0 )
		SET @ret_val = -6

	CLOSE product_cursor
	DEALLOCATE product_cursor

END

IF ISDATE(@brdcast_date2) = 1
    SET @brdcast_date2 = DATEADD(n, -1, DATEADD(mm, 1, @brdcast_date2))

--IF ( @ret_val = 0 )
--BEGIN
--	IF ( @media_table = 'RADIO' AND @brdcast_date1 > '1900-01-01' AND @brdcast_date2 > '1900-01-01' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @radio_setup = 1 )) 
--	BEGIN
--		DELETE FROM #broadcast
		
--		IF ( @@ERROR <> 0 )
--			SET @ret_val = -20
--		ELSE	
--		BEGIN
--			INSERT INTO #broadcast( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, BRDCAST_YEAR, MONTH_IND, MONTH_SHORT )
--				 SELECT D.ORDER_NBR, D.LINE_NBR, D.REV_NBR, D.SEQ_NBR,
--						D.BRDCAST_YEAR, B.MONTH_IND, B.MONTH_SHORT
--				   FROM dbo.RADIO_HEADER A 
--			 INNER JOIN dbo.RADIO_DETAIL1 D
--					 ON ( A.ORDER_NBR = D.ORDER_NBR ) 
--					AND ( A.REV_NBR = D.REV_NBR )
--		LEFT OUTER JOIN dbo.V_RADIO_DETAIL1 B					  
--					 ON ( D.ORDER_NBR = B.ORDER_NBR ) 
--					AND ( D.REV_NBR = B.REV_NBR )
--					AND ( D.LINE_NBR = B.LINE_NBR )
--					AND ( D.SEQ_NBR = B.SEQ_NBR )
--					AND ( D.BRDCAST_YEAR = B.BRDCAST_YEAR )
--					AND ( CONVERT( smalldatetime, CONVERT( varchar(2), B.MONTH_IND ) + '/01/' + CONVERT( varchar(4), B.BRDCAST_YEAR )) 
--						BETWEEN @brdcast_date1 AND @brdcast_date2 )
--  				  WHERE A.ORD_PROCESS_CONTRL IN ( 1, 5 ) 
--					AND A.ORDER_NBR = @order_number_in 
--					AND D.LINE_NBR = @line_number_in
--					AND ( D.BILLING_USER IS NULL OR D.BILLING_USER = @billing_user )
--					AND ( D.DO_NOT_BILL IS NULL OR D.DO_NOT_BILL = 0 ) 
--					AND (	( D.AR_INV_NBR IS NULL AND ( 
--								( D.NETCHARGES <> 0.00 AND D.NETCHARGES IS NOT NULL  ) OR 
--								( D.VENDOR_TAX_NC <> 0.00 AND D.VENDOR_TAX_NC IS NOT NULL ) OR 
--								( D.STATE_TAX_NC <> 0.00 AND D.STATE_TAX_NC IS NOT NULL ) OR 
--								( D.COUNTY_TAX_NC <> 0.00 AND D.COUNTY_TAX_NC IS NOT NULL ) OR 
--								( D.CITY_TAX_NC <> 0.00 AND D.CITY_TAX_NC IS NOT NULL )))  
--						 OR ( B.AR_INV_NBR IS NULL AND (
--								( B.SPOTS <> 0 AND B.SPOTS IS NOT NULL AND @incl_zero_spots_in = 1 ) OR
--								( B.BILLING_AMT <> 0.00 AND B.BILLING_AMT IS NOT NULL ) OR
--								( B.LINE_NET <> 0.00 AND B.LINE_NET IS NOT NULL ) OR
--								( B.COMM_AMT <> 0.00 AND B.COMM_AMT IS NOT NULL ) OR
--								( B.REBATE_AMT <> 0.00 AND B.REBATE_AMT IS NOT NULL ) OR
--								( B.DISCOUNT <> 0.00 AND B.DISCOUNT IS NOT NULL ) OR
--								( B.VENDOR_TAX <> 0.00 AND B.VENDOR_TAX IS NOT NULL ) OR
--								( B.STATE_TAX <> 0.00 AND B.STATE_TAX IS NOT NULL ) OR
--								( B.COUNTY_TAX <> 0.00 AND B.COUNTY_TAX IS NOT NULL ) OR
--								( B.CITY_TAX <> 0.00 AND B.CITY_TAX IS NOT NULL ))))
--					AND ( @radio_pre_post = 1 OR @radio_pre_post IS NULL 
--						OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
--									  FROM dbo.V_AP_MEDIA_RADIO apr
--									 WHERE apr.ORDER_NBR = @order_number_in 
--									   AND apr.BRDCAST_MONTH = B.MONTH_SHORT
--									   AND apr.BRDCAST_YEAR = B.BRDCAST_YEAR ))
--			   GROUP BY D.ORDER_NBR, D.LINE_NBR, D.REV_NBR, D.SEQ_NBR, D.BRDCAST_YEAR, B.MONTH_IND, B.MONTH_SHORT
--			   ORDER BY D.ORDER_NBR, D.LINE_NBR, D.REV_NBR ASC, D.SEQ_NBR ASC, D.BRDCAST_YEAR ASC, B.MONTH_IND ASC
			
--			IF ( @@ERROR <> 0 )
--				SET @ret_val = -21
--		END		   
		
--		IF ( @ret_val = 0 )
--		BEGIN
			
--			SET @months_yr1 = ''   
--			SET @months_yr2 = ''
			
--			SET @brdcast_yr1 = DATEPART( yyyy, @brdcast_date1 )
--			SET @brdcast_yr2 = DATEPART( yyyy, @brdcast_date2 )
			
--			DECLARE radio_cursor CURSOR FOR
--			 SELECT month_ind, month_short, brdcast_yr 
--			   FROM dbo.advtf_brdcast_month_table( @brdcast_date1, @brdcast_date2 )
--		   ORDER BY listpos ASC
--			FOR READ ONLY
			
--			OPEN radio_cursor 
--			FETCH NEXT FROM radio_cursor INTO @month_ind, @month_short, @brdcast_year
		 
--			WHILE( @@FETCH_STATUS = 0 )
--			BEGIN
--				IF ( @radio_pre_post = 2 )
--				BEGIN
--					-- Check for an A/P record
--					IF EXISTS ( SELECT * FROM #broadcast WHERE BRDCAST_YEAR = @brdcast_year AND MONTH_IND = @month_ind  )
--					BEGIN
--						IF ( @brdcast_year = @brdcast_yr1 )
--							SET @months_yr1 = @months_yr1 + @month_short
--						ELSE
--							SET @months_yr2 = @months_yr2 + @month_short	
--					END
						
--				END	
--				ELSE	-- Doesn't matter if an A/P record exists or not
--				BEGIN
--					IF ( @brdcast_year = @brdcast_yr1 )
--						SET @months_yr1 = @months_yr1 + @month_short
--					ELSE
--						SET @months_yr2 = @months_yr2 + @month_short
--				END														               
				
--				FETCH NEXT FROM radio_cursor INTO @month_ind, @month_short, @brdcast_year
--			END

--			CLOSE radio_cursor
--			DEALLOCATE radio_cursor
					
--			 UPDATE dbo.RADIO_DETAIL1
--				SET BILLING_USER = @billing_user,
--					BILL_MONTHS = @months_yr1
--			  WHERE BRDCAST_YEAR = @brdcast_yr1
--				AND EXISTS ( SELECT *
--							   FROM #broadcast b
--							  WHERE b.ORDER_NBR = dbo.RADIO_DETAIL1.ORDER_NBR
--								AND b.LINE_NBR = dbo.RADIO_DETAIL1.LINE_NBR
--								AND b.REV_NBR = dbo.RADIO_DETAIL1.REV_NBR
--								AND b.SEQ_NBR = dbo.RADIO_DETAIL1.SEQ_NBR
--								AND b.BRDCAST_YEAR = dbo.RADIO_DETAIL1.BRDCAST_YEAR )
			
--			SET @radio_rows = @@ROWCOUNT								
			
--			IF ( @@ERROR <> 0 )
--				SET @ret_val = -11					
--			ELSE
--			BEGIN
				
--				IF ( @brdcast_yr1 <> @brdcast_yr2 )
--				BEGIN
--					 UPDATE dbo.RADIO_DETAIL1
--						SET BILLING_USER = @billing_user,
--							BILL_MONTHS = @months_yr2
--					  WHERE BRDCAST_YEAR = @brdcast_yr2
--						AND EXISTS ( SELECT *
--									   FROM #broadcast b
--									  WHERE dbo.RADIO_DETAIL1.ORDER_NBR = b.ORDER_NBR
--										AND dbo.RADIO_DETAIL1.LINE_NBR = b.LINE_NBR
--										AND dbo.RADIO_DETAIL1.REV_NBR = b.REV_NBR
--										AND dbo.RADIO_DETAIL1.SEQ_NBR = b.SEQ_NBR
--										AND dbo.RADIO_DETAIL1.BRDCAST_YEAR = b.BRDCAST_YEAR )
					
--					SET @radio_rows = @radio_rows + @@ROWCOUNT										
					
--					IF ( @@ERROR <> 0 )
--						SET @ret_val = -12
--				END						 
--			END
--		END	
--	END
--	ELSE IF @media_table = 'RADIO' AND @bill_media_type = 1 AND @radio_setup = 0
--		SET @ret_val = -30
--END	

--IF ( @ret_val = 0 )
--BEGIN
--	IF ( @media_table = 'TV' AND @brdcast_date1 > '1900-01-01' AND @brdcast_date2 > '1900-01-01' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @tv_setup = 1 ))
--	BEGIN
--		DELETE FROM #broadcast
					
--		IF ( @@ERROR <> 0 )
--			SET @ret_val = -22
--		ELSE	
--		BEGIN
--			INSERT INTO #broadcast( ORDER_NBR, LINE_NBR, REV_NBR, SEQ_NBR, BRDCAST_YEAR, MONTH_IND, MONTH_SHORT )
--				 SELECT D.ORDER_NBR, D.LINE_NBR, D.REV_NBR, D.SEQ_NBR,
--						D.BRDCAST_YEAR, B.MONTH_IND, B.MONTH_SHORT
--				   FROM dbo.TV_HEADER A
--			 INNER JOIN dbo.TV_DETAIL1 D  
--					 ON ( A.ORDER_NBR = D.ORDER_NBR ) AND ( A.REV_NBR = D.REV_NBR )
--		LEFT OUTER JOIN dbo.V_TV_DETAIL1 B  
--					 ON ( D.ORDER_NBR = B.ORDER_NBR ) 
--					AND ( D.REV_NBR = B.REV_NBR )
--					AND ( D.LINE_NBR = B.LINE_NBR )
--					AND ( D.SEQ_NBR = B.SEQ_NBR )
--					AND ( D.BRDCAST_YEAR = B.BRDCAST_YEAR )
--					AND ( CONVERT( smalldatetime, CONVERT( varchar(2), B.MONTH_IND ) + '/01/' + CONVERT( varchar(4), B.BRDCAST_YEAR )) 
--						BETWEEN @brdcast_date1 AND @brdcast_date2 )
--				  WHERE A.ORD_PROCESS_CONTRL IN ( 1, 5 ) 
--					AND A.ORDER_NBR = @order_number_in 
--					AND D.LINE_NBR = @line_number_in
--					AND ( D.BILLING_USER IS NULL OR D.BILLING_USER = @billing_user )
--					AND ( D.DO_NOT_BILL IS NULL OR D.DO_NOT_BILL = 0 ) 
--					AND (	( D.AR_INV_NBR IS NULL AND ( 
--								( D.NETCHARGES <> 0.00 AND D.NETCHARGES IS NOT NULL  ) OR 
--								( D.VENDOR_TAX_NC <> 0.00 AND D.VENDOR_TAX_NC IS NOT NULL ) OR 
--								( D.STATE_TAX_NC <> 0.00 AND D.STATE_TAX_NC IS NOT NULL ) OR 
--								( D.COUNTY_TAX_NC <> 0.00 AND D.COUNTY_TAX_NC IS NOT NULL ) OR 
--								( D.CITY_TAX_NC <> 0.00 AND D.CITY_TAX_NC IS NOT NULL )))  
--						 OR ( B.AR_INV_NBR IS NULL AND (
--								( B.SPOTS <> 0 AND B.SPOTS IS NOT NULL AND @incl_zero_spots_in = 1 ) OR
--								( B.BILLING_AMT <> 0.00 AND B.BILLING_AMT IS NOT NULL ) OR
--								( B.LINE_NET <> 0.00 AND B.LINE_NET IS NOT NULL ) OR
--								( B.COMM_AMT <> 0.00 AND B.COMM_AMT IS NOT NULL ) OR
--								( B.REBATE_AMT <> 0.00 AND B.REBATE_AMT IS NOT NULL ) OR
--								( B.DISCOUNT <> 0.00 AND B.DISCOUNT IS NOT NULL ) OR
--								( B.VENDOR_TAX <> 0.00 AND B.VENDOR_TAX IS NOT NULL ) OR
--								( B.STATE_TAX <> 0.00 AND B.STATE_TAX IS NOT NULL ) OR
--								( B.COUNTY_TAX <> 0.00 AND B.COUNTY_TAX IS NOT NULL ) OR
--								( B.CITY_TAX <> 0.00 AND B.CITY_TAX IS NOT NULL ))))
--					AND ( @tv_pre_post = 1 OR @tv_pre_post IS NULL 
--						OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
--									  FROM dbo.V_AP_MEDIA_TV apt
--									 WHERE apt.ORDER_NBR = @order_number_in 
--									   AND apt.BRDCAST_MONTH = B.MONTH_SHORT
--									   AND apt.BRDCAST_YEAR = B.BRDCAST_YEAR ))
--			   GROUP BY D.ORDER_NBR, D.LINE_NBR, D.REV_NBR, D.SEQ_NBR, D.BRDCAST_YEAR, B.MONTH_IND, B.MONTH_SHORT
--			   ORDER BY D.ORDER_NBR, D.LINE_NBR, D.REV_NBR ASC, D.SEQ_NBR ASC, D.BRDCAST_YEAR ASC, B.MONTH_IND ASC
		
--			IF ( @@ERROR <> 0 )
--				SET @ret_val = -23
--		END
		
--		IF ( @ret_val = 0 )
--		BEGIN
			
--			SET @months_yr1 = ''   
--			SET @months_yr2 = ''
			
--			SET @brdcast_yr1 = DATEPART( yyyy, @brdcast_date1 )
--			SET @brdcast_yr2 = DATEPART( yyyy, @brdcast_date2 )
			
--			DECLARE tv_cursor CURSOR FOR
--			 SELECT month_ind, month_short, brdcast_yr 
--			   FROM dbo.advtf_brdcast_month_table( @brdcast_date1, @brdcast_date2 )
--		   ORDER BY listpos ASC
--			FOR READ ONLY
			
--			OPEN tv_cursor 
--			FETCH NEXT FROM tv_cursor INTO @month_ind, @month_short, @brdcast_year
			 
--			WHILE( @@FETCH_STATUS = 0 )
--			BEGIN
--				IF ( @tv_pre_post = 2 )
--				BEGIN
--					-- Check for an A/P record
--					IF EXISTS ( SELECT * FROM #broadcast WHERE BRDCAST_YEAR = @brdcast_year AND MONTH_IND = @month_ind  )
--					BEGIN
--						IF ( @brdcast_year = @brdcast_yr1 )
--							SET @months_yr1 = @months_yr1 + @month_short
--						ELSE
--							SET @months_yr2 = @months_yr2 + @month_short	
--					END
						
--				END	
--				ELSE	-- Doesn't matter if an A/P record exists or not
--				BEGIN
--					IF ( @brdcast_year = @brdcast_yr1 )
--						SET @months_yr1 = @months_yr1 + @month_short
--					ELSE
--						SET @months_yr2 = @months_yr2 + @month_short
--				END														               
				
--				FETCH NEXT FROM tv_cursor INTO @month_ind, @month_short, @brdcast_year
--			END

--			CLOSE tv_cursor
--			DEALLOCATE tv_cursor
			
--			 UPDATE dbo.TV_DETAIL1
--				SET BILLING_USER = @billing_user,
--					BILL_MONTHS = @months_yr1
--			  WHERE BRDCAST_YEAR = @brdcast_yr1
--				AND EXISTS ( SELECT *
--							   FROM #broadcast b
--							  WHERE b.ORDER_NBR = dbo.TV_DETAIL1.ORDER_NBR
--								AND b.LINE_NBR = dbo.TV_DETAIL1.LINE_NBR
--								AND b.REV_NBR = dbo.TV_DETAIL1.REV_NBR
--								AND b.SEQ_NBR = dbo.TV_DETAIL1.SEQ_NBR
--								AND b.BRDCAST_YEAR = dbo.TV_DETAIL1.BRDCAST_YEAR )
--			SET @tv_rows = @@ROWCOUNT								

--			IF ( @@ERROR <> 0 )
--				SET @ret_val = -13					
--			ELSE
--			BEGIN
				
--				IF ( @brdcast_yr1 <> @brdcast_yr2 )
--				BEGIN
--					 UPDATE dbo.TV_DETAIL1
--						SET BILLING_USER = @billing_user,
--							BILL_MONTHS = @months_yr2
--					  WHERE BRDCAST_YEAR = @brdcast_yr2
--						AND EXISTS ( SELECT *
--									   FROM #broadcast b
--									  WHERE dbo.TV_DETAIL1.ORDER_NBR = b.ORDER_NBR
--										AND dbo.TV_DETAIL1.LINE_NBR = b.LINE_NBR
--										AND dbo.TV_DETAIL1.REV_NBR = b.REV_NBR
--										AND dbo.TV_DETAIL1.SEQ_NBR = b.SEQ_NBR
--										AND dbo.TV_DETAIL1.BRDCAST_YEAR = b.BRDCAST_YEAR )

--					SET @tv_rows = @tv_rows + @@ROWCOUNT
															
--					IF ( @@ERROR <> 0 )
--						SET @ret_val = -14
--				END						 
--			END
--		END	
--	END
--	ELSE IF @media_table = 'TV' AND @bill_media_type = 1 AND @tv_setup = 0
--		SET @ret_val = -30
--END	

IF ( @ret_val = 0 )
BEGIN
	IF ( @media_table = 'MAG2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @mag_setup = 1 )) 
	BEGIN
		UPDATE dbo.MAGAZINE_DETAIL
			   SET BILLING_USER = @billing_user
		FROM dbo.MAGAZINE_DETAIL d
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			 WHERE ORDER_NBR = @order_number_in 
			   AND LINE_NBR = @line_number_in
			   AND AR_INV_NBR IS NULL
			   AND	(
					( @date_to_use = 2 AND d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
					OR 
					( @date_to_use = 1 AND DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					OR
					( @date_to_use = 3 AND COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end )
					)
			   AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
			   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
			   AND EXISTS (	 SELECT *
							   FROM dbo.MAGAZINE_HEADER A 
							  WHERE ( A.ORDER_NBR = d.ORDER_NBR )
								AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
			   AND ( @mag_pre_post = 1 OR @mag_pre_post IS NULL 
					OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
								  FROM dbo.V_AP_MEDIA_MAG C
								 WHERE C.ORDER_NBR = d.ORDER_NBR 
								   AND C.ORDER_LINE_NBR = d.LINE_NBR )
					OR ( LINE_CANCELLED = 1 AND @mag_pre_post = 2 )
					OR (SELECT COALESCE(SUM(COALESCE(BILLING_AMT, 0)),0)
												  FROM dbo.MAGAZINE_DETAIL d   
												  WHERE ORDER_NBR = @order_number_in
												  AND LINE_NBR = @line_number_in
												  AND AR_INV_NBR IS NULL) < 0
					)

			SET @mag_rows = @@ROWCOUNT

			SELECT @amount_selected_for_billing = SUM( COALESCE( BILLING_AMT, 0.00 ))
            FROM dbo.MAGAZINE_DETAIL
            WHERE ORDER_NBR = @order_number_in
            AND LINE_NBR = @line_number_in
            AND BILLING_USER IS NOT NULL
	END
	ELSE IF @media_table = 'MAG2' AND @bill_media_type = 1 AND @mag_setup = 0
		SET @ret_val = -30
END	

IF ( @ret_val = 0 )
BEGIN
	IF ( @media_table = 'NEWS2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @news_setup = 1 )) 
	BEGIN
		UPDATE dbo.NEWSPAPER_DETAIL
			   SET BILLING_USER = @billing_user
		FROM dbo.NEWSPAPER_DETAIL d
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			 WHERE ORDER_NBR = @order_number_in 
			   AND LINE_NBR = @line_number_in
			   AND AR_INV_NBR IS NULL
			   AND	(
					( @date_to_use = 2 AND d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
					OR 
					( @date_to_use = 1 AND DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					OR
					( @date_to_use = 3 AND COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end )
					)
			   AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
			   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
			   AND EXISTS (	 SELECT *
							   FROM dbo.NEWSPAPER_HEADER A 
							  WHERE ( A.ORDER_NBR = d.ORDER_NBR )
								AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
			   AND ( @news_pre_post = 1 OR @news_pre_post IS NULL 
					OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
								  FROM dbo.V_AP_MEDIA_NEWS C
								 WHERE C.ORDER_NBR = d.ORDER_NBR 
								   AND C.ORDER_LINE_NBR = d.LINE_NBR )
					OR ( LINE_CANCELLED = 1 AND @news_pre_post = 2 )
					OR (SELECT COALESCE(SUM(COALESCE(BILLING_AMT, 0)),0)
												  FROM dbo.NEWSPAPER_DETAIL d   
												  WHERE ORDER_NBR = @order_number_in
												  AND LINE_NBR = @line_number_in
												  AND AR_INV_NBR IS NULL) < 0
					)

			SET @news_rows = @@ROWCOUNT
			
			SELECT @amount_selected_for_billing = SUM( COALESCE( BILLING_AMT, 0.00 ))
            FROM dbo.NEWSPAPER_DETAIL
            WHERE ORDER_NBR = @order_number_in
            AND LINE_NBR = @line_number_in
            AND BILLING_USER IS NOT NULL
	END
	ELSE IF @media_table = 'NEWS2' AND @bill_media_type = 1 AND @news_setup = 0
		SET @ret_val = -30
END

IF ( @ret_val = 0 )
BEGIN
	IF ( @media_table = 'OUTDOOR' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @ooh_setup = 1 )) 
	BEGIN
		UPDATE dbo.OUTDOOR_DETAIL
			   SET BILLING_USER = @billing_user
		FROM dbo.OUTDOOR_DETAIL d
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			 WHERE ORDER_NBR = @order_number_in 
			   AND LINE_NBR = @line_number_in
			   AND AR_INV_NBR IS NULL
			   AND	(
					( @date_to_use = 2 AND POST_DATE BETWEEN @m_start_date AND @m_cutoff_date )
					OR
					( @date_to_use = 1 AND DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					OR
					( @date_to_use = 3 AND COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end )
					)
			   AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
			   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
			   AND EXISTS (	 SELECT *
							   FROM dbo.OUTDOOR_HEADER A 
							  WHERE ( A.ORDER_NBR = d.ORDER_NBR )
								AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
			   AND ( @ooh_pre_post = 1 OR @ooh_pre_post IS NULL 
					OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
								  FROM dbo.V_AP_MEDIA_OOH C
								 WHERE C.ORDER_NBR = d.ORDER_NBR 
								   AND C.ORDER_LINE_NBR = d.LINE_NBR )
					OR ( LINE_CANCELLED = 1 AND @ooh_pre_post = 2 )
					OR (SELECT COALESCE(SUM(COALESCE(BILLING_AMT, 0)),0)
												  FROM dbo.OUTDOOR_DETAIL d   
												  WHERE ORDER_NBR = @order_number_in
												  AND LINE_NBR = @line_number_in
												  AND AR_INV_NBR IS NULL) < 0
					)

			SET @ooh_rows = @@ROWCOUNT

			SELECT @amount_selected_for_billing = SUM( COALESCE( BILLING_AMT, 0.00 ))
            FROM dbo.OUTDOOR_DETAIL
            WHERE ORDER_NBR = @order_number_in
            AND LINE_NBR = @line_number_in
            AND BILLING_USER IS NOT NULL
	END
	ELSE IF @media_table = 'OUTDOOR' AND @bill_media_type = 1 AND @ooh_setup = 0
		SET @ret_val = -30
END		

IF ( @ret_val = 0 )
BEGIN
	IF ( @media_table = 'INTERNET' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @inet_setup = 1 )) 
	BEGIN
		UPDATE dbo.INTERNET_DETAIL 
			   SET BILLING_USER = @billing_user
		FROM dbo.INTERNET_DETAIL d
			LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON d.JOB_NUMBER = jc.JOB_NUMBER AND d.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
			 WHERE ORDER_NBR = @order_number_in 
			   AND LINE_NBR = @line_number_in
			   AND AR_INV_NBR IS NULL
			   AND	(
					( @date_to_use = 2 AND d.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
					OR 
					( @date_to_use = 1 AND DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					OR
					( @date_to_use = 3 AND COALESCE(jc.MEDIA_BILL_DATE, d.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end )
					)
			   AND ( d.BILLING_USER IS NULL OR d.BILLING_USER = @billing_user )
			   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
			   AND EXISTS (	 SELECT *
							   FROM dbo.INTERNET_HEADER A 
							  WHERE ( A.ORDER_NBR = d.ORDER_NBR )
								AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
			   AND ( @inet_pre_post = 1 OR @inet_pre_post IS NULL 
					OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
								  FROM dbo.V_AP_MEDIA_INET C
								 WHERE C.ORDER_NBR = d.ORDER_NBR 
								   AND C.ORDER_LINE_NBR = d.LINE_NBR )
					OR ( LINE_CANCELLED = 1 AND @inet_pre_post = 2 )
					OR (SELECT COALESCE(SUM(COALESCE(BILLING_AMT, 0)), 0)
												  FROM dbo.INTERNET_DETAIL d   
												  WHERE ORDER_NBR = @order_number_in
												  AND LINE_NBR = @line_number_in
												  AND AR_INV_NBR IS NULL) < 0
					)
			
			SET @inet_rows = @@ROWCOUNT

			SELECT @amount_selected_for_billing = SUM( COALESCE( BILLING_AMT, 0.00 ))
            FROM dbo.INTERNET_DETAIL
            WHERE ORDER_NBR = @order_number_in
            AND LINE_NBR = @line_number_in
            AND BILLING_USER IS NOT NULL
	END
	ELSE IF @media_table = 'INTERNET' AND @bill_media_type = 1 AND @inet_setup = 0
		SET @ret_val = -30	
END
IF ( @ret_val = 0 )
BEGIN
	IF ( @media_table = 'RADIO2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @radio_setup = 1 )) 
	BEGIN
		UPDATE dbo.RADIO_DETAIL
		   SET BILLING_USER = @billing_user
		  FROM dbo.RADIO_DETAIL rd JOIN dbo.RADIO_HDR rh 
		    ON rh.ORDER_NBR = rd.ORDER_NBR
			   LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON rd.JOB_NUMBER = jc.JOB_NUMBER AND rd.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		 WHERE rh.ORD_PROCESS_CONTRL IN ( 1, 5 )
		   AND rd.ORDER_NBR = @order_number_in 
		   AND rd.LINE_NBR = @line_number_in
		   AND rd.AR_INV_NBR IS NULL
		   AND ( rd.BILLING_AMT <> 0.00 OR ( @incl_zero_spots_in = 1 AND rd.TOTAL_SPOTS <> 0 ))
		   -- BEGIN Date criteria
		   AND 
				(
				(@radio_daily = 1 AND @date_to_use = 1 AND ( rh.UNITS = 'DB' AND rd.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
				OR
				(@radio_daily = 1 AND @date_to_use = 2 AND ( rh.UNITS = 'DB' AND rd.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
				OR
				(@radio_monthly = 1 AND @date_to_use = 1 AND rh.UNITS IN ( 'BM', 'CM' ) AND rd.DATE_TO_BILL BETWEEN @brdcast_date1 AND @brdcast_date2)
				OR
				(@radio_monthly = 1 AND @date_to_use = 2 AND ( rh.UNITS IN ( 'BM', 'CM' ) AND ( CAST(CAST( rd.MONTH_NBR as varchar(2)) + '/01/' + CAST( rd.YEAR_NBR as varchar(4)) as smalldatetime) BETWEEN @brdcast_date1 AND @brdcast_date2)))
				OR
				(@date_to_use = 3 AND rd.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, rd.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end ) AND ( (@radio_daily = 1 AND rh.UNITS = 'DB') OR (@radio_monthly = 1 AND rh.UNITS IN ( 'BM', 'CM' ))))
				)
			-- END Date criteria
		  -- AND (
		  -- 		( rh.UNITS = 'DB' AND @date_to_use = 2 AND rd.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
		  -- 	 OR ( rh.UNITS = 'DB' AND @date_to_use = 1 AND rd.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
		  -- 	 OR ( @date_to_use <> 3 AND rh.UNITS IN ( 'BM', 'CM' ) AND ( CONVERT( smalldatetime, CONVERT( varchar(2), rd.MONTH_NBR ) + '/01/' + CONVERT( varchar(4), rd.YEAR_NBR ))
		  -- 		BETWEEN @brdcast_date1 AND @brdcast_date2 ))
			 --OR ( @date_to_use = 3 AND COALESCE(jc.MEDIA_BILL_DATE, rd.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end )
		  --     )
		   AND ( rd.BILLING_USER IS NULL OR rd.BILLING_USER = @billing_user )
		   AND ( rd.LINE_CANCELLED IS NULL OR rd.BILL_CANCELLED = 1 )
		   AND ( @radio_pre_post = 1 OR @radio_pre_post IS NULL 
				OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
							  FROM dbo.AP_RADIO C
							 WHERE C.ORDER_NBR = rh.ORDER_NBR 
							   AND C.ORDER_LINE_NBR = rd.LINE_NBR
							   AND COALESCE(C.MODIFY_DELETE, 0) = 0 )
				OR ( LINE_CANCELLED = 1 AND @radio_pre_post = 2 )
				OR (SELECT COALESCE(SUM(COALESCE(BILLING_AMT, 0)), 0)
												  FROM dbo.RADIO_DETAIL d   
												  WHERE ORDER_NBR = @order_number_in
												  AND LINE_NBR = @line_number_in
												  AND AR_INV_NBR IS NULL) < 0
				OR ( @radio_pre_post = 2 AND (COALESCE(rd.EXT_NET_AMT,0) + COALESCE(rd.NETCHARGE,0) + COALESCE(rd.NON_RESALE_AMT,0) + COALESCE(rd.DISCOUNT_AMT,0)) = 0 )
			   )

		SET @radio2_rows = @@ROWCOUNT

		SELECT @amount_selected_for_billing = SUM( COALESCE( BILLING_AMT, 0.00 ))
        FROM dbo.RADIO_DETAIL
        WHERE ORDER_NBR = @order_number_in
        AND LINE_NBR = @line_number_in
        AND BILLING_USER IS NOT NULL
	END
	ELSE IF @media_table = 'RADIO2' AND @bill_media_type = 1 AND @radio_setup = 0
		SET @ret_val = -30	
END
IF ( @ret_val = 0 )
BEGIN
	IF ( @media_table = 'TV2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @tv_setup = 1 )) 
	BEGIN
		UPDATE dbo.TV_DETAIL
		   SET BILLING_USER = @billing_user
		  FROM dbo.TV_DETAIL td JOIN dbo.TV_HDR th 
		    ON th.ORDER_NBR = td.ORDER_NBR
			   LEFT OUTER JOIN dbo.JOB_COMPONENT jc ON td.JOB_NUMBER = jc.JOB_NUMBER AND td.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
		 WHERE th.ORD_PROCESS_CONTRL IN ( 1, 5 )
		   AND td.ORDER_NBR = @order_number_in 
		   AND td.LINE_NBR = @line_number_in
		   AND td.AR_INV_NBR IS NULL
		   AND ( td.BILLING_AMT <> 0.00 OR ( @incl_zero_spots_in = 1 AND td.TOTAL_SPOTS <> 0 ))
		   -- BEGIN Date criteria
		   AND 
				(
				(@tv_daily = 1 AND @date_to_use = 1 AND ( th.UNITS = 'DB' AND td.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date ))
				OR
				(@tv_daily = 1 AND @date_to_use = 2 AND ( th.UNITS = 'DB' AND td.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date ))
				OR
				(@tv_monthly = 1 AND @date_to_use = 1 AND th.UNITS IN ( 'BM', 'CM' ) AND td.DATE_TO_BILL BETWEEN @brdcast_date1 AND @brdcast_date2)
				OR
				(@tv_monthly = 1 AND @date_to_use = 2 AND ( th.UNITS IN ( 'BM', 'CM' ) AND ( CAST(CAST( td.MONTH_NBR as varchar(2)) + '/01/' + CAST( td.YEAR_NBR as varchar(4)) as smalldatetime) BETWEEN @brdcast_date1 AND @brdcast_date2)))
				OR
				(@date_to_use = 3 AND td.ACTIVE_REV = 1 AND ( COALESCE(jc.MEDIA_BILL_DATE, td.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end ) AND ( (@tv_daily = 1 AND th.UNITS = 'DB') OR (@tv_monthly = 1 AND th.UNITS IN ( 'BM', 'CM' ))))
				)
		   -- END Date criteria
		   --AND (
		   --		( th.UNITS = 'DB' AND @date_to_use = 2 AND td.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
		   --	 OR ( th.UNITS = 'DB' AND @date_to_use = 1 AND td.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
		   --	 OR ( @date_to_use <> 3 AND th.UNITS IN ( 'BM', 'CM' ) AND ( CONVERT( smalldatetime, CONVERT( varchar(2), td.MONTH_NBR ) + '/01/' + CONVERT( varchar(4), td.YEAR_NBR ))
		   --		BETWEEN @brdcast_date1 AND @brdcast_date2 )) 
		   --  OR ( @date_to_use = 3 AND COALESCE(jc.MEDIA_BILL_DATE, td.DATE_TO_BILL) BETWEEN @job_media_date_start AND @job_media_date_end )
		   --    )
		   AND ( td.BILLING_USER IS NULL OR td.BILLING_USER = @billing_user )
		   AND ( td.LINE_CANCELLED IS NULL OR td.BILL_CANCELLED = 1 )
		   AND ( @tv_pre_post = 1 OR @tv_pre_post IS NULL 
				OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
							  FROM dbo.AP_TV C
							 WHERE C.ORDER_NBR = th.ORDER_NBR 
							   AND C.ORDER_LINE_NBR = td.LINE_NBR
							   AND COALESCE(C.MODIFY_DELETE, 0) = 0 )
				OR ( LINE_CANCELLED = 1 AND @tv_pre_post = 2 )
				OR (SELECT COALESCE(SUM(COALESCE(BILLING_AMT, 0)), 0)
												  FROM dbo.TV_DETAIL d   
												  WHERE ORDER_NBR = @order_number_in
												  AND LINE_NBR = @line_number_in
												  AND AR_INV_NBR IS NULL) < 0
				OR ( @tv_pre_post = 2 AND (COALESCE(td.EXT_NET_AMT,0) + COALESCE(td.NETCHARGE,0) + COALESCE(td.NON_RESALE_AMT,0) + COALESCE(td.DISCOUNT_AMT,0)) = 0 )
			   )

		SET @tv2_rows = @@ROWCOUNT

		SELECT @amount_selected_for_billing = SUM( COALESCE( BILLING_AMT, 0.00 ))
        FROM dbo.TV_DETAIL
        WHERE ORDER_NBR = @order_number_in
        AND LINE_NBR = @line_number_in
        AND BILLING_USER IS NOT NULL
	END
	ELSE IF @media_table = 'TV2' AND @bill_media_type = 1 AND @tv_setup = 0
		SET @ret_val = -30	
END

IF ( @ret_val = 0 )
BEGIN
	EXECUTE ( @sql_upd_billing )
	IF ( @@ERROR <> 0 )
		SET @ret_val = @@ERROR
END

IF ( @ret_val = 0 )
BEGIN
	SET @total_rows  = ( COALESCE(( COALESCE( @radio_rows, 0 ) + COALESCE( @tv_rows, 0 ) + COALESCE( @mag_rows, 0 )	+ COALESCE( @news_rows, 0 ) 
		+ COALESCE( @inet_rows, 0 ) + COALESCE( @ooh_rows, 0 ) + COALESCE( @radio2_rows, 0 ) + COALESCE( @tv2_rows, 0 )), 0 ))
	SELECT @total_rows	
	IF ( @total_rows = 0 )	
		SET @ret_val = -1
END
