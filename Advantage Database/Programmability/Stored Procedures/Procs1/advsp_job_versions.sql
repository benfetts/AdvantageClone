IF EXISTS ( SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID( N'dbo.advsp_job_versions') AND OBJECTPROPERTY(id, N'IsProcedure' ) = 1 )
	DROP PROCEDURE dbo.advsp_job_versions
GO

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO

SET ANSI_PADDING OFF
GO


CREATE PROCEDURE dbo.advsp_job_versions( @jv_tmplt_code varchar(6), @date_from smalldatetime, @date_to smalldatetime, @date_type smallint,
										 @show_closed_jobs smallint, @UserID varchar(100))
AS
	DECLARE @OfficeRestrictions AS INTEGER, @Restrictions AS INTEGER	
	DECLARE @EMP_CODE AS varchar(6)

	SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserID)
	SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	Select @Restrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID);
	SET NOCOUNT ON

	-- Comments
	-- BJL 01/31/12 Made job parameters optional

	DECLARE @label_text varchar(25), @advan_dtype varchar(20), @dtype_prec smallint, @dtype_scale smallint, @dtype_id smallint
	DECLARE @job_ver_seq_nbr smallint, @alter_sql varchar(1000), @update_sql varchar(1000), @jvh_id integer, @jvtd_id integer, @sql nvarchar(4000)
	DECLARE @job_number integer, @job_component_nbr smallint, @job_ver_name varchar(50), @job_ver_desc varchar(50), @create_date smalldatetime,
			@created_by varchar(100), @modified_date smalldatetime, @modified_by varchar(100), @job_desc varchar(60), @comp_desc varchar(60), @job_comp varchar(10),
			@created_by_cp varchar(100), @modified_by_cp varchar(100), @jv_order smallint, @count int, @pos int, @pos2 int, @paramlist nvarchar(4000)
	
	CREATE TABLE #job_versions( [Job Number] int NOT NULL, [Job Description] varchar(60), [Component Number] smallint NOT NULL, [Component Description] varchar(60), [Job/Component] varchar(10),
								 [Template] varchar(50), [Number] smallint NOT NULL,  [Description] varchar(50),
								[Create Date] smalldatetime, [Created By] varchar(100), [Modified Date] smalldatetime, [Modified By] varchar(100), [Created By CP] varchar(100), [Modified By CP] varchar(100),
								[JobVerHeaderID] int)


Set @sql = 'INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE(''0'', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + ''/'' + RIGHT(REPLICATE(''0'', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
			   FROM JOB_VER_HDR jvh INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
					INNER JOIN JOB_LOG jl ON jl.JOB_NUMBER = jvh.JOB_NUMBER
					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP'
					If @OfficeRestrictions > 0
					Begin
						Set @sql = @sql + ' INNER JOIN EMP_OFFICE ON jl.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
					End		
					If @Restrictions > 0
					Begin
						Set @sql = @sql + ' INNER JOIN SEC_CLIENT ON jl.CL_CODE = SEC_CLIENT.CL_CODE AND jl.DIV_CODE = SEC_CLIENT.DIV_CODE AND jl.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End	
	
