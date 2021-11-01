﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_GetQuickAdd]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_GetQuickAdd]
GO
CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetQuickAdd]
@SHOW_PRESET BIT,
@JOB_NUMBER INT,
@CL_CODE VARCHAR(6)
AS
BEGIN	

	DECLARE 
		@LIMIT_BY_CLIENT BIT;

	SET @LIMIT_BY_CLIENT = 0;
	IF (@CL_CODE IS NULL OR DATALENGTH(@CL_CODE) = 0) AND (NOT @JOB_NUMBER IS NULL AND @JOB_NUMBER > 0)
	BEGIN
		SELECT @CL_CODE = CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = @JOB_NUMBER;
	END
	IF NOT @CL_CODE IS NULL AND DATALENGTH(@CL_CODE) > 0
	BEGIN
		SELECT @LIMIT_BY_CLIENT = CAST(ISNULL(LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY, 0) AS BIT) FROM CLIENT WHERE CL_CODE = @CL_CODE;
	END

	IF @SHOW_PRESET = 1
	BEGIN
		IF NOT @LIMIT_BY_CLIENT IS NULL AND @LIMIT_BY_CLIENT = 1
		BEGIN
			SELECT DISTINCT   
				PRESET_FUNC.ROWID,
				PRESET_FUNC_HDR.PRESET_CODE, 
				PRESET_FUNC_HDR.PRESET_DESC, 
				FUNCTIONS.FNC_CODE, 
				FUNCTIONS.FNC_DESCRIPTION, 
				ISNULL(PRESET_FUNC.SUPPLIED_BY,'') AS SUPPLIED_BY, 
				ISNULL(PRESET_FUNC.HRS_QTY,0) AS HRS_QTY, 
				ISNULL(PRESET_FUNC.NET_AMOUNT,0.00) AS NET_AMOUNT, FUNCTIONS.FNC_TYPE,
				CASE 
					WHEN FUNCTIONS.FNC_TYPE = 'E' THEN 'Employee'
					WHEN FUNCTIONS.FNC_TYPE = 'V' THEN 'Vendor'
					WHEN FUNCTIONS.FNC_TYPE = 'I' THEN 'Income Only'
					WHEN FUNCTIONS.FNC_TYPE = 'C' THEN 'Client OOP'
					ELSE '' 
				END AS FNC_TYPE_DESC,
				FUNCTIONS.FNC_HEADING_ID, 
				FNC_HEADING_DESC,
				FUNCTIONS.FNC_TYPE
			FROM         
				PRESET_FUNC_HDR WITH(NOLOCK) INNER JOIN
				PRESET_FUNC WITH(NOLOCK) ON PRESET_FUNC_HDR.PRESET_CODE = PRESET_FUNC.PRESET_CODE LEFT OUTER JOIN
				FUNCTIONS WITH(NOLOCK) ON PRESET_FUNC.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
				FNC_HEADING WITH(NOLOCK) ON FNC_HEADING.FNC_HEADING_ID = FUNCTIONS.FNC_HEADING_ID
				INNER JOIN BILLING_RATE BR ON PRESET_FUNC.FNC_CODE = BR.FNC_CODE
			WHERE    
				1 = CASE WHEN FUNCTIONS.FNC_TYPE = 'E' AND BR.CL_CODE = @CL_CODE THEN 1 WHEN FUNCTIONS.FNC_TYPE = 'E' AND (BR.CL_CODE <> @CL_CODE OR BR.CL_CODE IS NULL) THEN 0 WHEN FUNCTIONS.FNC_TYPE <> 'E' THEN 1 ELSE 0 END 
				AND
				((PRESET_FUNC_HDR.INACTIVE_FLAG = 0) OR
				(PRESET_FUNC_HDR.INACTIVE_FLAG IS NULL))
				AND
				((FUNCTIONS.FNC_INACTIVE = 0) OR
				(FUNCTIONS.FNC_INACTIVE IS NULL))   
			ORDER BY 
				PRESET_FUNC_HDR.PRESET_CODE, 
				FUNCTIONS.FNC_TYPE, 
				FUNCTIONS.FNC_CODE, 
				FUNCTIONS.FNC_DESCRIPTION;
		END
		ELSE
		BEGIN
			SELECT DISTINCT   
				PRESET_FUNC.ROWID,
				PRESET_FUNC_HDR.PRESET_CODE, 
				PRESET_FUNC_HDR.PRESET_DESC, 
				FUNCTIONS.FNC_CODE, 
				FUNCTIONS.FNC_DESCRIPTION, 
				ISNULL(PRESET_FUNC.SUPPLIED_BY,'') AS SUPPLIED_BY, 
				ISNULL(PRESET_FUNC.HRS_QTY,0) AS HRS_QTY, 
				ISNULL(PRESET_FUNC.NET_AMOUNT,0.00) AS NET_AMOUNT, FUNCTIONS.FNC_TYPE,
				CASE 
					WHEN FUNCTIONS.FNC_TYPE = 'E' THEN 'Employee'
					WHEN FUNCTIONS.FNC_TYPE = 'V' THEN 'Vendor'
					WHEN FUNCTIONS.FNC_TYPE = 'I' THEN 'Income Only'
					WHEN FUNCTIONS.FNC_TYPE = 'C' THEN 'Client OOP'
					ELSE '' 
				END AS FNC_TYPE_DESC,
				FUNCTIONS.FNC_HEADING_ID, 
				FNC_HEADING_DESC,
				FUNCTIONS.FNC_TYPE
			FROM         
				PRESET_FUNC_HDR WITH(NOLOCK) INNER JOIN
				PRESET_FUNC WITH(NOLOCK) ON PRESET_FUNC_HDR.PRESET_CODE = PRESET_FUNC.PRESET_CODE LEFT OUTER JOIN
				FUNCTIONS WITH(NOLOCK) ON PRESET_FUNC.FNC_CODE = FUNCTIONS.FNC_CODE LEFT OUTER JOIN
				FNC_HEADING WITH(NOLOCK) ON FNC_HEADING.FNC_HEADING_ID = FUNCTIONS.FNC_HEADING_ID
			WHERE     
				((PRESET_FUNC_HDR.INACTIVE_FLAG = 0) OR
				(PRESET_FUNC_HDR.INACTIVE_FLAG IS NULL))
				AND
				((FUNCTIONS.FNC_INACTIVE = 0) OR
				(FUNCTIONS.FNC_INACTIVE IS NULL))   
			ORDER BY 
				PRESET_FUNC_HDR.PRESET_CODE, 
				FUNCTIONS.FNC_TYPE, 
				FUNCTIONS.FNC_CODE, 
				FUNCTIONS.FNC_DESCRIPTION;
		END
	END
	IF @SHOW_PRESET = 0 OR @SHOW_PRESET IS NULL
	BEGIN
		IF NOT @LIMIT_BY_CLIENT IS NULL AND @LIMIT_BY_CLIENT = 1
		BEGIN
			SELECT DISTINCT
				FUNCTIONS.FNC_CODE, 
				FUNCTIONS.FNC_DESCRIPTION, 
				'' AS SUPPLIED_BY, 
				0.00 AS HRS_QTY, 
				0.00 AS NET_AMOUNT, FUNCTIONS.FNC_TYPE,
				CASE 
					WHEN FUNCTIONS.FNC_TYPE = 'E' THEN 'Employee'
					WHEN FUNCTIONS.FNC_TYPE = 'V' THEN 'Vendor'
					WHEN FUNCTIONS.FNC_TYPE = 'I' THEN 'Income Only'
					WHEN FUNCTIONS.FNC_TYPE = 'C' THEN 'Client OOP'
					ELSE '' 
				END AS FNC_TYPE_DESC,
				FUNCTIONS.FNC_HEADING_ID, 
				FNC_HEADING.FNC_HEADING_DESC,
				FUNCTIONS.FNC_TYPE
			FROM  
				FUNCTIONS WITH(NOLOCK) LEFT OUTER JOIN
				FNC_HEADING WITH(NOLOCK) ON FNC_HEADING.FNC_HEADING_ID = FUNCTIONS.FNC_HEADING_ID
				INNER JOIN BILLING_RATE BR ON FUNCTIONS.FNC_CODE = BR.FNC_CODE
			WHERE     
				(FUNCTIONS.FNC_INACTIVE = 0 OR FUNCTIONS.FNC_INACTIVE IS NULL)
				AND 1 = CASE WHEN FUNCTIONS.FNC_TYPE = 'E' AND BR.CL_CODE = @CL_CODE THEN 1 WHEN FUNCTIONS.FNC_TYPE = 'E' AND (BR.CL_CODE <> @CL_CODE OR BR.CL_CODE IS NULL) THEN 0 WHEN FUNCTIONS.FNC_TYPE <> 'E' THEN 1 ELSE 0 END 
			ORDER BY 
				FUNCTIONS.FNC_TYPE,
				FUNCTIONS.FNC_CODE, 
				FNC_DESCRIPTION;
		END
		ELSE
		BEGIN
			SELECT DISTINCT
				FNC_CODE, 
				FNC_DESCRIPTION, 
				'' AS SUPPLIED_BY, 
				0.00 AS HRS_QTY, 
				0.00 AS NET_AMOUNT, FUNCTIONS.FNC_TYPE,
				CASE WHEN FUNCTIONS.FNC_TYPE = 'E' THEN 'Employee'
					 WHEN FUNCTIONS.FNC_TYPE = 'V' THEN 'Vendor'
					 WHEN FUNCTIONS.FNC_TYPE = 'I' THEN 'Income Only'
					 WHEN FUNCTIONS.FNC_TYPE = 'C' THEN 'Client OOP'
					 ELSE '' END AS FNC_TYPE_DESC,
				FUNCTIONS.FNC_HEADING_ID, 
				FNC_HEADING_DESC,
				FUNCTIONS.FNC_TYPE
			FROM  
				FUNCTIONS WITH(NOLOCK) LEFT OUTER JOIN
				FNC_HEADING WITH(NOLOCK) ON FNC_HEADING.FNC_HEADING_ID = FUNCTIONS.FNC_HEADING_ID
			WHERE     
				(FUNCTIONS.FNC_INACTIVE = 0 OR FUNCTIONS.FNC_INACTIVE IS NULL)   
			ORDER BY 
				FUNCTIONS.FNC_TYPE,
				FNC_CODE, 
				FNC_DESCRIPTION;
		END
	END
END