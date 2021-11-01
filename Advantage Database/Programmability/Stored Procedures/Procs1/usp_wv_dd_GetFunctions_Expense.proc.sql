/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetFunctions_All_CD]    Script Date: 5/2/2019 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_wv_dd_GetFunctions_Expense] 

AS
	SELECT 
		FNC_CODE as Code, 
		FNC_CODE + ' - ' + ISNULL(FNC_DESCRIPTION,'') as Description,
		FNC_DESCRIPTION as Name
	FROM
		FUNCTIONS
	WHERE 
			((FNC_INACTIVE IS NULL ) OR (FNC_INACTIVE = 0))
			-- Needed to restrict for use on expense
			AND ((FNC_TYPE = 'E')) --OR  (FNC_TYPE = 'V'))
			--AND (EX_FLAG = 1)

GO