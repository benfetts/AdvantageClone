
CREATE PROCEDURE [dbo].[advsp_update_billing_cmd_center] @bcc_id_in integer, @bill_user_in varchar(100), 
	@p_select_by smallint, @prod_flag bit, @sel_option smallint, @p_et_cutoff_date smalldatetime,
	@p_io_cutoff_date smalldatetime, @p_ab_cutoff_date smalldatetime, @p_ap_cutoff_ppd varchar(6), @ba_batch_id integer,
	@media_flag bit, @m_select_by smallint, @m_start_date smalldatetime, @m_cutoff_date smalldatetime, @newspaper bit, 
	@magazine bit, @radio bit, @television bit, @out_of_home bit, @internet bit, @radio_d bit, @tv_d bit, 
	@radio_m bit, @tv_m bit, @m_brdcast_mth1 smalldatetime, @m_brdcast_mth2 smalldatetime, 
	@incl_unbilled_only bit, @inc_zero_spots bit, @date_to_use smallint, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

 UPDATE dbo.BILLING_CMD_CENTER 
	SET P_SELECT_BY = @p_select_by,
		PROD_FLAG = @prod_flag,
		SEL_OPTION = @sel_option,
		P_ET_CUTOFF_DATE = @p_et_cutoff_date,
		P_IO_CUTOFF_DATE = @p_io_cutoff_date,
		P_AB_CUTOFF_DATE = @p_ab_cutoff_date,
		P_AP_CUTOFF_PPD = @p_ap_cutoff_ppd,
		BA_BATCH_ID = @ba_batch_id,
		MEDIA_FLAG = @media_flag,
		M_SELECT_BY = @m_select_by,
		M_START_DATE = @m_start_date,
		M_CUTOFF_DATE = @m_cutoff_date,
		NEWSPAPER = @newspaper,
		MAGAZINE = @magazine,
		RADIO = @radio,
		TELEVISION = @television,
		RADIO_DAILY = @radio_d,
		TV_DAILY = @tv_d,
		RADIO_MONTHLY = @radio_m,
		TV_MONTHLY = @tv_m,
		OUT_OF_HOME = @out_of_home,
		INTERNET = @internet,
		M_BRDCAST_MTH1 = @m_brdcast_mth1,
		M_BRDCAST_MTH2 = @m_brdcast_mth2,
		INCL_UNBILLED_ONLY = @incl_unbilled_only,
		INCL_ZERO_SPOTS = @inc_zero_spots,
		DATE_CUTOFF_TO_USE = @date_to_use
  WHERE BCC_ID = @bcc_id_in 

IF ( @@ROWCOUNT = 1 ) AND ( @@ERROR = 0 )
	SELECT @ret_val = 0	
ELSE
	SELECT @ret_val = -1			  	  
