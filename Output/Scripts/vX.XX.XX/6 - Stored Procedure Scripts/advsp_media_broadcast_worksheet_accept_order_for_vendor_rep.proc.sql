CREATE PROCEDURE [dbo].[advsp_media_broadcast_worksheet_accept_order_for_vendor_rep]
	@order_number int,
	@order_line_number int,
	@media_type char(1),
	@revised_date datetime
AS

--DECLARE	@order_number int,
--		@order_line_number int,
--		@media_type char(1)
--		--@emp_code varchar(6)

--set @order_number = 1118
--set @order_line_number = 1
--set @media_type = 'T'

BEGIN
DECLARE @rev_nbr int,
		@revised_by varchar(100),
		@revised_by_name varchar(max),
		@max_id int
		
IF @media_type = 'T'
	SELECT @rev_nbr = REV_NBR FROM dbo.TV_DETAIL WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND ACTIVE_REV = 1
ELSE IF @media_type = 'R'
	SELECT @rev_nbr = REV_NBR FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND ACTIVE_REV = 1

SELECT @max_id = MAX(MMGR.MEDIA_MGR_GENERATED_REPORT_ID)
FROM dbo.MEDIA_MGR_GENERATED_REPORT MMGR
	--INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL MMGRD ON MMGR.MEDIA_MGR_GENERATED_REPORT_ID = MMGRD.MEDIA_MGR_GENERATED_REPORT_ID 
WHERE MMGR.ORDER_NBR = @order_number 
--AND MMGRD.LINE_NBR = @order_line_number

--SELECT @revised_by_name = [dbo].[advfn_get_emp_name] ( @emp_code, 'FML' )

IF EXISTS(SELECT 1 FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE WHERE ORDER_NBR = @order_number AND ORDER_LINE_NBR = @order_line_number)
	--IF EXISTS(SELECT 1 FROM dbo.MEDIA_MGR_GENERATED_REPORT MMGR INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL MMGRD ON MMGR.MEDIA_MGR_GENERATED_REPORT_ID = MMGRD.MEDIA_MGR_GENERATED_REPORT_ID 
	--			WHERE MMGR.ORDER_NBR = @order_number 
	--			AND MMGRD.LINE_NBR = @order_line_number) 
	BEGIN
		IF NOT EXISTS(SELECT 1
						FROM dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL
						WHERE LINE_NBR = @order_line_number 
						AND REV_NBR = @rev_nbr
						AND MEDIA_MGR_GENERATED_REPORT_ID = @max_id)
			INSERT INTO dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL (MEDIA_MGR_GENERATED_REPORT_ID, LINE_NBR, REV_NBR, IS_CANCELLED) VALUES
																(@max_id, @order_line_number, @rev_nbr, 0)
		IF @media_type = 'T'
		BEGIN
			SET ROWCOUNT 1
			SELECT @revised_by = REVISED_BY, @revised_by_name = REVISED_BY_NAME 
			FROM dbo.TV_ORDER_STATUS 
			WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND [STATUS] = 5
			ORDER BY REVISED_DATE DESC
            IF @revised_by IS NULL AND @revised_by_name IS NULL
                SELECT @revised_by = REVISED_BY, @revised_by_name = REVISED_BY_NAME 
			    FROM dbo.TV_ORDER_STATUS 
			    WHERE ORDER_NBR = @order_number AND [STATUS] = 5
			    ORDER BY REVISED_DATE DESC
			SET ROWCOUNT 0

			IF EXISTS(SELECT 1 FROM dbo.TV_ORDER_STATUS WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND REV_NBR = @rev_nbr AND [STATUS] = 5)
				UPDATE dbo.TV_ORDER_STATUS SET REVISED_DATE = @revised_date
				WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND REV_NBR = @rev_nbr AND [STATUS] = 5
			ELSE
				INSERT INTO dbo.TV_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME) VALUES
												(@order_number, @order_line_number, @rev_nbr, 5, @revised_date, @revised_by, @revised_by_name)
            
		END
		ELSE IF @media_type = 'R'
		BEGIN
			SET ROWCOUNT 1
			SELECT @revised_by = REVISED_BY, @revised_by_name = REVISED_BY_NAME 
			FROM dbo.RADIO_ORDER_STATUS 
			WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND [STATUS] = 5
			ORDER BY REVISED_DATE DESC
            IF @revised_by IS NULL AND @revised_by_name IS NULL
                SELECT @revised_by = REVISED_BY, @revised_by_name = REVISED_BY_NAME 
			    FROM dbo.RADIO_ORDER_STATUS 
			    WHERE ORDER_NBR = @order_number AND [STATUS] = 5
			    ORDER BY REVISED_DATE DESC
			SET ROWCOUNT 0

			IF EXISTS(SELECT 1 FROM dbo.RADIO_ORDER_STATUS WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND REV_NBR = @rev_nbr AND [STATUS] = 5)
				UPDATE dbo.RADIO_ORDER_STATUS SET REVISED_DATE = @revised_date
				WHERE ORDER_NBR = @order_number AND LINE_NBR = @order_line_number AND REV_NBR = @rev_nbr AND [STATUS] = 5
			ELSE
				INSERT INTO dbo.RADIO_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME) VALUES
												   (@order_number, @order_line_number, @rev_nbr, 5, @revised_date, @revised_by, @revised_by_name)
		END
        
		DELETE AA 
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE AA	
		    INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL BB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID = BB.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID
		    INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON BB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
		WHERE AB.ORDER_NBR = @order_number
        AND AB.ORDER_LINE_NBR = @order_line_number

		DELETE AA 
		FROM MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL AA	
		    INNER JOIN MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID
		WHERE AB.ORDER_NBR = @order_number
        AND AB.ORDER_LINE_NBR = @order_line_number

	END
END
GO