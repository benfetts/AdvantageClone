IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_PaymentCenterGetBanks]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_PaymentCenterGetBanks] 
GO

CREATE PROCEDURE [dbo].[usp_wv_PaymentCenterGetBanks]

@USER_ID VARCHAR(6)

AS

BEGIN

SELECT B.BK_CODE as BankCode, 
       B.BK_CODE + ' | ' + BK_DESCRIPTION as BankDescription,
	   CASE WHEN BH.BANK_CODE IS NOT NULL OR CW.BK_CODE IS NOT NULL THEN 1 ELSE 0 END AS OpenBatchFlag	   
FROM   BANK B WITH (NOLOCK)
       JOIN (SELECT O.OFFICE_CODE OFF_CODE 
             FROM   dbo.EMPLOYEE AS E WITH (NOLOCK)
                    CROSS JOIN dbo.OFFICE AS O WITH (NOLOCK)
                    LEFT OUTER JOIN dbo.EMP_OFFICE AS EO WITH (NOLOCK) 
                                 ON EO.EMP_CODE = E.EMP_CODE 
                    JOIN (SELECT EMP_CODE 
                          FROM   SEC_USER A WITH (NOLOCK) 
                          WHERE  UPPER(A.USER_CODE) = @USER_ID) S 
                      ON S.EMP_CODE = E.EMP_CODE 
             WHERE  ( EO.OFFICE_CODE = O.OFFICE_CODE 
                       OR ( O.OFFICE_CODE IS NOT NULL 
                            AND EO.OFFICE_CODE IS NULL ) )) C 
         ON C.OFF_CODE = OFFICE_CODE
		LEFT JOIN (SELECT DISTINCT BANK_CODE FROM PC_BATCH_HEADER WITH (NOLOCK)
				WHERE BATCH_STATUS NOT IN ('C','D')) BH ON BH.BANK_CODE = B.BK_CODE				
		LEFT JOIN CHECKWRITING CW WITH (NOLOCK) ON CW.BK_CODE = B.BK_CODE		
WHERE  B.BK_CODE = '' 
       AND ( INACTIVE_FLAG = 0 
              OR INACTIVE_FLAG IS NULL ) 
UNION 
SELECT B.BK_CODE as BankCode, 
       B.BK_CODE + ' | ' + BK_DESCRIPTION as BankDescription,
	   CASE WHEN BH.BANK_CODE IS NOT NULL OR CW.BK_CODE IS NOT NULL THEN 1 ELSE 0 END AS OpenBatchFlag	   
FROM   BANK B WITH (NOLOCK)
       JOIN (SELECT O.OFFICE_CODE OFF_CODE 
             FROM   dbo.EMPLOYEE AS E WITH (NOLOCK) 
                    CROSS JOIN dbo.OFFICE AS O WITH (NOLOCK) 
                    LEFT OUTER JOIN dbo.EMP_OFFICE AS EO WITH (NOLOCK) 
                                 ON EO.EMP_CODE = E.EMP_CODE 
                    JOIN (SELECT EMP_CODE 
                          FROM   SEC_USER A WITH (NOLOCK) 
                          WHERE  UPPER(A.USER_CODE) = @USER_ID) S 
                      ON S.EMP_CODE = E.EMP_CODE 
             WHERE  ( EO.OFFICE_CODE = O.OFFICE_CODE 
                       OR ( O.OFFICE_CODE IS NOT NULL 
                            AND EO.OFFICE_CODE IS NULL ) )) C 
         ON C.OFF_CODE = OFFICE_CODE 
		LEFT JOIN (SELECT DISTINCT BANK_CODE FROM PC_BATCH_HEADER WITH (NOLOCK)
				WHERE BATCH_STATUS NOT IN ('C','D')) BH ON BH.BANK_CODE = B.BK_CODE		
		LEFT JOIN CHECKWRITING CW WITH (NOLOCK) ON CW.BK_CODE = B.BK_CODE		
WHERE  ( INACTIVE_FLAG = 0 
          OR INACTIVE_FLAG IS NULL ) 

END