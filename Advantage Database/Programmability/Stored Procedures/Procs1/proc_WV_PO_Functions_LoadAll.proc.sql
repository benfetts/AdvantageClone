


--exec proc_WV_PO_Functions_LoadAll 1,'',0,''

CREATE PROCEDURE [dbo].[proc_WV_PO_Functions_LoadAll](@funct integer, @ref_code varchar(6),
     @ref_id integer, @sort varchar(50)) AS

      if @funct=1 -- all function codes -- selection list -- filter by Vendor function type.
       begin
                   SELECT  FNC_CODE as Code, ISNULL(FNC_DESCRIPTION,'') as Descrip,
                          FNC_CODE + '  (' +  ISNULL(FNC_DESCRIPTION,'')  + ')'  as Descrip2
                         FROM [FUNCTIONS]
		WHERE FNC_TYPE='V'  and (FUNCTIONS.FNC_INACTIVE = 0 or FUNCTIONS.FNC_INACTIVE IS NULL)
                          order by Descrip
       end
 



