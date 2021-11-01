Namespace Database.Procedures.CheckRegister

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function SetCheckToCleared(ByVal DbContext As Database.DbContext, ByVal BankCode As String, ByVal CheckNumber As Integer, ByVal CheckClearedDate As Nullable(Of Date)) As Boolean

            'objects
            Dim CheckCleared As Boolean = False

            Try

                If CheckClearedDate.HasValue Then

					CheckCleared = (DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CHECK_REGISTER SET CLEARED = 1, CHECK_CLEARED_DATE = '{2}' WHERE BK_CODE = '{0}' AND CHECK_NBR = {1}", BankCode, CheckNumber, CheckClearedDate.Value.ToString("MM/dd/yyyy"))) > 0)

				Else

                    CheckCleared = (DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CHECK_REGISTER SET CLEARED = 1 WHERE BK_CODE = '{0}' AND CHECK_NBR = {1}", BankCode, CheckNumber)) > 0)

                End If

            Catch ex As Exception
                CheckCleared = False
            Finally
                SetCheckToCleared = CheckCleared
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CheckRegister)

            Load = From CheckRegister In DbContext.GetQuery(Of Database.Entities.CheckRegister)
                   Select CheckRegister

        End Function

#End Region

    End Module

End Namespace
