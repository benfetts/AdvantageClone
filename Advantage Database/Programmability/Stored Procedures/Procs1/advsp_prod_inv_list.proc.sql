
CREATE PROCEDURE [dbo].[advsp_prod_inv_list] 
	@from_assign bit, @ar_inv_date varchar(10), @inv_nbr_filter varchar(20), 
	@office_where varchar(4000), @client_where varchar(4000), @bill_user varchar(100)
AS

SET NOCOUNT ON

DECLARE @orig_sql varchar(4000)

SELECT @orig_sql = 'SELECT DISTINCT ACCT_REC.AR_INV_NBR, ACCT_REC.CL_CODE, ACCT_REC.AR_INV_DATE '
				 + '  FROM dbo.ACCT_REC '
				 + ' WHERE ACCT_REC.REC_TYPE = ''P'' '
				 + '   AND ( ACCT_REC.MANUAL_INV IS NULL OR ACCT_REC.MANUAL_INV = 0 ) '
				 + '   AND ( ACCT_REC.AR_INV_SEQ <> 99 ) '

IF @from_assign = 1
	SELECT @orig_sql = @orig_sql 
		+ '      AND ACCT_REC.AR_INV_NBR BETWEEN ' 
		+ '				 ( SELECT FIRST_INV FROM dbo.BILLING WHERE INV_ASSIGN = 1 AND PRODUCTION = 1 AND BILLING_USER = ''' + @bill_user + ''' ) ' 
		+ '     	 AND ( SELECT LAST_INV FROM BILLING WHERE INV_ASSIGN = 1 AND PRODUCTION = 1 AND BILLING_USER = ''' + @bill_user + ''' ) ' 
		+ ' GROUP BY ACCT_REC.AR_INV_NBR, ACCT_REC.CL_CODE, ACCT_REC.OFFICE_CODE, ACCT_REC.AR_INV_DATE '
		+ '   HAVING MAX ( ACCT_REC.AR_TYPE ) <> ''VO'' ORDER BY 1 DESC '

ELSE
BEGIN
	IF ( @ar_inv_date IS NULL ) OR ( LTRIM( RTRIM( @ar_inv_date )) = '' )
	BEGIN
		IF ( @inv_nbr_filter IS NULL ) OR ( LTRIM( RTRIM( @inv_nbr_filter )) = '' )
			SELECT @orig_sql = @orig_sql + @client_where + @office_where 
				+ ' GROUP BY ACCT_REC.AR_INV_NBR, ACCT_REC.CL_CODE, ACCT_REC.OFFICE_CODE, ACCT_REC.AR_INV_DATE '
				+ '   HAVING MAX ( ACCT_REC.AR_TYPE ) <> ''VO'' ORDER BY 1 DESC '
		ELSE
			SELECT @orig_sql = @orig_sql + @client_where + @office_where 
				+ '		 AND ACCT_REC.AR_INV_NBR = ' + @inv_nbr_filter 
				+ ' GROUP BY ACCT_REC.AR_INV_NBR, ACCT_REC.CL_CODE, ACCT_REC.OFFICE_CODE, ACCT_REC.AR_INV_DATE ' 
				+ '   HAVING MAX ( ACCT_REC.AR_TYPE ) <> ''VO'' ORDER BY 1 DESC '
	END
	ELSE
	BEGIN
		IF ( @inv_nbr_filter IS NULL ) OR ( LTRIM( RTRIM( @inv_nbr_filter )) = '' )
			SELECT @orig_sql = @orig_sql + @client_where + @office_where 
				+ ' GROUP BY ACCT_REC.AR_INV_NBR, ACCT_REC.CL_CODE, ACCT_REC.OFFICE_CODE, ACCT_REC.AR_INV_DATE '
				+ '   HAVING ACCT_REC.AR_INV_DATE = ''' + @ar_inv_date + ''' '
				+ '      AND MAX ( ACCT_REC.AR_TYPE ) <> ''VO'' ORDER BY 1 DESC '		
		ELSE
			SELECT @orig_sql = @orig_sql + @client_where + @office_where 
				+ '		 AND ACCT_REC.AR_INV_NBR = ' + @inv_nbr_filter 
				+ ' GROUP BY ACCT_REC.AR_INV_NBR, ACCT_REC.CL_CODE, ACCT_REC.OFFICE_CODE, ACCT_REC.AR_INV_DATE ' 
				+ '   HAVING ACCT_REC.AR_INV_DATE = ''' + @ar_inv_date + ''' '
				+ '      AND MAX ( ACCT_REC.AR_TYPE ) <> ''VO'' ORDER BY 1 DESC '
	END
END

EXECUTE ( @orig_sql )
