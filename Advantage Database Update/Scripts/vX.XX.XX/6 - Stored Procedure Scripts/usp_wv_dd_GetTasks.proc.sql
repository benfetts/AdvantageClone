﻿/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetTasks]    Script Date: 6/18/2021 3:22:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- EXEC [dbo].[usp_wv_dd_GetTasks] 0,0

CREATE PROCEDURE [dbo].[usp_wv_dd_GetTasks] /*WITH ENCRYPTION*/
	@JOB_NUMBER         INT,
	@JOB_COMPONENT_NBR  SMALLINT
AS
/*=========== QUERY ===========*/
	IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR > 0
	BEGIN
		SELECT TRF_CODE AS Code,
			   TRF_CODE + ISNULL(' - ' + TRF_DESC, '') AS DESCRIPTION,
			    ISNULL(TRF_DESC, '') AS TRF_DESCRIPTION,
				ISNULL(TRF_DESC, '') AS Name,
				TRAFFIC_FNC.FNC_CODE AS EST_FNC_CODE,
				FUNCTIONS.FNC_DESCRIPTION,
				TRF_ORDER
		FROM   TRAFFIC_FNC WITH(NOLOCK)  LEFT JOIN FUNCTIONS ON TRAFFIC_FNC.FNC_CODE = FUNCTIONS.FNC_CODE
		WHERE  ((TRF_INACTIVE IS NULL) OR TRF_INACTIVE = 0)
			   AND TRF_CODE IN (SELECT DISTINCT FNC_CODE
								FROM   JOB_TRAFFIC_DET WITH(NOLOCK)
								WHERE  JOB_NUMBER = @JOB_NUMBER
									   AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
									   AND (NOT(FNC_CODE IS NULL)));
	END
	IF @JOB_NUMBER > 0 AND @JOB_COMPONENT_NBR = 0
	BEGIN
		SELECT TRF_CODE AS Code,
			   TRF_CODE + ISNULL(' - ' + TRF_DESC, '') AS DESCRIPTION, ISNULL(TRF_DESC, '') AS TRF_DESCRIPTION,
				ISNULL(TRF_DESC, '') AS Name,
				TRAFFIC_FNC.FNC_CODE AS EST_FNC_CODE,
				FUNCTIONS.FNC_DESCRIPTION,
				TRF_ORDER
		FROM   TRAFFIC_FNC WITH(NOLOCK) LEFT JOIN FUNCTIONS ON TRAFFIC_FNC.FNC_CODE = FUNCTIONS.FNC_CODE
		WHERE  ((TRF_INACTIVE IS NULL) OR TRF_INACTIVE = 0)
			   AND TRF_CODE IN (SELECT DISTINCT FNC_CODE
								FROM   JOB_TRAFFIC_DET WITH(NOLOCK)
								WHERE  JOB_NUMBER = @JOB_NUMBER
									   AND (NOT(FNC_CODE IS NULL)));
	END
	IF (@JOB_NUMBER = 0 AND @JOB_COMPONENT_NBR = 0) OR (@JOB_NUMBER = 0 AND @JOB_COMPONENT_NBR > 0)
	BEGIN
		SELECT TRF_CODE AS Code,
			   TRF_CODE + ISNULL(' - ' + TRF_DESC, '') AS DESCRIPTION, ISNULL(TRF_DESC, '') AS TRF_DESCRIPTION,
				ISNULL(TRF_DESC, '') AS Name,
				TRAFFIC_FNC.FNC_CODE AS EST_FNC_CODE,
				FUNCTIONS.FNC_DESCRIPTION,
				TRF_ORDER
		FROM   TRAFFIC_FNC WITH(NOLOCK)  LEFT JOIN FUNCTIONS ON TRAFFIC_FNC.FNC_CODE = FUNCTIONS.FNC_CODE
		WHERE  ((TRF_INACTIVE IS NULL) OR TRF_INACTIVE = 0);
	END
/*=========== QUERY ===========*/


GO


