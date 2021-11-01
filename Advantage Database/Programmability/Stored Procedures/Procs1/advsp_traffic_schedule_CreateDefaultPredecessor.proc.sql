﻿CREATE PROCEDURE dbo.advsp_traffic_schedule_CreateDefaultPredecessor
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR SMALLINT,
	@SEQ_NBR SMALLINT
AS
BEGIN

	DECLARE @PREDECESSOR_JOB_ORDER SMALLINT
	DECLARE @JOB_ORDER SMALLINT

	SELECT 
		@JOB_ORDER = JOB_TRAFFIC_DET.JOB_ORDER 
	FROM 
		dbo.JOB_TRAFFIC_DET 
	WHERE 
		JOB_NUMBER = @JOB_NUMBER AND 
		JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND 
		SEQ_NBR = @SEQ_NBR

	SELECT TOP 1
		@PREDECESSOR_JOB_ORDER = ISNULL(JOB_TRAFFIC_DET.JOB_ORDER, -1)
	FROM
		dbo.JOB_TRAFFIC_DET 
	WHERE
		JOB_NUMBER = @JOB_NUMBER AND
		JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND
		SEQ_NBR <> @SEQ_NBR AND
		ISNULL(JOB_ORDER, 0) < ISNULL(@JOB_ORDER, 0)
	ORDER BY
		JOB_ORDER DESC

	IF NOT @PREDECESSOR_JOB_ORDER IS NULL 
	BEGIN

		INSERT INTO dbo.JOB_TRAFFIC_DET_PREDS (JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, PREDECESSOR_SEQ_NBR) 
			SELECT
				[JOB_NUMBER] = JOB_TRAFFIC_DET.JOB_NUMBER,
				[JOB_COMPONENT_NBR] = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
				[SEQ_NBR] = @SEQ_NBR,
				[PREDECESSOR_SEQ_NBR] = JOB_TRAFFIC_DET.SEQ_NBR
			FROM
				dbo.JOB_TRAFFIC_DET LEFT OUTER JOIN
				(SELECT
					JOB_TRAFFIC_DET_PREDS.PREDECESSOR_SEQ_NBR
				 FROM
					dbo.JOB_TRAFFIC_DET_PREDS 
				 WHERE
					JOB_NUMBER = @JOB_NUMBER AND
					JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND
					SEQ_NBR = @SEQ_NBR) JOB_TRAFFIC_DET_PREDS ON JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_PREDS.PREDECESSOR_SEQ_NBR
			WHERE
				JOB_TRAFFIC_DET.JOB_NUMBER = @JOB_NUMBER AND
				JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND
				ISNULL(JOB_TRAFFIC_DET.JOB_ORDER, -1) = @PREDECESSOR_JOB_ORDER AND
				JOB_TRAFFIC_DET_PREDS.PREDECESSOR_SEQ_NBR IS NULL

	END

END