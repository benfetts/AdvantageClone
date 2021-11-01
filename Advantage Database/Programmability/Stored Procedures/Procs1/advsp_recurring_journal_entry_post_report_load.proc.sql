CREATE PROCEDURE [dbo].[advsp_recurring_journal_entry_post_report_load]
	@PostPeriodCode varchar(6),
	@CycleCode varchar(6)
AS
BEGIN

	SET NOCOUNT ON

	SELECT    
		[CycleCode] = C.CYCODE,
		[CycleDescription] = C.CYNAME, 
		[PostPeriodCode] = GLT.GLEHPP,
		[ControlNumber] = RJE.GLRHCNTRL, 
		[GLTransaction] = GLT.GLEHXACT, 
		[GLTransactionDescription] = GLT.GLEHDESC, 
		[TransactionDate] = GLT.GLEHENTDATE, 
		[ControlAmount] = GTA.TotalAmount,  
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
		INNER JOIN [dbo].[GLRJELOG] AS RJEL ON RJEL.GLEHXACT = GLT.GLEHXACT
		INNER JOIN [dbo].[GLRJEHDR] AS RJE ON RJE.GLRHCNTRL = RJEL.GLRLCNTRL
		INNER JOIN [dbo].[CYCLE] AS C ON C.CYCODE = RJE.GLRHCYCLE
	WHERE
		GLT.GLEHSOURCE = 'RJ' AND
		GLT.GLEHPP = @PostPeriodCode AND
		RJE.GLRHCYCLE = @CycleCode 

END
GO