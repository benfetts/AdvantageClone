 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_validate_office_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_validate_office_all]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[usp_wv_validate_office_all] 
@OfficeCode as VarChar(6),
@USER_ID VARCHAR(100)

AS

	SET NOCOUNT ON

	DECLARE @ROffice        AS INT
	DECLARE @ReturnMessage  AS VARCHAR(256)
		
	DECLARE @EMP_CODE       AS VARCHAR(6)
	SELECT @EMP_CODE = EMP_CODE
	FROM   SEC_USER WITH(NOLOCK)
	WHERE  UPPER(USER_CODE) = UPPER(@USER_ID);

	DECLARE @COUNT AS INT
	SELECT @COUNT = ISNULL(COUNT(*), 0)
	FROM   EMP_OFFICE WITH(NOLOCK)
	WHERE  EMP_CODE = @EMP_CODE;

	IF @COUNT = 0
	BEGIN
		IF EXISTS(
			   SELECT OFFICE_CODE
			   FROM   OFFICE
			   WHERE  OFFICE_CODE = @OfficeCode
		   )
			SET @ROffice = 1
		ELSE
			SET @ROffice = 0
	END
	ELSE
	BEGIN
		IF EXISTS(
			   SELECT OFFICE.OFFICE_CODE
			   FROM   OFFICE WITH(NOLOCK)
					  INNER JOIN EMP_OFFICE WITH(NOLOCK)
						   ON  OFFICE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
							   AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			   WHERE  OFFICE.OFFICE_CODE = @OfficeCode
		   )
			SET @ROffice = 1
		ELSE
			SET @ROffice = 0
	END




		 
	IF @ROffice = 1
		SET @ReturnMessage = 'Valid'
	ELSE
		SET @ReturnMessage = 'Invalid'


	SELECT @ReturnMessage






GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 