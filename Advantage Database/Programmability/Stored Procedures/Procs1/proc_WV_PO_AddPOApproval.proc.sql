









CREATE PROCEDURE [dbo].[proc_WV_PO_AddPOApproval]
	@PO_NUMBER int,
	@PO_APPR_RULE_CODE varchar(6),
	@SEQ_NBR smallint, 
	@PO_APPR_RULE_ID int, 
	@PO_APPROVAL_FLAG bit,
	@PO_APPROVAL_USER varchar(100),
	@PO_APPROVAL_DATE smalldatetime,
	@PO_APPROVAL_NOTES text
AS


	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err2 int
	 
	INSERT INTO [PO_APPROVAL]
			   ([PO_NUMBER]
			   ,[PO_APPR_RULE_CODE]
			   ,[SEQ_NBR]
			   ,[PO_APPR_RULE_ID]
			   ,[PO_APPROVAL_FLAG]
			   ,[PO_APPROVAL_USER]
			   ,[PO_APPROVAL_DATE]
			   ,[PO_APPROVAL_NOTES])
		 VALUES
			   (@PO_NUMBER,
				@PO_APPR_RULE_CODE,
				@SEQ_NBR, 
				@PO_APPR_RULE_ID, 
				@PO_APPROVAL_FLAG,
				@PO_APPROVAL_USER,
				@PO_APPROVAL_DATE,
				@PO_APPROVAL_NOTES
				)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END


















