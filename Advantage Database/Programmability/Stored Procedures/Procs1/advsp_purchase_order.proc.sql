if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_purchase_order]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_purchase_order]
GO

set ANSI_NULLS ON
GO

set ANSI_PADDING OFF
GO

set QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_purchase_order]	

-- #00 07/07/14 - initial v6.60.04.00

AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		po.PO_NUMBER AS [PO Number], 
		pod.LINE_NUMBER AS [PO Line Number], 
		v.VN_CODE AS [Vendor Code], 
		v.VN_NAME AS [Vendor Name], 
		v.VN_ADDRESS1 AS [Vendor Address1], 
		v.VN_ADDRESS2 AS [Vendor Address2], 
		v.VN_CITY AS [Vendor City], 
		v.VN_STATE AS [Vendor State], 
		v.VN_ZIP AS [Vendor Zip],
		v.VN_COUNTRY AS [Vendor Country], 
		v.VN_PHONE AS [Vendor Phone],
		v.VN_FAX_NUMBER AS [Vendor Fax],
		po.EMP_CODE AS [Originator Code], 
		e.[EMP_FNAME] + ' ' + e.[EMP_LNAME] AS [Originator Name],
		et.EMPLOYEE_TITLE AS [Originator Title],  
		po.PO_DATE AS [PO Issue Date], 
		po.PO_DUE_DATE AS [PO Due Date], 
		po.PO_DESCRIPTION AS [PO Description], 
		po.PO_MAIN_INSTRUCT AS [PO Instructions], 
		j.CL_CODE AS [Client Code], 
		c.CL_NAME AS [Client Name], 
		j.DIV_CODE AS [Division Code], 
		d.DIV_NAME AS [Division Name],
		j.PRD_CODE AS [Product Code], 
		p.PRD_DESCRIPTION AS [Product Description], 
		p.OFFICE_CODE AS [Product Office Code],
		o.OFFICE_NAME AS [Product Office Name],
		pod.JOB_NUMBER AS [Job Number],
		j.JOB_DESC AS [Job Description], 
		pod.JOB_COMPONENT_NBR AS [Job Component Number],   
		jc.JOB_COMP_DESC AS [Job Component Description], 
		RIGHT('000000' + CAST(pod.JOB_NUMBER AS varchar(6)), 6) + '-' + 
			RIGHT('000' + CAST(pod.JOB_COMPONENT_NBR AS varchar(3)), 3) AS [Job Component Number Formatted],
		fh.FNC_HEADING_SEQ AS [Function Heading Sequence], 
		fh.FNC_HEADING_DESC AS [Function Heading Description], 
		f.FNC_ORDER AS [Function Order], 
		f.FNC_CODE AS [Function Code], 
		f.FNC_DESCRIPTION AS [Function Description], 
		pod.LINE_DESC AS [PO Line Description], 
		pod.DET_DESC AS [PO Detail Description], 
		pod.DET_INSTRUCT AS [PO Detail Instructions], 
		po.DEL_INSTRUCT AS [PO Shipping Instructions],
		ISNULL(pod.[PO_QTY], 0) AS [PO Quantity], 
		ISNULL(pod.[PO_RATE], 0) AS [PO Rate], 
		pod.PO_EXT_AMOUNT AS [PO Amount], 
		po.PO_FOOTER AS [PO Footer], 
		po.PO_REVISION AS [PO Revision Number],
		jc.JOB_FIRST_USE_DATE AS [Job Component First Use Date], 
		po.VN_CONT_CODE AS [Vendor Contact Code], 
		vc.[VC_FNAME] + ' ' + vc.[VC_LNAME] AS [Vendor Contact Name],
		vc.VC_ADDRESS1 AS [Vendor Contact Address1],
		vc.VC_ADDRESS2 AS [Vendor Contact Address2],
		vc.VC_CITY AS [Vendor Contact City],
		vc.VC_STATE AS [Vendor Contact State],
		vc.VC_ZIP AS [Vendor Contact ZIP],
		vc.VC_COUNTRY AS [Vendor Contact Country],
		vc.VC_TELEPHONE AS [Vendor Contact Phone],
		vc.VC_FAX AS [Vendor Contact Fax], 
		ISNULL(pod.EXT_MARKUP_AMT, 0) AS [PO Markup Amount], 
		ISNULL(pod.PO_COMM_PCT, 0) AS [PO Commission Percent], 
		po.VOID_FLAG AS [PO Void Flag], 
		dbo.advfn_std_comment_comment('Purchase Order', 'Standard Footer', p.OFFICE_CODE, j.CL_CODE, j.DIV_CODE, j.PRD_CODE) AS [PO Standard Comment]
	FROM dbo.PURCHASE_ORDER AS po 
	INNER JOIN dbo.PURCHASE_ORDER_DET AS pod 
		ON po.PO_NUMBER = pod.PO_NUMBER 
	INNER JOIN dbo.VENDOR AS v 
		ON po.VN_CODE = v.VN_CODE
	INNER JOIN dbo.EMPLOYEE AS e 
		ON po.EMP_CODE = e.EMP_CODE 
	LEFT JOIN dbo.FUNCTIONS AS f 
		ON pod.FNC_CODE = f.FNC_CODE 
	LEFT JOIN dbo.JOB_LOG AS j 
		ON pod.JOB_NUMBER = j.JOB_NUMBER 
	LEFT JOIN dbo.CLIENT AS c
		ON j.CL_CODE = c.CL_CODE
	LEFT JOIN dbo.DIVISION AS d
		ON j.CL_CODE = d.CL_CODE
		AND j.DIV_CODE = d.DIV_CODE
	LEFT JOIN dbo.PRODUCT AS p
		ON j.CL_CODE = p.CL_CODE
		AND j.DIV_CODE = p.DIV_CODE
		AND j.PRD_CODE = p.PRD_CODE
	LEFT JOIN dbo.JOB_COMPONENT AS jc 
		ON pod.JOB_NUMBER = jc.JOB_NUMBER 
		AND pod.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR 
	LEFT JOIN dbo.VEN_CONT AS vc 
		ON po.VN_CODE = vc.VN_CODE 
		AND po.VN_CONT_CODE = vc.VC_CODE 
	LEFT JOIN dbo.EMPLOYEE_TITLE AS et 
		ON e.EMPLOYEE_TITLE_ID = et.EMPLOYEE_TITLE_ID 
	LEFT JOIN dbo.FNC_HEADING AS fh 
		ON f.FNC_HEADING_ID = fh.FNC_HEADING_ID
	LEFT JOIN dbo.OFFICE AS o
		ON p.OFFICE_CODE = o.OFFICE_CODE	
	WHERE ISNULL(po.VOID_FLAG, 0) = 0
	ORDER BY po.PO_NUMBER, pod.LINE_NUMBER
	
END
GO
                             
