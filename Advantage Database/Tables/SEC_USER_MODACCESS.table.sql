CREATE TABLE [dbo].[SEC_USER_MODACCESS] (
    [SEC_USER_MODACCESS_ID] INT IDENTITY (1, 1) NOT NULL,
    [SEC_USER_ID]           INT NOT NULL,
    [SEC_MODULE_ID]         INT NOT NULL,
    [IS_BLOCKED]            BIT NOT NULL,
    [CAN_PRINT]             BIT NOT NULL,
    [CAN_UPDATE]            BIT NOT NULL,
    [CAN_ADD]               BIT NOT NULL,
    [CUSTOM1]               BIT NOT NULL,
    [CUSTOM2]               BIT NOT NULL
);

