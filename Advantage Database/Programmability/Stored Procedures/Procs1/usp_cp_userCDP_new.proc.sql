

CREATE PROCEDURE [dbo].[usp_cp_userCDP_new]
	@CDPCode int,
	@ClientCode varchar(6),
	@DivisionCode varchar(6),
	@ProductCode varchar(6)
AS

INSERT INTO [dbo].[CP_SEC_CLIENT] (
			[CDP_CONTACT_ID]
           ,[CL_CODE]
           ,[DIV_CODE]
           ,[PRD_CODE]
) 
VALUES (
	@CDPCode,
	@ClientCode,
	@DivisionCode,
	@ProductCode
)


