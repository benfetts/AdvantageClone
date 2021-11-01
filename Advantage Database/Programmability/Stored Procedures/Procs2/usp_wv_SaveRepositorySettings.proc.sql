
CREATE PROCEDURE [dbo].[usp_wv_SaveRepositorySettings] 
	-- Add the parameters for the stored procedure here
	@DOC_PATH varchar(100),
	@USER_DOMAIN varchar(100),
	@USER_NAME varchar(100),
	@USER_PASSWORD varchar(100)
AS
/*=========== QUERY ===========*/
	UPDATE AGENCY 
	SET DOC_REPOSITORY_PATH = @DOC_PATH,
		DOC_REPOSITORY_USER_DOMAIN = @USER_DOMAIN,
		DOC_REPOSITORY_USER_NAME = @USER_NAME,
		DOC_REPOSITORY_USER_PASSWORD = @USER_PASSWORD
/*=========== QUERY ===========*/
