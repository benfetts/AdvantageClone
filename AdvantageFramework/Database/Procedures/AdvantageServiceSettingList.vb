Namespace Database.Procedures.AdvantageServiceSettingList

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.AdvantageServiceSettingList)

            Load = From AdvantageServiceSettingList In DataContext.AdvantageServiceSettingLists
                   Select AdvantageServiceSettingList

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSettingList As AdvantageFramework.Database.Entities.AdvantageServiceSettingList) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceSettingList.DataContext = DataContext

                AdvantageServiceSettingList.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AdvantageServiceSettingLists.InsertOnSubmit(AdvantageServiceSettingList)

                ErrorText = AdvantageServiceSettingList.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSettingList As AdvantageFramework.Database.Entities.AdvantageServiceSettingList) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AdvantageServiceSettingList.DataContext = DataContext

                AdvantageServiceSettingList.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = AdvantageServiceSettingList.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSettingList As AdvantageFramework.Database.Entities.AdvantageServiceSettingList) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.AdvantageServiceSettingLists.DeleteOnSubmit(AdvantageServiceSettingList)

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
        Public Function DeleteByAdvantageServiceSettingID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceSettingID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            
            Try

                DataContext.ExecuteCommand(String.Format("DELETE FROM dbo.ADV_SERVICE_SETTING_LIST WHERE ADV_SERVICE_SETTING_ID = {0}", AdvantageServiceSettingID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByAdvantageServiceSettingID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
