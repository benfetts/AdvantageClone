IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[advsp_write_offs]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_write_offs]
GO

CREATE PROCEDURE [dbo].[advsp_write_offs]
AS
SET NOCOUNT ON

-- ============================================================================
-- advsp_write_offs
-- #00 02/24/14 - v660 initial
-- ============================================================================

--Main data table
CREATE TABLE #write_offs( 
	WriteoffType				varchar(2) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OfficeCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OfficeName					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ClientCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ClientName					varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionCode				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	DivisionName				varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductCode					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	ProductDescription			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,	
	JobNumber					integer NULL,	
	JobDescription				varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	JobComponentNumber				smallint NULL,
	ComponentDescription		varchar(60) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VendorEmployeeCode			varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VendorEmployeeName			varchar(40) COLLATE SQL_Latin1_General_CP1_CS_AS,
	VendorEmployeeDate			datetime NULL,
	PostPeriod					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	OOPWriteoff					decimal(15,2) NULL, 
	HoursMarkup					decimal(15,2) NULL, 
	HoursMarkdown				decimal(15,2) NULL)

-- AP production writeoff amounts
INSERT INTO #write_offs
SELECT
	'AP',
	j.OFFICE_CODE,
	o.OFFICE_NAME,
	j.CL_CODE,
	c.CL_NAME,
	j.DIV_CODE,
	d.DIV_NAME,
	j.PRD_CODE,
	p.PRD_DESCRIPTION,
	a.JOB_NUMBER,
	j.JOB_DESC,
	a.JOB_COMPONENT_NBR,
	jc.JOB_COMP_DESC,
	h.VN_FRL_EMP_CODE,
	v.VN_NAME,
	h.AP_INV_DATE,
	a.POST_PERIOD,
	a.LINE_TOTAL * -1,
	0,
	0
FROM dbo.AP_HEADER AS h
JOIN dbo.AP_PRODUCTION AS a
	ON h.AP_ID = a.AP_ID
JOIN dbo.JOB_LOG AS j
	ON a.JOB_NUMBER =j.JOB_NUMBER
JOIN dbo.JOB_COMPONENT AS jc
	ON a.JOB_NUMBER =jc.JOB_NUMBER
	AND a.JOB_COMPONENT_NBR =jc.JOB_COMPONENT_NBR	
JOIN dbo.OFFICE AS o
	ON j.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.CLIENT AS c
	ON j.CL_CODE = c.CL_CODE
JOIN dbo.DIVISION AS d
	ON j.CL_CODE = d.CL_CODE
	AND j.DIV_CODE = d.DIV_CODE	
JOIN dbo.PRODUCT AS p
	ON j.CL_CODE = p.CL_CODE
	AND j.DIV_CODE = p.DIV_CODE	
	AND j.PRD_CODE = p.PRD_CODE
JOIN dbo.VENDOR AS v
	ON h.VN_FRL_EMP_CODE = v.VN_CODE	
WHERE ISNULL(a.WRITE_OFF,0) <> 0
--SELECT * FROM #write_offs

-- Employee time writeoff amounts
INSERT INTO #write_offs
SELECT
	'ET',
	j.OFFICE_CODE,
	o.OFFICE_NAME,
	j.CL_CODE,
	c.CL_NAME,
	j.DIV_CODE,
	d.DIV_NAME,
	j.PRD_CODE,
	p.PRD_DESCRIPTION,
	a.JOB_NUMBER,
	j.JOB_DESC,
	a.JOB_COMPONENT_NBR,
	jc.JOB_COMP_DESC,
	h.EMP_CODE,
	dbo.advfn_get_emp_name(h.EMP_CODE, 'FML'),	
	h.EMP_DATE,
	dbo.advfn_date_to_post_period(h.EMP_DATE),
	0,
	CASE 
		WHEN a.EXT_MARKUP_AMT > 0 THEN a.EXT_MARKUP_AMT
		ELSE 0
	END,	
	CASE 
		WHEN a.EXT_MARKUP_AMT < 0 THEN a.EXT_MARKUP_AMT
		ELSE 0
	END
FROM dbo.EMP_TIME AS h
JOIN dbo.EMP_TIME_DTL AS a
	ON h.ET_ID = a.ET_ID
JOIN dbo.JOB_LOG AS j
	ON a.JOB_NUMBER =j.JOB_NUMBER
JOIN dbo.JOB_COMPONENT AS jc
	ON a.JOB_NUMBER =jc.JOB_NUMBER
	AND a.JOB_COMPONENT_NBR =jc.JOB_COMPONENT_NBR	
JOIN dbo.OFFICE AS o
	ON j.OFFICE_CODE = o.OFFICE_CODE
JOIN dbo.CLIENT AS c
	ON j.CL_CODE = c.CL_CODE
JOIN dbo.DIVISION AS d
	ON j.CL_CODE = d.CL_CODE
	AND j.DIV_CODE = d.DIV_CODE	
JOIN dbo.PRODUCT AS p
	ON j.CL_CODE = p.CL_CODE
	AND j.DIV_CODE = p.DIV_CODE	
	AND j.PRD_CODE = p.PRD_CODE
JOIN dbo.EMPLOYEE AS v
	ON h.EMP_CODE = v.EMP_CODE	
WHERE ISNULL(a.EXT_MARKUP_AMT,0) <> 0


SELECT * FROM #write_offs

end_tran:

--SELECT * FROM #write_offs

DROP TABLE #write_offs
GO


