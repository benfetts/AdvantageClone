if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_SOFTWARE_VERSION_GET_BY_JC]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_SOFTWARE_VERSION_GET_BY_JC]
GO
CREATE PROCEDURE [dbo].[usp_wv_SOFTWARE_VERSION_GET_BY_JC] /*WITH ENCRYPTION*/
@JOB_NUMBER INT,
@JOB_COMPONENT_NBR SMALLINT
AS
/*=========== QUERY ===========*/
	SET @JOB_COMPONENT_NBR = ISNULL(@JOB_COMPONENT_NBR, 0);

	IF @JOB_COMPONENT_NBR > 0 
	BEGIN
		SELECT DISTINCT SOFTWARE_VERSION.VERSION_ID,
				SOFTWARE_VERSION.VERSION,
				SOFTWARE_VERSION.VERSION_DESC,
				SOFTWARE_VERSION.ACTIVE_FLAG
		FROM   SOFTWARE_VERSION WITH (NOLOCK)
				INNER JOIN SOFTWARE_LEVEL WITH (NOLOCK)
					ON  SOFTWARE_VERSION.VERSION_ID = SOFTWARE_LEVEL.VERSION_ID
		WHERE  (
				(SOFTWARE_LEVEL.JOB_NUMBER = @JOB_NUMBER
				AND SOFTWARE_LEVEL.JOB_COMPONENT_NBR IS NULL)
				OR
				(SOFTWARE_LEVEL.JOB_NUMBER = @JOB_NUMBER
				AND SOFTWARE_LEVEL.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)
				)
				AND (
						SOFTWARE_VERSION.ACTIVE_FLAG = 1
						OR SOFTWARE_VERSION.ACTIVE_FLAG IS NULL
					);
	END
	ELSE
	BEGIN
		SELECT DISTINCT SOFTWARE_VERSION.VERSION_ID,
				SOFTWARE_VERSION.VERSION,
				SOFTWARE_VERSION.VERSION_DESC,
				SOFTWARE_VERSION.ACTIVE_FLAG
		FROM   SOFTWARE_VERSION WITH (NOLOCK)
				INNER JOIN SOFTWARE_LEVEL WITH (NOLOCK)
					ON  SOFTWARE_VERSION.VERSION_ID = SOFTWARE_LEVEL.VERSION_ID
		WHERE  (SOFTWARE_LEVEL.JOB_NUMBER = @JOB_NUMBER
				AND SOFTWARE_LEVEL.JOB_COMPONENT_NBR IS NULL)
				AND (
						SOFTWARE_VERSION.ACTIVE_FLAG = 1
						OR SOFTWARE_VERSION.ACTIVE_FLAG IS NULL
					);
	END
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO