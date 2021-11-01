CREATE PROCEDURE [dbo].[usp_wv_exp_InsertEXPENSE_HEADER] 
@EMP_CODE varchar(6),
@INV_DATE datetime,
@EXP_DESC varchar(30),
@DTL_DESC text,
@CREATE_USER_ID varchar(100) = null
AS
     DECLARE @VN_CODE AS VARCHAR(10);
     SET NOCOUNT ON;
     SELECT @VN_CODE = VN_CODE_EXP
     FROM EMPLOYEE
          INNER JOIN VENDOR ON VENDOR.VN_CODE = EMPLOYEE.VN_CODE_EXP
     WHERE EMP_CODE = @EMP_CODE;
     INSERT INTO [dbo].[EXPENSE_HEADER]
     ([EMP_CODE],
      [VN_CODE],
      [INV_DATE],
      [EXP_DESC],
      [DTL_DESC],
      [CREATE_DATE],
      [CREATE_USER_ID]
     )
     VALUES
     (@EMP_CODE,
      @VN_CODE,
      @INV_DATE,
      @EXP_DESC,
      @DTL_DESC,
      GETDATE(),
      @CREATE_USER_ID
     );
     SELECT SCOPE_IDENTITY();