
-- Create_advsp_sec_module_insert_110901
CREATE PROCEDURE [dbo].[advsp_sec_module_insert]
	@SEC_APPLICATION_ID AS int,
	@SEC_MODULE_CODE AS varchar(100),
	@DESCRIPTION AS varchar(100),
	@IS_INACTIVE AS bit,
	@IS_MENU_ITEM AS bit,
	@IS_CATEGORY AS bit,
	@IS_APPLICATION AS bit,
	@IS_REPORT AS bit,
	@IS_DESKTOP_OBJECT AS bit,
	@IS_DASH_QUERY AS bit,
	@PARENT_MODULE_CODE AS varchar(100),
	@IMAGENAME AS varchar(100),
	@SORT_ORDER AS int,
	@CUSTOM_PERMISSION AS bit,
	@WV_URL AS varchar(100),
	@WV_IMAGEPATHACTIVE AS varchar(100),
	@WV_IMAGEPATH AS varchar(100),
	@PB_APPNAME AS varchar(100),
	@PB_MENU AS varchar(100),
	@PB_NAME AS varchar(100),
	@PB_COMMAND_STRING AS varchar(50),
	@PB_ICON AS int,
	@PB_ALLOW_MULTI AS int,
	@WV_DO_NAME AS varchar(50),
	@WV_DO_DSIZE AS int,
	@WV_RPT_URL AS varchar(50),
	@WV_RPT_IMAGEPATHACTIVE AS varchar(50),
	@WV_RPT_IMAGEPATH AS varchar(50),
	@WV_RPT_DESCRIPTION AS varchar(2000),
	@WV_RPT_PREVIEWLOCATION AS varchar(255),
	@WV_RPT_LOCKED AS bit,
	@IS_NEW AS bit = 0,
	@WV_IMAGEPATHLARGE AS varchar(50) = '',
	@WV_RPT_IMAGEPATHLARGE AS varchar(50) = ''
