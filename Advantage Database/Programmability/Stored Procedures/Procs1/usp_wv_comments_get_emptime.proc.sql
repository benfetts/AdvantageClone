SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_comments_get_emptime]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_comments_get_emptime]
GO
CREATE PROCEDURE [dbo].[usp_wv_comments_get_emptime] /*WITH ENCRYPTION*/
@ETSource AS VARCHAR(1),
@ETID AS INT, 
@ETDTLID AS SMALLINT
AS
/*=========== QUERY ===========*/
	SELECT 
		ISNULL(EMP_COMMENT,'') AS EMP_COMMENT
	FROM 
		EMP_TIME_DTL_CMTS WITH(NOLOCK)
	WHERE 
		ET_SOURCE = @ETSource
		AND ET_ID = @ETID
		AND ET_DTL_ID = @ETDTLID
		AND ET_ID > 0
		AND ET_DTL_ID > 0;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO