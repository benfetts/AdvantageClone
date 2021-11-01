
CREATE PROCEDURE [dbo].[advsp_bill_select_order] 
	@bcc_id_in integer, @newspaper bit, @magazine bit, @radio bit, @television bit, @out_of_home bit, @internet bit, 
	@m_cutoff_date smalldatetime, @bill_user_in varchar(100), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

CREATE TABLE #selection (
	CL_CODE				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	ORDER_NUMBER		integer NOT NULL,
	ORDER_DESC			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	MEDIA_TYPE			varchar(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	cc_selected			smallint NULL
)	

SELECT @ret_val = 0

IF ( @bcc_id_in IS NOT NULL )
BEGIN
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'News', 1
		   FROM dbo.NEWS_HEADER A INNER JOIN dbo.NEWS_DETAIL B
			 ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
			AND BCC_ID = @bcc_id_in

	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'News2', 1
		   FROM dbo.NEWSPAPER_HEADER A INNER JOIN dbo.NEWSPAPER_DETAIL B
		     ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
			AND BCC_ID = @bcc_id_in
			
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Mag', 1
		   FROM dbo.MAG_HEADER A INNER JOIN dbo.MAG_DETAIL B
		     ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
		    AND BCC_ID = @bcc_id_in
	
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )								
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Mag2', 1
		   FROM dbo.MAGAZINE_HEADER A INNER JOIN dbo.MAGAZINE_DETAIL B
			 ON ( A.ORDER_NBR = B.ORDER_NBR )	     
		  WHERE ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
			AND BCC_ID = @bcc_id_in	

	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, ORDER_NBR, 
				( SELECT TOP 1 rh.ORDER_DESC 
				    FROM dbo.RADIO_HEADER rh 
				   WHERE rh.ORDER_NBR = A.ORDER_NBR 
				ORDER BY rh.REV_NBR DESC ), 
				'Radio', 1
		   FROM dbo.RADIO_HEADER A 
		  WHERE BCC_ID = @bcc_id_in
		  
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, ORDER_NBR, 
				( SELECT TOP 1 th.ORDER_DESC 
				    FROM dbo.TV_HEADER th 
				   WHERE th.ORDER_NBR = A.ORDER_NBR 
				ORDER BY th.REV_NBR DESC ), 
				'TV', 1
		   FROM dbo.TV_HEADER A 
		  WHERE BCC_ID = @bcc_id_in		  

	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )								
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Outdoor', 1								
		   FROM dbo.OUTDOOR_HEADER A INNER JOIN dbo.OUTDOOR_DETAIL B
		     ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE BCC_ID = @bcc_id_in

	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )								
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Internet', 1								
		   FROM dbo.INTERNET_HEADER A INNER JOIN dbo.INTERNET_DETAIL B
		     ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE BCC_ID = @bcc_id_in
END

IF ( @newspaper = 1 )
BEGIN
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'News', 0
		   FROM dbo.NEWS_HEADER A INNER JOIN dbo.NEWS_DETAIL B
			 ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE MEDIA_TYPE IS NOT NULL 
			AND	DATE_TO_BILL <= @m_cutoff_date 
			AND	AR_INV_NBR IS NULL
			AND ORD_PROCESS_CONTRL IN ( 1, 5 )
			AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
			AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )  

	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'News2', 0
		   FROM dbo.NEWSPAPER_HEADER A INNER JOIN dbo.NEWSPAPER_DETAIL B
			 ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE MEDIA_TYPE IS NOT NULL 
			AND	DATE_TO_BILL <= @m_cutoff_date 
			AND	ORD_PROCESS_CONTRL IN ( 1, 5 ) 
			AND AR_INV_NBR IS NULL 
			AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
			AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )  
END
		