Set @sql = @sql + ' WHERE jvh.JV_TMPLT_CODE = ''' + @jv_tmplt_code + ''''

if @date_type = 1
	Begin
		Set @sql = @sql + ' AND jl.CREATE_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + '' 23:59:59'' AS DATETIME)'
	End
if @date_type = 2
	Begin
		Set @sql = @sql + ' AND jc.JOB_COMP_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + '' 23:59:59'' AS DATETIME)'
	End
if @date_type = 3
	Begin
		Set @sql = @sql + ' AND jc.JOB_FIRST_USE_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + '' 23:59:59'' AS DATETIME)	'
	End
if @date_type = 4
	Begin
		Set @sql = @sql + ' AND jc.START_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + '' 23:59:59'' AS DATETIME)'
	End
if @date_type = 5
	Begin
		Set @sql = @sql + ' AND jvh.CREATE_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + '' 23:59:59'' AS DATETIME)'
	End
If @show_closed_jobs = 0
	Begin
		Set @sql = @sql + ' AND (jc.JOB_PROCESS_CONTRL NOT IN (6,12))'
	End
If @Restrictions > 0
	Begin
		Set @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	End	

SELECT @paramlist = '@date_from SmallDateTime, @date_to SmallDateTime'
if @date_type <> -1
Begin
	PRINT @sql
	EXEC sp_executesql @sql, @paramlist, @date_from, @date_to
End
	


--If @show_closed_jobs = 1
--Begin
--	if @date_type = 1
--	Begin		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM JOB_VER_HDR jvh INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					INNER JOIN JOB_LOG jl ON jl.JOB_NUMBER = jvh.JOB_NUMBER
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jl.CREATE_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)		    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC
		
		
--	End
	
--	If @date_type = 2
--	Begin
		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM dbo.JOB_VER_HDR jvh INNER JOIN JOB_LOG jl ON jvh.JOB_NUMBER = jl.JOB_NUMBER
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jc.JOB_COMP_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)		    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC
		
		
--	End
	
--	If @date_type = 3
--	Begin
		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM dbo.JOB_VER_HDR jvh INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					INNER JOIN JOB_LOG jl ON jl.JOB_NUMBER = jvh.JOB_NUMBER
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jc.JOB_FIRST_USE_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)		    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC		
		
--	End
	
--	If @date_type = 4
--	Begin
		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM dbo.JOB_VER_HDR jvh INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					INNER JOIN JOB_LOG jl ON jl.JOB_NUMBER = jvh.JOB_NUMBER
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jc.START_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)		    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC
	
--	End
	
--End
--Else
--Begin
--	if @date_type = 1
--	Begin
		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM dbo.JOB_VER_HDR jvh INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					INNER JOIN JOB_LOG jl ON jl.JOB_NUMBER = jvh.JOB_NUMBER
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jl.CREATE_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)
--					AND (jc.JOB_PROCESS_CONTRL NOT IN (6,12)) 	    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC
		
--	End
	
--	If @date_type = 2
--	Begin
		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM dbo.JOB_VER_HDR jvh INNER JOIN JOB_LOG jl ON jvh.JOB_NUMBER = jl.JOB_NUMBER
--			   INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jc.JOB_COMP_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)
--					AND (jc.JOB_PROCESS_CONTRL NOT IN (6,12)) 	    		    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC
		
--	End
	
--	If @date_type = 3
--	Begin
		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM dbo.JOB_VER_HDR jvh INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					INNER JOIN JOB_LOG jl ON jl.JOB_NUMBER = jvh.JOB_NUMBER
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jc.JOB_FIRST_USE_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)
--					AND (jc.JOB_PROCESS_CONTRL NOT IN (6,12)) 	    		    		    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC		
		
--	End
	
--	If @date_type = 4
--	Begin
		
--			INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP], [JobVerHeaderID]) 
--			 SELECT DISTINCT jvh.JOB_NUMBER, jl.JOB_DESC, jvh.JOB_COMPONENT_NBR, jc.JOB_COMP_DESC, (RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), jvh.JOB_NUMBER),6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), jvh.JOB_COMPONENT_NBR),2)),
--							 jvth.JV_TMPLT_DESC, jvh.JOB_VER_SEQ_NBR, jvh.JOB_VER_DESC, jvh.CREATE_DATE, jvh.CREATED_BY, jvh.MODIFIED_DATE, jvh.MODIFIED_BY, CCH.CONT_FML AS CREATED_BY_CP, CCHM.CONT_FML AS MODIFIED_BY_CP, jvh.JOB_VER_HDR_ID
--			   FROM dbo.JOB_VER_HDR jvh INNER JOIN JOB_COMPONENT jc ON jvh.JOB_NUMBER = jc.JOB_NUMBER AND jvh.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
--					INNER JOIN JOB_VER_TMPLT_HDR jvth ON jvh.JV_TMPLT_CODE = jvth.JV_TMPLT_CODE
--					INNER JOIN JOB_LOG jl ON jl.JOB_NUMBER = jvh.JOB_NUMBER
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCH ON CCH.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--					LEFT OUTER JOIN CDP_CONTACT_HDR CCHM ON CCHM.CDP_CONTACT_ID = jvh.CREATED_BY_CP
--			  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jc.START_DATE BETWEEN @date_from AND CAST(CONVERT(VARCHAR, @date_to, 101) + ' 23:59:59' AS DATETIME)
--					AND (jc.JOB_PROCESS_CONTRL NOT IN (6,12)) 	    		    		    
--		   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC
		
--	End
--End

if @date_type = 0
Begin
	DECLARE jv_col_cursor CURSOR FOR 
		 SELECT jvtd.JV_TMPLT_LABEL, adt.ADVAN_DTYPE, jvdt.JV_DTYPE_PREC, jvdt.JV_DTYPE_SCALE,
				jvdt.ADVAN_DTYPE_ID,jvtd.JV_TMPLT_ORDER
		   FROM dbo.JOB_VER_TMPLT_DTL jvtd 
	 INNER JOIN dbo.JOB_VER_DTYPE jvdt ON ( jvtd.JV_DTYPE_ID = jvdt.JV_DTYPE_ID )
	 INNER JOIN dbo.ADVAN_DTYPE adt ON ( jvdt.ADVAN_DTYPE_ID = adt.ADVAN_DTYPE_ID )	 
		  WHERE jvtd.JV_TMPLT_CODE = @jv_tmplt_code AND jvtd.JV_DTYPE_ID <> 12 --AND (jvtd.INACTIVE_FLAG = 0 OR jvtd.INACTIVE_FLAG IS NULL)
	   ORDER BY jvtd.JV_TMPLT_ORDER ASC

	--DECLARE jv_col_cursor CURSOR FOR 
	--	 SELECT DISTINCT jvtd.JV_TMPLT_LABEL, adt.ADVAN_DTYPE, jvdt.JV_DTYPE_PREC, jvdt.JV_DTYPE_SCALE,
	--			jvdt.ADVAN_DTYPE_ID, jvtd.JV_TMPLT_ORDER
	--	   FROM dbo.JOB_VER_HDR jvh
	-- INNER JOIN dbo.JOB_VER_DTL jvd ON ( jvh.JOB_VER_HDR_ID = jvd.JOB_VER_HDR_ID )
	-- INNER JOIN dbo.JOB_VER_TMPLT_DTL jvtd ON ( jvd.JV_TMPLT_DTL_ID = jvtd.JV_TMPLT_DTL_ID )
	-- INNER JOIN dbo.JOB_VER_DTYPE jvdt ON ( jvtd.JV_DTYPE_ID = jvdt.JV_DTYPE_ID )
	-- INNER JOIN dbo.ADVAN_DTYPE adt ON ( jvdt.ADVAN_DTYPE_ID = adt.ADVAN_DTYPE_ID )
	--	  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code
	--   ORDER BY jvtd.JV_TMPLT_ORDER ASC

	SELECT @pos = ORDINAL_POSITION FROM tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like 'Modified By CP'
	 
	OPEN jv_col_cursor

	FETCH NEXT FROM jv_col_cursor INTO @label_text, @advan_dtype, @dtype_prec, @dtype_scale, @dtype_id, @jv_order

	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN
		IF ( @dtype_id = 6 )
		BEGIN
			SELECT @advan_dtype = 'VARCHAR'
			SELECT @dtype_prec = 8000
			SELECT @dtype_scale = 0
		END
		SELECT @pos2 = ISNULL(ORDINAL_POSITION,0) FROM tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like @label_text
		If exists (Select * from tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like @label_text) --AND (@pos >= @pos2)
		Begin
			SELECT @alter_sql = 'ALTER TABLE #job_versions ADD [' + @label_text + '_' + CAST(@jv_order as varchar(5)) + '] ' + LOWER( @advan_dtype )								
		End
		Else
		Begin
			SELECT @alter_sql = 'ALTER TABLE #job_versions ADD [' + @label_text + '] ' + LOWER( @advan_dtype )
		End
								
		BEGIN TRY
			EXECUTE ( @alter_sql )
		END TRY
		
		BEGIN CATCH
			--GOTO FNEXT
		END CATCH
		
		FETCH NEXT FROM jv_col_cursor INTO @label_text, @advan_dtype, @dtype_prec, @dtype_scale, @dtype_id,@jv_order
	END

	CLOSE jv_col_cursor
	DEALLOCATE jv_col_cursor
	ALTER TABLE #job_versions DROP COLUMN [JobVerHeaderID]
	SELECT '' AS [Client Code],'' AS [Client Description],'' AS [Division Code],'' AS [Division Description],'' AS [Product Code],'' AS [Product Description],'' AS [Sales Class Code],
        '' AS [Sales Class Description],'' AS [Job Type Code],'' AS [Job Type Description],'' AS [Client Street Address 1],'' AS [Client City],'' AS [Client State],'' AS [Client Country],'' AS [Client Zip],jv.*
	FROM #job_versions jv

End
Else if @date_type = -1
Begin
	--DECLARE jv_col_cursor CURSOR FOR 
	--	 SELECT jvtd.JV_TMPLT_LABEL, adt.ADVAN_DTYPE, jvdt.JV_DTYPE_PREC, jvdt.JV_DTYPE_SCALE,
	--			jvdt.ADVAN_DTYPE_ID,jvtd.JV_TMPLT_ORDER
	--	   FROM dbo.JOB_VER_TMPLT_DTL jvtd 
	-- INNER JOIN dbo.JOB_VER_DTYPE jvdt ON ( jvtd.JV_DTYPE_ID = jvdt.JV_DTYPE_ID )
	-- INNER JOIN dbo.ADVAN_DTYPE adt ON ( jvdt.ADVAN_DTYPE_ID = adt.ADVAN_DTYPE_ID )	 
	--	  WHERE jvtd.JV_TMPLT_CODE = @jv_tmplt_code
	--   ORDER BY jvtd.JV_TMPLT_ORDER ASC

	DECLARE jv_col_cursor CURSOR FOR 
		 SELECT DISTINCT jvtd.JV_TMPLT_LABEL, adt.ADVAN_DTYPE, jvdt.JV_DTYPE_PREC, jvdt.JV_DTYPE_SCALE,
				jvdt.ADVAN_DTYPE_ID, jvtd.JV_TMPLT_ORDER
		   FROM dbo.JOB_VER_HDR jvh
	 INNER JOIN dbo.JOB_VER_DTL jvd ON ( jvh.JOB_VER_HDR_ID = jvd.JOB_VER_HDR_ID )
	 INNER JOIN dbo.JOB_VER_TMPLT_DTL jvtd ON ( jvd.JV_TMPLT_DTL_ID = jvtd.JV_TMPLT_DTL_ID )
	 INNER JOIN dbo.JOB_VER_DTYPE jvdt ON ( jvtd.JV_DTYPE_ID = jvdt.JV_DTYPE_ID )
	 INNER JOIN dbo.ADVAN_DTYPE adt ON ( jvdt.ADVAN_DTYPE_ID = adt.ADVAN_DTYPE_ID )
		  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jvtd.JV_DTYPE_ID <> 12
	   ORDER BY jvtd.JV_TMPLT_ORDER ASC

	SELECT @pos = ORDINAL_POSITION FROM tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like 'Modified By CP'
	 
	OPEN jv_col_cursor

	FETCH NEXT FROM jv_col_cursor INTO @label_text, @advan_dtype, @dtype_prec, @dtype_scale, @dtype_id, @jv_order

	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN
		IF ( @dtype_id = 6 )
		BEGIN
			SELECT @advan_dtype = 'VARCHAR'
			SELECT @dtype_prec = 8000
			SELECT @dtype_scale = 0
		END
		SELECT @pos2 = ISNULL(ORDINAL_POSITION,0) FROM tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like @label_text
		If exists (Select * from tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like @label_text) --AND (@pos >= @pos2)
		Begin
			SELECT @alter_sql = 'ALTER TABLE #job_versions ADD [' + @label_text + '_' + CAST(@jv_order as varchar(5)) + '] ' + LOWER( @advan_dtype )								
		End
		Else
		Begin
			SELECT @alter_sql = 'ALTER TABLE #job_versions ADD [' + @label_text + '] ' + LOWER( @advan_dtype )
		End
								
		BEGIN TRY
			EXECUTE ( @alter_sql )
		END TRY
		
		BEGIN CATCH
			--GOTO FNEXT
		END CATCH
		
		FETCH NEXT FROM jv_col_cursor INTO @label_text, @advan_dtype, @dtype_prec, @dtype_scale, @dtype_id,@jv_order
	END

	CLOSE jv_col_cursor
	DEALLOCATE jv_col_cursor
	ALTER TABLE #job_versions DROP COLUMN [JobVerHeaderID]

	SELECT '' AS [Client Code],'' AS [Client Description],'' AS [Division Code],'' AS [Division Description],'' AS [Product Code],'' AS [Product Description],'' AS [Sales Class Code],
        '' AS [Sales Class Description],'' AS [Job Type Code],'' AS [Job Type Description],'' AS [Client Street Address 1],'' AS [Client City],'' AS [Client State],'' AS [Client Country],'' AS [Client Zip],jv.*
	FROM #job_versions jv

End
Else
Begin
	--OPEN jv_row_cursor
	
	--FETCH NEXT FROM jv_row_cursor INTO @job_number, @job_desc, @job_component_nbr, @comp_desc, @job_comp, @job_ver_name, @job_ver_seq_nbr, @job_ver_desc, @create_date, @created_by, @modified_date, @modified_by, @created_by_cp, @modified_by_cp
	
	--WHILE ( @@FETCH_STATUS <> -1 )
	--BEGIN
	--	INSERT INTO #job_versions ( [Job Number], [Job Description], [Component Number], [Component Description], [Job/Component], [Template], [Number], [Description], [Create Date], [Created By], [Modified Date], [Modified By], [Created By CP], [Modified By CP]) 
	--	VALUES ( @job_number, @job_desc, @job_component_nbr, @comp_desc, @job_comp, @job_ver_name, @job_ver_seq_nbr, @job_ver_desc, @create_date, @created_by, @modified_date, @modified_by, @created_by_cp, @modified_by_cp )
	--	FETCH NEXT FROM jv_row_cursor INTO @job_number, @job_desc, @job_component_nbr, @comp_desc, @job_comp, @job_ver_name, @job_ver_seq_nbr, @job_ver_desc, @create_date, @created_by, @modified_date, @modified_by, @created_by_cp, @modified_by_cp
	--END
	
	--CLOSE jv_row_cursor
	--DEALLOCATE jv_row_cursor	

	--SELECT jvtd.JV_TMPLT_LABEL, adt.ADVAN_DTYPE, jvdt.JV_DTYPE_PREC, jvdt.JV_DTYPE_SCALE,
	--			jvh.JOB_VER_HDR_ID, jvd.JV_TMPLT_DTL_ID, jvdt.ADVAN_DTYPE_ID, jvh.JOB_NUMBER,
	--			jvh.JOB_COMPONENT_NBR,jvtd.JV_TMPLT_ORDER, jvh.JOB_VER_SEQ_NBR
	--	   FROM dbo.JOB_VER_HDR jvh
	-- INNER JOIN dbo.JOB_VER_DTL jvd ON ( jvh.JOB_VER_HDR_ID = jvd.JOB_VER_HDR_ID )
	-- INNER JOIN dbo.JOB_VER_TMPLT_DTL jvtd ON ( jvd.JV_TMPLT_DTL_ID = jvtd.JV_TMPLT_DTL_ID )
	-- INNER JOIN dbo.JOB_VER_DTYPE jvdt ON ( jvtd.JV_DTYPE_ID = jvdt.JV_DTYPE_ID )
	-- INNER JOIN dbo.ADVAN_DTYPE adt ON ( jvdt.ADVAN_DTYPE_ID = adt.ADVAN_DTYPE_ID )
	-- INNER JOIN #job_versions jv ON ( jvh.JOB_NUMBER = jv.[Job Number] AND jvh.JOB_COMPONENT_NBR = jv.[Component Number] )
	--	  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code
	--   ORDER BY jvh.JOB_NUMBER ASC, jvh.JOB_COMPONENT_NBR ASC, jvh.JOB_VER_SEQ_NBR ASC, jvtd.JV_TMPLT_ORDER ASC
	
	DECLARE jv_col_cursor CURSOR FOR 
		 SELECT DISTINCT jvtd.JV_TMPLT_LABEL, adt.ADVAN_DTYPE, jvdt.JV_DTYPE_PREC, jvdt.JV_DTYPE_SCALE,
				jvd.JV_TMPLT_DTL_ID, jvdt.ADVAN_DTYPE_ID, jvtd.JV_TMPLT_ORDER
		   FROM dbo.JOB_VER_HDR jvh
	 INNER JOIN dbo.JOB_VER_DTL jvd ON ( jvh.JOB_VER_HDR_ID = jvd.JOB_VER_HDR_ID )
	 INNER JOIN dbo.JOB_VER_TMPLT_DTL jvtd ON ( jvd.JV_TMPLT_DTL_ID = jvtd.JV_TMPLT_DTL_ID )
	 INNER JOIN dbo.JOB_VER_DTYPE jvdt ON ( jvtd.JV_DTYPE_ID = jvdt.JV_DTYPE_ID )
	 INNER JOIN dbo.ADVAN_DTYPE adt ON ( jvdt.ADVAN_DTYPE_ID = adt.ADVAN_DTYPE_ID )
	 --INNER JOIN #job_versions jv ON ( jvh.JOB_NUMBER = jv.[Job Number] AND jvh.JOB_COMPONENT_NBR = jv.[Component Number] )
		  WHERE jvh.JV_TMPLT_CODE = @jv_tmplt_code AND jvtd.JV_DTYPE_ID <> 12
	   ORDER BY jvtd.JV_TMPLT_ORDER ASC
	 
	OPEN jv_col_cursor

	FETCH NEXT FROM jv_col_cursor INTO @label_text, @advan_dtype, @dtype_prec, @dtype_scale, @jvtd_id, @dtype_id, @jv_order

	SELECT @pos = ORDINAL_POSITION FROM tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like 'JobVerHeaderID'

	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN
		IF ( @dtype_id = 6 )
		BEGIN
			SELECT @advan_dtype = 'VARCHAR'
			SELECT @dtype_prec = 8000
			SELECT @dtype_scale = 0
		END
		
		
		--SELECT @alter_sql = 'ALTER TABLE #job_versions_columns ADD [' + @label_text + '] ' + LOWER( @advan_dtype )
		SELECT @pos2 = ISNULL(ORDINAL_POSITION,0) FROM tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like @label_text
		If exists (Select * from tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like @label_text) --AND (@pos >= @pos2)
		Begin			
			SELECT @alter_sql = 'ALTER TABLE #job_versions ADD [' + @label_text + '_' + CAST(@jv_order as varchar(5)) + '] ' + LOWER( @advan_dtype )								
		End
		Else
		Begin
			SELECT @alter_sql = 'ALTER TABLE #job_versions ADD [' + @label_text + '] ' + LOWER( @advan_dtype )
		End

		--SELECT @update_sql = 'UPDATE #job_versions_columns SET [' + @label_text + '] = ( SELECT CONVERT( ' + LOWER( @advan_dtype )
		If exists (Select * from tempdb.information_schema.columns where table_name like '#job_versions%' and column_name like @label_text) --AND (@pos >= @pos2)
		Begin			
			SELECT @update_sql = 'UPDATE #job_versions SET [' + @label_text + '_' + CAST(@jv_order as varchar(5)) + '] = ( SELECT CONVERT( ' + LOWER( @advan_dtype )			
		End
		Else
		Begin
			SELECT @update_sql = 'UPDATE #job_versions SET [' + @label_text + '] = ( SELECT CONVERT( ' + LOWER( @advan_dtype )
		End

		IF ( @dtype_prec > 0 ) 
		BEGIN
			SELECT @alter_sql = @alter_sql + '(' + CONVERT( varchar(4), @dtype_prec )
			SELECT @update_sql = @update_sql + '(' + CONVERT( varchar(4), @dtype_prec )

			IF ( @dtype_scale > 0 ) 
			BEGIN
				SELECT @alter_sql = @alter_sql + ',' + CONVERT( varchar(3), @dtype_scale )
				SELECT @update_sql = @update_sql + ',' + CONVERT( varchar(3), @dtype_scale )
			END	

			SELECT @alter_sql = @alter_sql + ')'
			SELECT @update_sql = @update_sql + ')'
		END
		
		SELECT @alter_sql = @alter_sql + ' NULL'
		
		if @dtype_id = 7
		Begin
			SELECT @update_sql = @update_sql + '		, ISNULL(dbo.JOB_VER_DTL.JOB_VER_VALUE,0) ) '
		End
		Else
		Begin
			SELECT @update_sql = @update_sql + '		, dbo.JOB_VER_DTL.JOB_VER_VALUE ) '
		End		
		SELECT @update_sql = @update_sql + '	  FROM dbo.JOB_VER_DTL INNER JOIN dbo.JOB_VER_HDR jvh ON jvh.JOB_VER_HDR_ID = JOB_VER_DTL.JOB_VER_HDR_ID  '		
		SELECT @update_sql = @update_sql + '	 WHERE jvh.JOB_NUMBER = #job_versions.[Job Number] AND jvh.JOB_COMPONENT_NBR = #job_versions.[Component Number] AND JOB_VER_DTL.JOB_VER_HDR_ID = #job_versions.JobVerHeaderID'-- + CONVERT( varchar(8), @jvh_id )
		SELECT @update_sql = @update_sql + '	   AND JV_TMPLT_DTL_ID = ' + CONVERT( varchar(8), @jvtd_id ) + ' )'
		--SELECT @update_sql = @update_sql + ' WHERE [Job Number] = job_versions.' --+ CONVERT( varchar(8), @job_number )
		--SELECT @update_sql = @update_sql + '   AND [Component Number] = job_versions.' --+ CONVERT( varchar(3), @job_component_nbr )
		--SELECT @update_sql = @update_sql + '   AND [Number] = job_versions.' --+ CONVERT( varchar(3), @job_ver_seq_nbr )
				
		--PRINT @alter_sql;
		--PRINT @update_sql;

		BEGIN TRY
			EXECUTE ( @alter_sql )
		END TRY
		
		BEGIN CATCH
			GOTO FNEXT
		END CATCH
		
		FNEXT:
		EXECUTE ( @update_sql )
		
		FETCH NEXT FROM jv_col_cursor INTO @label_text, @advan_dtype, @dtype_prec, @dtype_scale, @jvtd_id, @dtype_id, @jv_order
	END

	CLOSE jv_col_cursor
	DEALLOCATE jv_col_cursor

	ALTER TABLE #job_versions DROP COLUMN [JobVerHeaderID]

--SELECT * FROM #job_versions
SELECT [Client Code] = J.CL_CODE,
		[Client Description] = C.CL_NAME,
		[Division Code] = J.DIV_CODE,
		[Division Description] = D.DIV_NAME,
		[Product Code] = J.PRD_CODE,
		[Product Description] = P.PRD_DESCRIPTION,
        [Sales Class Code] = J.SC_CODE,
        [Sales Class Description] = S.SC_DESCRIPTION,
        [Job Type Code] = JC.JT_CODE,
        [Job Type Description] = T.JT_DESC,
        [Client Street Address 1] = C.CL_ADDRESS1,
        [Client City] = CL_CITY,
        [Client State] = CL_STATE,
        [Client Country] = CL_COUNTRY,
        [Client Zip] = CL_ZIP,
		jv.*
FROM #job_versions AS jv INNER JOIN 
		[dbo].[JOB_COMPONENT] AS JC ON jv.[Job Number] = JC.JOB_NUMBER AND jv.[Component Number] = JC.JOB_COMPONENT_NBR INNER JOIN 
		[dbo].[JOB_LOG] AS J ON J.JOB_NUMBER = JC.JOB_NUMBER INNER JOIN
		[dbo].[CLIENT] AS C ON C.CL_CODE = J.CL_CODE INNER JOIN
		[dbo].[DIVISION] AS D ON D.CL_CODE = J.CL_CODE AND
								 D.DIV_CODE = J.DIV_CODE INNER JOIN
		[dbo].[PRODUCT] AS P ON P.CL_CODE = J.CL_CODE AND
								P.DIV_CODE = J.DIV_CODE AND
								P.PRD_CODE = J.PRD_CODE INNER JOIN
        [dbo].[SALES_CLASS] AS S ON S.SC_CODE = J.SC_CODE LEFT JOIN 
        [dbo].[JOB_TYPE] T ON T.JT_CODE = JC.JT_CODE
ORDER BY J.CL_CODE
End
		 






DROP TABLE #job_versions
GO

GRANT EXECUTE ON advsp_job_versions TO PUBLIC AS dbo
GO