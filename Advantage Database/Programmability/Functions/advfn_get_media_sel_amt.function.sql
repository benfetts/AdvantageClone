CREATE FUNCTION [dbo].[advfn_get_media_sel_amt] ( @order_number integer, @line_number smallint )
RETURNS decimal(18,2)
AS
BEGIN
	DECLARE @amt decimal(15,2)

	SET @amt = 0

	SELECT @amt = @amt + COALESCE(SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00)
                            FROM MAGAZINE_DETAIL d
                          WHERE d.ORDER_NBR = @order_number 
                            AND d.LINE_NBR = @line_number 
                            AND d.BILLING_USER IS NOT NULL
	   
	SELECT @amt = @amt + COALESCE(SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00)
                            FROM NEWSPAPER_DETAIL d
                           WHERE d.ORDER_NBR = @order_number 
                             AND d.LINE_NBR = @line_number 
                             AND d.BILLING_USER IS NOT NULL
	   
	SELECT @amt = @amt + COALESCE(SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00)
                            FROM INTERNET_DETAIL d
                           WHERE d.ORDER_NBR = @order_number 
                             AND d.LINE_NBR = @line_number 
                             AND d.BILLING_USER IS NOT NULL

	SELECT @amt = @amt + COALESCE(SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00)
                            FROM RADIO_DETAIL d
                           WHERE d.ORDER_NBR = @order_number 
                             AND d.LINE_NBR = @line_number 
                             AND d.BILLING_USER IS NOT NULL

	SELECT @amt = @amt + COALESCE(SUM( COALESCE( d.BILLING_AMT, 0.00 )), 0.00)
                            FROM TV_DETAIL d
                           WHERE d.ORDER_NBR = @order_number 
                             AND d.LINE_NBR = @line_number 
                             AND d.BILLING_USER IS NOT NULL

	SELECT @amt = @amt + COALESCE(COALESCE( SUM( d.BILLING_AMT ), 0.00 ), 0.00)
						 FROM dbo.OUTDOOR_DETAIL d   
						WHERE d.ORDER_NBR = @order_number 
						  AND d.LINE_NBR = @line_number 
						  AND d.BILLING_USER IS NOT NULL

	SELECT @amt = @amt + COALESCE(SUM( td.LINE_TOTAL), 0.00 )
 						FROM dbo.V_TV_DETAIL1 vtd
					INNER JOIN dbo.TV_DETAIL1 td 
							ON vtd.ORDER_NBR = td.ORDER_NBR 
						AND vtd.LINE_NBR = td.LINE_NBR 
						AND vtd.REV_NBR = td.REV_NBR		
						AND vtd.SEQ_NBR = td.SEQ_NBR
						AND vtd.BRDCAST_YEAR = td.BRDCAST_YEAR
					INNER JOIN dbo.TV_HEADER th ON ( vtd.ORDER_NBR = th.ORDER_NBR ) AND ( vtd.REV_NBR = th.REV_NBR )
						WHERE vtd.ORDER_NBR = @order_number
						AND vtd.LINE_NBR = @line_number
						AND vtd.BILLING_USER IS NOT NULL

	SELECT @amt = @amt + COALESCE(SUM( rd.LINE_TOTAL), 0.00 )
						FROM dbo.V_RADIO_DETAIL1 vrd
					 INNER JOIN dbo.RADIO_DETAIL1 rd 
							 ON vrd.ORDER_NBR = rd.ORDER_NBR 
							AND vrd.LINE_NBR = rd.LINE_NBR
							AND vrd.REV_NBR = rd.REV_NBR
							AND vrd.SEQ_NBR = rd.SEQ_NBR
							AND vrd.BRDCAST_YEAR = rd.BRDCAST_YEAR
					 INNER JOIN dbo.RADIO_HEADER rh ON ( vrd.ORDER_NBR = rh.ORDER_NBR ) AND ( vrd.REV_NBR = rh.REV_NBR )
					 WHERE vrd.ORDER_NBR = @order_number
						AND vrd.LINE_NBR = @line_number
						AND vrd.BILLING_USER IS NOT NULL

RETURN ( @amt )
END

GO

