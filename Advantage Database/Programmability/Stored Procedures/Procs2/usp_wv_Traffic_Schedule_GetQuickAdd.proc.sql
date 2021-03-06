
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetQuickAdd]
@SHOW_PRESET TINYINT
AS
/*=========== QUERY ===========*/
	IF @SHOW_PRESET = 1
	BEGIN
		SELECT TRF_PRESET_DTL.ROWID,
			   TRF_PRESET_HDR.TRF_PRESET_CODE,
			   TRF_PRESET_HDR.TRF_PRESET_DESC,
			   TRF_PRESET_DTL.FNC_CODE,
			   TRAFFIC_FNC.TRF_DESC,
			   TRF_PRESET_DTL.TRF_PRESET_ORDER,
			   ISNULL(TRF_PRESET_DTL.TRF_PRESET_DAYS, 0) AS TRF_PRESET_DAYS,
			   ISNULL(TRF_PRESET_DTL.TRF_PRESET_HRS, 0.00) AS TRF_PRESET_HRS,
			   TRF_PRESET_DTL.TRAFFIC_PHASE_ID,
			   TRAFFIC_PHASE.PHASE_DESC,
			   ISNULL(TRF_PRESET_DTL.MILESTONE, 0) AS MILESTONE,
			   TRF_PRESET_DTL.PARENT_TASK,
			   TRF_PRESET_DTL.DEFAULT_EMP,
			   ISNULL(TRF_PRESET_DTL.RUSH_DAYS, 0) AS RUSH_DAYS,
			   ISNULL(TRF_PRESET_DTL.RUSH_HOURS, 0) AS RUSH_HOURS,
			   TRF_PRESET_DTL.EST_FNC_CODE AS PRESET_EST_FNC_CODE,
			   TRAFFIC_FNC.FNC_CODE AS TRF_FNC_EST_FNC_CODE,
			   CASE 
					WHEN TRF_PRESET_DTL.EST_FNC_CODE IS NULL THEN TRAFFIC_FNC.FNC_CODE
					WHEN (NOT (TRF_PRESET_DTL.EST_FNC_CODE IS NULL)) THEN 
						 TRF_PRESET_DTL.EST_FNC_CODE
					WHEN (
							 TRF_PRESET_DTL.EST_FNC_CODE IS NULL
							 AND TRAFFIC_FNC.FNC_CODE IS NULL
						 ) THEN NULL
					ELSE NULL
			   END AS EST_FNC_CODE,
			   TRF_PRESET_DTL.DEF_TRF_ROLE AS TRF_PRESET_DTL_DEF_TRF_ROLE,
			   CASE 
					WHEN TRF_PRESET_DTL.DEF_TRF_ROLE IS NULL THEN TRAFFIC_FNC.DEF_TRF_ROLE
					WHEN (NOT (TRF_PRESET_DTL.DEF_TRF_ROLE IS NULL)) THEN 
						 TRF_PRESET_DTL.DEF_TRF_ROLE
					WHEN (
							 TRF_PRESET_DTL.DEF_TRF_ROLE IS NULL
							 AND TRAFFIC_FNC.DEF_TRF_ROLE IS NULL
						 ) THEN NULL
					ELSE NULL
			   END AS DEF_TRF_ROLE
		FROM   TRF_PRESET_HDR WITH(NOLOCK)
			   INNER JOIN TRF_PRESET_DTL WITH(NOLOCK)
					ON  TRF_PRESET_HDR.TRF_PRESET_CODE = TRF_PRESET_DTL.TRF_PRESET_CODE
			   LEFT OUTER JOIN TRAFFIC_PHASE WITH(NOLOCK)
					ON  TRF_PRESET_DTL.TRAFFIC_PHASE_ID = TRAFFIC_PHASE.TRAFFIC_PHASE_ID
			   LEFT OUTER JOIN TRAFFIC_FNC WITH(NOLOCK)
					ON  TRF_PRESET_DTL.FNC_CODE = TRAFFIC_FNC.TRF_CODE
		WHERE  (
				   (TRF_PRESET_HDR.INACTIVE_FLAG = 0)
				   OR (TRF_PRESET_HDR.INACTIVE_FLAG IS NULL)
			   )
			   AND (
					   (TRAFFIC_FNC.TRF_INACTIVE = 0)
					   OR (TRAFFIC_FNC.TRF_INACTIVE IS NULL)
				   )
		ORDER BY
			   TRF_PRESET_HDR.TRF_PRESET_CODE,
			   TRF_PRESET_DTL.TRF_PRESET_ORDER;
	END

	IF @SHOW_PRESET = 0 OR @SHOW_PRESET IS NULL
	BEGIN
		SELECT 0 AS ROWID,
			   TRF_CODE AS TRF_PRESET_CODE,
			   TRF_DESC AS TRF_PRESET_DESC,
			   TRF_ORDER AS TRF_PRESET_ORDER,
			   TRF_DAYS AS TRF_PRESET_DAYS,
			   TRF_HRS AS TRF_PRESET_HRS,
			   NULL AS TRAFFIC_PHASE_ID,
			   NULL AS PHASE_DESC,
			   MILESTONE,
			   NULL AS PARENT_TASK,
			   NULL AS DEFAULT_EMP,
			   0 AS RUSH_DAYS,
			   0 AS RUSH_HOURS,
			   NULL AS PRESET_EST_FNC_CODE,
			   NULL AS TRF_FNC_EST_FNC_CODE,
			   FNC_CODE AS EST_FNC_CODE,
			   NULL AS TRF_PRESET_DTL_DEF_TRF_ROLE,
			   DEF_TRF_ROLE,
			   TRF_CODE AS FNC_CODE,
			   TRF_DESC AS TRF_DESC,
			   --FNC_CODE,
			   DEF_STATUS
		FROM   TRAFFIC_FNC WITH(NOLOCK)
		WHERE  (TRF_INACTIVE IS NULL OR TRF_INACTIVE = 0)
		ORDER BY
			   TRF_CODE,
			   TRF_ORDER;
	END
/*=========== QUERY ===========*/
