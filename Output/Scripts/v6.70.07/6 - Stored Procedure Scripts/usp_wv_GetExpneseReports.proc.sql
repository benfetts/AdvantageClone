/****** Object:  StoredProcedure [dbo].[usp_wv_GetExpneseReports]    Script Date: 12/18/2020 4:06:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- exec usp_wv_GetExpneseReports 'sysadm','ama',1,1,1,1

CREATE PROCEDURE [dbo].[usp_wv_GetExpneseReports](
		@UserID VARCHAR(100),
		@EmployeeCode as varchar(6),
		@ShowOpen as bit,
		@ShowPending as bit,
		@ShowApproved as bit,
		@ShowDenied as bit,
		@StartDate as DateTime = null,
		@EndDate as DateTime = null,
		@ClientCode as VARCHAR(6) = null,
		@JobNumber as int = null,
		@FunctionCode as VARCHAR(6) = null,
		@Description as VARCHAR(50) = null,
		@ItemDate as DateTime = null,
		@ExcludePaid as bit = 0,
		@ExcludeUnpaid as bit = 0
)
as
	-- exec usp_wv_GetExpneseReports 'sysadm','ama',1,1,1,1,null,null,'',0,null,null,null

	DECLARE @CL_CODE VARCHAR(10),
			@JOB_NBR VARCHAR(12),
			@FNC_CODE varchar(10),
			@DESC varchar(100)

	set @CL_CODE = '%' + @ClientCode + '%'
	set @FNC_CODE =	'%' + @FunctionCode + '%'
	set @JobNumber = nullif(@JobNumber,0)
	set @JOB_NBR = '%' + cast(@JobNumber as VARCHAR(10)) + '%'
	set @DESC = '%' + LOWER(@Description) + '%'

	if @StartDate is Null 
	begin
		set @StartDate = cast('1900-01-01 00:00:00' as datetime)
	end
	
	if @EndDate is Null 
	begin
		set @EndDate = cast('2900-01-01 00:00:00' as datetime)
	end

	select eh.INV_NBR InvoiceNumber,
		eh.EMP_CODE EmployeeCode,
		eh.VN_CODE VendorCode,
		eh.INV_DATE InvoiceDate,
		eh.EXP_DESC Description,
		eh.DTL_DESC Details,
		eh.DATE_FROM DateFrom,
		eh.DATE_TO DateTo,
		eh.INV_AMOUNT InvoiceAmount,
		eh.APPROVED_BY ApprovedBy,
		eh.APPROVED_DATE ApprovedDate,
		eh.STATUS Status,
		Case ISNULL(eh.STATUS,0) when 0 then 'Open'
			when 1 then 
				 Case When eh.SUBMITTED_FLAG = 0 Then 'Pending'
					  When eh.SUBMITTED_FLAG = 1 and eh.APPROVED_FLAG = 0 Then 'Pending'
					  When eh.SUBMITTED_FLAG = 1 and eh.APPROVED_FLAG = 1 Then 'Denied' Else 'Approved' End
			when 2 then 'Approved'
			when 4 then 'Pending'
			when 5 then 'Denied'
		END AS StatusCode,
		eh.APPR_NOTES ApproverNotes,
		eh.SUBMITTED_FLAG IsSubmitted,
		eh.APPROVED_FLAG IsApproved,
		eh.CREATE_USER_ID CreatedBy,
		eh.CREATE_DATE CreatedDate,
		eh.MOD_USER_ID ModifiedBy,
		eh.MOD_DATE ModifiedDate,
		eh.SUBMITTED_TO SubmittedTo,
		eh.BATCH_DATE BatchDate,
		TotalAmount,
		Billable TotalBillable,
		NonBillable TotalNonBillable,
		isnull(P.Paid,0) Paid,
        [HasDocuments] = CAST(CASE WHEN (SELECT COUNT(1) FROM dbo.EXPENSE_DOCS WHERE INV_NBR = eh.INV_NBR) > 0 THEN 1 ELSE 0 END AS bit),
        [AttachmentCount] = (SELECT COUNT(1) FROM dbo.EXPENSE_DOCS WHERE INV_NBR = eh.INV_NBR)
		from EXPENSE_HEADER eh
			LEFT JOIN (select INV_NBR,
		 STUFF((
			SELECT distinct ', ' + [CL_CODE] 
			FROM EXPENSE_DETAIL 
			WHERE (INV_NBR = ED.INV_NBR) 
			FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
		  ,1,2,'') AS CL_CODES,
		 STUFF((
			SELECT distinct '- ' + cast([JOB_NBR] as varchar(10)) 
			FROM EXPENSE_DETAIL 
			WHERE (INV_NBR = ED.INV_NBR) 
			FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
		  ,1,2,'') AS JOB_NBRS,
		 STUFF((
			SELECT distinct ', ' + [FNC_CODE] 
			FROM EXPENSE_DETAIL 
			WHERE (INV_NBR = ED.INV_NBR) 
			FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
		  ,1,2,'') AS FNC_CODES,
		SUM(AMOUNT) TotalAmount,
		SUM(CASE WHEN FU.NOBILL_FLAG = 0 AND ED.JOB_NBR IS NOT NULL THEN
			AMOUNT
			ELSE
			0.0
		END) AS Billable,
		SUM(CASE WHEN FU.NOBILL_FLAG > 0 OR ED.JOB_NBR IS NULL  THEN
			AMOUNT
			ELSE
			0.0
		END) AS NonBillable
			from EXPENSE_DETAIL ED
			cross apply advtf_get_billing_rate(@EmployeeCode,null,ED.FNC_CODE,ED.CL_CODE,ED.DIV_CODE,ED.PRD_CODE,null,null,ED.JOB_NBR,ED.JOB_COMP_NBR,null) FU
			WHERE LINE_NBR > 0
	group by INV_NBR) Details on Details.INV_NBR = eh.INV_NBR
			left join (SELECT EH.INV_NBR, COUNT(1) as Paid
				FROM AP_HEADER AH
					left join EXPENSE_HEADER EH on AH.VN_FRL_EMP_CODE = EH.VN_CODE 
						AND AH.AP_INV_VCHR = cast(EH.INV_NBR AS varchar(20))
					inner join AP_PMT_HIST APH on APH.AP_ID = AH.AP_ID
				WHERE EH.EMP_CODE = @EmployeeCode
					Group by EH.INV_NBR) as P on P.INV_NBR = eh.INV_NBR
		WHERE EMP_CODE = @EmployeeCode
			and ((@ShowOpen = 1 and ISNULL(eh.STATUS,0) = 0)
				or (@ShowPending = 1 and ((eh.STATUS = 1 and eh.SUBMITTED_FLAG = 0) or (eh.STATUS = 1 and eh.SUBMITTED_FLAG = 1 and eh.APPROVED_FLAG = 0) or (eh.STATUS = 4)))
				or (@ShowApproved = 1 and ((eh.STATUS = 2) or (eh.STATUS = 1 and eh.SUBMITTED_FLAG = 1 and eh.APPROVED_FLAG = 2)))
				or (@ShowDenied = 1 and ((eh.STATUS = 5) or (eh.STATUS = 1 and eh.SUBMITTED_FLAG = 1 and eh.APPROVED_FLAG = 1))))
			and INV_DATE Between @StartDate and @EndDate
			and (Details.CL_CODES like @CL_CODE 
				or NULLIF(@ClientCode,'') is null)
			and (Details.JOB_NBRS like  @JOB_NBR
				or NULLIF(@JobNumber,0) is null)
			and (Details.FNC_CODES like @FNC_CODE 
				or NULLIF(@FunctionCode,'') is null)
			and (LOWER(eh.EXP_DESC) like @DESC 
				or NULLIF(@Description,'') is null)
			and (@ExcludePaid = 0 or isnull(P.Paid,0) != 1)
			and (@ExcludeUnpaid = 0 or isnull(P.Paid,0) != 0 )
			and ( @ItemDate is null
				or 	eh.INV_NBR in (select INV_NBR from EXPENSE_DETAIL where EXPENSE_DETAIL.ITEM_DATE = @ItemDate))
				order by eh.INV_NBR DESC





GO