IF ( @magazine = 1 )
BEGIN
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Mag', 0
		   FROM dbo.MAG_HEADER A INNER JOIN dbo.MAG_DETAIL B
		     ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE MEDIA_TYPE IS NOT NULL 
		    AND	DATE_TO_BILL <= @m_cutoff_date
		    AND	AR_INV_NBR IS NULL
			AND ORD_PROCESS_CONTRL IN ( 1, 5 )
			AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
			AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )  
								
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )								
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Mag2', 0
		   FROM dbo.MAGAZINE_HEADER A INNER JOIN dbo.MAGAZINE_DETAIL B
			 ON ( A.ORDER_NBR = B.ORDER_NBR )	     
		  WHERE MEDIA_TYPE IS NOT NULL 
		    AND	DATE_TO_BILL <= @m_cutoff_date 
		    AND	ORD_PROCESS_CONTRL IN ( 1, 5 ) 
		    AND AR_INV_NBR IS NULL 
		    AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
			AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )  

END
	
IF ( @radio = 1 )
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, ORDER_NBR, 
				( SELECT TOP 1 rh.ORDER_DESC 
				    FROM dbo.RADIO_HEADER rh 
				   WHERE rh.ORDER_NBR = A.ORDER_NBR 
				ORDER BY rh.REV_NBR DESC ), 
				'Radio', 0
		   FROM dbo.RADIO_HEADER A 
		  WHERE MEDIA_TYPE IS NOT NULL
			AND ORD_PROCESS_CONTRL IN ( 1, 5 ) 
			AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )

IF ( @television = 1 )
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )
		 SELECT DISTINCT CL_CODE, ORDER_NBR, 
				( SELECT TOP 1 th.ORDER_DESC 
				    FROM dbo.TV_HEADER th 
				   WHERE th.ORDER_NBR = A.ORDER_NBR 
				ORDER BY th.REV_NBR DESC ), 
				'TV', 0
		   FROM dbo.TV_HEADER A 
		  WHERE MEDIA_TYPE IS NOT NULL
			AND ORD_PROCESS_CONTRL IN ( 1, 5 ) 
			AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )

IF ( @out_of_home = 1 )
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )								
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Outdoor', 0								
		   FROM dbo.OUTDOOR_HEADER A INNER JOIN dbo.OUTDOOR_DETAIL B
		     ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE MEDIA_TYPE IS NOT NULL 
		    AND	DATE_TO_BILL <= @m_cutoff_date
		    AND	ORD_PROCESS_CONTRL IN ( 1, 5 ) 
		    AND	AR_INV_NBR IS NULL 
		    AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )								
			AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )  
								
IF ( @internet = 1 )
	INSERT INTO #selection ( CL_CODE, ORDER_NUMBER, ORDER_DESC, MEDIA_TYPE, cc_selected )								
		 SELECT DISTINCT CL_CODE, A.ORDER_NBR, ORDER_DESC, 'Internet', 1								
		   FROM dbo.INTERNET_HEADER A INNER JOIN dbo.INTERNET_DETAIL B
		     ON ( A.ORDER_NBR = B.ORDER_NBR )
		  WHERE MEDIA_TYPE IS NOT NULL 
		    AND DATE_TO_BILL <= @m_cutoff_date
		    AND	ORD_PROCESS_CONTRL IN ( 1, 5 ) 
		    AND AR_INV_NBR IS NULL 
		    AND ( BILLING_USER IS NULL OR BILLING_USER = @bill_user_in )
		    AND BCC_ID IS NULL
			AND NOT EXISTS ( SELECT * 
							   FROM #selection 
							  WHERE #selection.ORDER_NUMBER = A.ORDER_NUMBER
								AND #selection.cc_selected = 1 )  
		  

/*****************************************************************************************/
  SELECT s.CL_CODE, s.ORDER_NUMBER, s.ORDER_DESC, s.MEDIA_TYPE, s.cc_selected
	FROM #selection s
ORDER BY s.MEDIA_TYPE ASC, s.ORDER_NUMBER DESC 

DROP TABLE #selection
