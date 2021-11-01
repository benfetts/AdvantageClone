




CREATE PROCEDURE [dbo].[usp_cp_userCDP_delete]
	@CDPCode int
	--@ClientCode varchar(6),
	--@DivisionCode varchar(6),
	--@ProductCode varchar(6)

AS

DELETE FROM [dbo].[CP_SEC_CLIENT] 
	WHERE
	[CDP_CONTACT_ID] = @CDPCode --AND [CL_CODE] = @ClientCode AND [DIV_CODE] = @DivisionCode AND [PRD_CODE] = @ProductCode



















