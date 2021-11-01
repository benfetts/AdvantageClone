
CREATE PROCEDURE [dbo].[usp_wv_AD_NUMBER_INSERT] 
        @AD_NBR                VARCHAR(30),
        @AD_NBR_DESC           VARCHAR(60),
        @ACTIVE                SMALLINT,
        @DEF_BLKPLT_VER_CODE   VARCHAR(6),
        @DEF_BLKPLT_VER2_CODE  VARCHAR(6),
        @CL_CODE               VARCHAR(6),
        @COLOR                 VARCHAR(7)

AS


            DECLARE @MSG                   VARCHAR(150),
                    @IS_VALID              BIT,
                    @CTR                   SMALLINT

            SET @MSG = 0;
            SET @IS_VALID = 1;

            SELECT @CTR = ISNULL(COUNT(1),0) FROM AD_NUMBER WITH(NOLOCK) WHERE AD_NBR = @AD_NBR;
            IF @CTR > 0 
            BEGIN
	            SET @MSG = '1'; -- ALREADY EXISTS
	            SET @IS_VALID = 0;
            END


            IF @IS_VALID = 1
            BEGIN
	            INSERT INTO AD_NUMBER WITH(ROWLOCK)
	            (
		            AD_NBR,
		            AD_NBR_DESC,
		            [ACTIVE],
		            DEF_BLKPLT_VER_CODE,
		            DEF_BLKPLT_VER2_CODE,
		            CL_CODE,
		            COLOR
	            )
	            VALUES
	            (
		            @AD_NBR,
		            @AD_NBR_DESC,
		            @ACTIVE,
		            @DEF_BLKPLT_VER_CODE,
		            @DEF_BLKPLT_VER2_CODE,
		            @CL_CODE,
		            @COLOR
	            );

                SET @MSG = '0';
            END

            SELECT @MSG;
            
            

