CREATE PROCEDURE [dbo].[advsp_hosted_ncc_tv_fusion_ue_delete_reissues]

AS
BEGIN

	DECLARE @NCC_TV_FUSION_UE_ID int,
			@ROWCOUNT int,
			@ROW_ID int

	DECLARE @REISSUE TABLE (
		ID					int IDENTITY (1, 1) NOT NULL,
		NCC_TV_FUSION_UE_ID	int NOT NULL
	)

	INSERT INTO @REISSUE (NCC_TV_FUSION_UE_ID)
	SELECT OLD_NCC_TV_FUSION_UE_ID 
	FROM NIELSENDATASTORE.dbo.NCC_TV_FUSION_UE_REVISION 

	SELECT @ROWCOUNT = COUNT(1) FROM @REISSUE 
	SELECT @ROW_ID = MIN(ID) FROM @REISSUE 

	IF @ROWCOUNT > 0 BEGIN

		WHILE @ROW_ID <= @ROWCOUNT
		BEGIN

			SELECT @NCC_TV_FUSION_UE_ID = NCC_TV_FUSION_UE_ID
			FROM @REISSUE 
			WHERE ID = @ROW_ID 

			DELETE NIELSENHOSTED.dbo.NCC_TV_FUSION_AUDIENCE WHERE NCC_TV_FUSION_UE_ID = @NCC_TV_FUSION_UE_ID 
			DELETE NIELSENHOSTED.dbo.NCC_TV_FUSION_HUTPUT WHERE NCC_TV_FUSION_UE_ID = @NCC_TV_FUSION_UE_ID 
			DELETE NIELSENHOSTED.dbo.NCC_TV_FUSION_UE WHERE NCC_TV_FUSION_UE_ID = @NCC_TV_FUSION_UE_ID 

			SET @ROW_ID = @ROW_ID + 1

		END

	END
END
GO

GRANT EXEC ON [advsp_hosted_ncc_tv_fusion_ue_delete_reissues] TO PUBLIC
GO