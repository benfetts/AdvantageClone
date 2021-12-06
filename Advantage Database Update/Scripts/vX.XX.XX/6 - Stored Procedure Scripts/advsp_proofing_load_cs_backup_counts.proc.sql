IF EXISTS (
		SELECT *
		FROM dbo.sysobjects
		WHERE id = object_id(N'[dbo].[advsp_proofing_load_cs_backup_counts]')
			AND OBJECTPROPERTY(id, N'IsProcedure') = 1
		)
	DROP PROCEDURE [dbo].[advsp_proofing_load_cs_backup_counts]
GO
CREATE PROCEDURE [dbo].[advsp_proofing_load_cs_backup_counts] 
AS
/*=========== QUERY ===========*/
BEGIN
		DECLARE
			@TOTAL_REVIEWS INT,
			@TOTAL_ASSETS INT,
			@TOTAL_BACKEDUP INT,
			@TOTAL_FAILED INT

		SELECT @TOTAL_REVIEWS = COUNT(DISTINCT(ReviewID)) FROM CS_BACKUP_LOG C WITH(NOLOCK);
		SELECT @TOTAL_ASSETS = COUNT(DISTINCT(AssetID)) FROM CS_BACKUP_LOG C WITH(NOLOCK);
		SELECT @TOTAL_BACKEDUP = COUNT(DISTINCT(AssetID)) FROM CS_BACKUP_LOG C WITH(NOLOCK) WHERE	BackedUp = 1;
		SELECT @TOTAL_FAILED = COUNT(DISTINCT(AssetID)) FROM CS_BACKUP_LOG C WITH(NOLOCK) WHERE BackedUp = 0;

		SELECT
			[TotalReviewsDB] = @TOTAL_REVIEWS,
			[TotalAssetsDB] = @TOTAL_ASSETS,
			[TotalBackedUpDB] = @TOTAL_BACKEDUP,
			[TotalFailedDB] = @TOTAL_FAILED
		;
END
/*=========== QUERY ===========*/