AS
BEGIN

	DECLARE @SEC_MODULE_ID AS int
	DECLARE @SEC_MODULE_INFO_ID AS int
	DECLARE @ROW_COUNT AS int
	DECLARE @ROW_ID AS int
	DECLARE @USER_CODE AS varchar(100)
	DECLARE @GROUP_CODE AS varchar(100)
	DECLARE @SEC_USER_ID AS int
	DECLARE @SEC_GROUP_ID AS int
	DECLARE @GROUPNAME AS varchar(50)
	DECLARE @GROUPROW_COUNT AS int
	DECLARE @SQL AS nvarchar(1000)
	DECLARE @SQLPARAM AS nvarchar(1000)
	DECLARE @CAN_PRINT AS bit
	DECLARE @CAN_UPDATE AS bit
	DECLARE @CAN_ADD AS bit
	DECLARE @CUSTOM1 AS bit
	DECLARE @CUSTOM2 AS bit
	DECLARE @IS_BLOCKED AS bit
	DECLARE @PARENT_MODULE_ID AS int
	
	SET @SEC_MODULE_ID = 0
	SET @SEC_MODULE_INFO_ID = 0
	
	IF NOT EXISTS(SELECT * FROM [dbo].[SEC_MODULE] WHERE [SEC_MODULE_CODE] = @SEC_MODULE_CODE) BEGIN

		INSERT INTO 
			[dbo].[SEC_MODULE_INFO]([IMAGENAME], [SORT_ORDER], [CUSTOM_PERMISSION], [WV_URL],
									[WV_IMAGEPATHACTIVE], [WV_IMAGEPATH], [WV_IMAGEPATHLARGE], [PB_APPNAME], [PB_MENU],
									[PB_NAME], [PB_COMMAND_STRING], [PB_ICON], [PB_ALLOW_MULTI],
									[WV_DO_NAME], [WV_DO_DSIZE], [WV_RPT_URL], [WV_RPT_IMAGEPATHACTIVE],
									[WV_RPT_IMAGEPATH], [WV_RPT_IMAGEPATHLARGE], [WV_RPT_DESCRIPTION], [WV_RPT_PREVIEWLOCATION], [WV_RPT_LOCKED])
		VALUES
			(@IMAGENAME, @SORT_ORDER, @CUSTOM_PERMISSION, @WV_URL,
			 @WV_IMAGEPATHACTIVE, @WV_IMAGEPATH, @WV_IMAGEPATHLARGE, @PB_APPNAME, @PB_MENU,
			 @PB_NAME, @PB_COMMAND_STRING, @PB_ICON, @PB_ALLOW_MULTI,
			 @WV_DO_NAME, @WV_DO_DSIZE, @WV_RPT_URL, @WV_RPT_IMAGEPATHACTIVE,
			 @WV_RPT_IMAGEPATH, @WV_RPT_IMAGEPATHLARGE, @WV_RPT_DESCRIPTION, @WV_RPT_PREVIEWLOCATION, @WV_RPT_LOCKED)
						
		SET @SEC_MODULE_INFO_ID = @@IDENTITY
		
		INSERT INTO 
			[dbo].[SEC_MODULE]([SEC_MODULE_CODE], [DESCRIPTION], [IS_INACTIVE], [IS_MENU_ITEM], 
							   [IS_CATEGORY], [IS_APPLICATION], [IS_REPORT], [IS_DESKTOP_OBJECT], 
							   [IS_DASH_QUERY], [SEC_MODULE_INFO_ID])
		VALUES
			(@SEC_MODULE_CODE, @DESCRIPTION, @IS_INACTIVE, @IS_MENU_ITEM, 
			 @IS_CATEGORY, @IS_APPLICATION, @IS_REPORT, @IS_DESKTOP_OBJECT, 
			 @IS_DASH_QUERY, @SEC_MODULE_INFO_ID)
			 
		SET @SEC_MODULE_ID = @@IDENTITY
			
		IF @SEC_MODULE_ID > 0 AND EXISTS(SELECT * FROM [dbo].[SEC_APPLICATION] WHERE [SEC_APPLICATION_ID] = @SEC_APPLICATION_ID) BEGIN
		
			INSERT INTO
				[dbo].[SEC_APPLICATION_MOD]([SEC_APPLICATION_ID], [SEC_MODULE_ID])
			VALUES
				(@SEC_APPLICATION_ID, @SEC_MODULE_ID)
		
		END
			
		IF @SEC_MODULE_ID > 0 AND EXISTS(SELECT * FROM [dbo].[SEC_MODULE] WHERE [SEC_MODULE_CODE] = @PARENT_MODULE_CODE) BEGIN
		
			SET @PARENT_MODULE_ID = 0
			
			SELECT
				@PARENT_MODULE_ID = [SEC_MODULE_ID]
			FROM
				[dbo].[SEC_MODULE]
			WHERE
				[SEC_MODULE_CODE] = @PARENT_MODULE_CODE
				
			IF @PARENT_MODULE_ID > 0 BEGIN
			
				INSERT INTO
					[dbo].[SEC_MODULE_SUB]([PARENT_MODULE_ID], [SEC_MODULE_ID])
				VALUES
					(@PARENT_MODULE_ID, @SEC_MODULE_ID)
				
			END

		END
		
		CREATE TABLE #SEC_USER_TEMP([ROW_ID] [int] IDENTITY(1,1),
									[SEC_USER_ID] [int] NOT NULL,
									[USER_CODE] [varchar](100) NOT NULL,
									[GROUP_CODE] [varchar](100) NULL)
		CREATE TABLE #SEC_GROUP_TEMP([ROW_ID] [int] IDENTITY(1,1),
									 [SEC_GROUP_ID] [int] NOT NULL,
									 [NAME] [varchar](50) NOT NULL)

		IF @IS_CATEGORY = 0 AND @PB_APPNAME <> '' BEGIN	
		
			INSERT INTO 
				#SEC_USER_TEMP([SEC_USER_ID], [USER_CODE], [GROUP_CODE])
			SELECT
				[SEC_USER].[SEC_USER_ID], [SEC_USER].[USER_CODE], CASE WHEN [U_APP_SECURITY].[GROUP_CODE] IN (SELECT NAME FROM [dbo].[SEC_GROUP]) AND [U_APP_SECURITY].[GROUP_CODE] IN (SELECT  NAME + 'ADV' FROM [dbo].[SEC_GROUP])
																	       THEN [U_APP_SECURITY].[GROUP_CODE]+ 'ADV' 
																	       ELSE [U_APP_SECURITY].[GROUP_CODE] END
			FROM
				[dbo].[SEC_USER] INNER JOIN
				[dbo].[U_APP_SECURITY] ON UPPER([SEC_USER].[USER_CODE]) = UPPER([U_APP_SECURITY].[USER_CODE])
			
			SET @ROW_COUNT = @@ROWCOUNT
			SET @ROW_ID = 1

			SET @USER_CODE = ''
			SET @SEC_USER_ID = 0

			WHILE @ROW_ID <= @ROW_COUNT BEGIN

				SELECT
					@SEC_USER_ID = [SEC_USER_ID],
					@USER_CODE = [USER_CODE],
					@GROUP_CODE = [GROUP_CODE]
				FROM
					#SEC_USER_TEMP
				WHERE
					[ROW_ID] = @ROW_ID

				SET @SQL = N'SELECT @PID = CASE WHEN CAST(' + @PB_APPNAME + ' AS varchar(1)) = ''N'' OR CAST(' + @PB_APPNAME + ' AS varchar(1)) = ''0'''
				
				IF @PB_MENU <> '' BEGIN
				
					SET @SQL = @SQL + ' OR CAST(' + @PB_MENU + ' AS varchar(1)) = ''N'''
					
				END
				
				SET @SQL = @SQL + ' THEN 1 ELSE 0 END FROM [dbo].[U_APP_SECURITY] WHERE UPPER([USER_CODE]) = UPPER(@UC)'
				
				SET @SQLPARAM = N'@UC varchar(100), @PID int OUTPUT'

				EXEC sp_executesql @SQL, @SQLPARAM, @UC = @USER_CODE, @PID = @IS_BLOCKED OUTPUT;

				IF @PB_APPNAME = 'PR_TIME_ENTRY' BEGIN

					PRINT 'TIME ENTRY ONLY CHECK FOR USER_CODE: ' + UPPER(@USER_CODE) + ''

					IF EXISTS(SELECT * FROM [dbo].[U_APP_SECURITY] WHERE UPPER([U_APP_SECURITY].[USER_CODE]) = UPPER(@USER_CODE) AND [U_APP_SECURITY].[TIME_ENTRY_ONLY] = 1) BEGIN

						PRINT 'USER_CODE: ' + UPPER(@USER_CODE) + ' IS TIME ENTRY ONLY AND IS UNBLOCKED'
						SET @IS_BLOCKED = 0
						PRINT 'USER_CODE: ' + UPPER(@USER_CODE) + ' IS ' + CAST(@IS_BLOCKED AS varchar(1))
						
					END
				
				END

				INSERT INTO
					[dbo].[SEC_USER_MODACCESS]([SEC_USER_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
				VALUES
					(@SEC_USER_ID, @SEC_MODULE_ID, @IS_BLOCKED, 1, 1, 1, 0, 0)

				IF @GROUP_CODE IS NOT NULL AND @GROUP_CODE <> '' BEGIN
				
					SET @SEC_GROUP_ID = NULL
					
					SELECT
						@SEC_GROUP_ID = [SEC_GROUP_ID]
					FROM
						[dbo].[SEC_GROUP]
					WHERE
						[SEC_GROUP].[NAME] = @GROUP_CODE
						
					IF @SEC_GROUP_ID IS NOT NULL AND NOT EXISTS(SELECT * FROM [dbo].[SEC_GROUP_MODACCESS] WHERE [SEC_GROUP_ID] = @SEC_GROUP_ID AND [SEC_MODULE_ID] = @SEC_MODULE_ID) BEGIN
					
						INSERT INTO
							[dbo].[SEC_GROUP_MODACCESS]([SEC_GROUP_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
						VALUES
							(@SEC_GROUP_ID, @SEC_MODULE_ID, @IS_BLOCKED, 1, 1, 1, 0, 0)
					
					END
				
				END
				
				SET @ROW_ID = @ROW_ID + 1
					
			END

		END ELSE IF @IS_CATEGORY = 0 AND @PB_APPNAME = '' BEGIN
			
			INSERT INTO 
				#SEC_USER_TEMP([SEC_USER_ID], [USER_CODE], [GROUP_CODE])
			SELECT
				[SEC_USER].[SEC_USER_ID], [SEC_USER].[USER_CODE], CASE WHEN [U_APP_SECURITY].[GROUP_CODE] IN (SELECT NAME FROM [dbo].[SEC_GROUP]) AND [U_APP_SECURITY].[GROUP_CODE] IN (SELECT  NAME + 'ADV' FROM [dbo].[SEC_GROUP])
																	       THEN [U_APP_SECURITY].[GROUP_CODE]+ 'ADV' 
																	       ELSE [U_APP_SECURITY].[GROUP_CODE] END
			FROM
				[dbo].[SEC_USER] INNER JOIN
				[dbo].[U_APP_SECURITY] ON UPPER([SEC_USER].[USER_CODE]) = UPPER([U_APP_SECURITY].[USER_CODE])
			
			SET @ROW_COUNT = @@ROWCOUNT
			SET @ROW_ID = 1

			SET @USER_CODE = ''
			SET @SEC_USER_ID = 0

			WHILE @ROW_ID <= @ROW_COUNT BEGIN

				SELECT
					@SEC_USER_ID = [SEC_USER_ID],
					@USER_CODE = [USER_CODE],
					@GROUP_CODE = [GROUP_CODE]
				FROM
					#SEC_USER_TEMP
				WHERE
					[ROW_ID] = @ROW_ID

				IF EXISTS(SELECT * FROM [dbo].[U_APP_SECURITY] WHERE UPPER([U_APP_SECURITY].[USER_CODE]) = UPPER(@USER_CODE) AND [U_APP_SECURITY].[TIME_ENTRY_ONLY] = 1) BEGIN

					INSERT INTO
						[dbo].[SEC_USER_MODACCESS]([SEC_USER_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
					VALUES
						(@SEC_USER_ID, @SEC_MODULE_ID, 1, 1, 1, 1, 0, 0)

				END ELSE  BEGIN

					INSERT INTO
						[dbo].[SEC_USER_MODACCESS]([SEC_USER_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
					VALUES
						(@SEC_USER_ID, @SEC_MODULE_ID, @IS_NEW, 1, 1, 1, 0, 0)

					IF @GROUP_CODE IS NOT NULL AND @GROUP_CODE <> '' BEGIN
						
						SET @SEC_GROUP_ID = NULL
						
						SELECT
							@SEC_GROUP_ID = [SEC_GROUP_ID]
						FROM
							[dbo].[SEC_GROUP]
						WHERE
							[SEC_GROUP].[NAME] = @GROUP_CODE
							
						IF @SEC_GROUP_ID IS NOT NULL AND NOT EXISTS(SELECT * FROM [dbo].[SEC_GROUP_MODACCESS] WHERE [SEC_GROUP_ID] = @SEC_GROUP_ID AND [SEC_MODULE_ID] = @SEC_MODULE_ID) BEGIN
						
							INSERT INTO
								[dbo].[SEC_GROUP_MODACCESS]([SEC_GROUP_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
							VALUES
								(@SEC_GROUP_ID, @SEC_MODULE_ID, @IS_NEW, 1, 1, 1, 0, 0)
						
						END
					
					END
				
				END

				SET @ROW_ID = @ROW_ID + 1
					
			END
		
		END
						
		IF @IS_CATEGORY = 0 AND @PB_NAME <> '' AND @CUSTOM_PERMISSION = 1 BEGIN

			IF NOT EXISTS(SELECT * FROM #SEC_USER_TEMP) BEGIN

				INSERT INTO 
					#SEC_USER_TEMP([SEC_USER_ID], [USER_CODE], [GROUP_CODE])
				SELECT
					[SEC_USER].[SEC_USER_ID], [SEC_USER].[USER_CODE], CASE WHEN [U_APP_SECURITY].[GROUP_CODE] IN (SELECT NAME FROM [dbo].[SEC_GROUP]) AND [U_APP_SECURITY].[GROUP_CODE] IN (SELECT  NAME + 'ADV' FROM [dbo].[SEC_GROUP])
																	       THEN [U_APP_SECURITY].[GROUP_CODE]+ 'ADV' 
																	       ELSE [U_APP_SECURITY].[GROUP_CODE] END
				FROM
					[dbo].[SEC_USER] INNER JOIN
					[dbo].[U_APP_SECURITY] ON UPPER([SEC_USER].[USER_CODE]) = UPPER([U_APP_SECURITY].[USER_CODE])
					
				SET @ROW_COUNT = @@ROWCOUNT

			END
									
			SET @ROW_ID = 1

			SET @USER_CODE = ''
			SET @SEC_USER_ID = 0

			WHILE @ROW_ID <= @ROW_COUNT BEGIN

				SELECT
					@SEC_USER_ID = [SEC_USER_ID],
					@USER_CODE = [USER_CODE],
					@GROUP_CODE = [GROUP_CODE]
				FROM
					#SEC_USER_TEMP
				WHERE
					[ROW_ID] = @ROW_ID
					
				SET @CAN_PRINT = 1
				SET @CAN_UPDATE = 1
				SET @CAN_ADD = 1
				SET @CUSTOM1 = 1
				SET @CUSTOM2 = 1

				SELECT
					@CAN_PRINT = CASE WHEN [SEC_VIEW] = 'Y' THEN 1 ELSE 0 END,
					@CAN_UPDATE = CASE WHEN [SEC_EDIT] = 'Y' THEN 1 ELSE 0 END,
					@CAN_ADD = CASE WHEN [SEC_INSERT] = 'Y' THEN 1 ELSE 0 END,
					@CUSTOM1 = CASE WHEN [CUSTOM_1] = 'Y' THEN 1 ELSE 0 END,
					@CUSTOM2 = CASE WHEN [CUSTOM_2] = 'Y' THEN 1 ELSE 0 END
				FROM 
					[dbo].[U_SEC_RIGHTS]
				WHERE
					UPPER([USER_ID]) = UPPER(@USER_CODE) AND
					[APPLICATION_ID] = @PB_NAME
				
				UPDATE
					[dbo].[SEC_USER_MODACCESS]
				SET
					[CAN_PRINT] = @CAN_PRINT, 
					[CAN_UPDATE] = @CAN_UPDATE, 
					[CAN_ADD] = @CAN_ADD, 
					[CUSTOM1] = @CUSTOM1, 
					[CUSTOM2] = @CUSTOM2
				WHERE
					[SEC_USER_ID] = @SEC_USER_ID AND
					[SEC_MODULE_ID] = @SEC_MODULE_ID
					
				IF @GROUP_CODE IS NOT NULL AND @GROUP_CODE <> '' BEGIN
					
					SET @SEC_GROUP_ID = NULL
					
					SELECT
						@SEC_GROUP_ID = [SEC_GROUP_ID]
					FROM
						[dbo].[SEC_GROUP]
					WHERE
						[SEC_GROUP].[NAME] = @GROUP_CODE
						
					IF @SEC_GROUP_ID IS NOT NULL AND EXISTS(SELECT * FROM [dbo].[SEC_GROUP_MODACCESS] WHERE [SEC_GROUP_ID] = @SEC_GROUP_ID AND [SEC_MODULE_ID] = @SEC_MODULE_ID) BEGIN
					
						UPDATE
							[dbo].[SEC_GROUP_MODACCESS]
						SET
							[CAN_PRINT] = @CAN_PRINT, 
							[CAN_UPDATE] = @CAN_UPDATE, 
							[CAN_ADD] = @CAN_ADD, 
							[CUSTOM1] = @CUSTOM1, 
							[CUSTOM2] = @CUSTOM2
						WHERE
							[SEC_GROUP_ID] = @SEC_GROUP_ID AND
							[SEC_MODULE_ID] = @SEC_MODULE_ID
					
					END
				
				END
				
				SET @ROW_ID = @ROW_ID + 1
					
			END
			
		END

		IF @IS_CATEGORY = 0 BEGIN

			INSERT INTO 
				#SEC_GROUP_TEMP([SEC_GROUP_ID], [NAME])
			SELECT
				[SEC_GROUP_ID], [NAME]
			FROM
				[dbo].[SEC_GROUP]
			
			SET @ROW_COUNT = @@ROWCOUNT
			SET @ROW_ID = 1

			SET @GROUPNAME = ''
			SET @SEC_GROUP_ID = 0

			WHILE @ROW_ID <= @ROW_COUNT BEGIN

				SELECT
					@SEC_GROUP_ID = [SEC_GROUP_ID],
					@GROUPNAME = [NAME]
				FROM
					#SEC_GROUP_TEMP
				WHERE
					[ROW_ID] = @ROW_ID

				IF NOT EXISTS(SELECT * FROM [dbo].[SEC_GROUP_MODACCESS] WHERE [SEC_GROUP_ID] = @SEC_GROUP_ID AND [SEC_MODULE_ID] = @SEC_MODULE_ID) BEGIN

					IF @IS_NEW = 0 BEGIN

						IF @WV_URL <> '' BEGIN
						
							IF EXISTS(SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[WV_APPLICATIONS]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) BEGIN
							
								IF EXISTS(SELECT * FROM [dbo].[WV_SEC_GROUP_APPLICATION] GA LEFT OUTER JOIN [dbo].[WV_SEC_GROUPS] G ON G.GROUPID = GA.GROUPID LEFT OUTER JOIN [dbo].[WV_APPLICATIONS] A ON A.APPID = GA.APPID WHERE A.URL = @WV_URL AND G.GROUPNAME = @GROUPNAME) BEGIN
								
									INSERT INTO
										[dbo].[SEC_GROUP_MODACCESS]([SEC_GROUP_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
									VALUES
										(@SEC_GROUP_ID, @SEC_MODULE_ID, 1, 1, 1, 1, 0, 0)
								
								END ELSE BEGIN
								
									INSERT INTO
										[dbo].[SEC_GROUP_MODACCESS]([SEC_GROUP_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
									VALUES
										(@SEC_GROUP_ID, @SEC_MODULE_ID, 0, 1, 1, 1, 0, 0)
								
								END
							
							END ELSE BEGIN
							
								INSERT INTO
									[dbo].[SEC_GROUP_MODACCESS]([SEC_GROUP_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
								VALUES
									(@SEC_GROUP_ID, @SEC_MODULE_ID, 0, 1, 1, 1, 0, 0)

							END 
							
						END ELSE BEGIN
						
							INSERT INTO
								[dbo].[SEC_GROUP_MODACCESS]([SEC_GROUP_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
							VALUES
								(@SEC_GROUP_ID, @SEC_MODULE_ID, 1, 1, 1, 1, 0, 0)
								
						END
					
					END ELSE BEGIN
					
						INSERT INTO
							[dbo].[SEC_GROUP_MODACCESS]([SEC_GROUP_ID], [SEC_MODULE_ID], [IS_BLOCKED], [CAN_PRINT], [CAN_UPDATE], [CAN_ADD], [CUSTOM1], [CUSTOM2])
						VALUES
							(@SEC_GROUP_ID, @SEC_MODULE_ID, 1, 1, 1, 1, 0, 0)
					
					END

				END

				SET @ROW_ID = @ROW_ID + 1
					
			END

		END
		
		DROP TABLE #SEC_USER_TEMP
		DROP TABLE #SEC_GROUP_TEMP

		PRINT 'INSERTED MODULE - ' + @SEC_MODULE_CODE
		
	END ELSE BEGIN
	
		SELECT 
			@SEC_MODULE_ID =  [SEC_MODULE_ID]
		FROM 
			[dbo].[SEC_MODULE] 
		WHERE 
			[SEC_MODULE_CODE] = @SEC_MODULE_CODE
			
		IF @SEC_MODULE_ID > 0 AND EXISTS(SELECT * FROM [dbo].[SEC_APPLICATION] WHERE [SEC_APPLICATION_ID] = @SEC_APPLICATION_ID) BEGIN
		
			IF NOT EXISTS(SELECT * FROM [dbo].[SEC_APPLICATION_MOD] WHERE [SEC_APPLICATION_ID] = @SEC_APPLICATION_ID AND [SEC_MODULE_ID] = @SEC_MODULE_ID) BEGIN
			
				INSERT INTO
					[dbo].[SEC_APPLICATION_MOD]([SEC_APPLICATION_ID], [SEC_MODULE_ID])
				VALUES
					(@SEC_APPLICATION_ID, @SEC_MODULE_ID)
				
			END

		END

		IF @SEC_MODULE_ID > 0 AND EXISTS(SELECT * FROM [dbo].[SEC_MODULE] WHERE [SEC_MODULE_CODE] = @PARENT_MODULE_CODE) BEGIN
		
			SET @PARENT_MODULE_ID = 0
			
			SELECT
				@PARENT_MODULE_ID = [SEC_MODULE_ID]
			FROM
				[dbo].[SEC_MODULE]
			WHERE
				[SEC_MODULE_CODE] = @PARENT_MODULE_CODE
				
			IF @PARENT_MODULE_ID > 0 BEGIN
			
				UPDATE 
					[dbo].[SEC_MODULE_SUB]
				SET 
					[PARENT_MODULE_ID] = @PARENT_MODULE_ID
				WHERE
					[SEC_MODULE_ID] = @SEC_MODULE_ID
				
			END

		END
		
		UPDATE 
			[dbo].[SEC_MODULE]
		SET 
			[DESCRIPTION] = @DESCRIPTION, 
			[IS_INACTIVE] = @IS_INACTIVE,  
			[IS_MENU_ITEM] = @IS_MENU_ITEM, 
			[IS_CATEGORY] = @IS_CATEGORY,  
			[IS_APPLICATION] = @IS_APPLICATION,  
			[IS_REPORT] = @IS_REPORT,  
			[IS_DESKTOP_OBJECT] = @IS_DESKTOP_OBJECT, 
			[IS_DASH_QUERY] = @IS_DASH_QUERY
		WHERE
			[SEC_MODULE_ID] = @SEC_MODULE_ID
			
		SELECT
			@SEC_MODULE_INFO_ID = [SEC_MODULE_INFO_ID]
		FROM
			[dbo].[SEC_MODULE]
		WHERE
			[SEC_MODULE_ID] = @SEC_MODULE_ID
			
		UPDATE
			[dbo].[SEC_MODULE_INFO]
		SET
			[IMAGENAME] = @IMAGENAME, 
			[SORT_ORDER] = @SORT_ORDER,  
			[CUSTOM_PERMISSION] = @CUSTOM_PERMISSION,  
			[WV_URL] = @WV_URL, 
			[WV_IMAGEPATHACTIVE] = @WV_IMAGEPATHACTIVE,  
			[WV_IMAGEPATH] = @WV_IMAGEPATH,  
			[PB_APPNAME] = @PB_APPNAME,  
			[PB_MENU] = @PB_MENU, 
			[PB_NAME] = @PB_NAME,  
			[PB_COMMAND_STRING] = @PB_COMMAND_STRING,  
			[PB_ICON] = @PB_ICON,  
			[PB_ALLOW_MULTI] = @PB_ALLOW_MULTI, 
			[WV_DO_NAME] = @WV_DO_NAME,  
			[WV_DO_DSIZE] = @WV_DO_DSIZE,  
			[WV_RPT_URL] = @WV_RPT_URL,  
			[WV_RPT_IMAGEPATHACTIVE] = @WV_RPT_IMAGEPATHACTIVE, 
			[WV_RPT_IMAGEPATH] = @WV_RPT_IMAGEPATH,  
			[WV_RPT_DESCRIPTION] = @WV_RPT_DESCRIPTION,  
			[WV_RPT_PREVIEWLOCATION] = @WV_RPT_PREVIEWLOCATION,  
			[WV_RPT_LOCKED] = @WV_RPT_LOCKED
		WHERE
			[SEC_MODULE_INFO_ID] = @SEC_MODULE_INFO_ID

		PRINT 'Module Already Exists'
	
	END
	
END
