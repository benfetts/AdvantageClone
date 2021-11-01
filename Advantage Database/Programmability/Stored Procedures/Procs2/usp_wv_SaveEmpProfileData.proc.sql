

CREATE PROCEDURE [dbo].[usp_wv_SaveEmpProfileData]
	@EmpCode varchar(6),
	@Picture image,
	@Nickname varchar(10),
	@Wallpaper image
AS

INSERT INTO [dbo].[EMPLOYEE_PICTURE] (
			[EMP_CODE]
           ,[EMP_IMAGE]
		   ,[EMP_NICKNAME]
		   ,[EMP_WALLPAPER]
) 
VALUES (
	@EmpCode,
	@Picture,
	@Nickname,
	@Wallpaper
)


