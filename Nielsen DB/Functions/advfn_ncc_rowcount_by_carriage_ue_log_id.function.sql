CREATE FUNCTION [dbo].[advfn_ncc_rowcount_by_carriage_ue_log_id](
	@NCC_TV_CARRIAGE_UE_LOG_ID int
)
RETURNS bigint
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @totalrows bigint

	SELECT @totalrows = COALESCE(COUNT(1), 0)
	FROM dbo.NCC_TV_CARRIAGE_UE_LOG 
	WHERE NCC_TV_CARRIAGE_UE_LOG_ID = @NCC_TV_CARRIAGE_UE_LOG_ID

	RETURN @totalrows
END
GO

GRANT EXEC ON [advfn_ncc_rowcount_by_carriage_ue_log_id] TO PUBLIC
GO
