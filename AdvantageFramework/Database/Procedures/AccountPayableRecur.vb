Namespace Database.Procedures.AccountPayableRecur

    <HideModuleName()>
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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRecur)

            Dim VendorCodes As IEnumerable(Of String) = Nothing

            VendorCodes = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Session)
                           Select Vendor.Code).ToArray

            LoadWithOfficeLimits = From Entity In DbContext.AccountPayableRecurs
                                   Where VendorCodes.Contains(Entity.VendorCode)
                                   Select Entity

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableRecur)

            Load = From AccountPayableRecur In DbContext.GetQuery(Of Database.Entities.AccountPayableRecur)
                   Select AccountPayableRecur

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.AccountPayableRecur

            Try

                LoadByID = (From AccountPayableRecur In DbContext.GetQuery(Of Database.Entities.AccountPayableRecur)
                            Where AccountPayableRecur.ID = ID
                            Select AccountPayableRecur).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayableRecurs.Add(AccountPayableRecur)

                ErrorText = AccountPayableRecur.ValidateEntity(IsValid)

                If IsValid Then

                    If AccountPayableRecur.ID = 0 Then

                        AccountPayableRecur.ID = AdvantageFramework.Database.Procedures.AssignNumber.GetNextNumber(DbContext, "RECUR_ID")

                    End If

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountPayableRecur)

                ErrorText = AccountPayableRecur.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

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
