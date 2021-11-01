Namespace Database.Procedures.OfficeSalesClassAccount

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.OfficeSalesClassAccount)

            Load = From OfficeSalesClassAccount In DbContext.GetQuery(Of Database.Entities.OfficeSalesClassAccount)
                   Select OfficeSalesClassAccount

        End Function
        Public Function LoadBySalesClassCodeOfficeCode(ByVal DbContext As Database.DbContext, ByVal SalesClassCode As String, ByVal OfficeCode As String) As Database.Entities.OfficeSalesClassAccount

            Try

                LoadBySalesClassCodeOfficeCode = (From OfficeSalesClassAccount In DbContext.GetQuery(Of Database.Entities.OfficeSalesClassAccount)
                                                  Where OfficeSalesClassAccount.OfficeCode = OfficeCode AndAlso
                                                  OfficeSalesClassAccount.SalesClassCode = SalesClassCode
                                                  Select OfficeSalesClassAccount).SingleOrDefault

            Catch ex As Exception
                LoadBySalesClassCodeOfficeCode = Nothing
            End Try

        End Function
        Public Function InsertFromExistingOffice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CopyFromOfficeCode As String, ByVal CopyToOfficeCode As String, ByVal IncludeMedia As Boolean, ByVal IncludeProduction As Boolean,
                                                 ByVal ReplaceOfficeSegment As Boolean, ByVal ReplaceWithOfficeSegment As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim InsertSQL As String = Nothing

            Try

                If ReplaceOfficeSegment Then

                    If IncludeMedia And IncludeProduction Then

                        InsertSQL = "insert OFF_SC_ACCTS (OFFICE_CODE, SC_CODE, PGLACODE_SALES, PGLACODE_COS, MGLACODE_COS, MGLACODE_SALES) " &
                                    "select '{0}', SC_CODE, dbo.[advfn_glaccount_replace_office_segment] (PGLACODE_SALES, '{2}'), dbo.[advfn_glaccount_replace_office_segment] (PGLACODE_COS, '{2}'), " &
                                    "dbo.[advfn_glaccount_replace_office_segment] (MGLACODE_COS, '{2}'), dbo.[advfn_glaccount_replace_office_segment] (MGLACODE_SALES, '{2}') " &
                                    "from dbo.OFF_SC_ACCTS where OFFICE_CODE='{1}'"

                    ElseIf IncludeMedia Then

                        InsertSQL = "insert OFF_SC_ACCTS (OFFICE_CODE, SC_CODE, MGLACODE_COS, MGLACODE_SALES) " &
                                    "select '{0}', SC_CODE, dbo.[advfn_glaccount_replace_office_segment] (MGLACODE_COS, '{2}'), dbo.[advfn_glaccount_replace_office_segment] (MGLACODE_SALES, '{2}') " &
                                    "from dbo.OFF_SC_ACCTS where OFFICE_CODE='{1}'"


                    ElseIf IncludeProduction Then

                        InsertSQL = "insert OFF_SC_ACCTS (OFFICE_CODE, SC_CODE, PGLACODE_SALES, PGLACODE_COS) " &
                                    "select '{0}', SC_CODE, dbo.[advfn_glaccount_replace_office_segment] (PGLACODE_SALES, '{2}'), dbo.[advfn_glaccount_replace_office_segment] (PGLACODE_COS, '{2}') " &
                                    "from dbo.OFF_SC_ACCTS where OFFICE_CODE='{1}'"

                    End If

                    DbContext.Database.ExecuteSqlCommand(String.Format(InsertSQL, CopyToOfficeCode, CopyFromOfficeCode, ReplaceWithOfficeSegment))

                Else

                    If IncludeMedia And IncludeProduction Then

                        InsertSQL = "insert dbo.OFF_SC_ACCTS (OFFICE_CODE, SC_CODE, PGLACODE_SALES, PGLACODE_COS, MGLACODE_COS, MGLACODE_SALES) " &
                                    "select '{0}', SC_CODE, PGLACODE_SALES, PGLACODE_COS, MGLACODE_COS, MGLACODE_SALES " &
                                    "from dbo.OFF_SC_ACCTS where OFFICE_CODE='{1}'"

                    ElseIf IncludeMedia Then

                        InsertSQL = "insert dbo.OFF_SC_ACCTS (OFFICE_CODE, SC_CODE, MGLACODE_COS, MGLACODE_SALES) " &
                                    "select '{0}', SC_CODE, MGLACODE_COS, MGLACODE_SALES " &
                                    "from dbo.OFF_SC_ACCTS where OFFICE_CODE='{1}'"


                    ElseIf IncludeProduction Then

                        InsertSQL = "insert dbo.OFF_SC_ACCTS (OFFICE_CODE, SC_CODE, PGLACODE_SALES, PGLACODE_COS) " &
                                    "select '{0}', SC_CODE, PGLACODE_SALES, PGLACODE_COS " &
                                    "from dbo.OFF_SC_ACCTS where OFFICE_CODE='{1}'"

                    End If

                    DbContext.Database.ExecuteSqlCommand(String.Format(InsertSQL, CopyToOfficeCode, CopyFromOfficeCode))

                End If

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertFromExistingOffice = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.OfficeSalesClassAccounts.Add(OfficeSalesClassAccount)

                ErrorText = OfficeSalesClassAccount.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(OfficeSalesClassAccount)

                ErrorText = OfficeSalesClassAccount.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(OfficeSalesClassAccount)

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
