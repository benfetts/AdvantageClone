IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[advsp_sec_pwd_lock_clear]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_sec_pwd_lock_clear]
GO
CREATE PROCEDURE [dbo].[advsp_sec_pwd_lock_clear]
@USER_CODE VARCHAR(100)
AS
/*=========== QUERY ===========*/
BEGIN

	UPDATE 
		SEC_PWD_LOCK SET ATTEMPTS = 0, 
		LOCK_DATE = NULL 
	WHERE 
		USER_CODE = @USER_CODE;

END
/*=========== QUERY ===========*/
