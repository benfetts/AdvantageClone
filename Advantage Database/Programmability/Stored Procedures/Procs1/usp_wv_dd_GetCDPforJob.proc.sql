/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetCDPforJob]    Script Date: 6/13/2019 10:09:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/*
	exec usp_wv_dd_GetCDPforJob 542
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetCDPforJob](
	@JobNumber int
)
as
	select OFFICE_CODE OfficeCode,CL_CODE ClientCode,DIV_CODE DivisionCode,PRD_CODE ProductCode from JOB_LOG WHERE JOB_NUMBER = @JobNumber



GO


