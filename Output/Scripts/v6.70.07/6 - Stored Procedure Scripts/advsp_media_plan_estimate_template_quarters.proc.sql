CREATE PROCEDURE [dbo].[advsp_media_plan_estimate_template_quarters]
	@MEDIA_PLAN_ESTIMATE_TEMPLATE_ID int
AS

CREATE TABLE #qtrs (
	QTR smallint NOT NULL,
	QTR_DESC varchar(20)
)

insert #qtrs (QTR, QTR_DESC) VALUES (1, 'Q1')
insert #qtrs (QTR, QTR_DESC) VALUES (2, 'Q2')
insert #qtrs (QTR, QTR_DESC) VALUES (3, 'Q3')
insert #qtrs (QTR, QTR_DESC) VALUES (4, 'Q4')

SELECT
	Selected = CAST(CASE WHEN mpetq.[QUARTER] IS NOT NULL THEN 1 ELSE 0 END as bit),
	QuarterNumber = q.QTR,
	[Quarter] = q.QTR_DESC
FROM #qtrs q
	LEFT OUTER JOIN dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_QUARTER mpetq ON q.QTR = mpetq.[QUARTER] AND mpetq.MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = @MEDIA_PLAN_ESTIMATE_TEMPLATE_ID
ORDER BY q.QTR_DESC
GO
