 CREATE PROCEDURE advsp_get_billing_rate @emp_code VARCHAR(6),
					@eff_date SMALLDATETIME, 
					@fnc_code VARCHAR(6), 
					@cl_code VARCHAR(6),
					@div_code VARCHAR(6), 
					@prd_code VARCHAR(6), 
					@sc_code VARCHAR(6), 
					@fnc_type VARCHAR(1), 
					@job_number INTEGER, 
					@job_component_nbr SMALLINT
 
 AS
 
 SELECT * 
 FROM [dbo].[advtf_get_billing_rate] (@emp_code, 
										@eff_date, 
										@fnc_code, 
										@cl_code,
										@div_code, 
										@prd_code,
										@sc_code, 
										@fnc_type, 
										@job_number, 
										@job_component_nbr,
										NULL)
GO
