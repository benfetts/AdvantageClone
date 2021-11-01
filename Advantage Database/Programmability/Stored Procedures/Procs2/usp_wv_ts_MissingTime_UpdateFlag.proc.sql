















CREATE PROCEDURE [dbo].[usp_wv_ts_MissingTime_UpdateFlag]
	@EMP_CODE VarChar(6)

AS

	UPDATE EMPLOYEE WITH (ROWLOCK)  SET MISSING_TIME = 0 WHERE EMP_CODE=@EMP_CODE















