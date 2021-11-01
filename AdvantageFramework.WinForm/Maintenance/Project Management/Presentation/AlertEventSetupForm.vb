Namespace Maintenance.ProjectManagement.Presentation

    Public Class AlertEventSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RepositoryItemCheckEdit_Blank As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim AlertCategorySettingsList As Generic.List(Of AdvantageFramework.Database.Classes.AlertCategorySetting) = Nothing
            Dim AlertGroupCodes() As String = Nothing

            AlertCategorySettingsList = New Generic.List(Of AdvantageFramework.Database.Classes.AlertCategorySetting)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ButtonItemView_Inactive.Checked Then

                    AlertGroupCodes = AdvantageFramework.Database.Procedures.AlertGroup.LoadDistinctAlertGroups(DbContext).Select(Function(Entity) Entity.Code).ToArray

                Else

                    AlertGroupCodes = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActiveDistinctAlertGroups(DbContext).Select(Function(Entity) Entity.Code).ToArray

                End If

                PivotGridForm_AlertEvents.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AlertGroupCategory.Load(DbContext).Include("AlertCategory").ToList
                                                        Where AlertGroupCodes.Contains(Entity.AlertGroupCode) = True AndAlso
                                                              Entity.AlertCategory.GroupLevelSecurityID IsNot Nothing AndAlso
                                                              Entity.AlertCategory.GroupLevelSecurityID > 0
                                                        Select [AlertGroupCategory] = New AdvantageFramework.Database.Classes.AlertGroupCategory(Entity)
                                                        Order By [AlertGroupCategory].GroupLevelSecurity).ToList

                For Each AlertCategory In (From Entity In AdvantageFramework.Database.Procedures.AlertCategory.Load(DbContext).ToList
                                           Where Entity.GroupLevelSecurityID IsNot Nothing AndAlso
                                                 Entity.GroupLevelSecurityID > 0
                                           Select Entity
                                           Order By Entity.GroupLevelSecurityID).ToList

                    AlertCategorySettingsList.Add(New AdvantageFramework.Database.Classes.AlertCategorySetting(True, AlertCategory))
                    AlertCategorySettingsList.Add(New AdvantageFramework.Database.Classes.AlertCategorySetting(False, AlertCategory))

                Next

                PivotGridForm_AlertEventSettings.DataSource = AlertCategorySettingsList

            End Using

            PivotGridForm_AlertEvents.BestFitRowArea()
            PivotGridForm_AlertEventSettings.BestFitRowArea()

            If PivotGridForm_AlertEvents.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).Any AndAlso
                    PivotGridForm_AlertEventSettings.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea).Any Then

                If PivotGridForm_AlertEvents.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)(0).Width >
                        PivotGridForm_AlertEventSettings.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)(0).Width Then

                    PivotGridForm_AlertEventSettings.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)(0).Width = PivotGridForm_AlertEvents.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)(0).Width

                Else

                    PivotGridForm_AlertEvents.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)(0).Width = PivotGridForm_AlertEventSettings.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)(0).Width

                End If

            End If

            PivotGridForm_AlertEvents.BestFitColumnArea()
            PivotGridForm_AlertEventSettings.BestFitColumnArea()

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub
        Private Function IsAttachPDFAllowed(ByVal AlertCategoryDescription As String) As Boolean

            'objects
            Dim AllowedCategories As Generic.List(Of String) = Nothing
            Dim Allowed As Boolean = False

            Try

                AllowedCategories = New Generic.List(Of String)

                AllowedCategories.Add("Job Created")
                AllowedCategories.Add("Job Modified")
                AllowedCategories.Add("Job Specs Created")
                AllowedCategories.Add("Job Specs Modified")
                AllowedCategories.Add("Job Specs Revised")
                AllowedCategories.Add("Creative Brief Created")
                AllowedCategories.Add("Creative Brief Revised")

                Allowed = AllowedCategories.Contains(AlertCategoryDescription)

            Catch ex As Exception
                Allowed = False
            Finally
                IsAttachPDFAllowed = Allowed
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AlertEventSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertEventSetupForm = Nothing

            AlertEventSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertEventSetupForm()

            AlertEventSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertEventSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

            PivotGridForm_AlertEvents.WriteEditValueToAllDataSourceItems = True
            PivotGridForm_AlertEventSettings.WriteEditValueToAllDataSourceItems = False

            ButtonItemView_Inactive.Image = AdvantageFramework.My.Resources.ShowInactiveImage
            ButtonItemCheck_CheckAll.Icon = AdvantageFramework.My.Resources.CheckIcon
            ButtonItemCheck_UncheckAll.Icon = AdvantageFramework.My.Resources.UncheckIcon
            ButtonItemCategoryCheck_CheckAll.Icon = AdvantageFramework.My.Resources.CheckIcon
            ButtonItemCategoryCheck_UncheckAll.Icon = AdvantageFramework.My.Resources.UncheckIcon

            _RepositoryItemCheckEdit_Blank = AdvantageFramework.WinForm.Presentation.Controls.CreateBlankSubItemCheckBox()

            _RepositoryItemCheckEdit_Blank.ReadOnly = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each AlertGroupCode In DbContext.Database.SqlQuery(Of String)("SELECT DISTINCT EMAIL_GR_CODE FROM dbo.EMAIL_GROUP WHERE EMAIL_GR_CODE NOT IN (SELECT E_GROUP FROM dbo.ALERT_GROUP)").ToList

                    For Each AlertCategory In AdvantageFramework.Database.Procedures.AlertCategory.Load(DbContext).ToList

                        AlertGroupCategory = New AdvantageFramework.Database.Entities.AlertGroupCategory

                        AlertGroupCategory.DbContext = DbContext

                        AlertGroupCategory.AlertGroupCode = AlertGroupCode
                        AlertGroupCategory.AlertCategoryID = AlertCategory.ID
                        AlertGroupCategory.IsActive = 1

                        DbContext.AlertGroupCategories.Add(AlertGroupCategory)

                    Next

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception

                    End Try

                Next

            End Using

            LoadGrid()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PivotGridForm_AlertEvents_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.EditValueChangedEventArgs) Handles PivotGridForm_AlertEvents.EditValueChanged

            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

            Try

                AlertGroupCategory = (From Entity In DirectCast(PivotGridForm_AlertEvents.ListSource, Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupCategory))
                                      Where Entity.AlertGroup = e.GetFieldValue(e.RowField) AndAlso
                                            Entity.AlertCategory = e.GetFieldValue(e.ColumnField)
                                      Select Entity.GetEntity()).SingleOrDefault

            Catch ex As Exception
                AlertGroupCategory = Nothing
            End Try

            If AlertGroupCategory IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Database.Procedures.AlertGroupCategory.Update(DbContext, AlertGroupCategory) Then

                        Me.ClearChanged()

                    End If

                End Using

                PivotGridForm_AlertEvents.RefreshData()

            End If

        End Sub
        Private Sub PivotGridForm_AlertEventSettings_CustomCellEdit(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomCellEditEventArgs) Handles PivotGridForm_AlertEventSettings.CustomCellEdit

            'objects
            Dim AlertCategory As String = Nothing

            If e.GetFieldValue(e.RowField) = "Attach PDF" Then

                Try

                    AlertCategory = (From Entity In DirectCast(PivotGridForm_AlertEventSettings.ListSource, Generic.List(Of AdvantageFramework.Database.Classes.AlertCategorySetting))
                                     Where Entity.EventSetting = e.GetFieldValue(e.RowField) AndAlso
                                           Entity.AlertCategory = e.GetFieldValue(e.ColumnField)
                                     Select [AlertCat] = Entity.AlertCategory).SingleOrDefault

                Catch ex As Exception
                    AlertCategory = Nothing
                End Try

                If String.IsNullOrEmpty(AlertCategory) = False Then

                    If IsAttachPDFAllowed(AlertCategory) = False Then

                        e.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridForm_AlertEventSettings_EditValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.EditValueChangedEventArgs) Handles PivotGridForm_AlertEventSettings.EditValueChanged

            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim AlertCategorySetting As AdvantageFramework.Database.Classes.AlertCategorySetting = Nothing

            Try

                AlertCategorySetting = (From Entity In DirectCast(PivotGridForm_AlertEventSettings.ListSource, Generic.List(Of AdvantageFramework.Database.Classes.AlertCategorySetting))
                                        Where Entity.EventSetting = e.GetFieldValue(e.RowField) AndAlso
                                              Entity.AlertCategory = e.GetFieldValue(e.ColumnField)
                                        Select Entity).SingleOrDefault

            Catch ex As Exception
                AlertCategorySetting = Nothing
            End Try

            If AlertCategorySetting IsNot Nothing Then

                AlertCategorySetting.IsActive = e.Editor.EditValue

                AlertCategory = AlertCategorySetting.GetEntity

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Database.Procedures.AlertCategory.Update(DbContext, AlertCategory, "") Then

                        Me.ClearChanged()

                    End If

                End Using

                PivotGridForm_AlertEventSettings.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemCategoryCheck_CheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemCategoryCheck_CheckAll.Click

            'objects
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

            PivotCellEventArgs = PivotGridForm_AlertEvents.Cells.GetFocusedCellInfo

            If PivotCellEventArgs IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each AGC In (From Entity In DirectCast(PivotGridForm_AlertEvents.ListSource, Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupCategory))
                                     Where Entity.AlertCategory = PivotCellEventArgs.GetFieldValue(PivotCellEventArgs.ColumnField)
                                     Select Entity)

                        AGC.IsActive = True

                        AlertGroupCategory = AGC.GetEntity

                        DbContext.UpdateObject(AlertGroupCategory)

                    Next

                    DbContext.SaveChanges()

                End Using

                PivotGridForm_AlertEvents.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemCategoryCheck_UncheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemCategoryCheck_UncheckAll.Click

            'objects
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

            PivotCellEventArgs = PivotGridForm_AlertEvents.Cells.GetFocusedCellInfo

            If PivotCellEventArgs IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each AGC In (From Entity In DirectCast(PivotGridForm_AlertEvents.ListSource, Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupCategory))
                                     Where Entity.AlertCategory = PivotCellEventArgs.GetFieldValue(PivotCellEventArgs.ColumnField)
                                     Select Entity)

                        AGC.IsActive = False

                        AlertGroupCategory = AGC.GetEntity

                        DbContext.UpdateObject(AlertGroupCategory)

                    Next

                    DbContext.SaveChanges()

                End Using

                PivotGridForm_AlertEvents.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemCheck_CheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemCheck_CheckAll.Click

            'objects
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

            PivotCellEventArgs = PivotGridForm_AlertEvents.Cells.GetFocusedCellInfo

            If PivotCellEventArgs IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each AGC In (From Entity In DirectCast(PivotGridForm_AlertEvents.ListSource, Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupCategory))
                                     Where Entity.AlertGroup = PivotCellEventArgs.GetFieldValue(PivotCellEventArgs.RowField)
                                     Select Entity)

                        AGC.IsActive = True

                        AlertGroupCategory = AGC.GetEntity

                        DbContext.UpdateObject(AlertGroupCategory)

                    Next

                    DbContext.SaveChanges()

                End Using

                PivotGridForm_AlertEvents.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemCheck_UncheckAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemCheck_UncheckAll.Click

            'objects
            Dim PivotCellEventArgs As DevExpress.XtraPivotGrid.PivotCellEventArgs = Nothing
            Dim AlertGroupCategory As AdvantageFramework.Database.Entities.AlertGroupCategory = Nothing

            PivotCellEventArgs = PivotGridForm_AlertEvents.Cells.GetFocusedCellInfo

            If PivotCellEventArgs IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each AGC In (From Entity In DirectCast(PivotGridForm_AlertEvents.ListSource, Generic.List(Of AdvantageFramework.Database.Classes.AlertGroupCategory))
                                     Where Entity.AlertGroup = PivotCellEventArgs.GetFieldValue(PivotCellEventArgs.RowField)
                                     Select Entity)

                        AGC.IsActive = False

                        AlertGroupCategory = AGC.GetEntity

                        DbContext.UpdateObject(AlertGroupCategory)

                    Next

                    DbContext.SaveChanges()

                End Using

                PivotGridForm_AlertEvents.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemView_Inactive_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_Inactive.CheckedChanged

            If Me.FormShown Then

                LoadGrid()

            End If
            
        End Sub

#End Region

#End Region

    End Class

End Namespace