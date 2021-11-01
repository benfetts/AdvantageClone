if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_dd_job_comp_job_type]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_dd_job_comp_job_type]
GO
/****** Object:  StoredProcedure [dbo].[usp_wv_dd_job_comp_job_type]    Script Date: 6/26/2019 11:05:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_wv_dd_job_comp_job_type] 
@SC_CODE VARCHAR(6)
AS
IF @SC_CODE = ''
	BEGIN
		SELECT DISTINCT JT_CODE as code, JT_CODE + ' - ' + JT_DESC as description
		FROM JOB_TYPE
		WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) --AND  (SC_CODE IS NULL)
	END
ELSE
	BEGIN
		SELECT DISTINCT JT_CODE as code, JT_CODE + ' - ' + JT_DESC as description
		FROM JOB_TYPE
		WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) AND  (SC_CODE IS NULL OR SC_CODE = @SC_CODE)
	END



GO

GRANT EXECUTE ON [dbo].[usp_wv_dd_job_comp_job_type] TO PUBLIC
GO


