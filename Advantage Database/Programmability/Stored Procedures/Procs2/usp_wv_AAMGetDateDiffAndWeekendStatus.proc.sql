IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_AAMGetDateDiffAndWeekendStatus]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_AAMGetDateDiffAndWeekendStatus]
GO

/****** Object:  StoredProcedure [dbo].[usp_wv_AAMGetDateDiffAndWeekendStatus]    Script Date: 7/21/2020 4:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_wv_AAMGetDateDiffAndWeekendStatus]
	@DATE_VALUE VARCHAR(10)
AS
	BEGIN	
		SELECT	DATEDIFF(DAY, GETDATE(), @DATE_VALUE) AS DateDifference,
			CASE WHEN (DATEPART(DW,@DATE_VALUE) = 1 OR DATEPART(DW,@DATE_VALUE) = 7) THEN 1
				ELSE 0
			END AS IsWeekendDate
	END

