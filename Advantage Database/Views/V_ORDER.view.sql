CREATE VIEW [dbo].[V_ORDER]
WITH SCHEMABINDING
AS

	SELECT 
		[MediaType],
		[OrderNumber],
		[OrderDescription],
		[OfficeCode],
		[OfficeName],
		[ClientCode],
		[ClientName],
		[DivisionCode],
		[DivisionName],
		[ProductCode],
		[ProductDescription],
		[VendorCode],
		[VendorName]	
	FROM
		(SELECT 
				[MediaType] = 'M',
				[OrderNumber] = MH.ORDER_NBR, 
				[OrderDescription] = MH.ORDER_DESC,
				[OfficeCode] = MH.OFFICE_CODE,
				[OfficeName] = O.OFFICE_NAME, 
				[ClientCode] = MH.CL_CODE, 
				[ClientName] = C.CL_NAME,
				[DivisionCode] = MH.DIV_CODE, 
				[DivisionName] = D.DIV_NAME,
				[ProductCode] = MH.PRD_CODE,
				[ProductDescription] = P.PRD_DESCRIPTION,
				[VendorCode] = MH.VN_CODE,
				[VendorName] = V.VN_NAME
			FROM 
				[dbo].[MAGAZINE_HEADER] AS MH 
				INNER JOIN [dbo].[CLIENT] AS C ON C.CL_CODE = MH.CL_CODE
				INNER JOIN [dbo].[DIVISION] AS D ON D.CL_CODE = MH.CL_CODE AND D.DIV_CODE = MH.DIV_CODE
				INNER JOIN [dbo].[PRODUCT] AS P ON P.CL_CODE = MH.CL_CODE AND P.DIV_CODE = MH.DIV_CODE AND P.PRD_CODE = MH.PRD_CODE
				LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = MH.OFFICE_CODE
				LEFT OUTER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = MH.VN_CODE

			UNION ALL

			SELECT 
				[MediaType] = 'N',
				[OrderNumber] = NH.ORDER_NBR, 
				[OrderDescription] = NH.ORDER_DESC,
				[OfficeCode] = NH.OFFICE_CODE,
				[OfficeName] = O.OFFICE_NAME, 
				[ClientCode] = NH.CL_CODE, 
				[ClientName] = C.CL_NAME,
				[DivisionCode] = NH.DIV_CODE, 
				[DivisionName] = D.DIV_NAME,
				[ProductCode] = NH.PRD_CODE,
				[ProductDescription] = P.PRD_DESCRIPTION,
				[VendorCode] = NH.VN_CODE,
				[VendorName] = V.VN_NAME
			FROM 
				[dbo].[NEWSPAPER_HEADER] AS NH 
				INNER JOIN [dbo].[CLIENT] AS C ON C.CL_CODE = NH.CL_CODE
				INNER JOIN [dbo].[DIVISION] AS D ON D.CL_CODE = NH.CL_CODE AND D.DIV_CODE = NH.DIV_CODE
				INNER JOIN [dbo].[PRODUCT] AS P ON P.CL_CODE = NH.CL_CODE AND P.DIV_CODE = NH.DIV_CODE AND P.PRD_CODE = NH.PRD_CODE
				LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = NH.OFFICE_CODE
				LEFT OUTER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = NH.VN_CODE
	
			UNION ALL

			SELECT 
				[MediaType] = 'I',
				[OrderNumber] = IH.ORDER_NBR, 
				[OrderDescription] = IH.ORDER_DESC,
				[OfficeCode] = IH.OFFICE_CODE,
				[OfficeName] = O.OFFICE_NAME, 
				[ClientCode] = IH.CL_CODE, 
				[ClientName] = C.CL_NAME,
				[DivisionCode] = IH.DIV_CODE, 
				[DivisionName] = D.DIV_NAME,
				[ProductCode] = IH.PRD_CODE,
				[ProductDescription] = P.PRD_DESCRIPTION,
				[VendorCode] = IH.VN_CODE,
				[VendorName] = V.VN_NAME
			FROM 
				[dbo].[INTERNET_HEADER] AS IH 
				INNER JOIN [dbo].[CLIENT] AS C ON C.CL_CODE = IH.CL_CODE
				INNER JOIN [dbo].[DIVISION] AS D ON D.CL_CODE = IH.CL_CODE AND D.DIV_CODE = IH.DIV_CODE
				INNER JOIN [dbo].[PRODUCT] AS P ON P.CL_CODE = IH.CL_CODE AND P.DIV_CODE = IH.DIV_CODE AND P.PRD_CODE = IH.PRD_CODE
				LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = IH.OFFICE_CODE
				LEFT OUTER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = IH.VN_CODE

			UNION ALL

			SELECT 
				[MediaType] = 'O',
				[OrderNumber] = OH.ORDER_NBR, 
				[OrderDescription] = OH.ORDER_DESC,
				[OfficeCode] = OH.OFFICE_CODE,
				[OfficeName] = O.OFFICE_NAME, 
				[ClientCode] = OH.CL_CODE, 
				[ClientName] = C.CL_NAME,
				[DivisionCode] = OH.DIV_CODE, 
				[DivisionName] = D.DIV_NAME,
				[ProductCode] = OH.PRD_CODE,
				[ProductDescription] = P.PRD_DESCRIPTION,
				[VendorCode] = OH.VN_CODE,
				[VendorName] = V.VN_NAME
			FROM 
				[dbo].[OUTDOOR_HEADER] AS OH 
				INNER JOIN [dbo].[CLIENT] AS C ON C.CL_CODE = OH.CL_CODE
				INNER JOIN [dbo].[DIVISION] AS D ON D.CL_CODE = OH.CL_CODE AND D.DIV_CODE = OH.DIV_CODE
				INNER JOIN [dbo].[PRODUCT] AS P ON P.CL_CODE = OH.CL_CODE AND P.DIV_CODE = OH.DIV_CODE AND P.PRD_CODE = OH.PRD_CODE
				LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = OH.OFFICE_CODE
				LEFT OUTER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = OH.VN_CODE

			UNION ALL

			SELECT 
				[MediaType] = 'R',
				[OrderNumber] = RH.ORDER_NBR, 
				[OrderDescription] = RH.ORDER_DESC,
				[OfficeCode] = RH.OFFICE_CODE,
				[OfficeName] = O.OFFICE_NAME, 
				[ClientCode] = RH.CL_CODE, 
				[ClientName] = C.CL_NAME,
				[DivisionCode] = RH.DIV_CODE, 
				[DivisionName] = D.DIV_NAME,
				[ProductCode] = RH.PRD_CODE,
				[ProductDescription] = P.PRD_DESCRIPTION,
				[VendorCode] = RH.VN_CODE,
				[VendorName] = V.VN_NAME
			FROM 
				[dbo].[RADIO_HDR] AS RH 
				INNER JOIN [dbo].[CLIENT] AS C ON C.CL_CODE = RH.CL_CODE
				INNER JOIN [dbo].[DIVISION] AS D ON D.CL_CODE = RH.CL_CODE AND D.DIV_CODE = RH.DIV_CODE
				INNER JOIN [dbo].[PRODUCT] AS P ON P.CL_CODE = RH.CL_CODE AND P.DIV_CODE = RH.DIV_CODE AND P.PRD_CODE = RH.PRD_CODE
				LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = RH.OFFICE_CODE
				LEFT OUTER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = RH.VN_CODE

			UNION ALL

			SELECT 
				[MediaType] = 'T',
				[OrderNumber] = TH.ORDER_NBR, 
				[OrderDescription] = TH.ORDER_DESC,
				[OfficeCode] = TH.OFFICE_CODE,
				[OfficeName] = O.OFFICE_NAME, 
				[ClientCode] = TH.CL_CODE, 
				[ClientName] = C.CL_NAME,
				[DivisionCode] = TH.DIV_CODE, 
				[DivisionName] = D.DIV_NAME,
				[ProductCode] = TH.PRD_CODE,
				[ProductDescription] = P.PRD_DESCRIPTION,
				[VendorCode] = TH.VN_CODE,
				[VendorName] = V.VN_NAME
			FROM 
				[dbo].[TV_HDR] AS TH 
				INNER JOIN [dbo].[CLIENT] AS C ON C.CL_CODE = TH.CL_CODE
				INNER JOIN [dbo].[DIVISION] AS D ON D.CL_CODE = TH.CL_CODE AND D.DIV_CODE = TH.DIV_CODE
				INNER JOIN [dbo].[PRODUCT] AS P ON P.CL_CODE = TH.CL_CODE AND P.DIV_CODE = TH.DIV_CODE AND P.PRD_CODE = TH.PRD_CODE
				LEFT OUTER JOIN [dbo].[OFFICE] AS O ON O.OFFICE_CODE = TH.OFFICE_CODE
				LEFT OUTER JOIN [dbo].[VENDOR] AS V ON V.VN_CODE = TH.VN_CODE) AS O


GO