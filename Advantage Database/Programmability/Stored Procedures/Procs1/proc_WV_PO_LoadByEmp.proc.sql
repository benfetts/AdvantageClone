

CREATE PROCEDURE [dbo].[proc_WV_PO_LoadByEmp](@funct integer, @backdays integer, @emp_code varchar(6), @vn_code varchar(6),
  @str1 varchar(15), @str2 varchar(15), @voided as smallint, @closed as smallint) AS

--exec proc_WV_PO_LoadByEmp 1, 30, 'ama', 'hamil', '', ''
--exec proc_WV_PO_LoadByEmp 2, 30, 'ama', '', '', ''

declare @backdate as datetime, @sql as nvarchar(4000)

select @backdate = dateadd(day,-@backdays, getdate())

if @funct=1
begin
select @sql = 'select  p.PO_NUMBER, 
Right(''00000000'' + convert(varchar(8),p.PO_NUMBER),8) as PO_PAD, 
convert(char(10),p.PO_CREATE_DATE,101) as PO_CREATE_DATE,
 p.VN_CODE, p.EMP_CODE,
convert(char(10),p.PO_DATE,101) as PO_DATE,
PO_DUE_DATE = case when p.PO_DUE_DATE is not null then convert(char(10),p.PO_DUE_DATE,101) else ''(?)'' end,
p.PO_DESCRIPTION, isnull(p.PO_COMPLETE, 0) as PO_COMPLETE,
isnull(p.PO_REVISION,0) as PO_REVISION,
isnull(PO_WORK_COMPLETE,0) as PO_WORK_COMPLETE,
v.VN_NAME, ISNULL(VOID_FLAG,0) AS VOID_FLAG,
PO_TOTAL =
  convert(char(20),cast(isnull((select sum(d.PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as d where d.PO_NUMBER=p.PO_NUMBER),0)as money),101), ISNULL(PO_APPROVAL_FLAG, 0) AS PO_APPROVAL_FLAG
  from PURCHASE_ORDER as p
  join VENDOR as v on v.VN_CODE=p.VN_CODE
  left join EMPLOYEE as e on e.EMP_CODE = p.[EMP_CODE]
  where p.EMP_CODE = ''' + cast(@emp_code as varchar(6)) + ''' and p.VN_CODE= ''' + cast(@vn_code as varchar(6)) + '''
  and PO_DATE > ''' + cast(@backdate as varchar(25)) + ''''

 if @voided = 1
 Begin
	select @sql = @sql + ' and (p.VOID_FLAG = 0 or p.VOID_FLAG IS NULL)'
 End
 if @closed = 1
 Begin
	select @sql = @sql + ' and (p.PO_COMPLETE = 0 or p.PO_COMPLETE IS NULL)'
 End

 select @sql = @sql + ' order by PO_NUMBER desc'
 Print @sql
 EXECUTE sp_executesql @sql

end

else if @funct=2
begin
select distinct p.VN_CODE, v.VN_NAME from PURCHASE_ORDER as p
 join VENDOR as v on v.VN_CODE= p.VN_CODE
 where p.EMP_CODE = @emp_code and PO_DATE > @backdate
 order by v.VN_NAME
end

else if @funct=3  -- only POs where work is incomplete.
begin
select  p.PO_NUMBER, 
Right('00000000' + convert(varchar(8),p.PO_NUMBER),8) as PO_PAD, 
convert(char(10),p.PO_CREATE_DATE,101) as PO_CREATE_DATE,
 p.VN_CODE, p.EMP_CODE,
convert(char(10),p.PO_DATE,101) as PO_DATE,
PO_DUE_DATE = case when p.PO_DUE_DATE is not null then convert(char(10),p.PO_DUE_DATE,101) else '(?)' end,
p.PO_DESCRIPTION, isnull(p.PO_COMPLETE, 0) as PO_COMPLETE,
isnull(p.PO_REVISION,0) as PO_REVISION,
isnull(PO_WORK_COMPLETE,0) as PO_WORK_COMPLETE,
v.VN_NAME, 
PO_TOTAL =
  convert(char(20),cast(isnull((select sum(d.PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as d where d.PO_NUMBER=p.PO_NUMBER),0)as money),101), ISNULL(PO_APPROVAL_FLAG, 0) AS PO_APPROVAL_FLAG
  from PURCHASE_ORDER as p
  join VENDOR as v on v.VN_CODE=p.VN_CODE
  left join EMPLOYEE as e on e.EMP_CODE = p.[EMP_CODE]
  where p.EMP_CODE = @emp_code and p.VN_CODE= @vn_code
  and (VOID_FLAG is null or VOID_FLAG=0) and (PO_WORK_COMPLETE is null or PO_WORK_COMPLETE=0)
  and PO_DATE > @backdate
 order by PO_NUMBER desc
end





