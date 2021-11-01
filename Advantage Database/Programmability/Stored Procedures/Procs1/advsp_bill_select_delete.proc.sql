CREATE PROCEDURE [dbo].[advsp_bill_select_delete] 
	@billing_user varchar(100),	@ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @inv_assign smallint

SELECT @ret_val = 0

 SELECT @inv_assign = INV_ASSIGN
   FROM dbo.BILLING 
  WHERE BILLING_USER = @billing_user

IF ( @inv_assign = 1 )
	SELECT @ret_val = -3

IF ( @ret_val = 0 )
BEGIN 
	UPDATE dbo.BILLING
	   SET PRODUCTION = 0,
		   SELECT_BY = 0,
		   P_EMPTIME_DATE = NULL,
		   P_CUTOFF_PP = NULL,
		   P_INCOMEONLY_DATE = NULL,
		   P_ADVBILL_DATE = NULL,
		   AB_JOBS_ONLY = NULL
	 WHERE BILLING_USER = @billing_user
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.JOB_COMPONENT jc
						 WHERE jc.BILLING_USER = @billing_user ) 	
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.AP_PRODUCTION ap
						 WHERE ap.BILLING_USER = @billing_user ) 	
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.EMP_TIME_DTL etd
						 WHERE etd.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.INCOME_ONLY [io]
						 WHERE [io].BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.ADVANCE_BILLING ab
						 WHERE ab.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.INCOME_REC ir
						 WHERE ir.BILLING_USER = @billing_user )				

	IF ( @@ERROR <> 0 )
		SET @ret_val = @@ERROR			  	

END
	
IF ( @ret_val = 0 )
BEGIN	
	UPDATE dbo.BILLING
	   SET MEDIA = 0,
		   M_SELECT_BY = 0,
		   M_CUTOFF_DATE = NULL,
		   NEWSPAPER = 0,
		   MAGAZINE = 0,
		   RADIO = 0,
		   TELEVISION = 0,
		   OUTDOOR = 0,
		   M_CUTOFF_MONTH1 = NULL,
		   M_CUTOFF_MONTH2 = NULL,
		   INTERNET = 0,
		   M_START_DATE = NULL,
		   DATE_TO_USE = NULL
	 WHERE BILLING_USER = @billing_user
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.MAGAZINE_DETAIL d
						 WHERE d.BILLING_USER = @billing_user ) 	
	   AND NOT EXISTS ( SELECT *
						  FROM dbo.NEWSPAPER_DETAIL d
						 WHERE d.BILLING_USER = @billing_user ) 	
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.NEWS_DETAIL d
						 WHERE d.BILLING_USER = @billing_user ) 	
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.MAG_DETAIL d
						 WHERE d.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.RADIO_DETAIL1 d
						 WHERE d.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.TV_DETAIL1 d
						 WHERE d.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.OUTDOOR_DETAIL d
						 WHERE d.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.INTERNET_DETAIL d
						 WHERE d.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.TV_DETAIL d
						 WHERE d.BILLING_USER = @billing_user )
	   AND NOT EXISTS ( SELECT *
	                      FROM dbo.RADIO_DETAIL d
						 WHERE d.BILLING_USER = @billing_user ) 

	IF ( @@ERROR <> 0 )
		SET @ret_val = @@ERROR			  	

END

IF ( @ret_val = 0 )
BEGIN	
	DELETE FROM dbo.BILLING
	 WHERE BILLING_USER = @billing_user
	   AND ( PRODUCTION = 0 OR PRODUCTION IS NULL )
	   AND ( MEDIA = 0 OR MEDIA IS NULL )
END
