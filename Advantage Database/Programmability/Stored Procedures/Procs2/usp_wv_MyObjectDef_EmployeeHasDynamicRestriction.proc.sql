SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_MyObjectDef_EmployeeHasDynamicRestriction]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_MyObjectDef_EmployeeHasDynamicRestriction]
GO
CREATE PROCEDURE [dbo].[usp_wv_MyObjectDef_EmployeeHasDynamicRestriction] /*WITH ENCRYPTION*/
@EMP_CODE VARCHAR(6),
@OBJECT_ID INT
AS
/*=========== QUERY ===========*/

	DECLARE @EMPLOYEE_HAS_MGMT_RESTRICTIONS BIT
    SELECT @EMPLOYEE_HAS_MGMT_RESTRICTIONS = [dbo].[fn_my_objects_employee_has_dynamic_restriction](@EMP_CODE, @OBJECT_ID); 
    
    SELECT ISNULL(@EMPLOYEE_HAS_MGMT_RESTRICTIONS, 0) AS EMPLOYEE_HAS_MGMT_RESTRICTIONS;

/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO