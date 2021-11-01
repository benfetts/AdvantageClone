SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_IsApprovalActive]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_IsApprovalActive]
GO
CREATE PROCEDURE [dbo].[usp_wv_ts_IsApprovalActive] /*WITH ENCRYPTION*/
@EMP_CODE VARCHAR(6)
AS
/*=========== QUERY ===========*/
	DECLARE 
		@BIT_RETURN BIT;
	
	SELECT @BIT_RETURN = [dbo].[advfn_timesheet_is_approval_active] (@EMP_CODE);
	
	SELECT 
		--ISNULL(@TIME_APPR_ACTIVE, 0) AS TIME_APPR_ACTIVE_INT,
		ISNULL(@BIT_RETURN, 0) AS TIME_APPR_ACTIVE;
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO