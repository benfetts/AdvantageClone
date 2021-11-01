SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_SaveClientPortalImage]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_SaveClientPortalImage]
GO
CREATE PROCEDURE [dbo].[usp_wv_SaveClientPortalImage] /*WITH ENCRYPTION*/
@CL_CODE VARCHAR(6),
@IMAGE IMAGE,
@IMAGE_TYPE TINYINT -- 0 = LOGO, 1 = WALLPAPER, SOLID COLOR = 2, CUSTOM = 3, ICON = 4
AS
/*=========== QUERY ===========*/
IF @CL_CODE IS NULL
BEGIN

	IF EXISTS(SELECT BINARY_IMAGE_ID FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT IS NULL)
	BEGIN
		--SELECT 'UPDATE DEFAULT RECORD'
		IF @IMAGE_TYPE = 0
		BEGIN
			UPDATE CP_BINARY_IMAGES WITH(ROWLOCK) SET BINARY_IMAGE_LOGO = @IMAGE WHERE BINARY_IMAGE_CLIENT IS NULL;
		END
		IF @IMAGE_TYPE = 3
		BEGIN
			UPDATE CP_BINARY_IMAGES WITH(ROWLOCK) SET BINARY_IMAGE_WP = @IMAGE WHERE BINARY_IMAGE_CLIENT IS NULL;
		END
		IF @IMAGE_TYPE = 4
		BEGIN
			UPDATE CP_BINARY_IMAGES WITH(ROWLOCK) SET BINARY_IMAGE_ICON = @IMAGE WHERE BINARY_IMAGE_CLIENT IS NULL;
		END
	END
	ELSE
	BEGIN
		--SELECT 'INSERT DEFAULT RECORD'
		IF @IMAGE_TYPE = 0
		BEGIN
			INSERT INTO CP_BINARY_IMAGES WITH(ROWLOCK) (BINARY_IMAGE_LOGO) VALUES (@IMAGE);
		END
		IF @IMAGE_TYPE = 3
		BEGIN
			INSERT INTO CP_BINARY_IMAGES WITH(ROWLOCK) (BINARY_IMAGE_WP) VALUES (@IMAGE);
		END
		IF @IMAGE_TYPE = 4
		BEGIN
			INSERT INTO CP_BINARY_IMAGES WITH(ROWLOCK) (BINARY_IMAGE_ICON) VALUES (@IMAGE);
		END
	END

END
ELSE
BEGIN

	IF EXISTS(SELECT BINARY_IMAGE_ID FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT = @CL_CODE)
	BEGIN
		--SELECT 'UPDATE CLIENT RECORD'
		IF @IMAGE_TYPE = 0
		BEGIN
			UPDATE CP_BINARY_IMAGES WITH(ROWLOCK) SET BINARY_IMAGE_LOGO = @IMAGE WHERE BINARY_IMAGE_CLIENT = @CL_CODE;
		END
		IF @IMAGE_TYPE = 3
		BEGIN
			UPDATE CP_BINARY_IMAGES WITH(ROWLOCK) SET BINARY_IMAGE_WP = @IMAGE WHERE BINARY_IMAGE_CLIENT = @CL_CODE;
		END
		IF @IMAGE_TYPE = 4
		BEGIN
			UPDATE CP_BINARY_IMAGES WITH(ROWLOCK) SET BINARY_IMAGE_ICON = @IMAGE WHERE BINARY_IMAGE_CLIENT = @CL_CODE;
		END
	END
	ELSE
	BEGIN
		--SELECT 'INSERT CLIENT RECORD'
		IF @IMAGE_TYPE = 0
		BEGIN
			INSERT INTO CP_BINARY_IMAGES WITH(ROWLOCK) (BINARY_IMAGE_CLIENT, BINARY_IMAGE_LOGO) VALUES (@CL_CODE, @IMAGE);
		END
		IF @IMAGE_TYPE = 3
		BEGIN
			INSERT INTO CP_BINARY_IMAGES WITH(ROWLOCK) (BINARY_IMAGE_CLIENT, BINARY_IMAGE_WP) VALUES (@CL_CODE, @IMAGE);
		END
		IF @IMAGE_TYPE = 4
		BEGIN
			INSERT INTO CP_BINARY_IMAGES WITH(ROWLOCK) (BINARY_IMAGE_CLIENT, BINARY_IMAGE_ICON) VALUES (@CL_CODE, @IMAGE);
		END
	END

END
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO