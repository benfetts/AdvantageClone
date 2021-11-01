


























CREATE PROCEDURE [dbo].[usp_wv_InsertError] 
@UserID Varchar(100), 
@ErrNo Int, 
@ErrDescription VarChar(255), 
@ErrSource VarChar(255)
AS
INSERT INTO WV_ERROR (USERID, ERRDATETIME, ERRNUMBER, ERRDESCRIPTION, ERRSOURCE)
Values(@UserID, GETDATE(), @ErrNo, @ErrDescription, @ErrSource)


























