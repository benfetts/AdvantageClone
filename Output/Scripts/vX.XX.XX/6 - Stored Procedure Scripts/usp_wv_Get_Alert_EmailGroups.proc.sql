IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_Get_Alert_EmailGroups]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_Get_Alert_EmailGroups]
GO
CREATE PROCEDURE [dbo].[usp_wv_Get_Alert_EmailGroups] 
@Group	VARCHAR(50) = NULL,
@JOB_NUMBER INT = NULL,
@JOB_COMPONENT_NBR SMALLINT = NULL,
@AUTO_GROUP SMALLINT = NULL
AS
/*=========== QUERY ===========*/
BEGIN

	SELECT 
		A.EMPGROUP,
		A.EMPCODE,
		A.[DESCRIPTION],
		A.Checked,
		A.REC_ORDER,
		A.EMP_FML
	FROM 
		[dbo].[advtf_get_email_groups] (@Group, @JOB_NUMBER, @JOB_COMPONENT_NBR, @AUTO_GROUP) AS A
	WHERE
		A.IsContacts = 0;

END
/*=========== QUERY ===========*/
