CREATE FUNCTION [dbo].[advfn_ncc_rowcount_by_fusion_ue_id](
	@NCC_TV_FUSION_UE_ID bigint
)
RETURNS bigint
WITH SCHEMABINDING
AS
BEGIN

	DECLARE @totalrows bigint

	SELECT @totalrows = COALESCE(COUNT(1), 0)
	FROM dbo.NCC_TV_FUSION_AUDIENCE 
	WHERE NCC_TV_FUSION_UE_ID = @NCC_TV_FUSION_UE_ID

	SELECT @totalrows = @totalrows + COALESCE(COUNT(1), 0)
	FROM dbo.NCC_TV_FUSION_HUTPUT
	WHERE NCC_TV_FUSION_UE_ID = @NCC_TV_FUSION_UE_ID


	RETURN @totalrows
END
GO

GRANT EXEC ON [advfn_ncc_rowcount_by_fusion_ue_id] TO PUBLIC
GO
