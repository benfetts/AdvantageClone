Namespace Database.Procedures.OfficeFunctionAccount

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeFunctionAccount)

            Load = From OfficeFunctionAccount In DbContext.GetQuery(Of Database.Entities.OfficeFunctionAccount)
                   Select OfficeFunctionAccount

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeFunctionAccount)

            LoadByOfficeCode = From OfficeFunctionAccount In DbContext.GetQuery(Of Database.Entities.OfficeFunctionAccount)
                               Where OfficeFunctionAccount.OfficeCode = OfficeCode
                               Select OfficeFunctionAccount

        End Function
        Public Function InsertFromExistingOffice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CopyFromOfficeCode As String, ByVal CopyToOfficeCode As String,
                                                 ByVal ReplaceOfficeSegment As Boolean, ByVal ReplaceWithOfficeSegment As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim InsertSQL As String = Nothing

            Try

                If ReplaceOfficeSegment Then

                    InsertSQL = "INSERT dbo.OFF_FNC_ACCTS (OFFICE_CODE, FNC_CODE, PGLACODE_SALES, PGLACODE_COS) " &
                        "SELECT '{0}', FNC_CODE, dbo.[advfn_glaccount_replace_office_segment] (PGLACODE_SALES, '{2}'), dbo.[advfn_glaccount_replace_office_segment] (PGLACODE_COS, '{2}') " &
                        "FROM dbo.OFF_FNC_ACCTS WHERE OFFICE_CODE = '{1}'"

                    DbContext.Database.ExecuteSqlCommand(String.Format(InsertSQL, CopyToOfficeCode, CopyFromOfficeCode, ReplaceWithOfficeSegment))

                Else

                    InsertSQL = "insert dbo.OFF_FNC_ACCTS (OFFICE_CODE, FNC_CODE, PGLACODE_SALES, PGLACODE_COS) " &
                            "select '{0}', FNC_CODE, PGLACODE_SALES, PGLACODE_COS " &
                            "from dbo.OFF_FNC_ACCTS where OFFICE_CODE = '{1}'"

                    DbContext.Database.ExecuteSqlCommand(String.Format(InsertSQL, CopyToOfficeCode, CopyFromOfficeCode))

                End If

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertFromExistingOffice = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeFunctionAccount As AdvantageFramework.Database.Entities.OfficeFunctionAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OfficeFunctionAccounts.Add(OfficeFunctionAccount)

                ErrorText = OfficeFunctionAccount.ValidateEntity(IsValid)

                If IsValid Then

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeFunctionAccount As AdvantageFramework.Database.Entities.OfficeFunctionAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OfficeFunctionAccount)

                ErrorText = OfficeFunctionAccount.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeFunctionAccount As AdvantageFramework.Database.Entities.OfficeFunctionAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(OfficeFunctionAccount)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
