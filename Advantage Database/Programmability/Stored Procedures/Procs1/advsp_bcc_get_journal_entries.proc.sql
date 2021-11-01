CREATE PROCEDURE [dbo].[advsp_bcc_get_journal_entries] @bill_user_in varchar(100)

AS

SET NOCOUNT ON

SELECT DISTINCT 
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
FROM dbo.AR_SUMMARY ars 
	INNER JOIN dbo.BILLING b ON ( b.BILLING_USER = @bill_user_in ) AND ( b.INV_ASSIGN = 1 )
	INNER JOIN dbo.GLENTHDR glh ON ( ars.GL_XACT = glh.GLEHXACT OR ars.GL_XACT_DEF = glh.GLEHXACT )
	INNER JOIN dbo.GLENTTRL glt ON ( glh.GLEHXACT = glt.GLETXACT )
	LEFT OUTER JOIN dbo.GLACCOUNT gla ON ( glt.GLETCODE = gla.GLACODE )		 
WHERE
	( ars.AR_INV_NBR BETWEEN b.FIRST_INV AND b.LAST_INV )
AND ( ars.AR_TYPE = 'IN' )
ORDER BY
	glt.GLETXACT, glt.GLETSEQ

GO
