CREATE PROCEDURE [dbo].[advsp_gl_import_batch_report]
	@batch_date smalldatetime,
	@user_code varchar(100),
	@glsource_codes varchar(max)
AS

SELECT
	[BatchDate] = H.BATCH_DATE,
	[TransactionDate] = H.GLEHENTDATE,
	[PostPeriod] = H.GLEHPP,
	[TransactionID] = H.GLEHXACT,
	[IDSeq] = D.GLETSEQ,
	[Description] = H.GLEHDESC,
	[GLAccount] = D.GLETCODE,
	[Debit] = CAST(CASE WHEN GLETAMT > 0 THEN GLETAMT ELSE 0 END AS decimal(28,2)),
	[Credit] = CAST(CASE WHEN GLETAMT < 0 THEN GLETAMT ELSE 0 END AS decimal(28,2)),
	[Remark] = D.GLETREM,
	[Client] = D.CL_CODE,
	[Division] = D.DIV_CODE,
	[Product] = D.PRD_CODE,
	[UserID] = H.GLEHUSER
FROM dbo.GLENTHDR H
	INNER JOIN dbo.GLENTTRL D ON H.GLEHXACT = D.GLETXACT 
WHERE
	UPPER(H.GLEHUSER) = UPPER(@user_code)
AND H.GLEHSOURCE IN (SELECT * FROM dbo.udf_split_list(@glsource_codes, '|'))
AND H.BATCH_DATE = @batch_date 
GO
