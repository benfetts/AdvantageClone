IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advsp_bill_select_all_media]' ) AND OBJECTPROPERTY( id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE [dbo].[advsp_bill_select_all_media]
GO

CREATE PROCEDURE [dbo].[advsp_bill_select_all_media] 
	@billing_user varchar(100),	@inv_date_in smalldatetime, @post_period_in varchar(6), @radio_in smallint, 
	@television_in smallint, @magazine_in smallint,	@internet_in smallint, @out_of_home_in smallint, 
	@newspaper_in smallint, @m_start_date_in smalldatetime, @m_cutoff_date_in smalldatetime,
	@date_to_use_in smallint, @brdcast_date1_in smalldatetime, @brdcast_date2_in smalldatetime, 
	@incl_zero_spots_in bit, @ret_val integer OUTPUT 
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
DECLARE @m_start_date smalldatetime, @bcc_id integer, @order_number integer, @line_number integer

SET @ret_val = 0
SET @radio2_rows = 0
SET @tv2_rows = 0
SET @radio_rows = 0 
SET @tv_rows = 0 
SET @mag_rows = 0 
SET @news_rows = 0 
SET @inet_rows = 0 
SET @ooh_rows = 0 
SET @sql_upd_billing = ''

SELECT @bcc_id = BCC_ID FROM dbo.BILLING_CMD_CENTER WHERE ( BILLING_USER = @billing_user )

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
			C.NEWS_SETUP_COMPLETE, C.MAG_SETUP_COMPLETE, B.BILL_MEDIA_TYPE, D.ORDER_NBR, D.LINE_NBR,
			A.ORD_PROCESS_CONTRL, UPPER( A.MEDIA_FROM )
	   FROM dbo.V_MEDIA_HDR A 
  INNER JOIN dbo.AGENCY B 
		  ON ( 1 = 1 )
  INNER JOIN dbo.PRODUCT C 
		  ON ( A.CL_CODE = C.CL_CODE ) AND ( A.DIV_CODE = C.DIV_CODE ) AND ( A.PRD_CODE = C.PRD_CODE )
  INNER JOIN dbo.BCC_ORDER_LINE D 
		  ON ( A.ORDER_NBR = D.ORDER_NBR ) AND ( D.BCC_ID = @bcc_id )
	FOR READ ONLY
	 
	OPEN product_cursor 
	FETCH NEXT FROM product_cursor INTO @cl_code, @div_code, @prd_code, @radio_pre_post, @tv_pre_post,
		@ooh_pre_post, @inet_pre_post, @news_pre_post, @mag_pre_post, @radio_setup, @tv_setup, 
		@ooh_setup, @inet_setup, @news_setup, @mag_setup, @bill_media_type, @order_number, @line_number,
		@order_process_contrl, @media_table

	WHILE ( @@FETCH_STATUS = 0 )
	BEGIN
		IF ( @order_process_contrl IS NULL OR ( @order_process_contrl NOT IN ( 1, 5 )))
			CONTINUE
		IF ( @media_table = 'MAG' OR @media_table = 'NEWS' )
			CONTINUE

		IF ( @ret_val = 0 )
		BEGIN
			IF ( @media_table = 'MAG2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @mag_setup = 1 )) 
			BEGIN
				IF ( @date_to_use = 2 )
				BEGIN
					UPDATE dbo.MAGAZINE_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number 
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
					   AND ( [START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.MAGAZINE_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.MAGAZINE_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @mag_pre_post = 1 OR @mag_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_MAG C
										 WHERE C.ORDER_NBR = dbo.MAGAZINE_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.MAGAZINE_DETAIL.LINE_NBR ))

					SET @mag_rows = @mag_rows + @@ROWCOUNT
				END
				ELSE
				BEGIN
					UPDATE dbo.MAGAZINE_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number 
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
   					   AND ( DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.MAGAZINE_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.MAGAZINE_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @mag_pre_post = 1 OR @mag_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_MAG C
										 WHERE C.ORDER_NBR = dbo.MAGAZINE_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.MAGAZINE_DETAIL.LINE_NBR ))
					
					SET @mag_rows = @mag_rows + @@ROWCOUNT
				END	
						
				IF ( @@ERROR <> 0 )
					SET @ret_val = -15
			END
		END	

		IF ( @ret_val = 0 )
		BEGIN
			IF ( @media_table = 'NEWS2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @news_setup = 1 )) 
			BEGIN
				IF ( @date_to_use = 2 )
				BEGIN
					UPDATE dbo.NEWSPAPER_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number 
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
					   AND ( [START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.NEWSPAPER_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.NEWSPAPER_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @news_pre_post = 1 OR @news_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_NEWS C
										 WHERE C.ORDER_NBR = dbo.NEWSPAPER_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.NEWSPAPER_DETAIL.LINE_NBR ))

					SET @news_rows = @news_rows + @@ROWCOUNT
				END
				ELSE
				BEGIN
					UPDATE dbo.NEWSPAPER_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
					   AND ( DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.NEWSPAPER_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.NEWSPAPER_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @news_pre_post = 1 OR @news_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_NEWS C
										 WHERE C.ORDER_NBR = dbo.NEWSPAPER_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.NEWSPAPER_DETAIL.LINE_NBR ))

					SET @news_rows = @news_rows + @@ROWCOUNT							   
				END	

				IF ( @@ERROR <> 0 )
					SET @ret_val = -16
			END
		END

		IF ( @ret_val = 0 )
		BEGIN
			IF ( @media_table = 'OUTDOOR' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @ooh_setup = 1 )) 
			BEGIN
				IF ( @date_to_use = 2 )
				BEGIN
					UPDATE dbo.OUTDOOR_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number 
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
					   AND ( POST_DATE BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.OUTDOOR_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.OUTDOOR_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @ooh_pre_post = 1 OR @ooh_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_OOH C
										 WHERE C.ORDER_NBR = dbo.OUTDOOR_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.OUTDOOR_DETAIL.LINE_NBR ))

					SET @ooh_rows = @ooh_rows + @@ROWCOUNT
				END
				ELSE
				BEGIN
					UPDATE dbo.OUTDOOR_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number 
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
					   AND ( DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.OUTDOOR_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.OUTDOOR_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @ooh_pre_post = 1 OR @ooh_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_OOH C
										 WHERE C.ORDER_NBR = dbo.OUTDOOR_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.OUTDOOR_DETAIL.LINE_NBR ))

					SET @ooh_rows = @ooh_rows + @@ROWCOUNT
				END			

				IF ( @@ERROR <> 0 )
					SET @ret_val = -17					
			END
		END		

		IF ( @ret_val = 0 )
		BEGIN
			IF ( @media_table = 'INTERNET' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @inet_setup = 1 )) 
			BEGIN
				IF ( @date_to_use = 2 )
				BEGIN
					UPDATE dbo.INTERNET_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number 
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
					   AND ( [START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.INTERNET_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.INTERNET_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @inet_pre_post = 1 OR @inet_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_INET C
										 WHERE C.ORDER_NBR = dbo.INTERNET_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.INTERNET_DETAIL.LINE_NBR ))

					SET @inet_rows = @inet_rows + @@ROWCOUNT
				END	
				ELSE
				BEGIN
					UPDATE dbo.INTERNET_DETAIL
					   SET BILLING_USER = @billing_user
					 WHERE ORDER_NBR = @order_number 
					   AND LINE_NBR = @line_number
					   AND AR_INV_NBR IS NULL
					   AND ( DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
					   AND ( BILLING_USER IS NULL OR BILLING_USER = @billing_user )
					   AND ( LINE_CANCELLED IS NULL OR BILL_CANCELLED = 1 )
					   AND EXISTS (	 SELECT *
									   FROM dbo.INTERNET_HEADER A 
									  WHERE ( A.ORDER_NBR = dbo.INTERNET_DETAIL.ORDER_NBR )
										AND ( A.ORD_PROCESS_CONTRL IN ( 1, 5 )) ) 
					   AND ( @inet_pre_post = 1 OR @inet_pre_post IS NULL 
							OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
										  FROM dbo.V_AP_MEDIA_INET C
										 WHERE C.ORDER_NBR = dbo.INTERNET_DETAIL.ORDER_NBR 
										   AND C.ORDER_LINE_NBR = dbo.INTERNET_DETAIL.LINE_NBR ))

					SET @inet_rows = @inet_rows + @@ROWCOUNT
				END
							
				IF ( @@ERROR <> 0 )
					SET @ret_val = -18
			END
		
			IF ( @media_table = 'RADIO2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @radio_setup = 1 )) 
			BEGIN
				UPDATE dbo.RADIO_DETAIL
				   SET BILLING_USER = @billing_user
				  FROM dbo.RADIO_DETAIL rd JOIN dbo.RADIO_HDR rh 
					ON rh.ORDER_NBR = rd.ORDER_NBR
				 WHERE rh.ORD_PROCESS_CONTRL IN ( 1, 5 )
				   AND rd.ORDER_NBR = @order_number 
				   AND rd.LINE_NBR = @line_number
				   AND rd.AR_INV_NBR IS NULL
				   AND ( rd.BILLING_AMT <> 0.00 OR ( @incl_zero_spots_in = 1 AND rd.TOTAL_SPOTS <> 0 ))
				   AND (
		   				( rh.UNITS = 'DB' AND @date_to_use = 2 AND rd.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
		   			 OR ( rh.UNITS = 'DB' AND @date_to_use = 1 AND rd.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
		   			 OR ( rh.UNITS IN ( 'BM', 'CM' ) AND ( CONVERT( smalldatetime, CONVERT( varchar(2), rd.MONTH_NBR ) + '/01/' + CONVERT( varchar(4), rd.YEAR_NBR ))
		   				BETWEEN @brdcast_date1 AND @brdcast_date2 )) 
					   )
				   AND ( rd.BILLING_USER IS NULL OR rd.BILLING_USER = @billing_user )
				   AND ( rd.LINE_CANCELLED IS NULL OR rd.BILL_CANCELLED = 1 )
				   AND ( @radio_pre_post = 1 OR @radio_pre_post IS NULL 
						OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
									  FROM dbo.AP_RADIO C
									 WHERE C.ORDER_NBR = rh.ORDER_NBR 
									   AND C.ORDER_LINE_NBR = rd.LINE_NBR ))

				SET @radio2_rows = @radio2_rows + @@ROWCOUNT
							
				IF ( @@ERROR <> 0 )
					SET @ret_val = -19
			END

			IF ( @media_table = 'TV2' AND ( @bill_media_type IS NULL OR @bill_media_type = 0 OR @tv_setup = 1 )) 
			BEGIN
				UPDATE dbo.TV_DETAIL
				   SET BILLING_USER = @billing_user
				  FROM dbo.TV_DETAIL td JOIN dbo.TV_HDR th 
					ON th.ORDER_NBR = td.ORDER_NBR
				 WHERE th.ORD_PROCESS_CONTRL IN ( 1, 5 )
				   AND td.ORDER_NBR = @order_number 
				   AND td.LINE_NBR = @line_number
				   AND td.AR_INV_NBR IS NULL
				   AND ( td.BILLING_AMT <> 0.00 OR ( @incl_zero_spots_in = 1 AND td.TOTAL_SPOTS <> 0 ))
				   AND (
		   				( th.UNITS = 'DB' AND @date_to_use = 2 AND td.[START_DATE] BETWEEN @m_start_date AND @m_cutoff_date )
		   			 OR ( th.UNITS = 'DB' AND @date_to_use = 1 AND td.DATE_TO_BILL BETWEEN @m_start_date AND @m_cutoff_date )
		   			 OR ( th.UNITS IN ( 'BM', 'CM' ) AND ( CONVERT( smalldatetime, CONVERT( varchar(2), td.MONTH_NBR ) + '/01/' + CONVERT( varchar(4), td.YEAR_NBR ))
		   				BETWEEN @brdcast_date1 AND @brdcast_date2 )) 
					   )
				   AND ( td.BILLING_USER IS NULL OR td.BILLING_USER = @billing_user )
				   AND ( td.LINE_CANCELLED IS NULL OR td.BILL_CANCELLED = 1 )
				   AND ( @tv_pre_post = 1 OR @tv_pre_post IS NULL 
						OR EXISTS ( SELECT DISTINCT TOP 1 AP_ID 
									  FROM dbo.AP_TV C
									 WHERE C.ORDER_NBR = th.ORDER_NBR 
									   AND C.ORDER_LINE_NBR = td.LINE_NBR ))

				SET @tv2_rows = @tv2_rows + @@ROWCOUNT
							
				IF ( @@ERROR <> 0 )
					SET @ret_val = -20
			END
		END
		
		FETCH NEXT FROM product_cursor INTO @cl_code, @div_code, @prd_code, @radio_pre_post, @tv_pre_post,
			@ooh_pre_post, @inet_pre_post, @news_pre_post, @mag_pre_post, @radio_setup, @tv_setup, 
			@ooh_setup, @inet_setup, @news_setup, @mag_setup, @bill_media_type, @order_number, @line_number,
			@order_process_contrl, @media_table

	END
	
--	SET @ret_val = -6

	CLOSE product_cursor
	DEALLOCATE product_cursor

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
GO

GRANT EXECUTE ON [advsp_bill_select_all_media] TO PUBLIC AS dbo
GO
