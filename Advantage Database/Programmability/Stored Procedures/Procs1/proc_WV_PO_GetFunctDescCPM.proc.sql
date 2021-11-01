


CREATE PROCEDURE [dbo].[proc_WV_PO_GetFunctDescCPM](@funct integer, @po_number integer, @func_code char(6), 
  @qty integer, @desc varchar(100) OUTPUT, @use_cpm tinyint OUTPUT, @cpmqty integer OUTPUT, @funct_po_total decimal OUTPUT,
  @glacode varchar(30) OUTPUT, @gladesc varchar(75) OUTPUT) AS
/*
Return function descriptiona dn CPM flag / initial Qty Calculation
*/

/*
declare @desc as varchar(100)
declare @use_cpm as  tinyint
declare @cpmqty as integer
declare @func_total as integer

exec proc_WV_PO_GetFunctDescCPM  1, 37, 'print', 500, @desc output, @use_cpm output, @cpmqty output, @func_total output

print @desc
print @use_cpm
print @cpmqty
print @func_total
*/

declare @flt as float

if @qty is null
 begin
  select @qty=0
 end

if @funct=1
begin
select @flt = round(@qty,0)

select @desc= isnull(f.FNC_DESCRIPTION,''), @use_cpm= isnull(f.FNC_CPM_FLAG,0),
 @cpmqty = case when FNC_CPM_FLAG=0 or FNC_CPM_FLAG is null then 0 else  cast((@flt * 100) / 1000   as integer) end,
 @funct_po_total =( select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET  WHERE 
PO_NUMBER=@po_number and FNC_CODE= @func_code), @glacode = g.GLACODE, @gladesc = g.GLADESC
 from [FUNCTIONS] as f LEFT OUTER JOIN GLACCOUNT as g ON
				f.OVERHEAD_GLACCT=g.GLACODE
  where f.FNC_CODE= @func_code

  select @desc=isnull(@desc,'')
  select @use_cpm= isnull(@use_cpm,0)
  select @cpmqty= isnull(@cpmqty,0)
  select @funct_po_total= isnull(@funct_po_total,0)
  select @glacode = isnull(@glacode, '')
  select @gladesc = isnull(@gladesc, '')
end



