
CREATE PROCEDURE [dbo].[usp_wv_AD_NUMBER_UPDATE] 
        @AD_NBR                VARCHAR(30),
        @AD_NBR_DESC           VARCHAR(60),
        @ACTIVE                SMALLINT,
        @DEF_BLKPLT_VER_CODE   VARCHAR(6),
        @DEF_BLKPLT_VER2_CODE  VARCHAR(6),
        @CL_CODE               VARCHAR(6),
        @COLOR                 VARCHAR(7)

AS


        UPDATE AD_NUMBER WITH(ROWLOCK)
        SET    AD_NBR_DESC = @AD_NBR_DESC,
               [ACTIVE] = @ACTIVE,
               DEF_BLKPLT_VER_CODE = @DEF_BLKPLT_VER_CODE,
               DEF_BLKPLT_VER2_CODE = @DEF_BLKPLT_VER2_CODE,
               CL_CODE = @CL_CODE,
               COLOR = @COLOR
        WHERE  AD_NBR = @AD_NBR;


