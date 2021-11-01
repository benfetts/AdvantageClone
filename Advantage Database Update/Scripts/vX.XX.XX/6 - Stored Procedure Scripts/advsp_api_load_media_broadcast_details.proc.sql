IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_api_load_media_broadcast_details]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_api_load_media_broadcast_details]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_api_load_media_broadcast_details] 
		@media_type varchar(1) = 'A'
AS

/* API - LoadMediaBroadcastDetails */

IF @media_type IS NULL OR @media_type = '*' BEGIN

	SET @media_type = 'A'

END

IF @media_type = 'A' BEGIN

	SELECT 
		[ID] = NEWID(),
		[MediaType]='T',
		[OrderNumber]=ORDER_NBR, 
		[LineNumber]=ORDER_LINE_NBR, 
		[RunDate]=RUN_DATE, --CONVERT(varchar, RUN_DATE, 110), 
		[DayOfWeek]=DAY_OF_WEEK, 
		[TimeOfDay]=CONVERT(varchar, TIME_OF_DAY, 14), 
		[Length]=[LENGTH],
		[RUN_DATE]
	FROM AP_TV_BROADCAST_DTL A JOIN
		(SELECT AP_ID, MAX(AP_SEQ) AP_SEQ FROM AP_HEADER
		GROUP BY AP_ID) B ON A.AP_ID = B.AP_ID AND A.AP_SEQ = B.AP_SEQ

	UNION

	SELECT 
		[ID] = NEWID(), 
		[MediaType]='R',
		[OrderNumber]=ORDER_NBR, 
		[LineNumber]=ORDER_LINE_NBR, 
		[RunDate]=RUN_DATE, 
		[DayOfWeek]=DAY_OF_WEEK, 
		[TimeOfDay]=CONVERT(varchar, TIME_OF_DAY, 14), 
		[Length]=[LENGTH],
		[RUN_DATE]
	FROM AP_RADIO_BROADCAST_DTL A JOIN
		(SELECT AP_ID, MAX(AP_SEQ) AP_SEQ FROM AP_HEADER
		GROUP BY AP_ID) B ON A.AP_ID = B.AP_ID AND A.AP_SEQ = B.AP_SEQ

	ORDER BY A.ORDER_NBR, A.ORDER_LINE_NBR, A.RUN_DATE

END
ELSE IF @media_type = 'T' BEGIN

	SELECT 
		[ID] = NEWID(),
		[MediaType]='T',
		[OrderNumber]=ORDER_NBR, 
		[LineNumber]=ORDER_LINE_NBR, 
		[RunDate]=RUN_DATE, 
		[DayOfWeek]=DAY_OF_WEEK, 
		[TimeOfDay]=CONVERT(varchar, TIME_OF_DAY, 14),  
		[Length]=[LENGTH],
		[RUN_DATE]
	FROM AP_TV_BROADCAST_DTL A JOIN
		(SELECT AP_ID, MAX(AP_SEQ) AP_SEQ FROM AP_HEADER
		GROUP BY AP_ID) B ON A.AP_ID = B.AP_ID AND A.AP_SEQ = B.AP_SEQ

	ORDER BY A.ORDER_NBR, A.ORDER_LINE_NBR, A.RUN_DATE

END
ELSE IF @media_type = 'R' BEGIN

	SELECT 
		[ID] = NEWID(), 
		[MediaType]='R',
		[OrderNumber]=ORDER_NBR, 
		[LineNumber]=ORDER_LINE_NBR, 
		[RunDate]=RUN_DATE, 
		[DayOfWeek]=DAY_OF_WEEK, 
		[TimeOfDay]=CONVERT(varchar, TIME_OF_DAY, 14),  
		[Length]=[LENGTH],
		[RUN_DATE]
	FROM AP_RADIO_BROADCAST_DTL A JOIN
		(SELECT AP_ID, MAX(AP_SEQ) AP_SEQ FROM AP_HEADER
		GROUP BY AP_ID) B ON A.AP_ID = B.AP_ID AND A.AP_SEQ = B.AP_SEQ

	ORDER BY A.ORDER_NBR, A.ORDER_LINE_NBR, A.RUN_DATE

END

GRANT EXECUTE ON [advsp_api_load_media_broadcast_details] TO PUBLIC AS dbo
GO