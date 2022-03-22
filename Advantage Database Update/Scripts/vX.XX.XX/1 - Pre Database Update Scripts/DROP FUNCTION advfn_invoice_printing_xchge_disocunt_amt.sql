IF EXISTS(SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'advfn_invoice_printing_xchge_disocunt_amt') BEGIN

    DROP FUNCTION [dbo].[advfn_invoice_printing_xchge_disocunt_amt]

END
GO