




CREATE PROCEDURE [dbo].[usp_cp_userCDP_update]
	@CDPCode int,
	@ClientCode varchar(6),
	@DivisionCode varchar(6),
	@ProductCode varchar(6)
AS

UPDATE [dbo].[CP_SEC_CLIENT] SET
			[CDP_CONTACT_ID] = @CDPCode
           ,[CL_CODE] = @ClientCode
           ,[DIV_CODE] = @DivisionCode
           ,[PRD_CODE] = @ProductCode
WHERE
	[CDP_CONTACT_ID] = @CDPCode



















