CREATE PROCEDURE [dbo].[advsp_journal_entry_import_select_details]
	@ImportID int
AS
	
SELECT
	[ID] = D.ID,
	[ImportID] = D.IMPORT_ID,
	[IDSequence] = D.IDSEQ,
	[GLACode] = D.GLACODE,
	[Amount] = D.AMOUNT,
	[Remark] = D.REMARK,
	[ClientCode] = D.CL_CODE,
	[DivisionCode] = D.DIV_CODE,
	[ProductCode] = D.PRD_CODE 
FROM dbo.IMP_JE_DETAIL D
WHERE D.IMPORT_ID = @ImportID
GO
