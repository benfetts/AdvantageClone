CREATE FUNCTION [dbo].[fn_get_nth_workday] (@initial_date  SMALLDATETIME,
                                            @relative_days SMALLINT)
RETURNS SMALLDATETIME
AS
BEGIN
    
	DECLARE @increment   SMALLINT,
            @date_ret    SMALLDATETIME,
            @day_of_week SMALLINT

    SELECT @date_ret = (SELECT @initial_date)

    IF ( @relative_days < 0 )
    SELECT @increment = -1

    IF ( @relative_days > 0 )
    SELECT @increment = 1

    IF ( @relative_days IS NULL )
    BEGIN
        SELECT @date_ret = (SELECT Dateadd(day, -1, @initial_date))

        SELECT @relative_days = 1

        SELECT @increment = 1
    END

    WHILE ( @relative_days <> 0 AND @date_ret IS NOT NULL)
    BEGIN
        SELECT @date_ret = (SELECT Dateadd(day, @increment, @date_ret))

        SELECT @day_of_week = (SELECT Datepart(dw, @date_ret))

        IF ( @day_of_week NOT IN ( 1, 7 ) )
            IF (SELECT Count(*)
                FROM   dbo.EMP_NON_TASKS
                WHERE  ( @date_ret BETWEEN [START_DATE] AND [END_DATE] )
                        AND TYPE = 'H') = 0
            SELECT @relative_days = (SELECT @relative_days - @increment)
    END

    IF ( @relative_days = 0 )
    BEGIN
        WHILE ( @relative_days = 0 )
            BEGIN
                SELECT @day_of_week = (SELECT Datepart(dw, @date_ret))

                IF ( @day_of_week IN ( 1, 7 ) )
                BEGIN
                    SELECT @increment = 1

                    SELECT @date_ret = (SELECT Dateadd(day, @increment,
                                                @date_ret)
                                        )
                END
                ELSE
                BEGIN
                    SELECT @relative_days = (SELECT @relative_days - 1)
                END
            END
    END

    RETURN @date_ret

END
GO 