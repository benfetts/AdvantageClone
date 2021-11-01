CREATE PROCEDURE [dbo].[advsp_journal_entry_report_load]
	@GLTransaction int
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		[GLTransaction] = GLT.GLEHXACT, 
		[GLTransactionDescription] = GLT.GLEHDESC,   
		[PostPeriodCode] = PP.PPPERIOD,
		[PostPeriodDescription] = PP.PPDESC, 
		[TransactionDate] = GLT.GLEHENTDATE,
		[CreatedByUserCode] = GLT.GLEHUSER, 
		[ControlAmount] = GTA.TotalAmount,  
		[GLSourceCode] = GLT.GLEHSOURCE,  
		[GLSourceDescription] = GLS.GLSRDESC,  
		[PostedToSummary] = GLT.GLEHPOSTSUM,
		[Reversing] = CASE WHEN GLT.GLEHREVENTRY = 1 THEN 'Yes' ELSE 'No' END,
		[SequenceNumber] = GLTD.GLETSEQ, 
		[GLACode] = GLA.GLACODE,   
		[GLAccountDescription] = GLA.GLADESC, 
		[Amount] = GLTD.GLETAMT,
		[Debit] = CASE WHEN GLTD.GLETAMT < 0 THEN NULL ELSE GLTD.GLETAMT END,
		[Credit] = CASE WHEN GLTD.GLETAMT < 0 THEN GLTD.GLETAMT ELSE NULL END,  
		[ClientCode] = GLTD.CL_CODE,   
		[DivisionCode] = GLTD.DIV_CODE,   
		[ProductCode] = GLTD.PRD_CODE,
		[Remark] = GLTD.GLETREM
	FROM 
		[dbo].[GLENTHDR] AS GLT 
		INNER JOIN [dbo].[GLENTTRL] AS GLTD ON GLTD.GLETXACT = GLT.GLEHXACT
		INNER JOIN (SELECT 
							GLETXACT,
							TotalAmount = SUM(CASE WHEN GLETAMT >= 0 THEN GLETAMT ELSE 0 END) 
						FROM 
							[dbo].[GLENTTRL]
						GROUP BY
							GLETXACT) AS GTA ON GTA.GLETXACT = GLT.GLEHXACT
		INNER JOIN [dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLTD.GLETCODE 
		INNER JOIN [dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = GLT.GLEHPP   
		LEFT OUTER JOIN [dbo].[GLSOURCE] AS GLS ON GLS.GLSRCODE = GLT.GLEHSOURCE 
	WHERE
		GLT.GLEHXACT = @GLTransaction 

END
GO