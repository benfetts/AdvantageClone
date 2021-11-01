﻿CREATE PROC advsp_ap_import_set_invoice_description @batch_name varchar(50), @description_option varchar(50)

AS

IF @description_option = 'CDP_Codes'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = D.CL_CODE + '/' + D.DIV_CODE + '/' + D.PRD_CODE
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CL_CODE) AS CL_CODE, MIN(D.DIV_CODE) AS DIV_CODE, MIN(D.PRD_CODE) AS PRD_CODE
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, CL_CODE, DIV_CODE, PRD_CODE
				 FROM dbo.IMP_AP_MEDIA 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, CL_CODE, DIV_CODE, PRD_CODE
				 FROM dbo.IMP_AP_JOB
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND NULLIF(CL_CODE,'') IS NOT NULL
			AND NULLIF(DIV_CODE,'') IS NOT NULL
			AND NULLIF(PRD_CODE,'') IS NOT NULL
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID  
	WHERE H.BATCH_NAME = @batch_name 

ELSE IF @description_option = 'Client_Name'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = SUBSTRING(COALESCE(C.CL_NAME,''),1,30)
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CL_CODE) AS CL_CODE
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, CL_CODE
				 FROM dbo.IMP_AP_MEDIA 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, CL_CODE
				 FROM dbo.IMP_AP_JOB
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND NULLIF(CL_CODE,'') IS NOT NULL
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
		INNER JOIN dbo.CLIENT C ON D.CL_CODE = C.CL_CODE 
	WHERE H.BATCH_NAME = @batch_name 

ELSE IF @description_option = 'Product_Name'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = SUBSTRING(COALESCE(P.PRD_DESCRIPTION,''),1,30)
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CL_CODE) AS CL_CODE, MIN(D.DIV_CODE) AS DIV_CODE, MIN(D.PRD_CODE) AS PRD_CODE
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, CL_CODE, DIV_CODE, PRD_CODE 
				 FROM dbo.IMP_AP_MEDIA 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, CL_CODE, DIV_CODE, PRD_CODE
				 FROM dbo.IMP_AP_JOB
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND NULLIF(PRD_CODE,'') IS NOT NULL
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
		INNER JOIN dbo.PRODUCT P ON D.CL_CODE = P.CL_CODE AND D.DIV_CODE = P.DIV_CODE AND D.PRD_CODE = P.PRD_CODE 
	WHERE H.BATCH_NAME = @batch_name 

ELSE IF @description_option = 'Client_Name_and_Client_PO'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = RTRIM(SUBSTRING(COALESCE(C.CL_NAME,''),1,17)) + ':' + SUBSTRING(COALESCE(D.CLIENT_PO,''),1,12)
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CL_CODE) AS CL_CODE, MIN(D.CLIENT_PO) AS CLIENT_PO
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, D.CL_CODE, D.CLIENT_PO 
				 FROM dbo.IMP_AP_MEDIA IM
					INNER JOIN 
					(
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE
						FROM dbo.INTERNET_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE
						FROM dbo.MAGAZINE_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE
						FROM dbo.NEWSPAPER_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE
						FROM dbo.OUTDOOR_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE
						FROM dbo.RADIO_HDR  
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE
						FROM dbo.TV_HDR 
					) D ON IM.ORDER_NUMBER = D.ORDER_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, J.CL_CODE, JC.JOB_CL_PO_NBR 
				 FROM dbo.IMP_AP_JOB IJ
					INNER JOIN dbo.JOB_LOG J ON J.JOB_NUMBER = IJ.JOB_NBR 
					INNER JOIN dbo.JOB_COMPONENT JC ON IJ.JOB_NBR = JC.JOB_NUMBER AND IJ.COMP_NBR = JC.JOB_COMPONENT_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND (NULLIF(CL_CODE,'') IS NOT NULL
				 OR NULLIF(CLIENT_PO,'') IS NOT NULL)
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
		INNER JOIN dbo.CLIENT C ON D.CL_CODE = C.CL_CODE 
	WHERE H.BATCH_NAME = @batch_name 

