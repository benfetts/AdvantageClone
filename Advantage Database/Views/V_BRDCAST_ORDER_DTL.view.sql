CREATE VIEW [dbo].[V_BRDCAST_ORDER_DTL]
	WITH SCHEMABINDING
AS

	SELECT
		[ID] = NEWID(),
		[DetailID] = DTL.DTL_ID,
		[MediaType] = 'TV',	
		[AccountPayableID] = DTL.AP_ID,
		[SequenceNumber] = DTL.AP_SEQ,
		[VendorCode] = V.VN_CODE,
		[VendorName] = V.VN_NAME,
		[Vendor] = V.VN_CODE + ' - ' + V.VN_NAME,
		[OrderNumber] = DTL.ORDER_NBR,
		[OrderLineNumber] = DTL.ORDER_LINE_NBR,
		[RunDate] = DTL.RUN_DATE,
		[RunTime] = DTL.TIME_OF_DAY,
		[DayOfWeekNumber] = DTL.DAY_OF_WEEK,
		[Length] = DTL.[LENGTH],
		[AdNumber] = DTL.AD_NUMBER,
		[NetworkID] = DTL.NETWORK_ID,
		[GrossRate] = DTL.GROSS_RATE,
		[Approved] = DTL.APPROVED,
		[Comment] = DTL.COMMENT,
        [ProgramName] = DTL.[PROGRAM_NAME]
	FROM
		dbo.AP_TV_BROADCAST_DTL DTL
	INNER JOIN
		dbo.AP_HEADER APH ON DTL.AP_ID = APH.AP_ID AND
							 DTL.AP_SEQ = APH.AP_SEQ
	LEFT OUTER JOIN	
		dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE

	UNION ALL
  
	SELECT
		[ID] = NEWID(),
		[DetailID] = DTL.DTL_ID,
		[MediaType] = 'Radio',
		[AccountPayableID] = DTL.AP_ID,
		[SequenceNumber] = DTL.AP_SEQ,
		[VendorCode] = V.VN_CODE,
		[VendorName] = V.VN_NAME,
		[Vendor] = V.VN_CODE + ' - ' + V.VN_NAME,
		[OrderNumber] = DTL.ORDER_NBR,
		[OrderLineNumber] = DTL.ORDER_LINE_NBR,
		[RunDate] = DTL.RUN_DATE,
		[RunTime] = DTL.TIME_OF_DAY,
		[DayOfWeekNumber] = DTL.DAY_OF_WEEK,
		[Length] = DTL.[LENGTH],
		[AdNumber] = DTL.AD_NUMBER,
		[NetworkID] = DTL.NETWORK_ID,
		[GrossRate] = DTL.GROSS_RATE,
		[Approved] = DTL.APPROVED,
		[Comment] = DTL.COMMENT,
        [ProgramName] = DTL.[PROGRAM_NAME]
	FROM
		dbo.AP_RADIO_BROADCAST_DTL DTL
	INNER JOIN
		dbo.AP_HEADER APH ON DTL.AP_ID = APH.AP_ID AND
							 DTL.AP_SEQ = APH.AP_SEQ
	LEFT OUTER JOIN	
		dbo.VENDOR V ON APH.VN_FRL_EMP_CODE = V.VN_CODE
