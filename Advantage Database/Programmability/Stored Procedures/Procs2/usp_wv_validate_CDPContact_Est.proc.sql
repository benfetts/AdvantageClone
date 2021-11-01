
CREATE PROCEDURE [dbo].[usp_wv_validate_CDPContact_Est]
@CDPContactID INT,
@UserCode VARCHAR(100)	

AS
DECLARE @ThisReturn INT,@Restricted INT

SELECT @Restricted = Count(*) FROM SEC_CLIENT WITH (NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserCode) 

--Structure setup, but for now security restriction is not in effect.
--Only validate that the CDPContactCode Exists

--Restrict by client:
IF @Restricted > 0
    BEGIN
        SELECT 
            @ThisReturn = COUNT(*)
        FROM         
            CDP_CONTACT_HDR WITH(NOLOCK)
        WHERE     
            (CDP_CONTACT_ID = @CDPContactID) AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
    END
ELSE
    BEGIN
        SELECT 
            @ThisReturn = COUNT(*)
        FROM         
            CDP_CONTACT_HDR WITH(NOLOCK)
        WHERE     
            (CDP_CONTACT_ID = @CDPContactID) AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
    END

SELECT ISNULL(@ThisReturn,0)

