
CREATE PROCEDURE dbo.usp_wv_dto_insert_emp_status(
   @empcode char(6), 
   @new_status smallint,
   @inout_time datetime,
   @comment varchar(255),
   @return datetime
) AS

 if @inout_time is null 
   begin
     select @inout_time = getdate()
   end


INSERT INTO EMP_INOUTBOARD(EMP_CODE, INOUT_STAT, INOUT_TIME, COMMENT, EXP_RETURN_TIME)
VALUES	 (@empcode, @new_status, @inout_time, @comment, @return)



