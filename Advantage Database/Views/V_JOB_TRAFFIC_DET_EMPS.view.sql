CREATE VIEW dbo.V_JOB_TRAFFIC_DET_EMPS ( 
	JOB_NUMBER, 
	JOB_COMPONENT_NBR, 
	SEQ_NBR, 
	EMP_CODE_LIST, 
	EMP_LNAME_LIST,	
	EMP_LFI_LIST, 
	EMP_CODE_FML_LIST, 
	EMP_CODE_FML_NAME_LIST, 
	EMP_CODE_HOURS_LIST, 
	EMP_CODE_FML_NAME_HOURS_LIST 
)  	
AS  	 
	SELECT 
		JOB_NUMBER,  		
		JOB_COMPONENT_NBR,  		
		SEQ_NBR,  		
		[dbo].[fn_task_employees]( JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, 1 ),  		
		[dbo].[fn_task_employees]( JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, 2 ),  		
		[dbo].[fn_task_employees]( JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, 3 ),  		
		[dbo].[fn_task_employees]( JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, 4 ),  		
		[dbo].[fn_task_employees]( JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, 7 ),  		
		[dbo].[fn_task_employees]( JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, 5 ),  		
		[dbo].[fn_task_employees]( JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, 6 )  	   
	FROM 
		dbo.JOB_TRAFFIC_DET 