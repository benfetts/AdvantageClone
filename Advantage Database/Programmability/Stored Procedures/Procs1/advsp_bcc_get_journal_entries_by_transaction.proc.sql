CREATE PROCEDURE [dbo].[advsp_bcc_get_journal_entries_by_transaction] @GLTransactionList varchar(max)

AS

SELECT
	[GLTransaction] = glt.GLETXACT,
	[GLSequenceNumber] = glt.GLETSEQ,
	[GLACode] = glt.GLETCODE,
	[GLDescription] = gla.GLADESC,
	[PostPeriodCode] = glh.GLEHPP,
	[Amount] = glt.GLETAMT,
	[Remark] = glt.GLETREM,
	[ClientCode] = glt.CL_CODE,
	[DivisionCode] = glt.DIV_CODE,
	[ProductCode] = glt.PRD_CODE
FROM dbo.GLENTTRL glt
	INNER JOIN dbo.GLENTHDR glh ON glh.GLEHXACT = glt.GLETXACT
	LEFT OUTER JOIN dbo.GLACCOUNT gla ON glt.GLETCODE = gla.GLACODE
WHERE glt.GLETXACT IN (SELECT * FROM dbo.udf_split_list(@GLTransactionList, ','))
ORDER BY 1, 2
GO
