























CREATE PROCEDURE [dbo].[usp_wv_reports_ar_statements_updateprinted_client] 

@ClientID as varchar(6),
@ContactCode as varchar(6)

AS

Update CLIENT_AR_STMT SET CLIENT_AR_STMT.LAST_PRINTED = getdate()
where CLIENT_AR_STMT.CL_CODE = @ClientID AND CLIENT_AR_STMT.CONT_CODE = @ContactCode























