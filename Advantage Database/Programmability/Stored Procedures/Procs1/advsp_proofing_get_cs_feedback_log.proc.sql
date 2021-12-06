IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_proofing_get_cs_feedback_log]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    DROP PROCEDURE [dbo].[advsp_proofing_get_cs_feedback_log];
END
GO
CREATE PROCEDURE [dbo].[advsp_proofing_get_cs_feedback_log] 
AS
/*=========== QUERY ===========*/
BEGIN
	INSERT INTO CS_FEEDBACK_LOG (AlertID, ProjectID, ReviewID, [Title])
	SELECT
		A.ALERT_ID,
		A.CS_PROJECT_ID,
		A.CS_REVIEW_ID,
		A.[SUBJECT]
	FROM
		ALERT A WITH(NOLOCK)
		LEFT OUTER JOIN CS_FEEDBACK_LOG C WITH(NOLOCK) ON A.ALERT_ID = C.AlertID AND A.CS_REVIEW_ID = C.ReviewID
	WHERE
		A.CS_REVIEW_ID IS NOT NULL
		AND C.AlertID IS NULL
		AND C.ReviewID IS NULL
	;
	SELECT 
		CFL.*
	FROM 
		CS_FEEDBACK_LOG CFL WITH(NOLOCK)
	ORDER BY
		CFL.AlertID DESC
	;
END
/*=========== QUERY ===========*/

