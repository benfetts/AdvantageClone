EXECUTE sp_addrolemember @rolename = N'advan_admin', @membername = N'SYSADM';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'SYSADM';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'SYSADM';


GO
