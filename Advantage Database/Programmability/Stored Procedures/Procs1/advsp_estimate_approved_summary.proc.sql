if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_estimate_approved_summary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_estimate_approved_summary]
GO

set ANSI_NULLS ON
GO

SET ANSI_PADDING OFF
GO

set QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_estimate_approved_summary] @from_date AS datetime = '1/1/1900', 
	@to_date AS datetime = '12/31/2199'

-- advsp_estimate_approved_summary (summarizes by job/component)==========================
-- #00 01/27/14 - initial

AS
BEGIN
	SET NOCOUNT ON;
-- =======================================================================================	
	SELECT 
		j.OFFICE_CODE AS OfficeCode, 
		o.OFFICE_NAME AS OfficeName, 
		j.CL_CODE AS ClientCode, 
		c.CL_NAME AS ClientName, 
		j.DIV_CODE AS DivisionCode, 
		d.DIV_NAME AS DivisionName, 
		j.PRD_CODE AS ProductCode, 
		p.PRD_DESCRIPTION AS ProductDescription, 
		p.USER_DEFINED1 AS ProductUDF1, 
		p.USER_DEFINED2 AS ProductUDF2, 
		p.USER_DEFINED3 AS ProductUDF3, 
		p.USER_DEFINED4 AS ProductUDF4, 
		ea.ESTIMATE_NUMBER AS EstimateNumber, 
		e.EST_LOG_DESC AS EstimateDescription, 
		CAST(e.EST_LOG_COMMENT AS varchar(4000)) AS EstimateComment, 
		ea.EST_COMPONENT_NBR AS EstimateCompNumber, 
		ec.EST_COMP_DESC AS EstimateCompDescription, 
		CAST(ec.EST_COMP_COMMENT AS Varchar(4000)) AS EstimateCompComment, 
		ec.CDP_CONTACT_ID AS EstimateContactID, 
		ch.CONT_CODE AS EstimateContactCode, 
		ch.CONT_FNAME + ' ' + ch.CONT_LNAME AS EstimateContactName, 
		ea.EST_QUOTE_NBR AS QuoteNumber, 
		eq.EST_QUOTE_DESC AS QuoteDescription, 
		CAST(eq.EST_QTE_COMMENT AS varchar(4000)) AS QuoteComment, 
		ea.EST_REVISION_NBR AS RevisionNumber, 
		CAST(er.EST_REV_COMMENT AS varchar(4000)) AS RevisionComment, 
		ea.TYPE AS ApprovalType, 
		--Choose(ea.TYPE,"Internal","Client","Both") AS ApprovalTypeDescription, 
		CASE ea.TYPE
			WHEN 1 THEN 'Internal'
			WHEN 2 THEN 'Client'
			WHEN 1 THEN 'Both'
		END AS ApprovalTypeDescription,	
		ea.CL_EST_APPR_BY AS ClientApprovalName, 
		ea.CL_EST_APPR_DATE AS ClientApprovalDate, 
		ea.IN_EST_APPR_BY AS InternalApprovalName, 
		ea.IN_EST_APPR_DATE AS InternalApprovalDate, 
		ea.JOB_NUMBER AS JobNumber, 
		j.JOB_CLI_REF AS JobClientReference, 
		j.JOB_DESC AS JobDescription, 
		j.CMP_IDENTIFIER AS CampaignID, 
		ca.CMP_CODE AS CampaignCode, 
		ca.CMP_NAME AS CampaignName, 
		j.SC_CODE AS SalesClassCode, 
		sc.SC_DESCRIPTION AS SalesClassDescription, 
		j.CREATE_DATE AS JobCreateDate, 
		j.JOB_DATE_OPENED AS JobDateOpened, 
		ea.JOB_COMPONENT_NBR AS JobCompNumber, 
		jc.JOB_COMP_DESC AS JobCompDescription, 
		jc.EMP_CODE AS AccountExecutiveCode, 
		ae.EMP_FNAME + ' ' + ae.EMP_LNAME AS AccountExecutiveName, 
		jc.JOB_CL_PO_NBR AS JobClientPO, 
		jc.JOB_COMP_DATE AS JobCompDateOpened, 
		jc.JOB_FIRST_USE_DATE AS JobDueDate, 
		jc.START_DATE AS JobStartDate, 
		--Choose([Job_Process_Contrl],"All Processing","No Processing","A/P and Billing","A/P, Time and Billing","Billing Only,
			--"Closed","Time and Billing","A/P, Time, I/O and Billing","A/P, I/O and Billing","I/O and Billing",
			--"Time, I/O and Billing","Archive") AS JobProcessingControl,
		CASE jc.JOB_PROCESS_CONTRL 
			WHEN 1 THEN 'All Processing'
			WHEN 2 THEN 'No Processing'
			WHEN 3 THEN 'A/P and Billing'
			WHEN 4 THEN 'A/P, Time and Billing'
			WHEN 5 THEN 'Billing Only'
			WHEN 6 THEN 'Closed'
			WHEN 7 THEN 'Time and Billing'
			WHEN 8 THEN 'A/P, Time, I/O and Billing'
			WHEN 9 THEN 'A/P, I/O and Billing'
			WHEN 10 THEN 'I/O and Billing'
			WHEN 11 THEN 'Time, I/O and Billing'
			WHEN 12 THEN 'Archive'
		END AS JobProcessingControl, 
