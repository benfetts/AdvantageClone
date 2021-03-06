SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_DetailRequireComment]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_DetailRequireComment]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_DetailRequireComment] /*WITH ENCRYPTION*/
@JOB_NUMBER INT,
@ET_ID INT,
@ET_DTL_ID SMALLINT
AS
/*=========== QUERY ===========*/
	SET @JOB_NUMBER = ISNULL(@JOB_NUMBER, 0);
	SET @ET_ID = ISNULL(@ET_ID, 0);
	SET @ET_DTL_ID = ISNULL(@ET_DTL_ID, 0);
	
	
	DECLARE @REQ_TIME_COMMENT BIT;
	SET @REQ_TIME_COMMENT = 0;
	
	DECLARE
		@COMMENTS_REQ SMALLINT;
	
	SELECT
		@COMMENTS_REQ = ISNULL(TIME_COMMENTS_REQ,0)
	FROM
		AGENCY WITH(NOLOCK);
	
	SET @COMMENTS_REQ = ISNULL(@COMMENTS_REQ, 0);

	IF @COMMENTS_REQ = 1
	BEGIN
	
		SET @REQ_TIME_COMMENT = 1;
		
	END	
	
	IF @REQ_TIME_COMMENT = 0
	BEGIN
	
		IF @JOB_NUMBER > 0
		BEGIN
		
			SELECT 
        		@REQ_TIME_COMMENT = ISNULL(CLIENT.REQ_TIME_COMMENT, 0)
			FROM 
        		CLIENT WITH(NOLOCK) INNER JOIN 
        		JOB_LOG WITH(NOLOCK) ON CLIENT.CL_CODE = JOB_LOG.CL_CODE 
			WHERE 
        		(JOB_LOG.JOB_NUMBER = @JOB_NUMBER); 
		
		END
		
		IF @ET_ID > 0 AND @ET_DTL_ID > 0
		BEGIN
		
			SELECT 
        		@REQ_TIME_COMMENT = ISNULL(CLIENT.REQ_TIME_COMMENT, 0)
			FROM 
        		EMP_TIME_DTL WITH(ROWLOCK) INNER JOIN 
        		JOB_LOG WITH(ROWLOCK) ON EMP_TIME_DTL.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN 
        		CLIENT WITH(ROWLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE 
			WHERE 
        		(EMP_TIME_DTL.ET_ID = @ET_ID) AND (EMP_TIME_DTL.ET_DTL_ID = @ET_DTL_ID); 
		
		END	
		
	END
	
	SELECT @REQ_TIME_COMMENT AS REQ_TIME_COMMENT;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO