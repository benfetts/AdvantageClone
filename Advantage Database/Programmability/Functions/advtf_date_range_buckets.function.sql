CREATE FUNCTION [dbo].[advtf_date_range_buckets] 
(
	@Dates			[dbo].[MEDIA_BROADCAST_WORKSHEETMARKET_DATE_TYPE] READONLY
	,@BucketSlots	INT = 14
	,@BucketRez		INT = 1
)
RETURNS 
@BucketPeriods TABLE 
(
	WorksheetmarketID		INT
	,BucketBeginDate		DATE
	,BucketEndDate			DATE
	,BucketNumber			INT
	,BucketRow				INT
	,BucketSlot				INT
	,BucketLastRow			BIT
)
AS
BEGIN

	DECLARE @BucketDates	TABLE	(WorksheetMarketID INT ,RptDate DATE, BucketBeginDate DATE, BucketEndDate DATE)
	
	INSERT INTO @BucketDates (WorksheetMarketID, RptDate, BucketBeginDate, BucketEndDate)
	SELECT
		 Buckets.WORKSHEETMARKETID
		,Buckets.RPTDATE
		,Buckets.BucketBeginDate
		,Buckets.BucketEndDate
	FROM (
		SELECT
			RD.WORKSHEETMARKETID
			,RD.RPTDATE
			,CASE WHEN (@BucketRez = 7) THEN MC.BROADCAST_WEEKDATE  ELSE RD.RPTDATE END BucketBeginDate
			,CASE WHEN (@BucketRez = 7) THEN DATEADD(day,6,MC.BROADCAST_WEEKDATE) ELSE RD.RPTDATE END BucketEndDate
		FROM @Dates RD
			INNER JOIN MEDIA_CALENDAR MC
				ON RD.RPTDATE = MC.DATE) Buckets

	INSERT INTO @BucketPeriods
	SELECT DISTINCT
		BD.WorksheetMarketID
		,BD.BucketBeginDate
		,BD.BucketEndDate
		,BDX.BucketNumber
		,CASE 
			WHEN ((BDX.BucketNumber % @BucketSlots) = 0) THEN (BDX.BucketNumber / @BucketSlots) -1
			ELSE (BDX.BucketNumber / @BucketSlots)
		 END BucketRow
		,(BDX.BucketNumber % @BucketSlots) BucketSlot
		,0
	FROM 
		@BucketDates BD
		INNER JOIN (
			SELECT
				ROW_NUMBER() OVER(ORDER BY BDZ.BucketBeginDate ASC) AS BucketNumber
				,BDZ.BucketBeginDate
			FROM
				@BucketDates BDZ
			GROUP BY 
				BDZ.BucketBeginDate) BDX
		ON BD.BucketBeginDate = BDX.BucketBeginDate

	UPDATE @BucketPeriods
		SET
			BucketLastRow = 1
	FROM
		@BucketPeriods BP
	WHERE
		BP.BucketRow = (SELECT MAX(BPX.BucketRow) FROM @BucketPeriods BPX)

	RETURN 
END
GO


