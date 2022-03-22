--recreate GL Cross Office data

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_PADDING OFF
GO 
IF EXISTS (Select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_gl_cross_office]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_gl_cross_office]

GO

CREATE PROCEDURE [dbo].[advsp_gl_cross_office] (
	--Add parameter list including @VariableName, Type and Default Value or NULL, i.e.:
	@start_period	varchar(6) = '190001',
	@end_period		varchar(6) = '290012',
    @UserID varchar(100)
	)

AS
BEGIN
SET NOCOUNT ON;

--============
--MAIN TABLE
--============
CREATE TABLE #GLCrossOfficeTransactions (
	GLYear					varchar(5)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLPeriod				varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	OfficeCode				varchar(4)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	OfficeName				varchar(30)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	ClientCode				varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	ClientName				varchar(40)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionCode			varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionName			varchar(40)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductCode				varchar(6)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductDescription		varchar(40)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLXact					int NOT NULL,
	GLSeq					smallint NOT NULL,
	GLAccountCode			varchar(30)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLAccountDescription	varchar(75)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLSource				varchar(2)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLRemark				varchar(150)	COLLATE SQL_Latin1_General_CP1_CS_AS,
	GLAmount				decimal(18,2)
	)

--Get multiple offices transactions list as #TransactionsList
CREATE TABLE #TransactionsByOffice (
	GLETXACT				int NOT NULL,
	GLAOFFICE				varchar(4)		COLLATE SQL_Latin1_General_CP1_CS_AS,
	SUMGLETFCAMT			decimal(18,2)
	)
INSERT INTO #TransactionsByOffice
SELECT
	d.GLETXACT,
	a.GLAOFFICE,
	SUM(ISNULL(d.GLETFCAMT,0))
FROM dbo.GLENTTRL AS d
JOIN dbo.GLENTHDR AS h ON h.GLEHXACT = d.GLETXACT
JOIN dbo.GLACCOUNT AS a ON a.GLACODE = d.GLETCODE
WHERE h.GLEHPP BETWEEN @Start_Period AND @End_Period
GROUP BY d.GLETXACT, GLAOFFICE
HAVING ABS(SUM(ISNULL(d.GLETFCAMT,0))) > 0

CREATE TABLE #TransactionList (
	GLETXACT				int NOT NULL,
	COUNTGLAOFFICE			varchar(4)		COLLATE SQL_Latin1_General_CP1_CS_AS
	)
INSERT INTO #TransactionList
SELECT
	t.GLETXACT,
	COUNT(t.GLAOFFICE)
FROM #TransactionsByOffice AS t
GROUP BY t.GLETXACT
HAVING COUNT(t.GLAOFFICE) > 1
--SELECT * FROM #TransactionList

INSERT INTO #GLCrossOfficeTransactions
SELECT
	p.PPGLYEAR,
	h.GLEHPP,
	a.GLAOFFICE,
	o.OFFICE_NAME,
	d.CL_CODE,
	cl.CL_NAME,
	d.DIV_CODE,
	dv.DIV_NAME,
	d.PRD_CODE,
	pr.PRD_DESCRIPTION,
	d.GLETXACT,
	d.GLETSEQ,
	d.GLETCODE,
	a.GLADESC,
	d.GLETSOURCE,
	d.GLETREM,
	ISNULL(d.GLETAMT,0)
FROM dbo.GLENTHDR AS h
JOIN #TransactionList AS t ON t.GLETXACT = h.GLEHXACT
JOIN dbo.POSTPERIOD AS p ON p.PPPERIOD = h.GLEHPP
JOIN dbo.GLENTTRL AS d ON d.GLETXACT = t.GLETXACT
JOIN dbo.GLACCOUNT AS a ON a.GLACODE = d.GLETCODE
JOIN dbo.GLOXREF AS x ON x.GLOXGLOFFICE = a.GLAOFFICE
JOIN dbo.OFFICE AS o ON o.OFFICE_CODE = x.GLOXOFFICE
LEFT JOIN dbo.CLIENT AS cl ON cl.CL_CODE = d.CL_CODE
LEFT JOIN dbo.DIVISION AS dv ON dv.CL_CODE = d.CL_CODE AND dv.DIV_CODE = d.DIV_CODE
LEFT JOIN dbo.PRODUCT AS pr ON pr.CL_CODE = d.CL_CODE AND pr.DIV_CODE = d.DIV_CODE AND pr.PRD_CODE = d.PRD_CODE

SELECT * FROM #GLCrossOfficeTransactions

END
GO

BEGIN

	GRANT ALL ON [advsp_gl_cross_office] TO PUBLIC AS dbo

END
GO
