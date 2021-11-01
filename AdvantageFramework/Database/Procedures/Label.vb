Namespace Database.Procedures.Label

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

        Public Function HasActiveLabels(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            HasActiveLabels = LoadActive(DataContext).Count > 0

        End Function

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.Label)

            Load = From Label In DataContext.Labels
                   Select Label

        End Function
        Public Function LoadActive(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.Label)

            LoadActive = From Label In DataContext.Labels
                         Where Label.IsInactive Is Nothing OrElse Label.IsInactive = 0
                         Select Label

        End Function

        'Public Function LoadByAlertIDs(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AlertIDs() As Long) As IQueryable(Of Database.Entities.Label)

        '    LoadByAlertIDs = From Label In DataContext.Labels
        '                     Join LabelAlerts In DataContext.LabelDocuments On Label.ID Equals LabelAlerts.LabelID
        '                     Where AlertIDs.Contains(LabelDocs.DocumentID)
        '                     Select Label

        'End Function
        Public Function LoadDistinctByDocumentIDs(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentIDs() As Long) As IQueryable(Of Database.Entities.Label)

            LoadDistinctByDocumentIDs = (From Label In DataContext.Labels
                                         Join LabelDocs In DataContext.LabelDocuments On Label.ID Equals LabelDocs.LabelID
                                         Where DocumentIDs.Contains(LabelDocs.DocumentID)
                                         Select Label).Distinct

        End Function
        Public Function LoadByLabelID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelID As Long) As Database.Entities.Label

            LoadByLabelID = (From Label In DataContext.Labels
                             Where Label.ID = LabelID
                             Select Label).SingleOrDefault

        End Function
        Public Function LoadByLabelIDs(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal LabelIDs() As Long) As IQueryable(Of Database.Entities.Label)

            LoadByLabelIDs = From Label In DataContext.Labels
                             Where LabelIDs.Contains(Label.ID)
                             Select Label

        End Function

        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Label As AdvantageFramework.Database.Entities.Label) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try
                If Label.Name <> String.Empty AndAlso Label.Name.Trim.Length > 0 Then

                    Dim NameExists As Boolean = False

                    NameExists = (From Entity In DataContext.Labels
                                  Where Entity.Name.Trim().ToUpper() = Label.Name.Trim().ToUpper()).Count > 0

                    If NameExists = False Then

                        Label.DataContext = DataContext

                        Label.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                        DataContext.Labels.InsertOnSubmit(Label)

                        ErrorText = Label.ValidateEntity(IsValid)

                        If IsValid Then

                            DataContext.SubmitChanges()

                            Inserted = True

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                        End If

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please choose a different label name.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Label name is required.")

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Label As AdvantageFramework.Database.Entities.Label) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If Label.Name <> String.Empty AndAlso Label.Name.Trim.Length > 0 Then

                    Dim NameExists As Boolean = False

                    NameExists = (From Entity In DataContext.Labels
                                  Where Entity.ID <> Label.ID AndAlso Entity.Name.Trim().ToUpper() = Label.Name.Trim().ToUpper()).Count > 0

                    If NameExists = False Then

                        Label.DataContext = DataContext

                        Label.DatabaseAction = AdvantageFramework.Database.Action.Updating

                        ErrorText = Label.ValidateEntity(IsValid)

                        If IsValid Then

                            DataContext.SubmitChanges()

                            Updated = True

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                        End If

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please choose a different label name.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Label name is required.")

                End If


            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Label As AdvantageFramework.Database.Entities.Label) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'Delete recs for docs using the label
                IsValid = AdvantageFramework.Database.Procedures.LabelDocument.DeleteByLabelID(DataContext, Label.ID)

                Try 'delete sub-label docs recs

                    DataContext.ExecuteCommand(String.Format("DELETE FROM LABEL_DOCUMENT WITH(ROWLOCK) WHERE LABEL_ID IN (SELECT DISTINCT ID FROM LABEL WITH(ROWLOCK) WHERE PARENT_ID = {0});", Label.ID))

                Catch ex As Exception
                    IsValid = False
                End Try
                Try 'Delete sub-labels

                    DataContext.ExecuteCommand(String.Format("DELETE FROM LABEL WITH(ROWLOCK) WHERE PARENT_ID = {0};", Label.ID))

                Catch ex As Exception
                    IsValid = False
                End Try

                If IsValid Then

                    DataContext.Labels.DeleteOnSubmit(Label)

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

#End Region

    End Module

End Namespace