ELSE IF @description_option = 'Product_Name_and_Client_PO'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = RTRIM(SUBSTRING(COALESCE(P.PRD_DESCRIPTION,''),1,17)) + ':' + SUBSTRING(COALESCE(D.CLIENT_PO,''),1,12)
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CL_CODE) AS CL_CODE, MIN(D.DIV_CODE) AS DIV_CODE, MIN(D.PRD_CODE) AS PRD_CODE, MIN(D.CLIENT_PO) AS CLIENT_PO
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, D.CL_CODE, D.DIV_CODE, D.PRD_CODE, D.CLIENT_PO 
				 FROM dbo.IMP_AP_MEDIA IM
					INNER JOIN 
					(
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.INTERNET_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.MAGAZINE_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.NEWSPAPER_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.OUTDOOR_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.RADIO_HDR  
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.TV_HDR 
					) D ON IM.ORDER_NUMBER = D.ORDER_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, J.CL_CODE, J.DIV_CODE, J.PRD_CODE, JC.JOB_CL_PO_NBR 
				 FROM dbo.IMP_AP_JOB IJ
					INNER JOIN dbo.JOB_LOG J ON J.JOB_NUMBER = IJ.JOB_NBR 
					INNER JOIN dbo.JOB_COMPONENT JC ON IJ.JOB_NBR = JC.JOB_NUMBER AND IJ.COMP_NBR = JC.JOB_COMPONENT_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND (NULLIF(PRD_CODE,'') IS NOT NULL
				 OR NULLIF(CLIENT_PO,'') IS NOT NULL)
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
		INNER JOIN dbo.PRODUCT P ON D.CL_CODE = P.CL_CODE AND D.DIV_CODE = P.DIV_CODE AND D.PRD_CODE = P.PRD_CODE
	WHERE H.BATCH_NAME = @batch_name 

ELSE IF @description_option = 'Campaign_Code_and_Name'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = SUBSTRING(COALESCE(C.CMP_CODE,'') + ' - ' + COALESCE(C.CMP_NAME,''),1,30)
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CMP_CODE) AS CMP_CODE
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, D.CMP_CODE
				 FROM dbo.IMP_AP_MEDIA IM
					INNER JOIN 
					(
						SELECT ORDER_NBR, CMP_CODE 
						FROM dbo.INTERNET_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE
						FROM dbo.MAGAZINE_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE
						FROM dbo.NEWSPAPER_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE
						FROM dbo.OUTDOOR_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE
						FROM dbo.RADIO_HDR  
						UNION
						SELECT ORDER_NBR, CMP_CODE
						FROM dbo.TV_HDR 
					) D ON IM.ORDER_NUMBER = D.ORDER_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, J.CMP_CODE
				 FROM dbo.IMP_AP_JOB IJ
					INNER JOIN dbo.JOB_LOG J ON IJ.JOB_NBR = J.JOB_NUMBER 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND NULLIF(CMP_CODE,'') IS NOT NULL
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
		INNER JOIN dbo.CAMPAIGN C ON D.CMP_CODE = C.CMP_CODE
	WHERE H.BATCH_NAME = @batch_name 

ELSE IF @description_option = 'CDP_Campaign_Codes'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = COALESCE(D.CL_CODE,'') + '/' + COALESCE(D.DIV_CODE,'') + '/' + COALESCE(D.PRD_CODE,'') + ' - ' + COALESCE(D.CMP_CODE,'')
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CMP_CODE) AS CMP_CODE, MIN(D.CL_CODE) AS CL_CODE, MIN(D.DIV_CODE) AS DIV_CODE, MIN(D.PRD_CODE) AS PRD_CODE
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, D.CMP_CODE, D.CL_CODE, D.DIV_CODE, D.PRD_CODE 
				 FROM dbo.IMP_AP_MEDIA IM
					INNER JOIN 
					(
						SELECT ORDER_NBR, CMP_CODE, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.INTERNET_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.MAGAZINE_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.NEWSPAPER_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.OUTDOOR_HEADER 
						UNION
						SELECT ORDER_NBR, CMP_CODE, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.RADIO_HDR  
						UNION
						SELECT ORDER_NBR, CMP_CODE, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.TV_HDR 
					) D ON IM.ORDER_NUMBER = D.ORDER_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, J.CMP_CODE, J.CL_CODE, J.DIV_CODE, J.PRD_CODE
				 FROM dbo.IMP_AP_JOB IJ
					INNER JOIN dbo.JOB_LOG J ON IJ.JOB_NBR = J.JOB_NUMBER 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND NULLIF(CL_CODE,'') IS NOT NULL
			AND NULLIF(DIV_CODE,'') IS NOT NULL
			AND NULLIF(PRD_CODE,'') IS NOT NULL
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
	WHERE H.BATCH_NAME = @batch_name

