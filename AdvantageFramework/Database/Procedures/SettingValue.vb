Namespace Database.Procedures.SettingValue

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

        Public Function LoadBySettingCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.SettingValue)

            LoadBySettingCode = From SettingValue In DataContext.SettingValues
                                Where SettingValue.SettingCode = SettingCode
                                Order By SettingValue.DisplayText
                                Select SettingValue

        End Function
        Public Function LoadBySettingCodeAndValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingCode As String, ByVal Value As String) As AdvantageFramework.Database.Entities.SettingValue

            LoadBySettingCodeAndValue = (From SettingValue In DataContext.SettingValues
                                         Where SettingValue.SettingCode = SettingCode _
                                And SettingValue.Value.ToString = Value
                                         Select SettingValue).SingleOrDefault

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.SettingValue)

            Load = From SettingValue In DataContext.SettingValues
                   Select SettingValue

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingValue As AdvantageFramework.Database.Entities.SettingValue) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                SettingValue.DataContext = DataContext

                SettingValue.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.SettingValues.InsertOnSubmit(SettingValue)

                ErrorText = SettingValue.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingValue As AdvantageFramework.Database.Entities.SettingValue) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                SettingValue.DataContext = DataContext

                SettingValue.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = SettingValue.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingValue As AdvantageFramework.Database.Entities.SettingValue) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.SettingValues.DeleteOnSubmit(SettingValue)

                    DataContext.SubmitChanges()

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
        Public Function DeleteBySettingCodeAndLookupValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SettingCode As String, ByVal LookupValue As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DataContext.ExecuteCommand(String.Format("DELETE FROM dbo.AGY_SETTINGS_LOOKUP WHERE [AGY_SETTINGS_CODE] = '{0}' AND [LOOKUP_VALUE] = '{1}'", SettingCode, LookupValue))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteBySettingCodeAndLookupValue = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
