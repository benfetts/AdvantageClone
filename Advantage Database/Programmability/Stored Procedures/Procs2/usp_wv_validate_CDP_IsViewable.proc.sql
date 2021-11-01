
CREATE PROCEDURE [dbo].[usp_wv_validate_CDP_IsViewable]
@Level VARCHAR(2),
@ClientCode VARCHAR(6),
@DivisionCode VARCHAR(6),
@ProductCode VARCHAR(6),
@UserID VARCHAR(100),
@FromApp VARCHAR(100)	

AS
DECLARE @ThisReturn INT,@Restricted INT

SELECT @Restricted = Count(*) FROM SEC_CLIENT WITH (NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID)
IF @Restricted <= 0
    BEGIN
        SELECT @ThisReturn = 1
    END
ELSE
    BEGIN
		IF @FromApp = 'ts'
		BEGIN
			IF @Level = 'CL'
				SELECT @ThisReturn = Count(*) 
				FROM SEC_CLIENT WITH (NOLOCK) 
				WHERE UPPER(USER_ID) = UPPER(@UserID) AND CL_CODE = @ClientCode
			IF @Level = 'DI'
				SELECT @ThisReturn = Count(*) 
				FROM SEC_CLIENT WITH (NOLOCK) 
				WHERE UPPER(USER_ID) = UPPER(@UserID) AND CL_CODE = @ClientCode AND DIV_CODE = @DivisionCode
			IF @Level = 'PR'
				SELECT @ThisReturn = Count(*) 
				FROM SEC_CLIENT WITH (NOLOCK) 
				WHERE UPPER(USER_ID) = UPPER(@UserID) AND CL_CODE = @ClientCode AND DIV_CODE = @DivisionCode AND PRD_CODE = @ProductCode
		END
		ELSE
		BEGIN
			IF @Level = 'CL'
				SELECT @ThisReturn = Count(*) 
				FROM SEC_CLIENT WITH (NOLOCK) 
				WHERE UPPER(USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND CL_CODE = @ClientCode
			IF @Level = 'DI'
				SELECT @ThisReturn = Count(*) 
				FROM SEC_CLIENT WITH (NOLOCK) 
				WHERE UPPER(USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND CL_CODE = @ClientCode AND DIV_CODE = @DivisionCode
			IF @Level = 'PR'
				SELECT @ThisReturn = Count(*) 
				FROM SEC_CLIENT WITH (NOLOCK) 
				WHERE UPPER(USER_ID) = UPPER(@UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) AND CL_CODE = @ClientCode AND DIV_CODE = @DivisionCode AND PRD_CODE = @ProductCode
		END
        
    END

SELECT ISNULL(@ThisReturn,0)

