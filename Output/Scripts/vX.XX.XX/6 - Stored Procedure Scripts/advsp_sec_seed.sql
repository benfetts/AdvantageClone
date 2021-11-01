IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[advsp_sec_seed]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[advsp_sec_seed]
GO
CREATE PROCEDURE [dbo].[advsp_sec_seed]
@ADV_USER_ID AS VARCHAR(100) = N'SYSADM',
@ADV_USER_PWD AS VARCHAR(MAX) = N'sysadm',
@EMP_CODE AS VARCHAR(6) = 'sys',
@DP_TM_CODE AS VARCHAR(4) = 'adm',
@DP_TM_DESC AS VARCHAR(30) = 'Added by setup script',
@F_NAME AS VARCHAR(30) = 'System',
@MI_NAME AS VARCHAR(1) = NULL,
@L_NAME AS VARCHAR(30) = 'Administrator'
AS
/*=========== QUERY ===========*/
BEGIN
	DECLARE
		@SQL_USER_ID AS VARCHAR(100),
		@USER_COUNT INT
	;
	SELECT @SQL_USER_ID = @ADV_USER_ID;
	--SELECT @USER_COUNT = COUNT(1) FROM SEC_USER WITH(NOLOCK);

	--IF @USER_COUNT = 0
	BEGIN

		DECLARE 
			@SEC_USER_ID AS INT,
			@SEC_APPLICATION_ID AS INT,
			@SEC_MODULE_ID AS INT,
			@ROW_COUNT AS INT,
			@ROW_ID AS INT
			;


		IF ( DATALENGTH(@ADV_USER_ID) > 0 AND DATALENGTH(@EMP_CODE) > 0 AND DATALENGTH(@DP_TM_CODE) > 0 )
		BEGIN
			IF NOT EXISTS( SELECT 1 FROM DEPT_TEAM WHERE DP_TM_CODE = @DP_TM_CODE )
			BEGIN
				INSERT INTO DEPT_TEAM WITH(ROWLOCK) ( DP_TM_CODE, DP_TM_DESC ) 
				VALUES (@DP_TM_CODE, @DP_TM_DESC);
			END
			ELSE
			BEGIN
				SELECT
					@DP_TM_DESC = DT.DP_TM_DESC
				FROM
					DEPT_TEAM DT WITH(NOLOCK)
				WHERE
					DT.DP_TM_CODE = @DP_TM_CODE;
			END
			IF NOT EXISTS( SELECT 1 FROM EMPLOYEE WHERE EMP_CODE = @EMP_CODE )
			BEGIN
				INSERT INTO [EMPLOYEE]([EMP_CODE], [EMP_LNAME], [EMP_FNAME], [EMP_MI], [DP_TM_CODE], [IS_ACTIVE_FREELANCE] ) 
				VALUES ( @EMP_CODE, @L_NAME, @F_NAME, @MI_NAME, @DP_TM_CODE, 0 );
			END
			ELSE
			BEGIN
				SELECT
					@L_NAME = E.EMP_LNAME,
					@F_NAME = E.EMP_FNAME,
					@MI_NAME = E.EMP_MI,
					@DP_TM_CODE = E.DP_TM_CODE
				FROM 
					EMPLOYEE E
				WHERE
					E.EMP_CODE = @EMP_CODE;
			END
			IF NOT EXISTS( SELECT 1 FROM EMP_DP_TM WHERE EMP_CODE = @EMP_CODE AND DP_TM_CODE = @DP_TM_CODE )
			BEGIN
				INSERT INTO EMP_DP_TM( EMP_CODE, DP_TM_CODE, DP_TM_DESC ) VALUES ( @EMP_CODE, @DP_TM_CODE, @DP_TM_DESC )
			END
			IF NOT EXISTS( SELECT 1 FROM SEC_USER WHERE USER_CODE = @ADV_USER_ID )
			BEGIN
				INSERT INTO [SEC_USER]( [USER_CODE], [USER_NAME], [EMP_CODE], [CHECK_USER_ACCESS] ) 
				VALUES ( @ADV_USER_ID, @SQL_USER_ID, @EMP_CODE, 0 );
			END

			SET @SEC_USER_ID = @@IDENTITY;    

			CREATE TABLE #SEC_APPLICATION_TEMP( [ROW_ID] [int] IDENTITY(1,1), [SEC_APPLICATION_ID] [int] NOT NULL )
				
			INSERT INTO 
				#SEC_APPLICATION_TEMP([SEC_APPLICATION_ID])
			SELECT
				[SEC_APPLICATION_ID]
			FROM
				[SEC_APPLICATION];
				
			SET @ROW_COUNT = @@ROWCOUNT;	
			SET @ROW_ID = 1;

			SET @SEC_APPLICATION_ID = 0;

			WHILE @ROW_ID <= @ROW_COUNT BEGIN

				SELECT
					@SEC_APPLICATION_ID = [SEC_APPLICATION_ID]
				FROM
					#SEC_APPLICATION_TEMP
				WHERE
					[ROW_ID] = @ROW_ID

				IF NOT EXISTS(SELECT 1 FROM [SEC_USER_APPACCESS] WHERE [SEC_APPLICATION_ID] = @SEC_APPLICATION_ID AND [SEC_USER_ID] = @SEC_USER_ID)
				BEGIN		
					INSERT INTO
						[SEC_USER_APPACCESS]([SEC_USER_ID], [SEC_APPLICATION_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
					VALUES
						(@SEC_USER_ID, @SEC_APPLICATION_ID, 0, 1, 1, 1, 0, 0);			
				END

				SET @ROW_ID = @ROW_ID + 1;
			
			END

			DROP TABLE #SEC_APPLICATION_TEMP;
	    
			CREATE TABLE #SEC_MODULE_TEMP([ROW_ID] [int] IDENTITY(1,1),
										  [SEC_MODULE_ID] [int] NOT NULL)
				
			INSERT INTO 
				#SEC_MODULE_TEMP([SEC_MODULE_ID])
			SELECT
				[SEC_MODULE_ID]
			FROM
				[SEC_MODULE];
				
			SET @ROW_COUNT = @@ROWCOUNT;	
			SET @ROW_ID = 1;

			SET @SEC_MODULE_ID = 0;

			WHILE @ROW_ID <= @ROW_COUNT 
			BEGIN

				SELECT
					@SEC_MODULE_ID = [SEC_MODULE_ID]
				FROM
					#SEC_MODULE_TEMP
				WHERE
					[ROW_ID] = @ROW_ID;

				IF NOT EXISTS(SELECT * FROM [SEC_USER_MODACCESS] WHERE [SEC_MODULE_ID] = @SEC_MODULE_ID AND [SEC_USER_ID] = @SEC_USER_ID) 
				BEGIN
		
					INSERT INTO
						[SEC_USER_MODACCESS]([SEC_USER_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
					VALUES
						(@SEC_USER_ID, @SEC_MODULE_ID, 1, 1, 1, 1, 0, 0);
			
				END

				SET @ROW_ID = @ROW_ID + 1;
			
			END

			DROP TABLE #SEC_MODULE_TEMP;

			CREATE TABLE #SEC_MODULE_TEMP2([ROW_ID] [int] IDENTITY(1,1),
										   [SEC_MODULE_ID] [int] NOT NULL)
				
			INSERT INTO 
				#SEC_MODULE_TEMP2([SEC_MODULE_ID])
			SELECT
				[SEC_MODULE_ID]
			FROM
				[SEC_MODULE]
			WHERE
				[SEC_MODULE_CODE] IN ('Maintenance_Accounting_DeptTeam', 'Maintenance_Accounting_Employee', 'Security_Setup_Group', 
									  'Security_Setup_ModuleAccess', 'Security_Setup_User');
		
			SET @ROW_COUNT = @@ROWCOUNT;	
			SET @ROW_ID = 1;

			SET @SEC_MODULE_ID = 0;

			WHILE @ROW_ID <= @ROW_COUNT 
			BEGIN

				SELECT
					@SEC_MODULE_ID = [SEC_MODULE_ID]
				FROM
					#SEC_MODULE_TEMP2
				WHERE
					[ROW_ID] = @ROW_ID;

				IF NOT EXISTS(SELECT * FROM [SEC_USER_MODACCESS] WHERE [SEC_MODULE_ID] = @SEC_MODULE_ID AND [SEC_USER_ID] = @SEC_USER_ID) 
				BEGIN
		
					INSERT INTO
						[SEC_USER_MODACCESS]([SEC_USER_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
					VALUES
						(@SEC_USER_ID, @SEC_MODULE_ID, 0, 1, 1, 1, 0, 0);
			
				END 
				ELSE 
				BEGIN
			
					UPDATE 
						[SEC_USER_MODACCESS]
					SET
						[IS_BLOCKED] = 0
					WHERE
						[SEC_USER_ID] = @SEC_USER_ID AND
						[SEC_MODULE_ID] = @SEC_MODULE_ID;
				
				END

				SET @ROW_ID = @ROW_ID + 1;
			
			END

			DROP TABLE #SEC_MODULE_TEMP2;

			IF @SEC_USER_ID IS NOT NULL
			BEGIN
				IF NOT EXISTS( SELECT 1 FROM SEC_GROUP_USER WHERE SEC_USER_ID = @SEC_USER_ID)
				BEGIN
					DECLARE
						@SEC_GROUP_ID INT

					SELECT @SEC_GROUP_ID = ( SELECT TOP 1 SEC_GROUP_ID FROM SEC_GROUP ORDER BY SEC_GROUP_ID ASC)

					IF @SEC_GROUP_ID IS NOT NULL
					BEGIN

						INSERT INTO SEC_GROUP_USER (SEC_GROUP_ID, SEC_USER_ID) VALUES (@SEC_GROUP_ID, @SEC_USER_ID);

					END

				END
			END

		END

	END

END
/*=========== QUERY ===========*/

