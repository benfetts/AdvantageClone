/****** Object:  StoredProcedure [dbo].[usp_wv_dd_salesclass_all]    Script Date: 3/21/2019 1:32:55 PM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_wv_dd_salesclass_all] 
AS
	SELECT DISTINCT SC_CODE AS code, SC_CODE + ' - ' + ISNULL(SC_DESCRIPTION, '') AS description
	,SC_DESCRIPTION as Name
	FROM         SALES_CLASS
	WHERE     (INACTIVE_FLAG IS NULL OR  INACTIVE_FLAG = 0) 
	ORDER BY SC_DESCRIPTION

GO


