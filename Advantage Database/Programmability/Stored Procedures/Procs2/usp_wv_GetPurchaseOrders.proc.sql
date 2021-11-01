/****** Object:  StoredProcedure [dbo].[usp_wv_GetPurchaseOrders]    Script Date: 8/14/2019 4:52:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/*
	DECLARE @Status int
	set @status = 3
	exec usp_wv_GetPurchaseOrders 'sysadm',0,'',0,0,'','','','',null,null,null,'','',3,0,0,0
*/

CREATE PROCEDURE [dbo].[usp_wv_GetPurchaseOrders](
		@UserID VARCHAR(6),
		@PONumber int,
		@Description VARCHAR(50),
		@JobCode INT,
		@ComponentCode INT,
		@ClientCode VARCHAR(6),
		@DivisionCode VARCHAR(6),
		@ProductCode VARCHAR(6),
		@VendorCode VARCHAR(6),
		@FromDate DATETIME,
		@ToDate DATETIME,
		@DueDate DATETIME,
		@EmployeeCode VARCHAR(6),
		@ApproverCode VARCHAR(6),
		@Status smallint,
		@OmitVoided smallint,
		@OmitClosed smallint,
		@Printed smallint
)
AS
	DECLARE @JobNumberString VARCHAR(10) = '%' + CAST(@JobCode AS VARCHAR(10)) + '%',
		@ComponentCodeString VARCHAR(10) = '%' + cast (@ComponentCode AS VARCHAR(10)) + '%',
		@ClientCodeString VARCHAR(10) = '%' + @ClientCode + '%',
		@DivisionCodeString VARCHAR(10) = '%' + @DivisionCode + '%',
		@ProductCodeString VARCHAR(10) = '%' + @ProductCode + '%'
	set @PONumber = NULLIF(@PONumber,'')
	set @JobCode = NULLIF(@JobCode,0)
	SET @Description = LOWER(@Description)
	SET @Description = NULLIF(@Description,'')
	SET @VendorCode = NULLIF(@VendorCode,'')
	SET @EmployeeCode = NULLIF(@EmployeeCode,'')
	SET @PRINTED = NULLIF(@PRINTED,0)
	SET @ApproverCode = NULLIF(@ApproverCode,'')
	set @ClientCode = NULLIF(@ClientCode,'')
	Set @ComponentCode = NULLIF(@ComponentCode,0)
	set @DivisionCode = NULLIF(@DivisionCode,'')
	Set @DivisionCodeString = NULLIF(@DivisionCodeString,'')
	set @ProductCode = NULLIF(@ProductCode,'')
	Set @ProductCodeString = NULLIF(@ProductCodeString,'')

	if @FromDate is Null 
	begin
		set @FromDate = cast('1900-01-01 00:00:00' as datetime)
	end
	
	if @ToDate is Null 
	begin
		set @ToDate = cast('2900-01-01 00:00:00' as datetime)
	end


	select PO.PO_NUMBER PONumber
		,DISPLAY_PO_NUMBER DisplayPONumber
		,PO.PO_CREATE_DATE CreateDate
		,PO.VN_CODE VendorCode
		,VN.VN_NAME VendorName
		,PO.EMP_CODE IssuedByCode
		,PO.PO_DATE PODate
		,PO.PO_DUE_DATE DueDate
		,PO.PO_DESCRIPTION Description
		,PO.VOID_FLAG Voided
		,PO.VOID_DATE VoidDate
		,PO.PO_REVISION Revision
		,PO.PO_APPROVAL_FLAG Approved
		,PO.PO_PRINTED Printed
		,EMP.EMP_FNAME FirstName
		,EMP.EMP_LNAME LastName
		,EMP.EMP_MI MiddleInitial
		,POD.CL_CODES
		,PO.PO_APPROVAL_FLAG
		from PURCHASE_ORDER PO
			join V_PURCHASE_ORDER vpo on vpo.PO_NUMBER = PO.PO_NUMBER
			JOIN VENDOR VN on VN.VN_CODE = PO.VN_CODE
			left JOIN EMPLOYEE EMP on EMP.EMP_CODE = PO.EMP_CODE
			LEFT JOIN (select PO_NUMBER,
			 STUFF((
				SELECT distinct ', ' + cast([JOB_NUMBER] as VARCHAR(6))
				FROM PURCHASE_ORDER_DET 
				WHERE (PO_NUMBER = DETAILS.PO_NUMBER) 
				FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
			  ,1,2,'') AS JOB_NUMBERS,
			 STUFF((
				SELECT distinct ', ' + cast(CL_CODE as VARCHAR(6))
				FROM PURCHASE_ORDER_DET 
				left Join JOB_LOG on JOB_LOG.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER
				WHERE (PO_NUMBER = DETAILS.PO_NUMBER) 
				FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
			  ,1,2,'') AS CL_CODES,
			 STUFF((
				SELECT distinct ', ' + DIV_CODE 
				FROM PURCHASE_ORDER_DET 
				left Join JOB_LOG on JOB_LOG.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER
				WHERE (PO_NUMBER = DETAILS.PO_NUMBER) 
				FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
			  ,1,2,'') AS DIV_CODES,
			 STUFF((
				SELECT distinct ', ' + PRD_CODE 
				FROM PURCHASE_ORDER_DET 
				left Join JOB_LOG on JOB_LOG.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER
				WHERE (PO_NUMBER = DETAILS.PO_NUMBER) 
				FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
			  ,1,2,'') AS PRD_CODES,
			 STUFF((
				SELECT distinct ', ' + cast(JOB_COMPONENT.JOB_COMPONENT_NBR as VARCHAR(6))
				FROM PURCHASE_ORDER_DET 
				left Join JOB_LOG on JOB_LOG.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER
				left join JOB_COMPONENT on JOB_COMPONENT.JOB_NUMBER = PURCHASE_ORDER_DET.JOB_NUMBER and JOB_COMPONENT.JOB_COMPONENT_NBR = PURCHASE_ORDER_DET.JOB_COMPONENT_NBR
				WHERE (PO_NUMBER = DETAILS.PO_NUMBER) 
				FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
			  ,1,2,'') AS COMPONENT_IDS
				from PURCHASE_ORDER_DET DETAILS
					left join JOB_LOG JL on JL.JOB_NUMBER = DETAILS.JOB_NUMBER
				GROUP BY PO_NUMBER) AS POD ON POD.PO_NUMBER = PO.PO_NUMBER
			 LEFT JOIN	dbo.PO_APPROVAL ON PO.PO_NUMBER = PO_APPROVAL.PO_NUMBER 
			 LEFT JOIN	dbo.PO_APPR_RULE_EMP ON PO_APPROVAL.PO_APPR_RULE_ID = PO_APPR_RULE_EMP.PO_APPR_RULE_ID
		WHERE (@PONUMBER IS NULL or PO.PO_NUMBER = @PONUMBER)
			AND (@Description is null or LOWER(PO.PO_DESCRIPTION) like '%' + @Description + '%')
			AND (@JobCode is null OR POD.JOB_NUMBERS LIKE @JobNumberString)
			AND (@ComponentCode is null OR POD.COMPONENT_IDS LIKE @ComponentCodeString)
			AND (@ClientCode is null OR POD.CL_CODES LIKE @ClientCodeString)
			AND (@DivisionCode is null OR POD.DIV_CODES LIKE @DivisionCodeString)
			AND (@ProductCode is null OR POD.PRD_CODES LIKE @ProductCodeString)
			And (@VendorCode IS NULL OR PO.VN_CODE = @VendorCode)
			AND (@DueDate IS NULL or PO.PO_DUE_DATE = @DueDate)
			AND (@EmployeeCode IS NULL OR PO.EMP_CODE = @EmployeeCode)
			AND (@Status = 0 OR (PO.PO_APPROVAL_FLAG = @Status))
			AND (@Printed IS NULL OR PO.PO_PRINTED = 1)
			AND (@ApproverCode IS NULL OR PO_APPR_RULE_EMP.EMP_CODE = @ApproverCode)
			AND PO.PO_DATE BETWEEN @FromDate AND @ToDate
			AND (@OmitVoided = 0 or PO.VOID_FLAG = 0 or PO.VOID_FLAG is null)
			AND (@OmitClosed = 0 or PO.PO_COMPLETE = 0 or PO.PO_COMPLETE is null)
		group by PO.PO_NUMBER
		,DISPLAY_PO_NUMBER
		,PO.PO_CREATE_DATE
		,PO.VN_CODE
		,VN.VN_NAME
		,PO.EMP_CODE
		,PO.PO_DATE
		,PO.PO_DUE_DATE
		,PO.PO_DESCRIPTION
		,PO.VOID_FLAG
		,PO.VOID_DATE
		,PO.PO_REVISION
		,PO.PO_APPROVAL_FLAG
		,PO.PO_PRINTED
		,EMP.EMP_FNAME
		,EMP.EMP_LNAME
		,EMP.EMP_MI
		,POD.CL_CODES
		ORDER BY PO.PO_NUMBER DESC



GO


