CREATE PROCEDURE [dbo].[advsp_estimate_printing_load_standardestimatedetails]
	@UserCode AS varchar(100),
	@EstimateNumber AS int,
	@EstimateCompNumber as smallint,
	@AddressBlockType AS smallint,
	@PrintClientName AS bit,
	@PrintDivisionName AS bit,
	@PrintProductDescription AS bit,
	@PrintContactAfterAddress AS bit,
	@ContactType AS smallint,
	@ShowCodes AS bit,
	@ClientCode as Varchar(6),
	@DivisionCode as varchar(6),
	@ProductCode as varchar(6)
AS
BEGIN
	
	SELECT DISTINCT		
		[Address] = CASE WHEN OCDPC.CDP_CONTACT_ID IS NOT NULL THEN dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																										C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																										C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																										C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																										D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																										D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																										D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																										P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																										P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																										P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																										OCDPC.CDP_CONTACT_ID, OCDPC.CONT_CODE, OCDPC.CONT_FNAME, OCDPC.CONT_LNAME, OCDPC.CONT_MI,
																										OCDPC.CONT_ADDRESS1, OCDPC.CONT_ADDRESS2, OCDPC.CONT_CITY,
																										OCDPC.CONT_COUNTY, OCDPC.CONT_STATE, OCDPC.CONT_COUNTRY, OCDPC.CONT_ZIP, @ContactType, 'Estimate') 
															   ELSE dbo.advfn_invoice_printing_address(@AddressBlockType, @ShowCodes, @PrintClientName, @PrintDivisionName, @PrintProductDescription, @PrintContactAfterAddress,  
																										C.CL_CODE, C.CL_NAME, C.CL_ATTENTION,
																										C.CL_BADDRESS1, C.CL_BADDRESS2, C.CL_BCITY,
																										C.CL_BCOUNTY, C.CL_BSTATE, C.CL_BCOUNTRY, C.CL_BZIP,
																										D.DIV_CODE, D.DIV_NAME, D.DIV_ATTENTION,
																										D.DIV_BADDRESS1, D.DIV_BADDRESS2, D.DIV_BCITY,
																										D.DIV_BCOUNTY, D.DIV_BSTATE, D.DIV_BCOUNTRY, D.DIV_BZIP,
																										P.PRD_CODE, P.PRD_DESCRIPTION, P.PRD_ATTENTION,
																										P.PRD_BILL_ADDRESS1, P.PRD_BILL_ADDRESS2, P.PRD_BILL_CITY,
																										P.PRD_BILL_COUNTY, P.PRD_BILL_STATE, P.PRD_BILL_COUNTRY, P.PRD_BILL_ZIP,
																										CDPC.CDP_CONTACT_ID, CDPC.CONT_CODE, CDPC.CONT_FNAME, CDPC.CONT_LNAME, CDPC.CONT_MI,
																										CDPC.CONT_ADDRESS1, CDPC.CONT_ADDRESS2, CDPC.CONT_CITY,
																										CDPC.CONT_COUNTY, CDPC.CONT_STATE, CDPC.CONT_COUNTRY, CDPC.CONT_ZIP, @ContactType, 'Job') END
	FROM [dbo].[ESTIMATE_LOG] AS EL INNER JOIN 
					[dbo].[ESTIMATE_COMPONENT] AS EC ON EC.ESTIMATE_NUMBER = EL.ESTIMATE_NUMBER INNER JOIN 
			[dbo].[PRODUCT] AS P ON P.CL_CODE = EL.CL_CODE AND 
									P.DIV_CODE = EL.DIV_CODE AND 
									P.PRD_CODE = EL.PRD_CODE INNER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = P.CL_CODE AND
									 D.DIV_CODE = P.DIV_CODE INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = P.CL_CODE LEFT OUTER JOIN 
			[dbo].[CDP_CONTACT_HDR] AS OCDPC ON OCDPC.CDP_CONTACT_ID = EC.CDP_CONTACT_ID LEFT OUTER JOIN
			[dbo].[JOB_COMPONENT] AS JC ON EC.ESTIMATE_NUMBER = JC.ESTIMATE_NUMBER AND 
                      EC.EST_COMPONENT_NBR = JC.EST_COMPONENT_NBR LEFT OUTER JOIN 
			[dbo].[CDP_CONTACT_HDR] AS CDPC ON CDPC.CDP_CONTACT_ID = JC.CDP_CONTACT_ID
	WHERE EL.ESTIMATE_NUMBER = @EstimateNumber AND EC.EST_COMPONENT_NBR = @EstimateCompNumber
		
		
END








GO