ELSE IF @description_option = 'CDP_Codes_and_Client_PO'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = SUBSTRING(COALESCE(D.CL_CODE,'') + '/' + COALESCE(D.DIV_CODE,'') + '/' + COALESCE(D.PRD_CODE,'') + ':' + COALESCE(D.CLIENT_PO,''),1,30)
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CL_CODE) AS CL_CODE, MIN(D.DIV_CODE) AS DIV_CODE, MIN(D.PRD_CODE) AS PRD_CODE, MIN(D.CLIENT_PO) AS CLIENT_PO
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, D.CL_CODE, D.DIV_CODE, D.PRD_CODE, D.CLIENT_PO 
				 FROM dbo.IMP_AP_MEDIA IM
					INNER JOIN 
					(
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.INTERNET_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.MAGAZINE_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.NEWSPAPER_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.OUTDOOR_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.RADIO_HDR  
						UNION
						SELECT CLIENT_PO, ORDER_NBR, CL_CODE, DIV_CODE, PRD_CODE
						FROM dbo.TV_HDR 
					) D ON IM.ORDER_NUMBER = D.ORDER_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, J.CL_CODE, J.DIV_CODE, J.PRD_CODE, JC.JOB_CL_PO_NBR 
				 FROM dbo.IMP_AP_JOB IJ
					INNER JOIN dbo.JOB_LOG J ON J.JOB_NUMBER = IJ.JOB_NBR 
					INNER JOIN dbo.JOB_COMPONENT JC ON IJ.JOB_NBR = JC.JOB_NUMBER AND IJ.COMP_NBR = JC.JOB_COMPONENT_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND NULLIF(CL_CODE,'') IS NOT NULL
			AND NULLIF(DIV_CODE,'') IS NOT NULL
			AND NULLIF(PRD_CODE,'') IS NOT NULL
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
	WHERE H.BATCH_NAME = @batch_name 

ELSE IF @description_option = 'Client_PO'

	UPDATE dbo.IMP_AP_HEADER SET INV_DESC = SUBSTRING(COALESCE(D.CLIENT_PO,''),1,30)
	FROM dbo.IMP_AP_HEADER H
		INNER JOIN (
			SELECT H.IMPORT_ID, MIN(D.CLIENT_PO) AS CLIENT_PO
			FROM dbo.IMP_AP_HEADER H
				INNER JOIN
				(SELECT IMPORT_ID, D.CLIENT_PO 
				 FROM dbo.IMP_AP_MEDIA IM
					INNER JOIN 
					(
						SELECT CLIENT_PO, ORDER_NBR
						FROM dbo.INTERNET_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR
						FROM dbo.MAGAZINE_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR
						FROM dbo.NEWSPAPER_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR
						FROM dbo.OUTDOOR_HEADER 
						UNION
						SELECT CLIENT_PO, ORDER_NBR
						FROM dbo.RADIO_HDR  
						UNION
						SELECT CLIENT_PO, ORDER_NBR
						FROM dbo.TV_HDR 
					) D ON IM.ORDER_NUMBER = D.ORDER_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				 UNION
				 SELECT IMPORT_ID, JC.JOB_CL_PO_NBR 
				 FROM dbo.IMP_AP_JOB IJ
					INNER JOIN dbo.JOB_LOG J ON J.JOB_NUMBER = IJ.JOB_NBR 
					INNER JOIN dbo.JOB_COMPONENT JC ON IJ.JOB_NBR = JC.JOB_NUMBER AND IJ.COMP_NBR = JC.JOB_COMPONENT_NBR 
				 WHERE IMPORT_ID IN (SELECT IMPORT_ID FROM dbo.IMP_AP_HEADER WHERE BATCH_NAME = @batch_name)
				) D ON H.IMPORT_ID = D.IMPORT_ID 
			WHERE H.BATCH_NAME = @batch_name 
			AND NULLIF(CLIENT_PO,'') IS NOT NULL
			GROUP BY H.IMPORT_ID) D ON H.IMPORT_ID = D.IMPORT_ID 
	WHERE H.BATCH_NAME = @batch_name 

GO