-- --------------------------------------------------------------------------------------------	 
		CASE erd.EST_FNC_TYPE
			WHEN 'E' THEN ISNULL(erd.EST_REV_QUANTITY,0)
			ELSE 0
		END AS EstimateHours,	
		--(IIf([EST_FNC_TYPE]<>"E",Nz([EST_REV_QUANTITY],0),0)) AS EstimateQuantity, 
		CASE erd.EST_FNC_TYPE
			WHEN 'E' THEN 0
			ELSE ISNULL(erd.EST_REV_QUANTITY,0)
		END AS EstimateQuantity,	
		SUM(ISNULL(erd.[EST_REV_RATE],0)) AS EstimateRate, 
		SUM(ISNULL(erd.[EST_REV_EXT_AMT],0)) AS EstimateExtAmount,
		SUM(ISNULL(erd.[EXT_NONRESALE_TAX],0)) AS EstimateNonResaleAmount, 
		SUM(ISNULL(erd.[EST_REV_EXT_AMT],0) + ISNULL(erd.[EXT_NONRESALE_TAX],0)) AS EstimateNetAmount, 
		--(IIf([EST_FNC_TYPE] In ("C","V"),Nz([EST_REV_EXT_AMT],0)+Nz([EXT_NONRESALE_TAX],0),0)) AS EstimateCostAmount, 
		CASE erd.EST_FNC_TYPE
			WHEN 'C' THEN SUM(ISNULL(erd.[EST_REV_EXT_AMT],0) + ISNULL(erd.[EXT_NONRESALE_TAX],0))
			WHEN 'V' THEN SUM(ISNULL(erd.[EST_REV_EXT_AMT],0) + ISNULL(erd.[EXT_NONRESALE_TAX],0))
			ELSE 0
		END AS EstimateCostAmount,	
		erd.TAX_CODE AS TaxCode, 
		t.TAX_DESCRIPTION AS TaxCodeDescription, 
		SUM(ISNULL(erd.[EXT_STATE_RESALE],0)) AS EstimateStateAmount, 
		SUM(ISNULL(erd.[EXT_COUNTY_RESALE],0)) AS EstimateCountyAmount, 
		SUM(ISNULL(erd.[EXT_CITY_RESALE],0)) AS EstimateCityAmount, 
		SUM(ISNULL(erd.[EXT_STATE_RESALE],0) + ISNULL(erd.[EXT_COUNTY_RESALE],0) + ISNULL(erd.[EXT_CITY_RESALE],0)) 
			AS EstimateResaleTaxAmount, 
		SUM(ISNULL(erd.[EST_REV_COMM_PCT],0)) AS EstimateMarkupPct, 
		SUM(ISNULL(erd.[EXT_MARKUP_AMT],0)) AS EstimateMarkupAmount, 
		SUM(ISNULL(erd.[LINE_TOTAL],0)) AS EstimateTotalAmount, 
		SUM(ISNULL(erd.[EST_REV_CONT_PCT],0)) AS EstimateContingencyPct, 
		SUM(ISNULL(erd.[LINE_TOTAL_CONT],0)) AS EstimateContingencyAmount, 
		SUM(ISNULL(erd.[LINE_TOTAL],0) + ISNULL(erd.[LINE_TOTAL_CONT],0)) AS EstimateTotalWithContingency
	FROM dbo.V_ESTIMATEAPPR AS ea 
	INNER JOIN dbo.JOB_COMPONENT AS jc 
		ON (ea.JOB_NUMBER = jc.JOB_NUMBER) 
		AND (ea.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR) 
	INNER JOIN dbo.JOB_LOG AS j 
		ON (jc.JOB_NUMBER = j.JOB_NUMBER) 
	INNER JOIN dbo.ESTIMATE_REV_DET AS erd 
		ON (ea.ESTIMATE_NUMBER = erd.ESTIMATE_NUMBER) 
		AND (ea.EST_COMPONENT_NBR = erd.EST_COMPONENT_NBR) 
		AND (ea.EST_QUOTE_NBR = erd.EST_QUOTE_NBR) 
		AND (ea.EST_REVISION_NBR = erd.EST_REV_NBR) 
	INNER JOIN dbo.ESTIMATE_REV AS er 
		ON (erd.ESTIMATE_NUMBER = er.ESTIMATE_NUMBER) 
		AND (erd.EST_COMPONENT_NBR = er.EST_COMPONENT_NBR) 
		AND (erd.EST_QUOTE_NBR = er.EST_QUOTE_NBR) 
		AND (erd.EST_REV_NBR = er.EST_REV_NBR) 
	INNER JOIN dbo.ESTIMATE_QUOTE AS eq 
		ON (er.ESTIMATE_NUMBER = eq.ESTIMATE_NUMBER) 
		AND (er.EST_COMPONENT_NBR = eq.EST_COMPONENT_NBR) 
		AND (er.EST_QUOTE_NBR = eq.EST_QUOTE_NBR) 
	INNER JOIN dbo.ESTIMATE_COMPONENT AS ec 
		ON (eq.ESTIMATE_NUMBER = ec.ESTIMATE_NUMBER) 
		AND (eq.EST_COMPONENT_NBR = ec.EST_COMPONENT_NBR) 
	INNER JOIN dbo.ESTIMATE_LOG AS e 
		ON (ec.ESTIMATE_NUMBER = e.ESTIMATE_NUMBER) 
	INNER JOIN dbo.FUNCTIONS AS f 
		ON (erd.FNC_CODE = f.FNC_CODE) 
	LEFT JOIN dbo.FNC_HEADING AS fh 
		ON (f.FNC_HEADING_ID = fh.FNC_HEADING_ID) 
	INNER JOIN dbo.OFFICE AS o 
		ON (j.OFFICE_CODE = o.OFFICE_CODE) 
	INNER JOIN dbo.PRODUCT AS p 
		ON (j.CL_CODE = p.CL_CODE) 
		AND (j.DIV_CODE = p.DIV_CODE) 
		AND (j.PRD_CODE = p.PRD_CODE) 
	LEFT JOIN dbo.CAMPAIGN AS ca 
		ON (j.CMP_IDENTIFIER = ca.CMP_IDENTIFIER) 
	INNER JOIN dbo.EMPLOYEE AS ae 
		ON (jc.EMP_CODE = ae.EMP_CODE) 
	INNER JOIN dbo.DIVISION AS d 
		ON (j.CL_CODE = d.CL_CODE) 
		AND (j.DIV_CODE = d.DIV_CODE) 
	INNER JOIN dbo.CLIENT AS c 
		ON (j.CL_CODE = c.CL_CODE) 
	INNER JOIN dbo.SALES_CLASS AS sc 
		ON (j.SC_CODE = sc.SC_CODE) 
	LEFT JOIN dbo.CDP_CONTACT_HDR AS ch 
		ON (ec.CDP_CONTACT_ID = ch.CDP_CONTACT_ID) 
	LEFT JOIN dbo.VENDOR AS sv 
		ON (erd.EST_REV_SUP_BY_CDE = sv.VN_CODE) 
	LEFT JOIN dbo.EMPLOYEE AS se 
		ON (erd.EST_REV_SUP_BY_CDE = se.EMP_CODE) 
	LEFT JOIN dbo.SALES_TAX AS t 
		ON (erd.TAX_CODE = t.TAX_CODE)
	GROUP BY 
		j.OFFICE_CODE, 
		o.OFFICE_NAME, 
		j.CL_CODE, 
		c.CL_NAME, 
		j.DIV_CODE, 
		d.DIV_NAME, 
		j.PRD_CODE, 
		p.PRD_DESCRIPTION, 
		p.USER_DEFINED1, 
		p.USER_DEFINED2, 
		p.USER_DEFINED3, 
		p.USER_DEFINED4, 
		ea.ESTIMATE_NUMBER, 
		e.EST_LOG_DESC, 
		CAST(e.EST_LOG_COMMENT AS varchar(4000)), 
		ea.EST_COMPONENT_NBR, 
		ec.EST_COMP_DESC, 
		CAST(ec.EST_COMP_COMMENT AS Varchar(4000)), 
		ec.CDP_CONTACT_ID, 	
		ch.CONT_CODE, 
		ch.CONT_FNAME + ' ' + ch.CONT_LNAME, 
		ea.EST_QUOTE_NBR, 
		eq.EST_QUOTE_DESC, 
		CAST(eq.EST_QTE_COMMENT AS varchar(4000)), 
		ea.EST_REVISION_NBR, 
		CAST(er.EST_REV_COMMENT AS varchar(4000)), 
		ea.[TYPE], 
		--Choose(ea.TYPE,"Internal","Client","Both"), 
		ea.CL_EST_APPR_BY, 
		ea.CL_EST_APPR_DATE, 
		ea.IN_EST_APPR_BY, 
		ea.IN_EST_APPR_DATE, 
		ea.JOB_NUMBER, 
		j.JOB_CLI_REF, 
		j.JOB_DESC, 
		j.CMP_IDENTIFIER, 
		ca.CMP_CODE, 
		ca.CMP_NAME, 
		j.SC_CODE, 
		sc.SC_DESCRIPTION, 
		j.CREATE_DATE, 
		j.JOB_DATE_OPENED, 
		ea.JOB_COMPONENT_NBR, 
		jc.JOB_COMP_DESC, 
		jc.EMP_CODE, 
		ae.EMP_FNAME + ' ' + ae.EMP_LNAME, 
		jc.JOB_CL_PO_NBR, 
		jc.JOB_COMP_DATE, 
		jc.JOB_FIRST_USE_DATE, 
		jc.[START_DATE], 
		--Choose([Job_Process_Contrl],"All Processing","No Processing","A/P and Billing","A/P, Time and Billing","Billing Only",
			--"Closed","Time and Billing","A/P, Time, I/O and Billing","A/P, I/O and Billing","I/O and Billing",
			--"Time, I/O and Billing","Archive"), 	erd.EST_FNC_TYPE, 
		jc.JOB_PROCESS_CONTRL,
