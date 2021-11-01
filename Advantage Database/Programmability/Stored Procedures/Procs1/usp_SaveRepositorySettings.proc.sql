

























-- =============================================
-- Author:		Rick Ellenburg
-- Create date: 2/21/2007
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_SaveRepositorySettings] 
	-- Add the parameters for the stored procedure here
	@DOC_PATH varchar(100),
	@USER_DOMAIN varchar(100),
	@USER_NAME varchar(100),
	@USER_PASSWORD varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE AGENCY 
	SET DOC_REPOSITORY_PATH = @DOC_PATH,
		DOC_REPOSITORY_USER_DOMAIN = @USER_DOMAIN,
		DOC_REPOSITORY_USER_NAME = @USER_NAME,
		DOC_REPOSITORY_USER_PASSWORD = @USER_PASSWORD

SELECT     DOC_REPOSITORY_PATH, DOC_REPOSITORY_USER_DOMAIN, DOC_REPOSITORY_USER_NAME, DOC_REPOSITORY_USER_PASSWORD
FROM         dbo.AGENCY
END

























