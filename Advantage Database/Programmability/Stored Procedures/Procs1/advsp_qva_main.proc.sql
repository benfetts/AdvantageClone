
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_qva_main]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_qva_main]
GO

CREATE PROCEDURE [dbo].[advsp_qva_main] 
	@row_ids_list varchar(max),
	@job_count int
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @ROW_IDS TABLE
		(
			[ID] INT IDENTITY(1,1) PRIMARY KEY,
			[ROW_ID] [int] NOT NULL
		) 	

	DECLARE	@pos int,
						@nextpos int,
						@valuelen int

	   SELECT @pos = 0, @nextpos = 1

	   WHILE @nextpos > 0
	   BEGIN
		  SELECT @nextpos = charindex(',', @row_ids_list, @pos + 1)
		  SELECT @valuelen = CASE WHEN @nextpos > 0
								  THEN @nextpos
								  ELSE len(@row_ids_list) + 1
							 END - @pos - 1
		  INSERT @ROW_IDS  (ROW_ID)
			 VALUES (convert(int, substring(@row_ids_list, @pos + 1, @valuelen)))
		  SELECT @pos = @nextpos
	   END

	--SELECT * FROM @ROW_IDS	

	DECLARE @ET TABLE
		(
			[ID] INT IDENTITY(1,1) PRIMARY KEY,
			[JOB_NUMBER] [int] NOT NULL,
			[JOB_COMPONENT_NBR] [int] NOT NULL,
			FNC_CODE varchar(6) NOT NULL
		) 	
		
	INSERT INTO @ET	
	SELECT et.JOB_NUMBER, et.JOB_COMPONENT_NBR, et.FNC_CODE 
	FROM V_QUOTE_VS_ACTUAL et 
	INNER JOIN JOB_COMPONENT jc ON et.JOB_NUMBER = jc.JOB_NUMBER  AND et.JOB_COMPONENT_NBR = jc.JOB_COMPONENT_NBR
	WHERE jc.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )

	SELECT * FROM (
	  SELECT cc_row_hdr = '',   
			 et.FNC_CODE,   
			 f.FNC_DESCRIPTION,   
			 f.FNC_TYPE,
				f.FNC_INACTIVE,   
			 cc_est_hrs = ( SELECT COALESCE( SUM( D.EST_REV_QUANTITY ) / ( @job_count ), 0 ) 
			  						  FROM ESTIMATE_REV_DET D, ESTIMATE_APPROVAL A, JOB_COMPONENT JC
			 						 WHERE D.ESTIMATE_NUMBER = A.ESTIMATE_NUMBER
			   					   AND D.EST_COMPONENT_NBR = A.EST_COMPONENT_NBR
			   					   AND D.EST_QUOTE_NBR = A.EST_QUOTE_NBR
			   					   AND D.EST_REV_NBR = A.EST_REVISION_NBR
			   						AND A.JOB_NUMBER = JC.JOB_NUMBER
			   						AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
									  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
			   						AND D.FNC_CODE = et.FNC_CODE ),   
			 cc_est_amount = ( SELECT COALESCE( SUM( D.EST_REV_EXT_AMT ) / ( @job_count ), 0 )
			     						  FROM ESTIMATE_REV_DET D, ESTIMATE_APPROVAL A, JOB_COMPONENT JC
			    						 WHERE D.ESTIMATE_NUMBER = A.ESTIMATE_NUMBER
			      						AND D.EST_COMPONENT_NBR = A.EST_COMPONENT_NBR
			      						AND D.EST_QUOTE_NBR = A.EST_QUOTE_NBR
			      						AND D.EST_REV_NBR = A.EST_REVISION_NBR
			      						AND A.JOB_NUMBER = JC.JOB_NUMBER
			      						AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
										  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
			      						AND D.FNC_CODE = et.FNC_CODE ),   
			 cc_est_tax = ( SELECT ( COALESCE( SUM( D.EXT_CITY_RESALE ), 0 ) + 
			       						   COALESCE( SUM( D.EXT_STATE_RESALE ), 0 ) + 
			       						   COALESCE( SUM( D.EXT_COUNTY_RESALE ), 0 ) + 
			       						   COALESCE( SUM( D.EXT_NONRESALE_TAX ), 0 )) / ( @job_count )
			  						  FROM ESTIMATE_REV_DET D, ESTIMATE_APPROVAL A, JOB_COMPONENT JC
			 						 WHERE D.ESTIMATE_NUMBER = A.ESTIMATE_NUMBER
			   						AND D.EST_COMPONENT_NBR = A.EST_COMPONENT_NBR
			   						AND D.EST_QUOTE_NBR = A.EST_QUOTE_NBR
			   						AND D.EST_REV_NBR = A.EST_REVISION_NBR
			   						AND A.JOB_NUMBER = JC.JOB_NUMBER
			   						AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
									  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
			   						AND D.FNC_CODE = et.FNC_CODE ),   
			 cc_est_total = 0.00,   
			 cc_actual_hrs = CASE f.FNC_TYPE
										WHEN 'E' THEN 
											( SELECT COALESCE( SUM( D.EMP_HOURS ) / ( @job_count ), 0 ) 
					    						 FROM EMP_TIME_DTL D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												 AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE )
										WHEN 'I' THEN 
											( SELECT COALESCE( SUM( D.IO_QTY ) / ( @job_count ), 0 )
					    						 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE )
										WHEN 'V' THEN 
											( SELECT COALESCE( SUM( D.AP_PROD_QUANTITY ) / ( @job_count ), 0 )
					    						 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE ) 
										WHEN 'C' THEN 0.00
			    					END,   
			 cc_actual_amount = CASE f.FNC_TYPE
											WHEN 'E' THEN 
												( SELECT COALESCE( SUM( D.TOTAL_BILL ) / ( @job_count ), 0 )
					    							 FROM EMP_TIME_DTL D, JOB_COMPONENT JC
					   							WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     							  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
													  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     							  AND D.FNC_CODE = et.FNC_CODE )
											WHEN 'I' THEN 
												( SELECT COALESCE( SUM( D.IO_AMOUNT ) / ( @job_count ), 0 )
					    							 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   							WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     							  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
													  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     							  AND D.FNC_CODE = et.FNC_CODE )
											WHEN 'V' THEN 
												( SELECT COALESCE( SUM( D.AP_PROD_EXT_AMT ) / ( @job_count ), 0 )
					    							 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   							WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     							  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
													  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     							  AND D.FNC_CODE = et.FNC_CODE ) 
											WHEN 'C' THEN
												( SELECT COALESCE( SUM( D.AMOUNT ) / ( @job_count ), 0 )
					    							 FROM CLIENT_OOP D, JOB_COMPONENT JC
					   							WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     							  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
													  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     							  AND D.FNC_CODE = et.FNC_CODE )
			    						END,   
			 cc_actual_tax = CASE f.FNC_TYPE
										WHEN 'E' THEN 
											( SELECT ( COALESCE( SUM( D.EXT_CITY_RESALE ), 0 ) + 
														  COALESCE( SUM( D.EXT_STATE_RESALE ), 0 ) + 
						 								  COALESCE( SUM( D.EXT_COUNTY_RESALE ), 0 )) / ( @job_count ) 
					    						 FROM EMP_TIME_DTL D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE )
										WHEN 'I' THEN 
											( SELECT ( COALESCE( SUM( D.EXT_CITY_RESALE ), 0 ) + 
						 								  COALESCE( SUM( D.EXT_STATE_RESALE ), 0 ) + 
						 								  COALESCE( SUM( D.EXT_COUNTY_RESALE ), 0 )) / ( @job_count )
					    						 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE )
										WHEN 'V' THEN 
											( SELECT ( COALESCE( SUM( D.EXT_CITY_RESALE ) , 0 ) + 
						 								  COALESCE( SUM( D.EXT_STATE_RESALE ), 0 ) + 
						 								  COALESCE( SUM( D.EXT_COUNTY_RESALE ), 0 ) + 
						 								  COALESCE( SUM( D.EXT_NONRESALE_TAX ), 0 )) / ( @job_count ) 
					    						 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE ) 
										WHEN 'C' THEN 0.00
			    					END,   
			 cc_actual_total = 0.00,   
			 cc_open_po = 0.00,   
			 cc_billed = CASE f.FNC_TYPE
									WHEN 'E' THEN 
										( SELECT COALESCE( SUM( D.LINE_TOTAL ) / ( @job_count ), 0 )
											FROM EMP_TIME_DTL D, JOB_COMPONENT JC
										   WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     					  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
											  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     					  AND D.FNC_CODE = et.FNC_CODE 
					     					  AND ( D.AR_INV_NBR IS NOT NULL OR D.AB_FLAG = 3 ))
									WHEN 'I' THEN 
										( SELECT COALESCE( SUM( D.LINE_TOTAL ) / ( @job_count ), 0 )
					    					 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   					WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     					  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
											  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     					  AND D.FNC_CODE = et.FNC_CODE
					     					  AND ( D.AR_INV_NBR IS NOT NULL OR D.AB_FLAG = 3 ))
									WHEN 'V' THEN 
										( SELECT COALESCE( SUM( D.LINE_TOTAL ) / ( @job_count ), 0 )
					    					 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   					WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     					  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
											  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     					  AND D.FNC_CODE = et.FNC_CODE 
					     					  AND ( D.AR_INV_NBR IS NOT NULL OR D.AB_FLAG = 3 )) 
									WHEN 'C' THEN 0.00
			    				END,   
			 cc_qva = 0.00,   
			 cc_avb = 0.00,   
				cc_qva_po = 0.00,
				cc_avb_po = 0.00,
			 cc_est_mkp = ( SELECT COALESCE( SUM( D.EXT_MARKUP_AMT ) / ( @job_count ), 0 )  
			    					  FROM ESTIMATE_REV_DET D, ESTIMATE_APPROVAL A, JOB_COMPONENT JC
			   					 WHERE D.ESTIMATE_NUMBER = A.ESTIMATE_NUMBER
			     						AND D.EST_COMPONENT_NBR = A.EST_COMPONENT_NBR
			     						AND D.EST_QUOTE_NBR = A.EST_QUOTE_NBR
			     						AND D.EST_REV_NBR = A.EST_REVISION_NBR
			     						AND A.JOB_NUMBER = JC.JOB_NUMBER
			     						AND A.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
									  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
			     						AND D.FNC_CODE = et.FNC_CODE ),   
			 cc_actual_mkp = CASE f.FNC_TYPE
										WHEN 'E' THEN 
											( SELECT COALESCE( SUM( D.EXT_MARKUP_AMT ) / ( @job_count ), 0 ) 
					    						 FROM EMP_TIME_DTL D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE )
										WHEN 'I' THEN 
											( SELECT COALESCE( SUM( D.EXT_MARKUP_AMT ) / ( @job_count ), 0 )
					    						 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE )
										WHEN 'V' THEN 
											( SELECT COALESCE( SUM( D.EXT_MARKUP_AMT ) / ( @job_count ), 0 )
					    						 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   						WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     						  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     						  AND D.FNC_CODE = et.FNC_CODE ) 
										WHEN 'C' THEN 0.00
			    					END,   
				 cc_nb_actual_total = 0.00,
				 cc_adv_billed = ( SELECT COALESCE( SUM( D.LINE_TOTAL ) / ( @job_count ), 0 )
					     					FROM ADVANCE_BILLING D, JOB_COMPONENT JC
					    				  WHERE D.JOB_NUMBER = JC.JOB_NUMBER
				   	   				 AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
											 AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
			   	   					 AND D.FNC_CODE = et.FNC_CODE
			      						 AND ( AR_INV_NBR IS NOT NULL OR D.AB_FLAG = 3 )),
				 cc_po_total = CASE f.FNC_TYPE
										WHEN 'V' THEN 
											( SELECT COALESCE( SUM( pod.PO_EXT_AMOUNT ) / ( @job_count ), 0 )
					   		 				 FROM PURCHASE_ORDER_DET pod, PURCHASE_ORDER po, JOB_COMPONENT JC
					   						WHERE pod.JOB_NUMBER = JC.JOB_NUMBER
							     				  AND pod.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
												  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
							     				  AND pod.FNC_CODE = et.FNC_CODE
							     				  AND pod.PO_NUMBER = po.PO_NUMBER
					   		  				  AND ( pod.PO_COMPLETE IS NULL OR pod.PO_COMPLETE = 0 )
					     						  AND ( VOID_FLAG IS NULL OR VOID_FLAG = 0 ) ) 
										ELSE 0.00
									END,
				 cc_po_applied = CASE f.FNC_TYPE
										WHEN 'V' THEN 
											( SELECT COALESCE( SUM( AP_PROD_EXT_AMT ) / ( @job_count ), 0 ) 
					   		 				 FROM PURCHASE_ORDER_DET, AP_PRODUCTION, JOB_COMPONENT JC
					   						WHERE ( PURCHASE_ORDER_DET.PO_NUMBER = AP_PRODUCTION.PO_NUMBER ) 
							     				  AND ( PURCHASE_ORDER_DET.LINE_NUMBER = AP_PRODUCTION.PO_LINE_NUMBER) 
							     				  AND ( PURCHASE_ORDER_DET.JOB_NUMBER = JC.JOB_NUMBER ) 
							     				  AND ( PURCHASE_ORDER_DET.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR ) 
												  AND ( JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 ) )
					   		  				  AND ( PURCHASE_ORDER_DET.FNC_CODE = et.FNC_CODE ) 
					     						  AND ( PURCHASE_ORDER_DET.PO_COMPLETE = 0 OR PURCHASE_ORDER_DET.PO_COMPLETE IS NULL ) )
										ELSE 0.00
					    			END,   
			 cc_nb_tax = CASE f.FNC_TYPE
												WHEN 'E' THEN 
													( SELECT ( COALESCE( SUM( D.EXT_CITY_RESALE ), 0 ) + 
																  COALESCE( SUM( D.EXT_STATE_RESALE ), 0 ) + 
						 										  COALESCE( SUM( D.EXT_COUNTY_RESALE ), 0 )) / ( @job_count ) 
					    								 FROM EMP_TIME_DTL D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.EMP_NON_BILL_FLAG = 1 )
												WHEN 'I' THEN 
													( SELECT ( COALESCE( SUM( D.EXT_CITY_RESALE ), 0 ) + 
						 										  COALESCE( SUM( D.EXT_STATE_RESALE ), 0 ) + 
						 										  COALESCE( SUM( D.EXT_COUNTY_RESALE ), 0 )) / ( @job_count )
					    								 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.NON_BILL_FLAG = 1 )
												WHEN 'V' THEN 
													( SELECT ( COALESCE( SUM( D.EXT_CITY_RESALE ) , 0 ) + 
						 										  COALESCE( SUM( D.EXT_STATE_RESALE ), 0 ) + 
						 										  COALESCE( SUM( D.EXT_COUNTY_RESALE ), 0 ) + 
						 										  COALESCE( SUM( D.EXT_NONRESALE_TAX ), 0 )) / ( @job_count ) 
					    								 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.AP_PROD_NOBILL_FLG = 1 ) 
												WHEN 'C' THEN 0.00
			    							END,   
			 cc_nb_mkp = CASE f.FNC_TYPE
												WHEN 'E' THEN 
													( SELECT COALESCE( SUM( D.EXT_MARKUP_AMT ) / ( @job_count ), 0 ) 
					    								 FROM EMP_TIME_DTL D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.EMP_NON_BILL_FLAG = 1 )
												WHEN 'I' THEN 
													( SELECT COALESCE( SUM( D.EXT_MARKUP_AMT ) / ( @job_count ), 0 )
					    								 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.NON_BILL_FLAG = 1 )
												WHEN 'V' THEN 
													( SELECT COALESCE( SUM( D.EXT_MARKUP_AMT ) / ( @job_count ), 0 )
					    								 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.AP_PROD_NOBILL_FLG = 1 ) 
												WHEN 'C' THEN 0.00
			    							END,
				cc_nb_amt = CASE f.FNC_TYPE
												WHEN 'E' THEN 
													( SELECT COALESCE( SUM( D.TOTAL_BILL ) / ( @job_count ), 0 ) 
					    								 FROM EMP_TIME_DTL D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.EMP_NON_BILL_FLAG = 1 )
												WHEN 'I' THEN 
													( SELECT COALESCE( SUM( D.IO_AMOUNT ) / ( @job_count ), 0 )
					    								 FROM INCOME_ONLY D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.NON_BILL_FLAG = 1 )
												WHEN 'V' THEN 
													( SELECT COALESCE( SUM( D.AP_PROD_EXT_AMT ) / ( @job_count ), 0 )
					    								 FROM AP_PRODUCTION D, JOB_COMPONENT JC
					   								WHERE D.JOB_NUMBER = JC.JOB_NUMBER
					     								  AND D.JOB_COMPONENT_NBR = JC.JOB_COMPONENT_NBR
														  AND JC.ROWID IN ( SELECT ROW_ID FROM @ROW_IDS	 )
					     								  AND D.FNC_CODE = et.FNC_CODE
					     								  AND D.AP_PROD_NOBILL_FLG = 1 ) 
												WHEN 'C' THEN 0.00
			    							END
	                                                     
	FROM @ET et, FUNCTIONS f
	   WHERE et.FNC_CODE = f.FNC_CODE
	GROUP BY et.FNC_CODE,   
			 f.FNC_DESCRIPTION,   
			 f.FNC_TYPE,
					  f.FNC_INACTIVE  ) A
	WHERE cc_est_hrs  <> 0 OR   cc_est_amount  <> 0 OR  cc_est_tax  <> 0 OR   cc_est_total  <> 0 OR   cc_actual_hrs  <> 0 OR   
			cc_actual_amount  <> 0 OR   cc_actual_tax  <> 0 OR   cc_actual_total  <> 0 OR   cc_nb_actual_total  <> 0 OR   
			cc_open_po  <> 0  OR cc_open_po = 0 OR   cc_billed  <> 0 OR   cc_qva  <> 0 OR   cc_qva_po  <> 0 OR   
			cc_avb_po  <> 0 OR   cc_est_mkp  <> 0 OR   cc_actual_mkp <> 0         
	ORDER BY FNC_TYPE, FNC_DESCRIPTION
                 
END  /* SP */                  