-- --------------------------------------------------------------------------------------------
		fh.FNC_HEADING_DESC, 
		erd.FNC_CODE, 
		f.FNC_DESCRIPTION, 
		CAST(erd.EST_FNC_COMMENT AS varchar(4000)), 
		erd.EST_REV_SUP_BY_CDE, 
		--IIf([EST_FNC_TYPE]="E",
		erd.EST_FNC_TYPE,
		erd.EST_REV_QUANTITY,
		se.EMP_FNAME + ' ' + se.EMP_LNAME,
		sv.VN_NAME, 
		CAST(erd.EST_REV_SUP_BY_NTE AS varchar(4000)), 
		--IIf(Nz([EST_NONBILL_FLAG],0)=1,"No","Yes"), 
		erd.EST_NONBILL_FLAG,
		--IIf(Nz([ESTIMATE_REV_DET]![FEE_TIME],0)<>0,"Yes","No"),
		erd.FEE_TIME, 
		ISNULL([EST_REV_RATE],0), 
		erd.TAX_CODE, 
		t.TAX_DESCRIPTION, 
		ISNULL([EST_REV_COMM_PCT],0), 
		ISNULL([EST_REV_CONT_PCT],0)	
	HAVING (ea.CL_EST_APPR_DATE >= @from_date AND ea.CL_EST_APPR_DATE <= @to_date) 
		OR (ea.IN_EST_APPR_DATE >= @from_date AND ea.IN_EST_APPR_DATE <= @to_date)

-- =======================================================================================	

END
GO
