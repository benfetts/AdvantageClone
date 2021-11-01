SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_comments_update_emptime]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_comments_update_emptime]
GO
CREATE PROCEDURE [dbo].[usp_wv_comments_update_emptime] 
@ETSource AS VARCHAR(1),
@ETID AS INT, 
@ETDTLID AS SMALLINT,
@Comments AS NTEXT,
@ReturnMessage AS BIT
AS
/*=========== QUERY ===========*/
IF @ETID > 0 AND @ETDTLID > 0
BEGIN

	DECLARE @Rows AS INT

	SELECT @Rows = COUNT(1)
	FROM EMP_TIME_DTL_CMTS WITH(NOLOCK)
	WHERE ET_SOURCE= @ETSource
	AND ET_ID= @ETID
	AND ET_DTL_ID= @ETDTLID;

	SET @ReturnMessage = ISNULL(@ReturnMessage, 0);

	IF @Rows > 0 
		BEGIN
			IF @Comments IS NULL OR DATALENGTH(@Comments) = 0
			BEGIN
				DELETE FROM EMP_TIME_DTL_CMTS WITH(ROWLOCK)
				WHERE ET_SOURCE= @ETSource
				AND ET_ID= @ETID
				AND ET_DTL_ID= @ETDTLID;
			END
			ELSE
			BEGIN
				UPDATE EMP_TIME_DTL_CMTS WITH(ROWLOCK)
				SET EMP_COMMENT = @Comments
				WHERE ET_SOURCE= @ETSource
				AND ET_ID= @ETID
				AND ET_DTL_ID= @ETDTLID;
			END
			IF @ReturnMessage = 1
			BEGIN
				SELECT 'UPDATE_CMT_SUCCESS';
			END
		END
	ELSE
		BEGIN
			INSERT INTO EMP_TIME_DTL_CMTS ( ET_ID, ET_DTL_ID, SEQ_NBR, ET_SOURCE, EMP_COMMENT )
			VALUES (@ETID, @ETDTLID, @ETDTLID, @ETSource, @Comments);
			IF @ReturnMessage = 1
			BEGIN
				SELECT 'INSERT_CMT_SUCCESS'
			END
		END

END
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO