


























create proc sp_columnlist

/* PURPOSE: generates list of col names
	    for use in statements.
  PARAMETERS:   @tablename, 'showall'(optional)
		The tablename must be passed in.
		If a second param is given, then
		datatype and size info is gen'd 
		in comments as well.
 USAGE:   sp_columnlist 'mytable' 
	  sp_columnlist 'mytable' , 'showall'

   DATE:    1/26/01 -MJH      */

@tablename varchar(50), @showall varchar(10) = 'no' --optional

as

declare @myint int
declare @mystr  varchar(1000)


select @myint =  max(len(sc.name)) from syscolumns sc 
where 
 id in ( select object_id(@tablename) ) 


--see if table doesn't exist
if @myint  is null 
BEGIN
print 'table ''' + @tablename + ''' not found.' 
+ char(13)
+ 'Here is a list of tables by'
+char (13)
select name from sysobjects 
where  type  = 'U' 
	and 
	name not like 'dt%'  
order by name  
return 
END


if (@showall = 'no') 
BEGIN
-- just the column name
set @mystr = 'select left(sc.name, ' + str(@myint)+ ')
+ '',''  from syscolumns sc 
where id in ( select object_id(''' + @tablename + ''')  )
order by colid ' 

exec ( @mystr )
return -- go away
END


--  show all the stuff 
set @mystr = 'select left(sc.name, ' + str(@myint) + ') 
+ '',     '' as ''col_name'', 
  ''/*   '' + convert(varchar(10), st.name) as ''datatype'', 
right(str(sc.length),5)  as length, right(str(sc.isnullable), 2)   
+  ''      */'' as ''can be null''
from syscolumns sc join systypes st on sc.xtype = st.xtype
where 
 id 
  in ( select object_id(''' + @tablename + ''')  )
order by colid ' 

exec ( @mystr )



























