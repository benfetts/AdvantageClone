
CREATE PROCEDURE [dbo].[advsp_update_bill_select]
	@bill_user_in varchar(100),
	@inv_date_in varchar(10),
	@post_period_in varchar(8),
	@production_flag bit,
	@p_select_by_in smallint,
	@ap_post_period_in varchar(8),
	@emp_date_in varchar(10),
	@io_date_in varchar(10),
	@ab_date_in varchar(10),
	@media_flag bit,
	@m_select_by_in smallint,
	@m_cutoff_date_in varchar(10),
	@m_cutoff_mnth1_in varchar(10),
	@m_cutoff_mnth2_in varchar(10),
	@newspaper_flag bit,
	@magazine_flag bit,
	@radio_flag bit,
	@television_flag bit,
	@outdoor_flag bit,
	@internet_flag bit,
	@service_fees_flag bit,
	@inc_no_dtl bit,
	@ab_jobs_only bit,
	@ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @billing_exists BIT

SELECT @billing_exists = ( SELECT COUNT(*) FROM dbo.BILLING WHERE BILLING_USER = @bill_user_in )

IF ( @billing_exists = 1 ) 
	 UPDATE dbo.BILLING 
		SET INV_DATE = CAST( @inv_date_in AS SMALLDATETIME ), 
			POST_PERIOD = @post_period_in,
			PRODUCTION = @production_flag, 
			MEDIA = @media_flag,
			SERVICE_FEES = @service_fees_flag, 
			SELECT_BY = @p_select_by_in,
			SELECTION = 1, 
			P_EMPTIME_DATE = CAST( @emp_date_in AS smalldatetime ),
			P_INCOMEONLY_DATE = CAST( @io_date_in AS smalldatetime ), 
			P_ADVBILL_DATE = CAST( @ab_date_in AS smalldatetime ),
			P_CUTOFF_PP = @ap_post_period_in,
			INC_NO_DTL = @inc_no_dtl,
			AB_JOBS_ONLY = @ab_jobs_only
	  WHERE BILLING_USER = @bill_user_in 
ELSE
	INSERT INTO dbo.BILLING 
		( INV_DATE, POST_PERIOD, PRODUCTION, MEDIA, SERVICE_FEES, SELECT_BY, SELECTION,
		  P_EMPTIME_DATE, P_INCOMEONLY_DATE, P_ADVBILL_DATE, P_CUTOFF_PP, BILLING_USER, 
		  M_SELECT_BY, M_CUTOFF_DATE, M_CUTOFF_MONTH1, M_CUTOFF_MONTH2, NEWSPAPER, MAGAZINE, RADIO, 
	 	  TELEVISION, OUTDOOR, INTERNET, INC_NO_DTL, AB_JOBS_ONLY )
		 VALUES ( 
		  CAST( @inv_date_in AS SMALLDATETIME ), @post_period_in, @production_flag, @media_flag, 
		  @service_fees_flag, @p_select_by_in, 1, CAST( @emp_date_in AS SMALLDATETIME ), 
		  CAST( @io_date_in AS SMALLDATETIME ), CAST( @ab_date_in AS SMALLDATETIME ), 
		  @ap_post_period_in, @bill_user_in, @m_select_by_in, CAST( @m_cutoff_date_in AS SMALLDATETIME ), 
		  CAST( @m_cutoff_mnth1_in AS SMALLDATETIME ), CAST( @m_cutoff_mnth2_in AS SMALLDATETIME ), 
		  @newspaper_flag, @magazine_flag, @radio_flag, @television_flag, @outdoor_flag, @internet_flag,
		  @inc_no_dtl, @ab_jobs_only )	  
