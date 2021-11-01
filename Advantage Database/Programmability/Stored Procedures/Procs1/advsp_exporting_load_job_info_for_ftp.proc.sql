CREATE PROCEDURE [dbo].[advsp_exporting_load_job_info_for_ftp]
AS
BEGIN
	
	SET NOCOUNT ON

	SELECT
		[JobNumber] = JC.JOB_NUMBER,
		[OfficeCode] = J.OFFICE_CODE,
		[OfficeDescription] = O.OFFICE_NAME,
		[ClientCode] = J.CL_CODE,
		[ClientDescription] = C.CL_NAME,
		[JobDescription] = J.JOB_DESC,
		[ComponentNumber] = JC.JOB_COMPONENT_NBR,
		[AccountExecutiveCode] = JC.EMP_CODE,
		[AccountExecutive] = COALESCE((RTRIM(EMP.EMP_FNAME) + ' '),'') + COALESCE((EMP.EMP_MI + '. '),'') + COALESCE(EMP.EMP_LNAME,''),
		[JobProcessControl] = JPC.JOB_PROCESS_DESC,
		[ComponentDescription] = JC.JOB_COMP_DESC,
		[NonBillable] = JC.NOBILL_FLAG
	FROM
		[dbo].[JOB_COMPONENT] AS JC INNER JOIN 
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER LEFT OUTER JOIN
		[dbo].[OFFICE] AS O ON O.OFFICE_CODE = J.OFFICE_CODE INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
		[dbo].[EMPLOYEE_CLOAK] AS EMP ON EMP.EMP_CODE = JC.EMP_CODE LEFT OUTER JOIN
		[dbo].[JOB_PROC_CONTROLS] AS JPC ON JPC.JOB_PROCESS_CONTRL = JC.JOB_PROCESS_CONTRL
	WHERE
		JC.JOB_PROCESS_CONTRL IN (1,8,4,9,3) AND
		J.COMP_OPEN = 1		

END
GO