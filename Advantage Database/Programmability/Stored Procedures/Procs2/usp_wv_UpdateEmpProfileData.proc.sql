

CREATE PROCEDURE [dbo].[usp_wv_UpdateEmpProfileData]
	@ID int,
	@Picture image,
	@Nickname varchar(10),
	@Wallpaper image
AS

UPDATE [dbo].[EMPLOYEE_PICTURE] SET
			[EMP_IMAGE] = @Picture,
			[EMP_NICKNAME] = @Nickname,
			[EMP_WALLPAPER] = @Wallpaper
WHERE
	[EMP_PICTURE_ID] = @ID


