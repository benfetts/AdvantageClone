

























CREATE PROCEDURE [dbo].[usp_wv_exp_VendorCheck]

@EmpCode VarChar(6)

AS

Select VN_CODE_EXP as VendorCode, VN_NAME AS VendorName
from EMPLOYEE 
	Inner Join VENDOR
	On VENDOR.VN_CODE = EMPLOYEE.VN_CODE_EXP
where EMP_CODE = @EmpCode






















