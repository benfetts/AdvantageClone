CREATE PROCEDURE [dbo].[advsp_recurring_journal_entry_report_load]
	@ControlNumber int
AS
BEGIN

	SET NOCOUNT ON

	SELECT 
		[ControlNumber] = GLT.GLRHCNTRL, 
		[Description] = GLT.GLRHDESC,    
		[ControlAmount] = GTA.TotalAmount, 
		[CycleCode] = C.CYCODE,
		[CycleDescription] = C.CYNAME, 
		[CreatedByUserCode] = GLT.GLRHUSER,
		[LastPostPeriodCode] = GLT.GLRHLASTPP,
		[LastPostingDate] = GLT.GLRHLASTDATE,
		[LastPostingUserCode] = GLT.GLRHLASTBY,
		[TotalNumberOfPostings] = ISNULL(GLRT.TotalPostings, 0),
		[StartingPostPeriodCode] = GLT.STARTING_PPPERIOD,
		[NumberOfPostings] = CASE WHEN GLT.UNLIMITED_POSTINGS = 1 THEN 'Unlimited' ELSE CAST(ISNULL(GLT.NUMBER_OF_POSTINGS, 0) AS varchar(10)) END ,
		[Reversing] = CASE WHEN GLT.GLRHREVFLAG = '1' THEN 'Yes' ELSE 'No' END,
		[SequenceNumber] = GLTD.GLRTSEQ, 
		[GLACode] = GLA.GLACODE,   
		[GLAccountDescription] = GLA.GLADESC, 
		[Amount] = GLTD.GLRTAMT,
		[Debit] = CASE WHEN GLTD.GLRTAMT < 0 THEN NULL ELSE GLTD.GLRTAMT END,
		[Credit] = CASE WHEN GLTD.GLRTAMT < 0 THEN GLTD.GLRTAMT ELSE NULL END,  
		[ClientCode] = GLTD.CL_CODE,   
		[DivisionCode] = GLTD.DIV_CODE,   
		[ProductCode] = GLTD.PRD_CODE,
		[Remark] = GLTD.GLRTREM
	FROM 
		[dbo].[GLRJEHDR] AS GLT 
		INNER JOIN [dbo].[GLRJETRL] AS GLTD ON GLTD.GLRTCNTRL = GLT.GLRHCNTRL
		INNER JOIN (SELECT 
							GLRTCNTRL,
							TotalAmount = SUM(CASE WHEN GLRTAMT >= 0 THEN GLRTAMT ELSE 0 END) 
						FROM 
							[dbo].[GLRJETRL]
						GROUP BY
							GLRTCNTRL) AS GTA ON GTA.GLRTCNTRL = GLT.GLRHCNTRL
		LEFT OUTER JOIN (SELECT 
							GLRLCNTRL,
							TotalPostings = COUNT(*)
						FROM 
							[dbo].[GLRJELOG]
						GROUP BY
							GLRLCNTRL) AS GLRT ON GLRT.GLRLCNTRL = GLT.GLRHCNTRL
		INNER JOIN [dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLTD.GLRTCODE
		LEFT OUTER JOIN [dbo].[POSTPERIOD] AS LPP ON LPP.PPPERIOD = GLT.GLRHLASTPP  
		LEFT OUTER JOIN [dbo].[POSTPERIOD] AS SPP ON SPP.PPPERIOD = GLT.STARTING_PPPERIOD 
		INNER JOIN [dbo].[CYCLE] AS C ON C.CYCODE = GLT.GLRHCYCLE
	WHERE
		GLT.GLRHCNTRL = @ControlNumber 

END
GO