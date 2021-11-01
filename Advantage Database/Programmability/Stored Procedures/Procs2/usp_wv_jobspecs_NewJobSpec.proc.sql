









CREATE PROCEDURE [dbo].[usp_wv_jobspecs_NewJobSpec]
	@JobNumber int,
	@JobCompNumber int,
	@Version int,
	@Revision int,	
	@UserID varchar(100),
	@Date smalldatetime,
	@SpecType varchar(6)
	
AS

--insert new job spec data
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

INSERT INTO [JOB_SPECS]
           ([JOB_NUMBER]
           ,[JOB_COMPONENT_NBR]
           ,[SPEC_VER]
           ,[SPEC_REV]
           ,[SPEC_REV_REASON]
           ,[SPEC_REV_AUTH]
           ,[SPEC_REV_USER_ID]
           ,[SPEC_REV_USER_DATE]
           ,[SPEC_TYPE_CODE]
           ,[SPEC_VER_DESC]
           ,[QTY1]
           ,[QTY2]
           ,[QTY3]
           ,[QTY4]
           ,[QTY5]
           ,[CHAR1_1]
           ,[CHAR1_2]
           ,[CHAR1_3]
           ,[CHAR1_4]
           ,[CHAR1_5]
           ,[CHAR10_1]
           ,[CHAR10_2]
           ,[CHAR10_3]
           ,[CHAR10_4]
           ,[CHAR10_5]
           ,[CHAR50_1]
           ,[CHAR50_2]
           ,[CHAR50_3]
           ,[CHAR50_4]
           ,[CHAR50_5]
           ,[CHAR50_6]
           ,[CHAR50_7]
           ,[CHAR254_1]
           ,[CHAR254_2]
           ,[CHAR254_3]
           ,[CHAR254_4]
           ,[SMALLINT_1]
           ,[SMALLINT_2]
           ,[SMALLINT_3]
           ,[SMALLINT_4]
           ,[SMALLINT_5]
           ,[SMALLINT_6]
           ,[SMALLINT_7]
           ,[SMALLINT_8]
           ,[INT_1]
           ,[INT_2]
           ,[INT_3]
           ,[INT_4]
           ,[INT_5]
           ,[INT_6]
           ,[INT_7]
           ,[INT_8]
           ,[INT_9]
           ,[INT_10]
           ,[TEXT_1]
           ,[TEXT_2]
           ,[TEXT_3]
           ,[TEXT_4]
           ,[TEXT_5]
           ,[TEXT_6]
           ,[TEXT_7]
           ,[TEXT_8]
           ,[CHAR1_6]
           ,[CHAR1_7]
           ,[CHAR1_8]
           ,[CHAR1_9]
           ,[CHAR1_10]
           ,[CHAR1_11]
           ,[CHAR1_12]
           ,[CHAR1_13]
           ,[CHAR1_14]
           ,[CHAR1_15]
           ,[CHAR1_16]
           ,[CHAR1_17]
           ,[CHAR1_18]
           ,[CHAR1_19]
           ,[CHAR1_20]
           ,[CHAR10_6]
           ,[CHAR10_7]
           ,[CHAR10_8]
           ,[CHAR10_9]
           ,[CHAR10_10]
           ,[CHAR10_11]
           ,[CHAR10_12]
           ,[CHAR10_13]
           ,[CHAR10_14]
           ,[CHAR10_15]
           ,[CHAR10_16]
           ,[CHAR10_17]
           ,[CHAR10_18]
           ,[CHAR10_19]
           ,[CHAR10_20]
           ,[CHAR50_8]
           ,[CHAR50_9]
           ,[CHAR50_10]
           ,[CHAR50_11]
           ,[CHAR50_12]
           ,[CHAR50_13]
           ,[CHAR50_14]
           ,[CHAR50_15]
           ,[CHAR50_16]
           ,[CHAR50_17]
           ,[CHAR50_18]
           ,[CHAR50_19]
           ,[CHAR50_20]
           ,[CHAR254_5]
           ,[CHAR254_6]
           ,[CHAR254_7]
           ,[CHAR254_8]
           ,[CHAR254_9]
           ,[CHAR254_10]
           ,[SMALLINT_9]
           ,[SMALLINT_10]
           ,[SMALLINT_11]
           ,[SMALLINT_12]
           ,[SMALLINT_13]
           ,[SMALLINT_14]
           ,[SMALLINT_15]
           ,[SMALLINT_16]
           ,[SMALLINT_17]
           ,[SMALLINT_18]
           ,[SMALLINT_19]
           ,[SMALLINT_20]
           ,[INT_11]
           ,[INT_12]
           ,[INT_13]
           ,[INT_14]
           ,[INT_15]
           ,[INT_16]
           ,[INT_17]
           ,[INT_18]
           ,[INT_19]
           ,[INT_20]
           ,[TEXT_9]
           ,[TEXT_10]
           ,[TEXT_11]
           ,[TEXT_12]
           ,[TEXT_13]
           ,[TEXT_14]
           ,[TEXT_15]
           ,[TEXT_16]
           ,[TEXT_17]
           ,[TEXT_18]
           ,[TEXT_19]
           ,[TEXT_20])
     VALUES
           (@JobNumber,
			@JobCompNumber,
			@Version,
			@Revision,
			NULL,
			NULL,
			@UserID,
			@Date,
			@SpecType,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,	
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL)

	SET @Err = @@Error

	
	RETURN @Err
END
















