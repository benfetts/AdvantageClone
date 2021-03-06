CREATE PROCEDURE [dbo].[advsp_makegood_staging_reject_makegoods]
	@USER_CODE varchar(100),
	@MEDIA_TYPE char(1),
	@MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID varchar(max)
AS

DECLARE @REJECT TABLE (
	MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID int NOT NULL,
	MAKEGOOD_DATE date NOT NULL
)

DECLARE @UPDATE TABLE (
	ORDER_NBR INT NOT NULL,
	ORDER_LINE_NBR INT NOT NULL,
	REV_NBR INT NOT NULL
)

INSERT @REJECT 
SELECT MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID, MAKEGOOD_DATE
FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL
WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID IN (SELECT * FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID, ','))

BEGIN TRY

	BEGIN TRAN
	
		UPDATE s SET s.WORKSHEET_ACTION_TAKEN = 3, WORKSHEET_ACTION_USER = @USER_CODE, WORKSHEET_ACTION_DATE = getdate()
		FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL s
		WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID IN (SELECT * FROM dbo.udf_split_list(@MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID, ','))

		IF @MEDIA_TYPE = 'T' BEGIN
			INSERT @UPDATE
			SELECT d.ORDER_NBR, d.ORDER_LINE_NBR, od.REV_NBR 
			FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE d
				INNER JOIN @REJECT r ON d.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = r.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
									AND d.[DATE] = r.MAKEGOOD_DATE 
				INNER JOIN dbo.TV_DETAIL od ON d.ORDER_NBR = od.ORDER_NBR AND d.ORDER_LINE_NBR = od.LINE_NBR AND od.ACTIVE_REV = 1

			UPDATE os SET REVISED_DATE = getdate(), REVISED_BY = @USER_CODE, REVISED_BY_NAME = [dbo].[advfn_get_user_name](@USER_CODE)
			FROM dbo.TV_ORDER_STATUS os 
				INNER JOIN @UPDATE u ON os.ORDER_NBR = u.ORDER_NBR AND os.LINE_NBR = u.ORDER_LINE_NBR AND os.REV_NBR = u.REV_NBR AND os.[STATUS] = 17
			
			INSERT dbo.TV_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME)
			SELECT u.ORDER_NBR, u.ORDER_LINE_NBR, u.REV_NBR, 17, getdate(), @USER_CODE, [dbo].[advfn_get_user_name](@USER_CODE)
			FROM @UPDATE u 
				LEFT OUTER JOIN dbo.TV_ORDER_STATUS os ON os.ORDER_NBR = u.ORDER_NBR AND os.LINE_NBR = u.ORDER_LINE_NBR AND os.REV_NBR = u.REV_NBR AND os.[STATUS] = 17
			WHERE os.ORDER_NBR IS NULL
		END ELSE IF @MEDIA_TYPE = 'R' BEGIN
			INSERT @UPDATE
			SELECT d.ORDER_NBR, d.ORDER_LINE_NBR, od.REV_NBR 
			FROM dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE d
				INNER JOIN @REJECT r ON d.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = r.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID 
									AND d.[DATE] = r.MAKEGOOD_DATE 
				INNER JOIN dbo.RADIO_DETAIL od ON d.ORDER_NBR = od.ORDER_NBR AND d.ORDER_LINE_NBR = od.LINE_NBR AND od.ACTIVE_REV = 1

			UPDATE os SET REVISED_DATE = getdate(), REVISED_BY = @USER_CODE, REVISED_BY_NAME = [dbo].[advfn_get_user_name](@USER_CODE)
			FROM dbo.RADIO_ORDER_STATUS os 
				INNER JOIN @UPDATE u ON os.ORDER_NBR = u.ORDER_NBR AND os.LINE_NBR = u.ORDER_LINE_NBR AND os.REV_NBR = u.REV_NBR AND os.[STATUS] = 17
			
			INSERT dbo.RADIO_ORDER_STATUS (ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE, REVISED_BY, REVISED_BY_NAME)
			SELECT u.ORDER_NBR, u.ORDER_LINE_NBR, u.REV_NBR, 17, getdate(), @USER_CODE, [dbo].[advfn_get_user_name](@USER_CODE)
			FROM @UPDATE u 
				LEFT OUTER JOIN dbo.RADIO_ORDER_STATUS os ON os.ORDER_NBR = u.ORDER_NBR AND os.LINE_NBR = u.ORDER_LINE_NBR AND os.REV_NBR = u.REV_NBR AND os.[STATUS] = 17
			WHERE os.ORDER_NBR IS NULL
		END
		
		--SELECT a.ORDER_NBR, b.LINE_NBR, b.REV_NBR 
		--FROM dbo.MEDIA_MGR_GENERATED_REPORT a
		--	INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
		--WHERE a.MEDIA_MGR_GENERATED_REPORT_ID = (SELECT MAX(MEDIA_MGR_GENERATED_REPORT_ID) FROM dbo.MEDIA_MGR_GENERATED_REPORT WHERE ORDER_NBR = 740)
	COMMIT TRAN

END TRY
BEGIN CATCH
	
	ROLLBACK TRAN
		
	SELECT 
    --ERROR_NUMBER() as ErrorNumber,
    ERROR_MESSAGE() as ErrorMessage;
        
END CATCH

GO
