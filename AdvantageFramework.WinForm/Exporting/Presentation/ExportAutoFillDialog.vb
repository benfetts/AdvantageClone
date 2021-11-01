Namespace Exporting.Presentation

    Public Class ExportAutoFillDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedItemIndex As Integer = 0
        Private _NumberOfItems As Integer = 0
        Private _ExportedItems As IEnumerable = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ExportedItems As IEnumerable
            Get
                ExportedItems = _ExportedItems
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ExportedItems As IEnumerable)

            ' This call is required by the designer.
            InitializeComponent()

            _ExportedItems = ExportedItems

        End Sub
        Private Sub LoadObject()

            'objects
            Dim SelectedObject = Nothing
            Dim ExportedItem As Object = Nothing

            If RadioButtonControlForm_FromBlank.Checked Then

                Try

                    ExportedItem = (From Item In _ExportedItems
                                    Select Item).FirstOrDefault

                Catch ex As Exception
                    ExportedItem = Nothing
                End Try

                If ExportedItem IsNot Nothing Then
                    
                    Try

                        If ExportedItem.GetType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                            SelectedObject = System.Activator.CreateInstance(ExportedItem.GetType)

                        End If

                    Catch ex As Exception
                        SelectedObject = Nothing
                    End Try

                End If

            Else

                Try

                    ExportedItem = _ExportedItems(_SelectedItemIndex)

                Catch ex As Exception
                    ExportedItem = Nothing
                End Try

                If ExportedItem IsNot Nothing Then

                    Try

                        SelectedObject = ExportedItem

                    Catch ex As Exception
                        SelectedObject = Nothing
                    End Try

                End If

            End If

            PropertyGridControlForm_Properties.SelectedObject = SelectedObject

        End Sub
        Private Sub EnableOrDisableActions()

            If RadioButtonControlForm_FromBlank.Checked Then

                ButtonForm_SelectFirst.Visible = False
                ButtonForm_SelectLast.Visible = False
                ButtonForm_SelectNext.Visible = False
                ButtonForm_SelectPrevious.Visible = False

            Else

                ButtonForm_SelectFirst.Visible = True
                ButtonForm_SelectLast.Visible = True
                ButtonForm_SelectNext.Visible = True
                ButtonForm_SelectPrevious.Visible = True

                ButtonForm_SelectFirst.Enabled = Convert.ToBoolean(_SelectedItemIndex)
                ButtonForm_SelectLast.Enabled = If(_SelectedItemIndex + 1 < _NumberOfItems, True, False)
                ButtonForm_SelectNext.Enabled = If(_SelectedItemIndex + 1 < _NumberOfItems, True, False)
                ButtonForm_SelectPrevious.Enabled = Convert.ToBoolean(_SelectedItemIndex)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ExportedItems As IEnumerable) As System.Windows.Forms.DialogResult

            'objects
            Dim ExportAutoFillDialog As AdvantageFramework.Exporting.Presentation.ExportAutoFillDialog = Nothing

            ExportAutoFillDialog = New AdvantageFramework.Exporting.Presentation.ExportAutoFillDialog(ExportedItems)

            ShowFormDialog = ExportAutoFillDialog.ShowDialog()

            ExportedItems = ExportAutoFillDialog.ExportedItems

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExpenseImportTemplateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _NumberOfItems = (From Item In _ExportedItems _
                              Select Item).Count

            RadioButtonControlForm_FromBlank.Checked = True

            PropertyGridControlForm_Properties.ControlType = WinForm.Presentation.Controls.PropertyGridControl.ControlTypes.ExportTemplate

            PropertyGridControlForm_Properties.AutoFilterLookupColumns = True
            PropertyGridControlForm_Properties.AutoloadRepositoryDatasource = True

            LoadObject()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim SelectedObject As Object = Nothing
            Dim Value As Object = Nothing
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If Me.Validator Then

                SelectedObject = PropertyGridControlForm_Properties.SelectedObject

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each ExportItem In (From Entity In _ExportedItems _
                                        Select Entity).ToList

                    For Each PropertyDescriptor In PropertyDescriptors

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                        If PropertyGridControlForm_Properties.VisibleRows.OfType(Of DevExpress.XtraVerticalGrid.Rows.EditorRow).Any(Function(EditorRow) EditorRow.Properties.FieldName = PropertyDescriptor.Name) Then

                            Value = PropertyDescriptor.GetValue(SelectedObject)

                            If Value IsNot Nothing Then

                                Try

                                    If Value.GetType Is GetType(String) Then

                                        If String.IsNullOrEmpty(Value) = False Then

                                            PropertyDescriptor.SetValue(ExportItem, PropertyDescriptor.GetValue(SelectedObject))

                                        End If

                                    Else

                                        PropertyDescriptor.SetValue(ExportItem, PropertyDescriptor.GetValue(SelectedObject))

                                    End If

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                Next

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonControlForm_UpdateFromSelected_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonControlForm_UpdateFromSelected.CheckedChanged

            If RadioButtonControlForm_UpdateFromSelected.Checked Then

                LoadObject()

                EnableOrDisableActions()

            End If
            
        End Sub
        Private Sub RadioButtonControlForm_FromBlank_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonControlForm_FromBlank.CheckedChanged

            If RadioButtonControlForm_FromBlank.Checked Then

                LoadObject()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_SelectFirst_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectFirst.Click

            _SelectedItemIndex = 0

            LoadObject()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectLast_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectLast.Click

            If _NumberOfItems > 0 Then

                _SelectedItemIndex = _NumberOfItems - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectNext_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectNext.Click

            If _NumberOfItems > 0 AndAlso _SelectedItemIndex + 1 < _NumberOfItems Then

                _SelectedItemIndex = _SelectedItemIndex + 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectPrevious_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectPrevious.Click

            If _NumberOfItems > 0 AndAlso _SelectedItemIndex - 1 >= 0 Then

                _SelectedItemIndex = _SelectedItemIndex - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()

            EnableOrDisableActions()

        End Sub
        Private Sub PropertyGridControlForm_Properties_ShownEditor(sender As Object, e As System.EventArgs) Handles PropertyGridControlForm_Properties.ShownEditor

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing

            If TypeOf PropertyGridControlForm_Properties.ActiveEditor Is DevExpress.XtraEditors.DateEdit AndAlso _
                    TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Exporting.DataClasses.MediaPlanningData Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, CType(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Exporting.DataClasses.MediaPlanningData).PlanID)

                    Catch ex As Exception
                        MediaPlan = Nothing
                    End Try

                    If MediaPlan IsNot Nothing Then

                        CType(PropertyGridControlForm_Properties.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MinValue = MediaPlan.StartDate
                        CType(PropertyGridControlForm_Properties.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MaxValue = MediaPlan.EndDate

                    End If

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace