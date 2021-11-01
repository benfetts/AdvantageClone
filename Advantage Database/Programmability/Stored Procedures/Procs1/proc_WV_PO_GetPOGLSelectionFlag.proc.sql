





CREATE PROCEDURE [dbo].[proc_WV_PO_GetPOGLSelectionFlag] 
@EmpCode varchar(6)
AS

SELECT     ISNULL(PO_GL_SELECTION, 0) AS PO_GL_SELECTION
FROM       EMPLOYEE
WHERE      EMP_CODE = @EmpCode





















