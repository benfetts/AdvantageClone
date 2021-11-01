/****** Object:  StoredProcedure [dbo].[usp_wv_GetProjectManager]    Script Date: 1/22/2020 11:03:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- EXEC GetProjectManager 527,2

CREATE PROCEDURE [dbo].[usp_wv_GetProjectManager](
		@JobNumber int,
		@JobComponentNbr smallint
)
AS 
	DECLARE @ColumnName VARCHAR(20),
			@EmpCode VARCHAR(6)


	SELECT @ColumnName = 
		UPPER(RTRIM(LTRIM(CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, '') AS VARCHAR(20)))))
			  FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL';



	SELECT @EmpCode = case @ColumnName
			 WHEN 'TR_TITLE1' THEN	ASSIGN_1
			 WHEN 'TR_TITLE2' THEN	ASSIGN_2
			 WHEN 'TR_TITLE3' THEN	ASSIGN_3
			 WHEN 'TR_TITLE4' THEN	ASSIGN_4
			 WHEN 'TR_TITLE5' THEN	ASSIGN_5
			END
	  from JOB_TRAFFIC WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNbr

	select EMP_FNAME EmpFName ,EMP_MI EmpMI,EMP_LNAME EmpLName,EMP_CODE EmpCode from EMPLOYEE where EMP_CODE = @EmpCode

--select * from JOB_TRAFFIC

GO


