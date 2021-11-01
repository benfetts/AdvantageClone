Namespace BillingCommandCenter.Database.Procedures.BillingCommandCenter

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

        Public Function LoadByID(ByVal BCCDbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.BillingCommandCenter

            Try

                LoadByID = (From BillingCommandCenter In BCCDbContext.GetQuery(Of Database.Entities.BillingCommandCenter)
                            Where BillingCommandCenter.ID = ID
                            Select BillingCommandCenter).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByUser(ByVal BCCDbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingCommandCenter)

            LoadByUser = From BillingCommandCenter In BCCDbContext.GetQuery(Of Database.Entities.BillingCommandCenter)
                         Where Mid(BillingCommandCenter.BillingUser.ToUpper, 1, BillingCommandCenter.BillingUser.ToUpper.Length - 2) = UserCode.ToUpper
                         Select BillingCommandCenter

        End Function
        Public Function Load(ByVal BCCDbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingCommandCenter)

            Load = From BillingCommandCenter In BCCDbContext.GetQuery(Of Database.Entities.BillingCommandCenter)
                   Select BillingCommandCenter

        End Function
        Public Function Delete(ByVal BCCDbContext As Database.DbContext, ByVal BillingCommandCenterID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                Try

                    BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.BILLING_CMD_CENTER WHERE BCC_ID = {0}", BillingCommandCenterID))

                    Deleted = True

                Catch ex As Exception

                End Try

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Update(ByVal BCCDbContext As Database.DbContext, ByVal BillingCommandCenter As Database.Entities.BillingCommandCenter) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                BCCDbContext.UpdateObject(BillingCommandCenter)

                ErrorText = BillingCommandCenter.ValidateEntity(IsValid)

                If IsValid Then

                    BCCDbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
