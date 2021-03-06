SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_grant_execute_on_sp_to_public]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_grant_execute_on_sp_to_public]
GO

CREATE PROCEDURE [dbo].[usp_grant_execute_on_sp_to_public] 
AS
/*=========== QUERY ===========*/
	SET NOCOUNT ON

    DECLARE   @spname sysname
    DECLARE   @x_type NVARCHAR(2)
    DECLARE spnames CURSOR FOR
    Select [name], xtype
    From sysobjects 
    Where OBJECTPROPERTY(id, 'IsMSShipped') = 0 
    AND 
    (
    (OBJECTPROPERTY(id, 'IsProcedure') = 1 )
    OR (xtype='V' )
    OR (xtype='P' )
    OR (xtype='FN' )
    OR (xtype='TF' )
    )
	
	UNION

	Select [name], 'TT'
    From sys.table_types  
	
    OPEN spnames

    FETCH NEXT
    FROM spnames
    INTO @spname, @x_type

    WHILE @@FETCH_STATUS = 0
        BEGIN
        --SELECT @x_type = xtype FROM sysobjects WHERE [name] = @spname;
		IF @x_type = 'TT'
			BEGIN
				EXECUTE('GRANT EXECUTE ON TYPE::[' + @spname + '] TO PUBLIC AS [dbo]')
			END
        ELSE IF @x_type = 'V' OR @x_type = 'TF'
            BEGIN
   		        EXECUTE('GRANT SELECT ON [' + @spname + '] TO PUBLIC AS [dbo]')
            END
        ELSE
            BEGIN
                EXECUTE('GRANT EXECUTE ON [' + @spname + '] TO PUBLIC AS [dbo]')
            END
           

        -- Get the next sprocname name to backup.
        FETCH NEXT
        FROM spnames
        INTO @spname, @x_type
        END

    -- Cleanup
    CLOSE spnames
    DEALLOCATE spnames
/*=========== QUERY ===========*/
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

