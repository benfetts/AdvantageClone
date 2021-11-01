﻿

CREATE PROCEDURE [dbo].[usp_wv_SaveCPImageSettings]
	@BINARY_IMAGE_CLIENT varchar(6),
	@BINARY_IMAGE_LOGO image,
	@BINARY_IMAGE_WP image,
	@BINARY_IMAGE_WV_WP varchar(100),
	@BINARY_IMAGE_WV_SC varchar(10),
	@BINARY_IMAGE_WV_THEME varchar(20),
	@BINARY_BACKGROUND varchar(20)
AS

IF EXISTS (
           SELECT *
           FROM   CP_BINARY_IMAGES WITH(NOLOCK)
           WHERE  BINARY_IMAGE_CLIENT = @BINARY_IMAGE_CLIENT
       )
		BEGIN
			--UPDATE
			UPDATE CP_BINARY_IMAGES
			SET    BINARY_IMAGE_LOGO = @BINARY_IMAGE_LOGO, BINARY_IMAGE_WP = @BINARY_IMAGE_WP, BINARY_IMAGE_WV_WP = @BINARY_IMAGE_WV_WP, BINARY_IMAGE_WV_SC = @BINARY_IMAGE_WV_SC,
				   BINARY_IMAGE_WV_THEME = @BINARY_IMAGE_WV_THEME, BINARY_BACKGROUND = @BINARY_BACKGROUND
			WHERE  BINARY_IMAGE_CLIENT = @BINARY_IMAGE_CLIENT;
		END
    ELSE
		BEGIN
			--INSERT
			INSERT INTO CP_BINARY_IMAGES
			  (
				BINARY_IMAGE_CLIENT,
				BINARY_IMAGE_LOGO,
				BINARY_IMAGE_WP,
				BINARY_IMAGE_WV_WP,
				BINARY_IMAGE_WV_SC,
				BINARY_IMAGE_WV_THEME,
				BINARY_BACKGROUND
			  )
			VALUES
			  (
				@BINARY_IMAGE_CLIENT,
				@BINARY_IMAGE_LOGO,
				@BINARY_IMAGE_WP,
				@BINARY_IMAGE_WV_WP,
				@BINARY_IMAGE_WV_SC,
				@BINARY_IMAGE_WV_THEME,
				@BINARY_BACKGROUND
			  );
		END

