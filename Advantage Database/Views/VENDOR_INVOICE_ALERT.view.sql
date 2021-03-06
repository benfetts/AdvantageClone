CREATE VIEW [dbo].[VENDOR_INVOICE_ALERT]
WITH SCHEMABINDING 
AS

SELECT
--AL.ALERT_ID,
--RECIPIENTS.ALERT_ID AS RALERT, 
--DISMISSEDS.ALERT_ID AS DALERT,
--AL.ALERT_STATE_ID ,
--AL.ALRT_NOTIFY_HDR_ID ,
--RECIPIENT.AssignedTo AS RAssignedTo,
	[AccountPayableID] = A.AP_ID,
	[AccountPayableSequenceNumber] = A.AP_SEQ,
	[VendorCode] = A.VN_FRL_EMP_CODE,
	[VendorName] = V.VN_NAME,
	[VendorCategory] = V.VN_CATEGORY,
	[OfficeCode] = A.OFFICE_CODE,
	[OfficeName] = O.OFFICE_NAME,
	[InvoiceNumber] = A.AP_INV_VCHR,
	[InvoiceDate] = A.AP_INV_DATE,
	[EntryDate] = A.CREATE_DATE,
	[InvoiceDescription] = A.AP_DESC,
	[InvoiceAmount] = A.AP_INV_AMT + COALESCE(A.AP_SHIPPING, 0) + COALESCE(A.AP_SALES_TAX, 0),
	[PaymentHold] = A.PAYMENT_HOLD,
	[Is1099Invoice] = A.FLAG_1099,
	[Template] = ANH.ALERT_NOTIFY_NAME,
	[State] = S.ALERT_STATE_NAME,
	[AssignedTo] = CASE
						WHEN AL.ALERT_STATE_ID IS NOT NULL AND AL.ALRT_NOTIFY_HDR_ID IS NOT NULL AND 
							(RECIPIENTS.ALERT_ID IS NOT NULL OR DISMISSEDS.ALERT_ID IS NOT NULL) THEN 'Completed'
				        WHEN AL.ALERT_STATE_ID IS NOT NULL AND AL.ALRT_NOTIFY_HDR_ID IS NOT NULL AND RECIPIENT.AssignedTo IS NOT NULL THEN RECIPIENT.AssignedTo
				        WHEN AL.ALERT_STATE_ID IS NOT NULL AND AL.ALRT_NOTIFY_HDR_ID IS NOT NULL AND DISMISSED.AssignedTo IS NOT NULL THEN DISMISSED.AssignedTo
				        WHEN AL.ALERT_STATE_ID IS NOT NULL AND AL.ALRT_NOTIFY_HDR_ID IS NOT NULL THEN 'Unassigned'
				        ELSE ''
				   END,
	[Priority] = CASE AL.PRIORITY
						WHEN 1 THEN 'Highest'
						WHEN 2 THEN 'High'
						WHEN 3 THEN '--'
						WHEN 4 THEN 'Low'
						WHEN 5 THEN 'Lowest'
				 END,
	[DueDate] = AL.DUE_DATE,
	[TimeDue] = AL.TIME_DUE,
	[VendorOfficeCode] = V.OFFICE_CODE

FROM [dbo].AP_HEADER A
	INNER JOIN [dbo].VENDOR V ON A.VN_FRL_EMP_CODE = V.VN_CODE 
	LEFT OUTER JOIN [dbo].OFFICE O ON A.OFFICE_CODE = O.OFFICE_CODE
	INNER JOIN [dbo].[ALERT] AL ON A.AP_ID = AL.AP_ID AND A.AP_SEQ = AL.AP_SEQ 
	LEFT OUTER JOIN [dbo].ALERT_NOTIFY_HDR ANH ON AL.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID 
	LEFT OUTER JOIN [dbo].ALERT_STATES S ON AL.ALERT_STATE_ID = S.ALERT_STATE_ID 
	LEFT OUTER JOIN (SELECT ALERT_ID
					 FROM [dbo].ALERT_RCPT 
					 WHERE CURRENT_NOTIFY = 1
					 AND PROCESSED IS NOT NULL) AS RECIPIENTS ON AL.ALERT_ID = RECIPIENTS.ALERT_ID 
	LEFT OUTER JOIN (SELECT ALERT_ID
					 FROM [dbo].ALERT_RCPT_DISMISSED 
					 WHERE CURRENT_NOTIFY = 1
					 AND PROCESSED IS NOT NULL) AS DISMISSEDS ON AL.ALERT_ID = DISMISSEDS.ALERT_ID 
	LEFT OUTER JOIN (SELECT ALERT_ID, COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,'') AS AssignedTo
					 FROM [dbo].ALERT_RCPT R
						INNER JOIN [dbo].EMPLOYEE_CLOAK E ON R.EMP_CODE = E.EMP_CODE 
					 WHERE CURRENT_NOTIFY = 1
					 AND PROCESSED IS NULL) AS RECIPIENT ON AL.ALERT_ID = RECIPIENT.ALERT_ID 
	LEFT OUTER JOIN (SELECT ALERT_ID, COALESCE((RTRIM(E.EMP_FNAME) + ' '),'') + COALESCE((E.EMP_MI + '. '),'') + COALESCE(E.EMP_LNAME,'') AS AssignedTo
					 FROM [dbo].ALERT_RCPT_DISMISSED D
						INNER JOIN [dbo].EMPLOYEE_CLOAK E ON D.EMP_CODE = E.EMP_CODE 
					 WHERE CURRENT_NOTIFY = 1
					 AND PROCESSED IS NULL) AS DISMISSED ON AL.ALERT_ID = DISMISSED.ALERT_ID 
WHERE (A.ARCHIVE_FLAG IS NULL OR A.ARCHIVE_FLAG = 0)
AND A.MODIFY_FLAG IS NULL
AND A.DELETE_FLAG IS NULL

GO