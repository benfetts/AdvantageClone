SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proc_WV_PO_GetEmpPOLimit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[proc_WV_PO_GetEmpPOLimit]
GO




CREATE PROCEDURE [dbo].[proc_WV_PO_GetEmpPOLimit](@funct integer, @emp_code char(6), @po_limit decimal(15,2) OUTPUT, 
@user_code varchar(15) OUTPUT, @user_name varchar(255) OUTPUT) AS

if @funct=1 -- return as output values
begin

select @po_limit= e.PO_LIMIT, @user_code= s.USER_CODE, @user_name= s.[USER_NAME]  from EMPLOYEE as e
 join SEC_USER as s on s.EMP_CODE=e.EMP_CODE
 where e.EMP_CODE=@emp_code


         if @po_limit is null
            begin
             select @po_limit='-1.00'
           end

          if @user_code is null
           begin
            select @user_code=''
           end

          if @user_name is null
            begin
               select @user_name = 'Undefined'
            end
 

end
else if @funct=2 -- return row
begin
select @po_limit= e.PO_LIMIT, @user_code= s.USER_CODE, @user_name= s.[USER_NAME]  from EMPLOYEE as e
 join SEC_USER as s on s.EMP_CODE=e.EMP_CODE
 where e.EMP_CODE=@emp_code
end




GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

