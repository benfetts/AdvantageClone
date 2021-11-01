CREATE PROCEDURE [dbo].[advsp_media_plan_estimate_template_rate_types]
	@MEDIA_PLAN_ESTIMATE_TEMPLATE_ID int
AS

CREATE TABLE #rates (
	RATE_TYPE smallint NOT NULL,
	RATE_DESC varchar(20)
)

insert #rates (RATE_TYPE, RATE_DESC) VALUES (1, 'Column/Inch')
insert #rates (RATE_TYPE, RATE_DESC) VALUES (2, 'Line')
insert #rates (RATE_TYPE, RATE_DESC) VALUES (3, 'Standard')

SELECT
	Selected = CAST(CASE WHEN mpetrt.RATE_TYPE IS NOT NULL THEN 1 ELSE 0 END as bit),
	RateType = r.RATE_TYPE,
	RateDescription = r.RATE_DESC 
FROM #rates r
	LEFT OUTER JOIN dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_RATE_TYPE mpetrt ON r.RATE_TYPE = mpetrt.RATE_TYPE AND mpetrt.MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = @MEDIA_PLAN_ESTIMATE_TEMPLATE_ID
ORDER BY r.RATE_DESC
GO
