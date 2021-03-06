IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[advsp_project_schedule_cmplt_sched_last_cpmlt]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_project_schedule_cmplt_sched_last_cpmlt]
GO
/****** Object:  StoredProcedure [dbo].[advsp_project_schedule_cmplt_sched_last_cpmlt]    Script Date: 2/7/2022 11:36:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- exec [advsp_project_schedule_cmplt_sched_last_cpmlt]  311, 1
CREATE PROCEDURE [dbo].[advsp_project_schedule_cmplt_sched_last_cpmlt] 
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT
AS
/*=========== QUERY ===========*/
BEGIN
	-- VARS
	BEGIN
		DECLARE
			@COMPLETE_ON_LAST BIT = 0,
			@SCHEDULE_CALC INT = 0,
			@MAX_COMPLETED_DATE SMALLDATETIME = NULL
		;
	END
	-- INIT
	BEGIN
		SELECT 
			@COMPLETE_ON_LAST = CAST(ISNULL(A.AGY_SETTINGS_VALUE, A.AGY_SETTINGS_DEF) AS BIT) 
		FROM AGY_SETTINGS A WITH(NOLOCK) 
		WHERE 
			A.AGY_SETTINGS_CODE = 'TRF_CMPLT_ON_LAST'
		;
	END
	-- DO IT IF SETTING SET
    IF ISNULL(@COMPLETE_ON_LAST, 0) = 1
    BEGIN		
		-- GET SCHEDULE TYPE (ORDER/PRED)
		BEGIN
			SELECT 
				@SCHEDULE_CALC = ISNULL(SCHEDULE_CALC, 0) 
			FROM 
				JOB_TRAFFIC WITH(NOLOCK) 
			WHERE 
				JOB_NUMBER = @JOB_NUMBER 
				AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
			;
		END
		--	GET MAX COMPLETED DATE BASED ON SCHEDULE TYPE
		IF ISNULL(@SCHEDULE_CALC, 0) = 0 
		BEGIN -- ORDER
			IF NOT EXISTS (	SELECT 
								JOB_NUMBER 
							FROM 
								JOB_TRAFFIC_DET J WITH(NOLOCK)
							WHERE 
								J.JOB_NUMBER = @JOB_NUMBER 
								AND J.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR 
								AND J.JOB_COMPLETED_DATE IS NULL)
			BEGIN
				SELECT 
					@MAX_COMPLETED_DATE = MAX(JTD.JOB_COMPLETED_DATE) 
				FROM 
					JOB_TRAFFIC_DET JTD WITH(NOLOCK)
				WHERE 
					JTD.JOB_NUMBER = @JOB_NUMBER 
					AND JTD.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
				;
			END
		END
		ELSE
		BEGIN -- PREDECESSOR
			IF NOT EXISTS ( SELECT
								J.JOB_NUMBER
							FROM
								JOB_TRAFFIC_DET J WITH(NOLOCK)
								LEFT OUTER JOIN JOB_TRAFFIC_DET_PREDS P WITH(NOLOCK) ON 
									J.JOB_NUMBER = P.JOB_NUMBER 
									AND J.JOB_COMPONENT_NBR = P.JOB_COMPONENT_NBR 
									AND J.SEQ_NBR = P.SEQ_NBR
							WHERE
								J.JOB_NUMBER = @JOB_NUMBER
								AND J.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
								AND (J.JOB_COMPLETED_DATE IS NULL
								AND J.SEQ_NBR NOT IN ( select PARENT_TASK_SEQ FROM JOB_TRAFFIC_DET WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR  and PARENT_TASK_SEQ is not null))
							)
			BEGIN
				--SELECT
				--	@MAX_COMPLETED_DATE = MAX(J.JOB_COMPLETED_DATE)
				--FROM
				--	JOB_TRAFFIC_DET J WITH(NOLOCK)
				--	LEFT OUTER JOIN JOB_TRAFFIC_DET_PREDS P WITH(NOLOCK) ON 
				--		J.JOB_NUMBER = P.JOB_NUMBER 
				--		AND J.JOB_COMPONENT_NBR = P.JOB_COMPONENT_NBR 
				--		AND J.SEQ_NBR = P.SEQ_NBR
				--WHERE
				--	J.JOB_NUMBER = @JOB_NUMBER
				--	AND J.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
				--	AND NOT PREDECESSOR_SEQ_NBR IS NULL
				SELECT 
					@MAX_COMPLETED_DATE = MAX(JTD.JOB_COMPLETED_DATE) 
				FROM 
					JOB_TRAFFIC_DET JTD WITH(NOLOCK)
				WHERE 
					JTD.JOB_NUMBER = @JOB_NUMBER 
					AND JTD.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR
				;
			END
		END
		--	MARK COMPLETE IF MAX DATE FOUND BUT DON'T UPDATE IF ALREADY THERE
		IF @MAX_COMPLETED_DATE IS NOT NULL
		BEGIN
			IF EXISTS (	SELECT 1 
						FROM JOB_TRAFFIC JT WITH(NOLOCK) 
						WHERE 
							JOB_NUMBER = @JOB_NUMBER 
							AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR 
							AND COMPLETED_DATE IS NULL)
			BEGIN
				UPDATE JOB_TRAFFIC WITH(ROWLOCK) 
				SET 
					COMPLETED_DATE = @MAX_COMPLETED_DATE 
				WHERE 
					JOB_NUMBER = @JOB_NUMBER 
					AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR 
					AND COMPLETED_DATE IS NULL
				;
			END
		END
    END
	-- RETURN
	BEGIN
		SELECT 
			[CompletedDate] = @MAX_COMPLETED_DATE
		;
	END
END
/*=========== QUERY ===========*/
GO


