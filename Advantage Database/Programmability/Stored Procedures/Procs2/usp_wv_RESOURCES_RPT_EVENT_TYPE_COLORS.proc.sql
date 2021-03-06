--DROP PROCEDURE [dbo].[usp_wv_RESOURCES_RPT_EVENT_TYPE_COLORS]
CREATE PROCEDURE [dbo].[usp_wv_RESOURCES_RPT_EVENT_TYPE_COLORS] /*WITH ENCRYPTION*/
	@NO_EVENT_TYPE_COLOR VARCHAR(7),
	@FIXED_COLOR VARCHAR(7),
	@FLEX_COLOR VARCHAR(7),
	@PRE_EMPTABLE_COLOR VARCHAR(7),
	@HOLD_COLOR VARCHAR(7),
	@DO_UPDATE TINYINT
AS
/*=========== QUERY ===========*/
	IF @DO_UPDATE = 1
	BEGIN
		--EVENTS WITH NO EVENT TYPE ID	
		IF NOT EXISTS (SELECT * FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'RSC_RPT_NO_ETI_CLR')
		BEGIN
			INSERT INTO AGY_SETTINGS WITH(ROWLOCK)
			(
				AGY_SETTINGS_CODE,
				AGY_SETTINGS_DESC,
				AGY_SETTINGS_VALUE,
				AGY_SETTINGS_DEF
			) 
			VALUES
			(
				'RSC_RPT_NO_ETI_CLR',
				'Resource Report Color for events without event type',
				@NO_EVENT_TYPE_COLOR,
				'#FFFFFF'
			);
		END
		ELSE
		BEGIN
			UPDATE AGY_SETTINGS WITH(ROWLOCK)
			SET AGY_SETTINGS_VALUE = @NO_EVENT_TYPE_COLOR
			WHERE AGY_SETTINGS_CODE = 'RSC_RPT_NO_ETI_CLR';
		END
		--EVENTS WITH EVENT TYPE 'FIXED'
		IF NOT EXISTS (SELECT * FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'RSC_RPT_FXD_CLR')
		BEGIN
			INSERT INTO AGY_SETTINGS WITH(ROWLOCK)
			(
				AGY_SETTINGS_CODE,
				AGY_SETTINGS_DESC,
				AGY_SETTINGS_VALUE,
				AGY_SETTINGS_DEF
			) 
			VALUES
			(
				'RSC_RPT_FXD_CLR',
				'Resource Report Color for events with FIXED event type',
				@FIXED_COLOR,
				'#FF444D'
			);
		END
		ELSE
		BEGIN
			UPDATE AGY_SETTINGS WITH(ROWLOCK)
			SET AGY_SETTINGS_VALUE = @FIXED_COLOR
			WHERE AGY_SETTINGS_CODE = 'RSC_RPT_FXD_CLR';
		END
		--EVENTS WITH EVENT TYPE 'FLEX'
		IF NOT EXISTS (SELECT * FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'RSC_RPT_FLX_CLR')
		BEGIN
			INSERT INTO AGY_SETTINGS WITH(ROWLOCK)
			(
				AGY_SETTINGS_CODE,
				AGY_SETTINGS_DESC,
				AGY_SETTINGS_VALUE,
				AGY_SETTINGS_DEF
			) 
			VALUES
			(
				'RSC_RPT_FLX_CLR',
				'Resource Report Color for events with FLEX event type',
				@FLEX_COLOR,
				'#7CCA62'
			);
		END
		ELSE
		BEGIN
			UPDATE AGY_SETTINGS WITH(ROWLOCK)
			SET AGY_SETTINGS_VALUE = @FLEX_COLOR
			WHERE AGY_SETTINGS_CODE = 'RSC_RPT_FLX_CLR';
		END
		--EVENTS WITH EVENT TYPE 'PRE-EMPTABLE'
		IF NOT EXISTS (SELECT * FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'RSC_RPT_PRE_CLR')
		BEGIN
			INSERT INTO AGY_SETTINGS WITH(ROWLOCK)
			(
				AGY_SETTINGS_CODE,
				AGY_SETTINGS_DESC,
				AGY_SETTINGS_VALUE,
				AGY_SETTINGS_DEF
			) 
			VALUES
			(
				'RSC_RPT_PRE_CLR',
				'Resource Report Color for events with Pre-emptable event type',
				@PRE_EMPTABLE_COLOR,
				'#5ABAFF'
			);
		END
		ELSE
		BEGIN
			UPDATE AGY_SETTINGS WITH(ROWLOCK)
			SET AGY_SETTINGS_VALUE = @PRE_EMPTABLE_COLOR
			WHERE AGY_SETTINGS_CODE = 'RSC_RPT_PRE_CLR';
		END		
		--EVENTS WITH EVENT TYPE 'HOLD'
		IF NOT EXISTS (SELECT * FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'RSC_RPT_HLD_CLR')
		BEGIN
			INSERT INTO AGY_SETTINGS WITH(ROWLOCK)
			(
				AGY_SETTINGS_CODE,
				AGY_SETTINGS_DESC,
				AGY_SETTINGS_VALUE,
				AGY_SETTINGS_DEF
			) 
			VALUES
			(
				'RSC_RPT_HLD_CLR',
				'Resource Report Color for events with hold event type',
				@HOLD_COLOR,
				'#5ABAFF'
			);
		END
		ELSE
		BEGIN
			UPDATE AGY_SETTINGS WITH(ROWLOCK)
			SET AGY_SETTINGS_VALUE = @HOLD_COLOR
			WHERE AGY_SETTINGS_CODE = 'RSC_RPT_HLD_CLR';
		END		
	END	
	
	SELECT @NO_EVENT_TYPE_COLOR = CONVERT(VARCHAR(7),COALESCE(AGY_SETTINGS_VALUE,AGY_SETTINGS_DEF) )
	FROM AGY_SETTINGS WITH(NOLOCK) 
	WHERE AGY_SETTINGS_CODE = 'RSC_RPT_NO_ETI_CLR';	

	SELECT @FIXED_COLOR = CONVERT(VARCHAR(7),COALESCE(AGY_SETTINGS_VALUE,AGY_SETTINGS_DEF) )
	FROM AGY_SETTINGS WITH(NOLOCK) 
	WHERE AGY_SETTINGS_CODE = 'RSC_RPT_FXD_CLR';	

	SELECT @FLEX_COLOR = CONVERT(VARCHAR(7),COALESCE(AGY_SETTINGS_VALUE,AGY_SETTINGS_DEF) )
	FROM AGY_SETTINGS WITH(NOLOCK) 
	WHERE AGY_SETTINGS_CODE = 'RSC_RPT_FLX_CLR';	

	SELECT @PRE_EMPTABLE_COLOR = CONVERT(VARCHAR(7),COALESCE(AGY_SETTINGS_VALUE,AGY_SETTINGS_DEF) )
	FROM AGY_SETTINGS WITH(NOLOCK) 
	WHERE AGY_SETTINGS_CODE = 'RSC_RPT_PRE_CLR';	

	SELECT @HOLD_COLOR = CONVERT(VARCHAR(7),COALESCE(AGY_SETTINGS_VALUE,AGY_SETTINGS_DEF) )
	FROM AGY_SETTINGS WITH(NOLOCK) 
	WHERE AGY_SETTINGS_CODE = 'RSC_RPT_HLD_CLR';	
	
	SELECT
		@NO_EVENT_TYPE_COLOR AS NO_EVENT_TYPE_COLOR,
		@FIXED_COLOR AS STATIC_COLOR,
		@FLEX_COLOR AS FLEX_COLOR,
		@PRE_EMPTABLE_COLOR AS PRE_EMPTABLE_COLOR,
		@HOLD_COLOR AS HOLD_COLOR;
/*=========== QUERY ===========*/
