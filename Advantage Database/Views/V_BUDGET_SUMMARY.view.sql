CREATE VIEW [dbo].[V_BUDGET_SUMMARY] AS  	 
	 SELECT B.BUDGET_CODE, B.REV_NBR, B.CATEGORY_CODE,   		
			B.LINE_NBR, B.OFFICE_CODE, B.CL_CODE, B.DIV_CODE,   		
			B.PRD_CODE, B.BUDGET_TYPE, B.SC_CODE, B.BUDGET_PERIOD,   		
			dbo.udf_get_budget_acct( 'S', B.OFFICE_CODE, B.SC_CODE, B.BUDGET_TYPE ) 'GLACCT_SALES',  		
			dbo.udf_get_budget_acct( 'C', B.OFFICE_CODE, B.SC_CODE, B.BUDGET_TYPE ) 'GLACCT_COS',  		
			COALESCE( SUM(AA.BUDGET_VALUE), 0.00 ) 'BILLING_AMOUNT',  		
			COALESCE( SUM(A.BUDGET_VALUE), 0.00 ) 'INCOME_AMOUNT',  		
			COALESCE( SUM(B.BUDGET_VALUE), 0.00 ) 'BUDGET_VALUE'  	   
	   FROM dbo.BUDGET_DETAIL B LEFT OUTER JOIN dbo.BUDGET_DETAIL A 
	     ON A.BUDGET_CODE = B.BUDGET_CODE 
	    AND A.REV_NBR = B.REV_NBR 
	    AND A.SEQ_NBR = B.SEQ_NBR 
	    AND A.CATEGORY_CODE IN ( 'fee', 'lab', 'com' ) LEFT OUTER JOIN dbo.BUDGET_DETAIL AA   	     
	     ON AA.BUDGET_CODE = B.BUDGET_CODE   	    
	    AND AA.REV_NBR = B.REV_NBR   	    
	    AND AA.SEQ_NBR = B.SEQ_NBR   	    
	    AND AA.CATEGORY_CODE IN ( 'fee', 'lab', 'com', 'cos' )   	  
	  WHERE B.CATEGORY_CODE IN ( 'fee', 'lab', 'dsc', 'com', 'cos', 'de', 'oop' )         
   GROUP BY B.BUDGET_CODE, B.REV_NBR, B.CATEGORY_CODE, B.LINE_NBR, B.OFFICE_CODE,   		
			B.CL_CODE, B.DIV_CODE, B.PRD_CODE, B.BUDGET_TYPE, B.SC_CODE, B.BUDGET_PERIOD  
UNION  	 
	 SELECT BUDGET_CODE, REV_NBR, 'S', LINE_NBR, OFFICE_CODE, CL_CODE, DIV_CODE,   		
			PRD_CODE, BUDGET_TYPE, SC_CODE, BUDGET_PERIOD,   		
			dbo.udf_get_budget_acct( 'S', OFFICE_CODE, SC_CODE, BUDGET_TYPE ) 'GLACCT_SALES',  		
			dbo.udf_get_budget_acct( 'C', OFFICE_CODE, SC_CODE, BUDGET_TYPE ) 'GLACCT_COS',  		
			COALESCE( BILLING_AMOUNT, 0.00 ), COALESCE( INCOME_AMOUNT, 0.00 ), 0.00
	   FROM dbo.BUDGET_SUMMARY  



