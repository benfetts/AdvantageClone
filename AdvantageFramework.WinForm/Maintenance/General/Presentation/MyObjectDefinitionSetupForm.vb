Namespace Maintenance.General.Presentation

    Public Class MyObjectDefinitionSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _AgencyImportPath As String = ""
        Protected _IsAgencyASP As Boolean = False

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
            Dim MyObjectDefaultObjectType As Integer = Nothing

            If ComboBoxForm_ObjectType.HasASelectedValue Then

                MyObjectDefaultObjectType = ComboBoxForm_ObjectType.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewForm_MyObjectDefinitionObjects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MyObjectDefinitionObject.LoadByType(DbContext, MyObjectDefaultObjectType)
                                                                             Where Entity.IsInactive Is Nothing OrElse
                                                                                   Entity.IsInactive = False
                                                                             Select Entity).ToList

                End Using

                DataGridViewForm_MyObjectDefinitionObjects.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub LoadMyObjectDefinitions()

            'objects
            Dim ObjectID As Integer = Nothing

            If DataGridViewForm_MyObjectDefinitionObjects.HasOnlyOneSelectedRow Then

                ObjectID = DataGridViewForm_MyObjectDefinitionObjects.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewForm_MyObjectDefinitions.DataSource = AdvantageFramework.Database.Procedures.MyObjectDefinitionComplexType.Load(DbContext, ObjectID, False).ToList

                End Using

                DataGridViewForm_MyObjectDefinitions.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MyObjectDefinitionSetupForm As AdvantageFramework.Maintenance.General.Presentation.MyObjectDefinitionSetupForm = Nothing

            MyObjectDefinitionSetupForm = New AdvantageFramework.Maintenance.General.Presentation.MyObjectDefinitionSetupForm()

            MyObjectDefinitionSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MyObjectDefinitionSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ComboBoxForm_ObjectType.ByPassUserEntryChanged = True

            ComboBoxForm_ObjectType.DataSource = (From Entity In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.ObjectType))
                                                  Select [Key] = Entity.Key,
                                                         [Value] = Entity.Value).ToList

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                LoadMyObjectDefinitions()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()


            'DataGridViewForm_MyObjectDefinitionObjects.ItemDescription = "My Dashboard Definition Dashboard(s)"

            'DataGridViewForm_MyObjectDefinitions.ItemDescription = "My Dashboard Definition Dashboard(s)"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_ObjectType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_ObjectType.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadGrid()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_MyObjectDefinitionObjects_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_MyObjectDefinitionObjects.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadMyObjectDefinitions()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewForm_MyObjectDefinitions_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_MyObjectDefinitions.CellValueChangingEvent

            'objects
            Dim MyObjectDefinition As AdvantageFramework.Database.Classes.MyObjectDefinition = Nothing
            Dim MyObjectDefinitionSetting As AdvantageFramework.Database.Entities.MyObjectDefinitionSetting = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.MyObjectDefinition.Properties.Checked.ToString Then

                Try

                    MyObjectDefinition = DataGridViewForm_MyObjectDefinitions.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    MyObjectDefinition = Nothing
                End Try

                If MyObjectDefinition IsNot Nothing Then

                    Try

                        MyObjectDefinition.Checked = CBool(e.Value)

                    Catch ex As Exception
                        MyObjectDefinition.Checked = MyObjectDefinition.Checked
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            MyObjectDefinitionSetting = AdvantageFramework.Database.Procedures.MyObjectDefinitionSetting.LoadByID(DbContext, MyObjectDefinition.ObjectDefinitionID)

                            If MyObjectDefinitionSetting IsNot Nothing Then

                                MyObjectDefinitionSetting.Checked = MyObjectDefinition.Checked

                                Saved = AdvantageFramework.Database.Procedures.MyObjectDefinitionSetting.Update(DbContext, MyObjectDefinitionSetting)

                            Else

                                MyObjectDefinitionSetting = New AdvantageFramework.Database.Entities.MyObjectDefinitionSetting

                                MyObjectDefinitionSetting.ObjectID = MyObjectDefinition.ObjectID
                                MyObjectDefinitionSetting.DefinitionID = MyObjectDefinition.DefinitionID
                                MyObjectDefinitionSetting.IsStatic = MyObjectDefinition.IsStatic
                                MyObjectDefinitionSetting.Checked = MyObjectDefinition.Checked
                                MyObjectDefinitionSetting.DbContext = DbContext

                                If AdvantageFramework.Database.Procedures.MyObjectDefinitionSetting.Insert(DbContext, MyObjectDefinitionSetting) Then

                                    Saved = True

                                    LoadMyObjectDefinitions()

                                End If

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace