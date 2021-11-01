Namespace Database.Procedures.AppVars

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

        'Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AppVars)

        '    Load = From AppVars In DbContext.GetQuery(Of Database.Entities.AppVar)  _
        '           Select AppVars

        'End Function

        Public Function Load(ByVal DbContext As Database.DbContext, ByVal AppVar As AdvantageFramework.Database.Entities.AppVars) As AdvantageFramework.Database.Entities.AppVars

            Load = (From AppVars In DbContext.GetQuery(Of Database.Entities.AppVars)
                    Where AppVars.Application = AppVar.Application And AppVars.Group = AppVar.Group And AppVars.Name = AppVar.Name
                    Select AppVars).FirstOrDefault()

        End Function
        Public Function LoadByApplicationName(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal ApplicationPageName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AppVars)

            LoadByApplicationName = From AppVars In DbContext.GetQuery(Of Database.Entities.AppVars)
                                    Where AppVars.Application = ApplicationPageName And AppVars.UserCode = UserCode
                                    Select AppVars

        End Function
        Public Function LoadByApplicationNameAndVariableName(ByVal DbContext As Database.DbContext,
                                                             ByVal UserCode As String, ByVal ApplicationPageName As String, ByVal VariableName As String) As Database.Entities.AppVars

            LoadByApplicationNameAndVariableName = (From AppVars In DbContext.GetQuery(Of Database.Entities.AppVars)
                                                    Where AppVars.Application = ApplicationPageName And AppVars.UserCode = UserCode And AppVars.Name = VariableName
                                                    Select AppVars).SingleOrDefault

        End Function

        Public Function BulkInsertList(ByVal DbContext As Database.DbContext, ByVal Settings As List(Of AdvantageFramework.Database.Entities.AppVars)) As Boolean

            Dim dt As New DataTable()
            Dim Inserted As Boolean = False

            dt.Columns.Add(New DataColumn("USERID", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("APPLICATION", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("VARIABLE_GROUP", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("VARIABLE_NAME", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("VARIABLE_TYPE", System.Type.GetType("System.String")))
            dt.Columns.Add(New DataColumn("VARIABLE_ORDER", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("VARIABLE_VALUE", System.Type.GetType("System.String")))

            For Each Setting As AdvantageFramework.Database.Entities.AppVars In Settings

                Dim Row As DataRow = dt.NewRow()

                Row("USERID") = Setting.UserCode
                Row("APPLICATION") = Setting.Application.ToString()
                Row("VARIABLE_GROUP") = IIf(Setting.Group Is Nothing, "NA", Setting.Group)
                Row("VARIABLE_NAME") = Setting.Name
                Row("VARIABLE_TYPE") = IIf(Setting.Type Is Nothing, "NA", Setting.Type)
                Row("VARIABLE_ORDER") = IIf(Setting.Order Is Nothing, System.DBNull.Value, Setting.Order)
                Row("VARIABLE_VALUE") = IIf(Setting.Value Is Nothing, System.DBNull.Value, Setting.Value)

                dt.Rows.Add(Row)

                Row = Nothing

            Next

            Try

                Using bc = New System.Data.SqlClient.SqlBulkCopy(DbContext.Database.Connection.ConnectionString())

                    With bc

                        .ColumnMappings.Add("USERID", "USERID")
                        .ColumnMappings.Add("APPLICATION", "APPLICATION")
                        .ColumnMappings.Add("VARIABLE_GROUP", "VARIABLE_GROUP")
                        .ColumnMappings.Add("VARIABLE_NAME", "VARIABLE_NAME")
                        .ColumnMappings.Add("VARIABLE_TYPE", "VARIABLE_TYPE")
                        .ColumnMappings.Add("VARIABLE_ORDER", "VARIABLE_ORDER")
                        .ColumnMappings.Add("VARIABLE_VALUE", "VARIABLE_VALUE")

                        .BatchSize = dt.Rows.Count
                        .DestinationTableName = "APP_VARS"

                        .WriteToServer(dt)
                        Inserted = True

                    End With

                End Using

            Catch ex As Exception

                Inserted = False

            End Try

            BulkInsertList = Inserted

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AppVar As AdvantageFramework.Database.Entities.AppVars) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AppVars.Add(AppVar)

                ErrorText = AppVar.ValidateEntity(IsValid)

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

        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AppVar As AdvantageFramework.Database.Entities.AppVars) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AppVar)

                ErrorText = AppVar.ValidateEntity(IsValid)

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

        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal ApplicationPageName As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.APP_VARS WITH(ROWLOCK) WHERE USERID = '{0}' AND [APPLICATION] = '{1}'", UserCode, ApplicationPageName.ToString()))
                        Deleted = True

                    Catch ex As Exception

                        IsValid = False

                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception

                Deleted = False

            Finally

                Delete = Deleted

            End Try

        End Function
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal ApplicationPageName As String, ByVal VariableGroup As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.APP_VARS WITH(ROWLOCK) WHERE USERID = '{0}' AND [APPLICATION] = '{1}' AND VARIABLE_GROUP = '{2}'", _
                                                                        UserCode, ApplicationPageName.ToString(), VariableGroup))

                    Catch ex As Exception

                        IsValid = False

                    End Try

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception

                Deleted = False

            Finally

                Delete = Deleted

            End Try

        End Function
        Public Function Delete(ByVal DbContext As Database.DbContext, ByVal UserCode As String, ByVal ApplicationPageName As String, ByVal VariableGroup As String, ByVal VariableName As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.APP_VARS WITH(ROWLOCK) WHERE USERID = '{0}' AND [APPLICATION] = '{1}' AND VARIABLE_GROUP = '{2}' AND VARIABLE_NAME = '{3}'", _
                                                                        UserCode, ApplicationPageName.ToString(), VariableGroup, VariableName))

                    Catch ex As Exception

                        IsValid = False

                    End Try

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
