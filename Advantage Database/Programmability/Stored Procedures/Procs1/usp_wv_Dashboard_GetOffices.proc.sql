if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Dashboard_GetOffices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Dashboard_GetOffices]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[usp_wv_Dashboard_GetOffices]
@UserID varchar(100)
AS
Declare @RestrictionsOffice Int, @EmpCode varchar(6)
--SELECT DISTINCT DASH_DATA_EMP_TIME.OFFICE_CODE, OFFICE.OFFICE_NAME
--FROM DASH_DATA LEFT OUTER JOIN
--	 OFFICE ON DASH_DATA.OFFICE_CODE = OFFICE.OFFICE_CODE

Select @EmpCode = EMP_CODE
FROM SEC_USER
WHERE UPPER(USER_CODE) = UPPER(@UserID)

Select @RestrictionsOffice = Count(*) 
FROM EMP_OFFICE
Where EMP_CODE = @EmpCode


if @RestrictionsOffice > 0
    Begin
		SELECT     OFFICE.OFFICE_CODE, OFFICE.OFFICE_NAME
		FROM         OFFICE INNER JOIN EMP_OFFICE ON OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
		WHERE     ((INACTIVE_FLAG IS NULL) OR
							  (INACTIVE_FLAG = 0)) AND EMP_OFFICE.EMP_CODE = @EmpCode
		ORDER BY OFFICE.OFFICE_NAME
    End
Else
	Begin
		SELECT     OFFICE_CODE, OFFICE_NAME
		FROM         OFFICE
		WHERE     (INACTIVE_FLAG IS NULL) OR
							  (INACTIVE_FLAG = 0)
		ORDER BY OFFICE.OFFICE_NAME
	End


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

