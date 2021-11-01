CREATE VIEW [dbo].[V_DRPT_DIVISIONS]

WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
		[ClientCode] = D.CL_CODE,
		[ClientName] = C.CL_NAME, 
		[DivisionCode] = D.DIV_CODE,
		[DivisionName] = D.DIV_NAME,
		[BillingAddress] = D.DIV_BADDRESS1,
		[BillingAddress2] = D.DIV_BADDRESS2,
		[BillingCity] = D.DIV_BCITY,
		[BillingCounty] = D.DIV_BCOUNTY,
		[BillingState] = D.DIV_BSTATE,
		[BillingZip] = D.DIV_BZIP,
		[BillingCountry] = D.DIV_BCOUNTRY,
        [StatementAddress] = D.DIV_SADDRESS1,
		[StatementAddress2] = D.DIV_SADDRESS2,
		[StatementCity] = D.DIV_SCITY,
		[StatementCounty] = D.DIV_SCOUNTY,
		[StatementState] = D.DIV_SSTATE,
		[StatementZip] = D.DIV_SZIP,
		[StatementCountry] = D.DIV_SCOUNTRY,
		[NewBusiness] = CASE WHEN C.NEW_BUSINESS = 1 THEN 'Y' ELSE 'N' END,
		[IsActive] = CASE WHEN ISNULL(C.ACTIVE_FLAG, 0) = 1 THEN 
							CASE WHEN ISNULL(D.ACTIVE_FLAG, 0) = 1 THEN 'Y' ELSE 'N' END 
					 ELSE 'N' END,
		[SortName] = D.DIV_ALPHA_SORT,
		[AttentionLine] = D.DIV_ATTENTION
	FROM
		dbo.DIVISION D INNER JOIN
		dbo.CLIENT C ON D.CL_CODE = C.CL_CODE
GO