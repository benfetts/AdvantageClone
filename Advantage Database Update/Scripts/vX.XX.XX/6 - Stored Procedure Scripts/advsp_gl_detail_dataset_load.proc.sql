IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_gl_detail_dataset_load]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_gl_detail_dataset_load]
GO

CREATE PROCEDURE [dbo].[advsp_gl_detail_dataset_load]
	@FROM_PPPERIOD varchar(6),
	@TO_PPPERIOD varchar(6),
	@RECORD_SOURCE_ID int,
	@IncludeInactiveAccounts bit
AS
BEGIN

/*
Updated SP - Changed [MappedAccount] to GLACCOUNT_XREF_EXPORT.TARGET_GLACODE
*/

	SET NOCOUNT ON

	SELECT 
		[TransactionID] = GLT.GLEHXACT,
		[TransSeq] = GLTD.GLETSEQ,   
		[AccountCode] = GLA.GLACODE,   
		[AccountDescription] = GLA.GLADESC,   
		[Amount] = GLTD.GLETAMT,
		[AbsoluteAmount] = GLTD.GLETAMT * CASE WHEN GLTD.GLETAMT < 0 THEN -1 ELSE 1 END,
		[DebitOrCredit] = CASE WHEN GLTD.GLETAMT < 0 THEN 'Credit' ELSE 'Debit' END,   
		[Remark] = GLTD.GLETREM,   
		[PostPeriodCode] = PP.PPPERIOD,
		[PostingPeriodEndingDate] = PP.PPENDDATE, 
		[EntryDate] = (SELECT CONVERT(date, GLT.GLEHENTDATE)),  
		[PostedToSummary] = GLT.GLEHPOSTSUM,   
		[ClientCode] = GLTD.CL_CODE,   
		[ClientName] = C.CL_NAME,
		[DivisionCode] = GLTD.DIV_CODE,   
        [DivisionName] = D.DIV_NAME,   
		[ProductCode] = GLTD.PRD_CODE,  
        [ProductName] = PRD.PRD_DESCRIPTION,   
		[Source] = GLTD.GLETSOURCE,   
		[OfficeSegment] = GLA.GLAOFFICE,   
		[BaseAccount] = GLA.GLABASE,   
		[DepartmentSegment] = GLA.GLADEPT,   
		[OtherSegment] = GLA.GLAOTHER,   
		[MappedAccount] = GLAX.SOURCE_GLACODE,
		[TargetAccount] = GLAEX.TARGET_GLACODE,
		[UserID] = GLT.GLEHUSER,
		[ProductUserDefinedField1] = PRD.USER_DEFINED1,
		[ProductUserDefinedField2] = PRD.USER_DEFINED2,
		[ProductUserDefinedField3] = PRD.USER_DEFINED3,
		[ProductUserDefinedField4] = PRD.USER_DEFINED4
	FROM 
		[dbo].[GLENTHDR] AS GLT INNER JOIN 
		[dbo].[GLENTTRL] AS GLTD ON GLTD.GLETXACT = GLT.GLEHXACT INNER JOIN  
		[dbo].[GLACCOUNT] AS GLA ON GLA.GLACODE = GLTD.GLETCODE INNER JOIN
		[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = GLT.GLEHPP LEFT OUTER JOIN
		(SELECT 
		 	GLACODE,
		 	SOURCE_GLACODE
		 FROM 
		 	[dbo].[GLACCOUNT_XREF] 
		 WHERE
		 	GLACCOUNT_XREF_ID IN (SELECT MAX(GLACCOUNT_XREF_ID) FROM [dbo].[GLACCOUNT_XREF] WHERE RECORD_SOURCE_ID = @RECORD_SOURCE_ID GROUP BY GLACODE)) AS GLAX ON GLAX.GLACODE = GLA.GLACODE LEFT OUTER JOIN
		(SELECT
		 	HDR.TARGET_GLACODE,
			DTL.GLACODE
		 FROM
		 	dbo.GLACCOUNT_XREF_EXPORT HDR
		 INNER JOIN
		 	dbo.GLACCOUNT_XREF_EXPORT_DETAIL DTL ON HDR.GLACCOUNT_XREF_EXPORT_ID = DTL.GLACCOUNT_XREF_EXPORT_ID
		 WHERE
			HDR.RECORD_SOURCE_ID = @RECORD_SOURCE_ID) AS GLAEX ON GLA.GLACODE = GLAEX.GLACODE LEFT JOIN
		[dbo].[PRODUCT] AS PRD ON PRD.CL_CODE = GLTD.CL_CODE AND PRD.DIV_CODE = GLTD.DIV_CODE AND PRD.PRD_CODE = GLTD.PRD_CODE LEFT OUTER JOIN
        [dbo].[DIVISION] AS D ON D.CL_CODE = PRD.CL_CODE AND D.DIV_CODE = PRD.DIV_CODE LEFT OUTER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = D.CL_CODE
	WHERE 
		((@IncludeInactiveAccounts = 0  AND GLA.GLAACTIVE = 'A') OR  (@IncludeInactiveAccounts = 1)) AND  
		PP.PPGLMONTH <> 99 AND  
		PP.PPPERIOD BETWEEN @FROM_PPPERIOD AND @TO_PPPERIOD
		
END

GO

GRANT EXECUTE ON [advsp_gl_detail_dataset_load] TO PUBLIC AS dbo
GO