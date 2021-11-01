IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'[dbo].[advfn_emp_time_np_hrs]' ) AND xtype IN ( N'FN', N'IF', N'TF' ))
BEGIN
	DROP FUNCTION [dbo].[advfn_emp_time_np_hrs]
END
GO
CREATE FUNCTION [dbo].[advfn_emp_time_np_hrs] (@et_id INTEGER)
RETURNS DECIMAL(15, 2)
AS
BEGIN
    RETURN
	(
		SELECT 
			COALESCE(SUM(EMP_HOURS), 0)
		FROM 
			[dbo].[EMP_TIME_NP]
		WHERE 
			ET_ID = @et_id
			AND (EMP_TIME_NP.EDIT_FLAG <> 1 OR EMP_TIME_NP.EDIT_FLAG IS NULL)
	);
END; 